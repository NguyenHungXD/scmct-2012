<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_new_module.aspx.cs" Inherits="chiase.create_new_module" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>.:SCMCT-Cổng thông tin SCMCT:.</title>
<meta name="keywords" content="SCMCT, Sách cho miền cát trắng, sach cho mien cat trang, quyen gop sach, sach cu, sach cho tre em ngheo" />
<meta name="description" content=".::SCMCT - Công quyên góp sách online ::." />
<link href="Styles/templatemain_style.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
    </script>

</head>
<body>
<form id="form1" runat="server">

<fieldset>   
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align="center">
        
        </td>
        <td valign="middle" align="right">

            <asp:Label ID="lbl_create_new_module" runat="server" >
                    <asp:Button ID="Button2" runat="server" Text="Lưu chức năng" class="btn" 
                        Height="25px" Width="120px" onclick="Button2_Click1"/>
            </asp:Label>

        </td>
    </tr>
    <tr>
    <td colspan=3>
    <font size=2><b><asp:Label ID="lbl_error" runat="server" ></asp:Label></b></font>
        <hr>
    </td>
    </tr>
        <tr>
    <td><br><br>
        Mã chức năng:
    </td>
    <td>
        
    <i><asp:Label ID="lbl_help" runat="server" Text="Bạn nên thay đổi mã chức năng phù hợp.<br>Ví dụ: <b>CNxxx.000001</b> -> <b>CNND.000001</b> [xxx->ND: cho chức năng người dùng]"></asp:Label>  </i><br>
        <asp:TextBox ID="txt_feature_id" runat="server"  class="txtformat" 
            Width="150px" Height="22px" BackColor="#CCFFCC">
            </asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ForeColor="Red" ControlToValidate="txt_feature_id" runat="server" ErrorMessage="Nhập mã chức năng"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td>
        Tên chức năng:
    </td>
    <td>
        <asp:TextBox ID="txt_module_name" runat="server"  class="txtformat" 
            Width="300px" Height="22px" BackColor="#CCFFCC"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ForeColor="Red" ControlToValidate="txt_module_name" runat="server" ErrorMessage="Nhập tên chức năng"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
      <td>
        Chi tiết:
    </td>
    <td>
        <asp:TextBox ID="txt_desc" runat="server" class="txtformat_area"
    Width="585px" Height="49px" BackColor="#CCFFCC" Rows="4" TextMode="MultiLine"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        Đường dẫn:
    </td>
    <td>
 <asp:TextBox ID="txt_path" runat="server"  class="txtformat" 
            Width="300px" Height="22px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" ForeColor="Red" ControlToValidate="txt_path" runat="server" ErrorMessage="Nhập đường dẫn truy cập tới chức năng"></asp:RequiredFieldValidator>
    </td>
    </tr>
  

    <tr>
       <td>
           Code path:
    </td>
    <td>
 <asp:TextBox ID="txt_code_path" runat="server"  class="txtformat" 
            Width="300px" Height="22px" BackColor="#CCFFCC"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ForeColor="Red" ControlToValidate="txt_code_path" runat="server" ErrorMessage="Nhập đường dẫn truy cập tới code"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td colspan=3 align=left><hr>
         <table width="100%">
     <tr align="right">
    <td colspan=3 align=right style="color:White">
    <br>&nbsp Hôm nay,  nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>
</tr>
     </table>
    </fieldset>
    </form>
</body>
</html>
