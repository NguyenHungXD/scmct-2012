using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chiase
{
    public partial class about : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Session["current"] = "5"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='about.aspx' title='Giới thiệu'>Giới thiệu</a> ";
        }
    }
}