         $(document).ready(function() {
//             setControlFind($.mkv.queryString("idkhoachinh"));
             Find(document.getElementById("timKiem"));
               $("#luu").click(function () {
                   $(this).Luu({
                      ajax:"../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=Luu"
                      },null,function () {
                         $("#timKiem").click();
                   });
                });
                $("#moi").click(function () {
                     $(this).Moi();  
                });
                $("#xoa").click(function () {
                    $(this).Xoa({
                        ajax:'../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=xoa'
                    },null,function () {
                         $("#timKiem").click();
                    });
                });
                $("#timKiem").click(function () {
                    Find(this);
                });
         });
          function setControlFind(idkhoatimkiem) {
              if(idkhoatimkiem != "" && idkhoatimkiem != null){
                 $.BindFind({ajax:"../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});
              }      
          }
           function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=TimKiem&page="+page
               },function (data) {
                     $("#tableAjax_KH_PHIEU_NHAP_KHO").html(data);
                     $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               },function () {
                 $("#tableAjax_KH_PHIEU_NHAP_KHO").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                 return true;
               });
              
          }
        function NGUOI_NHAPSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=NGUOI_NHAPSearch",{
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
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=MEM_IDSearch",{
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
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=KHO_IDSearch",{
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
        function DU_AN_IDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=DU_AN_IDSearch",{
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
        function LY_DO_NHAP_IDSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=LY_DO_NHAP_IDSearch",{
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
             $(obj).unautocomplete().autocomplete("../ajax/KH_PHIEU_NHAP_KHO_ajax1.aspx?do=YEU_CAU_IDSearch",{
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
