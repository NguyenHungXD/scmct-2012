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
    public partial class slideshow : System.Web.UI.Page
    {
        public static string username;
        public static string allbum_id;
        public static string v_liked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                dispplay();
                show_commemt();
                ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";
            }
        }



        public void show_commemt()
        {
            try
            {
                String sql = string.Format(@"SELECT a.*,b.USERNAME,c.heart,c.created_date,c.avatar_path,d.GROUPNAME
                             FROM IMG_ALLBUM_COMMENT a
                            INNER JOIN  ND_THONG_TIN_DN b ON  a.commented_by=b.MEM_ID
                            INNER JOIN  ND_THONG_TIN_ND c ON a.commented_by = c.id
                            INNER JOIN ND_TEN_NHOM_ND d ON c.MEM_GROUP_ID = d.GROUPID
                            WHERE allbum_id={0} and a.deleted is null order by a.id", Request.QueryString["allbumid"]);
                DataTable comments = SQLConnectWeb.GetTable(sql);
                showList_comment.DataSource = comments;
                showList_comment.DataBind();
            }
            catch
            { }
        }

        public void dispplay()
        {
            try
            {
                String sql = @"select a.*,b.*,b.Liked as imgLiked
                            from IMG_ALLBUM a 
                            inner join IMG_ALLBUM_DETAIL b on a.allbum_id = b.allbum_id
                            where a.allbum_id = @allbum_id and b.deleted is null
                            order by b.img_id";
                DataTable table = SQLConnectWeb.GetData(sql, "@allbum_id", Request.QueryString["allbumid"]);
                if (table == null) return;
                showImageList.DataSource = table;
                showImageList.DataBind();



                String sql_liked = @"select liked as likeds from IMG_ALLBUM where allbum_id=@allbum_id and deleted is null";
                DataTable table_liked = SQLConnectWeb.GetData(sql_liked, "@allbum_id", Request.QueryString["allbumid"]);
                allbum_id = Request.QueryString["allbumid"];
                v_liked = table_liked.Rows[0]["likeds"].ToString();



                DataTable table_info = (DataTable)Session["ThanhVien"];

                if (table_info.Rows.Count > 0)
                {
                    username = table_info.Rows[0]["username"].ToString();
                    vusername.Value = username;
                    imgpath.Value = table_info.Rows[0]["avatar_path"].ToString();

                }
                else
                    vusername.Value = "Guest";

            }
            catch
            {
            }
        }

        protected void showImageList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                Repeater showcm = (Repeater)e.Item.FindControl("showcomment");
                if (RowView == null) return;
                long id = (long)RowView.Row["img_id"];
                String sql = @"select a.*,a.img_id as imgids,b.username,c.avatar_path from IMG_ALLBUM_COMMENT a
                            inner join ND_THONG_TIN_DN b on a.commented_by = b.mem_id
                            inner join ND_THONG_TIN_ND c on b.mem_id = c.id
                            where a.img_id = @img_id and a.deleted is null
                            order by commented_date";
                DataTable table = SQLConnectWeb.GetData(sql, "@img_id", id);


                showcm.DataSource = table;
                showcm.DataBind();

                string sql_cnt = @"select count(*) as cnt from IMG_ALLBUM_COMMENT where img_id = @img_id and deleted is null";
                DataTable table_cnt = SQLConnectWeb.GetData(sql_cnt, "@img_id", id);

                Label cntcm = (Label)e.Item.FindControl("cnt_cm");
                cntcm.Text = table_cnt.Rows[0]["cnt"].ToString();
            }
            catch
            { }

        }

        protected void btn_comments_Click(object sender, EventArgs e)
        {
            try
            {
                if (functions.LoginMemID(this) != "")
                {
                    String sql = "INSERT INTO IMG_ALLBUM_COMMENT(ALLBUM_ID,COMMENTED_BY,COMMENTED_DATE,COMMENT,STATUS,LIKED) Values(@ALLBUM_ID,@COMMENTED_BY,@COMMENTED_DATE,@COMMENT,@STATUS,@LIKED)";
                    SQLConnectWeb.ExecuteNonQuery(sql,
                            "@ALLBUM_ID", Request.QueryString["allbumid"],
                             "@COMMENTED_BY", functions.LoginMemID(this),
                            "@COMMENTED_DATE", functions.GetStringDatetime(),
                            "@COMMENT", ASPxHtmlEditor1.Html.Replace("'", ""),
                            "@STATUS", 1,
                            "@LIKED", 0
                            );

                    String sql_cm = "UPDATE IMG_ALLBUM SET COMMENTS=COMMENTS+1 WHERE ALLBUM_ID=@ALLBUM_ID";
                    SQLConnectWeb.ExecuteNonQuery(sql_cm,
                            "@ALLBUM_ID", Request.QueryString["allbumid"]);

                    Response.Redirect("slideshow.aspx?allbumid=" + Request.QueryString["allbumid"]);
                }
                
            }
            catch
            { 
            
            }
        }
    }
}