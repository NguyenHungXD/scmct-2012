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
 namespace chiase {
 public partial class KH_PHIEU_XUAT_KHO_ajax3 : System.Web.UI.Page
 {
     protected DataProcess s_KH_PHIEU_XUAT_KHO()
     {
             DataProcess KH_PHIEU_XUAT_KHO = new DataProcess("KH_PHIEU_XUAT_KHO"); 
             KH_PHIEU_XUAT_KHO.data("PXK_ID",Request.QueryString["idkhoachinh"]);
             KH_PHIEU_XUAT_KHO.data("MA_PXK",Request.QueryString["MA_PXK"]);
             KH_PHIEU_XUAT_KHO.data("NGUOI_XUAT",Request.QueryString["NGUOI_XUAT"]);
             KH_PHIEU_XUAT_KHO.data("NGAY_XUAT",Request.QueryString["NGAY_XUAT"]);
             KH_PHIEU_XUAT_KHO.data("NGUOI_CAP_NHAT",Request.QueryString["NGUOI_CAP_NHAT"]);
             KH_PHIEU_XUAT_KHO.data("NGAY_CAP_NHAT",Request.QueryString["NGAY_CAP_NHAT"]);
             KH_PHIEU_XUAT_KHO.data("NGUOI_NHAN",Request.QueryString["NGUOI_NHAN"]);
             KH_PHIEU_XUAT_KHO.data("MEM_ID",Request.QueryString["MEM_ID"]);
             KH_PHIEU_XUAT_KHO.data("KHO_ID",Request.QueryString["KHO_ID"]);
             KH_PHIEU_XUAT_KHO.data("DU_AN_ID",Request.QueryString["DU_AN_ID"]);
             KH_PHIEU_XUAT_KHO.data("LY_DO_XUAT_ID",Request.QueryString["LY_DO_XUAT_ID"]);
             KH_PHIEU_XUAT_KHO.data("CHUNG_TU",Request.QueryString["CHUNG_TU"]);
             KH_PHIEU_XUAT_KHO.data("GHI_CHU",Request.QueryString["GHI_CHU"]);
             KH_PHIEU_XUAT_KHO.data("YEU_CAU_ID",Request.QueryString["YEU_CAU_ID"]);
            return KH_PHIEU_XUAT_KHO;
     }
     protected DataProcess s_KH_PHIEU_XUAT_KHO_CT()
     {
             DataProcess KH_PHIEU_XUAT_KHO_CT = new DataProcess("KH_PHIEU_XUAT_KHO_CT"); 
             KH_PHIEU_XUAT_KHO_CT.data("PXK_CT_ID",Request.QueryString["idkhoachinh"]);
             KH_PHIEU_XUAT_KHO_CT.data("PXK_ID",Request.QueryString["PXK_ID"]);
             KH_PHIEU_XUAT_KHO_CT.data("HH_ID",Request.QueryString["HH_ID"]);
             KH_PHIEU_XUAT_KHO_CT.data("SO_LUONG",Request.QueryString["SO_LUONG"]);
             KH_PHIEU_XUAT_KHO_CT.data("DON_GIA",Request.QueryString["DON_GIA"]);
             KH_PHIEU_XUAT_KHO_CT.data("THANH_TIEN",Request.QueryString["THANH_TIEN"]);
             KH_PHIEU_XUAT_KHO_CT.data("GHI_CHU",Request.QueryString["GHI_CHU"]);
             KH_PHIEU_XUAT_KHO_CT.data("PNK_CT_ID",Request.QueryString["PNK_CT_ID"]);
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
             case "luuTableKH_PHIEU_XUAT_KHO_CT": LuuTableKH_PHIEU_XUAT_KHO_CT();break ;
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
         DataTable table = ND_THONG_TIN_ND .GetTableAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
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
         DataTable table = ND_THONG_TIN_ND .GetTableAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
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
         DataTable table = KH_DM_KHO .GetTableAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
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
         DataTable table = DA_DU_AN .GetTableAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
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
         DataTable table = KH_DM_LY_DO_XUAT_KHO .GetTableAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
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
         DataTable table = YC_YEU_CAU .GetTableAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
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
         DataTable table = DM_HANG_HOA.GetTableAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;
 
             }
         }
     }
                Response.Clear(); Response.Write(html);
}
     private void PNK_CT_IDSearch()
     {
         DataTable table = KH_PHIEU_NHAP_KHO_CT.GetTableAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
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
                DataProcess process = s_KH_PHIEU_XUAT_KHO();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("PXK_ID"));
                 return;
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
                DataProcess process = s_KH_PHIEU_XUAT_KHO_CT();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("PXK_CT_ID"));
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
 if (UserLogin.HavePermision(this, "KH_PHIEU_XUAT_KHO_Search"))
         {
         string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
         DataTable table = KH_PHIEU_XUAT_KHO.SearchByPXK_ID(idkhoachinh);
 string html = "";
 html += "<root>";
         html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
        DataTable NGUOI_XUAT = ND_THONG_TIN_ND .SearchByID("'" + table.Rows[0]["NGUOI_XUAT"] + "'");
 html += "<data id=\"mkv_NGUOI_XUAT\">" + ((NGUOI_XUAT.Rows.Count > 0) ? NGUOI_XUAT.Rows[0][1] : "") + "</data>";
        DataTable MEM_ID = ND_THONG_TIN_ND .SearchByID("'" + table.Rows[0]["MEM_ID"] + "'");
 html += "<data id=\"mkv_MEM_ID\">" + ((MEM_ID.Rows.Count > 0) ? MEM_ID.Rows[0][1] : "") + "</data>";
        DataTable KHO_ID = KH_DM_KHO .SearchByID("'" + table.Rows[0]["KHO_ID"] + "'");
 html += "<data id=\"mkv_KHO_ID\">" + ((KHO_ID.Rows.Count > 0) ? KHO_ID.Rows[0][1] : "") + "</data>";
        DataTable DU_AN_ID = DA_DU_AN .SearchByID("'" + table.Rows[0]["DU_AN_ID"] + "'");
 html += "<data id=\"mkv_DU_AN_ID\">" + ((DU_AN_ID.Rows.Count > 0) ? DU_AN_ID.Rows[0][1] : "") + "</data>";
        DataTable LY_DO_XUAT_ID = KH_DM_LY_DO_XUAT_KHO .SearchByID("'" + table.Rows[0]["LY_DO_XUAT_ID"] + "'");
 html += "<data id=\"mkv_LY_DO_XUAT_ID\">" + ((LY_DO_XUAT_ID.Rows.Count > 0) ? LY_DO_XUAT_ID.Rows[0][1] : "") + "</data>";
        DataTable YEU_CAU_ID = YC_YEU_CAU .SearchByYEU_CAU_ID("'" + table.Rows[0]["YEU_CAU_ID"] + "'");
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
             Response.Write("Bạn không có quyền xem dữ liệu");
             Response.StatusCode = 500;
         }
     }
 
     private void TimKiem()
     {
         if (UserLogin.HavePermision(this, "KH_PHIEU_XUAT_KHO_Search"))
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
          where "+process.sWhere());
         string html ="";
         html += "<table class='jtable' id=\"tablefind\">";
         html += "<tr>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("PXK_ID") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("MA_PXK") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("NGUOI_XUAT") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("NGAY_XUAT") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("NGUOI_NHAN") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("MEM_ID_PXK") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("KHO_ID") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("DU_AN_ID") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("LY_DO_XUAT_ID") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("CHUNG_TU") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("GHI_CHU") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("YEU_CAU_ID") + "</th>";
         html += "</tr>";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr onclick=\"setControlFind('" + table.Rows[i]["PXK_ID"].ToString() + "')\">";
                         html += "<td>" + table.Rows[i]["MA_PXK"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["NAME"].ToString() + "</td>";
                         if(table.Rows[i]["NGAY_XUAT"].ToString() != ""){
                        html += "<td>" + DateTime.Parse(table.Rows[i]["NGAY_XUAT"].ToString()).ToString("dd/MM/yyyy") + "</td>";}
                        else{html += "<td>" + table.Rows[i]["NGAY_XUAT"].ToString()+ "</td>";}
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
                     Response.Clear();Response.Write(html);
             return;
         }}
         else
         {
                     Response.StatusCode = 500;
         }
         }
         else
         {
             Response.Write("Bạn không có quyền xem dữ liệu.");
         }
     }
 
     private void SaveKH_PHIEU_XUAT_KHO()
     {
         try
         {
              DataProcess process = s_KH_PHIEU_XUAT_KHO();
             if (process.getData("PXK_ID") != null && process.getData("PXK_ID") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("PXK_ID"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("PXK_ID"));
                 return;
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
              DataProcess process = s_KH_PHIEU_XUAT_KHO_CT();
             if (process.getData("PXK_CT_ID") != null && process.getData("PXK_CT_ID") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("PXK_CT_ID"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("PXK_CT_ID"));
                 return;
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
         string html ="";
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
         html += "<th>STT</th>";
         html += "<th></th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("HH_ID") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("SO_LUONG") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("DON_GIA") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("THANH_TIEN") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("GHI_CHU") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("PNK_CT_ID") + "</th>";
         html += "<th></th>";
         html += "</tr>";
 bool add = UserLogin.HavePermision(this, "KH_PHIEU_XUAT_KHO_CT_Add");
 bool search = UserLogin.HavePermision(this, "KH_PHIEU_XUAT_KHO_CT_Search");
         if (search){
                DataProcess process = s_KH_PHIEU_XUAT_KHO_CT();
         process.Page = Request.QueryString["page"];
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.PXK_CT_ID),T.*
                   ,A.MA_PXK
                   ,B.MA_HH
                   ,C.PNK_ID
                               from KH_PHIEU_XUAT_KHO_CT T
                    left join KH_PHIEU_XUAT_KHO  A on T.PXK_ID=A.PXK_ID
                    left join DM_HANG_HOA  B on T.HH_ID=B.ID
                    left join KH_PHIEU_NHAP_KHO_CT  C on T.PNK_CT_ID=C.PNK_CT_ID
          where T.PXK_ID='"+process.getData("PXK_ID")+"'");
         if (table.Rows.Count > 0)
         {
          paging = process.Paging("KH_PHIEU_XUAT_KHO_CT");
 bool delete = UserLogin.HavePermision(this, "KH_PHIEU_XUAT_KHO_CT_Delete");
  bool edit = UserLogin.HavePermision(this, "KH_PHIEU_XUAT_KHO_CT_Edit");
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr>";
                 html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                 html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + DictionaryDB.sGetValueLanguage("delete") + "</a></td>";
 html+= "<td><input mkv='true' id='HH_ID' type='hidden' value='" + table.Rows[i]["HH_ID"] + "'/><input mkv='true' id='mkv_HH_ID' type='text' value='" + table.Rows[i]["MA_HH"].ToString() + "' onfocus='HH_IDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                         html += "<td><input mkv='true' id='SO_LUONG' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SO_LUONG"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                         html += "<td><input mkv='true' id='DON_GIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DON_GIA"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                         html += "<td><input mkv='true' id='THANH_TIEN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["THANH_TIEN"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                         html += "<td><input mkv='true' id='GHI_CHU' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["GHI_CHU"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
 html+= "<td><input mkv='true' id='PNK_CT_ID' type='hidden' value='" + table.Rows[i]["PNK_CT_ID"] + "'/><input mkv='true' id='mkv_PNK_CT_ID' type='text' value='" + table.Rows[i]["PNK_ID"].ToString() + "' onfocus='PNK_CT_IDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                 html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["PXK_CT_ID"].ToString() + "'/></td>";
                 html += "</tr>";
             }
         }}
         if(add)
         {
                 html += "<tr>";
                 html += "<td>1</td>";
                 html += "<td><a onclick='xoaontable(this)'>" + DictionaryDB.sGetValueLanguage("delete") + "</a></td>";
 html+= "<td><input mkv='true' id='HH_ID' type='hidden' value=''/><input mkv='true' id='mkv_HH_ID' type='text' value='' onfocus='HH_IDSearch(this);' class=\"down_select\"/></td>";
                         html += "<td><input mkv='true' id='SO_LUONG' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
                         html += "<td><input mkv='true' id='DON_GIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
                         html += "<td><input mkv='true' id='THANH_TIEN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
                         html += "<td><input mkv='true' id='GHI_CHU' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
 html+= "<td><input mkv='true' id='PNK_CT_ID' type='hidden' value=''/><input mkv='true' id='mkv_PNK_CT_ID' type='text' value='' onfocus='PNK_CT_IDSearch(this);' class=\"down_select\"/></td>";
                 html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
                 html += "</tr>";
         }
         html += "<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
         html += "</table>";
         if(!search)
             html += "Bạn không có quyền xem.";
         else
            html += paging;
                 Response.Clear();Response.Write(html);
     }
 }
 }
 
 
