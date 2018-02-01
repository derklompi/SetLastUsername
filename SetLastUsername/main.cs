using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;
using System.Management;


namespace SetLastUsername
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();           
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool adminRights;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            adminRights = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if(adminRights)
            {
                string username;
                if(cbLR.Checked && txtDomain.Text != "")
                {
                    username = txtDomain.Text + "\\" + cbUsernames.Text;
                }
                else
                {
                    username = cbUsernames.Text;
                }
                string userID;
                userID = txtUsernameID.Text;

                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Authentication\\LogonUI", true);
                key.SetValue("LastLoggedOnSAMUser", username);
                key.SetValue("LastLoggedOnUser", username);
                key.SetValue("LastLoggedOnDisplayName", "");

                if (lblWinVer.Text == "W10")
                {
                    key.SetValue("LastLoggedOnUserSID", userID);
                    key.SetValue("SelectedUserSID", userID);
                }

                string lastSam;
                string lastUser;

                lastSam = Convert.ToString(key.GetValue("LastLoggedOnSAMUser"));
                lastUser = Convert.ToString(key.GetValue("LastLoggedOnUser"));
             
                if (lastSam == username && lastUser == username)
                {
                    MessageBox.Show("Der Benutzer " + username + " wurde erfolgreich eingetragen");
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Bitte als Administrator ausführen");
            }       
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Programm beenden?", "Beenden", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                e.Cancel = true;
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            int WinMajorVersion = Environment.OSVersion.Version.Major;
            switch (WinMajorVersion)
            {
                case 6:
                    lblWinVer.Text = "W7";
                    break;
                case 10:
                    lblWinVer.Text = "W10";
                    break;
                default:
                    lblWinVer.Text = "??";
                    break;
            }

            string[] files = Directory.GetDirectories(@"C:\\Users\");
            foreach (string item in files)
            {
                FileInfo f = new FileInfo(item);
                cbUsernames.Items.Add(f.Name);
            }

            cbUsernames.Items.Remove("Administrator");
            cbUsernames.Items.Remove("All Users");
            cbUsernames.Items.Remove("Default");
            cbUsernames.Items.Remove("Default User");
            cbUsernames.Items.Remove("Public");

            string result = System.Environment.UserDomainName;
            txtDomain.Text = result;
        }

        private void cbUsernames_TextChanged(object sender, EventArgs e)
        {
            if (cbUsernames.Text !="")
            {
                string a = "C:\\Users\\" + cbUsernames.Text;
                ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_UserProfile");

                foreach (ManagementObject mo in query.Get())
                {
                    if (mo["LocalPath"].ToString() == a)
                    {
                        txtUsernameID.Text = mo["SID"].ToString();
                    }
                }
            }
            
        }
    }
}
