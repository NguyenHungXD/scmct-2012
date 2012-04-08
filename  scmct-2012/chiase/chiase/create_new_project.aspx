<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="create_new_project.aspx.cs" Inherits="chiase.create_new_project" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

 <fieldset>
<legend><b><font size=2 color=white>Tạo dự án mới</font></b></legend>    
<table border=0 cellpadding =1 cellspacing=2 width =100%>
    <tr>
    <td align=center colspan=2>
        <font size=3><b><asp:Label ID="lbl_error" runat="server" ForeColor="#0000CC"></asp:Label></b></font>
        </td>
    </tr>
    <tr>
    <td colspan=2>
        <hr>
    </td>
    </tr>
        <tr>
    <td>
        Mã dự án:
    </td>
    <td>
        <asp:TextBox ID="txt_project_code" runat="server"  class="txtformat" 
            Width="150px" Height="22px" BackColor="#CCFFCC">
            </asp:TextBox> <i><font color="#0000CC">(Bạn nên thay đổi mã dự án phù hợp)</font></i>
    </td>
    </tr>
    <tr>
    <td>
        Tên dự án:
    </td>
    <td>
        <asp:TextBox ID="txt_project_name" runat="server"  class="txtformat" 
            Width="300px" Height="22px" BackColor="#CCFFCC"></asp:TextBox>
    </td>
    </tr>
        <tr>
    <td>
        Nội dung:
    </td>
    <td>
        <asp:TextBox ID="txt_project_details" runat="server"  class="txtformat_area" 
            Width="600px" Height="109px" BackColor="#CCFFCC" TextMode="MultiLine"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        Ngày bắt đầu dự án:
    </td>
    <td>
        <asp:DropDownList ID="dropd_day_start" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_month_start" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_year_start" runat="server">
        </asp:DropDownList>(dd/mm/yyyy)
    </td>
    </tr>
  
     <tr>
    <td>
        Ngày kết thúc dự án:
    </td>
    <td>
        <asp:DropDownList ID="dropd_day_end" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_month_end" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="dropd_year_end" runat="server">
        </asp:DropDownList>(dd/mm/yyyy)
            </td>
    </tr>
    <tr>
       <td>
           Ghi chú:

    </td>
    <td>
    <asp:TextBox ID="txt_notes" runat="server" class="txtformat_area"
    Width="600px" Height="55px" BackColor="#CCFFCC" Rows="4" TextMode="MultiLine"></asp:TextBox>
    </td>
    </tr>
    <tr>
       <td>
           Trạng thái:
    </td>
    <td>
        <asp:DropDownList ID="dropd_status" runat="server">
        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp<asp:LinkButton ID="btn_add_project_status" runat="server" 
            Text="[Thêm trạng thái]" onclick="btn_add_project_status_Click"></asp:LinkButton>
            
            
            <asp:Panel
                ID="panel_add_new_status" runat="server" BackColor="#0099FF" 
            Direction="LeftToRight" Height="50px" HorizontalAlign="Left" 
            style="margin-left: 102px" Width="500">

 


                <table border=0 cellpadding=3 cellspacing=3 width=20%>
                <tr>
                <td>
                               <asp:TextBox ID="txt_status_project" runat="server" class="txtformat"
    Width="300px" Height="22px" BackColor="#CCFFCC"></asp:TextBox>
                </td>
                <td align=right>
                    <dx:ASPxButton ID="btn_add_stutus_names" runat="server" Text="Tạo mới" 
                        CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" CssPostfix="SoftOrange" 
                        SpriteCssFilePath="~/App_Themes/SoftOrange/{0}/sprite.css" Width="80px" 
                        onclick="btn_add_stutus_names_Click">
                    </dx:ASPxButton>
                </td>
                <td align=left>
                    <dx:ASPxButton ID="btn_close" runat="server" Text="Đóng" 
                        CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css" CssPostfix="SoftOrange" 
                        onclick="btn_close_Click2" SpriteCssFilePath="~/App_Themes/SoftOrange/{0}/sprite.css" 
                        Width="80px">
                    </dx:ASPxButton>
                </td>
                </tr>
                </table>

     </asp:Panel> 





        </td>
    </tr>
    <tr>
    <td colspan=3 align=left><hr><br>
       
               <table border=0 cellpadding=3 cellspacing=3 width=20%>
                <tr>
                <td align=right>
                    <dx:ASPxButton ID="btn_create_projects" runat="server" Text="Tạo mới" 
                        CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                        SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="150px" 
                        onclick="btn_create_projects_Click">
                    </dx:ASPxButton>
                </td>
                <td align=left>
                    <dx:ASPxButton ID="btn_back" runat="server" Text="Trở lại" 
                        CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                        onclick="btn_back_Click" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                        Width="150px">
                    </dx:ASPxButton>
                </td>
                </tr>
                </table>
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
