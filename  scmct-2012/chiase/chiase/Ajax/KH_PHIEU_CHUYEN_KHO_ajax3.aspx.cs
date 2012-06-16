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
    public partial class KH_PHIEU_CHUYEN_KHO_ajax3 : System.Web.UI.Page
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
        protected DataProcess s_KH_PHIEU_CHUYEN_KHO_CT(bool isLoad)
        {
            DataProcess KH_PHIEU_CHUYEN_KHO_CT = new DataProcess("KH_PHIEU_CHUYEN_KHO_CT");
            KH_PHIEU_CHUYEN_KHO_CT.data("PCK_CT_ID", Request.QueryString["idkhoachinh"]);
            KH_PHIEU_CHUYEN_KHO_CT.data("PCK_ID", Request.QueryString["PCK_ID"]);
            KH_PHIEU_CHUYEN_KHO_CT.data("HH_ID", Request.QueryString["HH_ID"]);
            KH_PHIEU_CHUYEN_KHO_CT.data("SO_LUONG", Request.QueryString["SO_LUONG"]);
            KH_PHIEU_CHUYEN_KHO_CT.data("DON_GIA", Request.QueryString["DON_GIA"]);
            KH_PHIEU_CHUYEN_KHO_CT.data("THANH_TIEN", Request.QueryString["THANH_TIEN"]);
            KH_PHIEU_CHUYEN_KHO_CT.data("GHI_CHU", Request.QueryString["GHI_CHU"]);
            KH_PHIEU_CHUYEN_KHO_CT.data("PNK_CT_ID", Request.QueryString["PNK_CT_ID"]);
            if (isLoad)
            {
                KH_PHIEU_CHUYEN_KHO_CT.data("HH_NAME", Request.QueryString["HH_NAME"]);
                KH_PHIEU_CHUYEN_KHO_CT.data("NHH_ID", Request.QueryString["NHH_ID"]);

            }
            return KH_PHIEU_CHUYEN_KHO_CT;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["do"];
            switch (action)
            {
                case "Luu": SaveKH_PHIEU_CHUYEN_KHO(); break;
                case "TimKiem": TimKiem(); break;
                case "setTimKiem": setTimKiem(); break;
                case "luuTableKH_PHIEU_CHUYEN_KHO_CT": LuuTableKH_PHIEU_CHUYEN_KHO_CT(); break;
                case "loadTableKH_PHIEU_CHUYEN_KHO_CT": loadTableKH_PHIEU_CHUYEN_KHO_CT(); break;
                case "xoa": XoaKH_PHIEU_CHUYEN_KHO(); break;
                case "xoaKH_PHIEU_CHUYEN_KHO_CT": XoaKH_PHIEU_CHUYEN_KHO_CT(); break;
                case "NGUOI_CHUYENSearch": NGUOI_CHUYENSearch(); break;
                case "KHO_XUAT_IDSearch": KHO_XUAT_IDSearch(); break;
                case "KHO_NHAP_IDSearch": KHO_NHAP_IDSearch(); break;
                case "DU_AN_IDSearch": DU_AN_IDSearch(); break;
                case "HH_IDSearch": HH_IDSearch(); break;
                case "PNK_CT_IDSearch": PNK_CT_IDSearch(); break;
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
        private void HH_IDSearch()
        {

         
            string khoID = Request.QueryString["sKHO_ID"];
            string pxct = Request.QueryString["sPCKCT_ID"];
            string where = " where 1=1";
            string where2 = " where 1=1";
            string where3 = "";
            if (!string.IsNullOrEmpty(pxct))
                where3 += " pcct.PCK_CT_ID <> " + pxct;
          
            if (!string.IsNullOrEmpty(khoID))
            {
                where += " AND pn.KHO_ID=" + khoID;
                where2 += " AND pc.kho_nhap_id=" + khoID;
            }

            string sql = string.Format(@"SELECT DISTINCT HH.ID,HH.MA_HH,HH.[NAME],HH.NHH_ID,NHH.[NAME] NHH_NAME
            FROM 
            (
            SELECT pnct.HH_ID, pnct.PNK_CT_ID,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) NGAY_NHAP,
            pn.KHO_ID,pn.DU_AN_ID,N'' GHI_CHU,
            pnct.SO_LUONG -
            ISNULL((SELECT sum (pcct.SO_LUONG)
            FROM KH_PHIEU_CHUYEN_KHO_CT pcct
            WHERE pcct.PNK_CT_ID=pnct.PNK_CT_ID {0}
            ),0)-
            ISNULL((SELECT sum (pxct.SO_LUONG)
            FROM KH_PHIEU_XUAT_KHO_CT pxct
            WHERE pxct.PNK_CT_ID=pnct.PNK_CT_ID 
            ),0) SO_LUONG
            FROM KH_PHIEU_NHAP_KHO_CT pnct
            INNER JOIN KH_PHIEU_NHAP_KHO pn ON pn.PNK_ID = pnct.PNK_ID    
            {1}                        
            UNION ALL
            SELECT pnct.HH_ID, pcct.PNK_CT_ID,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) NGAY_NHAP,
            pn.KHO_ID,pn.DU_AN_ID,N'Chuyển đến',
            SUM (pcct.SO_LUONG) SO_LUONG
            FROM KH_PHIEU_NHAP_KHO pn
            INNER JOIN KH_PHIEU_NHAP_KHO_CT pnct ON pnct.PNK_ID = pn.PNK_ID
            INNER JOIN KH_PHIEU_CHUYEN_KHO_CT pcct ON pnct.PNK_CT_ID=pcct.PNK_CT_ID
            INNER JOIN KH_PHIEU_CHUYEN_KHO pc ON pc.PCK_ID=pcct.PCK_ID
            {2}
            GROUP BY pcct.PNK_CT_ID,pnct.HH_ID, pn.MA_PNK,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) ,
            pn.KHO_ID,pn.DU_AN_ID
            ) abc
            LEFT JOIN  DA_DU_AN da ON da.ID=abc.DU_AN_ID
            LEFT JOIN KH_DM_KHO kh ON kh.ID=abc.KHO_ID
            LEFT JOIN DM_HANG_HOA hh ON hh.ID=abc.HH_ID
            LEFT JOIN DM_HANG_HOA_NHOM NHH ON NHH.ID=HH.NHH_ID 
            GROUP BY abc.HH_ID, abc.PNK_CT_ID,abc.MA_PNK,abc.NGAY_NHAP,da.MA_DU_AN,kh.[NAME],abc.ghi_chu,
            HH.ID,HH.MA_HH,HH.[NAME],HH.NHH_ID,NHH.[NAME]
            HAVING  SUM(abc.SO_LUONG)>0", where3, where, where2);
            //            DataTable table = SQLConnectWeb.GetTable(@"SELECT HH.ID,HH.MA_HH,HH.[NAME],HH.NHH_ID,NHH.[NAME] NHH_NAME
            //                                FROM DM_HANG_HOA HH                    
            //                                LEFT JOIN DM_HANG_HOA_NHOM NHH ON NHH.ID=HH.NHH_ID
            //                                WHERE EXISTS(SELECT TOP 1 PNCT.PNK_CT_ID
            //                                FROM KH_PHIEU_NHAP_KHO_CT PNCT 
            //                                WHERE PNCT.HH_ID=HH.ID)");
            DataTable table = SQLConnectWeb.GetTable(sql);
            string html = "";
            if (table != null && table.Rows.Count > 0)
            {


                int mlmhh = table.Rows[0][DM_HANG_HOA.cl_MA_HH].ToString().Trim().Length;
                int mlnhh = table.Rows[0][DM_HANG_HOA.cl_NAME].ToString().Trim().Length;
                foreach (DataRow r in table.Rows)
                {
                    if (r[DM_HANG_HOA.cl_MA_HH].ToString().Trim().Length > mlmhh)
                        mlmhh = r[DM_HANG_HOA.cl_MA_HH].ToString().Trim().Length;

                    if (r[DM_HANG_HOA.cl_NAME].ToString().Trim().Length > mlnhh)
                        mlnhh = r[DM_HANG_HOA.cl_NAME].ToString().Trim().Length;

                }

                int step = 40;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int l1 = (mlmhh - table.Rows[i][DM_HANG_HOA.cl_MA_HH].ToString().Trim().Length) * 2;
                    int l2 = (mlnhh - table.Rows[i][DM_HANG_HOA.cl_NAME].ToString().Trim().Length) * 2;


                    html += table.Rows[i][DM_HANG_HOA.cl_MA_HH].ToString()
                        + "<span style=\"margin-left:" + (step - l1) + "px\"> - "
                         + "</span >"
                        + "<span style=\"margin-left:" + (step) + "px\">"
                        + table.Rows[i][DM_HANG_HOA.cl_NAME].ToString()
                        + "</span >"
                        + "<span style=\"margin-left:" + (step - l2) + "px\"> - "
                        + "</span >"
                        + "<span style=\"margin-left:" + (step) + "px\">"
                        + table.Rows[i]["NHH_NAME"].ToString()

                        + "</span >"
                        + "|" + table.Rows[i][DM_HANG_HOA.cl_ID].ToString() + Environment.NewLine;
                }

            }
            Response.Clear(); Response.Write(html);
        }
        private void PNK_CT_IDSearch()
        {
            string hhid = Request.QueryString["sHH_ID"];           
            string khoID = Request.QueryString["sKHO_ID"];
            string pxct = Request.QueryString["sPXKCT_ID"];
            string where = " where ";
            string where2 = " where";
            string where3 = "";
            if (!string.IsNullOrEmpty(pxct))
                where3 += " pcct.sPCKCT_ID <> " + pxct;
            if (string.IsNullOrEmpty(hhid))
            {
                where += " 1=-1";
                where2 += " 1=-1";
            }
            else
            {
                where += " PNCT.HH_ID=" + hhid;
                where2 += " PNCT.HH_ID=" + hhid;               
                if (!string.IsNullOrEmpty(khoID))
                {
                    where += " AND pn.KHO_ID=" + khoID;
                    where2 += " AND pc.kho_nhap_id=" + khoID;
                }
            }
            //            string sql = string.Format(@"SELECT pnct.PNK_CT_ID,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) NGAY_NHAP,
            //            kh.[NAME] KHO_NHAP,da.MA_DU_AN, pnct.SO_LUONG
            //            FROM KH_PHIEU_NHAP_KHO_CT pnct
            //            INNER JOIN KH_PHIEU_NHAP_KHO pn ON pn.PNK_ID = pnct.PNK_ID
            //            LEFT JOIN KH_DM_KHO kh ON kh.ID=pn.KHO_ID
            //            LEFT JOIN DA_DU_AN da ON da.ID=pn.DU_AN_ID
            //            {0}", where);
            string sql = string.Format(@"SELECT abc.PNK_CT_ID,abc.MA_PNK,abc.NGAY_NHAP,da.MA_DU_AN,kh.[NAME] KHO_NHAP, SUM(abc.SO_LUONG) SO_LUONG, abc.GHI_CHU
            FROM 
            (
			            SELECT pnct.PNK_CT_ID,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) NGAY_NHAP,
                        pn.KHO_ID,pn.DU_AN_ID,N'' GHI_CHU,
                        pnct.SO_LUONG -
                        ISNULL((SELECT sum (pcct.SO_LUONG)
                            FROM KH_PHIEU_CHUYEN_KHO_CT pcct
                            WHERE pcct.PNK_CT_ID=pnct.PNK_CT_ID  {0}
                            ),0)-
                            ISNULL((SELECT sum (pxct.SO_LUONG)
                            FROM KH_PHIEU_XUAT_KHO_CT pxct
                            WHERE pxct.PNK_CT_ID=pnct.PNK_CT_ID
                            ),0) SO_LUONG
                        FROM KH_PHIEU_NHAP_KHO_CT pnct
                        INNER JOIN KH_PHIEU_NHAP_KHO pn ON pn.PNK_ID = pnct.PNK_ID   
                        {1}       
            UNION ALL
            SELECT pcct.PNK_CT_ID,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) NGAY_NHAP,
            pn.KHO_ID,pn.DU_AN_ID,N'Chuyển đến',
            SUM (pcct.SO_LUONG) SO_LUONG
            FROM KH_PHIEU_NHAP_KHO pn
            INNER JOIN KH_PHIEU_NHAP_KHO_CT pnct ON pnct.PNK_ID = pn.PNK_ID
            INNER JOIN KH_PHIEU_CHUYEN_KHO_CT pcct ON pnct.PNK_CT_ID=pcct.PNK_CT_ID
            INNER JOIN KH_PHIEU_CHUYEN_KHO pc ON pc.PCK_ID=pcct.PCK_ID
            {2}
            GROUP BY pcct.PNK_CT_ID, pn.MA_PNK,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) ,
            pn.KHO_ID,pn.DU_AN_ID
            ) abc
            LEFT JOIN  DA_DU_AN da ON da.ID=abc.DU_AN_ID
            LEFT JOIN KH_DM_KHO kh ON kh.ID=abc.KHO_ID
            GROUP BY abc.PNK_CT_ID,abc.MA_PNK,abc.NGAY_NHAP,da.MA_DU_AN,kh.[NAME],abc.ghi_chu
            HAVING  SUM(abc.SO_LUONG)>0", where3, where, where2);
            DataTable table = SQLConnectWeb.GetTable(sql);
            string html = "";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    int step = 20;
                    for (int i = 0; i < table.Rows.Count; i++)
                    {


                        html += table.Rows[i]["MA_PNK"].ToString()
                            + "<span style=\"margin-left:" + (step) + "px\"> - "
                             + "</span >"
                            + "<span style=\"margin-left:" + (step) + "px\">"
                            + table.Rows[i]["NGAY_NHAP"].ToString()
                            + "</span >"
                            + "<span style=\"margin-left:" + (step) + "px\"> - "
                            + "</span >"
                            + "<span style=\"margin-left:" + (step) + "px\">"
                            + table.Rows[i]["KHO_NHAP"].ToString()

                            + "</span >"
                             + "<span style=\"margin-left:" + (step) + "px\"> - "
                             + "</span >"
                            + "<span style=\"margin-left:" + (step) + "px\">"
                            + table.Rows[i]["MA_DU_AN"].ToString()
                            + "</span >"
                            + "<span style=\"margin-left:" + (step) + "px\"> - "
                             + "</span >"
                             + "<span style=\"margin-left:" + (step) + "px\"" + (table.Rows[i]["GHI_CHU"].ToString() == "" ? "" : "-") + ">"
                            + table.Rows[i]["SO_LUONG"].ToString()
                            + "</span >"
                             + "<span style=\"margin-left:" + (step) + "px\">"
                            + table.Rows[i]["GHI_CHU"].ToString()
                            + "</span >"
                            + "|" + table.Rows[i]["PNK_CT_ID"].ToString() + Environment.NewLine;

                    }
                }
            }
            Response.Clear(); Response.Write(html);
        }
        private void XoaKH_PHIEU_CHUYEN_KHO()
        {
            try
            {
                if (PermissionChuyenKho.IsDelete(this))
                {
                    DataProcess process = s_KH_PHIEU_CHUYEN_KHO();
                    bool ok = process.Delete();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PCK_ID"));
                        return;
                    }
                }
                else
                {
                    Response.Write(functions.GetValueLanguage("MssgNotPerDelete"));
                }
            }
            catch
            {
            }
            Response.StatusCode = 500;
        }
        private void XoaKH_PHIEU_CHUYEN_KHO_CT()
        {
            try
            {
                if (PermissionChuyenKho.IsDelete(this))
                {

                    DataProcess process = s_KH_PHIEU_CHUYEN_KHO_CT(false);
                    bool ok = process.Delete();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PCK_CT_ID"));
                        return;
                    }
                }

                else
                {
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
            if (PermissionChuyenKho.IsView(this))
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
                Response.Write("<font color='red'>" + functions.GetValueLanguage("MssgNotPerView") + "</font>");
                Response.StatusCode = 500;
            }
        }

        private void TimKiem()
        {
            if (PermissionChuyenKho.IsView(this))
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
                html += "<table class='jtable' id=\"tablefind\">";
                html += "<tr>";
                html += "<th>" + functions.GetValueLanguage("PCK_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("MA_PCK") + "</th>";
                html += "<th>" + functions.GetValueLanguage("NGUOI_CHUYEN") + "</th>";
                html += "<th>" + functions.GetValueLanguage("NGAY_CHUYEN") + "</th>";
                html += "<th>" + functions.GetValueLanguage("KHO_XUAT_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("KHO_NHAP_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("DU_AN_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("GHI_CHU") + "</th>";
                html += "</tr>";
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            html += "<tr onclick=\"setControlFind('" + table.Rows[i]["PCK_ID"].ToString() + "')\">";
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
                        html += "</table>";
                        html += process.Paging();
                        Response.Clear(); Response.Write(html);
                        return;
                    }
                }
                else
                {
                    Response.StatusCode = 500;
                }
            }
            else
            {
                Response.Write("<font color='red'>" + functions.GetValueLanguage("MssgNotPerView") + "</font>");
            }
        }

        private void SaveKH_PHIEU_CHUYEN_KHO()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_CHUYEN_KHO();
                if (process.getData("PCK_ID") != null && process.getData("PCK_ID") != "")
                {
                    if (PermissionChuyenKho.IsEdit(this))
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
                        Response.Clear(); Response.Write(functions.GetValueLanguage("MssgNotPerEdit"));
                    }

                }
                else
                {
                    if (PermissionChuyenKho.IsAdd(this))
                    {
                        string mp = functions.NewMaPhieuChuyen();
                        process.data("MA_PCK", mp);
                        bool ok = process.Insert();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PCK_ID"));
                            return;
                        }
                    }
                    else
                    {
                        Response.Clear(); Response.Write(functions.GetValueLanguage("MssgNotPerAdd"));
                    }
                }
            }
            catch
            {
            }
            Response.StatusCode = 500;
        }
        public void LuuTableKH_PHIEU_CHUYEN_KHO_CT()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_CHUYEN_KHO_CT(false);
                if (process.getData("PCK_CT_ID") != null && process.getData("PCK_CT_ID") != "")
                {
                    if (PermissionChuyenKho.IsEdit(this))
                    {
                        bool ok = process.Update();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PCK_CT_ID"));
                            return;
                        }
                    }
                    else
                    {
                        Response.Clear(); Response.Write(functions.GetValueLanguage("MssgNotPerEdit"));
                    }
                }
                else
                {
                    if (PermissionChuyenKho.IsAdd(this))
                    {
                        bool ok = process.Insert();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PCK_CT_ID"));
                            return;
                        }
                    }
                    else
                    {
                        Response.Clear(); Response.Write(functions.GetValueLanguage("MssgNotPerAdd"));
                    }
                }
            }
            catch
            {
            }
            Response.StatusCode = 500;
        }
        public void loadTableKH_PHIEU_CHUYEN_KHO_CT()
        {
            string paging = "";
            string html = "";
            html += "<table class='jtable' id=\"gridTable\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th></th>";
            //html += "<th>" + functions.sGetValueLanguage("HH_ID") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("HH_NAME") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("NNH_NAME") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("MA_PNK") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("SO_LUONG") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("DON_GIA") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("THANH_TIEN") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("GHI_CHU") + "</th>";     

            html += "<th>Mã hàng</th>";
            html += "<th>Tên hàng</th>";
            html += "<th>Loại hàng</th>";
            html += "<th>Phiếu nhập</th>";
            html += "<th>" + functions.GetValueLanguage("SO_LUONG") + "</th>";
            html += "<th>" + functions.GetValueLanguage("DON_GIA") + "</th>";
            html += "<th>" + functions.GetValueLanguage("THANH_TIEN") + "</th>";
            html += "<th>" + functions.GetValueLanguage("GHI_CHU") + "</th>";

            //html += "<th></th>";
            html += "</tr>";
            bool add = PermissionChuyenKho.IsAdd(this);
            bool search = PermissionChuyenKho.IsView(this);
            if (search)
            {
                DataProcess process = s_KH_PHIEU_CHUYEN_KHO_CT(true);
                process.Page = Request.QueryString["page"];
                DataTable table = process.Search(@"select STT=row_number() over (order by T.PCK_CT_ID),T.*
                   ,A.MA_PCK
                   ,B.MA_HH,B.NAME TEN_HH,B.NAME [HH_NAME],C.[NAME] NHH_NAME, B.NHH_ID   
                   ,E.MA_PNK
                    from KH_PHIEU_CHUYEN_KHO_CT T
                    left join KH_PHIEU_CHUYEN_KHO  A on T.PCK_ID=A.PCK_ID
                    left join DM_HANG_HOA  B on T.HH_ID=B.ID
                    left join DM_HANG_HOA_NHOM C ON C.ID=B.NHH_ID 
                    left join KH_PHIEU_NHAP_KHO_CT D on T.PNK_CT_ID=D.PNK_CT_ID
                    left join KH_PHIEU_NHAP_KHO E on E.PNK_ID=D.PNK_ID      
                where T.PCK_ID='" + process.getData("PCK_ID") + "'");
                if (table.Rows.Count > 0)
                {
                    paging = process.Paging("KH_PHIEU_CHUYEN_KHO_CT");
                    bool delete = PermissionChuyenKho.IsDelete(this);
                    bool edit = PermissionChuyenKho.IsEdit(this);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr>";
                        html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                        html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">Xóa</a></td>"; //" + functions.sGetValueLanguage("delete") + "
                        html += "<td><input mkv='true' id='HH_ID' type='hidden' value='" + table.Rows[i]["HH_ID"] + "'/><input style='width:82px' mkv='true' id='mkv_HH_ID' type='text' value='" + table.Rows[i]["MA_HH"].ToString() + "' onfocus='HH_IDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='HH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["HH_NAME"].ToString() + "' " + "disabled" + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='NHH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["NHH_NAME"].ToString() + "' " + "disabled" + "/></td>";
                        html += "<td><input  mkv='true' id='PNK_CT_ID' type='hidden' value='" + table.Rows[i]["PNK_CT_ID"] + "'/><input style='width:82px' mkv='true' id='mkv_PNK_CT_ID' type='text' value='" + table.Rows[i]["MA_PNK"].ToString() + "' onfocus='PNK_CT_IDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='SO_LUONG' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SO_LUONG"].ToString() + "' onblur='TestSo(this,true,false,1);TinhTien(this);' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='DON_GIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DON_GIA"].ToString() + "' onblur='TestSo(this,true,false);TinhTien(this);' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='THANH_TIEN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["THANH_TIEN"].ToString() + "' onblur='TestSo(this,true,false);TinhDonGia(this);' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='GHI_CHU' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["GHI_CHU"].ToString() + "' " + (!edit ? "disabled" : "") + "/> <input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["PCK_CT_ID"].ToString() + "'/></td>";

                        //html += "<td></td>";
                        html += "</tr>";
                    }
                }
            }
            if (add)
            {
                html += "<tr>";
                html += "<td>&nbsp</td>";
                html += "<td><a onclick='xoaontable(this)'>Xóa</a></td>"; //" + functions.sGetValueLanguage("delete") + "
                html += "<td><input mkv='true' id='HH_ID' type='hidden' value=''/><input style='width:82px' mkv='true' id='mkv_HH_ID' type='text' value='' onfocus='HH_IDSearch(this);' class=\"down_select\"/></td>";
                html += "<td><input style='width:82px' mkv='true' id='HH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled value='' /></td>";
                html += "<td><input style='width:82px' mkv='true' id='NHH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled  value=''/></td>";
                html += "<td><input mkv='true' id='PNK_CT_ID' type='hidden' value=''/><input style='width:82px' mkv='true' id='mkv_PNK_CT_ID' type='text' value='' onfocus='PNK_CT_IDSearch(this);' class=\"down_select\"/></td>";
                html += "<td><input style='width:82px' style='width:82px' mkv='true' id='SO_LUONG' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,true,false,1);TinhTien(this);' /></td>";
                html += "<td><input style='width:82px' mkv='true' id='DON_GIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,true,false);TinhTien(this);' /></td>";
                html += "<td><input style='width:82px' mkv='true' id='THANH_TIEN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,true,false);TinhDonGia(this);' /></td>";
                html += "<td><input style='width:82px' mkv='true' id='GHI_CHU' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /> <input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
                //html += "<td></td>";
                html += "</tr>";
            }
            html += "<tr><td></td><td colspan='9'>" + (add ? "" : "<font color='red'>" + functions.GetValueLanguage("MssgNotPerAdd") + "</font>") + "</td></tr>";
            html += "</table>";
            if (!search)
                html += "<font color='red'>" + functions.GetValueLanguage("MssgNotPerView") + "</font>";
            else
                html += paging;
            Response.Clear(); Response.Write(html);
        }
    }
}


