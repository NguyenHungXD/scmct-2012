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
    public partial class edit_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                functions.add_date_to_dropd(dropd_day, dropd_month, dropd_year,0);
                display_info();
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='edit_profife.aspx' title='Cập nhật thông tin cá nhân'>Cập nhật thông tin cá nhân</a> ";
            }
        }

        private void display_info()
        {
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                if (table != null)
                {
                    ND_THONG_TIN_ND nd = new ND_THONG_TIN_ND(table, 0);
                    String avatar_name = nd.AVATAR_PATH == "" ? "default_img.gif" : nd.AVATAR_PATH;
                    txt_username.Text = (String)table.Rows[0][ND_THONG_TIN_DN.cl_USERNAME];
                    if (table.Rows[0][ND_THONG_TIN_DN.cl_LASTED_ACCESS].ToString() != null)
                    {
                        DateTime lasted_access = (DateTime)table.Rows[0][ND_THONG_TIN_DN.cl_LASTED_ACCESS];
                        lbl_lasted_access.Text = lasted_access.ToString("dd/MM/yyyy hh:mm:ss tt");
                    }
                    else
                    {
                        lbl_lasted_access.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

                    }

                    img_user.ImageUrl = "Images/avatars/" + avatar_name;

                    //Fill data on form
                    
                    txt_address.Text =nd.ADDRESS;
                    txt_full_name.Text = nd.NAME;
                    txt_faxnumber.Text = nd.FAX;
                    txt_phonenumber.Text = nd.PHONE;
                    txt_email.Text = nd.EMAIL;
                    txt_website.Text = nd.WEBSITE;
                    txt_skype.Text = nd.SKYPE;
                    txt_yahoo.Text = nd.YAHOO;
                    DateTime birthday = DateTime.Parse(nd.BIRTH_DAY);

                    functions.selectedDropdown(dropd_day, birthday.Day.ToString());
                    functions.selectedDropdown(dropd_month, birthday.Month.ToString());
                    functions.selectedDropdown(dropd_year, birthday.Year.ToString());

                    rd_sex.Items[int.Parse(nd.SEX)].Selected = true;

                    lbl_group_name.Text = (String)table.Rows[0][ND_TEN_NHOM_ND.cl_GROUPNAME];
                    txt_note.Text = nd.NOTE;
                    
                }
            }
            catch (Exception ex) {
                lbl_group_name.Text = ex.ToString();
                //Response.Redirect("error_page.aspx");
            }
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btn_updateprofile_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)Session["ThanhVien"];
            ND_THONG_TIN_ND nd = new ND_THONG_TIN_ND(table, 0);
            try
            {
                DateTime bithday = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month.Text, dropd_day.Text, dropd_year.Text));               
                bool ok = nd.Save_Object(txt_full_name.Text, nd.MEM_GROUP_ID, txt_address.Text, functions.GetStringDate(bithday),
                    rd_sex.SelectedItem.Value, txt_phonenumber.Text, txt_faxnumber.Text, txt_email.Text, txt_website.Text,
                   txt_yahoo.Text, txt_skype.Text, nd.TAX_CODE, nd.NOTE, nd.AVATAR_PATH, nd.VISIBLE_BIT,functions.CheckDate(nd.CREATED_DATE), nd.EDITED_BY,
                   functions.GetStringDatetime(), nd.ID,nd.HEART);
                if (ok)
                    lbl_error.Text = "Cập nhật thông tin cá nhân thành công";
                else lbl_error.Text = "Cập nhật thông tin cá nhân không thành công, vui lòng kiểm tra lại thông tin!";
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Cập nhật thông tin cá không thành công" ;
            }
        }


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
                            "@V_MEM_ID", memid)==1)
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

        protected void btn_close_Click1(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

     

        



        } 
}