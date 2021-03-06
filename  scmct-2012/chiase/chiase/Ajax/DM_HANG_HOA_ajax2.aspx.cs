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
using chiase.Objects;
using DK2C.DataAccess.Web;

namespace chiase
{
    public partial class DM_HANG_HOA_ajax2 : System.Web.UI.Page
    {
        protected DataProcess s_DM_HANG_HOA()
        {
            DataProcess DM_HANG_HOA = new DataProcess("DM_HANG_HOA");
            DM_HANG_HOA.data("ID", Request.QueryString["idkhoachinh"]);
            DM_HANG_HOA.data("MA_HH", Request.QueryString["MA_HH"]);
            DM_HANG_HOA.data("NAME", Request.QueryString["NAME"]);
            DM_HANG_HOA.data("NHH_ID", Request.QueryString["NHH_ID"]);
            DM_HANG_HOA.data("MO_TA", Request.QueryString["MO_TA"]);
            DM_HANG_HOA.data("VISIBLE_BIT", Request.QueryString["VISIBLE_BIT"]);
            return DM_HANG_HOA;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["do"];
            switch (action)
            {
                case "luuTable": LuuTable_DM_HANG_HOA(); break;
                case "xoa": Xoa_DM_HANG_HOA(); break;
                case "TimKiem": TimKiem(); break;
                case "NHH_IDSearch": NHH_IDSearch(); break;
                case "loadNhomHH": loadNhomHangHoa(); break;
                case "getHH": getHH(); break;

            }
        }
        private void getHH()
        {
            string sql = @"SELECT HH.ID,HH.MA_HH,HH.[NAME],HH.NHH_ID,NHH.[NAME] NHH_NAME
                      FROM DM_HANG_HOA HH                    
                    LEFT JOIN DM_HANG_HOA_NHOM NHH ON NHH.ID=HH.NHH_ID
                    WHERE HH.ID='" + Request.QueryString["HH_ID"] + "'";

            DataTable dt = SQLConnectWeb.GetTable(sql);
            Response.Clear();
            string rs = "<HH_NAM>{0}</HH_NAME><NHH_ID>{1}</NHH_ID><NHH_NAME>{2}</NHH_NAME>";
            if (dt != null && dt.Rows.Count > 0)
                Response.Write(string.Format(rs, dt.Rows[0]["NAME"], dt.Rows[0]["NHH_ID"], dt.Rows[0]["NHH_NAME"]));
            else
                Response.Write(string.Format(rs, "", "", ""));
        }
        private void loadNhomHangHoa()
        {
            DataTable table = DM_HANG_HOA_NHOM.GetTableAll();
            string html = "<a href=\"javascript:ddtreemenu.flatten('treemenu1', 'expand')\">M??? r???ng</a> | <a href=\"javascript:ddtreemenu.flatten('treemenu1', 'contact')\">Thu h???p</a>" + "\r\n";
            html += " <ul id=\"treemenu1\" class=\"treeview\">" + "\r\n";          
            if (table != null && table.Rows.Count > 0)
            {
                html += " <li><a onclick=\"filter(-1,null);\"> " + functions.GetValueLanguage("NHH_ID") + " </a>" + "\r\n";
                DataRow[] roots = table.Select(DM_HANG_HOA_NHOM.cl_PARENT_ID + " IS NULL");
                if (roots.Length > 0)
                {
                    html += "<ul>" + "\r\n";
                    foreach (DataRow r in roots)
                    {
                        html += " <li><a onclick=\"filter(" + r[DM_HANG_HOA_NHOM.cl_ID] + ",\"" + r[DM_HANG_HOA_NHOM.cl_NAME] + "\");\"> " + r[DM_HANG_HOA_NHOM.cl_NAME] + " </a>" + "\r\n";
                        html += "</li>";

                    }
                    html += "</ul>" + "\r\n";
                }
                html += "</li>" + "\r\n";
            }
            html += "</ul>" + "\r\n"
              + " <script type=\"text/javascript\">" + "\r\n"
              + "                     ddtreemenu.createTree(\"treemenu1\", true) // n???u b???n mu???n khi load trang, menu ??? d???ng thu g???n th?? thay TRUE th??nh FALSE" + "\r\n"
              + "</script>" + "\r\n";
            Response.Clear();
            Response.Write(html);
        }

