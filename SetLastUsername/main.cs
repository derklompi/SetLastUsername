﻿using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;
using System.Management;
using Microsoft.Win32;

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

                Microsoft.Win32.RegistryKey LogOnUI;
                LogOnUI = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI", true);

                RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "SBL-NB230");
                RegistryKey rkeyUsers = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI");


                rkeyUsers.SetValue("LastLoggedOnSAMUser", username);
                rkeyUsers.SetValue("LastLoggedOnUser", username);
                rkeyUsers.SetValue("LastLoggedOnDisplayName", "");

                if (lblWinVer.Text == "W10")
                {
                    rkeyUsers.SetValue("LastLoggedOnUserSID", userID);
                    rkeyUsers.SetValue("SelectedUserSID", userID);
                }

                string lastSam;
                string lastUser;
                string lastLSID;
                string lastUSID;

                lastSam = rkeyUsers.GetValue("LastLoggedOnSAMUser").ToString();
                lastUser = rkeyUsers.GetValue("LastLoggedOnUser").ToString();
                lastLSID = rkeyUsers.GetValue("LastLoggedOnUserSID").ToString();
                lastUSID = rkeyUsers.GetValue("SelectedUserSID").ToString();

                int WinMajorVersion = Environment.OSVersion.Version.Major;
                switch (WinMajorVersion)
                {
                    case 6:
                        if (lastSam == username && lastUser == username)
                        {
                            MessageBox.Show("Der Benutzer " + username + " wurde erfolgreich eingetragen");
                            this.Close();

                        }
                        break;
                    case 10:
                        if (lastSam == username && lastUser == username && userID == lastLSID && userID == lastUSID)
                        {
                            MessageBox.Show("Der Benutzer " + username + " wurde erfolgreich eingetragen");
                            this.Close();

                        }
                        break;
                    default:
                        MessageBox.Show("Windows-Version konnte nicht erkannt werden");
                        this.Close();
                        break;
                }
                
            }
            else
            {
                MessageBox.Show("Bitte als Administrator ausführen");
                this.Close();
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
            
        }

        private void cbUsernames_TextChanged(object sender, EventArgs e)
        {
            if (cbUsernames.Text !="")
            {
                string a = @"C:\Users\" + cbUsernames.Text;
                //ManagementScope scope = new ManagementScope(@"\\" + machineId + @"\root\cimv2");
                ManagementScope scope = new ManagementScope(@"\\" + tbRemotePC.Text + @"\root\cimv2");
                scope.Connect();
                SelectQuery query1 = new SelectQuery("SELECT * FROM Win32_UserProfile");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query1);
                // ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_UserProfile");

                foreach (ManagementObject mo in searcher.Get())
                {
                    if (mo["LocalPath"].ToString() == a)
                    {
                        txtUsernameID.Text = mo["SID"].ToString();
                    }
                }
            }
            
        }

        private void btnLoadInfo_Click(object sender, EventArgs e)
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

            string username;
            //ManagementScope scope = new ManagementScope(@"\\" + machineId + @"\root\cimv2");
            ManagementScope scope = new ManagementScope(@"\\" + tbRemotePC.Text + @"\root\cimv2");
            scope.Connect();
            SelectQuery query1 = new SelectQuery("SELECT * FROM Win32_UserProfile");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query1);
            // ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_UserProfile");

            foreach (ManagementObject mo in searcher.Get())
            {
                username = mo["LocalPath"].ToString();
                username = username.Substring(username.LastIndexOf(@"\") + 1);
                cbUsernames.Items.Add(username);
            }

            cbUsernames.Items.Remove("NetworkService");
            cbUsernames.Items.Remove("LocalService");
            cbUsernames.Items.Remove("systemprofile");

            string domain = System.Environment.UserDomainName;
            txtDomain.Text = domain;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "SBL-NB230");
            RegistryKey rkeyUsers = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI");


            MessageBox.Show(rkeyUsers.GetValue("LastLoggedOnSAMUser").ToString());



        }
    }
}
