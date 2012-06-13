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
    public partial class show_album : System.Web.UI.Page
    {
        public static string username;
        public static string v_project_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Just display this option when user loged in
                if (functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this)))
                {
                    show_search.Visible = true;
                    lbl_create_album.Visible = true;
                    lbl_info.Visible = false;
                }
                else
                {
                    show_search.Visible = false;
                    lbl_create_album.Visible = false;
                    lbl_info.Visible = true;
                }

                display();
                Session["current"] = "3"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]

                if (Request.QueryString["projectid"] == null)
                {
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='show_album.aspx' title='Hình ảnh'>Hình ảnh</a> ";
                    ASPxPopupControl1.ContentUrl = "upload_images.aspx";
                }
                else
                {
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='show_album.aspx?projectid=" + Request.QueryString["projectid"] + "'>Hình ảnh</a>";
                    v_project_id = "upload_images.aspx?projectid=" + Request.QueryString["projectid"];
                    ASPxPopupControl1.ContentUrl = v_project_id;
                }
            }
        }
        public void display()
        {
            try
            {
                //Rechecked

                string sWhere = "where a.deleted is null";
                if (functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this)))
                {
                    if (Request.QueryString["show_all"] == "all")
                    {
                        sWhere += "";
                        album_alls.Checked = true;
                        album_cuatoi.Checked = true;
                        album_toithich.Checked = true;
                        album_toibl.Checked = true;
                    }
                    else
                    {

                        string TempWhere = "";
                        if (Request.QueryString["album_cuatoi"] == "all")
                        {
                            TempWhere += " or a.created_by=" + functions.LoginMemID(this);
                            album_cuatoi.Checked = true;
                        }
                        if (Request.QueryString["album_toithich"] == "all")
                        {
                            //Liked album
                            TempWhere += " or a.album_id in (select bai_viet_id from bv_vote where user_id=" + functions.LoginMemID(this) + " and mode=4) ";
                            //Liked img
                            TempWhere += " or a.album_id in (select album_id from IMG_ALBUM_DETAIL a inner join BV_VOTE b on bai_viet_id = a.img_id where mode=3 and user_id=" + functions.LoginMemID(this) + " group by album_id) ";
                            album_toithich.Checked = true;
                        }
                        if (Request.QueryString["album_toibl"] == "all")
                        {
                            //Comment on Album
                            TempWhere += " or a.album_id in (select album_id from IMG_ALBUM_COMMENT where deleted is null and commented_by=" + functions.LoginMemID(this) + ") ";
                            //Comment on Image
                            TempWhere += " or a.album_id in (select a.album_id from IMG_ALBUM_DETAIL a inner join IMG_ALBUM_COMMENT b on b.img_id = a.img_id where b.deleted is null and b.commented_by=" + functions.LoginMemID(this) + " group by a.album_id) ";
                            album_toibl.Checked = true;
                        }
                        if (TempWhere!="")
                        {
                            sWhere += " and ( 1=2 " + TempWhere + ")";
                        }
                       
                    }
                }

                DataTable table;
                username = functions.LoginMemID(this);
                //Remove all album without any images was uploaded
                String sql_del = "Delete from IMG_album where album_id not in (select album_id from IMG_album_DETAIL)";
                SQLConnectWeb.ExecuteNonQuery(sql_del);
                if (Request.QueryString["projectid"] == null)
                {
                    String sql = @"select a.*,b.name,c.username
                            from IMG_album a 
                            inner join ND_THONG_TIN_ND b on a.created_by = b.ID
                            inner join ND_THONG_TIN_DN c on c.mem_id = b.ID " + sWhere  + " order by album_id";
                    table = SQLConnectWeb.GetData(sql);
                }
                else
                {
                    String sql = @"select a.*,b.name,c.username
                            from IMG_album a 
                            inner join ND_THONG_TIN_ND b on a.created_by = b.ID
                            inner join ND_THONG_TIN_DN c on c.mem_id = b.ID " + sWhere + " and a.project_id=" + Request.QueryString["projectid"] + " order by album_id";
                    table = SQLConnectWeb.GetData(sql);
                }
                if (table.Rows.Count == 0)
                {
                    lbl_info.Text = "Album ảnh chưa được đăng tải";
                }
                DataList1.DataSource = table;
                DataList1.DataBind();
            }
            catch

            { }
            
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row["album_id"];
                Label cnt = (Label)e.Item.FindControl("lbl_cnt_img");
                Image img = (Image)e.Item.FindControl("img_first");

                const String sql = @"select count(*) as v_cnt from IMG_album_DETAIL where album_id = @id and deleted is null";
                using (DataTable table = SQLConnectWeb.GetData(sql, "@id", id))
                {
                    cnt.Text = table.Rows[0]["v_cnt"].ToString();
                }
                /*
                const String sql_img = @"select path from IMG_album_DETAIL where img_id=(select max(img_id) from IMG_album_DETAIL where album_id=@id)";
                using (DataTable table_img = SQLConnectWeb.GetData(sql_img, "@id", id))
                {
                    img.ImageUrl = table_img.Rows[0]["path"].ToString();
                }
                */
                const String sql_img = @"select path from IMG_album a inner join IMG_album_DETAIL b on a.main_img = b.img_id where a.album_id = @id and b.deleted is null";
                using (DataTable table_img = SQLConnectWeb.GetData(sql_img, "@id", id))
                {
                    if (table_img.Rows.Count == 0)
                    {
                        const String sql_imgs = @"select path from IMG_album_DETAIL where img_id=(select max(img_id) from IMG_album_DETAIL where album_id=@id)";
                        using (DataTable table_imgs = SQLConnectWeb.GetData(sql_imgs, "@id", id))
                        {
                            img.ImageUrl = table_imgs.Rows[0]["path"].ToString();
                        }
                    }
                    else
                        img.ImageUrl = table_img.Rows[0]["path"].ToString();
                }

                //
                Label lbl_edit_album = (Label)e.Item.FindControl("lbl_edit_album");
                Label lbl_del_album = (Label)e.Item.FindControl("lbl_del_album");

                if (functions.ValidateUserLogin(functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this)))
                {
                    if (functions.checkOwnSection(functions.LoginMemID(this), id.ToString(), "IMG_album", "CREATED_BY", "album_ID"))
                    {
                        lbl_edit_album.Visible = true;
                        lbl_del_album.Visible = true;
                    }
                    else
                    {
                        lbl_edit_album.Visible = functions.checkPrivileges("44", functions.LoginMemID(this), "E");
                        lbl_del_album.Visible = functions.checkPrivileges("44", functions.LoginMemID(this), "D");
                    }
                }
                else
                {
                    lbl_edit_album.Visible = false;
                    lbl_del_album.Visible = false;
                }
            }
            catch
            { }
        }
    }
}