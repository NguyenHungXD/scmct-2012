<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="chiase.Admin" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">


    <table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td>
         <fieldset>
          <legend>   Quản lí dự án    </legend>
          <table border=0 cellpadding =0 cellspacing=2 width =30% align="right">
          <tr>
          <td>

              <dx:ASPxButton ID="btn_add_new_project" runat="server" Text="Tạo dự án mới" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  onclick="btn_add_new_project_Click" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                  Width="150px">
              </dx:ASPxButton>
            </td>
            <td>
              <dx:ASPxButton ID="btn_update_project" runat="server" Text="Cập nhật dự án" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_update_member" runat="server" Text="Nhân sự cho dự án" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

              <td>
              <dx:ASPxButton ID="btn_find" runat="server" Text="Tìm kiếm" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
           </td>
           </tr>
           </table>

           </fieldset>
    </td>
    </tr>

    <tr>
    <td>
          <fieldset>
          <legend>   Quản lí yêu cầu tặng/yêu cầu trợ giúp sách    </legend>
          <table border=0 cellpadding =0 cellspacing=2 width =30% align="right">
          <tr>
          <td>

              <dx:ASPxButton ID="btn_create_new_request" runat="server" Text="Tạo yêu cầu mới" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                  Width="150px">
              </dx:ASPxButton>
            </td>
            <td>
              <dx:ASPxButton ID="btn_update_request" runat="server" Text="Cập nhật yêu cầu" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
              </td>

              
              <td>
                  <dx:ASPxButton ID="btn_create_new_request_status" runat="server" Text="Tạo mới trạng thái" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_update_request_status" runat="server" Text="Cập nhật trạng thái" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

              <td>
              <dx:ASPxButton ID="btn_find_request" runat="server" Text="Tìm kiếm" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
           </td>
           </tr>
           </table>
           </fieldset>
    </td>
    </tr>
    <tr>
    <td>
          <fieldset>
          <legend>   Quản lí người dùng    </legend>
          <table border=0 cellpadding =0 cellspacing=2 width =30% align="right">
          <tr>
          <td>

              <dx:ASPxButton ID="btn_create_new_user" runat="server" Text="Tạo mới" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                  Width="150px">
              </dx:ASPxButton>
            </td>
            <td>
              <dx:ASPxButton ID="btn_update_user" runat="server" Text="Cập nhật" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
              </td>

              
              <td>
                  <dx:ASPxButton ID="btn_create_new_user_group" runat="server" Text="Tạo nhóm mới" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_update_user_group" runat="server" Text="Cập nhật nhóm" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

              <td>
              <dx:ASPxButton ID="btn_find_user" runat="server" Text="Tìm kiếm" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
           </td>
           </tr>
           </table>
           </fieldset>
    </td>
    </tr>
    <tr>
    <td>

           <fieldset>
              
          <legend>   Quản lí bài viết    </legend>
           <table border=0 cellpadding =0 cellspacing=2 width =30% align="right">
          <tr>
          <td>

              <dx:ASPxButton ID="btn_create_new_subject" runat="server" Text="Tạo chủ đề" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                  Width="150px" onclick="btn_create_new_subject_Click">
              </dx:ASPxButton>
            </td>
            <td>
              <dx:ASPxButton ID="btn_update_subject" runat="server" Text="Quản lý chủ đề" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_post_news" runat="server" Text="Bài viết mới" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_manage_post" runat="server" Text="Quản lý bài viết" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

             <td>
              <dx:ASPxButton ID="btn_manage_cm" runat="server" Text="Quản lý phản hồi" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
            </td>

              <td>
              <dx:ASPxButton ID="btn_find_subject" runat="server" Text="Tìm kiếm" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
           </td>
           </tr>
           </table>
           </fieldset>

    </td>
    </tr>
    <tr>
    <td>

           <fieldset>
          <legend>   Quản lí kho    </legend>
                     <table border=0 cellpadding =0 cellspacing=2 width =30% align="right">
          <tr>
          <td>

              <dx:ASPxButton ID="btn_create_new_reciever" runat="server" Text="Nhập kho" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                  Width="150px">
              </dx:ASPxButton>
            </td>
            <td>
              <dx:ASPxButton ID="btn_issue_to" runat="server" Text="Xuất kho" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_pass_stock" runat="server" Text="Chuyển kho" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_adjust_stock" runat="server" Text="Điều chỉnh kho" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

             <td>
              <dx:ASPxButton ID="btn_create_new_stock" runat="server" Text="Tạo mới kho" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
            </td>

              <td>
              <dx:ASPxButton ID="btn_seach_stock" runat="server" Text="Tìm kiếm" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
           </td>
           </tr>
           </table>
           </fieldset>

    </td>
    </tr>
    <tr>
    <td>

           <fieldset>
          <legend>   Quản lí thu chi    </legend>
          <table border=0 cellpadding =0 cellspacing=2 width =30% align="right">
          <tr>
          <td>

              <dx:ASPxButton ID="btn_pt" runat="server" Text="Phiếu thu" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                  Width="150px">
              </dx:ASPxButton>
            </td>
            <td>
              <dx:ASPxButton ID="btn_pc" runat="server" Text="Phiếu chi" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_update_pt" runat="server" Text="Cập nhật phiếu thu" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_update_pc" runat="server" Text="Cập nhật phiếu chi" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

             <td>
              <dx:ASPxButton ID="btn_find_ptpc" runat="server" Text="Tìm kiếm" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
            </td>
           </tr>
           </table>
           </fieldset>

    </td>
    </tr>
    <tr>
    <td>

           <fieldset>
          <legend>   Quản lí quyền truy cập    </legend>
          <table border=0 cellpadding =0 cellspacing=2 width =30% align="right">
          <tr>
          <td>

              <dx:ASPxButton ID="btn_module" runat="server" Text="Thêm chức năng" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                  Width="150px">
              </dx:ASPxButton>
            </td>
            <td>
              <dx:ASPxButton ID="btn_update_module" runat="server" Text="Cập nhật chức năng" 
                  CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                  SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px">
              </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_set_right" runat="server" Text="Xét quyền" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

              <td>
                  <dx:ASPxButton ID="btn_find_module" runat="server" Text="Tìm kiếm" 
                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                      SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                      Width="150px">
                  </dx:ASPxButton>
              </td>

           </tr>
           </table>
           </fieldset>

    </td>
    </tr>
    <tr>
    <td  align=right >
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt") %>
    </td>
     </tr>
     </table>

    <br>&nbsp




</asp:Content>

