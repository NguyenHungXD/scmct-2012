using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chiase.Objects;
using DK2C.DataAccess.Web;
using System.Data;
namespace chiase
{
    public partial class join_project : System.Web.UI.Page
    {
        public static DateTime start_date ;
        public static DateTime end_date ;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                display();
            }
            catch
            { }
        }
        public void display()
        {
            try {
                string sql = @"select ma_du_an,ten_du_an,ngay_bat_dau,ngay_ket_thuc from da_du_an where id=@id";
                DataTable dt = SQLConnectWeb.GetData(sql,"@id",Request.QueryString["id"]);
                lbl_ma_du_an.Text = dt.Rows[0]["ma_du_an"].ToString();
                lbl_ten_du_an.Text = dt.Rows[0]["ten_du_an"].ToString();

                 start_date = (DateTime)dt.Rows[0]["ngay_bat_dau"];
                 end_date = (DateTime)dt.Rows[0]["ngay_ket_thuc"];

                lbl_ngay_bat_dau.Text = start_date.ToString("dd/MM/yyyy");
                lbl_ngay_ket_thuc.Text = end_date.ToString("dd/MM/yyyy");
                
                //
                DataTable table = (DataTable)Session["ThanhVien"];
                DateTime joined_date = (DateTime)table.Rows[0]["created_date"];
                lbl_joined_date.Text = joined_date.ToString("dd/MM/yyyy");
                lbl_name.Text = table.Rows[0]["name"].ToString() + "(" + table.Rows[0]["username"].ToString() + ")";
                lbl_Address.Text = table.Rows[0]["address"].ToString();
                lbl_group_name.Text = table.Rows[0]["groupname"].ToString();
            }
            catch
            { }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            try {

                string sql_check_update = @"select a.* from DA_NHAN_SU a where DU_AN_ID=@DU_AN_ID and MEM_ID=@MEM_ID";

                DataTable table_check_update = SQLConnectWeb.GetData(sql_check_update, "@DU_AN_ID", Request.QueryString["id"], "@MEM_ID", functions.LoginMemID(this));
                if (table_check_update.Rows.Count > 0)
                {
                    lbl_error.Text = "Bạn đã có trong danh sách đăng ký tham gia dự án!";
                }
                else
                {
                    String sql = "INSERT INTO DA_NHAN_SU(DU_AN_ID,MEM_ID,START_DATE,END_DATE,ACTIVE,POSITION,ADDED_BY,ADDED_DATE,STATUS) VALUES(@DU_AN_ID,@MEM_ID,@START_DATE,@END_DATE,@ACTIVE,@POSITION,@ADDED_BY,@ADDED_DATE,@STATUS)";
                    int done = SQLConnectWeb.ExecuteNonQuery(sql,
                                                            "@DU_AN_ID", Request.QueryString["id"],
                                                            "@MEM_ID", functions.LoginMemID(this),
                                                            "@START_DATE", functions.CheckDate(start_date.ToString()),
                                                            "@END_DATE", functions.CheckDate(start_date.ToString()),
                                                            "NOTE", ASPxHtmlEditor1.Html.Replace("'", ""),
                                                            "@ACTIVE", "Y",
                                                            "@POSITION", "1",
                                                            "@ADDED_BY", functions.LoginMemID(this),
                                                            "@ADDED_DATE", functions.GetStringDatetime(),
                                                            "@STATUS", 0); // [1 : Approved (Was added by addmin)] | [0 : Wating for approval (Register by members)]
                    lbl_error.Text = "Yêu cầu đã được gửi thành công!";
                }
            }
            catch
            { }
        }
    }
}