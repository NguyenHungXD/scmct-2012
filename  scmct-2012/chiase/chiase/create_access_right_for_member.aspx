<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="create_access_right_for_member.aspx.cs" Inherits="chiase.create_access_right_for_member" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<fieldset >
    <script type="text/javascript">

        function checkalls(mode, index) {
            var obj = document.forms["chiase"];
            var vchecked = false;
            if (mode == 'view') {
                var obj_chk = obj.chk_view;
            }
            else if (mode == 'add') {
                var obj_chk = obj.chk_add;
            }
            else if (mode == 'edit') {
                var obj_chk = obj.chk_edit;
            }
            else if (mode == 'lock') {
                var obj_chk = obj.chk_lock;
            }
            else if (mode == 'del') {
                var obj_chk = obj.chk_del;
            }

            if (obj_chk.length > 0) {
                if (obj.chkall[index].checked == true) {
                    vchecked = true;
                } else {
                    vchecked = false;
                }
                for (i = 0; i < obj_chk.length; i++)
                    obj_chk[i].checked = vchecked;
            }
            else {
                if (obj.chkall.checked == true) {
                    vchecked = true;
                } else {
                    vchecked = false;
                }
                obj_chk.checked = vchecked;
            }
        }


        function checkall(index) {
            var obj = document.forms["chiase"];
            var vchecked = false;
            if (obj.chk_all.length > 0) {
                if (obj.chk_all[index].checked == true) {
                    vchecked = true;
                } else {
                    vchecked = false;
                }
                obj.chk_view[index].checked = vchecked;
                obj.chk_add[index].checked = vchecked;
                obj.chk_edit[index].checked = vchecked;
                obj.chk_del[index].checked = vchecked;
                obj.chk_lock[index].checked = vchecked;
            }
            else {
                if (obj.chk_all.checked == true) {
                    vchecked = true;
                } else {
                    vchecked = false;
                }
                obj.chk_view.checked = vchecked;
                obj.chk_add.checked = vchecked;
                obj.chk_edit.checked = vchecked;
                obj.chk_del.checked = vchecked;
                obj.chk_lock.checked = vchecked;
            }
        }

        function returnvalChecked(obj) {
            if (obj.checked == true)
                return 'Y';
            else
                return 'N';
        }

        function updates(vmode) {
            var obj = document.forms["chiase"];
            var checked = false;
            var vuserid = document.getElementById("divuserid").value;
            if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để Đóng.")) {
                if (obj.chk_all.length > 0) {
                    for (i = 0; i < obj.chk_all.length; i++) {
                        var vView = returnvalChecked(obj.chk_view[i]);
                        var vCreate = returnvalChecked(obj.chk_add[i]);
                        var vEdit = returnvalChecked(obj.chk_edit[i]);
                        var vDel = returnvalChecked(obj.chk_del[i]);
                        var vLock = returnvalChecked(obj.chk_lock[i]);

                        var url = "create_access_right_for_member.aspx?userid=" + vuserid + "&moduleid=" + obj.chk_all[i].value + "&V=" + vView + "&C=" + vCreate + "&E=" + vEdit + "&D=" + vDel + "&L=" + vLock + "&vmode=" + vmode;
                        loadXMLUpdate(url);
                        checked = true;
                    }
                }
                else {
                    var vView = returnvalChecked(obj.chk_view);
                    var vCreate = returnvalChecked(obj.chk_add);
                    var vEdit = returnvalChecked(obj.chk_edit);
                    var vDel = returnvalChecked(obj.chk_del);
                    var vLock = returnvalChecked(obj.chk_lock);

                    var url = "create_access_right_for_member.aspx?userid=" + vuserid + "&moduleid=" + obj.chk_all.value + "&V=" + vView + "&C=" + vCreate + "&E=" + vEdit + "&D=" + vDel + "&L=" + vLock + "&vmode=" + vmode;
                    loadXMLUpdate(url);
                    checked = true;
                }

                if (vmode == "create_new") {
                    var error = "Bạn chưa chọn quyền để xét cho thành viên!";
                    var result = "Cập nhật quyền cho thành thành công!";
                }

                if (checked == false)
                    document.getElementById("stausinfo").innerHTML = error;
                else
                    document.getElementById("stausinfo").innerHTML = result;

            }
        }

        function backs() {
            window.close();
        }

    </script>

<fieldset>
    <asp:HiddenField ID="divuserid" ClientIDMode="Static" runat="server" />
    <table border="0" cellpadding=2 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;">
        <tr style="color:White;font-weight:bold"><td colspan="2"><font size=3><p align="center">Xét quyền cho thành viên</p></font></td></tr>
        <tr>
        <td>
            Tên thành viên:
            </td>
            <td>
                <font size=3><b>&nbsp<asp:Label ID="lbl_groupname" runat="server" Font-Size="Larger" Text=""></asp:Label></b></font>
        </td>
        </tr>
        <tr>
         <td>
            Nhóm:
                        </td>
            <td>
                <font size=3><b>&nbsp<asp:Label ID="lbl_name" runat="server" Font-Size="Larger" Text=""></asp:Label></b></font>
        </td>
        </tr>
        <tr>
        <td colspan="2"><hr>
        </td>
        </tr>
        <tr>
        <td width="20%">Mã chức năng:</td><td>
            <asp:TextBox ID="txt_moduleid" runat="server" class="txtformat" Height="25px" Width="250px"></asp:TextBox></td>
        </tr>
        <tr>
        <td>Tên chức năng:</td><td><asp:TextBox ID="txt_module_name" runat="server" class="txtformat" Height="25px" Width="250px"></asp:TextBox></td>
        </tr>
        <tr>
        <td>&nbsp</td>
        <td align="left">
            <asp:Label id="lbl_search" runat="server" Text="">
                <asp:Button ID="Button3" runat="server" Text="Tìm kiếm" class="btn" Height="25px" Width="120px" onclick="Button3_Click" />
            </asp:Label>
                <input id="Button4" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/>
        </td>
        </tr>
                <tr>
        <td colspan="2"><hr>
        </td>
        </tr>
        </table>
