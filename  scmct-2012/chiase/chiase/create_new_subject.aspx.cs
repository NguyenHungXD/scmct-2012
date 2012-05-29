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
    public partial class create_new_subject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                display();
                ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";
            }
            txt_title.Focus();

        }

        public void display()
        {
            try
            {
            //const String sql = "SELECT * FROM BV_DM_TRANG_THAI_BAI_VIET";
            DataTable table = BV_DM_TRANG_THAI_BAI_VIET.GetTableAll();
            functions.fill_DropdownList(dropd_status, table, 0, 1);

            if (Request.QueryString["id"] != null)
            {
                string sql = @"select a.*,b.id as status_id
                                        from BV_DM_CHU_DE_BV a 
                                        inner join BV_DM_TRANG_THAI_BAI_VIET b on a.status = b.id
                                        where a.id =@id";

                DataTable table_data = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["id"]);
                txt_sort.Text = table_data.Rows[0]["sort"].ToString();
                txt_title.Text = table_data.Rows[0]["title"].ToString();
                ASPxHtmlEditor1.Html = table_data.Rows[0]["description"].ToString();

                functions.selectedDropdown(dropd_status,table_data.Rows[0]["status"].ToString());
            }
            }
           catch
            {}
        }
        
        protected void btn_create_new_subject_Click(object sender, EventArgs e)
        {
            //String sql = "INSERT INTO BV_DM_CHU_DE_BV (TITLE,VISIBLE_BIT,SORT,STATUS,DESCRIPTION,CREATED_DATE,CREATED_BY) VALUES(@V_TITLE,@V_VISIBLE_BIT,@V_SORT,@V_STATUS,@V_DESCRIPTION,@V_CREATED_DATE,@V_CREATED_BY)";
            
            //DataTable table = (DataTable)Session["ThanhVien"];

            try
            {
                //Database.ExecuteNonQuery(sql,
                //                        "@V_TITLE",txt_title.Text,
                //                        "@V_VISIBLE_BIT", 'Y',
                //                        "@V_SORT", txt_sort.Text,
                //                        "@V_STATUS",dropd_status.SelectedValue,
                //                        "@V_DESCRIPTION", txt_description.Text,
                //                        "@V_CREATED_DATE", functions.GetStringDatetime(),
                //                        "@V_CREATED_BY", table.Rows[0]["mem_id"]);

                if (Request.QueryString["id"] != null)
                {
                    String sql = "update BV_DM_CHU_DE_BV set  title=@title,sort=@sort,status=@status,description=@description,edited_date=@edited_date,edited_by=@edited_by where id=@id";
                   int bv= SQLConnectWeb.ExecuteNonQuery(sql,
                                            "@title", txt_title.Text,
                                            "@sort", txt_sort.Text,
                                            "@status", dropd_status.SelectedValue,
                                            "@description", ASPxHtmlEditor1.Html.Replace("'", ""),
                                            "@edited_date", functions.GetStringDatetime(),
                                            "@edited_by", functions.LoginMemID(this),
                                            "@id", Request.QueryString["id"]);

                    if (bv != 0)
                        lbl_error.Text = "Chủ đề đã cập nhật thành công";
                    else lbl_error.Text = "Chủ đề cập nhật không thành công, vui lòng kiểm tra lại thông tin";
                }else
                {
                    BV_DM_CHU_DE_BV bv = BV_DM_CHU_DE_BV.Insert_Object(txt_title.Text, "Y", txt_sort.Text, dropd_status.SelectedValue,
                          ASPxHtmlEditor1.Html.Replace("'", ""), functions.GetStringDatetime(), functions.LoginMemID(this), "", "");



                    if (bv != null)
                        lbl_error.Text = "Chủ đề mới đã được tạo thành công";
                    else lbl_error.Text = "Chủ đề mới tạo không thành công, vui lòng kiểm tra lại thông tin";

                }
            }
            catch (Exception ex)
            {

                lbl_error.Text = "Không thể tạo chủ đề mới "+ex.ToString();
            }
        }
    }
}