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
 
 namespace chiase {
 public partial class KH_DM_KHO_ajax : System.Web.UI.Page
 {
     protected DataProcess s_KH_DM_KHO()
     {
             DataProcess KH_DM_KHO = new DataProcess("KH_DM_KHO"); 
             KH_DM_KHO.data("ID",Request.QueryString["idkhoachinh"]);
             KH_DM_KHO.data("NAME",Request.QueryString["NAME"]);
             KH_DM_KHO.data("DIA_CHI",Request.QueryString["DIA_CHI"]);
             KH_DM_KHO.data("DIEN_THOAI",Request.QueryString["DIEN_THOAI"]);
             KH_DM_KHO.data("NGUOI_QUAN_LY",Request.QueryString["NGUOI_QUAN_LY"]);
             KH_DM_KHO.data("VISIBLE_BIT",Request.QueryString["VISIBLE_BIT"]);
            return KH_DM_KHO;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_KH_DM_KHO();break ;
             case "xoa": Xoa_KH_DM_KHO(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_KH_DM_KHO()
     {
         try
         {
                DataProcess process = s_KH_DM_KHO();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("ID"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_KH_DM_KHO()
     {
         try
         {
              DataProcess process = s_KH_DM_KHO();
             if (process.getData("ID") != null && process.getData("ID") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("ID"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("ID"));
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
         string html ="";
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
          html += "<th>STT</th>";
          html += "<th></th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("NAME") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("DIA_CHI") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("DIEN_THOAI") + "</th>";
         html += "<th>" + DictionaryDB.sGetValueLanguage("NGUOI_QUAN_LY") + "</th>";
          html += "<th></th>";
         html += "</tr>";
 bool add = UserLogin.HavePermision(this, "KH_DM_KHO_Add");
 bool search = UserLogin.HavePermision(this, "KH_DM_KHO_Search");
         if (search)
         {
                DataProcess process = s_KH_DM_KHO();
         process.Page = Request.QueryString["page"];
         process.NumberRow = "50";
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.ID),T.*
                               from KH_DM_KHO T
          where "+process.sWhere());
 paging = process.Paging();
 html +=  paging;
         if (table.Rows.Count > 0)
         {
 bool delete = UserLogin.HavePermision(this, "KH_DM_KHO_Delete");
  bool edit = UserLogin.HavePermision(this, "KH_DM_KHO_Edit");
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr>";
 html+= "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
 html+= "<td> <a id=\"xoaRow\" style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + delete.ToString().ToLower() + ");\" onfocus=\"chuyendong(this);\">"+DictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='NAME' type='text' value='" + table.Rows[i]["NAME"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
 html+= "<td><input mkv='true' id='DIA_CHI' type='text' value='" + table.Rows[i]["DIA_CHI"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
 html+= "<td><input mkv='true' id='DIEN_THOAI' type='text' value='" + table.Rows[i]["DIEN_THOAI"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
 html+= "<td><input mkv='true' id='NGUOI_QUAN_LY' type='text' value='" + table.Rows[i]["NGUOI_QUAN_LY"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["ID"] + "'/></td>";
                 html += "</tr>";
             }}}
if (add){
                 html += "<tr>";
 html+= "<td>1</td>";
 html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+DictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='NAME' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='DIA_CHI' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='DIEN_THOAI' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='NGUOI_QUAN_LY' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                 html += "</tr>";
}
         html += "<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
         html += "</table>";
         if(!search)
             html += "Bạn không có quyền xem.";
         else
            html += paging;
         Response.Clear(); Response.Write(html);
     }
 }
 }
 
 
