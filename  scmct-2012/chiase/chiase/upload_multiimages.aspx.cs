using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using chiase.Objects;
using DK2C.DataAccess.Web;
using System.Data;
using CuteWebUI;
using System.Data.SqlClient;

namespace chiase
{
    public partial class upload_multiimages : System.Web.UI.Page
    {
        public string album_name;
        public string album_detail;
        public string album_id;
        private const string vUploadPath = "Images/upload/";
        public string UploadPath
        {
            get
            {
                return Server.MapPath("~/"+vUploadPath);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));


                //txt_album_name.Text = Request.QueryString["projectid"];
                //lbl_error.Text = Request.QueryString["projectid"];
                if (Request.QueryString["albumid"] == null)
                {
                    album_id = null;
                    txt_album_name.Text = "Album ảnh " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    Panel1.Visible = true;
                }
                else
                {
                    display();
                }
            }

        }
        protected void btn_save_album_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_album_name.Text))
                    txt_album_name.Text = "Albumn " + SQLConnectWeb.GetSystemDatetime().ToString("yyyy-MM-dd-hh:mm:ss tt");


                lbl_error.Text = String.Format("Album ảnh [<b>{0}</b>] đã tạo thành công. Upload hình cho album...", txt_album_name.Text);
                btn_save_album.Visible = false;
                Panel1.Visible = false;
                Panel2.Visible = true;
                
            }
            catch (Exception ex)
            {

            }
        }
        public void display()
        {
            try
            {

                String sql = @"select a.*,b.name,c.username
                            from IMG_album a 
                            inner join ND_THONG_TIN_ND b on a.created_by = b.ID
                            inner join ND_THONG_TIN_DN c on c.mem_id = b.ID
                            where album_id=@album_id";

                DataTable table = SQLConnectWeb.GetData(sql, "@album_id", Request.QueryString["albumid"]);

                album_name = table.Rows[0]["album_name"].ToString();
                album_detail = table.Rows[0]["description"].ToString();
                album_id = Request.QueryString["albumid"];
                Panel2.Visible = true;
                Panel3.Visible = true;
                ImageFiles.InsertText = "Thêm ảnh";
                btnUploadFiles.Text = "Đăng ảnh";
            }
            catch
            { }
        }


        

        protected void btnUploadFiles_Click(object sender, EventArgs e)
        {

            if (ImageFiles.InsertText != "Thêm ảnh" && ImageFiles.Items.Count == 0)
            {
                lbl_error.Text = "Vui lòng chọn ảnh trước khi lưu albumn";
                return;
            }
            string memid = functions.LoginMemID(this);
            string date = functions.GetStringDatetime();

            using (SqlConnection conn = SQLConnectWeb.GetConnection())
            {
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        if (string.IsNullOrEmpty(album_id))
                        {
                            string sqlInsertAlbum = @"insert into img_album (album_name,description,created_by,created_date,status,liked,PROJECT_ID,viewed) 
                                      values({0},{1},{2},{3},{4},{5},{6},{7})";

                            bool ok = SQLConnectWeb.ExecuteNonQueryTrans(trans, sqlInsertAlbum,
                                txt_album_name.Text.Trim(), txt_desc.Text.Trim(), memid, date, 1, 0,
                               (Request.QueryString["projectid"] == null ? (object)DBNull.Value : (object)Request.QueryString["projectid"]),
                               0);
                            if (ok == false)
                            {
                                lbl_error.Text = "Lưu album không thành công!";
                                trans.Rollback();
                                return;
                            }
                            string sql = string.Format(@"SELECT TOP 1 AL.ALBUM_ID FROM IMG_ALBUM AL 
                            where al.album_name=N'{0}' and created_by={1} and  created_date='{2}'
                            ORDER BY al.ALBUM_ID DESc", txt_album_name.Text, memid, date);
                            album_id = SQLConnectWeb.ExecuteStringTrans(trans, sql);
                            if (string.IsNullOrEmpty(album_id))
                            {
                                lbl_error.Text = "Lưu album không thành công!";
                                trans.Rollback();
                                return;
                            }
                        }
                        string dir = UploadPath;
                        string sqlInsertDetail = @"insert into IMG_album_DETAIL (album_id,path,title,status,posted_by,posted_date,liked) 
                                    values({0},{1},{2},{3},{4},{5},{6})";
                        foreach (AttachmentItem attitem in ImageFiles.Items.ToArray())
                        {
                            if (attitem.Checked)
                            {

                                string newfilename = Path.GetFileNameWithoutExtension(attitem.FileName) + "." + attitem.FileGuid + "." + attitem.FileSize + Path.GetExtension(attitem.FileName);
                                FileItem fileitem = new FileItem(dir, attitem);
                                fileitem.TempFileName = newfilename;
                                attitem.CopyTo(fileitem.TempFilePath);
                                string mappath = vUploadPath + Path.GetFileName(fileitem.TempFilePath);
                                if (SQLConnectWeb.ExecuteNonQueryTrans(trans, sqlInsertDetail, album_id,mappath, fileitem.FileName, 1, memid, date, 0))
                                {
                                    attitem.Delete();
                                   
                                }
                                else
                                {
                                    //              
                                    lbl_error.Text = "Lưu album không thành công!";
                                    trans.Rollback();
                                    return;
                                }
                            }
                        }
                        trans.Commit();
                        lbl_error.Text = String.Format("Đã lưu Album ảnh [<b>{0}</b>] thành công.Bạn có muốn chọn thêm ảnh?", txt_album_name.Text);
                        ImageFiles.InsertText = "Thêm ảnh";
                    }
                    catch
                    {
                        lbl_error.Text = "Lưu album không thành công!";
                        trans.Rollback();
                    }
                }
            }
            
        }

        
    }
}