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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               display();
               Session["current"] = "1"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
               Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a>";
            }
        }

        public void display()
        {
            try
            {
                String sql = @"select a.*,b.name 
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID where b.id in (2,3) order by b.id";
                DataTable table = SQLConnectWeb.GetData(sql);

                showListProject.DataSource = table;
                showListProject.DataBind();

                //Hot news data
                String sql_hot_news = @"select a.* from bv_hot_news a";
                DataTable table_hot_news = SQLConnectWeb.GetData(sql_hot_news);

                Repeater1.DataSource = table_hot_news;
                Repeater1.DataBind();

                Repeater2.DataSource = table_hot_news;
                Repeater2.DataBind();

            }
            catch (Exception ex)
            {
            }
        
        
        }

        protected void showListProject_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                HyperLink hpLink = (HyperLink)e.Item.FindControl("link_new_post");
                Label posted_by= (Label)e.Item.FindControl("lbl_posted_by");

                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row["id"];
                string sql = @"select bai_viet_id,tieu_de,a.ngay_tao,b.username from bv_bai_viet a 
                            inner join ND_THONG_TIN_DN b on b.mem_id = a.nguoi_tao
                            where bai_viet_id =(select max(bai_viet_id) from bv_bai_viet  where bai_viet_cha_id is null and du_an_id=@du_an_id)";
                DataTable table = SQLConnectWeb.GetData(sql, "@du_an_id", id);
                hpLink.Text = table.Rows[0]["tieu_de"].ToString();
                DateTime posted_Date = (DateTime)table.Rows[0]["ngay_tao"];

                hpLink.NavigateUrl = String.Format("post_show_details.aspx?news_id={0}",table.Rows[0]["bai_viet_id"]);
                posted_by.Text = String.Format("<br><i><b>{0}</b> ngày, {1}</i>", table.Rows[0]["username"], posted_Date.ToString("dd/MM/yyy hh:mm:ss tt"));
            }
            catch
            { }
        }
     


    }
}
