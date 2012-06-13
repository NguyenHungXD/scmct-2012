<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="hot_news.aspx.cs" Inherits="chiase.hot_news" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area"  runat="server">
<script type="text/javascript">

    //removeHTMLTags(string) in "js/jquery.autocomplete.js" khanhdtn
    function removeHTMLTags(htmlString) {
        if (htmlString) {
            var mydiv = document.createElement("div");
            mydiv.innerHTML = htmlString;

            if (document.all) // IE Stuff
            {
                return mydiv.innerText;

            }
            else // Mozilla does not work with innerText
            {
                return mydiv.textContent;
            }
            document.removeChild(mydiv);
        }

        return htmlString;
    }
    function showDetail(obj, index) {
    /*
        for (i = 1; i < 5; i++) {
            var div = "TextBox" + i;
            var titles = document.getElementById(div);
            alert(titles.value);
        }
*/
        switch (index) {
            case 1:
                var title = document.all["<%=TextBox1.ClientID %>"];
                var shortcontent = document.all["<%=TextBox11.ClientID %>"];
                var divid = document.getElementById("id1");
                break;
            case 2:
                var title = document.all["<%=TextBox2.ClientID %>"];
                var shortcontent = document.all["<%=TextBox22.ClientID %>"];
                var divid = document.getElementById("id2");
                break;
            case 3:
                var title = document.all["<%=TextBox3.ClientID %>"];
                var shortcontent = document.all["<%=TextBox33.ClientID %>"];
                var divid = document.getElementById("id3");
                break;
            case 4:
                var title = document.all["<%=TextBox4.ClientID %>"];
                var shortcontent = document.all["<%=TextBox44.ClientID %>"];
                var divid = document.getElementById("id4");
                break;
        }
        var url = "get_data_detail.aspx?post_id=" + obj.value;
        var content = getValXML(url);
        divid.innerHTML = "<a href='post_show_details.aspx?news_id=" + obj.value + "' style='color:#CC00FF' target='_blank'>Xem chi tiết</a>";
        title.value = removeHTMLTags(readXMLFormat(content, "[start1]", "[endstart1]"));
        shortcontent.value = removeHTMLTags(readXMLFormat(content, "[start2]", "[endstart2]"));

    }
    function backs() {
        window.location = "admin.aspx";
    }
</script>

<fieldset>
<div id="content" runat="server">

<br><br>&nbsp
<table cellpadding="3" cellspacing="1" border="0" width="100%" style="background-color:#FFFFFF;color:Black">
<tr bgcolor="#1A15FB" style="color:White;font-weight:bold"><td align="center" colspan="5">DANH SÁCH BÀI VIẾT NỔI BẬT</td></tr>
<tr class="btn_project" style="text-align:center;font-weight:bold;">
<td>
<P>Tiêu đề</P>
</td>
<td>
Nội dung rút gọn
</td>
<td colspan="3">
Hình ảnh đại diện
</td>
</tr>
<tr>
<td colspan="5" style="background-color:#CCFFCC;font-weight:bold;font-size:larger">
<table><tr><td>
Chọn bài viết 1:<asp:DropDownList ID="DropDownList1" runat="server" 
        onChange="showDetail(this,1)" BackColor="#FFFF99" Height="25px" ></asp:DropDownList></td><td id="id1"><asp:HyperLink ID="HyperLink1" runat="server" style='color:#CC00FF' target='_blank'>Xem chi tiết</asp:HyperLink></td></tr></table>
</td>
</tr>
<tr >
<td>
    <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" class="txtformat" Width="340px" 
        Height="30px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox11"  runat="server" TextMode="MultiLine" 
        class="txtformat_area" Width="340px" Height="50px"></asp:TextBox>
</td>
<td align="right">
    <asp:Image ID="Image1" runat="server" Width="120px" Height="50px" style="border:2px solid #FFFFFF"/>
<asp:Label ID="Label1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" BackColor="#CCCCCC" 
                Text="Chọn hình" BorderColor="White" BorderStyle="Solid" 
                BorderWidth="1px" Height="21px" ToolTip="Chọn hình" Width="175px"/>
</asp:Label>
</td>
<td style="background-color:Red">
    <asp:CheckBox ID="CheckBox1" runat="server" Checked="true"/>

</td>
</tr>
<tr>
<td colspan="4" style="background-color:#CCFFCC;font-weight:bold;font-size:larger" >
<table><tr><td>
Chọn bài viết 2:<asp:DropDownList ID="DropDownList2" runat="server" 
        onChange="showDetail(this,2)" BackColor="#FFFF99" Height="25px"></asp:DropDownList></td><td id="id2"><asp:HyperLink ID="HyperLink2" runat="server" style='color:#CC00FF' target='_blank'>Xem chi tiết</asp:HyperLink></td></tr></table>
