<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_member_list.aspx.cs" Inherits="chiase.search_member_list" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
        <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<script type="text/JavaScript">
    function return_link(id) {
        var contentUrl = "create_new_members.aspx?id=" + id;
        window.open(contentUrl, 'mywindow', 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
    }
    function updates(obj) {
        var result = "";
        if (obj.value != "None") {
            var arr = obj.value.split(';');
            var url = "search_member_list.aspx?id=" + arr[0] + "&groupid=" + arr[1] + "&vmode=update_group";
            loadXMLUpdate(url);
            result = "Cập nhật nhóm thành viên thành công"
        } else {
            result = "Cập nhật nhóm thành viên không thành công"
        }
        document.getElementById("stausinfo").innerHTML = result;
    }
    function reset_password(val,username) {
        var url = "search_member_list.aspx?id=" + val + "&vmode=reset_pass";
        loadXMLUpdate(url);
        alert("Mật khẩu mới: " + username+"123");
    }
    function return_links(val) {
            var contentUrl = "user_info.aspx?id=" + val;
            var windowIndex = 1;
            var window = divpopup.GetWindow(windowIndex);
            divpopup.SetWindowContentUrl(window, contentUrl);
            alert(val);
    }

    function deletes(vmode) {
        var obj = document.forms["chiase"];
        var checked = false;
        if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để Đóng.")) {
            if (obj.chk.length > 0) {
                for (i = 0; i < obj.chk.length; i++) {
                    if (obj.chk[i].checked == true) {
                        var url = "search_member_list.aspx?id=" + obj.chk[i].value + "&vmode=" + vmode;
                        loadXMLUpdate(url);
                        checked = true;
                    }
                }
            }
            else {
                if (obj.chk.checked == true) {
                    var url = "search_member_list.aspx?id=" + obj.chk.value + "&vmode=" + vmode;
                    loadXMLUpdate(url);
                    checked = true;
                }
            }
            if (checked == false)
                if (vmode == "del")
                    document.getElementById("stausinfo").innerHTML = "Bạn chưa chọn thành viên cần xóa!"
                else if (vmode == "undel")
                    document.getElementById("stausinfo").innerHTML = "Bạn chưa chọn thành viên cần phục hồi!"
                else if (vmode == "lock")
                    document.getElementById("stausinfo").innerHTML = "Bạn chưa chọn thành viên cần khóa!"
                else {
                    document.getElementById("stausinfo").innerHTML = "Bạn chưa chọn thành viên cần mở khóa!"
                }
            else {
                if (vmode == "del")
                    document.getElementById("stausinfo").innerHTML = "Xóa thành viên thành công!"
                else if (vmode == "undel")
                    document.getElementById("stausinfo").innerHTML = "Phục thành viên hồi thành công!"
                else if (vmode == "lock")
                    document.getElementById("stausinfo").innerHTML = "Khóa thành viên thành công!"
                else
                    document.getElementById("stausinfo").innerHTML = "Mở khóa thành viên thành công!"
            }
        }
    }
    function backs() {
        window.location = "admin.aspx";
    }
</script>



<fieldset>
<fieldset>
    <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;">
        <tr style="color:White;font-weight:bold"><td colspan="8"><font size=3><p align="center">Tìm kiếm thành viên</p></font><br>*-Bạn có thể bỏ qua điều kiện bạn không quan tâm.</td></tr>
        <tr><td colspan=8><hr></td></tr>
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
        <tr><td colspan=8><hr></td></tr>
        <tr>
        <td>&nbsp</td><td colspan="3">&nbsp

            <asp:Label ID="lbl_search_members" runat="server">
         <asp:Button ID="Button4" runat="server"  Text="Tìm kiếm" class="btn" onclick="btn_search_Click" Height="25px" Width="100px"/>
         </asp:Label>
         <input id="Button7" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/>
        </td>
        </tr>
        </table>
</fieldset>

<asp:Repeater ID="member_list" runat="server" 
        onitemdatabound="member_list_ItemDataBound">
    <HeaderTemplate>
    <table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="8">DANH SÁCH NHÓM THÀNH VIÊN</td></tr>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="12%" colspan="2">
            <p>STT</p>
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
            Đăng nhập lần cuối
        </td>
                <td width="10%">
            Nhóm thành viên
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor='#<%# Eval("bgcolors1")%><%# Eval("bgcolors")%>' >
                <td valign="middle" align="center">
            <%= no++ %>.
                    <input name="chk" value="<%#Eval("id") %>" type="checkbox" />  
                    <asp:Label ID="lbl_edit_members" runat="server"><img src="images/edit.gif" width="25" height="25" style="cursor:pointer"  onclick=return_link('<%#Eval("id") %>') title='<%#Eval("ten_dn","Sửa thông tin thành viên: {0}") %>'> | <img src="images/reset_pass.png" width="25" height="25" style="cursor:pointer"  onclick=reset_password('<%#Eval("id") %>','<%#Eval("ten_dn") %>') title='<%#Eval("ten_dn","Reset password - Mật khẩu mới: {0}123") %>'> </asp:Label>
        </td>
        <td align="center">
        <asp:Image ID="Image1" ImageUrl='<%#Eval("avatar","images/avatars/{0}") %>' runat="server" Width="40" Height="40" BorderColor="Blue" BorderWidth="1" BorderStyle="Solid"/>
        </td>
       
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

        <td align="center">
            <%# Eval("lasted_access", "{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>
               <td>
                   <asp:Label ID="lbl_edit_group_members" runat="server">
                    <asp:DropDownList ID="dropd_groups" AutoPostBack="false" runat="server" Height="25px" class="selects" style="font-size:larger" onchange="updates(this);">
            </asp:DropDownList>
            </asp:Label>
                   <asp:Label ID="lbl_group_members" runat="server"></asp:Label>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    </asp:Repeater>
        <tr>
    <td colspan="6" style="color:white;font-weight:bold">
    
    <i>*-Chọn thành viên cần xóa/phục hồi/khóa/mở khóa</i>
    <i><br>*-Thành viên đã xóa có nền màu vàng</i>
    <i><br>*-Thành viên đã khóa có nền màu xanh</i>
    <i><br>*-Thành viên đã khóa và xóa có nền màu xám đen</i>
    <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
    <br>
        <asp:Label ID="lbl_del_members" runat="server">
            <input id="Button1" type="button" value="Xóa" class="btn" style="width:100px;height:25px" onclick="deletes('del');"/>
            <input id="Button3" type="button" value="Phục hồi" class="btn" style="width:100px;height:25px" onclick="deletes('undel');"/>
        </asp:Label>
        <asp:Label ID="lbl_lock_members" runat="server">
            <input id="Button5" type="button" value="Khóa" class="btn" style="width:100px;height:25px" onclick="deletes('lock');"/>
            <input id="Button6" type="button" value="Mở khóa" class="btn" style="width:100px;height:25px" onclick="deletes('unlock');"/>
        </asp:Label>
        <input id="Button2" type="button" value="Đóng" style="width:100px;height:25px" class="btn" onclick="backs();"/><br>&nbsp
    </td>
    </tr>
    </table>
     <table width="100%">
     <tr align="right">
    <td colspan=3 align=right style="color:White">
    <br>&nbsp Hôm nay,  nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>


    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>





    </fieldset>




</asp:Content>