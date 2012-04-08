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
            }
        }
        public void display()
        {
            DataTable table = BV_DM_CHU_DE_BV.GetTableFields(new string[] { BV_DM_CHU_DE_BV.cl_SORT },
                BV_DM_CHU_DE_BV.cl_ID, BV_DM_CHU_DE_BV.cl_TITLE, BV_DM_CHU_DE_BV.cl_DESCRIPTION, BV_DM_CHU_DE_BV.cl_CREATED_DATE);
            show_subject.DataSource = table;
            show_subject.DataBind();

        }

        protected void show_subject_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            Repeater showListPost = (Repeater)e.Item.FindControl("showListPost");
            DataRowView RowView = (DataRowView)e.Item.DataItem;
            if (RowView == null) return;
            long id = (long)RowView.Row[BV_DM_CHU_DE_BV.cl_ID];

            //nvdat02/04/12 : Get posted_by field --commented-out and replace
            String sql = string.Format(@"SELECT a.*,b.USERNAME
                         FROM BV_BAI_VIET a
                        INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
                        WHERE CHU_DE_ID={0} and BAI_VIET_CHA_ID IS NULL", id);
            DataTable baiviet = SQLConnectWeb.GetTable(sql);
            //DataTable baiviet = BV_BAI_VIET.GetTableFields(BV_BAI_VIET.cl_CHU_DE_ID + "=" + id,
            //    new string[] { BV_BAI_VIET.cl_SORT }, BV_BAI_VIET.cl_TIEU_DE, BV_BAI_VIET.cl_NOI_DUNG);

            showListPost.DataSource = baiviet;
            showListPost.DataBind();


        }

        protected void showListPost_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            //Count viewing times
            Label cnt_view = (Label)e.Item.FindControl("lbl_cnt_view");
            DataRowView RowView = (DataRowView)e.Item.DataItem;
            if (RowView == null) return;
            long id = (long)RowView.Row[BV_BAI_VIET.cl_BAI_VIET_ID];
            String sql_cnt = string.Format(@"SELECT count(*) as cnt FROM BV_BAI_VIET WHERE CHU_DE_ID={0} and BAI_VIET_CHA_ID IS NOT NULL", id);
            DataTable cnt = SQLConnectWeb.GetTable(sql_cnt);
            cnt_view.Text = cnt.Rows[0]["cnt"].ToString();

            //New comment, commented by, commented date
            HyperLink cm_link = (HyperLink)e.Item.FindControl("link_comment");
            HyperLink cm_by = (HyperLink)e.Item.FindControl("link_cm_by");
            Label cm_date = (Label)e.Item.FindControl("lbl_date_time");

            String sql_lasted_cm = string.Format(@"SELECT bbv.*,nd.username FROM BV_BAI_VIET bbv 
                        INNER JOIN ND_THONG_TIN_DN nd ON bbv.NGUOI_TAO = nd.MEM_ID
                        WHERE 
                        bbv.BAI_VIET_ID = (SELECT MAX(BAI_VIET_ID) FROM BV_BAI_VIET bbv2 WHERE bbv.BAI_VIET_CHA_ID ={0} )", id);
            DataTable lasted_cm = SQLConnectWeb.GetTable(sql_lasted_cm);
            cm_link.Text = lasted_cm.Rows[0]["noi_dung"].ToString();
            cm_link.NavigateUrl = string.Format("post_show_details.aspx?news_id={0}",id);
            string str_cm = lasted_cm.Rows[0]["username"].ToString();
            if (str_cm.Length > 50)
                    str_cm = str_cm.Substring(1,30)+"...";
            cm_by.Text = str_cm;
            cm_by.NavigateUrl = string.Format("user_info.aspx?user_name={0}",lasted_cm.Rows[0]["username"]);
            DateTime created_date = (DateTime)lasted_cm.Rows[0]["ngay_tao"];
            cm_date.Text = created_date.ToString("dd/mm/yyyy hh:mm:ss tt");

        }
    }
}