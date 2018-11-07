var uploadControlCounter;
var ImageInfo;
$(document).ready(function () {
    $("#addFileUpload").click(function (e) {
        e.preventDefault();
        createFileUpload();
    });

    $("#uploadUI").on("click", "a.removeUpload", function (e) {
        e.preventDefault();
        $(this).parent().remove();
    });
    uploadControlCounter = 0;
    // Start by creating one file upload
    //createFileUpload();

    $('.img-wrap .close').on('click', function() {
        var id = $(this).closest('.img-wrap').find('img').data('id');
        
        $("#hID").val(id);
        ShowDeleteImageDialog();
    //alert('remove picture: ' + id);
    });


    $('.img-wrap .update').on('click', function () {
        var id = $(this).closest('.img-wrap').find('img').data('id');
        $("#hID").val(id);
        ShowUpdateImageDialog(id);
    });


    $("#UpdateImageDialog").dialog({
        title: 'تغییر مشخصات تصویر',
        autoOpen: false,
        buttons: [{
            text: "انصراف",
            click: function () {
                $(this).dialog("close");
            }
        }, {
            text: "تایید",
            click: function () {
                UpdateImage(ImageInfo.ImageID,$('#CategorySelectedImage').val(), $('#SubCategorySelectedImage').val());
            }
        }],
        width: '520px'
    });



    $("#DeleteImageDialog").dialog({
        title: 'حذف تصویر',
        autoOpen: false,
        //buttons: [{
        //    text: "انصراف",
        //    click: function () {
        //        $(this).dialog("close");
        //    }
        //}, {
        //    text: "تایید",
        //    click: function () {
        //        DeleteImage();
        //    }
        //}],
        width: '320px'
    });
    //for (i = 0; i < uploadControlCounter; i++) {
    //    $("#CategoryFile" + i).change(function () {
    //        LoadSubCategory($("#CategoryFile" + i).val());
    //    })
    //}
    $("#uploadUI").on('change', '[id^=CategoryFile]', function (e) {
        LoadSubCategory(e.target.value, e.target.id);
    });
    
});
function GetImageInfo(Imagename)
{
    var data = {};
    data.Imagename = Imagename;
    var result;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService/Category.asmx/GetImageInfo",
        data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (data) {
            result = data.d;
        }
    })
    return result;
}

function ShowDeleteImageDialog()
{

    $("#DeleteImageDialog").dialog("open");
    $("#DeleteImageDialog").parent().appendTo($("form:first"));
}

function ShowUpdateImageDialog(id) {
    $('#CategorySelectedImage').empty();
    $('#SubCategorySelectedImage').empty();
    ImageInfo = GetImageInfo(id).Rows[0];
    var Categorylist = GetCategoryList();
    $('#CategorySelectedImage').append(new Option('انتخاب دسته بندی ...', ''));
    $('#SubCategorySelectedImage').append(new Option('انتخاب زیر شاخه ...', ''));
    for (var i = 0; i < Categorylist.Rows.length; i++) {
        $('#CategorySelectedImage').append(new Option(Categorylist.Rows[i].CategoryDescription, Categorylist.Rows[i].CategoryID));
    }
    $('#CategorySelectedImage').val(ImageInfo.CategoryID);
    var SubCategorylist = GetSubCategoryList(ImageInfo.CategoryID);
    for (i = 0; i < SubCategorylist.Rows.length; i++) {
        $('#SubCategorySelectedImage').append(new Option(SubCategorylist.Rows[i].SubCategoryDescription, SubCategorylist.Rows[i].SubCategoryID));
    }
        $('#SubCategorySelectedImage').val(ImageInfo.SubCategoryID);
    


        $('#CategorySelectedImage').on('change', function (e) {
            $('#SubCategorySelectedImage').empty();
            $('#SubCategorySelectedImage').append(new Option('انتخاب زیر شاخه ...', ''));
        var SubCategorylist = GetSubCategoryList(e.target.value);
        for (i = 0; i < SubCategorylist.Rows.length; i++) {
            $('#SubCategorySelectedImage').append(new Option(SubCategorylist.Rows[i].SubCategoryDescription, SubCategorylist.Rows[i].SubCategoryID));
        }
    });
    
    $("#UpdateImageDialog").dialog("open");
    $("#UpdateImageDialog").parent().appendTo($("form:first"));
}

//function DeleteImage()
//{
function Cancel()
{
    $("#DeleteImageDialog").dialog("close");
}


