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
    public partial class contribution_product_list : System.Web.UI.Page
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
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='contribution_product_list.aspx?id={0}' title='Danh sách đóng góp'>Danh sách đóng góp</a> ", Request.QueryString["id"]);
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


                string sql = @"exec SP_DANH_SACH_QUYEN_GOP " + Request.QueryString["id"];
                if (Request.QueryString["project_id"] == null)
                {
                    sql += ",null";
                }
                else
                {
                    sql += ","+ Request.QueryString["project_id"];
                }

                DataTable table = SQLConnectWeb.GetData(sql);
                product_report_detail.DataSource = table;
                product_report_detail.DataBind();
                sums_tong.Text = table.Compute("sum(so_luong_nhap)", null).ToString();

            }
            catch (Exception ex)
            {
                //lbl_error.Text = ex.ToString();
            }
        }

        protected void product_report_detail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;

                long mem_id = (long)RowView.Row["mem_id"];
                long project_id = (long)RowView.Row["du_an_id"];
                long product_id = (long)RowView.Row["hh_id"];
                long request_id = (long)RowView.Row["yeu_cau_id"];
                Double sl_nhap = (Double)RowView.Row["so_luong_nhap"];

                string  receiver_date = RowView.Row["ngay_nhap"].ToString();


                HyperLink link_tong_thu = (HyperLink)e.Item.FindControl("so_luong_nhap");
                link_tong_thu.Text = sl_nhap.ToString();
                link_tong_thu.NavigateUrl = String.Format("detail_contribution_product_list.aspx?user_id={0}&project_id={1}&product_id={2}&request_id={3}&receiver_date={4}", mem_id, project_id, product_id, request_id, receiver_date);
            }
            catch
            { 
            }
        }
    }
}