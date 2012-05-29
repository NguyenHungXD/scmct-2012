﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="phieu_chi_view.aspx.cs" Inherits="chiase.phieu_chi_view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">


<fieldset style="font-size:15px">
<table cellpadding=5 cellspacing=0 style="border:1px solid #FFFFFF" width=100% >
<tr style="background-color:#F8F7F7">
<td>
    <table cellpadding=0 cellspacing=0 border=0 width=100% style="background-color:#FFFFFF;color:Black">
    <tr>
        <td valign="middle" rowspan="3">
    <img src="/images/logo_print.png"><br>
    <b>Cổng quyên góp sách online</b>
    </td>
    
    
    <td colspan="2"><br>&nbsp</td></tr>
    <tr>


    <td valign="middle" align="center" colspan="2"><b>
    <p><font size="3px">Nhóm tình nguyện viên SCMCCT</font><br>
    CỔNG THÔNG TIN QUYÊN GÓP SÁCH ONLINE</b>
    </p>
    </td>
    </tr>

    <tr>
    <td>
    <table cellspacing=0><tr><td align="right">
    Địa chỉ  :</td><td>TP.Hồ Chí Minh
    </td></tr>
    <td align="right">
    Email  :</td><td> quantri.scmct@gmail.com
    </td>
    </tr>
    </table>
    </td>
    <td>


        <table cellspacing=0><tr><td align="right">
        Tel  :</td><td> 01643376677
        </td>
        </tr>
        <tr>
        <td align="right">
        Fax  :</td>
        <td> 12345678912
            </tr>
        <tr>
        <td align="right">
        Web  :</td><td> www.chiase.org 
        </td>
        </tr>
        </table>

    </td>
    </tr>
    <tr>
    <td colspan="3">
    <hr style="height:1px">
    </td>
    </tr>
    <tr>
    <td colspan="3" align="center"><br>
        <p>
        <font size="5px"><b>PHẾU CHI</b></font><i> Số:<b> <asp:Label ID="lbl_ma_pc" runat="server" Text=""></asp:Label></b><br>
        Ngày..<asp:Label ID="lbl_days" runat="server" Text=""></asp:Label>..tháng..<asp:Label ID="lbl_months" runat="server" Text=""></asp:Label>..năm <asp:Label ID="lbl_years" runat="server" Text=""></asp:Label></i><br>
            
        Quyển số:....................</i>
        </p><br>&nbsp
    </td>
    </tr>
    <tr>
    <td colspan="3">



    <table width="100%" border=0 >
    <tr>
    <td>&nbsp</td><td width=25% style="font-weight:bold">Họ tên người nhận tiền  :</td><td colspan="3" width=75%> 
        <asp:Label ID="lbl_reciever_name" runat="server" Text=""></asp:Label>
    </td>
    </tr>

    <tr>
    <td>&nbsp</td><td style="font-weight:bold">Địa chỉ  :</td><td colspan="3">  
    <asp:Label ID="lbl_address" runat="server" Text=""></asp:Label>
    </td>
    </tr>

    <tr>
    <td>&nbsp</td><td style="font-weight:bold">Chi cho dự án  :</td><td colspan="3">  

        <asp:Label ID="lbl_project_name" runat="server" ClientIDMode="Static" Text=""></asp:Label>
       
    </td>
    </tr>

           <tr>
    <td>&nbsp</td><td style="font-weight:bold">Ghi chú  : </td><td colspan="3"> 
<asp:Label ID="lbl_note" runat="server" Text=""></asp:Label>
    </td>
    </tr>

    <tr>
    <td>&nbsp</td><td style="font-weight:bold">Số tiền  : </td><td colspan="3"> 
        <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label>
    </td>
    </tr>

    <tr>
    <td>&nbsp</td><td colspan="3" style="font-weight:bold">(Viết bằng chữ)  :<t style="font-weight:normal"><i><asp:Label ID="lbl_text_money" runat="server" Text=""></asp:Label></i></t>
    </td>
    </tr>

        <tr>
    <td>&nbsp</td><td colspan="3">

    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="font-weight:bold">
    <tr>
    <td colspan="9" style="font-weight:bold">Chứng từ kèm theo:<br>&nbsp
    <p align="right" style="font-weight:normal"><i>Ngày..<asp:Label ID="lbl_day" runat="server" Text=""></asp:Label>..tháng..<asp:Label ID="lbl_month" runat="server" Text=""></asp:Label>..năm <asp:Label ID="lbl_year" runat="server" Text=""></asp:Label></i></p><br>
    </td>
    </tr>
    <tr align="center" valign="middle">
    <td>&nbsp</td><td>&nbsp</td><td>Người lập phiếu<p style="font-weight:normal"><font size=-1>(Ký,họ tên)</font></p>
    <t style="font-weight:normal"> <asp:Label ID="lbl_nguoi_lap_phieu" runat="server" Text=""></asp:Label></t>
    </td>
      <td>Người nhận tiền<p style="font-weight:normal"><font size=-1>(Ký,họ tên)</font></p>
      
    </td>
      <td>Thủ quỹ<p style="font-weight:normal"><font size=-1>(Ký,họ tên)</font></p>
    </td>
      <td>Kế toán trưởng<p style="font-weight:normal"><font size=-1>(Ký,họ tên)</font></p>
    </td>
        </td>
      <td>Giám đốc<p style="font-weight:normal"><font size=-1>(Ký,họ tên,đóng dấu)</font></p>
    </td>
    </tr>
    <tr>
    <td colspan="9">
        <br>&nbsp<br>&nbsp
    </td>
    </tr>
    </table>

    </table><p align="right">
        <input id="Button2" type="button" value="In phiếu chi" class="btn" style="width:100px;height:30px" />
        </p>


    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
    </td>
    </tr>
    </table>
</td>
</tr>
</table>
</fieldset>

</asp:Content>
