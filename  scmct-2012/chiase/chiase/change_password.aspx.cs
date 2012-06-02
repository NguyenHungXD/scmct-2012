using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DK2C.DataAccess.Web;

namespace chiase
{
    public partial class change_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Display();
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='change_password.aspx' title='Đổi mật khẩu'>Đổi mật khẩu</a> ";
            }
        }
        public void Display()
        {
            DataTable table = (DataTable)Session["ThanhVien"];
            
            if (table != null)
            {
                String avatar_name = Convert.IsDBNull(table.Rows[0]["avatar_path"]) ? "default_img.gif" : (String)table.Rows[0]["avatar_path"];
                lbl_username.Text = (String)table.Rows[0]["username"];
                lbl_email.Text = (String)table.Rows[0]["email"];
                DateTime lasted_access = (DateTime)table.Rows[0]["lasted_access"];
                lbl_lasted_access.Text = lasted_access.ToString("dd/MM/yyyy hh:mm:ss tt");
                lbl_group_name.Text = (String)table.Rows[0]["groupname"];
                img_user.ImageUrl = "Images/User.gif";
                img_user.ImageUrl = "Images/avatars/" + avatar_name;
            }
        }



        protected void btn_changepass_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)Session["ThanhVien"];
            String sql_check = "Select * from ND_THONG_TIN_DN where username=@v_username and pwd=@v_password";
            String username = (String)table.Rows[0]["username"];
            String password = txt_oldpass.Text;
            String new_password = txt_new_pass.Text;
            DataTable table_check = SQLConnectWeb.GetData(sql_check, "@v_username", username, "@v_password", password);

            if (table_check.Rows.Count > 0)
            {
                string sql_update = "UPDATE ND_THONG_TIN_DN SET PWD=@v_new_pass WHERE USERNAME=@v_username";
                SQLConnectWeb.ExecuteNonQuery(sql_update,
                        "@v_new_pass", new_password,
                        "@v_username", username);

                lbl_error.Text = "Mật khẩu đã được đổi thành công !";


                Session.Remove("ThanhVien");
                Response.Redirect("Default.aspx");
            }
            else
            {
                lbl_error.Text = "Đổi mật khẩu không thành công !";
            }
        }



        protected void btn_back_Click(object sender, EventArgs e)
        {
            object refUrl = ViewState["RefUrl"];
            if (refUrl != null)
                Response.Redirect((string)refUrl);
        }





  

        








    }
}