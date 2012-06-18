<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="project_detail.aspx.cs" Inherits="chiase.project_detail" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<script type="text/javascript">

    function like_post(id, val, divid) {
        var url = "update_like_post.aspx?post_id=" + id;
        loadXMLUpdate(url);
        document.getElementById(divid).innerHTML = val + 1;
    }
</script>
<fieldset> 
<table cellpadding="3" cellspacing="1" border="0" width="100%">
<tr>
<td colspan="2">
<fieldset style="background-color:White"> 
<table border="0" cellpadding=5 cellspacing=0 width="100%"  style="border:1px solid #118AF5;" >
<tr>
<td>&nbsp
</td>
</tr>
<tr>
<td>
    Dự án:
        </td>
<td width=90%>
    <b><asp:Label ID="lbl_maduan" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr>
<td>
Tên dự án:
</td>
    <td>
    <b><asp:Label ID="lbl_tenduan" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<%--<tr >
<td>
    Ghi chú:
    </td>
    <td>
    <b><asp:Label ID="lbl_ghichu" runat="server" Text=""></asp:Label></b>
</td>
</tr>--%>
<tr>
<td>
    Số sách cần quyên góp:
        </td>
    <td>
    <b><asp:Label ID="lbl_book" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr>
<td>
    Trạng thái:
        </td>
    <td>
    <b><asp:Label ID="lbl_trangthai" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr>
<td>
    Thời gian:
        </td>
    <td>
    <b><asp:Label ID="lbl_batdau" runat="server" Text=""></asp:Label> - <asp:Label ID="lbl_ketthuc" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr>
<td width="80%" colspan=2 >
<hr>
    <asp:Label ID="lbl_chitiet" runat="server" Text=""></asp:Label>
</td>
</tr>

<tr>
<td colspan=8>
<hr>
<p align="right">&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %></p>
</td>
</tr>
</table>
</fieldset>
</td>
</tr>
<tr>
<td colspan="2">

        <table border="0" cellpadding=0 cellspacing=1 width="100%"  style="border:0px solid #118AF5;background-color:#3BB9FF" class="btn_forum">
  
        <tr class="btn_project" style="text-align:center;font-weight:bold">
        <td style="padding:5px 0px 0px 0px"><img src="images/news_project.png" width=30 height=30></td>
        <td colspan=2 width=30%>
           Tiêu đề
        </td>
        <td width=10%>
            Lượt xem
        </td>
        <td width=10%>
            Bình luận
        </td>
        <td width=10%>
            Xếp hạng
        </td>
        <td width=40%>
            <table border=0 cellpadding=0 cellspacing=0 width=100%><tr><td valign="middle">Bình luận mới</td><td align=right> <asp:Label ID="lbl_post_new" runat="server" ><asp:HyperLink style="cursor:pointer" ID="linkPostnew"  runat="server" class="btn">  <img src="images/post_new.png" width="20" height="20"> Bài mới</asp:HyperLink></asp:Label></td></tr></table>
        </td>
        </tr>
 <asp:Repeater ID="showListPost" runat="server" 
            onitemdatabound="showListPost_ItemDataBound1">
        <HeaderTemplate>


        </HeaderTemplate>
        <ItemTemplate>

                    <tr class="new_post_details_4rum">
                    <td with=10%>
                    <p style="margin:5px 5px 5px 5px">
                    <asp:Image ID="img_like" runat="server" ImageUrl="images/open_news.png" Width=25 Height=20/>
                    </p>
                    </td>
                    <td with=10% valign=middle align=center style="cursor:pointer;"  onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'<%#Eval("BAI_VIET_ID","div{0}")%>')>
                    <p style="margin:5px 5px 5px 5px">
                    <div id='<%#Eval("BAI_VIET_ID","div{0}")%>' class="like_text">
                    <%#Eval("liked")%>
                    </div>
                    <div class="like_fm">
                    &nbsp
                    </div>
                    </p>
                    </td>

                    <td align=left with=25%>
                    <p style="margin:5px 5px 5px 5px">
                    
                    <img src="<%# Eval("avatar_path","images/avatars/{0}") %>" width="30px" height="30px">&nbsp<asp:HyperLink ID="link_show_detail" runat="server" Text='<%# Eval("tieu_de") %>'></asp:HyperLink><br><font size=-3><i>Tạo bởi 
                                        <a style="cursor:pointer" ID='<%#Eval("BAI_VIET_ID", "username{0}") %>'><font color="Yellow"><%#Eval("username") %></font></a>
                                        , <%#Eval("ngay_tao", "{0:dd/MM/yyyy hh:mm:ss tt}")%></font></i>
                    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl='<%#Eval("username", "user_info.aspx?user_name={0}") %>'
                            EnableViewState="False" PopupElementID='<%#Eval("BAI_VIET_ID", "username{0}") %>'
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="600px" FooterText=""
                            HeaderText="" ClientInstanceName="FeedPopupControl" 
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
                   </p>         
                    </td>
                    <td with=10%>
                    
                        <asp:Label ID="lbl_cnt_comment" runat="server" Text='<%# Eval("xem") %>'></asp:Label>
                    
                    </td>
                    <td with=10%>
                        <asp:Label ID="lbl_cnt_view" runat="server" Text="0"></asp:Label>
                    </td>
                    <td with=10%>
                    
                    <asp:Image ID="Image2" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image5" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image6" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image7" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image8" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    </td>
                    <td with=25% align=left>
                    <p style="margin:5px 5px 5px 5px">
                        <asp:HyperLink ID="link_comment" runat="server"></asp:HyperLink><br>
                        <font size=-3><asp:Label ID="lbl_text" runat="server"></asp:Label>
                        <asp:Label ID="lbl_create" runat="server" Text="0"></asp:Label><asp:HyperLink ID="link_cm_by" runat="server" Text="" target="_blank" title="Xem chi tiết"></asp:HyperLink> <asp:Label ID="lbl_date_time" runat="server" Text=""></asp:Label></font>
                    </p>
                    </td>
                    </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>



    



</td>
</tr>
</table>
</fieldset> 
</asp:Content>
