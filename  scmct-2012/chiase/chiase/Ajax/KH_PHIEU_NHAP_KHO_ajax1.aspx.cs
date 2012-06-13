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
    public partial class KH_PHIEU_NHAP_KHO_ajax1 : System.Web.UI.Page
    {
        protected DataProcess s_KH_PHIEU_NHAP_KHO()
        {
            DataProcess KH_PHIEU_NHAP_KHO = new DataProcess("KH_PHIEU_NHAP_KHO");
            KH_PHIEU_NHAP_KHO.data("PNK_ID", Request.QueryString["idkhoachinh"]);
            KH_PHIEU_NHAP_KHO.data("MA_PNK", Request.QueryString["MA_PNK"]);
            KH_PHIEU_NHAP_KHO.data("NGUOI_NHAP", Request.QueryString["NGUOI_NHAP"]);
            KH_PHIEU_NHAP_KHO.data("NGAY_NHAP", Request.QueryString["NGAY_NHAP"]);
            KH_PHIEU_NHAP_KHO.data("NGUOI_CAP_NHAT", Request.QueryString["NGUOI_CAP_NHAT"]);
            KH_PHIEU_NHAP_KHO.data("NGAY_CAP_NHAT", Request.QueryString["NGAY_CAP_NHAT"]);
            KH_PHIEU_NHAP_KHO.data("MEM_ID", Request.QueryString["MEM_ID"]);
            KH_PHIEU_NHAP_KHO.data("KHO_ID", Request.QueryString["KHO_ID"]);
            KH_PHIEU_NHAP_KHO.data("DU_AN_ID", Request.QueryString["DU_AN_ID"]);
            KH_PHIEU_NHAP_KHO.data("LY_DO_NHAP_ID", Request.QueryString["LY_DO_NHAP_ID"]);
            KH_PHIEU_NHAP_KHO.data("YEU_CAU_ID", Request.QueryString["YEU_CAU_ID"]);
            KH_PHIEU_NHAP_KHO.data("CHUNG_TU", Request.QueryString["CHUNG_TU"]);
            KH_PHIEU_NHAP_KHO.data("GHI_CHU", Request.QueryString["GHI_CHU"]);
            return KH_PHIEU_NHAP_KHO;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["do"];
            switch (action)
            {
                case "Luu": SaveKH_PHIEU_NHAP_KHO(); break;
                case "setTimKiem": setTimKiem(); break;
                case "xoa": XoaKH_PHIEU_NHAP_KHO(); break;
                case "TimKiem": TimKiem(); break;
                case "NGUOI_NHAPSearch": NGUOI_NHAPSearch(); break;
                case "MEM_IDSearch": MEM_IDSearch(); break;
                case "KHO_IDSearch": KHO_IDSearch(); break;
                case "DU_AN_IDSearch": DU_AN_IDSearch(); break;
                case "LY_DO_NHAP_IDSearch": LY_DO_NHAP_IDSearch(); break;
                case "YEU_CAU_IDSearch": YEU_CAU_IDSearch(); break;
            }
        }

        private void NGUOI_NHAPSearch()
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
        private void MEM_IDSearch()
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
        private void KHO_IDSearch()
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
        private void LY_DO_NHAP_IDSearch()
        {
            DataTable table = KH_DM_LY_DO_NHAP_KHO.GetTableAll();
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
        private void YEU_CAU_IDSearch()
        {
            DataTable table = YC_YEU_CAU.GetTableAll();
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
        private void XoaKH_PHIEU_NHAP_KHO()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_NHAP_KHO();
                bool ok = process.Delete();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("PNK_ID"));
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
            if (PermissionNhapKho.IsView(this))
            {
                string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                DataTable table = KH_PHIEU_NHAP_KHO.SearchByPNK_ID(idkhoachinh);
                string html = "";
                html += "<root>";
                html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
                DataTable NGUOI_NHAP = ND_THONG_TIN_ND.SearchByID("'" + table.Rows[0]["NGUOI_NHAP"] + "'");
                html += "<data id=\"mkv_NGUOI_NHAP\">" + ((NGUOI_NHAP.Rows.Count > 0) ? NGUOI_NHAP.Rows[0][1] : "") + "</data>";
                DataTable NGUOI_CAP_NHAT = ND_THONG_TIN_ND.SearchByID("'" + table.Rows[0]["NGUOI_CAP_NHAT"] + "'");
                html += "<data id=\"mkv_NGUOI_CAP_NHAT\">" + ((NGUOI_CAP_NHAT.Rows.Count > 0) ? NGUOI_CAP_NHAT.Rows[0][1] : "") + "</data>";
                DataTable MEM_ID = ND_THONG_TIN_ND.SearchByID("'" + table.Rows[0]["MEM_ID"] + "'");
                html += "<data id=\"mkv_MEM_ID\">" + ((MEM_ID.Rows.Count > 0) ? MEM_ID.Rows[0][1] : "") + "</data>";
                DataTable KHO_ID = KH_DM_KHO.SearchByID("'" + table.Rows[0]["KHO_ID"] + "'");
                html += "<data id=\"mkv_KHO_ID\">" + ((KHO_ID.Rows.Count > 0) ? KHO_ID.Rows[0][1] : "") + "</data>";
                DataTable DU_AN_ID = DA_DU_AN.SearchByID("'" + table.Rows[0]["DU_AN_ID"] + "'");
                html += "<data id=\"mkv_DU_AN_ID\">" + ((DU_AN_ID.Rows.Count > 0) ? DU_AN_ID.Rows[0][1] : "") + "</data>";
                DataTable LY_DO_NHAP_ID = KH_DM_LY_DO_NHAP_KHO.SearchByID("'" + table.Rows[0]["LY_DO_NHAP_ID"] + "'");
                html += "<data id=\"mkv_LY_DO_NHAP_ID\">" + ((LY_DO_NHAP_ID.Rows.Count > 0) ? LY_DO_NHAP_ID.Rows[0][1] : "") + "</data>";
                DataTable YEU_CAU_ID = YC_YEU_CAU.SearchByYEU_CAU_ID("'" + table.Rows[0]["YEU_CAU_ID"] + "'");
                html += "<data id=\"mkv_YEU_CAU_ID\">" + ((YEU_CAU_ID.Rows.Count > 0) ? YEU_CAU_ID.Rows[0][1] : "") + "</data>";
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
                Response.Write("<font color='red'>" + functions.GetValueLanguage("MssgNotPerView") + "</font>");
                Response.StatusCode = 500; 
            }
        }

        private void SaveKH_PHIEU_NHAP_KHO()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_NHAP_KHO();
                if (process.getData("PNK_ID") != null && process.getData("PNK_ID") != "")
                {
                    bool ok = process.Update();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PNK_ID"));
                        return;
                    }
                }
                else
                {
                    bool ok = process.Insert();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PNK_ID"));
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
            if (PermissionNhapKho.IsView(this))
            {
                DataProcess process = s_KH_PHIEU_NHAP_KHO();
                process.Page = Request.QueryString["page"];
                DataTable table = process.Search(@"select STT=row_number() over (order by T.PNK_ID),T.*
                   ,A.NAME NN_NAME
                   ,B.NAME NT_NAME
                   ,C.NAME KHO_NAME
                   ,D.MA_DU_AN
                   ,E.NAME LN_NAME
                   ,F.TIEU_DE
                               from KH_PHIEU_NHAP_KHO T
                    left join ND_THONG_TIN_ND  A on T.NGUOI_NHAP=A.ID
                    left join ND_THONG_TIN_ND  B on T.MEM_ID=B.ID
                    left join KH_DM_KHO  C on T.KHO_ID=C.ID
                    left join DA_DU_AN  D on T.DU_AN_ID=D.ID
                    left join KH_DM_LY_DO_NHAP_KHO  E on T.LY_DO_NHAP_ID=E.ID
                    left join YC_YEU_CAU  F on T.YEU_CAU_ID=F.YEU_CAU_ID
                    where " + process.sWhere());
                string html = "";
                //html += process.Paging();
                html += "<table class='jtable' id=\"gridTable\">";
                html += "<tr>";
                html += "<th>STT</th>";
                html += "<th>" + functions.GetValueLanguage("MA_PNK") + "</th>";
                html += "<th>" + functions.GetValueLanguage("NGUOI_NHAP") + "</th>";
                html += "<th>" + functions.GetValueLanguage("NGAY_NHAP") + "</th>";
                html += "<th>" + functions.GetValueLanguage("MEM_ID_PNK") + "</th>";
                html += "<th>" + functions.GetValueLanguage("KHO_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("DU_AN_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("LY_DO_NHAP_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("YEU_CAU_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("CHUNG_TU") + "</th>";
                html += "<th>" + functions.GetValueLanguage("GHI_CHU") + "</th>";
                html += "</tr>";
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            html += "<tr style='cursor:pointer;' onclick=\"openPhieu('" + table.Rows[i]["PNK_ID"].ToString() + "')\">";
                            html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["MA_PNK"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NN_NAME"].ToString() + "</td>";
                            if (table.Rows[i]["NGAY_NHAP"].ToString() != "")
                            {
                                html += "<td>" + DateTime.Parse(table.Rows[i]["NGAY_NHAP"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                            }
                            else { html += "<td>" + table.Rows[i]["NGAY_NHAP"].ToString() + "</td>"; }
                            html += "<td>" + table.Rows[i]["NT_NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["KHO_NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["MA_DU_AN"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["LN_NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["TIEU_DE"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["CHUNG_TU"].ToString() + "</td>";
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
                Response.Write("<font color='red'>" + functions.GetValueLanguage("MssgNotPerView") + "</font>");
            }
        }
    }
}
 
 
