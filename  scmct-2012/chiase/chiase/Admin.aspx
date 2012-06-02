<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="chiase.Admin" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <asp:Panel ID="pn_addmin_main" runat="server" Visible="false">

<fieldset style="background-color:#0066FF">
    <table border=0 cellpadding =0 cellspacing=0 width =100%>
    <tr>
    <td>
        <asp:Panel ID="pn_project" runat="server" >
                <div style="margin-bottom:5px;" class="admin">
                <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                <tr><td align="left"><b>Quản lý dự án</b></td></tr>
                <tr>
                <td align="right"><hr>
                    <asp:Label ID="lbl_create_new_project" runat="server">
                            <a style='cursor:pointer' class="btn_admin" id="new_project">Tạo dự án mới</a>
                    </asp:Label>
                    <asp:Label ID="lbl_search_project" runat="server">
                            <a href="search_project.aspx" class="btn_admin">Cập nhật dự án</a>
                    </asp:Label>
                    <asp:Label ID="lbl_add_member_project" runat="server">
                            <a style='cursor:pointer'  class="btn_admin" id="add_member_project" >Nhân sự cho dự án</a>
                    </asp:Label>
                    <asp:Label ID="lbl_create_new_status" runat="server">
                            <a style="cursor:pointer" class="btn_admin" id="create_new_status_project">Trạng thái mới</a>
                    </asp:Label>
                    <asp:Label ID="lbl_search_status_project" runat="server">
                            <a href="search_status_project.aspx" class="btn_admin">Cập nhật trạng thái</a>
                    </asp:Label>


                           <!-- <a href="#" class="btn_admin">Tìm kiếm</a> -->
                    <hr>
                </td>
                </tr>
                </table>
            </div>


          
          </asp:Panel>
                             <dx:ASPxPopupControl ID="ASPxPopupControl7" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_status_project.aspx"
                            EnableViewState="False" PopupElementID="create_new_status_project"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="400px"
                            Height="340px" FooterText=""
                            HeaderText="Tạo trạng thái dự án mới" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl7" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>


           <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_project.aspx"
                            EnableViewState="False" PopupElementID="new_project"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="738px" FooterText=""
                            HeaderText="" ClientInstanceName="FeedPopupControl" 
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

                <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="add_member_project.aspx"
                            EnableViewState="False" PopupElementID="add_member_project"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="1000px"
                            Height="738px" FooterText=""
                            HeaderText="Thành viên cho dự án" ClientInstanceName="FeedPopupControl" 
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
          <!--</fieldset>-->
    </td>
    </tr>

    <tr>
    <td>
        <asp:Panel ID="pn_request" runat="server">
              <div style="margin-bottom:5px;" class="admin">
                <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                <tr><td align="left"><b>Quản lý yêu cầu tặng/xin sách</b></td></tr>
                <tr>
                <td align="right"><hr>
                    <asp:Label ID="lbl_new_request" runat="server">
                            <a href="request.aspx?vmode=admin" class="btn_admin">Tạo yêu cầu mới</a>
                    </asp:Label>
                    <asp:Label ID="lbl_search_request" runat="server">
                            <a href="search_request.aspx" class="btn_admin">Cập nhật yêu cầu</a>
                    </asp:Label>
                    <asp:Label ID="lbl_new_status_request" runat="server">
                            <a style="cursor:pointer" class="btn_admin" id="create_new_status_request">Trạng thái mới</a>
                    </asp:Label>
                    <asp:Label ID="lbl_search_status_request" runat="server">
                            <a href="search_status_request.aspx" class="btn_admin">Cập nhật trạng thái</a>
                    </asp:Label>
                    <asp:Label ID="lbl_new_kind_request" runat="server">
                            <a style="cursor:pointer" class="btn_admin" id="create_new_kind_request">Loại YC mới</a>
                    </asp:Label>
                    <asp:Label ID="lbl_search_kind_request" runat="server">
                            <a href="search_kind_request.aspx"  class="btn_admin">Cập nhật loại YC</a>
                    </asp:Label>

                           <!-- <a href="#" class="btn_admin">Tìm kiếm</a> -->
                    <hr>
                </td>
                </tr>
                </table>
            </div>
            </asp:Panel>
                                           <dx:ASPxPopupControl ID="ASPxPopupControl6" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_kind_request.aspx"
                            EnableViewState="False" PopupElementID="create_new_kind_request"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="400px"
                            Height="340px" FooterText=""
                            HeaderText="Tạo loại yêu cầu mới" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl6" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>
                               <dx:ASPxPopupControl ID="ASPxPopupControl5" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_status_request.aspx"
                            EnableViewState="False" PopupElementID="create_new_status_request"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="400px"
                            Height="340px" FooterText=""
                            HeaderText="Tạo trạng thái yêu cầu mới" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>

            <!--
          <fieldset style="background-color: #010005;">
          <legend>   Quản lý yêu cầu tặng/yêu cầu trợ giúp sách    </legend>


          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a href="request.aspx?vmode=admin" class="btn">Tạo yêu cầu mới</a>
                <a href="search_request.aspx" class="btn">Cập nhật yêu cầu</a>
                <a href="#" class="btn">Tạo mới trạng thái</a>
                <a href="#" class="btn">Cập nhật trạng thái</a>
                <a href="#" class="btn">Tìm kiếm</a>
            </td>
           </tr>
           </table>

           </fieldset>
           -->
    </td>
    </tr>
   
    <tr>
    <td>
        <asp:Panel ID="pn_news" runat="server">
                <div style="margin-bottom:5px;" class="admin">
                <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                <tr><td align="left"><b>Quản lý chủ đề/bài viết</b></td></tr>
                <tr>
                <td align="right"><hr>
                <asp:Label ID="lbl_create_new_subject" runat="server">
                        <a style="cursor:pointer" class="btn_admin" id="create_new_subject">Tạo chủ đề</a>
                        </asp:Label>
                <asp:Label ID="lbl_search_subject" runat="server">
                        <a href="search_subject.aspx" class="btn_admin">Quản lý chủ đề</a>
                        </asp:Label>
                <asp:Label ID="lbl_search_post_news" runat="server">
                        <a href="search_post_news.aspx" class="btn_admin">Quản lý bài viết</a>
                        </asp:Label>
                <asp:Label ID="lbl_hot_news" runat="server">
                        <a href="hot_news.aspx" class="btn_admin">Bài viết nổi bật</a>
                        </asp:Label>
                <asp:Label ID="lbl_create_new_status_news" runat="server">
                        <a style="cursor:pointer" class="btn_admin" id="create_new_status_news">Trạng thái mới</a>
                        </asp:Label>
                <asp:Label ID="lbl_search_status_news" runat="server">
                        <a href="search_status_news.aspx" class="btn_admin">Cập nhật trạng thái</a>
                        </asp:Label>
                 
                 <!--       <a href="#" class="btn_admin">Tìm kiếm</a>-->
                    <hr>
                </td>
                </tr>
                </table>
                </div>
            </asp:Panel>
    <!--

           <fieldset style="background-color: #010005;">
          <legend>Quản lý bài viết</legend>
          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a style="cursor:pointer" class="btn" id="create_new_subject">Tạo chủ đề</a>
                <a href="#" class="btn">Quản lý chủ đề</a>
                <a href="#" class="btn">Quản lý bài viết</a>
                <a href="hot_news.aspx" class="btn">Quản lý bài viết nổi bật</a>
                <a href="#" class="btn">Tìm kiếm</a>



                




            </td>
           </tr>
           </table>
           </fieldset>
           -->
                   <dx:ASPxPopupControl ID="ASPxPopupControl4" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_status_news.aspx"
                            EnableViewState="False" PopupElementID="create_new_status_news"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="400px"
                            Height="340px" FooterText=""
                            HeaderText="Tạo trạng thái bài viết mới" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>

                           <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_subject.aspx"
                            EnableViewState="False" PopupElementID="create_new_subject"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="765px"
                            Height="738px" FooterText=""
                            HeaderText="Tạo chủ đề mới" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>
    </td>
    </tr>
    <tr>
    <td>

        <asp:Panel ID="pn_stock" runat="server">
        
                <div style="margin-bottom:5px;" class="admin">
                <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                <tr><td align="left"><b>Quản lý kho</b></td></tr>
                <tr>
                <td align="right">
                <hr />
                        <a href="web/ManageOfReceiver.aspx" class="btn_admin">Quản lý nhập kho</a>
                        <a href="web/ManageOfShipments.aspx" class="btn_admin">Quản lý xuất kho</a>
                        <a href="web/ManageOfTransfer.aspx" class="btn_admin">Quản lý chuyển kho</a>     
                       <hr />   
                        <a href="web/CategoryWarehouse.aspx" class="btn_admin">Danh mục kho</a>                       
                        <a href="web/CategoryItems.aspx" class="btn_admin">Danh mục hàng hóa</a>    
                        <a href="web/CategoryGroupItems.aspx" class="btn_admin">Danh mục chủng loại</a>  
                        <hr />
                
                </td>
                </tr>
                </table>
                </div>
            </asp:Panel>
