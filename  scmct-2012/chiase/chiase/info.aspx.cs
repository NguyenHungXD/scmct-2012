using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using chiase.Objects;
using DK2C.DataAccess.Web;

namespace chiase
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      
                resetColor();
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                if (!IsPostBack)
                {
                    Boolean check = false;
                    if (functions.checkPrivileges("45", functions.LoginMemID(this), "E"))
                    {
                        check = true;
                    }

                    Button1.Visible = check;
                    Button5.Visible = check;
                    Button6.Visible = check;
                    Button7.Visible = check;

                    display();
                }
        }
        public void display()
        {
            MultiView1.ActiveViewIndex = 0;
            Button2.BackColor = Color.Yellow;
            Button2.ForeColor = Color.Blue;
            try
            {
                string sql = @"select * from help where id=1";
                DataTable dt = SQLConnectWeb.GetData(sql);
                ASPxHtmlEditor1.Html = dt.Rows[0]["contents"].ToString();
            }
            catch
            {
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            Button2.BackColor = Color.Yellow;
            Button2.ForeColor = Color.Blue;


            //
            try
            {
                string sql = @"select * from help where id=1";
                DataTable dt = SQLConnectWeb.GetData(sql);
                ASPxHtmlEditor1.Html = dt.Rows[0]["contents"].ToString();
            }
            catch
            { 
            }

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            Button8.BackColor = Color.Yellow;
            Button8.ForeColor = Color.Blue;
            //
            try
            {
                string sql = @"select * from help where id=4";
                DataTable dt = SQLConnectWeb.GetData(sql);
                ASPxHtmlEditor2.Html = dt.Rows[0]["contents"].ToString();
            }
            catch
            {
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            Button3.BackColor = Color.Yellow;
            Button3.ForeColor = Color.Blue;
            //
            try
            {
                string sql = @"select * from help where id=2";
                DataTable dt = SQLConnectWeb.GetData(sql);
                ASPxHtmlEditor2.Html = dt.Rows[0]["contents"].ToString();
            }
            catch
            {
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            Button4.BackColor = Color.Yellow;
            Button4.ForeColor = Color.Blue;

            //
            try
            {
                string sql = @"select * from help where id=3";
                DataTable dt = SQLConnectWeb.GetData(sql);
                ASPxHtmlEditor3.Html = dt.Rows[0]["contents"].ToString();
            }
            catch
            {
            }

        }
        public void resetColor()
        {
            Button2.BackColor = Color.Blue;
            Button2.ForeColor = Color.White;
            Button3.BackColor = Color.Blue;
            Button3.ForeColor = Color.White;
            Button4.BackColor = Color.Blue;
            Button4.ForeColor = Color.White;
            Button8.BackColor = Color.Blue;
            Button8.ForeColor = Color.White;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 0;
                Button2.BackColor = Color.Yellow;
                Button2.ForeColor = Color.Blue;

                string sql = @"update help set contents=@contents,edited_by=@edited_by,edited_date=@edited_date where id=1";
                SQLConnectWeb.ExecuteNonQuery(sql,
                                                "@contents", ASPxHtmlEditor1.Html.Replace("'", ""),
                                                "@edited_by", functions.LoginMemID(this),
                                                "@edited_date",functions.GetStringDatetime());
                lbl_error.Text = "Cập nhật nội dung giới thiệu thành công";
            }
            catch
            { }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {


                MultiView1.ActiveViewIndex = 1;
                Button3.BackColor = Color.Yellow;
                Button3.ForeColor = Color.Blue;

                string sql = @"update help set contents=@contents,edited_by=@edited_by,edited_date=@edited_date where id=2";
                SQLConnectWeb.ExecuteNonQuery(sql,
                                                "@contents", ASPxHtmlEditor2.Html.Replace("'", ""),
                                                "@edited_by", functions.LoginMemID(this),
                                                "@edited_date", functions.GetStringDatetime());
                lbl_error.Text = "Cập nhật nội dung trợ giúp thành công";
            }
            catch
            { }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {


                MultiView1.ActiveViewIndex = 2;
                Button4.BackColor = Color.Yellow;
                Button4.ForeColor = Color.Blue;

                string sql = @"update help set contents=@contents,edited_by=@edited_by,edited_date=@edited_date where id=3";
                SQLConnectWeb.ExecuteNonQuery(sql,
                                                "@contents", ASPxHtmlEditor3.Html.Replace("'", ""),
                                                "@edited_by", functions.LoginMemID(this),
                                                "@edited_date", functions.GetStringDatetime());
                lbl_error.Text = "Cập nhật nội dung điều khoản thành công";
            }
            catch
            {
                lbl_error.Text = "Cập nhật nội dung không thành công";
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 4;
                Button8.BackColor = Color.Yellow;
                Button8.ForeColor = Color.Blue;

                string sql = @"update help set contents=@contents,edited_by=@edited_by,edited_date=@edited_date where id=4";
                SQLConnectWeb.ExecuteNonQuery(sql,
                                                "@contents", ASPxHtmlEditor4.Html.Replace("'", ""),
                                                "@edited_by", functions.LoginMemID(this),
                                                "@edited_date", functions.GetStringDatetime());
                lbl_error.Text = "Cập nhật nội dung thông tin liên hệ thành công";
            }
            catch
            {
                lbl_error.Text = "Cập nhật nội dung không thành công";
            }
        }


    }
}