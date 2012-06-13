using System;
using System.Data;
using System.Web.UI;
using chiase.Objects;



namespace chiase
{
    public partial class categoryitems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check LogIn session
                functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

                Page.DataBind();
                loadNhomHangHoa();
                Session["current_link"] = "<a  href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a  href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a  href='categoryitems.aspx' title='Danh mục hàng hóa'>Danh mục hàng hóa</a>";

                Session["current_link"] = "<a  href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a  href='admin.aspx' title='Quản trị'>Quản trị</a> >> <a  href='manageofreceiver.aspx' title='Nhập kho'>Nhập kho</a>";
               


            }
        }
        protected string GetCaption(string dictionaryID)
        {
            return functions.GetValueLanguage(dictionaryID);


        }
        protected bool IsView
        {
            get
            {
                return PermissionDMHangHoa.IsView(this);
            }
        }
        protected bool IsAdd
        {
            get
            {
                return PermissionDMHangHoa.IsAdd(this);
            }
        }
        protected bool IsEdit
        {
            get
            {
                return PermissionDMHangHoa.IsEdit(this);
            }
        }


        private void loadNhomHangHoa()
        {
            DataTable table = DM_HANG_HOA_NHOM.GetTableAll();
            string html = "<a href=\"javascript:ddtreemenu.flatten('treemenu1', 'expand')\">Mở rộng tất cả</a> | <a href=\"javascript:ddtreemenu.flatten('treemenu1', 'contact')\">Thu hẹp tất cả</a>" + "\r\n";
            html += " <ul id=\"treemenu1\" class=\"treeview\" rel=\"open\" >" + "\r\n";
            if (table != null && table.Rows.Count > 0)
            {
                html += " <li><a onclick=\"filter(null,null);\"> " + functions.GetValueLanguage("NHH_ID") + " </a>" + "\r\n";
                DataRow[] roots = table.Select(DM_HANG_HOA_NHOM.cl_PARENT_ID + " IS NULL");
                if (roots.Length > 0)
                {
                    html += "<ul>" + "\r\n";
                    foreach (DataRow r in roots)
                    {
                        html += " <li><a onclick=\"filter(" + r[DM_HANG_HOA_NHOM.cl_ID] + ",'" + r[DM_HANG_HOA_NHOM.cl_NAME] + "');\"> " + r[DM_HANG_HOA_NHOM.cl_NAME] + " </a>" + "\r\n";
                        html += loadNhomHangHoaChild(table, r[DM_HANG_HOA_NHOM.cl_ID]);
                        html += "</li>";

                    }
                    html += "</ul>" + "\r\n";
                }
                html += "</li>" + "\r\n";
            }
            html += "</ul>" + "\r\n"
              + " <script type=\"text/javascript\">" + "\r\n"
              + "                     ddtreemenu.createTree(\"treemenu1\", false) // nếu bạn muốn khi load trang, menu ở dạng thu gọn thì thay TRUE thành FALSE" + "\r\n"
              + "</script>" + "\r\n";

            divtree.InnerHtml = html;
            //Response.Clear();
            //Response.Write(html);
        }
        private string loadNhomHangHoaChild(DataTable table, object parentID)
        {
            string html = "";
            DataRow[] rows = table.Select(DM_HANG_HOA_NHOM.cl_PARENT_ID + "=" + parentID);
            if (rows.Length > 0)
            {
                html += "<ul>" + "\r\n";
                foreach (DataRow r in rows)
                {
                    html += " <li><a onclick=\"filter(" + r[DM_HANG_HOA_NHOM.cl_ID] + ",'" + r[DM_HANG_HOA_NHOM.cl_NAME] + "');\"> " + r[DM_HANG_HOA_NHOM.cl_NAME] + " </a>" + "\r\n";
                    html += loadNhomHangHoaChild(table, r[DM_HANG_HOA_NHOM.cl_ID]);
                    html += "</li>";
                }
                html += "</ul>" + "\r\n";
            }
            return html;
        }
    }
}