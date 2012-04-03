using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;

namespace chiase
{
    public partial class register : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_user_name.Focus();
                functions.add_date_to_dropd(dropd_day, dropd_month, dropd_year,0);
            }
        }
        
  


      protected void btn_register_Click(object sender, EventArgs e)
        {
            Boolean check = true;//Check availabe (Username,Email address)
            //SQL String
            //const String sql_check_username = "SELECT userid FROM ND_THONG_TIN_DN WHERE username=@v_username";
            //const String sql_check_id = "SELECT id FROM ND_THONG_TIN_ND WHERE email=@v_email";
            //const String sql_insert_ttdn = "INSERT INTO ND_THONG_TIN_DN (USERNAME, PWD, LASTED_ACCESS, CREATED_DATE, ISCHANGEPWD_BIT, ISACTIVE_BIT, MEM_ID)VALUES(@v_USERNAME, @v_PWD,@v_LASTED_ACCESS, @v_CREATED_DATE, @v_ISCHANGEPWD_BIT,@v_ISACTIVE_BIT, @v_MEM_ID)"; //CREATED_BY  @v_CREATED_BY
            //const String sql_insert_ttnd = "INSERT INTO ND_THONG_TIN_ND (NAME, MEM_GROUP_ID, ADDRESS,BIRTH_DAY,SEX, PHONE, EMAIL,CREATED_DATE, VISIBLE_BIT)VALUES(@v_NAME, @v_MEM_GROUP_ID, @v_ADDRESS,@v_BIRTH_DAY,@v_SEX, @v_PHONE, @v_EMAIL,@v_CREATED_DATE, @v_VISIBLE_BIT)";
            
            try
            {
                //Kiem tra Username
                String username = txt_user_name.Text;
                String email = txt_emaill_address.Text;
                DataTable table= ND_THONG_TIN_DN.GetTableFields(ND_THONG_TIN_DN.cl_USERNAME+"=N'"+username+"'",
                    new string[]{},ND_THONG_TIN_DN.cl_USERID);                

                if (table.Rows.Count > 0)
                {
                    check = false;
                }

                if (check) //Continue checking email address if username is available
                {
                    DataTable tb_email = ND_THONG_TIN_ND.GetTableFields(ND_THONG_TIN_ND.cl_EMAIL + "=N'" + email + "'",
                    new string[] { }, ND_THONG_TIN_ND.cl_ID);  
                    if (tb_email.Rows.Count > 0)
                    {
                        check = false;
                    }
                }

                if (check)//Is available (username,email)
                {
                    //Insert ND_THONG_TIN_ND

    
          

                    DateTime bithday = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month.Text, dropd_day.Text, dropd_year.Text));
                    //Database.ExecuteNonQuery(sql_insert_ttnd,
                    //                        "@v_NAME", txt_full_name.Text,
                    //                        "@v_MEM_GROUP_ID", '1',
                    //                        "@v_ADDRESS", txt_address.Text,
                    //                        "@v_BIRTH_DAY", bithday,
                    //                        "@v_SEX",rd_sex.SelectedItem.Value,
                    //                        "@v_PHONE", txt_phone_number.Text,
                    //                        "@v_EMAIL", txt_emaill_address.Text,
                    //                        "@v_CREATED_DATE", DateTime.Now,
                    //                        "@v_VISIBLE_BIT", 'Y');

                   
                    bool ok=false;
                    ND_THONG_TIN_ND nd = ND_THONG_TIN_ND.Insert_Object(
                        txt_full_name.Text,
                        "1",
                        txt_address.Text,
                        bithday.ToString("yyyy-MM-dd"),
                        rd_sex.SelectedItem.Value, txt_phone_number.Text, "",
                        txt_emaill_address.Text, "", "", "", "", "", "", "Y", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                        "", "", "");
                    if (nd != null)
                    {
                        //Get Mem ID
                        //DataTable tb_memID = Database.GetData(sql_check_id, "@v_email", email);
                        //Int64 v_memID = (Int64)tb_memID.Rows[0]["id"]; //Get ID Member from ND_THONG_TIN_ND
                        //Insert ND_THONG_TIN_DN
                        //Database.ExecuteNonQuery(sql_insert_ttdn,
                        //                        "@v_USERNAME", txt_user_name.Text,
                        //                        "@v_PWD", txt_pass_word.Text,
                        //                        "@v_LASTED_ACCESS", DateTime.Now,
                        //                        "@v_CREATED_DATE", DateTime.Now,
                        //                        "@v_ISCHANGEPWD_BIT", 'Y',
                        //                        "@v_ISACTIVE_BIT", 'Y',
                        //                        "@v_MEM_ID", v_memID);
                        ND_THONG_TIN_DN dn = ND_THONG_TIN_DN.Insert_Object(txt_user_name.Text,
                            txt_pass_word.Text, "", "", "", "", "", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                            "", "", "Y", "Y", nd.ID);
                        if (dn != null)
                            ok = true;

                    }

                    //Direct to Default page
                    //string url = "notification_page.aspx?str_note=" + "Tài khoảng đã được tạo thành công...";
                    if (ok)
                        Response.Redirect("edit_profile.aspx");
                    else
                        lbl_result.Text = "Đăng ký thành viên không thành công.  <br>Vui lòng kiểm tra lại thông tin!";
                }
                else {

                    lbl_result.Text = "Đăng ký thành viên không thành công. <br>Tên tài khoản hoặc địa chỉ email đã tồn tại trong hệ thống!";
                    //Response.Redirect("register.aspx");
                }
            }
            catch (Exception ex)
            {
                // chuyen sang trang thong bao loi
                //Response.Redirect("error_page.aspx");
              // Response.Write(ex);
                lbl_result.Text = "Đăng ký thành viên không thành công !" +ex.ToString();
                
            }
           
           
            
        }
        protected void btn_close_Click1(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

    

        

      

    

   


    }
}