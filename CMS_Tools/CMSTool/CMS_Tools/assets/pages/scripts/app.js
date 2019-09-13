var URL_MENU = "Apis/Menu.ashx";
var URL_ACCOUNT = "Apis/Account.ashx";


var AppManage = function () {
    var getURLParameter = function (paramName) {
        var searchString = window.location.search.substring(1),
            i, val, params = searchString.split("&");

        for (i = 0; i < params.length; i++) {
            val = params[i].split("=");
            if (val[0] == paramName) {
                return unescape(val[1]);            
            }
        }
        return null;
    }

    return {
        getURLParameter: function (paramName) {
            return getURLParameter(paramName);
        }
    }
}();