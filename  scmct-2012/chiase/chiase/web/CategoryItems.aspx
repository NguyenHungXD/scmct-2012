<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="True"
    CodeBehind="CategoryItems.aspx.cs" Inherits="chiase.CategoryItems" Title="Danh mục hàng hóa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="Server">
    <script type="text/javascript" src="../js/treeview.js"></script>
    <script type="text/javascript" src="../javascript/DM_HANG_HOA2.js"> </script>
   <script type="text/javascript">
       function filter(nhhid, nhhtext) {
           document.getElementById("NHH_ID").value = nhhid;
           document.getElementById("mkv_NHH_ID").value = (nhhtext == null ? "Tất cả" : nhhtext);
           Find(document.getElementById("timKiem"));
       }

//       $(document).ready(function () {

//           var xmlHttp = GetMSXmlHttp();
//           xmlHttp.onreadystatechange = function () {
//               if (xmlHttp.readyState == 4) {
//                   if (xmlHttp.responseText.length > 0) {
//                       document.getElementById("divtree").innerHTML = xmlHttp.responseText;
//                   }
//               }
//           }
//           xmlHttp.open("GET", "../ajax/DM_HANG_HOA_ajax2.aspx?do=loadNhomHH&times=" + Math.random(), true);
//           xmlHttp.send(null);
//       });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="Server">
    <p class="header-div">
        <%=GetCaption("DM_HANG_HOA")%></p>
       
    <table width="100%">
        <tr valign="top">
            <td style="width: 25%">             
                <div id="divtree" runat="server">
                   
                </div>              
            </td>
            <td style="width: 70%">
                <div class="body-div">
                    <%--   <p class="header-div">
                 <%=GetCaption("DM_HANG_HOA")%>
           </p>   --%>
                    <div class="in-a">
                        <div class="div-Out">
                            <h4>
                                <%=GetCaption("MA_HH")%>
                            </h4>
                            <p>
                                <input mkv="true" id="MA_HH" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 90%" />
                            </p>
                        </div>
                        <div class="div-Out">
                            <h4>
                                <%=GetCaption("NAME")%>
                            </h4>
                            <p>
                                <input mkv="true" id="NAME" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 90%" />
                            </p>
                        </div>
                        <div class="div-Out">
                            <h4>
                              NHÓM HH <%-- <%=GetCaption("NHH_ID")%>--%>
                            </h4>
                            <p>
                                <input mkv="true" id="NHH_ID" type="hidden" />
                                <input mkv="true" id="mkv_NHH_ID" type="text" disabled="disabled" onfocus="Find(this);chuyenphim(this);NHH_IDSearch(this);"
                                     style="width: 90%" />
                            </p>
                        </div>
                        <div class="div-Out">
                            <h4>
                                <%=GetCaption("MO_TA")%>
                            </h4>
                            <p>
                                <input mkv="true" id="MO_TA" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 90%" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="body-div-button">
                    <p class="in-a">
                        <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=GetCaption("save") %>" />
                        <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#GetCaption("new") %>' />
                        <input id="timKiem" search="true" type="button" value="<%=GetCaption("find") %>" />
                    </p>
                    <a class="reload" onclick="Find(this)"></a>
                    <div class="in-b" id="tableAjax_DM_HANG_HOA">
                    </div>
                    <p class="in-c">
                        <input id="luuTable_2" type="button" value='<%=GetCaption("save") %>' /></p>
                 
                    <p>
&nbsp;</p>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
