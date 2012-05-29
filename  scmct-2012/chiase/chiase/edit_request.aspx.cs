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
    public partial class edit_request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";
                display();
            }
        }
        public void display()
        {
            try
            {
                string sql = "select a.* from yc_yeu_cau a where yeu_cau_id=@id";
                DataTable table_detail = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["id"]);
                txt_request_subject.Text = table_detail.Rows[0]["tieu_de"].ToString();
                ASPxHtmlEditor1.Html = table_detail.Rows[0]["noi_dung"].ToString();
                DataTable table_request_kind = YC_DM_LOAI_YEU_CAU.GetTableFields(YC_DM_LOAI_YEU_CAU.cl_ID, YC_DM_LOAI_YEU_CAU.cl_TEN_LOAI_YC);
                functions.fill_DropdownList(dropd_request_kind, table_request_kind, 0, 1);
                functions.selectedDropdown(dropd_request_kind, table_detail.Rows[0]["loai_yc_id"].ToString());
            }
            catch
            { 
            
            }
        
        
        }

        protected void btn_requests_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"update yc_yeu_cau set tieu_de=@tieu_de,noi_dung=@noi_dung,loai_yc_id=@loai_yc_id,nguoi_cap_nhat=@nguoi_cap_nhat,ngay_cap_nhat=@ngay_cap_nhat where yeu_cau_id=@id";
                SQLConnectWeb.ExecuteNonQuery(sql,
                                                 "@tieu_de", txt_request_subject.Text,
                                                 "@noi_dung", ASPxHtmlEditor1.Html.Replace(",", ""),
                                                 "@loai_yc_id", dropd_request_kind.SelectedValue,
                                                 "@nguoi_cap_nhat", functions.LoginMemID(this),
                                                 "@ngay_cap_nhat", functions.GetStringDatetime(),
                                                 "@id", Request.QueryString["id"]);

                lbl_result.Text = "Cập nhật nội dung yêu cầu thành công!";

            }
            catch
            { 
            
            }
        }
    }
}