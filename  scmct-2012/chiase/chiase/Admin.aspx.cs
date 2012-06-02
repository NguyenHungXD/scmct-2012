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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                functions.checkLogIn(this,functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                checkAccessRight();

                Session["current"] = "7"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> ";
            }
        }

        public void checkAccessRight()
        {
            string sLock = "<img src='images/lock_access.png' height=30 width=30>";
            if (functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this)))
            {
                //View all module on admin page
                pn_addmin_main.Visible = functions.checkPrivileges("7", functions.LoginMemID(this), "V"); 
                //View all module on project section
                if (functions.checkPrivileges("5", functions.LoginMemID(this), "V"))
                {
                    //Project
                    lbl_create_new_project.Visible = functions.checkPrivileges("6", functions.LoginMemID(this), "V");
                    lbl_search_project.Visible = functions.checkPrivileges("8", functions.LoginMemID(this), "V");
                    lbl_add_member_project.Visible = functions.checkPrivileges("11", functions.LoginMemID(this), "V");
                    lbl_create_new_status.Visible = functions.checkPrivileges("9", functions.LoginMemID(this), "V");
                    lbl_search_status_project.Visible = functions.checkPrivileges("10", functions.LoginMemID(this), "V");
                }
                else
                {
                    lbl_create_new_project.Text = sLock + "Tạo dự án mới";
                    lbl_search_project.Text = sLock + "Cập nhật dự án";
                    lbl_add_member_project.Text = sLock + "Nhân sự cho dự án";
                    lbl_create_new_status.Text = sLock + "Trạng thái mới";
                    lbl_search_status_project.Text = sLock + "Cập nhật trạng thái";
                }

                if (functions.checkPrivileges("13", functions.LoginMemID(this), "V"))
                {
                    //Request
                    
                    lbl_new_request.Visible = functions.checkPrivileges("12", functions.LoginMemID(this), "V");
                    lbl_search_request.Visible = functions.checkPrivileges("14", functions.LoginMemID(this), "V");
                    lbl_new_status_request.Visible = functions.checkPrivileges("15", functions.LoginMemID(this), "V");
                    lbl_search_status_request.Visible = functions.checkPrivileges("16", functions.LoginMemID(this), "V");
                    lbl_new_kind_request.Visible = functions.checkPrivileges("17", functions.LoginMemID(this), "V");
                    lbl_search_kind_request.Visible = functions.checkPrivileges("18", functions.LoginMemID(this), "V");
                }
                else
                {
                    lbl_new_request.Text = sLock + "Tạo yêu cầu mới";
                    lbl_search_request.Text = sLock + "Cập nhật yêu cầu";
                    lbl_new_status_request.Text = sLock + "Trạng thái mới";
                    lbl_search_status_request.Text = sLock + "Cập nhật trạng thái mới";
                    lbl_new_kind_request.Text = sLock + "Loại yêu cầu mới";
                    lbl_search_kind_request.Text = sLock + "Cập nhật loại yêu cầu mới";
                }

                if (functions.checkPrivileges("19", functions.LoginMemID(this), "V"))
                {
                    //News

                    lbl_create_new_subject.Visible = functions.checkPrivileges("20", functions.LoginMemID(this), "V");
                    lbl_search_subject.Visible = functions.checkPrivileges("21", functions.LoginMemID(this), "V");
                    lbl_search_post_news.Visible = functions.checkPrivileges("22", functions.LoginMemID(this), "V");
                    lbl_hot_news.Visible = functions.checkPrivileges("23", functions.LoginMemID(this), "V");
                    lbl_create_new_status_news.Visible = functions.checkPrivileges("24", functions.LoginMemID(this), "V");
                    lbl_search_status_news.Visible = functions.checkPrivileges("25", functions.LoginMemID(this), "V");
                }
                else
                {

                    lbl_create_new_subject.Text = sLock + "Tạo chủ đề mới";
                    lbl_search_subject.Text = sLock + "Quản lý chủ đề";
                    lbl_search_post_news.Text = sLock + "Quản lý bài viết";
                    lbl_hot_news.Text = sLock + "Bài viết nổi bật";
                    lbl_create_new_status_news.Text = sLock + "Trạng thái bài viết mới";
                    lbl_search_status_news.Text = sLock + "Cập nhật trạng thái";
                }

                if (functions.checkPrivileges("27", functions.LoginMemID(this), "V"))
                {
                    //Finance

                    lbl_phieu_thu.Visible = functions.checkPrivileges("28", functions.LoginMemID(this), "V");
                    lbl_search_phieu_thu.Visible = functions.checkPrivileges("29", functions.LoginMemID(this), "V");
                    lbl_phieu_chi.Visible = functions.checkPrivileges("30", functions.LoginMemID(this), "V");
                    lbl_search_phieu_chi.Visible = functions.checkPrivileges("31", functions.LoginMemID(this), "V");
                }
                else
                {
                    lbl_phieu_thu.Text = sLock + "Tạo phiếu thu";
                    lbl_search_phieu_thu.Text = sLock + "Cập nhật phiếu thu";
                    lbl_phieu_chi.Text = sLock + "Tạo phiếu chi";
                    lbl_search_phieu_chi.Text = sLock + "Cập nhật phiếu chi";
                }

                if (functions.checkPrivileges("32", functions.LoginMemID(this), "V"))
                {
                    //Members
                    lbl_create_new_members.Visible = functions.checkPrivileges("33", functions.LoginMemID(this), "V");
                    lbl_search_member_list.Visible = functions.checkPrivileges("42", functions.LoginMemID(this), "V");
                    lbl_create_new_group.Visible = functions.checkPrivileges("34", functions.LoginMemID(this), "V");
                    lbl_search_group_members.Visible = functions.checkPrivileges("35", functions.LoginMemID(this), "V");
                }
                else
                {
                    lbl_create_new_members.Text = sLock + "Tạo tài khoản mới";
                    lbl_search_member_list.Text = sLock + "Cập nhật tài khoản";
                    lbl_create_new_group.Text = sLock + "Tạo nhóm thành viên";
                    lbl_search_group_members.Text = sLock + "Cập nhật nhóm thành viên";
                }

                if (functions.checkPrivileges("36", functions.LoginMemID(this), "V"))
                {
                    //Module
                    lbl_create_new_module.Visible = functions.checkPrivileges("37", functions.LoginMemID(this), "V");
                    lbl_search_module_list.Visible = functions.checkPrivileges("38", functions.LoginMemID(this), "V");
                }
                else
                {
                    lbl_create_new_module.Text = sLock + "Thêm chức năng mới";
                    lbl_search_module_list.Text = sLock + "Cập nhật chức năng";
                }

                if (functions.checkPrivileges("39", functions.LoginMemID(this), "V"))
                {
                    //Access right
                    lbl_access_right_for_groups.Visible = functions.checkPrivileges("40", functions.LoginMemID(this), "V");
                    lbl_access_right_for_members.Visible = functions.checkPrivileges("41", functions.LoginMemID(this), "V");
                }
                else
                {
                    lbl_access_right_for_groups.Text = sLock + "Xét quyền cho nhóm thành viên";
                    lbl_access_right_for_members.Text = sLock + "Xét quyền cho thành viên";
                }

                if (functions.checkPrivileges("45", functions.LoginMemID(this), "V"))
                {
                    //Access Orther
                    lbl_update_info.Visible = functions.checkPrivileges("45", functions.LoginMemID(this), "V");
                }
                else
                {
                    lbl_update_info.Text = sLock + "Cập nhật thông tin điều khoản,trợ giúp";
              
                }
                //
            }
            else
                Response.Redirect("error_page.aspx");
        


        }

        protected void btn_add_new_project_Click(object sender, EventArgs e)
        {
            Response.Redirect("create_new_project.aspx");
        }

        protected void btn_create_new_subject_Click(object sender, EventArgs e)
        {
            Response.Redirect("create_new_subject.aspx");
        }

        protected void btn_create_new_reciever_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageReceive.aspx");
        }

        protected void btn_issue_to_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageShipments.aspx");
        }
    }
} 