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
    public partial class update_img_comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                update_img_comments();
        }
        public void update_img_comments()
        {
            try
            {
                    String sql = "INSERT INTO IMG_ALLBUM_COMMENT(IMG_ID,COMMENTED_BY,COMMENTED_DATE,COMMENT,STATUS) Values(@IMG_ID,@COMMENTED_BY,@COMMENTED_DATE,@COMMENT,@STATUS)";
                    SQLConnectWeb.ExecuteNonQuery(sql,
                            "@IMG_ID", Request.QueryString["imgid"],
                             "@COMMENTED_BY", functions.LoginMemID(this),
                            "@COMMENTED_DATE",DateTime.Now ,
                            "@COMMENT", Request.QueryString["content_cm"].Replace("\n","<br>"),
                            "@STATUS", 1
                            );
                    String sql_cm = "UPDATE IMG_ALLBUM SET COMMENTS=COMMENTS+1 WHERE ALLBUM_ID=(select allbum_id from IMG_ALLBUM_DETAIL where img_id=@IMG_ID)";
                    SQLConnectWeb.ExecuteNonQuery(sql_cm,
                            "@IMG_ID", Request.QueryString["imgid"]);

                }
            
            catch (Exception ex)
            { }
        }
        }
    
}