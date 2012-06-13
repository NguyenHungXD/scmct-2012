using System;
using System.Web.UI;
namespace chiase
{
    public partial class receiver : System.Web.UI.Page
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
                return PermissionNhapKho.IsEdit(this);
            }
        }
        protected bool IsAdd
        {
            get
            {
                return PermissionNhapKho.IsAdd(this);
            }
        }
        protected bool IsDelete
        {
            get
            {

                return PermissionNhapKho.IsDelete(this);
            }
        }

    }
}