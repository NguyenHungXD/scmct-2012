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
    public partial class create_new_module : System.Web.UI.Page
    {
        public static string vNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                if (Request.QueryString["id"] != null)
                {
                    lbl_create_new_module.Visible = functions.checkPrivileges("38", functions.LoginMemID(this), "E");
                    lbl_help.Text = "";
                    txt_feature_id.Enabled = false;
                    display();
                }
                else
                {
                    lbl_create_new_module.Visible = functions.checkPrivileges("37", functions.LoginMemID(this), "C");
                    txt_feature_id.Text = functions.getNo("CNxxx.000000");
                }
            }
        }
        public void display()
        {
            try
            {
                string sql = @"select a.*,b.name as created_by_name,
                                        case when a.deleted is null then 'FFF' else '454' end as bgcolors,
                                        case when a.visible_bit like '%Y%' then 'FFF' else '454' end as bgcolors1
                                        from PQ_CHUC_NANG a 
                                        inner join ND_THONG_TIN_ND b on b.id = a.CREATED_BY
                                        where a.id =@id";
                DataTable table = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["id"]);
                txt_feature_id.Text = table.Rows[0]["featureid"].ToString();
                txt_module_name.Text = table.Rows[0]["name"].ToString();
                txt_desc.Text = table.Rows[0]["description"].ToString();
                txt_path.Text = table.Rows[0]["access_path"].ToString();
                txt_code_path.Text = table.Rows[0]["code_path"].ToString();
                
                
            }
            catch
            { }
        }



        protected void Button2_Click1(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string sql = @"update PQ_CHUC_NANG set name=@name,description=@description,edited_by=@edited_by,edited_date=@edited_date,access_path=@access_path,code_path=@code_path where id =@id";
                    int done = SQLConnectWeb.ExecuteNonQuery(sql,
                                "@name", txt_module_name.Text,
                                "@description", txt_desc.Text,
                                "@edited_by", functions.LoginMemID(this),
                                "@edited_date", functions.GetStringDatetime(),
                                "@access_path", txt_path.Text,
                                "@code_path", txt_code_path.Text,
                                "@id", Request.QueryString["id"]
                                );

                    lbl_error.Text = "Cập nhật chức năng " + txt_feature_id.Text + " thành công.";
                }
                else
                {
                    string sql_get_next_no = @"select featureid from PQ_CHUC_NANG where RTRIM(featureid) = @featureid";
                    DataTable table_next_no = SQLConnectWeb.GetData(sql_get_next_no, "@featureid", txt_feature_id.Text);
                    if (table_next_no.Rows.Count > 0)
                    {
                        vNo = functions.getNo(txt_feature_id.Text);
                        lbl_error.Text = "Mã chức năng đã tồn tại. Bạn có thê sử dụng mã kế tiếp: <b>" + vNo + "</b>";
                    }
                    else
                    {

                        string sql = @"insert into PQ_CHUC_NANG (featureid,name,description,visible_bit,created_by,created_date,access_path,code_path) values(@featureid,@name,@description,@visible_bit,@created_by,@created_date,@access_path,@code_path)";
                        int done = SQLConnectWeb.ExecuteNonQuery(sql,
                                    "@featureid", txt_feature_id.Text,
                                    "@name", txt_module_name.Text,
                                    "@description", txt_desc.Text,
                                    "@visible_bit", 'Y',
                                    "@created_by", functions.LoginMemID(this),
                                    "@created_date", functions.GetStringDatetime(),
                                    "@access_path", txt_path.Text,
                                    "@code_path", txt_code_path.Text
                                    );

                        lbl_error.Text = "Lưu chức năng " + txt_feature_id.Text + " mới thành công.";
                    }
                }
            }
            catch (Exception ex)
            {
                //lbl_error.Text = ex.ToString();

            }
        }

    }
}