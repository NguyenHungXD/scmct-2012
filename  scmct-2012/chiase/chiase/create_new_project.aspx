﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="create_new_project.aspx.cs" Inherits="chiase.create_new_project" %>

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
    // ]]> 
    </script>

</head>
<body>
<form id="form1" runat="server">

<fieldset>   
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align="center" colspan=2>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ForeColor="#0000CC"></asp:Label></b></font>
        </td>
        <td valign="middle" align="right">
                            <dx:ASPxButton ID="btn_create_projects" runat="server" Text="Lưu dự án" 
                        CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                        SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="120px" 
                        onclick="btn_create_projects_Click">
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
    <td>
        <asp:TextBox ID="txt_project_code" runat="server"  class="txtformat" 
            Width="150px" Height="22px" BackColor="#CCFFCC">
            </asp:TextBox> <i><font color="#0000CC">(Bạn nên thay đổi mã dự án phù hợp)</font></i>
    </td>
    </tr>
    <tr>
    <td>
        Tên dự án:
    </td>
    <td>
        <asp:TextBox ID="txt_project_name" runat="server"  class="txtformat" 
            Width="300px" Height="22px" BackColor="#CCFFCC"></asp:TextBox>
    </td>
    </tr>
    </table>
    <table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td>
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
                    <RequiredField IsRequired="True" ErrorText="Chưa nhập chi tiết dự án" />
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
    <td>
        Ngày bắt đầu:
    </td>
    <td>
        <asp:DropDownList ID="dropd_day_start" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_month_start" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_year_start" runat="server">
        </asp:DropDownList>(dd/MM/yyyy)
    </td>
    </tr>
  
     <tr>
    <td>
        Ngày kết thúc:
    </td>
    <td>
        <asp:DropDownList ID="dropd_day_end" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_month_end" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_year_end" runat="server">
        </asp:DropDownList>(dd/MM/yyyy)
            </td>
    </tr>
    <tr>
       <td>
           Ghi chú:

    </td>
    <td>
    <asp:TextBox ID="txt_notes" runat="server" class="txtformat_area"
    Width="585px" Height="49px" BackColor="#CCFFCC" Rows="4" TextMode="MultiLine"></asp:TextBox>
    </td>
    </tr>
    <tr>
       <td>
           Trạng thái:
    </td>
    <td>
        <asp:DropDownList ID="dropd_status" runat="server">
        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp<asp:LinkButton ID="btn_add_project_status" runat="server" 
            Text="[Thêm trạng thái]" onclick="btn_add_project_status_Click"></asp:LinkButton>
            
            
            <asp:Panel
                ID="panel_add_new_status" runat="server" BackColor="#0099FF" 
            Direction="LeftToRight" Height="50px" HorizontalAlign="Left" 
            style="margin-left: 102px" Width="500">

 


                <table border=0 cellpadding=3 cellspacing=3 width=20%>
                <tr>
                <td>
                               <asp:TextBox ID="txt_status_project" runat="server" class="txtformat"
    Width="300px" Height="22px" BackColor="#CCFFCC"></asp:TextBox>
                </td>
                <td align=right>
                    <dx:ASPxButton ID="btn_add_stutus_names" runat="server" Text="Tạo mới" 
                        CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" CssPostfix="SoftOrange" 
                        SpriteCssFilePath="~/App_Themes/SoftOrange/{0}/sprite.css" Width="80px" 
                        onclick="btn_add_stutus_names_Click">
                    </dx:ASPxButton>
                </td>
                <td align=left>
                    <dx:ASPxButton ID="btn_close" runat="server" Text="Đóng" 
                        CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" CssPostfix="SoftOrange" 
                        onclick="btn_close_Click2" SpriteCssFilePath="~/App_Themes/SoftOrange/{0}/sprite.css" 
                        Width="80px">
                    </dx:ASPxButton>
                </td>
                </tr>
                </table>

     </asp:Panel> 
        </td>
    </tr>
    <tr>
    <td>
    Sách cho dự án:
    </td>
    <td>
        <asp:TextBox ID="txt_book" runat="server"  class="txtformat" 
            Width="150px" Height="22px" BackColor="#CCFFCC"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan=3 align=left><hr>
</tr>
     </table>
    </fieldset>
    </form>
</body>
</html>