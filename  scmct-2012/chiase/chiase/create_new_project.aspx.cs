﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace chiase
{
    public partial class create_new_project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                functions.add_date_to_dropd(dropd_day_start, dropd_month_start, dropd_year_start,10);
                functions.add_date_to_dropd(dropd_day_end, dropd_month_end, dropd_year_end,10);
                display();
            }
           
            txt_project_name.Focus();
            panel_add_new_status.Visible = false;
        }
        public void display()
        {
            try
            {
                const String sql = "SELECT * FROM DA_DM_TRANG_THAI_DU_AN";
                DataTable table = Database.GetData(sql);
                functions.fill_DropdownList(dropd_status, table, 0, 1);
                txt_project_code.Text = String.Format("DA{0}{1}{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Không thể tạo mới dự án";
            }
        
        }
        
        protected void btn_add_project_status_Click(object sender, EventArgs e)
        {
            panel_add_new_status.Visible = true;
        }

        protected void btn_add_stutus_name_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                String sql = "INSERT INTO DA_DM_TRANG_THAI_DU_AN(NAME,ENABLE_BIT,CREATED_DATE,CREATED_BY) VALUES(@V_NAME,@V_ENABLE_BIT,@V_CREATED_DATE,@V_CREATED_BY)";
                Database.ExecuteNonQuery(sql,
                            "@v_NAME", txt_status_project.Text,
                            "@V_ENABLE_BIT", 'Y',
                            "@V_CREATED_DATE", DateTime.Now,
                            "@V_CREATED_BY", table.Rows[0]["mem_id"]);
                lbl_error.Text = "Trang thái mới đã được tạo thành công, bạn hãy tiếp tục tạo dự án mới";

                display(); //Reload the list with the new Item#
                dropd_status.SelectedIndex = functions.selectedDropdown(dropd_status, txt_status_project.Text);
            }
            catch (Exception ex)
            {

                lbl_error.Text = "Không tạo được trạng thái mới";
            }
        }

        protected void btn_create_project_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = (DataTable)Session["ThanhVien"];
                String sql = "INSERT INTO DA_DU_AN(MA_DU_AN,TEN_DU_AN,NGAY_TAO,NGUOI_TAO,NGAY_BAT_DAU,NGAY_KET_THUC,CHI_TIET,TRANG_THAI_ID,GHI_CHU,ENABLE_BIT) VALUES(@V_MA_DU_AN,@V_TEN_DU_AN,@V_NGAY_TAO,@V_NGUOI_TAO,@V_NGAY_BAT_DAU,@V_NGAY_KET_THUC,@V_CHI_TIET,@V_TRANG_THAI_ID,@V_GHI_CHU,@V_ENABLE_BIT)";
                DateTime start_date = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month_start.Text, dropd_day_start.Text, dropd_year_start.Text));
                DateTime end_date = Convert.ToDateTime(String.Format("{0}/{1}/{2}", dropd_month_end.Text, dropd_day_end.Text, dropd_year_end.Text));
                Database.ExecuteNonQuery(sql,
                                            "@V_MA_DU_AN", txt_project_code.Text,
                                            "@V_TEN_DU_AN",txt_project_name.Text,
                                            "@V_NGAY_TAO",DateTime.Now,
                                            "@V_NGUOI_TAO",table.Rows[0]["mem_id"],
                                            "@V_NGAY_BAT_DAU",start_date,
                                            "@V_NGAY_KET_THUC",end_date,
                                            "@V_CHI_TIET",txt_project_details.Text,
                                            "@V_TRANG_THAI_ID",dropd_status.SelectedValue,
                                            "@V_GHI_CHU",txt_notes.Text,
                                            "@V_ENABLE_BIT",'Y');


                lbl_error.Text = "Tạo dự án mới thành công";

            }catch (Exception ex)
            {

                lbl_error.Text = "Không tạo được dự án mới" + ex.ToString();
            }
        }
    }
}