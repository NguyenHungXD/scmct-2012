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
    public partial class phieu_thu : System.Web.UI.Page
    {
        public static string vNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

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
                    lbl_create_new_pt.Visible = functions.checkPrivileges("28", functions.LoginMemID(this), "C");
                    display();
                }
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='phieu_thu.aspx' title='Phiếu thu'>Phiếu thu</a>";
                
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



                string sql_get_next_no = @"select MA_PT from TC_PHIEU_THU where PT_ID = (select max(PT_ID) from TC_PHIEU_THU)";
                DataTable table_next_no = SQLConnectWeb.GetData(sql_get_next_no);
                if(table_next_no.Rows.Count>0)
                    vNo = functions.getNo(table_next_no.Rows[0]["MA_PT"].ToString());
                else
                    vNo = functions.getNo("PT-No.000000"); //The first time run the application

                String sqls = @"select a.id,a.ma_du_an,a.ten_du_an 
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID where 
                            b.id in (2,3) order by a.ma_du_an";
                DataTable table = SQLConnectWeb.GetData(sqls);
                functions.fill_DropdownList(dropd_list_project, table, 0, 1);

                String sql_request = @"select a.yeu_cau_id,a.tieu_de from yc_yeu_cau a where deleted is null";
                DataTable table_request = SQLConnectWeb.GetData(sql_request);
                functions.fill_DropdownList(dropd_request, table_request, 0, 1);


                String sql = @"SELECT b.id,b.name + '(' + a.username+')' as name,b.name as fullname ,b.address,a.username,c.groupname
                         FROM ND_THONG_TIN_DN a
                        INNER JOIN  ND_THONG_TIN_ND b ON  a.MEM_ID=b.ID
                        INNER JOIN ND_TEN_NHOM_ND c ON  b.MEM_GROUP_ID = c.GROUPID
                        order by b.name";
                    DataTable table_details = SQLConnectWeb.GetData(sql);
                    functions.fill_DropdownList(dropd_name_list, table_details, 0, 1);
                    functions.fill_DropdownList(drop_list, table_details, 0, 1);

                    if (Request.QueryString["id"] != null)
                    {
                        string sql_pull = @"select a.*,b.name as nguoi_thu_tien,d.name as thu_tu,d.address,e.tieu_de as tieude,f.ma_du_an as maduan,f.ten_du_an as tenduan
                                    from TC_PHIEU_THU a
                                    inner join ND_THONG_TIN_ND b on b.id = a.nguoi_thu
                                    inner join ND_THONG_TIN_ND d on d.id = a.mem_id
                                    left outer join YC_YEU_CAU e on e.yeu_cau_id = a.yeu_cau_id
                                    inner join DA_DU_AN f on f.id = a.du_an_id
                                    where a.pt_id=@id";
                        
                        DataTable table_detail = SQLConnectWeb.GetData(sql_pull, "@id", Request.QueryString["id"]);
                        vNo = table_detail.Rows[0]["ma_pt"].ToString();
                        txt_name.Text = table_detail.Rows[0]["thu_tu"].ToString();
                        txt_address.Text = table_detail.Rows[0]["address"].ToString();

                        functions.selectedDropdown(dropd_name_list, table_detail.Rows[0]["mem_id"].ToString());

                        //functions.selectedDropdown(drop_list, table_detail.Rows[0]["mem_id"].ToString());

                        functions.selectedDropdown(dropd_request, table_detail.Rows[0]["yeu_cau_id"].ToString());
                        functions.selectedDropdown(dropd_list_project, table_detail.Rows[0]["du_an_id"].ToString());
                        txt_note.Text = table_detail.Rows[0]["ghi_chu"].ToString();
                        txt_total.Text = table_detail.Rows[0]["tong_tien"].ToString();
                        txt_received_from.Text = table_detail.Rows[0]["doi_tuong_thu"].ToString();
                        project_name.Text = table_detail.Rows[0]["tenduan"].ToString();
                        
                        lbl_money_text.Text = functions.conVertToText((Double)table_detail.Rows[0]["tong_tien"]);
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
                long request_id = 0;
                if (dropd_request.SelectedValue != "None")
                    request_id = long.Parse(dropd_request.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    string sql = @"update tc_phieu_thu SET NGUOI_CAP_NHAT=@NGUOI_CAP_NHAT,NGAY_CAP_NHAT=@NGAY_CAP_NHAT,TONG_TIEN=@TONG_TIEN,DU_AN_ID=@DU_AN_ID,DOI_TUONG_THU=@DOI_TUONG_THU,MEM_ID=@MEM_ID,YEU_CAU_ID=@YEU_CAU_ID,GHI_CHU=@GHI_CHU WHERE PT_ID=@ID";
                    SQLConnectWeb.ExecuteNonQuery(sql,
                             "@NGUOI_CAP_NHAT", functions.LoginMemID(this),
                             "@NGAY_CAP_NHAT", functions.GetStringDatetime(),
                             "@TONG_TIEN", txt_total.Text,
                             "@DU_AN_ID", dropd_list_project.SelectedValue,
                             "@DOI_TUONG_THU", txt_received_from.Text,
                             "@MEM_ID", dropd_name_list.SelectedValue,
                             "@YEU_CAU_ID", request_id,
                             "@GHI_CHU", txt_note.Text,
                             "@ID", Request.QueryString["id"]);
                    string sql_get_next_no = @"select MA_PT from TC_PHIEU_THU where pt_id = @id";
                    DataTable table_next_no = SQLConnectWeb.GetData(sql_get_next_no, "@id", Request.QueryString["id"]);
                    Response.Redirect("phieu_thu_view.aspx?ma_pt=" + table_next_no.Rows[0]["ma_pt"]);

                }
                else
                {


                    string sql_get_next_no = @"select MA_PT from TC_PHIEU_THU where PT_ID = (select max(PT_ID) from TC_PHIEU_THU)";
                    DataTable table_next_no = SQLConnectWeb.GetData(sql_get_next_no);
                    if (table_next_no.Rows.Count > 0)
                        vNo = functions.getNo(table_next_no.Rows[0]["MA_PT"].ToString());
                    else
                        vNo = functions.getNo("PT-No.000000"); //The first time run the application
                    string sql = @"insert into tc_phieu_thu (MA_PT,NGUOI_THU,NGAY_THU,TONG_TIEN,DU_AN_ID,DOI_TUONG_THU,MEM_ID,YEU_CAU_ID,GHI_CHU) values (@MA_PT,@NGUOI_THU,@NGAY_THU,@TONG_TIEN,@DU_AN_ID,@DOI_TUONG_THU,@MEM_ID,@YEU_CAU_ID,@GHI_CHU)";
                    SQLConnectWeb.ExecuteNonQuery(sql,
                             "@MA_PT", vNo,
                             "@NGUOI_THU", functions.LoginMemID(this),
                             "@NGAY_THU", functions.GetStringDatetime(),
                             "@TONG_TIEN", txt_total.Text,
                             "@DU_AN_ID", dropd_list_project.SelectedValue,
                             "@DOI_TUONG_THU", txt_received_from.Text,
                             "@MEM_ID", dropd_name_list.SelectedValue,
                             "@YEU_CAU_ID", request_id,
                             "@GHI_CHU", txt_note.Text);

                    Response.Redirect("phieu_thu_view.aspx?ma_pt=" + vNo);
                }
            }
            catch(Exception ex)
            {
                //lbl_error.Text = ex.ToString() + dropd_name_list.SelectedValue;
            }
        }

    }
}