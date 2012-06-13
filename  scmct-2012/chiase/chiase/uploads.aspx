<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploads.aspx.cs" Inherits="chiase.uploads" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="Stylesheet" type="text/css" href="Styles/uploadify.css" />
     <script type="text/javascript" src="scripts/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="scripts/jquery.uploadify.js"></script>
</head>
<body>
<fieldset>
<form id="form1" runat="server">


<asp:Panel ID="Panel3" runat="server" Visible="false">

  <table border=0 cellpadding=3 cellspacing=3 width=100%>
        <tr>
        <td>
        Tên album:
        </td>
        <td>
            <b><%= album_name %></b>
        </td>
        </tr>
        <tr>
        <td valign="top">
        Chi tiết:
        </td>
        <td>
           <b><%= album_detail %></b>
        </td>         
        </tr>
        </table>


</asp:Panel>


<asp:Panel ID="Panel1" runat="server" Visible="false">
  <table border=0 cellpadding=3 cellspacing=3 width=100%>
        <tr>
        <td>
        Tên album:
        </td>
        <td>
        <asp:TextBox ID="txt_album_name" runat="server" class="txtformat" Width="300px" 
                Height="23px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td valign=top>
        Mô tả:
        </td>
        <td>
        <asp:TextBox ID="txt_desc" runat="server" class="txtformat_area" Height="138px" 
                TextMode="MultiLine" Width="545px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>&nbsp
        </td>
        <td>

            <dx:ASPxButton ID="btn_save_album" runat="server" Text="Lưu album" 
                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="120px" OnClick="btn_save_album_Click">
            </dx:ASPxButton>

        </td>
        </tr>
        </table>
         </asp:Panel>


            <asp:Label ID="lbl_error" runat="server"></asp:Label>
            <br>
 



    <div style = "padding:40px">

    <asp:Panel ID="Panel2" runat="server" Visible="false">

        <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="#CC0099" />


     </asp:Panel>


        <asp:HiddenField ID="album_id" runat="server" />
        <asp:HiddenField ID="user_id" runat="server" />
    </div>

</form>
</fieldset>
</body>
</html>
<script type = "text/javascript">
    var album_id = document.all["<%=album_id.ClientID%>"].value;
    var user_id = document.all["<%=user_id.ClientID%>"].value;

    $(window).load(
    function () {
        $("#<%=FileUpload1.ClientID %>").fileUpload({
            'uploader': 'scripts/uploader.swf',
            'cancelImg': 'images/cancel.png',
            'buttonText': 'Chon hinh...',
            'script': 'Upload.ashx?id=' + album_id + ';' + user_id + ';',
            'fileDesc': 'Image Files',
            'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
            'multi': true,
            'auto': true
        });
    }
);
</script> 
