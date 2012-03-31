namespace DK2C.DataAccess.Win
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmExecSQL : Form
    {
        private ImageList _imageList;
        private Button btnExit;
        private Button btnOK;
        private Button btnOpen;
        private ComboBox cbTableName;
        private IContainer components = null;
        private DataGrid dgView;
        private Label label1;
        private LinkLabel lk_;
        private LinkLabel lk_copyup;
        private LinkLabel lk_Delete;
        private LinkLabel lk_FKeys;
        private LinkLabel lk_from;
        private LinkLabel lk_Select;
        private LinkLabel lk_sp_Columns;
        private LinkLabel lk_sp_PKey;
        private LinkLabel lk_SPFkey;
        private LinkLabel lk_Update;
        private LinkLabel lk_Where;
        private TextBox txtSqlText;

        public frmExecSQL()
        {
            this.InitializeComponent();
            this.cbTableName.KeyDown += new KeyEventHandler(this.cbTableName_KeyDown);
            this.txtSqlText.KeyDown += new KeyEventHandler(this.txtSqlText_KeyDown);
            this.lk_Select.Click += new EventHandler(this.lk_Click);
            this.lk_sp_Columns.Click += new EventHandler(this.lk_Click);
            this.lk_sp_PKey.Click += new EventHandler(this.lk_Click);
            this.lk_SPFkey.Click += new EventHandler(this.lk_Click);
            this.lk_Update.Click += new EventHandler(this.lk_Click);
            this.lk_Where.Click += new EventHandler(this.lk_Click);
            this.lk_Delete.Click += new EventHandler(this.lk_Click);
            this.lk_from.Click += new EventHandler(this.lk_Click);
            this.lk_.Click += new EventHandler(this.lk_Click);
        }

        private void AutoLoadSetting()
        {
        }

        private void AutoMakeGridStyle()
        {
            DataTable dataSource = (DataTable) this.dgView.DataSource;
            if (dataSource != null)
            {
                this.dgView.TableStyles.Clear();
                DataGridTableStyle table = new DataGridTableStyle();
                table.MappingName = dataSource.TableName;
                double num = ((double) this.dgView.Width) / ((double) dataSource.Columns.Count);
                for (int i = 0; i < dataSource.Columns.Count; i++)
                {
                    int num3 = (int) num;
                    if (dataSource.Columns[i].DataType.ToString().IndexOf("Boolean") != -1)
                    {
                        DataGridBoolColumn column = new DataGridBoolColumn();
                        column.ReadOnly = true;
                        column.NullText = "";
                        column.Width = num3;
                        column.Alignment = HorizontalAlignment.Left;
                        column.MappingName = dataSource.Columns[i].ColumnName;
                        column.HeaderText = dataSource.Columns[i].ColumnName;
                        table.GridColumnStyles.Add(column);
                    }
                    else
                    {
                        DataGridTextBoxColumn column2 = new DataGridTextBoxColumn();
                        column2.ReadOnly = true;
                        column2.Format = "";
                        column2.NullText = "";
                        column2.Width = num3;
                        column2.Alignment = HorizontalAlignment.Left;
                        column2.MappingName = dataSource.Columns[i].ColumnName;
                        column2.HeaderText = dataSource.Columns[i].ColumnName;
                        column2.NullText = "";
                        table.GridColumnStyles.Add(column2);
                    }
                }
                this.dgView.TableStyles.Add(table);
                table.BackColor = this.dgView.BackColor;
                table.ForeColor = this.dgView.ForeColor;
                table.HeaderBackColor = this.dgView.HeaderBackColor;
                table.HeaderForeColor = this.dgView.HeaderForeColor;
                table.GridLineColor = this.dgView.GridLineColor;
                table.SelectionBackColor = this.dgView.SelectionBackColor;
                table.SelectionForeColor = this.dgView.SelectionForeColor;
                table.AlternatingBackColor = this.dgView.AlternatingBackColor;
                this.dgView.BorderStyle = BorderStyle.Fixed3D;
                this.dgView.FlatMode = false;
                string captionText = this.dgView.CaptionText;
                DataView defaultView = dataSource.DefaultView;
                int index = captionText.IndexOf(" ,Số lượng: ");
                if (index != -1)
                {
                    captionText = captionText.Remove(index, captionText.Length - index);
                }
                index = captionText.IndexOf("Số lượng: ");
                if (index != -1)
                {
                    captionText = captionText.Remove(index, captionText.Length - index);
                }
                captionText = captionText + " ,Số lượng: " + defaultView.Count.ToString();
                if (captionText == (" ,Số lượng: " + defaultView.Count.ToString()))
                {
                    captionText = " DS,Số lượng: " + defaultView.Count.ToString();
                }
                this.dgView.CaptionText = captionText;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtSqlText.Text.Trim() != "")
            {
                this.txtSqlText.Text = this.txtSqlText.Text.Trim().ToUpper();
                if (this.txtSqlText.Text.IndexOf("SELECT") == 0)
                {
                    DataTable table =SQLConnectWin.GetTable(this.txtSqlText.Text.Trim());
                    if (table != null)
                    {
                        this.dgView.DataSource = table;
                        this.AutoMakeGridStyle();
                    }
                }
                else
                {
                    int num =SQLConnectWin.Exec(this.txtSqlText.Text.Trim());
                    if (num >= 0)
                    {
                        MessageBox.Show("Row Success=" + num.ToString(), "Success");
                    }
                    else
                    {
                        MessageBox.Show("Not Success", "Not Success", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DataTable table =SQLConnectWin.GetTable("SELECT * FROM " + this.cbTableName.Text);
            if (table != null)
            {
                this.dgView.DataSource = table;
                this.AutoMakeGridStyle();
            }
        }

        private void cbTableName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.btnOpen_Click(sender, e);
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

        private void frmExecSQL_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveSetting();
        }

        private void frmExecSQL_Load(object sender, EventArgs e)
        {
            DataTable table =SQLConnectWin.GetTable("SELECT NAME FROM SYSOBJECTS WHERE TYPE='U'");
            if (table != null)
            {
                this.cbTableName.DataSource = table;
                this.cbTableName.DisplayMember = table.Columns[0].ColumnName;
            }
            this.LoadSetting();
            base.FormClosing += new FormClosingEventHandler(this.frmExecSQL_FormClosing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmExecSQL));
            this.label1 = new Label();
            this.txtSqlText = new TextBox();
            this.dgView = new DataGrid();
            this.btnOK = new Button();
            this._imageList = new ImageList(this.components);
            this.btnExit = new Button();
            this.cbTableName = new ComboBox();
            this.btnOpen = new Button();
            this.lk_Select = new LinkLabel();
            this.lk_Update = new LinkLabel();
            this.lk_Delete = new LinkLabel();
            this.lk_sp_Columns = new LinkLabel();
            this.lk_SPFkey = new LinkLabel();
            this.lk_FKeys = new LinkLabel();
            this.lk_sp_PKey = new LinkLabel();
            this.lk_copyup = new LinkLabel();
            this.lk_Where = new LinkLabel();
            this.lk_from = new LinkLabel();
            this.lk_ = new LinkLabel();
            this.dgView.BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL Command Text";
            this.txtSqlText.Location = new Point(1, 0x19);
            this.txtSqlText.Multiline = true;
            this.txtSqlText.Name = "txtSqlText";
            this.txtSqlText.Size = new Size(0x291, 0x6a);
            this.txtSqlText.TabIndex = 0;
            this.dgView.AlternatingBackColor = SystemColors.Info;
            this.dgView.BackColor = Color.GhostWhite;
            this.dgView.BackgroundColor = SystemColors.Window;
            this.dgView.BorderStyle = BorderStyle.None;
            this.dgView.CaptionBackColor = SystemColors.Info;
            this.dgView.CaptionForeColor = SystemColors.InfoText;
            this.dgView.DataMember = "";
            this.dgView.FlatMode = true;
            this.dgView.Font = new Font("Tahoma", 8f);
            this.dgView.GridLineStyle = DataGridLineStyle.None;
            this.dgView.HeaderFont = new Font("Tahoma", 8f, FontStyle.Bold);
            this.dgView.HeaderForeColor = SystemColors.ControlText;
            this.dgView.LinkColor = Color.Teal;
            this.dgView.Location = new Point(1, 0x9f);
            this.dgView.Name = "dgView";
            this.dgView.ParentRowsBackColor = Color.Gainsboro;
            this.dgView.ParentRowsForeColor = Color.MidnightBlue;
            this.dgView.SelectionBackColor = Color.CadetBlue;
            this.dgView.SelectionForeColor = Color.WhiteSmoke;
            this.dgView.Size = new Size(0x291, 0x160);
            this.dgView.TabIndex = 4;
            this.btnOK.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnOK.ImageIndex = 13;
            this.btnOK.ImageList = this._imageList;
            this.btnOK.Location = new Point(0x1fb, 0x85);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
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
            this.btnExit.Location = new Point(0x247, 0x85);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.cbTableName.FormattingEnabled = true;
            this.cbTableName.Location = new Point(1, 0x89);
            this.cbTableName.Name = "cbTableName";
            this.cbTableName.Size = new Size(0xda, 0x15);
            this.cbTableName.TabIndex = 2;
            this.btnOpen.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnOpen.ImageIndex = 8;
            this.btnOpen.ImageList = this._imageList;
            this.btnOpen.Location = new Point(220, 0x89);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new Size(0x4b, 20);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "O&pen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new EventHandler(this.btnOpen_Click);
            this.lk_Select.AutoSize = true;
            this.lk_Select.Location = new Point(0x84, 7);
            this.lk_Select.Name = "lk_Select";
            this.lk_Select.Size = new Size(0x24, 13);
            this.lk_Select.TabIndex = 6;
            this.lk_Select.TabStop = true;
            this.lk_Select.Text = "Select";
            this.lk_Update.AutoSize = true;
            this.lk_Update.Location = new Point(0xae, 8);
            this.lk_Update.Name = "lk_Update";
            this.lk_Update.Size = new Size(0x2a, 13);
            this.lk_Update.TabIndex = 7;
            this.lk_Update.TabStop = true;
            this.lk_Update.Text = "Update";
            this.lk_Delete.AutoSize = true;
            this.lk_Delete.Location = new Point(0xde, 8);
            this.lk_Delete.Name = "lk_Delete";
            this.lk_Delete.Size = new Size(0x26, 13);
            this.lk_Delete.TabIndex = 8;
            this.lk_Delete.TabStop = true;
            this.lk_Delete.Text = "Delete";
            this.lk_sp_Columns.AutoSize = true;
            this.lk_sp_Columns.Location = new Point(0x1dc, 9);
            this.lk_sp_Columns.Name = "lk_sp_Columns";
            this.lk_sp_Columns.Size = new Size(0x41, 13);
            this.lk_sp_Columns.TabIndex = 9;
            this.lk_sp_Columns.TabStop = true;
            this.lk_sp_Columns.Text = "SP_Columns";
            this.lk_SPFkey.AutoSize = true;
            this.lk_SPFkey.Location = new Point(0x1ab, 9);
            this.lk_SPFkey.Name = "lk_SPFkey";
            this.lk_SPFkey.Size = new Size(0x2e, 13);
            this.lk_SPFkey.TabIndex = 10;
            this.lk_SPFkey.TabStop = true;
            this.lk_SPFkey.Text = "SP_Help";
            this.lk_FKeys.AutoSize = true;
            this.lk_FKeys.Location = new Point(0x220, 9);
            this.lk_FKeys.Name = "lk_FKeys";
            this.lk_FKeys.Size = new Size(0x36, 13);
            this.lk_FKeys.TabIndex = 11;
            this.lk_FKeys.TabStop = true;
            this.lk_FKeys.Text = "SP_FKeys";
            this.lk_sp_PKey.AutoSize = true;
            this.lk_sp_PKey.Location = new Point(0x257, 10);
            this.lk_sp_PKey.Name = "lk_sp_PKey";
            this.lk_sp_PKey.Size = new Size(0x36, 13);
            this.lk_sp_PKey.TabIndex = 12;
            this.lk_sp_PKey.TabStop = true;
            this.lk_sp_PKey.Text = "SP_PKeys";
            this.lk_copyup.AutoSize = true;
            this.lk_copyup.Location = new Point(0x12d, 0x8b);
            this.lk_copyup.Name = "lk_copyup";
            this.lk_copyup.Size = new Size(0x30, 13);
            this.lk_copyup.TabIndex = 13;
            this.lk_copyup.TabStop = true;
            this.lk_copyup.Text = "Copy Up";
            this.lk_copyup.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lk_copyup_LinkClicked);
            this.lk_Where.AutoSize = true;
            this.lk_Where.Location = new Point(0x10a, 8);
            this.lk_Where.Name = "lk_Where";
            this.lk_Where.Size = new Size(0x27, 13);
            this.lk_Where.TabIndex = 14;
            this.lk_Where.TabStop = true;
            this.lk_Where.Text = "Where";
            this.lk_from.AutoSize = true;
            this.lk_from.Location = new Point(0x15c, 9);
            this.lk_from.Name = "lk_from";
            this.lk_from.Size = new Size(0x1f, 13);
            this.lk_from.TabIndex = 15;
            this.lk_from.TabStop = true;
            this.lk_from.Text = "From";
            this.lk_.AutoSize = true;
            this.lk_.Location = new Point(0x137, 9);
            this.lk_.Name = "lk_";
            this.lk_.Size = new Size(13, 13);
            this.lk_.TabIndex = 0x10;
            this.lk_.TabStop = true;
            this.lk_.Text = "*";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btnExit;
            base.ClientSize = new Size(670, 0x20b);
            base.Controls.Add(this.lk_);
            base.Controls.Add(this.lk_from);
            base.Controls.Add(this.lk_Where);
            base.Controls.Add(this.lk_copyup);
            base.Controls.Add(this.lk_sp_PKey);
            base.Controls.Add(this.lk_FKeys);
            base.Controls.Add(this.lk_SPFkey);
            base.Controls.Add(this.lk_sp_Columns);
            base.Controls.Add(this.lk_Delete);
            base.Controls.Add(this.lk_Update);
            base.Controls.Add(this.lk_Select);
            base.Controls.Add(this.btnOpen);
            base.Controls.Add(this.cbTableName);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.dgView);
            base.Controls.Add(this.txtSqlText);
            base.Controls.Add(this.label1);
            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "frmExecSQL";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ExecSQL";
            base.Load += new EventHandler(this.frmExecSQL_Load);
            this.dgView.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void lk_Click(object sender, EventArgs e)
        {
            LinkLabel label = (LinkLabel) sender;
            this.txtSqlText.Text = this.txtSqlText.Text = this.txtSqlText.Text + " " + label.Text;
        }

        private void lk_copyup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtSqlText.Text = this.txtSqlText.Text = this.txtSqlText.Text + " " + this.cbTableName.Text;
        }

        private void LoadSetting()
        {
            string listFormSize = Settings.Default.ListFormSize;
            if ((listFormSize == null) || (listFormSize == ""))
            {
                this.AutoLoadSetting();
            }
            else
            {
                int index = listFormSize.IndexOf("#" + base.Name);
                if (index == -1)
                {
                    this.AutoLoadSetting();
                }
                else
                {
                    int num2 = listFormSize.Substring(index, listFormSize.Length - index).IndexOf("@");
                    string[] strArray = listFormSize.Substring(index + 1, num2 - 1).Split(new char[] { ';' });
                    if (strArray.Length >= 5)
                    {
                        int x = int.Parse(strArray[1]);
                        int y = int.Parse(strArray[2]);
                        base.Location = new Point(x, y);
                        int width = int.Parse(strArray[3]);
                        int height = int.Parse(strArray[4]);
                        base.Size = new Size(width, height);
                    }
                }
            }
        }

        private void SaveSetting()
        {
            string newValue = string.Concat(new object[] { "#", base.Name, ";", base.Location.X, ";", base.Location.Y, ";", base.Size.Width, ";", base.Size.Height, "@" });
            string listFormSize = Settings.Default.ListFormSize;
            if ((listFormSize == null) || (listFormSize == ""))
            {
                listFormSize = newValue;
            }
            else
            {
                int index = listFormSize.IndexOf("#" + base.Name);
                if (index == -1)
                {
                    listFormSize = listFormSize + newValue;
                }
                else
                {
                    int num2 = listFormSize.Substring(index, listFormSize.Length - index).IndexOf("@");
                    string oldValue = listFormSize.Substring(index, num2 + 1);
                    listFormSize = listFormSize.Replace(oldValue, newValue);
                }
            }
            Settings.Default.ListFormSize = listFormSize;
            Settings.Default.Save();
        }

        private void txtSqlText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.btnOK_Click(sender, e);
            }
        }
    }
}

