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
    public partial class detail_finance_reports : System.Web.UI.Page
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
                    if (Request.QueryString["stock_id"] == null)
                        Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='detail_finance_reports.aspx'title='Báo cáo thu chi theo dự án'>Báo cáo thu chi theo dự án</a>";
                    else
                        Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='detail_finance_reports.aspx?project_id={0}'title='Báo cáo thu chi theo dự án'>Báo cáo thu chi theo dự án</a> ", Request.QueryString["project_id"]);
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
                string sql=@"exec sp_TC_THU_CHI_BY_DA ";
                if (Request.QueryString["project_id"] == null)
                {
                    sql+= "null";
                }
                else
                {
                    sql += Request.QueryString["project_id"];
                }

                if (Request.QueryString["start_date"] == null || Request.QueryString["start_date"] == "" || Request.QueryString["end_date"] == null || Request.QueryString["end_date"] == "")
                {
                    sql += ",null,null";
                }
                else
                {
                    lbl_error.Text = "<br>Từ ngày: <b>" + Request.QueryString["start_date"] + "</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbspĐến ngày: <b>" + Request.QueryString["end_date"] + "</b>";
                    sql += ",'" + functions.CheckDate(Request.QueryString["start_date"]) + "','" + functions.CheckDate(Request.QueryString["end_date"]) + "'";
                }

                DataTable table = SQLConnectWeb.GetData(sql);

                finance_report_detail.DataSource = table;
                finance_report_detail.DataBind();

                sums_ton_truoc.Text = string.Format("{0:#,###0}",table.Compute("sum(ton_truoc)", null));
                sums_tong_thu.Text = string.Format("{0:#,###0}",table.Compute("sum(tong_thu)", null));
                sums_tong_chi.Text = string.Format("{0:#,###0}",table.Compute("sum(tong_chi)", null));
                sums_ton.Text = string.Format("{0:#,###0}",table.Compute("sum(ton)", null));

            }
            catch (Exception ex)
            {
                //lbl_error.Text = ex.ToString();
            }
        }

        protected void finance_report_detail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label cnt_view = (Label)e.Item.FindControl("lbl_cnt_view");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                Double tong_thu = (Double)RowView.Row["tong_thu"];
                Double tong_chi = (Double)RowView.Row["tong_chi"];
                long project_id = (long)RowView.Row["du_an_id"];
                HyperLink link_tong_thu = (HyperLink)e.Item.FindControl("lbl_tong_thu");
                link_tong_thu.Text = string.Format("{0:#,###0}", tong_thu);
                link_tong_thu.NavigateUrl = "detail_phieu_thu_reports.aspx?project_id=" + project_id.ToString() + "&start_date=" + Request.QueryString["start_date"] + "&end_date=" + Request.QueryString["end_date"];
                HyperLink link_tong_chi = (HyperLink)e.Item.FindControl("lbl_tong_chi");
                link_tong_chi.Text = string.Format("{0:#,###0}", tong_chi);
                link_tong_chi.NavigateUrl = "detail_phieu_chi_reports.aspx?project_id=" + project_id.ToString() + "&start_date=" + Request.QueryString["start_date"] + "&end_date=" + Request.QueryString["end_date"];
            }
            catch(Exception ex)
            {
                lbl_error.Text = ex.ToString();
            }
        }
    }
}