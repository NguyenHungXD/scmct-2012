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
    public partial class post_news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btn_create_news_Click1(object sender, EventArgs e)
        {
            //String sql = "INSERT INTO BV_BAI_VIET(TIEU_DE,NGUOI_TAO,NGAY_TAO,NOI_DUNG,TRANG_THAI_ID,CHU_DE_ID,SORT)VALUES(@V_TIEU_DE,@V_NGUOI_TAO,@V_NGAY_TAO,@V_NOI_DUNG,@V_TRANG_THAI_ID,@V_CHU_DE_ID,@V_SORT)";
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                //Database.ExecuteNonQuery(sql,
                //                 "@V_TIEU_DE", txt_title.Text,
                //                 "@V_NGUOI_TAO", table.Rows[0]["mem_id"],
                //                 "@V_NGAY_TAO",DateTime.Now,
                //                 "@V_NOI_DUNG", Editor1.Content,
                //                 "@V_TRANG_THAI_ID",1,
                //                 "@V_CHU_DE_ID", Request.QueryString["subjectID"],
                //                 "@V_SORT", txt_sort.Text);
                BV_BAI_VIET bv = BV_BAI_VIET.Insert_Object(txt_title.Text, table.Rows[0][ND_THONG_TIN_DN.cl_MEM_ID].ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), table.Rows[0][ND_THONG_TIN_DN.cl_MEM_ID].ToString(),
                    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").ToString(),
                    Editor1.Content, "1", "", "", Request.QueryString["subjectID"], txt_sort.Text);
                if (bv != null)
                    lbl_error.Text = "Đăng bài thành công";
                else
                    lbl_error.Text = "Đăng bài không thành công";
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.ToString();
            }
        }
    }
}