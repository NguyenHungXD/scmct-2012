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
        function delete_request() {
            userid = document.getElementById("userid").value;
            var obj = document.forms["chiase"];
            var checked = false;
            if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để Đóng.")) {
                if (obj.chk.length > 0) {
                    for (i = 0; i < obj.chk.length; i++) {
                        if (obj.chk[i].checked == true) {
                            var url = "my_page.aspx?id=" + userid  + "&request_id=" + obj.chk[i].value + "&vmode=del";
                            loadXMLUpdate(url);
                            checked = true;
                        }
                    }
                }
                else {
                    if (obj.chk.checked == true) {
                        var url = "my_page.aspx?id=" + userid + "&request_id=" + obj.chk.value + "&vmode=del";
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

        function showdetail_project(obj) {

            
            var project_id = document.getElementById("project_id");
            var project_name = document.getElementById("project_name");
            var from_date = document.getElementById("from_date");
            var to_date = document.getElementById("to_date");

            if (obj.value == "None") {
                project_name.innerHTML = "";
                from_date.innerHTML = "";
                to_date.innerHTML = "";
                project_id.innerHTML = "<i><font color=yellow>Bạn chọn xem tất cả dự án</font></i>";
                return;
            }
            var url = "my_page.aspx?project_id=" + obj.value;
            var content = getValXML(url);
            project_id.innerHTML = readXMLFormat(content, "<project_id>", "</project_id>");
            project_name.innerHTML = readXMLFormat(content, "<project_name>", "</project_name>");
            from_date.innerHTML = "<b>Ngày bắt đầu:</b><i> " + readXMLFormat(content, "<from_date>", "</from_date>") + "</i>";
            to_date.innerHTML = "<b>Ngày kết thúc:</b> <i>" + readXMLFormat(content, "<to_date>", "</to_date>")+"</i>";
        }

        function return_link() {
            var contentUrl = "";
            var windowname = 'mywindow';
            project_id = document.getElementById("drop_project").value;
            userid = document.getElementById("userid").value;
            contentUrl = "contribution_product_list.aspx?id=" + userid;
            if (project_id != "None")
                contentUrl = contentUrl + "&project_id=" + project_id;
            window.open(contentUrl, windowname, 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
        }

    </script>


    <br>
    <asp:HiddenField id="userid" ClientIDMode="Static" runat="server"></asp:HiddenField>
    <table cellpadding=2 cellspacing=0 style="border:1px solid #FFF;border-radius: 5px;box-shadow: 1px 1px 2px #CCC;padding:10px 10px 10px 10px" width=100%>
    <tr>
    <td>Chọn dự án:</td>
    <td colspan=5>
    <asp:DropDownList id="drop_project" ClientIDMode="Static" runat="server" onChange="showdetail_project(this)" ></asp:DropDownList>
    <tr>
    <tr>
    <td width=10%  align="right">
    <b>Mã dự án:</b>
    </td>
    <td>
        <i><div id="project_id"><font color=yellow>Bạn chọn xem tất dự án</font></div></i>
    </td>
    <td width=10%>
    <b>Tên dự án:</b>
    </td>
    <td>
        <i><div id="project_name"></div></i>
    </td>

    <td>
        <div id="from_date"><b>Ngày bắt đầu:</b></div>
    </td>
        
    <td>
        <div id="to_date"><b>Ngày kết thúc:</b></div>
    </td>
    </tr>
    <tr>
    <td colspan=6><hr><i>*-Chọn dự án bạn muốn xem chi tiết</i><br>
    <img src="images/book-open.png" width=25 height=25> <a style="cursor:pointer;font-size:15px;text-decoration:underline;font-weight:bold;color:White" onclick="return_link();" id="link_view_contribution_list" target="_blank"  title="Xem chi tiết" >Xem danh sách đóng góp của bạn theo dự án</a>
    </td>
    </table>

    <br>
    <asp:Repeater ID="request_list" runat="server">
    <HeaderTemplate>
    <table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="6">DANH SÁCH YÊU CẦU</td></tr>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="13%">
            <p>STT</p>
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
    </FooterTemplate>
    </asp:Repeater>
        <tr>
    <td colspan="6" style="color:white;font-weight:bold"><br>
    <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
        *-Bạn có thể xóa hoặc sửa yêu cầu nếu yêu cầu đang chờ duyệt.<br>
        *-Chọn yêu cầu bạn muốn xóa.<br><br>
<asp:Label id="lbl_del" runat="server" Text="">
        <input id="Button1" type="button" value="Xóa yêu cầu" class="btn" style="width:120px;height:25px" onclick="delete_request();"/>
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
