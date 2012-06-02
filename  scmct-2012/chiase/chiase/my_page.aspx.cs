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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='my_page.aspx' title='Trang của tôi'>Trang của tôi</a> ";
                if (Request.QueryString["vmode"] == "del")
                    delete_request();
                else
                    display();
            
            }
        }
        public void delete_request()
        {
            try
            {
                string sql = @"update yc_yeu_cau set deleted='Y',nguoi_cap_nhat=@nguoi_cap_nhat,ngay_cap_nhat=@ngay_cap_nhat where yeu_cau_id=@id";
                SQLConnectWeb.ExecuteNonQuery(sql,
                                "@id", Request.QueryString["id"],
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
                string sql = @"select a.*,b.name,c.ten_loai_yc,d.name as requested_by,
                                        case when a.trang_thai_id=1 then '.<input id=' + convert(nvarchar,a.yeu_cau_id) + ' name=chk type=checkbox value=' + convert(nvarchar,a.yeu_cau_id) + ' /><label for=' + convert(nvarchar,a.yeu_cau_id) + N'>Xóa</label> | <a style=cursor:pointer title='+N'Sửa'+' onclick=update_request('+ convert(nvarchar,a.yeu_cau_id) +')><img src=images/edit.gif width=20 height=20 alt=' +N'Cập nhật yêu cầu  id='+convert(nvarchar,a.yeu_cau_id)+ '></a>' else '.' end as del_request
                                        from yc_yeu_cau a 
                                        inner join YC_DM_TRANG_THAI_YEU_CAU b on a.trang_thai_id = b.id
                                        inner join YC_DM_LOAI_YEU_CAU c on a.loai_yc_id = c.id
                                        inner join ND_THONG_TIN_ND d on d.id = a.nguoi_yeu_cau
                                        where nguoi_yeu_cau =@nguoi_yeu_cau
                                        and a.deleted is null";

                DataTable table_request = SQLConnectWeb.GetData(sql, "@nguoi_yeu_cau", Request.QueryString["id"]);
                request_list.DataSource = table_request;
                request_list.DataBind();

            }
            catch
            { }

        }
    }
}