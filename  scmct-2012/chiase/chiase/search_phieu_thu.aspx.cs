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
    public partial class search_phieu_thu : System.Web.UI.Page
    {
        public static int no;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["vmode"] == "del")
                {
                    del_phieu_thu();
                }
                else if (Request.QueryString["vmode"] == "undel")
                {
                    undel_phieu_thu();
                }
                else
                {
                    no = 1;
                    display();
                }
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_phieu_thu.aspx' title='Cập nhật phiếu thu'>Cập nhật phiếu thu</a>";
            }
        }
        public void del_phieu_thu()
        {
            try
            {
                string sql = @"update TC_PHIEU_THU set deleted ='Y' where pt_id =@pt_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@pt_id", Request.QueryString["id"]);
            }
            catch
            { 
            }
        }
        public void undel_phieu_thu()
        {
            try
            {
                string sql = @"update TC_PHIEU_THU set deleted =null where pt_id =@pt_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@pt_id", Request.QueryString["id"]);
            }
            catch
            {
            }
        }
        public void display()
        {
            try
            {
                tu_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string mapt="%";
                string nguoilap = "%";
                string nguoinop = "%";
                string diachi = "%";
                string nguoi_giao = "%";
                string maduan = "%";
                string tenduan = "%";
                string yeucau = "%";

                if (dropd_ma_pt.SelectedValue != "None" && dropd_ma_pt.SelectedValue != "")
                    mapt = dropd_ma_pt.SelectedValue;
                if (txt_nguoilap.Text != "")
                    nguoilap = String.Format("%{0}%", txt_nguoilap.Text);
                if (txt_nguoi_nop.Text != "")
                    nguoinop = String.Format("%{0}%", txt_nguoi_nop.Text);
                if (txt_dia_chi.Text != "")
                    diachi = String.Format("%{0}%", txt_dia_chi.Text);
                if (txt_nguoi_giao.Text != "")
                    nguoi_giao = String.Format("%{0}%", txt_nguoi_giao.Text);
                if (txt_maduan.Text != "")
                    maduan = String.Format("%{0}%", txt_maduan.Text);
                if (txt_tenduan.Text != "")
                    tenduan = String.Format("%{0}%", txt_tenduan.Text);
                if (txt_yeu_cau.Text != "")
                    yeucau = String.Format("%{0}%", txt_yeu_cau.Text);

       

                string sql = @"select a.*,b.name as nguoi_thu_tien,c.name as nhan_tien_tu,d.name as thu_tu,d.address,e.tieu_de as tieude,f.ma_du_an as maduan,f.ten_du_an as tenduan,
                                    case when a.deleted is null then 'FFFFFF' else 'CCCCCCC' end as bgcolors
                                    from TC_PHIEU_THU a
                                    inner join ND_THONG_TIN_ND b on b.id = a.nguoi_thu
                                    inner join ND_THONG_TIN_ND c on c.id = a.doi_tuong_thu
                                    inner join ND_THONG_TIN_ND d on d.id = a.mem_id
                                    left join YC_YEU_CAU e on e.yeu_cau_id = a.yeu_cau_id
                                    inner join DA_DU_AN f on f.id = a.du_an_id
                                    where a.pt_id like '" + mapt + "' and b.name like N'" + nguoilap + "' and d.name like N'" + nguoinop + "' and d.address like N'" + diachi + "' and c.name like N'" + nguoi_giao + "' and f.ma_du_an like N'" + maduan + "' and f.ten_du_an like N'" + tenduan + "'" ;
                              //' or e.tieu_de like '"+yeucau+"'"      
                DataTable table_detail = SQLConnectWeb.GetData(sql);
                phieu_thu_list.DataSource = table_detail;
                phieu_thu_list.DataBind();

                string sql_pt = @"select pt_id,ma_pt from TC_PHIEU_THU";
                DataTable table_pt = SQLConnectWeb.GetData(sql_pt);
                functions.fill_DropdownList(dropd_ma_pt, table_pt, 0, 1);
                functions.selectedDropdown(dropd_ma_pt, mapt);
            }
            catch(Exception ex)
            {
                //lbl_error.Text = ex.ToString();
            }
        
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            display();
        }
    }
}