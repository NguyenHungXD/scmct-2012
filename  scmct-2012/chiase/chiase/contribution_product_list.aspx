<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="contribution_product_list.aspx.cs" Inherits="chiase.contribution_product_list" %>
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
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="10">DANH SÁCH ĐÓNG GÓP THEO DỰ ÁN</td></tr>

<asp:Repeater ID="product_report_detail" runat="server" onitemdatabound="product_report_detail_ItemDataBound" >
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
            Mã hàng
        </td>
        <td width="10%">
            Tên hàng
        </td>
        <td width="10%">
            Chủng loại
        </td>
        <td width="10%">
            Ngày quyên góp
        </td>
        <td width="10%">
            Tên yêu cầu
        </td>
        <td width="10%">
            Ngày yêu cầu
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
                <td valign="middle" style="text-align:left;">
            <%# Eval("ma_du_an")%>
        </td>
                <td valign="middle" style="text-align:left;">
            <%# Eval("ten_du_an")%>
        </td>
                <td valign="middle">
            <%# Eval("ma_hh")%>
        </td>
        <td valign="middle">
            <%# Eval("ten_hh")%>
        </td>
        <td>
            <%# Eval("ten_nhh")%>
        </td>
        <td>
            <%# Eval("ngay_nhap")%>
        </td>
        <td>
            <%# Eval("phieu_yeu_cau")%>
        </td>
        <td>
            <%# Eval("ngay_yeu_cau")%>
        </td>
        <td align="center">
            <%--<%# Eval("so_luong_nhap")%>--%><asp:HyperLink target="_blank" id="so_luong_nhap" runat="server"></asp:HyperLink>
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
        <asp:Label id="sums_tong" runat="server" Text="0"> </asp:Label>
    </td>
    </tr>
        <tr align="right">
    <td colspan="10" align="right" style="color:White"><hr>
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

