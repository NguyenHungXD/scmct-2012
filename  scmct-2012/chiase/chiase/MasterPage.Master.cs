using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DK2C.DataAccess.Web;
using chiase.Objects;

namespace chiase
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    pn_admin.Visible = false;
                    this.Display();
                    txt_search.Text = (string)Session["str_search"];
                }
            }
            catch
            { }
        }

        void Display()
        {
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                MultiView1.ActiveViewIndex = (table == null) ? 0 : 1;
                if (table != null)
                {
                    lbl_username.Text = (String)table.Rows[0][ND_THONG_TIN_DN.cl_USERNAME];

                    object obj = table.Rows[0][ND_THONG_TIN_DN.cl_LASTED_ACCESS];
                    if (obj != null && obj != DBNull.Value)
                    {
                        DateTime lasted_access = (DateTime)obj;
                        lbl_lasted_access.Text = lasted_access.ToString("dd/MM/yyyy hh:mm:ss tt");
                    }
                    else lbl_lasted_access.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    String avatar_name = Convert.IsDBNull(table.Rows[0][ND_THONG_TIN_ND.cl_AVATAR_PATH]) ? "default_img.gif" : (String)table.Rows[0][ND_THONG_TIN_ND.cl_AVATAR_PATH];
                    imgUser.ImageUrl = "Images/avatars/" + avatar_name;
                    link_member_page.NavigateUrl = "my_page.aspx?id=" + table.Rows[0]["id"];
                    pn_admin.Visible = functions.checkPrivileges("1", table.Rows[0]["id"].ToString(),"V");
                }
            }
            catch
            { }
        }


        protected void logout_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                string sql = @"update ND_LOG_IN_SESSION set sessionid=-1 where userid = @id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", table.Rows[0]["mem_id"]);
                Session.Remove("ThanhVien");

                Response.Redirect("Default.aspx");
            }
            catch
            { }
        }

        protected void btn_login_Click1(object sender, EventArgs e)
        {
            try
            {
                bool ok = false;
                //            String sql = string.Format(@"SELECT a.userid,a.username,a.lasted_access,a.created_date,b.*,c.* 
                //                         FROM ND_THONG_TIN_DN a
                //                        INNER JOIN  ND_THONG_TIN_ND b ON  a.MEM_ID=b.ID
                //                        INNER JOIN ND_TEN_NHOM_ND c ON  b.MEM_GROUP_ID = c.GROUPID
                //                        WHERE username=N'{0}'", txtUserID.Text);
                String sql = @"SELECT a.userid,a.username,a.lasted_access,a.created_date,a.mem_id,b.*,c.* 
                                     FROM ND_THONG_TIN_DN a
                                    INNER JOIN  ND_THONG_TIN_ND b ON  a.MEM_ID=b.ID
                                    INNER JOIN ND_TEN_NHOM_ND c ON  b.MEM_GROUP_ID = c.GROUPID
                                    WHERE username=@username and pwd=@pwd";

                DataTable table = SQLConnectWeb.GetData(sql, "@username", txtUserID.Text, "@pwd", txtPassWord.Text);

                if (table.Rows.Count > 0)
                {
                    //if (table.Rows[0][ND_THONG_TIN_DN.cl_PWD].ToString().Equals(txtPassWord.Text))
                    //{

                    //capture the session
                    string v_sessionid = functions.randomstring(17) + functions.randomstring(17);
                    string access_date = functions.GetStringDatetime();
                    string ipaddress = functions.getIPAddress();
                    //
                    string sql_remove_sessionid = @"update ND_LOG_IN_SESSION set sessionid=-1 where userid = @id";
                    SQLConnectWeb.ExecuteNonQuery(sql_remove_sessionid, "@id", table.Rows[0]["id"]);
                    //
                    string sql_session = @"insert into ND_LOG_IN_SESSION(userid,sessionid,access_date,ipaddress,fullname,username,groupid) values (@userid,@sessionid,@access_date,@ipaddress,@fullname,@username,@groupid)";
                    SQLConnectWeb.ExecuteNonQuery(sql_session, "@userid", table.Rows[0]["id"], "@sessionid", v_sessionid, "@access_date", access_date, "@ipaddress", ipaddress, "@fullname", table.Rows[0]["name"], "@username", table.Rows[0]["username"], "@groupid", table.Rows[0]["groupid"]);



                    DataColumn col;
                    col = new DataColumn("sessionid", System.Type.GetType(" System.String"));
                    table.Columns.Add(col);
                    table.Rows[0]["sessionid"] = v_sessionid;
                    col = new DataColumn("ipaddress", System.Type.GetType(" System.String"));
                    table.Columns.Add(col);
                    table.Rows[0]["ipaddress"] = ipaddress;

                    Session["ThanhVien"] = table;
                    link_member_page.NavigateUrl = "my_page.aspx?id=" + table.Rows[0]["id"];
                    //lblError.Text = "Dang nhap thanh cong !";
                    this.Display();
                    

                    
                    ok = true;
                    Response.Redirect("Default.aspx");
                    //}
                    
                }
                if (ok == false)
                {
                    lblError.Text = "Tên đăng nhập hoặc mật khẩu không hợp lệ!";
                }
            }
            catch
            { }
           
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["search_news"] == "" || Session["search_news"] == null)
                {
                    Session["search_news"] = "checked";
                    Session["search_all"] = "unchecked";
                    Session["search_request"] = "unchecked";
                    Session["search_album"] = "unchecked";
                }
                Session["str_search"] = txt_search.Text;
                string url = "search_result.aspx?str_search=" + txt_search.Text;
                Response.Redirect(url);
               
            }
            catch
            { 
            }
        }

 

        

   
    }
}