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
    public partial class search_module_list : System.Web.UI.Page
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
                    del_module();
                }
                else if (Request.QueryString["vmode"] == "undel")
                {
                    undel_module();
                }
                else if (Request.QueryString["vmode"] == "lock")
                {
                    lock_module();
                }
                else if (Request.QueryString["vmode"] == "unlock")
                {
                    unlock_module();
                }
                else
                {
                    lbl_create_module.Visible = functions.checkPrivileges("37", functions.LoginMemID(this), "C");
                    lbl_del_module.Visible = functions.checkPrivileges("38", functions.LoginMemID(this), "D");
                    lbl_lock_module.Visible = functions.checkPrivileges("38", functions.LoginMemID(this), "L");
                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_module_list.aspx' title='Cập nhật chức năng'>Cập nhật chức năng</a>";
                }
            }
        }

        public void del_module()
        {
            try
            {
                string sql = @"update PQ_CHUC_NANG set deleted ='Y' where id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void undel_module()
        {
            try
            {
                string sql = @"update PQ_CHUC_NANG set deleted =null where id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void lock_module()
        {
            try
            {
                string sql = @"update PQ_CHUC_NANG set visible_bit ='N' where id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void unlock_module()
        {
            try
            {
                string sql = @"update PQ_CHUC_NANG set visible_bit ='Y' where id =@id";
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


                tu_ngay.Text = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string vModuleName = "%";
                string vModuleID = "%";
                string vCreated_by = "%";
                string vModuleDesc = "%";
                string vModuleAcesspath = "%";
                string vModuleCodepath = "%";
                string vFeatureid = "%";

                if (dropd_module.SelectedValue != "None" && dropd_module.SelectedValue != "")
                    vModuleID = dropd_module.SelectedValue;
                if (txt_name.Text != "")
                    vModuleName = String.Format("%{0}%", txt_name.Text);
                if (txt_created_by.Text != "")
                    vCreated_by = String.Format("%{0}%", txt_created_by.Text);
                if (txt_desc.Text!= "")
                    vModuleDesc = String.Format("%{0}%", txt_desc.Text);
                if (txt_access_path.Text!= "")
                    vModuleAcesspath = String.Format("%{0}%", txt_access_path.Text);
                if (txt_code_path.Text != "")
                    vModuleCodepath = String.Format("%{0}%", txt_code_path.Text);
                if ( txt_featureid.Text!= "")
                    vFeatureid = String.Format("%{0}%", txt_featureid.Text);


                string sql = @"select a.*,b.name as created_by_name,
                                        case when a.deleted is null then 'FFF' else '454' end as bgcolors,
                                        case when a.visible_bit like '%Y%' then 'FFF' else '454' end as bgcolors1
                                        from PQ_CHUC_NANG a 
                                        inner join ND_THONG_TIN_ND b on b.id = a.CREATED_BY
                                        where a.name like N'" + vModuleName + "' and a.id like N'" + vModuleID + "' and b.name like N'" + vCreated_by + "' and a.description like N'" + vModuleDesc + "' and a.ACCESS_PATH like N'" + vModuleAcesspath + "' and a.CODE_PATH like N'" + vModuleCodepath + "' and a.featureid like N'" + vFeatureid + "' order by featureid";

                DataTable table_status = SQLConnectWeb.GetData(sql);
                module_list.DataSource = table_status;
                module_list.DataBind();




                string sql_status = @"select id,featureid from PQ_CHUC_NANG";
                using (DataTable sql_status_all = SQLConnectWeb.GetData(sql_status))
                {
                    functions.fill_DropdownList(dropd_module, sql_status_all, 0, 1);
                }
                functions.selectedDropdown(dropd_module, vModuleID);


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

        protected void module_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label lb_edit = (Label)e.Item.FindControl("lbl_edit_module");
                lb_edit.Visible = functions.checkPrivileges("38", functions.LoginMemID(this), "E");
            }
            catch
            { }
        }
    }
}