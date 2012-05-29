<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="post_show_details.aspx.cs" Inherits="chiase.post_show_details" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<asp:HiddenField ID="vusername" runat="server" />
<asp:HiddenField ID="bai_viet_ids" runat="server" />

<script type="text/javascript">
    
    function like_post(id,val,divid) {
        
        var url = "update_like_post.aspx?post_id=" + id;
        loadXMLUpdate(url);
        if (divid == 'liked1' || divid == 'liked2' || divid == 'liked3') {
            document.getElementById('liked1').innerHTML = val + 1;
            document.getElementById('liked2').innerHTML = val + 1;
            document.getElementById('liked3').innerHTML = val + 1;
        }
        else {
            var result = val + 1;
            document.getElementById(divid).innerHTML = "&nbsp(" +result + ")&nbsp";
        }
    }

    function validate() {
        var username = document.all["<%=vusername.ClientID%>"].value;
        if (username == "") {
            alert("Đăng nhập để bình luận allbum!")
            return;
        }
    }
    function deletes(id,vmode) {

        var url = "post_show_details.aspx?id=" + id + "&vmode=del";
        loadXMLUpdate(url);

        if (vmode != "comments") {
            window.location = "forum.aspx";
            alert("Bài viết đã được xóa");
        }
        else {
            var bv_id = document.all["<%=bai_viet_ids.ClientID%>"].value;
            window.location = "post_show_details.aspx?news_id=" + bv_id;
            alert("Bình luận đã được xóa");
        }
        }
    
</script>

    <script type="text/javascript">
    // <![CDATA[
        var MaxLength = 50;
        var CustomErrorText = "Nội dung phản hồi phải lớn hơn " + MaxLength.toString() + " ký tự.";
        function ValidationHandler(s, e) {
            if (e.html.length < MaxLength) {
                e.isValid = false;
                e.errorText = CustomErrorText;
            }
        }
        function HtmlChangedHandler(s, e) {
            ContentLength.SetText(s.GetHtml().length);
        }
    // ]]> 
    </script>

<asp:Repeater ID="show_content" runat="server" 
        onitemdatabound="show_content_ItemDataBound" >
