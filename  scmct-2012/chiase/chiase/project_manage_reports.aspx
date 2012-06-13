<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="project_manage_reports.aspx.cs" Inherits="chiase.project_manage_reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<script type="text/javascript">
    function backs() {
        window.location = "admin.aspx";
    }
    function showdetail(obj) {
        var divid = document.getElementById("project_name");
        var start_date = document.getElementById("start_date");
        var end_date = document.getElementById("end_date");
        var rp1 = document.getElementById("rp1");
        var rp2 = document.getElementById("rp2");
        var rp3 = document.getElementById("rp3");
        var rp4 = document.getElementById("rp4");
        if (obj.value == "None") {
            divid.innerHTML = "";
            rp1.innerHTML = "Sách quyên góp được";
            rp2.innerHTML = "Danh sách đóng góp cho dự án";
            rp3.innerHTML = "Danh sách tham gia dự án";
            rp4.innerHTML = "Báo cáo tổng kết dự án";
            return;
        }
        //re-fill the link
        rp1.innerHTML = "<a style='color:White;font-weight:bold;text-decoration: none;' target='_blank' title='Xem chi tiết' href='detail_list.aspx?id=" + obj.value + "'>Sách quyên góp được</a>";
        rp2.innerHTML = "<a style='color:White;font-weight:bold;text-decoration: none;' target='_blank' title='Xem chi tiết' href='contributor_list.aspx?id=" + obj.value + "'>Danh sách đóng góp cho dự án</a>";
        rp3.innerHTML = "<a style='color:White;font-weight:bold;text-decoration: none;' target='_blank' title='Xem chi tiết' href='member_list_project.aspx?id=" + obj.value + "' >Danh sách tham gia dự án</a>";
        rp4.innerHTML = "<a style='color:White;font-weight:bold;text-decoration: none;' target='_blank' title='Xem chi tiết' href='project_reports.aspx?id=" + obj.value + "' >Báo cáo tổng kết dự án</a>"
        
        var url = "project_manage_reports.aspx?project_id=" + obj.value;
        var content = getValXML(url);
        divid.innerHTML = readXMLFormat(content, "<project_name>", "</project_name>");
        start_date.innerHTML = "<b>Bắt đầu:&nbsp</b>" +  readXMLFormat(content, "<start_date>", "</start_date>");
        end_date.innerHTML = "<b>Kết thúc:&nbsp</b>"+ readXMLFormat(content, "<end_date>", "</end_date>");

    }
</script>
<fieldset>
                <table border="0" cellpadding=5 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
                <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="6">BÁO CÁO DỰ ÁN</td></tr>
                               <tr>
                <td colspan=4 style="color:White;font-weight:bold">
                    *-Chọn dự án sau đó chọn báo cáo cần xem.
                </td>
                </tr>
                <tr bgcolor="White">
                <td width=10%>
                <b>Chọn dự án:</b>
                </td>
                <td width=20%>
                <asp:DropDownList id="drop_projects" runat="server" onChange="showdetail(this)" ></asp:DropDownList>
                </td>

                <td width=10%>
                <b>Tên dự án:</b>
                </td>
                <td>
                    <div id="project_name"></div>
                </td>
                <td>
                    </b><div id="start_date"><b>Bắt đầu:&nbsp</div>
                </td>
                <td>
                    </b><div id="end_date"><b>Kết thúc:&nbsp</div>
                </td>
                </tr>
                <tr>
                <td colspan=6 style="color:White;font-weight:bold" align="center"><br>
                <asp:Label id="lbl_project_reports" runat="server" Text=""><table border=0><tr><td><div id="rp1" class="btn"><a style="color:White;font-weight:bold" title="Xem chi tiết" >Sách quyên góp được</a></div></td><td> </td><td> <div id="rp2" class="btn"><a style="color:White;font-weight:bold" title="Xem chi tiết"  >Danh sách đóng góp cho dự án</a></div></td><td> </td><td> <div id="rp3" class="btn"><a style="color:White;font-weight:bold" title="Xem chi tiết"  >Danh sách tham gia dự án</a></div></td><td> </td><td> <div id="rp4" class="btn"><a style="color:White;font-weight:bold" title="Xem chi tiết"  >Báo cáo tổng kết dự án</a></div></td></tr></table></asp:Label>
                </td>
                </tr>
                <tr>
                <td colspan=6>
                    <hr>
                </td>
                </tr>

                <tr>
                <td colspan=6>
                    <input id="Button3" type="button" value="Đóng" onclick="backs();" style="width:120px;height:25px" class="btn"/>
                </td>
                </tr>
                    
                </table>
</fieldset>
</asp:Content>
