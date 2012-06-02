<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="edit_project.aspx.cs" Inherits="chiase.edit_project" %>



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
    <td align=center colspan=2>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ForeColor="White"></asp:Label></b></font>
        </td>
        <td valign="middle" align="right">
                            <dx:ASPxButton ID="btn_create_projects" runat="server" Text="Lưu thông tin"
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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ForeColor="Red" ControlToValidate="txt_project_code" runat="server" ErrorMessage="Nhập mã dự án"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td>
        Tên dự án:
    </td>
    <td>
        <asp:TextBox ID="txt_project_name" runat="server"  class="txtformat" 
            Width="300px" Height="22px" BackColor="#CCFFCC"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ForeColor="Red" ControlToValidate="txt_project_name" runat="server" ErrorMessage="Nhập tên dự án"></asp:RequiredFieldValidator>
    </td>
    </tr>
    </table>
    <table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td>
            <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" Width="720px" 
                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                Height="285px">
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
    Width="610px" Height="49px" BackColor="#CCFFCC" Rows="4" TextMode="MultiLine"></asp:TextBox>
    </td>
    </tr>
    <tr>
       <td>
           Trạng thái:
    </td>
    <td>
        <asp:DropDownList ID="dropd_status" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="dropd_status" Display="Dynamic" InitialValue="None" ForeColor="REd" runat="server" ErrorMessage="Chọn trạng thái"></asp:RequiredFieldValidator>
        
        
       
            
            

        </td>
    </tr>
    <tr>
    <td valign="middle">
    Sách cho dự án:
    </td>
    <td>
        <asp:TextBox ID="txt_book" runat="server"  class="txtformat" 
            Width="150px" Height="22px" BackColor="#CCFFCC"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
            ControlToValidate="txt_book" Display="Dynamic" runat="server" 
            ErrorMessage="Nhập số sách cần cho dự án" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_book" ValidationExpression="^\d+$" runat="server" ErrorMessage=" Số lượng sách phải là số"></asp:RegularExpressionValidator>
    </td>
    </tr>
        <tr>
    <td colspan=3>
        <hr>
    </td>
    </tr>
     </table>
    </fieldset>
</form>
</body>
</html>
