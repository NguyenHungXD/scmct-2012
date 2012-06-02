<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="chiase._Default" %>
        <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="content_slider" Runat="Server">

 <script type="text/javascript">

     function like_post(id, val, divid) {
         var url = "update_like_post.aspx?project_id=" + id + "&mode=2";
         loadXMLUpdate(url);
         document.getElementById(divid).innerHTML = val + 1;
     }

     function return_link(val) {

         var contentUrl = "join_project.aspx?id=" + val;
         alert(contentUrl);
         var windowIndex = 1;
         var window = divpopup.GetWindow(windowIndex);
         divpopup.SetWindowContentUrl(window, contentUrl);
     }

</script>
     
     <div id="templatemo_slider">
		<div id="featured" >
			<ul class="ui-tabs-nav">
                <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <li class="ui-tabs-nav-item" id='<%#Eval("ID","nav-fragment-{0}") %>'><a href='<%#Eval("ID","#fragment-{0}") %>' ><img src='<%#Eval("img_path") %>' alt="" width="80" height="45"/><span><%#Eval("title") %></span></a></li>
                </ItemTemplate>
                </asp:Repeater>
            <!--
                <li class="ui-tabs-nav-item" id="nav-fragment-1"><a href="#fragment-1"><img src="images/content_slider/image2-small.jpg" alt="Image2small" /><span>Chương trình Quyên góp 3000 sách cho trẻ em nghèo</span></a></li>
                <li class="ui-tabs-nav-item" id="nav-fragment-2"><a href="#fragment-2"><img src="images/content_slider/image2-small.jpg" alt="Image2small" /><span>Chương trình Quyên góp 3000 sách cho trẻ em nghèo</span></a></li>
				<li class="ui-tabs-nav-item" id="nav-fragment-3"><a href="#fragment-3"><img src="images/content_slider/image3-small.jpg" alt="Image3small" /><span>Cờ Đỏ là một huyện vùng ven TP Cần Thơ...</span></a></li>
				<li class="ui-tabs-nav-item" id="nav-fragment-4"><a href="#fragment-4"><img src="images/content_slider/image4-small.jpg" alt="Image4small" /><span>Kêu gọi ủng hộ trẻ em nghèo</span></a></li>
		    -->
            </ul>

           <asp:Repeater ID="Repeater2" runat="server">
           <ItemTemplate>
            <div id='<%#Eval("ID","fragment-{0}") %>' class="ui-tabs-panel" style="">
				<img src='<%#Eval("img_path") %>' width="580" height="250" alt="" />
				<div class="info">
					<h2><a href='<%#Eval("post_id","post_show_details.aspx?news_id={0}") %>' ><%#Eval("title") %></a></h2>
					<p><%#Eval("contents") %>....<a href='<%#Eval("post_id","post_show_details.aspx?news_id={0}") %>'>[Đọc thêm]</a></p>
				</div>
			</div>
            </ItemTemplate>
            </asp:Repeater>
		</div>
