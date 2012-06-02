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
    public partial class update_view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                updateView();
            }
        }


        public void updateView()
        {
            try
            {
                String sql = "UPDATE IMG_ALLBUM SET VIEWED=VIEWED+1 WHERE ALLBUM_ID=@ALLBUM_ID";
                SQLConnectWeb.ExecuteNonQuery(sql,
                        "@ALLBUM_ID", Request.QueryString["allbumid"]);
            }
            catch
            { 
            
            }
        
        }
    }
}