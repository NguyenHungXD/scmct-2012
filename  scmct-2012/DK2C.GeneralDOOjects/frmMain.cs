using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DK2C.DataAccess.Win;
using System.IO;

namespace DK2C.GeneralDOOjects
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.txtPassword.PasswordChar = (char)0x25CF;
            ReadKeys();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool ok=true;
            if (string.IsNullOrEmpty(txtNameSpace.Text))
            {
                errorProvider1.SetError(this.txtNameSpace, "Prefix NameSpace cannot empty!");
                ok=false;
            }
            if (string.IsNullOrEmpty(txtSaveTo.Text)||Directory.Exists(txtSaveTo.Text)==false)
            {
                errorProvider1.SetError(this.txtSaveTo, "Please chose correct folder to save!");
                ok=false;
            }
            if (ok == false)
            {
                MessageBox.Show("Please enter data correctly!");
                return;

            }
            SQLConnectWin.NewConnect(txtServer.Text.Trim(), txtDatabase.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text);
            if (SQLConnectWin.BeginConnect() == false)
            {
                MessageBox.Show("Cannot connect to SQLServer, please check connection information!");
                return;
            }
            WriteKeys();
            DataTable dt = SQLConnectWin.GetTable(" SELECT NAME  FROM SYSOBJECTS WHERE TYPE='U' AND NAME NOT LIKE '%PROPER%' AND NAME NOT LIKE 'SYS%' AND NAME NOT IN ('sysdiagrams')");
            if (dt != null)
            {
                string folder = txtSaveTo.Text + "\\" + txtNameSpace.Text .Trim()+ ".Objects";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                int toltal = dt.Rows.Count;
                int i = 1;
                lblCount.Visible = true;
                lblNotice.Visible = true;
                lblSubject.Visible = true;
                foreach (DataRow rtble in dt.Rows)
                {
                    Application.DoEvents();
                    lblSubject.Text = "Please wait a moment...";
                    lblCount.Text = i + "/" + toltal;
                    lblNotice.Text = "Creating class \"" + rtble[0] + "\"...";
                    
                    CreateDOObjectsForWeb.CreateFileClass(txtNameSpace.Text.Trim(), rtble[0].ToString(), folder);
                    i++;
                }
                Application.DoEvents();
                lblNotice.Text = "Creating class \"TBLS\"...";
                CreateDOObjectsForWeb.CreateStaticClass(txtNameSpace.Text.Trim(), dt, txtSaveTo.Text);
                lblSubject.Text = "Finish!";
                lblNotice.Text = folder + " was created!";
                MessageBox.Show("Success Full \r\n " + folder);
            }
            return;
        }
        protected void WriteKeys()
        {
            ConnectSetting.Default.ServerName = txtServer.Text;
            ConnectSetting.Default.Databasename = txtDatabase.Text;
            ConnectSetting.Default.LoginName = txtUserName.Text;
            ConnectSetting.Default.LoginPassword = txtPassword.Text;
            ConnectSetting.Default.PrefixNameSpace = txtNameSpace.Text;
            ConnectSetting.Default.SelectedPath = txtSaveTo.Text;
            ConnectSetting.Default.Save();
        }
        protected void ReadKeys()
        {
            try
            {
                txtServer.Text = ConnectSetting.Default.ServerName;
                txtDatabase.Text = ConnectSetting.Default.Databasename;
                txtUserName.Text = ConnectSetting.Default.LoginName;
                txtPassword.Text = ConnectSetting.Default.LoginPassword;
                txtNameSpace.Text = ConnectSetting.Default.PrefixNameSpace;
                txtSaveTo.Text = ConnectSetting.Default.SelectedPath;
            }
            catch { }
           
        }


        private void btnSaveTo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                txtSaveTo.Text = fd.SelectedPath;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSaveTo.Text) || Directory.Exists(txtSaveTo.Text) == false)
            {
                MessageBox.Show("Cannot open folder!");
                return;
            }
            System.Diagnostics.Process.Start(txtSaveTo.Text.Trim());
        }
    }
}
