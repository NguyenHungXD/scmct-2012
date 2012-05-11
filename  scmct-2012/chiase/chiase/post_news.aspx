<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="post_news.aspx.cs" Inherits="chiase.post_news"%>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <script type="text/javascript">
    // <![CDATA[
        var MaxLength = 100;
        var CustomErrorText = "Nội dung bài viết phải lớn hơn " + MaxLength.toString() + " ký tự.";
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
<legend>Đăng bài mới</legend>
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2><br>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ForeColor="#0000CC"></asp:Label></font><br>
        <hr>
        </td>
    </tr>
          <tr>
    <td colspan=2><font color=white><b>
        Tiêu đề: </font></b>

        <asp:TextBox ID="txt_title" runat="server"  class="txtformat" Width="614px" 
            Height="23px"></asp:TextBox>
            <asp:RequiredFieldValidator ForeColor="Red" Display="Dynamic" ControlToValidate="txt_title" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tiêu đề"></asp:RequiredFieldValidator>
            </td>
    </tr>
     <tr>
     <td colspan=2 align=right>
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
                    <RequiredField IsRequired="True" ErrorText="Bài viết chưa có nội dung" />
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
    <br>
     </td>
     </tr>
      <tr>
    <td colspan=2>
     <font color=white><b>  Sắp xếp:</b></font>

        <asp:TextBox ID="txt_sort" runat="server"  class="txtformat" Width="74px" 
            Height="22px"></asp:TextBox>
            </td>
    </tr>
    <tr>
    <td colspan=3 align=left><hr>
    <br>
    </td>
</tr>
<tr>
        <td align=right>
        <dx:ASPxButton ID="btn_post_news" runat="server" Text="Đăng bài" 
                onclick="btn_post_news_Click" 
                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="120px">
        </dx:ASPxButton>
        </td>
        <td align=left style="width: 470px">
        <dx:ASPxButton ID="btn_back" runat="server" Text="Hủy" onclick="btn_back_Click" 
                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="120px">

                                                                         <ClientSideEvents Click="function(s, e) {
                            window.location.href='forum.aspx'
                    }" />

        </dx:ASPxButton>


    </td>
    </tr>
<tr>
    <td colspan=3 align=right>
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
     </table>
    </fieldset>
    <br>&nbsp





  
</asp:Content>
