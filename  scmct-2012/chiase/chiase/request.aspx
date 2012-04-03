<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="chiase.request" %>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <fieldset>
<legend><font size=2 color=white><b>Gửi yêu cầu</font></b></legend>    
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2>
        <font size=3><b><asp:Label ID="lbl_result" runat="server" ForeColor="#0000CC"></asp:Label></b></font>
        <hr>
        </td>
    <td rowspan=9><br>
    </td>
    </tr>
    <tr>
    <td>
    Tiêu đề:
    </td>
    <td>
        <asp:TextBox ID="txt_request_subject" runat="server"  class="txtformat"  Width="449px" 
            Height="23px"></asp:TextBox>
    </td>
    </tr>
     <tr>
    <td>
    Nội dung:
    </td>
    <td>
        <asp:TextBox ID="txt_content" runat="server"  class="txtformat_area"  Width="811px" 
            Height="279px" TextMode="MultiLine"></asp:TextBox>
            </td>
    </tr>
    <tr>
    <td>
    Loại yêu cầu:
    </td>
    <td>

    
        <asp:DropDownList ID="dropd_request_kind" runat="server">
        </asp:DropDownList>

    </td>
    </tr>

    <tr>
    <td colspan=2>
        <b><font color=white size=3><br>Thông tin liên hệ:<br>&nbsp</font></b>
    </td>
    </tr>

    <asp:Panel ID="Panel1" runat="server">
     <tr>
     <td>
        Họ và tên:
    </td>
    <td>
        <asp:TextBox ID="txt_full_name" runat="server" class="txtformat"  Width="250px" 
            Height="22px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    Địa chỉ:
    </td>
    <td>
        <asp:TextBox ID="txt_address" runat="server"  class="txtformat"  Width="250px" 
            Height="22px"></asp:TextBox>
     </td>
     </tr>

     <tr>
     <td>
    Số điện thoại:
    </td>
    <td>
        <asp:TextBox ID="txt_phone_number" runat="server"  class="txtformat"  
            Width="250px" Height="22px"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
    Email:
    </td>
    <td>
        <asp:TextBox ID="txt_emaill_address" runat="server" class="txtformat" Width="250px" Height="22px"></asp:TextBox>
    </td>
    </tr>
    </asp:Panel>
    <tr>
    <td colspan=3 align=left><hr><br>
            <asp:Button ID="btn_request" runat="server" Text="Gửi yêu cầu" 
            onclick="btn_request_Click" class="btnformat"/>
            <asp:Button ID="btn_close" runat="server" Text="Đóng" 
            onclick="btn_close_Click" class="btnformat"/>
    </td>
        
    </tr>
    <tr>
    <td colspan=3 align=right>
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>
    </fieldset>
    <br>&nbsp


</asp:Content>
