using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;
using DK2C.DataAccess.Web;
using System.Collections;
namespace chiase
{
    public partial class search_project : System.Web.UI.Page
    {
        public static int vNo;
        public int PageNumber
            {
            get
            {
            if (ViewState["PageNumber"] != null)
            return Convert.ToInt32(ViewState["PageNumber"]);
            else
            return 0;
            }
            set
            {
            ViewState["PageNumber"] = value;
            }
            }
            protected override void OnInit(EventArgs e)
            {
            base.OnInit(e);
            rptPages.ItemCommand += rptPages_ItemCommand;
            }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

                display();
            Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_project.aspx' title='Cập nhật dự án'>Cập nhật dự án</a>";
        }
        public void display()
        {
            try
            {
                start_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                end_date.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string ma_duan = "%";
                string ten_duan = "%";
                string ngay_batdau = "%";
                string ngay_ketthuc = "%";
                string trang_thai = "%";

                if (txt_maduan.Text != "")
                    ma_duan = String.Format("%{0}%", txt_maduan.Text.ToUpper());
                if (txt_tenduan.Text != "")
                    ten_duan = String.Format("%{0}%", txt_tenduan.Text.ToUpper());
                if (start_date.Text != "")
                    ngay_batdau = start_date.Text;
                if (end_date.Text != "")
                    ngay_ketthuc = end_date.Text;
                if (dropd_status.Text != "" && dropd_status.Text != "None")
                    trang_thai = dropd_status.Text ;


                String sql = @"select a.*,
                       case when a.enable_bit='N' then 'unlockicon.gif' else 'lockicon.gif' end as img_lock,
                        case when a.enable_bit='N' then N'Mở khóa' else N'Khóa' end as img_lock_alt,
                       case when a.enable_bit='D' then 'undeleteicon.gif' else 'deleteicon.gif' end as img_del,
                        case when a.enable_bit='D' then N'Phục hồi' else N'Xóa' end as img_del_alt,
                            b.name,c.name as ten_nguoi_tao
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID
                            inner join ND_THONG_TIN_ND c on c.id = a.nguoi_tao
                            where upper(a.ma_du_an) like N'" + ma_duan +"' and upper(a.ten_du_an) like N'" + ten_duan +"' and upper(b.id) like N'" + trang_thai + "'";
                           // "and a.ngay_bat_dau BETWEEN  " + ngay_batdau + " and " + ngay_ketthuc;
                DataTable table = SQLConnectWeb.GetData(sql);

                //showListProject.DataSource = table;
                //showListProject.DataBind();


                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView(table);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 10;
                pgitems.CurrentPageIndex = PageNumber;
                if (pgitems.PageCount > 1)
                {
                    rptPages.Visible = true;
                    ArrayList pages = new ArrayList();
                    for (int i = 0; i < pgitems.PageCount; i++)
                        pages.Add((i + 1).ToString());
                        rptPages.DataSource = pages;
                        rptPages.DataBind();
                }
                else
                    rptPages.Visible = false;

                showListProject.DataSource = pgitems;
                showListProject.DataBind();


                Label1.Text = String.Format("Tổng cộng: [{0}] | Mẫu tin/trang:10 | Trang hiện tại: {1}", table.Rows.Count, PageNumber + 1);



                using (DataTable table_status = DA_DM_TRANG_THAI_DU_AN.GetTableAll())
                {
                    functions.fill_DropdownList(dropd_status, table_status, 0, 1);
                }

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

        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
                        PageNumber = Convert.ToInt32(e.CommandArgument);
                        PageNumber -= 1;
            
                        display();
        }



    }
}