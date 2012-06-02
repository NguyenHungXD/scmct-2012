<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="access_right_for_members.aspx.cs" Inherits="chiase.access_right_for_members" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
        <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<script type="text/JavaScript">
    function return_link(id) {
        var windowname = 'mywindow' +id;
        var contentUrl = "create_access_right_for_member.aspx?id=" + id;
        window.open(contentUrl, windowname, 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
    }

    function return_links(id) {
        var windowname = 'mywindow' + id;
        var contentUrl = "create_access_right_for_group.aspx?id=" + id;
        window.open(contentUrl, windowname, 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
    }

    function backs() {
        window.location = "admin.aspx";
    }
</script>



<fieldset>
<fieldset>
    <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;">
        <tr style="color:White;font-weight:bold"><td colspan="8"><font size=3><p align="center">Tìm kiếm thành viên</p></font><br>*-Bạn có thể bỏ qua điều kiện bạn không quan tâm.</td></tr>
        <tr>
        <td >
            Tên đăng nhập: 
            </td><td>
                             <asp:TextBox ID="txt_tendangnhap" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>

        </td>

        <td>
            Họ tên:
            </td>
            <td>
        <asp:TextBox ID="txt_hoten" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
                <tr>
        <td>
            Địa chỉ:
            </td>
            <td>
        <asp:TextBox ID="txt_diachi" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>

        <td>
            Email:
            </td>
            <td>
        <asp:TextBox ID="txt_email" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
                               <tr>
        <td>
            Yahoo/skype/phone/fax:
            </td>
            <td>
        <asp:TextBox ID="txt_skype" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>

        <td>
            Sở thích:
            </td>
            <td>
        <asp:TextBox ID="txt_sothich" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
             <tr>
        <td>
            Nhóm thành viên:
            </td>
            <td>
                    <asp:DropDownList ID="dropd_group" AutoPostBack="false" runat="server" Height="30px" Width="250px" style="font-size:larger"  >
            </asp:DropDownList>
        </td>
        <td>
            Người tạo:
            </td>
            <td>
        <asp:TextBox ID="txt_nguoitao" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>

        <tr>
        <td width="15%">Ngày tạo:<br>
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
        <td>&nbsp</td><td colspan="3">&nbsp
            <asp:Label ID="lbl_search_members" runat="server">
         <asp:Button ID="Button4" runat="server"  Text="Tìm kiếm" class="btn" onclick="btn_search_Click" Height="25px" Width="100px"/>
         </asp:Label>
        </td>
        </tr>
        </table>
</fieldset>
<hr>
<asp:Repeater ID="member_list" runat="server" 
        onitemdatabound="member_list_ItemDataBound">
    <HeaderTemplate>
    <table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#990099" style="color:White;font-weight:bold"><td align="center" colspan="8">Danh sách thành viên</td></tr>
        <tr class="new_post">
        <td width="20%" colspan="2">
            STT
        </td>
 
        <td width="10%">
            Tên đăng nhập/Tên thành viên
        </td>

        <td width="10%">
            Số điện thoại/Địa chỉ
        </td>
        <td width="10%">
            Người tạo/ngày tạo
        </td>
                <td width="10%">
            Nhóm thành viên
        </td>
  
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor='#<%# Eval("bgcolors1")%><%# Eval("bgcolors")%>' >
                <td valign="middle" align="center">
            <%= no++ %>.<asp:Label ID="lbl_access_for_group" runat="server">
               <a style=cursor:pointer title='Cập nhật quyền cho người dùng' onclick=return_link('<%#Eval("id") %>')><img src=images/member_access.png width=30 height=30 alt='Cập nhật quyền cho người dùng'></a> </asp:Label>
                    <asp:Label ID="lbl_access_member" runat="server">
        | <a style=cursor:pointer title='Cập nhật quyền cho nhóm người dùng' onclick=return_links('<%#Eval("groupid") %>')><img src=images/access_right.png width=30 height=30 alt='Cập nhật quyền cho nhóm người dùng'></a>
        </asp:Label>
        </td>
        <td align="center">
        <asp:Image ID="Image1" ImageUrl='<%#Eval("avatar","images/avatars/{0}") %>' runat="server" Width="40" Height="40" BorderColor="Blue" BorderWidth="1" BorderStyle="Solid"/>
       <br><i> Lần cuối:<%# Eval("lasted_access", "{0:dd/MM/yyyy hh:mm:ss tt}")%></i></td>
       
           <td align="center" >
             <a style="color:Blue;cursor:pointer" id='<%#Eval("id","divdetail{0}")%>' title='<%#Eval("ten_dn","Xem chi tiết thông tin: {0}") %>' ><%# Eval("ten_dn")%></a>
        <br><%#Eval("name") %>


            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server"
                    AllowDragging="True" AllowResize="True" ClientInstanceName="divpopup"
                            CloseAction="CloseButton" contentUrl='<%#Eval("id","user_info.aspx?id={0}")%>'  
                            EnableViewState="False" PopupElementID='<%#Eval("id","divdetail{0}")%>'
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="610px" FooterText=""
                            HeaderText="SCMCT-Thông tin chi tiết thành viên" 
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
                <td align="center">
                <%# Eval("phone")%><br>
            <%# Eval("address")%>
        </td>

        <td align="center">
            <%# Eval("nguoi_tao")%><br>
           <%# Eval("created_date","{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>


               <td>
                <%# Eval("groupname")%> 
        </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
    <tr>
    <td colspan="6" style="color:white;font-weight:bold">
 <br>
    <i><br>*-Thành viên đã xóa có nền màu vàng</i><i><br>*-Thành viên đã khóa có nền màu xanh</i><i><br>*-Thành viên đã khóa và xóa có nền màu xám đen</i><br><br>
        <input id="Button2" type="button" value="Hủy" style="width:100px;height:25px" class="btn" onclick="backs();"/><br>&nbsp
    </td>
    </tr>
    </table>
    </FooterTemplate>
    </asp:Repeater>
     <table width="100%">
     <tr align="right">
    <td colspan=3 align=right style="color:White">
    <br>&nbsp Hôm nay,  nay,    <br>&nbsp Hôm nay,  nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>


    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>





    </fieldset>




</asp:Content>
