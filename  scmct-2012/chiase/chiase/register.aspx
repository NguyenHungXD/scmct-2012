<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="chiase.register" %>

<asp:Content ID="register" ContentPlaceHolderID="content_area" Runat="Server">
<fieldset>
<legend><font size=2 color=white><b>Đăng ký thành viên</font></b></legend>    
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
    Tài khoản:
    </td>
    <td>
        <asp:TextBox ID="txt_user_name" runat="server"  class="txtformat" 
            Width="200px" Height="22px"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
    Mật khẩu:
    </td>
    <td>
        <asp:TextBox ID="txt_pass_word" runat="server"  class="txtformat"  Width="200px" 
            Height="22px" TextMode="Password"></asp:TextBox>
            </td>
    </tr>
     <tr>
    <td>
    Xác nhận mật khẩu:
    </td>
    <td>
        <asp:TextBox ID="txt_pass_word_re" runat="server"  class="txtformat"  Width="200px" 
            Height="22px" TextMode="Password"></asp:TextBox>
            </td>
    </tr>
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
    Ngày sinh:
    </td>
    <td>
        <asp:DropDownList ID="dropd_day" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_month" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_year" runat="server">
        </asp:DropDownList>
        (dd/mm/yyyy)
        </td>

    </tr>
        <tr>
       <td>
    Giới tính:
    </td>
    <td>

        <asp:RadioButtonList ID="rd_sex" runat="server" Height="16px" Width="248px">
            <asp:ListItem Selected="True" Value="0">Nam</asp:ListItem>
            <asp:ListItem Value="1">Nữ</asp:ListItem>
        </asp:RadioButtonList>

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
       <td colspan=2>
    <asp:CheckBox ID="chk_agree" runat="server" Checked="true" /><b><font color="ButtonHighlight">
        Tôi đồng ý thỏa thuận thành viên của cổng thông tin CSMCT </font></b>- [Thỏa thuận]
           </td>
    </tr>
    <tr>
    <td colspan=3 align=left><hr><br>
        <asp:Button ID="btn_register" runat="server" Text="Đăng ký" 
            onclick="btn_register_Click"  class="btnformat"/>
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