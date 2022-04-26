
namespace ControlModul.DBControl.SQL
{
    partial class SQLConnectionForm
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
            this.components = new System.ComponentModel.Container();
            this.cbox_ServerList = new System.Windows.Forms.ComboBox();
            this.l_servers = new System.Windows.Forms.Label();
            this.l_databases = new System.Windows.Forms.Label();
            this.cbox_DatabaseList = new System.Windows.Forms.ComboBox();
            this.gbox_Login = new System.Windows.Forms.GroupBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.l_pass = new System.Windows.Forms.Label();
            this.l_userName = new System.Windows.Forms.Label();
            this.gbox_ServersAndDatabases = new System.Windows.Forms.GroupBox();
            this.checkBox_TrustedConnection = new System.Windows.Forms.CheckBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.l_status = new System.Windows.Forms.Label();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_Test = new System.Windows.Forms.Button();
            this.gbox_DirectConnectionString = new System.Windows.Forms.GroupBox();
            this.l_directlink = new System.Windows.Forms.Label();
            this.txt_ConnectionString = new System.Windows.Forms.TextBox();
            this.checkBox_UseDirectLink = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.pictureBoxSQL = new System.Windows.Forms.PictureBox();
            this.gbox_Login.SuspendLayout();
            this.gbox_ServersAndDatabases.SuspendLayout();
            this.gbox_DirectConnectionString.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSQL)).BeginInit();
            this.SuspendLayout();
            // 
            // cbox_ServerList
            // 
            this.cbox_ServerList.FormattingEnabled = true;
            this.cbox_ServerList.Location = new System.Drawing.Point(9, 32);
            this.cbox_ServerList.Name = "cbox_ServerList";
            this.cbox_ServerList.Size = new System.Drawing.Size(327, 21);
            this.cbox_ServerList.TabIndex = 0;
            this.cbox_ServerList.SelectedIndexChanged += new System.EventHandler(this.cbox_ServerList_SelectedIndexChanged);
            // 
            // l_servers
            // 
            this.l_servers.AutoSize = true;
            this.l_servers.Location = new System.Drawing.Point(155, 16);
            this.l_servers.Name = "l_servers";
            this.l_servers.Size = new System.Drawing.Size(53, 13);
            this.l_servers.TabIndex = 1;
            this.l_servers.Text = "Server list";
            // 
            // l_databases
            // 
            this.l_databases.AutoSize = true;
            this.l_databases.Location = new System.Drawing.Point(155, 69);
            this.l_databases.Name = "l_databases";
            this.l_databases.Size = new System.Drawing.Size(68, 13);
            this.l_databases.TabIndex = 2;
            this.l_databases.Text = "Database list";
            // 
            // cbox_DatabaseList
            // 
            this.cbox_DatabaseList.FormattingEnabled = true;
            this.cbox_DatabaseList.Location = new System.Drawing.Point(9, 85);
            this.cbox_DatabaseList.Name = "cbox_DatabaseList";
            this.cbox_DatabaseList.Size = new System.Drawing.Size(327, 21);
            this.cbox_DatabaseList.TabIndex = 1;
            // 
            // gbox_Login
            // 
            this.gbox_Login.Controls.Add(this.txt_Password);
            this.gbox_Login.Controls.Add(this.txt_Username);
            this.gbox_Login.Controls.Add(this.l_pass);
            this.gbox_Login.Controls.Add(this.l_userName);
            this.gbox_Login.Location = new System.Drawing.Point(15, 163);
            this.gbox_Login.Name = "gbox_Login";
            this.gbox_Login.Size = new System.Drawing.Size(427, 97);
            this.gbox_Login.TabIndex = 4;
            this.gbox_Login.TabStop = false;
            this.gbox_Login.Text = "Login";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(76, 49);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '•';
            this.txt_Password.Size = new System.Drawing.Size(344, 20);
            this.txt_Password.TabIndex = 4;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(77, 20);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(344, 20);
            this.txt_Username.TabIndex = 3;
            // 
            // l_pass
            // 
            this.l_pass.AutoSize = true;
            this.l_pass.Location = new System.Drawing.Point(12, 49);
            this.l_pass.Name = "l_pass";
            this.l_pass.Size = new System.Drawing.Size(56, 13);
            this.l_pass.TabIndex = 1;
            this.l_pass.Text = "Password:";
            // 
            // l_userName
            // 
            this.l_userName.AutoSize = true;
            this.l_userName.Location = new System.Drawing.Point(12, 20);
            this.l_userName.Name = "l_userName";
            this.l_userName.Size = new System.Drawing.Size(58, 13);
            this.l_userName.TabIndex = 0;
            this.l_userName.Text = "Username:";
            // 
            // gbox_ServersAndDatabases
            // 
            this.gbox_ServersAndDatabases.Controls.Add(this.l_servers);
            this.gbox_ServersAndDatabases.Controls.Add(this.cbox_ServerList);
            this.gbox_ServersAndDatabases.Controls.Add(this.cbox_DatabaseList);
            this.gbox_ServersAndDatabases.Controls.Add(this.l_databases);
            this.gbox_ServersAndDatabases.Location = new System.Drawing.Point(15, 12);
            this.gbox_ServersAndDatabases.Name = "gbox_ServersAndDatabases";
            this.gbox_ServersAndDatabases.Size = new System.Drawing.Size(344, 117);
            this.gbox_ServersAndDatabases.TabIndex = 5;
            this.gbox_ServersAndDatabases.TabStop = false;
            this.gbox_ServersAndDatabases.Text = "Server and Databases";
            // 
            // checkBox_TrustedConnection
            // 
            this.checkBox_TrustedConnection.AutoSize = true;
            this.checkBox_TrustedConnection.Location = new System.Drawing.Point(15, 140);
            this.checkBox_TrustedConnection.Name = "checkBox_TrustedConnection";
            this.checkBox_TrustedConnection.Size = new System.Drawing.Size(141, 17);
            this.checkBox_TrustedConnection.TabIndex = 2;
            this.checkBox_TrustedConnection.Text = "Use Trusted Connection";
            this.checkBox_TrustedConnection.UseVisualStyleBackColor = true;
            this.checkBox_TrustedConnection.CheckedChanged += new System.EventHandler(this.checkBox_TrustedConnection_CheckedChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_OK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_OK.Location = new System.Drawing.Point(0, 402);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(454, 46);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "Save";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_status.Location = new System.Drawing.Point(23, 366);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(60, 15);
            this.l_status.TabIndex = 8;
            this.l_status.Text = "Status: -";
            // 
            // btn_Reload
            // 
            this.btn_Reload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Reload.Location = new System.Drawing.Point(406, 357);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(44, 38);
            this.btn_Reload.TabIndex = 8;
            this.btn_Reload.Text = "⟳";
            this.toolTip.SetToolTip(this.btn_Reload, "Reload servers...");
            this.btn_Reload.UseVisualStyleBackColor = false;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_Test
            // 
            this.btn_Test.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Test.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Test.Location = new System.Drawing.Point(356, 357);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(44, 38);
            this.btn_Test.TabIndex = 7;
            this.btn_Test.Text = "T";
            this.toolTip.SetToolTip(this.btn_Test, "Test connection...");
            this.btn_Test.UseVisualStyleBackColor = false;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // gbox_DirectConnectionString
            // 
            this.gbox_DirectConnectionString.Controls.Add(this.btnShowPassword);
            this.gbox_DirectConnectionString.Controls.Add(this.l_directlink);
            this.gbox_DirectConnectionString.Controls.Add(this.txt_ConnectionString);
            this.gbox_DirectConnectionString.Location = new System.Drawing.Point(12, 295);
            this.gbox_DirectConnectionString.Name = "gbox_DirectConnectionString";
            this.gbox_DirectConnectionString.Size = new System.Drawing.Size(423, 56);
            this.gbox_DirectConnectionString.TabIndex = 11;
            this.gbox_DirectConnectionString.TabStop = false;
            this.gbox_DirectConnectionString.Text = "Direct link";
            // 
            // l_directlink
            // 
            this.l_directlink.AutoSize = true;
            this.l_directlink.Location = new System.Drawing.Point(6, 22);
            this.l_directlink.Name = "l_directlink";
            this.l_directlink.Size = new System.Drawing.Size(92, 13);
            this.l_directlink.TabIndex = 5;
            this.l_directlink.Text = "Connection string:";
            // 
            // txt_ConnectionString
            // 
            this.txt_ConnectionString.Location = new System.Drawing.Point(104, 19);
            this.txt_ConnectionString.Name = "txt_ConnectionString";
            this.txt_ConnectionString.Size = new System.Drawing.Size(284, 20);
            this.txt_ConnectionString.TabIndex = 6;
            this.txt_ConnectionString.UseSystemPasswordChar = true;
            this.txt_ConnectionString.TextChanged += new System.EventHandler(this.txt_ConnectionString_TextChanged);
            // 
            // checkBox_UseDirectLink
            // 
            this.checkBox_UseDirectLink.AutoSize = true;
            this.checkBox_UseDirectLink.Location = new System.Drawing.Point(15, 266);
            this.checkBox_UseDirectLink.Name = "checkBox_UseDirectLink";
            this.checkBox_UseDirectLink.Size = new System.Drawing.Size(99, 17);
            this.checkBox_UseDirectLink.TabIndex = 5;
            this.checkBox_UseDirectLink.Text = "Use Direct Link";
            this.checkBox_UseDirectLink.UseVisualStyleBackColor = true;
            this.checkBox_UseDirectLink.CheckedChanged += new System.EventHandler(this.checkBox_UseDirectLink_CheckedChanged);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.BackgroundImage = global::ControlModul.Properties.Resources.Eye_Scan_icon;
            this.btnShowPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowPassword.Location = new System.Drawing.Point(397, 19);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(20, 20);
            this.btnShowPassword.TabIndex = 14;
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // pictureBoxSQL
            // 
            this.pictureBoxSQL.Image = global::ControlModul.Properties.Resources.sql_logo;
            this.pictureBoxSQL.Location = new System.Drawing.Point(365, 28);
            this.pictureBoxSQL.Name = "pictureBoxSQL";
            this.pictureBoxSQL.Size = new System.Drawing.Size(85, 79);
            this.pictureBoxSQL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSQL.TabIndex = 13;
            this.pictureBoxSQL.TabStop = false;
            // 
            // SQLConnectionForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 448);
            this.Controls.Add(this.pictureBoxSQL);
            this.Controls.Add(this.checkBox_UseDirectLink);
            this.Controls.Add(this.gbox_DirectConnectionString);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.checkBox_TrustedConnection);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.l_status);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbox_ServersAndDatabases);
            this.Controls.Add(this.gbox_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SQLConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SQLConnectionFom_FormClosing);
            this.Load += new System.EventHandler(this.SQLConnectionFom_Load);
            this.gbox_Login.ResumeLayout(false);
            this.gbox_Login.PerformLayout();
            this.gbox_ServersAndDatabases.ResumeLayout(false);
            this.gbox_ServersAndDatabases.PerformLayout();
            this.gbox_DirectConnectionString.ResumeLayout(false);
            this.gbox_DirectConnectionString.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSQL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_ServerList;
        private System.Windows.Forms.Label l_servers;
        private System.Windows.Forms.Label l_databases;
        private System.Windows.Forms.ComboBox cbox_DatabaseList;
        private System.Windows.Forms.GroupBox gbox_Login;
        private System.Windows.Forms.GroupBox gbox_ServersAndDatabases;
        private System.Windows.Forms.CheckBox checkBox_TrustedConnection;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Label l_pass;
        private System.Windows.Forms.Label l_userName;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.GroupBox gbox_DirectConnectionString;
        private System.Windows.Forms.Label l_directlink;
        private System.Windows.Forms.TextBox txt_ConnectionString;
        private System.Windows.Forms.CheckBox checkBox_UseDirectLink;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pictureBoxSQL;
        private System.Windows.Forms.Button btnShowPassword;
    }
}