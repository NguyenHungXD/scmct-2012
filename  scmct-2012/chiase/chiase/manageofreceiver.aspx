<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="manageofreceiver.aspx.cs" Inherits="chiase.manageofreceiver" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content_slider" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" runat="Server">
 <head><link type="text/css" href="css/stocksection.css" rel="Stylesheet"/> </head>
<script src="js/jquery-1.6.1.min.js" type="text/javascript"></script>
<script src="js/jquery-ui.js" type="text/javascript"></script>
<script src="js/jquery.autocomplete.js" type="text/javascript"></script>    
<script src="js/jquery.validate.js" type="text/javascript"></script>
<script src="js/myscriptvalid.js" type="text/javascript"></script>
<script type="text/javascript" src="js/timepicker.js"></script>
<script type="text/javascript" src="js/myscript.js"></script>
<script type="text/javascript" src="js/myscript.jqr.js"></script>
<script type="text/javascript" src="js/treeview.js"></script>

<script type="text/javascript" src="javascript/KH_PHIEU_NHAP_KHO1.js"></script>
    <script type="text/javascript">

        function openPhieu(id) {
            pnk_ID = id;
            var contentUrl = "Receiver.aspx";
            if (pnk_ID != "") contentUrl = contentUrl + "#idkhoachinh=" + pnk_ID; //location=no,status=yes,scrollbars=yes,toolbar=no,menubar=no
            newwindow = window.open(contentUrl, 'mywindow', 'toolbar=no, location=no,directories=no,status=yes,menubar=no,scrollbars=yes,copyhistory=yes,resizable=yes')
            if (window.focus) { newwindow.focus() }
            return false;
        }
        function deletePhieu(id, maphieu) {
            if (!confirm("Bạn có chắc là muốn xóa phiếu " + maphieu + "?"))
                return false;
            $.mkv.loading();
            $.ajax({ type: "GET", cache: false, dataType: "text", url: 'ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=xoa' + "&idkhoachinh" + "=" + id, success: function (value) {
                if ($("#diverror").length > 0)
                    $.mkv.closeMyerror("#diverror");
                $.mkv.myalert("Xóa dữ liệu thành công!", 2000, "success");
                //   $.mkv.New(opt);
                //  $.mkv.XoaTrangData(opt);
                //   $.mkv.ExtendtionLuu(false, opt);
                //    $(control).attr('disabled', false);
                $("#loadingAjax").remove();
                //   if (!$.isNullOrEmpty(after))
                //      after(value)
            }, error: function (data) {
                //  $(control).attr('disabled', false);
                $("#loadingAjax").remove();
                //   $(control).filter(':visible').filter(':enabled').focus();
                if (data.responseText.length)
                    $.mkv.myerror(data.responseText);
                else
                    $.mkv.myerror("Xóa dữ liệu không thành công. Dữ liệu đang sữ dụng!");
            }
            })

        }
        function createNew() {
            pnk_ID = "";
            var contentUrl = "Receiver.aspx";
            newwindow = window.open(contentUrl, 'mywindow', 'toolbar=no, location=no,directories=no,status=yes,menubar=no,scrollbars=yes,copyhistory=yes,resizable=yes')
            if (window.focus) { newwindow.focus() }
            return false;
        }
        function backs() {
            window.location = "admin.aspx";
        }
    /*
        var pnk_ID = "";
        function openPhieu(id) {
            pnk_ID = id;
            pcForm.Show();
        }
        function createNew() {
            pnk_ID = "";
            pcForm.Show();
        }
        function closeUp(s, e) {
            s.SetContentUrl("about:blank");
            Find(document.getElementById("timKiem"));
        }
        function opening(s, e) {
            var contentUrl = "Receiver.aspx";
            if (pnk_ID != "") contentUrl = contentUrl + "#idkhoachinh=" + pnk_ID;
            s.SetContentUrl(contentUrl);
        }
        var i = 0;
        function alo() {
            i++;
            document.getElementById("MA_PNK").value = document.getElementById("NGUOI_NHAP").value + "_" + i;
        }*/

    </script>
        <fieldset style="color:black">

    <div class="body-div">
        <p class="header-div">
