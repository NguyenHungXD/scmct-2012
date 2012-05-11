<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="edit_profile.aspx.cs" Inherits="chiase.edit_profile" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="register" ContentPlaceHolderID="content_area" Runat="Server">
    <fieldset>
<legend>Cập nhật thông tin cá nhân</legend>    
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ForeColor="#0000CC"></asp:Label></b></font>
        </td>
    </tr>
    <tr>
    <td colspan=2>
        &nbsp;<asp:Image 
            ID="img_user" runat="server" Height="50px" Width="50px" BorderColor="White" 
            BorderStyle="Solid" BorderWidth="1px" />
        &nbsp;<div id ="update_avatar">
            Avatar mới:<br> 
            <asp:FileUpload ID="upload_img" runat="server" BackColor="#67C9FF" 
                Text="Chọn hình" class="btnformat" BorderColor="White" BorderStyle="Solid" 
                BorderWidth="1px" Height="21px" ToolTip="Chọn hình" Width="300px"/>
        </div>

        <dx:ASPxButton ID="btn_avatars" runat="server" Text="Cập nhật Avatar" 
            onclick="btn_avatar_Click" CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" 
            CssPostfix="SoftOrange" 
            SpriteCssFilePath="~/App_Themes/SoftOrange/{0}/sprite.css" Width="150px">
        </dx:ASPxButton>



        <br>
        <i>Truy cập lần cuối, <asp:Label ID="lbl_lasted_access" runat="server" ForeColor="White"></asp:Label></i><br>
        <asp:Label ID="lbl_group_name" runat="server" Text=""></asp:Label>
        <hr>
    </td>
    </tr>
    <tr>
    <td>
        Tên đăng nhập:
    </td>
    <td>
        <asp:TextBox ID="txt_username" runat="server"  class="txtformat" 
            Width="96px" Height="22px" Enabled="False" BackColor="#CCFFCC"></asp:TextBox>
    </td>
    </tr>
      <tr>
    <td>
        Mật khẩu:
    </td>
    <td>
        <asp:TextBox ID="txt_password" runat="server"  class="txtformat" 
            Width="96px" Height="22px" Enabled="False" BackColor="#CCFFCC">**********</asp:TextBox>
    &nbsp;<asp:HyperLink ID="link_changepass" runat="server" Text="Đổi mật khẩu" NavigateUrl="~/change_password.aspx" title="Đổi mật khẩ"></asp:HyperLink></td>
    </tr>
    <tr>
    <td>
        Họ tên:
    </td>
    <td>
        <asp:TextBox ID="txt_full_name" runat="server"  class="txtformat" 
            Width="250px" Height="22px"></asp:TextBox>
    </td>
    </tr>
    <!--
    <tr>
    <td>
        Nhóm :
    </td>
    <td>
        <asp:DropDownList ID="dropd_group" runat="server">
        </asp:DropDownList>
         </td>
    </tr>
    -->
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
           Ngày sinh:
    </td>
    <td>
        <asp:DropDownList ID="dropd_day" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_month" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_year" runat="server">
        </asp:DropDownList>(dd/MM/yyyy)
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
           Số điện thoại:
    </td>
    <td>

        <asp:TextBox ID="txt_phonenumber" runat="server" class="txtformat" 
            Width="250px" Height="22px"></asp:TextBox>

        </td>
    </tr>

        <tr>
       <td>
           Email:
    </td>
    <td>
        <asp:TextBox ID="txt_email" runat="server"  class="txtformat"  Width="250px" 
            Height="22px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_email" runat="server" ErrorMessage="Nhập địa chỉ email"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_email" ErrorMessage="Địa chỉ email chưa đúng" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>   
            </td>
            </tr>
    <tr>
        <td>
            Số Fax:
    </td>
    <td>
        <asp:TextBox ID="txt_faxnumber" runat="server" class="txtformat" Width="250px" Height="22px"></asp:TextBox>
            </td>
    </tr>
    <tr>
       <td>
           Website:
    </td>
    <td>
        <asp:TextBox ID="txt_website" runat="server"  class="txtformat"  Width="250px" 
            Height="22px"></asp:TextBox>
            </td>
            </tr>
  <tr>
       <td>
           Skype:
    </td>
    <td>
        <asp:TextBox ID="txt_skype" runat="server"  class="txtformat"  
            Width="250px" Height="22px"></asp:TextBox>
        </td>
    </tr>
      <tr>
       <td>
           Yahoo :
    </td>
    <td>
        <asp:TextBox ID="txt_yahoo" runat="server"  class="txtformat"  
            Width="250px" Height="22px"></asp:TextBox>
        </td>
    </tr>
          <tr>
       <td>
           Sở thích :
    </td>
    <td>
        <asp:TextBox ID="txt_note" runat="server" Rows="5" TextMode="MultiLine" class="txtformat_area" Width="400px"></asp:TextBox>
        </td>
    </tr>
     <tr>
       <td colspan=2>
           &nbsp;</td>
    </tr>
    <tr>
    <td colspan=3 align="left"/><hr/>
    </td>
    </tr>
    <tr>
    <td align="right">
        <dx:ASPxButton ID="btn_updateprofiles" runat="server" Text="Lưu thay đổi" 
            onclick="btn_updateprofile_Click" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="123px">
        </dx:ASPxButton>
    </td>
    <td>
        <dx:ASPxButton ID="btn_closes" runat="server" Text="Đóng" 
            onclick="btn_close_Click1" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
            CssPostfix="Aqua" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
            Width="111px">

                     <ClientSideEvents Click="function(s, e) {
                            window.location.href='default.aspx'
                    }" />

        </dx:ASPxButton>
</tr>
<tr>
    <td colspan=3 align=right>
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
     </table>
    </fieldset>
    <br>&nbsp
    </asp:Content>