<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="help.aspx.cs" Inherits="chiase.help" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<script type="text/javascript">
    function update_request(id) {
        var contentUrl = "create_new_subject.aspx?id=" + id + "&types_id=4";
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
    <table border="0" cellpadding=4 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;background-color:#3399FF;color:Black" class="btn_forum">
    <tr class="btn_project" style="text-align:left;font-weight:bold;">
   <td with=60%>
<img src="images/help.png" width=20 height=18> TRỢ GIÚP SCMCT ONLINE
   </td>
      <td align=left>
        <table cellpadding=0 cellspacing=0 border=0 width=100%> <tr><td align=center>Bài mới</td><td align=right><asp:Label ID="lbl_create_new_subject" runat="server" ><a id="create_new_subject" class="btn" href='#' title='Chuyên mục mới' >  <img src="images/post_new.png" width="20" height="20"> Chuyên mục mới</a></asp:Label>

         <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_subject.aspx?types_id=4"
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
                                                                                                                            <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />
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
        <img src="images/helpbook.png" width=15 height=15> <b><%#Eval("title") %></b>
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

            

         <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
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
                                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                                                                                                <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />
                   </dx:ASPxPopupControl>              




 
<%--        <tr>
        <td>
        <%#Eval("description") %>
        </td>
        </tr>--%>

                    
                    
                    
         
         </td>
         </tr>
                     
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
        </asp:Repeater>   
        </table>

  
   <asp:Repeater ID="showListNewsDetail" onitemdatabound="showListNewsDetail_ItemDataBound"  runat="server" >
        <ItemTemplate>
        <a name='<%#Eval("title") %>'>
        <table border="0" cellpadding=4 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;background-color:#3399FF;color:Black" class="btn_forum">
        <tr class="post_news">
        <td>
            <table cellpadding=0 cellspacing=0 border=0 width=100%>
            <tr>
            <td>
            <img src="images/help.png" width=15 height=15> <b><%#Eval("title") %></b>
            </td>
            <td align="right">
            <asp:Label ID="lbl_post_new" runat="server" ><a class="btn" href='<%#Eval("url") %>' title='Viết bài mới' >  <img src="images/post_new.png" width="20" height="20"> Bài mới</a></asp:Label>
            </td>
            </tr>
            </table>
        </td>
        </tr>
        <tr class="post_news_desc">
        <td>
         <font size=-2><i><%#Eval("description") %></i></font></td>
        </tr>
        <tr style="background-color:White;padding:5px 20px 5px 20px">
        <td>
        <div style="padding:5px 10px 5px 5px;width:880px;height:170px;overflow:auto;border:1px solid #C8C8C8;background-color:#FFFFFF"> 
            <b><asp:HyperLink id="first_news_title" runat="server" Text="" title="Xem chi tiết"></asp:HyperLink></b><br>
            <asp:Label id="first_news_content" runat="server" Text=""></asp:Label>
            <b><asp:HyperLink id="link_view" runat="server" title="Xem chi tiết"></asp:HyperLink></b>
        </div>
        </td>
        </tr>
        <tr style="background-color:White">
        <td>
        <div style="width:895px;height:100px;overflow:auto;border:1px solid #C8C8C8;background-color:#F0F0F0">
            <asp:DataList ID="DataList1"  RepeatLayout="Table" RepeatColumns="4"  
                    RepeatDirection="Horizontal" runat="server" 
                    onitemdatabound="DataList1_ItemDataBound">
            <ItemTemplate>
                        <div style="padding:5px 10px 5px 5px"><img src="images/narrow.png" width=12 height=14> <asp:HyperLink id="list_news" runat="server" title="Xem chi tiết"></asp:HyperLink></div>
            </ItemTemplate>
            </asp:DataList>
        </div>
        </td>
        </tr>
        </table>  
        </ItemTemplate>
        </asp:Repeater>   
        

<dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server"
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
                                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                                                                    <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />
                            </dx:ASPxPopupControl>

</fieldset>
</asp:Content>
