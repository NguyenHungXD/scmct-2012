<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="upload.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="Stylesheet" type="text/css" href="Styles/uploadify.css" />
     <script type="text/javascript" src="Scripts/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.uploadify.js"></script>
</head>
<body>
<form id="form1" runat="server">


    <table style="width: 100%; height:300px" id="popupArea">
        <tr>
            <td align="center" valign="middle">
                <table cellpadding="4" style="cursor: pointer; white-space:nowrap">
                    <tr>
                        <td style="width: 32px; height: 34px;">
                        
                            
                            <dx:ASPxImage ID="Image1" runat="server" BackColor="Transparent" Height="32px" ImageUrl="~/PopupControl/Images/mail32x32.gif" Width="32px" /></dx:ASPxImage>
                        </td>
                        <td style="height: 34px;">
                            Click here to send us a message...
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>




    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" AllowDragging="True" AllowResize="True"
        CloseAction="CloseButton" ContentUrl="~/PopupControl/ContentUrlFeedForm.aspx"
        EnableViewState="False" PopupElementID="popupArea" PopupHorizontalAlign="Center"
        PopupVerticalAlign="Middle" ShowFooter="True" ShowOnPageLoad="True" Width="400px"
        Height="300px" FooterText="Try to resize the control using the resize grip or the control's edges"
        HeaderText="Feedback form" ClientInstanceName="FeedPopupControl" 
        EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
        CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
        SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
        <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
        </LoadingPanelImage>
        <ContentStyle VerticalAlign="Top">
        </ContentStyle>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>










    <div style = "padding:40px">
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>
</form>
</body>
</html>
<script type = "text/javascript">
$(window).load(
    function() {
    $("#<%=FileUpload1.ClientID %>").fileUpload({
        'uploader': 'images/uploader.swf',
        'cancelImg': 'images/cancel.png',
        'buttonText': 'Chon hinh',
        'script': 'Upload.ashx',
        'folder': 'images//upload',
        'fileDesc': 'Image Files',
        'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
        'multi': true,
        'auto': true
    });
   }
);
</script> 
