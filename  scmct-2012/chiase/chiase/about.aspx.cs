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
    public partial class about : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["current"] = "5"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
                lbl_create_new_subject.Visible = functions.checkPrivileges("20", functions.LoginMemID(this), "C");
                display();
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='about.aspx' title='Giới thiệu'>Giới thiệu</a> ";
            }
        }
        public void display()
        {
            try
            {
                string sql = @"select a.*, 'post_news.aspx?subjectID='+ convert(nvarchar,a.chu_de_id) +'&types_id=' + convert(nvarchar,a.types_id) url from BV_DM_CHU_DE_BV a
                                        where deleted is null and types_id=3 order by sort,title"; //3.Tin Tuc
                DataTable table = SQLConnectWeb.GetTable(sql);
                showListNews.DataSource = table;
                showListNews.DataBind();

                showListNewsDetail.DataSource = table;
                showListNewsDetail.DataBind();
            }
            catch (Exception ex)
            {
            }

        }
        protected void showListNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label lbl_edit_subject = (Label)e.Item.FindControl("lbl_edit_subject");
                lbl_edit_subject.Visible = functions.checkPrivileges("20", functions.LoginMemID(this), "E");
                Label lbl_del_subject = (Label)e.Item.FindControl("lbl_del_subject");
                lbl_del_subject.Visible = functions.checkPrivileges("20", functions.LoginMemID(this), "D");


                //Repeater showListPost = (Repeater)e.Item.FindControl("showListNews");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long subjectID = (long)RowView.Row["chu_de_id"];
                Image link_detail = (Image)e.Item.FindControl("userImg");
                HyperLink details = (HyperLink)e.Item.FindControl("details");
                Label created_by = (Label)e.Item.FindControl("created_by");

                string sql = @"select A.BAI_VIET_ID,A.TIEU_DE,A.NGAY_TAO,ND.NAME NGUOI_TAO,DN.USERNAME,ISNULL(nd.AVATAR_PATH,'default_img.gif') AVATAR_PATH,A.NOI_DUNG,A.CHU_DE_ID,A.XEM,A.LIKED from
                                    BV_BAI_VIET A 
                                    INNER JOIN ND_THONG_TIN_ND ND ON ND.ID = A.NGUOI_TAO
                                    INNER JOIN ND_THONG_TIN_DN DN ON DN.MEM_ID= A.NGUOI_TAO
                                    where A.BAI_VIET_ID = 
                                    (select max(BV.BAI_VIET_ID) 
                                    from 
                                    BV_BAI_VIET BV
                                    inner join BV_DM_CHU_DE_BV DMCDBV ON DMCDBV.CHU_DE_ID = BV.CHU_DE_ID
                                    WHERE DMCDBV.TYPES_ID =3
                                    AND BV.BAI_VIET_CHA_ID IS NULL
                                    AND BV.DELETED IS NULL
                                    AND BV.CHU_DE_ID=" + subjectID + ")";
                DataTable table = SQLConnectWeb.GetTable(sql);
                if (table.Rows.Count == 0)
                {
                    link_detail.Visible = false;
                }
                else
                {
                    link_detail.ImageUrl = "images/avatars/" + table.Rows[0]["AVATAR_PATH"];
                    details.Text = table.Rows[0]["TIEU_DE"].ToString() + " <img src='images/new.gif' width=40 height=30>";
                    details.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}&types_id=3&subjectID={1}", table.Rows[0]["BAI_VIET_ID"], subjectID);
                    DateTime created_date = (DateTime)table.Rows[0]["ngay_tao"];
                    created_by.Text = "<b>" + table.Rows[0]["username"].ToString() + "</b>";
                    Label texts = (Label)e.Item.FindControl("lbl_text");
                    Label created_dates = (Label)e.Item.FindControl("created_date");
                    texts.Text = "Đăng bởi, ";
                    created_dates.Text = created_date.ToString("dd/MM/yyyy hh:mm:ss tt");

                    string sql_cnt = @"select count(BV.BAI_VIET_ID) cnt
                                        from BV_BAI_VIET BV
                                        inner join BV_DM_CHU_DE_BV DMCDBV ON DMCDBV.CHU_DE_ID = BV.CHU_DE_ID
                                        WHERE DMCDBV.TYPES_ID =3
                                        AND BV.BAI_VIET_CHA_ID IS NULL
                                        AND BV.DELETED IS NULL
                                        AND BV.CHU_DE_ID=" + subjectID;
                    DataTable tables = SQLConnectWeb.GetTable(sql_cnt);
                    Label lbl_cnt = (Label)e.Item.FindControl("lbl_cnt");
                    lbl_cnt.Text = "<b>" + tables.Rows[0]["cnt"].ToString() + "</b> bài viết";



                }


            }
            catch (Exception ex)
            {
                //lbl_new_subject.Text = ex.ToString();

            }
        }

        protected void showListNewsDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                Label lb_create_news = (Label)e.Item.FindControl("lbl_post_new");
                lb_create_news.Visible = functions.checkPrivileges("20", functions.LoginMemID(this), "C");

                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long subjectID = (long)RowView.Row["chu_de_id"];

                HyperLink lbl_first_news_title = (HyperLink)e.Item.FindControl("first_news_title");
                Label lbl_first_news_content = (Label)e.Item.FindControl("first_news_content");
                HyperLink link = (HyperLink)e.Item.FindControl("link_view");

                string sql = @"select A.BAI_VIET_ID,A.TIEU_DE,substring(A.NOI_DUNG,1,500) + '...' NOI_DUNG,A.NGAY_TAO,ND.NAME NGUOI_TAO,DN.USERNAME,ISNULL(nd.AVATAR_PATH,'default_img.gif') AVATAR_PATH,A.NOI_DUNG,A.CHU_DE_ID,A.XEM,A.LIKED from
                                    BV_BAI_VIET A 
                                    INNER JOIN ND_THONG_TIN_ND ND ON ND.ID = A.NGUOI_TAO
                                    INNER JOIN ND_THONG_TIN_DN DN ON DN.MEM_ID= A.NGUOI_TAO
                                    where A.BAI_VIET_ID = 
                                    (select MAX(BV.BAI_VIET_ID)
                                        from BV_BAI_VIET BV
                                        inner join BV_DM_CHU_DE_BV DMCDBV ON DMCDBV.CHU_DE_ID = BV.CHU_DE_ID
                                        WHERE DMCDBV.TYPES_ID =3
                                        AND BV.BAI_VIET_CHA_ID IS NULL
                                        AND BV.DELETED IS NULL
                                        AND BV.SORT = 0
                                        AND BV.CHU_DE_ID=" + subjectID + ")";

                DataTable table = SQLConnectWeb.GetTable(sql);
                if (table.Rows.Count > 0)
                {
                    lbl_first_news_title.Text = "<img src='images/new.gif' width=40 height=30> " + table.Rows[0]["tieu_de"].ToString();
                    lbl_first_news_title.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}&subjectID={1}&types_id=3", table.Rows[0]["bai_viet_id"], subjectID);
                    lbl_first_news_content.Text = table.Rows[0]["noi_dung"].ToString();
                    link.Text = "Xem tiếp";
                    link.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}&subjectID={1}&types_id=3", table.Rows[0]["bai_viet_id"], subjectID);
                }

                //Show all news
                DataList dtList = (DataList)e.Item.FindControl("DataList1");
                string sqls = String.Format(@"exec SP_DS_BAI_VIET_THEO_CHU_DE_LOAI_CHU_DE {0},3", subjectID);
                DataTable baiviet = SQLConnectWeb.GetTable(sqls);
                dtList.DataSource = baiviet;
                dtList.DataBind();
            }
            catch
            {

            }
        }
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row["bai_viet_id"];
                long subjectID = (long)RowView.Row["chu_de_id"];
                string title = (string)RowView.Row["tieu_de"];

                HyperLink list_news = (HyperLink)e.Item.FindControl("list_news");
                if (title.Length > 50)
                    list_news.Text = title.Substring(0, 30) + "...";
                else
                    list_news.Text = title;

                list_news.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}&subjectID={1}&types_id=3", id, subjectID);



            }
            catch
            {

            }
        }

    }
}