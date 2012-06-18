using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;
using DK2C.DataAccess.Web;
using System.Collections;

namespace chiase
{
    public partial class search_subject : System.Web.UI.Page
    {
        public static int vNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                Boolean checkDel = functions.checkPrivileges("20", functions.LoginMemID(this), "D");
                Boolean checkEdit = functions.checkPrivileges("20", functions.LoginMemID(this), "E");
                Boolean checkView = functions.checkPrivileges("21", functions.LoginMemID(this), "V");

                

                if (Request.QueryString["vmode"] == "del" && checkDel)
                {
                     del_subject();
                } if (Request.QueryString["vmode"] == "undel" && checkDel)
                {
                     undel_subject();
                }
                else if (Request.QueryString["vmode"] == "update_subject_status" && checkEdit)
                {
                    update_subject_status();
                }
                else
                {
                    lbl_del_subject.Visible = checkDel;
                    lbl_search_subject.Visible = checkView;
                    subject_list.Visible = checkView;

                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_subject.aspx' title='Cập nhật chủ đề'>Cập nhật chủ đề</a>";

                }
            }
        }
        public void update_subject_status()
        {
            try
            {
                string sql = @"update BV_DM_CHU_DE_BV set status =@status where chu_de_id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@status", Request.QueryString["status_id"], "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void del_subject()
        {
            try
            {
                string sql = @"update BV_DM_CHU_DE_BV set deleted ='Y' where chu_de_id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void undel_subject()
        {
            try
            {
                string sql = @"update BV_DM_CHU_DE_BV set deleted =null where chu_de_id =@id";
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

                string vTitle = "%";
                string vDesc = "%";
                string vCreated_by = "%";
                string vStatus = "%";
                string vSubjectType = "%";

                if (dropd_status.SelectedValue != "None" && dropd_status.SelectedValue != "")
                    vStatus = dropd_status.SelectedValue;
                if (txt_title.Text != "")
                    vTitle = String.Format("%{0}%", txt_title.Text);
                if (txt_description.Text!= "")
                    vDesc = String.Format("%{0}%", txt_description.Text);
                if (txt_created_by.Text != "")
                    vCreated_by = String.Format("%{0}%", txt_created_by.Text);
                if (dropd_project_type.SelectedValue != "None" && dropd_project_type.SelectedValue != "")
                    vSubjectType = dropd_project_type.SelectedValue;


                string sql = @"select a.*,b.id as status_id,b.name as status_name,c.name,
                                        case when a.deleted is null then 'FFFFFF' else 'CCCCCC' end as bgcolors
                                        from BV_DM_CHU_DE_BV a 
                                        inner join BV_NEWS_TYPE d on d.types_id = a.types_id
                                        inner join BV_DM_TRANG_THAI_BAI_VIET b on a.status = b.id
                                        inner join ND_THONG_TIN_ND c on c.id = a.CREATED_BY
                                        where a.types_id like N'" + vSubjectType + "' and a.title like N'" + vTitle + "' and a.description like N'" + vDesc + "' and a.status like N'" + vStatus + "' and c.name like N'" + vCreated_by + "'";

                DataTable table_request = SQLConnectWeb.GetData(sql);
                subject_list.DataSource = table_request;
                subject_list.DataBind();

                string sql_status = @"select id,name from BV_DM_TRANG_THAI_BAI_VIET";
                using (DataTable table_status = SQLConnectWeb.GetData(sql_status))
                {
                    functions.fill_DropdownList(dropd_status, table_status, 0, 1);
                }

                functions.selectedDropdown(dropd_status,vStatus);

                string sql_subjectType = @"select types_id,name from bv_news_type where types_id <> 5";
                using (DataTable table_news_type = SQLConnectWeb.GetData(sql_subjectType))
                {
                    functions.fill_DropdownList(dropd_project_type, table_news_type, 0, 1);
                }

                functions.selectedDropdown(dropd_project_type, vSubjectType);

            }
            catch
            { }

        }

        protected void subject_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long status_id = (long)RowView.Row["status_id"];
                long subject_id = (long)RowView.Row["chu_de_id"];
                DropDownList drop_status = (DropDownList)e.Item.FindControl("dropd_status");

                string sql = @"select id,name from BV_DM_TRANG_THAI_BAI_VIET";
                DataTable table_status = SQLConnectWeb.GetData(sql);
                functions.fill_DropdownList(drop_status,table_status, 0, 1,subject_id.ToString());
                functions.selectedDropdown(drop_status, String.Format("{0};{1}", subject_id, status_id));

                Label lbl_edit = (Label)e.Item.FindControl("lbl_edit_subject");
                Label lbl_edit_status = (Label)e.Item.FindControl("lbl_edit_status_subject");
                Label lbl_status = (Label)e.Item.FindControl("lbl_status_subject");
                if (functions.checkPrivileges("20", functions.LoginMemID(this), "E"))
                {
                    lbl_edit.Visible = true;
                    lbl_edit_status.Visible = true;
                }
                else
                { 
                    lbl_edit.Visible = false;
                    lbl_edit_status.Visible = false;
                    lbl_status.Text = drop_status.SelectedItem.Text;
                }
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
            catch { }
        }


    }
}