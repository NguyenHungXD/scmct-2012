using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;
using DK2C.DataAccess.Web;

namespace chiase
{
    public partial class register : System.Web.UI.Page
    {
        public static string strConfirm="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strConfirm = functions.randomstring(4);
                txt_random.Text = strConfirm;
                txt_user_name.Focus();
                functions.add_date_to_dropd(dropd_day, dropd_month, dropd_year,0);
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='register.aspx' title='Đăng ký'>Đăng ký</a> ";
                Session["current"] = "9"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
            }
        }
        
  


      protected void btn_register_Click(object sender, EventArgs e)
        {

            Boolean check = true;//Check availabe (Username,Email address)
            //SQL String
            //const String sql_check_username = "SELECT userid FROM ND_THONG_TIN_DN WHERE username=@v_username";
            const String sql_check_id = "SELECT id FROM ND_THONG_TIN_ND WHERE email=@v_email";
            const String sql_insert_ttdn = "INSERT INTO ND_THONG_TIN_DN (USERNAME, PWD, LASTED_ACCESS,CREATED_BY, CREATED_DATE, ISCHANGEPWD_BIT, ISACTIVE_BIT, MEM_ID)VALUES(@v_USERNAME, @v_PWD,@v_LASTED_ACCESS,@v_CREATED_BY, @v_CREATED_DATE, @v_ISCHANGEPWD_BIT,@v_ISACTIVE_BIT, @v_MEM_ID)"; //CREATED_BY  @v_CREATED_BY
            const String sql_insert_ttnd = "INSERT INTO ND_THONG_TIN_ND (NAME, MEM_GROUP_ID, ADDRESS,BIRTH_DAY,SEX, PHONE, EMAIL,CREATED_DATE, VISIBLE_BIT)VALUES(@v_NAME, @v_MEM_GROUP_ID, @v_ADDRESS,@v_BIRTH_DAY,@v_SEX, @v_PHONE, @v_EMAIL,@v_CREATED_DATE, @v_VISIBLE_BIT)";
            
            try
            {
                if (txt_confirm.Text != strConfirm)
                {
                    strConfirm = functions.randomstring(4);
                    txt_random.Text = strConfirm;
                    lbl_result.Text = "Nhập mã xác nhận chưa đúng!";
                }
                else
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
                    int nd= SQLConnectWeb.ExecuteNonQuery(sql_insert_ttnd,
                                            "@v_NAME", txt_full_name.Text,
                                            "@v_MEM_GROUP_ID", '1',
                                            "@v_ADDRESS", txt_address.Text,
                                            "@v_BIRTH_DAY", bithday,
                                            "@v_SEX", rd_sex.SelectedItem.Value,
                                            "@v_PHONE", txt_phone_number.Text,
                                            "@v_EMAIL", txt_emaill_address.Text,
                                            "@v_CREATED_DATE", functions.GetStringDatetime(),
                                            "@v_VISIBLE_BIT", 'Y');

                   
                    bool ok=false;

                    /*
                    ND_THONG_TIN_ND nd = ND_THONG_TIN_ND.Insert_Object(
                        txt_full_name.Text,
                        "1",
                        txt_address.Text,
                        bithday.ToString("yyyy-MM-dd"),
                        rd_sex.SelectedItem.Value, txt_phone_number.Text, "",
                        txt_emaill_address.Text, "", "", "", "", "", "", "Y", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                        "", "", "","0");
                     */
                     
                    
                    if (nd != 0)
                    {
                        //Get Mem ID
                        DataTable tb_memID = SQLConnectWeb.GetData(sql_check_id, "@v_email", email);
                        long v_memID = (long)tb_memID.Rows[0]["id"]; //Get ID Member from ND_THONG_TIN_ND
                        //Insert ND_THONG_TIN_DN
                        int dn = SQLConnectWeb.ExecuteNonQuery(sql_insert_ttdn,
                                                "@v_USERNAME", txt_user_name.Text,
                                                "@v_PWD", txt_pass_word.Text,
                                                "@v_LASTED_ACCESS", functions.GetStringDatetime(),
                                                "@v_CREATED_BY",v_memID,
                                                "@v_CREATED_DATE", functions.GetStringDatetime(),
                                                "@v_ISCHANGEPWD_BIT", 'Y',
                                                "@v_ISACTIVE_BIT", 'Y',
                                                "@v_MEM_ID", v_memID);

                        /*
                        ND_THONG_TIN_DN dn = ND_THONG_TIN_DN.Insert_Object(txt_user_name.Text,
                            txt_pass_word.Text, "", "", "", "", "", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                            "", "", "Y", "Y", nd.ID);
                         */



                        if (dn != 0)
                            ok = true;

                    }

                    //Direct to Default page
                    //string url = "notification_page.aspx?str_note=" + "Tài khoảng đã được tạo thành công...";
                    if (ok)
                    {
                        //auto log-in

                        String sql = @"SELECT a.userid,a.username,a.lasted_access,a.created_date,a.mem_id,b.*,c.* 
                                     FROM ND_THONG_TIN_DN a
                                    INNER JOIN  ND_THONG_TIN_ND b ON  a.MEM_ID=b.ID
                                    INNER JOIN ND_TEN_NHOM_ND c ON  b.MEM_GROUP_ID = c.GROUPID
                                    WHERE username=@username";

                        DataTable table_info = SQLConnectWeb.GetData(sql, "@username", username);

                        if (table_info != null && table_info.Rows.Count > 0)
                        {
                            //if (table_info.Rows[0][ND_THONG_TIN_DN.cl_PWD].ToString().Equals(txt_pass_word.Text))
                            //{


                                //capture the session
                                string v_sessionid = functions.randomstring(17) + functions.randomstring(17);
                                string access_date = functions.GetStringDatetime();
                                string ipaddress = functions.getIPAddress();

                                //
                                string sql_remove_sessionid = @"update ND_LOG_IN_SESSION set sessionid=-1 where userid = @id";
                                SQLConnectWeb.ExecuteNonQuery(sql_remove_sessionid, "@id", table_info.Rows[0]["id"]);
                                //
                                string sql_session = @"insert into ND_LOG_IN_SESSION(userid,sessionid,access_date,ipaddress,fullname,username,groupid) values (@userid,@sessionid,@access_date,@ipaddress,@fullname,@username,@groupid)";
                                SQLConnectWeb.ExecuteNonQuery(sql_session, "@userid", table_info.Rows[0]["id"], "@sessionid", v_sessionid, "@access_date", access_date, "@ipaddress", ipaddress, "@fullname", table_info.Rows[0]["name"], "@username", table_info.Rows[0]["username"], "@groupid", table_info.Rows[0]["groupid"]);


                                DataColumn col;
                                col = new DataColumn("sessionid", System.Type.GetType(" System.String"));
                                table_info.Columns.Add(col);
                                table_info.Rows[0]["sessionid"] = v_sessionid;
                                col = new DataColumn("ipaddress", System.Type.GetType(" System.String"));
                                table_info.Columns.Add(col);
                                table_info.Rows[0]["ipaddress"] = ipaddress;

                                ok = true;
                                Session["ThanhVien"] = table_info;

                                Response.Redirect("edit_profile.aspx");
                            //}
                        }

                        
                    }
                    else
                        lbl_result.Text = "Đăng ký thành viên không thành công.  <br>Vui lòng kiểm tra lại thông tin!";
                }
                else {

                    lbl_result.Text = "Đăng ký thành viên không thành công. <br>Tên tài khoản hoặc địa chỉ email đã tồn tại trong hệ thống!";
                    //Response.Redirect("register.aspx");
                }

            }
            }
            
            catch (Exception ex)
            {
                // chuyen sang trang thong bao loi
                //Response.Redirect("error_page.aspx");
              // Response.Write(ex);
                lbl_result.Text = "Đăng ký thành viên không thành công !";
                
            }
           
           
            
        }
        protected void btn_close_Click1(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

    

        

      

    

   


    }
}