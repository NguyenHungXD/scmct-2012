﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_allbum_info.aspx.cs" Inherits="chiase.update_allbum_info" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>.:SCMCT-Cổng thông tin SCMCT:.</title>
<meta name="keywords" content="SCMCT, Sách cho miền cát trắng, sach cho mien cat trang, quyen gop sach, sach cu, sach cho tre em ngheo" />
<meta name="description" content=".::SCMCT - Công quyên góp sách online ::." />
<link href="Styles/templatemain_style.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">

                <br>
            <asp:Label ID="lbl_error" runat="server" style="font-size:medium"></asp:Label>
            <br>
            <br>
<table border=0 cellpadding=3 cellspacing=3 width=100%>
        <tr>

        <td>
        Tên allbum:
        </td>
        <td>
        <asp:TextBox ID="txt_allbum_name" runat="server" class="txtformat" Width="300px" 
                Height="23px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td valign=top>
        Mô tả:
        </td>
        <td>
        <asp:TextBox ID="txt_desc" runat="server" class="txtformat_area" Height="138px" 
                TextMode="MultiLine" Width="545px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>&nbsp
        </td>
        <td>
            <dx:ASPxButton ID="btn_save_allbum" runat="server" Text="Lưu allbum" 
                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="120px" OnClick="btn_save_allbum_Click">
            </dx:ASPxButton>

        </td>
        </tr>
        </table>
    </form>
</body>
</html>
