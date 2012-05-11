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
    public partial class search_project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                display();

        }
        public void display()
        {
            try
            {
                start_date.Text = DateTime.Now.ToString();
                end_date.Text = DateTime.Now.ToString();

                string ma_duan = "%";
                string ten_duan = "%";
                string ngay_batdau = "%";
                string ngay_ketthuc = "%";
                string trang_thai = "%";

                if (txt_maduan.Text != "")
                    ma_duan = "%" + txt_maduan.Text.ToUpper() + "%";
                if (txt_tenduan.Text != "")
                    ten_duan = "%" + txt_tenduan.Text.ToUpper() + "%";
                if (start_date.Text != "")
                    ngay_batdau = start_date.Text;
                if (end_date.Text != "")
                    ngay_ketthuc = end_date.Text;
                if (dropd_status.Text != "")
                    trang_thai = dropd_status.Text ;

                String sql = @"select a.*,
                       case when a.enable_bit='N' then 'unlockicon.gif' else 'lockicon.gif' end as img_lock,
                        case when a.enable_bit='N' then N'Mở khóa' else N'Khóa' end as img_lock_alt,
                       case when a.enable_bit='D' then 'undeleteicon.gif' else 'deleteicon.gif' end as img_del,
                        case when a.enable_bit='D' then N'Phục hồi' else N'Xóa' end as img_del_alt,
                            b.name 
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID
                            where upper(a.ma_du_an) like '" + ma_duan +"' and upper(a.ten_du_an) like '" + ten_duan +"' and upper(b.id) like '" + trang_thai + "'";
                           // "and a.ngay_bat_dau BETWEEN  " + ngay_batdau + " and " + ngay_ketthuc;
                DataTable table = SQLConnectWeb.GetData(sql);

                showListProject.DataSource = table;
                showListProject.DataBind();

                DataTable table_status = DA_DM_TRANG_THAI_DU_AN.GetTableAll();
                functions.fill_DropdownList(dropd_status, table_status, 0, 1);

                if (trang_thai != "'%'")
                    functions.selectedDropdown(dropd_status, trang_thai);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            display();
        }

    }
}