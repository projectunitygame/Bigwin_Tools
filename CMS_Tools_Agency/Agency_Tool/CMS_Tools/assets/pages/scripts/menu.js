var flag = true;
var Menu = function () {
    var r = function () {
        var e = $(".menu-form"),
            r = $(".alert-danger", e),
            i = $(".alert-success", e);
        e.validate({
            errorElement: "span",
            errorClass: "help-block help-block-error",
            focusInvalid: false,
            rules: {
                MenuName: {
                    required: true,
                    maxlength: 150
                },
                MenuDescription: {
                    maxlength: 500
                },
                MenuIcon: {
                    maxlength: 500
                },
                MenuClick: {
                    maxlength: 1000
                },
                input_sql_query: {
                    maxlength: 1000
                },
                input_sql_dataType: {
                    maxlength: 1000
                }
            },
            messages: {
                MenuName: {
                    required: "Vui lòng nhập!",
                    maxlength: "Vui lòng không nhập quá 150 ký tự!"
                },
                MenuDescription: {
                    maxlength: "Vui lòng không nhập quá 500 ký tự!"
                },
                MenuIcon: {
                    maxlength: "Vui lòng không nhập quá 50 ký tự!"
                },
                MenuClick: {
                    maxlength: "Vui lòng không nhập quá 1000 ký tự!"
                },
                input_sql_query: {
                    maxlength: "Vui lòng không nhập quá 1000 ký tự!"
                },
                input_sql_dataType: {
                    maxlength: "Vui lòng không nhập quá 1000 ký tự!"
                }
            },
            invalidHandler: function (e, t) {
                i.hide(), r.show(), App.scrollTo(r, -200)
            },
            errorPlacement: function (e, r) {
                var i = $(r).parent(".input-group");
                i.size() > 0 ? i.after(e) : r.after(e)
            },
            highlight: function (e) {
                $(e).closest(".form-group").addClass("has-error")
            },
            unhighlight: function (e) {
                $(e).closest(".form-group").removeClass("has-error")
            },
            success: function (e) {
                e.closest(".form-group").removeClass("has-error")
            },
            submitHandler: function (e) {
                if (!flag) {
                    console.log("Error double click!");
                    return;
                }
                flag = false;
                i.show(), r.hide();
                $(".alert-danger", $(".menu-form")).hide();
                //TO DO SUBMIT LOGIN
                $(".divLoading").fadeIn(0);
                var json = {
                    menuId: $("#input_menuID").val(),
                    parentId: $("#PageContent_input_parent").val(),
                    menuName: $("#input_menuName").val(),
                    description: $("#input_menuDescription").val(),
                    icon: $("#input_icon").val(),
                    onclick: $("#input_menuClick").val(),
                    dislayIndex: $("#input_displayIndex").val(),
                    status: $("#input_status").val(),
                    css: mirro2.getValue(),
                    js: mirro1.getValue(),
                    html: mirro3.getValue(),
                    databaseId: $("#input_database").val() != "" ? $("#input_database").val() : 0,
                    sql_query: (mirro4 != null ? mirro4.getValue() : ""),
                    sql_dataType: (mirro5 != null ? mirro5.getValue() : ""),
                    type_query: $("input[name='radio1']:checked").val()
                };
                console.log(json);
                var param = {
                    type: $("#input_menuID").val() == "0" ? 8 : 9,
                    json: JSON.stringify(json)
                };
                POST_DATA(URL_MENU, param, function (data) {
                    $(".divLoading").fadeOut(0);
                    flag = true;
                    if (data.status == 0) {
                        if (window.opener != null)
                            window.opener.CloseWindow(AppManage.getURLParameter("index"), "success");
                    }
                    else {
                        bootbox.alert({
                            message: data.msg,
                            callback: function () {
                                //if (window.opener != null)
                                //    window.opener.CloseWindow(AppManage.getURLParameter("index"), "success");
                            }
                        });
                    }                  
                });
            }
        }), $(".menu-form input").keypress(function (r) {
            if (13 == r.which) return $(".menu-form").validate().form() && $(".menu-form").submit(), !1
        });
    },
        a = function () {           
            POST_DATA(URL_MENU, { type: 15, p: $("#PageContent_input_action").val() }, function (res) {
                $(".divLoading").fadeOut(500);
                if (res.status == 0) {
                    var data = res.data[0];
                    mirro1 = ComponentsCodeEditors.editor("code_editor_js", "ambiance", "javascript");
                    mirro2 = ComponentsCodeEditors.editor("code_editor_css", "neat", "css");
                    mirro3 = ComponentsCodeEditors.editor("code_editor_html", "neat", "html");
                    if (res.data != "") {
                        $("#input_menuID").val(data.MenuID);
                        $("#input_menuName").val(data.MenuName);
                        $("#input_menuDescription").val(data.Description);
                        $("#input_icon").val(data.Icon);
                        $("#input_menuClick").val(data.Onclick);
                        $("#input_displayIndex").val(data.DisplayIndex);
                        $("#input_status").val(data.Status);
                        if (data.DatabaseID != "") {
                            $("#input_database").val(data.DatabaseID);
                            $(".sql_group").fadeIn(0);
                            $("#input_database").prop("required", true);
                            mirro4 = ComponentsCodeEditors.editor("input_sql_query", "neat", "javascript");
                            mirro5 = ComponentsCodeEditors.editor("input_sql_dataType", "neat", "javascript");
                            mirro4.setValue(data.SQL_Query);
                            mirro5.setValue(data.SQL_DataType);
                        }
                        else {
                            $("#input_database").val("0");
                        }
                        mirro1.setValue(data.JS);
                        mirro2.setValue(data.CSS);
                        mirro3.setValue(data.HTML);
                        $("#checkbox1_" + data.TypeQuery).prop("checked", true);
                    }
                }
                else {                   
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {
                            
                        }
                    });
                }
            });
        },
        b = function () {
            $(".divLoading").fadeIn(0);
            POST_DATA(URL_MENU, { type: 19 }, function (res) {
                if (res.status == 0) {
                    $('#input_database').html("<option value='0'>NO DATABASE</option>");
                    $.each(res.data, function (i, obj) {
                        $('#input_database').append("<option value='" + obj + "'>" + obj + "</option>");
                    });                   
                }
                a();
            });
        }
    return {
        init: function () {
            b();
            r();
            for (var i = 0; i <= 100; i++) {
                $("#input_displayIndex").append("<option value='" + i + "'>" + i + "</option>");
            }
            $("#input_displayIndex").select2();
        },
        cancel: function () {
            if (window.opener != null)
                window.opener.CloseWindow(AppManage.getURLParameter("index"), "cancel");
        }
    }
}();

