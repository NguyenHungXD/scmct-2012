using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;
namespace chiase
{
    public partial class create_new_subject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                display();
            }
            txt_title.Focus();

        }

        public void display()
        {

            //const String sql = "SELECT * FROM BV_DM_TRANG_THAI_BAI_VIET";
            DataTable table = BV_DM_TRANG_THAI_BAI_VIET.GetTableAll();
            functions.fill_DropdownList(dropd_status, table, 0, 1);
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
                //                        "@V_CREATED_DATE", DateTime.Now,
                //                        "@V_CREATED_BY", table.Rows[0]["mem_id"]);
                BV_DM_CHU_DE_BV bv = BV_DM_CHU_DE_BV.Insert_Object(txt_title.Text,"Y", txt_sort.Text, dropd_status.SelectedValue,
                      txt_description.Text, functions.GetStringDatetime(), functions.LoginMemID(this),"","");
                if (bv != null)
                    lbl_error.Text = "Chủ đề mới đã được tạo thành công";
                else lbl_error.Text = "Chủ đề mới đã được tạo không thành công, vui lòng kiểm tra lại thông tin";
            }
            catch (Exception ex)
            {

                lbl_error.Text = "Không thể tạo chủ đề mới "+ex.ToString();
            }
        }
    }
}