<!--
           <fieldset style="background-color: #010005;">
          <legend>   Quản lý kho    </legend>
          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a href="ManageReceive.aspx" class="btn">Nhập kho</a>
                <a href="ManageShipments.aspx" class="btn">Xuất kho</a>
                <a href="#" class="btn">Điều chỉnh kho</a>
                <a href="#" class="btn">Chuyển kho</a>
                <a href="#" class="btn">Tạo kho mới</a>
                <a href="#" class="btn">Tìm kiếm</a>
            </td>
           </tr>
           </table>
           </fieldset>
           -->
    </td>
    </tr>
    <tr>
    <td>
        <asp:Panel ID="pn_finance" runat="server">
        
                <div style="margin-bottom:5px;" class="admin">
                <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                <tr><td align="left"><b>Quản lý thu chi</b></td></tr>
                <tr>
                <td align="right"><hr>
                <asp:Label ID="lbl_phieu_thu" runat="server">
                        <a href="phieu_thu.aspx" class="btn_admin">Tạo phiếu thu</a>
                        </asp:Label>
                <asp:Label ID="lbl_search_phieu_thu" runat="server">
                        <a href="search_phieu_thu.aspx" class="btn_admin">Cập nhật phiếu thu</a>
                        </asp:Label>
                <asp:Label ID="lbl_phieu_chi" runat="server">
                        <a href="phieu_chi.aspx" class="btn_admin">Tạo phiếu chi</a>
                        </asp:Label>
                <asp:Label ID="lbl_search_phieu_chi" runat="server">
                        <a href="search_phieu_chi.aspx" class="btn_admin">Cập nhật phiếu chi</a>
                        </asp:Label>
                        <!--<a href="search_pt_pc.aspx" class="btn_admin">Tìm kiếm</a>-->
                    <hr>
                </td>
                </tr>
                </table>
                </div>
            </asp:Panel>
    <!--
           <fieldset style="background-color: #010005;">
          <legend>Quản lý thu chi</legend>

          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a href="phieu_thu.aspx" class="btn">Tạo phiếu thu</a>
                <a href="search_phieu_thu.aspx" class="btn">Cập nhật phiếu thu</a>
                <a href="phieu_chi.aspx" class="btn">Tạo phiếu chi</a>
                <a href="search_phieu_chi.aspx" class="btn">Cập nhật phiếu chi</a>
                <a href="search_pt_pc.aspx" class="btn">Tìm kiếm</a>
            </td>
           </tr>
           </table>
           </fieldset>
           -->

    </td>
    </tr>

 <tr>
    <td>

        <asp:Panel ID="pn_users" runat="server">
       
                <div style="margin-bottom:5px;" class="admin">
                <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                <tr><td align="left"><b>Quản lý người dùng</b></td></tr>
                <tr>
                <td align="right"><hr>
                <asp:Label ID="lbl_create_new_members" runat="server">
                        <a href="create_new_members.aspx" class="btn_admin">Tạo mới</a>
                </asp:Label>
                <asp:Label ID="lbl_search_member_list" runat="server">
                        <a href="search_member_list.aspx" class="btn_admin">Cập nhật thành viên</a>
                </asp:Label>
                <asp:Label ID="lbl_create_new_group" runat="server">
                        <a style="cursor:pointer" class="btn_admin" id="create_new_group">Tạo nhóm mới</a>
                </asp:Label>
                <asp:Label ID="lbl_search_group_members" runat="server">
                        <a href="search_group_members.aspx" class="btn_admin">Cập nhật nhóm</a>
                </asp:Label>
                        <!--<a href="#" class="btn_admin">Tìm kiếm</a>-->
                    <hr>
                </td>
                </tr>
                </table>
                </div>
            </asp:Panel>
                 <dx:ASPxPopupControl ID="ASPxPopupControl8" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_group.aspx"
                            EnableViewState="False" PopupElementID="create_new_group"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="400px"
                            Height="340px" FooterText=""
                            HeaderText="Tạo nhóm người dùng" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl8" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>

                           <dx:ASPxPopupControl ID="ASPxPopupControl9" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_subject.aspx"
                            EnableViewState="False" PopupElementID="create_new_subject"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="765px"
                            Height="738px" FooterText=""
                            HeaderText="Tạo chủ đề mới" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl9" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>

