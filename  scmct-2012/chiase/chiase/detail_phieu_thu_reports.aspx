<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detail_phieu_thu_reports.aspx.cs" Inherits="chiase.detail_phieu_thu_reports" %>
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
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="11">BÁO CÁO CHI TIẾT THU THEO DỰ ÁN</td></tr>
<asp:Repeater ID="phieu_thu_report_detail" runat="server">
    <HeaderTemplate>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="3%">
            <p>STT</p>
        </td>
        <td width="10%">
            Mã phiếu thu
        </td>
        <td width="5%">
            Người thu
        </td>
        <td width="10%">
            Ngày thu
        </td>
        <td width="7%">
            Ghi chú
        </td>
        <td width="7%">
            Chứng từ góc
        </td>
        <td width="10%">
            Thu từ
        </td>
        <td width="10%">
            Người nộp
        </td>
        <td width="10%">
            Thu từ yêu cầu
        </td>
        <td width="7%">
            Tổng tiền
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor="white" style="text-align:center;">
        <td valign="middle" >
            <%= no++ %> 
        </td>
        <td valign="middle">
            <%# Eval("ma_pt")%>
        </td>
        <td valign="middle">
            <%# Eval("nguoi_thu")%>
        </td>
        <td valign="middle">
            <%# Eval("ngay_thu")%>
        </td>
        <td>
            <%# Eval("ghi_chu")%>
        </td>
        <td>
            <%# Eval("chung_tu_goc")%>
        </td>
        <td align="center">
            <%# Eval("thu_tu")%>
        </td>
        <td align="center">
            <%# Eval("nguoi_nop")%>
        </td>
        <td align="center">
            <%# Eval("yeu_cau")%>
        </td>
        <td align="center">
            <%# Eval("tong_tien", "{0:###,###,###,###,##0}")%>
        </td>


        </tr>

    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    </asp:Repeater>
    <tr bgcolor="#FCEFEF" style="text-align:center;">
    <td colspan=9 align="right" style="text-align:right;">
    <b>Tổng cộng:</b>
    </td>
    <td style="font-weight:bold;color:red">
        <asp:Label id="sums_tong_tien" runat="server" Text="0"> </asp:Label>
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
