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
    public partial class project_reports : System.Web.UI.Page
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
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='project_reports.aspx?id={0}'title='Tổng kết dự án'>Tổng kết dự án</a> ", Request.QueryString["id"]);
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

                string sql = String.Format(@"exec sp_DA_XUAT_NHAP_TON {0}", Request.QueryString["id"]);
                DataTable table = SQLConnectWeb.GetData(sql);
                project_report_detail.DataSource = table;
                project_report_detail.DataBind();

                sums_sl_nhap.Text = table.Compute("sum(sl_nhap)", null).ToString();
                sums_chuyen_di.Text = table.Compute("sum(sl_chuyen_di_da)", null).ToString();
                sums_chuyen_den.Text = table.Compute("sum(sl_chuyen_den_da)", null).ToString();
                sums_xuat.Text = table.Compute("sum(sl_luong_xuat)", null).ToString();
                sums_ton.Text = table.Compute("sum(sl_ton)", null).ToString();
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.ToString();
            }

        }

        protected void project_report_detail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long hh_id = (long)RowView.Row["HH_ID"];
                long du_an_id = (long)RowView.Row["du_an_id"];

                Double v_sl_nhap = (Double)RowView.Row["sl_nhap"];
                Double v_sl_chuyen_di_da = (Double)RowView.Row["sl_chuyen_di_da"];
                Double v_sl_chuyen_den_da = (Double)RowView.Row["sl_chuyen_den_da"];
                Double v_sl_xuat = (Double)RowView.Row["sl_luong_xuat"];
                
                //Fill data for hyperlink
                HyperLink link_sl_nhap = (HyperLink)e.Item.FindControl("sl_nhap");
                HyperLink link_sl_chuyen_di_da = (HyperLink)e.Item.FindControl("sl_chuyen_di_da");
                HyperLink link_sl_chuyen_den_da = (HyperLink)e.Item.FindControl("sl_chuyen_den_da");
                HyperLink link_sl_xuat = (HyperLink)e.Item.FindControl("sl_xuat");

                link_sl_nhap.Text = v_sl_nhap.ToString();
                link_sl_nhap.NavigateUrl = "detail_receiver_reports.aspx?project_id=" + du_an_id.ToString() + "&product_id=" + hh_id.ToString();

                link_sl_chuyen_di_da.Text = v_sl_chuyen_di_da.ToString();
                link_sl_chuyen_di_da.NavigateUrl = "detail_transfer_to_reports.aspx?project_id=" + du_an_id.ToString() + "&product_id=" + hh_id.ToString();

                link_sl_chuyen_den_da.Text = v_sl_chuyen_den_da.ToString();
                link_sl_chuyen_den_da.NavigateUrl = "detail_transfer_from_reports.aspx?project_id=" + du_an_id.ToString() + "&product_id=" + hh_id.ToString();

                link_sl_xuat.Text = v_sl_xuat.ToString();
                link_sl_xuat.NavigateUrl = "detail_issue_reports.aspx?project_id=" + du_an_id.ToString() + "&product_id=" + hh_id.ToString();
                
            }
            catch(Exception ex)
            {
                lbl_error.Text = ex.ToString();
            }
        }
    }
}