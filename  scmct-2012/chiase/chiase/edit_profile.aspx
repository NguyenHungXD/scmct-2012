<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="edit_profile.aspx.cs" Inherits="chiase.edit_profile" %>
<%@ Register Assembly="obout_Interface" Namespace="Obout.Interface" TagPrefix="cc1" %>

<asp:Content ID="register" ContentPlaceHolderID="content_area" Runat="Server">
    <fieldset>
<legend><font size=2 color=white><b>Cập nhật thông tin cá nhân</font></b></legend>    
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
            <cc1:OboutButton ID="btn_update_avatar" runat="server" 
                onclick="btn_update_avatar_Click" Text="Lưu avatar mới">
            </cc1:OboutButton>
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
        </asp:DropDownList>(dd/mm/yyyy)
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
    <td colspan=3 align="left"/><hr/><br/>
    

        <cc1:OboutButton ID="btn_update_profile" runat="server" 
            Text="Cập nhật thông tin" onclick="btn_update_profile_Click">
        </cc1:OboutButton>

        <cc1:OboutButton ID="btn_close" runat="server" Text="Đóng" Width="100px" 
            onclick="btn_close_Click">
        </cc1:OboutButton>

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