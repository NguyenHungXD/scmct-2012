<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_request.aspx.cs" Inherits="chiase.search_request" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<fieldset >
    <script type="text/javascript">
        function updates(obj, vmode) {
            var result = "";
            if (obj.value != "None") {
                var arr = obj.value.split(';');
                var v_mode = "";

                if (vmode == '1') { //update kind of request
                    v_mode = "update_kind_request";
                    result = "Cập nhật loại yêu cầu thành công"
                } else { //Update request status
                    v_mode = "update_request_status";
                    result = "Cập nhật trạng thái yêu cầu thành công"
                }
                var url = "search_request.aspx?id=" + arr[0] + "&ids=" + arr[1] + "&vmode=" + v_mode;
                loadXMLUpdate(url);

            } else {
                result="Cập nhật không thành công"
            }
            document.getElementById("stausinfo").innerHTML = result;
        }
        function update_request(id) {
            var contentUrl = "edit_request.aspx?id=" + id;
            var windowIndex = 1;
            var window = divpopup.GetWindow(windowIndex);
            divpopup.SetWindowContentUrl(window, contentUrl);
            divpopup.ShowWindow(window);
        }

        function deletes(vmode) {
            var obj = document.forms["chiase"];
            var checked = false;
            if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để Đóng.")) {
                if (obj.chk.length > 0) {
                    for (i = 0; i < obj.chk.length; i++) {
                        if (obj.chk[i].checked == true) {
                            var url = "search_request.aspx?id=" + obj.chk[i].value + "&vmode=" + vmode;
                            loadXMLUpdate(url);
                            checked = true;
                        }
                    }
                }
                else {
                    if (obj.chk.checked == true) {
                        var url = "search_request.aspx?id=" + obj.chk.value + "&vmode=" + vmode;
                        loadXMLUpdate(url);
                        checked = true;
                    }
                }
                if (vmode == "del") {
                    var error = "Bạn chưa chọn yêu cầu cần xóa!";
                    var result = "Xóa thành công!";
                } else {
                    var error = "Bạn chưa chọn yêu cầu cần phục hồi!";
                    var result = "Phục hồi thành công!";
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
    <table border="0" cellpadding=3 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;">
        <tr style="color:White;font-weight:bold"><td colspan="8"><font size=3><p align="center">Tìm kiếm chủ đề</p></font><br>*-Bạn có thể bỏ qua điều kiện bạn không quan tâm.</td></tr>
        <tr><td colspan=5><hr></td></tr>

        <tr>
        <td>
            Tiêu đề:
            </td>
            <td>
        <asp:TextBox ID="txt_title" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>

        <td>
            Nội dung:
            </td>
            <td >
        <asp:TextBox ID="txt_description" runat="server" class="txtformat" Height="25px" 
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
            <td>
            Loại yêu cầu:
            </td>

            <td>
                <asp:DropDownList ID="dropd_kind_request" runat="server" Width="250px" Height="25px">
                </asp:DropDownList>
        </td>
                    <td>
            Trạng thái:
            </td>

            <td>
                <asp:DropDownList ID="dropd_status" runat="server" Width="250px" Height="25px">
                </asp:DropDownList>
        </td>
        </tr>
                <tr>
        <td >
            Người tạo:
            </td>
            <td colspan="3">
            <asp:TextBox ID="txt_created_by" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
            </td>
            </tr>
            <tr><td colspan=5><hr></td></tr>
        <tr>
        <td>&nbsp</td><td colspan="3">&nbsp<br>
        <asp:Label ID="lbl_search_request" runat="server">
                <asp:Button ID="Button2" runat="server" Text="Tìm kiếm" class="btn" Height="25px" Width="120px" onclick="btn_search_Click"/>
        </asp:Label>
        <input id="Button4" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/>
        </td>
        </tr>
        </table>
</fieldset>

   <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="7">DANH SÁCH YÊU CẦU</td></tr>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="10%">
            <p>STT</p>
        </td>
        <td width="17%">
            Tiêu đề
        </td>
        <td width="25%">
            Nội dung
        </td>
                        <td width="13%">
            Người tạo
        </td>
                <td width="10%">
            Ngày tạo
        </td>
        <td width="10%">
            Loại yêu cầu
        </td>


                <td width="10%">
            Trạng thái
        </td>
        </tr>
    <asp:Repeater ID="request_list" runat="server" 
        onitemdatabound="request_list_ItemDataBound">
    <HeaderTemplate>
 
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor='#<%# Eval("bgcolors")%>'>
                <td valign="middle" align="center">
            <%= no++ %>. 
             <asp:Label ID="lbl_edit_request" runat="server"> <input name="chk" value="<%#Eval("yeu_cau_id") %>" type="checkbox" /> | 
                   <a style=cursor:pointer title='Sửa yêu cầu' onclick=update_request('<%#Eval("yeu_cau_id") %>')><img src=images/edit.gif width=20 height=20 alt='Cập nhật yêu cầu'></asp:Label>
        </td>
        <td>
            <%# Eval("tieu_de")%>
        </td>
        <td>
            <%# Eval("noi_dung")%>
        </td>
               <td>
            <%# Eval("requested_by")%>
        </td>
                <td align="center">
            <%# Eval("ngay_yeu_cau","{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>
        <td align="center">
            <asp:Label ID="lbl_edit_kind_request" runat="server">
                <asp:DropDownList ID="dropd_kind_request" runat="server" class="selects" onchange="updates(this,'1');">
                </asp:DropDownList>
            </asp:Label>
            <asp:Label ID="kind_request" runat="server" Text=""></asp:Label>
        </td>
     



        <td align="center">
        <asp:Label ID="lbl_status_request" runat="server">
            <asp:DropDownList ID="dropd_status" runat="server" class="selects" onchange="updates(this,'2');">
            </asp:DropDownList>
        </asp:Label>
        <asp:Label ID="status_request" runat="server" Text=""></asp:Label>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>

    </FooterTemplate>
    </asp:Repeater>
        <tr>
    <td colspan="6" style="color:white;font-weight:bold"><br>
        *-Yêu cầu có nền màu xám là yêu cầu đã xóa.<br>
        *-Chọn yêu cầu bạn muốn xóa.<br><br>
        <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
        <asp:Label ID="lbl_del_request" runat="server">
            <input id="Button1" type="button" value="Xóa yêu cầu" class="btn" style="width:120px;height:25px" onclick="deletes('del')"/>
            <input id="Button3" type="button" value="Phục hồi yêu cầu" class="btn" style="width:120px;height:25px" onclick="deletes('undel')"/>
        </asp:Label>
        <input id="Button1" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/><br>&nbsp
        
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
                    AllowDragging="True" AllowResize="True" ClientInstanceName="divpopup"
                            CloseAction="CloseButton" 
                            EnableViewState="False" PopupElementID='divdetail'
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="680px" FooterText=""
                            HeaderText="Cập nhật yêu cầu" 
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
