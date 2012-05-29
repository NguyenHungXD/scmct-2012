using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chiase.Objects;
using DK2C.DataAccess.Web;
using System.Collections;
using System.Data;
namespace chiase
{
    public partial class search_status_news : System.Web.UI.Page
    {
        public static int vNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["vmode"] == "del")
                {
                    del_status();
                } if (Request.QueryString["vmode"] == "undel")
                {
                    undel_status();
                }
                else
                {
                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_status_news.aspx' title='Cập nhật trạng thái bài viết'>Cập nhật trạng thái</a>";

                }
            }
        }
  
        public void del_status()
        {
            try
            {
                string sql = @"update BV_DM_TRANG_THAI_BAI_VIET set deleted ='Y' where id =@id";
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
                string sql = @"update BV_DM_TRANG_THAI_BAI_VIET set deleted =null where id =@id";
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
                                        from BV_DM_TRANG_THAI_BAI_VIET a 
                                        inner join ND_THONG_TIN_ND b on b.id = a.CREATED_BY
                                        where a.name like N'" + vStatusName + "' and a.id like N'" + vStatusID + "' and b.name like N'" + vCreated_by + "'";

                DataTable table_status = SQLConnectWeb.GetData(sql);
                status_list.DataSource = table_status;
                status_list.DataBind();




                string sql_status = @"select id,name from BV_DM_TRANG_THAI_BAI_VIET";
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




    }
}