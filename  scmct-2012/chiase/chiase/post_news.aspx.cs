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
        public static Boolean check;
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_title.Focus();
            ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";

            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                if (functions.checkPrivileges("22", functions.LoginMemID(this), "E") || functions.checkPrivileges("22", functions.LoginMemID(this), "C"))
                    check = true;
                else
                    check = false;

                    lbl_sort.Visible = check;

                //if (Request.QueryString["types_id"] =="2")
                //    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='project_detail.aspx?id={0}' title='Dự án'>Dự án</a> >> <a href='post_news.aspx?projectID={0}'title='Bài mới'>Bài mới</a> ", Request.QueryString["projectID"]);
                //else if (Request.QueryString["types_id"] == "1")
                //{
                //    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='forum.aspx' title='Diễn đàn'>Diễn đàn</a> >> <a href='post_news.aspx?subjectID={0}' title='Bài mới'>Bài mới</a>", Request.QueryString["subjectID"]);
                //}
                if (Request.QueryString["post_id"] != null)
                {
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='forum.aspx' title='Diễn đàn'>Diễn đàn</a> >> <a href='post_show_details.aspx?news_id={0}'title='Bài viết'>Bài viết</a> ", Request.QueryString["post_id"]);
                    display();
                }

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
                int result;
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
                    if (check)
                    {
                        String sql = "UPDATE BV_BAI_VIET SET TIEU_DE=@TIEU_DE,NGUOI_CAP_NHAT=@NGUOI_CAP_NHAT,NGAY_CAP_NHAT=@NGAY_CAP_NHAT,NOI_DUNG=@NOI_DUNG,SORT=@SORT WHERE BAI_VIET_ID=@BAI_VIET_ID";
                         result = SQLConnectWeb.ExecuteNonQuery(sql,
                                     "@TIEU_DE", txt_title.Text,
                                     "@NGUOI_CAP_NHAT", memid,
                                     "@NGAY_CAP_NHAT", functions.GetStringDatetime(),
                                     "@NOI_DUNG", ASPxHtmlEditor1.Html.Replace("'", ""),
                                     "@SORT", txt_sort.Text,
                                     "@BAI_VIET_ID", Request.QueryString["post_id"]);
                    }
                    else
                    {
                        String sql = "UPDATE BV_BAI_VIET SET TIEU_DE=@TIEU_DE,NGUOI_CAP_NHAT=@NGUOI_CAP_NHAT,NGAY_CAP_NHAT=@NGAY_CAP_NHAT,NOI_DUNG=@NOI_DUNG WHERE BAI_VIET_ID=@BAI_VIET_ID";

                         result = SQLConnectWeb.ExecuteNonQuery(sql,
                                         "@TIEU_DE", txt_title.Text,
                                         "@NGUOI_CAP_NHAT", memid,
                                         "@NGAY_CAP_NHAT", functions.GetStringDatetime(),
                                         "@NOI_DUNG", ASPxHtmlEditor1.Html.Replace("'", ""),
                                         "@BAI_VIET_ID", Request.QueryString["post_id"]);
                    }

                    if(result!=0)
                        lbl_error.Text = "Cập nhật bài viết thành công";

                    //Response.Redirect("post_show_details.aspx?news_id=" + Request.QueryString["post_id"] + "&");
                    Response.Redirect(String.Format("post_show_details.aspx?news_id={0}&subjectID={1}&types_id={2}", Request.QueryString["post_id"], Request.QueryString["subjectID"], Request.QueryString["types_id"]));
                }
                else
                {
                    string sort="0";
                    if (check)
                        sort = txt_sort.Text;
                    //BV_BAI_VIET bv = BV_BAI_VIET.Insert_Object(txt_title.Text.Replace("'", ""), memid,
                    //   date, memid,
                    //   date.ToString(),
                    //    ASPxHtmlEditor1.Html.Replace("'", ""), "1", "", Request.QueryString["projectID"], Request.QueryString["subjectID"], sort, "0");
                    //string projectID = Request.QueryString["projectID"];
                    //if (Request.QueryString["projectID"] == null || Request.QueryString["projectID"] == "") projectID = "";

                    string subjectID = Request.QueryString["subjectID"];
                    if (Request.QueryString["subjectID"] != null && Request.QueryString["subjectID"] != "")
                    {

                        if (Request.QueryString["types_id"] == "5")
                        {
                            string sql = @"insert into BV_BAI_VIET (tieu_de,nguoi_tao,ngay_tao,noi_dung,trang_thai_id,du_an_id,sort) 
                                               values(@tieu_de,@nguoi_tao,@ngay_tao,@noi_dung,@trang_thai_id,@du_an_id,@sort)";


                            SQLConnectWeb.ExecuteNonQuery(sql,
                                "@tieu_de", txt_title.Text.Replace("'", ""), "@nguoi_tao", memid, "@ngay_tao", date, "@noi_dung", ASPxHtmlEditor1.Html.Replace("'", ""), "@trang_thai_id", "1", "@du_an_id", subjectID, "@sort", sort);
                        }
                        else
                        {
                            string sql = @"insert into BV_BAI_VIET (tieu_de,nguoi_tao,ngay_tao,noi_dung,trang_thai_id,chu_de_id,sort) 
                                               values(@tieu_de,@nguoi_tao,@ngay_tao,@noi_dung,@trang_thai_id,@chu_de_id,@sort)";


                            SQLConnectWeb.ExecuteNonQuery(sql,
                                "@tieu_de", txt_title.Text.Replace("'", ""), "@nguoi_tao", memid, "@ngay_tao", date, "@noi_dung", ASPxHtmlEditor1.Html.Replace("'", ""), "@trang_thai_id", "1", "@chu_de_id", subjectID, "@sort", sort);
                        
                        }
                        string sqlgetmaxID = @"select BAI_VIET_ID from BV_BAI_VIET where BAI_VIET_ID=(select max(BAI_VIET_ID) from BV_BAI_VIET where nguoi_tao=@nguoi_tao and bai_viet_cha_id is null)";
                        DataTable dt = SQLConnectWeb.GetData(sqlgetmaxID, "@nguoi_tao", memid);

                        Response.Redirect(String.Format("post_show_details.aspx?news_id={0}&subjectID={1}&types_id={2}", dt.Rows[0]["BAI_VIET_ID"], subjectID,Request.QueryString["types_id"]));

                        //if (Request.QueryString["subjectID"] != null && Request.QueryString["subjectID"] !="")
                        //{
                        //    Response.Redirect("post_show_details.aspx?news_id=" + dt.Rows[0]["BAI_VIET_ID"] + "&subjectID=" + subjectID);
                        //}
                        //else if (Request.QueryString["projectID"] != null && Request.QueryString["projectID"] != "")
                        //{
                        //    Response.Redirect("post_show_details.aspx?news_id=" + dt.Rows[0]["BAI_VIET_ID"] + "&projectID=" + projectID);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                //lbl_error.Text = "Lưu bài viết không thành công, vui lòng kiểm tra lại thông tin";
                
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("forum.aspx");
        }


    }
}