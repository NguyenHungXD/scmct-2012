using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
namespace chiase
{
    public partial class edit_profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                functions.add_date_to_dropd(dropd_day, dropd_month, dropd_year,0);
                display_info();
                
            }
        }

        private void display_info()
        {
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                if (table != null)
                {
                    String avatar_name = Convert.IsDBNull(table.Rows[0]["avatar_path"]) ? "default_img.gif" : (String)table.Rows[0]["avatar_path"];
                    txt_username.Text = (String)table.Rows[0]["username"];
                    DateTime lasted_access = (DateTime)table.Rows[0]["lasted_access"];
                    lbl_lasted_access.Text = lasted_access.ToString("dd/mm/yyyy hh:mm:ss tt");
                    img_user.ImageUrl = "Images/avatars/" + avatar_name;

                    String sql = "SELECT a.*,b.* FROM ND_THONG_TIN_ND a,ND_TEN_NHOM_ND b WHERE a.MEM_GROUP_ID = b.GROUPID AND a.ID=@v_memID";
                    DataTable table_info = Database.GetData(sql, "@v_memID", table.Rows[0]["mem_id"]);

                    //Fill data on form
                    
                    txt_address.Text = Convert.IsDBNull(table_info.Rows[0]["address"]) ? "" : (String)table_info.Rows[0]["address"];
                    txt_full_name.Text = Convert.IsDBNull(table_info.Rows[0]["name"]) ? "" : (String)table_info.Rows[0]["name"];
                    txt_faxnumber.Text = Convert.IsDBNull(table_info.Rows[0]["fax"])? "" :(String)table_info.Rows[0]["fax"];
                    txt_phonenumber.Text = Convert.IsDBNull(table_info.Rows[0]["phone"]) ? "" : (String)table_info.Rows[0]["phone"];
                    txt_email.Text = Convert.IsDBNull(table_info.Rows[0]["email"]) ? "" : (String)table_info.Rows[0]["email"];
                    txt_faxnumber.Text = Convert.IsDBNull(table_info.Rows[0]["fax"]) ? "" : (String)table_info.Rows[0]["fax"];
                    txt_website.Text = Convert.IsDBNull(table_info.Rows[0]["website"]) ? "" : (String)table_info.Rows[0]["website"];
                    txt_skype.Text = Convert.IsDBNull(table_info.Rows[0]["skype"]) ? "" : (String)table_info.Rows[0]["skype"];
                    txt_yahoo.Text = Convert.IsDBNull(table_info.Rows[0]["yahoo"]) ? "" : (String)table_info.Rows[0]["yahoo"];
                    DateTime birthday =  (DateTime)table_info.Rows[0]["birth_day"];

                    dropd_day.SelectedIndex = functions.selectedDropdown(dropd_day, birthday.Day.ToString());
                    dropd_month.SelectedIndex =  functions.selectedDropdown(dropd_month, birthday.Month.ToString());
                    dropd_year.SelectedIndex = functions.selectedDropdown(dropd_year, birthday.Year.ToString());

                    rd_sex.Items[(int)table_info.Rows[0]["sex"]].Selected = true;
                    lbl_group_name.Text = (String)table_info.Rows[0]["groupname"];
                    txt_note.Text = Convert.IsDBNull(table_info.Rows[0]["note"]) ? "" : (String)table_info.Rows[0]["note"];
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

        protected void btn_update_profile_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)Session["ThanhVien"];
            String sql = "UPDATE ND_THONG_TIN_ND SET NAME=@v_NAME, ADDRESS=@v_ADDRESS,BIRTH_DAY=@v_BIRTH_DAY,SEX=@v_SEX, PHONE=@v_PHONE,FAX=@v_FAX, EMAIL=@v_EMAIL,WEBSITE=@v_WEBSITE,SKYPE=@v_SKYPE,YAHOO=@v_YAHOO,NOTE=@v_NOTE,EDITED_BY=@v_EDITED_BY,EDITED_DATE=@v_EDITED_DATE WHERE ID=@V_MEM_ID";
            try
            {
                DateTime bithday = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month.Text, dropd_day.Text, dropd_year.Text));
                Database.ExecuteNonQuery(sql,
                        "@v_NAME", txt_full_name.Text,
                        "@v_ADDRESS", txt_address.Text,
                        "@v_BIRTH_DAY", bithday,
                        "@v_SEX", rd_sex.SelectedItem.Value,
                        "@v_PHONE", txt_phonenumber.Text,
                        "@v_FAX", txt_faxnumber.Text,
                        "@v_EMAIL", txt_email.Text,
                        "@v_WEBSITE",txt_website.Text,
                        "@v_SKYPE", txt_skype.Text,
                        "@v_YAHOO", txt_yahoo.Text,
                        "@v_NOTE",txt_note.Text,
                        "@v_EDITED_BY",table.Rows[0]["mem_id"],
                        "@v_EDITED_DATE", DateTime.Now,
                        "@V_MEM_ID", table.Rows[0]["mem_id"]);

                lbl_error.Text = "Cập nhật thông tin cá nhân thành công";
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Cập nhật thông tin cá không thành công" + ex.ToString();
            }
        }

        protected void btn_update_avatar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                String filename = upload_img.FileName;
                String file_type = System.IO.Path.GetExtension(filename);
                String avatar_name = table.Rows[0]["mem_id"].ToString() + file_type;
                if ((file_type == ".jpg" || file_type == ".gif" || file_type == ".png"))
                {
                    const String path = "images/avatars/";
                    File.Delete(MapPath(path) + avatar_name);
                    upload_img.SaveAs(MapPath(path) + avatar_name);
                    lbl_error.Text = "Cập nhật avatar thành công";
                    img_user.ImageUrl = path + avatar_name;

                    //Update to database

                    String sql = "UPDATE ND_THONG_TIN_ND SET AVATAR_PATH=@v_AVATAR_PATH WHERE ID=@V_MEM_ID";
                    Database.ExecuteNonQuery(sql,
                            "@v_AVATAR_PATH", avatar_name,
                            "@V_MEM_ID", table.Rows[0]["mem_id"]);

                    lbl_error.Text = "Cập nhật avatar thành công";
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

    

   





     



   

   
    }
}