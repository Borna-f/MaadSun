$(document).ready(function () {
    getUsers();

    $('#EditUser_dialog').dialog({
        autoOpen: false,
        width: 600,
        draggable: true,
        position: [ 'center',20]
    });
    $("#EditUser_dialog").parent().appendTo($("form:first"));

    $('#DeleteUser_dialog').dialog({
        autoOpen: false,
        width: 350,
        draggable: false
    });
    $("#DeleteUser_dialog").parent().appendTo($("form:first"));

    $("#password").mousedown(function () {
        $("#password").val("");
        $("#re_password").val("");
    });
    $("#RePass").mousedown(function () {
        $("#re_password").val("");
        $("#password").val("");
    });


});


function getUsers() {
    var result = { "rows": [] };
    $("#grid").jqGrid({
        width: 780,
        height: 'auto',
        direction: 'rtl',
        ajaxGridOptions:
    {
        url: "/Customer/WebService/User.asmx/GetAllUsers",
        datatype: 'json',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        complete: function (data, st) {
            if (st == "success" || st == 'parsererror') {
                data = JSON.parse(data.responseText);
                result.rows = [];
                if (data.d != null) {
                    for (i = 0; i < data.d.Rows.length; ++i) {
                        result.rows[i] = {};
                        result.rows[i].ID = data.d.Rows[i].UserID;
                        result.rows[i].cell = [data.d.Rows[i].UserID,
                                        data.d.Rows[i].Username,
                                        data.d.Rows[i].Firstname + " " + data.d.Rows[i].Familyname,
                                        data.d.Rows[i].Phonenumber,
                                        data.d.Rows[i].Email,
                                        data.d.Rows[i].Address,
                                        //data.d.Rows[i].Privilage,
                                        {
                                            Privilage: data.d.Rows[i].Privilage
                                        },
                                        {
                                            UserID: data.d.Rows[i].UserID
                                        },
                                        {
                                            UserID: data.d.Rows[i].UserID
                                        },
                                        {
                                            UserID: data.d.Rows[i].UserID,
                                            Username: data.d.Rows[i].Username,
                                            Firstname: data.d.Rows[i].Firstname,
                                            Familyname: data.d.Rows[i].Familyname,
                                            Phonenumber: data.d.Rows[i].Phonenumber,
                                            Email: data.d.Rows[i].Email,
                                            Address: data.d.Rows[i].Address,
                                            Password: data.d.Rows[i].Password,
                                            Privilage: data.d.Rows[i].Privilage
                                        },
                                        {
                                            UserID: data.d.Rows[i].UserID
                                        }


                        ];
                    }
                    var thegrid = $("#grid")[0];
                    result.records = data.d.RowCount;
                    result.page = data.d.PageIndex + 1;
                    result.total = Math.ceil(result.records / data.d.PageSize);
                    thegrid.addJSONData(result);
                }
            }
        }
    },
        serializeGridData: function (postdata) {
            var mydata = {};
            mydata = { filter: postdata };
            mydata.filter = {};
            mydata.filter.PageIndex = postdata.page - 1;

            mydata.filter.PageSize = postdata.row;
            mydata.filter.OrderBy = postdata.sidx;
            mydata.filter.Order = postdata.sord;


            return JSON.stringify(mydata);
        },
        colNames: ['کد کاربر', 'نام کاربری', 'نام و نام خانوادگی', 'شماره تماس' ,'ایمیل','آدرس','نوع کاربر', 'نمایش صفحه وب' ,'تغییر صفحه وب','ویرایش کاربر', 'حذف کاربر'],
        colModel: [
        { name: 'UserID', index: 'UserID', key: true, width: 100, hidden: true, sortable: false, search: false, editable: false, fixed: false, align: 'center', resizable: false },
        { name: 'Username', index: 'Username', key: false, width: 100, sortable: true, search: false, editable: true, fixed: false, align: 'center', resizable: true },
        { name: 'UserFullName', index: 'UserFullName', key: false, width: 120, sortable: true, search: false, editable: true, fixed: false, align: 'center', resizable: true },
        { name: 'Phonenumber', index: 'Phonenumber', key: false, width: 100, sortable: true, search: false, editable: true, fixed: false, align: 'center', resizable: true },
        { name: 'Email', index: 'Email', key: false, width: 120, sortable: true, search: false, editable: true, fixed: false, align: 'center', resizable: true },
        { name: 'Address', index: 'Address', key: false, width: 100, sortable: true, search: false, editable: true, fixed: false, align: 'center', resizable: true },
        {
            name: 'Privilage', index: 'Privilage', key: false, width: 100, sortable: true, search: false, editable: true, fixed: false, align: 'center', resizable: true,
            formatter: function (obj) {
                switch (obj.Privilage) {
                    case 100:
                        {
                            return "ادمین";
                            break;
                        }
                    default:
                        {
                            return "عادی";
                            break;
                        };
                }

            }
        },
        {
            name: 'ShowUserWebPage', index: 'ShowUserWebPage', search: false, searchable: false, width:100, align: 'center',
            formatter: function (obj) {
                return "<img src='/images/webpageshow.jpg' alt='نمایش صفحه وب' onclick= \"window.location.replace('/Customer/Colleague.aspx?UserID=" + obj.UserID + "')\"style=\"cursor: pointer;\">";
                
            }
        },
        {
            name: 'EditUserWebPage', index: 'EditUserWebPage', search: false, searchable: false, width: 120, align: 'center',
            formatter: function (obj) {

                return "<img src='/images/EditWebPage.png' alt='ویرایش صفحه وب' onclick=\"window.location.replace('/Customer/EditWebPage.aspx?UserID=" + obj.UserID + "')\" style=\"cursor: pointer;\">";


                //return "<img src='/images/edit.png' alt='ویرایش صفحه وب' onclick= '" + window.location.replace("/Customer/EditWebPage.aspx?UserID=" + obj.UserID) + "'";
            }
        },
        {
            name: 'edit', index: 'edit', search: false, searchable: false, width:100, align: 'center',
            formatter: function (obj) {
                //          return "<img src='/image/edit.png' alt='ویرایش' onclick='a(" + obj + ")'" + "/>"
                //return "<img src='/image/edit.png' alt='ویرایش' onclick='showeditpanel(" + obj.UserID + ","
                // + obj.Username + "," + obj.UserFullName + ")'" + "style='cursor: pointer;'>";
                //return "<img src='/image/edit.png' alt='ویرایش'/> onclick=\"showeditpanel(" + obj.UserID + ",'"
                //  + obj.Username + "','" + obj.UserFullName /*+ "','" + obj.Priv +*/ + "')\" style=\"cursor: pointer;\">";


                return "<img src='/images/edit.png' alt='ویرایش کاربر' onclick=\"showeditpanel(" + obj.UserID + ",'"
                    + obj.Username + "','" + obj.Firstname + "','" + obj.Familyname + "','" + obj.Phonenumber + "','"
                    + obj.Email + "','" + obj.Address + "','" + obj.Password + "','" + obj.Privilage + "')\" style=\"cursor: pointer;\">";
            }
        },
        {
            name: 'delete', index: 'delete', search: false, searchable: false, width:100, align: 'center',
            formatter: function (obj) {
                return "<img src='/images/remove.png' alt='حذف کاربر' onclick=\"showdelete(" + obj.UserID + ")\" style=\"cursor: pointer;\">";
            }
        }


        ],
        loadui: "block",
        loadtext: "در حال بارگذاری",
        altRows: true, rowNum: 10, rowList: [10, 25, 50, 75, 100],
        pager: '#ppdata',
        sortname: 'CallDate', mtype: "POST", postData: { q: 1 },
        viewrecords: true, sortorder: "desc",
        caption: "لیست کاربران", multiselect: false
    });

    isrefreshed = true;
}




