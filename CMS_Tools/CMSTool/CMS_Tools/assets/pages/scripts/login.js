var Login = function () {
    var r = function () {
        $(".login-form").validate({
            errorElement: "span",
            errorClass: "help-block",
            focusInvalid: false,
            rules: {
                username: {
                    required: true
                },
                password: {
                    required: true
                },
                captcha: {
                    required: true
                },
                remember: {
                    required: false
                }
            },
            messages: {
                username: {
                    required: "Vui lòng nhập email hoặc số điện thoại."
                },
                password: {
                    required: "Vui lòng nhập mật khẩu."
                },
                captcha: {
                    required: "Vui lòng nhập captcha."
                }
            },
            invalidHandler: function (label, e) {
                $('.msg').html("Vui lòng điền đầy đủ thông tin bên dưới.");
                $(".alert-danger", $(".login-form")).show();
            },
            highlight: function (label) {
                $(label).closest(".form-group").removeClass("valid");
                $(label).closest(".form-group").addClass("has-error");
            },
            success: function (label) {
                label.closest(".form-group").removeClass("has-error"), label.remove()
            },
            errorPlacement: function (r, e) {
                r.insertAfter(e.closest(".input-icon"));
            },
            submitHandler: function (r) {
                $(".alert-danger", $(".login-form")).hide();
                //TO DO SUBMIT LOGIN
                $('.divLoading').fadeIn(0);
                var param = {
                    type: 0,
                    id: r.username.value,
                    pass: r.password.value,
                    captcha: r.captcha.value,
                    remember: r.remember.checked
                };
                POST_DATA("Apis/Account.ashx", param, function (res) {
                    if (res.status == 0) {
                        //window.location.href = "Dashboard.aspx";
                        window.location.href = "Page.aspx?m=10";
                        return;
                    }
                    else {
                        $('.msg').html(res.msg);
                        $(".alert-danger", $(".login-form")).show();
                        refresh_captcha();
                    }
                    $('.divLoading').fadeOut(0);
                });
            }
        }), $(".login-form input").keypress(function (r) {
            if (13 == r.which) return $(".login-form").validate().form() && $(".login-form").submit(), !1
        }), $(".forget-form input").keypress(function (r) {
            if (13 == r.which) return $(".forget-form").validate().form() && $(".forget-form").submit(), !1
        }), $("#forget-password").click(function () {
            $(".login-form").hide(), $(".forget-form").show()
        }), $("#back-btn").click(function () {
            $(".login-form").show(), $(".forget-form").hide()
        })
    },
        resetPassword = function () {
            $('.divLoading').fadeIn(0);
            var param = {
                type: 3,
                email: $('#txtEmail').val(),
            };
            POST_DATA("Apis/Account.ashx", param, function (data) {
                bootbox.alert(data.msg);
                if (data.status == 0) {
                    $('#txtEmail').val("");
                }
                $('.divLoading').fadeOut(0);
            });
        }
    return {
        init: function () {
            r(), $(".login-bg").backstretch(["assets/pages/img/login/bg1.jpg", "assets/pages/img/login/bg2.jpg"], {
                fade: 1e3,
                duration: 8e3
            }), $(".forget-form").hide()
        },
        resetPassword: function () {
            resetPassword();
        }
    }
}();
jQuery(document).ready(function () {
    Login.init();
});

function refresh_captcha() {
    //$(".login-form").trigger('reset');
    $('.form-control[name="captcha"]').val('');
    var today = new Date();
    var time = today.getHours() + "" + today.getMinutes() + "" + today.getSeconds();
    $('#captcha').attr("src", "../../Apis/Captcha.ashx?t=" + time);
}