<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="post_news.aspx.cs" Inherits="chiase.post_news"%>

<%@ Register Assembly="obout_Interface" Namespace="Obout.Interface" TagPrefix="cc1" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Obout.Ajax.UI" Namespace="Obout.Ajax.UI.HTMLEditor" TagPrefix="obout" %>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <obout:Editor ID="Editor1" runat="server" Height="300px" Width="100%" class="txtformat_area">
    </obout:Editor>
    <br>
    <cc1:OboutButton ID="btn_post_news" runat="server" Text="Đăng bài" 
        Width="100px" >
    </cc1:OboutButton>
        <cc1:OboutButton ID="btn_close" runat="server" Text="Đóng" 
        Width="100px" >
    </cc1:OboutButton>
</asp:Content>
