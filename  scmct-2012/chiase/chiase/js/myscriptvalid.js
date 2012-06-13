

function TinhTien(control) {
    try {
        var tr = control.parentNode.parentNode;
        var table = tr.parentNode.parentNode;

        var dongia = $("#" + table.id).find("tr").eq(tr.rowIndex).find("[id=DON_GIA]")[0];
        var thanhtien = $("#" + table.id).find("tr").eq(tr.rowIndex).find("[id=THANH_TIEN]")[0];
        var soluong = $("#" + table.id).find("tr").eq(tr.rowIndex).find("[id=SO_LUONG]")[0];
        if (soluong == null || dongia == null || thanhtien == null)
            return;
        if (soluong.value == "" || dongia.value == "") {
            thanhtien.value = "";
            return;
        }
        var sl = eval(soluong.value);
        var dg = eval(dongia.value);
        thanhtien.value = sl * dg;
    } catch (ex) {
       
    }
}
function TinhDonGia(control) {
    try {
        var tr = control.parentNode.parentNode;
        var table = tr.parentNode.parentNode;

        var dongia = $("#" + table.id).find("tr").eq(tr.rowIndex).find("[id=DON_GIA]")[0];
        var thanhtien = $("#" + table.id).find("tr").eq(tr.rowIndex).find("[id=THANH_TIEN]")[0];
        var soluong = $("#" + table.id).find("tr").eq(tr.rowIndex).find("[id=SO_LUONG]")[0];
        if (soluong == null || dongia == null || thanhtien == null)
            return;
        if (soluong.value == "" || thanhtien.value == "") {
            dongia.value = "";
            return;
        }
        var sl = eval(soluong.value);
        var tt = eval(thanhtien.value);
        if (sl <= 0)
            dongia.value = "";
        else
            dongia.value = tt / sl;
    } catch (ex) {

    }
}


//TypeCtrl: T: text, N: Number
function isAllEmpty(IdCtlInputs, typeCtrl) {
    
    var ctlInput = null;
    var ctlType = null;
    for (i = 0; i < IdCtlInputs.length; i++) {
        ctlInput = IdCtlInputs[i];
        ctlType = typeCtrl[i];
        if (typeof (ctlInput) == "string")
            ctlInput = document.getElementById(ctlInput);
        if (ctlInput == null) continue;
        ctlInput.style.borderColor ="";
        ctlInput.title = "";
        if (ctlType == "T")//dạng text
        {
            if (ctlInput.value != null && $.trim(ctlInput.value).length > 0)
                return false;
        }
        if (ctlType == "N") {

            if (ctlInput.value != null && $.trim(ctlInput.value).length > 0) {
                try {
                    var val = eval(ctlInput.value);
                    if (val > 0)
                        return false;
                } catch (ex) {
                    return false;
                }
            }

        }

    }
    return true;
}

//typeChecks:  R: required; D: date; Z: >0  cách nhau khoảng trắng, ví dụ: "R N" : bắt buộc, nhập, kiểu số
//Phải truyền đầy đủ tham số, và đúng chiều dài của 4 mảng, giá trị của mãng nào ko có thì để giá trị "null"
var errorColor = "#FF3300";
function checkRequiredArray(captions, IdCtlInputs, IdCtlValues,typeChecks) {
  
    var error = 0;
    var caption = null;
    var ctlInput = null;
    var ctlValue = null;
    var typeCheck = null;
    var i = 0;
    for (i = 0; i < IdCtlInputs.length; i++) {
        caption = captions[i];
        ctlInput = IdCtlInputs[i];
        if (typeof (ctlInput) == "string")
            ctlInput = document.getElementById(ctlInput);
        ctlValue = IdCtlValues[i];
        if (ctlValue != null && typeof (ctlValue) == "string")
            ctlValue = document.getElementById(ctlValue);
        typeCheck = typeChecks[i];
        //Kiểm tra lỗi bắt buộc nhập
        if (typeCheck.indexOf("R") > -1) {
            if (ctlValue != null && ctlInput != null) {
                
                if (ctlValue.value == null || ctlValue.value == "") {
                    ctlInput.style.borderColor = errorColor;
                    ctlInput.title = "Vui lòng vào thông tin \"" + caption + "\"!";
                    error++;
                    continue;
                }
                else {
                    if (typeCheck.indexOf("Z") > -1) {
                       
                        try {
                            var val = eval(control.value) * 1;
                            if (val <= 0) {
                                ctlInput.style.borderColor = errorColor;
                                ctlInput.title = "Vui lòng vào thông tin \"" + caption + "\" > 0 !";
                                error++;
                                continue;
                            }
                        } catch (ex) {
                            ctlInput.style.borderColor = errorColor;
                            ctlInput.title = "Vui lòng vào thông tin \"" + caption + "\" dạng số > 0"; 
                            error;
                            continue;
                        }
                    }
                    ctlInput.style.borderColor = "";
                    ctlInput.title = "";
                }
            }
            if (ctlInput != null) {
                if (ctlInput.value == null || ctlInput.value == "") {
                    ctlInput.style.borderColor = errorColor;
                    ctlInput.title = "Vui lòng vào thông tin \"" + caption + "\"";
                    error++;
                    continue;
                }
                else {
                    ctlInput.style.borderColor = "";
                    ctlInput.title = "";
                }
            }
        }
        if (typeCheck.indexOf("D") > -1) {
            if (ctlInput != null) {
                var mss = InvalidDate(ctlInput.value);
                if (mss != "") {
                    ctlInput.style.borderColor = errorColor;
                    ctlInput.title = mss;
                    error++;
                } else {
                    ctlInput.style.borderColor = "";
                    ctlInput.title = "" ;
                }
            }
        }

    }
    if (error > 0) return false;
    else return true;
}
function checkTimes(control)
{
    if(control.value.length > 0){
        if(control.value.split(':').length == 2)
        {
            if(getTimes(control.value) == false)
            {
                control.select();
            }
        }
        else{
            var timenew = control.value.charAt(0) + control.value.charAt(1) + ':' + control.value.charAt(2) + control.value.charAt(3); 
            control.value = timenew;
            if(getTimes(control.value) == false)
            {
                control.select();
            }
        }
    }
}

