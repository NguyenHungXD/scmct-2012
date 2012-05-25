
$(document).ready(function () {    
    Find(document.getElementById("timKiem"));
    $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ ajax: "../ajax/DM_HANG_HOA_ajax2.aspx?do=luuTable", tablename: "gridTable" });
    });
    $("#timKiem").click(function () {
        Find(this);
    });
    
});
function xoa(control, bool) {
    if (bool || bool == null)
        $(control).XoaRow({ ajax: '../ajax/DM_HANG_HOA_ajax2.aspx?do=xoa' });
}
function Find(control, page) {
    if (page == null) page = "1";
    $(control).TimKiem({
        ajax: "../ajax/DM_HANG_HOA_ajax2.aspx?do=TimKiem&page=" + page
    }, function (data) {
        $("#tableAjax_DM_HANG_HOA").html(data);
        $("table.jtable tr:nth-child(odd)").addClass("odd");
        $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
        $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
    }, function () {
        $("#tableAjax_DM_HANG_HOA").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
        return true;
    });

}
function NHH_IDSearch(obj) {
    $(obj).unautocomplete().autocomplete("../ajax/DM_HANG_HOA_ajax2.aspx?do=NHH_IDSearch", {
        minChars: 0,
        width: 350,
        scroll: true,
        formatItem: function (data) {
            return data[0];
        } 
    }).result(function (event, data) {
        if ($(obj).parents("#gridTable").attr("id") != null) {
            $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#" + obj.id.replace("mkv_", "")).val(data[1]);
            if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                $.mkv.themDongTable("gridTable");
        } else {
            $("#" + obj.id.replace("mkv_", "")).val(data[1]);
        }
        setTimeout(function () {
            obj.focus();
        }, 100);
    });
}
