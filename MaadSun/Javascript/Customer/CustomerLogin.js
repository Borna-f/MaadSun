$(document).ready(function () {

    $("#CLtxtPassword").keyup(function (event) {
        if (event.keyCode == 13) {
            CLLogin();
            //$("#id_of_button").click();
        }
    });
});




function CLCustomerRegister() {
    window.location.replace("/Customer/CustomerRegister.aspx");
}

function CLLogin() {
    var data = {};
    data.UFilt = {};
    data.UFilt.User = {};
    var result;
    data.UFilt.User.Username = $("#CLtxtUsername").val();
    data.UFilt.User.Password = $("#CLtxtPassword").val();
    console.log(data);
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService/User.asmx/GetFilteredUser",
        data: JSON.stringify(data),
        dataType: "json",
        async: true,
        success: function (data) {

            if (data.d == "Success") {
                RedirectToMainPage();
                //window.location.replace("Index.aspx");
                //$("#CustomerPanel").addClass ('Inline')
                //$("#LoginPanel").addClass('Hidden')
                //$(".login").addClass('Hidden');
            }
            else {
                ShowMessage('نام کاربری یا کلمه ی عبور اشتباه است', 'خطا')
            };
            //$("#txtUserName").addClass('Hidden');
            //$("#txtPassword").addClass('Hidden');
            //data = JSON.parse(data.responseText);
            //result = JSON.parse(data.d);
            //console.log(result);
        },
        error: function (request, errorText, errorCode) {
        }
    });
}