function showeditpanel(id, Username, Firstname, Familyname,Phonenumber, Email,Address, Password, Priv) {
    //$('#id').val(id);
    $('#Username').val(Username);
    $('#Firstname').val(Firstname);
    $('#Familyname').val(Familyname);
    $('#Phonenumber').val(Phonenumber);
    $('#Email').val(Email);
    $('#Address').val(Address);
    $('#password').val(Password);
    $('#re_password').val(Password);
    $('select').val(Priv);
    $("#HUserID").val(id);
    $('#EditUser_dialog').dialog('open');
    // $('#Calltime').attr('readonly', 'true').attr('disabled', true);;
    //$('#Priv').val(Priv);

}

function showdelete(UserID) {
    $('#DeleteUser_dialog').dialog('open');
    $("#HUserID").val(UserID);
}

function EditClose() {
    $('#EditUser_dialog').dialog('close');
}

function DeleteClose() {
    $('#DeleteUser_dialog').dialog('close');
}


function ValidateForm() {
    var id = $("form")[0].getAttribute("id");
    $("#" + id).validate({
        errorClass: "errorClass",
        rules: {
            ctl00$body$Username: { required: true },
            ctl00$body$password: { required: true },
            RePass: { required: true, equalTo: '#password' },
            ctl00$body$Firstname: { required: true },
            ctl00$body$Familyname: { required: true },
            ctl00$body$Email: { required: true, email: true },
            ctl00$body$PhoneNumber: { required: true },
            ctl00$body$Address: { required: true },
        },
        messages: {
            ctl00$body$Username: { required: " * " },
            ctl00$body$password: { required: " * " },
            RePass: { required: " * ", equalTo: "تکرار رمز عبور متفاوت است" },
            ctl00$body$Firstname: { required: " * " },
            ctl00$body$Familyname: { required: " * " },
            ctl00$body$Email: { required: " * ", email: " لطفا یک آدرس ایمیل معتبر وارد نمایید " },
            ctl00$body$PhoneNumber: { required: " * " },
            ctl00$body$Address: { required: " * " },
        }
    });

}

function CheckData() {
    ValidateForm();
    var id = $("form")[0].getAttribute("id");
    if ($("#" + id).valid()) {
        return true;
    }
    else return false;
}