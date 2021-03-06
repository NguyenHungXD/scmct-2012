<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detail_transfer_from_reports.aspx.cs" Inherits="chiase.detail_transfer_from_reports" %>
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
<asp:Label id="lbl_error" runat="server" Text=""></asp:Label>
<div id="mydiv">
  <table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="11">BÁO CÁO CHI TIẾT CHUYỂN ĐẾN</td></tr>
<asp:Repeater ID="transfer_from_report_detail" runat="server">
    <HeaderTemplate>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="3%">
            <p>STT</p>
        </td>
        <td width="5%">
            Mã hàng
        </td>
        <td width="10%">
            Tên hàng
        </td>
        <td width="7%">
            Chủng loại
        </td>
        <td width="7%">
            Số lượng
        </td>
        <td width="10%">
            Chuyển từ dự án
        </td>
        <td width="10%">
            Người chuyển
        </td>
        <td width="7%">
            Ngày chuyển
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor="white" style="text-align:center;">
                <td valign="middle" >
            <%= no++ %> 
        </td>
        <td valign="middle">
            <%# Eval("ma_hh")%>
        </td>
        <td valign="middle">
            <%# Eval("name_hh")%>
        </td>
        <td>
            <%# Eval("nhom_hh")%>
        </td>
                <td>
            <%# Eval("so_luong")%>
        </td>
        <td align="center">
            <%# Eval("chuyen_tu_cac_da")%><br>
        </td>
        <td align="center">
            <%# Eval("name_nguoichuyen")%>(<%# Eval("username_nguoichuyen")%>)
        </td>
        <td align="center">
            <%# Eval("ngay_chuyen")%>
        </td>
        </tr>

    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    </asp:Repeater>
    <tr bgcolor="#FCEFEF" style="text-align:center;">
    <td colspan=5 align="right" style="text-align:right;">
    <b>Tổng cộng:</b>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums_sl_nhap" runat="server" Text="0"> </asp:Label>
    </td>
        <td style="font-weight:bold;color:red" colspan=7>
        
    </td>
    </tr>
        <tr align="right">
    <td colspan="11" align="right" style="color:White"><hr>
        Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>
    </div>
    <table>
    <tr>
    <td>
        <input id="Button3" type="button" value="In" class="btn" style="width:100px;height:25px" onclick="PrintContents('mydiv')" /> &nbsp
        <input id="Button4" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/>
    </td>
    </tr>
    </table>
</fieldset>

</asp:Content>
