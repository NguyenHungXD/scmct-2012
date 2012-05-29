<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="my_page.aspx.cs" Inherits="chiase.my_page" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<fieldset>
    <script type="text/javascript">
        function backs() {

            window.location="default.aspx";

        }
        function delete_request()
        {
            var obj = document.forms["chiase"];
            var checked = false;
            if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để hủy.")) {
                if (obj.chk.length > 0) {
                    for (i = 0; i < obj.chk.length; i++) {
                        if (obj.chk[i].checked == true) {
                            var url = "my_page.aspx?id=" + obj.chk[i].value + "&vmode=del";
                            loadXMLUpdate(url);
                            checked = true;
                        }
                    }
                }
                else {
                    if (obj.chk.checked == true) {
                        var url = "my_page.aspx?id=" + obj.chk.value + "&vmode=del";
                        loadXMLUpdate(url);
                        checked = true;
                    }
                }
                if (checked == false)
                    document.getElementById("stausinfo").innerHTML = "Bạn chưa chọn yêu cầu cần xóa!"
                else
                    document.getElementById("stausinfo").innerHTML = "Xóa thành công!"
            }
        
        }

        function update_request(id) {
            var contentUrl = "edit_request.aspx?id=" + id;
            var windowIndex = 1;
            var window = divpopup.GetWindow(windowIndex);
            divpopup.SetWindowContentUrl(window, contentUrl);
            divpopup.ShowWindow(window);
        }
    </script>
    <asp:Repeater ID="request_list" runat="server">
    <HeaderTemplate>
    <table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#990099" style="color:White;font-weight:bold"><td align="center" colspan="6">Danh sách yêu cầu</td></tr>
        <tr class="new_post">
        <td width="13%">
            STT
        </td>
        <td width="17%">
            Tiêu đề
        </td>
        <td width="40%">
            Nội dung
        </td>
        <td width="10%">
            Loại yêu cầu
        </td>

        <td width="10%">
            Ngày tạo
        </td>
                <td width="10%">
            Trạng thái
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor="white">
                <td valign="middle" align="left">
            <%= no++ %> <%# Eval("del_request")%> 
        </td>
        <td>
            <%# Eval("tieu_de")%>
        </td>
        <td>
            <%# Eval("noi_dung")%>
        </td>
        <td align="center">
            <%# Eval("ten_loai_yc")%>
        </td>
        <td align="center">
            <%# Eval("ngay_yeu_cau","{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>
        <td align="center">
             <%# Eval("name")%>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    <tr>
    <td colspan="6" style="color:white;font-weight:bold"><br>
    <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
        *-Bạn có thể xóa hoặc sửa yêu cầu nếu yêu cầu đang chờ duyệt.<br>
        *-Chọn yêu cầu bạn muốn xóa.<br><br>
        <input id="Button1" type="button" value="Xóa yêu cầu" class="btn" style="width:120px;height:30px" onclick="delete_request();"/><input id="Button2" type="button" value="Hủy" style="width:120px;height:30px" class="btn" onclick="backs();"/><br>&nbsp
    </td>
    </tr>
    </table>
    </FooterTemplate>
    </asp:Repeater>
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
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
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
