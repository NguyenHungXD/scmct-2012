<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="chiase.info" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
    
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <script type="text/javascript">

        function HtmlChangedHandler(s, e) {
            ContentLength.SetText(s.GetHtml().length);
        }

        function backs() {
            window.location = "admin.aspx";
        }

    </script>


<fieldset>
    <table cellpadding=0 cellspacing=0 border=0 width="100%">
    <tr>
    <td>
    <br>
        
    
    <br>
        <asp:Button ID="Button2" runat="server" Text="Giới thiệu" Width="120" 
            Height="25" class="menu_btn" onclick="Button2_Click"/>
            <asp:Button ID="Button3" 
            runat="server" Text="Trợ giúp" Width="120" Height="25" class="menu_btn" 
            onclick="Button3_Click"/>
            <asp:Button ID="Button4" runat="server" 
            Text="Điều khoản sử dụng" Width="180" Height="25" class="menu_btn" 
            onclick="Button4_Click"/>
            <asp:Button ID="Button8" runat="server" 
            Text="Thông tin liên hệ" Width="180" Height="25" class="menu_btn" 
            onclick="Button8_Click" />
            <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
            <br><hr>
    </td>
    <td>
    </td>
    <td>
        
    </td>
    </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">

            
            <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" 
             CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Height="533px" 
             Width="906px" CustomCommand="OnCommandExecute">
             <ClientSideEvents HtmlChanged="HtmlChangedHandler" />
             <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                 <ViewArea>
                     <Border BorderColor="#A3C0E8" />
                 </ViewArea>
             </Styles>


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

              <SettingsValidation>
                    <RequiredField IsRequired="True" ErrorText="Chưa có nội dung" />
                </SettingsValidation>
             <Images SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                 <LoadingPanel Url="~/App_Themes/Aqua/HtmlEditor/Loading.gif">
                 </LoadingPanel>
             </Images>
             <ImagesFileManager>
                 <FolderContainerNodeLoadingPanel Url="~/App_Themes/Aqua/Web/tvNodeLoading.gif">
                 </FolderContainerNodeLoadingPanel>
                 <LoadingPanel Url="~/App_Themes/Aqua/Web/Loading.gif">
                 </LoadingPanel>
             </ImagesFileManager>

         </dx:ASPxHtmlEditor>

         <div style="margin: 8px 0;">
        <font color="white">Số ký tự bạn đã nhập(ký tự): <dx:ASPxLabel ID="lblContentLength" runat="server" ClientInstanceName="ContentLength" Text="0" Font-Bold="True"></dx:ASPxLabel></font>
    </div>

                <p align="left"><asp:Button ID="Button1" runat="server" Text="Cập nhật giới thiệu" 
                        Width="160" Height="25" class="btn" onclick="Button1_Click" /></p>


        </asp:View>
        <asp:View ID="View2" runat="server">

                    <dx:ASPxHtmlEditor ID="ASPxHtmlEditor2" runat="server" 
             CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Height="533px" 
             Width="906px" CustomCommand="OnCommandExecute">
             <ClientSideEvents HtmlChanged="HtmlChangedHandler" />
             <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                 <ViewArea>
                     <Border BorderColor="#A3C0E8" />
                 </ViewArea>
             </Styles>


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

              <SettingsValidation>
                    <RequiredField IsRequired="True" ErrorText="Chưa có nội dung" />
                </SettingsValidation>
             <Images SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                 <LoadingPanel Url="~/App_Themes/Aqua/HtmlEditor/Loading.gif">
                 </LoadingPanel>
             </Images>
             <ImagesFileManager>
                 <FolderContainerNodeLoadingPanel Url="~/App_Themes/Aqua/Web/tvNodeLoading.gif">
                 </FolderContainerNodeLoadingPanel>
                 <LoadingPanel Url="~/App_Themes/Aqua/Web/Loading.gif">
                 </LoadingPanel>
             </ImagesFileManager>

         </dx:ASPxHtmlEditor>

         <div style="margin: 8px 0;">
        <font color="white">Số ký tự bạn đã nhập(ký tự): <dx:ASPxLabel ID="ASPxLabel1" runat="server" ClientInstanceName="ContentLength" Text="0" Font-Bold="True"></dx:ASPxLabel></font>
    </div>

                <p align="left"><asp:Button ID="Button5" runat="server" Text="Cập nhật trợ giúp" 
                        Width="160" Height="25" class="btn" onclick="Button5_Click" /></p>



            
        </asp:View>
        <asp:View ID="View3" runat="server">


                    <dx:ASPxHtmlEditor ID="ASPxHtmlEditor3" runat="server" 
             CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Height="533px" 
             Width="906px" CustomCommand="OnCommandExecute">
             <ClientSideEvents HtmlChanged="HtmlChangedHandler" />
             <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                 <ViewArea>
                     <Border BorderColor="#A3C0E8" />
                 </ViewArea>
             </Styles>


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

              <SettingsValidation>
                    <RequiredField IsRequired="True" ErrorText="Chưa có nội dung" />
                </SettingsValidation>
             <Images SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                 <LoadingPanel Url="~/App_Themes/Aqua/HtmlEditor/Loading.gif">
                 </LoadingPanel>
             </Images>
             <ImagesFileManager>
                 <FolderContainerNodeLoadingPanel Url="~/App_Themes/Aqua/Web/tvNodeLoading.gif">
                 </FolderContainerNodeLoadingPanel>
                 <LoadingPanel Url="~/App_Themes/Aqua/Web/Loading.gif">
                 </LoadingPanel>
             </ImagesFileManager>

         </dx:ASPxHtmlEditor>

         <div style="margin: 8px 0;">
        <font color="white">Số ký tự bạn đã nhập(ký tự): <dx:ASPxLabel ID="ASPxLabel2" runat="server" ClientInstanceName="ContentLength" Text="0" Font-Bold="True"></dx:ASPxLabel></font>
    </div>
                <p align="left"><asp:Button ID="Button6" runat="server" Text="Cập nhật điều khoản" 
                        Width="160" Height="25" class="btn" onclick="Button6_Click" /></p>
        </asp:View>


 

            <asp:View ID="View4" runat="server">


                    <dx:ASPxHtmlEditor ID="ASPxHtmlEditor4" runat="server" 
             CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Height="533px" 
             Width="906px" CustomCommand="OnCommandExecute">
             <ClientSideEvents HtmlChanged="HtmlChangedHandler" />
             <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                 <ViewArea>
                     <Border BorderColor="#A3C0E8" />
                 </ViewArea>
             </Styles>


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

              <SettingsValidation>
                    <RequiredField IsRequired="True" ErrorText="Chưa có nội dung" />
                </SettingsValidation>
             <Images SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                 <LoadingPanel Url="~/App_Themes/Aqua/HtmlEditor/Loading.gif">
                 </LoadingPanel>
             </Images>
             <ImagesFileManager>
                 <FolderContainerNodeLoadingPanel Url="~/App_Themes/Aqua/Web/tvNodeLoading.gif">
                 </FolderContainerNodeLoadingPanel>
                 <LoadingPanel Url="~/App_Themes/Aqua/Web/Loading.gif">
                 </LoadingPanel>
             </ImagesFileManager>

         </dx:ASPxHtmlEditor>

         <div style="margin: 8px 0;">
        <font color="white">Số ký tự bạn đã nhập(ký tự): <dx:ASPxLabel ID="ASPxLabel3" runat="server" ClientInstanceName="ContentLength" Text="0" Font-Bold="True"></dx:ASPxLabel></font>
    </div>
                <p align="left">
                    <asp:Button ID="Button7" runat="server" Text="Cập nhật thông tin liên hệ" 
                        Width="238px" Height="25px" class="btn" onclick="Button7_Click" /></p>
        </asp:View>


    </asp:MultiView>
<p align="right"><br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %></p>

    </fieldset>
    </asp:Content>
