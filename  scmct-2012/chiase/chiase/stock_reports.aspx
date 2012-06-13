<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="stock_reports.aspx.cs" Inherits="chiase.stock_reports" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<link rel="stylesheet" type="text/css" media="all" href="Styles/jsDatePick_ltr.min.css" />
<script type="text/javascript" src="Scripts/jsDatePick.min.1.3.js"></script>
<script type="text/javascript">
    var start_date = "";
    var end_date = "";
    var stock_id = "";
    var products_id = "";

    function return_link(id) {
        var contentUrl = "";
        var windowname = 'mywindow' + id;
        start_date = document.getElementById("start_date").value;
        end_date = document.getElementById("end_date").value;
        stock_id = document.getElementById("drop_stock").value;
        products_id = document.getElementById("drop_products").value;

        contentUrl = "detail_report_by_stocks.aspx?start_date=" + start_date + "&end_date=" + end_date;
        if (stock_id != "None")
            contentUrl=contentUrl+ "&stock_id=" + stock_id;

        if (products_id != "None")
            contentUrl = contentUrl+ "&product_id=" + products_id;
            
            window.open(contentUrl, windowname, 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
    }
    window.onload = function () {
        new JsDatePick({ useMode: 2, target: "start_date", dateFormat: "%d/%m/%Y" });
        new JsDatePick({ useMode: 2, target: "end_date", dateFormat: "%d/%m/%Y" });
    };

    function backs() {
        window.location = "admin.aspx";
    }
    function showdetail_product(obj) {
        start_date = document.getElementById("start_date").value;
        end_date = document.getElementById("end_date").value;

        var product_id = document.getElementById("product_id");
        var product_name = document.getElementById("product_name");
        var product_type = document.getElementById("product_type");
        
        if (obj.value == "None") {
            product_name.innerHTML = "";
            product_type.innerHTML = "";
            product_id.innerHTML = "<font color=red>Bạn chọn xem tất cả hàng hóa</font>";
            return;
        }
        var url = "stock_reports.aspx?product_id=" + obj.value;
        var content = getValXML(url);
        product_id.innerHTML = readXMLFormat(content, "<product_id>", "</product_id>");
        product_name.innerHTML = readXMLFormat(content, "<product_name>", "</product_name>");
        product_type.innerHTML = readXMLFormat(content, "<product_type>", "</product_type>");
    }
    function showdetail(obj) {
        start_date = document.getElementById("start_date").value;
        end_date = document.getElementById("end_date").value;
        var stock_name = document.getElementById("stock_name");
        var stock_address = document.getElementById("stock_address");
        var stock_phone = document.getElementById("stock_phone");
        var stock_manage_by = document.getElementById("stock_manage_by");
        var all = document.getElementById("idall");
        //var rp1 = document.getElementById("rp1");
//        var rp2 = document.getElementById("rp2");
//        var rp3 = document.getElementById("rp3");
//        var rp4 = document.getElementById("rp4");
        if (obj.value == "None") {
            stock_name.innerHTML = "";
            stock_address.innerHTML = "";
            stock_phone.innerHTML = "";
            stock_manage_by.innerHTML = "";
            stock_name.innerHTML = "<font color=red>Bạn chọn xem tất cả các kho</font>";
            //rp1.innerHTML = "<a style='color:White;font-weight:bold' target='_blank' title='Xem chi tiết' href='detail_list.aspx?start_date=" + start_date + "&end_date=" + end_date + "'>Báo cáo xuất-nhập-tồn theo kho</a>";
           
//            rp2.innerHTML = "Danh sách đóng góp cho dự án";
//            rp3.innerHTML = "Danh sách tham gia dự án";
//            rp4.innerHTML = "Báo cáo tổng kết dự án";
            return;
        }
        //re-fill the link
        //rp1.innerHTML = "<a style='color:White;font-weight:bold' target='_blank' title='Xem chi tiết' href='detail_report_by_stocks.aspx?stock_id=" + obj.value + "&start_date=" + start_date + "&end_date=" + end_date + "'>Báo cáo xuất-nhập-tồn theo kho</a>"; ;

//        rp2.innerHTML = "<a style='color:White;font-weight:bold' target='_blank' title='Xem chi tiết' href='contributor_list.aspx?id=" + obj.value + "'>Danh sách đóng góp cho dự án</a>";
//        rp3.innerHTML = "<a style='color:White;font-weight:bold' target='_blank' title='Xem chi tiết' href='member_list_project.aspx?id=" + obj.value + "' >Danh sách tham gia dự án</a>";
//        rp4.innerHTML = "<a style='color:White;font-weight:bold' target='_blank' title='Xem chi tiết' href='project_reports.aspx?id=" + obj.value + "' >Báo cáo tổng kết dự án</a>"

        var url = "stock_reports.aspx?stock_id=" + obj.value;
        
        var content = getValXML(url);
        stock_name.innerHTML = readXMLFormat(content, "<stock_name>", "</stock_name>");
        stock_address.innerHTML = readXMLFormat(content, "<stock_address>", "</stock_address>");
        stock_phone.innerHTML = readXMLFormat(content, "<stock_phone>", "</stock_phone>");
        stock_manage_by.innerHTML = readXMLFormat(content, "<stock_manage_by>", "</stock_manage_by>");
    }

</script>



<fieldset>
               <table border="0" cellpadding=5 cellspacing=0 width="100%"  style="border:1px solid #CCFFFF;color:Black">
                <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="8">BÁO CÁO XUẤT-NHẬP-TỒN</td></tr>
                <tr>
                <td colspan=8 style="color:White;font-weight:bold">
                    *-Mặc định là xem báo cáo cho tất cả các kho.<br>
                    *-Mặc định là xem báo cáo cho tất cả hàng hóa.<br>
                </td>
                </tr>
                <tr bgcolor="White">
                <td>
                &nbsp
                </td>
               <td align=left colspan=7>
                <b>Từ ngày:</b>
      
                    <input type="text" style="width:200px;height:25px" id="start_date" class="txtformat"  />
            
                <b>Đến ngày:</b>
        
                    <input type="text" style="width:200px;height:25px" id="end_date" class="txtformat" />
 
                </td>
                </tr>
                <tr bgcolor="#CCCCCC">
                <td width=10%>
                <b>Chọn kho:</b>
                </td>
                <td colspan=7 >
                <table><tr><td><asp:DropDownList id="drop_stock" ClientIDMode="Static" runat="server" onChange="showdetail(this)" ></asp:DropDownList></td>
 

                <tr></table>
                </td>
                </tr>
                <tr bgcolor="White">
                <td width=10%  align="right">
                <b>Tên kho:</b>
                </td>
                <td>
                    <div id="stock_name"><font color=red>Bạn chọn xem tất cả các kho</font></div>
                </td>
                <td width=10%>
                <b>Địa chỉ:</b>
                </td>
                <td>
                    <div id="stock_address"></div>
                </td>
                <td width=10%>
                <b>Điện thoại:</b>
                </td>
                <td>
                    <div id="stock_phone"></div>
                </td>
                <td width=10%>
                <b>Quản lý:</b>
                </td>
                <td>
                    <div id="stock_manage_by"></div>
                </td>
                </tr>
                <tr bgcolor="#CCCCCC" >
                <td>
                <b>Chọn hàng:</b>
                </td>
                <td colspan=7 >
                <asp:DropDownList id="drop_products" ClientIDMode="Static" runat="server" onChange="showdetail_product(this)" ></asp:DropDownList>
                </td>
                <tr bgcolor="White">
                <td width=10% align="right">
                <b>Mã hàng:</b>
                </td>
                <td>
                <div id="product_id"><font color=red>Bạn chọn xem tất cả hàng hóa</font></div>
                </td>
                <td>
                <b>Tên hàng:</b>
                </td>
                <td>
               <div id="product_name"></div>
                </td>
                                <td>
                <b>Chủng loại:</b>
                </td>
                <td colspan=3>
               <div id="product_type"></div>
                </td>
                </tr>
                <tr>
                <td colspan=8 style="color:White;font-weight:bold" align="center"><br>
                <!--<table border=0><tr><td><div id="rp1"><a style="color:White;font-weight:bold" title="Xem chi tiết" >Sách quyên góp được</a></div></td><td> |</td><td> <div id="rp2"><a style="color:White;font-weight:bold" title="Xem chi tiết"  >Danh sách đóng góp cho dự án</a></div></td><td> |</td><td> <div id="rp3"><a style="color:White;font-weight:bold" title="Xem chi tiết"  >Danh sách tham gia dự án</a></div></td><td> |</td><td> <div id="rp4"><a style="color:White;font-weight:bold" title="Xem chi tiết"  >Báo cáo tổng kết dự án</a></div></td></tr></table>-->
                <asp:Label id="lbl_stock_reports" runat="server" Text=""><table border=0 class="btn"><tr><td title="Xem báo cáo xuất-nhập-tồn" style="cursor:pointer" onclick="return_link('1');">Báo cáo xuất-nhập-tồn</td></tr></table></asp:Label>
                </td>
                </tr>
                <tr>
                <td colspan=8>
                    <hr>
                </td>
                </tr>
                <tr>
                <td colspan=8>
                    <input id="Button3" type="button" value="Đóng" onclick="backs();" style="width:120px;height:25px" class="btn"/>
                </td>
                </tr>
                </table>
</fieldset>

</asp:Content>
