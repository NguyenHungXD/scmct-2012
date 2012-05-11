<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="show_allbum.aspx.cs" Inherits="chiase.show_allbum" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">



<fieldset style="background-color:#4CC417;">
<div class="upload">
<table id="popupArea" bgcolor=green cellpadding=3 cellspacing=3 style="border: 1px solid #fff;">
<tr style="cursor:pointer;" title="Tạo allbum ảnh mới">
<td align="center" valign="middle" style="cursor:hand;">
    <asp:Image ID="Image1" runat="server"  ImageUrl="images/createnewallbum.png" 
        Height="20px" Width="20px" /> <font color=white><b>Tạo allbum mới</b></font>
</td>
</tr>
</table>
     <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" AllowDragging="True" AllowResize="True"
        CloseAction="CloseButton" ContentUrl="uploads.aspx"
        EnableViewState="False" PopupElementID="popupArea"
        PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
        Height="500px" FooterText="Thêm ảnh cho allbum - bạn nhấn Shift hoặc Ctrl để chọn nhiều ảnh"
        HeaderText="Tạo allbum ảnh" ClientInstanceName="FeedPopupControl" 
        EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
        CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
        SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
        <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
        </LoadingPanelImage>
        <ContentStyle VerticalAlign="Top">
        </ContentStyle>
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <br>
    <asp:DataList ID="DataList1"  RepeatLayout="Table" RepeatColumns="4"  
        RepeatDirection="Horizontal" runat="server" 
        onitemdatabound="DataList1_ItemDataBound">
          <ItemTemplate>
                <fieldset  class="btn_img">
                <table cellpadding="0" cellspacing="0" border="0" style="color:White;">
                <tr>
                <td>
                    
                <asp:Image ID="img_fist" runat="server" />
                </td>
                </tr>
                <tr>
                <td>
     
                <b><asp:Label ID="lbl_allbum_name" runat="server" Text='<%# Eval("allbum_name") %>'></asp:Label></b>
                </td>
                </tr>
                <tr>
                <td>
                Số lượng: <b><asp:Label ID="lbl_cnt_img" runat="server" Text="20"></asp:Label></b> ảnh
                </td>
                </tr>
                <tr>
                <td>
                Tạo bới: <b><asp:Label ID="llb_created_by" runat="server" Text='<%#Eval("name") %>'></asp:Label></b>
                (<asp:Label ID="username" runat="server" Text='<%#Eval("username") %>'></asp:Label>)
                </td>
                </tr>
                <tr>
                <td>
                Ngày, <b><asp:Label ID="lbl_created_date" runat="server" Text='<%#Eval("created_date") %>'></asp:Label></b>
                </td>
                </tr>
                <tr>
                <td>
                Xem: <b><asp:Label ID="lbl_viewed" runat="server" Text='<%#Eval("viewed") %>'></asp:Label></b>
                </td>
                </tr>
                <tr>
                <td>
                Thích: <b><asp:Label ID="lbl_liked" runat="server" Text='<%#Eval("liked") %>'></asp:Label></b>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" style="cursor:hand;">
                    <a href='<%#Eval("allbum_id","slideshow.aspx?allbumid={0}") %>' ><b>Xem allbum</b></a> | <a href='<%#Eval("allbum_id","slideshow.aspx?allbumid={0}") %>' ><b>Cập nhật</b></a>
                </td>
                </tr>
                </table>
                </fieldset>  
        </ItemTemplate>
    </asp:DataList>
    <br>
</div>
</fieldset>
</asp:Content>
