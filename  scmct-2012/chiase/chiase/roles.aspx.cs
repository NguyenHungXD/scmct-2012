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
                if (Request.QueryString["id"] == "1") { //Gioi thieu
                    Session["current"] = "5"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='roles.aspx?id=1' title='Giới thiệu'>Giới thiệu</a> ";
                }
                else if (Request.QueryString["id"] == "2") //tro giup
                {
                    Session["current"] = "8"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='roles.aspx?id=2' title='Trợ giúp'>Trợ giúp</a> ";
                }
                else if (Request.QueryString["id"] == "4") //lien he
                {
                    Session["current"] = "6"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='roles.aspx?id=4' title='Liên hệ'>Liên hệ</a> ";
                }
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