<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="chiase.Admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">


    <table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td>
         <fieldset>
          <legend>   Quản lí dự án    </legend>
          <table border=0 cellpadding =2 cellspacing=2 width =100%>
          <tr>
          <td>
            <asp:LinkButton ID="link_create_new_project" runat="server" 
                Text="Tạo dự án mới" onclick="link_create_new_project_Click"></asp:LinkButton> | 
                        <asp:LinkButton ID="link_associate_member_to_project" runat="server" 
                Text="Cập nhật thành viên cho dự án"></asp:LinkButton> | 
                        <asp:LinkButton ID="link_search_project" runat="server" 
                Text="Tìm kiếm"></asp:LinkButton>
           </td>
           <td>

           </td>
           <td>

           </td>
           </tr>
           <tr>
           <td colspan=3>
           Danh sách dự án: 
               <asp:DropDownList ID="dropd_lst_project" runat="server" 
                   onselectedindexchanged="dropd_lst_project_SelectedIndexChanged" 
                   AutoPostBack="True">
                            </asp:DropDownList> 
                 
               <asp:Label ID="lbl_project_name" runat="server" BackColor="#33CCCC" 
                   BorderStyle="None" BorderWidth="1px" ForeColor="White"></asp:Label>  
               <asp:Button ID="btn_view" runat="server" Text="Xem" Width="70px" 
                   class="btnformat" Height="25px" />
               <asp:Button ID="btn_update" runat="server" Text="Cập nhật" Width="70px" 
                   class="btnformat" Height="25px" />
               <asp:Button ID="btn_delete" runat="server" Text="Xóa" Width="70px" 
                   class="btnformat" Height="25px" />
         
           </td>
           </tr>
          
           <tr>
           <td colspan=3>
           <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
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
          <table border=0 cellpadding =2 cellspacing=2 width =100%>
          <tr>
          <td>
            <asp:LinkButton ID="link_update_request" runat="server" 
                Text="Tạo dự án mới" onclick="link_create_new_project_Click"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton17" runat="server" 
                Text="Cập nhật thành viên cho dự án"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton18" runat="server" 
                Text="Tìm kiếm"></asp:LinkButton>
           </td>
           <td>

           </td>
           <td>

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
          <table border=0 cellpadding =2 cellspacing=2 width =100%>
          <tr>
          <td>
            <asp:LinkButton ID="LinkButton1" runat="server" 
                Text="Tạo dự án mới" onclick="link_create_new_project_Click"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton2" runat="server" 
                Text="Cập nhật thành viên cho dự án"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton3" runat="server" 
                Text="Tìm kiếm"></asp:LinkButton>
           </td>
           <td>

           </td>
           <td>

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
          <table border=0 cellpadding =2 cellspacing=2 width =100%>
          <tr>
          <td>
              <asp:HyperLink ID="link_create_new_subject" runat="server" Text="Tạo chủ đề mới" NavigateUrl="create_new_subject.aspx"></asp:HyperLink>
             <asp:HyperLink ID="link_create_news" runat="server" NavigateUrl="post_news.aspx" Text="Đăng bài viết mới"></asp:HyperLink> | 
                        <asp:LinkButton ID="LinkButton5" runat="server" 
                Text="Cập nhật thành viên cho dự án"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton6" runat="server" 
                Text="Tìm kiếm"></asp:LinkButton>
           </td>
           <td>

           </td>
           <td>

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
          <table border=0 cellpadding =2 cellspacing=2 width =100%>
          <tr>
          <td>
            <asp:LinkButton ID="LinkButton7" runat="server" 
                Text="Tạo dự án mới" onclick="link_create_new_project_Click"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton8" runat="server" 
                Text="Cập nhật thành viên cho dự án"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton9" runat="server" 
                Text="Tìm kiếm"></asp:LinkButton>
           </td>
           <td>

           </td>
           <td>

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
          <table border=0 cellpadding =2 cellspacing=2 width =100%>
          <tr>
          <td>
            <asp:LinkButton ID="LinkButton10" runat="server" 
                Text="Tạo dự án mới" onclick="link_create_new_project_Click"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton11" runat="server" 
                Text="Cập nhật thành viên cho dự án"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton12" runat="server" 
                Text="Tìm kiếm"></asp:LinkButton>
           </td>
           <td>

           </td>
           <td>

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
          <table border=0 cellpadding =2 cellspacing=2 width =100%>
          <tr>
          <td>
            <asp:LinkButton ID="LinkButton13" runat="server" 
                Text="Tạo dự án mới" onclick="link_create_new_project_Click"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton14" runat="server" 
                Text="Cập nhật thành viên cho dự án"></asp:LinkButton> | 
                        <asp:LinkButton ID="LinkButton15" runat="server" 
                Text="Tìm kiếm"></asp:LinkButton>
           </td>
           <td>

           </td>
           <td>

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

