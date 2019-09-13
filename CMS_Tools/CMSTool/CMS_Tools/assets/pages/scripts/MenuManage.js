jQuery(document).ready(function () {
    MenuManage.init();

    $("#tbl_menu tbody").delegate(".checkbox_menu", "change", function () {
        if (this.checked) {
            if ($(".checkbox_menu:checked").length == $("input[name='ckbox[]']").length) {
                $(".checkbox_all").prop("checked", true);
            }
            $(".btnMenu_button a").removeClass("disable");
        }
        else {
            if ($(".checkbox_menu:checked").length == 0) {
                $(".btnMenu_button a").addClass("disable");
                $(".checkbox_all").prop("checked", false);
            }      
            if ($(".checkbox_menu:checked").length < $("input[name='ckbox[]']").length) {
                $(".checkbox_all").prop("checked", false);
            }
        }
    });

    $("#tbl_menu thead").delegate(".checkbox_all", "change", function () {
        if (this.checked) {
            $(".btnMenu_button a").removeClass("disable");
            $(".checkbox_menu").prop("checked", true);
        }
        else {
            $(".btnMenu_button a").addClass("disable");
            $(".checkbox_menu").prop("checked", false);
        }
    });

    $("#btnMenu_remove").click(function () {
        var arr = [];
        $(".checkbox_menu:checked").each(function (key, obj) {
            arr[key] = $(obj).val()
        });
        if (arr.length == 0)
            return
        bootbox.confirm("Xác nhận xóa (" + arr.length + ") menu?", function (result) {
            if (result) {
                if ($("#btnMenu_remove").attr("step") != 0) {
                    return;
                }
                $(".divLoading").fadeIn(0);
                $("#btnMenu_remove").attr("step", 1);
                MenuManage.RemoveMenu(arr.join(","));
            }
        });   
    });

    $("#btnMenu_edit").click(function () {
        var arr = [];
        $(".checkbox_menu:checked").each(function (key, obj) {
            arr[key] = $(obj).val()
        });
        var w = window.innerWidth;
        var h = window.innerHeight;
        console.log(w + ", " + h);
        for (var i = 0; i < arr.length; i++) {
            windowOpen.push(window.open("Menu.aspx?m=" + arr[i] + "&action=2&index=" + window_index, "_blank", "location=yes,height="+h+",width="+w+",scrollbars=yes,status=yes"));
            window_index++;
        }
    });

    $("#btnMenu_clone").click(function () {
        var arr = [];
        $(".checkbox_menu:checked").each(function (key, obj) {
            arr[key] = $(obj).val()
        });
        if (arr.length == 0)
            return;
        bootbox.confirm("Xác nhận sao chép (" + arr.length + ") menu?", function (result)
        {
            if (result) {
                if ($("#btnMenu_clone").attr("step") != 0) {
                    return;
                }
                $(".divLoading").fadeIn(0);
                $("#btnMenu_clone").attr("step", 1);
                MenuManage.CloneMenu(arr.join(","));
            }
        });       
    });

    $(".btnAddMenu").click(function () {
        var w = window.innerWidth;
        var h = window.innerHeight;
        windowOpen.push(window.open("Menu.aspx?m=0&action=1&index=" + window_index + "&parent=" + $("#PageContent_input_parentID").val(), "_blank", "location=yes,height=" + h + ",width=" + w + ",scrollbars=yes,status=yes"));
        window_index++;
    });
});


