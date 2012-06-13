using System;
using System.Web.UI;

namespace chiase
{
    public partial class categoryWarehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                Page.DataBind();

                Session["current_link"] = "<a  href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a  href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a  href='categorywarehouse.aspx' title='Danh mục kho'>Danh mục kho</a>";
                Session["current_link"] = "<a  href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a  href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a  href='manageofreceiver.aspx' title='Nhập kho'>Nhập kho</a>";
             
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
                return PermissionDMKho.IsView(this);
            }
        }
        protected bool IsAdd
        {
            get
            {
                return PermissionDMKho.IsAdd(this);
            }
        }
        protected bool IsEdit
        {
            get
            {
                return PermissionDMKho.IsEdit(this);
            }
        }

    }
}


