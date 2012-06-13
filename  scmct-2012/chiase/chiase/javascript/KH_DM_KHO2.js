
$(document).ready(function () {
    setPerrmissionOnCategory;
    Find(document.getElementById("timKiem"));
    $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ ajax: "ajax/KH_DM_KHO_ajax2.aspx?do=luuTable", tablename: "gridTable" });
    });
    $("#timKiem").click(function () {
        Find(this);
    });
});
function xoa(control, bool) {
    if (bool || bool == null)
        $(control).XoaRow({ ajax: 'ajax/KH_DM_KHO_ajax2.aspx?do=xoa' });
}
function Find(control, page) {
    if (page == null) page = "1";
    $(control).TimKiem({
        ajax: "ajax/KH_DM_KHO_ajax2.aspx?do=TimKiem&page=" + page
    }, function (data) {
        $("#tableAjax_KH_DM_KHO").html(data);
        $("table.jtable tr:nth-child(odd)").addClass("odd");
        $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
        $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
    }, function () {
        $("#tableAjax_KH_DM_KHO").html('<img src="images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>');
        return true;
    });

}
