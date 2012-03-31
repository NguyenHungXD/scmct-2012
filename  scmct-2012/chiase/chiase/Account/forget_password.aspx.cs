﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace chiase
{
    public partial class forget_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();

            }
        }
        public void Display()
        {
            DataTable table = (DataTable)Session["ThanhVien"];

            if (table != null)
            {
                //DateTime lasted_access = (DateTime)table.Rows[0]["lasted_access"];
                //lbl_lasted_access.Text = lasted_access.ToString("dd/mm/yyyy hh:mm:ss tt");
                //lbl_group_name.Text = (String)table.Rows[0]["groupname"];
                //img_user.ImageUrl = "Images/User.gif";
            }
        }




        protected void btn_getpassword_Click(object sender, EventArgs e)
        {
            String sql = "SELECT a.*,b.* FROM ND_THONG_TIN_DN a,ND_THONG_TIN_ND b WHERE a.MEM_ID=b.ID AND (username=@v_username OR email=@v_email)";
            String username = txt_username.Text;
            String email = txt_email.Text;
            DataTable table = Database.GetData(sql, "@v_username", username, "@v_email", email);

            if (table.Rows.Count == 0)
            {
               // lbl_error.Text = "Tên đăng nhập hoặc địa chỉ email không tồn tại";
            }
            else
            {
                String password = table.Rows[0]["pwd"].ToString();
                String subject = "SCMCT - Ban quan tri cong thong tin sach SCMCT - Quen mat khau";
                // String body = String.Format("Chao {0}, <br>Tên đăng nhập: {1}<br>Mật khẩu: {2}<br><a href=http:/chiase.org/>http://www.chiase.org/</a><br>Ban quan tri SCMCT</body></html>", table.Rows[0]["name"], table.Rows[0]["username"], table.Rows[0]["pwd"]);
                String body = String.Format("Tai khoan dang nhap :{0} Mat khau: {1}", table.Rows[0]["username"], table.Rows[0]["pwd"]);
                try
                {
                    Gmail.Send(table.Rows[0]["email"].ToString(), subject, body);
                   // lbl_error.Text = String.Format("Mật khẩu của bạn đã được gửi đến <u>{0}</u>. Xin vui lòng kiểm tra hộp thư của bạn", table.Rows[0]["email"]);
                }
                catch
                {
                  //  lbl_error.Text = "Mật khẩu của bạn : " + password;
                }

            }
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

   






   

        

     

  

      

 



    

 

        

    }
}