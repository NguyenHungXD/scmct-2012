<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_info.aspx.cs" Inherits="chiase.user_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 13%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset> 
<table cellpadding="3" cellspacing="1" border="0" bgcolor="#CCFFCC" width="100%" style="color:#FFFF33">
<tr bgcolor="#ff6600">
<td colspan="2" align="left">
    <asp:Image ID="img_user" runat="server" width="120" Height="120" 
        style="text-align: left"/><br>
    <b><asp:Label ID="user_name" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Tên
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_hoten" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Sinh nhật
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_ngaysinh" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Địa chỉ
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_diachi" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    SDT
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_sodienthoai" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Email
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_email" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Skype
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_skype" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Yahoo
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_yahoo" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Website
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_website" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Tham gia
    </td>
    <td width="80%">
    <b><asp:Label ID="lbl_thamgia" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Nhóm
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_nhom" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Tim
        </td>
    <td width="80%">
<b><asp:Label ID="lbl_sum_point" runat="server" Text='<%#Eval("heart")%>'></asp:Label></b>
<asp:Image ID="Image1" runat="server" ImageUrl="images/heart.gif" Width="10" Height="10"/>

</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Số bài viết
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_baidang" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Dự án tham gia
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_duan" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Số sách ủng hộ
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_sach" runat="server" Text="100"></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Truy cập lần cuối
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_truycap" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="#ff6600">
<td align="right" class="style1">
    Trạng thái
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_trangthai" runat="server" Text="Online"></asp:Label></b>
</td>
</tr>

<tr>
<td colspan="2">

</td>
</tr>
</table>
</fieldset> 




    </div>
    </form>
</body>
</html>
