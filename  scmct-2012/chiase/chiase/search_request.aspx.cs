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
    public partial class search_request : System.Web.UI.Page
    {
        public static int no = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["vmode"] == "del")
                {
                    del_request();
                } if (Request.QueryString["vmode"] == "undel")
                {
                    undel_request();
                }
                else if (Request.QueryString["vmode"] == "update_kind_request")
                {
                    update_kind_request();
                }
                else if (Request.QueryString["vmode"] == "update_request_status")
                {
                    update_request_status();
                }
                else
                {
                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_request.aspx' title='Cập nhật yêu cầu'>Cập nhật yêu cầu</a>";
                }
            }
        }
        public void update_kind_request()
        {
            try
            {
                string sql = @"update YC_YEU_CAU set loai_yc_id =@loai_yc_id where yeu_cau_id =@yeu_cau_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@loai_yc_id", Request.QueryString["ids"], "@yeu_cau_id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void update_request_status()
        {
            try
            {
                string sql = @"update YC_YEU_CAU set trang_thai_id =@trang_thai_id where yeu_cau_id =@yeu_cau_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@trang_thai_id", Request.QueryString["ids"], "@yeu_cau_id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void del_request()
        {
            try
            {
                string sql = @"update YC_YEU_CAU set deleted ='Y' where yeu_cau_id =@yeu_cau_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@yeu_cau_id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void undel_request()
        {
            try
            {
                string sql = @"update YC_YEU_CAU set deleted =null where yeu_cau_id =@yeu_cau_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@yeu_cau_id", Request.QueryString["id"]);
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

                tu_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string vTitle = "%";
                string vDesc = "%";
                string vCreated_by = "%";
                string vKindRequest = "%";
                string vStatus = "%";

                if (dropd_kind_request.SelectedValue != "None" && dropd_kind_request.SelectedValue != "")
                    vKindRequest = dropd_kind_request.SelectedValue;
                if (dropd_status.SelectedValue != "None" && dropd_status.SelectedValue != "")
                    vStatus = dropd_status.SelectedValue;
                if (txt_title.Text != "")
                    vTitle = String.Format("%{0}%", txt_title.Text);
                if (txt_description.Text != "")
                    vDesc = String.Format("%{0}%", txt_description.Text);
                if (txt_created_by.Text != "")
                    vCreated_by = String.Format("%{0}%", txt_created_by.Text);
                
                string sql = @"select a.*,b.id as status_id,b.name,c.id as kind_request_id,c.ten_loai_yc,d.name as requested_by,
                                        case when a.deleted is null then 'FFFFFF' else 'CCCCCC' end as bgcolors
                                        from yc_yeu_cau a 
                                        inner join YC_DM_TRANG_THAI_YEU_CAU b on a.trang_thai_id = b.id
                                        inner join YC_DM_LOAI_YEU_CAU c on a.loai_yc_id = c.id
                                        inner join ND_THONG_TIN_ND d on d.id = a.nguoi_yeu_cau
                                        where a.tieu_de like N'" + vTitle + "' and a.noi_dung like N'" + vDesc + "' and a.trang_thai_id like N'" + vStatus + "' and a.loai_yc_id like N'" + vKindRequest + "' and d.name like N'"+vCreated_by+"'";

                DataTable table_request = SQLConnectWeb.GetData(sql);
                request_list.DataSource = table_request;
                request_list.DataBind();

                string sql_request = @"select id,name from YC_DM_TRANG_THAI_YEU_CAU";
                using (DataTable table_status = SQLConnectWeb.GetData(sql_request))
                {
                    functions.fill_DropdownList(dropd_status, table_status, 0, 1);
                    functions.selectedDropdown(dropd_status,vStatus);
                }

                string sql_kind_request = @"select id,ten_loai_yc from YC_DM_LOAI_YEU_CAU";
                using (DataTable table_kind_request = SQLConnectWeb.GetData(sql_kind_request))
                {
                    functions.fill_DropdownList(dropd_kind_request, table_kind_request, 0, 1);
                    functions.selectedDropdown(dropd_kind_request,vKindRequest);
                }



            }
            catch
            { }

        }

        protected void request_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long status_id = (long)RowView.Row["status_id"];
                long request_id = (long)RowView.Row["yeu_cau_id"];
                long kind_request_id = (long)RowView.Row["kind_request_id"];

                string sql = @"select id,name from YC_DM_TRANG_THAI_YEU_CAU";
                DataTable table_request = SQLConnectWeb.GetData(sql);

                DropDownList dropd_status = (DropDownList)e.Item.FindControl("dropd_status");
                functions.fill_DropdownList(dropd_status, table_request, 0, 1, request_id.ToString());
                DropDownList kind_request = (DropDownList)e.Item.FindControl("dropd_kind_request");
                functions.selectedDropdown(dropd_status, String.Format("{0};{1}", request_id, status_id));

                string sql_kind_request = @"select id,ten_loai_yc from YC_DM_LOAI_YEU_CAU";
                DataTable table_kind_request = SQLConnectWeb.GetData(sql_kind_request);
                functions.fill_DropdownList(kind_request, table_kind_request, 0, 1, request_id.ToString());
                functions.selectedDropdown(kind_request, String.Format("{0};{1}", request_id, kind_request_id));
            }
            catch
            { 
            
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            try {

                display();
            }
            catch
            { }
        }
    }
}