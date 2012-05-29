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
    public partial class post_news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["projectID"] != null)
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='post_news.aspx?projectID={0}'title='Bài mới'>Bài mới</a> ", Request.QueryString["projectID"]);
                else if (Request.QueryString["post_id"] != null)
                {

                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='forum.aspx' title='Diễn đàn'>Diễn đàn</a> >> <a href='post_show_details.aspx?news_id={0}'title='Bài viết'>Bài viết</a> ", Request.QueryString["post_id"]);
                    display();
                }
                else
                {
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='forum.aspx' title='Diễn đàn'>Diễn đàn</a> >> <a href='post_news.aspx?subjectID={0}' title='Bài mới'>Bài mới</a>", Request.QueryString["subjectID"]);
                }
                txt_title.Focus();
                ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";
                
            }
        }
        public void display()
        {

            try
            {
                String sql = string.Format(@"SELECT a.*,b.USERNAME
                         FROM BV_BAI_VIET a
                        INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
                        WHERE BAI_VIET_ID={0} Order by sort,BAI_VIET_ID", Request.QueryString["post_id"]);
                DataTable table = SQLConnectWeb.GetTable(sql);
                if (table.Rows[0]["sort"] != null)
                    txt_sort.Text = table.Rows[0]["sort"].ToString();
                else
                    txt_sort.Text = "0";

                txt_title.Text = table.Rows[0]["tieu_de"].ToString();
                ASPxHtmlEditor1.Html = table.Rows[0]["noi_dung"].ToString();

            }
            catch
            { 
            }
        
        }
        protected void btn_post_news_Click(object sender, EventArgs e)
        {
            
            //String sql = "INSERT INTO BV_BAI_VIET(TIEU_DE,NGUOI_TAO,NGAY_TAO,NOI_DUNG,TRANG_THAI_ID,CHU_DE_ID,SORT)VALUES(@V_TIEU_DE,@V_NGUOI_TAO,@V_NGAY_TAO,@V_NOI_DUNG,@V_TRANG_THAI_ID,@V_CHU_DE_ID,@V_SORT)";
            try
            {
                
                //DataTable table = (DataTable)Session["ThanhVien"];
                //string memid = functions.LoginMemID(this);
                //Database.ExecuteNonQuery(sql,
                //                 "@V_TIEU_DE", txt_title.Text,
                //                 "@V_NGUOI_TAO", memid,
                //                 "@V_NGAY_TAO", functions.GetStringDatetime(),
                //                 "@V_NOI_DUNG", ASPxHtmlEditor1.Html,
                //                 "@V_TRANG_THAI_ID", 1,
                //                 "@V_CHU_DE_ID", Request.QueryString["subjectID"],
                //                 "@V_SORT", txt_sort.Text);

                string date = functions.GetStringDatetime();
                string memid = functions.LoginMemID(this);

                if (Request.QueryString["post_id"] != null)
                {
                    String sql = "UPDATE BV_BAI_VIET SET TIEU_DE=@TIEU_DE,NGUOI_CAP_NHAT=@NGUOI_CAP_NHAT,NGAY_CAP_NHAT=@NGAY_CAP_NHAT,NOI_DUNG=@NOI_DUNG,SORT=@SORT WHERE BAI_VIET_ID=@BAI_VIET_ID";
                    int result = SQLConnectWeb.ExecuteNonQuery(sql,
                                     "@TIEU_DE", txt_title.Text,
                                     "@NGUOI_CAP_NHAT", memid,
                                     "@NGAY_CAP_NHAT", functions.GetStringDatetime(),
                                     "@NOI_DUNG", ASPxHtmlEditor1.Html.Replace("'", ""),
                                     "@SORT", txt_sort.Text,
                                     "@BAI_VIET_ID", Request.QueryString["post_id"]);
                    if(result!=0)
                        lbl_error.Text = "Cập nhật bài viết thành công";
                }
                else
                {

                    BV_BAI_VIET bv = BV_BAI_VIET.Insert_Object(txt_title.Text.Replace("'", ""), memid,
                       date, memid,
                       date.ToString(),
                        ASPxHtmlEditor1.Html.Replace("'", ""), "1", "", Request.QueryString["projectID"], Request.QueryString["subjectID"], txt_sort.Text, "0");
                    //if (row != 0)
                    lbl_error.Text = "Đăng bài thành công";
                    //else
                    //    lbl_error.Text = "Đăng bài không thành công";

                }
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Lưu bài viết không thành công, vui lòng kiểm tra lại thông tin";
                
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("forum.aspx");
        }


    }
}