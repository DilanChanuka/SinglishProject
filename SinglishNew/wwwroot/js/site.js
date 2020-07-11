$(document).ready(function () {
    $('input[type="checkbox"]').click(function () {
        if ($(this).prop("checked") == true) {
            document.getElementById("btnManualTranlate").disabled = true;
            $('#SinglishTxt').bind('keyup', function () {
                $('#myForm').delay(200).submit();
            });
        }
        else if ($(this).prop("checked") == false) {
            document.getElementById("btnManualTranlate").disabled = false;
            $('#SinglishTxt').unbind();
        }
    });
});

$("#myForm").submit(function (event) {
    event.preventDefault();
    var e = document.getElementById("type");
    var strUser = e.options[e.selectedIndex].value;
    var Singlish = document.getElementById("SinglishTxt").value;
    $.ajax({
        type: "post",
        dataType: "JSON",
        url: "/Home/GetData",
        data: { txt: JSON.stringify({ SinglishTxt: Singlish, type: strUser }) },
        success: function (data) {
            document.getElementById("SinhalaTxt").value = data;
        }
    });
});

var changeFont = function (font) {
    document.getElementById("SinhalaTxt").style.fontFamily = font.value;
}

var changeType = function (type) {
    if (type.value == 'Unicode') {
        document.getElementById("font").disabled = true;
    }
    else if (type.value == 'Sinhala Font') {
        document.getElementById("font").disabled = false;
        document.getElementById("SinhalaTxt").style.fontFamily = font.value;
    }
}

function LoadDefault() {
    document.getElementById("font").disabled = true;
    document.getElementById("customSwitches").checked = true;
    document.getElementById("btnManualTranlate").disabled = true;
    $('#SinglishTxt').bind('keyup', function () {
        $('#myForm').delay(200).submit();
    });
}

function copy() {
    var vv = document.getElementById("SinhalaTxt").value;
    if (vv != "") {
        let textarea = document.getElementById("SinhalaTxt");
        textarea.select();
        document.execCommand("copy");
        Swal.fire({
            position: 'bottom-center',
            icon: 'success',
            title: 'Copied',
            showConfirmButton: false,
            timer: 1500
        });
    }
}

$(function () {
    var availableTags = [
        "dilaan", "chalaka", "uShaan", "roShaan", "erandha", "lamaya", "kaeththa",
        "koadmaart", "mama", "oyaa", "ohu", "eyaa", "eyaage", "api", "apea", "amma",
        "thaaththa", "ayiya", "akka", "naendha", "maama", "banis", "bas",
        "uda",  "dhodhol", "bath", "koththu", "balla", "puusa", "haraka",
        "husma", "gaemma", "shree", "thatte", "ala", "ibba", "dhora", "mahindha", "pohottuwa", "putuwa", "mawus", "karant", "heta", "anidhdha"
    ];
    $("#SinglishTxt").autocomplete({
        source: availableTags
    });
});