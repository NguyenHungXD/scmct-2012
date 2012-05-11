<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="chiase._Default" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="content_slider" Runat="Server">

 <script type="text/javascript">

     function like_post(id, val, divid) {
         var url = "update_like_post.aspx?project_id=" + id + "&mode=2";
         loadXMLUpdate(url);
         document.getElementById(divid).innerHTML = val + 1;
     }
</script>
     
     <div id="templatemo_slider">
		<div id="featured" >
			<ul class="ui-tabs-nav">
				<li class="ui-tabs-nav-item ui-tabs-selected" id="nav-fragment-1"><a href="#fragment-1"><img src="images/content_slider/image1-small.jpg" alt="Image1small" /><span>Những cuốn sách của bạn có thể mang lại một cơ hội mới cho các em nhỏ</span></a></li>
				<li class="ui-tabs-nav-item" id="nav-fragment-2"><a href="#fragment-2"><img src="images/content_slider/image2-small.jpg" alt="Image2small" /><span>Chương trình Quyên góp 3000 sách cho trẻ em nghèo</span></a></li>
				<li class="ui-tabs-nav-item" id="nav-fragment-3"><a href="#fragment-3"><img src="images/content_slider/image3-small.jpg" alt="Image3small" /><span>Cờ Đỏ là một huyện vùng ven TP Cần Thơ...</span></a></li>
				<li class="ui-tabs-nav-item" id="nav-fragment-4"><a href="#fragment-4"><img src="images/content_slider/image4-small.jpg" alt="Image4small" /><span>Kêu gọi ủng hộ trẻ em nghèo</span></a></li>
			</ul>

			<!-- First Content -->
			<div id="fragment-1" class="ui-tabs-panel" style="">
				<img src="images/content_slider/image1.jpg" alt="Image 1" />
				<div class="info" >
					<h2><a href="#" >Những cuốn sách của bạn có thể mang lại một cơ hội mới cho các em nhỏ</a></h2>
					<p>Những cuốn sách của bạn có thể mang lại một cơ hội mới cho các em nhỏ. Hãy san sẻ những con đường cho các em, bạn nhé, để các em có những cơ hội vượt thoát lên hoàn cảnh khó khăn....<a href="#" >read more</a></p>
				</div>
			</div>

			<!-- Second Content -->
			<div id="fragment-2" class="ui-tabs-panel ui-tabs-hide" style="">
				<img src="images/content_slider/image2.jpg" alt="Image 2" />
				<div class="info" >
					<h2><a href="#" >Chương trình Quyên góp 3000 sách cho trẻ em nghèo</a></h2>
					<p>Chương trình Quyên góp 3000 sách cho trẻ em nghèo hiếu học tỉnh Bến Tre....<a href="#" >read more</a></p>
				</div>
			</div>

			<!-- Third Content -->
			<div id="fragment-3" class="ui-tabs-panel ui-tabs-hide" style="">
				<img src="images/content_slider/image3.jpg" alt="Image 3" />
				<div class="info" >
					<h2><a href="#" >CHUYẾN TỪ THIỆN CHO TRẺ EM NGHÈO HIẾU HỌC</a></h2>
					<p>Cờ Đỏ là một huyện vùng ven TP Cần Thơ, cách trung tâm thành phố 40km....<a href="#" >read more</a></p>
				</div>
			</div>

			<!-- Fourth Content -->
			<div id="fragment-4" class="ui-tabs-panel ui-tabs-hide" style="">
				<img src="images/content_slider/image4.jpg" alt="Image 4" />
				<div class="info" >
					<h2><a href="#" >Kêu gọi ủng hộ trẻ em nghèo</a></h2>
					<p>Năm 2011, nhờ sự tài trợ của các tập thể, cá nhân hảo tâm, Quỹ Bảo trợ trẻ em Hà Nội đã hỗ trợ....<a href="#" >read more</a></p>
				</div>
			</div>
		</div>
</div> <!-- end of templatemo_slider -->
</asp:Content>

<asp:Content ID="register" ContentPlaceHolderID="content_area" Runat="Server">
 <asp:Repeater ID="showListProject" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;">
        <tr class="new_post">
        <td >
            &nbsp<!--<asp:Image ID="img_status" runat="server" ImageUrl="images/projecticon.gif" width="20" Height="20"/>-->
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
        </HeaderTemplate>
        <ItemTemplate>
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
                        Bài viết mới
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
                    <td rowspan=7>
                        <a href="request.aspx" class="btn">Tặng sách</a>  <a href="#" class="btn">Tham gia dự án</a> <a href='<%#Eval("ID","post_news.aspx?projectID={0}")%>' class="btn">Viết bài</a>  <a href="show_allbum.aspx" class="btn">Hình ảnh</a>
                    </td>
                    </tr>
                    <tr>
                    <td><asp:Image ID="Image1" runat="server" ImageUrl="images/heart.gif" width="10" Height="10"/>
                        Số sách đã quyên góp được: 100 quyển
                    </td>
                    </tr>
                    <tr>
                    <td class="link_format"><asp:Image ID="Image2" runat="server" ImageUrl="images/heart.gif" width="10" Height="10"/>
                        Danh sách quyên góp: [<a href="#" >xem</a>]
                    </td>
                    </tr>
                    <tr>
                    <td class="link_format"><asp:Image ID="Image4" runat="server" ImageUrl="images/heart.gif" width="10" Height="10"/>
                        Danh sách tham gia dự án: [<a href='<%#Eval("ID","member_list_project.aspx?id={0}")%>' >xem</a>]
                    </td>
                    </tr>
                    <tr>
                    <td class="link_format"><asp:Image ID="Image5" runat="server" ImageUrl="images/heart.gif" width="10" Height="10"/>
                        Báo cáo tổng kết dự án: [<a href="#" >xem</a>]
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
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>   
</asp:Content>