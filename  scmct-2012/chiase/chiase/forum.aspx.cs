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
    public partial class forum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
                Session["current"] = "2"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='forum.aspx' title='Diễn đàn'>Diễn đàn</a> ";
            }
        }
        public void display()
        {
            try
            {
                //DataTable table = BV_DM_CHU_DE_BV.GetTableFields(new string[] { BV_DM_CHU_DE_BV.cl_SORT },
                //    BV_DM_CHU_DE_BV.cl_ID, BV_DM_CHU_DE_BV.cl_TITLE, BV_DM_CHU_DE_BV.cl_DESCRIPTION, BV_DM_CHU_DE_BV.cl_CREATED_DATE);

                string sql = @"select a.*, 'post_news.aspx?subjectID='+ convert(nvarchar,a.chu_de_id) +'&types_id=' + convert(nvarchar,a.types_id) url from BV_DM_CHU_DE_BV a
                                        where deleted is null and types_id=1"; //bv thuoc forum
                DataTable table = SQLConnectWeb.GetTable(sql);
                show_subject.DataSource = table;
                show_subject.DataBind();

                showListNews.DataSource = table;
                showListNews.DataBind();

                //Vote 10 like = 1 star, 50 like= 2 star , 100 like= 3 star, 300 like = 4 star 500 like = 5 star


            }catch(Exception ex)
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
                                    WHERE DMCDBV.TYPES_ID =1
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
                    details.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}&types_id=2&subjectID={1}", table.Rows[0]["BAI_VIET_ID"], subjectID);
                    DateTime created_date = (DateTime)table.Rows[0]["ngay_tao"];
                    created_by.Text = "<b>" + table.Rows[0]["username"].ToString() + "</b>";
                    Label texts = (Label)e.Item.FindControl("lbl_text");
                    Label created_dates = (Label)e.Item.FindControl("created_date");
                    texts.Text = "Đăng bởi, ";
                    created_dates.Text = created_date.ToString("dd/MM/yyyy hh:mm:ss tt");

                    string sql_cnt = @"select count(BV.BAI_VIET_ID) cnt
                                        from BV_BAI_VIET BV
                                        inner join BV_DM_CHU_DE_BV DMCDBV ON DMCDBV.CHU_DE_ID = BV.CHU_DE_ID
                                        WHERE DMCDBV.TYPES_ID =1
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

        protected void show_subject_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Repeater showListPost = (Repeater)e.Item.FindControl("showListPost");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row["chu_de_id"];
                
                //nvdat02/04/12 : Get posted_by field --commented-out and replace
//                String sql = string.Format(@"SELECT a.*,b.USERNAME,case when c.avatar_path is null then 'default_img.gif' else c.avatar_path end as avatar_path
//                         FROM BV_BAI_VIET a
//                        INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
//                        INNER JOIN  ND_THONG_TIN_ND c ON  a.NGUOI_TAO=c.ID
//                        WHERE CHU_DE_ID={0} and BAI_VIET_CHA_ID IS NULL and a.deleted is null and a.trang_thai_id=1", id);
                string sql = String.Format(@"exec SP_DS_BAI_VIET_THEO_CHU_DE_LOAI_CHU_DE {0},1", id);
                DataTable baiviet = SQLConnectWeb.GetTable(sql);

                //DataTable baiviet = BV_BAI_VIET.GetTableFields(BV_BAI_VIET.cl_CHU_DE_ID + "=" + id,
                //    new string[] { BV_BAI_VIET.cl_SORT }, BV_BAI_VIET.cl_TIEU_DE, BV_BAI_VIET.cl_NOI_DUNG);

                showListPost.DataSource = baiviet;
                showListPost.DataBind();

                Label lbl_edit = (Label)e.Item.FindControl("lbl_post_new");
                lbl_edit.Visible = functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                

            }
            catch (Exception ex)
            {
            }
        }

        protected void showListPost_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                //Count viewing times
 
                String lasted_comment="";
                Label cnt_view = (Label)e.Item.FindControl("lbl_cnt_view");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row[BV_BAI_VIET.cl_BAI_VIET_ID];

                long type_id = (long)RowView.Row["types_id"];
                long subject_id = (long)RowView.Row["CHU_DE_ID"];
                //if(!string.IsNullOrEmpty(RowView.Row[BV_BAI_VIET.cl_CHU_DE_ID].ToString()))
                //    id_subject = (long)RowView.Row[BV_BAI_VIET.cl_CHU_DE_ID];

                //if(!string.IsNullOrEmpty(RowView.Row[BV_BAI_VIET.cl_DU_AN_ID].ToString()))
                //     id_project = (long)RowView.Row[BV_BAI_VIET.cl_DU_AN_ID];



                String sql_cnt = string.Format(@"SELECT count(*) as cnt FROM BV_BAI_VIET WHERE BAI_VIET_CHA_ID={0} and deleted is null", id);
                DataTable cnt = SQLConnectWeb.GetTable(sql_cnt);
                cnt_view.Text = cnt.Rows[0]["cnt"].ToString();


                //New comment, commented by, commented date
                HyperLink cm_link = (HyperLink)e.Item.FindControl("link_comment");
                Label cm_by = (Label)e.Item.FindControl("_cm_by");
                Label cm_date = (Label)e.Item.FindControl("lbl_date_time");
                Label lbl_text = (Label)e.Item.FindControl("lbl_text");

                String sql_lasted_cm = string.Format(@"SELECT bbv.*,nd.username FROM BV_BAI_VIET bbv 
                        INNER JOIN ND_THONG_TIN_DN nd ON bbv.NGUOI_TAO = nd.MEM_ID
                        WHERE 
                        bbv.BAI_VIET_ID = (SELECT MAX(BAI_VIET_ID) FROM BV_BAI_VIET bbv2 WHERE bbv2.BAI_VIET_CHA_ID ={0} and deleted is null) ", id);
                DataTable lasted_cm = SQLConnectWeb.GetTable(sql_lasted_cm);
                if (lasted_cm.Rows.Count > 0)
                {
                    lasted_comment = lasted_cm.Rows[0]["noi_dung"].ToString();
                    if (lasted_comment.Length > 50)
                        lasted_comment = lasted_comment.Substring(0, 30) + "...";
                    cm_link.Text = lasted_comment;
                    lbl_text.Text="Trả lời bởi, ";

                    cm_link.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}&types_id={1}&subjectID={2}", id, type_id, subject_id);
                    string str_cm = lasted_cm.Rows[0]["username"].ToString();
                    cm_by.Text = "<b>"+str_cm+", </b>";
                    //cm_by.NavigateUrl = string.Format("user_info.aspx?user_name={0}", lasted_cm.Rows[0]["username"]);
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
                HyperLink hpLinkPostDetail = (HyperLink)e.Item.FindControl("link_show_detail");
                hpLinkPostDetail.NavigateUrl = String.Format("post_show_details.aspx?news_id={0}&types_id={1}&subjectID={2}", id, type_id,subject_id); //NavigateUrl='<%# Eval("bai_viet_id", "post_show_details.aspx?news_id={0}") %>'
            }
            catch (Exception ex)
            {
            }
        }
    }
}