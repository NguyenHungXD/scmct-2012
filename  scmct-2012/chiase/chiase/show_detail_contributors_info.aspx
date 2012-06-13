<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="show_detail_contributors_info.aspx.cs" Inherits="chiase.show_detail_contributors_info" %>
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
        <table border="0" cellpadding="4" cellspacing="1" width="100%"  style="color:White;font-weight:bold;" >
        <tr>
        <td width="20%">
        Mã dự án:   
        </td>
        <td>
        <asp:Label ID="lbl_ma_du_an" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td width="20%">
        Tên dự án:  
        </td>
        <td>
        <asp:Label ID="lbl_ten_du_an" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td width="20%">
        Người quyên góp:  
        </td>
        <td>
        <asp:Label ID="lbl_hoten" runat="server"></asp:Label>
        </td>
        </tr>
        </table>
  <table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="6">DANH SÁCH ĐÓNG GÓP CHI TIẾT CHO DỰ ÁN</td></tr>
<asp:Repeater ID="contributor_lists_detail" runat="server">
    <HeaderTemplate>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="5%">
            <p>STT</p>
        </td>
                <td width="17%">
            Mã hàng
        </td>
        <td width="17%">
            Tên hàng
        </td>

        <td width="10%">
            Chủng loại
        </td>
        <td width="10%">
            Ngày nhận
        </td>
        <td width="10%">
            Số lượng
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
            <%# Eval("ten_hh")%>
        </td>
        <td>
            <%# Eval("chung_loai")%>
        </td>
        <td>
            <%# Eval("ngay_nhap")%>
        </td>
        <td align="center">
            <%# Eval("so_luong")%>
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
        <asp:Label id="sums" runat="server" Text="<%= v_totals %>"> </asp:Label>
    </td>
    </tr>
    <tr>
    <td colspan="6" style="color:white;" align="right"><hr />
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
