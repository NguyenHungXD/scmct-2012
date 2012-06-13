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
    public partial class my_page : System.Web.UI.Page
    {
        public static int no = 1;
        
        public static Boolean check = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            check = false;
            if(!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                if (Request.QueryString["id"] == functions.LoginMemID(this))
                {
                    check = true;
                }
                lbl_del.Visible = check;
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='my_page.aspx' title='Trang của tôi'>Trang của tôi</a> ";
                if (Request.QueryString["vmode"] == "del" && check)
                    delete_request();
                else if(Request.QueryString["project_id"]!=null)
                    getProject_info();
                else
                    display();
                //Danh sách hàng hóa đã đóng góp
                //link_view_contribution_list.NavigateUrl = "contribution_product_list.aspx?id=" + Request.QueryString["id"];
                userid.Value = Request.QueryString["id"];
            
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
        public void delete_request()
        {
            try
            {
                string sql = @"update yc_yeu_cau set deleted='Y',nguoi_cap_nhat=@nguoi_cap_nhat,ngay_cap_nhat=@ngay_cap_nhat where yeu_cau_id=@id";
                SQLConnectWeb.ExecuteNonQuery(sql,
                                "@id", Request.QueryString["request_id"],
                                "@nguoi_cap_nhat", functions.LoginMemID(this),
                                "@ngay_cap_nhat",functions.GetStringDatetime());
            }
            catch
            { 
            
            }
        
        }

        public void display()
        {
            try
            {
                no = 1;
                string selectMore = "";
                if (check)
                {
                    selectMore = ",case when a.trang_thai_id=1 then '.<input id=' + convert(nvarchar,a.yeu_cau_id) + ' name=chk type=checkbox value=' + convert(nvarchar,a.yeu_cau_id) + ' /><label for=' + convert(nvarchar,a.yeu_cau_id) + N'>Xóa</label> | <a style=cursor:pointer title='+N'Sửa'+' onclick=update_request('+ convert(nvarchar,a.yeu_cau_id) +')><img src=images/edit.gif width=20 height=20 alt=' +N'Cập nhật yêu cầu  id='+convert(nvarchar,a.yeu_cau_id)+ '></a>' else '.' end as del_request";
                }
                else
                {
                    selectMore = ", null as del_request";
                }


                string sql = @"select a.*,b.name,c.ten_loai_yc,d.name as requested_by " + selectMore +" from yc_yeu_cau a inner join YC_DM_TRANG_THAI_YEU_CAU b on a.trang_thai_id = b.id inner join YC_DM_LOAI_YEU_CAU c on a.loai_yc_id = c.id inner join ND_THONG_TIN_ND d on d.id = a.nguoi_yeu_cau where nguoi_yeu_cau =@nguoi_yeu_cau and a.deleted is null";

                DataTable table_request = SQLConnectWeb.GetData(sql, "@nguoi_yeu_cau", Request.QueryString["id"]);
                if (table_request.Rows.Count == 0)
                {
                    lbl_del.Visible = false;
                }
                else
                {
                    request_list.DataSource = table_request;
                    request_list.DataBind();
                }
                //Fill data for project Box
                String sqls = @"select a.id,a.ma_du_an,a.ten_du_an 
                            from da_du_an a where trang_thai_id in (2,3)";
                DataTable table = SQLConnectWeb.GetData(sqls);
                functions.fill_DropdownList(drop_project, table, 0, 1);
            }
            catch
            { }

        }
    }
}