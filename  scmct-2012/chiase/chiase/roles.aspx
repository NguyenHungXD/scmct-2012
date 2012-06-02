<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="roles.aspx.cs" Inherits="chiase.roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<script type="text/javascript">
        function backs() {
            window.location = "register.aspx";
        }
</script>

<fieldset>
<table cellpadding=5 cellspacing=3 border=0 width=100%><tr><td>
    <asp:Label ID="lbl_contents" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td align="right">
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
</td>
</tr>
</table>
</fieldset>
</asp:Content>
