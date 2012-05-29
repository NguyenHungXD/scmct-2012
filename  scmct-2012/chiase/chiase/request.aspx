<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="chiase.request" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

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
            if (obj.value != "None") {
                var contentUrl = "user_info.aspx?id=" + obj.value;
            } else
                var contentUrl = "";

                var windowIndex = 1;
                var window = divpopup.GetWindow(windowIndex);
                divpopup.SetWindowContentUrl(window, contentUrl);
            
                
        }
    // ]]> 
    </script>

    <fieldset>
<!--<legend>Gửi yêu cầu</legend> -->   
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
    <td colspan="2">
    Tiêu đề:

        <asp:TextBox ID="txt_request_subject" runat="server"  class="txtformat"  Width="840px" 
            Height="23px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_request_subject" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Nhập tiêu đề"></asp:RequiredFieldValidator>
    
    </td>
    </tr>
     <tr>
    <td colspan=2>



        <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            Width="900px" Height="300px">
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
    <td>
    Yêu cầu:
    </td>
    <td>

    
        <asp:DropDownList ID="dropd_request_kind" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" ControlToValidate="dropd_request_kind" ForeColor="Red" InitialValue="None" runat="server" ErrorMessage="Chọn loại yêu cầu"></asp:RequiredFieldValidator>

    </td>
    </tr>
    <tr>
    <td colspan=2>
        <b><font color=white size=3><br>Thông tin liên hệ:<br>&nbsp</font></b>
    </td>
    </tr>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
    <tr>
    <td style="height: 38px">
    Chọn thành viên:
    </td>
    <td style="height: 38px">
    <table><tr><td>
        <asp:DropDownList ID="member_list" runat="server" BackColor="#FFFFCC" 
            ForeColor="#000" Height="30px" 
            style="font-weight:lighter;font-size: 15px;" onchange="return_link(this);">
        </asp:DropDownList>
        
        </td>
        <td>
        <div id="divdetail"><a style="cursor:pointer">Xem chi tiết</a></div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" ForeColor="Red" ControlToValidate="member_list" InitialValue="None" runat="server" ErrorMessage="Chọn thành viên"></asp:RequiredFieldValidator>
        </td>
        </tr>
        </table>
        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server"
                    AllowDragging="True" AllowResize="True" ClientInstanceName="divpopup"
                            CloseAction="CloseButton" 
                            EnableViewState="False" PopupElementID='divdetail'
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
                            Height="600px" FooterText=""
                            HeaderText="" 
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


    </td>
    </tr>

    </asp:Panel>

    <asp:Panel ID="Panel1" runat="server" Visible="false">
     <tr>
     <td>
        Họ và tên:
    </td>
    <td>
        <asp:TextBox ID="txt_full_name" runat="server" class="txtformat"  Width="250px" 
            Height="22px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_full_name" runat="server" ErrorMessage="Nhập họ và tên"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td>
    Địa chỉ:
    </td>
    <td>
        <asp:TextBox ID="txt_address" runat="server"  class="txtformat"  Width="250px" 
            Height="22px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_address" runat="server" ErrorMessage="Nhập địa chỉ liên lạc"></asp:RequiredFieldValidator>
     </td>
     </tr>

     <tr>
     <td>
    Số điện thoại:
    </td>
    <td>
        <asp:TextBox ID="txt_phone_number" runat="server"  class="txtformat"  
            Width="250px" Height="22px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_phone_number" ErrorMessage="Nhập số điện thoại"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_phone_number" ValidationExpression="^\d+$" runat="server" ErrorMessage="Số điện thoại chưa đúng"></asp:RegularExpressionValidator>
    </td>
    </tr>

    <tr>
    <td>
    Email:
    </td>
    <td>
        <asp:TextBox ID="txt_emaill_address" runat="server" class="txtformat" Width="250px" Height="22px"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_emaill_address" runat="server" ErrorMessage="Nhập địa chỉ email"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_emaill_address" ErrorMessage="Địa chỉ email chưa đúng" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>   
    </td>
    </tr>
    </asp:Panel>
    <tr>
    <td colspan=3 align=left><hr>
    </td>
    </tr>
    <tr>
    <td align="right">
        <dx:ASPxButton ID="btn_requests" runat="server" Text="Gửi yêu cầu" 
            onclick="btn_request_Click" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
            CssPostfix="Aqua" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
            Width="120px">
        </dx:ASPxButton>
    </td>
    <td>
        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Đóng" 
            onclick="btn_close_Click" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
            CssPostfix="Aqua" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
            Width="120px">
                    <ClientSideEvents Click="function(s, e) {
                            window.location.href='default.aspx'
                    }" />
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


</asp:Content>
