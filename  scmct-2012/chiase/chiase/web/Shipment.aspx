<%@ Page Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true"
    CodeBehind="Shipment.aspx.cs" Inherits="chiase.Shipment" Title="Phiếu xuất kho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <script type="text/javascript" src="../javascript/KH_PHIEU_XUAT_KHO3.js">
    </script>
    <script type="text/javascript">
        function afterSelectHH(ctrl, hhid) {

            var tr = ctrl.parentNode.parentNode;
            var hhName = tr.cells[3].childNodes["HH_NAME"];          
            var nhhName = tr.cells[4].childNodes["NHH_NAME"];
            hhName.value = "";          
            nhhName.value = "";
            var xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function () {
                if (xmlHttp.readyState == 4) {
                    if (xmlHttp.responseText.length > 0) {
                        var rs = xmlHttp.responseText;
                        hhName.value = readXMLFormat(rs, "<HH_NAME>", "</HH_NAME>");                      
                        nhhName.value = readXMLFormat(rs, "<NHH_NAME>", "</NHH_NAME>");                      
                    }
                }
            }
            xmlHttp.open("GET", "../ajax/DM_HANG_HOA_ajax2.aspx?do=getHH&HH_ID=" + hhid + "&times=" + Math.random(), true);
            xmlHttp.send(null);
        }

        function txtChangeHH(ctrl) {
            var tr = ctrl.parentNode.parentNode;
            var hhID = tr.cells[2].childNodes["HH_ID"];
            var hhName = tr.cells[3].childNodes["HH_NAME"];           
            var nhhName = tr.cells[4].childNodes["NHH_NAME"];
            hhID.value = "";
            hhName.value = "";          
            nhhName.value = "";
          

        }

        function txtClearHH(rowIndex) {
            var table = document.getElementById("gridTable");
            var tr = table.rows[rowIndex];
            var hhID = tr.cells[2].childNodes["HH_ID"];
            var hhName = tr.cells[3].childNodes["HH_NAME"];       
            var nhhName = tr.cells[4].childNodes["NHH_NAME"];
            hhID.value = "";
            hhName.value = "";          
            nhhName.value = "";            
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
       <%-- <p class="header-div">
            <%=GetCaption("KH_PHIEU_XUAT_KHO")%>
        </p>--%>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=GetCaption("MA_PXK")%>
                </h4>
                <p>
                    <input mkv="true" readonly="readonly" id="MA_PXK" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%; background-color:#DCDCDC" />
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
        <a class="reload" onclick="loadTableAjaxKH_PHIEU_XUAT_KHO_CT($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_KH_PHIEU_XUAT_KHO_CT" class="in-b">
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
