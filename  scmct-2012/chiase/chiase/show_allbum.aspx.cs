using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chiase
{
    public partial class show_allbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_created_new_allbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("upload.aspx");
        }
    }
}