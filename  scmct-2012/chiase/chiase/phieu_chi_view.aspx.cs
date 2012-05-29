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
    public partial class phieu_chi_view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                display();
            }
        }
        public void display()
        {
            try
            {

                string sql = @"select a.*,b.name as nguoi_chi_tien,c.name as nguoi_nhan_tien,c.address,d.ma_du_an,d.ten_du_an
                                    from TC_PHIEU_CHI a
                                    inner join ND_THONG_TIN_ND b on b.id = a.nguoi_chi
                                    inner join ND_THONG_TIN_ND c on c.id = a.doi_tuong_chi
                                    inner join DA_DU_AN d on d.id = a.du_an_id
                                    where a.ma_pc=@id";

                DataTable table_detail = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["ma_pc"]);
                lbl_ma_pc.Text = Request.QueryString["ma_pc"];
                DateTime ngay_chi = (DateTime)table_detail.Rows[0]["ngay_chi"];
                lbl_day.Text = ngay_chi.Day.ToString();
                lbl_month.Text = ngay_chi.Month.ToString();
                lbl_year.Text = ngay_chi.Year.ToString();
                lbl_days.Text = ngay_chi.Day.ToString();
                lbl_months.Text = ngay_chi.Month.ToString();
                lbl_years.Text = ngay_chi.Year.ToString();

                lbl_reciever_name.Text = table_detail.Rows[0]["nguoi_nhan_tien"].ToString();
                lbl_address.Text = table_detail.Rows[0]["address"].ToString();
                lbl_nguoi_lap_phieu.Text = table_detail.Rows[0]["nguoi_chi_tien"].ToString();
                lbl_note.Text = table_detail.Rows[0]["ghi_chu"].ToString();
                lbl_project_name.Text = String.Format("{0}({1})", table_detail.Rows[0]["ma_du_an"], table_detail.Rows[0]["ten_du_an"]);
                lbl_total.Text = table_detail.Rows[0]["tong_tien"].ToString();
                Double total = (Double)table_detail.Rows[0]["tong_tien"];
                lbl_text_money.Text = functions.conVertToText(total);
           

            }
            catch
            { }
        
        }
    }
}