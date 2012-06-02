<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="forum.aspx.cs" Inherits="chiase.forum" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<script type="text/javascript">

    function like_post(id, val, divid) {
        var url = "update_like_post.aspx?post_id=" + id;
        loadXMLUpdate(url);
        document.getElementById(divid).innerHTML = val + 1;
    }
</script>


<asp:Repeater ID="show_subject" runat="server" 
        onitemdatabound="show_subject_ItemDataBound1" >
<HeaderTemplate>
<table border="0"  cellpadding=0 cellspacing=0  width="100%" >
</HeaderTemplate>
<ItemTemplate>



    <tr class="post_news">
    <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td valign="middle"><img src="images/subject.png" width="40" height="25"><%#Eval("title")%></td><td align=right>
            <asp:Label ID="lbl_post_new" runat="server" ><asp:HyperLink style="cursor:pointer" ID="linkPostnew" NavigateUrl='<%#Eval("id","post_news.aspx?subjectID={0}") %>' runat="server">  <img src="images/post_new.png" width="20" height="20"> Bài mới</asp:HyperLink></asp:Label>
    </td><tr></table> </td>
    </tr>
    <tr class="post_news_desc">
    <td><i><table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td><%#Eval("description")%></td><td align=right>Tạo ngày, <%#Eval("created_date", "{0:dd/MM/yyyy hh:mm:ss tt}")%></td></tr></table></i></td>
    </tr>
    <tr>
    <td>     

    <asp:Repeater ID="showListPost" runat="server" 
            onitemdatabound="showListPost_ItemDataBound1">
        <HeaderTemplate>
        <table border="0" cellpadding=4 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;background-color:#3BB9FF" class="btn_forum">
        <tr class="new_post">
        <td colspan=3 width=30%>
            Tiêu đề
        </td>
        <td width=10%>
            Lượt xem
        </td>
        <td width=10%>
            Bình luận
        </td>
        <td width=10%>
            Xếp hạng
        </td>
        <td width=40%>
            Bình luận mới
        </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>

                    <tr class="new_post_details_4rum">
                    <td with=10%>
                    
                    <asp:Image ID="img_like" runat="server" ImageUrl="images/new_post.gif" Width=25 Height=20/>
                    </td>
                    <td with=10% valign=middle align=center style="cursor:pointer;"  onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'<%#Eval("BAI_VIET_ID","div{0}")%>')>
                    <div id='<%#Eval("BAI_VIET_ID","div{0}")%>' class="like_text">
                    <%#Eval("liked")%>
                    </div>
                    <div class="like_fm">
                    &nbsp
                    </div>
                    </td>

                    <td align=left with=25%><img src="<%# Eval("avatar_path","images/avatars/{0}") %>" width="30px" height="30px">&nbsp<asp:HyperLink ID="link_show_detail" runat="server" Text='<%# Eval("tieu_de") %>'></asp:HyperLink><br><font size=-3><i>Tạo bởi 
                                        <a style="cursor:pointer" ID='<%#Eval("BAI_VIET_ID", "username{0}") %>'><font color="Yellow"><%#Eval("username") %></font></a>
                                        , <%#Eval("ngay_tao", "{0:dd/MM/yyyy hh:mm:ss tt}")%></font></i>
                    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl='<%#Eval("username", "user_info.aspx?user_name={0}") %>'
                            EnableViewState="False" PopupElementID='<%#Eval("BAI_VIET_ID", "username{0}") %>'
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="600px" FooterText=""
                            HeaderText="" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                   </dx:ASPxPopupControl>              
                    </td>
                    <td with=10%>
                    
                        <asp:Label ID="lbl_cnt_comment" runat="server" Text='<%# Eval("xem") %>'></asp:Label>
                    
                    </td>
                    <td with=10%>
                        <asp:Label ID="lbl_cnt_view" runat="server" Text="0"></asp:Label>
                    </td>
                    <td with=10%>
                    
                    <asp:Image ID="Image2" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image5" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image6" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image7" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image8" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    </td>
                    <td with=25% align=left>
                    
                        <asp:HyperLink ID="link_comment" runat="server"></asp:HyperLink><br>
                        <font size=-3><asp:Label ID="lbl_text" runat="server"></asp:Label>
                        <asp:Label ID="_cm_by" runat="server" Text=""></asp:Label> <asp:Label ID="lbl_date_time" runat="server" Text=""></asp:Label></font>
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
    <table cellpadding=3 cellspacing=3 style="color:White">
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
