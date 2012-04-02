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
    public partial class request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
            }
            txt_request_subject.Focus();
        }

        public void display()
        {
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                if (table != null)
                {
                    txt_full_name.Text = (String)table.Rows[0][ND_THONG_TIN_ND.cl_NAME];
                    txt_address.Text = (String)table.Rows[0][ND_THONG_TIN_ND.cl_ADDRESS];
                    txt_phone_number.Text = (String)table.Rows[0][ND_THONG_TIN_ND.cl_PHONE];
                    txt_emaill_address.Text = (String)table.Rows[0][ND_THONG_TIN_ND.cl_EMAIL];
                }
               // const String sql = "SELECT id,ten_loai_yc FROM YC_DM_LOAI_YEU_CAU";
                DataTable table_request_kind = YC_DM_LOAI_YEU_CAU.GetTableFields(YC_DM_LOAI_YEU_CAU.cl_ID, YC_DM_LOAI_YEU_CAU.cl_TEN_LOAI_YC);
                functions.fill_DropdownList(dropd_request_kind, table_request_kind, 0, 1);
            }catch (Exception ex)
            {
                lbl_result.Text = "";
            }
        }

     

        protected void btn_request_Click1(object sender, EventArgs e)
        {
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                if (table != null)
                {

                    //String sql = "INSERT INTO YC_YEU_CAU(TIEU_DE,NOI_DUNG,TRANG_THAI_ID,LOAI_YC_ID,NGUOI_YEU_CAU,NGAY_YEU_CAU) VALUES(@V_TIEU_DE,@V_NOI_DUNG,@V_TRANG_THAI_ID,@V_LOAI_YC_ID,@V_NGUOI_YEU_CAU,@V_NGAY_YEU_CAU)";
                    //Database.ExecuteNonQuery(sql,
                    //            "@V_TIEU_DE", txt_request_subject.Text,
                    //            "@V_NOI_DUNG", txt_content.Text,
                    //            "@V_TRANG_THAI_ID", '1',
                    //            "@V_LOAI_YC_ID", dropd_request_kind.SelectedValue,
                    //            "@V_NGUOI_YEU_CAU", table.Rows[0]["mem_id"],
                    //            "@V_NGAY_YEU_CAU", DateTime.Now);
                    YC_YEU_CAU yc=YC_YEU_CAU.Insert_Object(txt_request_subject.Text,txt_content.Text,
                        "1",dropd_request_kind.SelectedValue,
                        table.Rows[0][ND_THONG_TIN_DN.cl_MEM_ID].ToString(),
                        DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),"","");
                    if (yc != null)
                        lbl_result.Text = "Đã gửi yêu cầu thành công";
                    else lbl_result.Text = "Yêu cầu gửi không thành công, vui lòng kiểm tra lại thông tin!";
                }
                else
                {
                    lbl_result.Text = "Xin vui lòng đăng nhập cổng thông tin để gửi yêu cầu. Xin cảm ơn !";
                }
            }
            catch (Exception ex)
            {
                lbl_result.Text = "Không gửi được yêu cầu" + ex.ToString() + dropd_request_kind.SelectedValue.ToString();
            }
        }
    }
}