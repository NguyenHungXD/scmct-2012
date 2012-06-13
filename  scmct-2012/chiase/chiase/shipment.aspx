<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shipment.aspx.cs" Inherits="chiase.shipment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>.:SCMCT-Cổng thông tin SCMCT:. - PHIẾU XUẤT KHO</title>
    <link href="Styles/templatemain_style.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="css/stocksection.css" rel="Stylesheet" />
    <link type="text/css" href="css/jquery-ui.css" rel="Stylesheet" />
    <link type="text/css" href="css/jtable.css" rel="Stylesheet" />
    <link type="text/css" href="css/timepicker.css" rel="Stylesheet" />
    <link type="text/css" href="css/treeview.css" rel="Stylesheet" />
    <link type="text/css" href="css/jquery.autocomplete.css" rel="Stylesheet" />
    <script type="text/javascript" src="Scripts/ajax_script.js"></script>
    <script src="js/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script src="js/jquery.autocomplete.js" type="text/javascript"></script>
    <script src="js/jquery.validate.js" type="text/javascript"></script>
    <script src="js/myscriptvalid.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/timepicker.js"></script>
    <script type="text/javascript" src="js/myscript.js"></script>
    <script type="text/javascript" src="js/myscript.jqr.js"></script>
    <script type="text/javascript" src="js/treeview.js"></script>
    <script type="text/javascript" src="javascript/KH_PHIEU_XUAT_KHO3.js">
    </script>
    <script type="text/javascript">
        function afterSelectHH(ctrl, hhid) {

            var tr = ctrl.parentNode.parentNode;
            //            var hhName = tr.cells[3].childNodes["HH_NAME"];
            //            var nhhName = tr.cells[4].childNodes["NHH_NAME"];
            var hhName = tr.cells[3].childNodes[0];
            var nhhName = tr.cells[4].childNodes[0];
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
            xmlHttp.open("GET", "ajax/DM_HANG_HOA_ajax2.aspx?do=getHH&HH_ID=" + hhid + "&times=" + Math.random(), true);
            xmlHttp.send(null);
        }

        function txtChangeHH(ctrl) {
            var tr = ctrl.parentNode.parentNode;
            //            var hhID = tr.cells[2].childNodes["HH_ID"];
            //            var hhName = tr.cells[3].childNodes["HH_NAME"];
            //            var nhhName = tr.cells[4].childNodes["NHH_NAME"];
            var hhID = tr.cells[2].childNodes[0];
            var hhName = tr.cells[3].childNodes[0];
            var nhhName = tr.cells[4].childNodes[0];
            hhID.value = "";
            hhName.value = "";
            nhhName.value = "";


        }

        function txtClearHH(rowIndex) {
            var table = document.getElementById("gridTable");
            var tr = table.rows[rowIndex];
            //            var hhID = tr.cells[2].childNodes["HH_ID"];
            //            var hhName = tr.cells[3].childNodes["HH_NAME"];
            //            var nhhName = tr.cells[4].childNodes["NHH_NAME"];
            var hhID = tr.cells[2].childNodes[0];
            var hhName = tr.cells[3].childNodes[0];
            var nhhName = tr.cells[4].childNodes[0];
            hhID.value = "";
            hhName.value = "";
            nhhName.value = "";
        }

        function confirms() {
            if (confirm("Bạn thực sự muốn đóng không?\n Chọn [OK] để tiếp tục, chọn [Cancel] để Đóng.")) {
                window.close();
            }
            return false;

        }
        function setDefaultValues() {
            document.getElementById("LY_DO_XUAT_ID").value = 1;
            document.getElementById("mkv_LY_DO_XUAT_ID").value = 'Xuất quyên góp';
            document.getElementById("NGAY_XUAT").value = getCurrentddMMyyyy();
            document.getElementById("NGUOI_XUAT").value = "<%=GetLoginID()%>";
            document.getElementById("mkv_NGUOI_XUAT").value = "<%=GetLoginFullName() %>";
        }
        function validateOnSave() {

            var captions = Array("Người xuất", "Ngày xuất", "Xuất cho", "Kho xuất", "Dự án", "Loại xuất kho");
            var ctlInputs = Array("mkv_NGUOI_XUAT", "NGAY_XUAT", "mkv_MEM_ID", "mkv_KHO_ID", "mkv_DU_AN_ID", "mkv_LY_DO_XUAT_ID");
            var ctlValues = Array("NGUOI_XUAT", null, "MEM_ID", "KHO_ID", "DU_AN_ID", "LY_DO_XUAT_ID");
            var typeChecks = Array("R", "R D", "R", "R", "R", "R");

            var isValid = checkRequiredArray(captions, ctlInputs, ctlValues, typeChecks);


            var tableHH = document.getElementById("gridTable");
            var rowsCount = tableHH.rows.length;
            var error = document.getElementById("show_eror");
            //Bỏ dòng đầu (header) và dògn cuối (note)

            var hhid = null;
            var mahh = null;
            var hhName = null;
            var nhhID = null;
            var nhhName = null;
            var soluong = null;
            var dongia = null;
            var thanhtien = null;
            var khoachinh = null;
            var ghichu = null;
            var pnkID = null;
            var pnkName = null;
            var rowDatas = 0;
            var ctrlAll = null;
            var ctrlTye = null;
            var check = false;
            for (var x = 1; x < rowsCount - 1; x++) {

                hhid = $("#" + tableHH.id).find("tr").eq(x).find("[id=HH_ID]")[0];
                mahh = $("#" + tableHH.id).find("tr").eq(x).find("[id=mkv_HH_ID]")[0];
                soluong = $("#" + tableHH.id).find("tr").eq(x).find("[id=SO_LUONG]")[0];
                dongia = $("#" + tableHH.id).find("tr").eq(x).find("[id=DON_GIA]")[0];
                thanhtien = $("#" + tableHH.id).find("tr").eq(x).find("[id=THANH_TIEN]")[0];
                ghichu = $("#" + tableHH.id).find("tr").eq(x).find("[id=GHI_CHU]")[0];
                khoachinh = $("#" + tableHH.id).find("tr").eq(x).find("[id=idkhoachinh]")[0];
                pnkID = $("#" + tableHH.id).find("tr").eq(x).find("[id=PNK_CT_ID]")[0];
                pnkName = $("#" + tableHH.id).find("tr").eq(x).find("[id=mkv_PNK_CT_ID]")[0];

                captions = Array("Hàng hóa", "Số lượng", "Nhập từ phiếu nhập nào?");
                ctlInputs = Array(mahh, soluong, pnkName);
                ctlValues = Array(hhid, null, null, null, pnkID);
                typeChecks = Array("R", "R Z", "R");


                if (khoachinh.value != "")//Dòng cũ, sửa
                {
                    check = true;
                } else //
                {
                    ctrlAll = Array(mahh, soluong, dongia, thanhtien, ghichu, pnkName);
                    ctrlTye = Array("T", "N", "N", "N", "T", "T");
                    var empty = isAllEmpty(ctrlAll, ctrlTye);
                    if (empty == false) {

                        check = true;
                    } else {
                        check = false;
                    }

                }
                if (check == true) {
                    rowDatas++;
                    var ok = checkRequiredArray(captions, ctlInputs, ctlValues, typeChecks);
                    if (ok == false)
                        isValid = false;
                }

            }

            if (rowDatas == 0) {
                error.innerHTML = "Vui lòng nhập ít nhất 1 hàng hóa!";
                isValid = false;
            } else
                error.innerHTML = "";
            if (isValid == false)
                alert("Thông tin nhập không hợp lệ. \nVui lòng nhập lại theo hướng dẫn!");
            return isValid;
        }
    </script>
