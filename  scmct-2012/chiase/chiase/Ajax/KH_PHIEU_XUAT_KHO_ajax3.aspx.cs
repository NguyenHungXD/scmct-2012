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
    public partial class KH_PHIEU_XUAT_KHO_ajax3 : System.Web.UI.Page
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
        protected DataProcess s_KH_PHIEU_XUAT_KHO_CT(bool isLoad)
        {
            DataProcess KH_PHIEU_XUAT_KHO_CT = new DataProcess("KH_PHIEU_XUAT_KHO_CT");
            KH_PHIEU_XUAT_KHO_CT.data("PXK_CT_ID", Request.QueryString["idkhoachinh"]);
            KH_PHIEU_XUAT_KHO_CT.data("PXK_ID", Request.QueryString["PXK_ID"]);
            KH_PHIEU_XUAT_KHO_CT.data("HH_ID", Request.QueryString["HH_ID"]);
            KH_PHIEU_XUAT_KHO_CT.data("SO_LUONG", Request.QueryString["SO_LUONG"]);
            KH_PHIEU_XUAT_KHO_CT.data("DON_GIA", Request.QueryString["DON_GIA"]);
            KH_PHIEU_XUAT_KHO_CT.data("THANH_TIEN", Request.QueryString["THANH_TIEN"]);
            KH_PHIEU_XUAT_KHO_CT.data("GHI_CHU", Request.QueryString["GHI_CHU"]);
            KH_PHIEU_XUAT_KHO_CT.data("PNK_CT_ID", Request.QueryString["PNK_CT_ID"]);
            if (isLoad)
            {
                KH_PHIEU_XUAT_KHO_CT.data("HH_NAME", Request.QueryString["HH_NAME"]);
                KH_PHIEU_XUAT_KHO_CT.data("NHH_ID", Request.QueryString["NHH_ID"]);

            }
            return KH_PHIEU_XUAT_KHO_CT;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["do"];
            switch (action)
            {
                case "Luu": SaveKH_PHIEU_XUAT_KHO(); break;
                case "TimKiem": TimKiem(); break;
                case "setTimKiem": setTimKiem(); break;
                case "luuTableKH_PHIEU_XUAT_KHO_CT": LuuTableKH_PHIEU_XUAT_KHO_CT(); break;
                case "loadTableKH_PHIEU_XUAT_KHO_CT": loadTableKH_PHIEU_XUAT_KHO_CT(); break;
                case "xoa": XoaKH_PHIEU_XUAT_KHO(); break;
                case "xoaKH_PHIEU_XUAT_KHO_CT": XoaKH_PHIEU_XUAT_KHO_CT(); break;
                case "NGUOI_XUATSearch": NGUOI_XUATSearch(); break;
                case "MEM_IDSearch": MEM_IDSearch(); break;
                case "KHO_IDSearch": KHO_IDSearch(); break;
                case "DU_AN_IDSearch": DU_AN_IDSearch(); break;
                case "LY_DO_XUAT_IDSearch": LY_DO_XUAT_IDSearch(); break;
                case "YEU_CAU_IDSearch": YEU_CAU_IDSearch(); break;
                case "HH_IDSearch": HH_IDSearch(); break;
                case "PNK_CT_IDSearch": PNK_CT_IDSearch(); break;
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
        private void HH_IDSearch()
        {
           
            string duanID = Request.QueryString["sDU_AN_ID"];
            string khoID = Request.QueryString["sKHO_ID"];
            string pxct = Request.QueryString["sPXKCT_ID"];
            string where = " where 1=1";
            string where2 = " where 1=1";
            string where3 = "";
            if(!string.IsNullOrEmpty(pxct))
                where3+=" pxct.PXK_CT_ID <> "+pxct;        
              
                if (!string.IsNullOrEmpty(duanID))
                {    where += " AND pn.DU_AN_ID=" + duanID;
                    where2 += "AND pc.DU_AN_ID="+duanID;
                }
                if (!string.IsNullOrEmpty(khoID))
                { 
                    where += " AND pn.KHO_ID=" + khoID;
                    where2+=" AND pc.kho_nhap_id="+khoID;
                }
           
            string sql = string.Format(@"SELECT DISTINCT HH.ID,HH.MA_HH,HH.[NAME],HH.NHH_ID,NHH.[NAME] NHH_NAME
            FROM 
            (
            SELECT pnct.HH_ID, pnct.PNK_CT_ID,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) NGAY_NHAP,
            pn.KHO_ID,pn.DU_AN_ID,N'' GHI_CHU,
            pnct.SO_LUONG -
            ISNULL((SELECT sum (pcct.SO_LUONG)
            FROM KH_PHIEU_CHUYEN_KHO_CT pcct
            WHERE pcct.PNK_CT_ID=pnct.PNK_CT_ID
            ),0)-
            ISNULL((SELECT sum (pxct.SO_LUONG)
            FROM KH_PHIEU_XUAT_KHO_CT pxct
            WHERE pxct.PNK_CT_ID=pnct.PNK_CT_ID {0}
            ),0) SO_LUONG
            FROM KH_PHIEU_NHAP_KHO_CT pnct
            INNER JOIN KH_PHIEU_NHAP_KHO pn ON pn.PNK_ID = pnct.PNK_ID    
            {1}                        
            UNION ALL
            SELECT pnct.HH_ID, pcct.PNK_CT_ID,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) NGAY_NHAP,
            pn.KHO_ID,pn.DU_AN_ID,N'Chuy???n ?????n',
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
            HAVING  SUM(abc.SO_LUONG)>0",where3,where,where2);
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
            string duanID = Request.QueryString["sDU_AN_ID"];
            string khoID = Request.QueryString["sKHO_ID"];
            string pxct = Request.QueryString["sPXKCT_ID"];
            string where = " where ";
            string where2 = " where";
            string where3 = "";
            if (!string.IsNullOrEmpty(pxct))
                where3 += " pxct.PXK_CT_ID <> " + pxct;
            if (string.IsNullOrEmpty(hhid))
            {
                where += " 1=-1";
                where2 += " 1=-1";
            }
            else
            {
                where += " PNCT.HH_ID=" + hhid;
                where2 += " PNCT.HH_ID=" + hhid;
                if (!string.IsNullOrEmpty(duanID))
                {
                    where += " AND pn.DU_AN_ID=" + duanID;
                    where2 += "AND pc.DU_AN_ID=" + duanID;
                }
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
                            WHERE pcct.PNK_CT_ID=pnct.PNK_CT_ID
                            ),0)-
                            ISNULL((SELECT sum (pxct.SO_LUONG)
                            FROM KH_PHIEU_XUAT_KHO_CT pxct
                            WHERE pxct.PNK_CT_ID=pnct.PNK_CT_ID {0}
                            ),0) SO_LUONG
                        FROM KH_PHIEU_NHAP_KHO_CT pnct
                        INNER JOIN KH_PHIEU_NHAP_KHO pn ON pn.PNK_ID = pnct.PNK_ID   
                        {1}       
            UNION ALL
            SELECT pcct.PNK_CT_ID,pn.MA_PNK,CONVERT (VARCHAR(10),pn.NGAY_NHAP,103) NGAY_NHAP,
            pn.KHO_ID,pn.DU_AN_ID,N'Chuy???n ?????n',
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

        private void XoaKH_PHIEU_XUAT_KHO_CT()
        {
            try
            {
                if (PermissionXuatKho.IsDelete(this))
                {
                    DataProcess process = s_KH_PHIEU_XUAT_KHO_CT(false);
                    bool ok = process.Delete();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PXK_CT_ID"));
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
                Response.Write("<font color='red'>" + functions.GetValueLanguage("MssgNotPerView") + "</font>");
                Response.StatusCode = 500;
            }
        }

        private void TimKiem()
        {
            if (PermissionXuatKho.IsView(this))
            {
                DataProcess process = s_KH_PHIEU_XUAT_KHO();
                process.Page = Request.QueryString["page"];
                DataTable table = process.Search(@"select STT=row_number() over (order by T.PXK_ID),T.*
                   ,A.NAME
                   ,B.NAME
                   ,C.NAME
                   ,D.MA_DU_AN
                   ,E.NAME
                   ,F.TIEU_DE
                               from KH_PHIEU_XUAT_KHO T
                    left join ND_THONG_TIN_ND  A on T.NGUOI_XUAT=A.ID
                    left join ND_THONG_TIN_ND  B on T.MEM_ID=B.ID
                    left join KH_DM_KHO  C on T.KHO_ID=C.ID
                    left join DA_DU_AN  D on T.DU_AN_ID=D.ID
                    left join KH_DM_LY_DO_XUAT_KHO  E on T.LY_DO_XUAT_ID=E.ID
                    left join YC_YEU_CAU  F on T.YEU_CAU_ID=F.YEU_CAU_ID
          where " + process.sWhere());
                string html = "";
                html += "<table class='jtable' id=\"tablefind\">";
                html += "<tr>";
                html += "<th>" + functions.GetValueLanguage("PXK_ID") + "</th>";
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
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            html += "<tr onclick=\"setControlFind('" + table.Rows[i]["PXK_ID"].ToString() + "')\">";
                            html += "<td>" + table.Rows[i]["MA_PXK"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            if (table.Rows[i]["NGAY_XUAT"].ToString() != "")
                            {
                                html += "<td>" + DateTime.Parse(table.Rows[i]["NGAY_XUAT"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                            }
                            else { html += "<td>" + table.Rows[i]["NGAY_XUAT"].ToString() + "</td>"; }
                            html += "<td>" + table.Rows[i]["NGUOI_NHAN"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["MA_DU_AN"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["CHUNG_TU"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["GHI_CHU"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["TIEU_DE"].ToString() + "</td>";
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
                    if (PermissionXuatKho.IsEdit(this))
                    {
                        string mp = functions.NewMaPhieuXuat();
                        process.data("MA_PXK", mp);
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
        public void LuuTableKH_PHIEU_XUAT_KHO_CT()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_XUAT_KHO_CT(false);
                if (process.getData("PXK_CT_ID") != null && process.getData("PXK_CT_ID") != "")
                {
                    if (PermissionXuatKho.IsEdit(this))
                    {
                        bool ok = process.Update();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PXK_CT_ID"));
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
                        string mp = functions.NewMaPhieuXuat();
                        process.data("MA_PXK", mp);
                        bool ok = process.Insert();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PXK_CT_ID"));
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
        public void loadTableKH_PHIEU_XUAT_KHO_CT()
        {
            string paging = "";
            string html = "";
            html += "<table class='jtable' id=\"gridTable\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th></th>";
            html += "<th>" + functions.GetValueLanguage("MA_HANG") + "</th>";
            html += "<th>" + functions.GetValueLanguage("TEN_HANG") + "</th>";
            html += "<th>" + functions.GetValueLanguage("CHUNG_LOAI") + "</th>";
            html += "<th>" + functions.GetValueLanguage("PHIEU_NHAP") + "</th>";
            html += "<th>" + functions.GetValueLanguage("SO_LUONG") + "</th>";
            html += "<th>" + functions.GetValueLanguage("DON_GIA") + "</th>";
            html += "<th>" + functions.GetValueLanguage("THANH_TIEN") + "</th>";
            html += "<th>" + functions.GetValueLanguage("GHI_CHU") + "</th>";

            //html += "<th></th>";
            html += "</tr>";
            bool add = PermissionXuatKho.IsAdd(this);
            bool search = PermissionXuatKho.IsView(this);
            if (search)
            {
                DataProcess process = s_KH_PHIEU_XUAT_KHO_CT(true);
                process.Page = Request.QueryString["page"];
                DataTable table = process.Search(@"select STT=row_number() over (order by T.PXK_CT_ID),T.*
                   ,A.MA_PXK
                   ,B.MA_HH,B.NAME TEN_HH,B.NAME [HH_NAME],C.[NAME] NHH_NAME, B.NHH_ID   
                   ,E.MA_PNK
                    from KH_PHIEU_XUAT_KHO_CT T
                    left join KH_PHIEU_XUAT_KHO  A on T.PXK_ID=A.PXK_ID
                    left join DM_HANG_HOA  B on T.HH_ID=B.ID
                    left join DM_HANG_HOA_NHOM C ON C.ID=B.NHH_ID 
                    left join KH_PHIEU_NHAP_KHO_CT D on T.PNK_CT_ID=D.PNK_CT_ID
                    left join KH_PHIEU_NHAP_KHO E on E.PNK_ID=D.PNK_ID                    
                    where T.PXK_ID='" + process.getData("PXK_ID") + "'");
                if (table.Rows.Count > 0)
                {
                    paging = process.Paging("KH_PHIEU_XUAT_KHO_CT");
                    bool delete = PermissionXuatKho.IsDelete(this);
                    bool edit = PermissionXuatKho.IsEdit(this);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr>";
                        html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                        html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">X??a</a></td>"; //" + functions.sGetValueLanguage("delete") + "
                        html += "<td><input style='width:82px' mkv='true' id='HH_ID' type='hidden' value='" + table.Rows[i]["HH_ID"] + "'/><input style='width:82px' mkv='true' id='mkv_HH_ID' type='text' value='" + table.Rows[i]["MA_HH"].ToString() + "' onfocus='HH_IDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='HH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["HH_NAME"].ToString() + "' " + "disabled" + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='NHH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["NHH_NAME"].ToString() + "' " + "disabled" + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='PNK_CT_ID' type='hidden' value='" + table.Rows[i]["PNK_CT_ID"] + "'/><input style='width:82px' mkv='true' id='mkv_PNK_CT_ID' type='text' value='" + table.Rows[i]["MA_PNK"].ToString() + "' onfocus='PNK_CT_IDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='SO_LUONG' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SO_LUONG"].ToString() + "' onblur='TestSo(this,true,false,1);TinhTien(this);' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='DON_GIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DON_GIA"].ToString() + "' onblur='TestSo(this,true,false);TinhTien(this);' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='THANH_TIEN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["THANH_TIEN"].ToString() + "' onblur='TestSo(this,true,false);TinhDonGia(this);' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:82px' mkv='true' id='GHI_CHU' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["GHI_CHU"].ToString() + "' " + (!edit ? "disabled" : "") + "/> <input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["PXK_CT_ID"].ToString() + "'/></td>";

                        //html += "<td></td>";
                        html += "</tr>";
                    }
                }
            }
            if (add)
            {
                html += "<tr>";
                html += "<td>&nbsp</td>";
                html += "<td><a onclick='xoaontable(this)'>X??a</a></td>"; //" + functions.sGetValueLanguage("delete") + "
                html += "<td><input style='width:82px' mkv='true' id='HH_ID' type='hidden' value=''/><input style='width:82px' mkv='true' id='mkv_HH_ID' type='text' value='' onfocus='HH_IDSearch(this);' class=\"down_select\"/></td>";
                html += "<td><input style='width:82px' mkv='true' id='HH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled value='' /></td>";
                html += "<td><input style='width:82px' mkv='true' id='NHH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled  value=''/></td>";
                html += "<td><input style='width:82px' mkv='true' id='PNK_CT_ID' type='hidden' value=''/><input style='width:82px' mkv='true' id='mkv_PNK_CT_ID' type='text' value='' onfocus='PNK_CT_IDSearch(this);' class=\"down_select\"/></td>";
                html += "<td><input style='width:82px' mkv='true' id='SO_LUONG' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,true,false,1);TinhTien(this);' /></td>";
                html += "<td><input style='width:82px' mkv='true' id='DON_GIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,true,false);TinhTien(this);' /></td>";
                html += "<td><input style='width:82px' mkv='true' id='THANH_TIEN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,true,false);TinhDonGia(this);' /></td>";
                html += "<td><input style='width:82px' mkv='true' id='GHI_CHU' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /> <input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
                //html += "<td></td>";
                html += "</tr>";
            }
            html += "<tr><td></td><td colspan='8'>" + (add ? "" : "<font color='red'>" + functions.GetValueLanguage("MssgNotPerAdd") + "</font>") + "</td></tr>";
            html += "</table>";
            if (!search)
                html += "<font color='red'>" + "<font color='red'>" + functions.GetValueLanguage("MssgNotPerView") + "</font>" + "</font>";
            else
                html += paging;
            Response.Clear(); Response.Write(html);
        }
    }
}


