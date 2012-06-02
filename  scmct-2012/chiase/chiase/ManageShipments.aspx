<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="manageShipments.aspx.cs" Inherits="chiase.ManageShipments" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridLookup" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function btn_CreateNew_ClientClick(s, e) {

            txtMaPhieuXuat.SetText("");
            txtChungTu.SetText("");
            cboNguoiXuat.SetValue(null);
            cboLoaiXuat.SetValue(null);
            cboKhoXuat.SetValue(null);
            cboXuatCho.SetValue(null);
            grlDuAn.SetValue(null);
            grlPhieuYeuCau.SetValue(null);           
            dtNgayXuat.SetValue(null);
           

            var totalRow = gridViewHangHoa.GetVisibleRowsOnPage();
            for (var i = 0; i < totalRow; i++) {
                gridViewHangHoa.DeleteRow(i);
            }
            pcPhieuXuat.Show();
        }

// ]]>
    </script>
</asp:Content>
<asp:Content ID="Shipments" ContentPlaceHolderID="content_area" runat="server">
    <fieldset>
        <table>
            <tr>
                <td>
                    <dx:ASPxButton ID="btn_CreateNew" ClientInstanceName="btn_CreateNew" runat="server"
                        Text="Tạo phiếu nhập" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" 
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" 
                        AutoPostBack="False" >
                     <ClientSideEvents Click="btn_CreateNew_ClientClick" />
                     
                    </dx:ASPxButton>
                </td>
                <td>
                    <dx:ASPxButton ID="btn_Search" runat="server" Text="Tìm kiếm" ClientInstanceName="btn_Search"
                        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        
        <br />
        <dx:ASPxPopupControl ID="pcPhieuXuat" runat="server" Height="339px" Width="915px"
            Modal="True" HeaderText="PHIẾU XUẤT HÀNG" PopupHorizontalAlign="WindowCenter"
            PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" ScrollBars="Auto"
            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
            LoadingPanelImagePosition="Top" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
            ClientInstanceName="pcPhieuXuat">
            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
            </LoadingPanelImage>
            <ContentStyle VerticalAlign="Top">
            </ContentStyle>
            <HeaderStyle Font-Bold="True" Font-Size="16pt" HorizontalAlign="Center" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True" BorderColor="Blue">
                    <table width="100%">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend><font  size="2"><b>Thông tin Phiếu xuất</b></font></b></legend>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 107px">
                                                Mã phiếu xuất:
                                            </td>
                                            <td style="width: 193px">
                                                <dx:ASPxTextBox ID="txtMaPhieuXuat" ClientInstanceName="txtMaPhieuXuat" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" Height="16px" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                    Width="180px">
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 72px">
                                                Người xuất:
                                            </td>
                                            <td style="width: 184px">
                                                <dx:ASPxComboBox ID="cboNguoiXuat" ClientInstanceName="cboNguoiXuat" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                                                    SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                                                    Width="182px">
                                                    <LoadingPanelImage Url="~/App_Themes/Aqua/Editors/Loading.gif">
                                                    </LoadingPanelImage>
                                                    <DropDownButton>
                                                        <Image>
                                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                                        </Image>
                                                    </DropDownButton>
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td>
                                                Ngày xuất:
                                            </td>
                                            <td>
                                                <dx:ASPxDateEdit ID="dtNgayXuat" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" Height="16px" ShowShadow="False" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                    Width="179px" ClientInstanceName="dtNgayXuat">
                                                    <CalendarProperties>
                                                        <HeaderStyle Spacing="1px" />
                                                        <FooterStyle Spacing="17px" />
                                                    </CalendarProperties>
                                                    <DropDownButton>
                                                        <Image>
                                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
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
                                            <td style="width: 107px; height: 17px;">
                                                Loại xuất:
                                            </td>
                                            <td style="width: 193px; height: 17px;">
                                                <dx:ASPxComboBox ID="cboLoaiXuat" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                                                    SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                                                    Width="182px" ClientInstanceName="cboLoaiXuat">
                                                    <LoadingPanelImage Url="~/App_Themes/Aqua/Editors/Loading.gif">
                                                    </LoadingPanelImage>
                                                    <DropDownButton>
                                                        <Image>
                                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                                        </Image>
                                                    </DropDownButton>
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td style="width: 72px; height: 17px;">
                                                Kho xuất:
                                            </td>
                                            <td style="width: 184px; height: 17px;">
                                                <dx:ASPxComboBox ID="cboKhoXuat" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                                                    SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                                                    Width="182px" ClientInstanceName="cboKhoXuat">
                                                    <LoadingPanelImage Url="~/App_Themes/Aqua/Editors/Loading.gif">
                                                    </LoadingPanelImage>
                                                    <DropDownButton>
                                                        <Image>
                                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                                        </Image>
                                                    </DropDownButton>
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td style="height: 17px">
                                                Dự án:
                                            </td>
                                            <td style="height: 17px">
                                                <dx:ASPxGridLookup ID="grlDuAn" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" Height="16px" Spacing="0" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                    Width="180px" ClientInstanceName="grlDuAn">
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                    </GridViewProperties>
                                                    <GridViewImages SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                        <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                        </LoadingPanelOnStatusBar>
                                                        <LoadingPanel Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                        </LoadingPanel>
                                                    </GridViewImages>
                                                    <GridViewImagesFilterControl>
                                                        <LoadingPanel Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                        </LoadingPanel>
                                                    </GridViewImagesFilterControl>
                                                    <GridViewStyles>
                                                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                        </Header>
                                                        <LoadingPanel ImageSpacing="5px">
                                                        </LoadingPanel>
                                                    </GridViewStyles>
                                                    <GridViewStylesPager>
                                                        <PageNumber ForeColor="#3E4846">
                                                        </PageNumber>
                                                        <Summary ForeColor="#1E395B">
                                                        </Summary>
                                                    </GridViewStylesPager>
                                                    <GridViewStylesEditors ButtonEditCellSpacing="0">
                                                        <ProgressBar Height="21px">
                                                        </ProgressBar>
                                                    </GridViewStylesEditors>
                                                    <ButtonStyle Width="13px">
                                                    </ButtonStyle>
                                                </dx:ASPxGridLookup>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 107px">
                                                Phiếu yêu cầu:
                                            </td>
                                            <td style="width: 193px">
                                                <dx:ASPxGridLookup ID="grlPhieuYeuCau" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" Height="16px" Spacing="0" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                    Width="182px" ClientInstanceName="grlPhieuYeuCau">
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                    </GridViewProperties>
                                                    <GridViewImages SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                        <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                        </LoadingPanelOnStatusBar>
                                                        <LoadingPanel Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                        </LoadingPanel>
                                                    </GridViewImages>
                                                    <GridViewImagesFilterControl>
                                                        <LoadingPanel Url="~/App_Themes/Office2010Blue/GridView/Loading.gif">
                                                        </LoadingPanel>
                                                    </GridViewImagesFilterControl>
                                                    <GridViewStyles>
                                                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                        </Header>
                                                        <LoadingPanel ImageSpacing="5px">
                                                        </LoadingPanel>
                                                    </GridViewStyles>
                                                    <GridViewStylesPager>
                                                        <PageNumber ForeColor="#3E4846">
                                                        </PageNumber>
                                                        <Summary ForeColor="#1E395B">
                                                        </Summary>
                                                    </GridViewStylesPager>
                                                    <GridViewStylesEditors ButtonEditCellSpacing="0">
                                                        <ProgressBar Height="21px">
                                                        </ProgressBar>
                                                    </GridViewStylesEditors>
                                                    <ButtonStyle Width="13px">
                                                    </ButtonStyle>
                                                </dx:ASPxGridLookup>
                                            </td>
                                            <td style="width: 72px">
                                                Xuất cho:
                                            </td>
                                            <td style="width: 184px">
                                                <dx:ASPxComboBox ID="cboXuatCho" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                                                    SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                                                    Width="182px" ClientInstanceName="cboXuatCho">
                                                    <LoadingPanelImage Url="~/App_Themes/Aqua/Editors/Loading.gif">
                                                    </LoadingPanelImage>
                                                    <DropDownButton>
                                                        <Image>
                                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                                        </Image>
                                                    </DropDownButton>
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td>
                                                Chứng từ:
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtChungTu" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" Height="16px" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                    Width="180px" ClientInstanceName="txtChungTu">
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 286px" valign="top">
                                <fieldset>
                                    <legend><font size="2"><b>Chi tiết phiếu xuất</b></font></legend></font>
                                    <dx:ASPxGridView ID="gridViewHangHoa" runat="server" AutoGenerateColumns="False"
                                        ClientIDMode="AutoID" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                        CssPostfix="Office2010Blue" Width="100%" OnRowInserting="gridViewHangHoa_RowInserting"
                                        OnRowDeleting="gridViewHangHoa_RowDeleting" 
                                        OnRowUpdating="gridViewHangHoa_RowUpdating" 
                                        ClientInstanceName="gridViewHangHoa">
                                        <Columns>
                                            <dx:GridViewDataComboBoxColumn Caption="Mã hàng" Name="colMaHangHoa" ShowInCustomizationForm="True"
                                                VisibleIndex="2">
                                                <PropertiesComboBox ValueType="System.String">
                                                </PropertiesComboBox>
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataTextColumn Caption="Tên hàng" ShowInCustomizationForm="True" VisibleIndex="3"
                                                Name="colTenHangHoa">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Chủng loại" ShowInCustomizationForm="True" VisibleIndex="4"
                                                Name="colChungLoai">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Mã phiếu nhập" ShowInCustomizationForm="True"
                                                VisibleIndex="5" Name="colMaPhieuNhap">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataSpinEditColumn Caption="Số lượng" ShowInCustomizationForm="True"
                                                VisibleIndex="6" Name="colSoLuong">
                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn Caption="Đơn giá" ShowInCustomizationForm="True" VisibleIndex="7"
                                                Name="colDonGia">
                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn Caption="Thành tiền" ShowInCustomizationForm="True"
                                                VisibleIndex="8" Name="colThanhTien">
                                                <PropertiesSpinEdit DisplayFormatString="g">
                                                </PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="0" Name="colEdit">
                                                <EditButton Text="Sửa" Visible="True">
                                                </EditButton>
                                                <NewButton Text="Thêm" Visible="True">
                                                </NewButton>
                                                <CancelButton Text="Hủy">
                                                </CancelButton>
                                                <UpdateButton Text="Xong">
                                                </UpdateButton>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="1" Name="ColDelete">
                                                <DeleteButton Visible="True">
                                                </DeleteButton>
                                                <ClearFilterButton Visible="True">
                                                </ClearFilterButton>
                                            </dx:GridViewCommandColumn>
                                        </Columns>
                                        <SettingsPager PageSize="15" Mode="ShowAllRecords">
                                        </SettingsPager>
                                        <SettingsEditing Mode="Inline" />
                                        <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="250" />
                                        <SettingsText CommandDelete="Xóa" />
                                        <SettingsLoadingPanel ImagePosition="Top" Mode="Disabled" />
                                        <Images SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                            <LoadingPanelOnStatusBar Url="~/App_Themes/Aqua/GridView/gvLoadingOnStatusBar.gif">
                                            </LoadingPanelOnStatusBar>
                                            <LoadingPanel Url="~/App_Themes/Aqua/GridView/Loading.gif">
                                            </LoadingPanel>
                                        </Images>
                                        <ImagesEditors>
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
                                        </ImagesEditors>
                                        <ImagesFilterControl>
                                            <LoadingPanel Url="~/App_Themes/Aqua/Editors/Loading.gif">
                                            </LoadingPanel>
                                        </ImagesFilterControl>
                                        <Styles CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue">
                                            <Header Font-Bold="True" HorizontalAlign="Center">
                                            </Header>
                                            <LoadingPanel ImageSpacing="8px">
                                            </LoadingPanel>
                                        </Styles>
                                        <StylesEditors>
                                            <CalendarHeader Spacing="1px">
                                            </CalendarHeader>
                                            <ProgressBar Height="25px">
                                            </ProgressBar>
                                        </StylesEditors>
                                    </dx:ASPxGridView>
                                </fieldset>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btn_SavePX" runat="server" ClientInstanceName="btn_SavePX" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                CssPostfix="Office2010Blue" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                Text="Lưu" Width="97px" EnableTheming="False" EnableClientSideAPI="True" EnableViewState="False"
                                                OnClick="btn_SavePX_Click">
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btn_ClosePX" runat="server" AutoPostBack="false" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                CssPostfix="Office2010Blue" Height="17px" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                Text="Đóng" Width="86px" ClientInstanceName="btn_ClosePX">
                                                <ClientSideEvents Click="function(s, e) {pcPhieuXuat.Hide();}" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </fieldset>
    <fieldset>
        <legend><font size="2"><b>Điều kiện tìm kiếm</legend>
        <table style="height: 34px">
            <tr>
                <td style="width: 411px; height: 32px;">
                    Mã phiếu xuất:
                </td>
                <td style="width: 219px; height: 32px;">
                    <asp:TextBox ID="TextBox1" runat="server" Width="181px"></asp:TextBox>
                </td>
                <td style="width: 203px" class="col_w280">
                    Người xuất
                </td>
                <td style="width: 219px; height: 32px;">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="28px" Width="176px">
                    </asp:DropDownList>
                </td>
                <td style="width: 325px; height: 32px;">
                    Ngày xuất từ:
                </td>
                <td style="width: 139px; height: 32px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 411px; height: 32px;">
                    Người nhận:
                </td>
                <td style="width: 219px; height: 32px;">
                    <asp:TextBox ID="TextBox2" runat="server" Width="181px"></asp:TextBox>
                </td>
                <td style="width: 203px" class="col_w280">
                    Kho xuất
                </td>
                <td style="width: 219px; height: 32px;">
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="28px" Width="176px">
                    </asp:DropDownList>
                </td>
                <td style="width: 325px; height: 32px;">
                    Ngày xuất đến:
                </td>
                <td style="width: 139px; height: 32px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 411px; height: 32px;">
                    Loại xuất:
                </td>
                <td style="width: 219px; height: 32px;">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="28px" Width="176px">
                    </asp:DropDownList>
                </td>
                <td style="width: 203px" class="col_w280">
                    Chứng từ
                </td>
                <td style="width: 219px; height: 32px;">
                    <asp:TextBox ID="TextBox3" runat="server" Width="181px"></asp:TextBox>
                </td>
                <td style="width: 325px; height: 32px;">
                    &nbsp; Dự án:
                </td>
                <td style="width: 139px; height: 32px;">
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="28px" Width="176px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 411px; height: 32px;">
                    Phiếu yêu cầu:
                </td>
                <td style="width: 219px; height: 32px;">
                    <asp:DropDownList ID="DropDownList5" runat="server" Height="28px" Width="176px">
                    </asp:DropDownList>
                </td>
                <td style="width: 203px" class="col_w280">
                    &nbsp;
                </td>
                <td style="width: 219px; height: 32px;">
                    &nbsp;
                </td>
                <td style="width: 325px; height: 32px;">
                    &nbsp;
                </td>
                <td style="width: 139px; height: 32px;">
                    &nbsp;
                </td>
            </tr>
        </table>
        </b></font>
    </fieldset>
    <fieldset>
        <legend><font size="2"><b>Danh sách phiếu xuất</font></b></legend>
        <table style="height: 188px; margin-left: 0px;">
            <tr>
                <td style="width: 921px; height: 115px;">
                    <asp:GridView ID="gridShipmments" runat="server" Height="169px" Width="100%" AutoGenerateColumns="False"
                        CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:CommandField CancelText="Hủy" DeleteText="Xóa" EditText="Sửa" ShowEditButton="True" />
                            <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                            <asp:BoundField HeaderText="Mã phiếu xuất" />
                            <asp:BoundField HeaderText="Ngày xuất" />
                            <asp:BoundField HeaderText="Người xuất" />
                            <asp:BoundField HeaderText="Chứng từ" />
                            <asp:BoundField HeaderText="Kho xuất" />
                            <asp:BoundField HeaderText="Dự án" />
                            <asp:BoundField HeaderText="Loại xuất" />
                            <asp:BoundField HeaderText="Ghi chú" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
