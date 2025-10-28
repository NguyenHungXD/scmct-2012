using System;

namespace chiase
{
    public partial class quiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["current"] = "11";
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='quiz.aspx' title='Thi trắc nghiệm'>Thi trắc nghiệm</a> ";
            }
        }
    }
}
