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
        public static string id = "123";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_allbum_name.Text = "Allbum ảnh " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
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
                            "@created_date", DateTime.Now,
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