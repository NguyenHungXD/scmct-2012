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
    public partial class detail_report_by_stocks : System.Web.UI.Page
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
                    if (Request.QueryString["stock_id"]==null)
                        Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='detail_report_by_stocks.aspx'title='Báo cáo xuất-nhập-tồn theo kho'>Báo cáo xuất-nhập-tồn</a>";
                    else
                        Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='detail_report_by_stocks.aspx?stock_id={0}'title='Báo cáo xuất-nhập-tồn'>Báo cáo xuất-nhập-tồn</a> ", Request.QueryString["stock_id"]);
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

                //string sql_da = @"select ma_du_an,ten_du_an from da_du_an where id=" + Request.QueryString["id"];
                //DataTable dt = SQLConnectWeb.GetData(sql_da);
                //lbl_ma_du_an.Text = dt.Rows[0]["ma_du_an"].ToString();
                //lbl_ten_du_an.Text = dt.Rows[0]["ten_du_an"].ToString();

                string sql;
                if (Request.QueryString["stock_id"] == null)
                {

                    sql = @"exec sp_KH_XUAT_NHAP_TON_BY_HH null";

                }
                else//view by stock
                {
                    sql = @"exec sp_KH_XUAT_NHAP_TON_BY_HH " + Request.QueryString["stock_id"];
                }

                if (Request.QueryString["product_id"] == null)
                {

                    sql +=",null";

                }
                else
                {
                    sql += "," + Request.QueryString["product_id"];
                }

                if (Request.QueryString["start_date"] == null || Request.QueryString["start_date"] == "" || Request.QueryString["end_date"] == null || Request.QueryString["end_date"] == "")
                {
                    sql += ",null,null";
                }
                else
                {
                    lbl_error.Text = "<br>Từ ngày: <b>" + Request.QueryString["start_date"] + "</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbspĐến ngày: <b>" + Request.QueryString["end_date"] + "</b>";
                    sql +=",'"+ functions.CheckDate(Request.QueryString["start_date"]) + "','" + functions.CheckDate(Request.QueryString["end_date"]) +"'";
                }

                DataTable table = SQLConnectWeb.GetData(sql);
                stock_report_detail.DataSource = table;
                stock_report_detail.DataBind();

                sums_sl_ton_truoc.Text = table.Compute("sum(sl_ton_truoc)",null).ToString();
                sums_sl_nhap.Text = table.Compute("sum(sl_nhap)",null).ToString();
                sums_chuyen_di.Text = table.Compute("sum(sl_chuyen_di_kho)",null).ToString();
                sums_chuyen_den.Text = table.Compute("sum(sl_chuyen_den_kho)",null).ToString();
                sums_xuat.Text = table.Compute("sum(sl_luong_xuat)",null).ToString();
                sums_ton.Text = table.Compute("sum(sl_ton)",null).ToString();

            }
            catch (Exception ex)
            {
                //lbl_error.Text = ex.ToString();
            }
        }
    }
}