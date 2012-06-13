<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="contributor_list.aspx.cs" Inherits="chiase.contributor_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<script>
        function backs() {
            window.close();
        }
        function PrintContents(div) {
            var DocumentContainer = document.getElementById(div);
            var WindowObject = window.open('', "TrackHistoryData",
                              "toolbars=no,scrollbars=no,status=no,resizable=no");
            WindowObject.document.write(DocumentContainer.innerHTML);
            //alert(ctrl);
            WindowObject.document.close();
            WindowObject.focus();
            WindowObject.print();
            WindowObject.close();
        }
</script>

<fieldset>
    <div id="mydiv">
                <table border="0" cellpadding="4" cellspacing="1" width="100%"  style="color:White;" >
        <tr>
        <td width="15%">
        Mã dự án:   
        </td>
        <td style="font-weight:bold;">
        <asp:Label ID="lbl_ma_du_an" runat="server"></asp:Label>
        </td>
        <td width="15%">
        Tên dự án:  
        </td>
        <td style="font-weight:bold;">
        <asp:Label ID="lbl_ten_du_an" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td width="15%">
        Bắt đầu:   
        </td>
        <td style="font-weight:bold;">
        <asp:Label ID="lbl_start_date" runat="server"></asp:Label>
        </td>
        <td width="15%">
        Kết thúc:  
        </td>
        <td style="font-weight:bold;">
        <asp:Label ID="lbl_end_date" runat="server"></asp:Label>
        </td>
        </tr>
        </table>

  <table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" 
                colspan="5">DANH SÁCH QUYÊN GÓP CHO DỰ ÁN</td></tr>
<asp:Repeater ID="contributor_lists" runat="server" onitemdatabound="contributor_lists_ItemDataBound">
    <HeaderTemplate>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="5%">
            <p>STT</p>
        </td>
        <td width="17%">
            Họ tên
        </td>
        <td width="10%">
            Địa chỉ
        </td>
        <td width="10%">
            Số lượng
        </td>
       <td width="10%">
            Chi tiết
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor="white" style="text-align:center;">
                <td valign="middle" >
            <%= no++ %> 
        </td>
        <td valign="middle">
            <table cellpadding=3 cellspacing=0 border=0><td><img src="<%# Eval("avatar_path","images/avatars/{0}") %>" width="50px" height="50px"></td>
            <td><%# Eval("nguoi_quyen_gop")%>(<%# Eval("username")%>)</td>
            </tr>
            </table>
        </td>
        <td>
            <%# Eval("address")%>
        </td>
        <td align="center">
            <%# Eval("so_luong")%>
        </td>
        <td align="center">
            <asp:HyperLink target="_blank" id="view_details" runat="server" title="Xem chi tiết" class="link_main"></asp:HyperLink>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    </asp:Repeater>
    <tr bgcolor="#FCEFEF" style="text-align:center;">
    <td colspan=3 align="right" style="text-align:right;">
    <b>Tổng cộng:</b>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums" runat="server" Text="<%= v_totals %>"> </asp:Label>
    </td>
    <td>&nbsp
    </td>
    </tr>

    <tr>
    <td colspan="5" style="color:white" align="right">
    <hr>
        Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>
    </div>
     <table width="100%">
     <tr>
    <td>
            <input id="Button3" type="button" value="In" class="btn" style="width:100px;height:25px" onclick="PrintContents('mydiv')" /> &nbsp
        <input id="Button4" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/>
    </td>
    </tr>
    </table>
</fieldset>
</asp:Content>

