using System;
using System.Data;
using System.Web.UI;
using chiase.Objects;
using DK2C.DataAccess.Web;

namespace chiase
{
    public partial class Catagorygroupitems : System.Web.UI.Page
    {
        public static string del_right = "False";
        protected void Page_Load(object sender, EventArgs e)
        {
            datasouce1.ConnectionString = SQLConnectWeb.GetConnectionString();
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                treeList.Visible = functions.checkPrivileges("55", functions.LoginMemID(this), "V");
                treeList.VisibleColumns[2].Visible = functions.checkPrivileges("55", functions.LoginMemID(this), "D");
                if(functions.checkPrivileges("55", functions.LoginMemID(this), "E") || functions.checkPrivileges("55", functions.LoginMemID(this), "C"))//Combain editing and creating right.
                    treeList.VisibleColumns[1].Visible =  true;
                else
                    treeList.VisibleColumns[1].Visible =  false;
                Page.DataBind();
                Session["current_link"] = "<a  href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a  href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a  href='categorygroupitems.aspx' title='Danh mục chủng loại'>Danh mục chủng loại</a>";
            }
            // LoadTree();
        }
        protected static string GetCaption(string dictionaryID)
        {
            return functions.GetValueLanguage(dictionaryID);
        }
        protected void LoadTree()
        {
            DataTable dt = DM_HANG_HOA_NHOM.GetTableAll();
            treeList.DataSource = dt;
            treeList.DataBind();
        }
    }
}