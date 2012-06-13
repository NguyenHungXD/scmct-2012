using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace chiase
{
    public partial class shipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

            }
        }
        protected string GetCaption(string dictionaryID)
        {
            return functions.GetValueLanguage(dictionaryID);
        }
        protected string GetLoginID()
        {
            return functions.LoginMemID(this);
        }
        protected string GetLoginFullName()
        {
            return functions.LoginMemFullName(this);
        }
        protected bool IsEdit
        {
            get
            {

                return PermissionXuatKho.IsEdit(this);
            }
        }
        protected bool IsAdd
        {
            get
            {
                return PermissionXuatKho.IsAdd(this);
            }
        }
        protected bool IsDelete
        {
            get
            {

                return PermissionXuatKho.IsDelete(this);
            }
        }
    }
}