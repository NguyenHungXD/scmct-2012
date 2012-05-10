using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chiase
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["do"];
            switch (action)
            {
                //Dang ky thang nam lam viec
                case "LuuPhieuNhapKho": LuuPhieuNhapKho(); break;
                    

            }
        }
        private void LuuPhieuNhapKho()
        {
            string a = Request.QueryString["IDPhieuNhapKho"];
            if (a == null) a = "KH";
            Response.Write(a);
        }
    }
}