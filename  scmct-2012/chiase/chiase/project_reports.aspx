<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="project_reports.aspx.cs" Inherits="chiase.project_reports" %>
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
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="9">BÁO CÁO TỔNG KẾT DỰ ÁN</td></tr>

<asp:Repeater ID="project_report_detail" runat="server" onitemdatabound="project_report_detail_ItemDataBound">
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
            <%# Eval("ma_hh")%>
        </td>
        <td valign="middle">
            <%# Eval("ten_hang")%>
        </td>
        <td>
            <%# Eval("chung_loai")%>
        </td>
        <td align="center">
            <%--<%# Eval("sl_nhap")%>--%> <asp:HyperLink target="_blank" id="sl_nhap" runat="server" title="Xem chi tiết phiếu nhập"></asp:HyperLink>
        </td>
        <td align="center">
            <%--<%# Eval("sl_chuyen_di_da")%>--%><asp:HyperLink target="_blank" id="sl_chuyen_di_da" runat="server" title="Xem chi tiết"></asp:HyperLink>
        </td>
        <td align="center">
            <%--<%# Eval("sl_chuyen_den_da")%>--%><asp:HyperLink target="_blank" id="sl_chuyen_den_da" runat="server" title="Xem chi tiết"></asp:HyperLink>
        </td>
        <td align="center">
            <%--<%# Eval("sl_luong_xuat")%>--%><asp:HyperLink target="_blank" id="sl_xuat" runat="server" title="Xem chi tiết phiếu xuất kho"></asp:HyperLink>
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
    <td colspan=4 align="right" style="text-align:right;">
    <b>Tổng cộng:</b>
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
    <td colspan="9" align="right" style="color:White"><hr>
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
