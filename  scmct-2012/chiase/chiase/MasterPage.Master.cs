using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace chiase
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
                this.Display();
           }
        }

        void Display()
        {
            DataTable table = (DataTable)Session["ThanhVien"];
            MultiView1.ActiveViewIndex = (table == null) ? 0 : 1;
            if (table != null)
            {
                lbl_username.Text = (String)table.Rows[0]["username"];

                DateTime lasted_access = (DateTime)table.Rows[0]["lasted_access"];
                lbl_lasted_access.Text = lasted_access.ToString("dd/mm/yyyy hh:mm:ss tt");
                String avatar_name = Convert.IsDBNull(table.Rows[0]["avatar_path"]) ? "default_img.gif" : (String)table.Rows[0]["avatar_path"];
                imgUser.ImageUrl = "Images/avatars/" + avatar_name;
            }
        }


        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Remove("ThanhVien");
            Response.Redirect("Default.aspx");
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            String sql = "SELECT a.*,b.*,c.* FROM ND_THONG_TIN_DN a,ND_THONG_TIN_ND b,ND_TEN_NHOM_ND c WHERE a.MEM_ID=b.ID and b.MEM_GROUP_ID = c.GROUPID AND username=@v_username AND pwd=@v_password";
            String userId = txtUserID.Text;
            String password = txtPassWord.Text;
            DataTable table = Database.GetData(sql, "@v_username", userId, "@v_password", password);

            if (table.Rows.Count > 0)
            {
                Session["ThanhVien"] = table;
                //lblError.Text = "Dang nhap thanh cong !";
                this.Display();
            }
            else
            {
                lblError.Text = "Tài khoản không tôn tại hoặc mật khẩu không đúng !";
            }
        }

   
    }
}