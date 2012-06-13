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

    function backs() {
        window.location = "default.aspx";
    }
</script>

   <fieldset>

<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2><br>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ></asp:Label></font><br>
        <p align="left">Nhập tên đăng nhập hoặc địa chỉ email</p>
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
    <td>
        Mã xác nhận:&nbsp 
    </td>
    <td><asp:Label ID="txt_random" runat="server" Text="" style="color:Yellow;font-weight:bold;font-size:x-large"></asp:Label>
        <asp:TextBox ID="txt_confirm" style="color:Red;font-weight:bold;font-size:x-large" runat="server" class="txtformat" Width="80px" Height="27px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ForeColor="Red" ControlToValidate="txt_confirm" runat="server" ErrorMessage="Nhập mã xác nhận"></asp:RequiredFieldValidator>
    </td>
    </tr>


    <tr>
    <td colspan=3 align=left><hr>
    </td>
    <tr>
    <td align="right">
    <asp:Button ID="Button2" runat="server" Text="Lấy lại mật khẩu" class="btn" Height="25px" Width="120px" onclick="btn_getpassword_Click"/>
        </td>
        <td>
 <input id="Button3" type="button" value="Đóng" onclick="backs();" style="width:120px;height:25px" class="btn"/>
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

