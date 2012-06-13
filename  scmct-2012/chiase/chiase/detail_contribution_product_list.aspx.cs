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
    public partial class detail_contribution_product_list : System.Web.UI.Page
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
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='detail_contribution_product_list.aspx?user_id={0}&project_id={1}&product_id={2}&request_id={3}&receiver_date={4}' title='Chi tiết hàng hóa đã xuất'>Chi tiết hàng hóa đã xuất</a> ", Request.QueryString["user_id"], Request.QueryString["project_id"], Request.QueryString["product_id"], Request.QueryString["request_id"], Request.QueryString["receiver_date"]);
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
                string sql_da = @"select ma_du_an,ten_du_an,CONVERT(VARCHAR(10),NGAY_BAT_DAU,103) NGAY_BAT_DAU,CONVERT(VARCHAR(10),NGAY_KET_THUC,103) NGAY_KET_THUC from da_du_an where id=" + Request.QueryString["project_id"];
                DataTable dt = SQLConnectWeb.GetData(sql_da);
                lbl_ma_du_an.Text = dt.Rows[0]["ma_du_an"].ToString();
                lbl_ten_du_an.Text = dt.Rows[0]["ten_du_an"].ToString();
                lbl_start_date.Text = dt.Rows[0]["ngay_bat_dau"].ToString();
                lbl_end_date.Text = dt.Rows[0]["ngay_ket_thuc"].ToString();

                //THong tin hh
                string sql_hh = @"select a.*,b.name nhom_hh 
                from dm_hang_hoa a
                inner join DM_HANG_HOA_NHOM b on a.NHH_ID = b.id
                where a.id=@id";
                DataTable dt_hh = SQLConnectWeb.GetData(sql_hh, "@id", Request.QueryString["product_id"]);
                lbl_mahh.Text = dt_hh.Rows[0]["ma_hh"].ToString();
                lbl_tenhh.Text = dt_hh.Rows[0]["name"].ToString();
                lbl_chungloai.Text = dt_hh.Rows[0]["nhom_hh"].ToString();


                string sql = @"exec SP_DANH_SACH_QUYEN_GOP_CT " + Request.QueryString["user_id"] + "," + Request.QueryString["project_id"] + ",'" +  functions.CheckDate(Request.QueryString["receiver_date"]) + "'," + Request.QueryString["product_id"];
                if (Request.QueryString["request_id"] == null || Request.QueryString["request_id"] == "")
                {
                    sql += ",null";
                }
                else
                {
                    sql += "," + Request.QueryString["request_id"];
                }

                DataTable table = SQLConnectWeb.GetData(sql);
                product_report_detail.DataSource = table;
                product_report_detail.DataBind();
                sums_tong.Text = table.Compute("sum(so_luong_xuat)", null).ToString();

            }
            catch (Exception ex)
            {
                //lbl_error.Text = ex.ToString();
            }
        }
    }
}