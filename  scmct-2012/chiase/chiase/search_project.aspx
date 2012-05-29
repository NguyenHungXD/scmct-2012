<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="search_project.aspx.cs" Inherits="chiase.search_project" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

    <%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="server">

<script type="text/JavaScript">
    function lock_project(id, enable, divid) {
        if (enable=='D') {
            alert("Dự án đang bị xóa!");
            return;
        }
        var url = "update_project.aspx?id=" + id + "&enable=" + enable + "&vmode=lock";
        loadXMLUpdate(url);

        if (enable == 'N')
            document.getElementById(divid).innerHTML = "<a style=cursor:pointer title='Khóa'><img src=images/lockicon.gif width=20 height=20 onclick=lock_project(" + id + ",'Y','" + divid + "') /></a>";
        else
            document.getElementById(divid).innerHTML = "<a style=cursor:pointer title='Mở khóa'><img src=images/unlockicon.gif width=20 height=20 onclick=lock_project(" + id + ",'N','" + divid + "') /></a>";
            
       
    }
    function del_project(id, enable,divid,dividlock) {
        var url = "update_project.aspx?id=" + id + "&enable=" + enable + "&vmode=del";
        loadXMLUpdate(url);
        if (enable == 'D') {
            document.getElementById(divid).innerHTML = "<a style=cursor:pointer title='Xóa'><img src=images/deleteicon.gif width=20 height=20 alt='Phục hồi' onclick=del_project(" + id + ",'Y','" + divid + "','" + dividlock + "') /></a>";
            document.getElementById(dividlock).innerHTML = "<a  style=cursor:pointer title='Khóa'><img src=images/lockicon.gif width=20 height=20 onclick=lock_project(" + id + ",'Y','" + dividlock + "') /></a>";
        }
        else
        {
            document.getElementById(divid).innerHTML = "<a style=cursor:pointer title='Phục hồi'><img src=images/undeleteicon.gif width=20 height=20 alt=Xóa onclick=del_project(" + id + ",'D','" + divid + "','" + dividlock + "') /></a>";
            document.getElementById(dividlock).innerHTML = "<a style=cursor:pointer title='Khóa'><img src=images/lockicon.gif width=20 height=20 onclick=lock_project(" + id + ",'D','" + dividlock + "') /></a>";
        }
    }


        function ValidateDates() {
            var startDate = clientEdtStart.GetDate();
            var endDate = clientEdtEnd.GetDate();
            var delta = endDate - startDate;
            var monthDuration = 2678400000;
            if (delta < 0)
                clientEdtEnd.SetDate(startDate);
            else if (delta > monthDuration) {
                clientEdtEnd.SetDate(new Date(startDate.valueOf() + monthDuration));
            }
        }



</script>
<fieldset>
<i><font color="white">*-Tìm kiếm theo điều kiện tương đối - bạn có thể để trống điều kiện bạn không quan tâm.</font></i>
<br>&nbsp
<table cellpadding="3" cellspacing="3" border="0" width="100%">
    <tr>
    <td>
    Mã dự án:
    </td>
    <td colspan="5">
    <asp:TextBox ID="txt_maduan" runat="server" class="txtformat" Height="25px"></asp:TextBox>

    &nbsp;&nbsp;

    Tên dự án:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp

    <asp:TextBox ID="txt_tenduan" runat="server" class="txtformat" Height="25px" Width="372px"></asp:TextBox>
    </td>
    </tr>
    
    <tr>
    <td>
        Ngày bắt đầu:
    </td>
    <td colspan="5">

        <table cellpadding="0" cellspacing="0" border="0" width="55%">
        <tr>
        <td style="width: 123px">
        <dx:ASPxDateEdit ID="start_date" runat="server" Width="150px" 
            ClientInstanceName="clientEdtStart" Height="25px"
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            ShowShadow="False" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
            <CalendarProperties>
                <HeaderStyle Spacing="1px" />
                <FooterStyle Spacing="17px" />
            </CalendarProperties>
       
            <DropDownButton>
                <Image>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                        PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
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
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp
        Ngày kết thúc:
        </td>
        <td>
        <dx:ASPxDateEdit ID="end_date" runat="server" Width="150px" 
            ClientInstanceName="clientEdtEnd" Height="25px"
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            ShowShadow="False" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                <CalendarProperties>
                                    <HeaderStyle Spacing="1px" />
                                    <FooterStyle Spacing="17px" />
                                </CalendarProperties>
                               
                                <DropDownButton>
                                    <Image>
                                        <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                                            PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
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
            </table>

            </td>
    </tr>
    <tr>
    <td>
    Trạng thái:
    </td>
    <td colspan="3">
        <asp:DropDownList ID="dropd_status" runat="server" Height="25px" Width="150px">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>&nbsp
    </td>
    <td align="left"><br>
            <dx:ASPxButton ID="btn_search" runat="server" Text="Tìm kiếm" 
                    CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Width="120px" Height="25px"
                    SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" 
            onclick="btn_search_Click">
            </dx:ASPxButton>
    </td>
    <td colspan="2">&nbsp
    </td>
    </tr>
