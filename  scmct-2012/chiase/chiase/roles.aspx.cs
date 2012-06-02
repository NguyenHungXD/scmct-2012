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
    public partial class roles : System.Web.UI.Page
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
            try
            {
                string sql = @"select * from help where id=" + Request.QueryString["id"];
                DataTable dt = SQLConnectWeb.GetData(sql);
                lbl_contents.Text = dt.Rows[0]["contents"].ToString();
            }
            catch
            { 
            }
        
        
        
        }
    }
}