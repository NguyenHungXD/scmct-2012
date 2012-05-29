<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project_detail_popup.aspx.cs" Inherits="chiase.project_detail_popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  
    <fieldset> 
<table cellpadding="3" cellspacing="1" border="0" bgcolor="#0099CC" width="100%">
<tr bgcolor="white">
<td width="20%" align="right">
    Mã dự án
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_maduan" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Tên dự án
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_tenduan" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Chi tiết
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_chitiet" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Ghi chú
    </td>
    <td width="80%">
    <b><asp:Label ID="lbl_ghichu" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Số sách cần quyên góp
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_book" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Trạng thái
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_trangthai" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Ngày bắt đầu
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_batdau" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Ngày kết thúc
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_ketthuc" runat="server" Text=""></asp:Label></b>
</td>
</tr>
</table>
 </fieldset> 
   
    </form>
</body>
</html>
