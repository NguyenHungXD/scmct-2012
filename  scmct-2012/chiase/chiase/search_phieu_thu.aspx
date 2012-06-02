<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_phieu_thu.aspx.cs" Inherits="chiase.search_phieu_thu" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
<script type="text/JavaScript">
        function return_link(val) {
            var contentUrl = "phieu_thu.aspx?id=" + val;
            window.open(contentUrl, 'mywindow', 'toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes,resizable=yes')
        }

        function deletes(vmode) {
            var obj = document.forms["chiase"];
            var checked = false;
            if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để hủy.")) {
                if (obj.chk.length > 0) {
                    for (i = 0; i < obj.chk.length; i++) {
                        if (obj.chk[i].checked == true) {
                            var url = "search_phieu_thu.aspx?id=" + obj.chk[i].value + "&vmode=" + vmode;
                            loadXMLUpdate(url);
                            checked = true;
                        }
                    }
                }
                else {
                    if (obj.chk.checked == true) {
                        var url = "search_phieu_thu.aspx?id=" + obj.chk.value + "&vmode=" + vmode;
                        loadXMLUpdate(url);
                        checked = true;
                    }
                }
                if (checked == false)
                    if (vmode == "del")
                        document.getElementById("stausinfo").innerHTML = "Bạn chưa chọn phiếu thu cần xóa!"
                    else {
                        document.getElementById("stausinfo").innerHTML = "Bạn chưa chọn phiếu thu cần phuc hồi!"
                    }
                else {
                    if(vmode=="del")
                        document.getElementById("stausinfo").innerHTML = "Xóa thành công!"
                    else
                        document.getElementById("stausinfo").innerHTML = "Phục hồi thành công!"
                    }
            }
        }
        function backs() {
            window.location = "admin.aspx";
        }
</script>



<fieldset>
<fieldset>
    <table border="0" cellpadding=3 cellspacing=1 width="100%"  style="border:0px solid #CCFFFF;">
        <tr style="color:White;font-weight:bold"><td colspan="8"><font size=3><p align="center">Tìm kiếm phiếu thu</p></font><br>*-Bạn có thể bỏ qua điều kiện bạn không quan tâm.</td></tr>
        <tr>
        <td >
            Mã phiếu thu: 
            </td><td colspan="3">
            <asp:DropDownList ID="dropd_ma_pt" AutoPostBack="false" runat="server" Height="30px" Width="250px" style="font-size:larger">
            </asp:DropDownList>
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
            Người nộp tiền:
            </td>
            <td>
            <asp:TextBox ID="txt_nguoi_nop" runat="server" class="txtformat" Height="25px" 
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
        <tr>
       <td >
            Người giao tiền:
         </td>
         <td>   
            <asp:TextBox ID="txt_nguoi_giao" runat="server" class="txtformat" Height="25px" 
                 Width="250px"></asp:TextBox>
        </td>

        <td>
            Người lập:
            </td>
            <td>
        <asp:TextBox ID="txt_nguoilap" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
        <tr>

        <td >
            Dự án:
            </td>
          <td>  
            <asp:TextBox ID="txt_duan" runat="server" class="txtformat" Height="25px" 
                  Width="250px"></asp:TextBox>
            </td>


        <td >
            Yêu cầu:
                        </td>
            <td colspan="3">
            
            <asp:TextBox ID="txt_yeu_cau" runat="server" class="txtformat" Height="25px" 
                    Width="250px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>&nbsp</td><td colspan="3">&nbsp
       
            <asp:Label ID="lbl_search_pt" runat="server">
         <asp:Button ID="Button4" runat="server"  Text="Tìm kiếm" class="btn" onclick="btn_search_Click" Height="25px" Width="100px"/>
         </asp:Label>
        </td>
        </tr>
        </table>
</fieldset>
<hr>
<asp:Repeater ID="phieu_thu_list" runat="server" 
        onitemdatabound="phieu_thu_list_ItemDataBound">
    <HeaderTemplate>
    <table border="0" cellpadding=1 cellspacing=1 width="100%"  style="border:1px solid #CCFFFF;color:Black">
        <tr bgcolor="#990099" style="color:White;font-weight:bold"><td align="center" colspan="8">Danh sách phiếu thu</td></tr>
        <tr class="new_post">
        <td width="7%">
            STT
        </td>
        <td width="10%">
            Mã phiếu thu
        </td>
        <td width="10%">
            Người lập/Ngày lập
        </td>


        <td width="10%">
            Người nộp tiền/Địa chỉ
        </td>
       <td width="10%">
            Nhận tiền từ
        </td>
               <td width="5%">
            Tổng cộng(VNĐ)
        </td>
        <td width="10%">
            Mã dự án/Tên dự án
        </td>
        <td width="10%">
            Yêu cầu
        </td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr bgcolor='#<%# Eval("bgcolors")%>'>
                <td valign="middle" align="center">
            <%= no++ %>.
                    <input name="chk" value="<%#Eval("pt_id") %>" type="checkbox" /> 
                    <asp:Label ID="lbl_edit_pt" runat="server" > | <img src="images/edit.gif" width="25" height="25" style="cursor:pointer"  onclick=return_link('<%#Eval("pt_id") %>') title='<%#Eval("ma_pt","Sửa phiếu thu {0}") %>'></asp:Label>




        </td>
            
           <td align="center" >
             <asp:HyperLink style="color:Blue" ID="HyperLink1" runat="server" Target="_blank" title='<%#Eval("ma_pt","Xem phiếu thu {0}") %>' NavigateUrl=<%#Eval("ma_pt","phieu_thu_view.aspx?ma_pt={0}") %>><%# Eval("ma_pt")%></asp:HyperLink>
        </td>
        <td align="center">
            <%# Eval("nguoi_thu_tien")%><br>
           <%# Eval("ngay_thu","{0:dd/MM/yyyy hh:mm:ss tt}")%>
        </td>
        <td align="center">
            <%# Eval("thu_tu")%><br><%# Eval("address")%>
        </td>
        <td align="center">
             <%# Eval("nhan_tien_tu")%>
        </td>
                <td align="center">
             <%# Eval("tong_tien", "{0:###,###,###,###,##0}")%>
        </td>
        <td align="center">
             <b><%# Eval("maduan")%></b><br><%# Eval("tenduan")%>
        </td>
        <td align="center">
             <%# Eval("tieude")%>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
  
    </FooterTemplate>
    </asp:Repeater>
      <tr>
    <td colspan="6" style="color:white;font-weight:bold">
    
    <font color="white"><i>*-Chọn phiếu thu cần xóa/phục hồi</i></font>
    <font color="white"><i><br>*-Phiếu thu đã xóa có nền màu xám</i></font><br>
    <font color="ButtonHighlight" size=4px><b><p id="stausinfo" align="center"></p></b></font><br> 
    <br>
        <asp:Label ID="lbl_del_pt" runat="server">
        <input id="Button1" type="button" value="Xóa phiếu thu" class="btn" style="width:120px;height:25px" onclick="deletes('del');"/>
        <input id="Button3" type="button" value="Phục hồi" class="btn" style="width:120px;height:25px" onclick="deletes('undel');"/>
        </asp:Label>

        <input id="Button2" type="button" value="Hủy" style="width:120px;height:25px" class="btn" onclick="backs();"/><br>&nbsp
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


    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>

    </fieldset>

</asp:Content>
