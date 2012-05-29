<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_new_kind_request.aspx.cs" Inherits="chiase.create_new_kind_request" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>.:SCMCT-Cổng thông tin SCMCT:.</title>
<meta name="keywords" content="SCMCT, Sách cho miền cát trắng, sach cho mien cat trang, quyen gop sach, sach cu, sach cho tre em ngheo" />
<meta name="description" content=".::SCMCT - Công quyên góp sách online ::." />
<link href="Styles/templatemain_style.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <fieldset>  
        <table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align="center"><br><hr>
        <font size=3><asp:Label ID="lbl_error" runat="server" ></asp:Label></font>
        </td>
        </tr>
        <tr>
        <td valign="middle" align="right">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="txt_name" ForeColor="red" runat="server" ErrorMessage="Nhập tên trạng thái mới"></asp:RequiredFieldValidator><br>
            Loại yêu cầu:<asp:TextBox ID="txt_name" runat="server" class="txtformat" Width="200px" Height="25px"></asp:TextBox>
            
        </td>
    </tr>
        <tr>
        <td valign="middle" align="right">
            <asp:Button ID="btn_saves" runat="server" Text="Lưu loại yêu cầu" class="btn" 
                Width="120px" Height="25" onclick="btn_saves_Click"/>
        </td>
    </tr>
    <tr>
    <td align=right><hr>
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>
    </fieldset>  
    </form>
</body>
</html>
