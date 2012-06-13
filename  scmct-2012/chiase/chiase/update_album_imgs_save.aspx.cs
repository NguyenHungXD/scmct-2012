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
    public partial class update_album_imgs_save : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

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
                    del_album();
                }
            }
        }
        public void save_images_info()
        {
            try
            {
                String sql = "update IMG_album_DETAIL set title=@title,deleted=null where img_id=@img_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@title", Request.QueryString["v_title"], "@img_id", Request.QueryString["img_id"]);
            }
            catch
            { }
        }
        public void del_images()
        {
            try
            {
                String sql = "update IMG_album_DETAIL set DELETED='Y' where img_id=@img_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@img_id", Request.QueryString["img_id"]);
            }
            catch
            { }
        }

        public void save_default_image()
        {
            try
            {
                String sql = "update IMG_album set MAIN_IMG=@img_id where album_id=@album_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@img_id", Request.QueryString["img_id"], "@album_id", Request.QueryString["album_id"]);
            }
            catch
            { }
        }

        public void del_album()
        {
            try
            {
                String sql = "update IMG_album set deleted='Y' where album_id=@album_id";
                SQLConnectWeb.ExecuteNonQuery(sql, "@album_id", Request.QueryString["album_id"]);
            }
            catch
            { }
        }
    }
}