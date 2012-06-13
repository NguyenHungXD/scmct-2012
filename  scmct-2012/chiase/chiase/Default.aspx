<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="chiase._Default" %>
        <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="content_slider" Runat="Server">
 <script type="text/javascript">

     function like_post(id, val, divid) {
         var url = "update_like_post.aspx?project_id=" + id + "&mode=2";
         loadXMLUpdate(url);
         var vals =  val + 1;
         document.getElementById(divid).innerHTML = "(" + vals + ")";
     }

     function return_link(val) {

         var contentUrl = "join_project.aspx?id=" + val;
         alert(contentUrl);
         var windowIndex = 1;
         var window = divpopup.GetWindow(windowIndex);
         divpopup.SetWindowContentUrl(window, contentUrl);
     }

</script>
     
     <div id="templatemo_slider" >
		<div id="featured" style="background-color:#FFF">
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
            <table border="0" cellpadding=0 cellspacing=1 width="100%" class="btn_project_main">

            <tr > <%--class="new_post_details"--%>
                    
                    <td rowspan=2 width=40% align=center>
                        <img src='<%#Eval("img_path","images/projects/{0}")%>' class="img_border" width="320" height="200" />
                    </td>

                    <td with=5% valign=middle align="left">
                        <b><font color=#306EFF size=3><%#Eval("MA_DU_AN")%></font></b>
                        <br>
                        <%#Eval("TEN_DU_AN")%>
                        <br>
                        Thời gian: <%#Eval("NGAY_BAT_DAU", "{0:dd/MM/yyyy }")%>-<%#Eval("NGAY_KET_THUC", "{0:dd/MM/yyyy }")%>(<%#Eval("NAME")%>)
                        <br>
                        <asp:HyperLink ID="link_more" runat="server" NavigateUrl='<%#Eval("ID","project_detail.aspx?id={0}")%>' title='<%#Eval("MA_DU_AN","Xem chi tiết dự án {0}")%>' Text="...xem chi tiết dự án..." style="cursor:pointer;"></asp:HyperLink>
                    
                        <asp:HyperLink Visible="false" ID="link_new_post" runat="server"></asp:HyperLink>
                        <asp:Label Visible="false" ID="lbl_posted_by" runat="server" Text=""></asp:Label>
                    
                    </td>



                    </tr>

                    <tr>
                    <td colspan="7">

                    <div > <%--class="project_detail"--%>
                    <table cellpadding="2" cellspacing="0" border="0" width="100%">
                    <tr>
                    <td>
                    <hr>
                    </td>
                    </tr>
                    <tr>
                    <td><asp:Image ID="img_status" runat="server" ImageUrl="images/book-open.png" width="12" Height="12"/>
                        Số sách cần quyên góp cho dự án: <font color=red><b><%#Eval("BOOK")%></b></font> quyển
                    </td>
                    <td rowspan=8 valign=bottom align=right>
                        
                    </td>
                    </tr>
                    <tr>
                    <td><asp:Image ID="Image1" runat="server" ImageUrl="images/book-open.png" width="12" Height="12"/>
                        Số hàng(sách, vật dụng,..) <font color=red>đã quyên góp</font> được: <b><asp:HyperLink title="Xem chi tiết" style="color:red; text-decoration: underline; font-weight: bold;" target="_blank" id="link_sum" runat="server"></asp:HyperLink></b> phần
                    </td>
                    </tr>
                    <tr>
                    <td class="link_format1"><asp:Image ID="Image2" runat="server" ImageUrl="images/book-open.png" width="12" Height="12"/>
                        Danh sách <font color=red>đóng góp</font> cho dự án: [<a title="Xem chi tiết" href="<%#Eval("id","contributor_list.aspx?id={0}") %>" target="_blank">xem</a>]
                    </td>
                    </tr>
                    <tr>
                    <td class="link_format1"><asp:Image ID="Image4" runat="server" ImageUrl="images/book-open.png" width="12" Height="12"/>
                        Danh sách <font color=red>tham gia</font> dự án: [<a title="Xem chi tiết" href='<%#Eval("ID","member_list_project.aspx?id={0}")%>' target="_blank">xem</a>]
                    </td>
                    </tr>
                    <tr>
                    <td class="link_format1"><asp:Image ID="Image5" runat="server" ImageUrl="images/book-open.png" width="12" Height="12"/>
                        Báo cáo <font color=red>tổng kết</font> dự án: [<a title="Xem chi tiết" href='<%#Eval("ID","project_reports.aspx?id={0}")%>' target="_blank">xem</a>]
                    </td>
                    </tr>
                    <tr>
                     <td with=5% valign="middle" align="center" style="cursor:pointer;"  >
                    <hr>
                    </td>
                    </tr>
                    </table>
                    </div>
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <table cellpadding=0 cellspacing=0 border=0><tr><td width=5%><a title="Thích dự án" style="cursor:pointer" onclick=like_post(<%# Eval("ID")%>,<%#Eval("liked")%>,'<%#Eval("ID","div{0}")%>')><img src="images/like.gif" width="20" height="15"></td><td id='<%#Eval("ID","div{0}")%>'>(<%#Eval("liked")%>)</td></tr></table>
                    </td>
                    <td colspan=2 align="right">
                    <a class="btn_admin_default" href="<%#Eval("ID","request.aspx?id={0}")%>" >Tặng sách</a><a class="btn_admin_default" id='<%#Eval("id","divpopup{0}") %>'>Tham gia dự án</a><a class="btn_admin_default" href='<%#Eval("ID","post_news.aspx?projectID={0}")%>' >Viết bài</a><a class="btn_admin_default" href='<%#Eval("id","show_album.aspx?projectid={0}") %>' >Hình ảnh</a>
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
                     </table>
        </ItemTemplate>
        <FooterTemplate>
       <div style="height:1px">&nbsp</div>
        </FooterTemplate>
        
        </asp:Repeater>   

</asp:Content>