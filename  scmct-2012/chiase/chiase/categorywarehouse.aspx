<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="categorywarehouse.aspx.cs" Inherits="chiase.categoryWarehouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <head>
        <link type="text/css" href="css/stocksection.css" rel="Stylesheet" />
    </head>
    <script type="text/javascript" src="javascript/KH_DM_KHO2.js"></script>
    <script src="js/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.autocomplete.js" type="text/javascript"></script>
    <script src="js/jquery.validate.js" type="text/javascript"></script>
    <script src="js/myscriptvalid.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/timepicker.js"></script>
    <script type="text/javascript" src="js/myscript.js"></script>
    <script type="text/javascript" src="js/myscript.jqr.js"></script>
    <script type="text/javascript" src="js/treeview.js"></script>
    <script>
        function backs() {
            window.location = "admin.aspx";
        }
    </script>
    <fieldset style="color: #000000">
        <div class="body-div">
            <p class="header-div">
                <%=GetCaption("KH_DM_KHO")%></p>
            <div class="in-a">
                <p style="color: Blue; font-weight: bold">
                    Điều kiện tìm kiếm</p>
                <hr>
                <div class="div-Out">
                    Tên kho
                    <!--<=GetCaption("NAME")%>-->
                    <p>
                        <input mkv="true" id="NAME" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 240px;
                            height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("DIA_CHI")%>
                    <p>
                        <input mkv="true" id="DIA_CHI" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 240px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("DIEN_THOAI")%>
                    <p>
                        <input mkv="true" id="DIEN_THOAI" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 240px; height: 25px" class="txtformat" />
                    </p>
                </div>
                <div class="div-Out">
                    <%=GetCaption("NGUOI_QUAN_LY")%>
                    <p>
                        <input mkv="true" id="NGUOI_QUAN_LY" type="text" onfocus="Find(this);chuyenphim(this);"
                            style="width: 240px; height: 25px" class="txtformat" />
                    </p>
                </div>
            </div>
            <hr>
            <input id="timKiem" search="<%=IsView %>" type="button" value="<%=GetCaption("find") %>"
                style="width: 120px; height: 25px" class="btn" />
        </div>
        <div class="body-div-button">
            <p class="in-a">
                <input id="luuTable_1" edit="<%=IsEdit %>" add="<%=IsAdd %>" type="button" style="margin-right: 10px;
                    width: 120px; height: 25px" value="<%=GetCaption("save") %>" class="btn" />
                <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#GetCaption("new") %>'
                    style="width: 120px; height: 25px" class="btn" />
                <input id="Button1" type="button" value="<%=GetCaption("dong") %>" onclick="backs();"
                    class="btn" style="width: 120px; height: 25px" />
            </p>
            <a class="reload" onclick="Find(this)"></a>
            <div class="in-b" id="tableAjax_KH_DM_KHO">
            </div>
            <p class="in-c">
                <input id="luuTable_2" edit="<%=IsEdit %>" add="<%=IsAdd %>" type="button" value='<%=GetCaption("save") %>'
                    style="width: 120px; height: 25px" class="btn" />
            </p>
        </div>
    </fieldset>
</asp:Content>
