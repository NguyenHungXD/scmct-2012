<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="manageReceive.aspx.cs" Inherits="chiase.ManageReceive" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridLookup" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxObjectContainer" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
  <script type="text/javascript" src="Scripts/libary.js"></script>
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
            txtTemp.SetText(values[0] + "@" + values[3]);
          
        }
        function ChungLoaiRowDblClickHandler(s, e) {
            s.GetNodeValues(e.nodeKey, 'ID;NAME', OnChungLoaiGetNodeValues);       }

       function OnChungLoaiGetNodeValues(values) {
           //alert(values[0]+ values[1]+ gridViewHangHoa.GetEditValue("colHHID"));
           gridViewHangHoa.SetEditValue("colChungLoaiID", values[0]);
           gridViewHangHoa.SetEditValue("colChungLoaiName", values[1]);
           var text = txtTemp.GetValue();
           //alert(text);
           if (text == null || text == "") {

               txtTemp.SetText("@" + values[0]);
               //alert(txtTemp.GetText());
           }
           else {
             //  alert(text);
               var hhid = text.substr(0, text.indexOf("@"));
               //alert(hhid);
               txtTemp.SetText(hhid + "@" + values[0]);
              // alert(hhid + "--" + txtTemp.GetText());
           }
       }

        function SavePhieuNhapKho(s, e) {

            gridViewHangHoa.SelectAllRowsOnPage();
            if (gridViewHangHoa.IsEditing()==true) {
            alert("Vui lòng hoàn thành thao tác đang nhập trên chi tiết phiếu nhập!");
            return;
            }            
            if(gridViewHangHoa.GetSelectedRowCount() == 0) {
                alert("Vui lòng vào thông tin chi tiết phiếu nhập!");
                return;
            }

            gridViewHangHoa.GetSelectedFieldValues('PNK_CT_ID;HH_ID;MA_HH;NAME;NHH_ID;SO_LUONG;DON_GIA;THANH_TIEN', OnGetRowValuesToSave);
            gridViewHangHoa.SelectAllRowsOnPage(false);

        }
        function OnGetRowValuesToSave(values) {

            var nguoinhap = cboNguoiNhap.GetValue();
            var ngaynhap = dtNgayNhap.GetText();
            var loainhap = cboLoaiNhap.GetValue();
            var khonhap = cboKhoNhap.GetValue();
            var nhaptu = cboNhapTu.GetValue();
            var chungtu = txtChungTu.GetText();
            var ghiChu = txtGhiChu.GetText();
            var idphieuNhap = lblIDPhieuNhap.GetText();

            var gridduan = grlDuAn.GetGridView();
            var duan = gridduan.GetRowKey(gridduan.GetFocusedRowIndex());
            
            var gridyeucau = grlPhieuYeuCau.GetGridView();
            var yeucau = gridyeucau.GetRowKey(gridyeucau.GetFocusedRowIndex());
        

            // alert(nguoinhap + "@" + ngaynhap + "@" + loainhap + "@" + khonhap + "@" + duan + "@" + yeucau + "@" + nhaptu + "@" + chungtu);

            var iserror = false;

            cboNguoiNhap.Validate();
            dtNgayNhap.Validate();
            cboLoaiNhap.Validate();
            cboKhoNhap.Validate();
            cboNhapTu.Validate();
         
            if(cboNguoiNhap.GetIsValid()==false)
                iserror=true;
            if (dtNgayNhap.GetIsValid() == false)
                iserror = true;
            if (cboLoaiNhap.GetIsValid() == false)
                iserror = true;
            if (cboKhoNhap.GetIsValid() == false)
                iserror = true;
            if (cboNhapTu.GetIsValid() == false)
                iserror = true;
            if (iserror == true) {
                alert("Thông tin nhập phiếu nhập chưa hợp lệ, vui lòng nhập lại theo hướng dẫn!");
                return "";
            }


            var list_pnkctid = "";
            var list_hhid = "";
            var list_hhname = "";
            var list_mahh = "";
            var list_hhChungloaiID = "";
           
            var list_soluong = "";
            var list_dongia = "";
            var list_thanhtien = "";




            if (values.length == 0) return;
            for (i = 0; i < values.length; i++) {

                list_pnkctid = list_pnkctid + "~" + values[i][0];
                list_hhid = list_hhid + "~" + values[i][1];
                list_mahh = list_mahh + "~" + values[i][2];
                list_hhname = list_hhname + "~" + values[i][3];
                list_hhChungloaiID = list_hhChungloaiID + "~" + values[i][4];              
                list_soluong = list_soluong + "~" + values[i][5];
                list_dongia = list_dongia + "~" + values[i][6];
                list_thanhtien = list_thanhtien + "~" + values[i][7];
            }

            xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function () {
                if (xmlHttp.readyState == 4) {
                    var value = xmlHttp.responseText;
                    if (value.indexOf("Success")!=-1) {
                        alert("Lưu phiếu nhập thành công!");
                        pcPhieuNhap.Hide();
                    } else if (value.indexOf("Fail")!=-1) {
                        alert("Lưu phiếu nhập không thành công, vui lòng kiểm tra lại dữ liệu!");

                    } else alert(value);
                }
            }

            xmlHttp.open("GET", "Ajax.aspx?do=LuuPhieuNhapKho&idphieunhapkho=" + idphieuNhap + "&nguoinhap=" + nguoinhap
            + "&ngaynhap=" + ngaynhap + "&loainhap=" + loainhap + "&khonhap=" + khonhap + "&duan=" + duan
            + "&yeucau=" + yeucau + "&nhaptu=" + nhaptu + "&chungtu=" + chungtu+"&ghichu="+ghiChu
            + "&list_pnkctid=" + list_pnkctid + "&list_hhid=" + list_hhid + "&list_mahh=" + encodeURIComponent(list_mahh)
            + "&list_hhname=" + encodeURIComponent(list_hhname) + "&list_hhChungloaiID=" + list_hhChungloaiID 
            + "&list_soluong=" + list_soluong + "&list_dongia=" + list_dongia + "&list_thanhtien=" + list_thanhtien
            + "&times=" + Math.random(), true);
            xmlHttp.send(null);

        }
        function YeuCauSelectedChange(s, e) {
            var gr = s.GetGridView();            
            gr.GetRowValues(gr.GetFocusedRowIndex(),"NGUOI_YEU_CAU;YEU_CAU_ID;", YeuCauSelectedValues);
            
        }
        function YeuCauSelectedValues(selectedValues) {

            if (selectedValues.length == 0) return;
            cboNhapTu.SetValue(selectedValues[0]);

        }
        function OnValidate(s, e) {
        if(e.value==null||e.value==""||eval(e.value)==-1)
            e.isValid=false;
    }
    function OnFocusedRowChange(s, e) {
        alert(gridViewHangHoa.GetFocusedRowIndex());
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
                        AutoPostBack="False" OnClick="btn_CreateNew_Click">
                        <%--<ClientSideEvents Click="btn_CreateNew_ClientClick" />--%>
                    </dx:ASPxButton>
                </td>
                <td>
                    <dx:ASPxButton ID="btn_Search" runat="server" Text="Tìm kiếm" ClientInstanceName="btn_Search"
                        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                    </dx:ASPxButton>
                    
                </td>
                <td><input id="IDPhieuNhapKho" type="hidden" value="-1" />
                </td>
            </tr>
        </table>
        <br />
        <dx:ASPxPopupControl ID="pcPhieuNhap" runat="server" Height="500px" Width="915px"
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
                                                    Width="180px" Enabled="False">
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
                                                   Width="182px">
                                                    <LoadingPanelImage Url="~/App_Themes/Aqua/Editors/Loading.gif">
                                                    </LoadingPanelImage>
                                                    <DropDownButton>
                                                        <Image>
                                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                                        </Image>
                                                    </DropDownButton>                                               
                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ErrorText="Vui lòng vào thông tin người nhập!"
                                                        ValidateOnLeave="False">
                                                    </ValidationSettings>
                                                    <ClientSideEvents Validation="OnValidate" />
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
                                                     <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ErrorText="Vui lòng vào thông tin ngày nhập!"
                                                        ValidateOnLeave="False">
                                                    </ValidationSettings>
                                                    <ClientSideEvents Validation="OnValidate" />
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
                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ErrorText="Vui lòng vào thông tin loại nhập!"
                                                        ValidateOnLeave="False">
                                                    </ValidationSettings>
                                                    <ClientSideEvents Validation="OnValidate" />
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
                                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ErrorText="Vui lòng vào thông tin kho nhập!"
                                                        ValidateOnLeave="False">
                                                    </ValidationSettings>
                                                    <ClientSideEvents Validation="OnValidate" />
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td style="height: 17px">
                                                Dự án:
                                            </td>
                                            <td style="height: 17px">
                                                <dx:ASPxGridLookup ID="grlDuAn" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" Height="16px" Spacing="0" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                    Width="180px" ClientInstanceName="grlDuAn" TextFormatString="{0}">
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                        <SettingsPager PageSize="12" Mode="ShowAllRecords"/>
                                                        <Settings ShowFilterRow="True" />  
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
                                                    Width="182px" ClientInstanceName="grlPhieuYeuCau" TextFormatString="{0}">
                                                    <GridViewProperties>
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                        <SettingsPager PageSize="12" Mode="ShowAllRecords"/>
                                                        <Settings ShowFilterRow="True" />                                        
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
                                                    <ClientSideEvents ValueChanged="YeuCauSelectedChange" />
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
                                                   <ValidationSettings ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True" ErrorText="Vui lòng vào thông tin nhập từ!"
                                                        ValidateOnLeave="False">
                                                    </ValidationSettings>
                                                    <ClientSideEvents Validation="OnValidate" />
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
                                        <tr>
                                            <td style="width: 107px" >
                                                Ghi chú:</td>
                                            <td style="width: 193px" colspan="5">
                                                 <dx:ASPxMemo ID="txtGhiChu" ClientInstanceName="txtGhiChu" runat="server" Height="32px" Width="740px"  CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                    CssPostfix="Office2010Blue" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css">
                                                 </dx:ASPxMemo></td>
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
                                        ClientInstanceName="gridViewHangHoa" 
                                        OnRowValidating="gridViewHangHoa_RowValidating" >
                                        <ClientSideEvents FocusedRowChanged= "OnFocusedRowChange" />                                        
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Mã hàng" ShowInCustomizationForm="True" VisibleIndex="6"
                                                Name="colMaHangHoa">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="PNKCT_ID" Name="colPNKCT_ID" ShowInCustomizationForm="True"
                                                Visible="False" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="PNK_ID" Name="colPNK_ID" ShowInCustomizationForm="True"
                                                Visible="False" VisibleIndex="3">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="HH_ID" Name="colHHID" ShowInCustomizationForm="True"
                                                Visible="False"  VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDropDownEditColumn Caption="Tên hàng" Name="colTenHangHoa" ShowInCustomizationForm="True"
                                                VisibleIndex="5" >
                                                <PropertiesDropDownEdit>
                                                    <DropDownWindowTemplate>
                                                        <dx:ASPxGridView ID="gridViewDMHH" ClientInstanceName="gridViewDMHH" runat="server"
                                                            OnInit="gridViewDMHH_OnInit" ClientIDMode="AutoID" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                            CssPostfix="Office2010Blue" Width="100%" >
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
                                                                    Visible="false" VisibleIndex="2">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Name="colDMHHNHom" Caption="Chủng loại" FieldName="NHH_NAME"
                                                                    VisibleIndex="3">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Name="colDMHHMoTa" Caption="Mô tả" FieldName="MO_TA" VisibleIndex="4">
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                            <ClientSideEvents RowDblClick="RowDblClickHandler" />
                                                        </dx:ASPxGridView>
                                                    </DropDownWindowTemplate>                                              
                                                </PropertiesDropDownEdit>                                                
                                            </dx:GridViewDataDropDownEditColumn>
                                            <dx:GridViewDataTextColumn Caption="NHH_ID" Name="colChungLoaiID" ShowInCustomizationForm="True"
                                                Visible="False" VisibleIndex="7">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDropDownEditColumn Caption="Chủng loại" ShowInCustomizationForm="True"
                                                VisibleIndex="8" Name="colChungLoaiName" ReadOnly="True">
                                                <PropertiesDropDownEdit>
                                                    <DropDownWindowTemplate>
                                                        <dx:ASPxTreeList ID="treeListChungLoai" ClientInstanceName="treeListChungLoai" runat="server"
                                                            AutoGenerateColumns="False" Width="100%" Height="100%" OnInit="treeListChungLoai_OnInit">
                                                            <Columns>
                                                                <dx:TreeListDataColumn FieldName="NAME" Caption="Tên chủng loại" Width="100%" CellStyle-HorizontalAlign="Left"
                                                                    VisibleIndex="0" />
                                                                <dx:TreeListDataColumn FieldName="ID" Visible="False" VisibleIndex="-1">
                                                                </dx:TreeListDataColumn>
                                                                <dx:TreeListDataColumn FieldName="ROOT_ID" Visible="False" VisibleIndex="-1">
                                                                </dx:TreeListDataColumn>
                                                                <dx:TreeListDataColumn FieldName="PARENT_ID" Visible="False" VisibleIndex="-1">
                                                                </dx:TreeListDataColumn>
                                                            </Columns>
                                                            <SettingsBehavior ExpandCollapseAction="Button" AutoExpandAllNodes="true" />
                                                            <ClientSideEvents NodeDblClick="ChungLoaiRowDblClickHandler" />
                                                            
                                                        </dx:ASPxTreeList>
                                                    </DropDownWindowTemplate>
                                                </PropertiesDropDownEdit>
                                            </dx:GridViewDataDropDownEditColumn>
                                            <dx:GridViewDataSpinEditColumn Caption="Số lượng" ShowInCustomizationForm="True"
                                                VisibleIndex="9" Name="colSoLuong">
<PropertiesSpinEdit DisplayFormatString="g" MaxValue="9999999999" MinValue="1"></PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn Caption="Đơn giá" ShowInCustomizationForm="True" VisibleIndex="10"
                                                Name="colDonGia">
<PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                            </dx:GridViewDataSpinEditColumn>
                                            <dx:GridViewDataSpinEditColumn Caption="Thành tiền" ShowInCustomizationForm="True"
                                                VisibleIndex="11" Name="colThanhTien">
<PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
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
                                        <SettingsBehavior ConfirmDelete="True" />
                                        <SettingsPager PageSize="12" Mode="ShowAllRecords">
                                        </SettingsPager>
                                        <SettingsEditing Mode="Inline" />
                                        <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="250" />
                                        <SettingsText CommandDelete="Xóa" 
                                            ConfirmDelete="Bạn có chắc là muốn xóa dòng dữ liệu này?" />
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
                                            <dx:ASPxButton ID="btn_SavePX" AutoPostBack="false" runat="server" ClientInstanceName="btn_SavePX" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                CssPostfix="Office2010Blue" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                Text="Lưu" Width="97px" EnableTheming="False" EnableClientSideAPI="True" EnableViewState="False">
                                                <ClientSideEvents Click="SavePhieuNhapKho" />
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btn_ClosePX" runat="server" AutoPostBack="false" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                                CssPostfix="Office2010Blue" Height="17px" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                                                Text="Đóng" Width="86px" ClientInstanceName="btn_ClosePX">
                                                <ClientSideEvents Click="function(s, e) {pcPhieuNhap.Hide();}" />
                                            </dx:ASPxButton>
                                      
                                        </td>
                                        <td>
                                            <dx:ASPxLabel ID="lblIDPhieuNhap" runat="server" 
                                                ClientInstanceName="lblIDPhieuNhap" Text="" ClientVisible="false">
                                                
                                            </dx:ASPxLabel>
                                          <dx:ASPxTextBox ID="txtTemp" runat="server"                                                  
                                                    Width="0px" ClientInstanceName="txtTemp"  ClientVisible="false" EnableTheming="false" Border-BorderStyle="None">
<Border BorderStyle="None"></Border>
                                           </dx:ASPxTextBox>
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
                    <dx:ASPxTextBox ID="txtMaPhieuNhap_M"  runat="server"
                        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
                        Height="16px" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Width="180px" ClientInstanceName="txtMaPhieuNhap_M">
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
                    <dx:ASPxDateEdit ID="dtNgayNhapTu_M" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" Height="16px" ShowShadow="False" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Width="179px" ClientInstanceName="dtNgayNhapTu_M" >
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
                    <dx:ASPxDateEdit ID="dtNgayNhapDen_M" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" Height="16px" ShowShadow="False" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Width="179px" ClientInstanceName="dtNgayNhapDen_M" >
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
                    <dx:ASPxComboBox ID="cboLoaiNhap_M" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                        Width="182px" ClientInstanceName="cboLoaiNhap_M" >
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
                    <dx:ASPxComboBox ID="cboKhoNhap_M" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                        Width="182px" ClientInstanceName="cboKhoNhap_M" >
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
                    <dx:ASPxGridLookup ID="grlDuAn_M" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" Height="16px" Spacing="0" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Width="180px" ClientInstanceName="grlDuAn_M" >
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
                    <dx:ASPxGridLookup ID="grlYeuCau_M" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" Height="16px" Spacing="0" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Width="182px" ClientInstanceName="grlYeuCau_M">
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
                    <dx:ASPxComboBox ID="cboNhapTu_M" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" LoadingPanelImagePosition="Top" ShowShadow="False"
                        SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css" ValueType="System.String"
                        Width="182px" ClientInstanceName="cboNhapTu_M" >
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
                    <dx:ASPxTextBox ID="txtChungTu_M" runat="server" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                        CssPostfix="Office2010Blue" Height="16px" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        Width="180px" ClientInstanceName="txtChungTu_M">
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
                    <dx:ASPxComboBox ID="cboNguoiNhap_M"  runat="server"
                        CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css" CssPostfix="Office2010Blue"
                        LoadingPanelImagePosition="Top" ShowShadow="False" SpriteCssFilePath="~/App_Themes/Office2010Blue/{0}/sprite.css"
                        ValueType="System.String" Width="182px" ClientInstanceName="cboNguoiNhap_M" >
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
        <legend><font size="2"><b>Danh sách phiếu nhập</b></font></legend>
        <table style="height: 188px; margin-left: 0px;">
            <tr>
                <td style="width: 921px; height: 115px;" valign="top">
                    <dx:ASPxGridView ID="gridViewManage" ClientInstanceName="gridViewManage" 
                        runat="server" AutoGenerateColumns="False" 
                        Width="100%" ClientIDMode="AutoID" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"
                                        CssPostfix="Office2010Blue" 
                        onrowcommand="gridViewManage_RowCommand"
                      OnRowDeleting="gridViewManage_RowDeleting"
                       >
                        <Columns>
                        
                            <dx:GridViewDataTextColumn Caption="#" ShowInCustomizationForm="True" 
                                VisibleIndex="1">
                                <DataItemTemplate>
                                    <dx:ASPxButton ID="btnEdit" runat="server" ClientInstanceName="btnEdit" 
                                        CommandArgument="edit" CommandName="edit" Cursor="pointer" 
                                        EnableDefaultAppearance="False" EnableTheming="False" EnableViewState="False" 
                                        ForeColor="#0066CC" Height="10px" Text="Sửa" ViewStateMode="Disabled" 
                                        Width="20px">
                                        <HoverStyle Font-Bold="True" Font-Underline="True" 
                                            ForeColor="#0066CC">
                                        </HoverStyle>
                                    </dx:ASPxButton>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn VisibleIndex="2">
                                <DeleteButton Text="Xóa" Visible="True">
                                </DeleteButton>
                                <ClearFilterButton Visible="True">
                                </ClearFilterButton>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Name="colMaPhieuNhap" Caption="Mã phiếu nhập" 
                                VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="colNgayNhap" Caption="Ngày nhập" 
                                VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="colNguoiNhap" Caption="Người nhập" 
                                VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="colLoaiNhap" Caption="Loại nhập" 
                                VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="colKhoNhap" Caption="Kho nhập" 
                                VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="colDuAn" Caption="Dự án" VisibleIndex="8">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="colYeuCau" Caption="Phiếu yêu cầu" 
                                VisibleIndex="9">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="colNhapTu" Caption="Nhập từ" VisibleIndex="10">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="colChungTu" Caption="Chứng từ" 
                                VisibleIndex="11">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="colGhiChu" Caption="Ghi chú" VisibleIndex="12">
                            </dx:GridViewDataTextColumn>
                        
                            <dx:GridViewDataTextColumn Caption="PNK_ID" Name="colPNKID" 
                                ShowInCustomizationForm="True" Visible="False" VisibleIndex="13">
                            </dx:GridViewDataTextColumn>
                        
                        </Columns>
                        <SettingsBehavior ConfirmDelete="True" />
                        <SettingsPager Mode="ShowAllRecords" PageSize="100">
                        </SettingsPager>
                     
                        <Settings ShowFilterRow="True" />
                     
                        <SettingsText CommandDelete="Xóa" 
                            ConfirmDelete="Bạn có chắc là muốn xóa phiếu nhập này?" />
                     
<Styles CssPostfix="Office2010Blue" CssFilePath="~/App_Themes/Office2010Blue/{0}/styles.css"></Styles>
                        
                    </dx:ASPxGridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
