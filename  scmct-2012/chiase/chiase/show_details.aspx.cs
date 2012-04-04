using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chiase.Objects;
using System.Data;
using DK2C.DataAccess.Web;
namespace chiase
{
    public partial class show_details : System.Web.UI.Page
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


//            String sql = string.Format(@"SELECT a.*,b.USERNAME
//                         FROM BV_BAI_VIET a
//                        INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID
//                        WHERE CHU_DE_ID={0}", id);

        }
    }
}