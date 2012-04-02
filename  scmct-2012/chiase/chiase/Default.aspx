﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="chiase._Default" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="content_slider" Runat="Server">
     <div id="templatemo_slider">
		<div id="featured" >
			<ul class="ui-tabs-nav">
				<li class="ui-tabs-nav-item ui-tabs-selected" id="nav-fragment-1"><a href="#fragment-1"><img src="images/content_slider/image1-small.jpg" alt="Image1small" /><span>Lorem ipsum dolor sit amet, consectetur adipiscing elit</span></a></li>
				<li class="ui-tabs-nav-item" id="nav-fragment-2"><a href="#fragment-2"><img src="images/content_slider/image2-small.jpg" alt="Image2small" /><span> Vestibulum ante ipsum primis in faucibus orci luctus et</span></a></li>
				<li class="ui-tabs-nav-item" id="nav-fragment-3"><a href="#fragment-3"><img src="images/content_slider/image3-small.jpg" alt="Image3small" /><span>Nullam commodo, lorem id varius hendrerit</span></a></li>
				<li class="ui-tabs-nav-item" id="nav-fragment-4"><a href="#fragment-4"><img src="images/content_slider/image4-small.jpg" alt="Image4small" /><span>Etiam congue, leo sit amet iaculis interdum</span></a></li>
			</ul>

			<!-- First Content -->
			<div id="fragment-1" class="ui-tabs-panel" style="">
				<img src="images/content_slider/image1.jpg" alt="Image 1" />
				<div class="info" >
					<h2><a href="#" >Lorem ipsum dolor sit amet, consectetur adipiscing elit</a></h2>
					<p>Praesent non nulla diam, a rutrum nisl. Quisque vehicula, lorem in ultrices porta, turpis diam ornare justo, in porttitor magna sem non eros....<a href="#" >read more</a></p>
				</div>
			</div>

			<!-- Second Content -->
			<div id="fragment-2" class="ui-tabs-panel ui-tabs-hide" style="">
				<img src="images/content_slider/image2.jpg" alt="Image 2" />
				<div class="info" >
					<h2><a href="#" >Vestibulum ante ipsum primis in faucibus orci luctus et</a></h2>
					<p>Vestibulum leo quam, accumsan nec porttitor a, euismod ac tortor. Sed ipsum lorem, sagittis non egestas id, suscipit....<a href="#" >read more</a></p>
				</div>
			</div>

			<!-- Third Content -->
			<div id="fragment-3" class="ui-tabs-panel ui-tabs-hide" style="">
				<img src="images/content_slider/image3.jpg" alt="Image 3" />
				<div class="info" >
					<h2><a href="#" >Nullam commodo, lorem id varius hendrerit</a></h2>
					<p>Nulla arcu turpis, ultricies a tempor at, vehicula consequat mi. Vivamus venenatis dui eget lacus adipiscing ornare. Praesent ultrices molestie nulla at semper. Morbi turpis lacus....<a href="#" >read more</a></p>
				</div>
			</div>

			<!-- Fourth Content -->
			<div id="fragment-4" class="ui-tabs-panel ui-tabs-hide" style="">
				<img src="images/content_slider/image4.jpg" alt="Image 4" />
				<div class="info" >
					<h2><a href="#" >Etiam congue, leo sit amet iaculis interdum</a></h2>
					<p>Quisque sed orci ut lacus viverra interdum ornare sed est. Donec porta, erat eu pretium luctus, leo augue sodales....<a href="#" >read more</a></p>
				</div>
			</div>
		</div>
</div> <!-- end of templatemo_slider -->
</asp:Content>

<asp:Content ID="register" ContentPlaceHolderID="content_area" Runat="Server">

<asp:DataList ID="DataList1" runat="server" Width="100%" 
        onitemdatabound="DataList1_ItemDataBound">
<HeaderTemplate>
    
    <table border=0 cellpadding=0 cellspacing=0 width=100%>
</HeaderTemplate>
    <ItemTemplate>
  
    <tr>
   
    <td colspan=3 align=right>
            <asp:HyperLink ID="link_post_new" runat="server" NavigateUrl='<%# Eval("id", "post_news.aspx?subjectID={0}") %>' Text="Bài mới"></asp:HyperLink>
    </td>
    </tr>
    <tr>
    <td colspan=3>
            <asp:Label ID="lbl_subject" runat="server" Text='<%# System.String.Format("{0}",Eval("title")) %>'></asp:Label>
    </td>
    </tr>
     <tr>
    <td colspan=3>
            <asp:Label ID="lbl_description" runat="server" Text='<%# System.String.Format("{0}",Eval("description")) %>'></asp:Label>
    </td>
    </tr>
    <tr>
    <td colspan=3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="5" GridLines="None" ShowHeader="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                    <table border=0 cellpadding=0 cellspacing=0 width=100%>
                                    <tr>
                                    <td>
                                            <asp:Label ID="lbl_subject" runat="server" Text='<%# Eval("tieu_de") %>'></asp:Label>
                                    
                                    <td>
                                    </td>
                                    </tr>
                                    </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
        </asp:GridView>
      </td>
      </tr>
     
    </ItemTemplate>
   
<FooterTemplate>
     </table>
<br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt") %>
</FooterTemplate>
    </asp:DataList>

</asp:Content>