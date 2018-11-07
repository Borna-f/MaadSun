


function ValidateForm()
{
    var id = $("form")[0].getAttribute("id");
    $("#" + id).validate({
        errorClass: "errorClass",
        rules: {
            ctl00$body$Username: { required: true },
            ctl00$body$Pass: { required: true },
            RePass: { required: true, equalTo: '#body_Pass' },
            ctl00$body$Firstname: { required: true },
            ctl00$body$Familyname: { required: true },
            ctl00$body$Email: { required: true, email: true },
            ctl00$body$PhoneNumber: { required: true },
            ctl00$body$Address: { required: true },
            ctl00$body$CaptchaTxT: { required: true },
        },
        messages: {
            ctl00$body$Username: { required: " * " },
            ctl00$body$Pass: { required: " * " },
            RePass: { required: " * ", equalTo: "تکرار رمز عبور متفاوت است" },
            ctl00$body$Firstname: { required: " * " },
            ctl00$body$Familyname: { required: " * " },
            ctl00$body$Email: { required: " * ", email: " لطفا یک آدرس ایمیل معتبر وارد نمایید " },
            ctl00$body$PhoneNumber: { required: " * " },
            ctl00$body$Address: { required: " * " },
            ctl00$body$CaptchaTxT: { required: " * " },
        }
    });
    
}

function Register()
{
    ValidateForm();
    var id = $("form")[0].getAttribute("id");
    if ($("#" + id).valid()) {
        if (UsernameExists("body_"+"Username")) {
            ShowMessage("این نام کاربری قبلا به ثبت رسیده است", "خطا");
            return false;
        }
        else if (EmailExists("body_" + "Email")) {
            ShowMessage("این ایمیل قبلا به ثبت رسیده است", "خطا");
            return false;
        }
        else
            return true;
        
        //else {
        //    var data = {};
        //    data.UFilt = {};
        //    data.UFilt.User = {};
        //    var result;
        //    data.UFilt.User.Username = $("#Username").val();
        //    data.UFilt.User.Password = $("#Pass").val();
        //    data.UFilt.User.Firstname = $("#Firstname").val();
        //    data.UFilt.User.Familyname = $("#Familyname").val();
        //    data.UFilt.User.Email = $("#Email").val();
        //    data.UFilt.User.Phonenumber = $("#PhoneNumber").val();
        //    data.UFilt.User.Address = $("#Address").val();
        //    $.ajax({
        //        type: "POST",
        //        contentType: "application/json; charset=utf-8",
        //        url: "WebService/User.asmx/CreateUser",
        //        data: JSON.stringify(data),
        //        dataType: "json",
        //        async: false,
        //        success: function (data) {
        //            ShowMessage("کاربر با موفقیت به ثبت رسید", "ثبت کاربر");
        //            //$("#txtUserName").addClass('Hidden');
        //            //$("#txtPassword").addClass('Hidden');
        //            //data = JSON.parse(data.responseText);
        //            //result = JSON.parse(data.d);
        //            //console.log(result);
        //        },
        //        error: function (request, errorText, errorCode) {
        //        }
        //    });
        //}
    }
}