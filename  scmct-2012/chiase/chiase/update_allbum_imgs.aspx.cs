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
    public partial class update_allbum_imgs : System.Web.UI.Page
    {
        public static string allbumname;
        public static string allbumid;
        public static string allbum_description;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                display();
            
            }
        }
        public void display()
        {
            try
            {
                String sql_detail = @"select a.*,b.*,b.Liked as imgLiked
                            from IMG_ALLBUM a 
                            inner join IMG_ALLBUM_DETAIL b on a.allbum_id = b.allbum_id
                            where a.allbum_id = @allbum_id and b.deleted is null
                            order by b.img_id";
                DataTable table_detail = SQLConnectWeb.GetData(sql_detail, "@allbum_id", Request.QueryString["allbum_id"]);
                if (table_detail == null) return;

                allbumname = table_detail.Rows[0]["allbum_name"].ToString();
                allbum_description = table_detail.Rows[0]["description"].ToString();
                allbumid = table_detail.Rows[0]["allbum_id"].ToString();
                showListimg.DataSource = table_detail;
                showListimg.DataBind();
            
            }
            catch
            { }
        
        
        }
    }
}