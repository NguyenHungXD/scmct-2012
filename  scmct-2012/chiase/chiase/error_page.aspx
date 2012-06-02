<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="error_page.aspx.cs" Inherits="chiase.error_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<fieldset style="background-color:Black"><br><table width="100%"><tr align="center"><td>
    <img alt="Hack" src="images/hack.png" /><br>
    <hr>
        <font color="#66FF00">Xin vui lòng đăng nhập để sử dụng hệ thống. Nếu bạn quên mật khẩu: <asp:HyperLink ID="link_forget_pass" runat="server" 
                Text="Quên mật khẩu" NavigateUrl="forget_password.aspx"></asp:HyperLink> | <asp:HyperLink ID="HyperLink1" runat="server" 
                Text="Đăng ký" NavigateUrl="register.aspx"></asp:HyperLink></font><br>
    
    Sách cho miền cát trắng xin chào bạn! Nếu bạn tìm thấy lổi bảo mật hệ thống xin vui lòng liên hệ quản trị <a style="color:#33FF33;cursor:pointer">quantri.scmct@gmail.com</a>.<br> Xin chân thành cảm ơn
    <br>
    <b>Ban quản trị</b>
    <hr>
        <p align="left"><asp:Label ID="ip" runat="server" Text=""></asp:Label></p>
</td>
<tr>
</table>
</fieldset>
</asp:Content>
