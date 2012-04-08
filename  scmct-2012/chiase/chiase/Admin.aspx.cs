using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;

namespace chiase
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
         
            }
        }
        protected void btn_add_new_project_Click(object sender, EventArgs e)
        {
            Response.Redirect("create_new_project.aspx");
        }

        protected void btn_create_new_subject_Click(object sender, EventArgs e)
        {
            Response.Redirect("create_new_subject.aspx");
        }

        protected void btn_create_new_reciever_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageReceive.aspx");
        }

        protected void btn_issue_to_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageShipments.aspx");
        }
    }
} 