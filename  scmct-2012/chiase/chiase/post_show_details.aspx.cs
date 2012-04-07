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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                display();
            }
        }


        public void display()
        {
            try
            {
                String sql = string.Format(@"SELECT a.*,b.USERNAME
                         FROM BV_BAI_VIET a
                        INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
                        WHERE BAI_VIET_ID={0} Order by sort", Request.QueryString["news_id"]);
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
                Label1.Text = ex.ToString();
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
                String sql = string.Format(@"SELECT a.*,b.USERNAME
                             FROM BV_BAI_VIET a
                            INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
                            WHERE BAI_VIET_CHA_ID={0}", id);

                DataTable comments = SQLConnectWeb.GetTable(sql);
                showList_comment.DataSource = comments;
                showList_comment.DataBind();
            }
            catch (Exception ex)
            {
               
            }
        }


        protected void btn_comment_Click(object sender, EventArgs e)
        {
            
            try
            {
                DataTable bv_info = BV_BAI_VIET.GetTableAll("BAI_VIET_ID=" + Request.QueryString["news_id"]);

                

                string date = functions.GetStringDatetime();
                string memid = functions.LoginMemID(this);
                BV_BAI_VIET bv = BV_BAI_VIET.Insert_Object(bv_info.Rows[0][BV_BAI_VIET.cl_TIEU_DE].ToString(), memid, date, "", "", ASPxHtmlEditor1.Html.Replace("'",""), "1", Request.QueryString["news_id"], "", bv_info.Rows[0][BV_BAI_VIET.cl_CHU_DE_ID].ToString(), "0","0");

                Response.Redirect("post_show_details.aspx?news_id=" + Request.QueryString["news_id"]);

            }
            catch (Exception ex)
            {
               
            }
        }
    }
}