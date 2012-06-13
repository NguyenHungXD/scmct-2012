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

namespace chiase
{
    public partial class upload_images : System.Web.UI.Page
    {
        public static string album_name;
        public static string album_detail;
        public static string album_id;
        public string UploadPath
        {
            get
            {
                return Server.MapPath("~/Images/upload/");
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
                    txt_album_name.Text = "Album ảnh " + DateTime.Now.ToString("dd/MM/yyyy");
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
                string memid = functions.LoginMemID(this);


                if (Request.QueryString["projectid"] == null)
                {
                    string sql = @"insert into img_album (album_name,description,created_by,created_date,status,liked,viewed) values(@album_name,@description,@created_by,@created_date,@status,@liked,@viewed)";
                    SQLConnectWeb.ExecuteNonQuery(sql,
                                "@album_name", txt_album_name.Text,
                                "@description", txt_desc.Text,
                                "@created_by", memid,
                                "@created_date", functions.GetStringDatetime(),
                                "@status", 1,
                                "@liked", 0,
                                "@viewed", 0);
                }
                else
                {
                    string sql = @"insert into img_album (album_name,description,created_by,created_date,status,liked,PROJECT_ID,viewed) values(@album_name,@description,@created_by,@created_date,@status,@liked,@PROJECT_ID,@viewed)";
                    SQLConnectWeb.ExecuteNonQuery(sql,
                                "@album_name", txt_album_name.Text,
                                "@description", txt_desc.Text,
                                "@created_by", memid,
                                "@created_date", functions.GetStringDatetime(),
                                "@status", 1,
                                "@liked", 0,
                                "@PROJECT_ID", Request.QueryString["projectid"],
                                "@viewed", 0);
                }


                lbl_error.Text = String.Format("Album ảnh [<b>{0}</b>] đã lưu thành công. Upload hình cho album...", txt_album_name.Text);
                btn_save_album.Visible = false;
                Panel1.Visible = false;
                Panel2.Visible = true;


                string sqls = @"select max(album_id) as album_ids from img_album where created_by = @created_by";
                DataTable table = SQLConnectWeb.GetData(sqls, "@created_by", memid);


                album_id = table.Rows[0]["album_ids"].ToString();




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
            }
            catch
            { }
        }


        protected void btnUploadFiles_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(UploadPath))
            {
                System.IO.Directory.CreateDirectory(UploadPath);
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            HttpFileCollection uploads = HttpContext.Current.Request.Files;

            for (int i = 0; i < uploads.Count; i++)
            {
                HttpPostedFile upload = uploads[i];
                string c = System.IO.Path.GetFileName(upload.FileName); // We don't need the path,just the name.
                String file_type = System.IO.Path.GetExtension(c);
                if (upload.ContentLength == 0)
                {
                    sb.AppendLine(String.Format("Hình: {0} upload không thành công.", c));
                    sb.AppendLine("<br>");
                    continue;
                }
                try
                {
                    if ((file_type == ".jpg" || file_type == ".gif" || file_type == ".png") && album_id != null)
                    {
                        string filename = c;
                        string addmore = "1_";
                        Boolean check = true;
                        while (check)
                        {
                            if (File.Exists(UploadPath + addmore + filename))
                            {
                                addmore = addmore + "1_";
                            }
                            else
                                check = false;
                        }

                        filename =addmore+ filename;

                        upload.SaveAs(UploadPath + filename);
                        //save images path to database
                        string memid = functions.LoginMemID(this);
                        string sql = @"insert into IMG_album_DETAIL (album_id,path,title,status,posted_by,posted_date,liked) values(@album_id,@path,@title,@status,@posted_by,@posted_date,@liked)";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                                    "@album_id", album_id,
                                    "@path", "Images/upload/" + filename,
                                    "@title", filename,
                                    "@status", 1,
                                    "@posted_by", memid,
                                    "@posted_date", functions.GetStringDatetime(),
                                    "@liked", 0);
                        sb.AppendLine(String.Format("Hình: {0} upload thành công.", filename));
                        sb.AppendLine("<br>");
                    }
                }
                catch (Exception ex)
                {
                    //sb.AppendLine(String.Format("File: {0} upload failed. Error: {1}...", c, ex.Message.Substring(0, 40)));
                    //sb.AppendLine("<br>");
                }
            }
            litResult.Text = sb.ToString();
        }
    }
}