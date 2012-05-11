<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="member_list_project.aspx.cs" Inherits="chiase.member_list_project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<asp:Repeater ID="showListmember" runat="server">
        
        <HeaderTemplate>
        <table border="0" cellpadding="0" cellspacing="1" width="100%"  style="border:1px solid #CCFFFF;">
        <tr class="new_post">
        <td>
            STT
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
            <h6>Vị trí</h6>
        </td>
         <td>
            <h6>Tim</h6>
        </td>
                <td>
            <h6>Tham gia</h6>
        </td>
        <td>
            <h6>Trạng thái</h6>
        </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr class="new_post_details">
                    <td valign=middle align="center">
                    <%= noofcnt++%>
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
                        <%#Eval("post_name")%>
                    </td>
                    <td valign=middle align="center">
                            <asp:Label ID="lbl_sum_point" runat="server" Text='<%#Eval("heart")%>'></asp:Label>
                            <asp:Image ID="Image1" runat="server" ImageUrl="images/heart.gif" Width="10" Height="10"/>
                    </td>
                    <td valign=middle align="center">

                    <%#Eval("added_date", "{0:dd/MM/yyyy }")%>
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




</asp:Content>
