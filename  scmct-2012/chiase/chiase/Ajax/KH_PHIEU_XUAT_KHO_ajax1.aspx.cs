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
    public partial class KH_PHIEU_XUAT_KHO_ajax1 : System.Web.UI.Page
    {
        protected DataProcess s_KH_PHIEU_XUAT_KHO()
        {
            DataProcess KH_PHIEU_XUAT_KHO = new DataProcess("KH_PHIEU_XUAT_KHO");
            KH_PHIEU_XUAT_KHO.data("PXK_ID", Request.QueryString["idkhoachinh"]);
            KH_PHIEU_XUAT_KHO.data("MA_PXK", Request.QueryString["MA_PXK"]);
            KH_PHIEU_XUAT_KHO.data("NGUOI_XUAT", Request.QueryString["NGUOI_XUAT"]);
            KH_PHIEU_XUAT_KHO.data("NGAY_XUAT", Request.QueryString["NGAY_XUAT"]);
            KH_PHIEU_XUAT_KHO.data("NGUOI_CAP_NHAT", Request.QueryString["NGUOI_CAP_NHAT"]);
            KH_PHIEU_XUAT_KHO.data("NGAY_CAP_NHAT", Request.QueryString["NGAY_CAP_NHAT"]);
            KH_PHIEU_XUAT_KHO.data("NGUOI_NHAN", Request.QueryString["NGUOI_NHAN"]);
            KH_PHIEU_XUAT_KHO.data("MEM_ID", Request.QueryString["MEM_ID"]);
            KH_PHIEU_XUAT_KHO.data("KHO_ID", Request.QueryString["KHO_ID"]);
            KH_PHIEU_XUAT_KHO.data("DU_AN_ID", Request.QueryString["DU_AN_ID"]);
            KH_PHIEU_XUAT_KHO.data("LY_DO_XUAT_ID", Request.QueryString["LY_DO_XUAT_ID"]);
            KH_PHIEU_XUAT_KHO.data("CHUNG_TU", Request.QueryString["CHUNG_TU"]);
            KH_PHIEU_XUAT_KHO.data("GHI_CHU", Request.QueryString["GHI_CHU"]);
            KH_PHIEU_XUAT_KHO.data("YEU_CAU_ID", Request.QueryString["YEU_CAU_ID"]);
            return KH_PHIEU_XUAT_KHO;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["do"];
            switch (action)
            {
                case "Luu": SaveKH_PHIEU_XUAT_KHO(); break;
                case "setTimKiem": setTimKiem(); break;
                case "xoa": XoaKH_PHIEU_XUAT_KHO(); break;
                case "TimKiem": TimKiem(); break;
                case "NGUOI_XUATSearch": NGUOI_XUATSearch(); break;
                case "MEM_IDSearch": MEM_IDSearch(); break;
                case "KHO_IDSearch": KHO_IDSearch(); break;
                case "DU_AN_IDSearch": DU_AN_IDSearch(); break;
                case "LY_DO_XUAT_IDSearch": LY_DO_XUAT_IDSearch(); break;
                case "YEU_CAU_IDSearch": YEU_CAU_IDSearch(); break;
            }
        }

        private void NGUOI_XUATSearch()
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
        private void LY_DO_XUAT_IDSearch()
        {
            DataTable table = KH_DM_LY_DO_XUAT_KHO.GetTableAll();
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
        private void XoaKH_PHIEU_XUAT_KHO()
        {
            try
            {
                if (PermissionXuatKho.IsDelete(this))
                {
                    DataProcess process = s_KH_PHIEU_XUAT_KHO();
                    bool ok = process.Delete();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PXK_ID"));
                        return;
                    }
                }
                else
                {
                    Response.Clear();
                    Response.Write(functions.GetValueLanguage("MssgNotPerDelete"));
                }
            }
            catch
            {
            }
            Response.StatusCode = 500;
        }

        private void setTimKiem()
        {
            if (PermissionXuatKho.IsView(this))
            {
                string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                DataTable table = KH_PHIEU_XUAT_KHO.SearchByPXK_ID(idkhoachinh);
                string html = "";
                html += "<root>";
                html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
                DataTable NGUOI_XUAT = ND_THONG_TIN_ND.SearchByID("'" + table.Rows[0]["NGUOI_XUAT"] + "'");
                html += "<data id=\"mkv_NGUOI_XUAT\">" + ((NGUOI_XUAT.Rows.Count > 0) ? NGUOI_XUAT.Rows[0][1] : "") + "</data>";
                DataTable MEM_ID = ND_THONG_TIN_ND.SearchByID("'" + table.Rows[0]["MEM_ID"] + "'");
                html += "<data id=\"mkv_MEM_ID\">" + ((MEM_ID.Rows.Count > 0) ? MEM_ID.Rows[0][1] : "") + "</data>";
                DataTable KHO_ID = KH_DM_KHO.SearchByID("'" + table.Rows[0]["KHO_ID"] + "'");
                html += "<data id=\"mkv_KHO_ID\">" + ((KHO_ID.Rows.Count > 0) ? KHO_ID.Rows[0][1] : "") + "</data>";
                DataTable DU_AN_ID = DA_DU_AN.SearchByID("'" + table.Rows[0]["DU_AN_ID"] + "'");
                html += "<data id=\"mkv_DU_AN_ID\">" + ((DU_AN_ID.Rows.Count > 0) ? DU_AN_ID.Rows[0][1] : "") + "</data>";
                DataTable LY_DO_XUAT_ID = KH_DM_LY_DO_XUAT_KHO.SearchByID("'" + table.Rows[0]["LY_DO_XUAT_ID"] + "'");
                html += "<data id=\"mkv_LY_DO_XUAT_ID\">" + ((LY_DO_XUAT_ID.Rows.Count > 0) ? LY_DO_XUAT_ID.Rows[0][1] : "") + "</data>";
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
                Response.Write(functions.GetValueLanguage("MssgNotPerView"));
                Response.StatusCode = 500;
            }
        }

        private void SaveKH_PHIEU_XUAT_KHO()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_XUAT_KHO();
                if (process.getData("PXK_ID") != null && process.getData("PXK_ID") != "")
                {
                    if (PermissionXuatKho.IsEdit(this))
                    {
                        bool ok = process.Update();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PXK_ID"));
                            return;
                        }
                    }
                    else
                    {

                        Response.Clear();
                        Response.Write(functions.GetValueLanguage("MssgNotPerEdit"));
                    }
                }
                else
                {
                    if (PermissionXuatKho.IsAdd(this))
                    {
                        bool ok = process.Insert();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PXK_ID"));
                            return;
                        }
                    }
                    else
                    {
                        Response.Clear();
                        Response.Write(functions.GetValueLanguage("MssgNotPerAdd"));
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
            if (PermissionXuatKho.IsView(this))
            {
                DataProcess process = s_KH_PHIEU_XUAT_KHO();
                process.Page = Request.QueryString["page"];
                DataTable table = process.Search(@"select STT=row_number() over (order by T.PXK_ID),T.*
                   ,A.NAME NX_NAME
                   ,B.NAME XC_NAME
                   ,C.NAME KH_NAME
                   ,D.MA_DU_AN
                   ,E.NAME LX_NAME
                   ,F.TIEU_DE
                               from KH_PHIEU_XUAT_KHO T
                    left join ND_THONG_TIN_ND  A on T.NGUOI_XUAT=A.ID
                    left join ND_THONG_TIN_ND  B on T.MEM_ID=B.ID
                    left join KH_DM_KHO  C on T.KHO_ID=C.ID
                    left join DA_DU_AN  D on T.DU_AN_ID=D.ID
                    left join KH_DM_LY_DO_XUAT_KHO  E on T.LY_DO_XUAT_ID=E.ID
                    left join YC_YEU_CAU  F on T.YEU_CAU_ID=F.YEU_CAU_ID
                where " + process.sWhere());
                bool isDelete = PermissionXuatKho.IsDelete(this);
                bool isEdit = PermissionXuatKho.IsEdit(this);
                string html = "";
                //html += process.Paging();
                html += "<table class='jtable' id=\"gridTable\">";
                html += "<tr>";
                if (isDelete) html += "<th></th>";
                html += "<th>STT</th>";
                html += "<th>" + functions.GetValueLanguage("MA_PXK") + "</th>";
                html += "<th>" + functions.GetValueLanguage("NGUOI_XUAT") + "</th>";
                html += "<th>" + functions.GetValueLanguage("NGAY_XUAT") + "</th>";
                html += "<th>" + functions.GetValueLanguage("NGUOI_NHAN") + "</th>";
                html += "<th>" + functions.GetValueLanguage("MEM_ID_PXK") + "</th>";
                html += "<th>" + functions.GetValueLanguage("KHO_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("DU_AN_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("LY_DO_XUAT_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("CHUNG_TU") + "</th>";
                html += "<th>" + functions.GetValueLanguage("GHI_CHU") + "</th>";
                html += "<th>" + functions.GetValueLanguage("YEU_CAU_ID") + "</th>";
                html += "</tr>";
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        string style = null;
                        DataRow r = null;
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            r = table.Rows[i];
                            style = " style='cursor:pointer;' onclick=\"openPhieu('" + r["PXK_ID"] + "') \" title=\"Click ????? xem " + (isEdit ? "ho???c s???a " : "") + "phi???u chuy???n " + r["MA_PXK"] + "\" ";
                            html += "<tr>";
                            if (isDelete) html += "<td><img src=\"images/delete.png\" width=\"20\" height=\"20\" style=\"cursor:pointer\"  onclick=\"xoaontable(this,'" + r["MA_PXK"] + "')\" title=\"X??a phi???u xu???t " + r["MA_PXK"] + "\" /></td>";
                            html += "<td" + style + ">"+ r["stt"] + "</td>";
                            html += "<td" + style + ">"+ r["MA_PXK"] + "</td>";
                            html += "<td" + style + ">"+ r["NX_NAME"] + "</td>";
                            if (r["NGAY_XUAT"].ToString() != "")
                            {
                                html += "<td" + style + ">"+ DateTime.Parse(r["NGAY_XUAT"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                            }
                            else { html += "<td" + style + ">"+ r["NGAY_XUAT"] + "</td>"; }
                            html += "<td" + style + ">"+ r["NGUOI_NHAN"] + "</td>";
                            html += "<td" + style + ">"+ r["XC_NAME"] + "</td>";
                            html += "<td" + style + ">"+ r["KH_NAME"] + "</td>";
                            html += "<td" + style + ">"+ r["MA_DU_AN"] + "</td>";
                            html += "<td" + style + ">"+ r["LX_NAME"] + "</td>";
                            html += "<td" + style + ">"+ r["CHUNG_TU"] + "</td>";
                            html += "<td" + style + ">"+ r["GHI_CHU"] + "</td>";
                            html += "<td" + style + ">"+ r["TIEU_DE"] + "<input mkv='true' id='idkhoachinh' type='hidden' value='" + r["PXK_ID"].ToString() + "'/></td>";
                            html += "</tr>";
                        }
                    }
                }
                html += "</table>";
                html += process.Paging();
                Response.Clear(); 
                Response.Write(html);
            }
            else
            {
                Response.Write("<font color='red'>" + functions.GetValueLanguage("MssgNotPerView") + "</font>");
            }
        }
    }
}


