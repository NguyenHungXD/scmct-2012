<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="join_project.aspx.cs" Inherits="chiase.join_project" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
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
</head>
<body>
<form id="form1" runat="server">
<fieldset>   
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align="center" colspan=2>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ></asp:Label></b></font>
        </td>
        <td valign="middle" align="right">
                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Gửi yêu cầu"
                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="120" Height="25" 
                    onclick="ASPxButton1_Click">
                </dx:ASPxButton>
        </td>
    </tr>
    <tr>
    <td colspan=3>
        <hr>
    </td>
    </tr>
        <tr>
    <td>
        Mã dự án:
    </td>
    <td style="font-weight:bold">
        <asp:Label ID="lbl_ma_du_an" runat="server"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        Tên dự án:
    </td>
    <td style="font-weight:bold">
        <asp:Label ID="lbl_ten_du_an" runat="server"></asp:Label>
    </td>
    </tr>
        <tr>
    <td>
        Ngày bắt đầu:
    </td>
    <td style="font-weight:bold">
        <asp:Label ID="lbl_ngay_bat_dau" runat="server"></asp:Label>
    </td>
    </tr>
     <tr>
    <td>
        Ngày kết thúc:
    </td>
    <td style="font-weight:bold">
        <asp:Label ID="lbl_ngay_ket_thuc" runat="server"></asp:Label>
            </td>
    </tr>
        <tr>
    <td>
        Tên thành viên:
    </td>
        <td style="font-weight:bold">
        <asp:Label ID="lbl_name" runat="server"></asp:Label>
    </td>
    </tr>
        <tr>
    <td >
        Ngày gia nhập:
    </td>
        <td style="font-weight:bold">
       
            <asp:Label ID="lbl_joined_date" runat="server"></asp:Label>
    </td>
    </tr>
                <tr>
    <td >
        Địa chỉ:
    </td>
        <td style="font-weight:bold">
       
            <asp:Label ID="lbl_Address" runat="server"></asp:Label>
    </td>
    </tr>
            <tr>
    <td >
        Nhóm thành viên:
    </td>
        <td style="font-weight:bold">
       
            <asp:Label ID="lbl_group_name" runat="server"></asp:Label>
    </td>
    </tr>
    </table>
    <table border=0 cellpadding =1 cellspacing=2 width =100%>

    <tr>
    <td>
    Tự giới thiệu:
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
                    <RequiredField IsRequired="True" ErrorText="Chưa nhập nội dung chi tiết thư tự giới thiệu" />
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
    </table>
    <table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td colspan=3 align=left><hr>
     <p align="right" style="color:White">&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %><br>&nbsp</p>
</tr>
     </table>
    </fieldset>
    </form>
</body>
</html>
