<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeBehind="ManageOfShipments.aspx.cs" Inherits="chiase.ManageOfShipments" Title="Quản lý phiếu xuất kho" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="Server">
    <script type="text/javascript" src="../javascript/KH_PHIEU_XUAT_KHO1.js">
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
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="Server">
    <div class="body-div">
        <p class="header-div">
            QUẢN LÝ
            <%=GetCaption("KH_PHIEU_XUAT_KHO")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=GetCaption("MA_PXK")%>
                </h4>
                <p>
                    <input mkv="true" id="MA_PXK" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("NGUOI_XUAT")%>
                </h4>
                <p>
                    <input mkv="true" id="NGUOI_XUAT" type="hidden" />
                    <input mkv="true" id="mkv_NGUOI_XUAT" type="text" onfocus="Find(this);chuyenphim(this);NGUOI_XUATSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("NGAY_XUAT")%>
                </h4>
                <p>
                    <input mkv="true" id="NGAY_XUAT" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("NGUOI_NHAN")%>
                </h4>
                <p>
                    <input mkv="true" id="NGUOI_NHAN" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("MEM_ID_PXK")%>
                </h4>
                <p>
                    <input mkv="true" id="MEM_ID" type="hidden" />
                    <input mkv="true" id="mkv_MEM_ID" type="text" onfocus="Find(this);chuyenphim(this);MEM_IDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("KHO_ID")%>
                </h4>
                <p>
                    <input mkv="true" id="KHO_ID" type="hidden" />
                    <input mkv="true" id="mkv_KHO_ID" type="text" onfocus="Find(this);chuyenphim(this);KHO_IDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("DU_AN_ID")%>
                </h4>
                <p>
                    <input mkv="true" id="DU_AN_ID" type="hidden" />
                    <input mkv="true" id="mkv_DU_AN_ID" type="text" onfocus="Find(this);chuyenphim(this);DU_AN_IDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("LY_DO_XUAT_ID")%>
                </h4>
                <p>
                    <input mkv="true" id="LY_DO_XUAT_ID" type="hidden" />
                    <input mkv="true" id="mkv_LY_DO_XUAT_ID" type="text" onfocus="Find(this);chuyenphim(this);LY_DO_XUAT_IDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("CHUNG_TU")%>
                </h4>
                <p>
                    <input mkv="true" id="CHUNG_TU" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("GHI_CHU")%>
                </h4>
                <p>
                    <input mkv="true" id="GHI_CHU" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("YEU_CAU_ID")%>
                </h4>
                <p>
                    <input mkv="true" id="YEU_CAU_ID" type="hidden" />
                    <input mkv="true" id="mkv_YEU_CAU_ID" type="text" onfocus="Find(this);chuyenphim(this);YEU_CAU_IDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
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
        <div class="in-b" id="tableAjax_KH_PHIEU_XUAT_KHO">
        </div>
    </div>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" Height="500px" Width="915px"
        Modal="True" HeaderText="PHIẾU XUẤT HÀNG" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" ScrollBars="Auto"
        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
        LoadingPanelImagePosition="Top" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
        ClientInstanceName="pcForm">
        <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
        </LoadingPanelImage>
        <ContentStyle VerticalAlign="Top">
        </ContentStyle>
        <HeaderStyle Font-Bold="True" Font-Size="16pt" HorizontalAlign="Center" />
        <ClientSideEvents CloseUp="closeUp" Shown="opening" />
    </dx:ASPxPopupControl>
    </div>
   
</asp:Content>
