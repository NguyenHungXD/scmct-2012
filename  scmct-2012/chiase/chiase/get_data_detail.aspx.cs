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
    public partial class get_data_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                pull_data_news();
            }
        }
        public void pull_data_news()
        {
            try
            {
                String sql = string.Format(@"select bai_viet_id,tieu_de,SUBSTRING(noi_dung,1,100) as noi_dung from bv_bai_viet where bai_viet_id={0}", Request.QueryString["post_id"]);
                DataTable table = SQLConnectWeb.GetTable(sql);

                HttpContext.Current.Response.Write(String.Format("[start1]{0}[endstart1][start2]{1}[endstart2] ", table.Rows[0]["tieu_de"], table.Rows[0]["noi_dung"]));

            }
            catch
            {

            }

        }
    }
}