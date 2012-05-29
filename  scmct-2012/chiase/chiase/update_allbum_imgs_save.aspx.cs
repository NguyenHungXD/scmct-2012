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
    public partial class update_allbum_imgs_save : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                if(Request.QueryString["mode"]=="1") //Update info
                {
                    save_images_info();
                }
                else if(Request.QueryString["mode"]=="2") //Del image
                {
                    del_images();
                }
                else if (Request.QueryString["mode"] == "3")//Set default image
                {
                    save_default_image();
                }
                else if (Request.QueryString["mode"] == "4")
                {
                    del_allbum();
                }
            }
        }
        public void save_images_info()
        {
            try
            {
                String sql = "update IMG_ALLBUM_DETAIL set title=@title,deleted=null where img_id=@img_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@title", Request.QueryString["v_title"], "@img_id", Request.QueryString["img_id"]);
            }
            catch
            { }
        }
        public void del_images()
        {
            try
            {
                String sql = "update IMG_ALLBUM_DETAIL set DELETED='Y' where img_id=@img_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@img_id", Request.QueryString["img_id"]);
            }
            catch
            { }
        }

        public void save_default_image()
        {
            try
            {
                String sql = "update IMG_ALLBUM set MAIN_IMG=@img_id where allbum_id=@allbum_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@img_id", Request.QueryString["img_id"], "@allbum_id", Request.QueryString["allbum_id"]);
            }
            catch
            { }
        }

        public void del_allbum()
        {
            try
            {
                String sql = "update IMG_ALLBUM set deleted='Y' where allbum_id=@allbum_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@allbum_id", Request.QueryString["allbum_id"]);
            }
            catch
            { }
        }
    }
}