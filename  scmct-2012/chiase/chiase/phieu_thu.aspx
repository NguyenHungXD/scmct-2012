<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="phieu_thu.aspx.cs" Inherits="chiase.phieu_thu" %>
    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
  
    <asp:HiddenField ID="txt_temp" ClientIDMode="Static" value="<%= vNo %>" runat="server" />

    <script type="text/javascript">
        function return_link(obj) {
            var name = document.getElementById("txt_name");
            var address = document.getElementById("txt_address");
            if (obj.value == "None") {
                name.value = "";
                address.value = "";
                return;
            }
            var contentUrl = "user_info.aspx?id=" + obj.value;
            var windowIndex = 1;
            var window = divpopup.GetWindow(windowIndex);
            divpopup.SetWindowContentUrl(window, contentUrl);


            var url = "phieu_thu.aspx?user_id=" + obj.value +"&vmode=getdata_fullname";
            var content = getValXML(url);

            name.value = readXMLFormat(content, "[start1]", "[endstart1]");
            address.value = readXMLFormat(content, "[start2]", "[endstart2]");
        }

        function hidebtn() {

            var mapt = document.getElementById("txt_temp").value;
            document.getElementById("btn_").innerHTML = "<font color=red><b>Phiếu thu đã lưu thành công.[<a style=color:blue href=phieu_thu_view.aspx?ma_pt=" + mapt + ">Xem chi tiết</a>]</b></font>";

        }
        function return_link_request(obj) {
            var contentUrl = "view_request.aspx?id=" + obj.value;
            var windowIndex = 1;
            var window = divpopup3.GetWindow(windowIndex);
            divpopup3.SetWindowContentUrl(window, contentUrl);
        }

        function return_links(obj) {
            var name = document.getElementById("txt_received_from");

            if (obj.value == "None") {
                name.value = "";
                return;
            }
            var contentUrl = "user_info.aspx?id=" + obj.value;
            var windowIndex = 1;
            var window = divpopup2.GetWindow(windowIndex);
            divpopup2.SetWindowContentUrl(window, contentUrl);


            var url = "phieu_thu.aspx?user_id=" + obj.value + "&vmode=getdata_fullname";
            var content = getValXML(url);
            
            name.value = readXMLFormat(content, "[start1]", "[endstart1]");
        }

        function return_link_project(obj) {
            var name = document.getElementById("project_name");
            if (obj.value == "None") {
                name.innerHTML = "";
                return;
            }
            var contentUrl = "project_detail_popup.aspx?id=" + obj.value;
            var windowIndex = 1;
            var window = divpopup1.GetWindow(windowIndex);
            divpopup1.SetWindowContentUrl(window, contentUrl);
            var url = "phieu_thu.aspx?id=" + obj.value + "&vmode=getdata_project";
            var content = getValXML(url);
            
            name.innerHTML = readXMLFormat(content, "[start2]", "[endstart2]");
        }



    // ]]> 


        function Button2_onclick() {
            window.location = "admin.aspx";
        }

    </script>


