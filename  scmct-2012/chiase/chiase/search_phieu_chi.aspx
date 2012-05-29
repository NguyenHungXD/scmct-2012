﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_phieu_chi.aspx.cs" Inherits="chiase.search_phieu_chi" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">


<script type="text/JavaScript">
    function return_link(val) {
        var contentUrl = "phieu_chi.aspx?id=" + val;
        window.open(contentUrl, 'mywindow', 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
    }

    function deletes(vmode) {
        var obj = document.forms["chiase"];
        var checked = false;
        if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để hủy.")) {
            if (obj.chk.length > 0) {
                for (i = 0; i < obj.chk.length; i++) {
                    if (obj.chk[i].checked == true) {
                        var url = "search_phieu_chi.aspx?id=" + obj.chk[i].value + "&vmode=" + vmode;
                        loadXMLUpdate(url);
                        checked = true;
                    }
                }
            }
            else {
                if (obj.chk.checked == true) {
                    var url = "search_phieu_chi.aspx?id=" + obj.chk.value + "&vmode=" + vmode;
                    loadXMLUpdate(url);
                    checked = true;
                }
            }
            if (vmode == "del") {
                var error = "Bạn chưa chọn phiếu chi cần xóa!";
                var result = "Xóa thành công!";
            } else {
                var error = "Bạn chưa chọn phiếu chi cần phục hồi!";
                var result = "Phục hồi thành công!";
            }
            if (checked == false)
                document.getElementById("stausinfo").innerHTML = error;
            else {
                document.getElementById("stausinfo").innerHTML = result;

            }
            
        }
    }
    function backs() {
        window.location = "admin.aspx";
    }
</script>



<fieldset>
<fieldset>
    <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;">
        <tr style="color:White;font-weight:bold"><td colspan="8"><font size=3><p align="center">Tìm kiếm phiếu chi</p></font><br>*-Bạn có thể bỏ qua điều kiện bạn không quan tâm.</td></tr>
        <tr>
        <td>
            Mã phiếu chi: 
            </td><td colspan="3">
            <asp:DropDownList ID="dropd_ma_pc" AutoPostBack="false" runat="server" Height="25px" Width="150px" style="font-size:larger">
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
            Người lập:
            </td>
            <td colspan="3">
        <asp:TextBox ID="txt_nguoilap" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td width="15%">
            Từ ngày:
            </td>
            <td>
            <dx:ASPxDateEdit ID="tu_ngay" runat="server" Width="250px" 
            ClientInstanceName="clientEdtStart" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            ShowShadow="False" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
                    EditFormat="Custom" EditFormatString="dd/MM/yyyy" Height="25px">
            <CalendarProperties>
                <HeaderStyle Spacing="1px" />
                <FooterStyle Spacing="17px" />
            </CalendarProperties>
       
            <DropDownButton>
                <Image>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                        PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                </Image>
            </DropDownButton>
            <ValidationSettings>
                <ErrorFrameStyle ImageSpacing="4px">
                    <ErrorTextPaddings PaddingLeft="4px" />
                </ErrorFrameStyle>
            </ValidationSettings>
        </dx:ASPxDateEdit>
        </td>
                <td width="10%">
            Đến ngày:
            </td>
            <td>
            <dx:ASPxDateEdit ID="den_ngay" runat="server" Width="250px" 
            ClientInstanceName="clientEdtStart" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            ShowShadow="False" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" EditFormat="Custom" EditFormatString="dd/MM/yyyy" 
                    Height="25px">
            <CalendarProperties>
                <HeaderStyle Spacing="1px" />
                <FooterStyle Spacing="17px" />
            </CalendarProperties>
       
            <DropDownButton>
                <Image>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                        PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                </Image>
            </DropDownButton>
            <ValidationSettings>
                <ErrorFrameStyle ImageSpacing="4px">
                    <ErrorTextPaddings PaddingLeft="4px" />
                </ErrorFrameStyle>
            </ValidationSettings>
        </dx:ASPxDateEdit>
        </td>
        </tr>

        <tr>
        <td >
            Người nhận tiền:
            </td>
            <td>
            <asp:TextBox ID="txt_nguoi_nhan" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
            </td>
            <td>
            Địa chỉ:
            </td>

            <td>
            <asp:TextBox ID="txt_dia_chi" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
        <td >
            Mã dự án:
            </td>
          <td>  
            <asp:TextBox ID="txt_maduan" runat="server" class="txtformat" Height="25px" 
                  Width="250px"></asp:TextBox>
            </td>
            <td>
            Tên dự án:
            
                        </td>
            <td>
            <asp:TextBox ID="txt_tenduan" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
        
        <tr>
        <td>&nbsp</td><td colspan="3">&nbsp
        
            <dx:ASPxButton ID="btn_search" runat="server" Text="Tìm kiếm" 
                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="149px" 
                onclick="btn_search_Click">
            </dx:ASPxButton>
        
        </td>
        </tr>
        </table>
