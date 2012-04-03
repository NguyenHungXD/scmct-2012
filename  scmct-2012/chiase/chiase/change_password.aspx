<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="change_password.aspx.cs" Inherits="chiase.change_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_area" runat="server">
    <fieldset>
<legend><font size=2 color=white><b>Đổi mật khẩu</font></b></legend> 
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2>
        <asp:Label ID="lbl_error" runat="server" ForeColor="#006600"></asp:Label>
        </td>
    </tr>
    <tr>
    <td colspan=2>
        &nbsp;<asp:Image ID="img_user" runat="server" Height="50px" Width="50px" />
        <br />
        <i>Truy cập lần cuối, <asp:Label ID="lbl_lasted_access" runat="server" ForeColor="White"></asp:Label></i>
        <br>
        <asp:Label ID="lbl_group_name" runat="server" Text=""></asp:Label>
        <hr>
    </td>
    </tr>
    <tr>
    <td>
        Tên đăng nhập:
    </td>
    <td>
        <b><asp:Label ID="lbl_username" runat="server" ForeColor="White"></asp:Label></b>
    </td>
    </tr>
        <tr>
    <td>
        Email:
    </td>
    <td>
        <b><asp:Label ID="lbl_email" runat="server" ForeColor="White"></asp:Label></b>
    </td>
    </tr>
          <tr>
    <td>
        Mật khẩu cũ:
    </td>
    <td>
        <asp:TextBox ID="txt_oldpass" runat="server"  class="txtformat" 
            Width="250px" Height="22px" TextMode="Password"></asp:TextBox>
    </tr>
      <tr>
    <td>
        Mật khẩu mới:
    </td>
    <td>
        <asp:TextBox ID="txt_new_pass" runat="server"  class="txtformat" 
            Width="250px" Height="22px" TextMode="Password"></asp:TextBox>
    </tr>
    <tr>
    <td>
        Nhập lại mật khẩu:
    </td>
    <td>
        <asp:TextBox ID="txt_new_pass_re" runat="server"  class="txtformat" 
            Width="250px" Height="22px" TextMode="Password"></asp:TextBox>
    </td>

    </tr>
    <tr>
    <td colspan=3 align=left><hr>
        <p align=center><asp:HyperLink ID="link_forget_pass" runat="server" 
                Text="Quên mật khẩu?" NavigateUrl="forget_password.aspx"></asp:HyperLink>
    <br>
    <br>


            <asp:Button ID="btn_change_pass" runat="server" Text="Đổi mật khẩu" 
                onclick="btn_change_pass_Click1" class="btnformat" Width="100px"/>
            <asp:Button ID="btn_close" runat="server" Text="Đóng" 
                onclick="btn_close_Click1" class="btnformat"/>
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