<fieldset style="font-size:15px">
<table cellpadding=5 cellspacing=0 style="border:1px solid #FFFFFF;color:Black" width=100% >
<tr style="background-color:#F8F7F7">
<td>
    <table cellpadding=0 cellspacing=0 border=0 width=100% style="background-color:#FFFFFF">
    <tr>
     <td valign="middle" rowspan="3">
    <img src="/images/logo_print.png"><br>
    <b>Cổng quyên góp sách online</b>
    </td>
    
    <td colspan="2"><br>&nbsp</td></tr>
    <tr>
   

    <td valign="middle" align="center" colspan="2"><b>
    <p><font size="3px">Nhóm tình nguyện viên SCMCCT</font><br>
    CỔNG THÔNG TIN QUYÊN GÓP SÁCH ONLINE</b>
    </p>
    </td>
    </tr>

    <tr>
    <td>
    <table cellspacing=0><tr><td align="right">
    Địa chỉ  :</td><td>TP.Hồ Chí Minh
    </td></tr>
    <td align="right">
    Email  :</td><td> quantri.scmct@gmail.com
    </td>
    </tr>
    </table>
    </td>
    <td>


        <table cellspacing=0><tr><td align="right">
        Tel  :</td><td> 01643376677
        </td>
        </tr>
        <tr>
        <td align="right">
        Fax  :</td>
        <td> 12345678912
            </tr>
        <tr>
        <td align="right">
        Web  :</td><td> www.chiase.org 
        </td>
        </tr>
        </table>

    </td>
    </tr>
    <tr>
    <td colspan="3">
    <hr style="height:1px">
    </td>
    </tr>
    <tr>
    <td colspan="3" align="center"><br>
        <p>
        <font size="5px"><b>PHẾU THU</b></font><i> Số:<b>...... <%--<%= vNo %>--%></b><br>
        Ngày..<%= System.DateTime.Now.ToString("dd") %>..tháng..<%= System.DateTime.Now.ToString("MM") %>..năm <%= System.DateTime.Now.ToString("yyyy") %></i><br>
        Quyển số:....................</i>
        </p><br>&nbsp
    </td>
    </tr>
    <tr>
    <td colspan="3">



    <table width="100%" border=0 >
    <tr>
    <td>&nbsp</td><td width=25% style="font-weight:bold">Họ tên người nộp tiền  :</td><td colspan="3" width=75%> 
        <asp:TextBox ID="txt_name" runat="server" class="txtformat" Width="200px" 
            ForeColor="#0066FF" Height="25px" ClientIDMode="Static"></asp:TextBox>
        

        <asp:DropDownList ID="dropd_name_list" runat="server" Height="25px" onchange="return_link(this)">
        </asp:DropDownList> [<a id="divdetail" style="cursor:pointer"><font color=blue>Xem chi tiết</font></a>]
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ControlToValidate="dropd_name_list" InitialValue="None" ForeColor="Red" ErrorMessage="Chọn người nộp tiền"></asp:RequiredFieldValidator>
        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server"
                    AllowDragging="True" AllowResize="True" ClientInstanceName="divpopup"
                            CloseAction="CloseButton" 
                            EnableViewState="False" PopupElementID='divdetail'
                            PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" ShowFooter="True" Width="800px"
                            Height="600px" FooterText=""
                            HeaderText="" 
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
    </tr>

    <tr>
    <td>&nbsp</td><td style="font-weight:bold">Địa chỉ  :</td><td colspan="3">  <asp:TextBox ID="txt_address" 
            runat="server" class="txtformat" ForeColor="#0066FF" Height="25px" 
            Width="400px" ClientIDMode="Static"></asp:TextBox>

    </td>
    </tr>


<tr>
    <td>&nbsp</td><td style="font-weight:bold">Thu từ yêu cầu  :</td><td colspan="3">  
        <asp:DropDownList ID="dropd_request" runat="server" Height="25px" onchange="return_link_request(this)">
        </asp:DropDownList>

        [<a id="divdetail3" style="cursor:pointer"><font color=blue>Xem chi tiết</font></a>]
<%--        [<a style="cursor:pointer;color:Blue" href="request.aspx?vmode=admin">Tạo yêu cầu mới</a>]--%>

