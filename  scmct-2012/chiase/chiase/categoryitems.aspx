<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="categoryitems.aspx.cs" Inherits="chiase.categoryitems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="Server">
    <head>
        <link type="text/css" href="css/stocksection.css" rel="Stylesheet" />
    </head>
    <script src="js/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.autocomplete.js" type="text/javascript"></script>
    <script src="js/jquery.validate.js" type="text/javascript"></script>
    <script src="js/myscriptvalid.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/timepicker.js"></script>
    <script type="text/javascript" src="js/myscript.js"></script>
    <script type="text/javascript" src="js/myscript.jqr.js"></script>
    <script type="text/javascript" src="js/treeview.js"></script>
    <script type="text/javascript" src="javascript/DM_HANG_HOA2.js"> </script>
    <script type="text/javascript">
        function filter(nhhid, nhhtext) {
            document.getElementById("NHH_ID").value = nhhid;
            document.getElementById("mkv_NHH_ID").value = (nhhtext == null ? "Tất cả" : nhhtext);
            Find(document.getElementById("timKiem"));
        }
        function backs() {
            window.location = "admin.aspx";
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
    <fieldset style="color: #000000">
        <p class="header-div">
            <%=GetCaption("DM_HANG_HOA")%></p>
        <table width="100%">
            <tr valign="top">
                <td style="width: 25%">
                    <div id="divtree" runat="server" style="font-weight: bold; color: White" class="links">
                    </div>
                </td>
                <td style="width: 70%">
                    <div class="body-div">
                        <div class="in-a">
                            <p style="color: Blue; font-weight: bold">
                                Điều kiện tìm kiếm</p>
                            <hr>
                            <div class="div-Out">
                                Mã hàng:<%--=GetCaption("MA_HH")--%>
                                <p>
                                    <input mkv="true" id="MA_HH" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 300px;
                                        height: 25px" class="txtformat" />
                                </p>
                            </div>
                            <div class="div-Out">
                                Tên hàng:<%--=GetCaption("NAME")--%>
                                <p>
                                    <input mkv="true" id="NAME" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 300px;
                                        height: 25px" class="txtformat" />
                                </p>
                            </div>
                            <div class="div-Out">
                                Nhóm hàng:
                                <%-- <%=GetCaption("NHH_ID")%>--%>
                                <p>
                                    <input mkv="true" id="NHH_ID" type="hidden" />
                                    <input mkv="true" id="mkv_NHH_ID" type="text" disabled="disabled" onfocus="Find(this);chuyenphim(this);NHH_IDSearch(this);"
                                        style="width: 300px; height: 25px" class="txtformat" />
                                </p>
                            </div>
                            <div class="div-Out">
                                Mô tả:<%--=GetCaption("MO_TA")--%>
                                <p>
                                    <input mkv="true" id="MO_TA" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 300px;
                                        height: 25px" class="txtformat" />
                                </p>
                            </div>
                        </div>
                        <hr>
                        <input id="timKiem" search="<%=IsView %>" type="button" value="<%=GetCaption("find") %>"
                            style="width: 120px; height: 25px" class="btn" />
                    </div>
                    <div class="body-div-button">
                        <p class="in-a">
                            <input id="luuTable_1" edit="<%=IsEdit %>" add="<%=IsAdd %>" type="button" value="<%=GetCaption("save") %>"
                                style="width: 120px; height: 25px" class="btn" />
                            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#GetCaption("new") %>'
                                style="width: 120px; height: 25px" class="btn" />
                            <input id="Button1" type="button" value="<%=GetCaption("dong") %>" onclick="backs();" style="width: 120px;
                                height: 25px" class="btn" />
                        </p>
                        <a class="reload" onclick="Find(this)"></a>
                        <div class="in-b" id="tableAjax_DM_HANG_HOA">
                        </div>
                        <p class="in-c">
                            <input id="luuTable_2" type="button" edit="<%=IsEdit %>" add="<%=IsAdd %>" value='<%=GetCaption("save") %>'
                                style="width: 120px; height: 25px" class="btn" /></p>
                        <p>
                            &nbsp;</p>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
