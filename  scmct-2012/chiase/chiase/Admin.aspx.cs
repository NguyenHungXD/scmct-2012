using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace chiase
{
    public partial class Admin : System.Web.UI.Page
    {
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
                const String sql = "SELECT * FROM DA_DU_AN";
                DataTable table = Database.GetData(sql);
                functions.fill_DropdownList(dropd_lst_project, table, 0, 1);
                show_project_name();
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.ToString();
            
            }
        
        }
        public void show_project_name()
        {
            try
            {
                const String sql = "SELECT * FROM DA_DU_AN WHERE ID = @v_ID";
                DataTable table = Database.GetData(sql, "@v_ID", dropd_lst_project.SelectedValue);
                lbl_project_name.Text = (String)table.Rows[0]["TEN_DU_AN"];
            }
            catch (Exception ex)
            {

                lbl_error.Text = ex.ToString();
            }
        }
        protected void link_create_new_project_Click(object sender, EventArgs e)
        {
            Response.Redirect("create_new_project.aspx");
        }

        protected void dropd_lst_project_SelectedIndexChanged(object sender, EventArgs e)
        {
            show_project_name();
        }
    }
} 