<%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            InitialValue="None" ControlToValidate="dropd_request" Display="Dynamic" 
            ErrorMessage="Chọn yêu cầu" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                <dx:ASPxPopupControl ID="ASPxPopupControl4" runat="server"
                    AllowDragging="True" AllowResize="True" ClientInstanceName="divpopup3"
                            CloseAction="CloseButton"  PopupVerticalAlign="WindowCenter"
                            EnableViewState="False" PopupElementID='divdetail3'
                            ShowFooter="True" Width="800px"
                            Height="300px" FooterText=""
                            HeaderText="" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>
    </td>
    </tr>



    <tr>
    <td>&nbsp</td><td style="font-weight:bold">Thu cho dự án  :</td><td colspan="3">  
        <asp:DropDownList ID="dropd_list_project" runat="server" Height="25px" onchange="return_link_project(this)">
        </asp:DropDownList>
        
        <asp:Label ID="project_name" runat="server" ClientIDMode="Static" Text=""></asp:Label>
        [<a id="divdetail1" style="cursor:pointer"><font color=blue>Xem chi tiết</font></a>]

        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            InitialValue="None" ControlToValidate="dropd_list_project" Display="Dynamic" 
            ErrorMessage="Chọn dự án" ForeColor="Red"></asp:RequiredFieldValidator>

                <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server"
                    AllowDragging="True" AllowResize="True" ClientInstanceName="divpopup1"
                            CloseAction="CloseButton"  PopupVerticalAlign="WindowCenter"
                            EnableViewState="False" PopupElementID='divdetail1'
                            ShowFooter="True" Width="800px"
                            Height="330px" FooterText=""
                            HeaderText="" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>
    </td>
    </tr>





       <tr>
    <td>&nbsp</td><td style="font-weight:bold">Ghi chú  : </td><td colspan="3"> 
        <asp:TextBox ID="txt_note" runat="server" class="txtformat_area" TextMode="MultiLine"
            ForeColor="#0066FF" Height="40px" Width="400px"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>&nbsp</td><td width=25% style="font-weight:bold">Nhận tiền từ:</td><td colspan="3" width=75%> 
        <asp:TextBox ID="txt_received_from" runat="server" class="txtformat" Width="200px" 
            ForeColor="#0066FF" Height="25px" ClientIDMode="Static"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"  ControlToValidate="txt_received_from" Display="Dynamic" 
            ErrorMessage="Chưa nhập họ tên người giao tiền" ForeColor="Red"></asp:RequiredFieldValidator>


        <asp:DropDownList ID="drop_list" runat="server" Height="25px" onchange="return_links(this)">
        </asp:DropDownList> [<a id="divdetail2" style="cursor:pointer"><font color=blue>Xem chi tiết</font></a>]
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            InitialValue="None" ControlToValidate="drop_list" Display="Dynamic" 
            ErrorMessage="Chọn người giao tiền" ForeColor="Red"></asp:RequiredFieldValidator>--%>

         <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server"
                    AllowDragging="True" AllowResize="True" ClientInstanceName="divpopup2"
                            CloseAction="CloseButton"  PopupVerticalAlign="WindowCenter"
                            EnableViewState="False" PopupElementID='divdetail2'
                            ShowFooter="True" Width="800px"
                            Height="600px" FooterText=""
                            HeaderText="" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>


        </td>
        </tr>

    <tr>
    <td>&nbsp</td><td style="font-weight:bold">Số tiền  : </td><td colspan="3"> 
        <asp:TextBox ID="txt_total" runat="server" class="txtformat" 
            ForeColor="#0066FF" Height="25px" Width="400px"></asp:TextBox>(VNĐ)
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
            ControlToValidate="txt_total" Display="Dynamic" runat="server" 
            ErrorMessage="Nhập số tiền nhận" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_total" ValidationExpression="^\d+$" runat="server" ErrorMessage=" Tiền phải là số"></asp:RegularExpressionValidator>
    </td>
    </tr>

    <tr>
    <td>&nbsp</td><td colspan="3" style="font-weight:bold">(Viết bằng chữ)  :<t style="font-weight:normal">&nbsp<asp:Label ID="lbl_money_text" runat="server" Text="..........................................................................................................................."></asp:Label></t>
    </td>
    </tr>

        <tr>
    <td>&nbsp</td><td colspan="3">

    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="font-weight:bold">
    <tr>
    <td colspan="9" style="font-weight:bold">Chứng từ kèm theo:<br>&nbsp
    <p align="right" style="font-weight:normal"><i>Ngày..<%= System.DateTime.Now.ToString("dd") %>..tháng..<%= System.DateTime.Now.ToString("MM") %>..năm <%= System.DateTime.Now.ToString("yyyy") %></i></p><br>
    </td>
    </tr>
    <tr align="center" valign="middle">
    <td>&nbsp</td><td>&nbsp</td><td>Người lập phiếu<p style="font-weight:normal"><font size=-1>(Ký,họ tên)</font></p>
    </td>
      <td>Người nộp tiền<p style="font-weight:normal"><font size=-1>(Ký,họ tên)</font></p>
    </td>
      <td>Thủ quỹ<p style="font-weight:normal"><font size=-1>(Ký,họ tên)</font></p>
    </td>
      <td>Kế toán trưởng<p style="font-weight:normal"><font size=-1>(Ký,họ tên)</font></p>
    </td>
        </td>
      <td>Giám đốc<p style="font-weight:normal"><font size=-1>(Ký,họ tên,đóng dấu)</font></p>
    </td>
    </tr>
    <tr>
    <td colspan="9">
        <br>&nbsp<br>&nbsp
    </td>
    </tr>
    </table>

    </table>
    
    
    <p align="right" style="display: block;" id="btn_">
        <asp:Label ID="lbl_create_new_pt" runat="server">
        <asp:Button ID="btn_save" runat="server" ClientIDMode="Static" Text="Lưu phiếu thu" class="btn"
                Height="25px" Width="120px" onclick="btn_save_Click" />
        </asp:Label>

                <input id="Button2" type="button" value="Đóng" class="btn" style="width:100px;height:25px" onclick="return Button2_onclick()"/>
        </p>


    </td>
    </tr>

    </table>
</td>
</tr>
</table>
</fieldset>

    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>

</asp:Content>
