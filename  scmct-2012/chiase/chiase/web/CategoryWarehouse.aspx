 <%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeBehind="CategoryWarehouse.aspx.cs" Inherits="chiase.CategoryWarehouse" Title="KH_DM_KHO" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="Content_slider"  runat="server">
     <script type="text/javascript" src="../javascript/KH_DM_KHO2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
     <div class="body-div">
             <p class="header-div">
                 <%=GetCaption("KH_DM_KHO")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=GetCaption("NAME")%>
     </h4>
     <p>
        <input mkv="true" id="NAME" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=GetCaption("DIA_CHI")%>
     </h4>
     <p>
        <input mkv="true" id="DIA_CHI" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=GetCaption("DIEN_THOAI")%>
     </h4>
     <p>
        <input mkv="true" id="DIEN_THOAI" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=GetCaption("NGUOI_QUAN_LY")%>
     </h4>
     <p>
        <input mkv="true" id="NGUOI_QUAN_LY" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
         </div></div>
 <div class="body-div-button">
 <p class="in-a">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=GetCaption("save") %>" />
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#GetCaption("new") %>' />
             <input  id="timKiem" search="true" type="button" value="<%=GetCaption("find") %>"
                       />
             </p>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_KH_DM_KHO">
         </div>
 <p class="in-c">
                     <input id="luuTable_2" type="button" value='<%=GetCaption("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>
