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
    public partial class create_new_kind_request : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));


                if (Request.QueryString["id"] != null)
                {
                    lbl_create_kind_request.Visible = functions.checkPrivileges("18", functions.LoginMemID(this), "E");
                    display();
                }
                else
                {
                    lbl_create_kind_request.Visible = functions.checkPrivileges("17", functions.LoginMemID(this), "C");
                }
            }
        }
        public void display()
        {
            try
            {
                string sql = @"select id,ten_loai_yc from YC_DM_LOAI_YEU_CAU where id =@id";
                DataTable table = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["id"]);
                txt_name.Text = table.Rows[0]["ten_loai_yc"].ToString();
            }
            catch
            { }


        }
        protected void btn_saves_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_check = @"select ten_loai_yc from YC_DM_LOAI_YEU_CAU where upper(ten_loai_yc) = upper(@ten_loai_yc)";
                DataTable table = SQLConnectWeb.GetData(sql_check, "@ten_loai_yc", txt_name.Text);

                if (table.Rows.Count == 0)
                {

                    if (Request.QueryString["id"] != null)
                    {
                        string sql = @"update YC_DM_LOAI_YEU_CAU set ten_loai_yc=@ten_loai_yc,nguoi_cap_nhat=@nguoi_cap_nhat,ngay_cap_nhat=@ngay_cap_nhat where id =@id";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                        "@ten_loai_yc", txt_name.Text,
                        "@nguoi_cap_nhat", functions.LoginMemID(this),
                        "@ngay_cap_nhat", functions.GetStringDatetime(),
                        "@id", Request.QueryString["id"]);
                        lbl_error.Text = String.Format("Cập nhật loại yêu cầu [<b>{0}</b>] thành công", txt_name.Text);
                    }
                    else
                    {
                        string sql = @"insert into YC_DM_LOAI_YEU_CAU (ten_loai_yc,nguoi_tao,ngay_tao,ENABLE_BIT) values(@ten_loai_yc,@nguoi_tao,@ngay_tao,@ENABLE_BIT)";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                        "@ten_loai_yc", txt_name.Text,
                        "@nguoi_tao", functions.LoginMemID(this),
                        "@ngay_tao", functions.GetStringDatetime(),
                        "@ENABLE_BIT", 'Y');
                        lbl_error.Text = String.Format("Lưu loại yêu cầu [<b>{0}</b>] thành công", txt_name.Text);

                    }


                }
                else
                    lbl_error.Text = String.Format("Loại yêu cầu [<b>{0}</b>] đã tồn tại", txt_name.Text);

            }
            catch
            {
                lbl_error.Text = String.Format("Lưu loại yêu cầu [<b>{0}</b>] không thành công", txt_name.Text);
            }
        }
    }
}