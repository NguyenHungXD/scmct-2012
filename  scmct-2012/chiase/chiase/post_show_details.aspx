<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="post_show_details.aspx.cs" Inherits="chiase.post_show_details" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">


<asp:Repeater ID="show_content" runat="server" 
        onitemdatabound="show_content_ItemDataBound" >
<HeaderTemplate>
<table border="0"  cellpadding=0 cellspacing=0  width="100%" >
</HeaderTemplate>
<ItemTemplate>
    <tr class="post_news">
    <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td><%#Eval("tieu_de")%></td><tr></table> </td></tr>

    <tr class="post_news_desc">
        <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td align=right><%#Eval("ngay_tao", "{0:dd/mm/yyyy hh:mm:ss tt}")%></td></tr></table></td>
    </tr>

    <tr>
    <td><table border=0 cellpadding=3 cellspacing=3 width=100% bgcolor=white><tr><td><%#Eval("noi_dung")%></td></tr></table></td>
    </tr>
    <tr >
    <td>       
        <asp:Repeater ID="showList_comment" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;">
        </HeaderTemplate>
        <ItemTemplate>
                    <tr class="new_post_details">
                    <td>
                    <%#Eval("noi_dung")%>
                    </td>
                    </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
    </td>
    </tr>
</ItemTemplate>
<FooterTemplate>
<tr>
<td>
</td>
</tr>
</table>
</FooterTemplate>
    </asp:Repeater>
            <asp:TextBox ID="txt_comment" runat="server" class="txtformat_area" 
        Height="103px" TextMode="MultiLine" Width="934px"></asp:TextBox>
        <asp:Button ID="btn_comment" runat="server" Text="Phản hồi" 
        class="btnformat" onclick="btn_comment_Click"/>


</asp:Content>
