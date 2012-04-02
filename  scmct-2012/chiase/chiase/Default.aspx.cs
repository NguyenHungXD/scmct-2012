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
            
            }
        }
        public void display()
        {
            DataTable table = BV_DM_CHU_DE_BV.GetTableFields(new string[] { BV_DM_CHU_DE_BV.cl_SORT },
                BV_DM_CHU_DE_BV.cl_ID, BV_DM_CHU_DE_BV.cl_TITLE, BV_DM_CHU_DE_BV.cl_DESCRIPTION,BV_DM_CHU_DE_BV.cl_CREATED_DATE);
            DataList1.DataSource = table;
            DataList1.DataBind();
        
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            GridView GridView1 = (GridView)e.Item.FindControl("GridView1");
            DataRowView RowView = (DataRowView)e.Item.DataItem;
            if (RowView == null) return;
            long id = (long)RowView.Row[BV_DM_CHU_DE_BV.cl_ID];

            //nvdat02/04/12 : Get posted_by field --commented-out and replace
            String sql = string.Format(@"SELECT a.*,b.USERNAME
                         FROM BV_BAI_VIET a
                        INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
                        WHERE BAI_VIET_ID=N'{0}'", id);
            DataTable baiviet = SQLConnectWeb.GetTable(sql);
           // DataTable baiviet = BV_BAI_VIET.GetTableFields(BV_BAI_VIET.cl_CHU_DE_ID + "=" + id,
           //     new string[] { BV_BAI_VIET.cl_SORT }, BV_BAI_VIET.cl_TIEU_DE, BV_BAI_VIET.cl_NOI_DUNG);

            GridView1.DataSource = baiviet;
            GridView1.DataBind();
        }

    }
}
