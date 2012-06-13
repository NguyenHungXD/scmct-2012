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
    public partial class update_album_imgs : System.Web.UI.Page
    {
        public static string albumname;
        public static string albumid;
        public static string album_description;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                display();
            
            }
        }
        public void display()
        {
            try
            {
                String sql_detail = @"select a.*,b.*,b.Liked as imgLiked
                            from IMG_album a 
                            inner join IMG_album_DETAIL b on a.album_id = b.album_id
                            where a.album_id = @album_id and b.deleted is null
                            order by b.img_id";
                DataTable table_detail = SQLConnectWeb.GetData(sql_detail, "@album_id", Request.QueryString["album_id"]);
                if (table_detail == null) return;

                albumname = table_detail.Rows[0]["album_name"].ToString();
                album_description = table_detail.Rows[0]["description"].ToString();
                albumid = table_detail.Rows[0]["album_id"].ToString();
                showListimg.DataSource = table_detail;
                showListimg.DataBind();
            
            }
            catch
            { }
        
        
        }
    }
}