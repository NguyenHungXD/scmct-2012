<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="chiase.Admin" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">


    <table border=0 cellpadding =1 cellspacing=1 width =100%>
    <tr>
    <td>
         <fieldset style="background-color: #0099FF;">
          <legend>Quản lí dự án</legend>
          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a href="#" class="btn" id="new_project">Tạo dự án mới</a>
                <a href="search_project.aspx" class="btn">Cập nhật dự án</a>
                <a href="#" class="btn" id="add_member_project" >Nhân sự cho dự án</a>
                <a href="search_project.aspx" class="btn">Tìm kiếm</a>

                <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_project.aspx"
                            EnableViewState="False" PopupElementID="new_project"
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
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
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="1000px"
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
                                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>
          </td>
          </tr>
          </table>
          </fieldset>
    </td>
    </tr>

    <tr>
    <td>
          <fieldset style="background-color: #0099FF;">
          <legend>   Quản lí yêu cầu tặng/yêu cầu trợ giúp sách    </legend>


          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a href="#" class="btn">Tạo yêu cầu mới</a>
                <a href="#" class="btn">Cập nhật yêu cầu</a>
                <a href="#" class="btn">Tạo mới trạng thái</a>
                <a href="#" class="btn">Cập nhật trạng thái</a>
                <a href="#" class="btn">Tìm kiếm</a>
            </td>
           </tr>
           </table>

           </fieldset>
    </td>
    </tr>
    <tr>
    <td>
          <fieldset style="background-color: #0099FF;">
          <legend>Quản lí người dùng</legend>


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
    </td>
    </tr>
    <tr>
    <td>
           <fieldset style="background-color: #0099FF;">
          <legend>Quản lí bài viết</legend>
          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a href="#" class="btn" id="create_new_subject">Tạo chủ đề</a>
                <a href="#" class="btn">Quản lý chủ đề</a>
                <a href="#" class="btn">Quản lý bài viết</a>
                <a href="#" class="btn">Tìm kiếm</a>

                <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_subject.aspx"
                            EnableViewState="False" PopupElementID="create_new_subject"
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="1000px"
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
                                <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>

                




            </td>
           </tr>
           </table>
           </fieldset>

    </td>
    </tr>
    <tr>
    <td>
           <fieldset style="background-color: #0099FF;">
          <legend>   Quản lí kho    </legend>
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
    </td>
    </tr>
    <tr>
    <td>

           <fieldset style="background-color: #0099FF;">
          <legend>Quản lí thu chi</legend>

          <table border=0 cellpadding =0 cellspacing=2 width =100% align="right">
          <tr>
          <td valign="middle" align="right">
                <a href="#" class="btn">Phiếu thu</a>
                <a href="#" class="btn">Cập nhật phiếu thu</a>
                <a href="#" class="btn">Phiếu chi</a>
                <a href="#" class="btn">Cập nhật phiếu chi</a>
                <a href="#" class="btn">Tìm kiếm</a>
            </td>
           </tr>
           </table>
           </fieldset>

    </td>
    </tr>
    <tr>
    <td>

           <fieldset style="background-color: #0099FF;">
          <legend>Quản lí quyền truy cập</legend>

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

    </td>
    </tr>
    <tr>
    <td  align=right >
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
     </tr>
     </table>

    <br>&nbsp




</asp:Content>

