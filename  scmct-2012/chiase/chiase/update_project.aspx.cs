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
    public partial class update_project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                if (Request.QueryString["vmode"] == "lock")
                    lock_project();

                if (Request.QueryString["vmode"] == "del")
                    del_project();
            }
        }
        public void lock_project()
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

                String sql = "UPDATE DA_DU_AN SET ENABLE_BIT=@ENABLE,NGUOI_CAP_NHAT=@NGUOI_CAP_NHAT,NGAY_CAP_NHAT=@NGAY_CAP_NHAT WHERE ID=@ID";
                SQLConnectWeb.ExecuteNonQuery(sql,
                        "@ID", Request.QueryString["id"],
                         "@ENABLE", v_enable,
                        "@NGUOI_CAP_NHAT", functions.LoginMemID(this),
                        "@NGAY_CAP_NHAT", DateTime.Now
                        );
            }
            }catch(Exception ex)
            {}
        }
        public void del_project()
        {
            try
            {
            string v_enable;
            if (Request.QueryString["enable"] == "D")
                v_enable = "Y";
            else
                v_enable = "D";

            String sql = "UPDATE DA_DU_AN SET ENABLE_BIT=@ENABLE,NGUOI_CAP_NHAT=@NGUOI_CAP_NHAT,NGAY_CAP_NHAT=@NGAY_CAP_NHAT WHERE ID=@ID";
            SQLConnectWeb.ExecuteNonQuery(sql,
                    "@ID", Request.QueryString["id"],
                    "@ENABLE", v_enable,
                    "@NGUOI_CAP_NHAT",functions.LoginMemID(this),
                    "@NGAY_CAP_NHAT",DateTime.Now
                    );


            }
            catch (Exception ex)
            { }
        }

    }
}