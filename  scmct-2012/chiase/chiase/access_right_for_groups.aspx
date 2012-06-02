<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="access_right_for_groups.aspx.cs" Inherits="chiase.access_right_for_group" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<fieldset >
    <script type="text/javascript">
        function return_link(id) {
            var windowname = 'mywindow' + id;
            var contentUrl = "create_access_right_for_group.aspx?id=" + id;
            window.open(contentUrl, windowname, 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
        }

        function backs() {
            window.location = "admin.aspx";
        }

    </script>

<fieldset>
    <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;">
        <tr style="color:White;font-weight:bold"><td colspan="8"><font size=3><p align="center">Tìm kiếm nhóm thành viên</p></font><br>*-Bạn có thể bỏ qua điều kiện bạn không quan tâm.</td></tr>
        <tr>
                    <td>
            Nhóm:
            </td>

            <td>
                <asp:DropDownList ID="dropd_group" runat="server" Width="250px" Height="25px">
                </asp:DropDownList>
        </td>
        <td>
            Tên nhóm:
            </td>
            <td >
        <asp:TextBox ID="txt_name" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td width="15%">
            Từ ngày:
            </td>
            <td>
            <dx:ASPxDateEdit ID="tu_ngay" runat="server" Width="250px" 
            ClientInstanceName="clientEdtStart" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            ShowShadow="False" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                    EditFormat="Custom" EditFormatString="dd/MM/yyyy" Height="25px">
            <CalendarProperties>
                <HeaderStyle Spacing="1px" />
                <FooterStyle Spacing="17px" />
            </CalendarProperties>
       
            <DropDownButton>
                <Image>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                        PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                </Image>
            </DropDownButton>
            <ValidationSettings>
                <ErrorFrameStyle ImageSpacing="4px">
                    <ErrorTextPaddings PaddingLeft="4px" />
                </ErrorFrameStyle>
            </ValidationSettings>
        </dx:ASPxDateEdit>
        </td>

                <td width="10%">
            Đến ngày:
            </td>
            <td>
            <dx:ASPxDateEdit ID="den_ngay" runat="server" Width="250px" 
            ClientInstanceName="clientEdtStart" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            ShowShadow="False" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" EditFormat="Custom" EditFormatString="dd/MM/yyyy" 
                    Height="25px">
            <CalendarProperties>
                <HeaderStyle Spacing="1px" />
                <FooterStyle Spacing="17px" />
            </CalendarProperties>
       
            <DropDownButton>
                <Image>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                        PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                </Image>
            </DropDownButton>
            <ValidationSettings>
                <ErrorFrameStyle ImageSpacing="4px">
                    <ErrorTextPaddings PaddingLeft="4px" />
                </ErrorFrameStyle>
            </ValidationSettings>
        </dx:ASPxDateEdit>
        </td>
        </tr>

        <tr>
        <td >
            Người tạo:
            </td>
            <td>
            <asp:TextBox ID="txt_created_by" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
        <td>&nbsp</td><td colspan="3">&nbsp
            <asp:Label ID="lbl_seach_group" runat="server">
            <asp:Button ID="btn_search" runat="server" Text="Tìm kiếm" class="btn" 
                Height="25px" onclick="btn_search_Click" Width="120px"  />
        </asp:Label>
        </td>
        </tr>
        </table>
</fieldset>
<hr>


    <asp:Repeater ID="group_list" runat="server" 
        onitemdatabound="group_list_ItemDataBound">
    <HeaderTemplate>
    <table border="0" cellpadding=3 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#990099" style="color:White;font-weight:bold"><td align="center" colspan="6">Danh sách nhóm thành viên</td></tr>
        <tr class="new_post">
        <td width="10%">
            STT
        </td>
        <td width="17%">
            Tên nhóm
        </td>
                        <td width="10%">
            Người tạo
        </td>
                <td width="10%">
            Ngày tạo
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor='#<%# Eval("bgcolors1")%><%# Eval("bgcolors")%>' >
                <td valign="middle" align="center">
            <%=vNo++ %>.<asp:Label ID="lbl_create_access_for_group" runat="server">
            <a style=cursor:pointer title='Cập nhật quyền cho nhóm người dùng' onclick=return_link('<%#Eval("groupid") %>')><img src=images/access_right.png width=30 height=30 alt='Cập nhật quyền cho nhóm người dùng'></a>
        </asp:Label>
        </td>
        <td align="left">
            <%# Eval("groupname")%>
        </td>
        <td>
            <%# Eval("created_by_name")%>
        </td>
                <td align="center">
            <%# Eval("created_date","{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    <tr>
    <td colspan="6" style="color:white;font-weight:bold">
    <br>
    <i><br>*-Nhóm thành viên đã xóa có nền màu vàng</i><i><br>*-Nhóm thành viên đã khóa có nền màu xanh</i><i><br>*-Nhóm thành viên đã khóa và xóa có nền màu xám đen</i><br>
        <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
        <input id="Button2" type="button" value="Hủy" style="width:120px;height:25px" class="btn" onclick="backs();"/><br>&nbsp
        
    </td>
    </tr>
    </table>
    </FooterTemplate>
    </asp:Repeater>
     <table width="100%">
     <tr align="right">
    <td colspan=3 align=right style="color:White">
    <br>&nbsp Hôm nay, br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>
</fieldset>


</asp:Content>
