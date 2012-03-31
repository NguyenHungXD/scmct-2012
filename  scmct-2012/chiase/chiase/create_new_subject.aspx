<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="create_new_subject.aspx.cs" Inherits="chiase.create_new_subject" %>

<%@ Register Assembly="obout_Interface" Namespace="Obout.Interface" TagPrefix="cc1" %>
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
        Chi tiết:
    </td>
    <td>
        <asp:TextBox ID="txt_description" runat="server"  class="txtformat_area" Width="623px" 
            Height="111px" TextMode="MultiLine"></asp:TextBox>
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
    <td colspan=3 align=left><hr>bb
    <br>
    </td>
</tr>

      <tr>
    <td>
       Trạng thái:
    </td>
    <td>
        <cc1:OboutDropDownList ID="dropd_status" runat="server">
        </cc1:OboutDropDownList>
    </td>
    </tr>

    <tr>
    <td colspan=3 align=left><hr>
    <br>

</tr>


<tr>
    <td colspan=3>
        <asp:Button ID="btn_create_new_subject" runat="server" Text="Tạo chủ đề mới" 
            onclick="btn_create_new_subject_Click" />
        <asp:Button ID="btn_close" runat="server" Text="Đóng" Width="100px" />

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