</head>
<body style="background: #0099FF">
    <table border="0" width="100%">
        <tr align="center">
            <td valign="middle">
                <br>
                <fieldset style="color: Black; width: 1024px; text-align: left">
                    <form id="form1" runat="server">
                    <div class="body-div">
                        <p class="header-div">
                            <%=GetCaption("KH_PHIEU_XUAT_KHO")%>
                        </p>
                        <div class="in-a">
                            <p style="color: Blue; font-weight: bold">
                                -Nhập thông tin chi tiết cho phiếu xuất
                                <br>
                                -Mã phiếu xuất sẽ được tạo tự động khi bạn lưu thành công
                                <br>
                                (<font color="red"><b>*</b></font>)Thông tin bắt buộc nhập
                            </p>
                            <hr>
                            <div class="div-Out">
                                <%=GetCaption("MA_PXK")%>
                                <p>
                                    <input mkv="true" readonly="readonly" id="MA_PXK" type="text" onfocus="Find(this);chuyenphim(this);"
                                        style="width: 250px; height: 25px" class="txtformat" />
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("NGUOI_XUAT")%>
                                <p>
                                    <input mkv="true" id="NGUOI_XUAT" type="hidden" />
                                    <input mkv="true" id="mkv_NGUOI_XUAT" type="text" onfocus="Find(this);chuyenphim(this);NGUOI_XUATSearch(this);"
                                        class="down_select" style="width: 250px; height: 25px" class="txtformat" />&nbsp<font
                                            color="red" size="3"><b>*</b></font>
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("NGAY_XUAT")%>
                                <p>
                                    <input mkv="true" id="NGAY_XUAT" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                                        onblur="TestDate(this);" style="width: 250px; height: 25px" class="down_select" />&nbsp<font
                                            color="red" size="3"><b>*</b></font>
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("NGUOI_NHAN")%>
                                <p>
                                    <input mkv="true" id="NGUOI_NHAN" type="text" onfocus="Find(this);chuyenphim(this);"
                                        style="width: 250px; height: 25px" class="txtformat" />
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("MEM_ID_PXK")%>
                                <p>
                                    <input mkv="true" id="MEM_ID" type="hidden" />
                                    <input mkv="true" id="mkv_MEM_ID" type="text" onfocus="Find(this);chuyenphim(this);MEM_IDSearch(this);"
                                        class="down_select" style="width: 250px; height: 25px" />&nbsp<font color="red" size="3"><b>*</b></font>
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("KHO_ID")%>
                                <p>
                                    <input mkv="true" id="KHO_ID" type="hidden" />
                                    <input mkv="true" id="mkv_KHO_ID" type="text" onfocus="Find(this);chuyenphim(this);KHO_IDSearch(this);"
                                        class="down_select" style="width: 250px; height: 25px" class="txtformat" />&nbsp<font
                                            color="red" size="3"><b>*</b></font>
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("DU_AN_ID")%>
                                <p>
                                    <input mkv="true" id="DU_AN_ID" type="hidden" />
                                    <input mkv="true" id="mkv_DU_AN_ID" type="text" onfocus="Find(this);chuyenphim(this);DU_AN_IDSearch(this);"
                                        class="down_select" style="width: 250px; height: 25px" class="txtformat" />&nbsp<font
                                            color="red" size="3"><b>*</b></font>
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("LY_DO_XUAT_ID")%>
                                <p>
                                    <input mkv="true" id="LY_DO_XUAT_ID" type="hidden" />
                                    <input mkv="true" id="mkv_LY_DO_XUAT_ID" type="text" onfocus="Find(this);chuyenphim(this);LY_DO_XUAT_IDSearch(this);"
                                        class="down_select" style="width: 250px; height: 25px" class="txtformat" />&nbsp<font
                                            color="red" size="3"><b>*</b></font>
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("CHUNG_TU")%>
                                <p>
                                    <input mkv="true" id="CHUNG_TU" type="text" onfocus="Find(this);chuyenphim(this);"
                                        style="width: 250px; height: 25px" class="txtformat" />
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("GHI_CHU")%>
                                <p>
                                    <input mkv="true" id="GHI_CHU" type="text" onfocus="Find(this);chuyenphim(this);"
                                        style="width: 250px; height: 25px" class="txtformat" />
                                </p>
                            </div>
                            <div class="div-Out">
                                <%=GetCaption("YEU_CAU_ID")%>
                                <p>
                                    <input mkv="true" id="YEU_CAU_ID" type="hidden" />
                                    <input mkv="true" id="mkv_YEU_CAU_ID" type="text" onfocus="Find(this);chuyenphim(this);YEU_CAU_IDSearch(this);"
                                        class="down_select" style="width: 250px; height: 25px" class="txtformat" />
                                </p>
                            </div>
                        </div>
                        <hr>
                        <input id="timKiem" style="display: none; width: 120px; height: 25px" class="btn"
                            search="true" type="button" value="<%=GetCaption("find") %>" />
                        <div id="show_eror" style="text-align: center; color: Red; font-weight: bold">
                        </div>
                        <a class="reload" onclick="loadTableAjaxKH_PHIEU_XUAT_KHO_CT($.mkv.queryString('idkhoachinh'))">
                        </a>
                        <div id="tableAjax_KH_PHIEU_XUAT_KHO_CT" class="in-b">
                        </div>
                    </div>
                    <div class="body-div-button">
                        <p class="in-a">
                            <input id="luu" edit="<%=IsEdit%>" add="<%=IsAdd %>" type="button" value="<%=GetCaption("save") %>"
                                style="width: 120px; height: 25px" class="btn" />
                            <input id="moi" type="button" value="<%=GetCaption("new") %>" style="width: 120px;
                                height: 25px" class="btn" />
                            <input id="xoa"  delete="<%=IsDelete %>" type="button" value="<%=GetCaption("delete") %>" style="display: none;
                                width: 120px; height: 25px" class="btn" />
                            <input id="Button1" type="button" value="<%=GetCaption("dong") %>" onclick="confirms();" style="width: 120px;
                                height: 25px" class="btn" />
                        </p>
                    </div>
                    </form>
                </fieldset>
            </td>
        </tr>
    </table>
</body>
</html>
