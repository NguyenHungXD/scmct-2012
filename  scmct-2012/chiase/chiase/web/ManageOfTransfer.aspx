 <%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeBehind="ManageOfTransfer.aspx.cs" Inherits="chiase.ManageOfTransfer" Title="Quản lý chuyển kho" %>
 <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" Runat="Server">
     <script type="text/javascript" src="../javascript/KH_PHIEU_CHUYEN_KHO1.js">
     </script>
     <script type="text/javascript">
         var pnk_ID = "";
         function openPhieu(id) {
             pnk_ID = id;
             pcForm.Show();
         }
         function createNew() {
             pnk_ID = "";
             pcForm.Show();
         }
         function closeUp(s, e) {
             s.SetContentUrl("about:blank");
             Find(document.getElementById("timKiem"));
         }
         function opening(s, e) {

             var contentUrl = "Shipment.aspx";
             if (pnk_ID != "") contentUrl = contentUrl + "#idkhoachinh=" + pnk_ID;
             s.SetContentUrl(contentUrl);

         }
    </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="content_area" Runat="Server">
   
  <div class="body-div">
             <p class="header-div">
              QUẢN LÝ <%=GetCaption("KH_PHIEU_CHUYEN_KHO")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=GetCaption("MA_PCK")%>
     </h4>
     <p>
        <input mkv="true" id="MA_PCK" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=GetCaption("NGUOI_CHUYEN")%>
     </h4>
     <p>
        <input mkv="true" id="NGUOI_CHUYEN" type="hidden" />
        <input mkv="true" id="mkv_NGUOI_CHUYEN" type="text" onfocus="Find(this);chuyenphim(this);NGUOI_CHUYENSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=GetCaption("NGAY_CHUYEN")%>
     </h4>
     <p>
        <input mkv="true" id="NGAY_CHUYEN" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=GetCaption("KHO_XUAT_ID")%>
     </h4>
     <p>
        <input mkv="true" id="KHO_XUAT_ID" type="hidden" />
        <input mkv="true" id="mkv_KHO_XUAT_ID" type="text" onfocus="Find(this);chuyenphim(this);KHO_XUAT_IDSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=GetCaption("KHO_NHAP_ID")%>
     </h4>
     <p>
        <input mkv="true" id="KHO_NHAP_ID" type="hidden" />
        <input mkv="true" id="mkv_KHO_NHAP_ID" type="text" onfocus="Find(this);chuyenphim(this);KHO_NHAP_IDSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=GetCaption("DU_AN_ID")%>
     </h4>
     <p>
        <input mkv="true" id="DU_AN_ID" type="hidden" />
        <input mkv="true" id="mkv_DU_AN_ID" type="text" onfocus="Find(this);chuyenphim(this);DU_AN_IDSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=GetCaption("GHI_CHU")%>
     </h4>
     <p>
        <input mkv="true" id="GHI_CHU" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
         </div></div>
 <div class="body-div-button">
             <p class="in-a">
            <input id="luu" edit="false" add="false" type="button" style="display: none" type="button"
                value="<%=GetCaption("save") %> " />
            <input id="moi" type="button" type="button" style="display: none" value="<%=GetCaption("new") %>" />
            <input id="xoa" delete="false" type="button" style="display: none" value="<%=GetCaption("delete") %>" />
            <input id="addNew" type="button" value="<%=GetCaption("addnew") %>" onclick="createNew()" />
            <input id="timKiem" search="true" type="button" value="<%=GetCaption("find") %>" />
        </p>
         <a class="reload" onclick="Find(this)"></a>
         <div  class="in-b" id="tableAjax_KH_PHIEU_CHUYEN_KHO">
         </div>
         </div>
          <dx:aspxpopupcontrol id="ASPxPopupControl1" runat="server" height="500px" width="915px"
        modal="True" headertext="PHIẾU CHUYỂN HÀNG" popuphorizontalalign="WindowCenter"
        popupverticalalign="WindowCenter" closeaction="CloseButton" scrollbars="Auto"
        cssfilepath="~/App_Themes/Office2010Blue/{0}/styles.css" csspostfix="Office2010Blue"
        loadingpanelimageposition="Top" spritecssfilepath="~/App_Themes/Office2010Blue/{0}/sprite.css"
        clientinstancename="pcForm">
            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
            </LoadingPanelImage>
            <ContentStyle VerticalAlign="Top">
            </ContentStyle>
            <HeaderStyle Font-Bold="True" Font-Size="16pt" HorizontalAlign="Center" />
                 <ClientSideEvents CloseUp="closeUp" Shown="opening" />
             </dx:aspxpopupcontrol>
             </div>
 </asp:Content>
