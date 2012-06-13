<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="finance_reports.aspx.cs" Inherits="chiase.finance_reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<link rel="stylesheet" type="text/css" media="all" href="Styles/jsDatePick_ltr.min.css" />
<script type="text/javascript" src="Scripts/jsDatePick.min.1.3.js"></script>
<script type="text/javascript">
    var start_date = "";
    var end_date = "";
    var project_id = "";


    function return_link(id) {
        var contentUrl = "";
        var windowname = 'mywindow' + id;
        start_date = document.getElementById("start_date").value;
        end_date = document.getElementById("end_date").value;
        project_id = document.getElementById("drop_project").value;

        contentUrl = "detail_finance_reports.aspx?start_date=" + start_date + "&end_date=" + end_date;
        if (project_id != "None")
            contentUrl = contentUrl + "&project_id=" + project_id;
            window.open(contentUrl, windowname, 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
    }



    function backs() {
        window.location = "admin.aspx";
    }

    function showdetail_project(obj) {
        start_date = document.getElementById("start_date").value;
        end_date = document.getElementById("end_date").value;

        var project_id = document.getElementById("project_id");
        var project_name = document.getElementById("project_name");
        var from_date = document.getElementById("from_date");
        var to_date = document.getElementById("to_date");

        if (obj.value == "None") {
            project_name.innerHTML = "";
            from_date.innerHTML = "";
            to_date.innerHTML = "";
            project_id.innerHTML = "<font color=red>Bạn chọn xem tất cả dự án</font>";
            return;
        }
        var url = "finance_reports.aspx?project_id=" + obj.value;
        var content = getValXML(url);
        project_id.innerHTML = readXMLFormat(content, "<project_id>", "</project_id>");
        project_name.innerHTML = readXMLFormat(content, "<project_name>", "</project_name>");
        from_date.innerHTML = "<b>Ngày bắt đầu:</b> "+ readXMLFormat(content, "<from_date>", "</from_date>");
        to_date.innerHTML = "<b>Ngày kết thúc:</b> " + readXMLFormat(content, "<to_date>", "</to_date>");
    }

    window.onload = function () {
        new JsDatePick({ useMode: 2, target: "start_date", dateFormat: "%d/%m/%Y" });
        new JsDatePick({ useMode: 2, target: "end_date", dateFormat: "%d/%m/%Y" });
    };

</script>
<fieldset>
               <table border="0" cellpadding=5 cellspacing=0 width="100%"  style="border:1px solid #CCFFFF;color:Black">
                <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="8">BÁO CÁO THU CHI THEO DỰ ÁN</td></tr>
                <tr>
                <td colspan=8 style="color:White;font-weight:bold">
                    *-Mặc định là xem báo cáo cho tất cả các dự án.<br>
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
                <b>Chọn dự án:</b>
                </td>
                <td colspan=7 >
                <table><tr><td><asp:DropDownList id="drop_project" ClientIDMode="Static" runat="server" onChange="showdetail_project(this)" ></asp:DropDownList></td>
 

                <tr></table>
                </td>
                </tr>
                <tr bgcolor="White">
                <td width=10%  align="right">
                <b>Mã dự án:</b>
                </td>
                <td>
                    <div id="project_id"><font color=red>Bạn chọn xem tất dự án</font></div>
                </td>
                <td width=10%>
                <b>Tên dự án:</b>
                </td>
                <td>
                    <div id="project_name"></div>
                </td>

                <td>
                    <div id="from_date"><b>Ngày bắt đầu:</b></div>
                </td>
        
                <td>
                    <div id="to_date"><b>Ngày kết thúc:</b></div>
                </td>
                </tr>
                
                <tr>
                <td colspan=8 style="color:White;font-weight:bold" align="center"><br>
                <!--<table border=0><tr><td><div id="rp1"><a style="color:White;font-weight:bold" title="Xem chi tiết" >Sách quyên góp được</a></div></td><td> |</td><td> <div id="rp2"><a style="color:White;font-weight:bold" title="Xem chi tiết"  >Danh sách đóng góp cho dự án</a></div></td><td> |</td><td> <div id="rp3"><a style="color:White;font-weight:bold" title="Xem chi tiết"  >Danh sách tham gia dự án</a></div></td><td> |</td><td> <div id="rp4"><a style="color:White;font-weight:bold" title="Xem chi tiết"  >Báo cáo tổng kết dự án</a></div></td></tr></table>-->
                <asp:Label id="lbl_finance_reports" runat="server" Text=""><table border=0 class="btn"><tr><td title="Xem báo cáo thu chi" style="cursor:pointer" onclick="return_link('1');">Báo cáo thu chi</td></tr></table></asp:Label>
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
