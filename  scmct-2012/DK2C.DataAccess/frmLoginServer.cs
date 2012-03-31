namespace DK2C.DataAccess.Win
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Windows.Forms;

    public class frmLoginServer : Form
    {
        private ImageList _imageList;
        private Button btnExit;
        private Button btnOK;
        private IContainer components = null;
        public static bool isConnect = false;
        private Label lbDataBase;
        private Label lbLoginName;
        private Label lbPass;
        private Label lbServer;
        private LinkLabel lbSqlExpress;
        private RadioButton rdChiness;
        private RadioButton rdEnlish;
        private RadioButton rdVietNam;
        public ComboBox txtDatabase;
        public TextBox txtLoginname;
        public TextBox txtPas;
        public ComboBox txtServer;

        public frmLoginServer()
        {
            this.InitializeComponent();
            this.rdChiness.CheckedChanged += new EventHandler(this.rdLabguage_checked);
            this.rdEnlish.CheckedChanged += new EventHandler(this.rdLabguage_checked);
            this.rdVietNam.CheckedChanged += new EventHandler(this.rdLabguage_checked);
            base.Load += new EventHandler(this.frmLoginServer_Load);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            isConnect = false;
            base.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((this.txtServer.Text.Trim() != "") && (this.txtDatabase.Text.Trim() != ""))
            {
                SQLConnectWin.NewConnect(this.txtServer.Text, this.txtDatabase.Text, this.txtLoginname.Text, this.txtPas.Text);
                if (!SQLConnectWin.BeginConnect())
                {
                    isConnect = false;
                    this.txtPas.Select();
                    this.txtPas.SelectAll();
                    switch (this.nLanguage)
                    {
                        case 1:
                            if (MessageBox.Show("Kh\x00f4ng thể kết nối CSDL\r\n Bạn muốn kết th\x00fac?", "Lỗi kết nối!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Application.Exit();
                            }
                            return;

                        case 2:
                            if (MessageBox.Show("Can not Connect Database\r\n Do you want exit?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Application.Exit();
                            }
                            return;

                        case 3:
                            if (MessageBox.Show("附帶\r\n 附帶?", "附帶", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Application.Exit();
                            }
                            return;
                    }
                }
                else
                {
                    isConnect = true;
                    if ((ConnectSetting.Default.ArrServerName == null) || (ConnectSetting.Default.ArrServerName == ""))
                    {
                        ConnectSetting.Default.ArrServerName = this.txtServer.Text;
                    }
                    else if (Array.IndexOf<string>(ConnectSetting.Default.ArrServerName.Split(new char[] { ',' }), this.txtServer.Text.Trim()) == -1)
                    {
                        ConnectSetting setting1 = ConnectSetting.Default;
                        setting1.ArrServerName = setting1.ArrServerName + "," + this.txtServer.Text.Trim();
                    }
                    if ((ConnectSetting.Default.ArrDatabaseName == null) || (ConnectSetting.Default.ArrDatabaseName == ""))
                    {
                        ConnectSetting.Default.ArrDatabaseName = this.txtDatabase.Text;
                    }
                    else if (Array.IndexOf<string>(ConnectSetting.Default.ArrDatabaseName.Split(new char[] { ',' }), this.txtDatabase.Text.Trim()) == -1)
                    {
                        ConnectSetting setting2 = ConnectSetting.Default;
                        setting2.ArrDatabaseName = setting2.ArrDatabaseName + "," + this.txtDatabase.Text.Trim();
                    }
                    ConnectSetting.Default.Save();
                    base.Close();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FixRadioText()
        {
            this.rdChiness.Font = new Font("MS Song", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rdEnlish.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.rdVietNam.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        private void frmLoginServer_Load(object sender, EventArgs e)
        {
            isConnect = false;
            switch (this.nLanguage)
            {
                case 1:
                    this.rdVietNam.Checked = true;
                    break;

                case 2:
                    this.rdEnlish.Checked = true;
                    break;

                case 3:
                    this.rdChiness.Checked = true;
                    break;
            }
            this.RefeshLanguageText();
            this.txtServer.Items.Clear();
            if ((ConnectSetting.Default.ArrServerName != null) && (ConnectSetting.Default.ArrServerName != ""))
            {
                string[] items = ConnectSetting.Default.ArrServerName.Split(new char[] { ',' });
                this.txtServer.Items.AddRange(items);
            }
            this.txtDatabase.Items.Clear();
            if ((ConnectSetting.Default.ArrDatabaseName != null) && (ConnectSetting.Default.ArrDatabaseName != ""))
            {
                string[] strArray2 = ConnectSetting.Default.ArrDatabaseName.Split(new char[] { ',' });
                this.txtDatabase.Items.AddRange(strArray2);
            }
            base.Shown += new EventHandler(this.frmLoginServer_Shown);
        }

        private void frmLoginServer_Shown(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmLoginServer));
            this.txtPas = new TextBox();
            this.txtLoginname = new TextBox();
            this.btnOK = new Button();
            this._imageList = new ImageList(this.components);
            this.btnExit = new Button();
            this.lbDataBase = new Label();
            this.lbPass = new Label();
            this.lbLoginName = new Label();
            this.lbServer = new Label();
            this.rdVietNam = new RadioButton();
            this.rdEnlish = new RadioButton();
            this.rdChiness = new RadioButton();
            this.lbSqlExpress = new LinkLabel();
            this.txtServer = new ComboBox();
            this.txtDatabase = new ComboBox();
            base.SuspendLayout();
            this.txtPas.Location = new Point(100, 0x5b);
            this.txtPas.Name = "txtPas";
            this.txtPas.PasswordChar = '*';
            this.txtPas.Size = new Size(0xd0, 0x16);
            this.txtPas.TabIndex = 13;
            this.txtLoginname.Location = new Point(100, 0x41);
            this.txtLoginname.Name = "txtLoginname";
            this.txtLoginname.Size = new Size(0xd0, 0x16);
            this.txtLoginname.TabIndex = 12;
            this.btnOK.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnOK.ImageIndex = 13;
            this.btnOK.ImageList = this._imageList;
            this.btnOK.Location = new Point(0x8a, 0x90);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x57, 0x19);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "&Cấu h\x00ecnh";
            this.btnOK.TextAlign = ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this._imageList.ImageStream = (ImageListStreamer) manager.GetObject("_imageList.ImageStream");
            this._imageList.TransparentColor = Color.Transparent;
            this._imageList.Images.SetKeyName(0, "");
            this._imageList.Images.SetKeyName(1, "");
            this._imageList.Images.SetKeyName(2, "");
            this._imageList.Images.SetKeyName(3, "");
            this._imageList.Images.SetKeyName(4, "");
            this._imageList.Images.SetKeyName(5, "");
            this._imageList.Images.SetKeyName(6, "");
            this._imageList.Images.SetKeyName(7, "");
            this._imageList.Images.SetKeyName(8, "");
            this._imageList.Images.SetKeyName(9, "");
            this._imageList.Images.SetKeyName(10, "");
            this._imageList.Images.SetKeyName(11, "");
            this._imageList.Images.SetKeyName(12, "");
            this._imageList.Images.SetKeyName(13, "");
            this._imageList.Images.SetKeyName(14, "");
            this._imageList.Images.SetKeyName(15, "");
            this.btnExit.DialogResult = DialogResult.Cancel;
            this.btnExit.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 14;
            this.btnExit.ImageList = this._imageList;
            this.btnExit.Location = new Point(0xe0, 0x90);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x57, 0x19);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "&Tho\x00e1t";
            this.btnExit.TextAlign = ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.lbDataBase.AutoSize = true;
            this.lbDataBase.Location = new Point(5, 40);
            this.lbDataBase.Name = "lbDataBase";
            this.lbDataBase.Size = new Size(0x3d, 14);
            this.lbDataBase.TabIndex = 0x11;
            this.lbDataBase.Text = "T\x00ean CSDL";
            this.lbPass.AutoSize = true;
            this.lbPass.Location = new Point(5, 0x5d);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new Size(0x39, 14);
            this.lbPass.TabIndex = 9;
            this.lbPass.Text = "Mật khẩu";
            this.lbLoginName.AutoSize = true;
            this.lbLoginName.Location = new Point(5, 0x41);
            this.lbLoginName.Name = "lbLoginName";
            this.lbLoginName.Size = new Size(0x5b, 14);
            this.lbLoginName.TabIndex = 0x12;
            this.lbLoginName.Text = "T\x00ean đăng nhập";
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new Point(5, 15);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new Size(0x54, 14);
            this.lbServer.TabIndex = 0x10;
            this.lbServer.Text = "IP/T\x00ean Server";
            this.rdVietNam.AutoSize = true;
            this.rdVietNam.Checked = true;
            this.rdVietNam.Location = new Point(0x1d, 120);
            this.rdVietNam.Name = "rdVietNam";
            this.rdVietNam.Size = new Size(0x52, 0x12);
            this.rdVietNam.TabIndex = 0x13;
            this.rdVietNam.TabStop = true;
            this.rdVietNam.Text = "Tiếng Việt";
            this.rdVietNam.UseVisualStyleBackColor = true;
            this.rdEnlish.AutoSize = true;
            this.rdEnlish.Location = new Point(0x7f, 120);
            this.rdEnlish.Name = "rdEnlish";
            this.rdEnlish.Size = new Size(0x3e, 0x12);
            this.rdEnlish.TabIndex = 20;
            this.rdEnlish.Text = "English";
            this.rdEnlish.UseVisualStyleBackColor = true;
            this.rdChiness.AutoSize = true;
            this.rdChiness.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rdChiness.Location = new Point(0xe2, 120);
            this.rdChiness.Name = "rdChiness";
            this.rdChiness.Size = new Size(50, 20);
            this.rdChiness.TabIndex = 0x15;
            this.rdChiness.Text = "附帶";
            this.rdChiness.UseVisualStyleBackColor = true;
            this.lbSqlExpress.AutoSize = true;
            this.lbSqlExpress.Location = new Point(0xed, 0);
            this.lbSqlExpress.Name = "lbSqlExpress";
            this.lbSqlExpress.Size = new Size(70, 14);
            this.lbSqlExpress.TabIndex = 0x16;
            this.lbSqlExpress.TabStop = true;
            this.lbSqlExpress.Text = "SQLExpress";
            this.lbSqlExpress.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lbSqlExpress_LinkClicked);
            this.txtServer.FormattingEnabled = true;
            this.txtServer.Location = new Point(100, 15);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new Size(0xcf, 0x16);
            this.txtServer.TabIndex = 0;
            this.txtDatabase.FormattingEnabled = true;
            this.txtDatabase.Location = new Point(0x65, 0x27);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new Size(0xce, 0x16);
            this.txtDatabase.TabIndex = 1;
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btnExit;
            base.ClientSize = new Size(0x139, 0xab);
            base.Controls.Add(this.txtDatabase);
            base.Controls.Add(this.txtServer);
            base.Controls.Add(this.lbSqlExpress);
            base.Controls.Add(this.rdChiness);
            base.Controls.Add(this.rdEnlish);
            base.Controls.Add(this.rdVietNam);
            base.Controls.Add(this.txtPas);
            base.Controls.Add(this.txtLoginname);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.lbDataBase);
            base.Controls.Add(this.lbPass);
            base.Controls.Add(this.lbLoginName);
            base.Controls.Add(this.lbServer);
            this.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmLoginServer";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Cấu h\x00ecnh CSDL";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void lbSqlExpress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string hostName = Dns.GetHostName();
            this.txtServer.Text = hostName + @"\SQLEXPRESS";
            this.txtLoginname.Text = "";
            this.txtPas.Text = "";
            this.txtDatabase.Select();
        }

        private void rdLabguage_checked(object sender, EventArgs e)
        {
            this.RefeshLanguageText();
        }

        private void RefeshLanguageText()
        {
            if (this.rdVietNam.Checked)
            {
                this.nLanguage = 1;
                this.Text = "Cấu h\x00ecnh CSDL";
                this.lbServer.Text = "IP/T\x00ean Server";
                this.lbDataBase.Text = "T\x00ean CSDL";
                this.lbLoginName.Text = "T\x00ean đăng nhập";
                this.lbPass.Text = "Mật khẩu";
                this.btnOK.Text = "&Cấu h\x00ecnh";
                this.btnExit.Text = "&Tho\x00e1t";
                this.lbSqlExpress.Text = "SQLExpress";
                this.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.FixRadioText();
            }
            else if (this.rdEnlish.Checked)
            {
                this.nLanguage = 2;
                this.Text = "Config Database";
                this.lbServer.Text = "Server IP/Name";
                this.lbDataBase.Text = "DatabaseName";
                this.lbLoginName.Text = "Login Name";
                this.lbPass.Text = "Login PassWord";
                this.btnOK.Text = "&Config";
                this.btnExit.Text = "&Exit";
                this.lbSqlExpress.Text = "SQLExpress";
                this.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.FixRadioText();
            }
            else if (this.rdChiness.Checked)
            {
                this.nLanguage = 3;
                this.Text = "附帶";
                this.lbServer.Text = "附帶";
                this.lbDataBase.Text = "附帶";
                this.lbLoginName.Text = "附帶";
                this.lbPass.Text = "附帶";
                this.btnOK.Text = "&附帶";
                this.btnExit.Text = "&附帶";
                this.lbSqlExpress.Text = "附帶";
                this.Font = new Font("MS Song", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
                this.FixRadioText();
            }
        }

        private int nLanguage
        {
            get
            {
                return ConnectSetting.Default.nLanguage;
            }
            set
            {
                ConnectSetting.Default.nLanguage = value;
                ConnectSetting.Default.Save();
            }
        }
    }
}

