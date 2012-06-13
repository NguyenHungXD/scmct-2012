<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="create_new_members.aspx.cs" Inherits="chiase.create_new_members" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<script type="text/JavaScript">
    function backs() {
        window.location = "admin.aspx";
    }

    function ValidateLenTDN(oSrc, args) {
        if (document.all["<%=txt_username.ClientID%>"].value.length < 4) {
            args.IsValid = false;
        } else
            args.IsValid = true;
    }
    function ValidateLenMK(oSrc, args) {
        if (document.all["<%=txt_password.ClientID%>"].value.length < 4) {
            args.IsValid = false;
        } else
            args.IsValid = true;
    }
</script>

   <fieldset>
<!--<legend>Cập nhật thông tin cá nhân</legend>  -->  
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2>
        <font size=2><b><asp:Label ID="lbl_error" runat="server" ForeColor="White"></asp:Label></b></font><br>
        <h3 align=left>Tạo mới người dùng</h3>
        <h5 align=left style="color:red">*-Là thông tin bắt buộc</h5>
        <hr>
        </td>
    </tr>
    <tr>
    <td>
        Tên đăng nhập:
    </td>
    <td>
        <asp:TextBox ID="txt_username" runat="server"  class="txtformat" 
            Width="250px" Height="25px" BackColor="#CCFFCC"></asp:TextBox><font color=red>*</font>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_username" Display="Dynamic" ForeColor="Red" ErrorMessage="Nhập tên đăn nhập" runat="server" ></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator2" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="-Tên đăng nhập ít nhất 4 ký tự" ClientValidationFunction="ValidateLenTDN"></asp:CustomValidator>

    </td>
    </tr>
      <tr>
    <td>
        Mật khẩu:
    </td>
    <td>
        <asp:TextBox ID="txt_password" runat="server" class="txtformat" 
            Width="250px" Height="25px"  BackColor="#CCFFCC"></asp:TextBox><font color=red>*</font>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_password" Display="Dynamic" ForeColor="Red" ErrorMessage="Nhập mật khẩu" runat="server" ></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="-Mật khẩu ít nhất 4 ký tự" ClientValidationFunction="ValidateLenMK"></asp:CustomValidator>
    </td>
    </tr>
          <tr>
    <td>
       Xác nhận mật khẩu:
    </td>
    <td>
        <asp:TextBox ID="txt_password_re" runat="server" class="txtformat" 
            Width="250px" Height="25px" BackColor="#CCFFCC"></asp:TextBox><font color=red>*</font>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_password_re" runat="server" ErrorMessage="Xác nhận mật khẩu"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="txt_password_re" ControlToCompare="txt_password" 
            Operator="Equal" ErrorMessage="-Mật khẩu không bằng nhau" ForeColor="#FF3300"></asp:CompareValidator>  
    </td>
    </tr>
    <tr>
    <td>
        Họ tên:
    </td>
    <td>
        <asp:TextBox ID="txt_full_name" runat="server"  class="txtformat" 
            Width="250px" Height="25px"></asp:TextBox>

    </td>
    </tr>

    <tr>
    <td>
        Nhóm :
    </td>
    <td>
        <asp:DropDownList ID="dropd_group" runat="server" Height="25px" Width="250px">
        </asp:DropDownList><font color=red>*</font>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ForeColor="Red" InitialValue="None" ControlToValidate="dropd_group" runat="server" ErrorMessage="Chọn nhóm thành viên"></asp:RequiredFieldValidator>
         </td>
    </tr>
 
     <tr>
    <td>
        Địa chỉ:
    </td>
    <td>
        <asp:TextBox ID="txt_address" runat="server"  class="txtformat"  Width="250px" 
            Height="25px"></asp:TextBox>

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
            Width="250px" Height="25px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_phonenumber" ValidationExpression="^\d+$" runat="server" ErrorMessage=" Số điện thoại phải là số"></asp:RegularExpressionValidator>
        </td>
    </tr>

        <tr>
       <td>
           Email:
    </td>
    <td>
        <asp:TextBox ID="txt_email" runat="server"  class="txtformat"  Width="250px" 
            Height="25px"></asp:TextBox><font color=red>*</font>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_email" runat="server" ErrorMessage="Nhập địa chỉ email"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_email" ErrorMessage="Địa chỉ email chưa đúng" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>   
            </td>
            </tr>
    <tr>
        <td>
            Số Fax:
    </td>
    <td>
        <asp:TextBox ID="txt_faxnumber" runat="server" class="txtformat" Width="250px" Height="25px"></asp:TextBox>
            </td>
    </tr>
    <tr>
       <td>
           Website:
    </td>
    <td>
        <asp:TextBox ID="txt_website" runat="server"  class="txtformat"  Width="250px" 
            Height="25px"></asp:TextBox>
            </td>
            </tr>
  <tr>
       <td>
           Skype:
    </td>
    <td>
        <asp:TextBox ID="txt_skype" runat="server"  class="txtformat"  
            Width="250px" Height="25px"></asp:TextBox>
        </td>
    </tr>
      <tr>
       <td>
           Yahoo :
    </td>
    <td>
        <asp:TextBox ID="txt_yahoo" runat="server"  class="txtformat"  
            Width="250px" Height="25px"></asp:TextBox>
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
        <asp:Label ID="lbl_create_new_members" runat="server">

        <asp:Button ID="Button1" runat="server" Text="Lưu thông tin" class="btn" 
            Height="25px" Width="120" onclick="Button1_Click"/>
            </asp:Label>
    </td>
    <td>


        <input id="Button2" type="button" value="Đóng" onclick="backs()" class="btn" style="height:25px;width:120px" />
        </td>
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