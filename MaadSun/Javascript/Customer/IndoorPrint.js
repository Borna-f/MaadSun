$(document).ready(function () {
    $("#I1,#I2,#I3").click (function ()
    {
        OpenDialog();
    });
    
});

function OpenDialog() {
    $("#I1D").dialog({
        title: 'نمونه کار چاپ داخلی',
        height: 800,
        width: 800,
        buttons: {
            "بستن پنجره": function () {
                $(this).dialog("close");
            },
        }
    });
}