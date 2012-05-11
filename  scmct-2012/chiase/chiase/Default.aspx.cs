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
    public partial class _Default : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               display();
               globalVariable.vSelected = "2";
            }
        }

        public void display()
        {
            try
            {
                String sql = @"select a.*,b.name 
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID";
                DataTable table = SQLConnectWeb.GetData(sql);

                showListProject.DataSource = table;
                showListProject.DataBind();

                //Vote 10 like = 1 star, 50 like= 2 star , 100 like= 3 star, 300 like = 4 star 500 like = 5 star


            }
            catch (Exception ex)
            {
            }
        
        
        }
     


    }
}
