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
using chiase.Objects;
using DK2C.DataAccess.Web;

namespace chiase
{
    public partial class CategoryGroupItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            datasouce1.ConnectionString = SQLConnectWeb.GetConnectionString();
            if (!IsPostBack)
            {
               
                Page.DataBind();
               
            }
           // LoadTree();
        }
        protected string GetCaption(string dictionaryID)
        {
            return DictionaryDB.sGetValueLanguage(dictionaryID);


        }
        protected void LoadTree()
        {
            DataTable dt = DM_HANG_HOA_NHOM.GetTableAll();
            treeList.DataSource = dt;
            treeList.DataBind();
        }
    }
}

