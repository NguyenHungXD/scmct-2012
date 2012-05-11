<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_project_member.aspx.cs" Inherits="chiase.search_project_member" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <fieldset>

    <asp:Repeater ID="showListmember" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding="0" cellspacing="1" width="100%"  style="border:1px solid #CCFFFF;">
        <tr class="new_post">
        <td >
            <img src="images/edit_icon.gif" width="20" height="20" alt="Cập nhật dự án"/>
        </td>
        <td>
            <h6>Tên đăng nhập</h6>
        </td>
        <td>
            <h6>Tên thành viên</h6>
        </td>
        <td>
            <h6>Nhóm</h6>
        </td>
        <td>
            <h6>Ngày tạo</h6>
        </td>
        <td>
            <h6>Vị trí</h6>
        </td>
         <td>
            <h6>Người tạo</h6>
        </td>
        <td>
            <h6>Trạng thái</h6>
        </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr class="new_post_details">
                    <td valign="middle" align="center">
                        <a href="#" title="Cập nhật"><img src="images/edit.gif" width="20" height="20" alt="Cập nhật dự án"/></a>
                     </td>
                    <td valign=middle align="center">
                    <%#Eval("username")%>
                    </td>
                    <td valign=middle align="center">
                    <%#Eval("name")%>
                    </td>
                    <td valign=middle align="center">
                    <%#Eval("groupname")%>
                    </td>
                    <td valign=middle align="center">

                    <%#Eval("added_date", "{0:dd/MM/yyyy }")%>
                    </td>
                    <td valign=middle align="center">
                        <%#Eval("post_name")%>
                    </td>
                    <td valign=middle align="center">
                        <%#Eval("added_name")%>
                    </td>
                    <td valign=middle align="center">
                        <%#Eval("status")%>
                    </td>
                    </tr>
                    <tr>
                    <td colspan="7">
                    </td>
                    </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>   


        </fieldset>


</asp:Content>
