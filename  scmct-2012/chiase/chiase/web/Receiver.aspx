<%@ Page Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="True"
    CodeBehind="Receiver.aspx.cs" Inherits="chiase.Receiver" Title="Phiếu nhập kho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <script type="text/javascript" src="../javascript/KH_PHIEU_NHAP_KHO3.js">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <%--  <p class="header-div">
                 <%=GetCaption("KH_PHIEU_NHAP_KHO")%>
           </p>--%>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=GetCaption("MA_PNK")%>
                </h4>
                <p>
                    <input mkv="true" id="MA_PNK" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("NGUOI_NHAP")%>
                </h4>
                <p>
                    <input mkv="true" id="NGUOI_NHAP" type="hidden" />
                    <input mkv="true" id="mkv_NGUOI_NHAP" type="text" onfocus="Find(this);chuyenphim(this);NGUOI_NHAPSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("NGAY_NHAP")%>
                </h4>
                <p>
                    <input mkv="true" id="NGAY_NHAP" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("MEM_ID")%>
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
                    <%=GetCaption("LY_DO_NHAP_ID")%>
                </h4>
                <p>
                    <input mkv="true" id="LY_DO_NHAP_ID" type="hidden" />
                    <input mkv="true" id="mkv_LY_DO_NHAP_ID" type="text" onfocus="Find(this);chuyenphim(this);LY_DO_NHAP_IDSearch(this);"
                        class="down_select" style="width: 90%" />
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
            <div class="div-Out">
                <h4>
                    <%=GetCaption("CHUNG_TU")%>
                </h4>
                <p>
                    <input mkv="true" id="CHUNG_TU" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxKH_PHIEU_NHAP_KHO_CT($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_KH_PHIEU_NHAP_KHO_CT" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="true" add="true" type="button" value="<%=GetCaption("save") %> " />
            <input id="moi" type="button" value="<%=GetCaption("new") %>" />
            <input id="xoa" delete="true" type="button" style="display: none" value="<%=GetCaption("delete") %>" />
            <input id="timKiem" style="display: none" search="true" type="button" value="<%=GetCaption("find") %>" />
        </p>
    </div>
</asp:Content>
