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
    public partial class project_manage_reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                lbl_project_reports.Visible = functions.checkPrivileges("48", functions.LoginMemID(this), "V");
                if (Request.QueryString["project_id"] == null)
                {

                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='project_manage_reports.aspx' title='Báo cáo dự án'>Báo cáo dự án</a>";
                }
                else
                    getProjectInfo();
            }
        }
        public void display()
        {
            try
            {
                String sqls = @"select a.id,a.ma_du_an,a.ten_du_an 
                                from da_du_an a 
                                inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID where 
                                b.id in (2,3) order by a.ma_du_an";
                DataTable table = SQLConnectWeb.GetData(sqls);
                functions.fill_DropdownList(drop_projects, table, 0, 1);
            }
            catch
            { }
        }
        public void getProjectInfo()
        {
            try
            {
                string sql_da = @"select ma_du_an,ten_du_an, CONVERT(VARCHAR(10),NGAY_BAT_DAU,103) NGAY_BAT_DAU,CONVERT(VARCHAR(10),NGAY_KET_THUC,103) NGAY_KET_THUC from da_du_an where id=" + Request.QueryString["project_id"];
                DataTable dt = SQLConnectWeb.GetData(sql_da);
                HttpContext.Current.Response.Write("<project_name>" + dt.Rows[0]["ten_du_an"].ToString() + "</project_name>" + "<start_date>" + dt.Rows[0]["ngay_bat_dau"].ToString() + "</start_date>" + "<end_date>" + dt.Rows[0]["ngay_ket_thuc"].ToString() + "</end_date>");
            }
            catch
            { }
        }
    }
}