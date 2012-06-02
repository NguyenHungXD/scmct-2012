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
    public partial class search_status_project : System.Web.UI.Page
    {
        public static int vNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                if (Request.QueryString["vmode"] == "del")
                {
                    del_status();
                } if (Request.QueryString["vmode"] == "undel")
                {
                    undel_status();
                }
                else
                {
                    lbl_view_status.Visible = functions.checkPrivileges("10", functions.LoginMemID(this), "V");
                    lbl_del_status.Visible = functions.checkPrivileges("10", functions.LoginMemID(this), "D");
                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_status_project.aspx' title='Cập nhật trạng thái dự án'>Cập nhật trạng thái</a>";

                }
            }
        }

        public void del_status()
        {
            try
            {
                string sql = @"update DA_DM_TRANG_THAI_DU_AN set deleted ='Y' where id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void undel_status()
        {
            try
            {
                string sql = @"update DA_DM_TRANG_THAI_DU_AN set deleted =null where id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void display()
        {
            try
            {
                vNo = 1;


                tu_ngay.Text = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string vStatusName = "%";
                string vStatusID = "%";
                string vCreated_by = "%";



                if (dropd_status.SelectedValue != "None" && dropd_status.SelectedValue != "")
                    vStatusID = dropd_status.SelectedValue;
                if (txt_name.Text != "")
                    vStatusName = String.Format("%{0}%", txt_name.Text);
                if (txt_created_by.Text != "")
                    vCreated_by = String.Format("%{0}%", txt_created_by.Text);


                string sql = @"select a.*,b.name as created_by_name,
                                        case when a.deleted is null then 'FFFFFF' else 'CCCCCC' end as bgcolors
                                        from DA_DM_TRANG_THAI_DU_AN a 
                                        inner join ND_THONG_TIN_ND b on b.id = a.CREATED_BY
                                        where a.name like N'" + vStatusName + "' and a.id like N'" + vStatusID + "' and b.name like N'" + vCreated_by + "'";

                DataTable table_status = SQLConnectWeb.GetData(sql);
                status_list.DataSource = table_status;
                status_list.DataBind();




                string sql_status = @"select id,name from DA_DM_TRANG_THAI_DU_AN";
                using (DataTable sql_status_all = SQLConnectWeb.GetData(sql_status))
                {
                    functions.fill_DropdownList(dropd_status, sql_status_all, 0, 1);
                }
                functions.selectedDropdown(dropd_status, vStatusID);


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

        protected void status_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label lb_edit = (Label)e.Item.FindControl("lbl_edit");
                lb_edit.Visible = functions.checkPrivileges("9", functions.LoginMemID(this), "E");
            }
            catch
            { 
            
            }

        }
    }
}