</td>
</tr>
<tr style="background-color:#E4DFDF">
<td>
<asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" class="txtformat" Width="340px" 
        Height="30px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox22" runat="server" TextMode="MultiLine" 
        class="txtformat_area" Width="340px" Height="50px"></asp:TextBox>
</td>
<td align="right"><asp:Image ID="Image2" runat="server" Width="120" Height="50" style="border:2px solid #FFFFFF"/>
<asp:Label ID="Label2" runat="server">
    <asp:FileUpload ID="FileUpload2" runat="server" BackColor="#CCCCCC" 
                Text="Chọn hình" BorderColor="White" BorderStyle="Solid" 
                BorderWidth="1px" Height="21px" ToolTip="Chọn hình" Width="175px"/>
</asp:Label>
                </td>
<td style="background-color:Red">
    <asp:CheckBox ID="CheckBox2" runat="server" Checked="true"/>
</td>
</tr>
<tr>
<td colspan="4" style="background-color:#CCFFCC;font-weight:bold;font-size:larger">
<table><tr><td>
Chọn bài viết 3:<asp:DropDownList ID="DropDownList3" runat="server" 
        onChange="showDetail(this,3)" BackColor="#FFFF99" Height="25px"></asp:DropDownList></td><td id="id3"><asp:HyperLink ID="HyperLink3" runat="server" style='color:#CC00FF' target='_blank'>Xem chi tiết</asp:HyperLink></td></tr></table>
</td>
</tr>
<tr style="background-color:#E4DFDF">
<td>
<asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" class="txtformat" Width="340px" 
        Height="30px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox33" runat="server" TextMode="MultiLine" 
        class="txtformat_area" Width="340px" Height="50px"></asp:TextBox>
</td>
<td align="right"><asp:Image ID="Image3" runat="server" Width="120" Height="50" style="border:2px solid #FFFFFF"/>
<asp:Label ID="Label3" runat="server">
    <asp:FileUpload ID="FileUpload3" runat="server" BackColor="#CCCCCC" 
                Text="Chọn hình" BorderColor="White" BorderStyle="Solid" 
                BorderWidth="1px" Height="21px" ToolTip="Chọn hình" Width="175px"/>
</asp:Label>
                </td>
<td style="background-color:Red">
    <asp:CheckBox ID="CheckBox3" runat="server" Checked="true"/>
</td>
</tr>
<tr>
<td colspan="4" style="background-color:#CCFFCC;font-weight:bold;font-size:larger">
<table><tr><td>
Chọn bài viết 4:<asp:DropDownList ID="DropDownList4" runat="server" 
        onChange="showDetail(this,4)" BackColor="#FFFF99" Height="25px"></asp:DropDownList></td><td id="id4"><asp:HyperLink ID="HyperLink4" runat="server" style='color:#CC00FF' target='_blank'>Xem chi tiết</asp:HyperLink>
            </td></tr></table>
</td>
</tr>
<tr style="background-color:#E4DFDF">
<td>
<asp:TextBox ID="TextBox4" ClientIDMode="Static" runat="server" class="txtformat" Width="340px" 
        Height="30px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="TextBox44" runat="server" TextMode="MultiLine" 
        class="txtformat_area" Width="340px" Height="50px"></asp:TextBox>
</td>
<td align="right"><asp:Image ID="Image4" runat="server" Width="120" Height="50" style="border:2px solid #FFFFFF"/>
<asp:Label ID="Label4" runat="server">
    <asp:FileUpload ID="FileUpload4" runat="server" BackColor="#CCCCCC" 
                Text="Chọn hình" BorderColor="White" BorderStyle="Solid" 
                BorderWidth="1px" Height="21px" ToolTip="Chọn hình" Width="175px"/>
</asp:Label>
</td>
<td style="background-color:Red">
    <asp:CheckBox ID="CheckBox4" runat="server" Checked="true" />
    </td>
<td>
</td>
</tr>
<tr style="background-color:#FFFFCC">
<td align="right">&nbsp

<asp:Label ID="lbl_edit_hot_news" runat="server">
    <asp:Button ID="Button2" runat="server" Text="Lưu thông tin" class="btn" Height="25px" Width="120px" onclick="btn_save_Click1"/>
</asp:Label>
</td>

<td align="left">&nbsp
    <input id="Button3" type="button" value="Đóng" onclick="backs();" style="width:120px;height:25px" class="btn"/>
</td>
<td colspan="2" align="left" style="color:Red">&nbsp <b>Chọn bài viết cần thay đổi<br>Kích thước ảnh 580x250 pixel</b>
</td>
</tr>
<tr>
<td colspan="5" align="left" style="font-size:large;font-weight:bold">
    <asp:Label ID="lbl_error" runat="server" style="text-align: center" 
        ForeColor="#FF3300"></asp:Label>
</td>
</tr>
</table>
<br><br>&nbsp
</div>
</fieldset>
</asp:Content>