<HeaderTemplate>
<table border="0"  cellpadding=0 cellspacing=0  width="100%" >
</HeaderTemplate>
<ItemTemplate>
    <tr class="post_news">
    <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td><%#Eval("tieu_de")%></td><td align="right"> 
        <a href="<%#Eval("BAI_VIET_ID","post_news.aspx?post_id={0}")%>" class="btn">Sửa bài</a>  <a style="cursor:hand" onclick=deletes('<%#Eval("BAI_VIET_ID")%>') class="btn">Xóa bài</a></td><tr></table> </td></tr>

    <tr class="post_news_desc">
        <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr>
            <td valign=middle>
            <b>
            <table border=0 cellpadding=2 cellspacing=0>
            <tr bgcolor="#0033ff" style="cursor:pointer;">
            <td>
            <a title="Thích" onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'liked1')>
            <asp:Image ID="Image2" runat="server"  ImageUrl="images/like.gif" Width=25 Height=15/>
            </td>
            <td>
            <font color="#FFFFFF">
             <div id="liked1"><%#Eval("liked")%>&nbsp</div>
             </font>
             </a>
             </td>
             </tr>
             </table>
             </b>
            </td>
            <td align=right >Đăng bởi,  
                <a href="#" ID='<%#Eval("username", "username{0}") %>'><font color="blue"><%#Eval("username") %></font>,</a> <%#Eval("ngay_tao", "{0:dd/MM/yyyy hh:mm:ss tt}")%>
            
            
            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl='<%#Eval("username", "user_info.aspx?user_name={0}") %>'
                            EnableViewState="False" PopupElementID='<%#Eval("username", "username{0}") %>'
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
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
            
            
            
            </td></tr></table></td>
    
                    
    
    </tr>
    
    <tr>
    <td><table border=0 cellpadding=3 cellspacing=3 width=100% bgcolor=white><tr><td><%#Eval("noi_dung")%></td></tr></table></td>
    </tr>
    <tr class="post_news_desc">
        <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr>
            <td valign=middle>
            <b>


             <table border=0 cellpadding=2 cellspacing=0>
            <tr bgcolor="#0033ff" style="cursor:pointer;">
            <td>
            <a title="Thích" onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'liked1')>
            <asp:Image ID="Image5" runat="server"  ImageUrl="images/like.gif" Width=25 Height=15/>
            </td>
            <td>
            <font color="#FFFFFF">
             <div id="liked2"><%#Eval("liked")%>&nbsp</div>
             </font>
             </a>
             </td>
             </tr>
             </table>


             </b>
            </td>
            </tr></table></td>
    </tr>
    <tr >
    <td>       
        <asp:Repeater ID="showList_comment" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding=1 cellspacing=3 width="100%"  style="border:1px solid #CCFFFF;">
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
                    <td width=20% bgcolor="#ecfce4" VALIGN="top">
                        <table border=0 cellpadding=0 cellspacing=0>
                        <tr>
                        <td colspan=2>
                            <asp:Image ID="user_img" runat="server" ImageUrl='<%#Eval("avatar_path", "images/avatars/{0}")%>' Width="40" Height="40" /><br>
                           
                           
                            <a style="cursor:pointer;" ID='<%#Eval("BAI_VIET_ID", "username{0}") %>'><font color="blue"><%#Eval("username") %></font></a>
                            

                   <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl='<%#Eval("username", "user_info.aspx?user_name={0}") %>'
                            EnableViewState="False" PopupElementID='<%#Eval("BAI_VIET_ID", "username{0}") %>'
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
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

                            <br>
                            Tham gia: <%#Eval("created_date", "{0:dd/MM/yyyy}")%>

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
                            <asp:Label ID="lbl_groupname" runat="server" Text='<%#Eval("groupname")%>'>'></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        Tim:
                        </td>
                        <td>
                            <asp:Label ID="lbl_sum_point" runat="server" Text='<%#Eval("heart")%>'></asp:Label>
                            <asp:Image ID="Image1" runat="server" ImageUrl="images/heart.gif" Width="10" Height="10"/>
                        </td>
                        </tr>
                        </table>
                    </td>
                    <td width=80% VALIGN="top" bgcolor="#ffffff">
                        <%#Eval("noi_dung")%>
                    </td>
                    </tr>
                    </table>

                    <table cellpadding=0 cellspacing=2 border=0 width=100%>
                    <tr align=right>
                    <td align=right>
                    <font size=-3><i>
                        Ngày, <%#Eval("ngay_tao", "{0:dd/MM/yyyy hh:mm:ss tt}")%>
                    </font></i>
                    </td>
                   <td colspan=2>                    
                   <b>
                   <table cellpadding=0 cellspacing=0 border="0">
                   <tr  style="cursor:pointer;"><td bgcolor="#FFFFFF" valign="bottom" align="center"> <a onclick=deletes('<%# Eval("BAI_VIET_ID")%>','comments') style='cursor:pointer' id="new_project"><image src="images/delete.png" width="20" height="20"></a>&nbsp;&nbsp</td>
                   <td>
                   <a title="Thích" onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'<%#Eval("BAI_VIET_ID","div{0}")%>')>
                    <asp:Image ID="Image2" runat="server"  ImageUrl="images/like.gif" Width=20 Height=15/>
                    </td>
                    <td>
                    <font color="#0033ff">
                     <div id='<%#Eval("BAI_VIET_ID","div{0}")%>'>&nbsp(<%#Eval("liked")%>)&nbsp</div>
                     </font>
                     </a>
                     </td>
                     </tr>
                     </table>
                     </b>
                     <td>
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



    <tr class="post_news_desc">
        <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr>
            <td valign=middle>
            <b>
            <table border=0 cellpadding=2 cellspacing=0>
            <tr bgcolor="#0033ff" style="cursor:pointer;">
            <td>
            <a title="Thích" onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'liked1')>
            <asp:Image ID="Image3" runat="server"  ImageUrl="images/like.gif" Width=25 Height=15/>
            </td>
            <td>
            <font color="#FFFFFF">
             <div id="liked3"><%#Eval("liked")%>&nbsp</div>
             </font>
             </a>
             </td>
             </tr>
             </table>
             </b>
            </td>
            <td align=right>
                </td></tr></table></td>
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
<fieldset>
    <table>
    <tr>
    <td>
 

    
        <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" 
                CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" 
                CssPostfix="Office2010Blue" Height="200px" Width="920px">
                <ClientSideEvents HtmlChanged="HtmlChangedHandler" />
            <Styles CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" 
                CssPostfix="Office2010Blue">
                <ViewArea>
                    <Border BorderColor="#859EBF" />
                </ViewArea>
            </Styles>
            <StylesEditors ButtonEditCellSpacing="0">
            </StylesEditors>
            <StylesStatusBar>
                <StatusBar TabSpacing="0px">
                    <Paddings Padding="0px" />
                </StatusBar>
            </StylesStatusBar>
    <SettingsImageSelector Enabled="True">
            <CommonSettings RootFolder="~/images/upload/" ThumbnailFolder="~/images/upload/"
                InitialFolder="upload" />
            <PermissionSettings>

            </PermissionSettings>
        </SettingsImageSelector>
        <SettingsImageUpload UploadImageFolder="~/images/upload/">
            <ValidationSettings AllowedFileExtensions=".jpe,.jpeg,.jpg,.gif,.png" MaxFileSize="500000">
            </ValidationSettings>
        </SettingsImageUpload>
                <SettingsValidation>
                    <RequiredField IsRequired="True" ErrorText="Nội dung phản hồi trống" />
                </SettingsValidation>
