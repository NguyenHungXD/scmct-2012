using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace chiase
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                display();
            
            }
        }
        public void display()
        {
            String sql = "Select id,title, description from BV_DM_CHU_DE_BV order by sort ";
            DataTable table = Database.GetData(sql);
            DataList1.DataSource = table;
            DataList1.DataBind();
        
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView GridView1 = (GridView)e.Item.FindControl("GridView1");
            DataRowView RowView = (DataRowView)e.Item.DataItem;
            if (RowView == null) return;
            long id = (long)RowView.Row["id"];
            String sql = "SELECT tieu_de,noi_dung FROM bv_bai_viet WHERE CHU_DE_ID=@v_id order by sort";
            DataTable baiviet = Database.GetData(sql, "@v_id", id);

            GridView1.DataSource = baiviet;
            GridView1.DataBind();
        }

    }
}
