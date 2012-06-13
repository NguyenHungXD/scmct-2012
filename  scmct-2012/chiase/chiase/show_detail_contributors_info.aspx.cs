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
    public partial class show_detail_contributors_info : System.Web.UI.Page
    {
        public static int no;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    no = 1;
                    display();
                    Session["current_link"] = String.Format("<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='show_detail_contributors_info.aspx?id={0}'title='Chi tiết đóng góp'>Chi tiết đóng góp</a> ", Request.QueryString["id"]);
                }

            }
            catch
            {
            }
        }
        public void display()
        {
            try
            {
                string sql_da = @"select ma_du_an,ten_du_an from da_du_an where id=" + Request.QueryString["id"];
                DataTable dt = SQLConnectWeb.GetData(sql_da);
                lbl_ma_du_an.Text = dt.Rows[0]["ma_du_an"].ToString();
                lbl_ten_du_an.Text = dt.Rows[0]["ten_du_an"].ToString();

                string sql_nguoi = @"select name from ND_THONG_TIN_ND where id=" + Request.QueryString["userid"];
                DataTable nguoi_qg = SQLConnectWeb.GetData(sql_nguoi);
                lbl_hoten.Text = nguoi_qg.Rows[0]["name"].ToString();


                string sql = String.Format(@"exec SP_DS_NGUOI_QUYEN_GOP_CT {0},{1}", Request.QueryString["id"], Request.QueryString["userid"]);
                DataTable table = SQLConnectWeb.GetData(sql);
                contributor_lists_detail.DataSource = table;
                contributor_lists_detail.DataBind();
                sums.Text = table.Compute("sum(so_luong)",null).ToString();
            }
            catch (Exception ex)
            {
                //lbl_error.Text = ex.ToString();
            }

        }
    }
}