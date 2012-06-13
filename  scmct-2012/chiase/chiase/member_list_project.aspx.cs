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
    public partial class member_list_project : System.Web.UI.Page
    {
        public static int noofcnt = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            noofcnt = 1;
            if (!IsPostBack)
                //Check LogIn session
                //functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='member_list_project.aspx?id={0}'title='Xem chi tiết danh sách tham gia dự án'>Danh sách tham gia dự án</a> ", Request.QueryString["id"]);
                display();
        }

        public void display()
        {
            try
            {
                string sql_da = @"select ma_du_an,ten_du_an,CONVERT(VARCHAR(10),NGAY_BAT_DAU,103) NGAY_BAT_DAU,CONVERT(VARCHAR(10),NGAY_KET_THUC,103) NGAY_KET_THUC from da_du_an where id=" + Request.QueryString["id"];
                DataTable dt = SQLConnectWeb.GetData(sql_da);
                lbl_ma_du_an.Text = dt.Rows[0]["ma_du_an"].ToString();
                lbl_ten_du_an.Text = dt.Rows[0]["ten_du_an"].ToString();
                lbl_start_date.Text = dt.Rows[0]["ngay_bat_dau"].ToString();
                lbl_end_date.Text = dt.Rows[0]["ngay_ket_thuc"].ToString();

                String sql_list_member = @"select a.id,a.active,a.du_an_id,a.mem_id,b.name,b.heart,a.added_date,c.groupname,d.post_name,e.name as added_name,f.username,
                                            case when status=1 then N'Đã duyêt' else N'Chờ duyêt' end as status
                                            from da_nhan_su a
                                            inner join nd_thong_tin_nd b on a.mem_id = b.id
                                            inner join nd_ten_nhom_nd c on b.mem_group_id = c.groupid
                                            inner join da_position d on a.position=d.pos_id
                                            inner join nd_thong_tin_nd e on a.added_by = e.id
                                            left join ND_THONG_TIN_DN f on a.mem_id = f.mem_id where a.du_an_id=" + Request.QueryString["id"];
                DataTable table_list_member = SQLConnectWeb.GetData(sql_list_member);
                showListmember.DataSource = table_list_member;
                showListmember.DataBind();

            }
            catch(Exception ex)
            {
                lbl_ma_du_an.Text = ex.ToString();
            }
        
        
        }
    }
}