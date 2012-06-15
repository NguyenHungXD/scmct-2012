using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using chiase.Objects;
using DK2C.DataAccess.Web;
namespace chiase
{
    public partial class hot_news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            //Check LogIn session
            {
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                display();
            }
            Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='hot_news.aspx' title='Cập nhật bài viết nổi bật'>Bài viết nổi bật</a>";
        }
        public void display()
        {
            try
            {
                string sql = @"select bai_viet_id,tieu_de from bv_bai_viet where bai_viet_cha_id is null order by bai_viet_id";
                DataTable table = SQLConnectWeb.GetTable(sql);
                functions.fill_DropdownList(DropDownList1, table, 0, 1);
                functions.fill_DropdownList(DropDownList2, table, 0, 1);
                functions.fill_DropdownList(DropDownList3, table, 0, 1);
                functions.fill_DropdownList(DropDownList4, table, 0, 1);

                string sql_hotnews = @"select a.* from bv_hot_news a where active='Y' order by id";
                DataTable table_hotnews = SQLConnectWeb.GetTable(sql_hotnews);

                //1.
                functions.selectedDropdown(DropDownList1, table_hotnews.Rows[0]["post_id"].ToString());
                functions.selectedDropdown(DropDownList2, table_hotnews.Rows[1]["post_id"].ToString());
                functions.selectedDropdown(DropDownList3, table_hotnews.Rows[2]["post_id"].ToString());
                functions.selectedDropdown(DropDownList4, table_hotnews.Rows[3]["post_id"].ToString());
                //Content c = this.FindControl("Content2") as Content;

                Boolean check = functions.checkPrivileges("23", functions.LoginMemID(this), "E");
                lbl_edit_hot_news.Visible = check;

                    for (int i = 1; i < 5; i++)
                    {
                        Label lb = (Label)content.FindControl("Label" + i);
                        lb.Visible = check;

                        TextBox title = (TextBox)content.FindControl("TextBox" + i);
                        title.Text = (String)table_hotnews.Rows[i - 1]["title"];

                        TextBox contents = (TextBox)content.FindControl(String.Format("TextBox{0}{0}", i));
                        contents.Text = (String)table_hotnews.Rows[i - 1]["contents"];

                        Image img = (Image)content.FindControl("Image" + i);
                        img.ImageUrl = (String)table_hotnews.Rows[i - 1]["img_path"];

                        HyperLink link = (HyperLink)content.FindControl("HyperLink"+i);
                        link.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}", table_hotnews.Rows[i - 1]["post_id"]);

                    }
            }
            catch
            { }
        
        }

        protected void btn_save_Click1(object sender, EventArgs e)
        {
            try
            {
                string itemSaved = "";
                string memid = functions.LoginMemID(this);
        //1.
                for (int i = 1; i < 5; i++)
                {
                    TextBox titles = (TextBox)content.FindControl("TextBox" + i);
                    string title = titles.Text;

                    FileUpload fileupload = (FileUpload)content.FindControl("FileUpload" + i);
                    string filename = fileupload.FileName;
                    String file_type = System.IO.Path.GetExtension(filename).ToLower(); //nvdatFixBug: some imgage type with Uppercase extension name

                    TextBox _content = (TextBox)content.FindControl(String.Format("TextBox{0}{0}", i));
                    string contents = _content.Text;

                    DropDownList dropd = (DropDownList)content.FindControl("DropDownList" + i);
                    string postid = dropd.SelectedValue;

                    String img_path = String.Format("images/content_slider/{0}{1}",i, file_type);
                    string path = "images/content_slider/";
                    string img_name = i.ToString() + file_type;
                    if ((file_type == ".jpg" || file_type == ".gif" || file_type == ".png" || file_type == "") && (CheckBox1.Checked == true))
                    {
                        int ok = 0;
                        if (file_type != "")
                        {
                            File.Delete(MapPath(img_path));
                            fileupload.SaveAs(MapPath(img_path));
                            String sql = "UPDATE BV_HOT_NEWS SET POST_ID=" + postid + ",TITLE=N'" + title  + "',CONTENTS=N'" + contents + "',IMG_PATH='" + img_path + "',EDITED_BY=" + memid + ",EDITED_DATE='" + functions.GetStringDatetime() + "' WHERE ID=" + i;
                            ok=SQLConnectWeb.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            String sql = "UPDATE BV_HOT_NEWS SET POST_ID=" + postid + ",TITLE=N'" + title + "',CONTENTS=N'" + contents + "',EDITED_BY=" + memid + ",EDITED_DATE='" + functions.GetStringDatetime() + "' WHERE ID=" + i;
                             ok=SQLConnectWeb.ExecuteNonQuery(sql);
                        }
                        if(ok==1)
                            itemSaved = String.Format("{0}Lưu thông tin thành công bài {1}<br>", itemSaved, i);
                    }

                }

                    lbl_error.Text = itemSaved;
            }
            catch(Exception ex)
            {
                lbl_error.Text = "Lưu thông tin không thành công!";
            
            }

            
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }


    }
}