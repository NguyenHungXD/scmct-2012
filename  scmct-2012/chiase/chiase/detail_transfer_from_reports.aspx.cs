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
    public partial class detail_transfer_from_reports : System.Web.UI.Page
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
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='detail_transfer_from_reports.aspx?project_id={0}&product_id={1}' title='Báo cáo chi tiết chuyển đến'>Báo cáo chi tiết chuyển đến</a> ", Request.QueryString["project_id"], Request.QueryString["product_id"]);
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
                string sql = String.Format(@"exec sp_DA_XUAT_NHAP_TON_CT_CHUYEN_DEN {0},{1}", Request.QueryString["project_id"], Request.QueryString["product_id"]);
                DataTable table = SQLConnectWeb.GetData(sql);
                transfer_from_report_detail.DataSource = table;
                transfer_from_report_detail.DataBind();

                sums_sl_nhap.Text = table.Compute("sum(so_luong)", null).ToString();

            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.ToString();
            }

        }
    }
}