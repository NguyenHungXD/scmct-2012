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
        public static string allbum_name;
        public static string allbum_detail;


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

                Panel2.Visible = true;
                Panel3.Visible = true;
            }
            catch
            { }
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


                allbum_id.Value = table.Rows[0]["allbum_ids"].ToString();
                user_id.Value = memid;


                
        
            }
            catch(Exception ex)
            { 
            
            }
        }

    }
}