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
using DK2C.DataAccess.Web;
using chiase.Objects;

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
                lbl_username.Text = (String)table.Rows[0][ND_THONG_TIN_DN.cl_USERNAME];

                object obj = table.Rows[0][ND_THONG_TIN_DN.cl_LASTED_ACCESS];
                if (obj != null && obj != DBNull.Value)
                {
                    DateTime lasted_access = (DateTime)obj;
                    lbl_lasted_access.Text = lasted_access.ToString("dd/mm/yyyy hh:mm:ss tt");
                }
                else lbl_lasted_access.Text = "__/__/___ __:__:__";
                String avatar_name = Convert.IsDBNull(table.Rows[0][ND_THONG_TIN_ND.cl_AVATAR_PATH]) ? "default_img.gif" : (String)table.Rows[0][ND_THONG_TIN_ND.cl_AVATAR_PATH];
                imgUser.ImageUrl = "Images/avatars/" + avatar_name;
            }
        }


        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Remove("ThanhVien");
            Response.Redirect("Default.aspx");
        }

        protected void btn_login_Click1(object sender, EventArgs e)
        {
            bool ok=false;
            String sql = string.Format(@"SELECT a.*,b.*,c.* 
                         FROM ND_THONG_TIN_DN a
                        INNER JOIN  ND_THONG_TIN_ND b ON  a.MEM_ID=b.ID
                        INNER JOIN ND_TEN_NHOM_ND c ON  b.MEM_GROUP_ID = c.GROUPID
                        WHERE username=N'{0}'", txtUserID.Text);


            DataTable table = SQLConnectWeb.GetTable(sql);



            if (table != null && table.Rows.Count > 0)
            {
                if (table.Rows[0][ND_THONG_TIN_DN.cl_PWD].ToString().Equals(txtPassWord.Text))
                {
                    ok = true;
                    Session["ThanhVien"] = table;
                    //lblError.Text = "Dang nhap thanh cong !";
                    this.Display();

                }
            }
            if (ok == false)
            {
                lblError.Text = "Tên đăng nhập hoặc mật khẩu không hợp lệ!";
            }
           
        }

 

        

   
    }
}