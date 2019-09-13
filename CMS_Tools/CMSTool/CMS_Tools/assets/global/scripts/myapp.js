var CONFIG = {
    "SIGN_OUT" : 1
}
var AccountManage = function () {
    var a = function () {
        if ($("#_userdata").val() != "") {
            var user = $.parseJSON($("#_userdata").val());
            $(".myavatar").attr("src", user.Avatar != "" ? user.Avatar : "assets/global/img/avatar.png");
            $(".username").html(user.UserName + "("+user.Code+")");
        }
        else
            window.location.href = "login.aspx";
    },
        ViewProfile = function () {

        },
        Logout = function () {           
            POST_DATA("Apis/Account.ashx", { type: CONFIG.SIGN_OUT }, function (res) {
                console.log(res);
                if (res.status == 0) {
                    window.location.href = "login.aspx";
                    //Disconnect(function () {
                    //});    
                }
            });
        }
    return {
        init: function () {
            a();
        },
        ViewProfile: function () {
            alert("function dev");
        },
        Logout: function () {
            Logout();
        }
    }
}();


$(document).ready(function () {
    AccountManage.init();
    $('#tbl_datatable').delegate('tbody tr', 'click', function () {
        if ($(this).hasClass('active')) { return; } else {
            $('#tbl_datatable tbody tr').removeClass('active');
            $(this).addClass('active');
        }
    });
});