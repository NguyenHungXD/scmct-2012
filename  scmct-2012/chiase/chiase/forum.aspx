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
                    <td with=10%>
                    
                    <asp:Image ID="img_like" runat="server" ImageUrl="images/new_post.gif" Width=25 Height=20/>
                    </td>
                    <td with=10%>
                    
                        </td>
                   
                    <td align=left with=25%><asp:HyperLink ID="link_show_detail" runat="server" NavigateUrl='<%# Eval("bai_viet_id", "post_show_details.aspx?news_id={0}") %>'
                                        Text='<%# Eval("tieu_de") %>'></asp:HyperLink><br><i>Tạo bởi 
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("username", "user_info.aspx?user_id={0}") %>' Text='<%# Eval("username") %>'></asp:HyperLink>, <%#Eval("ngay_tao", "{0:dd/mm/yyyy hh:mm:ss tt}")%></i></td>
                    <td with=10%>
                    
                        <asp:Label ID="lbl_cnt_comment" runat="server" Text='<%# Eval("xem") %>'></asp:Label>
                    
                    </td>
                    <td with=10%>
                        <asp:Label ID="lbl_cnt_view" runat="server" Text="0"></asp:Label>
                    </td>
                    <td with=10%>
                    
                    <asp:Image ID="Image2" runat="server" ImageUrl="images/star.gif" Width=12 Height=12/>
                    <asp:Image ID="Image5" runat="server" ImageUrl="images/star.gif" Width=12 Height=12/>
                    <asp:Image ID="Image6" runat="server" ImageUrl="images/star.gif" Width=12 Height=12/>
                    <asp:Image ID="Image7" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image8" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    </td>
                    <td with=25% align=left>
                    
                        <asp:HyperLink ID="link_comment" runat="server" NavigateUrl='<%# Eval("bai_viet_id", "post_show_details.aspx?news_id={0}") %>'>
                            <asp:Label ID="lbl_new_comment" runat="server" Text=""></asp:Label>
                        </asp:HyperLink>
                        
                    
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
    <table cellpadding=3 cellspacing=3>
    <tr>
    <td>
        <asp:Image ID="Image1" runat="server" ImageUrl="images/new_post.gif" /> Bài mới đăng
    </td>
    <td>
        <asp:Image ID="Image2" runat="server" ImageUrl="images/new_reply.gif"/> Phản hồi mới
    </td>
    <td>
        <asp:Image ID="Image3" runat="server"  ImageUrl="images/views.gif"/> Bài xem nhiều
    </td>
    <td>
        <asp:Image ID="Image4" runat="server" ImageUrl="images/lock.gif"/> Bài bị khóa
    </td>
    </tr>
    </table>
</td>
</tr>
</table>
</FooterTemplate>
    </asp:Repeater>


</asp:Content>
