using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DK2C.DataAccess.Web;
using System.Data;
namespace chiase
{
    public partial class update_like_post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                update_liked_post();
            }
        }

        public void update_liked_post()
        {
            try
            {
              DataTable nd = (DataTable)Session["ThanhVien"];
              String sql = string.Format(@"SELECT count(*) cnt
                         FROM BV_VOTE a
                        WHERE bai_viet_id={0} and user_id={1}",Request.QueryString["post_id"],nd.Rows[0]["id"]);
            DataTable table = SQLConnectWeb.GetTable(sql);

            int cnt = (int)table.Rows[0]["cnt"];

            if (cnt==0)
            {
                String sql_insert = "insert into bv_vote (bai_viet_id,user_id,mode)values(@bai_viet_id,@user_id,@mode)";
                SQLConnectWeb.ExecuteNonQuery(sql_insert,
                                        "@bai_viet_id", Request.QueryString["post_id"],
                                        "@user_id", nd.Rows[0]["id"],
                                        "@mode", '1');

                String sql_view = "UPDATE BV_BAI_VIET SET LIKED=LIKED+1 WHERE BAI_VIET_ID=@BAI_VIET_ID";
                SQLConnectWeb.ExecuteNonQuery(sql_view,
                        "@BAI_VIET_ID", Request.QueryString["post_id"]);
            }
            }
            catch (Exception ex)
            {

            }
        }
    }
}