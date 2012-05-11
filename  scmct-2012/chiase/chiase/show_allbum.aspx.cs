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
    public partial class show_allbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                display();
        }
        public void display()
        {
            try
            {
                String sql = @"select a.*,b.name,c.username
                            from IMG_ALLBUM a 
                            inner join ND_THONG_TIN_ND b on a.created_by = b.ID
                            inner join ND_THONG_TIN_DN c on c.mem_id = b.ID
                            order by allbum_id";
                DataTable table = SQLConnectWeb.GetData(sql);

                DataList1.DataSource = table;
                DataList1.DataBind();
            }
            catch

            { }
            
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row["allbum_id"];
                Label cnt = (Label)e.Item.FindControl("lbl_cnt_img");
                String sql = @"select count(*) as v_cnt from IMG_ALLBUM_DETAIL where allbum_id = @id";
                DataTable table = SQLConnectWeb.GetData(sql, "@id", id);
                cnt.Text = table.Rows[0]["v_cnt"].ToString();
            }
            catch
            { }
        }

    }
}