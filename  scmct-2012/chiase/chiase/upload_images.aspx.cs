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
        public static string allbum_name;
        public static string allbum_detail;
        public static string allbum_id;
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
                if (Request.QueryString["allbumid"] == null)
                {
                    txt_allbum_name.Text = "Allbum ảnh " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    Panel1.Visible = true;

                }
                else
                {
                    display();
                }
            }

        }
        protected void btn_save_allbum_Click(object sender, EventArgs e)
        {
            try
            {
                string memid = functions.LoginMemID(this);
                string sql = @"insert into img_allbum (allbum_name,description,created_by,created_date,status,liked,viewed) values(@allbum_name,@description,@created_by,@created_date,@status,@liked,@viewed)";
                SQLConnectWeb.ExecuteNonQuery(sql,
                            "@allbum_name", txt_allbum_name.Text,
                            "@description", txt_desc.Text,
                            "@created_by", memid,
                            "@created_date", functions.GetStringDatetime(),
                            "@status", 1,
                            "@liked", 0,
                            "@viewed", 0);

                lbl_error.Text = String.Format("Allbum ảnh [<b>{0}</b>] đã lưu thành công. Upload hình cho allbum...", txt_allbum_name.Text);
                btn_save_allbum.Visible = false;
                Panel1.Visible = false;
                Panel2.Visible = true;


                string sqls = @"select max(allbum_id) as allbum_ids from img_allbum where created_by = @created_by";
                DataTable table = SQLConnectWeb.GetData(sqls, "@created_by", memid);


                allbum_id = table.Rows[0]["allbum_ids"].ToString();




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
                            from IMG_ALLBUM a 
                            inner join ND_THONG_TIN_ND b on a.created_by = b.ID
                            inner join ND_THONG_TIN_DN c on c.mem_id = b.ID
                            where allbum_id=@allbum_id";

                DataTable table = SQLConnectWeb.GetData(sql, "@allbum_id", Request.QueryString["allbumid"]);

                allbum_name = table.Rows[0]["allbum_name"].ToString();
                allbum_detail = table.Rows[0]["description"].ToString();
                allbum_id = Request.QueryString["allbumid"];
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
                    if ((file_type == ".jpg" || file_type == ".gif" || file_type == ".png") && allbum_id != null)
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
                        string sql = @"insert into IMG_ALLBUM_DETAIL (allbum_id,path,title,status,posted_by,posted_date,liked) values(@allbum_id,@path,@title,@status,@posted_by,@posted_date,@liked)";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                                    "@allbum_id", allbum_id,
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