function getTimes(control)
{
    var time = /^(\d{2,2})(\:|-)(\d{2,2})$/;
    var times = control.match(time);
        if(times == null)
        {
            alert('Khong dung dinh dang HH:mm');
            return false;
        }
        if(control.split(':')[0] == 24 && control.split(':')[1] > 0)
        {
            alert('Phút không lớn hơn 0');
            return false;
        }
        else if(control.split(':')[0] < 24){
            if(control.split(':')[0] < 0)
            {
                alert('Giờ không nhỏ hơn 0');
                return false;
            }
            if(control.split(':')[1] > 59 || control.split(':')[1] < 0)
            {
                alert('Phút phải nhỏ hơn 59 va không nhỏ hơn 0');
                return false;
            }
        }
        else if(control.split(':')[0] > 24){
            alert('Giờ phải không lớn hơn 24');
            return false;
        }
}


function formatCurrency(num) 
 {
    num = num.toString().replace(/\$|\,/g,'');
    if(isNaN(num))
    num = "0";
    var sign = (num == (num = Math.abs(num)));
    num = Math.floor(num*100+0.50000000001);
    var sole = num % 100;
    num = Math.floor(num/100).toString();
    
    for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
    {
        num = num.substring(0,num.length-(4*i+3))+','+
        num.substring(num.length-(4*i+3));
    }
    return (((sign)?'':'-') + num+"."+sole);
}

function TestDate(t) {
    var ngay = t;
    if (t.value.length > 0) {
        var arrngay = ngay.value.split('/');
        if (arrngay.length == 3) {
            isDate(ngay.value);
            return;
        }
        else {
            var ngaymoi = ngay.value.charAt(0) + ngay.value.charAt(1) + '/' + ngay.value.charAt(2) + ngay.value.charAt(3) + '/' + ngay.value.charAt(4) + ngay.value.charAt(5) + ngay.value.charAt(6) + ngay.value.charAt(7);
            t.value = ngaymoi;
            if (t.value != "") {
                if (isDate(t.value) == false) {
                    t.select();
                }
            }
        }
    }
}
function InvalidDate(dateStr) {
    var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var matchArray = dateStr.match(datePat);
    if (matchArray == null) {
        return "Ngày tháng không đúng định dạng dd/MM/yyyy: " + dateStr;      
    }
    day = matchArray[1];
    month = matchArray[3];
    year = matchArray[5];

    if (month < 1 || month > 12) {
        return "Tháng phải giữa 1 và 12.";       
    }

    if (day < 1 || day > 31) {
        return "Ngày phải giữa 1 và 31 ngày.";
     
    }

    if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
        return "Tháng " + month + " không có 31 ngày!";
      
    }

    if (month == 2) {
        var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        if (day > 29 || (day == 29 && !isleap)) {
            return "Tháng 2 năm " + year + " không có " + day + " ngày!";
           
        }
    }
    return "";
}
function isDate(dateStr) {
    var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var matchArray = dateStr.match(datePat);
    if (matchArray == null) {
        alert("Ngày tháng không hợp lệ: " + dateStr);
        return false;
    }
    day = matchArray[1];
    month = matchArray[3];
    year = matchArray[5];

    if (month < 1 || month > 12) {
        alert("Tháng phải giữa 1 và 12.");
        return false;
    }

    if (day < 1 || day > 31) {
        alert("Ngày phải giữa 1 và 31 ngày.");
        return false;
    }

    if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
        alert("Tháng " + month + " không có 31 ngày!");
        return false;
    }

    if (month == 2) {
        var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        if (day > 29 || (day == 29 && !isleap)) {
            alert("Tháng 2 năm " + year + " không có " + day + " ngày!");
            return false;
        }
    }
    return true;
}
function TestMax(control, sokitu) {
    if (control.value.length > sokitu) {
        alert('Không được vượt quá "' + sokitu + '" kí tự !');
        control.focus();
        control.select();
        return;
    }
    return true;
}
function TestSo(control, soAm, formatSo, minvalue) {
    if (minvalue == null)
        minvalue = 0;
    if (formatSo == false) {
        if (control.value.length > 0) 
        {

            if (soAm == true) {
                try {
                    var val = eval(control.value) * 1;
                    if (val < minvalue)
                        control.value = minvalue;
                }
                catch (ex) {
                    control.value = minvalue;
                    return;
                }
            }
            else {
                try {
                    if (eval(control.value) < 0) {
                        alert('Số phải > "-1" !');
                        control.select();
                        control.focus();
                        return;
                    }
                }
                catch (ex) {
                    control.value = minvalue;
                    return;
                }

            }
        }       
    } else {
        control.value = formatCurrency(control.value);
    }
}


function openExcel(strLocation, boolReadOnly) {
	var objExcel;
	var fsobj = new ActiveXObject("Scripting.FileSystemObject");
	objExcel = new ActiveXObject("Excel.Application");
	objExcel.Visible = true;
	objExcel.DisplayAlerts = false;
	objExcel.Workbooks.Open(strLocation, false, boolReadOnly);
}