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
    public partial class search_phieu_chi : System.Web.UI.Page
    {
        public static int no;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                if (Request.QueryString["vmode"] == "del")
                {
                    del_phieu_chi();
                } if (Request.QueryString["vmode"] == "undel")
                {
                    undel_phieu_chi();
                }
                else
                {
                    lbl_del_pc.Visible = functions.checkPrivileges("31", functions.LoginMemID(this), "D");
                    lbl_search_pc.Visible = functions.checkPrivileges("31", functions.LoginMemID(this), "V");

                    no = 1;
                    display();
                }
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_phieu_chi.aspx' title='Cập nhật phiếu chi'>Cập nhật phiếu chi</a>";
            }
        }
        public void del_phieu_chi()
        {
            try
            {
                string sql = @"update TC_PHIEU_CHI set deleted ='Y' where pc_id =@pc_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@pc_id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void undel_phieu_chi()
        {
            try
            {
                string sql = @"update TC_PHIEU_CHI set deleted =null where pc_id =@pc_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@pc_id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void display()
        {
            try
            {


                string sWhere = "";
                tu_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string mapc = "%";

                //string nguoilap = "%";
                //string nguoinhan = "%";
                //string diachi = "%";
                //string maduan = "%";
                //string tenduan = "%";
                //where a.pc_id like '" + mapc + "' and b.name like N'" + nguoilap + "' and c.name like N'" + nguoinhan + "' and c.address like N'" + diachi + "' and d.ma_du_an like N'" + maduan + "' and d.ten_du_an like N'" + tenduan + "'";
                if (dropd_ma_pc.SelectedValue != "None" && dropd_ma_pc.SelectedValue != "")
                {
                    mapc = dropd_ma_pc.SelectedValue;
                    sWhere += " where a.pc_id like '%" + mapc + "%'";
                }
                else
                {
                    sWhere += " where a.pc_id like '%'";
                }
                if (txt_nguoilap.Text != "")
                    //nguoilap = String.Format("%{0}%", txt_nguoilap.Text);
                    sWhere += " and b.name like N'%" + txt_nguoilap.Text + "%'";
                if (txt_nguoi_nhan.Text != "")
                    //nguoinhan = String.Format("%{0}%", txt_nguoi_nhan.Text);
                    sWhere += " and c.name like N'%" + txt_nguoi_nhan.Text + "%'";
                if (txt_dia_chi.Text != "")
                    //diachi = String.Format("%{0}%", txt_dia_chi.Text);
                    sWhere += " and c.address like N'%" + txt_nguoi_nhan.Text + "%'";
                if (txt_duan.Text != "")
                    //maduan = String.Format("%{0}%", txt_maduan.Text);
                    sWhere += " and (d.ma_du_an like N'%" + txt_duan.Text + "%' or d.ten_du_an like N'%" + txt_duan.Text + "%')";


                string sql = @"select a.*,b.name as nguoi_chi_tien,c.name as nguoi_nhan_tien,c.address,d.ma_du_an as maduan,d.ten_du_an as tenduan,
                                    case when a.deleted is null then 'FFFFFF' else 'CCCCCCC' end as bgcolors
                                    from TC_PHIEU_CHI a
                                    inner join ND_THONG_TIN_ND b on b.id = a.nguoi_chi
                                    inner join ND_THONG_TIN_ND c on c.id = a.doi_tuong_chi
                                    inner join DA_DU_AN d on d.id = a.du_an_id" + sWhere;
                                    //where a.pc_id like '" + mapc + "' and b.name like N'" + nguoilap + "' and c.name like N'" + nguoinhan + "' and c.address like N'" + diachi + "' and d.ma_du_an like N'" + maduan + "' and d.ten_du_an like N'" + tenduan + "'";

                DataTable table_detail = SQLConnectWeb.GetData(sql);
                phieu_chi_list.DataSource = table_detail;
                phieu_chi_list.DataBind();

                string sql_pc = @"select pc_id,ma_pc from TC_PHIEU_CHI";
                using (DataTable table_pc = SQLConnectWeb.GetData(sql_pc))
                {
                    functions.fill_DropdownList(dropd_ma_pc, table_pc, 0, 1);
                }
                functions.selectedDropdown(dropd_ma_pc, mapc);

            }
            catch
            { }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            display();
        }

        protected void phieu_chi_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label lb_edit = (Label)e.Item.FindControl("lbl_edit_pc");
                lb_edit.Visible = functions.checkPrivileges("31", functions.LoginMemID(this), "E");
            }
            catch
            { }
        }
    }
}