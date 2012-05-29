<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="update_allbum.aspx.cs" Inherits="chiase.update_allbum" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<script type="text/javascript">
    function update_view(allbum_id) {
        var url = "update_view.aspx?allbumid=" + allbum_id;
        loadXMLUpdate(url);
    }
    function del_allbum(allbum_id) {
        if (confirm("Bạn thực sự muốn xóa allbum ảnh này?\n Chọn [Ok] để xóa, [Cancel] để hủy.")) {
            var url = "update_allbum_imgs_save.aspx?allbum_id=" + allbum_id + "&mode=4";
            loadXMLUpdate(url);
            alert("Allbum ảnh đã được xóa thành công!");
            window.location = "show_allbum.aspx";
        }
    }

</script>

<fieldset>
<asp:DataList ID="DataList1"  RepeatLayout="Table" RepeatColumns="2"  
        RepeatDirection="Horizontal" runat="server" 
        onitemdatabound="DataList1_ItemDataBound">
          <ItemTemplate>
                <fieldset >
                <table cellpadding="1" cellspacing="0" border="0" style="color:Black" width="880px">
                <tr>
                <td rowspan="9">
                    <asp:Image ID="img_first" runat="server" Width="160" Height="160" BorderColor="White" BorderWidth="1"/>
                </td>
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
                Ngày, <b><asp:Label ID="lbl_created_date" runat="server" Text='<%#Eval("created_date","{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label></b>
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
                <td>
                Bình luận: <b><asp:Label ID="lbl_commemt" Text='<%#Eval("comments") %>' runat="server"></asp:Label></b>
                </td>
                </tr>
                <tr>
                <td>
                Cập nhật: <b><asp:Label ID="lbl_update" Text='<%#Eval("edited_date","{0:dd/MM/yyyy hh:mm:ss tt}") %>' runat="server"></asp:Label></b>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" style="cursor:hand;">
                    <a href='<%#Eval("allbum_id","slideshow.aspx?allbumid={0}") %>' onclick=update_view('<%#Eval("allbum_id")%>')><b>Xem allbum</b></a> | <a id="popupArea" style="cursor:pointer"><b>Thêm ảnh</b></a> | <a id="update_allbum_info" style="cursor:pointer"><b>Sửa thông tin allbum</b></a> | <b><a href="<%#Eval("allbum_id","update_allbum_imgs.aspx?allbum_id={0}") %>"<b>Sửa ảnh</b></a></b> | <a style="cursor:pointer" onclick=del_allbum('<%#Eval("allbum_id")%>') ><b>Xóa allbum</b></a>
                
        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" AllowDragging="True" AllowResize="True"
        CloseAction="CloseButton" ContentUrl='<%#Eval("allbum_id","upload_images.aspx?allbumid={0}") %>'
        EnableViewState="False" PopupElementID="popupArea"
        PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
        Height="600px" FooterText="Thêm ảnh cho allbum - bạn nhấn Shift hoặc Ctrl để chọn nhiều ảnh"
        HeaderText="Thêm hình cho allbum ảnh" ClientInstanceName="FeedPopupControl" 
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
                                                <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />

    </dx:ASPxPopupControl>


                 
        <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" AllowDragging="True" AllowResize="True"
        CloseAction="CloseButton" ContentUrl='<%#Eval("allbum_id","update_allbum_info.aspx?allbumid={0}") %>'
        EnableViewState="False" PopupElementID="update_allbum_info"
        PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
        Height="500px" FooterText=""
        HeaderText="Sửa thông tin allbum" ClientInstanceName="FeedPopupControl" 
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
                                                <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />

    </dx:ASPxPopupControl>
    <br>
                
                
                </td>
                </tr>
                </table>
                </fieldset>
                <fieldset>Hình ảnh trong allbum: <b><%# Eval("allbum_name") %></b>
                <hr/>
                <asp:DataList ID="DataList2" RepeatLayout="Table" RepeatColumns="10" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                    <td>	                        
					    <a href='slideshow.aspx?allbumid=<%#Eval("allbum_id")%>#<%=ii++ %>' title="<%#Eval("title") %>"><img src='<%#Eval("path") %>' alt='<%#Eval("title") %>' width="75" height="75" style="border:1px solid #FFFFFF"/></a>
                    </td>
                    </tr>
                    </tr>
                    </table>
                </ItemTemplate>
                <FooterTemplate>   
                </FooterTemplate>       
                </asp:DataList>
                <hr/>
                </fieldset>
        </ItemTemplate>
    </asp:DataList>
    <br><p align="right">&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %></p>
</fieldset>

</asp:Content>