function UpdateImage(ImageID, CategoryID, SubCategoryID) {
    if ($("#CategorySelectedImage").val() == '')
    {
        ShowMessage('لطفا دسته بندی را انتخاب نمایید', 'تغییرات تصویر');
        return;
    }
    else if ($("#SubCategorySelectedImage").val() =='')
    {
        ShowMessage('لطفا زیر شاخه را انتخاب نمایید', 'تغییرات تصویر');
        return;
    }
        else
        {
        var data = {};
        data.ImFilt = {};
        data.ImFilt.Image = {};
        data.ImFilt.Image.ImageID = ImageID;
        data.ImFilt.Image.CategoryID = CategoryID;
        data.ImFilt.Image.SubCategoryID = SubCategoryID;
        var result;
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "WebService/Image.asmx/UpdateImage",
            data: JSON.stringify(data),
            dataType: "json",
            async: false,
            success: function (data) {
                result = data.d;
                ShowMessage('تغییرات تصویر با موفقیت انجام شد', 'تغییرات تصویر');

            }
        });
        $("#UpdateImageDialog").dialog("close");

        return result;
    }
   // ShowMessage('متاسفانه خطایی در تغییر تصویر رخ داده است', 'تغییرات تصویر');
    return "";
}
//ShowMessage('تصویر با موفقیت حذف شد','حذف تصویر')
//}

function Validation()
{
    ValidateForm();
    var id = $("form")[0].getAttribute("id");
    if ($("#" + id).valid()) {
        return true;
    }
    else {
        return false;
    }
        
}


function createFileUpload() {
    $("#uploadUI").append(
                    $("<div />")
                        .attr("id", "fileContainer" + uploadControlCounter)
                    .append(
                        $("<input />")
                            .attr("type", "file")
                            .attr("name", "file" + uploadControlCounter)
	            )
    .append(" ")
                    .append(
                        $("<a />")
	                    .attr("href", "#")
	                    .attr("class", "removeUpload")
	                    .text("حذف")
	            )
    .append(" ")
                    .append(
                    $("<select />")
                        .attr("id", "CategoryFile" + uploadControlCounter)
                        .attr("name", "CategoryFile" + uploadControlCounter)
                    )
    .append(" ")
                    .append(
                    $("<select />")
                        .attr("id", "SubCategoryFile" + uploadControlCounter)
                        .attr("name", "SubCategoryFile" + uploadControlCounter)
                    )
                    
	        );
    var Categorylist = GetCategoryList();
    $('#CategoryFile' + uploadControlCounter).append(new Option('انتخاب دسته بندی ...', ''));
    $('#SubCategoryFile' + uploadControlCounter).append(new Option('انتخاب زیر شاخه ...', ''));
    ValidateForm();
    $("#CategoryFile" + uploadControlCounter).rules("add", {
        required: true,
        messages: {
            required: "*",
        }
    });

    $("#SubCategoryFile" + uploadControlCounter).rules("add", {
        required: true,
        messages: {
            required: "*",
        }
    });

    for (var i = 0; i < Categorylist.Rows.length; i++) {
        $('#CategoryFile' + uploadControlCounter).append(new Option(Categorylist.Rows[i].CategoryDescription, Categorylist.Rows[i].CategoryID));
    }

    uploadControlCounter++;
}

function LoadSubCategory(SelectedCategory,id)
{
    var ID = id.substring(12);
    $('#SubCategoryFile' + ID).empty();
    $('#SubCategoryFile' + ID).append(new Option('انتخاب زیر شاخه ...', ''));
    var SubCategorylist = GetSubCategoryList(SelectedCategory);
    for (i = 0; i < SubCategorylist.Rows.length; i++) {
        $('#SubCategoryFile'+ID).append(new Option(SubCategorylist.Rows[i].SubCategoryDescription, SubCategorylist.Rows[i].SubCategoryID));
    }
}

function GetCategoryList() {
    var result;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService/Category.asmx/GetCategory",
        //data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (data) {
            //if (data.d == "Success") {
            result = data.d;
            //}
        }
    });
    return result;
}


function GetSubCategoryList(SelectedCategory) {
    var data = {};
    
    data.ParentID = SelectedCategory;
    var result;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService/Category.asmx/GetFilteredSubcategory",
        data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (data) {
            
            result = data.d;
            //if (data.d == "Success") {
              //  RedirectToMainPage();
            //}
        }
    })
    return result;
}

function ValidateForm() {
    
    var id = $("form")[0].getAttribute("id");
    //var rules = new Object();
    //var messages = new Object();
    //$('select[name^=CategoryFile]').each(function () {
    //    rules[this.name] = { required: true };
    //    messages[this.name] = { required: 'لطفا یک نوع دسته بندی را انتخاب کنید' };
    //});

    


    //$('select[name^=SubCategoryFile]').each(function() {
    //    rules[this.name] = { required: true };
    //    messages[this.name] = { required: 'لطفا یک زیر شاخه را انتخاب کنید' };
    //});


    $("#" + id).validate({
        errorClass: "errorClass"
        //rules: rules,
        //messages: messages,
        //ignore:[]
        
    });

}