</div> <!-- end of templatemo_slider -->
</asp:Content>
<asp:Content ID="register" ContentPlaceHolderID="content_area" Runat="Server">



    <asp:Repeater ID="showListProject" runat="server" 
        onitemdatabound="showListProject_ItemDataBound">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;" class="btn_project">
            <tr class="new_post">
            <td >
                &nbsp
            </td>
            <td>
                Mã dự án
            </td>
            <td>
                Tên dự án
            </td>
            <td>
                Ngày
            </td>
            <td>
                Bài viết mới
            </td>
            <td>
                Trạng thái
            </td>
            </tr>
                    <tr class="new_post_details">
                    <td with=5% valign="middle" align="center" style="cursor:pointer;"  onclick=like_post(<%# Eval("ID")%>,<%#Eval("liked")%>,'<%#Eval("ID","div{0}")%>')>
                    <div id='<%#Eval("ID","div{0}")%>' class="like_text">
                    <%#Eval("liked")%>
                    </div>
                    <div class="like_fm">
                    &nbsp
                    <div>
                    </td>
                    <td with=5% valign=middle align="center">
                    <%#Eval("MA_DU_AN")%>
                    <br>
                    <asp:HyperLink ID="link_more" runat="server" NavigateUrl='<%#Eval("ID","project_detail.aspx?id={0}")%>' Text="Xem chi tiết" style="cursor:pointer;"></asp:HyperLink>
                    </td>
                    <td with=10% valign=middle align="center">
                    <%#Eval("TEN_DU_AN")%>
                    </td>
                    <td with=10% valign=middle align="center">
                    Bắt đầu: <%#Eval("NGAY_BAT_DAU", "{0:dd/MM/yyyy }")%><br>
                    Kết thúc: <%#Eval("NGAY_KET_THUC", "{0:dd/MM/yyyy }")%>
                    </td>
                    <td with=30% valign=middle align="center">

                        <asp:HyperLink ID="link_new_post" runat="server"></asp:HyperLink>
                        <asp:Label ID="lbl_posted_by" runat="server" Text=""></asp:Label>
                    </td>
                    <td with=10% valign=middle align="center">
                        <%#Eval("NAME")%>
                    </td>
                    </tr>
                    <tr>
                    <td colspan="7">
                    <div class="project_detail">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                    <td>&nbsp
                    </td>
                    </tr>
                    <tr>
                    <td><asp:Image ID="img_status" runat="server" ImageUrl="images/heart.gif" width="10" Height="10"/>
                        Số sách cần quyên góp cho dự án: <b><%#Eval("BOOK")%></b> quyển
                    </td>
                    <td rowspan=7 align=right>
                        <a href="<%#Eval("ID","request.aspx?id={0}")%>" class="btn_admin">Tặng sách</a>  <a class="btn_admin" id='<%#Eval("id","divpopup{0}") %>'>Tham gia dự án</a> <a href='<%#Eval("ID","post_news.aspx?projectID={0}")%>' class="btn_admin">Viết bài</a>  <a href='<%#Eval("id","show_allbum.aspx?projectid={0}") %>' class="btn_admin">Hình ảnh</a>
                    
                    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ContentUrl='<%#Eval("id","join_project.aspx?id={0}")%>'
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" 
                            EnableViewState="False" PopupElementID='<%#Eval("id","divpopup{0}") %>'
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="700px" FooterText=""
                            HeaderText="Gửi yêu cầu tham gia dự án" 
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
                    <tr>
                    <td><asp:Image ID="Image1" runat="server" ImageUrl="images/heart.gif" width="10" Height="10"/>
                        Số sách đã quyên góp được: 100 quyển
                    </td>
                    </tr>
                    <tr>
                    <td class="link_format"><asp:Image ID="Image2" runat="server" ImageUrl="images/heart.gif" width="10" Height="10"/>
                        Danh sách quyên góp: [<a href="#" target="_blank">xem</a>]
                    </td>
                    </tr>
                    <tr>
                    <td class="link_format"><asp:Image ID="Image4" runat="server" ImageUrl="images/heart.gif" width="10" Height="10"/>
                        Danh sách tham gia dự án: [<a href='<%#Eval("ID","member_list_project.aspx?id={0}")%>' target="_blank">xem</a>]
                    </td>
                    </tr>
                    <tr>
                    <td class="link_format"><asp:Image ID="Image5" runat="server" ImageUrl="images/heart.gif" width="10" Height="10"/>
                        Báo cáo tổng kết dự án: [<a href="#" target="_blank">xem</a>]
                    </td>
                    </tr>
                    <tr>
                    <td>&nbsp
                    </td>
                    </tr>
                    </table>
                    </div>
                    </td>
                    </tr>
                     </table>
        </ItemTemplate>
        <FooterTemplate>
       <div style="height:1px">&nbsp</div>
        </FooterTemplate>
        
        </asp:Repeater>   

</asp:Content>