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
    public partial class project_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                display();
            Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='project_detail.aspx?id={0}'title='Xem chi tiết'>Xem chi tiết</a> ", Request.QueryString["id"]);
        }
        public void display()
        {
            try
            {
                String sql = @"select a.*,b.name
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID Where a.id=@v_id ";

                DataTable table = SQLConnectWeb.GetData(sql, "@v_id", Request.QueryString["id"]);

                lbl_post_new.Visible = functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                linkPostnew.NavigateUrl = "post_news.aspx?projectID=" + Request.QueryString["id"];
                
                if (table.Rows.Count > 0)
                {
                    //lbl_project_name.Text = (String)table.Rows[0]["TEN_DU_AN"];
                    lbl_tenduan.Text = (String)table.Rows[0]["TEN_DU_AN"];
                    lbl_maduan.Text = (String)table.Rows[0]["MA_DU_AN"];
                    Int64 book = (Int64)table.Rows[0]["BOOK"];
                    lbl_book.Text = book.ToString();
                    lbl_ghichu.Text = (String)table.Rows[0]["GHI_CHU"];
                    lbl_chitiet.Text = (String)table.Rows[0]["CHI_TIET"];
                    lbl_trangthai.Text= (String)table.Rows[0]["NAME"];
                    DateTime start_date = (DateTime)table.Rows[0]["ngay_bat_dau"];
                    DateTime end_date = (DateTime)table.Rows[0]["ngay_ket_thuc"];
                    lbl_batdau.Text = start_date.ToString("dd/MM/yyyy");
                    lbl_ketthuc.Text = end_date.ToString("dd/MM/yyyy");

                    //nvdat02/04/12 : Get posted_by field --commented-out and replace
                    String sql_show_post = string.Format(@"SELECT a.*,b.USERNAME,case when c.avatar_path is null then 'default_img.gif' else c.avatar_path end as avatar_path
                         FROM BV_BAI_VIET a
                        INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
                        INNER JOIN ND_THONG_TIN_ND c ON a.NGUOI_TAO = c.ID
                        WHERE DU_AN_ID={0} and BAI_VIET_CHA_ID IS NULL", Request.QueryString["id"]);
                    DataTable baiviet = SQLConnectWeb.GetTable(sql_show_post);

                    showListPost.DataSource = baiviet;
                    showListPost.DataBind();
                }
            }
            catch (Exception ex)
            {
               // lbl_error.Text = "Có lổi trong lúc hiển thị dữ liệu";
            }
        }

        protected void showListPost_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                //Count viewing times
                Label cnt_view = (Label)e.Item.FindControl("lbl_cnt_view");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row[BV_BAI_VIET.cl_BAI_VIET_ID];
                String sql_cnt = string.Format(@"SELECT count(*) as cnt FROM BV_BAI_VIET WHERE BAI_VIET_CHA_ID={0}", id);
                DataTable cnt = SQLConnectWeb.GetTable(sql_cnt);
                cnt_view.Text = cnt.Rows[0]["cnt"].ToString();

                //New comment, commented by, commented date
                HyperLink cm_link = (HyperLink)e.Item.FindControl("link_comment");
                HyperLink post_show= (HyperLink)e.Item.FindControl("link_show_detail");

                HyperLink cm_by = (HyperLink)e.Item.FindControl("link_cm_by");
                Label cm_date = (Label)e.Item.FindControl("lbl_date_time");
                post_show.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}", id);

                //HyperLink linkPostnew = (HyperLink)e.Item.FindControl("linkPostnew");
                //linkPostnew.NavigateUrl = "post_news.aspx?projectID=" + Request.QueryString["id"];


                String sql_lasted_cm = string.Format(@"SELECT bbv.*,nd.username FROM BV_BAI_VIET bbv 
                        INNER JOIN ND_THONG_TIN_DN nd ON bbv.NGUOI_TAO = nd.MEM_ID
                        WHERE 
                        bbv.BAI_VIET_ID = (SELECT MAX(BAI_VIET_ID) FROM BV_BAI_VIET bbv2 WHERE bbv2.BAI_VIET_CHA_ID ={0} )", id);
                DataTable lasted_cm = SQLConnectWeb.GetTable(sql_lasted_cm);
                if (lasted_cm.Rows.Count > 0)
                {
                    String lasted_comment = lasted_cm.Rows[0]["noi_dung"].ToString();
                    if (lasted_comment.Length > 50)
                        lasted_comment = lasted_comment.Substring(0, 30) + "...";
                    cm_link.Text = lasted_comment;

                    cm_link.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}", id);


                    string str_cm = lasted_cm.Rows[0]["username"].ToString();
                    cm_by.Text = str_cm;
                    cm_by.NavigateUrl = string.Format("user_info.aspx?user_name={0}", lasted_cm.Rows[0]["username"]);
                    DateTime created_date = (DateTime)lasted_cm.Rows[0]["ngay_tao"];
                    cm_date.Text = created_date.ToString("dd/MM/yyyy hh:mm:ss tt");
                }
                //Vote
                long vote = (long)RowView.Row["liked"];

                Image img1 = (Image)e.Item.FindControl("Image2");
                Image img2 = (Image)e.Item.FindControl("Image5");
                Image img3 = (Image)e.Item.FindControl("Image6");
                Image img4 = (Image)e.Item.FindControl("Image7");
                Image img5 = (Image)e.Item.FindControl("Image8");

                if (vote >= 10)
                {
                    img1.ImageUrl = "images/star.gif";
                }
                else if (vote >= 50)
                {
                    img1.ImageUrl = "images/star.gif";
                    img2.ImageUrl = "images/star.gif";
                }
                else if (vote >= 100)
                {
                    img1.ImageUrl = "images/star.gif";
                    img2.ImageUrl = "images/star.gif";
                    img3.ImageUrl = "images/star.gif";
                }
                else if (vote >= 300)
                {
                    img1.ImageUrl = "images/star.gif";
                    img2.ImageUrl = "images/star.gif";
                    img3.ImageUrl = "images/star.gif";
                    img4.ImageUrl = "images/star.gif";
                }
                else if (vote >= 500)
                {
                    img1.ImageUrl = "images/star.gif";
                    img2.ImageUrl = "images/star.gif";
                    img3.ImageUrl = "images/star.gif";
                    img4.ImageUrl = "images/star.gif";
                    img5.ImageUrl = "images/star.gif";
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}