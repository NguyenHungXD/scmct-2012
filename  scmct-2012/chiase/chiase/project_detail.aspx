<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="project_detail.aspx.cs" Inherits="chiase.project_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<script type="text/javascript">

    function like_post(id, val, divid) {
        var url = "update_like_post.aspx?post_id=" + id;
        loadXMLUpdate(url);
        document.getElementById(divid).innerHTML = val + 1;
    }
</script>
<fieldset> 
<table cellpadding="3" cellspacing="1" border="0" bgcolor="#ff6600" width="100%">
<tr bgcolor="white">
<td width="20%" align="right">
    Mã dự án
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_maduan" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Tên dự án
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_tenduan" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Chi tiết
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_chitiet" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Ghi chú
    </td>
    <td width="80%">
    <b><asp:Label ID="lbl_ghichu" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Số sách cần quyên góp
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_book" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Trạng thái
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_trangthai" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Ngày bắt đầu
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_batdau" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr bgcolor="white">
<td width="20%" align="right">
    Ngày kết thúc
        </td>
    <td width="80%">
    <b><asp:Label ID="lbl_ketthuc" runat="server" Text=""></asp:Label></b>
</td>
</tr>
<tr>
<td colspan="2">

    <asp:Repeater ID="showListPost" runat="server" 
            onitemdatabound="showListPost_ItemDataBound1">
        <HeaderTemplate>
        <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;">
        <tr class="new_post">
        <td colspan=3>
            Tiêu đề
        </td>
        <td>
            Lượt xem
        </td>
        <td>
            Bình luận
        </td>
        <td>
            Xếp hạng
        </td>
        <td>
            Bình luận mới
        </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>

                    <tr class="new_post_details">
                    <td with=10%>
                    
                    <asp:Image ID="img_like" runat="server" ImageUrl="images/new_post.gif" Width=25 Height=20/>
                    </td>
                    <td with=10% valign=middle align=center style="cursor:pointer;"  onclick=like_post(<%# Eval("BAI_VIET_ID")%>,<%#Eval("liked")%>,'<%#Eval("BAI_VIET_ID","div{0}")%>')>
                    <div id='<%#Eval("BAI_VIET_ID","div{0}")%>' class="like_text">
                    <%#Eval("liked")%>
                    </div>
                    <div class="like_fm">
                    &nbsp
                    <div>
                    </td>

                    <td align=left with=25%><asp:HyperLink ID="link_show_detail" runat="server" NavigateUrl='<%# Eval("bai_viet_id", "post_show_details.aspx?news_id={0}") %>'
                                        Text='<%# Eval("tieu_de") %>'></asp:HyperLink><br><font size=-3><i>Tạo bởi 
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("username", "user_info.aspx?user_name={0}") %>' Text='<%# Eval("username") %>'></asp:HyperLink>, <%#Eval("ngay_tao", "{0:dd/MM/yyyy hh:mm:ss tt}")%></font></i></td>
                    <td with=10%>
                    
                        <asp:Label ID="lbl_cnt_comment" runat="server" Text='<%# Eval("xem") %>'></asp:Label>
                    
                    </td>
                    <td with=10%>
                        <asp:Label ID="lbl_cnt_view" runat="server" Text="0"></asp:Label>
                    </td>
                    <td with=10%>
                    
                    <asp:Image ID="Image2" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image5" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image6" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image7" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    <asp:Image ID="Image8" runat="server" ImageUrl="images/star_w.gif" Width=12 Height=12/>
                    </td>
                    <td with=25% align=left>
                    
                        <asp:HyperLink ID="link_comment" runat="server"></asp:HyperLink><br>
                        <font size=-3>Trả lời bởi, 
                        <asp:HyperLink ID="link_cm_by" runat="server"></asp:HyperLink>, <asp:Label ID="lbl_date_time" runat="server" Text=""></asp:Label></font>

                        
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
</fieldset> 
</asp:Content>
