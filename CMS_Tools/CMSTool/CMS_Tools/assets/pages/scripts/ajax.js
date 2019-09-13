function POST_DATA(url, param, callback) {
    $.ajax({
        type: "POST",
        url: url,
        data: param,
        dataType: "json",
        beforeSend: function () {
            
        },
        success: function (data) {
            return callback(data);
        },
        complete: function () {
        }
    });
}