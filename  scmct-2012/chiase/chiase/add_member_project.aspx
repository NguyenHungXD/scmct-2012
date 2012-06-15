<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="add_member_project.aspx.cs"
    Inherits="chiase.add_member_project" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridLookup" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>.:SCMCT-Cổng thông tin SCMCT:.</title>
    <meta name="keywords" content="SCMCT, Sách cho miền cát trắng, sach cho mien cat trang, quyen gop sach, sach cu, sach cho tre em ngheo" />
    <meta name="description" content=".::SCMCT - Công quyên góp sách online ::." />
    <link href="Styles/templatemain_style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/ajax_script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
        <script type="text/javascript">
    // <![CDATA[
            function CloseGridLookup() {
                gridLookup.ConfirmCurrentSelection();
                gridLookup.HideDropDown();
            }
            // ]]>
            function lock_project(id, enable, divid) {
                if (enable == 'D') {
                    alert("Dự án đang bị xóa!");
                    return;
                }
                var url = "update_member_project.aspx?id=" + id + "&enable=" + enable + "&vmode=lock";
                loadXMLUpdate(url);

                if (enable == 'N')
                    document.getElementById(divid).innerHTML = "<a style=cursor:pointer title='Khóa'><img src=images/lockicon.gif width=20 height=20 onclick=lock_project(" + id + ",'Y','" + divid + "') /></a>";
                else
                    document.getElementById(divid).innerHTML = "<a style=cursor:pointer title='Mở khóa'><img src=images/unlockicon.gif width=20 height=20 onclick=lock_project(" + id + ",'N','" + divid + "') /></a>";
            }
            function del_project(id, enable, divid, dividlock) {
                var url = "update_member_project.aspx?id=" + id + "&enable=" + enable + "&vmode=del";
                loadXMLUpdate(url);
                if (enable == 'D') {
                    document.getElementById(divid).innerHTML = "<a style=cursor:pointer title='Xóa'><img src=images/deleteicon.gif width=20 height=20 alt='Phục hồi' onclick=del_project(" + id + ",'Y','" + divid + "','" + dividlock + "') /></a>";
                    document.getElementById(dividlock).innerHTML = "<a style=cursor:pointer title='Khóa'><img src=images/lockicon.gif width=20 height=20 onclick=lock_project(" + id + ",'Y','" + dividlock + "') /></a>";
                }
                else {
                    document.getElementById(divid).innerHTML = "<a style=cursor:pointer title='Phục hồi'><img src=images/undeleteicon.gif width=20 height=20 alt=Xóa onclick=del_project(" + id + ",'D','" + divid + "','" + dividlock + "') /></a>";
                    document.getElementById(dividlock).innerHTML = "<a style=cursor:pointer title='Khóa'><img src=images/lockicon.gif width=20 height=20 onclick=lock_project(" + id + ",'D','" + dividlock + "') /></a>";
                }
            }

            function do_update() {
                var obj = document.forms["form1"];
                var checked = false;
                if (typeof (obj.chk) == "undefined") return;
                if (confirm("Xác nhận thay đổi!\n Chọn [OK] để tiếp tục, [Cancel] để Đóng.")) {
                    if (obj.chk.length > 0) {
                        for (i = 0; i < obj.chk.length; i++) {
                            if (obj.chk[i].checked == true) {
                                var url = "update_member_project.aspx?id=" + obj.chk[i].value + "&vmode=approve";
                                loadXMLUpdate(url);
                                checked = true;
                            }
                        }
                    }
                    else {
                        if (obj.chk.checked == true) {
                            var url = "update_member_project.aspx?id=" + obj.chk.value + "&vmode=approve";
                            loadXMLUpdate(url);
                            checked = true;
                        }
                    }
                    if (checked == false)
                        document.getElementById("stausinfo").innerHTML = "Bạn chưa chọn thành viên để xét duyệt cho dự án!"
                    else
                        document.getElementById("stausinfo").innerHTML = "Cập nhật thành công!"
                }

            }

            function backs() {
                window.location = "admin.aspx";
            }

        </script>
        <table border="0" cellpadding="1" cellspacing="2" width="100%">
            <tr>
                <td colspan="3" align="center">
                    <font size="3"><b>
                        <asp:Label ID="lbl_error" runat="server"></asp:Label></b></font>
                    <hr>
                </td>
            </tr>
            <tr>
                <td>
                    Chọn dự án:
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td>
                                <dx:ASPxGridLookup ID="GridLookup" runat="server" ClientInstanceName="gridLookup"
                                    KeyFieldName="ID" Width="300px" AutoGenerateColumns="False" BackColor="#3399FF"
                                    CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Height="25px"
                                    SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" ForeColor="White" TextFormatString="{0}"
                                    Cursor="pointer">
                                    <Columns>
                                        <dx:GridViewDataColumn FieldName="MA_DU_AN" HeaderStyle-Font-Size="16px" Caption="&nbsp;&nbsp;&nbsp;&nbsp;&nbspMã dự án&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp"
                                            CellStyle-Font-Bold="true">
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="TEN_DU_AN" HeaderStyle-Font-Size="16px" Caption="&nbsp;&nbsp;&nbsp;&nbsp;&nbspTên dự án&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp"
                                            CellStyle-Font-Bold="true">
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="NGAY_BAT_DAU" Settings-AllowAutoFilter="False"
                                            HeaderStyle-Font-Size="16px" Caption="&nbsp;&nbsp;&nbsp;&nbsp;&nbspNgày bắt đầu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp"
                                            CellStyle-Font-Bold="true">
                                            <Settings AllowAutoFilter="False"></Settings>
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="NGAY_KET_THUC" Settings-AllowAutoFilter="False"
                                            HeaderStyle-Font-Size="16px" Caption="&nbsp;&nbsp;&nbsp;&nbsp;&nbspNgày kết thúc&nbsp;&nbsp;&nbsp;&nbsp;&nbsp"
                                            CellStyle-Font-Bold="true">
                                            <Settings AllowAutoFilter="False"></Settings>
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="name" HeaderStyle-Font-Size="16px" Caption="&nbsp;&nbsp;&nbsp;&nbsp;&nbspTrạng thái&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp"
                                            CellStyle-Font-Bold="true">
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <GridViewProperties>
                                        <Templates>
                                            <DataRow>
                                                <div class="select_gridview">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td width="20%">
                                                                <b>
                                                                    <%# Eval("MA_DU_AN") %></b>
                                                            </td>
                                                            <td width="30%">
                                                                <%# Eval("TEN_DU_AN") %>
                                                            </td>
                                                            <td width="15%">
                                                                <%#Eval("NGAY_BAT_DAU", "{0:dd/MM/yyyy}")%>
                                                            </td>
                                                            <td width="15%">
                                                                <%#Eval("NGAY_KET_THUC", "{0:dd/MM/yyyy}")%>
                                                            </td>
                                                            <td width="10%">
                                                                <%# Eval("NAME") %>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </DataRow>
                                            <StatusBar>
                                            </StatusBar>
                                        </Templates>
                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                        <SettingsPager PageSize="10" />
                                    </GridViewProperties>
                                    <GridViewImages SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                                        <LoadingPanelOnStatusBar Url="~/App_Themes/Aqua/GridView/gvLoadingOnStatusBar.gif">
                                        </LoadingPanelOnStatusBar>
                                        <LoadingPanel Url="~/App_Themes/Aqua/GridView/Loading.gif">
                                        </LoadingPanel>
                                    </GridViewImages>
                                    <GridViewImagesEditors>
                                        <DropDownEditDropDown>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                        </DropDownEditDropDown>
                                        <SpinEditIncrement>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditIncrementImageHover_Aqua"
                                                PressedCssClass="dxEditors_edtSpinEditIncrementImagePressed_Aqua" />
                                        </SpinEditIncrement>
                                        <SpinEditDecrement>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditDecrementImageHover_Aqua"
                                                PressedCssClass="dxEditors_edtSpinEditDecrementImagePressed_Aqua" />
                                        </SpinEditDecrement>
                                        <SpinEditLargeIncrement>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeIncImageHover_Aqua"
                                                PressedCssClass="dxEditors_edtSpinEditLargeIncImagePressed_Aqua" />
                                        </SpinEditLargeIncrement>
                                        <SpinEditLargeDecrement>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeDecImageHover_Aqua"
                                                PressedCssClass="dxEditors_edtSpinEditLargeDecImagePressed_Aqua" />
                                        </SpinEditLargeDecrement>
                                    </GridViewImagesEditors>
                                    <GridViewImagesFilterControl>
                                        <LoadingPanel Url="~/App_Themes/Aqua/Editors/Loading.gif">
                                        </LoadingPanel>
                                    </GridViewImagesFilterControl>
                                    <GridViewStyles>
                                        <LoadingPanel ImageSpacing="8px">
                                        </LoadingPanel>
                                    </GridViewStyles>
                                    <GridViewStylesEditors>
                                        <CalendarHeader Spacing="1px">
                                        </CalendarHeader>
                                        <ProgressBar Height="25px">
                                        </ProgressBar>
                                    </GridViewStylesEditors>
                                    <DropDownButton>
                                        <Image>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                        </Image>
                                    </DropDownButton>
                                    <ButtonEditEllipsisImage Height="3px" Url="~/App_Themes/Aqua/Editors/edtEllipsis.png"
                                        UrlDisabled="~/App_Themes/Aqua/Editors/edtEllipsisDisabled.png" UrlHottracked="~/App_Themes/Aqua/Editors/edtEllipsisHottracked.png"
                                        UrlPressed="~/App_Themes/Aqua/Editors/edtEllipsisPressed.png" Width="12px">
                                    </ButtonEditEllipsisImage>
                                    <ValidationSettings>
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                    </ValidationSettings>
                                </dx:ASPxGridLookup>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    Chọn thành viên:
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td>
                                <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" ClientInstanceName="gridLookup"
                                    KeyFieldName="id" Width="300px" AutoGenerateColumns="False" BackColor="#3399FF"
                                    CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Height="25px"
                                    SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" ForeColor="White" TextFormatString="{2}"
                                    Cursor="pointer">
                                    <Columns>
                                        <dx:GridViewDataColumn FieldName="id" HeaderStyle-Font-Size="16px" Caption="UserID"
                                            CellStyle-Font-Bold="true">
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="username" HeaderStyle-Font-Size="16px" Caption="Tên đăng nhập"
                                            CellStyle-Font-Bold="true">
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="name" HeaderStyle-Font-Size="16px" Caption="Họ tên&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp"
                                            CellStyle-Font-Bold="true">
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="address" HeaderStyle-Font-Size="16px" Caption="Địa chỉ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp"
                                            CellStyle-Font-Bold="true">
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn FieldName="groupname" HeaderStyle-Font-Size="16px" Caption="Nhóm thành viên"
                                            CellStyle-Font-Bold="true">
                                            <HeaderStyle Font-Size="16px"></HeaderStyle>
                                            <CellStyle Font-Bold="True">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <GridViewProperties>
                                        <Templates>
                                            <DataRow>
                                                <div class="select_gridview">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td rowspan="3">
                                                                <img src='<%# Eval("avatar","images/avatars/{0}") %>' width="50" height="50" />
                                                            </td>
                                                            <td>
                                                                <b>
                                                                    <%# Eval("id") %>
                                                            </td>
                                                            <td>
                                                                <%# Eval("username") %></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>
                                                                    <%# Eval("name") %>
                                                            </td>
                                                            <td>
                                                                <%# Eval("address") %></b>
                                                            </td>
                                                        </tr>
                                                        <!--
                                <tr>
                                <td>Sinh nhật:</td><td><%#Eval("birthday")%></td>
                                </tr>
                                <tr>
                                <td>Giới tính:</td><td><%#Eval("sex")%></td>
                                </tr>
                                -->
                                                        <!--
                                <tr>
                                <td>Email:</td><td><%# Eval("email") %></td>
                                </tr>
                                -->
                                                        <tr>
                                                            <td>
                                                                <%# Eval("joined_date") %>
                                                            </td>
                                                            <td>
                                                                <%# Eval("groupname") %>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </DataRow>
                                            <StatusBar>
                                            </StatusBar>
                                        </Templates>
                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                        <SettingsPager PageSize="5" />
                                    </GridViewProperties>
                                    <GridViewImages SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                                        <LoadingPanelOnStatusBar Url="~/App_Themes/Aqua/GridView/gvLoadingOnStatusBar.gif">
                                        </LoadingPanelOnStatusBar>
                                        <LoadingPanel Url="~/App_Themes/Aqua/GridView/Loading.gif">
                                        </LoadingPanel>
                                    </GridViewImages>
                                    <GridViewImagesEditors>
                                        <DropDownEditDropDown>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                        </DropDownEditDropDown>
                                        <SpinEditIncrement>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditIncrementImageHover_Aqua"
                                                PressedCssClass="dxEditors_edtSpinEditIncrementImagePressed_Aqua" />
                                        </SpinEditIncrement>
                                        <SpinEditDecrement>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditDecrementImageHover_Aqua"
                                                PressedCssClass="dxEditors_edtSpinEditDecrementImagePressed_Aqua" />
                                        </SpinEditDecrement>
                                        <SpinEditLargeIncrement>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeIncImageHover_Aqua"
                                                PressedCssClass="dxEditors_edtSpinEditLargeIncImagePressed_Aqua" />
                                        </SpinEditLargeIncrement>
                                        <SpinEditLargeDecrement>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeDecImageHover_Aqua"
                                                PressedCssClass="dxEditors_edtSpinEditLargeDecImagePressed_Aqua" />
                                        </SpinEditLargeDecrement>
                                    </GridViewImagesEditors>
                                    <GridViewImagesFilterControl>
                                        <LoadingPanel Url="~/App_Themes/Aqua/Editors/Loading.gif">
                                        </LoadingPanel>
                                    </GridViewImagesFilterControl>
                                    <GridViewStyles>
                                        <LoadingPanel ImageSpacing="8px">
                                        </LoadingPanel>
                                    </GridViewStyles>
                                    <GridViewStylesEditors>
                                        <CalendarHeader Spacing="1px">
                                        </CalendarHeader>
                                        <ProgressBar Height="25px">
                                        </ProgressBar>
                                    </GridViewStylesEditors>
                                    <DropDownButton>
                                        <Image>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                        </Image>
                                    </DropDownButton>
                                    <ButtonEditEllipsisImage Height="3px" Url="~/App_Themes/Aqua/Editors/edtEllipsis.png"
                                        UrlDisabled="~/App_Themes/Aqua/Editors/edtEllipsisDisabled.png" UrlHottracked="~/App_Themes/Aqua/Editors/edtEllipsisHottracked.png"
                                        UrlPressed="~/App_Themes/Aqua/Editors/edtEllipsisPressed.png" Width="12px">
                                    </ButtonEditEllipsisImage>
                                    <ValidationSettings>
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                    </ValidationSettings>
                                </dx:ASPxGridLookup>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    Chọn vị trí:
                </td>
                <td>
                    <dx:ASPxGridLookup ID="ASPxGridLookup2" runat="server" ClientInstanceName="gridLookup"
                        KeyFieldName="pos_id" Width="300px" AutoGenerateColumns="False" BackColor="#3399FF"
                        CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Height="25px"
                        SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" ForeColor="White" TextFormatString="{1}"
                        Cursor="pointer">
                        <Columns>
                            <dx:GridViewDataColumn FieldName="pos_id" HeaderStyle-Font-Size="16px" Caption="Pos ID"
                                CellStyle-Font-Bold="true">
                                <HeaderStyle Font-Size="16px"></HeaderStyle>
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn FieldName="post_name" HeaderStyle-Font-Size="16px" Caption="Tên Vị Trí&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp"
                                CellStyle-Font-Bold="true">
                                <HeaderStyle Font-Size="16px"></HeaderStyle>
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                            </dx:GridViewDataColumn>
                        </Columns>
                        <GridViewProperties>
                            <Templates>
                                <DataRow>
                                    <div class="select_gridview">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td width="30%">
                                                    <b>
                                                        <%# Eval("pos_id") %></b>
                                                </td>
                                                <td width="70%">
                                                    <b>
                                                        <%# Eval("post_name") %></b>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </DataRow>
                                <StatusBar>
                                </StatusBar>
                            </Templates>
                            <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
                            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                            <SettingsPager PageSize="20" />
                        </GridViewProperties>
                        <GridViewImages SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelOnStatusBar Url="~/App_Themes/Aqua/GridView/gvLoadingOnStatusBar.gif">
                            </LoadingPanelOnStatusBar>
                            <LoadingPanel Url="~/App_Themes/Aqua/GridView/Loading.gif">
                            </LoadingPanel>
                        </GridViewImages>
                        <GridViewImagesEditors>
                            <DropDownEditDropDown>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                            </DropDownEditDropDown>
                            <SpinEditIncrement>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditIncrementImageHover_Aqua"
                                    PressedCssClass="dxEditors_edtSpinEditIncrementImagePressed_Aqua" />
                            </SpinEditIncrement>
                            <SpinEditDecrement>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditDecrementImageHover_Aqua"
                                    PressedCssClass="dxEditors_edtSpinEditDecrementImagePressed_Aqua" />
                            </SpinEditDecrement>
                            <SpinEditLargeIncrement>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeIncImageHover_Aqua"
                                    PressedCssClass="dxEditors_edtSpinEditLargeIncImagePressed_Aqua" />
                            </SpinEditLargeIncrement>
                            <SpinEditLargeDecrement>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeDecImageHover_Aqua"
                                    PressedCssClass="dxEditors_edtSpinEditLargeDecImagePressed_Aqua" />
                            </SpinEditLargeDecrement>
                        </GridViewImagesEditors>
                        <GridViewImagesFilterControl>
                            <LoadingPanel Url="~/App_Themes/Aqua/Editors/Loading.gif">
                            </LoadingPanel>
                        </GridViewImagesFilterControl>
                        <GridViewStyles>
                            <LoadingPanel ImageSpacing="8px">
                            </LoadingPanel>
                        </GridViewStyles>
                        <GridViewStylesEditors>
                            <CalendarHeader Spacing="1px">
                            </CalendarHeader>
                            <ProgressBar Height="25px">
                            </ProgressBar>
                        </GridViewStylesEditors>
                        <DropDownButton>
                            <Image>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                            </Image>
                        </DropDownButton>
                        <ButtonEditEllipsisImage Height="3px" Url="~/App_Themes/Aqua/Editors/edtEllipsis.png"
                            UrlDisabled="~/App_Themes/Aqua/Editors/edtEllipsisDisabled.png" UrlHottracked="~/App_Themes/Aqua/Editors/edtEllipsisHottracked.png"
                            UrlPressed="~/App_Themes/Aqua/Editors/edtEllipsisPressed.png" Width="12px">
                        </ButtonEditEllipsisImage>
                        <ValidationSettings>
                            <ErrorFrameStyle ImageSpacing="4px">
                                <ErrorTextPaddings PaddingLeft="4px" />
                            </ErrorFrameStyle>
                        </ValidationSettings>
                    </dx:ASPxGridLookup>
                </td>
            </tr>
            <td colspan="3">
                <hr>
            </td>
            </tr>
            <tr>
                <td colspan="3" valign="middle" align="center">
                    <table border="0" cellpadding="2" cellspacing="0" width="80%">
                        <tr>
                            <td valign="middle" align="right" width="40%">
                                <asp:Label ID="lbl_view_member_project" runat="server">
                                    <asp:Button ID="Button3" runat="server" Text="Tìm kiếm" class="btn" Height="25px"
                                        Width="120px" OnClick="find_Click" />
                                </asp:Label>
                            </td>
                            <td valign="middle" align="left" width="60%">
                                <asp:Label ID="lbl_add_member_project" runat="server">
                                    <asp:Button ID="Button1" runat="server" Text="Lưu thông tin" class="btn" Height="25px"
                                        Width="120px" OnClick="btn_create_projects_Click" />
                                </asp:Label>
                                <%--<input id="Button4" type="button" value="Đóng" style="width:120px;height:25px" class="btn" onclick="backs();"/>--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <fieldset>
                        <legend>Dự án:<asp:Label ID="lbl_project" runat="server" Text=""></asp:Label></legend>
                        <asp:Repeater ID="showListmember" runat="server" OnItemDataBound="showListmember_ItemDataBound">
                            <HeaderTemplate>
                                <table border="0" cellpadding="2" cellspacing="1" width="40%" style="border: 0px solid #CCFFFF;">
                                    <tr>
                                        <td valign="middle" align="center">
                                            <img src="images/deleteicon.gif" width="25" height="25">
                                            Xóa
                                        </td>
                                        <td valign="middle" align="center">
                                            <img src="images/undeleteicon.gif" width="25" height="25">
                                            Phục hồi
                                        </td>
                                        <td valign="middle" align="center">
                                            <img src="images/lockicon.gif" width="25" height="25">
                                            Khóa
                                        </td>
                                        <td valign="middle" align="center">
                                            <img src="images/unlockicon.gif" width="25" height="25">
                                            Mở khóa
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="0" cellspacing="1" width="100%" style="border: 1px solid #CCFFFF;">
                                    <tr class="btn_project" style="text-align: center; font-weight: bold;">
                                        <td>
                                            <p>
                                                &nbsp</p>
                                        </td>
                                        <td>
                                            <p>
                                                Tên đăng nhập
                                            </p>
                                        </td>
                                        <td>
                                            Tên thành viên
                                        </td>
                                        <td>
                                            Nhóm
                                        </td>
                                        <td>
                                            Tham gia
                                        </td>
                                        <td>
                                            Vị trí
                                        </td>
                                        <td>
                                            Người tạo
                                        </td>
                                        <td>
                                            <p>
                                                Trạng thái</p>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background-color: #1E90FF; color: #FFFFFF">
                                    <td align="center">
                                        <table cellpadding="1" cellspacing="1" border="0">
                                            <tr>
                                                <td id=<%# Eval("id","'idlock{0}'")%>>
                                                    <asp:Label ID="lbl_member_del" runat="server"><a style=cursor:pointer title='<%#Eval("img_lock_alt")%>'><img src=<%#Eval("img_lock","images/{0}")%> width="20" height="20" alt=""  onclick="lock_project(<%# Eval("id")%>,<%# Eval("active","'{0}'")%>,<%# Eval("id","'idlock{0}'")%>)"/></a> </asp:Label>
                                                </td>
                                                <td id=<%# Eval("id","'iddel{0}'")%>>
                                                    <asp:Label ID="lbl_member_lock" runat="server"> <a style=cursor:pointer title='<%#Eval("img_del_alt")%>'><img src=<%#Eval("img_del","images/{0}")%> width="20" height="20" alt="" onclick="del_project(<%# Eval("id")%>,<%# Eval("active","'{0}'")%>,<%# Eval("id","'iddel{0}'")%>,<%# Eval("id","'idlock{0}'")%>)" /></a> </asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("username")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("name")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("groupname")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("added_date", "{0:dd/MM/yyyy }")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("post_name")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%#Eval("added_name")%>
                                    </td>
                                    <td valign="middle" align="center">
                                        <%# Eval("status1")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <br>
                        <font color="ButtonHighlight" size="4px"><b>
                            <p id="stausinfo" align="center">
                            </p>
                        </b></font>
                        <br>
                        <p align="right">
                            <font color="ButtonHighlight"><b>*-Chọn thành viên cần duyệt cho dự án</b></font><br>
                            <asp:Label ID="lbl_approve_member" runat="server">
            <input id="Button2" type="button" value="Duyệt thành viên" onclick="do_update();" class="btn" style="width:130px;height:25px"/>
                            </asp:Label>
                        </p>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
    </form>
</body>
</html>
