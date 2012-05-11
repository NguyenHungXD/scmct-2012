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
        protected void Page_Load(object sender, EventArgs e)
        {
            idpopup = 0;
            if (!IsPostBack)
            {

                display();
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
                Repeater showList_comment = (Repeater)e.Item.FindControl("showList_comment");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row[BV_BAI_VIET.cl_BAI_VIET_ID];

                //nvdat02/04/12 : Get posted_by field --commented-out and replace
                String sql = string.Format(@"SELECT a.*,b.USERNAME,c.heart,c.created_date,c.avatar_path,d.GROUPNAME
                             FROM BV_BAI_VIET a
                            INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
                            INNER JOIN  ND_THONG_TIN_ND c ON a.NGUOI_TAO = c.id
                            INNER JOIN ND_TEN_NHOM_ND d ON c.MEM_GROUP_ID = d.GROUPID
                            WHERE BAI_VIET_CHA_ID={0} order by BAI_VIET_ID", id);

                DataTable comments = SQLConnectWeb.GetTable(sql);
                showList_comment.DataSource = comments;
                showList_comment.DataBind();

                //Total Post


            }
            catch (Exception ex)
            {
               
            }
        }


        protected void btn_comments_Click(object sender, EventArgs e)
        {
            
            try
            {
                DataTable bv_info = BV_BAI_VIET.GetTableAll("BAI_VIET_ID=" + Request.QueryString["news_id"]);

                

                string date = functions.GetStringDatetime();
                string memid = functions.LoginMemID(this);
                BV_BAI_VIET bv = BV_BAI_VIET.Insert_Object(bv_info.Rows[0][BV_BAI_VIET.cl_TIEU_DE].ToString(), memid, date, "", "", ASPxHtmlEditor1.Html.Replace("'", ""), "1", Request.QueryString["news_id"], bv_info.Rows[0][BV_BAI_VIET.cl_DU_AN_ID].ToString(), bv_info.Rows[0][BV_BAI_VIET.cl_CHU_DE_ID].ToString(), "0", "0");

                Response.Redirect("post_show_details.aspx?news_id=" + Request.QueryString["news_id"]);

            }
            catch (Exception ex)
            {
               
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("forum.aspx");
        }




    }
}