        private void NHH_IDSearch()
        {
            DataTable table = DM_HANG_HOA_NHOM.GetTableAll();
            string html = "";
            if (table != null)
            {
                //if (table.Rows.Count > 0)
                //{
                //    for (int i = 0; i < table.Rows.Count; i++)
                //    {

                //        html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                //    }
                //}
                DataRow[] roots = table.Select(DM_HANG_HOA_NHOM.cl_PARENT_ID + " IS NULL");
                foreach (DataRow r in roots)
                {
                    html += r[DM_HANG_HOA_NHOM.cl_NAME].ToString() + "|" + r[DM_HANG_HOA_NHOM.cl_ID].ToString() + Environment.NewLine;
                    html += NHH_IDSearchChild(table, r[DM_HANG_HOA_NHOM.cl_ID]);
                    i -= step;
                }
            }
            Response.Clear(); Response.Write(html);
        }
        int i = 0;
        int step = 20;
        private string NHH_IDSearchChild(DataTable table, object parentsid)
        {
            i += step;
          
            string html = "";
            DataRow[] rows = table.Select(DM_HANG_HOA_NHOM.cl_PARENT_ID + "=" + parentsid);
            foreach (DataRow r in rows)
            {


                html += "<span style=\"margin-left:"+i+"px\">"+ r[DM_HANG_HOA_NHOM.cl_NAME].ToString() +"</span>"+ "|" + r[DM_HANG_HOA_NHOM.cl_ID].ToString() + Environment.NewLine;
                html += NHH_IDSearchChild(table, r[DM_HANG_HOA_NHOM.cl_ID]);
                i -= step;
            }
            return html;
        }
        private void Xoa_DM_HANG_HOA()
        {
            try
            {
                DataProcess process = s_DM_HANG_HOA();
                bool ok = process.Delete();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("ID"));
                    return;
                }
            }
            catch
            {
            }
            Response.StatusCode = 500;
        }

        private void LuuTable_DM_HANG_HOA()
        {
            try
            {
                DataProcess process = s_DM_HANG_HOA();
                if (process.getData("ID") != null && process.getData("ID") != "")
                {
                    bool ok = process.Update();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("ID"));
                        return;
                    }
                }
                else
                {
                    bool ok = process.Insert();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("ID"));
                        return;
                    }
                }
            }
            catch
            {
            }
            Response.StatusCode = 500;
        }
        private void TimKiem()
        {
            string paging = "";
            string html = "";
            html += "<table class='jtable' id=\"gridTable\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th></th>";
            html += "<th>" + functions.GetValueLanguage("MA_HH") + "</th>";
            html += "<th>" + functions.GetValueLanguage("NAME") + "</th>";
            html += "<th>" + functions.GetValueLanguage("NHH_ID") + "</th>";
            html += "<th>" + functions.GetValueLanguage("MO_TA") + "</th>";
            html += "<th></th>";
            html += "</tr>";
            bool add = PermissionDMHangHoa.IsAdd(this);
            bool search = PermissionDMHangHoa.IsView(this);
            if (search)
            {
                DataProcess process = s_DM_HANG_HOA();
                process.Page = Request.QueryString["page"];
                process.NumberRow = "50";
                DataTable table = process.Search(@"select STT=row_number() over (order by T.ID),T.*
                   ,A.NAME NHH_NAME
                               from DM_HANG_HOA T
                    left join DM_HANG_HOA_NHOM  A on T.NHH_ID=A.ID
          where " + process.sWhere());
                paging = process.Paging();
                //html += paging;
                if (table.Rows.Count > 0)
                {
                    bool delete = PermissionDMHangHoa.IsDelete(this);
                    bool edit = PermissionDMHangHoa.IsEdit(this);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr>";
                        html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                        html += "<td> <a id=\"xoaRow\" style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + delete.ToString().ToLower() + ");\" onfocus=\"chuyendong(this);\">X??a</td>";
                        html += "<td><input mkv='true' id='MA_HH' type='text' value='" + table.Rows[i]["MA_HH"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input mkv='true' id='NAME' type='text' value='" + table.Rows[i]["NAME"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input mkv='true' id='NHH_ID' type='hidden' value='" + table.Rows[i]["NHH_ID"] + "'/><input mkv='true' id='mkv_NHH_ID' type='text' value='" + table.Rows[i]["NHH_NAME"] + "' onfocus='NHH_IDSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input mkv='true' id='MO_TA' type='text' value='" + table.Rows[i]["MO_TA"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["ID"] + "'/></td>";
                        html += "</tr>";
                    }
                }
            }
            if (add)
            {
                html += "<tr>";
                html += "<td>&nbsp</td>";
                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + functions.GetValueLanguage("delete") + "</td>";
                html += "<td><input mkv='true' id='MA_HH' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='NAME' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='NHH_ID' type='hidden' value=''/><input mkv='true' id='mkv_NHH_ID' type='text' value='' onfocus='NHH_IDSearch(this);' class=\"down_select\" style='width:90%'/></td>";
                html += "<td><input mkv='true' id='MO_TA' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                html += "</tr>";
            }
            html += "<tr><td></td><td colspan='6'>" + (add ? "" : "<font color='red'>" + functions.GetValueLanguage("MssgNotPerAdd") + "</font>") + "</td></tr>";
            html += "</table>";
            if (!search)
                html += "<font color='red'>" + functions.GetValueLanguage("MssgNotPerView") + "</font>";
            else
                html += paging;
            Response.Clear();
            Response.Write(html);
        }
    }
}


