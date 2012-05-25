using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using chiase.Objects;

namespace chiase
{
    public partial class CategoryItems: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
                loadNhomHangHoa();
            }
        }
        protected string GetCaption(string dictionaryID)
        {
            return DictionaryDB.sGetValueLanguage(dictionaryID);


        }

        private void loadNhomHangHoa()
        {
            DataTable table = DM_HANG_HOA_NHOM.GetTableAll();
            string html = "<a href=\"javascript:ddtreemenu.flatten('treemenu1', 'expand')\">Mở rộng tất cả</a> | <a href=\"javascript:ddtreemenu.flatten('treemenu1', 'contact')\">Thu hẹp tất cả</a>" + "\r\n";
            html += " <ul id=\"treemenu1\" class=\"treeview\" rel=\"open\" >" + "\r\n";
            if (table != null && table.Rows.Count > 0)
            {
                html += " <li><a onclick=\"filter(null,null);\"> " + DictionaryDB.sGetValueLanguage("NHH_ID") + " </a>" + "\r\n";
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

