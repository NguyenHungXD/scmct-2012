<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="forget_password.aspx.cs" Inherits="chiase.forget_password" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="content_area" runat="server">

<script language="javascript" type="text/javascript">
    function Validate(oSrc, args) {
        if (document.all["<%=txt_username.ClientID%>"].value.length < 4 && document.all["<%=txt_email.ClientID%>"].value.length<4) {
            args.IsValid = false;
        }else
            args.IsValid = true;
    }
</script>

   <fieldset>
<legend>Quên mật khẩu -  Nhập tên đăng nhập hoặc địa chỉ email</legend> 
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2><br>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ></asp:Label></font><br>
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
        <asp:CustomValidator ID="CustomValidator1" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Bạn phải nhập tên đăng nhập hoặc địa chỉ email" ClientValidationFunction="Validate"></asp:CustomValidator>
    </tr>
      <tr>
    <td>
        Địa chỉ email:
    </td>
    <td>
        <asp:TextBox ID="txt_email" runat="server"  class="txtformat" Width="250px" 
            Height="22px"></asp:TextBox>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_email" ErrorMessage="Địa chỉ email chưa đúng" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    </tr>
    <tr>
    <td colspan=3 align=left><hr>
    </td>
    <tr>
    <td align="right">

        <dx:ASPxButton ID="btn_getpasswords" runat="server" Text="Lấy lại mật khẩu" 
            onclick="btn_getpassword_Click" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
            CssPostfix="Aqua" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
            Width="142px">
        </dx:ASPxButton>
        </td>
        <td>
        <dx:ASPxButton ID="btn_closes" runat="server" Text="Đóng" 
            onclick="btn_close_Click" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
            CssPostfix="Aqua" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
            Width="120px">

                    <ClientSideEvents Click="function(s, e) {
                            window.location.href='default.aspx'
                    }" />

        </dx:ASPxButton>
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