</table>
</fieldset>
<fieldset>
<!--<legend><b><font size=2 color=white>Danh sách dự án</font></b></legend>-->
 <p align="right"><a style="cursor:pointer" class="btn" id="new_project" title="Tạo dự án mới">Tạo dự án mới</a></p>

                 <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="create_new_project.aspx"
                            EnableViewState="False" PopupElementID="new_project"
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
                            Height="738px" FooterText=""
                            HeaderText="" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>



<asp:Repeater ID="showListProject" runat="server" >
        <HeaderTemplate>
        <table border="0" cellpadding="2" cellspacing="1" width="60%"  style="border:0px solid #CCFFFF;"><tr>
        <td valign="middle" align="center"><img src="images/edit.gif" width="25" height="25">: Sửa</td>
        <td valign="middle" align="center"><img src="images/deleteicon.gif" width="25" height="25">: Xóa</td>
        <td valign="middle" align="center"><img src="images/undeleteicon.gif" width="25" height="25">: Phục hồi</td>
        <td valign="middle" align="center"><img src="images/lockicon.gif" width="25" height="25">: Khóa</td>
        <td valign="middle" align="center"><img src="images/unlockicon.gif" width="25" height="25">: Mở khóa</td>
        <td valign="middle" align="center"><img src="images/add_member.png" width="25" height="25">: Thêm thành viên</td>
        </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="1" width="100%"  style="border:1px solid #CCFFFF;">
        <tr class="new_post">
        <td>
            <img src="images/edit_icon.gif" width="20" height="20" alt="Cập nhật dự án"/>
        </td>
        <td>
            <h6>Mã dự án</h6>
        </td>
        <td>
            <h6>Tên dự án</h6>
        </td>
        <td>
            <h6>Ngày bắt đầu/Kết thúc</h6>
        </td>
        <td>
            <h6>Người tạo/Ngày tạo</h6>
        </td>
        <td>
            <h6>Trạng thái</h6>
        </td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr class="new_post_details">
                    <td with=5% valign="middle" align="center" >
                        <table cellpadding=1 cellspacing=1 border=0><tr>
                        <td id='<%#Eval("MA_DU_AN","add_mem{0}")%>'><a style="cursor:pointer" title="Thêm thành viên cho dự án"><img src="images/add_member.png" width="20" height="20"></a></td>
                        <td><a style="cursor:pointer" title="Cập nhật"><img src="images/edit.gif" width="20" height="20" alt="Cập nhật dự án"/ id='<%#Eval("MA_DU_AN")%>'></a></td>
                        <td id=<%# Eval("id","'idlock{0}'")%>><a style="cursor:pointer" title='<%#Eval("img_lock_alt")%>'><img src=<%#Eval("img_lock","images/{0}")%> width="20" height="20" alt=""  onclick="lock_project(<%# Eval("id")%>,<%# Eval("enable_bit","'{0}'")%>,<%# Eval("id","'idlock{0}'")%>)"/></a></td>
                        <td id=<%# Eval("id","'iddel{0}'")%> ><a style="cursor:pointer" title='<%#Eval("img_del_alt")%>'><img src=<%#Eval("img_del","images/{0}")%> width="20" height="20" alt="" onclick="del_project(<%# Eval("id")%>,<%# Eval("enable_bit","'{0}'")%>,<%# Eval("id","'iddel{0}'")%>,<%# Eval("id","'idlock{0}'")%>)" /></a></td>
                        </tr>
                        </table>

                   <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" 
                    AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl="add_member_project.aspx"
                            EnableViewState="False" PopupElementID='<%#Eval("MA_DU_AN","add_mem{0}")%>'
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="1000px"
                            Height="738px" FooterText=""
                            HeaderText="" ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                            </dx:ASPxPopupControl>

                         <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" AllowDragging="True" AllowResize="True"
                            CloseAction="CloseButton" ContentUrl='<%#Eval("id","edit_project.aspx?id={0}") %>'
                            EnableViewState="False" PopupElementID='<%#Eval("MA_DU_AN")%>'
                            PopupVerticalAlign="Middle" ShowFooter="True" Width="800px"
                            Height="748px" FooterText=<%#Eval("TEN_DU_AN","{0}") %>
                            HeaderText='<%#Eval("MA_DU_AN","Dự án: {0}") %>' ClientInstanceName="FeedPopupControl" 
                            EnableHierarchyRecreation="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua" LoadingPanelImagePosition="Top" 
                            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
                            </LoadingPanelImage>
                            <ContentStyle VerticalAlign="Top">
                            </ContentStyle>
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                                        <ClientSideEvents CloseUp="function(s, e) {       
	                                            location.reload(true);
                                        }" />
                         </dx:ASPxPopupControl>
                     </td>
                    <td with=5% valign=middle align="center">
                    <%#Eval("MA_DU_AN")%>
                    <br>
                    <asp:HyperLink ID="link_more" runat="server" Text="Xem chi tiết" Target="_blank" NavigateUrl='<%#Eval("id","project_detail.aspx?id={0}") %>' style="cursor:pointer;"></asp:HyperLink>
                    </td>
                    <td with=10% valign=middle align="center">
                    <%#Eval("TEN_DU_AN")%>
                    </td>
                    <td with=10% valign=middle align="center">
                    <%#Eval("NGAY_BAT_DAU", "{0:dd/MM/yyyy }")%><br>
                    <%#Eval("NGAY_KET_THUC", "{0:dd/MM/yyyy }")%>
                    </td>
                    <td with=30% valign=middle align="center">
                        <%#Eval("ten_nguoi_tao")%><br>
                        <%#Eval("ngay_tao", "{0:dd/MM/yyyy hh:mm:ss tt}")%>
                    </td>
                    <td with=10% valign=middle align="center">
                        <%#Eval("NAME")%>
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
<fieldset style="background-color:White">
    <asp:Label ID="Label1" runat="server" style="font-weight:bold;color:Blue"></asp:Label>
    <asp:Repeater ID="rptPages" Runat="server" onitemcommand="rptPages_ItemCommand">
    <HeaderTemplate>
    <table cellpadding="0" cellspacing="0" border="0">
    <tr class="text">
    <td><b>Trang : </b>
    <td style="font-weight:bold;font-size:larger;color:Red">
    </HeaderTemplate>
    <ItemTemplate>
    [<asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%#Container.DataItem %>" Runat="server" style="font-weight:bold;color:Blue"><%# Container.DataItem %>
    </asp:LinkButton>]
        
    </ItemTemplate>
    <FooterTemplate>
    
    </td>
    </tr>
    </table>
    </FooterTemplate>
    </asp:Repeater>
    
    </fieldset>
    

    
        </fieldset>
</asp:Content>
