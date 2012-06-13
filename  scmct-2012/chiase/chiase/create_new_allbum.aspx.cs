using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chiase
{
    public partial class create_new_album : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the HttpFileCollection
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        hpf.SaveAs(String.Format("{0}\\{1}", Server.MapPath("images\\upload"), System.IO.Path.GetFileName(hpf.FileName)));
                        Response.Write("<b>File: </b>" + hpf.FileName + "  <b>Size:</b> " +
                            hpf.ContentLength + "  <b>Type:</b> " + hpf.ContentType + " Uploaded Successfully <br/>");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}