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

    function update_request(id) {
        var contentUrl = "create_new_subject.aspx?id=" + id + "&types_id=1";
        var windowIndex = 1;
        var window = divpopup.GetWindow(windowIndex);
        divpopup.SetWindowContentUrl(window, contentUrl);
        divpopup.ShowWindow(window);
    }

    function deletes(val) {

        if (confirm("Bạn thực sự muốn xóa chủ đề này!\n Chọn [OK] để tiếp tục, [Cancel] để Đóng.")) {
            var url = "search_subject.aspx?id=" + val + "&vmode=del";
            loadXMLUpdate(url);
            location.reload(true);
        }
    }


</script>
<fieldset>
<dx:ASPxPopupControl ID="ASPxPopupControl4" runat="server"
                    AllowDragging="True" AllowResize="True" ClientInstanceName="divpopup"
                            CloseAction="CloseButton" 
                            EnableViewState="False" PopupElementID='divdetail'
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="765px"
                            Height="738px" FooterText=""
                            HeaderText="Cập nhật chủ đề bài viết" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                                                                    <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />
                            </dx:ASPxPopupControl>
 <table border="0" cellpadding=4 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;background-color:#3399FF;color:Black" class="btn_forum">
<tr class="btn_project" style="text-align:left;font-weight:bold;">
   <td with=60%>
<img src="images/forum.png" width=25 height=18> DIỄN ĐÀN SCMCT ONLINE
   </td>
      <td align=left>
        <table cellpadding=0 cellspacing=0 border=0 width=100%> <tr><td align=center>Bài mới</td><td align=right><asp:Label ID="lbl_create_new_subject" runat="server" ><a id="create_new_subject" class="btn" href='#' title='Chuyên mục mới' >  <img src="images/post_new.png" width="20" height="20"> Chuyên mục mới</a></asp:Label>

         <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_subject.aspx?types_id=1"
                            EnableViewState="False" PopupElementID="create_new_subject"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="765px"
                            Height="738px" FooterText=""
                            HeaderText="Tạo chủ đề mới" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>


        </td></tr></table>
        
        </td>
   </td>        
   </tr>
   <asp:Repeater ID="showListNews" runat="server" 
        onitemdatabound="showListNews_ItemDataBound">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
        <tr style="background-color:#FFFFFF;" >
        <td width=60% >
        <table cellpadding=3 cellspacing=0 border=0 width=100%>
        <tr>
        <td title='<%#Eval("title","Xem {0}") %>'>
        <a style="text-decoration: none" href='<%#Eval("title","#{0}")%>' >
        <img src="images/newstext.png" width=15 height=15> <b><%#Eval("title") %></b>
        </a>
        <td>
        <td align =right>
        <asp:Label ID="lbl_edit_subject" runat="server" ><a style=cursor:pointer title='Sửa chủ đề' onclick=update_request('<%#Eval("chu_de_id") %>')><img src=images/edit.gif width=15 height=15 alt='Cập nhật chủ đề'></asp:Label>
        
        <asp:Label ID="lbl_del_subject" runat="server" > | <a style=cursor:pointer title='Sửa chủ đề' onclick=deletes('<%#Eval("chu_de_id") %>')><img src=images/delcm.png width=15 height=15 alt='Xóa chủ đề'></asp:Label>

        </td>
        </tr>
        <tr>
        <td>
        <font size=-2><i><%#Eval("description") %></i></font>
        </td>
        <td valign=middle align=right>
            <font size=-2><i><asp:Label id="lbl_cnt" runat="server" Text=""></asp:Label></i></font>
        </td>
        </tr>
        </table>
        
        
        </td>
        <td>

        <table cellpadding=3 cellspacing=0 border=0 width=100%><tr><td width=5% valign=middle>
        <asp:Image id="userImg" runat="server" width=40 height=40></asp:Image>
        </td>
        <td>
        <asp:HyperLink id="details" runat="server"  title='Xem chi tiết bài viết'></asp:HyperLink>
        <br> 
        <font size=-2><i><asp:Label id="lbl_text" runat="server"></asp:Label>
        <a style="cursor:pointer" ID='<%#Eval("chu_de_id", "username{0}") %>'><asp:Label id="created_by" runat="server" Text=""  title='Xem chi tiết'></asp:Label></a>
        <asp:Label id="created_date" runat="server"></asp:Label></i>
        </td>
        </tr>
        </table>

            

         <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl='<%#Eval("created_by", "user_info.aspx?id={0}") %>'
                            EnableViewState="False" PopupElementID='<%#Eval("chu_de_id", "username{0}") %>'
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
                                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                                                                                                <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />
                   </dx:ASPxPopupControl>              

         </td>
         </tr>
                     
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
        </asp:Repeater>   
        </table>







<asp:Repeater ID="show_subject" runat="server" 
        onitemdatabound="show_subject_ItemDataBound1" >
<HeaderTemplate>
<table border="0"  cellpadding=0 cellspacing=0  width="100%" style="border:1px solid #59A5F7">
</HeaderTemplate>
<ItemTemplate>
    <tr class="post_news">
    <td>
     <a name='<%#Eval("title") %>'>
    <table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td valign="middle"><img src="images/forum.png" width=15 height=15> <%#Eval("title")%></td><td align=right>
      <asp:Label ID="lbl_post_new" runat="server" ><a class="btn" href='<%#Eval("url") %>' title='Viết bài mới' >  <img src="images/post_new.png" width="20" height="20"> Bài mới</a></asp:Label>
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
        <table border="0" cellpadding=4 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;background-color:#1FA9F8" class="btn_forum">
        <tr style="text-align:center;font-weight:bold;font-size:11px;background-color:#5FBFF7">
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
                    
                    <asp:Image ID="img_like" runat="server" ImageUrl="images/open_news.png" Width=25 Height=20/>
                    </td>
                    <td with=10% valign=middle align=center style="cursor:pointer;"  onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'<%#Eval("BAI_VIET_ID","div{0}")%>')>
                    <div id='<%#Eval("BAI_VIET_ID","div{0}")%>' class="like_text">
                    <%#Eval("liked")%>
                    </div>
                    <div class="like_fm">
                    &nbsp
                    </div>
                    </td>

                    <td align=left with=25%><img style="border-radius: 5px;" src="<%# Eval("avatar_path","images/avatars/{0}") %>" width="30px" height="30px">&nbsp<asp:HyperLink ID="link_show_detail" runat="server" Text='<%# Eval("tieu_de") %>' title='Xem chi tiết'></asp:HyperLink><br><font size=-3><i>Tạo bởi 
                                        <a style="cursor:pointer" ID='<%#Eval("BAI_VIET_ID", "username{0}") %>' ><font color="Yellow"><%#Eval("username") %></font></a>
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
                    
                        <asp:HyperLink title='Xem chi tiết' ID="link_comment" runat="server"></asp:HyperLink><br>
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
<br>&nbsp
<%--    <table cellpadding=3 cellspacing=3 style="color:Blue">
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
    </table>--%>
</td>
</tr>
</table>
</FooterTemplate>
    </asp:Repeater>
    </fieldset>
</asp:Content>
