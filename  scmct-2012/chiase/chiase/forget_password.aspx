<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="forget_password.aspx.cs" Inherits="chiase.forget_password" %>


<asp:Content ID="Content1" ContentPlaceHolderID="content_area" runat="server">

   <fieldset>
<legend><font size=2 color=white><b>Quên mật khẩu -  Nhập tên đăng nhập hoặc địa chỉ email</font></b></legend> 
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2><br>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ForeColor="#0000CC"></asp:Label></font><br>
        <hr>
        </td>
    </tr>
          <tr>
    <td>
        Tên đăng nhập:
    </td>
    <td>
        <asp:TextBox ID="txt_username" runat="server"  class="txtformat" Width="250px" 
            Height="22px"></asp:TextBox>
    </tr>
      <tr>
    <td>
        Địa chỉ email:
    </td>
    <td>
        <asp:TextBox ID="txt_email" runat="server"  class="txtformat" Width="250px" 
            Height="22px"></asp:TextBox>
    </tr>
    <tr>
    <td colspan=3 align=left><hr>
    <br>
        <asp:Button ID="btn_getpassword" runat="server" Text="Lấy lại mật khẩu" 
            class="btnformat" onclick="btn_getpassword_Click" Width="150px"/>
        <asp:Button ID="btn_close" runat="server" Text="Đóng" class="btnformat" 
            onclick="btn_close_Click" Width="100px"/>
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

