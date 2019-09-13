var _lstMenu = [];
var _lstRules = [];
var listMenu;
var listRulesMenu;
var listObj = [];
var tempID = [];
var listGroupAccount;
var count = 0;
var UINestable = function () {
    return {
        //main function to initiate the module
        init: function () {
            $(".divLoading").fadeIn(0);
            loadPermissions();
            loadGroupAccount();
            function getSubMenu(menuId) {
                var results = "";
                $.each(listMenu, function (key, obj) {
                    if (obj.parentID == menuId) {
                        var _selectRules = "";
                        if (obj.isRules)
                            _selectRules = "<select id='checkRule_" + obj.id + "' class='rulesID' multiple='multiple' data-placeholder='Select rules...'>" + getRulesMenu(obj.id) + "</select>";
                        results += "<ol class='dd-list'>" +
                            "<li class='dd-item' data-id='3'>" +
                            "<input class='menuID' type='checkbox' value='" + obj.id + " ' " + checkMenuID(obj.id) + "/>" +
                            _selectRules +
                            "<div class='dd-handle'>" +
                            obj.menuName +
                            '</div>' + getSubMenu(obj.id) +
                            "</li>" +
                            "</ol>";
                        if (_selectRules != "") {
                            tempID.push(obj.id);
                        }
                    }
                });
                return results;
            }
            function getRulesMenu(menuID) {
                var result = "";
                var rules = undefined;
                if (listGroupAccount.menuID != null && listGroupAccount.menuPermissions != "") {
                    console.log(listGroupAccount.menuID);
                    var listMenuIDs = $.parseJSON(listGroupAccount.menuID);
                    var listRulesIDs = $.parseJSON(listGroupAccount.menuPermissions);
                    for (var i = 0; i < listMenuIDs.length; i++) {
                        if (parseInt(listMenuIDs[i]) == menuID) {
                            rules = listRulesIDs[i];
                        }
                    }
                }
                $.each(listRulesMenu, function (key, obj) {
                    var flag = true;
                    if (rules != undefined) {
                        var array_rules = rules;                    
                        for (var j = 0; j < array_rules.length; j++) {
                            if (obj.id == array_rules[j]) {
                                result += "<option value='" + obj.id + "' selected>" + obj.name + "</option>";
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag)
                        result += "<option value='" + obj.id + "'>" + obj.name + "</option>";
                });
                return result;
            }
            function checkMenuID(menuID) {
                var result = "";
                if (listGroupAccount.menuID != null && listGroupAccount.menuID != "") {
                    var listMenuIDs = $.parseJSON(listGroupAccount.menuID);
                    for (var i = 0; i < listMenuIDs.length; i++) {
                        if (menuID == parseInt(listMenuIDs[i])) {
                            result = "checked";
                            break;
                        }
                    }
                }
                return result;
            }
            function loadGroupAccount() {
                $.ajax({
                    type: "POST",
                    url: "Apis/Menu.ashx",
                    data: { type: "24", id: AppManage.getURLParameter("gid")},
                    dataType: 'json',
                    success: function (res) {
                        if (res.status == 5005) {
                            window.location.assign("login.aspx");
                            return;
                        }
                        if (res.status == 0) {
                            listGroupAccount = res.data;
                            count++;
                            CallbackData();
                        }
                    }
                });
            }
            function loadPermissions() {
                $.ajax({
                    type: "POST",
                    url: "Apis/Menu.ashx",
                    data: { type: "23" },
                    dataType: 'json',
                    success: function (res) {
                        if (res.status == 5005) {
                            window.location.assign("login.aspx");
                            return;
                        }
                        if (res.status == 0) {
                            listRulesMenu = res.data;
                            count++;
                            CallbackData();
                        }
                    }
                });
            }
            function loadMenu() {
                $.ajax({
                    type: "POST",
                    url: "Apis/Menu.ashx",
                    data: { type: "25"},
                    dataType: 'json',
                    success: function (res) {
                        if (res.status == 5005) {
                            window.location.assign("login.aspx");
                            return;
                        }
                        if (res.status > 0) {
                            listMenu = res.data;
                            $.each(listMenu, function (key, obj) {
                                if (obj.parentID == "0") {
                                    var selectRules = "";
                                    if (obj.isRules == 1)
                                        selectRules = "<select id='checkRule_" + obj.id + "' class='rulesID' multiple='multiple' data-placeholder='Select rules...'>" + getRulesMenu(obj.id) + "</select>";
                                    $('#nestable_list_1').append("<ol class='dd-list'><li id='sub' class='dd-item' data-id='1'>" +
                                        "<input class='menuID' type='checkbox' value='" + obj.id + " ' " + checkMenuID(obj.id) + "/>" +
                                        selectRules +
                                        "<div class='dd-handle'>" +
                                        obj.menuName +
                                        "</div>" + getSubMenu(obj.id) +
                                        "</li></ol>");
                                    //alert(selectRules);
                                    if (selectRules != "") {
                                        listObj[obj.id] = $('#checkRule_' + obj.id).kendoMultiSelect().data("kendoMultiSelect");
                                    }
                                }
                            });

                            for (var i = 0; i < tempID.length; i++) {
                                listObj[tempID[i]] = $('#checkRule_' + tempID[i]).kendoMultiSelect().data("kendoMultiSelect");
                            }
                        }
                    },
                    complete: function () {
                        // activate Nestable for list 1
                        $('#nestable_list_1').nestable({
                            group: 1
                        });
                        $('.dd').nestable('collapseAll');
                        //.on('change', updateOutput);

                        // output initial serialised data
                        //updateOutput($('#nestable_list_1').data('output', $('#nestable_list_1_output')));

                        $('#nestable_list_menu').on('click', function (e) {
                            var target = $(e.target),
                                action = target.data('action');
                            if (action === 'expand-all') {
                                $('.dd').nestable('expandAll');
                            }
                            if (action === 'collapse-all') {
                                $('.dd').nestable('collapseAll');
                            }
                        });
                        $(".divLoading").fadeOut(0);
                        $('#btn_expandall').click();
                    }
                });
            }
            function CallbackData() {
                if (count == 2) {
                    loadMenu();                   
                }
            }
        }
    };
}();


$(document).ready(function () {
    UINestable.init();
    $('#btn_update').click(function () {
        _lstMenu = [];
        _lstRules = [];
        $('.menuID:checked').each(function (i) {
            var idtemp = parseInt($(this).val());
            _lstMenu.push(idtemp);
            if (listObj[idtemp] == undefined)
                _lstRules.push([]);
            else {
                var d = listObj[idtemp].value();
                var arr = [];
                for (var i = 0; i < d.length; i++) {
                    arr.push(parseInt(d[i]));
                }
                _lstRules.push(arr);
            }
        });      
        $.ajax({
            type: "POST",
            url: "Apis/Menu.ashx",
            data: { type: "26", id: AppManage.getURLParameter("gid"), listMenu: JSON.stringify(_lstMenu), listPermissions: JSON.stringify(_lstRules) },
            dataType: 'json',
            success: function (res) {
                if (res.status == 0) {
                    bootbox.alert("Cập nhật thành công", function () {
                        window.history.back();
                    });
                }
                else {
                    bootbox.alert(res.msg);
                }
                _lstMenu = [];
                _lstRules = [];
            }
        });
    });
});