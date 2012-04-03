<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="post_news.aspx.cs" Inherits="chiase.post_news"%>


<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

   <fieldset>
<legend><font size=2 color=white><b>Tạo chủ đề mới</font></b></legend> 
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2><br>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ForeColor="#0000CC"></asp:Label></font><br>
        <hr>
        </td>
    </tr>
          <tr>
    <td>
        Tiêu đề:
    </td>
    <td>
        <asp:TextBox ID="txt_title" runat="server"  class="txtformat" Width="614px" 
            Height="23px"></asp:TextBox>
            </td>
    </tr>
     <tr>
     <td>
     Nội dung:
     </td>
     <td>


         <asp:TextBox ID="txt_content" runat="server" TextMode="MultiLine" class="txtformat_area"></asp:TextBox>

    <br>
     </td>
     </tr>
      <tr>
    <td>
       Sắp xếp:
    </td>
    <td>
        <asp:TextBox ID="txt_sort" runat="server"  class="txtformat" Width="74px" 
            Height="22px"></asp:TextBox>
            </td>
    </tr>
    <tr>
    <td colspan=3 align=left><hr>
    <br>
    </td>
</tr>
    <tr>
    <td colspan=3 align=left><hr>
    <br>
</tr>
<tr>
    <td colspan=3>
        <asp:Button ID="btn_create_news" runat="server" Text="Bài mới" Width="100px" 
            class="btnformat" onclick="btn_create_news_Click1" />
        <asp:Button ID="btn_close" runat="server" Text="Đóng" Width="100px" class="btnformat"/>
    </td>
    </tr>
<tr>
    <td colspan=3 align=right>
    <br>&nbsp Hôm nay, <%= System.DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
     </table>
    </fieldset>
    <br>&nbsp





  
</asp:Content>
