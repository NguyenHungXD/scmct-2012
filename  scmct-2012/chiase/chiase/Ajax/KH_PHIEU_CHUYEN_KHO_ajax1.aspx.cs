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
namespace chiase
{
    public partial class KH_PHIEU_CHUYEN_KHO_ajax1 : System.Web.UI.Page
    {

        protected DataProcess s_KH_PHIEU_CHUYEN_KHO()
        {
            DataProcess KH_PHIEU_CHUYEN_KHO = new DataProcess("KH_PHIEU_CHUYEN_KHO");
            KH_PHIEU_CHUYEN_KHO.data("PCK_ID", Request.QueryString["idkhoachinh"]);
            KH_PHIEU_CHUYEN_KHO.data("MA_PCK", Request.QueryString["MA_PCK"]);
            KH_PHIEU_CHUYEN_KHO.data("NGUOI_CAP_NHAT", Request.QueryString["NGUOI_CAP_NHAT"]);
            KH_PHIEU_CHUYEN_KHO.data("NGAY_CAP_NHAT", Request.QueryString["NGAY_CAP_NHAT"]);
            KH_PHIEU_CHUYEN_KHO.data("NGUOI_CHUYEN", Request.QueryString["NGUOI_CHUYEN"]);
            KH_PHIEU_CHUYEN_KHO.data("NGAY_CHUYEN", Request.QueryString["NGAY_CHUYEN"]);
            KH_PHIEU_CHUYEN_KHO.data("KHO_XUAT_ID", Request.QueryString["KHO_XUAT_ID"]);
            KH_PHIEU_CHUYEN_KHO.data("KHO_NHAP_ID", Request.QueryString["KHO_NHAP_ID"]);
            KH_PHIEU_CHUYEN_KHO.data("DU_AN_ID", Request.QueryString["DU_AN_ID"]);
            KH_PHIEU_CHUYEN_KHO.data("GHI_CHU", Request.QueryString["GHI_CHU"]);
            return KH_PHIEU_CHUYEN_KHO;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["do"];
            switch (action)
            {
                case "Luu": SaveKH_PHIEU_CHUYEN_KHO(); break;
                case "setTimKiem": setTimKiem(); break;
                case "xoa": XoaKH_PHIEU_CHUYEN_KHO(); break;
                case "TimKiem": TimKiem(); break;
                case "NGUOI_CHUYENSearch": NGUOI_CHUYENSearch(); break;
                case "KHO_XUAT_IDSearch": KHO_XUAT_IDSearch(); break;
                case "KHO_NHAP_IDSearch": KHO_NHAP_IDSearch(); break;
                case "DU_AN_IDSearch": DU_AN_IDSearch(); break;
            }
        }