</fieldset>
<hr>


<asp:Repeater ID="phieu_chi_list" runat="server">
    <HeaderTemplate>
    <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#990099" style="color:White;font-weight:bold"><td align="center" colspan="6">Danh sách phiếu chi</td></tr>
        <tr class="new_post">
        <td width="10%">
            STT
        </td>
        <td width="10%">
            Mã phiếu chi
        </td>
        <td width="10%">
            Người lập/Ngày lập
        </td>


        <td width="10%">
            Người nhận tiền/Địa chỉ
        </td>
        <td width="10%">
            Tổng cộng(VNĐ)
        </td>
        <td width="10%">
            Mã dự án/Tên dự án
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor='#<%# Eval("bgcolors")%>'>
                <td valign="middle" align="center">
            <%= no++ %>.
                    <input name="chk" value="<%#Eval("pc_id") %>" type="checkbox" /> | <img src="images/edit.gif" width="25" height="25" style="cursor:pointer"  onclick=return_link('<%#Eval("pc_id") %>') title='<%#Eval("ma_pc","Sửa phiếu thu {0}") %>'>
        </td>
           <td align="center" >
             <asp:HyperLink style="color:Blue" ID="HyperLink1" runat="server" Target="_blank" title='<%#Eval("ma_pc","Xem phiếu chi {0}") %>' NavigateUrl=<%#Eval("ma_pc","phieu_chi_view.aspx?ma_pc={0}") %>><%# Eval("ma_pc")%></asp:HyperLink>
        </td>
        <td align="center">
            <%# Eval("nguoi_chi_tien")%><br>
           <%# Eval("ngay_chi","{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>
        <td align="center">
            <%# Eval("nguoi_nhan_tien")%><br><%# Eval("address")%>
        </td>
                <td align="center">
             <%# Eval("tong_tien", "{0:###,###,###,###,##0}")%>
        </td>
        <td align="center">
             <%# Eval("maduan")%><br><%# Eval("tenduan")%>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    <tr>
    <td colspan="6" style="color:white;font-weight:bold">
    
    <font color="white"><i>*-Chọn phiếu chi cần xóa</i></font>
    <font color="white"><i><br>*-Phiếu chi đã xóa có nền màu xám</i></font><br>
    <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
    <br>

        <input id="Button1" type="button" value="Xóa phiếu chi" class="btn" style="width:120px;height:30px" onclick="deletes('del');"/>
        <input id="Button3" type="button" value="Phục hồi" class="btn" style="width:120px;height:30px" onclick="deletes('undel');"/>
        <input id="Button2" type="button" value="Hủy" style="width:120px;height:30px" class="btn" onclick="backs();"/><br>&nbsp
    </td>
    </tr>
    </table>
    </FooterTemplate>
    </asp:Repeater>
     <table width="100%">
     <tr align="right">
    <td colspan=3 align=right style="color:White">
    <br>&nbsp Hôm nay,  nay, <%= System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") %>
    </td>
    </tr>
    </table>


    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>

    </fieldset>





</asp:Content>
