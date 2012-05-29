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
    public partial class phieu_chi : System.Web.UI.Page
    {
        public static string vNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["vmode"] == "getdata_fullname")
                {
                    pull_fullname();
                }
                else if (Request.QueryString["vmode"] == "getdata_project")
                {
                    pull_projectname();
                }
                else
                {
                    display();
                }
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='phieu_chi.aspx' title='Phiếu chi'>Phiếu chi</a>";
            }
        }

        public void pull_projectname()
        {
            try
            {

                String sql = @"select a.id,a.ma_du_an,a.ten_du_an 
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID where 
                            a.id = @id and 
                            b.id in (2,3) order by a.ma_du_an";
                DataTable table = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["id"]);
                HttpContext.Current.Response.Write(String.Format("[start1]{0}[endstart1][start2]{1}[endstart2] ", table.Rows[0]["id"], table.Rows[0]["ten_du_an"]));

            }
            catch
            {

            }

        }

        public void pull_fullname()
        {
            try
            {



                String sql = @"SELECT b.id,b.name + '(' + a.username+')' as name,b.name as fullname ,b.address,a.username,c.groupname
                         FROM ND_THONG_TIN_DN a
                        INNER JOIN  ND_THONG_TIN_ND b ON  a.MEM_ID=b.ID
                        INNER JOIN ND_TEN_NHOM_ND c ON  b.MEM_GROUP_ID = c.GROUPID
                        where a.mem_id like @memid
                        order by b.name";
                DataTable table_detail = SQLConnectWeb.GetData(sql, "@memid", Request.QueryString["user_id"]);
                HttpContext.Current.Response.Write(String.Format("[start1]{0}[endstart1][start2]{1}[endstart2] ", table_detail.Rows[0]["fullname"], table_detail.Rows[0]["address"]));
            }
            catch
            {

            }

        }
        public void display()
        {
            try
            {

      

                    string sql_get_next_no = @"select MA_PC from TC_PHIEU_CHI where PC_ID = (select max(PC_ID) from TC_PHIEU_CHI)";
                    DataTable table_next_no = SQLConnectWeb.GetData(sql_get_next_no);
                    if (table_next_no.Rows.Count > 0)
                        vNo = functions.getNo(table_next_no.Rows[0]["MA_PC"].ToString(), 2);
                    else
                        vNo = functions.getNo("PC-No.000000", 2); //The first time run the application

                    String sqls = @"select a.id,a.ma_du_an,a.ten_du_an 
                                from da_du_an a 
                                inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID where 
                                b.id in (2,3) order by a.ma_du_an";
                    DataTable table = SQLConnectWeb.GetData(sqls);
                    functions.fill_DropdownList(dropd_list_project, table, 0, 1);

                    String sql = @"SELECT b.id,b.name + '(' + a.username+')' as name,b.name as fullname ,b.address,a.username,c.groupname
                             FROM ND_THONG_TIN_DN a
                            INNER JOIN  ND_THONG_TIN_ND b ON  a.MEM_ID=b.ID
                            INNER JOIN ND_TEN_NHOM_ND c ON  b.MEM_GROUP_ID = c.GROUPID
                            order by b.name";
                    DataTable table_details = SQLConnectWeb.GetData(sql);
                    functions.fill_DropdownList(dropd_name_list, table_details, 0, 1);

                    lbl_mapc.Text = vNo;


                    if (Request.QueryString["id"] != null)
                    {
                        string sql_edit = @"select a.*,b.name as nguoi_chi,c.name as nguoi_nhan_tien,c.address,d.ma_du_an as maduan,d.ten_du_an as tenduan
                                    from TC_PHIEU_CHI a
                                    inner join ND_THONG_TIN_ND b on b.id = a.nguoi_chi
                                    inner join ND_THONG_TIN_ND c on c.id = a.doi_tuong_chi
                                    inner join DA_DU_AN d on d.id = a.du_an_id
                                    where a.pc_id=@id";

                        DataTable table_detail = SQLConnectWeb.GetData(sql_edit, "@id", Request.QueryString["id"]);
                        DateTime ngay_chi = (DateTime)table_detail.Rows[0]["ngay_chi"];

                        lbl_day.Text = ngay_chi.Day.ToString();
                        lbl_month.Text = ngay_chi.Month.ToString();
                        lbl_year.Text = ngay_chi.Year.ToString();
                        lbl_days.Text = ngay_chi.Day.ToString();
                        lbl_months.Text = ngay_chi.Month.ToString();
                        lbl_years.Text = ngay_chi.Year.ToString();

                        Double total = Double.Parse(table_detail.Rows[0]["tong_tien"].ToString());
                        lbl_money_text.Text = functions.conVertToText(total);

                        txt_total.Text = total.ToString();
                        txt_name.Text = table_detail.Rows[0]["nguoi_nhan_tien"].ToString();
                        txt_address.Text = table_detail.Rows[0]["address"].ToString();
                        txt_note.Text = table_detail.Rows[0]["ghi_chu"].ToString();
                        project_name.Text = table_detail.Rows[0]["tenduan"].ToString();
                        functions.selectedDropdown(dropd_name_list, table_detail.Rows[0]["doi_tuong_chi"].ToString());
                        functions.selectedDropdown(dropd_list_project, table_detail.Rows[0]["du_an_id"].ToString());

                    }

            }
            catch
            {
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["id"] != null)
                {
                    string sql = @"update tc_phieu_chi SET NGUOI_CAP_NHAT=@NGUOI_CAP_NHAT,NGAY_CAP_NHAT=@NGAY_CAP_NHAT,TONG_TIEN=@TONG_TIEN,DU_AN_ID=@DU_AN_ID,DOI_TUONG_CHI=@DOI_TUONG_CHI,GHI_CHU=@GHI_CHU WHERE PC_ID=@ID";
                    SQLConnectWeb.ExecuteNonQuery(sql,
                             "@NGUOI_CAP_NHAT", functions.LoginMemID(this),
                             "@NGAY_CAP_NHAT", functions.GetStringDatetime(),
                             "@TONG_TIEN", txt_total.Text,
                             "@DU_AN_ID", dropd_list_project.SelectedValue,
                             "@DOI_TUONG_CHI", dropd_name_list.SelectedValue,
                             "@GHI_CHU", txt_note.Text,
                             "@ID",Request.QueryString["id"]);

                    string sql_get_next_no = @"select MA_PC from TC_PHIEU_CHI where pc_id = @id";
                    DataTable table_next_no = SQLConnectWeb.GetData(sql_get_next_no, "@id", Request.QueryString["id"]);
                    Response.Redirect("phieu_chi_view.aspx?ma_pc=" + table_next_no.Rows[0]["ma_pc"]);

                }
                else
                {
                    string sql_get_next_no = @"select MA_PC from TC_PHIEU_CHI where PC_ID = (select max(PC_ID) from TC_PHIEU_CHI)";
                    DataTable table_next_no = SQLConnectWeb.GetData(sql_get_next_no);
                    if (table_next_no.Rows.Count > 0)
                        vNo = functions.getNo(table_next_no.Rows[0]["MA_PC"].ToString(), 2);
                    else
                        vNo = functions.getNo("PC-No.000000", 2); //The first time run the application

                    string sql = @"insert into tc_phieu_chi (MA_PC,NGUOI_CHI,NGAY_CHI,TONG_TIEN,DU_AN_ID,DOI_TUONG_CHI,GHI_CHU) values (@MA_PC,@NGUOI_CHI,@NGAY_CHI,@TONG_TIEN,@DU_AN_ID,@DOI_TUONG_CHI,@GHI_CHU);";
                    SQLConnectWeb.ExecuteNonQuery(sql,
                             "@MA_PC", vNo,
                             "@NGUOI_CHI", functions.LoginMemID(this),
                             "@NGAY_CHI", functions.GetStringDatetime(),
                             "@TONG_TIEN", txt_total.Text,
                             "@DU_AN_ID", dropd_list_project.SelectedValue,
                             "@DOI_TUONG_CHI", dropd_name_list.SelectedValue,
                             "@GHI_CHU", txt_note.Text);

                    Response.Redirect("phieu_chi_view.aspx?ma_pc=" + vNo);
                }
            }
            catch(Exception ex)
            {
                lbl_error.Text = ex.ToString();
            }
        }

    }
}