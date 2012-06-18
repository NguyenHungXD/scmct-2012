<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="show_album.aspx.cs" Inherits="chiase.show_album" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <script type="text/javascript">

    function update_like(album_id,id,vals) {
        var liked = document.getElementById(id)
        var val = vals + 1;
        liked.innerHTML = "(" + val + ")";

        var url = "update_like_post.aspx?album_id=" + album_id + "&mode=4";
        loadXMLUpdate(url);
    }


    function update_view(album_id) {
        var url = "update_view.aspx?albumid=" + album_id;
        loadXMLUpdate(url);
    }
    function del_album(album_id) {
        if (confirm("Bạn thực sự muốn xóa album ảnh này?\n Chọn [Ok] để xóa, [Cancel] để Đóng.")) {
            var url = "update_album_imgs_save.aspx?album_id=" + album_id + "&mode=4";
            loadXMLUpdate(url);
            alert("album ảnh đã được xóa thành công!");
            window.location = "show_album.aspx";
        }
    }
    function checked_all(val) {
        var check = false;
        var album_alls = document.getElementById("album_alls");
        var album_cuatoi = document.getElementById("album_cuatoi");
        var album_toithich = document.getElementById("album_toithich");
        var album_toibl = document.getElementById("album_toibl");
        if (val == 1) {
            if (album_alls.checked == true)
                check = true;

            album_cuatoi.checked = check;
            album_toithich.checked = check;
            album_toibl.checked = check
        } else {
            if (album_cuatoi.checked == true && album_toithich.checked == true && album_toibl.checked == true)
                check = true;

                album_alls.checked = check;
        }
    }
    function reload_page() {
        var url="show_album.aspx";

        var album_alls= document.getElementById("album_alls");
        var album_cuatoi= document.getElementById("album_cuatoi");
        var album_toithich= document.getElementById("album_toithich");
        var album_toibl= document.getElementById("album_toibl");

        if(album_alls.checked==true) 
            url=url+"?show_all=all";
        else
            url=url+"?show_all=none";
        if(album_cuatoi.checked==true) url=url+"&album_cuatoi=all";  
        if(album_toithich.checked==true) url=url+"&album_toithich=all";
        if (album_toibl.checked == true) url = url + "&album_toibl=all";

        location.href = url; 
    }
</script>


<fieldset style="background-color:#F2F2F2;color:blue">
<div class="upload" >
     <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" AllowDragging="True" AllowResize="True"
        CloseAction="CloseButton"
        EnableViewState="False" PopupElementID="popupArea1"
        PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
        Height="500px" FooterText=""
        HeaderText="Tạo album ảnh" ClientInstanceName="FeedPopupControl" 
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
     <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" AllowDragging="True" AllowResize="True"
        CloseAction="CloseButton"
        EnableViewState="False" PopupElementID="popupArea"
        PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
        Height="500px" FooterText=""
        HeaderText="Tạo album ảnh" ClientInstanceName="FeedPopupControl" 
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
    <table width=100% cellspacing=0 cellpadding=0 border=0><tr><td valign="bottom"><font size=-1><asp:Label ID="lbl_info" runat="server" Text="">*-Đăng nhập để sử dụng tiện ích tùy chọn hình ảnh</asp:Label></font></td><td align=right>
<asp:Label ID="lbl_create_album" runat="server">
    <a title="Tạo album ảnh mới" id="popupArea" class="btn" style="height:25px;padding:5px 10px 5px 10px"/><img src="images/createnewallbum.png" width=20 height=20> <b>Tạo album ảnh cơ bản</b></a>
     <a title="Tạo album ảnh mới" id="popupArea1" class="btn" style="height:25px;padding:5px 10px 5px 10px"/><img src="images/createnewallbum.png" width=20 height=20> <b>Tạo album ảnh nâng cao</b></a>
</asp:Label>
</td></tr>
</table>
    
    


    <asp:Label id="show_search" runat="server" Text="">
    <hr>
        <asp:CheckBox onclick="checked_all('1');" ClientIDMode="Static" id="album_alls" runat="server" ></asp:CheckBox><label for="album_alls">Tất cả album</label> | 
        <asp:CheckBox onclick="checked_all('2');" ClientIDMode="Static" id="album_cuatoi" runat="server"></asp:CheckBox><label for="album_cuatoi">Album của tôi</label> | 
        <asp:CheckBox onclick="checked_all('3');" ClientIDMode="Static" id="album_toithich" runat="server"></asp:CheckBox><label for="album_toithich">Album tôi thích</label> | 
        <asp:CheckBox onclick="checked_all('4');" ClientIDMode="Static" id="album_toibl" runat="server"></asp:CheckBox><label for="album_toibl">Album tôi bình luận</label>
        &nbsp;&nbsp;<a onclick="reload_page();" title="Tìm lại" class="btn" style="font-weight:bold;padding:5px 10px 3px 5px"><img src="images/refresh.png" width=30px height=25px>Tìm lại</a>
    </asp:Label>

