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
    public partial class create_access_right_for_group : System.Web.UI.Page
    {
        public static int no;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Boolean check = false;
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));
                lbl_search.Visible = functions.checkPrivileges("40", functions.LoginMemID(this), "V");
                module_list.Visible = functions.checkPrivileges("40", functions.LoginMemID(this), "V");
                if (functions.checkPrivileges("40", functions.LoginMemID(this), "E") || functions.checkPrivileges("40", functions.LoginMemID(this), "C"))
                {
                    check = true;
                }
                if (Request.QueryString["vmode"] == "create_new" && check==true)
                {
                    update_right();
                }
                else
                {
                    lbl_create_access.Visible = check;
                    no = 0;
                    divgroupid.Value = Request.QueryString["id"];
                    Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a href='create_access_right_for_group.aspx?id=" + Request.QueryString["id"] + "' title='Xét quyền'>Xét quyền</a>";
                    display();
                }

            }
        }

        public void update_right()
        {
            try
            {
                string sql_update = @"update PQ_PHAN_QUYEN_NHOM_CN set isread='" + Request.QueryString["V"] + "',isinsert='" + Request.QueryString["C"] + "',isupdate='" + Request.QueryString["E"] + "',isdelete='" + Request.QueryString["D"] + "',islock='" + Request.QueryString["L"] + "',edited_by=" + functions.LoginMemID(this) + ",edited_date='" + functions.GetStringDatetime() + "' where moduleid=" + Request.QueryString["moduleid"] + " and groupid=" + Request.QueryString["groupid"];
                int chk = SQLConnectWeb.ExecuteNonQuery(sql_update);
                //string sql_update = @"update PQ_PHAN_QUYEN_NHOM_CN set isread=@isread,isinsert=@isinsert,isupdate=@isupdate,isdelete=@isdelete,islock=@islock,edited_by=@edited_by,edited_date=@created_date where moduleid=@moduleid and groupid=@groupid";
                //int chk = SQLConnectWeb.ExecuteNonQuery(sql_update,
                //                                        "@isread", Request.QueryString["V"],
                //                                        "@isinsert", Request.QueryString["C"],
                //                                        "@isupdate", Request.QueryString["E"],
                //                                        "@isdelete", Request.QueryString["D"],
                //                                        "@islock", Request.QueryString["L"],
                //                                        "@edited_by", functions.LoginMemID(this),
                //                                        "@edited_date", functions.GetStringDatetime(),
                //                                        "@moduleid", Request.QueryString["moduleid"],
                //                                        "@groupid", Request.QueryString["groupid"]);
                
                if (chk==0) //If the module is new, insert into 
                {
                    string sql_insert = @"insert into PQ_PHAN_QUYEN_NHOM_CN (moduleid,groupid,isread,isinsert,isupdate,isdelete,islock,created_by,created_date) values (@moduleid,@groupid,@isread,@isinsert,@isupdate,@isdelete,@islock,@created_by,@created_date)";
                    SQLConnectWeb.ExecuteNonQuery(sql_insert,
                                        "@isread", Request.QueryString["V"],
                                        "@isinsert", Request.QueryString["C"],
                                        "@isupdate", Request.QueryString["E"],
                                        "@isdelete", Request.QueryString["D"],
                                        "@islock", Request.QueryString["L"],
                                        "@created_by", functions.LoginMemID(this),
                                        "@created_date", functions.GetStringDatetime(),
                                        "@moduleid", Request.QueryString["moduleid"],
                                        "@groupid", Request.QueryString["groupid"]);
                }
            }
            catch(Exception ex)
            {
                //lbl_groupname.Text = ex.ToString();
            }
        }
        public void display()
        {
            try
            {
                no = 0;
                string sql_group = @"select groupname from ND_TEN_NHOM_ND a where GROUPID=@id";
                DataTable table = SQLConnectWeb.GetData(sql_group, "@id", Request.QueryString["id"]);
                lbl_groupname.Text = table.Rows[0]["groupname"].ToString();
                string sql = @"select a.id,a.featureid,a.name from PQ_CHUC_NANG a where deleted is null and (a.featureid like N'%" + txt_moduleid.Text + "%' or a.id like N'%" + txt_moduleid.Text + "%') and a.name like N'%" + txt_module_name.Text + "%' order by a.featureid";
                DataTable table_detail = SQLConnectWeb.GetData(sql);
                module_list.DataSource = table_detail;
                module_list.DataBind();
            }
            catch
            { 
            }
        }

        protected void module_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Repeater controlList = (Repeater)e.Item.FindControl("control_list");
                DataRowView RowView = (DataRowView)e.Item.DataItem;
                if (RowView == null) return;
                long id = (long)RowView.Row["id"];
                string sql = @"select id,moduleid,
                             case when isread = 'Y' then 'checked' else '' end as isreads,
                             case when isinsert = 'Y' then 'checked' else '' end as isinserts,
                             case when isupdate = 'Y' then 'checked' else '' end as isupdates,
                             case when isdelete = 'Y' then 'checked' else '' end as isdeletes,
                             case when islock = 'Y' then 'checked' else '' end as islocks,
                             case when islock = 'Y' and isdelete = 'Y' and isupdate = 'Y' and isinsert = 'Y' and isread = 'Y' then 'checked' else '' end as ischkalls,
                             case when isread = 'Y' then '#92C6F7' else '#FFFFFF' end as bgcolor_read,
                             case when isinsert = 'Y' then '#92C6F7' else '#FFFFFF' end as bgcolor_insert,
                             case when isupdate = 'Y' then '#92C6F7' else '#FFFFFF' end as bgcolor_edit,
                             case when isdelete = 'Y' then '#92C6F7' else '#FFFFFF' end as bgcolor_del,
                             case when islock = 'Y' then '#92C6F7' else '#FFFFFF' end as bgcolor_lock
							 from PQ_PHAN_QUYEN_NHOM_CN
                             where groupid=@groupid and moduleid=@moduleid";
                DataTable table_detail = SQLConnectWeb.GetData(sql, "@groupid", Request.QueryString["id"], "@moduleid", id);
                if (table_detail.Rows.Count == 0) //ADD A NEW TABLE TEMP TO DISPLAY DATA FOR SETTING UP THE ACCESS RIGHT
                {
                    DataTable dt2 = new DataTable();
                    DataColumn col;
                    col = new DataColumn("id", System.Type.GetType(" System.Int32"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("moduleid", System.Type.GetType("System.Int32"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("isreads", System.Type.GetType("System.String"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("isinserts", System.Type.GetType("System.String"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("isupdates", System.Type.GetType(" System.String"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("isdeletes", System.Type.GetType(" System.String"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("islocks", System.Type.GetType(" System.String"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("ischkalls", System.Type.GetType(" System.String"));
                    dt2.Columns.Add(col);

                    col = new DataColumn("bgcolor_read", System.Type.GetType(" System.String"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("bgcolor_insert", System.Type.GetType(" System.String"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("bgcolor_edit", System.Type.GetType(" System.String"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("bgcolor_del", System.Type.GetType(" System.String"));
                    dt2.Columns.Add(col);
                    col = new DataColumn("bgcolor_lock", System.Type.GetType(" System.String"));
                    dt2.Columns.Add(col);

                    DataRow dataRow = dt2.NewRow();
                    dataRow["ID"] = no;
                    dataRow["moduleid"] = id;
                    dataRow["isreads"] = "";
                    dataRow["isinserts"] = "";
                    dataRow["isupdates"] = "";
                    dataRow["isdeletes"] = "";
                    dataRow["islocks"] = "";
                    dataRow["ischkalls"] = "";
                    dataRow["bgcolor_read"] = "#FFFFFF";
                    dataRow["bgcolor_insert"] = "#FFFFFF";
                    dataRow["bgcolor_edit"] = "#FFFFFF";
                    dataRow["bgcolor_del"] = "#FFFFFF";
                    dataRow["bgcolor_lock"] = "#FFFFFF";

                    dt2.Rows.Add(dataRow);

                    controlList.DataSource = dt2;
                    controlList.DataBind();
                }
                else
                {
                    controlList.DataSource = table_detail;
                    controlList.DataBind();
                }
            }
            catch(Exception ex)
            {
                //view = ex.ToString();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                display();

            }
            catch
            { 
            }
        }
    }
}