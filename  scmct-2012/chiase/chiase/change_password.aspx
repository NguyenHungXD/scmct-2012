<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="change_password.aspx.cs" Inherits="chiase.change_password" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_area" runat="server">
<script language="javascript" type="text/javascript">
    function ValidateLenMK(oSrc, args) {
        if (document.all["<%=txt_new_pass.ClientID%>"].value.length < 4) {
            args.IsValid = false;
        } else
            args.IsValid = true;
    }

    function backs() {
        window.location = "default.aspx";
    }
</script>
    <fieldset>
<!--<legend>Đổi mật khẩu</legend> -->
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2><br>
        <b><asp:Label ID="lbl_error" runat="server" Text="Sau khi đổi mật khẩu thành công bạn sẽ phải đăng nhập lại với mật khẩu mới"></asp:Label></b>
        </td>
    </tr>
    <tr>
    <td colspan=2>
        &nbsp;<asp:Image ID="img_user" runat="server" Height="50px" Width="50px" />
        <br />
        <i>Truy cập lần cuối, <asp:Label ID="lbl_lasted_access" runat="server" ForeColor="White"></asp:Label></i>
        <br>
        <b><asp:Label ID="lbl_group_name" runat="server" Text=""></asp:Label></b>
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
            Width="250px" Height="22px" TextMode="Password"></asp:TextBox><font color=red>*</font>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_new_pass" runat="server" ErrorMessage="Nhập mật khẩu mới"></asp:RequiredFieldValidator>
         <asp:CustomValidator ID="CustomValidator3" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Mật khẩu ít nhất 4 ký tự" ClientValidationFunction="ValidateLenMK"></asp:CustomValidator>
    </tr>
    <tr>
    <td>
        Nhập lại mật khẩu:
    </td>
    <td>
        <asp:TextBox ID="txt_new_pass_re" runat="server"  class="txtformat" 
            Width="250px" Height="22px" TextMode="Password"></asp:TextBox><font color=red>*</font>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_new_pass_re" runat="server" ErrorMessage="Xác nhận mật khẩu"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_new_pass_re" ControlToCompare="txt_new_pass" runat="server" ErrorMessage="Mật khẩu không bằng nhau"></asp:CompareValidator>
    </td>

    </tr>
    <tr>
    <td colspan=3 align=left><hr>
        <p align=center><asp:HyperLink style="color:white" title="Quên mật khẩu" ID="link_forget_pass"  runat="server" Text="Quên mật khẩu?" NavigateUrl="forget_password.aspx"></asp:HyperLink>
    <br>
    <br>



                <table border=0 cellpadding=3 cellspacing=3 width=20%>
                <tr>
                <td align=right>


                    <asp:Button ID="Button2" runat="server" Text="Lưu thay đổi" class="btn" Height="25px" Width="120px" onclick="btn_changepass_Click"/>

                </td>
                <td align=left>

                <input id="Button3" type="button" value="Đóng" onclick="backs();" style="width:120px;height:25px" class="btn"/>


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
