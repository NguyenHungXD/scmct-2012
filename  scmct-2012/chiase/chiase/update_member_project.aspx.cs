using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using DK2C.DataAccess.Web;
using System.Data;

namespace chiase
{
    public partial class update_member_project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["vmode"] == "lock")
                lock_member_project();

            if (Request.QueryString["vmode"] == "del")
                del_member_project();

            if (Request.QueryString["vmode"] == "approve")
                approve_member_project();
        }

        public void approve_member_project()
        {
            try
            {
                    String sql = "UPDATE DA_NHAN_SU SET status=1,EDITED_BY=@EDITED_BY,EDITED_DATE=@EDITED_DATE WHERE ID=@ID";
                    SQLConnectWeb.ExecuteNonQuery(sql,
                            "@ID", Request.QueryString["id"],
                            "@EDITED_BY", functions.LoginMemID(this),
                            "@EDITED_DATE", DateTime.Now
                            );
                }
            catch (Exception ex)
            {
            }
        }

        public void lock_member_project()
        {
            try
            {

            if (Request.QueryString["enable"] != "D")
            {
                string v_enable="Y";
                if (Request.QueryString["enable"] == "Y")
                    v_enable = "N";
                if (Request.QueryString["enable"] == "N")
                    v_enable = "Y";

                String sql = "UPDATE DA_NHAN_SU SET ACTIVE=@ACTIVE,EDITED_BY=@EDITED_BY,EDITED_DATE=@EDITED_DATE WHERE ID=@ID";
                SQLConnectWeb.ExecuteNonQuery(sql,
                        "@ID", Request.QueryString["id"],
                         "@ACTIVE", v_enable,
                        "@EDITED_BY", functions.LoginMemID(this),
                        "@EDITED_DATE", DateTime.Now
                        );
            }
            }
            
            catch(Exception ex)
            {
            
            }
        }
        public void del_member_project()
        {
            try
            {
            string v_enable;
            if (Request.QueryString["enable"] == "D")
                v_enable = "Y";
            else
                v_enable = "D";

            String sql = "UPDATE DA_NHAN_SU SET ACTIVE=@ACTIVE,EDITED_BY=@EDITED_BY,EDITED_DATE=@EDITED_DATE WHERE ID=@ID";
            SQLConnectWeb.ExecuteNonQuery(sql,
                    "@ID", Request.QueryString["id"],
                    "@ACTIVE", v_enable,
                    "@EDITED_BY",functions.LoginMemID(this),
                    "@EDITED_DATE",DateTime.Now
                    );

            }catch(Exception ex)
            {}
        }
    }

    }