<!--
          <fieldset style="background-color: #010005;">
          <legend>Quản lý người dùng</legend>


          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a href="#" class="btn">Tạo mới</a>
                <a href="#" class="btn">Cập nhật</a>
                <a href="#" class="btn">Tạo nhóm mới</a>
                <a href="#" class="btn">Cập nhật nhóm</a>
                <a href="#" class="btn">Tìm kiếm</a>
            </td>
           </tr>
           </table>
           </fieldset>
           -->
    </td>
    </tr>
    <tr>
    <td>
        <asp:Panel ID="pn_module" runat="server">
        
                <div style="margin-bottom:5px;" class="admin">
                <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                <tr><td align="left"><b>Quản lý chức năng</b></td></tr>
                <tr>
                <td align="right"><hr>
                <asp:Label ID="lbl_create_new_module" runat="server">
                        <a style="cursor:pointer" class="btn_admin" id="create_new_module">Chức năng mới</a>
                </asp:Label>
                <asp:Label ID="lbl_search_module_list" runat="server">
                        <a href="search_module_list.aspx" class="btn_admin">Cập nhật chức năng</a>
                </asp:Label>
                        <!--<a href="#" class="btn_admin">Tìm kiếm</a>-->
                    <hr>
                </td>
                </tr>
                </table>
                </div>
            </asp:Panel>
                    <dx:ASPxPopupControl ID="ASPxPopupControl10" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_module.aspx"
                            EnableViewState="False" PopupElementID="create_new_module"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="480px" FooterText=""
                            HeaderText="Tạo chức năng mới" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl10" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>


    <!--
           <fieldset style="background-color: #010005;">
          <legend>Quản lý quyền truy cập</legend>

          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a href="#" class="btn">Nhập chức năng</a>
                <a href="#" class="btn">Cập nhật chức năng</a>
                <a href="#" class="btn">Xét quyền</a>
                <a href="#" class="btn">Tìm kiếm</a>
            </td>
           </tr>
           </table>
           </fieldset>
           -->
    </td>
    </tr>
    <tr>
    <td>
        <asp:Panel ID="pn_access_right" runat="server">
                <div style="margin-bottom:5px;" class="admin">
                <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                <tr><td align="left"><b>Quản lý quyền truy cập</b></td></tr>
                <tr>
                <td align="right"><hr>
                <asp:Label ID="lbl_access_right_for_groups" runat="server">
                        <a href="access_right_for_groups.aspx" style="cursor:pointer" class="btn_admin" >Xét quyền cho nhóm thành viên</a>
                </asp:Label>
                <asp:Label ID="lbl_access_right_for_members" runat="server">
                        <a href="access_right_for_members.aspx" style="cursor:pointer" class="btn_admin">Xét quyền cho thành viên</a>
                </asp:Label>
                        <!--<a href="#" class="btn_admin">Tìm kiếm</a>-->
                    <hr>
                </td>
                </tr>
                </table>
                </div>
         </asp:Panel>
    </td>
    </tr>
        <tr>
    <td>
        <asp:Panel ID="pn_orther" runat="server">
                <div style="margin-bottom:5px;" class="admin">
                <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                <tr><td align="left"><b>Quản lý thông tin khác</b></td></tr>
                <tr>
                <td align="right"><hr>
                <asp:Label ID="lbl_update_info" runat="server">
                        <a href="info.aspx" style="cursor:pointer" class="btn_admin" >Cập nhật thông tin điều khoản,trợ giúp</a>
                </asp:Label>
                        <!--<a href="#" class="btn_admin">Tìm kiếm</a>-->
                    <hr>
                </td>
                </tr>
                </table>
                </div>
         </asp:Panel>
    </td>
    </tr>

    <tr>
    <td align=right style="color: White">
        <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
     </tr>

     </table>

    <br>&nbsp

    </fieldset>
</asp:Panel>

</asp:Content>

