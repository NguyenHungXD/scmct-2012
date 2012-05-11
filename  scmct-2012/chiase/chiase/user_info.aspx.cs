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
    public partial class user_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                display();
        }
        public void display()
        {
            try
            {
                String sql = string.Format(@"SELECT a.username,b.*,c.groupname
                            FROM ND_THONG_TIN_DN a
                            INNER JOIN ND_THONG_TIN_ND b ON a.MEM_ID = b.ID
                            INNER JOIN ND_TEN_NHOM_ND c ON b.MEM_GROUP_ID =c.GROUPID
                            WHERE a.username='{0}'", Request.QueryString["user_name"]);
                DataTable info = SQLConnectWeb.GetTable(sql);

                img_user.ImageUrl= string.Format("images/avatars/{0}",info.Rows[0]["avatar_path"]);
                user_name.Text = info.Rows[0]["username"].ToString();
                lbl_hoten.Text = info.Rows[0]["name"].ToString();
                DateTime bd = (DateTime)info.Rows[0]["birth_day"];
                lbl_ngaysinh.Text = bd.ToString("dd/MM/yyyy");

                DateTime thamgia = (DateTime)info.Rows[0]["created_date"];
                lbl_thamgia.Text = thamgia.ToString("dd/MM/yyyy");

                lbl_nhom.Text = info.Rows[0]["groupname"].ToString();
                lbl_sum_point.Text = info.Rows[0]["heart"].ToString();
                lbl_email.Text = info.Rows[0]["email"].ToString();
                lbl_diachi.Text = info.Rows[0]["address"].ToString();
                lbl_sodienthoai.Text = info.Rows[0]["phone"].ToString();
                lbl_yahoo.Text = info.Rows[0]["yahoo"].ToString();
                lbl_skype.Text = info.Rows[0]["skype"].ToString();
                lbl_website.Text = info.Rows[0]["website"].ToString();

                DateTime truycap = (DateTime)info.Rows[0]["lasted_access"];
                lbl_truycap.Text = truycap.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {

            }
        
        }
    }
}