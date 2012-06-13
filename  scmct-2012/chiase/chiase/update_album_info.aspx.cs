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
    public partial class update_album_info : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                if (functions.checkOwnSection(functions.LoginMemID(this), Request.QueryString["albumid"], "IMG_album", "CREATED_BY", "album_ID") || functions.checkPrivileges("44", functions.LoginMemID(this), "E"))
                    lbl_edit_album.Visible = true;
                else
                    lbl_edit_album.Visible = false;
                display();
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

                txt_album_name.Text = table.Rows[0]["album_name"].ToString();
                txt_desc.Text = table.Rows[0]["description"].ToString();
                

            }
            catch
            { }
        }


        protected void btn_save_album_Click(object sender, EventArgs e)
        {
            try
            {
                string memid = functions.LoginMemID(this);
                string sql = @"update img_album set album_name=@album_name,description=@description,edited_by=@edited_by,edited_date=@edited_date where album_id=@album_id";
                SQLConnectWeb.ExecuteNonQuery(sql,
                            "@album_name", txt_album_name.Text,
                            "@description", txt_desc.Text,
                            "@edited_by", memid,
                            "@edited_date", functions.GetStringDatetime(),
                            "@album_id", Request.QueryString["albumid"]);

                lbl_error.Text = String.Format("Album ảnh [<b>{0}</b>] đã lưu thành công.", txt_album_name.Text);
     
            }
            catch (Exception ex)
            {

            }
        }
    }
}