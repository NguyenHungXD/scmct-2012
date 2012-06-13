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
    public partial class detail_phieu_thu_reports : System.Web.UI.Page
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
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='detail_phieu_thu_reports.aspx?project_id={0}&start_date={1}&end_date={2}' title='Báo cáo chi tiết xuất'>Báo cáo chi tiết xuất</a> ", Request.QueryString["project_id"], Request.QueryString["start_date"],Request.QueryString["end_date"]);
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
                string sql = @"exec sp_TC_CHI_TIET_THU_BY_DA ";
                if (Request.QueryString["project_id"] == null)
                {
                    sql += "null";
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
                phieu_thu_report_detail.DataSource = table;
                phieu_thu_report_detail.DataBind();
                sums_tong_tien.Text = string.Format("{0:#,###0}", table.Compute("sum(tong_tien)", null));

            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.ToString();
            }
        }
    }
}