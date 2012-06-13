<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="request_detail.aspx.cs" Inherits="chiase.request_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<fieldset>
    <asp:Repeater ID="request_list" runat="server">
    <HeaderTemplate>
<table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="6">CHI TIẾT YÊU CẦU</td></tr>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="17%">
            <P>Tiêu đề</P>
        </td>
        <td width="40%">
            Nội dung
        </td>
        <td width="10%">
            Loại yêu cầu
        </td>
        <td width="10%">
            Người tạo
        </td>
                <td width="10%">
            Ngày tạo
        </td>
        <td width="10%">
            Trạng thái
        </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr bgcolor="white">
  
        <td>
            <%# Eval("tieu_de")%>
        </td>
        <td>
            <%# Eval("noi_dung")%>
        </td>
        <td align="center">
            <%# Eval("ten_loai_yc")%>
        </td>
                <td align="center">
            <%# Eval("requested_by")%>
        </td>
        <td align="center">
            <%# Eval("ngay_yeu_cau","{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>
        <td align="center">
             <%# Eval("name")%>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    <tr>
    <td colspan="6" style="color:white;font-weight:bold"><br>
    <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 

<input id="Button2" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="window.close();"/><br>&nbsp
    </td>
    </tr>
    </table>
    </FooterTemplate>
    </asp:Repeater>
     <table width="100%">
     <tr align="right">
    <td colspan=3 align=right style="color:White">
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>
</fieldset>
</asp:Content>

