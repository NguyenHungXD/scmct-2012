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
    public partial class stock_reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                lbl_stock_reports.Visible = functions.checkPrivileges("46", functions.LoginMemID(this), "V");
                if (Request.QueryString["stock_id"] != null)
                {
                    getStockInfo();
                }
                else if (Request.QueryString["product_id"] != null)
                {
                    getProductInfo();
                }
                else
                {
                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='stock_reports.aspx' title='Báo cáo xuất-nhập-tồn'>Báo xuất-nhập-tồn</a>";
                }
            }
        }

        public void display()
        {
            try
            {
                String sqls = @"select id,name 
                                from kh_dm_kho where visible_bit='Y'";
                DataTable table = SQLConnectWeb.GetData(sqls);
                functions.fill_DropdownList(drop_stock, table, 0, 1);

                String sql_products_info = @"select id,name from DM_HANG_HOA where visible_bit='Y'";
                DataTable tables = SQLConnectWeb.GetData(sql_products_info);
                functions.fill_DropdownList(drop_products, tables, 0, 1);

            }
            catch
            { }
        }
        public void getProductInfo()
        {

            try
            {
                String sql_products_info = @"select a.ma_hh,a.name as ten_hang,b.name as chung_loai
                                from DM_HANG_HOA a
                                inner join DM_HANG_HOA_NHOM b on a.NHH_ID = b.ID
                                where a.id=" + Request.QueryString["product_id"] +" and a.visible_bit='Y'";
                DataTable dt = SQLConnectWeb.GetData(sql_products_info);
                HttpContext.Current.Response.Write("<product_id>" + dt.Rows[0]["ma_hh"].ToString() + "</product_id>" + "<product_name>" + dt.Rows[0]["ten_hang"].ToString() + "</product_name>" + "<product_type>" + dt.Rows[0]["chung_loai"].ToString() + "</product_type>");
            }
            catch
            { }
        }
        public void getStockInfo()
        {
            try
            {
                string sql_da = @"select * from kh_dm_kho where id=" + Request.QueryString["stock_id"];
                DataTable dt = SQLConnectWeb.GetData(sql_da);
                HttpContext.Current.Response.Write("<stock_name>" + dt.Rows[0]["name"].ToString() + "</stock_name>" + "<stock_address>" + dt.Rows[0]["dia_chi"].ToString() + "</stock_address>" + "<stock_phone>" + dt.Rows[0]["dien_thoai"].ToString() + "</stock_phone>" + "<stock_manage_by>" + dt.Rows[0]["nguoi_quan_ly"].ToString() + "</stock_manage_by>");
            }
            catch
            { }
        }

    }
}