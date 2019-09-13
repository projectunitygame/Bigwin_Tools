var oTable;
var listCategory;
var TableCategories = function () {
    var initTable1 = function () {
        /*
        * Initialize DataTables, with no sorting on the 'details' column
        */
        $(".divLoading").fadeIn(0);
        var parentID = AppManage.getURLParameter('parentID');
        if (parentID == null)
            parentID = 0;
        var param = [];
        param.push(parentID);
        $.ajax({
            type: "POST",
            url: "../../Apis/Menu.ashx",
            data: { type: 14, mid: 48, p: JSON.stringify(param)},
            dataType: 'json',
            beforeSend: function () {
                if (oTable != null) {
                    oTable.fnDestroy();
                    $('#tbl_category tbody').html("");
                    $('#tbl_category thead').html("<tr role='row'>" +
                        "<th>ID</th>" +
                        "<th>Hình Ảnh</th>" +
                        "<th>Tên Danh Mục</th>" +
                        "<th>Danh Mục Cha</th>" +
                        "<th>Mô Tả</th>" +
                        "<th>Mô Tả Từ Khóa</th>" +
                        "<th>Từ Khóa</th>" +
                        "<th>Loại Form</th>" +
                        "<th>Người Tạo</th>" +
                        "<th>Ngày Tạo</th>" +
                        "<th>Trạng Thái</th>" +
                        "<th>Hiển Thị Menu</th>" +
                        "<th>Vị Trí Hiển Thị</th>" +
                        "<th>Đường Dẫn</th>" +
                        "<th>Icon</th>" +
                        "<th>CSS</th>" +
                        "<th>HTML</th>" +
                        "<th>Action Tags</th>" +
                        "<th>Category Tags</th>" +
                        "<th>Thể Loại</th>" +
                        "<th>Action</th>" +
                        "</tr>");
                    $('#tbl_category').on('click', ' tbody td .row-details', function () {
                    }).unbind('click');
                }
            },
            success: function (res) {
                if (res.status == 0 || res.status == 5004) {
                    $('#tbl_category tbody').html("");
                    listCategory = res.data;
                    $.each(listCategory, function (key, obj) {
                        if (obj.parentID == $('#ContentPlaceHolder_MAIN__parentID').val()) {
                            if (key == 0)
                                $('#lblNode').html(obj.ParentName);
                            var status = obj.status;
                            if (status == 1) {
                                status = "Publish";
                            }
                            else {
                                status = "UnPublish";
                            }
                            var images = [];//$.parseJSON(obj.images);
                            var img = "img/document_image_cancel_32.png";
                            //if (images.urlTemp != undefined)
                            //    img = images.urlTemp;
                            var countSubCategory = "";
                            if (obj.CountSubCategory != "0")
                                countSubCategory = " <span class='badge badge-success'>" + obj.CountSubCategory + "</span>";
                            var linkEdit = "<a data-toggle='modal' class='btn btn-xs purple' href='#modal_category' onclick='EditCategory(" + key + ")'>Edit <i class='fa fa-edit'></i></a>";
                            var linkClone = "<a data-toggle='modal' class='btn btn-xs purple' href='#modal_category' onclick='CloneCategory(" + key + ")'>Clone <i class='fa fa-edit'></i></a>";
                            var linkDelete = "<a href='#' class='btn btn-xs red' onclick='DeleteCategory(" + obj.CategoryId + ")'>Delete <i class='fa fa-trash-o'></i></a>";
                            $('#tbl_category tbody').append("<tr>" +
                                "<td style='width:40px'>" + obj.CategoryId + "</td>" +
                                "<td style='width:50px'><img src='" + img + "' style='max-width:20px;max-height:20px'/></td>" +
                                "<td><a href='CategoryManage.aspx?parentID=" + obj.CategoryId + "'>" + obj.CategoryName + countSubCategory + "</a></td>" +
                                "<td>" + obj.ParentName + "</td>" +
                                "<td>" + obj.Description + "</td>" +
                                "<td>" + obj.MetaDescription + "</td>" +
                                "<td>" + obj.MetaKeyword + "</td>" +
                                "<td>" + obj.CategoryType + "</td>" +
                                "<td>" + obj.UserName + "</td>" +
                                "<td>" + obj.DateCreate + "</td>" +
                                "<td>" + status + "</td>" +
                                "<td>" + obj.IsMenu + "</td>" +
                                "<td style='width:100px'>" + obj.DisplayIndex + "</td>" +
                                "<td>" + obj.Link + "</td>" +
                                "<td>" + obj.Icon + "</td>" +
                                "<td>" + obj.CSS + "</td>" +
                                "<td>" + obj.HTML + "</td>" +
                                "<td>" + obj.ActionTags + "</td>" +
                                "<td>" + obj.CategoryTags + "</td>" +
                                "<td>" + obj.CategoryTypeName + "</td>" +
                                "<td style='width:200px; text-align:center;'>" + linkEdit + linkDelete + linkClone + "</td>" +
                                "</tr>");
                        }
                    });
                }
                else
                    bootbox.alert(res.msg);
                $(".divLoading").fadeOut(0);
            },
            complete: function () {
                /* Formatting function for row details */
                function fnFormatDetails(oTable, nTr) {
                    var aData = oTable.fnGetData(nTr);
                    var sOut = '<table>';
                    sOut += '<tr><td><i>ID:</i></td><td>' + aData[1] + '</td></tr>';
                    sOut += '<tr><td><i>Hình Ảnh:</i></td><td>' + aData[2] + '</td></tr>';
                    sOut += '<tr><td><i>Tên Danh Mục:</i></td><td>' + aData[3] + '</td></tr>';
                    sOut += '<tr><td><i>Danh Mục Cha:</i></td><td>' + aData[4] + '</td></tr>';
                    sOut += '<tr><td><i>Mô tả:</i></td><td>' + aData[5] + '</td></tr>';
                    sOut += '<tr><td><i>Mô Tả Từ Khóa:</i></td><td>' + aData[6] + '</td></tr>';
                    sOut += '<tr><td><i>Từ Khóa:</i></td><td>' + aData[7] + '</td></tr>';
                    sOut += '<tr><td><i>Loại Form:</i></td><td>' + aData[8] + '</td></tr>';
                    sOut += '<tr><td><i>Người Tạo:</i></td><td>' + aData[9] + '</td></tr>';
                    sOut += '<tr><td><i>Ngày Tạo:</i></td><td>' + aData[10] + '</td></tr>';
                    sOut += '<tr><td><i>Trạng Thái:</i></td><td>' + aData[11] + '</td></tr>';
                    sOut += '<tr><td><i>Hiển Thị Menu:</i></td><td>' + aData[12] + '</td></tr>';
                    sOut += '<tr><td><i>Vị Trí Hiển Thị:</i></td><td>' + aData[13] + '</td></tr>';
                    sOut += '<tr><td><i>Đường Dẫn:</i></td><td>' + aData[14] + '</td></tr>';
                    sOut += '<tr><td><i>Icon:</i></td><td>' + aData[15] + '</td></tr>';
                    sOut += '<tr><td><i>CSS:</i></td><td>' + aData[16] + '</td></tr>';
                    sOut += '<tr><td><i>HTML:</i></td><td>' + aData[17] + '</td></tr>';
                    sOut += '<tr><td><i>Action Tags:</i></td><td>' + aData[18] + '</td></tr>';
                    sOut += '<tr><td><i>Category Tags:</i></td><td>' + aData[19] + '</td></tr>';
                    sOut += '<tr><td><i>Thể Loại:</i></td><td>' + aData[20] + '</td></tr>';
                    sOut += '</table>';
                    return sOut;
                }
                /*
                * Insert a 'details' column to the table
                */
                var nCloneTh = document.createElement('th');
                var nCloneTd = document.createElement('td');
                nCloneTd.innerHTML = '<span class="row-details row-details-close"></span>';

                $('#tbl_category thead tr').each(function () {
                    this.insertBefore(nCloneTh, this.childNodes[0]);
                });

                $('#tbl_category tbody tr').each(function () {
                    this.insertBefore(nCloneTd.cloneNode(true), this.childNodes[0]);
                });

                /*
                * Initialize DataTables, with no sorting on the 'details' column
                */
                oTable = $('#tbl_category').DataTable({
                    "aLengthMenu": [
                        [10, 50, 100, -1],
                        [10, 50, 100, "All"] // change per page values here
                    ],
                    "iDisplayLength": 10,
                    "sPaginationType": "bootstrap",
                    "oLanguage": {
                        "sLengthMenu": "_MENU_ records",
                        "oPaginate": {
                            "sPrevious": "Prev",
                            "sNext": "Next"
                        }
                    },
                    "aoColumnDefs": [{
                        'bSortable': false,
                        'aTargets': [5]
                    }],
                    "order": [
                        [5, "asc"]
                    ]
                });

                var bVis = oTable.fnSettings().aoColumns[2].bVisible;
                oTable.fnSetColumnVis(2, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[5].bVisible;
                oTable.fnSetColumnVis(5, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[6].bVisible;
                oTable.fnSetColumnVis(6, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[7].bVisible;
                oTable.fnSetColumnVis(7, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[8].bVisible;
                oTable.fnSetColumnVis(8, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[9].bVisible;
                oTable.fnSetColumnVis(9, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[10].bVisible;
                oTable.fnSetColumnVis(10, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[11].bVisible;
                oTable.fnSetColumnVis(11, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[14].bVisible;
                oTable.fnSetColumnVis(14, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[15].bVisible;
                oTable.fnSetColumnVis(15, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[16].bVisible;
                oTable.fnSetColumnVis(16, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[17].bVisible;
                oTable.fnSetColumnVis(17, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[18].bVisible;
                oTable.fnSetColumnVis(18, bVis ? false : true);
                var bVis = oTable.fnSettings().aoColumns[19].bVisible;
                oTable.fnSetColumnVis(19, bVis ? false : true);

                jQuery('#sample_1_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
                jQuery('#sample_1_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
                jQuery('#sample_1_wrapper .dataTables_length select').select2(); // initialize select2 dropdown

                /* Add event listener for opening and closing details
                * Note that the indicator for showing which row is open is not controlled by DataTables,
                * rather it is done here
                */
                $('#tbl_category').on('click', ' tbody td .row-details', function () {
                    var nTr = $(this).parents('tr')[0];
                    if (oTable.fnIsOpen(nTr)) {
                        /* This row is already open - close it */
                        $(this).addClass("row-details-close").removeClass("row-details-open");
                        oTable.fnClose(nTr);
                    }
                    else {
                        /* Open this row */
                        $(this).addClass("row-details-open").removeClass("row-details-close");
                        oTable.fnOpen(nTr, fnFormatDetails(oTable, nTr), 'details');
                    }
                });
            }
        });
    }
    return {
        //main function to initiate the module
        init: function () {
            initTable1();
        }
    };
}();


function resetForm() {
    var form1 = $('#modal_category');
    var error1 = $('.alert-danger', form1);
    var success1 = $('.alert-success', form1);
    error1.hide();
    success1.hide();

    $('#tblImages tbody').html("");
    $('#categoryID').val(0);
    $('#txtCategoryName').val("");
    $('#txtIndex').val("");
    $('#txtMetaDescription').val("");
    $('#txtMetaKeyword').val("");
    $('#txtDescription').val("");
    $('#selectFormTypeID').val(1);
    $('#selectStatus').val(1);
    $('#txtLink').val("");
    $('#txtActionTags').val("");
    $('#txtCategoriesTags').val("");
    $('#txtIcon').val();
    $('#txtCSS').val();
    $('#txtHTML').val();
    loadParent_category();
    loadTags("#txtActionTags", "actiontags", "");
    loadTags("#txtCategoriesTags", "catagorytags", "");   
}

//----------------------Delete---------------------
function DeleteCategory(id) {
    bootbox.confirm("Are you sure?", function (result) {
        if (result) {
            $.ajax({
                type: "POST",
                url: "../../Apis/Categories.ashx",
                data: { type: 32, id: id, mid: 49 },
                dataType: 'json',
                success: function (res) {
                    if (res.status == 0) {
                        TableCategories.init();
                        loadParent_category();
                    }
                    else {
                        bootbox.alert(res.data);
                    }
                }
            });
        }
    });
}

function EditCategory(key) {
    $('#categoryID').val(listCategory[key].CategoryId);
    $('#txtCategoryName').val(listCategory[key].CategoryName);
    $('#txtMetaDescription').val(listCategory[key].MetaDescription);
    $('#txtMetaKeyword').val(listCategory[key].MetaKeyword);
    $('#txtDescription').val(listCategory[key].Description);
    $('#selectFormTypeID').val(listCategory[key].CategoryType);
    $('#txtIndex').val(listCategory[key].DisplayIndex);
    $('#selectStatus').val(listCategory[key].Status);
    $('#txtLink').val(listCategory[key].Link);
    $('#txtIcon').val(listCategory[key].Icon);
    $('#txtCSS').val(listCategory[key].CSS);
    $('#txtHTML').val(listCategory[key].HTML);
    if (listCategory[key].IsMenu == 1) {
        $('#ckbIsMenu').prop('checked', true);
        $('#uniform-ckbIsMenu span').addClass('checked');
    }
    else {
        $('#ckbIsMenu').prop('checked', false);
        $('#uniform-ckbIsMenu span').removeClass('checked');
    }
    loadTags("#txtActionTags", "actiontags", listCategory[key].ActionTags);
    loadTags("#txtCategoriesTags", "catagorytags", listCategory[key].CategoryTags);

    $('#tblImages tbody').html("");
    var listImages = $.parseJSON(listCategory[key].Images);
    console.log(listImages);
    if (listImages != null) {
        $.each(listImages, function (key, value) {
            var parent = "";
            if (value.urlPhone.split('http')[0] != "")
                parent = "..";
            $('#tblImages tbody').append("<tr id='img_" + key + "'>" +
                "<td><img data-fileSize='" + value.size + "' data-fileName='" + value.fileName + "' class='urlImg' " +
                "' data-urlweb='" + value.urlWeb +
                "' data-urltablet='" + value.urlTablet +
                "' data-urlphone='" + value.urlPhone +
                "' width=50 src='" + parent + value.urlPhone + "' style='border: 1px solid gray;margin:5px 10px 5px 0px'/></td>" +
                "<td>" + value.fileName + "</td>" +
                "<td>" + value.size + "</td>" +
                "<td class='colDel'><button type='button' class='btn red delete' onclick='$(\"#img_" + key + "\").remove();'>" +
                "<i class='fa fa-trash-o'></i>" +
                "<span>Delete</span>" +
                "</button></td>" +
                "</tr>");
        });
        $("#tblImages").tableDnD();
    } 
}

function CloneCategory(key) {
    $('#categoryID').val(0);
    $('#txtCategoryName').val(listCategory[key].CategoryName + " - copy");
    $('#txtMetaDescription').val(listCategory[key].MetaDescription);
    $('#txtMetaKeyword').val(listCategory[key].MetaKeyword);
    $('#txtDescription').val(listCategory[key].Description);
    $('#selectFormTypeID').val(listCategory[key].CategoryType);
    $('#txtIndex').val(listCategory[key].DisplayIndex);
    $('#selectStatus').val(listCategory[key].Status);
    $('#txtLink').val(listCategory[key].Link);
    $('#txtIcon').val(listCategory[key].Icon);
    $('#txtCSS').val(listCategory[key].CSS);
    $('#txtHTML').val(listCategory[key].HTML);
    if (listCategory[key].IsMenu == 1) {
        $('#ckbIsMenu').attr('checked', 'checked');
        $('#uniform-ckbIsMenu span').addClass('checked');
    }
    else {
        $('#ckbIsMenu').attr('checked', false);
        $('#uniform-ckbIsMenu span').removeClass('checked');
    }
    loadTags("#txtActionTags", "actiontags", listCategory[key].ActionTags);
    loadTags("#txtCategoriesTags", "catagorytags", listCategory[key].CategoryTags);

    $('#tblImages tbody').html("");
    var listImages = $.parseJSON(listCategory[key].Images);
    console.log(listImages);
    if (listImages != null) {
        $.each(listImages, function (key, value) {
            var parent = "";
            if (value.urlPhone.split('http')[0] != "")
                parent = "..";
            $('#tblImages tbody').append("<tr id='img_" + key + "'>" +
                "<td><img data-fileSize='" + value.size + "' data-fileName='" + value.fileName + "' class='urlImg' " +
                "' data-urlweb='" + value.urlWeb +
                "' data-urltablet='" + value.urlTablet +
                "' data-urlphone='" + value.urlPhone +
                "' width=50 src='" + parent + value.urlPhone + "' style='border: 1px solid gray;margin:5px 10px 5px 0px'/></td>" +
                "<td>" + value.fileName + "</td>" +
                "<td>" + value.size + "</td>" +
                "<td class='colDel'><button type='button' class='btn red delete' onclick='$(\"#img_" + key + "\").remove();'>" +
                "<i class='fa fa-trash-o'></i>" +
                "<span>Delete</span>" +
                "</button></td>" +
                "</tr>");
        });
        $("#tblImages").tableDnD();
    } 
}

function loadParent_category() {
    $.ajax({
        type: "POST",
        url: "../../Apis/Menu.ashx",
        data: { type: 14, mid: 50 },
        dataType: 'json',
        success: function (res) {
            if (res.status == 0 || res.status == 5004) {
                var parentID = AppManage.getURLParameter('parentID');
                if (parentID == null)
                    parentID = 0;
                if (parentID == 0)
                    $("#selectParentID").html("<option value='0' selected='selected'>Parent</option>");
                else
                    $("#selectParentID").html("<option value='0'>Parent</option>");
                console.log(res.data);
                $.each(res.data, function (key, obj) {
                    if (obj.CategoryId == parentID)
                        $("#selectParentID").append("<option value='" + obj.CategoryId + "' selected='selected'>" + obj.CategoryName + "</option>");
                    else
                        $("#selectParentID").append("<option value='" + obj.CategoryId + "'>" + obj.CategoryName + "</option>");
                });
            }
            else {
                bootbox.alert(res.msg);
            }
        }
    });
}

function loadTags(dvHTML, tagType, tagData){
    $(dvHTML).html("");
    $.ajax({
        type: "POST",
        url: "../../Apis/Categories.ashx",
        data: {
            type: 33
            , tagtype: tagType
        },
        dataType: 'json',
        success: function (res) {
            if (res.status > 0) {
                var listTags = [];
                $.each(res.data, function (key, obj) {
                    var selected = "";
                    if (tagData != "") {
                        $.each(tagData.split(','), function (i, d) {
                            if (d == obj.TagName) {
                                selected = "selected";
                                return false;
                            }
                        });
                    }
                    $(dvHTML).append("<option " + selected + " value='" + obj.TagName + "'>" + obj.TagName + "</option>");
                });
            }
            $(dvHTML).select2({
                tags: true,
                tokenSeparators: [',', ' ']
            });
        }
    });
}

var j = 1;
function AddImage(el1, el2) {
    if ($.trim($(el1).val()) != "") {
        $(el2).append("<tr id='li-" + (++j) + "'>" +
            "<td><img class='urlImg' data-fileSize=''" +
            " data-fileName=''" +
            " data-urlweb='" + $(el1).val() +
            "' data-urltablet='" + $(el1).val() +
            "' data-urlphone='" + $(el1).val() +
            "' src='" + $(el1).val() + "' style='width:50px; max-height:65px;border: 1px solid gray;margin:5px 10px 5px 0px'/></td>" +
            "<td></td>" +
            "<td></td>" +
            "<td class='colDel'><button type='button' class='btn red delete' onclick='$(\"#li-" + j + "\").remove();'>" +
            "<i class='fa fa-trash-o'></i> " +
            "<span>Delete</span>" +
            "</button>" +
            "</tr>");
        $(el1).val("");
    }
    else
        alert("Vui lòng nhập vào url ảnh!");
}

var validator;
var FormValidation = function () {
    var f = function () {
        var e = $("#formCategory"),
            r = $(".alert-danger", e),
            i = $(".alert-success", e);
        validator = e.validate({
            errorElement: "span",
            errorClass: "help-block help-block-error",
            focusInvalid: !1,
            ignore: "",
            rules: {
                categoryName: {
                    required: !0
                }
            },
            messages: {
                categoryName: {
                    required: "Vui lòng nhập tên danh mục!"
                }
            },
            invalidHandler: function (e, t) {
                i.hide(), r.show();//App.scrollTo(r, -200);
            },
            errorPlacement: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                i.removeClass("fa-check").addClass("fa-warning"), i.attr("data-original-title", e.text()).tooltip({
                    container: "body"
                });
            },
            highlight: function (e) {
                r.show(); i.hide();
                $(e).closest(".form-group").removeClass("has-success").addClass("has-error");
            },
            unhighlight: function (e) {
                $(e).closest(".form-group").removeClass("has-error");
            },
            success: function (e, r) {
                var i = $(r).parent(".input-icon").children("i");
                $(r).closest(".form-group").removeClass("has-error").addClass("has-success");
                i.removeClass("fa-warning").addClass("fa-check");
            },
            submitHandler: function (e) {
                i.show(), r.hide();
            }
        }), $(".select2me", e).change(function () {
            e.validate().element($(this))
        }), $(".date-picker").datepicker({
            rtl: App.isRTL(),
            autoclose: !0
        }), $(".input-icon .date-picker").change(function () {
            e.validate().element($(this))
        })

    }
    return {
        init: function () {
            f()
        }
    }
}();

function UpdateCategory() {
    $(".divLoading").fadeIn(0);
    var listObjImage = $('#tblImages .urlImg');
    var listImage = [];
    for (var i = 0; i < listObjImage.length; i++) {
        var images = {
            "urlWeb": $(listObjImage[i]).attr("data-urlweb"),
            "urlTablet": $(listObjImage[i]).attr("data-urltablet"),
            "urlPhone": $(listObjImage[i]).attr("data-urlphone"),
            "size": $(listObjImage[i]).attr("data-fileSize"),
            "fileName": $(listObjImage[i]).attr("data-fileName")
        }
        listImage.push(images);
    }
    var index = parseInt($('#txtIndex').val());
    if (isNaN(index))
        index = 0;
    var json = {
        "categoryID": $('#categoryID').val(),
        "categoryName": $('#txtCategoryName').val(),
        "description": $('#txtDescription').val(),
        "metaDescription": $('#txtMetaDescription').val(),
        "metakeyword": $('#txtMetaKeyword').val(),
        "images": listImage,
        "actionTags": $('#txtActionTags').val() != null ? $('#txtActionTags').val().toString() : "",
        "categoryTags": $('#txtCategoriesTags').val() != null ? $('#txtCategoriesTags').val().toString() : "",
        "isMenu": $("#ckbIsMenu").is(':checked') == true ? 1 : 0,
        "displayIndex": index,
        "link": $('#txtLink').val(),
        "icon": $('#txtIcon').val(),
        "css": $('#txtCSS').val(),
        "html": $('#txtHTML').val(),
        "parentId": $('#selectParentID').val(),
        "categoryType": $('#selectFormTypeID').val(),
        "status": $('#selectStatus').val()
    }
    var type = "";
    if ($('#categoryID').val() == 0)
        type = 30;
    else
        type = 31;

    $.ajax({
        type: "POST",
        url: "../../Apis/Categories.ashx",
        data: { type: type, json: JSON.stringify(json), mid: 49 },
        dataType: 'json',
        success: function (res) {
            $(".divLoading").fadeOut(0);
            if (res.status >= 0) {
                $('#modal_category').modal('hide');
                TableCategories.init();
                loadParent_category();
            }
            else {
                bootbox.alert(res.msg);
            }
        }
    });

}