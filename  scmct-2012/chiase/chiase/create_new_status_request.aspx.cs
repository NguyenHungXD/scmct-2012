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
    public partial class create_new_status_request : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                if (Request.QueryString["id"] != null)
                {
                    lbl_create_new_status_request.Visible = functions.checkPrivileges("16", functions.LoginMemID(this), "E");
                    display();
                }
                else
                {
                    lbl_create_new_status_request.Visible = functions.checkPrivileges("15", functions.LoginMemID(this), "C");
                }
            }
        }
        public void display()
        {
            try
            {
                string sql = @"select id,name from YC_DM_TRANG_THAI_YEU_CAU where id =@id";
                DataTable table = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["id"]);
                txt_name.Text = table.Rows[0]["name"].ToString();
            }
            catch
            { }


        }
        protected void btn_saves_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_check = @"select name from YC_DM_TRANG_THAI_YEU_CAU where upper(name) = upper(@name)";
                DataTable table = SQLConnectWeb.GetData(sql_check, "@name", txt_name.Text);

                if (table.Rows.Count == 0)
                {

                    if (Request.QueryString["id"] != null)
                    {
                        string sql = @"update YC_DM_TRANG_THAI_YEU_CAU set name=@name,edited_by=@edited_by,edited_date=@edited_date where id =@id";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                        "@name", txt_name.Text,
                        "@edited_by", functions.LoginMemID(this),
                        "@edited_date", functions.GetStringDatetime(),
                        "@id", Request.QueryString["id"]);
                        lbl_error.Text = String.Format("Cập nhật trạng thái [<b>{0}</b>] thành công", txt_name.Text);
                    }
                    else
                    {
                        string sql = @"insert into YC_DM_TRANG_THAI_YEU_CAU (name,created_by,created_date,VISIBLE_BIT) values(@name,@created_by,@created_date,@VISIBLE_BIT)";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                        "@name", txt_name.Text,
                        "@created_by", functions.LoginMemID(this),
                        "@created_date", functions.GetStringDatetime(),
                        "@VISIBLE_BIT",'Y');
                        lbl_error.Text = String.Format("Lưu trạng thái [<b>{0}</b>] thành công", txt_name.Text);

                    }


                }
                else
                    lbl_error.Text = String.Format("Trạng thái [<b>{0}</b>] đã tồn tại", txt_name.Text);

            }
            catch
            {
                lbl_error.Text = String.Format("Lưu trạng thái [<b>{0}</b>] không thành công", txt_name.Text);
            }
        }
    }
}