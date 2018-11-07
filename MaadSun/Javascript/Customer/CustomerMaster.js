$(document).ready(function () {
    $("#cssmenu > ul li.has-sub").hover(function () {
        /*$("#cssmenu > ul").css("padding-bottom", "200px");*/
        $("#header").css("padding-bottom", "150px");
    },
    function () {
        $("#header").css("padding-bottom", "0px");
    });

    var heightMenu = $('#header').height();
    $('.container').css({ paddingTop: heightMenu  + 'px' });
    $('#header .container').css({ paddingTop: 15 + 'px'});
    $('#header .container').css({ paddingBottom: 7 + 'px' });


    //When Enter is clicked it will fire login
    $("#txtPassword").keyup(function (event) {
        if (event.keyCode == 13) {
            Login();
            //$("#id_of_button").click();
        }
    });

    $("#forgottendialog").dialog({
        title: 'فراموشی رمز عبور',
        autoOpen: false,
        buttons: [{
            text: "انصراف",
            click: function () {
                $(this).dialog("close");
            }
        }, {
            text: "تایید",
            click: function () {
                SendforgottenEmail();
            }
        }],
        width: '320px'
    });
})

function ShowMessage (Message,msgtitle)
{
  var dialog = "<div id=Dialog style=\"direction:rtl\">" + Message + "</div>";
   $('body').append(dialog);
    $("#Dialog").dialog({
        title: msgtitle,
        text: Message,
        buttons: [{
            text: "خب",
            click: function () {
                $(this).dialog("close");
                $("#Dialog").remove();
            }
        }]
    });
}

function CustomerRegister()
{
window.location.replace("/Customer/CustomerRegister.aspx");
}

function RedirectToMainPage()
{
window.location.replace("Index.aspx");
}

function Login()
{
    var data = {};
    data.UFilt = {};
    data.UFilt.User = {};
    var result;
    data.UFilt.User.Username = $("#txtUserName").val();
    data.UFilt.User.Password = $("#txtPassword").val();
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

function forgotten() {
    //$("#forgottendialog").dialog();
    $("#forgottendialog").dialog("open");
    
}


function SendforgottenEmail()
{
    $("#forgottendialog").parent().appendTo($("form:first"));
    var id = $("form")[0].getAttribute("id");
    $("#" + id).validate({
        errorClass : "errorClass",
        rules: {
            txtUsernameforgotten: { required: function(element) {
                return $("#txtEmailforgotten").val() == ""; }},
                txtEmailforgotten: { required: function(element) {
                    return $("#txtUsernameforgotten").val() == "";
                }, email:true
                }
        },
        messages: {
            txtUsernameforgotten: { required: " * " },
            txtEmailforgotten: { required: " * ", email: " لطفا یک آدرس ایمیل معتبر وارد نمایید " },
        }
    });
    var flag = false;
    if ($("#" + id).valid()) {
        if ($("#txtEmailforgotten").val() != "")
            if (EmailExists("txtEmailforgotten"))
                flag = true;
            else {
                ShowMessage('ایمیل وارد شده در سیستم ثبت نشده است', 'خطا');
                flag = false;
            }
        if ($("#txtUsernameforgotten").val() != "")
            if (UsernameExists("txtUsernameforgotten"))
                flag = true;
            else {
                ShowMessage('نام کاربری وارد شده در سیستم ثبت نشده است', 'خطا');
                flag = false;
            }
        if (flag == true)
        {
        var data = {};
        var result;
        data.Username = $("#txtUsernameforgotten").val();
        data.Email = $("#txtEmailforgotten").val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "WebService/User.asmx/SendForgottenEmail",
            data: JSON.stringify(data),
            dataType: "json",
            async: true,
            success: function (data) {

                if (data.d == "Success") {
                    ShowMessage('ایمیل مشخصات کاربری برای شما ارسال گردید', 'ایمیل')
                    //window.location.replace("Index.aspx");
                    //$("#CustomerPanel").addClass ('Inline')
                    //$("#LoginPanel").addClass('Hidden')
                    //$(".login").addClass('Hidden');
                }
                else {
                    ShowMessage('نام کاربری یا ایمیل اشتباه است', 'خطا')
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
    }
}

function UsernameExists(field) {
    
    var data = {};
    var result;
    data.Username = $("#"+field).val();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService/User.asmx/CheckifUsernameExists",
        data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.d == true) result = true;
            else result = false;
        }
    });
    return result;
}

function EmailExists(field) {
    var data = {};
    var result;
    data.Email = $("#"+field).val();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService/User.asmx/CheckifEmailExists",
        data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.d == true) result = true;
            else result = false;
        }
    });
    return result;
}