var windowOpen = [];
var window_index = 0;
var oTable;
var listMenu;
var objSelectParent;
var _listMenu;
var count = 0;
var pageSize = 10;
var pageNum = 0;
var _currentPage = 0;
var MenuManage = function () {
    var l = function () {
        $(".divLoading").fadeIn(0);
        POST_DATA(URL_MENU, { type: 12, dataType: 1, parentId: $("#PageContent_input_parentID").val()}, function (res) {
            if (res.status == 0 || res.status == 5004) {
                if (oTable != null) {
                    _currentPage = oTable.fnPagingInfo().iPage;
                    oTable.fnDestroy();
                }
                var thead = "<tr role='row'><th><label class='mt-checkbox mt-checkbox-single mt-checkbox-outline'> <input type='checkbox' class='checkboxes checkbox_all'/> <span></span> </label></th>";
                for (var i = 0; i < res.columnName.length; i++) {
                    thead += "<th>" + res.columnName[i] + "</th>";
                }
                $("#tbl_menu thead").html(thead + "</tr>");
                var tblHtml = "";
                $.each(res.data, function (key, obj) {
                    tblHtml += "<tr><td style='width:50px'><label class='mt-checkbox mt-checkbox-single mt-checkbox-outline'> <input name='ckbox[]' type='checkbox' class='checkboxes checkbox_menu' value='" + obj[0] + "' /> <span></span> </label></td>";
                    for (var i = 0; i < obj.length; i++) {
                        tblHtml += "<td>" + obj[i].replace("{URL=}", "MenuManage.aspx?parentId=" + obj[0] + "&psize=" + pageSize + "&pnum=" + pageNum) + "</td>";
                    }
                    tblHtml += "</tr>";
                    //$("#tbl_menu tbody").append("<tr>" +
                    //    "<td style="width:50px"><label class="mt-checkbox mt-checkbox-single mt-checkbox-outline"> <input name="ckbox[]" type="checkbox" class="checkboxes checkbox_menu" value="" + obj.MenuID + "" /> <span></span> </label></td>" +
                    //    "<td style="width:100px">" + obj.MenuID + "</td>" +
                    //    "<td>" + obj.MenuName + "</td>" +
                    //    "</tr>");
                });
                $("#tbl_menu tbody").html(tblHtml);
                oTable = $("#tbl_menu").DataTable({
                    "aLengthMenu": [
                        [10, 30, 50, 100, -1],
                        [10, 30, 50, 100, "All"]
                    ],
                    //"iDisplayLength": pageSize,
                    //"iDisplayStart": pageNum * pageSize,
                    "displayStart": _currentPage * pageSize, 
                    "pageLength": pageSize,
                    "aoColumnDefs": [{
                        "bSortable": false,
                        "aTargets": [0]
                    }],
                    "aaSorting": [[0, "asc"]]
                });
                jQuery("#sample_1_wrapper .dataTables_filter input").addClass("form-control input-small"); // modify table search input
                jQuery("#sample_1_wrapper .dataTables_length select").addClass("form-control input-small"); // modify table per page dropdown
                jQuery("#sample_1_wrapper .dataTables_length select").select2(); // initialize select2 dropdown
                oTable.on("draw", function () {
                    pageNum = oTable.fnPagingInfo().iPage;
                    pageSize = oTable.fnPagingInfo().iLength;
                    console.log("pageSize: " + pageSize);
                    console.log("pageNum: " + pageNum);
                    history.pushState({}, "", "MenuManage.aspx?psize=" + pageSize + "&pnum=" + pageNum);
                });
                $(".btnMenu_button a").addClass("disable");
                $(".checkbox_all").prop("checked", false);
            }
            else {
                bootbox.alert(res.msg);
            }
            $(".divLoading").fadeOut(500);    
        });
    },
    c = function (menuId) {
        POST_DATA(URL_MENU, { type: 16, menuId: menuId }, function (res) {
            $("#btnMenu_clone").attr("step", 0);
            $(".divLoading").fadeOut(500);
            if (res.status == 0)
                MenuManage.LoadMenu();
            else
                bootbox.alert(res.msg);
        });       
    },
    r = function (menuId) {
        POST_DATA(URL_MENU, { type: 10, menuId: menuId }, function (res) {
            $("#btnMenu_remove").attr("step", 0);
            $(".divLoading").fadeOut(500);
            if (res.status == 0)
                MenuManage.LoadMenu();
            else
                bootbox.alert(res.msg);
        });
    }


    return {
        init: function () {
            var pSize = AppManage.getURLParameter("psize");
            var pNum = AppManage.getURLParameter("pnum");
            if (pSize != null)
                pageSize = pSize;
            if (pNum != null) {
                pageNum = pNum;
                _currentPage = pNum;
            }
            l();
        },
        CloneMenu: function (menuId) {
            c(menuId);
        },
        RemoveMenu: function (menuId) {
            r(menuId);
        },
        LoadMenu: function () {
            l();
        }
    }
}();

function CloseWindow(index, status) {
    if (windowOpen.length > 0) {
        windowOpen[index].close();
        if (status == "success")
            MenuManage.LoadMenu();
    }
}


