<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detail_finance_reports.aspx.cs" Inherits="chiase.detail_finance_reports" %>
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
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="12">BÁO CÁO THU CHI THEO DỰ ÁN</td></tr>

<asp:Repeater ID="finance_report_detail" runat="server"  onitemdatabound="finance_report_detail_ItemDataBound">
<HeaderTemplate>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="5%">
            <p>STT</p>
        </td>
        <td width="10%">
            Mã dự án
        </td>
        <td width="10%">
            Tên dự án
        </td>

        <td width="10%">
            Ngày bắt đầu
        </td>
               <td width="10%">
            Ngày kết thúc
        </td>
       <td width="10%">
            Tồn trước
        </td>
        <td width="10%">
            Tổng thu
        </td>
        <td width="10%">
            Tổng chi
        </td>
        <td width="10%">
            Còn lại
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor="white" style="text-align:center;">
                <td valign="middle" >
            <%= no++ %> 
        </td>
                <td valign="middle" style="text-align:left;">
            <%# Eval("ma_du_an")%>
        </td>
                <td valign="middle" style="text-align:left;">
            <%# Eval("ten_du_an")%>
        </td>
                <td valign="middle">
            <%# Eval("ngay_bat_dau")%>
        </td>
        <td valign="middle">
            <%# Eval("ngay_ket_thuc")%>
        </td>
        <td>
            <%# Eval("ton_truoc", "{0:###,###,###,###,##0}")%>
        </td>
                <td align="center">
            <%--<%# Eval("tong_thu", "{0:###,###,###,###,##0}")%>--%><asp:HyperLink id="lbl_tong_thu" title="Xem chi tiết" target="_blank" runat="server"></asp:HyperLink>
        </td>
        <td align="center">
            <%--<%# Eval("tong_chi", "{0:###,###,###,###,##0}")%>--%><asp:HyperLink id="lbl_tong_chi" title="Xem chi tiết" target="_blank" runat="server"></asp:HyperLink>
        </td>
        <td align="center">
            <%# Eval("ton", "{0:###,###,###,###,##0}")%>
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
        <asp:Label id="sums_ton_truoc" runat="server" Text="0"> </asp:Label>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums_tong_thu" runat="server" Text="0"> </asp:Label>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums_tong_chi" runat="server" Text="0"> </asp:Label>
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
