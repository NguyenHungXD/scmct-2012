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
    public partial class finance_reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                lbl_finance_reports.Visible = functions.checkPrivileges("47", functions.LoginMemID(this), "V");
                if(Request.QueryString["project_id"]!=null){
                    getProject_info();
                }else
                {
                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='finance_reports.aspx' title='Báo cáo thu chi theo dự án'>Báo thu chi</a>";
                }
            }
        }
        public void getProject_info()
        {
            try
            {
                String sqls = @"select a.id,a.ma_du_an,a.ten_du_an,CONVERT(VARCHAR(10), ngay_bat_dau,103) from_date,CONVERT(VARCHAR(10), ngay_ket_thuc,103) to_date
                            from da_du_an a where trang_thai_id in (2,3) and id=" + Request.QueryString["project_id"];
                DataTable dt = SQLConnectWeb.GetData(sqls);
                HttpContext.Current.Response.Write("<project_id>" + dt.Rows[0]["ma_du_an"].ToString() + "</project_id>" + "<project_name>" + dt.Rows[0]["ten_du_an"].ToString() + "</project_name>" + "<from_date>" + dt.Rows[0]["from_date"].ToString() + "</from_date>" + "<to_date>" + dt.Rows[0]["to_date"].ToString() + "</to_date>" );
            }
            catch
            { }
        }
        public void display()
        {
            try
            {
                String sqls = @"select a.id,a.ma_du_an,a.ten_du_an 
                            from da_du_an a where trang_thai_id in (2,3)";
                DataTable table = SQLConnectWeb.GetData(sqls);
                functions.fill_DropdownList(drop_project, table, 0, 1);

            }
            catch
            { 
            }
        
        
        }
    }
}