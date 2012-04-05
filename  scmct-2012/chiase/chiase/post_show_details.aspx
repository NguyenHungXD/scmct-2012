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
        <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td></td><td align=right>Đăng bởi, nvdat <%#Eval("ngay_tao", "{0:dd/mm/yyyy hh:mm:ss tt}")%></td></tr></table></td>
    </tr>

    <tr>
    <td><table border=0 cellpadding=3 cellspacing=3 width=100% bgcolor=white><tr><td><%#Eval("noi_dung")%></td></tr></table></td>
    </tr>
    <tr >
    <td>       
        <asp:Repeater ID="showList_comment" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding=0 cellspacing=0 width="100%"  style="border:1px solid #CCFFFF;">
        </HeaderTemplate>
        <ItemTemplate>
                    <tr >
                    <td>
                    &nbsp;&nbsp
                    </td>
                    <td>
                    <div class="comment_format_header">
                    &nbsp
                    <div>
                    <div class="comment_format">
                    <table border=0 cellpadding=1 cellspacing=1 width=100% bgcolor="#ede7fe">
                    <tr>
                    <td width=20% bgcolor="#FFFFCC" VALIGN="top">
                        <table border=0 cellpadding=0 cellspacing=0>
                        <tr>
                        <td colspan=2>
                            <asp:Image ID="user_img" runat="server" ImageUrl="images/user.gif" Width="40" Height="40"/><br>
                            <asp:Label ID="lbl_username" runat="server" Text="nvdat"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td colspan=2>
                            <asp:Label ID="lbl_created_date" runat="server" Text="12/02/2012 08:02:35 AM"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        Bài gửi :
                        </td>
                        <td>
                            <asp:Label ID="lbl_sum" runat="server" Text="80"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        Nhóm:
                        </td>
                        <td>
                            <asp:Label ID="lbl_groupname" runat="server" Text="Admin"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        Tim:
                        </td>
                        <td>
                            <asp:Label ID="lbl_sum_point" runat="server" Text="100"></asp:Label>
                            <asp:Image ID="Image1" runat="server" ImageUrl="images/heart.gif" Width="10" Height="10"/>
                        </td>
                        </tr>
                        </table>
                    </td>
                    <td width=80% bgcolor="#FFFFCC" VALIGN="top">
                        <%#Eval("noi_dung")%>
                    </td>
                    </tr>
                    </table>
                    </div>
                    <div class="comment_format_footer">
                    &nbsp

                    <div>
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
    <br>
    <font color=white>Ý kiến của bạn :</font>
    <table>
    <tr>
    <td>
            <asp:TextBox ID="txt_comment" runat="server" class="txtformat_area" 
        Height="103px" TextMode="MultiLine" Width="917px"></asp:TextBox>
        <asp:Button ID="btn_comment" runat="server" Text="Gửi" 
        class="btnformat" onclick="btn_comment_Click"/>
    </td>
    </tr>
    </table>


</asp:Content>
