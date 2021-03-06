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
    public partial class create_new_project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                functions.add_date_to_dropd(dropd_day_start, dropd_month_start, dropd_year_start,10);
                functions.add_date_to_dropd(dropd_day_end, dropd_month_end, dropd_year_end,20);
                display();
                ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";
                pn_create_new_project.Visible = functions.checkPrivileges("6", functions.LoginMemID(this), "C");//Display button to create a new project
            }
           
            txt_project_name.Focus();
           
        }
        public void display()
        {
            try
            {
              //  const String sql = "SELECT * FROM DA_DM_TRANG_THAI_DU_AN";
                DataTable table = DA_DM_TRANG_THAI_DU_AN.GetTableAll();
                functions.fill_DropdownList(dropd_status, table, 0, 1);
                txt_project_code.Text = String.Format("DA SCMCT{0}",DateTime.Now.Year);
                txt_book.Text = "0";

                functions.selectedDropdown(dropd_year_start, DateTime.Now.Year.ToString());
                functions.selectedDropdown(dropd_day_start, DateTime.Now.Day.ToString());
                functions.selectedDropdown(dropd_month_start, DateTime.Now.Month.ToString());
            
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Không thể tạo mới dự án";
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
                String sql = "INSERT INTO DA_DU_AN(MA_DU_AN,TEN_DU_AN,NGAY_TAO,NGUOI_TAO,NGAY_BAT_DAU,NGAY_KET_THUC,CHI_TIET,TRANG_THAI_ID,GHI_CHU,ENABLE_BIT,BOOK,SORT) VALUES(@V_MA_DU_AN,@V_TEN_DU_AN,@V_NGAY_TAO,@V_NGUOI_TAO,@V_NGAY_BAT_DAU,@V_NGAY_KET_THUC,@V_CHI_TIET,@V_TRANG_THAI_ID,@V_GHI_CHU,@V_ENABLE_BIT,@V_BOOK,@SORT)";
                //DateTime start_date = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month_start.Text, dropd_day_start.Text, dropd_year_start.Text));
                //DateTime end_date = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month_end.Text, dropd_day_end.Text, dropd_year_end.Text));
                string start_date= functions.CheckDate(String.Format("{0}/{1}/{2}", dropd_month_start.Text, dropd_day_start.Text, dropd_year_start.Text));
                string end_date = functions.CheckDate(String.Format("{0}/{1}/{2}", dropd_month_end.Text, dropd_day_end.Text, dropd_year_end.Text));
                int done = SQLConnectWeb.ExecuteNonQuery(sql,
                                            "@V_MA_DU_AN", txt_project_code.Text,
                                            "@V_TEN_DU_AN", txt_project_name.Text,
                                            "@V_NGAY_TAO", functions.GetStringDatetime(),
                                            "@V_NGUOI_TAO", functions.LoginMemID(this),
                                            "@V_NGAY_BAT_DAU", start_date,
                                            "@V_NGAY_KET_THUC", end_date,
                                            "@V_CHI_TIET", ASPxHtmlEditor1.Html.Replace("'", ""),
                                            "@V_TRANG_THAI_ID", dropd_status.SelectedValue,
                                            "@V_GHI_CHU", txt_notes.Text,
                                            "@V_ENABLE_BIT", 'Y',
                                            "@V_BOOK", txt_book.Text,
                                            "@SORT",txt_sort.Text);

                string max_project = @"select id from da_du_an where id = (select max(id) from da_du_an where nguoi_tao=" + functions.LoginMemID(this) + ")";
                DataTable table_detail = SQLConnectWeb.GetData(max_project);

                //DA_DU_AN da = DA_DU_AN.Insert_Object(txt_project_code.Text, txt_project_name.Text,
                //    functions.GetStringDatetime(), functions.LoginMemID(this), functions.GetStringDate(start_date),
                //    functions.GetStringDate(end_date), ASPxHtmlEditor1.Html.Replace("'", ""), dropd_status.SelectedValue,
                //    "", "", txt_notes.Text, "Y");

                ////Create a new forum section for project when it was created successfully
                //string sql_insert = @"insert into BV_DM_CHU_DE_BV (id,types_id,title,visible_bit,sort,status,description,created_date,created_by) values (@id,@types_id,@title,@visible_bit,@sort,@status,@description,@created_date,@created_by )";
                //SQLConnectWeb.ExecuteNonQuery(sql_insert,
                //    "@id",table_detail.Rows[0]["id"],"@types_id", "2", "@title", txt_project_code.Text, "@visible_bit", "Y", "@sort", "0", "@status", "1", "@description", txt_project_name.Text, "@created_date", functions.GetStringDatetime(), "@created_by", functions.LoginMemID(this));
                    
                    //BV_DM_CHU_DE_BV bv = BV_DM_CHU_DE_BV.Insert_Object(txt_project_code.Text, "Y", "0", "1",
                //        txt_project_name.Text, functions.GetStringDatetime(), functions.LoginMemID(this), "", "");




         
                String filename = upload_img.FileName;
                if(filename!="" || filename!=null)
                {
                    String file_type = System.IO.Path.GetExtension(filename).ToLower();
                    String img = table_detail.Rows[0]["id"] + file_type;
                    if ((file_type == ".jpg" || file_type == ".gif" || file_type == ".png"))
                    {
                        //Update to database
                        String sqls = "UPDATE DA_DU_AN SET img_path='" + img  + "' WHERE ID=" + table_detail.Rows[0]["id"];
                        if (SQLConnectWeb.ExecuteNonQuery(sqls)==1)
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
                {
                    lbl_error.Text = "Tạo dự án mới thành công";
                    ASPxButton1.Visible = false;
                }
                else
                    lbl_error.Text = "Tạo dự án mới không thành công, vui lòng kiểm tra lại thông tin!";
                
                //Update hinh dai dien


            }
            catch (Exception ex)
            {

                lbl_error.Text = "Không tạo được dự án mới" + ex.ToString() ;
            }
        }
        /*
        protected void btn_close_Click2(object sender, EventArgs e)
        {
            panel_add_new_status.Visible = false;
        }
        */
        protected void btn_back_Click(object sender, EventArgs e)
        {
            //object refUrl = ViewState["RefUrl"];
            //if (refUrl != null)
            //    Response.Redirect((string)refUrl);
            Response.Redirect("admin.aspx");
        }

  

 

        





        





 
    }
}