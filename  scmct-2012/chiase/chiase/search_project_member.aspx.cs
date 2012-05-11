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
    public partial class search_project_member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           display();
        }
        public void display()
        {
            try
            {
                String sql_list_member = @"select a.du_an_id,a.mem_id,b.name,a.added_date,c.groupname,d.post_name,e.name as added_name,f.username,
                                        case when status=1 then 'Đã duyêt' else 'Chờ duyêt' end as status
                                        from da_nhan_su a
                                        inner join nd_thong_tin_nd b on a.mem_id = b.id
                                        inner join nd_ten_nhom_nd c on b.mem_group_id = c.groupid
                                        inner join da_position d on a.position=d.pos_id
                                        inner join nd_thong_tin_nd e on a.added_by = e.id
                                        left join ND_THONG_TIN_DN f on a.mem_id = f.mem_id";

                DataTable table_list_member = SQLConnectWeb.GetData(sql_list_member);
                showListmember.DataSource = table_list_member;
                showListmember.DataBind();
            }
            catch (Exception ex)
            { }
        
        }
    }
}