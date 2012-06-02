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
    public partial class create_new_group : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));


                if (Request.QueryString["id"] != null)
                {
                    lbl_create_new_group.Visible = functions.checkPrivileges("35", functions.LoginMemID(this), "E");
                    display();
                }
                else
                {
                  lbl_create_new_group.Visible =  functions.checkPrivileges("34", functions.LoginMemID(this), "C");
                }
            }
        }
        public void display()
        {
            try
            {
                string sql = @"select groupid,groupname from ND_TEN_NHOM_ND where groupid =@id";
                DataTable table = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["id"]);
                txt_name.Text = table.Rows[0]["groupname"].ToString();
            }
            catch
            { }


        }
        protected void btn_saves_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_check = @"select groupname from ND_TEN_NHOM_ND where upper(groupname) = upper(@groupname)";
                DataTable table = SQLConnectWeb.GetData(sql_check, "@groupname", txt_name.Text);

                if (table.Rows.Count == 0)
                {

                    if (Request.QueryString["id"] != null)
                    {
                        string sql = @"update ND_TEN_NHOM_ND set groupname=@groupname,edited_by=@edited_by,edited_date=@edited_date where groupid =@id";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                        "@groupname", txt_name.Text,
                        "@edited_by", functions.LoginMemID(this),
                        "@edited_date", functions.GetStringDatetime(),
                        "@id", Request.QueryString["id"]);
                        lbl_error.Text = String.Format("Cập nhật tên nhóm người dùng [<b>{0}</b>] thành công", txt_name.Text);
                    }
                    else
                    {
                        string sql = @"insert into ND_TEN_NHOM_ND (groupname,created_by,created_date,is_active) values(@groupname,@created_by,@created_date,@is_active)";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                        "@groupname", txt_name.Text,
                        "@created_by", functions.LoginMemID(this),
                        "@created_date", functions.GetStringDatetime(),
                        "@is_active", 'Y');
                        lbl_error.Text = String.Format("Lưu nhóm người dùng [<b>{0}</b>] thành công", txt_name.Text);

                    }


                }
                else
                    lbl_error.Text = String.Format("Nhóm người dùng [<b>{0}</b>] đã tồn tại", txt_name.Text);

            }
            catch
            {
                lbl_error.Text = String.Format("Lưu thông tin nhóm người dùng [<b>{0}</b>] không thành công", txt_name.Text);
            }
        }
    }
}