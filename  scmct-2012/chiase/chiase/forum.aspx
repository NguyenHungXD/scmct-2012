<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="forum.aspx.cs" Inherits="chiase.forum" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">


<asp:Repeater ID="show_subject" runat="server" 
        onitemdatabound="show_subject_ItemDataBound1" >
<HeaderTemplate>
<table border="0"  cellpadding=0 cellspacing=0  width="100%" >
</HeaderTemplate>
<ItemTemplate>
    <tr class="post_news">
    <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td><%#Eval("title")%></td><td align=right>
    
        <asp:HyperLink ID="link_post_new" runat="server" Text="Bài mới" NavigateUrl='<%#Eval("id","post_news.aspx?subjectID={0}") %>' class="btn_link"></asp:HyperLink>
    </td><tr></table> </td>
        
    </tr>
    <tr class="post_news_desc">
    <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td><%#Eval("description")%></td><td align=right><%#Eval("created_date", "{0:dd/mm/yyyy hh:mm:ss tt}")%></td></tr></table></td>
    </tr>
    <tr >
    <td>       
        <asp:Repeater ID="showListPost" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;">
        <tr class="new_post">
        <td colspan=3>
            Tiêu đề
        </td>
        <td>
            Bình luận
        </td>
        <td>
            Lượt xem
        </td>
        <td>
            Xếp hạng
        </td>
        <td>
            Bình luận mới
        </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>

                    <tr class="new_post_details">
                    <td with=10%>Status</td>
                    <td with=10%>Like</td>
                    <td align=left with=25%><asp:HyperLink ID="link_show_detail" runat="server" NavigateUrl='<%# Eval("bai_viet_id", "post_show_details.aspx?news_id={0}") %>'
                                        Text='<%# Eval("tieu_de") %>'></asp:HyperLink><br><i>Tạo bởi 
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("username", "user_info.aspx?user_id={0}") %>' Text='<%# Eval("username") %>'></asp:HyperLink>, <%#Eval("ngay_tao", "{0:dd/mm/yyyy hh:mm:ss tt}")%></i></td>
                    <td with=10%>0</td>
                    <td with=10%>0</td>
                    <td with=10%>0</td>
                    <td with=25% align=left>0</td>
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
</table>
</FooterTemplate>
    </asp:Repeater>


</asp:Content>
