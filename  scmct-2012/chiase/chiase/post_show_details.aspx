<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="post_show_details.aspx.cs" Inherits="chiase.post_show_details" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<script type="text/javascript">
    
    function like_post(id,val,divid) {
        
        var url = "update_like_post.aspx?post_id=" + id;
        loadXMLUpdate(url);
        if (divid == 'liked1' || divid == 'liked2' || divid == 'liked3') {
            document.getElementById('liked1').innerHTML = val + 1;
            document.getElementById('liked2').innerHTML = val + 1;
            document.getElementById('liked3').innerHTML = val + 1;
        }
        else{
            document.getElementById(divid).innerHTML = val + 1;
        }
    }
</script>


<asp:Repeater ID="show_content" runat="server" 
        onitemdatabound="show_content_ItemDataBound" >
<HeaderTemplate>
<table border="0"  cellpadding=0 cellspacing=0  width="100%" >
</HeaderTemplate>
<ItemTemplate>
    <tr class="post_news">
    <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr><td><%#Eval("tieu_de")%></td><tr></table> </td></tr>

    <tr class="post_news_desc">
        <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr>
            <td valign=middle>
            <b>
            <table border=0 cellpadding=2 cellspacing=0>
            <tr>
            <td>
            <a style="cursor:hand;" title="Thích" onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'liked1')>
            <asp:Image ID="Image2" runat="server"  ImageUrl="images/like.gif" Width=25 Height=15/>
            </td>
            <td bgcolor=#FFFFFF>
            <font color=red>
             <div id="liked1"><%#Eval("liked")%></div>
             </font>
             </a>
             </td>
             </tr>
             </table>
             </b>
            </td>
            <td align=right>Đăng bởi,  
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#0099ff" NavigateUrl='<%# Eval("username", "user_info.aspx?user_name={0}") %>' Text='<%# Eval("username") %>'></asp:HyperLink> </asp:Label> <%#Eval("ngay_tao", "{0:dd/mm/yyyy hh:mm:ss tt}")%></td></tr></table></td>
    </tr>
    
    <tr>
    <td><table border=0 cellpadding=3 cellspacing=3 width=100% bgcolor=white><tr><td><%#Eval("noi_dung")%></td></tr></table></td>
    </tr>
    <tr class="post_news_desc">
        <td><table border=0 cellpadding=0 cellspacing=3 width=100%><tr>
            <td valign=middle>
            <b>
            <table border=0 cellpadding=2 cellspacing=0>
            <tr>
            <td>
            <a style="cursor:hand;" title="Thích" onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'liked2')>
            <asp:Image ID="Image4" runat="server"  ImageUrl="images/like.gif" Width=25 Height=15/>
            </td>
            <td bgcolor="#ffffff">
            <font color=red>
             <div id="liked2"><%#Eval("liked")%></div>
             </font>
             </a>
             </td>
             </tr>
             </table>
             </b>
            </td>
            <td align=right>Đăng bởi,  
                <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="#0099ff" NavigateUrl='<%# Eval("username", "user_info.aspx?user_name={0}") %>' Text='<%# Eval("username") %>'></asp:HyperLink> </asp:Label> <%#Eval("ngay_tao", "{0:dd/mm/yyyy hh:mm:ss tt}")%></td></tr></table></td>
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
                    <td width=20% bgcolor="#FFFFCC" VALIGN="top">
                        <table border=0 cellpadding=0 cellspacing=0>
                        <tr>
                        <td colspan=2>
                            <asp:Image ID="user_img" runat="server" ImageUrl='<%#Eval("avatar_path", "images/avatars/{0}")%>' Width="40" Height="40" /><br>
                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#0099ff" NavigateUrl='<%# Eval("username", "user_info.aspx?user_name={0}") %>' Text='<%# Eval("username") %>'>
                            </asp:HyperLink> <br>
                            
                            Tham gia: <%#Eval("created_date", "{0:dd/mm/yyyy}")%>

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
                    <td width=80% bgcolor="#FFFFCC" VALIGN="top">
                        <%#Eval("noi_dung")%>
                    </td>
                    </tr>
                    </table>

                    <table cellpadding=0 cellspacing=2 border=0 width=100%>
                    <tr align=right>
                    <td align=right>
                    <font size=-3><i>
                        Ngày, <%#Eval("ngay_tao", "{0:dd/mm/yyyy hh:mm:ss tt}")%>
                    </font></i>
                    </td>
                   <td colspan=2 bgcolor="#FFFFCC">                    
                   <b>
                   <table cellpadding=0 cellspacing=2 border=0>
                   <tr>
                   <td>
                   <a style="cursor:hand;" title="Thích" onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'<%#Eval("BAI_VIET_ID","div{0}")%>')>
                    <asp:Image ID="Image2" runat="server"  ImageUrl="images/like.gif" Width=20 Height=15/>
                    </td>
                    <td bgcolor=#FFFFFF>
                    <font color=red>
                     <div id='<%#Eval("BAI_VIET_ID","div{0}")%>'><%#Eval("liked")%></div>
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
            <table cellpadding=0 cellspacing=2 border=0 >  
            <tr>
            <td>
            <a style="cursor:hand;" title="Thích" onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'liked3')>
            <asp:Image ID="Image3" runat="server"  ImageUrl="images/like.gif" Width=25 Height=15/>
            </td>
            <td bgcolor=#FFFFFF>
            <font color=red>
             <div id="liked3"><%#Eval("liked")%></div>
             </font>
             </a>
             </td>
             </tr>
             </table>
             </b>
            </td>
            <td align=right>Đăng bởi,  
                <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="#0099ff" NavigateUrl='<%# Eval("username", "user_info.aspx?user_name={0}") %>' Text='<%# Eval("username") %>'></asp:HyperLink> </asp:Label> <%#Eval("ngay_tao", "{0:dd/mm/yyyy hh:mm:ss tt}")%></td></tr></table></td>
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
    <font color=white><b>Ý kiến của bạn :</b></font>
    <table>
    <tr>
    <td>
 

    
        <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" 
                CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" 
                CssPostfix="Office2010Blue" Height="200px" Width="930px">
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

        <table cellpadding=3 cellpadding=3 border=0 width=20%>
        <tr>
        <td>
                <dx:ASPxButton ID="btn_comments" runat="server" Text="Bình luận" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px" 
            onclick="btn_comments_Click">
        </dx:ASPxButton>
        </td>
        <td>
        <dx:ASPxButton ID="btn_back" runat="server" Text="Trở lại" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            onclick="btn_back_Click" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
            Width="150px">
        </dx:ASPxButton>
        </td>
        </tr>
        </table>
    </td>

    </tr>
    </table>


</asp:Content>
