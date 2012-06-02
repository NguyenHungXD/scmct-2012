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
    public partial class view_reuqest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                display();
            }
        }
        public void display()
        {
            try
            {
                string sql = @"select a.*,b.name,c.ten_loai_yc,d.name as requested_by,e.username
                                        from yc_yeu_cau a 
                                        inner join YC_DM_TRANG_THAI_YEU_CAU b on a.trang_thai_id = b.id
                                        inner join YC_DM_LOAI_YEU_CAU c on a.loai_yc_id = c.id
                                        left outer join ND_THONG_TIN_ND d on d.id = a.nguoi_yeu_cau
										left outer join ND_THONG_TIN_DN e on e.mem_id = a.nguoi_yeu_cau
                                        where a.yeu_cau_id = @yeu_cau_id";

                using (DataTable table_request = SQLConnectWeb.GetData(sql, "@yeu_cau_id", Request.QueryString["id"]))
                {
                    lbl_title.Text = table_request.Rows[0]["tieu_de"].ToString();
                    lbl_content.Text = table_request.Rows[0]["noi_dung"].ToString();
                    lbl_kind_request.Text = table_request.Rows[0]["ten_loai_yc"].ToString();
                    lbl_status.Text = table_request.Rows[0]["name"].ToString();
                    lbl_requested_by.Text = table_request.Rows[0]["requested_by"].ToString() + "(" + table_request.Rows[0]["username"].ToString() + ")";
                    DateTime created_date = (DateTime)table_request.Rows[0]["ngay_yeu_cau"];
                    lbl_requested_date.Text = created_date.ToString("dd/MM/yyyy hh:mm:ss tt");
                }

            }
            catch
            { 
            }
        
        }
    }
}