<hr>
<p align="center">
    <asp:DataList ID="DataList1"  RepeatLayout="Table" RepeatColumns="4"  
        RepeatDirection="Horizontal" runat="server" 
        onitemdatabound="DataList1_ItemDataBound">
          <ItemTemplate>
                <fieldset class="btn_img">
               
                <table cellpadding="2" cellspacing="0" border="0" width=100%>
                <tr>
                <td colspan="4" align="center">
                    <a href='<%#Eval("album_id","slideshow.aspx?albumid={0}") %>' onclick=update_view('<%#Eval("album_id")%>') title='Xem album ảnh'><asp:Image ID="img_first" runat="server" Width="160" Height="160" class="img_border"/></a>
                </td>
                </tr>
                <tr>
                <td colspan="4" align="center">
                <b><asp:Label ID="lbl_album_name" runat="server" Text='<%# Eval("album_name") %>'></asp:Label></b>
                </td>
                </tr>

                <tr style="font-size:10px">
                <td colspan=4>
                Tạo bới <b><asp:Label ID="username" runat="server" Text='<%#Eval("username") %>'></asp:Label></b>, <b><asp:Label ID="lbl_created_date" runat="server" Text='<%#Eval("created_date","{0:dd/MM/yyyy hh:mm:ss tt }") %>'></asp:Label></b>
                </td>
                </tr>

                <tr style="font-size:11px">
                <td colspan=4 align=center>
                <b><asp:Label ID="lbl_cnt_img" runat="server" Text="20"></asp:Label></b> ảnh |
              
                Xem <b><asp:Label ID="lbl_viewed" runat="server" Text='<%#Eval("viewed") %>'></asp:Label></b> |
          
                <%--Thích <b><asp:Label ID="lbl_liked" runat="server" Text='<%#Eval("liked") %>'></asp:Label></b> |--%>
            
                Bình luận <b><asp:Label ID="lbl_commemt" Text='<%#Eval("comments") %>' runat="server"></asp:Label></b>
                </td>
                </tr>

<%--                <tr>
                <td>
                Cập nhật: <b><asp:Label ID="lbl_update" Text='<%#Eval("edited_date","{0:dd/MM/yyyy hh:mm:ss tt}") %>' runat="server"></asp:Label></b>
                </td>
                </tr>--%>
              
                <tr>
                
                <td align="center" valign="middle" style="cursor:hand;" class="link_format1" colspan=4>
                <hr>
                <table cellpadding=0 cellspacing=0 width=100% border=0>
                <tr>
                <td align=left width=5%><a style="cursor:pointer" onclick=update_like('<%#Eval("album_id")%>','<%#Eval("album_id","divliked{0}")%>',<%#Eval("liked") %>) title='Thích album ảnh'><img src="images/like.gif" width="18" height="15"></a> </td><td width=5% id='<%#Eval("album_id","divliked{0}")%>'>(<%#Eval("liked") %>)</td>
                <td>
                    <img src="images/view.gif" width="12" height="15"><a href='<%#Eval("album_id","slideshow.aspx?albumid={0}") %>' onclick=update_view('<%#Eval("album_id")%>') title='Xem album ảnh'>Xem</a> 
                    
                    <asp:Label ID="lbl_edit_album" runat="server">
                        | <img src="images/edit.png" width="12" height="12"><a href='<%#Eval("album_id","update_album.aspx?album_id={0}") %>' title='Sửa album ảnh'>Sửa</a> 
                    </asp:Label>

                    <asp:Label ID="lbl_del_album" runat="server">
                        | <img src="images/deletes.png" width="12" height="12"><a style="cursor:pointer" onclick=del_album('<%#Eval("album_id")%>') title='Xóa album ảnh'>Xóa </a>
                    </asp:Label>
                </td>
                </tr>
                </table>
                </td>
                </tr>
                </table>
                </font>
                </fieldset>  
        </ItemTemplate>
    </asp:DataList>
    </p>
    <br>
    <hr>
<p align="right">&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %></p>
</div>

</fieldset>

</asp:Content>
