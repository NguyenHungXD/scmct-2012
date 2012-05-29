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
    public partial class request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
                
                ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";
                if (Request.QueryString["vmode"] == "admin")
                {
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='request.aspx' title='Gửi yêu cầu'>Gửi yêu cầu</a> ";
                    Session["current"] = "7";
                    Panel2.Visible = true;
                }
                else
                {
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='request.aspx' title='Gửi yêu cầu'>Gửi yêu cầu</a> ";
                    Panel1.Visible = true;
                    Session["current"] = "4"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
                }
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
                functions.selectedDropdown(dropd_request_kind, "1");


                String sql = @"SELECT b.id,'[' + a.username + ']-[' + b.name +']-['+ b.address +']-['+ c.groupname +']' as info
                         FROM ND_THONG_TIN_DN a
                        INNER JOIN  ND_THONG_TIN_ND b ON  a.MEM_ID=b.ID
                        INNER JOIN ND_TEN_NHOM_ND c ON  b.MEM_GROUP_ID = c.GROUPID order by c.groupname";


                DataTable table_detail = SQLConnectWeb.GetTable(sql);
                functions.fill_DropdownList(member_list, table_detail, 0, 1);


            }catch (Exception ex)
            {
                lbl_result.Text = "";
            }
        }



        protected void btn_request_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable table = (DataTable)Session["ThanhVien"];
                string memid= functions.LoginMemID(this);
                if (!string.IsNullOrEmpty(memid))
                {
                    if (Request.QueryString["vmode"] == "admin")
                        memid = member_list.SelectedValue;
                    String sql = "INSERT INTO YC_YEU_CAU(TIEU_DE,NOI_DUNG,TRANG_THAI_ID,LOAI_YC_ID,NGUOI_YEU_CAU,NGAY_YEU_CAU,NGUOI_CAP_NHAT,NGAY_CAP_NHAT) VALUES(@V_TIEU_DE,@V_NOI_DUNG,@V_TRANG_THAI_ID,@V_LOAI_YC_ID,@V_NGUOI_YEU_CAU,@V_NGAY_YEU_CAU,@NGUOI_CAP_NHAT,@NGAY_CAP_NHAT)";
                    int yc= SQLConnectWeb.ExecuteNonQuery(sql,
                                "@V_TIEU_DE", txt_request_subject.Text,
                                "@V_NOI_DUNG", ASPxHtmlEditor1.Html.Replace(",", ""),
                                "@V_TRANG_THAI_ID", '1',
                                "@V_LOAI_YC_ID", dropd_request_kind.SelectedValue,
                                "@V_NGUOI_YEU_CAU", memid,
                                "@V_NGAY_YEU_CAU", functions.GetStringDatetime(),
                                "@NGUOI_CAP_NHAT", functions.LoginMemID(this),
                                "@NGAY_CAP_NHAT", functions.GetStringDatetime()
                                );

                    //YC_YEU_CAU yc = YC_YEU_CAU.Insert_Object(txt_request_subject.Text.Replace("'",""), ASPxHtmlEditor1.Html.Replace(",",""),
                    //    "1", dropd_request_kind.SelectedValue,memid ,
                    //  functions.GetStringDatetime(), "", "");
                    if (yc >0)
                        lbl_result.Text = String.Format("Đã gửi yêu cầu thành công. Bạn có thể xem trạng thái yêu cầu của mình trong <font color=red><a href=my_page.aspx?id={0}>trang của tôi</a></font>", memid);
                    else lbl_result.Text = "Yêu cầu gửi không thành công, vui lòng kiểm tra lại thông tin!";
                }
                else
                {
                    //YC_YEU_CAU yc = YC_YEU_CAU.Insert_Object(txt_request_subject.Text.Replace("'", ""), ASPxHtmlEditor1.Html.Replace(",", ""),"1", dropd_request_kind.SelectedValue, "0",functions.GetStringDatetime(), "", "");

                    String sql = "INSERT INTO YC_YEU_CAU(TIEU_DE,NOI_DUNG,TRANG_THAI_ID,LOAI_YC_ID,NGUOI_YEU_CAU,NGAY_YEU_CAU) VALUES(@V_TIEU_DE,@V_NOI_DUNG,@V_TRANG_THAI_ID,@V_LOAI_YC_ID,@V_NGUOI_YEU_CAU,@V_NGAY_YEU_CAU)";
                    int yc = SQLConnectWeb.ExecuteNonQuery(sql,
                                "@V_TIEU_DE", txt_request_subject.Text,
                                "@V_NOI_DUNG", ASPxHtmlEditor1.Html.Replace(",", ""),
                                "@V_TRANG_THAI_ID", '1',
                                "@V_LOAI_YC_ID", dropd_request_kind.SelectedValue,
                                "@V_NGUOI_YEU_CAU", 0,
                                "@V_NGAY_YEU_CAU", functions.GetStringDatetime());
                    
                    if (yc >0)
                        lbl_result.Text = "Đã gửi yêu cầu thành công, xin chân thành cảm ơn! Chúng tôi sẽ liên hệ với bạn.";
                    else lbl_result.Text = "Yêu cầu gửi không thành công, vui lòng kiểm tra lại thông tin!";
                }
            }
            catch (Exception ex)
            {
                lbl_result.Text = String.Format("Không gửi được yêu cầu{0}{1}", ex, dropd_request_kind.SelectedValue);
            }
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

 

        
    }
}