QUẢN LÝ&nbsp<%=GetCaption("KH_PHIEU_NHAP_KHO")%>
        </p>

        <div class="in-a">
        <p style="color:Blue;font-weight:bold"><%=GetCaption("DIEU_KIEN_TIM")%></p>
        <hr>
            <div class="div-Out">
              
                    <%=GetCaption("MA_PNK")%>
              
                <p>
                    <input mkv="true" id="MA_PNK" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width:250px;height:25px" class="txtformat" />
                </p>
            </div>
            <div class="div-Out">
              
                    <%=GetCaption("NGUOI_NHAP")%>
               
                <p>
                    <input mkv="true" id="NGUOI_NHAP" type="hidden" />
                    <input mkv="true" id="mkv_NGUOI_NHAP" type="text" onfocus="Find(this);chuyenphim(this);NGUOI_NHAPSearch(this);" 
                        class="down_select" style="width:250px;height:25px" class="txtformat" />
                </p>
            </div>
            <div class="div-Out">
           
                    <%=GetCaption("NGAY_NHAP")%>
            
                <p>
                    <input mkv="true" id="NGAY_NHAP" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width:250px;height:25px" class="down_select" />
                </p>
            </div>
            <div class="div-Out">
          
                    <%=GetCaption("MEM_ID_PNK")%>
         
                <p>
                    <input mkv="true" id="MEM_ID" type="hidden" />
                    <input mkv="true" id="mkv_MEM_ID" type="text" onfocus="Find(this);chuyenphim(this);MEM_IDSearch(this);"
                        class="down_select" style="width:250px;height:25px" class="txtformat" />
                </p>
            </div>
            <div class="div-Out">
     
                    <%=GetCaption("KHO_ID")%>
           
                <p>
                    <input mkv="true" id="KHO_ID" type="hidden" />
                    <input mkv="true" id="mkv_KHO_ID" type="text" onfocus="Find(this);chuyenphim(this);KHO_IDSearch(this);"
                        class="down_select" style="width:250px;height:25px" class="txtformat" />
                </p>
            </div>
            <div class="div-Out">
        
                    <%=GetCaption("DU_AN_ID")%>
         
                <p>
                    <input mkv="true" id="DU_AN_ID" type="hidden" />
                    <input mkv="true" id="mkv_DU_AN_ID" type="text" onfocus="Find(this);chuyenphim(this);DU_AN_IDSearch(this);"
                        class="down_select" style="width:250px;height:25px" class="txtformat" />
                </p>
            </div>
            <div class="div-Out">
   
                    <%=GetCaption("LY_DO_NHAP_ID")%>
         
                <p>
                    <input mkv="true" id="LY_DO_NHAP_ID" type="hidden" />
                    <input mkv="true" id="mkv_LY_DO_NHAP_ID" type="text" onfocus="Find(this);chuyenphim(this);LY_DO_NHAP_IDSearch(this);"
                        class="down_select" style="width:250px;height:25px" class="txtformat" />
                </p>
            </div>
            <div class="div-Out">

                    <%=GetCaption("YEU_CAU_ID")%>
   
                <p>
                    <input mkv="true" id="YEU_CAU_ID" type="hidden" />
                    <input mkv="true" id="mkv_YEU_CAU_ID" type="text" onfocus="Find(this);chuyenphim(this);YEU_CAU_IDSearch(this);"
                        class="down_select" style="width:250px;height:25px" class="txtformat" />
                </p>
            </div>
            <div class="div-Out">
      
                    <%=GetCaption("CHUNG_TU")%>
      
                <p>
                    <input mkv="true" id="CHUNG_TU" type="text" onfocus="Find(this);chuyenphim(this);" style="width:250px;height:25px" class="txtformat" />
                </p>
            </div>
            <div class="div-Out">
            
                    <%=GetCaption("GHI_CHU")%>
      
                <p>
                    <input mkv="true" id="GHI_CHU" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width:250px;height:25px" class="txtformat" />
                </p>
            </div><br>
           
        </div>
         <hr>
            <p align="left">
          
                <input id="timKiem" search="<%=IsView%>" type="button" value="<%=GetCaption("find") %>" class="btn" style="width:120px;height:25px" />
            
            </p>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="false" add="false" type="button" style="display: none" type="button" value="<%=GetCaption("save") %>" class="btn"/>
            <input id="moi" type="button" type="button" style="display: none;width:120px;height:25px" class="btn" value="<%=GetCaption("new") %>" />
            <input id="xoa" delete="false" type="button" style="display:none;width:120px;height:25px" class="btn" value="<%=GetCaption("delete") %>" />
            <input id="addNew" add="<%=IsAdd%>" type="button" value="<%=GetCaption("addnew") %>" onclick="createNew()" class="btn"style="width:120px;height:25px"/> 
            <input id="Button1" type="button" value="<%=GetCaption("dong") %>" onclick="backs();" class="btn" style="width:120px;height:25px"/>
            
        </p>
            <a class="reload" onclick="Find(this)"></a>
            <div class="in-b" id="tableAjax_KH_PHIEU_NHAP_KHO">
        </div>    
    </div>
        </fieldset>
</asp:Content>

