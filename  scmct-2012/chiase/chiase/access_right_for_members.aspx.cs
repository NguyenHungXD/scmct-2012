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
    public partial class access_right_for_members : System.Web.UI.Page
    {
        public static int no;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                lbl_search_members.Visible = functions.checkPrivileges("41", functions.LoginMemID(this), "V");
                    no = 1;
                    display();
                
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='access_right_for_members.aspx' title='Xét quyền người dùng'>Xét quyền người dùng</a>";
            }
        }
    
     
     
    
     
        public void display()
        {
            try
            {

                string sWhere = "";
                tu_ngay.Text = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string group_id = "%";

                if (dropd_group.SelectedValue != "None" && dropd_group.SelectedValue != "")
                {
                    group_id = dropd_group.SelectedValue;
                    sWhere += " where d.groupid like '" + group_id + "'";
                }
                else
                    sWhere += " where d.groupid like '%'";

                if (txt_tendangnhap.Text != "")
                    sWhere += " and b.USERNAME like N'%" + txt_tendangnhap.Text + "%'";

                if (txt_hoten.Text != "")
                    sWhere += " and a.name like N'%" + txt_hoten.Text + "%'";

                if (txt_diachi.Text != "")
                    sWhere += " and a.address like N'%" + txt_diachi.Text + "%'";

                if (txt_email.Text != "")
                    sWhere += " and a.email like N'%" + txt_email.Text + "%'";

                if (txt_skype.Text != "")
                    sWhere += " and (a.skype like N'%" + txt_skype.Text + "%' or a.yahoo like N'%" + txt_skype.Text + "%' or a.fax like N'%" + txt_skype.Text + "%' or a.phone like N'%" + txt_skype.Text + "%')";

                if (txt_sothich.Text != "")
                    sWhere += " and a.note like N'%" + txt_sothich.Text + "%'";

                if (txt_nguoitao.Text != "")
                    sWhere += " and c.name like N'%" + txt_nguoitao.Text + "%'";

                string sql = @"select a.*,b.USERNAME as ten_dn,b.LASTED_ACCESS,b.CREATED_DATE,c.name as nguoi_tao,d.groupname,d.groupid,
                                    case when a.deleted is null then 'FFF' else '454' end as bgcolors,
                                    case when a.VISIBLE_BIT like '%Y%' then 'FFF' else '454' end as bgcolors1,
                                    case when a.avatar_path is null then 'default_img.gif' else a.avatar_path end as avatar
                                    from ND_THONG_TIN_ND a 
                                    left join ND_THONG_TIN_DN b on a.id = b.MEM_ID
                                    left join ND_THONG_TIN_ND c on b.CREATED_BY = c.id
                                    inner join ND_TEN_NHOM_ND d on a.MEM_GROUP_ID = d.groupid " + sWhere;

                DataTable table_detail = SQLConnectWeb.GetData(sql);
                member_list.DataSource = table_detail;
                member_list.DataBind();

                string sql_pt = @"select groupid,groupname from ND_TEN_NHOM_ND order by groupname";
                DataTable table_pt = SQLConnectWeb.GetData(sql_pt);
                functions.fill_DropdownList(dropd_group, table_pt, 0, 1);
                //functions.selectedDropdown(dropd_group, mapt);
            }
            catch (Exception ex)
            {
                //lbl_error.Text = ex.ToString();
            }

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            display();
        }

        protected void member_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label lb_access_right_for_group = (Label)e.Item.FindControl("lbl_access_for_group");
                Label lb_access_right_for_member = (Label)e.Item.FindControl("lbl_access_member");
                lb_access_right_for_group.Visible = functions.checkPrivileges("40", functions.LoginMemID(this), "E");
                lb_access_right_for_member.Visible = functions.checkPrivileges("41", functions.LoginMemID(this), "E");
            }
            catch
            { 
            }
        }

    }
}