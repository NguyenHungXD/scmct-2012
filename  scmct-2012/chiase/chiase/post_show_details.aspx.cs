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
                    if (Request.QueryString["types_id"] == "1")
                    {
                        Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='forum.aspx' title='Diễn đàn'>Diễn đàn</a> ";
                    }
                    else if (Request.QueryString["types_id"] == "2")
                    {
                        Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='news.aspx' title='Tin tức'>Tin tức</a> ";
                    } 
                    else if (Request.QueryString["types_id"] == "5")
                    {
                        Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='project_detail.aspx?id={0}'title='Dự án'>Dự án</a> ", Request.QueryString["id"]);
                    }
                    else if(Request.QueryString["types_id"] == "3")
                    {
                        Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='about.aspx' title='Giới thiệu'>Giới thiệu</a> ";
                    }
                    else if (Request.QueryString["types_id"] == "4")
                    {
                        Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='help.aspx' title='Trợ giúp'>Trợ giúp</a> ";
                    }


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
                linkPostNew.NavigateUrl = "post_news.aspx?types_id=" + Request.QueryString["types_id"] + "&subjectID=" + Request.QueryString["subjectID"];
                HyperLink linkEdit = (HyperLink)e.Item.FindControl("linkEdit");
                linkEdit.NavigateUrl = "post_news.aspx?post_id=" + id.ToString() +"&types_id=" + Request.QueryString["types_id"] + "&subjectID=" + Request.QueryString["subjectID"];

                //<a class="btn" style="cursor:pointer" href="<%#Eval("BAI_VIET_ID","post_news.aspx?post_id={0}")%>">

                //if (Request.QueryString["subjectID"] != null && Request.QueryString["subjectID"] != "")
                //    linkPostNew.NavigateUrl = "post_news.aspx?subjectID=" + Request.QueryString["subjectID"];
                //else if (Request.QueryString["project_id"] != null && Request.QueryString["subjectID"] != "")
                //    linkPostNew.NavigateUrl = "post_news.aspx?projectID=" + Request.QueryString["project_id"];

                //Total Post
                Label lbl_post_new = (Label)e.Item.FindControl("lbl_post_new");
                Label lbl_edit_post = (Label)e.Item.FindControl("lbl_edit_post");
                Label lbl_del_post = (Label)e.Item.FindControl("lbl_del_post");

                if (functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this)))
                {
                    if (functions.checkOwnSection(functions.LoginMemID(this), id.ToString(), "BV_BAI_VIET", "NGUOI_TAO", "BAI_VIET_ID") || functions.checkPrivileges("22", functions.LoginMemID(this), "E")) //Own post can edit/delete the post
                    {check = true;}

                    if (Request.QueryString["types_id"] == "2" || Request.QueryString["types_id"] == "3" || Request.QueryString["types_id"] == "4") //Private: Can create new post if you have permition to create a new subject/or news
                    {
                        if (functions.checkPrivileges("22", functions.LoginMemID(this), "E") || functions.checkPrivileges("20", functions.LoginMemID(this), "C")) 
                            lbl_post_new.Visible = true;
                    }
                    else if (Request.QueryString["types_id"] == "1" || Request.QueryString["types_id"] == "5" ) //Public : Everyone can create a new post for any project or forum
                    {
                        lbl_post_new.Visible = true;
                    }


                }else
                {
                    lbl_post_new.Visible = false;
                }
                    //Dont move this line to another place. Thanks
                    lbl_edit_post.Visible = check;
                    lbl_del_post.Visible = check;
                   //End comment
            
            }
            catch (Exception ex)
            {
               
            }
        }


        protected void btn_comments_Click(object sender, EventArgs e)
        {
            try
            {

                string sql_info = @"select * from BV_BAI_VIET where BAI_VIET_ID="+Request.QueryString["news_id"];
                DataTable bv_info = SQLConnectWeb.GetTable(sql_info);
                //DataTable bv_info = BV_BAI_VIET.GetTableAll("BAI_VIET_ID=" + Request.QueryString["news_id"]);


                    string subjectID = "";
                    if (Request.QueryString["types_id"] == "5")
                    {
                        subjectID = bv_info.Rows[0]["du_an_id"].ToString();
                        string sql = @"insert into BV_BAI_VIET (tieu_de,nguoi_tao,ngay_tao,noi_dung,trang_thai_id,bai_viet_cha_id,du_an_id,sort) 
                                               values(@tieu_de,@nguoi_tao,@ngay_tao,@noi_dung,@trang_thai_id,@bai_viet_cha_id,@du_an_id,@sort)";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                                "@tieu_de", bv_info.Rows[0]["tieu_de"].ToString(), "@nguoi_tao", functions.LoginMemID(this), "@ngay_tao", functions.GetStringDatetime(), "@noi_dung", ASPxHtmlEditor1.Html.Replace("'", ""), "@trang_thai_id", "1", "@bai_viet_cha_id", Request.QueryString["news_id"], "@du_an_id", subjectID, "@sort", "0");
                    }
                    else
                    {
                        subjectID = bv_info.Rows[0]["chu_de_id"].ToString();
                        string sql = @"insert into BV_BAI_VIET (tieu_de,nguoi_tao,ngay_tao,noi_dung,trang_thai_id,bai_viet_cha_id,chu_de_id,sort) 
                                               values(@tieu_de,@nguoi_tao,@ngay_tao,@noi_dung,@trang_thai_id,@bai_viet_cha_id,@chu_de_id,@sort)";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                                "@tieu_de", bv_info.Rows[0]["tieu_de"].ToString(), "@nguoi_tao", functions.LoginMemID(this), "@ngay_tao", functions.GetStringDatetime(), "@noi_dung", ASPxHtmlEditor1.Html.Replace("'", ""), "@trang_thai_id", "1", "@bai_viet_cha_id", Request.QueryString["news_id"], "@chu_de_id", subjectID, "@sort", "0");
                    }
                
                
                    string url = "";
                    //string projectID = bv_info.Rows[0]["du_an_id"].ToString();
                    //string subjectID = bv_info.Rows[0]["chu_de_id"].ToString();

                    //if (bv_info.Rows[0]["du_an_id"].ToString() != null && bv_info.Rows[0]["du_an_id"].ToString() != "")
                    //{
                    //    subjectID = "";
                    url = "post_show_details.aspx?news_id=" + Request.QueryString["news_id"] + "&subjectID=" + subjectID + "&types_id=" + Request.QueryString["types_id"];
                    //}
                    //else if (bv_info.Rows[0]["chu_de_id"].ToString() != null && bv_info.Rows[0]["chu_de_id"].ToString() != "")
                    //{
                    //    projectID = "";
                    //    url = "post_show_details.aspx?news_id=" + Request.QueryString["news_id"] + "&subjectID=" + subjectID;
                    //}

                //SQLConnectWeb.ExecuteNonQuery(sql,
                //        "@tieu_de", bv_info.Rows[0]["tieu_de"].ToString(), "@nguoi_tao", functions.LoginMemID(this), "@ngay_tao", functions.GetStringDatetime(), "@noi_dung", ASPxHtmlEditor1.Html.Replace("'", ""), "@trang_thai_id", "1", "@bai_viet_cha_id", Request.QueryString["news_id"],"@chu_de_id", subjectID, "@sort", "0");
                    //BV_BAI_VIET bv = BV_BAI_VIET.Insert_Object(bv_info.Rows[0][BV_BAI_VIET.cl_TIEU_DE].ToString(), memid, date, "", "", ASPxHtmlEditor1.Html.Replace("'", ""), "1", Request.QueryString["news_id"], bv_info.Rows[0][BV_BAI_VIET.cl_DU_AN_ID].ToString(), bv_info.Rows[0][BV_BAI_VIET.cl_CHU_DE_ID].ToString(), "0", "0");
                Response.Redirect(url);

            }
            catch (Exception ex)
            {
                //lbl_info.Text = ex.ToString();
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