<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_module_list.aspx.cs" Inherits="chiase.search_module_list" %>
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
            var contentUrl = "create_access_right_for_group.aspx?id=" + id;
            window.open(contentUrl, 'mywindow', 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
        }
        function update_request(id) {
            var contentUrl = "create_new_module.aspx?id=" + id;
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
                            var url = "search_module_list.aspx?id=" + obj.chk[i].value + "&vmode=" + vmode;
                            loadXMLUpdate(url);
                            checked = true;
                        }
                    }
                }
                else {
                    if (obj.chk.checked == true) {
                        var url = "search_module_list.aspx?id=" + obj.chk.value + "&vmode=" + vmode;
                        loadXMLUpdate(url);
                        checked = true;
                    }
                }
                if (vmode == "del") {
                    var error = "Bạn chưa chọn chức năng cần xóa!";
                    var result = "Xóa chức năng thành công!";
                } else if (vmode == "undel") {
                    var error = "Bạn chưa chọn chức năng cần phục hồi!";
                    var result = "Phục hồi chức năng thành công!";
                } else if (vmode == "lock") {
                    var error = "Bạn chưa chọn chức năng cần khóa!";
                    var result = "Khóa chức năng thành công!";
                } else if (vmode == "unlock") {
                    var error = "Bạn chưa chọn chức năng cần mở khóa!";
                    var result = "Mở khóa chức năng thành công!";
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
        <tr style="color:White;font-weight:bold"><td colspan="8"><font size=3><p align="center">Tìm kiếm trạng thái yêu cầu</p></font><br>*-Bạn có thể bỏ qua điều kiện bạn không quan tâm.</td></tr>
        <tr>
                    <td>
            Chọn chức năng:
            </td>

            <td>
                <asp:DropDownList ID="dropd_module" runat="server" Width="250px" Height="25px">
                </asp:DropDownList>
        </td>
        <td>
            Mã chức năng:
            </td>
            <td >
        <asp:TextBox ID="txt_featureid" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
                <tr>
        <td>
            Tên chức năng:
            </td>
            <td >
        <asp:TextBox ID="txt_name" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>

        <td>
            Chi tiết:
            </td>
            <td >
        <asp:TextBox ID="txt_desc" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
            Đường dẫn:
            </td>
            <td >
        <asp:TextBox ID="txt_access_path" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>

        <td>
            Code path:
            </td>
            <td >
        <asp:TextBox ID="txt_code_path" runat="server" class="txtformat" Height="25px" 
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
        
            <asp:Button ID="btn_search" runat="server" Text="Tìm kiếm" class="btn" 
                Height="25px" onclick="btn_search_Click" Width="120px"  />
        
        </td>
        </tr>
        </table>
</fieldset>
<hr>

    <p align="right">
        <asp:Label ID="lbl_create_module" runat="server">
    <input type="button" value="Chức năng mới" class="btn" style="width:135px;height:25px" id="create_new_module"/>
    </asp:Label>
    
    
    </p>

    <asp:Repeater ID="module_list" runat="server" 
        onitemdatabound="module_list_ItemDataBound">


    <HeaderTemplate>
    <table border="0" cellpadding=3 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#990099" style="color:White;font-weight:bold"><td align="center" colspan="7">Danh sách chức năng hệ thống</td></tr>
        <tr class="new_post">
        <td width="10%" align="center">
            STT
        </td>

        <td width="10%" align="center">
            Code setup<br>
            Mã chức năng
        </td>
                <td width="10%">
            Tên chức năng
        </td>
        <td width="17%" align="center">
            Chi tiết
        </td>

        <td width="8%" align="center">
            Đường dẫn
        </td>
                <td width="8%" align="center">
            Code path
        </td>
        <td width="10%" align="center">
            Người tạo<br>Ngày tạo
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor='#<%# Eval("bgcolors1")%><%# Eval("bgcolors")%>' >
                <td valign="middle" align="center">
            <%=vNo++ %>. 
            <input name="chk" value="<%#Eval("id") %>" type="checkbox" /><asp:Label ID="lbl_edit_module"
                runat="server">  | <a style=cursor:pointer title='Sửa nhóm người dùng' onclick=update_request('<%#Eval("id") %>')><img src=images/edit.gif width=25 height=25 alt='Cập nhật chức năng'></a></asp:Label>
        </td>
        <td align="center"><b>[<%# Eval("id")%>]<br>
            <%# Eval("featureid")%></b>
                    </td>
        <td>

             <%# Eval("name")%>
        </td>
        <td>
             <%# Eval("description")%>
        </td>
                <td align="center">
             <%# Eval("access_path")%>
        </td>
                <td align="center">
             <%# Eval("code_path")%>
        </td>
        <td align="center" >
            <%# Eval("created_by_name")%><br>
            <%# Eval("created_date","{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
  
    </FooterTemplate>
    </asp:Repeater>
      <tr>
    <td colspan="6" style="color:white;font-weight:bold"><br>
    <i>*-Chọn chức năng cần xóa/phục hồi/khóa/mở khóa</i>
    <i><br>*-Chức năng đã xóa có nền màu vàng</i>
    <i><br>*-Chức năng đã khóa có nền màu xanh</i>
    <i><br>*-Chức năng đã khóa và xóa có nền màu xám đen</i>
        <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
        <asp:Label ID="lbl_del_module" runat="server">
        <input id="Button1" type="button" value="Xóa chức năng" class="btn" style="width:135px;height:25px" onclick="deletes('del')"/>
        <input id="Button3" type="button" value="Phục hồi chức năng" class="btn" style="width:135px;height:25px" onclick="deletes('undel')"/>
        </asp:Label>
        <asp:Label ID="lbl_lock_module" runat="server">
        <input id="Button4" type="button" value="Khóa chức năng" class="btn" style="width:135px;height:25px" onclick="deletes('lock')"/>
        <input id="Button5" type="button" value="Mở khóa chức năng" class="btn" style="width:135px;height:25px" onclick="deletes('unlock')"/>
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
       <dx:ASPxPopupControl ID="ASPxPopupControl10" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_module.aspx"
                            EnableViewState="False" PopupElementID="create_new_module"
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="480px" FooterText=""
                            HeaderText="Tạo chức năng mới" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl10" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />
                            </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server"
                    AllowDragging="false" AllowResize="True" ClientInstanceName="divpopup"
                            CloseAction="CloseButton" 
                            EnableViewState="False" PopupElementID='divdetail'
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="480px" FooterText=""
                            HeaderText="Cập nhật chức năng" 
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
