using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;
using DK2C.DataAccess.Web;
using System.IO;
namespace chiase
{
    public partial class edit_project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                functions.add_date_to_dropd(dropd_day_start, dropd_month_start, dropd_year_start, 10);
                functions.add_date_to_dropd(dropd_day_end, dropd_month_end, dropd_year_end, 20);
                display();
                ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";
            }

            txt_project_name.Focus();
            
        }
        public void display()
        {
                try
                {
                    DataTable table_status = DA_DM_TRANG_THAI_DU_AN.GetTableAll();
                    functions.fill_DropdownList(dropd_status, table_status, 0, 1);

                    String sql = @"select a.*,b.name ,b.id as tt_id
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID Where a.id=@v_id ";

                    DataTable table = SQLConnectWeb.GetData(sql, "@v_id", Request.QueryString["id"]);

                    if (table.Rows.Count > 0)
                    {
                        txt_project_name.Text = (String)table.Rows[0]["TEN_DU_AN"];
                        txt_project_code.Text = (String)table.Rows[0]["MA_DU_AN"];
                        Int64 book = (Int64)table.Rows[0]["BOOK"];
                        txt_book.Text = book.ToString();
                        txt_notes.Text = (String)table.Rows[0]["GHI_CHU"];
                        ASPxHtmlEditor1.Html = (String)table.Rows[0]["CHI_TIET"];
                        functions.selectedDropdown(dropd_status, table.Rows[0]["tt_id"].ToString());
                        DateTime start_date = (DateTime)table.Rows[0]["ngay_bat_dau"];
                        DateTime end_date = (DateTime)table.Rows[0]["ngay_ket_thuc"];

                        functions.selectedDropdown(dropd_year_start, start_date.Year.ToString());
                        functions.selectedDropdown(dropd_day_start, start_date.Day.ToString());
                        functions.selectedDropdown(dropd_month_start, start_date.Month.ToString());

                        functions.selectedDropdown(dropd_year_end, end_date.Year.ToString());
                        functions.selectedDropdown(dropd_day_end, end_date.Day.ToString());
                        functions.selectedDropdown(dropd_month_end, end_date.Month.ToString());
                    }
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Có lổi trong lúc hiển thị dữ liệu";
            }
        }

  /*

        protected void btn_add_stutus_names_Click(object sender, EventArgs e)
        {
            try
            {
                // DataTable table = (DataTable)Session["ThanhVien"];
                //String sql = "INSERT INTO DA_DM_TRANG_THAI_DU_AN(NAME,ENABLE_BIT,CREATED_DATE,CREATED_BY) VALUES(@V_NAME,@V_ENABLE_BIT,@V_CREATED_DATE,@V_CREATED_BY)";
                //Database.ExecuteNonQuery(sql,
                //            "@v_NAME", txt_status_project.Text,
                //            "@V_ENABLE_BIT", 'Y',
                //            "@V_CREATED_DATE", functions.GetStringDatetime(),
                //            "@V_CREATED_BY", table.Rows[0]["mem_id"]);

                DA_DM_TRANG_THAI_DU_AN ttda = DA_DM_TRANG_THAI_DU_AN.Insert_Object(txt_status_project.Text, "Y",
                    functions.GetStringDate(), functions.LoginMemID(this));
                if (ttda != null)
                {
                    lbl_error.Text = "Trang thái mới đã được tạo thành công, bạn hãy tiếp tục tạo dự án mới";
                    display(); //Reload the list with the new Item#
                    dropd_status.SelectedIndex = functions.selectedDropdown(dropd_status, txt_status_project.Text);
                }
                else lbl_error.Text = "Trạng thái tạo không thành công!";


            }
            catch (Exception ex)
            {

                lbl_error.Text = "Không tạo được trạng thái mới";
            }
        }
        */
        protected void btn_create_projects_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = @"UPDATE DA_DU_AN SET MA_DU_AN = @V_MA_DU_AN,
                                TEN_DU_AN=@V_TEN_DU_AN,
                                NGAY_CAP_NHAT=@V_NGAY_CAP_NHAT,
                                NGUOI_CAP_NHAT=@V_NGUOI_CAP_NHAT,
                                NGAY_BAT_DAU=@V_NGAY_BAT_DAU,
                                NGAY_KET_THUC=@V_NGAY_KET_THUC,
                                CHI_TIET=@V_CHI_TIET,
                                TRANG_THAI_ID=@V_TRANG_THAI_ID,
                                GHI_CHU=@V_GHI_CHU,
                                ENABLE_BIT=@V_ENABLE_BIT,
                                BOOK=@V_BOOK
                                WHERE ID = @ID";
                DateTime start_date = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month_start.Text, dropd_day_start.Text, dropd_year_start.Text));
                DateTime end_date = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month_end.Text, dropd_day_end.Text, dropd_year_end.Text));
                int done = SQLConnectWeb.ExecuteNonQuery(sql,
                                            "@V_MA_DU_AN",txt_project_code.Text,
                                            "@V_TEN_DU_AN", txt_project_name.Text,
                                            "@V_NGAY_CAP_NHAT", functions.GetStringDatetime(),
                                            "@V_NGUOI_CAP_NHAT", functions.LoginMemID(this),
                                            "@V_NGAY_BAT_DAU", start_date,
                                            "@V_NGAY_KET_THUC", end_date,
                                            "@V_CHI_TIET", ASPxHtmlEditor1.Html.Replace("'", ""),
                                            "@V_TRANG_THAI_ID", dropd_status.SelectedValue,
                                            "@V_GHI_CHU", txt_notes.Text,
                                            "@V_ENABLE_BIT", 'Y',
                                            "@V_BOOK", txt_book.Text,
                                            "@ID",Request.QueryString["id"]);

                //DA_DU_AN da = DA_DU_AN.Insert_Object(txt_project_code.Text, txt_project_name.Text,
                //    functions.GetStringDatetime(), functions.LoginMemID(this), functions.GetStringDate(start_date),
                //    functions.GetStringDate(end_date), ASPxHtmlEditor1.Html.Replace("'", ""), dropd_status.SelectedValue,
                //    "", "", txt_notes.Text, "Y");

          
                String filename = upload_img.FileName;
                if(filename!="" || filename!=null)
                {
                    String file_type = System.IO.Path.GetExtension(filename).ToLower();
                    String img = Request.QueryString["id"] + file_type;
                    if ((file_type == ".jpg" || file_type == ".gif" || file_type == ".png"))
                    {
                        //Update to database
                        String sqls = "UPDATE DA_DU_AN SET img_path='" + img  + "' WHERE ID=" + Request.QueryString["id"];
                        if (SQLConnectWeb.ExecuteNonQuery(sqls) == 1)
                        {
                            const String path = "images/Projects/";
                            File.Delete(MapPath(path) + img);
                            upload_img.SaveAs(MapPath(path) + img);
                        }
                        else
                        {
                            lbl_error.Text = "Cập nhật hình đại diện không thành công, vui lòng kiểm tra lại thông tin!";
                        }
                    }
                    else
                    {
                        lbl_error.Text = String.Format("Chỉ cho phép hình có định dạng JPG/GIF/PNG, file của bạn: {0}", filename);
                    }
                }


                if (done == 1)
                    lbl_error.Text = "Cập nhật dự án thành công";
                else
                    lbl_error.Text = "Cập nhật dự án không thành công, vui lòng kiểm tra lại thông tin!";

                
            }
            catch (Exception ex)
            {

                lbl_error.Text = "Không cập nhật được dự án, xin vui lòng kiểm tra lại thông tin!" + ex.ToString();
            }
        }




    }
}