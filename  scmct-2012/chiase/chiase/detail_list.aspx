<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detail_list.aspx.cs" Inherits="chiase.detail_list" %>
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
                colspan="5">CHI TIẾT VẬT DỤNG QUYÊN GÓP CHO DỰ ÁN</td></tr>
<asp:Repeater ID="detail_lists" runat="server">
    <HeaderTemplate>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="5%">
            <p>STT</p>
        </td>
        <td width="17%">
            Mã hàng
        </td>
        <td width="10%">
            Tên hàng
        </td>
        <td width="10%">
            Chủng loại
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
        <td>
            <%# Eval("ten_hh")%>
        </td>
        <td>
            <%# Eval("chung_loai")%>
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
    <td colspan=4 align="right" style="text-align:right;">
    <b>Tổng cộng:</b>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums" runat="server"> </asp:Label>
    </td>
    </tr>
    <tr>
    <td colspan="5" style="color:white;" align="right">
    <hr>
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
