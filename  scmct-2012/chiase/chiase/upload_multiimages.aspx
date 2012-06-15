<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload_multiimages.aspx.cs"   Inherits="chiase.upload_multiimages" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="CuteWebUI.AjaxUploader" Namespace="CuteWebUI" TagPrefix="CuteWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>.:SCMCT-Cổng thông tin SCMCT:.</title>
    <meta name="keywords" content="SCMCT, Sách cho miền cát trắng, sach cho mien cat trang, quyen gop sach, sach cu, sach cho tre em ngheo" />
    <meta name="description" content=".::SCMCT - Công quyên góp sách online ::." />
    <link href="Styles/templatemain_style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

    </script>
    <style type="text/css">
        .inputs
        {
            width: 700px;
            height: 30px;
            background-color: #FFFFFF;
            color: #990099;
        }
        .inputs:hover
        {
            border: 1px solid #FFFFFF;
            background: #99FF00;
            cursor: pointer;
            color: Black;
        }
    </style>
</head>
<body>
    <fieldset>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel3" runat="server" Visible="false">
                    <table border="0" cellpadding="3" cellspacing="3" width="100%" style="color: White">
                        <tr>
                            <td>
                                Tên album:
                            </td>
                            <td>
                                <b>
                                    <%= album_name %></b>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                Chi tiết:
                            </td>
                            <td>
                                <b>
                                    <%= album_detail %></b>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <table border="0" cellpadding="3" cellspacing="3" width="100%" style="color: White">
                        <tr>
                            <td>
                                Tên album:
                            </td>
                            <td>
                                <asp:TextBox ID="txt_album_name" runat="server" class="txtformat" Width="300px" Height="23px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                Mô tả:
                            </td>
                            <td>
                                <asp:TextBox ID="txt_desc" runat="server" class="txtformat_area" Height="138px" TextMode="MultiLine"
                                    Width="545px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp
                            </td>
                            <td>
                                <asp:Button ID="btn_save_album" runat="server" Text="Tạo albumn" class="btn" Height="25px"
                                    Width="120px" OnClick="btn_save_album_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br>
                <asp:Label ID="lbl_error" runat="server" Style="font-size: medium" ForeColor="White"></asp:Label>
                <br>
                <br>
                <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <fieldset style="background-color: #0099FF">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td class="style1">
                                    <i><font color="ButtonHighlight">*-Cho phép upload hình ảnh có định dạng: <b>.JPEG,.JPG,
                                        .GIF, .PNG</b></font></i><br>
                                    <i><font color="ButtonHighlight">*-Chọn thêm ảnh để upload nhiều ảnh</font></i><br>
                                    <i><font color="ButtonHighlight">*-Dụng lượng tập tin tối đa 10MB</font></i><br>
                                    <div id="uploadArea" style="border: 1px solid #CCFF00; ">
                                        <CuteWebUI:UploadAttachments runat="server" ID="ImageFiles" InsertText="Chọn hình"
                                            CancelText="Hủy bỏ" UploadingMsg="Đang tải" CancelAllMsg="Hủy tất cả" 
                                            RemoveButtonText="Xóa" CancelUploadMsg="Hủy upload" 
                                            FileTooLargeMsg="{0} không thể upload !Dung lượng ({1}) lớn hơn dung lượng tối đa cho phép {2}." 
                                            MaxFilesLimitMsg="Số hình ảnh tối đa cho phép {0}." 
                                            WindowsDialogLimitMsg="Không thể chọn quá nhiều cùng một lúc. Tổng chiều dài tên cho phép là 32kb.">
                                            <ValidateOption AllowedFileExtensions="jpeg, jpg, gif, png" MaxSizeKB="10240"  />
                                           <ItemCellStyle ForeColor="Black" />
                                           <InsertButtonStyle CssClass="btn" />  
                                           <CancelButtonStyle CssClass="btn" />    
                                                                         
                                        </CuteWebUI:UploadAttachments>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style2">
                                    <br>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnUploadFiles" runat="server" OnClick="btnUploadFiles_Click" Text="Lưu albumn"
                                        class="btn" Width="120" Height="25" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <font color="white">
                                        <asp:Literal ID="litResult" runat="server"></asp:Literal>
                                    </font>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        </form>
    </fieldset>
</body>
</html>
