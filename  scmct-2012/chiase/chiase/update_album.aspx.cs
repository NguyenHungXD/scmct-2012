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
    public partial class update_album : System.Web.UI.Page
    {
        public static string username;
        public static int ii;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                display();
                Session["current"] = "3"; //[1.Trang chu 2.Dien Dan 3.Hinh Anh 4.Gui Yeu Cau 5.Gioi Thieu 6.Lien He 7.Quan Tri]
            }
        }

        public void display()
        {
            try
            {
                ii = 1;
                username = functions.LoginMemID(this);
                //Remove all album without any images uploaded
                String sql_del = "Delete from IMG_album where album_id not in (select album_id from IMG_album_DETAIL)";
                SQLConnectWeb.ExecuteNonQuery(sql_del);

                String sql = @"select a.*,b.name,c.username
                            from IMG_album a 
                            inner join ND_THONG_TIN_ND b on a.created_by = b.ID
                            inner join ND_THONG_TIN_DN c on c.mem_id = b.ID
                            where album_id = @album_id and a.deleted is null";
                DataTable table = SQLConnectWeb.GetData(sql, "@album_id", Request.QueryString["album_id"]);

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
                DataList dt_list = (DataList)e.Item.FindControl("DataList2");
                const String sql = @"select count(*) as v_cnt from IMG_album_DETAIL where album_id = @id and deleted is null";
                using (DataTable table = SQLConnectWeb.GetData(sql, "@id", id))
                {
                    cnt.Text = table.Rows[0]["v_cnt"].ToString();
                }

               // const String sql_img = @"select path from IMG_album_DETAIL where img_id=(select max(img_id) from IMG_album_DETAIL where album_id=@id)";
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
                String sql_detail = @"select a.*,b.*,b.Liked as imgLiked
                            from IMG_album a 
                            inner join IMG_album_DETAIL b on a.album_id = b.album_id
                            where a.album_id = @album_id and b.deleted is null
                            order by b.img_id";
                DataTable table_detail = SQLConnectWeb.GetData(sql_detail, "@album_id", id);
                if (table_detail == null) return;

                dt_list.DataSource = table_detail;
                dt_list.DataBind();
                //
                Label lbl_add = (Label)e.Item.FindControl("lbl_add_img");
                Label lbl_edit = (Label)e.Item.FindControl("lbl_edit_img");
                Label lbl_del = (Label)e.Item.FindControl("lbl_del_img");

                if (functions.checkOwnSection(functions.LoginMemID(this), id.ToString(), "IMG_album", "CREATED_BY", "album_ID"))
                {
                    lbl_add.Visible = true;
                    lbl_edit.Visible = true;
                    lbl_del.Visible = true;
                }
                else
                {
                    lbl_add.Visible = functions.checkPrivileges("44", functions.LoginMemID(this), "C");
                    lbl_edit.Visible = functions.checkPrivileges("44", functions.LoginMemID(this), "E");
                    lbl_del.Visible = functions.checkPrivileges("44", functions.LoginMemID(this), "D");
                
                }
                

                }
                
            catch
            { }
        }


    }
}