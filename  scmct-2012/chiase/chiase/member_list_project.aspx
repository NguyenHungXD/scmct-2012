<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="member_list_project.aspx.cs" Inherits="chiase.member_list_project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<script>
    function backs() {
        window.close();
    }
    function PrintContents(div) {
        var DocumentContainer = document.getElementById(div);
        var WindowObject = window.open('', "TrackHistoryData",
                              "toolbars=no,scrollbars=no,status=no,resizable=no");
        WindowObject.document.write(DocumentContainer.innerHTML);
        //alert(ctrl);
        WindowObject.document.close();
        WindowObject.focus();
        WindowObject.print();
        WindowObject.close();
    }
</script>

<fieldset>
    <div id="mydiv">
        <table border="0" cellpadding="4" cellspacing="1" width="100%"  style="color:White;" >
        <tr>
        <td width="15%">
        Mã dự án:   
        </td>
        <td style="font-weight:bold;">
        <asp:Label ID="lbl_ma_du_an" runat="server"></asp:Label>
        </td>
        <td width="15%">
        Tên dự án:  
        </td>
        <td style="font-weight:bold;">
        <asp:Label ID="lbl_ten_du_an" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td width="15%">
        Bắt đầu:   
        </td>
        <td style="font-weight:bold;">
        <asp:Label ID="lbl_start_date" runat="server"></asp:Label>
        </td>
        <td width="15%">
        Kết thúc:  
        </td>
        <td style="font-weight:bold;">
        <asp:Label ID="lbl_end_date" runat="server"></asp:Label>
        </td>
        </tr>
        </table>


<asp:Repeater ID="showListmember" runat="server">
        
        <HeaderTemplate>
        <table border="0" cellpadding="0" cellspacing="1" width="100%"  style="border:1px solid #CCFFFF;">
                <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" 
                colspan="8">DANH SÁCH THAM GIA DỰ ÁN</td></tr>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td>
            <p>STT</p>
        </td>
        <td>
            Tên đăng nhập
        </td>
        <td>
            Tên thành viên
        </td>
        <td>
            Nhóm
        </td>
        <td>
            Vị trí
        </td>
         <td>
            Tim
        </td>
        <td>
            Tham gia
        </td>
        <td>
            Trạng thái
        </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr bgcolor="white" style="text-align:center;color:Black;font-weight:normal;">
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
        </ItemTemplate>
        <FooterTemplate>
        <tr>
        <td colspan="8">        <hr>
        <p align="right" style="color:White">&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %><br>&nbsp</p>
        </td>
        </tr>
        </table>
        </FooterTemplate>
        </asp:Repeater>  
        </div>
    <table>
    <tr>
    <td>
        <input id="Button3" type="button" value="In" class="btn" style="width:100px;height:25px" onclick="PrintContents('mydiv')" /> &nbsp
        <input id="Button4" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/>
    </td>
    </tr>
    </table>
        </fieldset>
</asp:Content>
