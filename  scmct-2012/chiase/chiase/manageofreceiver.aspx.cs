using System;

namespace chiase
{
    public partial class manageofreceiver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                Session["current_link"] = "<a  href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a  href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a  href='manageofreceiver.aspx' title='Nhập kho'>Nhập kho</a>";
            
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
        protected bool IsView
        {
            get
            {
                return PermissionNhapKho.IsView(this);
            }
        }
        protected bool IsAdd
        {
            get
            {
                return PermissionNhapKho.IsAdd(this);
            }
        }
    }
}