<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="slideshow.aspx.cs" Inherits="chiase.slideshow" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

    <asp:HiddenField ID="vusername" runat="server" />
    <asp:HiddenField ID="imgpath" runat="server" />

<script type="text/javascript">
    document.write('<style>.noscript { display: none; }</style>');

                                                                var id_next = 0;
                                                                function forcusit(divid) {
                                                                    document.getElementById(divid).focus();
                                                                }
                                                                function getTime() {
                                                                    return '<%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>';
                                                                }
                                                                function update_cm(id,divid,dividmain) {
                                                                    var cm = document.getElementById(divid).value;
                                                                    var username = document.all["<%=vusername.ClientID%>"].value;
                                                                    var images = document.all["<%=imgpath.ClientID%>"].value;
                                                                    if (cm != "" && username != "") {
                                                                        var url = "update_img_comment.aspx?imgid=" + id + "&content_cm=" + cm;
                                                                        loadXMLUpdate(url);
                                                                        // Append content to div
                                                                        var divappend = document.getElementById(dividmain);
                                                                        var divIdName = 'divNEW' + id_next;
                                                                        var newdiv = document.createElement("div");
                                                                        newdiv.setAttribute("id", divIdName);

                                                                        var content = "<div id=" + divIdName + ">" +
                                                                                        "<table cellpadding=0 cellspacing=1 border=0 width=100%>" +
                                                                                        "<tr style=background-color:#FBFBFC;font-style:italic;>" +
                                                                                        "<td rowspan=2 width=5%><img src=images\\avatars\\" + images + " width=40 height=40></td>" +
                                                                                        "<td align=left>" + username + '(' + getTime() + ')' +
                                                                                        "</td>" +
                                                                                        "</tr>" +
                                                                                        "<tr>" +
                                                                                        "<td colspan=2 style=color:#330066>&nbsp;&nbsp" + cm +
                                                                                        "</td>" +
                                                                                        "</tr>" +
                                                                                        "</table>" +
                                                                                        "</div>";

                                                                        newdiv.innerHTML = content;
                                                                        divappend.appendChild(newdiv);
                                                                        id_next = id_next + 1;

                                                                        document.getElementById(divid).value = "";
                                                                        document.getElementById(divid).focus();

                                                                    } else {

                                                                        document.getElementById(divid).focus();
                                                                        if(username=="")
                                                                            alert("Đăng nhập để bình luận ảnh!");
                                                                    }
                                                                }
                                                                function showhide(divshow, divcontent) {

                                                                    var divid = document.getElementById(divshow);
                                                                    var divid_content = document.getElementById(divcontent);
                                                                    if (divid.style.display == "none") {
                                                                        divid.style.display = "block";
                                                                        divid_content.innerHTML = "<a><b>-</b> Ẩn bình luận</a>";
                                                                    } else {
                                                                        divid.style.display = "none";
                                                                        divid_content.innerHTML = "<a><b>+</b> Xem bình luận</a>";
                                                                    }

                                                                }
                                                                function update_img_liked(allbumid,val) {
                                                                    var divid = document.getElementById("allbumidimg");
                                                                    var liked = val + 1;
                                                                    divid.innerHTML = '(' + liked + ')';
                                                                    var url = "update_like_post.aspx?allbum_id=" + allbumid +"&mode=3";
                                                                    loadXMLUpdate(url);
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
<fieldset>
<div id="page">

			<div id="container">
				<!-- Start Advanced Gallery Html Containers -->
                
				<div id="gallery" class="content">
					<div id="controls" class="controls"></div>
					<div class="slideshow-container">
						<div id="loading" class="loader"></div>
						<div id="slideshow" class="slideshow"></div>
					</div>
					
				</div>
				<div id="thumbs" class="navigation">
					<ul class="thumbs noscript">
                        <asp:Repeater ID="showImageList" runat="server" 
                            onitemdatabound="showImageList_ItemDataBound">
                        <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
						                        <li>
							                        <a class="thumb" name=<%#Eval("allbum_name")%> href=<%#Eval("path") %> title=<%#Eval("title") %>>
								                        <img src='<%#Eval("path") %>' alt='<%#Eval("title") %>' width="75" height="75"/>
							                        </a>
							                        <div class="caption">
                                                       
								                        <div class="download">
									                        <a href='<%#Eval("path") %>' target=_blank>Xem ảnh góc</a>
								                        </div>
								                        <div class="image-title"><%#Eval("title") %></div>
                                                        <div class="image-desc"><%#Eval("description") %></div>
                                
                                                        <div style="background-color: #FFFFCC;color:Green;border: 1px solid #FFFFFF;cursor:pointer;"><table cellpadding=0 cellspacing=0 border=0 width=100%><tr><td width=25% align="right"><a onclick=forcusit('<%#Eval("img_id","txt_comment{0}")%>')>Bình luận</a> | <a onclick=update_img_liked('<%#Eval("allbum_id") %>',<%#Eval("liked") %>)>Thích</a></td><td width='20%' id='allbumidimg'>(<%#Eval("liked") %>)</td><td align=right id='<%#Eval("img_id","showhide{0}")%>' onclick=showhide('<%#Eval("img_id","divid{0}")%>','<%#Eval("img_id","showhide{0}")%>')><a>+ Xem bình luận</a></td><td>&nbsp(<asp:Label ID="cnt_cm" runat="server" Text=""></asp:Label>&nbsp bình luận)</td></tr></table></div>
                                                        <div id='<%#Eval("img_id","divid{0}")%>' style="background-color: #F2F2F2;color:#009933;display:none;"> 
                                                            
                                                        <asp:Repeater ID="showcomment" runat="server">
                                                        <HeaderTemplate>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div id='<%#Eval("ID","divchil{0}") %>'>
                                                                <table cellpadding="0" cellspacing="1" border="0" width="100%">
                                                                <tr style="background-color:#FBFBFC;font-style:italic;" >
                                                                <td rowspan="2" width="5%">
                                                                    <img src='<%#Eval("avatar_path","images\\avatars\\{0}") %>' width="40" Height="40"/>
                                                                </td>
                                                                <td align="left">
                                                                    <%#Eval("username") %>(<%#Eval("commented_date", "{0:dd/MM/yyyy hh:mm:ss tt}")%>)
                                                                </td>
                                                                </tr>
                                                                <tr>
                                                                <td colspan="2" style="color:#330066">&nbsp;&nbsp
                                                                <%#Eval("comment") %>
                                                                </td>
                                                                </tr>
                                                                </table>
                                                            </div>
                                                   </ItemTemplate>
                                                    <FooterTemplate>   
                                                    </FooterTemplate>       
                                                    </asp:Repeater>  
                                                    </div> 
                                                    <div style="border:1px solid #E3E0EA;background-color: #FFFFCC;">
                                                    <textarea id='<%#Eval("img_id","txt_comment{0}")%>' cols="60" rows="3" name="myname" class="txtformat_area"></textarea>
                                                    <input id='btn_comment' type='button' value='Bình luận' class='btn' onclick=update_cm('<%#Eval("img_id")%>','<%#Eval("img_id","txt_comment{0}")%>','<%#Eval("img_id","divid{0}")%>') />
                                                    </div>
                                                    
						                        </li>
                                           
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                                </asp:Repeater>   
                                
                                <div id="caption" class="caption-container"></div>
					</ul>
				</div>
				<!-- End Advanced Gallery Html Containers -->
				<div style="clear: both;"></div>
			</div>
            





		</div>
        <br><br>&nbsp

    <asp:Repeater ID="showList_comment" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding=1 cellspacing=3 width="100%"  style="border:0px solid #CCFFFF;">
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
                           
                           
                            <a style="cursor:pointer;" ID='<%#Eval("id", "username{0}") %>'><font color="blue"><%#Eval("username") %></font></a>
                            

                   <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl='<%#Eval("username", "user_info.aspx?user_name={0}") %>'
                            EnableViewState="False" PopupElementID='<%#Eval("ID", "username{0}") %>'
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
                            Height="730px" FooterText=""
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
                        <%#Eval("comment")%>
                    </td>
                    </tr>
                    </table>

                    <table cellpadding=0 cellspacing=2 border=0 width=100%>
                    <tr align=right>
                    <td align=right>
                    <font size=-3><i>
                        Ngày, <%#Eval("commented_date", "{0:dd/MM/yyyy hh:mm:ss tt}")%>
                    </font></i>
                    </td>
                   <td colspan=2>                    
                   <b>
                   <table cellpadding=0 cellspacing=0 border=0>
                   <tr bgcolor="#0033ff" style="cursor:pointer;">
                   <td>
                   
                    
                    </td>
                    <td>
                    <font color="#FFFFFFF">
                     
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
      <table cellpadding=3 cellpadding=3 border=0 width=20%>
        <tr>
        <td>
        <dx:ASPxButton ID="btn_comments" runat="server" Text="Bình luận" 
            CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" CssPostfix="SoftOrange" 
            SpriteCssFilePath="~/App_Themes/SoftOrange/{0}/sprite.css" Width="110px" 
                onclick="btn_comments_Click">
        </dx:ASPxButton>
        </td>
        <td>
        <dx:ASPxButton ID="btn_back" runat="server" Text="Trở lại" 
            CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" CssPostfix="SoftOrange" 
            SpriteCssFilePath="~/App_Themes/SoftOrange/{0}/sprite.css" 
            Width="110px">
        </dx:ASPxButton>
        </td>
        </tr>
        </table>
      
       
        
		<div id="footer" style="color:#FFFFFF;">&copy; SCMCT Online</div>
</fieldset>
		<script type="text/javascript">
		    jQuery(document).ready(function ($) {
		        // We only want these styles applied when javascript is enabled
		        $('div.navigation').css({ 'width': '300px', 'float': 'left' });
		        $('div.content').css('display', 'block');

		        // Initially set opacity on thumbs and add
		        // additional styling for hover effect on thumbs
		        var onMouseOutOpacity = 0.67;
		        $('#thumbs ul.thumbs li').opacityrollover({
		            mouseOutOpacity: onMouseOutOpacity,
		            mouseOverOpacity: 1.0,
		            fadeSpeed: 'fast',
		            exemptionSelector: '.selected'
		        });

		        // Initialize Advanced Galleriffic Gallery
		        var gallery = $('#thumbs').galleriffic({
		            delay: 2500,
		            numThumbs: 15,
		            preloadAhead: 10,
		            enableTopPager: true,
		            enableBottomPager: true,
		            maxPagesToShow: 7,
		            imageContainerSel: '#slideshow',
		            controlsContainerSel: '#controls',
		            captionContainerSel: '#caption',
		            loadingContainerSel: '#loading',
		            renderSSControls: true,
		            renderNavControls: true,
		            playLinkText: 'Xem tự động',
		            pauseLinkText: 'Dừng',
		            prevLinkText: '&lsaquo; Hình sau',
		            nextLinkText: 'Hình trước &rsaquo;',
		            nextPageLinkText: 'Tới &rsaquo;',
		            prevPageLinkText: '&lsaquo; Lùi',
		            enableHistory: true,
		            autoStart: false,
		            syncTransitions: true,
		            defaultTransitionDuration: 900,
		            onSlideChange: function (prevIndex, nextIndex) {
		                // 'this' refers to the gallery, which is an extension of $('#thumbs')
		                this.find('ul.thumbs').children()
							.eq(prevIndex).fadeTo('fast', onMouseOutOpacity).end()
							.eq(nextIndex).fadeTo('fast', 1.0);
		            },
		            onPageTransitionOut: function (callback) {
		                this.fadeTo('fast', 0.0, callback);
		            },
		            onPageTransitionIn: function () {
		                this.fadeTo('fast', 1.0);
		            }
		        });

		        /**** Functions to support integration of galleriffic with the jquery.history plugin ****/

		        // PageLoad function
		        // This function is called when:
		        // 1. after calling $.historyInit();
		        // 2. after calling $.historyLoad();
		        // 3. after pushing "Go Back" button of a browser
		        function pageload(hash) {
		            // alert("pageload: " + hash);
		            // hash doesn't contain the first # character.
		            if (hash) {
		                $.galleriffic.gotoImage(hash);
		            } else {
		                gallery.gotoIndex(0);
		            }
		        }

		        // Initialize history plugin.
		        // The callback is called at once by present location.hash. 
		        $.historyInit(pageload, "advanced.html");

		        // set onlick event for buttons using the jQuery 1.3 live method
		        $("a[rel='history']").live('click', function (e) {
		            if (e.button != 0) return true;

		            var hash = this.href;
		            hash = hash.replace(/^.*#/, '');

		            // moves to a new page. 
		            // pageload is called at once. 
		            // hash don't contain "#", "?"
		            $.historyLoad(hash);

		            return false;
		        });
		        /****************************************************************************************/
		    });
		</script>
</asp:Content>
