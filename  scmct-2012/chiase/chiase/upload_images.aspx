<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload_images.aspx.cs" Inherits="chiase.upload_images" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>.:SCMCT-Cổng thông tin SCMCT:.</title>
<meta name="keywords" content="SCMCT, Sách cho miền cát trắng, sach cho mien cat trang, quyen gop sach, sach cu, sach cho tre em ngheo" />
<meta name="description" content=".::SCMCT - Công quyên góp sách online ::." />
<link href="Styles/templatemain_style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function AddFileUploadControl() {
            for (i = 0; i < 4; i++) { //add 3 line at once
                if (!document.getElementById || !document.createElement) {
                    alert("Trình duyệt của bạn không hổ trợ upload nhiều ảnh.");
                    return false;
                }
                var uploadArea = document.getElementById("uploadArea");
                if (!uploadArea)
                    return;
                var newLine = document.createElement("br");
                uploadArea.appendChild(newLine);
                var newFile = document.createElement("input");
                newFile.type = "file";
                newFile.size = "60";
                if (!AddFileUploadControl.lastAssignedId)
                    AddFileUploadControl.lastAssignedId = 1000;
                newFile.setAttribute("id", "dynamic" + AddFileUploadControl.lastAssignedId);
                newFile.setAttribute("name", "dynamic" + AddFileUploadControl.lastAssignedId);
                newFile.setAttribute("class", "inputs");
                uploadArea.appendChild(newFile);
                AddFileUploadControl.lastAssignedId++;
            }
        }
    </script>

    <style type="text/css">
        .inputs
        {
            width: 700px;
            height: 30px;
            background-color:#FFFFFF;
            color:#990099;
        }
        .inputs:hover {
                border: 1px solid #FFFFFF;
                background: #99FF00;
                cursor:pointer;
                color:Black;
            }
    </style>

</head>
<body>
 <form id="form1" runat="server">

 <asp:Panel ID="Panel3" runat="server" Visible="false">



  <table border=0 cellpadding=3 cellspacing=3 width=100% style="color:White">
        <tr>
        <td>
        Tên allbum:
        </td>
        <td>
            <b><%= allbum_name %></b>
        </td>
        </tr>
        <tr>
        <td valign="top">
        Chi tiết:
        </td>
        <td>
           <b><%= allbum_detail %></b>
        </td>         
        </tr>
</table>


</asp:Panel>

<asp:Panel ID="Panel1" runat="server" Visible="false">
  <table border=0 cellpadding=3 cellspacing=3 width=100%>
        <tr>

        <td>
        Tên allbum:
        </td>
        <td>
        <asp:TextBox ID="txt_allbum_name" runat="server" class="txtformat" Width="300px" 
                Height="23px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td valign=top>
        Mô tả:
        </td>
        <td>
        <asp:TextBox ID="txt_desc" runat="server" class="txtformat_area" Height="138px" 
                TextMode="MultiLine" Width="545px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>&nbsp
        </td>
        <td>



            <asp:Button ID="btn_save_allbum" runat="server" Text="Lưu allbum" class="btn" Height="25px" Width="120px" OnClick="btn_save_allbum_Click"/>


        </td>
        </tr>
        </table>
         </asp:Panel>

            <br>
            <asp:Label ID="lbl_error" runat="server" style="font-size:medium" 
     ForeColor="White"></asp:Label>
            <br>
            <br>
<asp:Panel ID="Panel2" runat="server" Visible="false">
 <fieldset style="background-color:#0099FF">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
    <td class="style1">
    <i><font color="ButtonHighlight">*-Cho phép upload hình ảnh có định dạng: <b>.JPG, .GIF, .PNG</b></font></i><br>
    <i><font color="ButtonHighlight">*-Chọn thêm ảnh để upload nhiều ảnh</font></i><br>
    <div id="uploadArea" style="border:1px solid #CCFF00;background-color:White">
        <input type="file" id="File1" runat="server" class="inputs"/>
    </div>
    </td>
    </tr>

    <tr>
    <td align="right" class="style2"><br>
    <input type="button" value="Thêm hình" onclick="AddFileUploadControl();" class="btn" style="width:120px;height:25px"/>
    </td>
    </tr>
        <tr>
    <td>
    <asp:Button ID="btnUploadFiles" runat="server" OnClick="btnUploadFiles_Click" Text="Đăng ảnh" class="btn" Width="120" Height="25"/>
    </td>
    </tr>
            <tr>
    <td align="center"><font color="white">
    <asp:Literal ID="litResult" runat="server"></asp:Literal>
    </font>
    </td>
    </tr>
    </table>
 </fieldset>
        </asp:Panel>


 

    </form>
</body>
</html>
