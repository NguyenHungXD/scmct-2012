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
using System.Text;
namespace chiase
{
    public partial class KH_PHIEU_NHAP_KHO_ajax3 : System.Web.UI.Page
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
        protected DataProcess s_KH_PHIEU_NHAP_KHO_CT(bool isLoad)
        {
            DataProcess KH_PHIEU_NHAP_KHO_CT = new DataProcess("KH_PHIEU_NHAP_KHO_CT");
            KH_PHIEU_NHAP_KHO_CT.data("PNK_CT_ID", Request.QueryString["idkhoachinh"]);
            KH_PHIEU_NHAP_KHO_CT.data("PNK_ID", Request.QueryString["PNK_ID"]);
            KH_PHIEU_NHAP_KHO_CT.data("HH_ID", Request.QueryString["HH_ID"]);
            KH_PHIEU_NHAP_KHO_CT.data("SO_LUONG", Request.QueryString["SO_LUONG"]);
            KH_PHIEU_NHAP_KHO_CT.data("DON_GIA", Request.QueryString["DON_GIA"]);
            KH_PHIEU_NHAP_KHO_CT.data("THANH_TIEN", Request.QueryString["THANH_TIEN"]);
            KH_PHIEU_NHAP_KHO_CT.data("GHI_CHU", Request.QueryString["GHI_CHU"]);
            if (isLoad)
            {
                KH_PHIEU_NHAP_KHO_CT.data("HH_NAME", Request.QueryString["HH_NAME"]);
                KH_PHIEU_NHAP_KHO_CT.data("NHH_ID", Request.QueryString["NHH_ID"]);
            }
            return KH_PHIEU_NHAP_KHO_CT;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["do"];
            switch (action)
            {
                case "Luu": SaveKH_PHIEU_NHAP_KHO(); break;
                case "TimKiem": TimKiem(); break;
                case "setTimKiem": setTimKiem(); break;
                case "luuTableKH_PHIEU_NHAP_KHO_CT": LuuTableKH_PHIEU_NHAP_KHO_CT(); break;
                case "loadTableKH_PHIEU_NHAP_KHO_CT": loadTableKH_PHIEU_NHAP_KHO_CT(); break;
                case "xoa": XoaKH_PHIEU_NHAP_KHO(); break;
                case "xoaKH_PHIEU_NHAP_KHO_CT": XoaKH_PHIEU_NHAP_KHO_CT(); break;
                case "NGUOI_NHAPSearch": NGUOI_NHAPSearch(); break;
                case "MEM_IDSearch": MEM_IDSearch(); break;
                case "KHO_IDSearch": KHO_IDSearch(); break;
                case "DU_AN_IDSearch": DU_AN_IDSearch(); break;
                case "LY_DO_NHAP_IDSearch": LY_DO_NHAP_IDSearch(); break;
                case "YEU_CAU_IDSearch": YEU_CAU_IDSearch(); break;
                case "HH_IDSearch": HH_IDSearch(); break;
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
        private void HH_IDSearch()
        {
            // DataTable table = DM_HANG_HOA.GetTableAll();
            DataTable table = SQLConnectWeb.GetTable(@"SELECT HH.ID,HH.MA_HH,HH.[NAME],HH.NHH_ID,NHH.[NAME] NHH_NAME
                      FROM DM_HANG_HOA HH                    
                    LEFT JOIN DM_HANG_HOA_NHOM NHH ON NHH.ID=HH.NHH_ID");
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
        private string GetSpace(int space)
        {
            string s = "";
            while (space >= 0)
            {
                s += " ";
                space--;
            }
            return s;
        }
        private void XoaKH_PHIEU_NHAP_KHO()
        {
            try
            {
                if (PermissionNhapKho.IsDelete(this))
                {
                    DataProcess process = s_KH_PHIEU_NHAP_KHO();
                    bool ok = process.Delete();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PNK_ID"));
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

        private void XoaKH_PHIEU_NHAP_KHO_CT()
        {
            try
            {
                if (PermissionNhapKho.IsDelete(this))
                {
                    DataProcess process = s_KH_PHIEU_NHAP_KHO_CT(false);
                    bool ok = process.Delete();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("PNK_CT_ID"));
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
            if (PermissionNhapKho.IsView(this))
            {
                string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                DataTable table = KH_PHIEU_NHAP_KHO.SearchByPNK_ID(idkhoachinh);
                string html = "";
                html += "<root>";
                html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
                DataTable NGUOI_NHAP = ND_THONG_TIN_ND.SearchByID("'" + table.Rows[0]["NGUOI_NHAP"] + "'");
                html += "<data id=\"mkv_NGUOI_NHAP\">" + ((NGUOI_NHAP.Rows.Count > 0) ? NGUOI_NHAP.Rows[0][1] : "") + "</data>";
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

        private void TimKiem()
        {
            if (PermissionNhapKho.IsView(this))
            {
                DataProcess process = s_KH_PHIEU_NHAP_KHO();
                process.Page = Request.QueryString["page"];
                DataTable table = process.Search(@"select STT=row_number() over (order by T.PNK_ID),T.*
                   ,A.NAME
                   ,B.NAME
                   ,C.NAME
                   ,D.MA_DU_AN
                   ,E.NAME
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
                html += "<table class='jtable' id=\"tablefind\">";
                html += "<tr>";
                html += "<th>" + functions.GetValueLanguage("PNK_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("MA_PNK") + "</th>";
                html += "<th>" + functions.GetValueLanguage("NGUOI_NHAP") + "</th>";
                html += "<th>" + functions.GetValueLanguage("NGAY_NHAP") + "</th>";
                html += "<th>" + functions.GetValueLanguage("MEM_ID_PNK") + "</th>";
                html += "<th>" + functions.GetValueLanguage("KHO_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("DU_AN_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("LY_DO_NHAP_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("YEU_CAU_ID") + "</th>";
                html += "<th>" + functions.GetValueLanguage("CHUNG_TU") + "</th>";
                html += "</tr>";
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            html += "<tr onclick=\"setControlFind('" + table.Rows[i]["PNK_ID"].ToString() + "')\">";
                            html += "<td>" + table.Rows[i]["MA_PNK"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            if (table.Rows[i]["NGAY_NHAP"].ToString() != "")
                            {
                                html += "<td>" + DateTime.Parse(table.Rows[i]["NGAY_NHAP"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                            }
                            else { html += "<td>" + table.Rows[i]["NGAY_NHAP"].ToString() + "</td>"; }
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["MA_DU_AN"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["TIEU_DE"].ToString() + "</td>";
                            html += "<td>" + table.Rows[i]["CHUNG_TU"].ToString() + "</td>";
                            html += "</tr>";
                        }
                        html += "</table>";
                        //html += process.Paging();
                        html += "<br>";
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

        private void SaveKH_PHIEU_NHAP_KHO()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_NHAP_KHO();
                if (process.getData("PNK_ID") != null && process.getData("PNK_ID") != "")
                {
                    if (PermissionNhapKho.IsEdit(this))
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
                        Response.Clear();
                        Response.Write(functions.GetValueLanguage("MssgNotPerEdit"));
                    }
                }
                else
                {
                    if (PermissionNhapKho.IsAdd(this))
                    {
                        string mpn = functions.NewMaPhieuNhap();
                        process.data("MA_PNK", mpn);
                        bool ok = process.Insert();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PNK_ID"));
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
        public void LuuTableKH_PHIEU_NHAP_KHO_CT()
        {
            try
            {
                DataProcess process = s_KH_PHIEU_NHAP_KHO_CT(false);

                if (string.IsNullOrEmpty(process.getData("HH_ID")))
                {

                    DM_HANG_HOA hh = DM_HANG_HOA.Insert_Object(Request.QueryString["mkv_HH_ID"],
                             Request.QueryString["HH_NAME"],
                             Request.QueryString["NHH_ID"], "", "Y"
                             );
                    if (hh != null)
                        process.data("HH_ID", hh.ID);
                }


                if (process.getData("PNK_CT_ID") != null && process.getData("PNK_CT_ID") != "")
                {

                    if (PermissionNhapKho.IsEdit(this))
                    {
                        bool ok = process.Update();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PNK_CT_ID"));
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
                    if (PermissionNhapKho.IsEdit(this))
                    {
                        bool ok = process.Insert();
                        if (ok)
                        {
                            Response.Clear(); Response.Write(process.getData("PNK_CT_ID"));
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
        public void loadTableKH_PHIEU_NHAP_KHO_CT()
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
            //html += "<th>" + functions.sGetValueLanguage("SO_LUONG") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("DON_GIA") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("THANH_TIEN") + "</th>";
            //html += "<th>" + functions.sGetValueLanguage("GHI_CHU") + "</th>";
            //html += "<th></th>";
            html += "<th>M?? h??ng</th>";
            html += "<th>T??n h??ng</th>";
            html += "<th>Lo???i h??ng</th>";
            html += "<th>S??? l?????ng</th>";
            html += "<th>????n gi??</th>";
            html += "<th>Th??nh ti???n</th>";
            html += "<th>Ghi ch??</th>";
            //html += "<th></th>";
            html += "</tr>";
            bool add = PermissionNhapKho.IsAdd(this);
            bool search = PermissionNhapKho.IsView(this);
           
            if (search)
            {
                DataProcess process = s_KH_PHIEU_NHAP_KHO_CT(false);
                process.Page = Request.QueryString["page"];
                DataTable table = process.Search(@"select STT=row_number() over (order by T.PNK_CT_ID),T.*
                   ,A.MA_PNK
                   ,B.MA_HH,B.NAME TEN_HH,B.NAME [HH_NAME],C.[NAME] NHH_NAME, B.NHH_ID   
                    from KH_PHIEU_NHAP_KHO_CT T
                    left join KH_PHIEU_NHAP_KHO  A on T.PNK_ID=A.PNK_ID
                    left join DM_HANG_HOA  B on T.HH_ID=B.ID
                    left join DM_HANG_HOA_NHOM C ON C.ID=B.NHH_ID 
                    where T.PNK_ID='" + process.getData("PNK_ID") + "'");
                if (table.Rows.Count > 0)
                {
                    paging = process.Paging("KH_PHIEU_NHAP_KHO_CT");
                    bool delete = PermissionNhapKho.IsDelete(this);
                    bool edit = PermissionNhapKho.IsEdit(this);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr>";
                        html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                        html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">X??a</a></td>"; //" + functions.sGetValueLanguage("delete") + "
                        html += "<td><input mkv='true' id='HH_ID' type='hidden' value='" + table.Rows[i]["HH_ID"] + "'/><input style='width:100px' mkv='true' id='mkv_HH_ID' type='text' value='" + table.Rows[i]["MA_HH"].ToString() + "'  onchange='txtChangeHH(this);' onfocus='HH_IDSearch(this);'  class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:100px' mkv='true' id='HH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["HH_NAME"].ToString() + "' " + "disabled" + "/></td>";
                        html += "<td><input mkv='true' id='NHH_ID' type='hidden' value='" + table.Rows[i]["NHH_ID"] + "'/><input style='width:100px' mkv='true' id='mkv_NHH_ID' type='text' value='" + table.Rows[i]["NHH_NAME"].ToString() + "' onfocus='NHH_IDSearch(this);' class=\"down_select\" " + "disabled" + "/></td>";
                        html += "<td><input style='width:100px' mkv='true' id='SO_LUONG' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SO_LUONG"].ToString() + "' onblur='TestSo(this,true,false,1);TinhTien(this);' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:100px' mkv='true' id='DON_GIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DON_GIA"].ToString() + "' onblur='TestSo(this,true,false);TinhTien(this);' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:100px' mkv='true' id='THANH_TIEN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["THANH_TIEN"].ToString() + "' onblur='TestSo(this,true,false);TinhDonGia(this);' " + (!edit ? "disabled" : "") + "/></td>";
                        html += "<td><input style='width:100px' mkv='true' id='GHI_CHU' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["GHI_CHU"].ToString() + "' " + (!edit ? "disabled" : "") + "/> <input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["PNK_CT_ID"].ToString() + "'/></td>";
                        //html += "<td></td>";
                        html += "</tr>";
                    }
                }
            }
            if (add)
            {
                html += "<tr>";
                html += "<td>&nbsp</td>";
                html += "<td><a onclick='xoaontable(this)'>" + functions.GetValueLanguage("delete") + "</a></td>";
                html += "<td><input mkv='true' id='HH_ID' type='hidden' value=''/><input style='width:100px' mkv='true' id='mkv_HH_ID' type='text' value=''  onchange='txtChangeHH(this);' onfocus='HH_IDSearch(this);'  class=\"down_select\"/></td>";
                html += "<td><input style='width:100px' mkv='true' id='HH_NAME' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                html += "<td><input mkv='true' id='NHH_ID' type='hidden' value=''><input style='width:100px' mkv='true' id='mkv_NHH_ID' type='text' value='' onfocus='NHH_IDSearch(this);' class=\"down_select\"/></td>";
                html += "<td><input style='width:100px' mkv='true' id='SO_LUONG' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,true,false,1);TinhTien(this);' /></td>";
                html += "<td><input style='width:100px' mkv='true' id='DON_GIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,true,false);TinhTien(this);' /></td>";
                html += "<td><input style='width:100px' mkv='true' id='THANH_TIEN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,true,false);TinhDonGia(this);' /></td>";
                html += "<td><input style='width:100px' mkv='true' id='GHI_CHU' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /> <input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
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


