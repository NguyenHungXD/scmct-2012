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
    public partial class phieu_thu_view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                display();
            }
        }
        public void display()
        {
            try
            {
                string sql = @"select a.*,b.name as nguoi_thu_tien,c.name as nhan_tien_tu,d.name as thu_tu,d.address,e.tieu_de as tieude,f.ma_du_an as maduan,f.ten_du_an as tenduan
                                    from TC_PHIEU_THU a
                                    inner join ND_THONG_TIN_ND b on b.id = a.nguoi_thu
                                    inner join ND_THONG_TIN_ND c on c.id = a.doi_tuong_thu
                                    inner join ND_THONG_TIN_ND d on d.id = a.mem_id
                                    left outer join YC_YEU_CAU e on e.yeu_cau_id = a.yeu_cau_id
                                    inner join DA_DU_AN f on f.id = a.du_an_id
                                    where a.ma_pt=@id";

                DataTable table_detail = SQLConnectWeb.GetData(sql,"@id",Request.QueryString["ma_pt"]);
                lbl_ma_pt.Text = Request.QueryString["ma_pt"];
                DateTime ngay_thu = (DateTime) table_detail.Rows[0]["ngay_thu"];
                lbl_day.Text = ngay_thu.Day.ToString();
                lbl_month.Text = ngay_thu.Month.ToString();
                lbl_year.Text = ngay_thu.Year.ToString();
                lbl_days.Text = ngay_thu.Day.ToString();
                lbl_months.Text = ngay_thu.Month.ToString();
                lbl_years.Text = ngay_thu.Year.ToString();

                lbl_name.Text = table_detail.Rows[0]["thu_tu"].ToString();
                lbl_note.Text = table_detail.Rows[0]["ghi_chu"].ToString();
                lbl_request.Text = table_detail.Rows[0]["tieude"].ToString();
                lbl_recieved_from.Text = table_detail.Rows[0]["nhan_tien_tu"].ToString();
                Double total = Double.Parse(table_detail.Rows[0]["tong_tien"].ToString());
                lbl_money_text.Text = functions.conVertToText(total);
                lbl_address.Text = table_detail.Rows[0]["address"].ToString();
                lbl_receiver.Text = table_detail.Rows[0]["nguoi_thu_tien"].ToString();
                lbl_total.Text = table_detail.Rows[0]["tong_tien"].ToString();
                lbl_project_name.Text = String.Format("{0}({1}", table_detail.Rows[0]["maduan"], table_detail.Rows[0]["tenduan"]) + ')';
            }
            catch(Exception ex)
            {
                lbl_note.Text = ex.ToString();
            }
        
        }
    }
}