        private void NGUOI_CHUYENSearch()
        {
            DataTable table = ND_THONG_TIN_ND.GetTableAll();
            string html = "";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {

                        html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                    }
                }
            }
            Response.Clear(); Response.Write(html);
        }
        private void KHO_XUAT_IDSearch()
        {
            DataTable table = KH_DM_KHO.GetTableAll();
            string html = "";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {

                        html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                    }
                }
            }
            Response.Clear(); Response.Write(html);
        }
        private void KHO_NHAP_IDSearch()
        {
            DataTable table = KH_DM_KHO.GetTableAll();
            string html = "";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {

                        html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                    }
                }
            }
            Response.Clear(); Response.Write(html);
        }
        private void DU_AN_IDSearch()
        {
            DataTable table = DA_DU_AN.GetTableAll();
            string html = "";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {

                        html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                    }
                }
            }
            Response.Clear(); Response.Write(html);
        }
        private void XoaKH_PHIEU_CHUYEN_KHO()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_CHUYEN_KHO();
                bool ok = process.Delete();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("PCK_ID"));
                    return;
                }
            }
            catch
            {
            }
            Response.StatusCode = 500;
        }

        private void setTimKiem()
        {
            if (UserLogin.HavePermision(this, "KH_PHIEU_CHUYEN_KHO_Search"))
            {
                string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                DataTable table = KH_PHIEU_CHUYEN_KHO.SearchByPCK_ID(idkhoachinh);
                string html = "";
                html += "<root>";
                html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
                DataTable NGUOI_CHUYEN = ND_THONG_TIN_ND.SearchByID("'" + table.Rows[0]["NGUOI_CHUYEN"] + "'");
                html += "<data id=\"mkv_NGUOI_CHUYEN\">" + ((NGUOI_CHUYEN.Rows.Count > 0) ? NGUOI_CHUYEN.Rows[0][1] : "") + "</data>";
                DataTable KHO_XUAT_ID = KH_DM_KHO.SearchByID("'" + table.Rows[0]["KHO_XUAT_ID"] + "'");
                html += "<data id=\"mkv_KHO_XUAT_ID\">" + ((KHO_XUAT_ID.Rows.Count > 0) ? KHO_XUAT_ID.Rows[0][1] : "") + "</data>";
                DataTable KHO_NHAP_ID = KH_DM_KHO.SearchByID("'" + table.Rows[0]["KHO_NHAP_ID"] + "'");
                html += "<data id=\"mkv_KHO_NHAP_ID\">" + ((KHO_NHAP_ID.Rows.Count > 0) ? KHO_NHAP_ID.Rows[0][1] : "") + "</data>";
                DataTable DU_AN_ID = DA_DU_AN.SearchByID("'" + table.Rows[0]["DU_AN_ID"] + "'");
                html += "<data id=\"mkv_DU_AN_ID\">" + ((DU_AN_ID.Rows.Count > 0) ? DU_AN_ID.Rows[0][1] : "") + "</data>";
                html += Environment.NewLine;
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {

                        for (int y = 0; y < table.Columns.Count; y++)
                        {
                            try
                            {
                                html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                            }
                            catch (Exception)
                            {
                                html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                            }
                            html += Environment.NewLine;
                        }
                    }
                }
                html += "</root>";
                Response.Clear();
                Response.Write(html);
            }
            else
            {
                Response.Write("Bạn không có quyền xem dữ liệu");
                Response.StatusCode = 500;
            }
        }

        private void SaveKH_PHIEU_CHUYEN_KHO()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_CHUYEN_KHO();
                if (process.getData("PCK_ID") != null && process.getData("PCK_ID") != "")
                {
                    bool ok = process.Update();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PCK_ID"));
                        return;
                    }
                }
                else
                {
                    bool ok = process.Insert();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PCK_ID"));
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
            if (UserLogin.HavePermision(this, "KH_PHIEU_CHUYEN_KHO_Search"))
            {
                DataProcess process = s_KH_PHIEU_CHUYEN_KHO();
                process.Page = Request.QueryString["page"];
                DataTable table = process.Search(@"select STT=row_number() over (order by T.PCK_ID),T.*
                   ,A.NAME
                   ,B.NAME
                   ,C.NAME
                   ,D.MA_DU_AN
                               from KH_PHIEU_CHUYEN_KHO T
                    left join ND_THONG_TIN_ND  A on T.NGUOI_CHUYEN=A.ID
                    left join KH_DM_KHO  B on T.KHO_XUAT_ID=B.ID
                    left join KH_DM_KHO  C on T.KHO_NHAP_ID=C.ID
                    left join DA_DU_AN  D on T.DU_AN_ID=D.ID
          where " + process.sWhere());
                string html = "";
                html += process.Paging();
                html += "<table class='jtable' id=\"gridTable\">";
                html += "<tr>";
                html += "<th>STT</th>";
                html += "<th>" + DictionaryDB.sGetValueLanguage("MA_PCK") + "</th>";
                html += "<th>" + DictionaryDB.sGetValueLanguage("NGUOI_CHUYEN") + "</th>";
                html += "<th>" + DictionaryDB.sGetValueLanguage("NGAY_CHUYEN") + "</th>";
                html += "<th>" + DictionaryDB.sGetValueLanguage("KHO_XUAT_ID") + "</th>";
                html += "<th>" + DictionaryDB.sGetValueLanguage("KHO_NHAP_ID") + "</th>";
                html += "<th>" + DictionaryDB.sGetValueLanguage("DU_AN_ID") + "</th>";
                html += "<th>" + DictionaryDB.sGetValueLanguage("GHI_CHU") + "</th>";
                html += "</tr>";
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            html += "<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["PCK_ID"].ToString() + "')\">";
                            html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["MA_PCK"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            if (table.Rows[i]["NGAY_CHUYEN"].ToString() != "")
                            {
                                html += "<td>" + DateTime.Parse(table.Rows[i]["NGAY_CHUYEN"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                            }
                            else { html += "<td>" + table.Rows[i]["NGAY_CHUYEN"].ToString() + "</td>"; }
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["MA_DU_AN"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["GHI_CHU"].ToString() + "</td>";
                            html += "</tr>";
                        }
                    }
                }
                html += "</table>";
                html += process.Paging();
                Response.Clear(); Response.Write(html);
            }
            else
            {
                Response.Write("Bạn không có quyền xem dữ liệu.");
            }
        }
    }
}


