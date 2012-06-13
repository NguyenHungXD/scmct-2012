<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_result.aspx.cs" Inherits="chiase.search_result" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <script type="text/javascript">
        function options_search(objid) {
            var bv = "unchecked";
            var yc = "unchecked";
            var hinh = "unchecked";
            var all = "unchecked";
            var chkall = document.getElementById("chk_all");
            var chkbv = document.getElementById("chk_bv");
            var chkyc = document.getElementById("chk_yc");
            var chkhinh = document.getElementById("chk_hinh");
            if (chkall.checked == true && objid == "chk_all") {
                chkbv.checked = true;
                chkyc.checked = true;
                chkhinh.checked = true;
            }
            if (chkall.checked == false && objid == "chk_all") {
                chkbv.checked = false;
                chkyc.checked = false;
                chkhinh.checked = false;
            }
            if (chkbv.checked == true && chkyc.checked == true && chkhinh.checked == true) {
                chkall.checked = true;
            }
            if (chkall.checked == true) all = "checked";
            if (chkbv.checked == true) bv = "checked";
            if (chkyc.checked == true) yc = "checked";
            if (chkhinh.checked == true) hinh = "checked";
            var url = "search_result.aspx?vmode=search_options&search_all=" + all + "&search_news=" + bv + "&search_request=" + yc + "&search_album=" + hinh;
            loadXMLUpdate(url);
        }
    </script>

<div id="result">
<fieldset>
    
   Mục cần tìm: <asp:CheckBox id="chk_all" ClientIDMode="Static" runat="server" onclick="options_search('chk_all');"></asp:CheckBox><label for="chk_all"> Tất cả</label> | <asp:CheckBox id="chk_bv" ClientIDMode="Static" runat="server" onclick="options_search('chk_bv');"></asp:CheckBox><label for="chk_bv"> Bài viết</label> | <asp:CheckBox id="chk_yc" ClientIDMode="Static" runat="server" onclick="options_search('chk_yc');"></asp:CheckBox><label for="chk_yc"> Yêu cầu</label> | <asp:CheckBox id="chk_hinh" ClientIDMode="Static" runat="server" onclick="options_search('chk_hinh');"></asp:CheckBox><label for="chk_hinh"> Hình ảnh</label>
<hr>
<table cellpadding=1 cellspacing=1 border=0 width="100%">
<tr>
<td>
    <asp:Label id="lbl_result" runat="server" Text=""></asp:Label> <!-- Khoảng 222 kết quả(0.18 giây)-->

</td>
</tr>
<tr>
<td align=center>
    <b><asp:Label id="lbl_error" forecolor="Yellow" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr>
<td>
<!--Search result for News -->
        <asp:Repeater ID="showListPost" runat="server">
        <HeaderTemplate>
                <table border="0" cellpadding=4 cellspacing=5 width="100%"  style="border:0px solid #CCFFFF;background-color:#FFFFFF;color:Black" class="btn_forum">
        <tr>
        <td colspan=2 align=center style="background:#0066FF;color:White"><b><%= cnt_bvs %> KẾT QUẢ CHO BÀI VIẾT</b></td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                    <td align=right width=8%><img src="<%# Eval("avatar_path","images/avatars/{0}") %>" width="50px" height="50px"></td>
                    <td>
                    <a ID="link_show_detail" href="<%# Eval("url") %>" target="_blank" title='Xem chi tiết'><%#Eval("content2") %>...</a>
                    <br><%#Eval("content1") %>...
                    
                    <br><font size=-3><i>Tạo bởi 
                                        <font color="#CC33FF"><%#Eval("username") %></font>
                                        , <%#Eval("ngay_tao", "{0:dd/MM/yyyy hh:mm:ss tt}")%></font></i>
                             
                    </td>

                    </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
<!--Search result for request -->
        <asp:Repeater ID="showLisYC" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding=4 cellspacing=5 width="100%"  style="border:0px solid #CCFFFF;background-color:#FFFFFF;color:Black" class="btn_forum">
        <tr>
        <td colspan=2 align=center style="background:#0066FF;color:White"><b> <%= cnt_ycs %> KẾT QUẢ CHO YÊU CẦU</b></td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                    <td align=right width=8%><img src="<%# Eval("avatar_path","images/avatars/{0}") %>" width="50px" height="50px"></td>
                    <td>
                    <a ID="A2" href="<%# Eval("yeu_cau_id","request_detail.aspx?id={0}") %>" target="_blank" title='Xem chi tiết'><%#Eval("content2") %>...</a>
                    <br><%#Eval("content1") %>...
                    
                    <br><font size=-3><i>Tạo bởi 
                                        <font color="#CC33FF"><%#Eval("username") %></font>
                                        , <%#Eval("ngay_yeu_cau", "{0:dd/MM/yyyy hh:mm:ss tt}")%></font></i>
                    </td>
                    </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
<!--Search result for album -->
        <asp:Repeater ID="showList_album" runat="server">
        <HeaderTemplate>
        <table border="0" cellpadding=4 cellspacing=5 width="100%"  style="border:0px solid #CCFFFF;background-color:#FFFFFF;color:Black" class="btn_forum">
        <tr>
        <td colspan=2 align=center style="background:#0066FF;color:White"><b> <%= cnt_hinhs%> KẾT QUẢ CHO HÌNH ẢNH</b></td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                    <td align=right width=8%><img src="<%# Eval("avatar_path","images/avatars/{0}") %>" width="50px" height="50px"></td>
                    <td>
                    <a ID="A3" href="<%# Eval("album_id","slideshow.aspx?albumid={0}") %>" target="_blank" title='Xem chi tiết'><%#Eval("content2") %>...</a>
                    <br><%#Eval("content1") %>...
                    
                    <br><font size=-3><i>Tạo bởi 
                                        <font color="#CC33FF"><%#Eval("username") %></font>
                                        , <%#Eval("created_date", "{0:dd/MM/yyyy hh:mm:ss tt}")%></font></i>
                    </td>
                    </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
</td>
</tr>
</table>
<hr>
<p align=right>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %></p>
</fieldset>
</div>
</asp:Content>
