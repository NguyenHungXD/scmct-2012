<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="manageofshipments.aspx.cs" Inherits="chiase.manageofshipments" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
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
    <script type="text/javascript" src="javascript/KH_PHIEU_XUAT_KHO1.js">
    </script>
    <script type="text/javascript">
        var pnk_ID = "";
        /*
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
        */
        function openPhieu(id) {
            pnk_ID = id;
            var contentUrl = "Shipment.aspx";
            if (pnk_ID != "") contentUrl = contentUrl + "#idkhoachinh=" + pnk_ID; //location=no,status=yes,scrollbars=yes,toolbar=no,menubar=no
            newwindow = window.open(contentUrl, 'mywindow', 'toolbar=no, location=no,directories=no,status=yes,menubar=no,scrollbars=yes,copyhistory=yes,resizable=yes')
            if (window.focus) { newwindow.focus() }
            return false;
        }

        function createNew() {
            pnk_ID = "";
            var contentUrl = "shipment.aspx";
            newwindow = window.open(contentUrl, 'mywindow', 'toolbar=no, location=no,directories=no,status=yes,menubar=no,scrollbars=yes,copyhistory=yes,resizable=yes')
            if (window.focus) { newwindow.focus() }
            return false;
        }
        function backs() {
            window.location = "admin.aspx";
        }
    </script>
    <fieldset style="color: Black">
        <div class="body-div">
            <p class="header-div">
                QUẢN LÝ&nbsp<%=GetCaption("KH_PHIEU_XUAT_KHO")%>
            </p>
            <hr>
            <div class="in-a">
                <p style="color: Blue; font-weight: bold">
                    <%=GetCaption("DIEU_KIEN_TIM")%></p>
                <hr>
                <div class="div-Out">
                    <%=GetCaption("MA_PXK")%>
                    <p>
                        <input mkv="true" id="MA_PXK" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("NGUOI_XUAT")%>
                    <p>
                        <input mkv="true" id="NGUOI_XUAT" type="hidden" />
                        <input mkv="true" id="mkv_NGUOI_XUAT" type="text" onfocus="Find(this);chuyenphim(this);NGUOI_XUATSearch(this);"
                            class="down_select" style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("NGAY_XUAT")%>
                    <p>
                        <input mkv="true" id="NGAY_XUAT" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                            onblur="TestDate(this);" style="width: 280px; height: 25px" class="down_select" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("NGUOI_NHAN")%>
                    <p>
                        <input mkv="true" id="NGUOI_NHAN" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("MEM_ID_PXK")%>
                    <p>
                        <input mkv="true" id="MEM_ID" type="hidden" />
                        <input mkv="true" id="mkv_MEM_ID" type="text" onfocus="Find(this);chuyenphim(this);MEM_IDSearch(this);"
                            style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("KHO_ID")%>
                    <p>
                        <input mkv="true" id="KHO_ID" type="hidden" />
                        <input mkv="true" id="mkv_KHO_ID" type="text" onfocus="Find(this);chuyenphim(this);KHO_IDSearch(this);"
                            class="down_select" style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("DU_AN_ID")%>
                    <p>
                        <input mkv="true" id="DU_AN_ID" type="hidden" />
                        <input mkv="true" id="mkv_DU_AN_ID" type="text" onfocus="Find(this);chuyenphim(this);DU_AN_IDSearch(this);"
                            class="down_select" style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("LY_DO_XUAT_ID")%>
                    <p>
                        <input mkv="true" id="LY_DO_XUAT_ID" type="hidden" />
                        <input mkv="true" id="mkv_LY_DO_XUAT_ID" type="text" onfocus="Find(this);chuyenphim(this);LY_DO_XUAT_IDSearch(this);"
                            class="down_select" style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("CHUNG_TU")%>
                    <p>
                        <input mkv="true" id="CHUNG_TU" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("GHI_CHU")%>
                    <p>
                        <input mkv="true" id="GHI_CHU" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("YEU_CAU_ID")%>
                    <p>
                        <input mkv="true" id="YEU_CAU_ID" type="hidden" />
                        <input mkv="true" id="mkv_YEU_CAU_ID" type="text" onfocus="Find(this);chuyenphim(this);YEU_CAU_IDSearch(this);"
                            class="down_select" style="width: 280px; height: 25px" class="txtformat" />
                    </p>
                </div>
            </div>
            <hr>
            <p align="left">
                <input id="timKiem" search="<%=IsView%>" type="button" value="<%=GetCaption("find") %>"
                    style="width: 120px; height: 25px" class="btn" />
            </p>
        </div>
        <div class="body-div-button">
            <p class="in-a">
                <input id="luu" edit="false" add="false" type="button" style="display: none; width: 120px;
                    height: 25px" type="button" value="<%=GetCaption("save") %> " class="btn" />
                <input id="moi" type="button" type="button" style="display: none; width: 120px; height: 25px"
                    value="<%=GetCaption("new") %>" class="btn" />
                <input id="xoa" delete="false" type="button" style="display: none; width: 120px;
                    height: 25px" value="<%=GetCaption("delete") %>" class="btn" />
                <input id="addNew" add="<%=IsAdd%>" type="button" value="<%=GetCaption("addnew") %>"
                    onclick="createNew()" style="width: 120px; height: 25px" class="btn" />
                <input id="Button1" type="button" value="<%=GetCaption("dong") %>" onclick="backs();" class="btn" style="width: 120px;
                    height: 25px" />
            </p>
            <a class="reload" onclick="Find(this)"></a>
            <div class="in-b" id="tableAjax_KH_PHIEU_XUAT_KHO">
            </div>
        </div>
        </div>
    </fieldset>
</asp:Content>
