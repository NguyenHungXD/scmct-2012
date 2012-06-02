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
    public partial class search_member_list : System.Web.UI.Page
    {
        public static int no;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                if (Request.QueryString["vmode"] == "del")
                {
                    del_user();
                }
                else if (Request.QueryString["vmode"] == "undel")
                {
                    undel_user();
                }
                else if (Request.QueryString["vmode"] == "lock")
                {
                    lock_user();
                }
                else if (Request.QueryString["vmode"] == "unlock")
                {
                    unlock_user();
                }
                else if (Request.QueryString["vmode"] == "reset_pass")
                {
                    reset_pass_user();
                }
                else if (Request.QueryString["vmode"] == "update_group")
                {
                    update_group_user();
                }
                else
                {
                    lbl_del_members.Visible = functions.checkPrivileges("42", functions.LoginMemID(this), "D");
                    lbl_lock_members.Visible = functions.checkPrivileges("42", functions.LoginMemID(this), "L");
                    lbl_search_members.Visible = functions.checkPrivileges("42", functions.LoginMemID(this), "V");

                    no = 1;
                    display();
                }
                Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='search_member_list.aspx' title='Quản lý người dùng'>Quản lý người dùng</a>";
            }
        }
        public void reset_pass_user()
        {
            try
            {
                string sql = @"update ND_THONG_TIN_DN set PWD =USERNAME+'123' where MEM_ID =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
            }
            catch
            {
            }
        }
        public void update_group_user()
        {
            try
            {
                string sql = @"update ND_THONG_TIN_ND set MEM_GROUP_ID="+ Request.QueryString["groupid"] +" where id="+Request.QueryString["id"];
                SQLConnectWeb.ExecuteNonQuery(sql);
            }
            catch(Exception ex)
            {

            }
        }
        public void del_user()
        {
            try
            {
                string sql = @"update ND_THONG_TIN_DN set deleted ='Y' where MEM_ID =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
                string sql_nd = @"update ND_THONG_TIN_ND set deleted ='Y' where ID =@id";
                SQLConnectWeb.ExecuteNonQuery(sql_nd, "@id", Request.QueryString["id"]);
            }
            catch
            {
            }
        }
        public void undel_user()
        {
            try
            {
                string sql = @"update ND_THONG_TIN_DN set deleted =null where MEM_ID =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
                string sql_nd = @"update ND_THONG_TIN_ND set deleted =null where ID =@id";
                SQLConnectWeb.ExecuteNonQuery(sql_nd, "@id", Request.QueryString["id"]);
            }
            catch
            {
            }
        }
        public void lock_user()
        {
            try
            {
                string sql = @"update ND_THONG_TIN_DN set ISACTIVE_BIT ='N' where MEM_ID =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
                string sql_nd = @"update ND_THONG_TIN_ND set VISIBLE_BIT ='N' where ID =@id";
                SQLConnectWeb.ExecuteNonQuery(sql_nd, "@id", Request.QueryString["id"]);
            }
            catch
            {
            }
        }
        public void unlock_user()
        {
            try
            {
                string sql = @"update ND_THONG_TIN_DN set ISACTIVE_BIT ='Y' where MEM_ID =@id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@id", Request.QueryString["id"]);
                string sql_nd = @"update ND_THONG_TIN_ND set VISIBLE_BIT ='Y' where ID =@id";
                SQLConnectWeb.ExecuteNonQuery(sql_nd, "@id", Request.QueryString["id"]);
            }
            catch
            {
            }
        }
        public void display()
        {
            try
            {
                
                string sWhere = "";
                tu_ngay.Text = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
                den_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string group_id = "%";

                if (dropd_group.SelectedValue != "None" && dropd_group.SelectedValue != "")
                {
                    group_id = dropd_group.SelectedValue;
                    sWhere += " where d.groupid like '" + group_id + "'";
                }
                else
                    sWhere += " where d.groupid like '%'";
                
                if (txt_tendangnhap.Text != "")
                    sWhere += " and b.USERNAME like N'%" + txt_tendangnhap.Text + "%'";

                if (txt_hoten .Text!= "")
                    sWhere += " and a.name like N'%" + txt_hoten.Text + "%'";

                if (txt_diachi.Text != "")
                    sWhere += " and a.address like N'%" + txt_diachi.Text + "%'";
                
                if (txt_email.Text != "")
                    sWhere += " and a.email like N'%" + txt_email.Text + "%'";

                if (txt_skype.Text != "")
                    sWhere += " and (a.skype like N'%" + txt_skype.Text + "%' or a.yahoo like N'%" + txt_skype.Text + "%' or a.fax like N'%" + txt_skype.Text + "%' or a.phone like N'%" + txt_skype.Text + "%')";

                if (txt_sothich.Text != "")
                    sWhere += " and a.note like N'%" + txt_sothich.Text + "%'";

                if (txt_nguoitao.Text != "")
                    sWhere += " and c.name like N'%" + txt_nguoitao.Text + "%'";
                
                string sql = @"select a.*,b.USERNAME as ten_dn,b.LASTED_ACCESS,b.CREATED_DATE,c.name as nguoi_tao,d.groupname,
                                    case when a.deleted is null then 'FFF' else '454' end as bgcolors,
                                    case when a.VISIBLE_BIT like '%Y%' then 'FFF' else '454' end as bgcolors1,
                                    case when a.avatar_path is null then 'default_img.gif' else a.avatar_path end as avatar
                                    from ND_THONG_TIN_ND a 
                                    left join ND_THONG_TIN_DN b on a.id = b.MEM_ID
                                    left join ND_THONG_TIN_ND c on b.CREATED_BY = c.id
                                    inner join ND_TEN_NHOM_ND d on a.MEM_GROUP_ID = d.groupid "+ sWhere;

                DataTable table_detail = SQLConnectWeb.GetData(sql);
                member_list.DataSource = table_detail;
                member_list.DataBind();

                string sql_pt = @"select groupid,groupname from ND_TEN_NHOM_ND order by groupname";
                DataTable table_pt = SQLConnectWeb.GetData(sql_pt);
                functions.fill_DropdownList(dropd_group, table_pt, 0, 1);
                //functions.selectedDropdown(dropd_group, mapt);
            }
            catch (Exception ex)
            {
                //lbl_error.Text = ex.ToString();
            }

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            display();
        }

        protected void member_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                DropDownList dropd = (DropDownList)e.Item.FindControl("dropd_groups");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long groupid = (long)RowView.Row["MEM_GROUP_ID"];
                long id = (long)RowView.Row["id"];
                string sql_pt = @"select groupid,groupname from ND_TEN_NHOM_ND order by groupname";
                DataTable table_pt = SQLConnectWeb.GetData(sql_pt);
                functions.fill_DropdownList(dropd, table_pt, 0, 1,id.ToString());
                functions.selectedDropdown(dropd, String.Format("{0};{1}",id, groupid));

                Label lb_edit = (Label)e.Item.FindControl("lbl_edit_members");
                Label lb_edit_group = (Label)e.Item.FindControl("lbl_edit_group_members");
                Label lb_group = (Label)e.Item.FindControl("lbl_group_members");

                if (functions.checkPrivileges("42", functions.LoginMemID(this), "E"))
                {
                    lb_edit.Visible = true;
                    lb_edit_group.Visible = true;
                }
                else
                {
                    lb_edit.Visible = false;
                    lb_edit_group.Visible = false;
                    lb_group.Text = dropd.SelectedItem.Text;
                }
            }
            catch
            {
            }
        }
    }
}