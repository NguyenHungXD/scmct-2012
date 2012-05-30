<%@ Page Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true"
    CodeBehind="Transfer.aspx.cs" Inherits="chiase.Transfer" Title="Phiếu chuyển kho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <script type="text/javascript" src="../javascript/KH_PHIEU_CHUYEN_KHO3.js">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
      <%--  <p class="header-div">
            <%=GetCaption("KH_PHIEU_CHUYEN_KHO")%>
        </p>--%>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=GetCaption("MA_PCK")%>
                </h4>
                <p>
                    <input mkv="true" id="MA_PCK" readonly="readonly" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%; background-color:#DCDCDC" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("NGUOI_CHUYEN")%>
                </h4>
                <p>
                    <input mkv="true" id="NGUOI_CHUYEN" type="hidden" />
                    <input mkv="true" id="mkv_NGUOI_CHUYEN" type="text" onfocus="Find(this);chuyenphim(this);NGUOI_CHUYENSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("NGAY_CHUYEN")%>
                </h4>
                <p>
                    <input mkv="true" id="NGAY_CHUYEN" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("KHO_XUAT_ID")%>
                </h4>
                <p>
                    <input mkv="true" id="KHO_XUAT_ID" type="hidden" />
                    <input mkv="true" id="mkv_KHO_XUAT_ID" type="text" onfocus="Find(this);chuyenphim(this);KHO_XUAT_IDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=GetCaption("KHO_NHAP_ID")%>
                </h4>
                <p>
                    <input mkv="true" id="KHO_NHAP_ID" type="hidden" />
                    <input mkv="true" id="mkv_KHO_NHAP_ID" type="text" onfocus="Find(this);chuyenphim(this);KHO_NHAP_IDSearch(this);"
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
                    <%=GetCaption("GHI_CHU")%>
                </h4>
                <p>
                    <input mkv="true" id="GHI_CHU" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxKH_PHIEU_CHUYEN_KHO_CT($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_KH_PHIEU_CHUYEN_KHO_CT" class="in-b">
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
