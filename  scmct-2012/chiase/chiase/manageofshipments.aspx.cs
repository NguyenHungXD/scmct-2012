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
using System.Threading;

namespace chiase
{
    public partial class manageofshipments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                Session["current_link"] = "<a  href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a  href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a  href='manageofshipments.aspx' title='Xuất kho'>Xuất kho</a>";

            }

        }
        protected string GetCaption(string dictionaryID)
        {
            return functions.GetValueLanguage(dictionaryID);
        }
        protected bool IsView
        {
            get
            {
                return PermissionXuatKho.IsView(this);
            }
        }
        protected bool IsAdd
        {
            get
            {
                return PermissionXuatKho.IsAdd(this);
            }
        }

    }
}