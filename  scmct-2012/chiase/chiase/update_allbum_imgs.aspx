<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="update_allbum_imgs.aspx.cs" Inherits="chiase.update_allbum_imgs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<script type="text/javascript">
    function close_page(id) {
        window.location = "update_allbum.aspx?allbum_id=" + id;
    }

    function checkalls(div)
    {
        var obj = document.forms["chiase"];
        var divid = document.getElementById(div);
        if (obj.chk_del.length > 0) 
        {
            if (divid.checked == true) {
                    for (i = 0; i < obj.chk_del.length; i++) 
                    {
                        obj.chk_del[i].checked = true;
                        }
                    }else{
                       for (i = 0; i < obj.chk_del.length; i++) {
                           obj.chk_del[i].checked = false;
                        }
                    }
                }
                else {
                    if (divid.checked == true)
                        obj.chk_del.checked = true;
                    else
                        obj.chk_del.checked = false;
                }
     }
    

    function save_info() {

        var obj = document.forms["chiase"];
        if (confirm("Xác nhận thay đổi!\nChọn [Ok] để lưu thông tin, [Cancel] để hủy.")) {
            if (obj.txt_title.length > 0) {
                for (i = 0; i < obj.txt_title.length; i++) {
                    //Call ajax to update
                    if (obj.chk_del[i].checked == true) { //Mode = 1 Update info 2 Del 3 Set default image for allbum
                        var url = "update_allbum_imgs_save.aspx?img_id=" + obj.chk_del[i].value + "&mode=2";
                        loadXMLUpdate(url);
                    } else {
                        var url = "update_allbum_imgs_save.aspx?img_id=" + obj.chk_del[i].value + "&v_title=" + encodeURIComponent(obj.txt_title[i].value) + "&mode=1";
                        loadXMLUpdate(url);
                    }
                    if (obj.rd_mainimg[i].checked == true) {
                        var url = "update_allbum_imgs_save.aspx?img_id=" + obj.chk_del[i].value + "&allbum_id=" + obj.rd_mainimg[i].value + "&mode=3";
                        loadXMLUpdate(url);
                    }

                }
            } else { //For only 1 Item#

                if (obj.chk_del.checked == true) { //Mode = 1 Update info 2 Del 3 Set default image for allbum
                    var url = "update_allbum_imgs_save.aspx?img_id=" + obj.chk_del.value + "&mode=2";
                    loadXMLUpdate(url);
                } else {
                    var url = "update_allbum_imgs_save.aspx?img_id=" + obj.chk_del.value + "&v_title=" + encodeURIComponent(obj.txt_title.value) + "&mode=1";
                    loadXMLUpdate(url);
                }
                if (obj.rd_mainimg.checked == true) {
                    var url = "update_allbum_imgs_save.aspx?img_id=" + obj.chk_del.value + "&allbum_id=" + obj.rd_mainimg.value + "&mode=3";
                    loadXMLUpdate(url);
                }
            }
            document.getElementById("divinfo").innerHTML = "<font size=4px color=red>Lưu thông tin thành công!</font>";
        }
    }
</script>


<fieldset>
<br>
Allbum:<b> <%= allbumname%></b><br>
Chi tiết: <b><%= allbum_description%></b>
<br>
<hr>
<fieldset style="background-color:white;color:Blue">
<asp:Repeater ID="showListimg" runat="server" >
        <HeaderTemplate>
        <table cellpadding="3" cellspacing="1" border="0" width="90%">
        <tr bgcolor="#A619CF" style="color:White">
        <td colspan="3">
        </td>
        <td align="left">
        <input style="cursor:pointer" id="delall" type="checkbox" onclick="checkalls('delall');" /><label for="delall"><b>Xóa tất cả</b></label>
        </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td align="right">
            <asp:Image ID="Image1" runat="server" Width="50" Height="50" ImageUrl='<%#Eval("path") %>' BorderColor="Green" BorderWidth="1px"></asp:Image>
        </td>
        <td>
        Chi tiết ảnh:<br>
            <textarea id="txt_title" rows="2" cols="50" class="txtformat_area"><%#Eval("title") %></textarea>
        </td>
        <td><br>
            <input style="cursor:pointer" name="rd_mainimg" id="<%#Eval("img_id") %>" type="radio" value="<%= allbumid %>"/> <label for="<%#Eval("img_id") %>">Làm ảnh bìa allbum</label> 
        </td>
        <td><br>
            <input style="cursor:pointer" name="chk_del" id="<%#Eval("img_id","chk{0}") %>" type="checkbox" value="<%#Eval("img_id") %>"/><label for="<%#Eval("img_id","chk{0}") %>">Xóa ảnh</label>
        </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
                <tr bgcolor="#A619CF" style="color:White">
        <td colspan="3">
        </td>
        <td align="left">
        <input style="cursor:pointer"  id="delall1" type="checkbox" onclick="checkalls('delall1');" /><label for="delall1"><b>Xóa tất cả</b></label>
        </td>
        </tr>
        <tr><td colspan="3" id="Td1" align="left"><font color=red>*-Allbum không có ảnh sẽ tự động xóa khỏi hệ thống</font></td></tr>
        <tr><td colspan="3" id="divinfo" align="center">&nbsp</td></tr>

        
        <tr>
        <td align="right">
            <input id="Button1" type="button" value="Lưu thông tin" class="btn" style="width:120px;height:25px" onClick="save_info()"/>
        </td>
        <td>
            <input id="Button2" type="button" value="Bỏ qua" class="btn" style="width:120px;height:25px" onClick="close_page('<%=allbumid %>')"/>
        </td>
        </tr>
        </table>
        </FooterTemplate>
</asp:Repeater> 
</fieldset>
<hr>
</fieldset>
</asp:Content>