var mirro1 = null, mirro2 = null, mirro3 = null, mirro4 = null, mirro5 = null;
jQuery(document).ready(function () {  
    Menu.init();
    $("#input_database").change(function () {
        console.log("DB: " + $(this).val());
        if ($(this).val() != "") {
            $("#checkbox1_1").prop("checked", true);
            $(".sql_group").fadeIn(0);
            $("#input_database").prop("required", true);
            if (mirro4 == null && mirro5 == null) {
                mirro4 = ComponentsCodeEditors.editor("input_sql_query", "neat", "javascript");
                mirro5 = ComponentsCodeEditors.editor("input_sql_dataType", "neat", "javascript");
            }
        }
        else {
            $("#checkbox1_0").prop("checked", true);
            $(".sql_group").fadeOut(0);
            $("#input_database").val("0");
            $("#input_database").removeAttr("required");
            $("#input_database").parent().parent().removeClass("has-error");
            $("#input_database-error").remove();
        }
    });
    

    $("input[name='radio1']").change(function () {
        var d = $(this).val();
        if (d == 0) {
            $(".sql_group").fadeOut(0);
            $("#input_database").val("0");
            $("#input_database").removeAttr("required");
            $("#input_database").parent().parent().removeClass("has-error");
            $("#input_database-error").remove();
        }
        else {
            $(".sql_group").fadeIn(0);
            $("#input_database").prop("required", true);
            if (mirro4 == null && mirro5 == null) {
                mirro4 = ComponentsCodeEditors.editor("input_sql_query", "neat", "javascript");
                mirro5 = ComponentsCodeEditors.editor("input_sql_dataType", "neat", "javascript");
            }
        }
    });
});