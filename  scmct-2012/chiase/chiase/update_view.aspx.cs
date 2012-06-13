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
                //functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this)); //nvdat06/06/2012 : commented-out : View photos no need to login

                updateView();
            }
        }


        public void updateView()
        {
            try
            {
                String sql = "UPDATE IMG_album SET VIEWED=VIEWED+1 WHERE album_ID=@album_ID";
                SQLConnectWeb.ExecuteNonQuery(sql,
                        "@album_ID", Request.QueryString["albumid"]);
            }
            catch
            { 
            
            }
        
        }
    }
}