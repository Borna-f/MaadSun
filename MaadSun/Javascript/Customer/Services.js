$(document).ready(function () {
    LoadCategory();
    $("#CategorySelectors").on('change', '[id^=Category]', function (e) {
        LoadSubCategory(e.target.value);
        ShowImages();
    });

    $('#SubCategory').change(function () {
        ShowImages()
    });
    ShowImages();
    //$('.photoset-grid').photosetGrid({
    //    layout: '2133',
    //    gutter: '5px',
    //    borderActive: true,
    //        borderWidth: '3px',
    //        borderColor: '#000000',
    //        borderRadius: '3px',
    //        borderRemoveDouble: false,
    //});
    //$('.photoset-grid').photosetGrid({
    //    layout: '3333',
    //    width: '100%',
    //    gutter: '5px',
    //    highresLinks: true,
    //    lowresWidth: 300,
    //    rel: 'gallery-01',
    //    borderActive: true,
    //    borderWidth: '3px',
    //    borderColor: '#000000',
    //    borderRadius: '3px',
    //    borderRemoveDouble: false,
    //});
});

function ShowImages()
{
    $('#Images').empty();
    var ImageList = GetImage();
    for (i = 0; i < ImageList.Rows.length; i++) {
        $('#Images').append("<div class='mosaicflow__item'><a href='Colleague.aspx?UserID=" + ImageList.Rows[i].UserID + "'>" + "<img id= 'image" + i + "' alt= '" + ImageList.Rows[i].Imagename + "' src='/Uploads/" + ImageList.Rows[i].Imagename + "'; width=400; height=400;/>" + "</a></div>");
    }
    $('#Images').mosaicflow({
        minItemWidth: 300
    });

    //var options = { minMargin: 100, maxMargin: 350, itemSelector: ".item" };
    //$(".photoset-grid").rowGrid(options);
}


function LoadCategory() {

    var Categorylist = GetCategoryList();
    for (var i = 0; i < Categorylist.Rows.length; i++) {
        $('#Category').append(new Option(Categorylist.Rows[i].CategoryDescription, Categorylist.Rows[i].CategoryID));
    }
}


function LoadSubCategory(SelectedCategory) {
    $('#SubCategory').empty();
    $('#SubCategory').append(new Option('انتخاب زیر شاخه ...', ''));
    var SubCategorylist = GetSubCategoryList(SelectedCategory);
    for (i = 0; i < SubCategorylist.Rows.length; i++) {
        $('#SubCategory').append(new Option(SubCategorylist.Rows[i].SubCategoryDescription, SubCategorylist.Rows[i].SubCategoryID));
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
            result = data.d;
        }
    })
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
        }
    })
    return result;
}

function GetImage ()
{
    var data = {};
    data.ImFilt = {};
    data.ImFilt.Image = {};

    if ($('#Category').val() == -1)
        data.ImFilt.Image.CategoryID = null;
    else
        data.ImFilt.Image.CategoryID = $('#Category').val();

    if ($('#SubCategory').val() == -1)
        data.ImFilt.Image.SubCategoryID = null;
    else
        data.ImFilt.Image.SubCategoryID = $('#SubCategory').val();



    var result;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "WebService/Image.asmx/GetFilteredImage",
        data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (data) {
            result = data.d;
        }
    })
    return result;
}