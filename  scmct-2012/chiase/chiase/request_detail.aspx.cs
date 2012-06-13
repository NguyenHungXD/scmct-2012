using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chiase.Objects;
using DK2C.DataAccess.Web;
using System.Data;


namespace chiase
{
    public partial class request_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                display();
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='request_detail.aspx?id="+ Request.QueryString["id"]+" title='Chi tiết yêu cầu'>Chi tiết yêu cầu</a> ";
            }
            catch
            { }

        }
        public void display()
        {
            try
            {
                string sql = @"select a.*,b.name,c.ten_loai_yc,d.name as requested_by,
                                        case when a.trang_thai_id=1 then '.<input id=' + convert(nvarchar,a.yeu_cau_id) + ' name=chk type=checkbox value=' + convert(nvarchar,a.yeu_cau_id) + ' /><label for=' + convert(nvarchar,a.yeu_cau_id) + N'>Xóa</label> | <a style=cursor:pointer title='+N'Sửa'+' onclick=update_request('+ convert(nvarchar,a.yeu_cau_id) +')><img src=images/edit.gif width=20 height=20 alt=' +N'Cập nhật yêu cầu  id='+convert(nvarchar,a.yeu_cau_id)+ '></a>' else '.' end as del_request
                                        from yc_yeu_cau a 
                                        inner join YC_DM_TRANG_THAI_YEU_CAU b on a.trang_thai_id = b.id
                                        inner join YC_DM_LOAI_YEU_CAU c on a.loai_yc_id = c.id
                                        inner join ND_THONG_TIN_ND d on d.id = a.nguoi_yeu_cau
                                        where a.yeu_cau_id =@id
                                        and a.deleted is null";

                DataTable table_request = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["id"]);
                request_list.DataSource = table_request;
                request_list.DataBind();
            }
            catch
            { }
        
        }
    }
}