<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="post_news.aspx.cs" Inherits="chiase.post_news"%>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

   <fieldset>
<legend><font size=2 color=white><b>Đăng bài mới</font></b></legend>
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2><br>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ForeColor="#0000CC"></asp:Label></font><br>
        <hr>
        </td>
    </tr>
          <tr>
    <td>
        Tiêu đề:
    </td>
    <td>
        <asp:TextBox ID="txt_title" runat="server"  class="txtformat" Width="614px" 
            Height="23px"></asp:TextBox>
            </td>
    </tr>
     <tr>
     <td colspan=2 align=right>




     


         <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" 
             CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Height="533px" 
             Width="900px" CustomCommand="OnCommandExecute">
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
    <br>
     </td>
     </tr>
      <tr>
    <td>
       Sắp xếp:
    </td>
    <td>
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
    <td colspan=3 align=left><hr>
    <br>
</tr>
<tr>
    <td colspan=3>
        <asp:Button ID="btn_create_news" runat="server" Text="Bài mới" Width="100px" 
            class="btnformat" onclick="btn_create_news_Click1" />
        <asp:Button ID="btn_close" runat="server" Text="Đóng" Width="100px" class="btnformat"/>
    </td>
    </tr>
<tr>
    <td colspan=3 align=right>
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
     </table>
    </fieldset>
    <br>&nbsp





  
</asp:Content>
