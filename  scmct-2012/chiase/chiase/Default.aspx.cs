using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;

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
            DataTable table = BV_DM_CHU_DE_BV.GetTableFields(new string[] { BV_DM_CHU_DE_BV.cl_SORT },
                BV_DM_CHU_DE_BV.cl_ID, BV_DM_CHU_DE_BV.cl_TITLE, BV_DM_CHU_DE_BV.cl_DESCRIPTION);
            DataList1.DataSource = table;
            DataList1.DataBind();
        
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView GridView1 = (GridView)e.Item.FindControl("GridView1");
            DataRowView RowView = (DataRowView)e.Item.DataItem;
            if (RowView == null) return;
            long id = (long)RowView.Row[BV_DM_CHU_DE_BV.cl_ID];
            DataTable baiviet = BV_BAI_VIET.GetTableFields(BV_BAI_VIET.cl_CHU_DE_ID + "=" + id,
                new string[] { BV_BAI_VIET.cl_SORT }, BV_BAI_VIET.cl_TIEU_DE, BV_BAI_VIET.cl_NOI_DUNG);

            GridView1.DataSource = baiviet;
            GridView1.DataBind();
        }

    }
}