<SettingsDocumentSelector>
<CommonSettings AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp"></CommonSettings>
</SettingsDocumentSelector>
            <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                <LoadingPanel Url="~/App_Themes/Office2010Blue/HtmlEditor/Loading.gif">
                </LoadingPanel>
            </Images>
            <ImagesFileManager>
                <FolderContainerNodeLoadingPanel Url="~/App_Themes/Office2010Blue/Web/tvNodeLoading.gif">
                </FolderContainerNodeLoadingPanel>
                <LoadingPanel Url="~/App_Themes/Office2010Blue/Web/Loading.gif">
                </LoadingPanel>
            </ImagesFileManager>
        </dx:ASPxHtmlEditor>
        <font color="white">Số ký tự bạn đã nhập(ký tự): <dx:ASPxLabel ID="lblContentLength" runat="server" ClientInstanceName="ContentLength" Text="0" Font-Bold="True"></dx:ASPxLabel></font>
</fieldset>
        <table cellpadding=3 cellpadding=3 border=0 width=20%>
        <tr>
        <td>
                <dx:ASPxButton ID="btn_comments" runat="server" Text="Bình luận" 
            CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" CssPostfix="SoftOrange" 
            SpriteCssFilePath="~/App_Themes/SoftOrange/{0}/sprite.css" Width="110px" 
            onclick="btn_comments_Click">
            <ClientSideEvents Click="function(s, e) {
                                    validate();
                    }" />
        </dx:ASPxButton>
        </td>
        <td>
        <dx:ASPxButton ID="btn_back" runat="server" Text="Trở lại" 
            CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" CssPostfix="SoftOrange" 
            onclick="btn_back_Click" SpriteCssFilePath="~/App_Themes/SoftOrange/{0}/sprite.css" 
            Width="110px">
           <ClientSideEvents Click="function(s, e) {
                            window.location.href='show_allbum.aspx'
           }" />
        </dx:ASPxButton>
        </td>
        </tr>
        </table>
    </td>

    </tr>
    </table>


    </fieldset></asp:Content>
