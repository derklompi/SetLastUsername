namespace SetLastUsername
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChange = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cbUsernames = new System.Windows.Forms.ComboBox();
            this.cbLR = new System.Windows.Forms.CheckBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsernameID = new System.Windows.Forms.TextBox();
            this.lblWinVer = new System.Windows.Forms.Label();
            this.tbRemotePC = new System.Windows.Forms.TextBox();
            this.btnLoadInfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(95, 160);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(78, 23);
            this.btnChange.TabIndex = 0;
            this.btnChange.Text = "OK";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(74, 91);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Benutzername";
            // 
            // cbUsernames
            // 
            this.cbUsernames.FormattingEnabled = true;
            this.cbUsernames.Location = new System.Drawing.Point(77, 107);
            this.cbUsernames.Name = "cbUsernames";
            this.cbUsernames.Size = new System.Drawing.Size(121, 21);
            this.cbUsernames.TabIndex = 4;
            this.cbUsernames.TextChanged += new System.EventHandler(this.cbUsernames_TextChanged);
            // 
            // cbLR
            // 
            this.cbLR.AutoSize = true;
            this.cbLR.Location = new System.Drawing.Point(11, 109);
            this.cbLR.Name = "cbLR";
            this.cbLR.Size = new System.Drawing.Size(15, 14);
            this.cbLR.TabIndex = 5;
            this.cbLR.UseVisualStyleBackColor = true;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(32, 107);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(22, 20);
            this.txtDomain.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "\\";
            // 
            // txtUsernameID
            // 
            this.txtUsernameID.Enabled = false;
            this.txtUsernameID.Location = new System.Drawing.Point(77, 134);
            this.txtUsernameID.Name = "txtUsernameID";
            this.txtUsernameID.Size = new System.Drawing.Size(285, 20);
            this.txtUsernameID.TabIndex = 9;
            // 
            // lblWinVer
            // 
            this.lblWinVer.AutoSize = true;
            this.lblWinVer.Location = new System.Drawing.Point(29, 141);
            this.lblWinVer.Name = "lblWinVer";
            this.lblWinVer.Size = new System.Drawing.Size(0, 13);
            this.lblWinVer.TabIndex = 10;
            // 
            // tbRemotePC
            // 
            this.tbRemotePC.Location = new System.Drawing.Point(92, 8);
            this.tbRemotePC.Name = "tbRemotePC";
            this.tbRemotePC.Size = new System.Drawing.Size(100, 20);
            this.tbRemotePC.TabIndex = 14;
            // 
            // btnLoadInfo
            // 
            this.btnLoadInfo.Location = new System.Drawing.Point(198, 6);
            this.btnLoadInfo.Name = "btnLoadInfo";
            this.btnLoadInfo.Size = new System.Drawing.Size(78, 23);
            this.btnLoadInfo.TabIndex = 15;
            this.btnLoadInfo.Text = "Load";
            this.btnLoadInfo.UseVisualStyleBackColor = true;
            this.btnLoadInfo.Click += new System.EventHandler(this.btnLoadInfo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // main
            // 
            this.AcceptButton = this.btnChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 210);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadInfo);
            this.Controls.Add(this.tbRemotePC);
            this.Controls.Add(this.lblWinVer);
            this.Controls.Add(this.txtUsernameID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.cbLR);
            this.Controls.Add(this.cbUsernames);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnChange);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.ShowIcon = false;
            this.Text = "Benutzernamen setzen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ComboBox cbUsernames;
        private System.Windows.Forms.CheckBox cbLR;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsernameID;
        private System.Windows.Forms.Label lblWinVer;
        private System.Windows.Forms.TextBox tbRemotePC;
        private System.Windows.Forms.Button btnLoadInfo;
        private System.Windows.Forms.Button button1;
    }
}

