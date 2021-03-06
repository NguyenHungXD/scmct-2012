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
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                if (Request.QueryString["mode"] == "2")
                    update_liked_project();
                else if (Request.QueryString["mode"] == "3")
                    update_liked_img();
                else if (Request.QueryString["mode"] == "4")
                    update_liked_album();
                else if (Request.QueryString["mode"] == "5")
                    update_liked_album_comment();
                else
                    update_liked_post();
            }
        }

        public void update_liked_album_comment()
        {
            try
            {
                DataTable nd = (DataTable)Session["ThanhVien"];
                String sql = string.Format(@"SELECT count(*) cnt
                         FROM BV_VOTE a
                        WHERE bai_viet_id={0} and user_id={1} and mode=5", Request.QueryString["comment_id"], nd.Rows[0]["id"]);
                DataTable table = SQLConnectWeb.GetTable(sql);

                int cnt = (int)table.Rows[0]["cnt"];

                if (cnt == 0)
                {
                    String sql_insert = "insert into bv_vote (bai_viet_id,user_id,mode)values(@comment_id,@user_id,@mode)";
                    SQLConnectWeb.ExecuteNonQuery(sql_insert,
                                            "@comment_id", Request.QueryString["comment_id"],
                                            "@user_id", nd.Rows[0]["id"],
                                            "@mode", '5');

                    String sql_view = "UPDATE IMG_album_COMMENT SET LIKED=LIKED+1 WHERE id=@comment_id";
                    SQLConnectWeb.ExecuteNonQuery(sql_view,
                            "@comment_id", Request.QueryString["comment_id"]);

                }
            }
            catch (Exception ex)
            {
            }

        }


        public void update_liked_img()
        {
            try
            {
                DataTable nd = (DataTable)Session["ThanhVien"];
                String sql = string.Format(@"SELECT count(*) cnt
                         FROM BV_VOTE a
                        WHERE bai_viet_id={0} and user_id={1} and mode=3", Request.QueryString["img_id"], nd.Rows[0]["id"]);
                DataTable table = SQLConnectWeb.GetTable(sql);

                int cnt = (int)table.Rows[0]["cnt"];

                if (cnt == 0)
                {
                    String sql_insert = "insert into bv_vote (bai_viet_id,user_id,mode)values(@img_id,@user_id,@mode)";
                    SQLConnectWeb.ExecuteNonQuery(sql_insert,
                                            "@img_id", Request.QueryString["img_id"],
                                            "@user_id", nd.Rows[0]["id"],
                                            "@mode", '3');

                    String sql_view = "UPDATE IMG_album_DETAIL SET LIKED=LIKED+1 WHERE img_id=@img_id";
                    SQLConnectWeb.ExecuteNonQuery(sql_view,
                            "@img_id", Request.QueryString["img_id"]);
                   
                }
            }
            catch (Exception ex)
            {
            }

        }
        public void update_liked_album()
        {
            try
            {
                DataTable nd = (DataTable)Session["ThanhVien"];
                String sql = string.Format(@"SELECT count(*) cnt
                         FROM BV_VOTE a
                        WHERE bai_viet_id={0} and user_id={1} and mode=4", Request.QueryString["album_id"], nd.Rows[0]["id"]);
                DataTable table = SQLConnectWeb.GetTable(sql);

                int cnt = (int)table.Rows[0]["cnt"];

                if (cnt == 0)
                {
                    String sql_insert = "insert into bv_vote (bai_viet_id,user_id,mode)values(@album_id,@user_id,@mode)";
                    SQLConnectWeb.ExecuteNonQuery(sql_insert,
                                            "@album_id", Request.QueryString["album_id"],
                                            "@user_id", nd.Rows[0]["id"],
                                            "@mode", '4');

                    String sql_view = "UPDATE IMG_album SET LIKED=LIKED+1 WHERE album_ID=@album_ID";
                    SQLConnectWeb.ExecuteNonQuery(sql_view,
                            "@album_ID", Request.QueryString["album_id"]);
                }
            }
            catch (Exception ex)
            {
            }


        }
        public void update_liked_project()
        {
            try
            {
              DataTable nd = (DataTable)Session["ThanhVien"];
              String sql = string.Format(@"SELECT count(*) cnt
                         FROM BV_VOTE a
                        WHERE bai_viet_id={0} and user_id={1} and mode=2", Request.QueryString["project_id"], nd.Rows[0]["id"]);
            DataTable table = SQLConnectWeb.GetTable(sql);

            int cnt = (int)table.Rows[0]["cnt"];

            if (cnt==0)
            {
                String sql_insert = "insert into bv_vote (bai_viet_id,user_id,mode)values(@project_id,@user_id,@mode)";
                SQLConnectWeb.ExecuteNonQuery(sql_insert,
                                        "@project_id", Request.QueryString["project_id"],
                                        "@user_id", nd.Rows[0]["id"],
                                        "@mode", '2');

                String sql_view = "UPDATE DA_DU_AN SET LIKED=LIKED+1 WHERE ID=@project_id";
                SQLConnectWeb.ExecuteNonQuery(sql_view,
                        "@project_id", Request.QueryString["project_id"]);
            }
            }
            catch (Exception ex)
            {
            }
        
        
        }

        public void update_liked_post()
        {
            try
            {
              DataTable nd = (DataTable)Session["ThanhVien"];
              String sql = string.Format(@"SELECT count(*) cnt
                         FROM BV_VOTE a
                        WHERE bai_viet_id={0} and user_id={1} and mode=1", Request.QueryString["post_id"], nd.Rows[0]["id"]);
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