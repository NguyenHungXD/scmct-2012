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
    public partial class create_new_members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                functions.add_date_to_dropd(dropd_day, dropd_month, dropd_year, 0);
                display_info();
                if (Request.QueryString["id"] != null)
                {
                    lbl_create_new_members.Visible = functions.checkPrivileges("42", functions.LoginMemID(this), "E");
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='create_new_members.aspx?id=" + Request.QueryString["id"] + "' title='Cập nhật thông tin'>Cập nhật thông tin</a>";
                }
                else
                {
                    lbl_create_new_members.Visible = functions.checkPrivileges("33", functions.LoginMemID(this), "C");
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='create_new_members.aspx' title='Tạo mới người dùng'>Tạo mới người dùng</a>";
                }
            }
        }

        private void display_info()
        {
            try
            {
 
                string sql = @"select groupid,groupname from ND_TEN_NHOM_ND where deleted is null";
                DataTable table_detail = SQLConnectWeb.GetData(sql);
                functions.fill_DropdownList(dropd_group, table_detail, 0, 1);
                functions.add_date_to_dropd(dropd_day, dropd_month, dropd_year, 0);
                if (Request.QueryString["id"] != null)
                {
                  string  sql_info = string.Format(@"SELECT a.username,b.*,c.groupname,c.groupid
                            FROM ND_THONG_TIN_DN a
                            INNER JOIN ND_THONG_TIN_ND b ON a.MEM_ID = b.ID
                            INNER JOIN ND_TEN_NHOM_ND c ON b.MEM_GROUP_ID =c.GROUPID
                            WHERE a.MEM_ID='{0}'", Request.QueryString["id"]);
                  using (DataTable info = SQLConnectWeb.GetTable(sql_info))
                  {
                      txt_password.Enabled = false;
                      txt_password_re.Enabled = false;
                      txt_username.Enabled = false;
                      txt_password.Text = "mật khẩu đã ẩn";
                      txt_password_re.Text = "mật khẩu đã ẩn";
                      txt_username.Text = info.Rows[0]["username"].ToString();
                      txt_full_name.Text = info.Rows[0]["name"].ToString();
                      txt_address.Text = info.Rows[0]["address"].ToString();
                      txt_email.Text = info.Rows[0]["email"].ToString();
                      txt_faxnumber.Text = info.Rows[0]["fax"].ToString();
                      txt_note.Text = info.Rows[0]["note"].ToString();
                      txt_phonenumber.Text = info.Rows[0]["phone"].ToString();
                      txt_skype.Text = info.Rows[0]["skype"].ToString();
                      txt_yahoo.Text = info.Rows[0]["yahoo"].ToString();
                      txt_website.Text = info.Rows[0]["website"].ToString();
                      int sex = (int)info.Rows[0]["sex"];
                      rd_sex.Items[sex].Selected = true;
                      DateTime birthday = (DateTime)info.Rows[0]["BIRTH_DAY"];
                      functions.selectedDropdown(dropd_day, birthday.Day.ToString());
                      functions.selectedDropdown(dropd_month, birthday.Month.ToString());
                      functions.selectedDropdown(dropd_year, birthday.Year.ToString());
                      functions.selectedDropdown(dropd_group, info.Rows[0]["groupid"].ToString());
                  }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean check = true;//Check availabe (Username,Email address)
            try
            {
                if (Request.QueryString["id"] != null)
                {

                    string sql_getID = @"select id from ND_THONG_TIN_ND where email=@v_email and id <> @id";
                    DataTable tb_memID = SQLConnectWeb.GetData(sql_getID, "@v_email", txt_email.Text, "@id", Request.QueryString["id"]);

                    if (tb_memID.Rows.Count == 0)
                    {
                        DateTime bithday = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month.Text, dropd_day.Text, dropd_year.Text));
                        string sql = @"update ND_THONG_TIN_ND set NAME=@v_NAME, MEM_GROUP_ID=@v_MEM_GROUP_ID, ADDRESS=@v_ADDRESS,BIRTH_DAY=@v_BIRTH_DAY,SEX=@v_SEX,PHONE=@v_PHONE,FAX=@v_FAX, EMAIL=@v_EMAIL,WEBSITE=@v_WEBSITE,YAHOO=@v_YAHOO,SKYPE=@v_SKYPE,NOTE=@v_NOTE,EDITED_DATE=@v_EDITED_DATE,EDITED_BY=@v_EDITED_BY where id=@id";
                        int nd = SQLConnectWeb.ExecuteNonQuery(sql,
                                                    "@v_NAME", txt_full_name.Text,
                                                    "@v_MEM_GROUP_ID", dropd_group.SelectedValue,
                                                    "@v_ADDRESS", txt_address.Text,
                                                    "@v_BIRTH_DAY", bithday.ToString("yyyy-MM-dd"),
                                                    "@v_SEX", rd_sex.SelectedItem.Value,
                                                    "@v_PHONE", txt_phonenumber.Text,
                                                    "@v_FAX", txt_faxnumber.Text,
                                                    "@v_EMAIL", txt_email.Text,
                                                    "@v_WEBSITE", txt_website.Text,
                                                    "@v_YAHOO", txt_yahoo.Text,
                                                    "@v_SKYPE", txt_skype.Text,
                                                    "@v_NOTE", txt_note.Text,
                                                    "@v_EDITED_DATE", functions.GetStringDatetime(),
                                                    "@v_EDITED_BY", functions.LoginMemID(this),
                                                    "@id", Request.QueryString["id"]);

                        lbl_error.Text = String.Format("Lưu thông tin thành viên [<b>{0}-{1}</b>] thành công !", txt_username.Text, txt_full_name.Text);
                    }
                    else
                    {
                        lbl_error.Text = String.Format("Lưu thông tin thành viên [<b>{0}-{1}</b>] không thành công ! Địa chỉ email bạn thay đổi đã tồn tại<b> {2} </b>.", txt_username.Text, txt_full_name.Text, txt_email.Text);
                    }
                }
                else
                {


                    //Kiem tra Username
                    String username = txt_username.Text;
                    String email = txt_email.Text;
                    DataTable table = ND_THONG_TIN_DN.GetTableFields(ND_THONG_TIN_DN.cl_USERNAME + "=N'" + username + "'",
                        new string[] { }, ND_THONG_TIN_DN.cl_USERID);

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
                        DateTime bithday = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month.Text, dropd_day.Text, dropd_year.Text));
                        bool ok = false;

                        string sql_insert_ttdn = "INSERT INTO ND_THONG_TIN_DN (USERNAME, PWD, LASTED_ACCESS,CREATED_BY, CREATED_DATE, ISCHANGEPWD_BIT, ISACTIVE_BIT, MEM_ID)VALUES(@v_USERNAME, @v_PWD,@v_LASTED_ACCESS,@V_CREATED_BY, @v_CREATED_DATE, @v_ISCHANGEPWD_BIT,@v_ISACTIVE_BIT, @v_MEM_ID)"; //CREATED_BY  @v_CREATED_BY
                        string sql_insert_ttnd = "INSERT INTO ND_THONG_TIN_ND (NAME, MEM_GROUP_ID, ADDRESS,BIRTH_DAY,SEX,PHONE,FAX, EMAIL,WEBSITE,YAHOO,SKYPE,NOTE,VISIBLE_BIT,CREATED_DATE,CREATED_BY,HEART)VALUES(@v_NAME, @v_MEM_GROUP_ID, @v_ADDRESS,@v_BIRTH_DAY,@v_SEX, @v_PHONE,@V_FAX,@v_EMAIL,@V_WEBSITE,@V_YAHOO,@V_SKYPE,@V_NOTE,@v_VISIBLE_BIT,@v_CREATED_DATE,@v_CREATED_BY,@V_HEART)";

                        int nd = SQLConnectWeb.ExecuteNonQuery(sql_insert_ttnd,
                                                "@v_NAME", txt_full_name.Text,
                                                "@v_MEM_GROUP_ID", dropd_group.SelectedValue,
                                                "@v_ADDRESS", txt_address.Text,
                                                "@v_BIRTH_DAY", bithday.ToString("yyyy-MM-dd"),
                                                "@v_SEX", rd_sex.SelectedItem.Value,
                                                "@v_PHONE", txt_phonenumber.Text,
                                                "@v_FAX", txt_faxnumber.Text,
                                                "@v_EMAIL", txt_email.Text,
                                                "@v_WEBSITE", txt_website.Text,
                                                "@v_YAHOO", txt_yahoo.Text,
                                                "@v_SKYPE", txt_skype.Text,
                                                "@v_NOTE", txt_note.Text,
                                                "@v_VISIBLE_BIT", 'Y',
                                                "@v_CREATED_DATE", functions.GetStringDatetime(),
                                                "@v_CREATED_BY", functions.LoginMemID(this),
                                                "@V_HEART", 0);

                        /*
                        ND_THONG_TIN_ND nd = ND_THONG_TIN_ND.Insert_Object(
                            txt_full_name.Text,
                            "1",
                            txt_address.Text,
                            bithday.ToString("yyyy-MM-dd"),
                            rd_sex.SelectedItem.Value, txt_phonenumber.Text, "",
                            txt_email.Text, "", "", "", "", "", "", "Y", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                            "", "", "", "0");
                        */


                        if (nd != 0)
                        {
                            /*
                            ND_THONG_TIN_DN dn = ND_THONG_TIN_DN.Insert_Object(txt_username.Text,
                                txt_password.Text, "", "", "", "", "", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                                "", "", "Y", "Y", nd.ID);
                            if (dn != null)
                             */
                            string sql_getID = @"select id from ND_THONG_TIN_ND where email=@v_email";
                            DataTable tb_memID = SQLConnectWeb.GetData(sql_getID, "@v_email", email);
                            long v_memID = (long)tb_memID.Rows[0]["id"];
                            SQLConnectWeb.ExecuteNonQuery(sql_insert_ttdn,
                                                    "@v_USERNAME", txt_username.Text,
                                                    "@v_PWD", txt_password.Text,
                                                    "@v_LASTED_ACCESS", functions.GetStringDatetime(),
                                                    "@v_CREATED_BY", functions.LoginMemID(this),
                                                    "@v_CREATED_DATE", functions.GetStringDatetime(),
                                                    "@v_ISCHANGEPWD_BIT", 'Y',
                                                    "@v_ISACTIVE_BIT", 'Y',
                                                    "@v_MEM_ID", v_memID);

                            ok = true;

                        }
                        if (ok)
                            lbl_error.Text = String.Format("Thành viên [<b>{0}-{1}</b>] đã được tạo thành công.!", txt_username.Text, txt_full_name.Text);
                        else
                            lbl_error.Text = String.Format("Đăng ký thành viên [<b>{0}-{1}</b>] không thành công.  <br>Vui lòng kiểm tra lại thông tin!", txt_username.Text, txt_full_name.Text);
                    }
                    else
                    {

                        lbl_error.Text = String.Format("Tạo hành viên [<b>{0}-{1}</b>] không thành công. <br>Tên tài khoản hoặc địa chỉ email đã tồn tại trong hệ thống!", txt_username.Text, txt_full_name.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_error.Text = String.Format("Lưu thông tin thành viên [<b>{0}-{1}</b>] không thành công !", txt_username.Text, txt_full_name.Text);

            }
        }

 

      
    /*

        protected void btn_avatar_Click(object sender, EventArgs e)
        {
            try
            {
                string memid = functions.LoginMemID(this);
                String filename = upload_img.FileName;
                String file_type = System.IO.Path.GetExtension(filename);
                String avatar_name = memid + file_type;
                if ((file_type == ".jpg" || file_type == ".gif" || file_type == ".png"))
                {


                    //Update to database

                    String sql = "UPDATE ND_THONG_TIN_ND SET AVATAR_PATH=@v_AVATAR_PATH WHERE ID=@V_MEM_ID";
                    if (SQLConnectWeb.ExecuteNonQuery(sql,
                            "@v_AVATAR_PATH", avatar_name,
                            "@V_MEM_ID", memid) == 1)
                    {
                        const String path = "images/avatars/";
                        File.Delete(MapPath(path) + avatar_name);
                        upload_img.SaveAs(MapPath(path) + avatar_name);
                        //  lbl_error.Text = "Upload avatar thành công";
                        img_user.ImageUrl = path + avatar_name;
                        lbl_error.Text = "Cập nhật avatar thành công";
                    }
                    else
                    {
                        lbl_error.Text = "Cập nhật avatar không thành công, vui lòng kiểm tra lại thông tin!";
                    }
                }
                else
                {
                    lbl_error.Text = String.Format("Chỉ cho phép avatar định dạng JPG/GIF/PNG, file của bạn: {0}", filename);
                }
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Cập nhật avatar không thành công";
            }

        }
    */

    }
}