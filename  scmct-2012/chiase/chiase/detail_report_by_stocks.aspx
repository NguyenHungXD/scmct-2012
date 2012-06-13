<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detail_report_by_stocks.aspx.cs" Inherits="chiase.detail_report_by_stocks" %>
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
    <asp:Label id="lbl_error" runat="server" Text=""></asp:Label>
    <br>
  <table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="12">BÁO CÁO XUẤT-NHẬP-TỒN THEO KHO</td></tr>

<asp:Repeater ID="stock_report_detail" runat="server">
    <HeaderTemplate>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="5%">
            <p>STT</p>
        </td>
        <td width="10%">
            Tên kho
        </td>
        <td width="10%">
            Địa chỉ
        </td>

        <td width="10%">
            Mã hàng
        </td>
               <td width="10%">
            Tên hàng
        </td>
       <td width="10%">
            Chủng loại
        </td>
        <td width="10%">
            SL tồn trước
        </td>
        <td width="10%">
            SL nhập
        </td>
        <td width="10%">
            SL chuyển đi
        </td>
        <td width="10%">
            SL chuyển đến
        </td>
        <td width="10%">
            SL xuất
        </td>
        <td width="10%">
            SL tồn
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor="white" style="text-align:center;">
                <td valign="middle" >
            <%= no++ %> 
        </td>
                <td valign="middle">
            <%# Eval("ten_kho")%>
        </td>
                <td valign="middle">
            <%# Eval("dia_chi_kho")%>
        </td>
                <td valign="middle">
            <%# Eval("ma_hh")%>
        </td>
        <td valign="middle">
            <%# Eval("ten_hang")%>
        </td>
        <td>
            <%# Eval("chung_loai")%>
        </td>
                <td align="center">
            <%# Eval("sl_ton_truoc")%>
        </td>
        <td align="center">
            <%# Eval("sl_nhap")%>
        </td>
        <td align="center">
            <%# Eval("sl_chuyen_di_kho")%>
        </td>
        <td align="center">
            <%# Eval("sl_chuyen_den_kho")%>
        </td>
        <td align="center">
            <%# Eval("sl_luong_xuat")%>
        </td>
        <td align="center">
            <%# Eval("sl_ton")%>
        </td>
        </tr>

    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    </asp:Repeater>
    <tr bgcolor="#FCEFEF" style="text-align:center;">
    <td colspan=6 align="right" style="text-align:right;">
    <b>Tổng cộng:</b>
    </td>
      <td style="font-weight:bold;color:red">
        <asp:Label id="sums_sl_ton_truoc" runat="server" Text="0"> </asp:Label>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums_sl_nhap" runat="server" Text="0"> </asp:Label>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums_chuyen_di" runat="server" Text="0"> </asp:Label>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums_chuyen_den" runat="server" Text="0"> </asp:Label>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums_xuat" runat="server" Text="0"> </asp:Label>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums_ton" runat="server" Text="0"> </asp:Label>
    </td>
    </tr>
        <tr align="right">
    <td colspan="12" align="right" style="color:White"><hr>
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
