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
    public partial class create_new_subject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                lbl_create_new_subject.Visible = functions.checkPrivileges("20", functions.LoginMemID(this), "C");
                display();
                ASPxHtmlEditor1.ClientSideEvents.Validation = "ValidationHandler";
            }
            txt_title.Focus();

        }

        public void display()
        {
            try
            {
            //const String sql = "SELECT * FROM BV_DM_TRANG_THAI_BAI_VIET";
            DataTable table = BV_DM_TRANG_THAI_BAI_VIET.GetTableAll();
            functions.fill_DropdownList(dropd_status, table, 0, 1);

            string sql_news_type = @"select types_id,name from BV_NEWS_TYPE where types_id not in (5) and deleted is null";
            DataTable table_datas = SQLConnectWeb.GetData(sql_news_type);
            functions.fill_DropdownList(drop_news_type, table_datas, 0, 1);

            if (Request.QueryString["id"] != null)
            {
                string sql = @"select a.*,b.id as status_id,c.name
                                        from BV_DM_CHU_DE_BV a 
                                        inner join BV_DM_TRANG_THAI_BAI_VIET b on a.status = b.id
                                        inner join BV_NEWS_TYPE c on c.types_id =  a.types_id
                                        where a.chu_de_id =@id";

                DataTable table_data = SQLConnectWeb.GetData(sql, "@id", Request.QueryString["id"]);
                txt_sort.Text = table_data.Rows[0]["sort"].ToString();
                txt_title.Text = table_data.Rows[0]["title"].ToString();
                ASPxHtmlEditor1.Html = table_data.Rows[0]["description"].ToString();
                functions.selectedDropdown(dropd_status, table_data.Rows[0]["status"].ToString());
                functions.selectedDropdown(drop_news_type, table_data.Rows[0]["types_id"].ToString());
                if (Request.QueryString["types_id"] != null && Request.QueryString["types_id"] != "")
                {
                    drop_news_type.Enabled = false;
                    dropd_status.Enabled = false;
                }
            }
            else
            {

                if (Request.QueryString["types_id"] != null && Request.QueryString["types_id"] != "")
                {
                    functions.selectedDropdown(drop_news_type, Request.QueryString["types_id"]);
                    functions.selectedDropdown(dropd_status, "1");
                    drop_news_type.Enabled = false;
                    dropd_status.Enabled = false;
                }
                else
                {
                    functions.selectedDropdown(drop_news_type, "1");
                    functions.selectedDropdown(dropd_status, "1");
                }
            }
            }
           catch
            {}
        }
        
        protected void btn_create_new_subject_Click(object sender, EventArgs e)
        {
            //String sql = "INSERT INTO BV_DM_CHU_DE_BV (TITLE,VISIBLE_BIT,SORT,STATUS,DESCRIPTION,CREATED_DATE,CREATED_BY) VALUES(@V_TITLE,@V_VISIBLE_BIT,@V_SORT,@V_STATUS,@V_DESCRIPTION,@V_CREATED_DATE,@V_CREATED_BY)";
            
            //DataTable table = (DataTable)Session["ThanhVien"];

            try
            {
                //Database.ExecuteNonQuery(sql,
                //                        "@V_TITLE",txt_title.Text,
                //                        "@V_VISIBLE_BIT", 'Y',
                //                        "@V_SORT", txt_sort.Text,
                //                        "@V_STATUS",dropd_status.SelectedValue,
                //                        "@V_DESCRIPTION", txt_description.Text,
                //                        "@V_CREATED_DATE", functions.GetStringDatetime(),
                //                        "@V_CREATED_BY", table.Rows[0]["mem_id"]);
                int bv = 0;
                if (Request.QueryString["id"] != null)
                {
                    String sql = "update BV_DM_CHU_DE_BV set types_id=@types_id,title=@title,sort=@sort,status=@status,description=@description,edited_date=@edited_date,edited_by=@edited_by where chu_de_id=@id";
                    bv= SQLConnectWeb.ExecuteNonQuery(sql,
                                            "@types_id",drop_news_type.SelectedValue,
                                            "@title", txt_title.Text,
                                            "@sort", txt_sort.Text,
                                            "@status", dropd_status.SelectedValue,
                                            "@description", ASPxHtmlEditor1.Html.Replace("'", ""),
                                            "@edited_date", functions.GetStringDatetime(),
                                            "@edited_by", functions.LoginMemID(this),
                                            "@id", Request.QueryString["id"]);

                    if (bv != 0)
                        lbl_error.Text = "Chủ đề đã cập nhật thành công";
                    else lbl_error.Text = "Chủ đề cập nhật không thành công, vui lòng kiểm tra lại thông tin";
                }else
                {
                    //BV_DM_CHU_DE_BV bv = BV_DM_CHU_DE_BV.Insert_Object(txt_title.Text, "Y", txt_sort.Text, dropd_status.SelectedValue,
                    //      ASPxHtmlEditor1.Html.Replace("'", ""), functions.GetStringDatetime(), functions.LoginMemID(this), "", "");
                    //long nextID;
                    //string max_subject = @"select chu_de_id from BV_DM_CHU_DE_BV where chu_de_id = (select max(chu_de_id) from BV_DM_CHU_DE_BV where types_id=" + drop_news_type.SelectedValue + ")";
                    //DataTable table_max = SQLConnectWeb.GetData(max_subject);
                    //if(table_max.Rows.Count==0) 
                    //    nextID =1;
                    //else
                    //    nextID = (long)table_max.Rows[0]["chu_de_id"]+1;
                    string sql_insert = @"insert into BV_DM_CHU_DE_BV (types_id,title,visible_bit,sort,status,description,created_date,created_by) values (@types_id,@title,@visible_bit,@sort,@status,@description,@created_date,@created_by )";
                    bv=SQLConnectWeb.ExecuteNonQuery(sql_insert,
                        "@types_id", drop_news_type.SelectedValue, "@title", txt_title.Text, "@visible_bit", "Y", "@sort", txt_sort.Text, "@status", dropd_status.SelectedValue, "@description", ASPxHtmlEditor1.Html.Replace("'", ""), "@created_date", functions.GetStringDatetime(), "@created_by", functions.LoginMemID(this));


                    if (bv == 1)
                    {
                        lbl_error.Text = "Chủ đề mới đã được tạo thành công";
                        //ASPxButton1.Visible = false;
                    }
                    else lbl_error.Text = "Chủ đề mới tạo không thành công, vui lòng kiểm tra lại thông tin";

                }
            }
            catch (Exception ex)
            {

                lbl_error.Text = "Không thể tạo chủ đề mới "+ex.ToString();
            }
        }
    }
}