</fieldset>

    <asp:Repeater ID="module_list" runat="server" 
        onitemdatabound="module_list_ItemDataBound">
    <HeaderTemplate>
    <table border="0" cellpadding=3 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="8">DANH SÁCH CHỨC NĂNG HỆ THỐNG</td></tr>
        <tr class="btn_project" style="text-align:center;font-weight:bold;">
        <td width="10%">
            
            Mã chức năng
        </td>
                        <td width="15%">
            Tên chức năng
        </td>
        <td>
        <input name="chkall" onclick="checkalls('view',0);" id="chkall001" type="checkbox" /> <label style="cursor:pointer" for="chkall001" title="Chọn tất cả">
            Xem</label>
        </td>
                <td>
                <input name="chkall" onclick="checkalls('add',1);" id="chkall002" type="checkbox" /> <label style="cursor:pointer" for="chkall002" title="Chọn tất cả">
            Tạo mới</label>
        </td>
                <td>
                <input name="chkall" onclick="checkalls('edit',2);" id="chkall003" type="checkbox" /> <label style="cursor:pointer" for="chkall003" title="Chọn tất cả">
            Sửa</label>
        </td>
                        <td>
                        <input name="chkall" onclick="checkalls('lock',3);" id="chkall004" type="checkbox" /> <label style="cursor:pointer" for="chkall004" title="Chọn tất cả">
            Khóa</label>
        </td>
                <td>
                <input name="chkall" onclick="checkalls('del',4);" id="chkall005" type="checkbox" /> <label style="cursor:pointer" for="chkall005" title="Chọn tất cả">
            Xóa</label>
        </td>
                <td>
            Tất cả
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr bgcolor='#FFFFFF' >
        <td align="center">
           <b>[<%#Eval("id") %>]<br> <%#Eval("featureid") %> </b>
        </td>
        <td align="left">
            <%#Eval("name") %>
            
        </td>
        <asp:Repeater ID="control_list" runat="server" >
        <ItemTemplate>
        <td align="center" width="10%" bgcolor="<%#Eval("bgcolor_read") %>"> 
         <input name="chk_view" id="<%#Eval("id","chkview{0}") %>" type="checkbox" <%#Eval("isreads") %> />  <label style="cursor:pointer" for="<%#Eval("id","chkview{0}") %>" title="Quyền xem">&nbsp<img src="images/view.gif" width="20" height="20"></label>
        </td>
        <td align="center" width="10%" bgcolor="<%#Eval("bgcolor_insert") %>">
           <input name="chk_add" id="<%#Eval("id","chkadd{0}") %>" type="checkbox" <%#Eval("isinserts") %> /> <label style="cursor:pointer" for="<%#Eval("id","chkadd{0}") %>" title="Quyền tạo mới">&nbsp<img src="images/add.gif" width="20" height="20"></label>
        </td>
        <td align="center" width="10%" bgcolor="<%#Eval("bgcolor_edit") %>">
          <input name="chk_edit" id="<%#Eval("id","chkedit{0}") %>" type="checkbox" <%#Eval("isupdates") %>   />  <label style="cursor:pointer" for="<%#Eval("id","chkedit{0}") %>" title="Quyền cập nhật">&nbsp<img src="images/edit.png" width="20" height="20"></label>
        </td>
        <td align="center" width="10%" bgcolor="<%#Eval("bgcolor_del") %>">
           <input name="chk_lock" id="<%#Eval("id","chklock{0}") %>" type="checkbox" <%#Eval("isdeletes") %>  /> <label style="cursor:pointer" for="<%#Eval("id","chklock{0}") %>" title="Quyền khóa">&nbsp<img src="images/lock.png" width="20" height="20"></label>
        </td>
        <td align="center" width="10%" bgcolor="<%#Eval("bgcolor_lock") %>">
           <input name="chk_del" id="<%#Eval("id","chkdel{0}") %>" type="checkbox" <%#Eval("islocks") %> /> <label style="cursor:pointer" for="<%#Eval("id","chkdel{0}") %>" title="Quyền xóa">&nbsp<img src="images/deletes.png" width="20" height="20"></label>
        </td>
        <td align="center" width="10%" >
           <input name="chk_all" onclick="checkall(<%= no++ %>);" id="chkall<%= no %>"  value="<%#Eval("moduleid") %>" type="checkbox"  <%#Eval("ischkalls") %> /> <label style="cursor:pointer" for="chkall<%= no %>" title="Chọn tất cả">&nbsp<img src="images/checkall.png" width="20" height="20"></label>
        </td>
        </ItemTemplate>
        </asp:Repeater>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    </asp:Repeater>
        <tr>
    <td colspan="6" style="color:white;font-weight:bold"><br>
    <i>*-Chọn quyền cần xét cho nhóm thành viên</i>
    <i><br>*-Nhóm thành viên đã xóa có nền màu vàng</i><font color="white" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
    <asp:Label id="lbl_save" runat="server" Text="">
    <input id="Button1" type="button" value="Lưu thông tin" class="btn" style="width:125px;height:25px" onclick="updates('create_new')"/>
    </asp:Label>
    <input id="Button2" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/><br>&nbsp
        
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

