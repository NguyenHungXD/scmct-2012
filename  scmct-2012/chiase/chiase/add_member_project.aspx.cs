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
    public partial class add_member_project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                display();
        }
        public void display()
        {
            try
            {
                String sql = @"select a.*,b.name
                            from da_du_an a 
                            inner join DA_DM_TRANG_THAI_DU_AN b on a.TRANG_THAI_ID = B.ID";
                DataTable table = SQLConnectWeb.GetData(sql);

                GridLookup.DataSource = table;
                GridLookup.DataBind();

                String sql_member = @"select id,name,address,convert(varchar,birth_day,103) as birthday,case when sex=0 then 'Nam' else 'Nữ' end as sex,email,
                                    case when avatar_path is null then 'default_img.gif' else avatar_path end as avatar,groupname,
                                    convert(varchar,a.created_date,103) as joined_date,skype,yahoo,c.username
                                    from ND_THONG_TIN_ND a
                                    inner join ND_THONG_TIN_DN c on c.mem_id = a.id
                                    inner join ND_TEN_NHOM_ND b on a.MEM_GROUP_ID = b.GROUPID";
                DataTable table_member = SQLConnectWeb.GetData(sql_member);
                ASPxGridLookup1.DataSource = table_member;
                ASPxGridLookup1.DataBind();

                String sql_pos = @"select pos_id,post_name from da_position";
                DataTable table_pos = SQLConnectWeb.GetData(sql_pos);
                ASPxGridLookup2.DataSource = table_pos;
                ASPxGridLookup2.DataBind();


            }
            catch (Exception ex)
            {
            }
        }
        protected void btn_create_projects_Click(object sender, EventArgs e)
        {
            try{
                const String sql_duan = @"select a.ngay_bat_dau,a.ngay_ket_thuc from da_du_an a where id=@id";
                DataTable table_duan = SQLConnectWeb.GetData(sql_duan, "@id", (long)GridLookup.Value);

                const String sql_check_update = @"select a.* from DA_NHAN_SU a where DU_AN_ID=@DU_AN_ID and MEM_ID=@MEM_ID";
                long du_an_id =  (long)GridLookup.Value;
                long mem_da_id = (long)ASPxGridLookup1.Value;
                long pos_da_id = (long)ASPxGridLookup2.Value;
                DataTable table_check_update = SQLConnectWeb.GetData(sql_check_update, "@DU_AN_ID", du_an_id.ToString(),"@MEM_ID",mem_da_id.ToString());
                if (table_check_update.Rows.Count > 0)
                {
                    String sql = "UPDATE DA_NHAN_SU SET POSITION=@POSITION,EDITED_BY =@EDITED_BY,EDITED_DATE=@EDITED_DATE WHERE DU_AN_ID=@DU_AN_ID AND MEM_ID=@MEM_ID ";
                    int done = SQLConnectWeb.ExecuteNonQuery(sql,
                                                           "@DU_AN_ID", du_an_id.ToString(),
                                                           "@MEM_ID", mem_da_id.ToString(),
                                                           "@POSITION", pos_da_id.ToString(),
                                                           "@EDITED_BY", functions.LoginMemID(this),
                                                           "@EDITED_DATE", functions.GetStringDatetime());
                    if (done == 1)
                    {
                        lbl_error.Text = "Cập nhật thành công";
                        seach();
                    }
                    else
                        lbl_error.Text = "Cập nhật không thành công, vui lòng kiểm tra lại thông tin!";
                }
                else
                {
                    String sql = "INSERT INTO DA_NHAN_SU(DU_AN_ID,MEM_ID,START_DATE,END_DATE,ACTIVE,POSITION,ADDED_BY,ADDED_DATE,STATUS) VALUES(@DU_AN_ID,@MEM_ID,@START_DATE,@END_DATE,@ACTIVE,@POSITION,@ADDED_BY,@ADDED_DATE,@STATUS)";
                    int done = SQLConnectWeb.ExecuteNonQuery(sql,
                                                            "@DU_AN_ID", (long)GridLookup.Value,
                                                            "@MEM_ID", (long)ASPxGridLookup1.Value,
                                                            "@START_DATE", table_duan.Rows[0]["ngay_bat_dau"],
                                                            "@END_DATE", table_duan.Rows[0]["ngay_ket_thuc"],
                                                            "@ACTIVE", "Y",
                                                            "@POSITION", (long)ASPxGridLookup2.Value,
                                                            "@ADDED_BY", functions.LoginMemID(this),
                                                            "@ADDED_DATE", functions.GetStringDatetime(),
                                                            "@STATUS", 1); // [1 : Approved (Was added by addmin)] | [0 : Wating for approval (Register by members)]

                    if (done == 1)
                    {
                        lbl_error.Text = "Thêm thành viên thành công";
                        seach();
                    }
                    else
                        lbl_error.Text = "Thêm thành viên mới không thành công, vui lòng kiểm tra lại thông tin!";

                }
            }
            catch (Exception ex)
            {

                lbl_error.Text = "Thêm thành viên cho dự án không thành công. vui lòng kiểm tra lại thông tin: [Mã dự án]-[Thành viên]-[Vị trí]"; 
            }
        }
        public void seach()
        {
            lbl_project.Text = GridLookup.Text;
            string project_id;
            string pos_id;
            string user_id;

            if (GridLookup.Text != "" || ASPxGridLookup2.Text != "")
            {
                if (GridLookup.Text == "")
                    project_id = "%";
                else
                    project_id = GridLookup.Value.ToString();
                if (ASPxGridLookup2.Text == "")
                    pos_id = "%";
                else
                    pos_id = ASPxGridLookup2.Value.ToString();
                if (ASPxGridLookup1.Text == "")
                    user_id = "%";
                else
                    user_id = ASPxGridLookup1.Value.ToString();

                String sql_list_member = String.Format(@"select a.id,a.active,a.du_an_id,a.mem_id,b.name,a.added_date,c.groupname,d.post_name,e.name as added_name,f.username,
                                                                                         case when status=1 then N'Đã duyêt' else N'Chờ duyêt' end as status,
                                                                                         case when status=1 then N'Đã duyêt' else '<input id=' + convert(nvarchar,a.id) + ' name=chk type=checkbox value=' + convert(nvarchar,a.id) + ' /><label for=' + convert(nvarchar,a.id) + N'>Duyệt</label>' end as status1,
                                                                                        case when a.active='N' then 'unlockicon.gif' else 'lockicon.gif' end as img_lock,
                                                                                         case when a.active='N' then N'Mở khóa' else N'Khóa' end as img_lock_alt,
                                                                                        case when a.active='D' then 'undeleteicon.gif' else 'deleteicon.gif' end as img_del,
                                                                                         case when a.active='D' then N'Phục hồi' else N'Xóa' end as img_del_alt
                                                                                         from da_nhan_su a
                                                                                         inner join nd_thong_tin_nd b on a.mem_id = b.id
                                                                                         inner join nd_ten_nhom_nd c on b.mem_group_id = c.groupid
                                                                                         inner join da_position d on a.position=d.pos_id
                                                                                         inner join nd_thong_tin_nd e on a.added_by = e.id
                                                                                         left join ND_THONG_TIN_DN f on a.mem_id = f.mem_id where a.du_an_id like '{0}' and a.position like '{1}' and a.mem_id like '{2}'", project_id, pos_id, user_id); 
                    DataTable table_list_member = SQLConnectWeb.GetData(sql_list_member);
                    showListmember.DataSource = table_list_member;
                    showListmember.DataBind();
            }
            else
            {
                lbl_error.Text = "Chọn dự án hoặc vị trí sau đó thử tìm lại!";
            
            }
            
        }

        protected void find_Click(object sender, EventArgs e)
        {
            seach();
        }
    }
}