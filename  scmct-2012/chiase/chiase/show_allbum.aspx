<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="show_allbum.aspx.cs" Inherits="chiase.show_allbum" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <dx:ASPxButton ID="btn_created_new_allbum" runat="server" 
    Text="Tạo allbum ảnh" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
    CssPostfix="Aqua" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
    Width="150px" onclick="btn_created_new_allbum_Click">
    </dx:ASPxButton>
    <asp:DataList ID="DataList1"  RepeatLayout="Table" RepeatColumns="3"  RepeatDirection="Horizontal" runat="server">
          <ItemTemplate>

                <asp:Image ID="img_fist" runat="server" />
                Tên allbum:<asp:Label ID="lbl_allbum_name" runat="server" Text='<%# Eval("allbum_name") %>'></asp:Label><br />
                <asp:Label ID="lbl_cnt_img" runat="server" Text="20"></asp:Label> hình
                Tạo bới<asp:Label ID="llb_created_by" runat="server" Text='<%#Eval("created_by") %>'></asp:Label><br />
                Ngày,<asp:Label ID="lbl_created_date" runat="server" Text='<%#Eval("created_date") %>'></asp:Label>
                Xem:<asp:Label ID="lbl_viewed" runat="server" Text='<%#Eval("viewed") %>'></asp:Label>
                Thích:<asp:Label ID="lbl_liked" runat="server" Text='<%#Eval("liked") %>'></asp:Label>

        </ItemTemplate>
    </asp:DataList>
</asp:Content>
