<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="chiase.register" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="register" ContentPlaceHolderID="content_area" Runat="Server">
<script language="javascript" type="text/javascript">
    function ValidateChecked(oSrc, args) {
        if (document.all["<%=chk.ClientID%>"].checked == false) {
            args.IsValid = false;
        }else
            args.IsValid = true;
    }
    function ValidateLenTDN(oSrc, args) {
        if (document.all["<%=txt_user_name.ClientID%>"].value.length < 4) {
            args.IsValid = false;
        } else
            args.IsValid = true;
    }
    function ValidateLenMK(oSrc, args) {
        if (document.all["<%=txt_pass_word.ClientID%>"].value.length < 4) {
            args.IsValid = false;
        } else
            args.IsValid = true;
    }
</script>

<fieldset>
<legend>Đăng ký thành viên</legend>    
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2>
        <font size=3><b><asp:Label ID="lbl_result" runat="server" ForeColor="#0000CC"></asp:Label></b></font>
        <p align="left"><font color=red><i>* - Là thông tin bắt buột khi đăng ký tài khoản mới</i></font></p>
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
            Width="200px" Height="22px"></asp:TextBox><font color=red>*</font>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="txt_user_name" runat="server" 
            ErrorMessage="Nhập tên đăng nhập" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator2" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên đăng nhập ít nhất 4 ký tự" ClientValidationFunction="ValidateLenTDN"></asp:CustomValidator>
    </td>
    </tr>
    <tr>
    <td>
    Mật khẩu:
    </td>
    <td>
        <asp:TextBox ID="txt_pass_word" runat="server"  class="txtformat"  Width="200px" 
            Height="22px" TextMode="Password"></asp:TextBox><font color=red>*</font>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_pass_word" runat="server" ErrorMessage="Nhập mật khẩu"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator3" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Mật khẩu ít nhất 4 ký tự" ClientValidationFunction="ValidateLenMK"></asp:CustomValidator>
            </td>
    </tr>
     <tr>
    <td>
    Xác nhận mật khẩu:
    </td>
    <td>
        <asp:TextBox ID="txt_pass_word_re" runat="server"  class="txtformat"  Width="200px" 
            Height="22px" TextMode="Password"></asp:TextBox><font color=red>*</font>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_pass_word_re" runat="server" ErrorMessage="Xác nhận mật khẩu"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="txt_pass_word_re" ControlToCompare="txt_pass_word" 
            Operator="Equal" ErrorMessage="Mật khẩu không bằng nhau" ForeColor="#FF3300"></asp:CompareValidator>  
            
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
        (dd/MM/yyyy)
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
        <asp:TextBox ID="txt_emaill_address" runat="server" class="txtformat" Width="250px" Height="22px"></asp:TextBox><font color=red>*</font>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_emaill_address" runat="server" ErrorMessage="Nhập địa chỉ email"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_emaill_address" ErrorMessage="Địa chỉ email chưa đúng" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>   
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
    <asp:CheckBox ID="chk" runat="server"/><b><font color="ButtonHighlight">
        Tôi đồng ý thỏa thuận thành viên của cổng thông tin CSMCT </font></b>- [<a href="#">Thỏa thuận</a>]
           <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Bạn phải đồng ý thỏa thuận thành viên" ClientValidationFunction="ValidateChecked" ForeColor="#FF3300"></asp:CustomValidator>
           </td>
    </tr>
    <tr>
    <td colspan=3 align=left><hr><br>

    <table cellpadding="0" cellspacing="3" border="0" width="80%">
    <tr>
    <td align="right">
        <dx:ASPxButton ID="btn_registers" onclick="btn_register_Click" runat="server" 
            Text="Đăng ký" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="100px">
        </dx:ASPxButton>
        </td>
        <td>

        <dx:ASPxButton ID="btn_closes" onclick="btn_close_Click1" runat="server" AutoPostBack="False" UseSubmitBehavior="False"
                Text="Đóng" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="100px">
                     <ClientSideEvents Click="function(s, e) {
                            window.location.href='default.aspx'
                    }" />
        </dx:ASPxButton>

    </td>
    </tr>
    </table>

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