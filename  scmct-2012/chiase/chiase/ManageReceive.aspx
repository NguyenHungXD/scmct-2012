<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="ManageReceive.aspx.cs" Inherits="chiase.ManageReceive" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridLookup" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">

    <script language="javascript" type="text/javascript">
// <![CDATA[

        function btn_CreateNew_ClientClick(s, e) {

            txtMaPhieuNhap.SetText("");
            txtChungTu.SetText("");
            cboNguoiNhap.SetValue(null);
            cboLoaiNhap.SetValue(null);
            cboKhoNhap.SetValue(null);
            cboNhapTu.SetValue(null);
            grlDuAn.SetValue(null);
            grlPhieuYeuCau.SetValue(null);
            dtNgayNhap.SetValue(null);


            var totalRow = gridViewHangHoa.GetVisibleRowsOnPage();
            for (var i = 0; i < totalRow; i++) {
                gridViewHangHoa.DeleteRow(i);
            }
            if (gridViewHangHoa.IsEditing() == false)
                gridViewHangHoa.AddNewRow();
            pcPhieuNhap.Show();
        }
           
      function RowDblClickHandler(s, e) {
        s.GetRowValues(e.visibleIndex, 'ID;NAME;MA_HH;NHH_ID;NHH_NAME', OnGetRowValues);
            
           
        }
        function OnGetRowValues(values) {
            gridViewHangHoa.SetEditValue("colHHID", values[0]);
            gridViewHangHoa.SetEditValue("colTenHangHoa", values[1]);
            gridViewHangHoa.SetEditValue("colMaHangHoa", values[2]);
            gridViewHangHoa.SetEditValue("colChungLoaiID", values[3]);
            gridViewHangHoa.SetEditValue("colChungLoaiName", values[4]);       
    }
    function ChungLoaiRowDblClickHandler(s, e) {
      s.GetNodeValues(s.GetFocusedNodeKey(), 'ID;NAME', OnChungLoaiGetRowValues);
        

    }
    function OnChungLoaiGetRowValues(values) {
        gridViewHangHoa.SetEditValue("colChungLoaiID", values[0]);
        gridViewHangHoa.SetEditValue("colChungLoaiNAME", values[1]);
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
                        CssPostfix="Office2010Blue" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        AutoPostBack="False">
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
        <dx:ASPxPopupControl ID="pcPhieuNhap" runat="server" Height="339px" Width="915px"
            Modal="True" HeaderText="PHIẾU NHẬP HÀNG" PopupHorizontalAlign="WindowCenter"
            PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" ScrollBars="Auto"
            CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
            LoadingPanelImagePosition="Top" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
            ClientInstanceName="pcPhieuNhap">
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
                                    <legend><font size="2"><b>Thông tin phiếu nhập</b></font></b></legend>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 107px">
                                                Mã phiếu nhập:
                                            </td>
                                            <td style="width: 193px">
                                                <dx:ASPxTextBox ID="txtMaNhap" ClientInstanceName="txtMaPhieuNhap" runat="server"
                                                    CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
                                                    Height="16px" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                    Width="180px">
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 72px">
                                                Người nhập:
                                            </td>
                                            <td style="width: 184px">
                                                <dx:ASPxComboBox ID="cboNguoiNhap" ClientInstanceName="cboNguoiNhap" runat="server"
                                                    CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
                                                    LoadingPanelImagePosition="Top" ShowShadow="False" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                    ValueType="System.String" Width="182px">
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
                                                Ngày nhập:
                                            </td>
                                            <td>
                                                <dx:ASPxDateEdit ID="dtNgayNhap" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" Height="16px" ShowShadow="False" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                    Width="179px" ClientInstanceName="dtNgayNhap">
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
                                                Loại nhập:
                                            </td>
                                            <td style="width: 193px; height: 17px;">
                                                <dx:ASPxComboBox ID="cboLoaiNhap" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                                                    SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                                                    Width="182px" ClientInstanceName="cboLoaiNhap">
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
                                                Kho nhập:
                                            </td>
                                            <td style="width: 184px; height: 17px;">
                                                <dx:ASPxComboBox ID="cboKhoNhap" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                                                    SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                                                    Width="182px" ClientInstanceName="cboKhoNhap">
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
                                                Nhập từ:
                                            </td>
                                            <td style="width: 184px">
                                                <dx:ASPxComboBox ID="cboNhapTu" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                                                    SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                                                    Width="182px" ClientInstanceName="cboNhapTu">
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
                                    <legend><font size="2"><b>Chi tiết phiếu nhập</b></font></legend></font>
                                    <dx:ASPxGridView ID="gridViewHangHoa" runat="server" AutoGenerateColumns="False"
                                        ClientIDMode="AutoID" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                        CssPostfix="Office2010Blue" Width="100%" OnRowInserting="gridViewHangHoa_RowInserting"
                                        OnRowDeleting="gridViewHangHoa_RowDeleting" OnRowUpdating="gridViewHangHoa_RowUpdating"
                                        ClientInstanceName="gridViewHangHoa">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Mã hàng" ShowInCustomizationForm="True" VisibleIndex="6"
                                                Name="colMaHangHoa">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="PNKCT_ID" Name="colPNKCT_ID" 
                                                ShowInCustomizationForm="True" Visible="False" VisibleIndex="3">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="PNK_ID" Name="colPNK_ID" 
                                                ShowInCustomizationForm="True" Visible="False" VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="HH_ID" Name="colHHID" 
                                                ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDropDownEditColumn Caption="Tên hàng" Name="colTenHangHoa" ShowInCustomizationForm="True"
                                                VisibleIndex="2">
                                                <PropertiesDropDownEdit>
                                                    <DropDownWindowTemplate>
                                                        <dx:ASPxGridView ID="gridViewDMHH" ClientInstanceName="gridViewDMHH" runat="server" OnInit="gridViewDMHH_OnInit"
                                                         ClientIDMode="AutoID" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                        CssPostfix="Office2010Blue" Width="100%"
                                                        OnRowInserting="gridViewDMHH_RowInserting">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn Name="colDNHHID" Caption="ID" FieldName="ID" VisibleIndex="0"
                                                                    Visible="False">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Name="colDMHHMa" Caption="Mã hàng hóa" FieldName="MA_HH"
                                                                    VisibleIndex="0">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Name="colDMHHName" Caption="Tên hàng hóa" FieldName="NAME"
                                                                    VisibleIndex="1">
                                                                </dx:GridViewDataTextColumn>
                                                                
                                                                <dx:GridViewDataTextColumn Name="colDMHHNHomID" Caption="Chủng loại ID" FieldName="NHH_ID"
                                                                   Visible="false" VisibleIndex="-1"> 
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Name="colDMHHNHom" Caption="Chủng loại" FieldName="NHH_NAME"
                                                                    VisibleIndex="2"> 
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Name="colDMHHMoTa" Caption="Mô tả" FieldName="MO_TA" VisibleIndex="2">
                                                                </dx:GridViewDataTextColumn>                                                              
                                                            </Columns>
                                                             <ClientSideEvents RowDblClick="RowDblClickHandler" />

                                                        </dx:ASPxGridView>
                                                        
                                                    </DropDownWindowTemplate>
                                                </PropertiesDropDownEdit>
                                            </dx:GridViewDataDropDownEditColumn>
                                             <dx:GridViewDataTextColumn Caption="NHH_ID" Name="colChungLoaiID" 
                                                ShowInCustomizationForm="True" Visible="False" VisibleIndex="-1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDropDownEditColumn Caption="Chủng loại" ShowInCustomizationForm="True" VisibleIndex="7" Name="colChungLoaiName" >
                                                 <PropertiesDropDownEdit>
                                                  <DropDownWindowTemplate>
                                                  <dx:ASPxTreeList ID="treeListChungLoai" ClientInstanceName="treeListChungLoai" runat="server" AutoGenerateColumns="False" 
                                                   Width="100%" Height="100%"  OnInit="treeListChungLoai_OnInit">                                          
                                                    <Columns>
                                                        <dx:TreeListDataColumn FieldName="NAME" Caption="Tên chủng loại" Width="100%" CellStyle-HorizontalAlign="Left" VisibleIndex="0" />                                                        
                                                        <dx:TreeListDataColumn FieldName="ID" Visible="False" VisibleIndex="-1">                                                           
                                                        </dx:TreeListDataColumn>
                                                         <dx:TreeListDataColumn FieldName="ROOT_ID" Visible="False" VisibleIndex="-1">                                                          
                                                        </dx:TreeListDataColumn>
                                                        <dx:TreeListDataColumn FieldName="PARENT_ID" Visible="False" VisibleIndex="-1">                                                          
                                                        </dx:TreeListDataColumn> 
                                                    </Columns>
                                                    <SettingsBehavior ExpandCollapseAction="NodeDblClick" />
                                                    <ClientSideEvents NodeDblClick="ChungLoaiRowDblClickHandler" />
                                                </dx:ASPxTreeList>
                                                   </DropDownWindowTemplate>
                                                  </PropertiesDropDownEdit>
                                            </dx:GridViewDataDropDownEditColumn>
                                            <dx:GridViewDataSpinEditColumn Caption="Số lượng" ShowInCustomizationForm="True"
                                                VisibleIndex="8" Name="colSoLuong">
                                              
                                              
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn Caption="Đơn giá" ShowInCustomizationForm="True" VisibleIndex="9"
                                                Name="colDonGia">
                                         
                                              
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn Caption="Thành tiền" ShowInCustomizationForm="True"
                                                VisibleIndex="10" Name="colThanhTien">
                                               
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
                                                <ClientSideEvents Click="function(s, e) {pcPhieuNhap.Hide();}" />
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
        <legend><font size="2"><b>Điều kiện tìm kiếm</b></font></legend>
        <table style="width: 100%">
            <tr>
                <td style="width: 107px">
                    Mã phiếu nhập:
                </td>
                <td style="width: 193px">
                    <dx:ASPxTextBox ID="ASPxTextBox1" ClientInstanceName="txtMaPhieuNhap" runat="server"
                        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
                        Height="16px" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Width="180px">
                        <ValidationSettings>
                            <ErrorFrameStyle ImageSpacing="4px">
                                <ErrorTextPaddings PaddingLeft="4px" />
                            </ErrorFrameStyle>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 98px">
                    Ngày nhập từ:
                </td>
                <td style="width: 184px">
                    <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" Height="16px" ShowShadow="False" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Width="179px" ClientInstanceName="dtNgayNhap">
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
                <td>
                    đến ngày:
                </td>
                <td>
                    <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" Height="16px" ShowShadow="False" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Width="179px" ClientInstanceName="dtNgayNhap">
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
                    Loại nhập:
                </td>
                <td style="width: 193px; height: 17px;">
                    <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                        Width="182px" ClientInstanceName="cboLoaiNhap">
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
                <td style="width: 98px; height: 17px;">
                    Kho nhập:
                </td>
                <td style="width: 184px; height: 17px;">
                    <dx:ASPxComboBox ID="ASPxComboBox3" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                        Width="182px" ClientInstanceName="cboKhoNhap">
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
                    <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
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
                    <dx:ASPxGridLookup ID="ASPxGridLookup2" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
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
                <td style="width: 98px">
                    Nhập từ:
                </td>
                <td style="width: 184px">
                    <dx:ASPxComboBox ID="ASPxComboBox4" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                        Width="182px" ClientInstanceName="cboNhapTu">
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
                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
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
            <tr>
                <td style="width: 107px">
                    Người nhập:
                </td>
                <td style="width: 193px">
                    <dx:ASPxComboBox ID="ASPxComboBox1" ClientInstanceName="cboNguoiNhap" runat="server"
                        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
                        LoadingPanelImagePosition="Top" ShowShadow="False" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        ValueType="System.String" Width="182px">
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
                <td style="width: 98px">
                    &nbsp;
                    
                
              
                
                    
                </td>
                <td style="width: 184px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><font size="2"><b>Danh sách phiếu nhập</font></b></legend>
        <table style="height: 188px; margin-left: 0px;">
            <tr>
                <td style="width: 921px; height: 115px;">
                    <asp:GridView ID="gridShipmments" runat="server" Height="169px" Width="100%" AutoGenerateColumns="False"
                        CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:CommandField CancelText="Hủy" DeleteText="Xóa" EditText="Sửa" ShowEditButton="True" />
                            <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                            <asp:BoundField HeaderText="Mã phiếu nhập" />
                            <asp:BoundField HeaderText="Ngày nhập" />
                            <asp:BoundField HeaderText="Người nhập" />
                            <asp:BoundField HeaderText="Chứng từ" />
                            <asp:BoundField HeaderText="Kho nhập" />
                            <asp:BoundField HeaderText="Dự án" />
                            <asp:BoundField HeaderText="Loại nhập" />
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
