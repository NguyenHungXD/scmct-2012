<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="create_new_subject.aspx.cs" Inherits="chiase.create_new_subject" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>.:SCMCT-Cổng thông tin SCMCT:.</title>
<meta name="keywords" content="SCMCT, Sách cho miền cát trắng, sach cho mien cat trang, quyen gop sach, sach cu, sach cho tre em ngheo" />
<meta name="description" content=".::SCMCT - Công quyên góp sách online ::." />
<link href="Styles/templatemain_style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    // <![CDATA[
        var MaxLength = 20;
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
    // ]]> 
    </script>


    <style type="text/css">
        .style1
        {
            width: 91px;
        }
    </style>


</head>
<body>
<form id="form1" runat="server">
   <fieldset>
<!--<legend><b>Tạo chủ đề mới</font></b></legend> -->
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td colspan="3" align="right">

        <asp:Label ID="lbl_create_new_subject" runat="server">
                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Lưu chủ đề" 
                onclick="btn_create_new_subject_Click"
                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="120" Height="25">
                </dx:ASPxButton>
        </asp:Label>
    </td>
    </tr>
    <tr>
    <td align=center colspan=2><br>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ></asp:Label></font><br>
        <hr>
        </td>
    </tr>

          <tr>
    <td colspan="2">
        Tiêu đề:

        <asp:TextBox ID="txt_title" runat="server"  class="txtformat" Width="642px" 
            Height="23px"></asp:TextBox>
        <asp:RequiredFieldValidator ForeColor="Red" Display="Dynamic" ControlToValidate="txt_title" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tiêu đề"></asp:RequiredFieldValidator>
            </td>
    </tr>
      <tr>
    <td colspan="2">

<dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" Width="700px" 
                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                Height="308px">
                <ClientSideEvents HtmlChanged="HtmlChangedHandler" />
                <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                    <ViewArea>
                        <Border BorderColor="#A3C0E8" />
                    </ViewArea>
                </Styles>
<SettingsImageUpload>
<ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png"></ValidationSettings>
</SettingsImageUpload>

<SettingsImageSelector>
<CommonSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png"></CommonSettings>
</SettingsImageSelector>
                <SettingsValidation>
                    <RequiredField IsRequired="True" ErrorText="Chưa nhập chi tiết chủ đề" />
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
    <td class="style1">
       Sắp xếp:
    </td>
    <td>
        <asp:TextBox ID="txt_sort" runat="server"  class="txtformat" Width="74px" 
            Height="22px"></asp:TextBox>
            </td>
    </tr>

   
      <tr>
    <td class="style1">
       Trạng thái:
    </td>
    <td>
        <asp:DropDownList ID="dropd_status" runat="server">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td colspan=3 align=left><hr>
</tr>
<tr>
    <td colspan=3 align=right>
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
     </table>
    </fieldset>
    </form>
</body>
</html>