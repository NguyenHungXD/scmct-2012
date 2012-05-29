<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_request.aspx.cs" Inherits="chiase.edit_request" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>.:SCMCT-Cổng thông tin SCMCT:.</title>
<meta name="keywords" content="SCMCT, Sách cho miền cát trắng, sach cho mien cat trang, quyen gop sach, sach cu, sach cho tre em ngheo" />
<meta name="description" content=".::SCMCT - Công quyên góp sách online ::." />
<link href="Styles/templatemain_style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="Scripts/ajax_script.js" ></script>
</head>
<body>
<form id="form1" runat="server">
    <script type="text/javascript">
    // <![CDATA[
        var MaxLength = 50;
        var CustomErrorText = "Nội dung yêu cầu phải lớn hơn " + MaxLength.toString() + " ký tự.";

        function ValidationHandler(s, e) {
            if (e.html.length < MaxLength) {
                e.isValid = false;
                e.errorText = CustomErrorText;
            }
        }

        function HtmlChangedHandler(s, e) {
            ContentLength.SetText(s.GetHtml().length);
        }
        function return_link(obj) {
            var contentUrl = "user_info.aspx?id=" + obj.value;
            var windowIndex = 1;
            var window = divpopup.GetWindow(windowIndex);
            divpopup.SetWindowContentUrl(window, contentUrl);
        }
    // ]]> 
    </script>

    <fieldset>  
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2>
        <font size=3><b><asp:Label ID="lbl_result" runat="server" ForeColor="#FFFFFF"></asp:Label></b></font>
        <hr>
        </td>
    <td rowspan=9><br>
    </td>
    </tr>
    <tr>
    <td>
    Tiêu đề:
    </td>
    <td align="left">
        <asp:TextBox ID="txt_request_subject" runat="server"  class="txtformat"  Width="449px" 
            Height="23px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_request_subject" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Nhập tiêu đề"></asp:RequiredFieldValidator>
    
    </td>
    </tr>
     <tr>
    <td colspan=2>



        <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            Width="730px" Height="300px">
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
                      <SettingsValidation>
                    <RequiredField IsRequired="True" ErrorText="Yêu cầu chưa có nội dung" />
                </SettingsValidation>
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
       
       <font color="white">Số ký tự bạn đã nhập(ký tự): <dx:ASPxLabel ID="lblContentLength" runat="server" ClientInstanceName="ContentLength" Text="0" Font-Bold="True"></dx:ASPxLabel></font>
            </td>
    </tr>
    <tr>
    <td colspan="2">
    Yêu cầu:

        <asp:DropDownList ID="dropd_request_kind" runat="server">
        </asp:DropDownList>

    </td>
    </tr>
    <tr>
    <td align="right" colspan="2"><br>
        <dx:ASPxButton ID="btn_requests" runat="server" Text="Lưu thông tin" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
            CssPostfix="Aqua" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
            Width="120px" onclick="btn_requests_Click">
        </dx:ASPxButton>
    </td>
    </tr>
    <tr>
    <td colspan=3 align=right style="color:White">
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>
    </fieldset>
    <br>&nbsp
         </form>
</body>
</html>