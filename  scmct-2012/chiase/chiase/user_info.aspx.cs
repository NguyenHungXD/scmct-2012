using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;
using DK2C.DataAccess.Web;
using System.Drawing;
namespace chiase
{
    public partial class user_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                display();
            }
        }
        public void display()
        {
            try
            {
                string sql;
                if (Request.QueryString["user_name"] != null)
                {
                     sql = string.Format(@"SELECT a.username,a.mem_id,a.created_date created_dates,b.*,c.groupname
                            FROM ND_THONG_TIN_DN a
                            INNER JOIN ND_THONG_TIN_ND b ON a.MEM_ID = b.ID
                            INNER JOIN ND_TEN_NHOM_ND c ON b.MEM_GROUP_ID =c.GROUPID
                            WHERE a.username='{0}'", Request.QueryString["user_name"]);
                }
                else
                {
                    sql = string.Format(@"SELECT a.username,a.mem_id,a.created_date created_dates,b.*,c.groupname
                            FROM ND_THONG_TIN_DN a
                            INNER JOIN ND_THONG_TIN_ND b ON a.MEM_ID = b.ID
                            INNER JOIN ND_TEN_NHOM_ND c ON b.MEM_GROUP_ID =c.GROUPID
                            WHERE a.MEM_ID='{0}'", Request.QueryString["id"]);
                
                }

                DataTable info = SQLConnectWeb.GetTable(sql);

                img_user.ImageUrl= string.Format("images/avatars/{0}",info.Rows[0]["avatar_path"]);
                user_name.Text = info.Rows[0]["username"].ToString();
                lbl_hoten.Text = info.Rows[0]["name"].ToString();
                DateTime bd = (DateTime)info.Rows[0]["birth_day"];
                lbl_ngaysinh.Text = bd.ToString("dd/MM/yyyy");

                DateTime thamgia = (DateTime)info.Rows[0]["created_dates"];
                lbl_thamgia.Text = thamgia.ToString("dd/MM/yyyy");

                lbl_nhom.Text = info.Rows[0]["groupname"].ToString();
                lbl_sum_point.Text = info.Rows[0]["heart"].ToString();
                lbl_email.Text = info.Rows[0]["email"].ToString();
                lbl_diachi.Text = info.Rows[0]["address"].ToString();
                lbl_sodienthoai.Text = info.Rows[0]["phone"].ToString();
                lbl_yahoo.Text = info.Rows[0]["yahoo"].ToString();
                lbl_skype.Text = info.Rows[0]["skype"].ToString();
                lbl_website.Text = info.Rows[0]["website"].ToString();

                sql = @"select count(userid) cnt from ND_LOG_IN_SESSION where sessionid<>'-1' and userid=" + info.Rows[0]["mem_id"].ToString();
                DataTable info_login = SQLConnectWeb.GetTable(sql);
                int cnt = (int)info_login.Rows[0]["cnt"];
                if (cnt > 0)
                {
                    lbl_trangthai.Text = "Online";
                    lbl_trangthai.ForeColor = Color.Blue;
                }
                else
                {
                    lbl_trangthai.Text = "Offline";
                    lbl_trangthai.ForeColor = Color.Black;
                }

                //DateTime truycap = (DateTime)info.Rows[0]["lasted_access"];
                lbl_truycap.Text = functions.getLastedAccess(info.Rows[0]["mem_id"].ToString());

                sql = @"select count(bai_viet_id) cnt from BV_BAI_VIET where bai_viet_cha_id is null and deleted is null and nguoi_tao=" + info.Rows[0]["mem_id"].ToString();
                DataTable info_cnt_bv = SQLConnectWeb.GetTable(sql);
                int cnt_bv = (int)info_cnt_bv.Rows[0]["cnt"];
                lbl_baidang.Text = cnt_bv.ToString();

                sql = @"select count(bai_viet_id) cnt from BV_BAI_VIET where bai_viet_cha_id is not null and deleted is null and nguoi_tao=" + info.Rows[0]["mem_id"].ToString();
                DataTable info_cnt_bl = SQLConnectWeb.GetTable(sql);
                int cnt_bl = (int)info_cnt_bl.Rows[0]["cnt"];
                lbl_bl.Text = cnt_bl.ToString();


                //--------Set point-----------------------------------
                //1point/ bai viet
                //0.1 point/binh luan
                //0.1 pont /like (binh luan,bai viet,hinh anh, album )
                //----------------------------------------------------

                lbl_sum_point.Text = functions.returnPoint(info.Rows[0]["mem_id"].ToString());

            }
            catch (Exception ex)
            {

            }
        
        }
    }
}