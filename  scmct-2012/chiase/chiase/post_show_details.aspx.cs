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
    public partial class post_show_details : System.Web.UI.Page
    {
        public static int idpopup = 0;
        public static string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            idpopup = 0;
            if (!IsPostBack)
            {
                if (Request.QueryString["vmode"] == "del")
                {
                    functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                    del_news();

                }
                else
                {
                    if (functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this)))
                    {
                        lbl_comment.Visible = true;
                    }
                    else
                    {
                        lbl_comment.Visible = false;
                        lbl_info.Text = "<b>Đăng nhập để bình luận bài viết</b>";
                    }
                    display();
                    ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";
                }
            }
        }

        public void del_news()
        {
            try
            {
                string sql = @"update BV_BAI_VIET set deleted ='Y' where BAI_VIET_ID =@BAI_VIET_ID";
                SQLConnectWeb.ExecuteNonQuery(sql, "@BAI_VIET_ID", Request.QueryString["id"]);
            }
            catch
            {
            }
        }
        public void display()
        {
            try
            {
                username = functions.LoginMemID(this);
                vusername.Value = username;
                bai_viet_ids.Value = Request.QueryString["news_id"];

                String sql = string.Format(@"SELECT a.*,b.USERNAME
                         FROM BV_BAI_VIET a
                        INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
                        WHERE BAI_VIET_ID={0} Order by sort,BAI_VIET_ID", Request.QueryString["news_id"]);
                DataTable table = SQLConnectWeb.GetTable(sql);
                show_content.DataSource = table;
                show_content.DataBind();
                //Count viewing times
                String sql_view = "UPDATE BV_BAI_VIET SET XEM=XEM+1 WHERE BAI_VIET_ID=@BAI_VIET_ID";
                SQLConnectWeb.ExecuteNonQuery(sql_view,
                        "@BAI_VIET_ID", Request.QueryString["news_id"]);

                

            }
            catch (Exception ex)
            {
         
            }
        }



        protected void show_content_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Boolean check = false;
                Repeater showList_comment = (Repeater)e.Item.FindControl("showList_comment");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row[BV_BAI_VIET.cl_BAI_VIET_ID];

                //nvdat02/04/12 : Get posted_by field --commented-out and replace
                String sql = string.Format(@"SELECT a.*,b.USERNAME,c.heart,c.created_date,case when c.avatar_path is null then 'default_img.gif' else c.avatar_path end as avatar_path,d.GROUPNAME
                             FROM BV_BAI_VIET a
                            INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
                            INNER JOIN  ND_THONG_TIN_ND c ON a.NGUOI_TAO = c.id
                            INNER JOIN ND_TEN_NHOM_ND d ON c.MEM_GROUP_ID = d.GROUPID
                            WHERE BAI_VIET_CHA_ID={0} and a.deleted is null order by BAI_VIET_ID", id);

                DataTable comments = SQLConnectWeb.GetTable(sql);
                showList_comment.DataSource = comments;
                showList_comment.DataBind();

                HyperLink linkPostNew = (HyperLink)e.Item.FindControl("linkPostnew");
                linkPostNew.NavigateUrl = "post_news.aspx?subjectID=" + Request.QueryString["subjectID"];

                //Total Post
                Label lbl_post_new = (Label)e.Item.FindControl("lbl_post_new");
                Label lbl_edit_post = (Label)e.Item.FindControl("lbl_edit_post");
                Label lbl_del_post = (Label)e.Item.FindControl("lbl_del_post");

                if (functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this)))
                {
                    if (functions.checkOwnSection(functions.LoginMemID(this), id.ToString(), "BV_BAI_VIET", "NGUOI_TAO", "BAI_VIET_ID") || functions.checkPrivileges("22", functions.LoginMemID(this), "E"))
                    {check = true;}
                    lbl_post_new.Visible = true;
                }else
                {
                    lbl_post_new.Visible = false;
                }
                    lbl_edit_post.Visible = check;
                    lbl_del_post.Visible = check;
            
            }
            catch (Exception ex)
            {
               
            }
        }


        protected void btn_comments_Click(object sender, EventArgs e)
        {
            
            try
            {
                string memid = functions.LoginMemID(this);
                if (memid != "")
                {
                    DataTable bv_info = BV_BAI_VIET.GetTableAll("BAI_VIET_ID=" + Request.QueryString["news_id"]);



                    string date = functions.GetStringDatetime();

                    BV_BAI_VIET bv = BV_BAI_VIET.Insert_Object(bv_info.Rows[0][BV_BAI_VIET.cl_TIEU_DE].ToString(), memid, date, "", "", ASPxHtmlEditor1.Html.Replace("'", ""), "1", Request.QueryString["news_id"], bv_info.Rows[0][BV_BAI_VIET.cl_DU_AN_ID].ToString(), bv_info.Rows[0][BV_BAI_VIET.cl_CHU_DE_ID].ToString(), "0", "0");

                    Response.Redirect("post_show_details.aspx?news_id=" + Request.QueryString["news_id"]);
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("forum.aspx");
        }

        protected void showList_comment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Boolean check = false;
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row[BV_BAI_VIET.cl_BAI_VIET_ID];
                Label lbl_edit_comment = (Label)e.Item.FindControl("lbl_del_comment");
                if ((functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this)) && functions.checkOwnSection(functions.LoginMemID(this), id.ToString(), "BV_BAI_VIET", "NGUOI_TAO", "BAI_VIET_ID")) || functions.checkPrivileges("22", functions.LoginMemID(this), "E"))
                {
                   check = true;
                }
                lbl_edit_comment.Visible = check;

            }
            catch
            { 
            }
        }




    }
}