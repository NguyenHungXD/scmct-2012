<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_group_members.aspx.cs" Inherits="chiase.search_group_members" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<fieldset >
    <script type="text/javascript">
        function update_request(id) {
            var contentUrl = "create_new_group.aspx?id=" + id;
            var windowIndex = 1;
            var window = divpopup.GetWindow(windowIndex);
            divpopup.SetWindowContentUrl(window, contentUrl);
            divpopup.ShowWindow(window);
        }
        function deletes(vmode) {
            var obj = document.forms["chiase"];
            var checked = false;
            if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để hủy.")) {
                if (obj.chk.length > 0) {
                    for (i = 0; i < obj.chk.length; i++) {
                        if (obj.chk[i].checked == true) {
                            var url = "search_group_members.aspx?id=" + obj.chk[i].value + "&vmode=" + vmode;
                            loadXMLUpdate(url);
                            checked = true;
                        }
                    }
                }
                else {
                    if (obj.chk.checked == true) {
                        var url = "search_group_members.aspx?id=" + obj.chk.value + "&vmode=" + vmode;
                        loadXMLUpdate(url);
                        checked = true;
                    }
                }
                if (vmode == "del") {
                    var error = "Bạn chưa chọn nhóm thành viên cần xóa!";
                    var result = "Xóa nhóm thành viên thành công!";
                } else if (vmode == "undel") {
                    var error = "Bạn chưa chọn nhóm thành viên cần phục hồi!";
                    var result = "Phục hồi nhóm thành viên thành công!";
                } else if (vmode == "lock") {
                    var error = "Bạn chưa chọn nhóm thành viên cần khóa!";
                    var result = "Khóa nhóm thành viên thành công!";
                } else if (vmode == "unlock") {
                    var error = "Bạn chưa chọn nhóm thành viên cần mở khóa!";
                    var result = "Mở khóa nhóm thành viên thành công!";
                }
                if (checked == false)
                    document.getElementById("stausinfo").innerHTML = error;
                else {
                    document.getElementById("stausinfo").innerHTML = result;
                }
            }
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
            <asp:Label ID="lbl_search_group_member" runat="server" >
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
            <%=vNo++ %>. 
            <input name="chk" value="<%#Eval("groupid") %>" type="checkbox" /><asp:Label ID="lbl_edit_members"
                runat="server"> | <a style=cursor:pointer title='Sửa nhóm người dùng' onclick=update_request('<%#Eval("groupid") %>')><img src=images/edit.gif width=25 height=25 alt='Cập nhật nhóm người dùng'></a> </asp:Label> 
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
 
    </FooterTemplate>
    </asp:Repeater>
       <tr>
    <td colspan="6" style="color:white;font-weight:bold"><br>
    <i>*-Chọn nhóm thành viên cần xóa/phục hồi/khóa/mở khóa</i>
    <i><br>*-Nhóm thành viên đã xóa có nền màu vàng</i>
    <i><br>*-Nhóm thành viên đã khóa có nền màu xanh</i>
    <i><br>*-Nhóm thành viên đã khóa và xóa có nền màu xám đen</i>
        <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
        <asp:Label ID="lbl_del_members" runat="server">
            <input id="Button1" type="button" value="Xóa nhóm" class="btn" style="width:125px;height:25px" onclick="deletes('del')"/>
            <input id="Button3" type="button" value="Phục hồi nhóm" class="btn" style="width:125px;height:25px" onclick="deletes('undel')"/>
        </asp:Label>
        <asp:Label ID="lbl_lock_members" runat="server">
            <input id="Button4" type="button" value="Khóa nhóm" class="btn" style="width:125px;height:25px" onclick="deletes('lock')"/>
            <input id="Button5" type="button" value="Mở khóa nhóm" class="btn" style="width:125px;height:25px" onclick="deletes('unlock')"/>
        </asp:Label>
        <input id="Button2" type="button" value="Hủy" style="width:120px;height:25px" class="btn" onclick="backs();"/><br>&nbsp
        
    </td>
    </tr>
    </table>
     <table width="100%">
     <tr align="right">
    <td colspan=3 align=right style="color:White">
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server"
                    AllowDragging="false" AllowResize="True" ClientInstanceName="divpopup"
                            CloseAction="CloseButton" 
                            EnableViewState="False" PopupElementID='divdetail'
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="400px"
                            Height="310px" FooterText=""
                            HeaderText="Cập nhật trạng thái yêu cầu" 
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
                                                                    <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />
                            </dx:ASPxPopupControl>
</fieldset>


</asp:Content>
