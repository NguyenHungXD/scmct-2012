<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="True"
    CodeBehind="CategoryGroupItems.aspx.cs" Inherits="chiase.CategoryGroupItems"
    Title="Danh mục nhóm hàng hóa" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="Server">
    <script type="text/javascript">
  
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="Server">
    <p class="header-div">
        <%=GetCaption("DM_HANG_HOA_NHOM")%>
    </p>
    <br />
    <br />
    <div class="body-div">
        <dx:ASPxTreeList ID="treeList" runat="server" AutoGenerateColumns="False" Width="100%"
            KeyFieldName="ID" ParentFieldName="PARENT_ID" DataSourceID="datasouce1">
            <Settings GridLines="Both" />
            <SettingsBehavior ExpandCollapseAction="NodeDblClick" AllowDragDrop="true" />
            <SettingsEditing Mode="Inline" />
            <Columns>
                <dx:TreeListTextColumn FieldName="NAME" Caption="Tên chủng loại">
                    <EditFormSettings VisibleIndex="0" />
                    <EditFormSettings VisibleIndex="0"></EditFormSettings>
                </dx:TreeListTextColumn>
                <dx:TreeListCommandColumn ShowNewButtonInHeader="true" Width="10%">
                    <EditButton Visible="true" Text="Sửa" />
                    <NewButton Visible="true" Text="Thêm con" />
                    <UpdateButton Visible="false" Text="Lưu" />
                    <CancelButton Visible="false" Text="Hủy" />
                    <EditButton Text="Sửa" Visible="True">
                    </EditButton>
                    <NewButton Text="Th&#234;m con" Visible="True">
                    </NewButton>
                    <UpdateButton Text="Lưu">
                    </UpdateButton>
                    <CancelButton Text="Hủy">
                    </CancelButton>
                    <FooterCellStyle HorizontalAlign="Center">
                    </FooterCellStyle>
                </dx:TreeListCommandColumn>
                <dx:TreeListCommandColumn Width="10%">
                    <DeleteButton Visible="true" Text="Xóa" />
                    <DeleteButton Text="X&#243;a" Visible="True">
                    </DeleteButton>
                    <FooterCellStyle HorizontalAlign="Center">
                    </FooterCellStyle>
                </dx:TreeListCommandColumn>
            </Columns>
            <Settings GridLines="Both"></Settings>
            <SettingsBehavior ExpandCollapseAction="NodeDblClick"></SettingsBehavior>
            <SettingsEditing AllowNodeDragDrop="True" />
            <SettingsText ConfirmDelete="Bạn có chắc là  muốn xóa dữ liệu này?" RecursiveDeleteError="Không thể xóa vì tồn tại dữ liệu con." />
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
    </div>
    <div class="body-div-button">
        <p class="in-a" style="height: 15px">
        </p>
    </div>
</asp:Content>
