<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="categorygroupitems.aspx.cs" Inherits="chiase.Catagorygroupitems" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="Server">
<head><link type="text/css" href="css/stocksection.css" rel="Stylesheet"/></head>
<script>
    function backs() {
        window.location = "admin.aspx";
    }
    function backs() {
        window.location = "admin.aspx";
    }
</script>
<fieldset>
    <p class="header-div"><%= GetCaption("DM_HANG_HOA_NHOM")%></p>

        <dx:ASPxTreeList ID="treeList" runat="server" AutoGenerateColumns="False" Width="100%"
            KeyFieldName="ID" ParentFieldName="PARENT_ID" 
        DataSourceID="datasouce1" style="font-weight:bold;color:blue" class="links"  
        CssFilePath="~/App_Themes/PlasticBlue/{0}/styles.css" CssPostfix="PlasticBlue">
            <Settings GridLines="Both" />
            <SettingsBehavior ExpandCollapseAction="NodeDblClick" AllowDragDrop="true" />
            <SettingsPager ShowDefaultImages="False">
                <AllButton Text="All">
                </AllButton>
                <NextPageButton Text="Next &gt;">
                </NextPageButton>
                <PrevPageButton Text="&lt; Prev">
                </PrevPageButton>
            </SettingsPager>
            <SettingsEditing Mode="Inline" />
            <Columns>
                <dx:TreeListTextColumn FieldName="NAME" Caption="Tên chủng loại" >
                    <EditFormSettings VisibleIndex="0" />
                    <EditFormSettings VisibleIndex="0"></EditFormSettings>
                </dx:TreeListTextColumn>
                <dx:TreeListCommandColumn ShowNewButtonInHeader="true" Width="10%">
                    <EditButton Visible="true" Text="Sửa"  />
                    <NewButton Visible="true" Text="Thêm mới" />
                    <UpdateButton Visible="false" Text="Lưu thay đổi" />
                    <CancelButton Visible="false" Text="Đóng" />
                    <EditButton Text="Sửa" Visible="True">
                    </EditButton>
                    <NewButton Text="Thêm mới" Visible="True">
                    </NewButton>
                    <UpdateButton Text="Lưu thay đổi">
                    </UpdateButton>
                    <CancelButton Text="Đóng">
                    </CancelButton>
                    <FooterCellStyle HorizontalAlign="Center">
                    </FooterCellStyle>
                </dx:TreeListCommandColumn>
                <dx:TreeListCommandColumn Width="10%">
                    <DeleteButton Visible="true" Text="Xóa" />
                    <DeleteButton Text="Xóa" Visible="True">
                    </DeleteButton>
                    <FooterCellStyle HorizontalAlign="Center">
                    </FooterCellStyle>
                </dx:TreeListCommandColumn>
            </Columns>
            <Settings GridLines="Both"></Settings>
            <SettingsBehavior ExpandCollapseAction="NodeDblClick"></SettingsBehavior>
            <SettingsEditing AllowNodeDragDrop="True" />
            <SettingsText ConfirmDelete="Bạn có chắc là  muốn xóa dữ liệu này?" RecursiveDeleteError="Không thể xóa vì tồn tại dữ liệu con." />
            <Images SpriteCssFilePath="~/App_Themes/PlasticBlue/{0}/sprite.css">
                <LoadingPanel Url="~/App_Themes/PlasticBlue/GridView/Loading.gif">
                </LoadingPanel>
            </Images>
            <Styles CssFilePath="~/App_Themes/PlasticBlue/{0}/styles.css" 
                CssPostfix="PlasticBlue">
                <CustomizationWindowContent VerticalAlign="Top">
                </CustomizationWindowContent>
            </Styles>
        </dx:ASPxTreeList>
        <asp:SqlDataSource ID="datasouce1" runat="server" DataSourceMode="DataSet" SelectCommand="select * from [DM_HANG_HOA_NHOM]"
            DeleteCommand="delete from [DM_HANG_HOA_NHOM] where [ID]=@ID" UpdateCommand="update [DM_HANG_HOA_NHOM] set [NAME]=@NAME,PARENT_ID=@PARENT_ID where [ID]=@ID"
            InsertCommand="insert into [DM_HANG_HOA_NHOM] ([NAME],PARENT_ID) values (@NAME,@PARENT_ID)">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ID" Type="String" />
                <asp:Parameter Name="NAME" Type="String" />
                <asp:Parameter Name="PARENT_ID" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="String" />
                <asp:Parameter Name="NAME" Type="String" />
                <asp:Parameter Name="PARENT_ID" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>


    <div class="body-div-button">
        
        <p class="in-a" >
           <input id="Button1" type="button" value="Đóng" onclick="backs();" class="btn" style="width:120px;height:25px"/>
        </p>
    </div>
</fieldset>
</asp:Content>
