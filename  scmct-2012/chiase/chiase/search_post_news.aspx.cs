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
    public partial class search_post_news : System.Web.UI.Page
    {
        public static int vNo;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["vmode"] == "del")
                {
                    del_news();
                } if (Request.QueryString["vmode"] == "undel")
                {
                    undel_news();
                }
                else if (Request.QueryString["vmode"] == "update_news_status")
                {
                    update_news_status();
                }
                else
                {
                    display();
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_post_news.aspx' title='Cập nhật bài viết'>Cập nhật bài viết</a>";

                }
            }
        }
        public void update_news_status()
        {
            try
            {
                string sql = @"update BV_BAI_VIET set trang_thai_id =@trang_thai_id where bai_viet_id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@trang_thai_id", Request.QueryString["status_id"], "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void del_news()
        {
            try
            {
                string sql = @"update BV_BAI_VIET set deleted ='Y' where bai_viet_id =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
            }
            catch
            {

            }

        }
        public void undel_news()
        {
            try
            {
                string sql = @"update BV_BAI_VIET set deleted =null where bai_viet_id =@id";
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
                string sWhere = " where a.bai_viet_cha_id is null";

                tu_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //string vTitle = "%";
                //string vDesc = "%";
                //string vCreated_by = "%";
                
                //string vSubject = "%";
                //string vProject = "%";
                string vStatus = "%";
                vStatus = dropd_status.SelectedValue;

                //where a.bai_viet_cha_id is null and a.tieu_de like N'" + vTitle + "' and a.noi_dung like N'" + vDesc + "' and a.trang_thai_id like N'" + vStatus + "' and c.name like N'" + vCreated_by + "'";
                if (dropd_status.SelectedValue != "None" && dropd_status.SelectedValue != "")
                {
                    vStatus = dropd_status.SelectedValue;
                    sWhere += " and a.trang_thai_id like N'" + vStatus + "'";
                }
                if (txt_title.Text != "")
                    //vTitle = String.Format("%{0}%", txt_title.Text);
                    sWhere += " and a.tieu_de like N'%" + txt_title.Text + "%'";
                if (txt_description.Text != "")
                    //vDesc = String.Format("%{0}%", txt_description.Text);
                    sWhere += " and a.noi_dung like N'%" + txt_description.Text + "%'";
                if (txt_created_by.Text != "")
                    //vCreated_by = String.Format("%{0}%", txt_created_by.Text);
                    sWhere += " and c.name like N'%" + txt_created_by.Text + "%'";
                if (txt_subject.Text != "")
                    //vSubject = String.Format("%{0}%", txt_subject.Text);
                    sWhere += " and d.title like N'%" + txt_subject.Text + "%'";
                if (txt_project.Text != "")
                    //vProject = String.Format("%{0}%", txt_project.Text);
                    sWhere += " and e.ma_du_an like N'%" + txt_project.Text + "%'";

                string sql = @"select a.*,b.id as status_id,b.name as status_name,c.name as ten_nguoi_tao,d.title as chu_de,'<b>'+e.ma_du_an + '</b><br>' + e. ten_du_an as du_an,
                                        case when a.deleted is null then 'FFFFFF' else 'CCCCCC' end as bgcolors
                                        from BV_BAI_VIET a 
                                        inner join BV_DM_TRANG_THAI_BAI_VIET b on a.trang_thai_id = b.id
                                        inner join ND_THONG_TIN_ND c on c.id = a.nguoi_tao
                                        left join BV_DM_CHU_DE_BV d on d.id = a.chu_de_id
                                        left join DA_DU_AN e on e.id = a.du_an_id" + sWhere;
                                        //where a.bai_viet_cha_id is null and a.tieu_de like N'" + vTitle + "' and a.noi_dung like N'" + vDesc + "' and a.trang_thai_id like N'" + vStatus + "' and c.name like N'" + vCreated_by + "'";

                DataTable table_request = SQLConnectWeb.GetData(sql);
                news_list.DataSource = table_request;
                news_list.DataBind();

                string sql_status = @"select id,name from BV_DM_TRANG_THAI_BAI_VIET";
                using (DataTable table_status = SQLConnectWeb.GetData(sql_status))
                {
                    functions.fill_DropdownList(dropd_status, table_status, 0, 1);
                }

                functions.selectedDropdown(dropd_status, vStatus);


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

        protected void news_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long status_id = (long)RowView.Row["TRANG_THAI_ID"];
                long news_id = (long)RowView.Row["bai_viet_id"];
                DropDownList drop_status = (DropDownList)e.Item.FindControl("dropd_status");

                string sql = @"select id,name from BV_DM_TRANG_THAI_BAI_VIET";
                DataTable table_status = SQLConnectWeb.GetData(sql);
                functions.fill_DropdownList(drop_status, table_status, 0, 1, news_id.ToString());
                functions.selectedDropdown(drop_status, String.Format("{0};{1}", news_id, status_id));



            }
            catch
            { }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                display();
            }
            catch
            { }
        }
    }
}