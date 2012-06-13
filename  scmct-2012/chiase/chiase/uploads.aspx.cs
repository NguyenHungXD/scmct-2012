using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using chiase.Objects;
using DK2C.DataAccess.Web;

namespace chiase
{
    public partial class uploads : System.Web.UI.Page
    {
        public static string album_name;
        public static string album_detail;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                if (Request.QueryString["albumid"] == null)
                {
                    txt_album_name.Text = "album ảnh " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    Panel1.Visible = true;

                }
                else
                {
                    display();
                }
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

                Panel2.Visible = true;
                Panel3.Visible = true;
            }
            catch
            { }
        }

        protected void btn_save_album_Click(object sender, EventArgs e)
        {
            try
            {
                string memid = functions.LoginMemID(this);
                string sql = @"insert into img_album (album_name,description,created_by,created_date,status,liked,viewed) values(@album_name,@description,@created_by,@created_date,@status,@liked,@viewed)";
                SQLConnectWeb.ExecuteNonQuery(sql,
                            "@album_name", txt_album_name.Text,
                            "@description", txt_desc.Text,
                            "@created_by", memid,
                            "@created_date", functions.GetStringDatetime(),
                            "@status", 1,
                            "@liked", 0,
                            "@viewed", 0);

                lbl_error.Text = String.Format("album ảnh [<b>{0}</b>] đã lưu thành công. Upload hình cho album...", txt_album_name.Text);
                btn_save_album.Visible = false;
                Panel1.Visible = false;
                Panel2.Visible = true;


                string sqls = @"select max(album_id) as album_ids from img_album where created_by = @created_by";
                DataTable table = SQLConnectWeb.GetData(sqls, "@created_by", memid);


                album_id.Value = table.Rows[0]["album_ids"].ToString();
                user_id.Value = memid;


                
        
            }
            catch(Exception ex)
            { 
            
            }
        }

    }
}