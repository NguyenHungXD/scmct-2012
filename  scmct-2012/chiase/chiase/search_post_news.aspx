<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_post_news.aspx.cs" Inherits="chiase.search_post_news" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<fieldset >
    <script type="text/javascript">
        function updates(obj) {
            var result = "";
            if (obj.value != "None") {
                var arr = obj.value.split(';');
                var url = "search_post_news.aspx?id=" + arr[0] + "&status_id=" + arr[1] + "&vmode=update_news_status";
                loadXMLUpdate(url);
                result = "Cập nhật trạng thái thành công"
            } else {
                result = "Cập nhật không thành công"
            }
            document.getElementById("stausinfo").innerHTML = result;
        }

        function update_request(id) {
            var contentUrl = "post_news.aspx?post_id=" + id;
            window.open(contentUrl, 'mywindow', 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
        }

        function deletes(vmode) {
            var obj = document.forms["chiase"];
            var checked = false;
            if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để Đóng.")) {
                if (obj.chk.length > 0) {
                    for (i = 0; i < obj.chk.length; i++) {
                        if (obj.chk[i].checked == true) {
                            var url = "search_post_news.aspx?id=" + obj.chk[i].value + "&vmode=" + vmode;
                            loadXMLUpdate(url);
                            checked = true;
                        }
                    }
                }
                else {
                    if (obj.chk.checked == true) {
                        var url = "search_post_news.aspx?id=" + obj.chk.value + "&vmode=" + vmode;
                        loadXMLUpdate(url);
                        checked = true;
                    }
                }
                if (vmode == "del") {
                    var error = "Bạn chưa chọn bài viết cần xóa!";
                    var result = "Xóa bài viết thành công!";
                } else {
                    var error = "Bạn chưa chọn bài viết cần phục hồi!";
                    var result = "Phục hồi bài viết thành công!";
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
        <tr style="color:White;font-weight:bold"><td colspan="8"><font size=3><p align="center">Tìm kiếm bài viết</p></font><br>*-Bạn có thể bỏ qua điều kiện bạn không quan tâm.</td></tr>
        <tr><td colspan=5><hr></td></tr>

        <tr>
        <td>
            Tiêu đề:
            </td>
            <td >
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
            Chủ đề:
            </td>

            <td>
                <asp:TextBox ID="txt_subject" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
                    <td>
            Dự án:
            </td>

            <td>
               <asp:TextBox ID="txt_project" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
                    </tr>
            <tr>
                    <td>
            Trạng thái:
            </td>

            <td>
                <asp:DropDownList ID="dropd_status" runat="server" Width="250px" Height="25px">
                </asp:DropDownList>
        </td>
        <td >
            Người đăng:
            </td>
            <td>
            <asp:TextBox ID="txt_created_by" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
            </td>
            </tr>
        <tr>
        <tr><td colspan=5><hr></td></tr>
        <td>&nbsp</td><td colspan="3"><br>&nbsp
            <asp:Label ID="lbl_search_news" runat="server" >
            <asp:Button ID="Button4" runat="server" Text="Tìm kiếm" class="btn" 
                Width="120px" Height="25px" onclick="Button4_Click"/>
                </asp:Label>
                <input id="Button5" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/>
        </td>
        </tr>
        </table>
</fieldset>



    <asp:Repeater ID="news_list" runat="server" 
        onitemdatabound="news_list_ItemDataBound">
    <HeaderTemplate>
    <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="8">DANH SÁCH CHỦ ĐỀ</td></tr>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="8%">
            <P>STT</P>
        </td>
        <td width="17%">
            Tiêu đề
        </td>
                        <td width="10%">
            Người tạo
        </td>
                <td width="10%">
            Ngày tạo
        </td>
                        <td width="10%">
            Chủ đề
        </td>
                        <td width="12%">
            Mã dự án/Tên dự án
        </td>
                <td width="10%">
            Trạng thái
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor='#<%# Eval("bgcolors")%>'>
                <td valign="middle" align="center">
            <%=vNo++ %>. 
            <input name="chk" value="<%#Eval("bai_viet_id") %>" type="checkbox" /> 
                    <asp:Label ID="lbl_edit_news" runat="server"> | <a style=cursor:pointer title='Sửa yêu cầu' onclick=update_request('<%#Eval("bai_viet_id") %>')><img src=images/edit.gif width=20 height=20 alt='Sửa bài viết'></asp:Label>
        </td>
        <td>
            <asp:HyperLink ForeColor="Blue" ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%#Eval("bai_viet_id","post_show_details.aspx?news_id={0}") %>'><%# Eval("tieu_de")%></asp:HyperLink>
        </td>
                <td>
            <%# Eval("ten_nguoi_tao")%>
        </td>
                <td align="center">
            <%# Eval("ngay_tao","{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>

                </td>
                <td align="center">
            <%# Eval("chu_de")%>
        </td>
                </td>
                <td align="center">
            <%# Eval("du_an")%>
        </td>

        <td align="center">

        <asp:Label ID="lbl_edit_status_news" runat="server">
            <asp:DropDownList ID="dropd_status" runat="server" class="selects" onchange="updates(this);">
            </asp:DropDownList>
       </asp:Label>

       <asp:Label ID="lbl_edit_status" runat="server" ></asp:Label>

        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    </asp:Repeater>
      <tr>
    <td colspan="6" style="color:white;font-weight:bold"><br>
        *-Chủ đề bài viết có nền màu xám là yêu cầu đã xóa.<br>
        *-Chọn chủ đề bạn muốn xóa.<br><br>
        <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
        <asp:Label ID="lbl_del_news" runat="server">
            <input id="Button1" type="button" value="Xóa bài viết" class="btn" style="width:120px;height:25px" onclick="deletes('del')"/>
            <input id="Button3" type="button" value="Phục hồi bài viết" class="btn" style="width:120px;height:25px" onclick="deletes('undel')"/>
        </asp:Label>
        <input id="Button2" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/><br>&nbsp
        
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
   
</fieldset>

</asp:Content>
