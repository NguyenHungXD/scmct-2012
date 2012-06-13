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
    public partial class contributor_list : System.Web.UI.Page
    {
        public static int no;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    no = 1;
                    display();
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='contributor_list.aspx?id={0}' title='Danh sách đóng góp'>Danh sách đóng góp</a> ", Request.QueryString["id"]);
                }

            }
            catch
            { 
            }
        }
        public void display()
        {
            try
            {
                string sql_da = @"select ma_du_an,ten_du_an,CONVERT(VARCHAR(10),NGAY_BAT_DAU,103) NGAY_BAT_DAU,CONVERT(VARCHAR(10),NGAY_KET_THUC,103) NGAY_KET_THUC from da_du_an where id=" + Request.QueryString["id"];
                DataTable dt = SQLConnectWeb.GetData(sql_da);
                lbl_ma_du_an.Text = dt.Rows[0]["ma_du_an"].ToString();
                lbl_ten_du_an.Text = dt.Rows[0]["ten_du_an"].ToString();
                lbl_start_date.Text = dt.Rows[0]["ngay_bat_dau"].ToString();
                lbl_end_date.Text = dt.Rows[0]["ngay_ket_thuc"].ToString();
               
                string sql = @"exec SP_DS_NGUOI_QUYEN_GOP " + Request.QueryString["id"];
                DataTable table = SQLConnectWeb.GetData(sql);
                contributor_lists.DataSource = table;
                contributor_lists.DataBind();
                sums.Text=table.Compute("sum(so_luong)",null).ToString();
            }
            catch(Exception ex)
            {
                //lbl_error.Text = ex.ToString();
            }
        }

        protected void contributor_lists_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Repeater showListPost = (Repeater)e.Item.FindControl("contributor_lists");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long uid = (long)RowView.Row["id"];
                HyperLink link = (HyperLink)e.Item.FindControl("view_details");
                link.NavigateUrl = String.Format("show_detail_contributors_info.aspx?id={0}&userid={1}", Request.QueryString["id"], uid);
                link.Text = "Xem chi tiết";

            }
            catch
            { 
            }

        }
    }
}