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
    public partial class access_right_for_group : System.Web.UI.Page
    {
        public static int vNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                lbl_seach_group.Visible = functions.checkPrivileges("40", functions.LoginMemID(this), "V");

                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='access_right_for_groups.aspx' title='Xét quyền truy cập cho nhóm'>Xét quyền cho nhóm</a>";
            }
        }

        public void display()
        {
            try
            {
                vNo = 1;


                tu_ngay.Text = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string vGroupName = "%";
                string vGroupID = "%";
                string vCreated_by = "%";



                if (dropd_group.SelectedValue != "None" && dropd_group.SelectedValue != "")
                    vGroupID = dropd_group.SelectedValue;
                if (txt_name.Text != "")
                    vGroupName = String.Format("%{0}%", txt_name.Text);
                if (txt_created_by.Text != "")
                    vCreated_by = String.Format("%{0}%", txt_created_by.Text);


                string sql = @"select a.*,b.name as created_by_name,
                                        case when a.deleted is null then 'FFF' else '454' end as bgcolors,
                                        case when a.is_active like '%Y%' then 'FFF' else '454' end as bgcolors1
                                        from ND_TEN_NHOM_ND a 
                                        inner join ND_THONG_TIN_ND b on b.id = a.CREATED_BY
                                        where a.groupname like N'" + vGroupName + "' and a.groupid like N'" + vGroupID + "' and b.name like N'" + vCreated_by + "'";

                DataTable table_status = SQLConnectWeb.GetData(sql);
                group_list.DataSource = table_status;
                group_list.DataBind();




                string sql_status = @"select groupid,groupname from ND_TEN_NHOM_ND";
                using (DataTable sql_status_all = SQLConnectWeb.GetData(sql_status))
                {
                    functions.fill_DropdownList(dropd_group, sql_status_all, 0, 1);
                }
                functions.selectedDropdown(dropd_group, vGroupID);


            }
            catch
            { }

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                display();
            }
            catch
            {
            }
        }

        protected void group_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label lb_access = (Label)e.Item.FindControl("lbl_create_access_for_group");
                lb_access.Visible = functions.checkPrivileges("40", functions.LoginMemID(this), "E");
            }
            catch
            { 
            
            }
        }
    }
}