using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chiase.Objects;
using DK2C.DataAccess.Web;
using System.Data;

namespace chiase
{
    public partial class update_allbum_info : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                    display();
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

                txt_allbum_name.Text = table.Rows[0]["allbum_name"].ToString();
                txt_desc.Text = table.Rows[0]["description"].ToString();
                

            }
            catch
            { }
        }


        protected void btn_save_allbum_Click(object sender, EventArgs e)
        {
            try
            {
                string memid = functions.LoginMemID(this);
                string sql = @"update img_allbum set allbum_name=@allbum_name,description=@description,edited_by=@edited_by,edited_date=@edited_date where allbum_id=@allbum_id";
                SQLConnectWeb.ExecuteNonQuery(sql,
                            "@allbum_name", txt_allbum_name.Text,
                            "@description", txt_desc.Text,
                            "@edited_by", memid,
                            "@edited_date", functions.GetStringDatetime(),
                            "@allbum_id", Request.QueryString["allbumid"]);

                lbl_error.Text = String.Format("Allbum ảnh [<b>{0}</b>] đã lưu thành công.", txt_allbum_name.Text);
     
            }
            catch (Exception ex)
            {

            }
        }
    }
}