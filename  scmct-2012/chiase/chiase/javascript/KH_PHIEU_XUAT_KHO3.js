         $(document).ready(function() {
                 $.mkv.moveUpandDown("#tablefind");
               setControlFind($.mkv.queryString("idkhoachinh"));
                 $("#luu").click(function () {
                   $(this).Luu({
                         ajax:"../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=Luu"
                      },null,function () {
                           $.LuuTable({
                                 ajax:"../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=luuTableKH_PHIEU_XUAT_KHO_CT&PXK_ID=" + $.mkv.queryString("idkhoachinh"),
                                 tablename:"gridTable"
                           });
                      });
                });
                $("#moi").click(function () {
                     $(this).Moi();                    
                     loadTableAjaxKH_PHIEU_XUAT_KHO_CT('');
                });
                $("#xoa").click(function () {
                   $(this).Xoa({
                         ajax:"../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=xoa"
                    },null,function () {
                         loadTableAjaxKH_PHIEU_XUAT_KHO_CT('');
                     });
                });
                $("#timKiem").click(function () {
                    Find($(this)); 
                 });
         });
           function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
                     loadTableAjaxKH_PHIEU_XUAT_KHO_CT($.mkv.queryString("idkhoachinh"));                    
                 });
              }else{loadTableAjaxKH_PHIEU_XUAT_KHO_CT();}         
            }
          function Find(control,page) {
              if(page == null)page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=TimKiem&page="+page
               });
          }
         function xoaontable(control,bool){
           if(bool || bool == null)
              $(control).XoaRow({
                 ajax:"../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=xoaKH_PHIEU_XUAT_KHO_CT"
              });
         }
         function loadTableAjaxKH_PHIEU_XUAT_KHO_CT(idkhoa,page)
         {
             if(idkhoa == null) idkhoa = "";
                 if(page == null) page = "1";
                 $("#tableAjax_KH_PHIEU_XUAT_KHO_CT").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                  $.ajax({
                 type:"GET",
                 cache:false,
                 url:"../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=loadTableKH_PHIEU_XUAT_KHO_CT&PXK_ID="+idkhoa+"&page="+page,
                  success: function (value){
                         document.getElementById("tableAjax_KH_PHIEU_XUAT_KHO_CT").innerHTML=value;
                        $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
                    }
             });
         }
         function HH_IDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=HH_IDSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function PNK_CT_IDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=PNK_CT_IDSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function NGUOI_XUATSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=NGUOI_XUATSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function MEM_IDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=MEM_IDSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function KHO_IDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=KHO_IDSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function LY_DO_XUAT_IDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=LY_DO_XUAT_IDSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function YEU_CAU_IDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_XUAT_KHO_ajax3.aspx?do=YEU_CAU_IDSearch",{
             minChars:0,
             width:350,
             scroll:true,
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
