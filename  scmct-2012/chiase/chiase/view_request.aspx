<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_request.aspx.cs" Inherits="chiase.view_reuqest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 <fieldset>  
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2>
        <font size=3><b><asp:Label ID="lbl_result" runat="server" ForeColor="#FFFFFF"></asp:Label></b></font>
        <hr>
        </td>
    <td rowspan=9><br>
    </td>
    </tr>
    <tr>
    <td>
    Tiêu đề:
    </td>
    <td align="left">
        <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        Nội dung:
    </td>
    <td align="left">
        <asp:Label ID="lbl_content" runat="server" Text=""></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        Loại yêu cầu:
    </td>
    <td align="left">
        <asp:Label ID="lbl_kind_request" runat="server" Text=""></asp:Label>
    </td>
    </tr>

     <tr>
    <td>
        Trạng thái:
    </td>
    <td align="left">
        <asp:Label ID="lbl_status" runat="server" Text=""></asp:Label>
    </td>
    </tr>

       <tr>
    <td>
        Người yêu cầu:
    </td>
    <td align="left">
        <asp:Label ID="lbl_requested_by" runat="server" Text=""></asp:Label>
    </td>
    </tr>
          <tr>
    <td>
        Ngày yêu cầu:
    </td>
    <td align="left">
        <asp:Label ID="lbl_requested_date" runat="server" Text=""></asp:Label>
    </td>
    </tr>
    </table>
    </fieldset>
    </form>
</body>
</html>
