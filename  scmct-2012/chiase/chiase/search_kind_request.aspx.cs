using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DK2C.DataAccess.Web;
using System.Collections;
using System.Data;

namespace chiase
{
    public partial class search_kind_request : System.Web.UI.Page
    {
        public static int vNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                Boolean isDel = functions.checkPrivileges("18", functions.LoginMemID(this), "D");
                Boolean isView = functions.checkPrivileges("18", functions.LoginMemID(this), "V");

                if (Request.QueryString["vmode"] == "del" && isDel)
                {
                    del_kind_request();
                } if (Request.QueryString["vmode"] == "undel" && isDel)
                {
                    undel_kind_request();
                }
                else
                {

                    lbl_search_kind_request.Visible = isView;
                    kind_list.Visible = isView;
                    lbl_del_kind_request.Visible = isDel;

                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_kind_request.aspx' title='Cập nhật loại yêu cầu'>Cập nhật loại yêu cầu</a>";

                }
            }
        }

        public void del_kind_request()
        {
            try
            {
                string sql = @"update YC_DM_LOAI_YEU_CAU set deleted ='Y' where id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void undel_kind_request()
        {
            try
            {
                string sql = @"update YC_DM_LOAI_YEU_CAU set deleted =null where id =@id";
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


                tu_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string vKindName = "%";
                string vKindID = "%";
                string vCreated_by = "%";



                if (dropd_kind_request.SelectedValue != "None" && dropd_kind_request.SelectedValue != "")
                    vKindID = dropd_kind_request.SelectedValue;
                if (txt_name.Text != "")
                    vKindName = String.Format("%{0}%", txt_name.Text);
                if (txt_created_by.Text != "")
                    vCreated_by = String.Format("%{0}%", txt_created_by.Text);


                string sql = @"select a.*,b.name as ten_nguoi_tao,
                                        case when a.deleted is null then 'FFFFFF' else 'CCCCCC' end as bgcolors
                                        from YC_DM_LOAI_YEU_CAU a 
                                        inner join ND_THONG_TIN_ND b on b.id = a.nguoi_tao
                                        where a.ten_loai_yc like N'" + vKindName + "' and a.id like N'" + vKindID + "' and b.name like N'" + vCreated_by + "'";

                DataTable table_status = SQLConnectWeb.GetData(sql);
                kind_list.DataSource = table_status;
                kind_list.DataBind();




                string sql_status = @"select id,ten_loai_yc from YC_DM_LOAI_YEU_CAU";
                using (DataTable sql_status_all = SQLConnectWeb.GetData(sql_status))
                {
                    functions.fill_DropdownList(dropd_kind_request, sql_status_all, 0, 1);
                }
                functions.selectedDropdown(dropd_kind_request, vKindID);


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

        protected void kind_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label lb_edit = (Label)e.Item.FindControl("lbl_search_kind_request");
                lb_edit.Visible = functions.checkPrivileges("18", functions.LoginMemID(this), "D");
            }
            catch
            {
            }
        }
    }
}