using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace chiase
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                display();
            
            }
        }
        public void display()
        {
            String sql = "Select title,description from BV_DM_CHU_DE_BV order by sort ";
            DataTable table = Database.GetData(sql);
            show_page.DataSource = table;
            show_page.DataBind(); 
        
        }

    }
}
