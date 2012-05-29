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
    public partial class project_detail_popup : System.Web.UI.Page
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


                String sql = @"select a.*,b.name 
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID Where a.id=@v_id ";

                DataTable table = SQLConnectWeb.GetData(sql, "@v_id", Request.QueryString["id"]);

                if (table.Rows.Count > 0)
                {
                    lbl_tenduan.Text = (String)table.Rows[0]["TEN_DU_AN"];
                    lbl_maduan.Text = (String)table.Rows[0]["MA_DU_AN"];
                    Int64 book = (Int64)table.Rows[0]["BOOK"];
                    lbl_book.Text = book.ToString();
                    lbl_ghichu.Text = (String)table.Rows[0]["GHI_CHU"];
                    lbl_chitiet.Text = (String)table.Rows[0]["CHI_TIET"];
                    lbl_trangthai.Text = (String)table.Rows[0]["NAME"];
                    DateTime start_date = (DateTime)table.Rows[0]["ngay_bat_dau"];
                    DateTime end_date = (DateTime)table.Rows[0]["ngay_ket_thuc"];
                    lbl_batdau.Text = start_date.ToString("dd/MM/yyyy");
                    lbl_ketthuc.Text = end_date.ToString("dd/MM/yyyy");
                }
            }
            catch
            {
            }
        }
    }
}
