<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_GameDT_Quythuong.aspx.cs" Inherits="CMS_Tools.Test_Quythuong_Minipoker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .easy-autocomplete-container ul li, .easy-autocomplete-container ul .eac-category {
            font-size: 12px !important;
        }

        .easy-autocomplete {
            float: left;
            margin-right: 10px;
            width:100% !important;
        }
        .avatar_u{
    height: 50px;
    border: 1px solid #ddd;
    border-radius: 50% !important;
}
.form-section {
    margin: 20px 0;
    padding-bottom: 5px;
    border-bottom: 1px solid #eee;
    font-size: 12px;
    color: #333;
    text-transform: uppercase;
}
.btn-group-xs>.btn, .btn-xs{
	font-size:11px !important;
}
.table td, .table th {
    font-size: 12px !important;
}
.select2-container--bootstrap .select2-selection, .form-control, output{
	font-size: 12px !important;
}

.control-label{
	text-align:left !important;
}

.dataTable thead tr, .dataTable tfoot tr{
    background: #1871af;
    color: #FFF;
    border: 1px solid #1871af;
    font-weight: 600;
}

.dataTables_wrapper > .row{
    display:none;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <div class="divLoading" style="display: none;">
        <div class="lds-default">
            <div></div>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
        </div>
        <span>Đang xử lý...</span>
    </div>
    <!--Minipoker-->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                       Minipoker game
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body"> 
                    <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable"
                            aria-describedby="sample_1_info">
                           <thead><tr role="row"></tr></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot><tr role="row"></tr></tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Slot1-->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                       Nông trại
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body"> 
                    <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable2"
                            aria-describedby="sample_1_info">
                           <thead><tr role="row"></tr></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot><tr role="row"></tr></tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Slot2 (Mafia)-->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                       Mafia
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body"> 
                    <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable3"
                            aria-describedby="sample_1_info">
                           <thead><tr role="row"></tr></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot><tr role="row"></tr></tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Slot3 (Hải vương)-->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                       Hải vương
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body"> 
                    <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable4"
                            aria-describedby="sample_1_info">
                           <thead><tr role="row"></tr></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot><tr role="row"></tr></tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <!--Thần quay (Vua bão) -->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                       Vua bão
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body"> 
                    <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable5"
                            aria-describedby="sample_1_info">
                           <thead><tr role="row"></tr></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot><tr role="row"></tr></tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <!--Hilo (Cao thấp) -->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                       Cao thấp
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body"> 
                    <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable6"
                            aria-describedby="sample_1_info">
                           <thead><tr role="row"></tr></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot><tr role="row"></tr></tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Disk Sharking (Xóc xóc)-->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                       Xóc xóc
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body"> 
                    <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable7"
                            aria-describedby="sample_1_info">
                           <thead><tr role="row"></tr></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot><tr role="row"></tr></tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--HooHeyHow (Bầu cua)-->
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                       Bầu cua
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body"> 
                    <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable8"
                            aria-describedby="sample_1_info">
                           <thead><tr role="row"></tr></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot><tr role="row"></tr></tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--nhập user nổ hủ-->
    <div id="modal_jackpot_user" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_jackpot_user" class="form-horizontal" novalidate="novalidate">
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title">
                                <i class="fa fa-edit"></i> NHẬP THÔNG TIN USER NỔ HŨ</h4>
                        </div>
                        <div class="form-body">
                            <div class="alert alert-danger2 display-hide">
                                <button class="close" data-close="alert"></button>
                                Vui lòng kiểm tra và nhập đầy đủ thông tin!
                            </div>
                            <div class="alert alert-success2 display-hide">
                                <button class="close" data-close="alert"></button>
                                Nhập thông tin hợp lệ
                            </div>
                            <input id="ID_Game" type="hidden"/>
                            <input id="ID_Room" type="hidden"/>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-4">
                                            Nhập tên hiển thị: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtAccountID" name="AccountID" class="form-control" value="" />
                                                <span class="loading1" style="display: none;width: 29px;position: absolute;right: 1px;top: 3px;"><img style='max-width: 100%;' src="assets/global/img/loading_spinner.gif"></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                          </div>  
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn dark btn-outline">Hủy</button>
                        <button type="submit" class="btn green">Đăng Ký</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script src="assets/global/plugins/Base64JS.js"></script>
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var options = {
                url: function (param) {
                    return "Apis/API_GameAccount.ashx";
                },
                getValue: function (element) {
                    $('.loading1').fadeOut(10);
                    return element.AccountID + '-' + element.DisplayName;
                },
                ajaxSettings: {
                    dataType: "json",
                    method: "POST",
                    data: {
                        type: 19,
                        mid: AppManage.getURLParameter('m')
                    }
                },
                preparePostData: function (data) {
                    $('.loading1').fadeIn();
                    data.param = $("#txtAccountID").val();
                    return data;
                },
                requestDelay: 500
            };
            $("#txtAccountID").easyAutocomplete(options);
        })

        jQuery(document).ready(function () {
            $('.page-toolbar').remove();
            //load danh sach dai ly
            TableEditable.init();
            FormValidation.init();
        });

        var FormValidation = function () {
            var r = function () {
                var e = $("#form_jackpot_user"),
                    r = $(".alert-danger", e),
                    i = $(".alert-success", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        AccountID: {
                            required: !0
                        }
                        //MenhGia: {
                        //    required: !0
                        //},
                        //Captcha: {
                        //    required: !0
                        //}
                        //province: {
                        //    required: !0
                        //},
                        //country: {
                        //    required: !0
                        //}
                        //digits: {
                        //    required: !0,
                        //    digits: !0
                        //},
                        //creditcard: {
                        //    required: !0,
                        //    creditcard: !0
                        //}
                    },
                    invalidHandler: function (e, t) {
                        i.hide(), r.show(), App.scrollTo(r, -200)
                    },
                    errorPlacement: function (e, r) {
                        var i = $(r).parent(".input-icon").children("i");
                        i.removeClass("fa-check").addClass("fa-warning"), i.attr("data-original-title", e.text()).tooltip({
                            container: "body"
                        })
                    },
                    highlight: function (e) {
                        $(e).closest(".form-group").removeClass("has-success").addClass("has-error")
                    },
                    unhighlight: function (e) { },
                    success: function (e, r) {
                        var i = $(r).parent(".input-icon").children("i");
                        $(r).closest(".form-group").removeClass("has-error").addClass("has-success"), i.removeClass("fa-warning").addClass("fa-check");
                    },
                    submitHandler: function (e) {
                        //i.show(), 
                        r.hide(),
                            SubMitJackpotUser();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();


        var _pageSize = 50,
            oTable = null,
            colFilter = null,
            _dataColumn = null,
            oTable2 = null,
            colFilter2 = null,
            _dataColumn2 = null,
            oTable3 = null,
            colFilter3 = null,
            _dataColumn3 = null,
            oTable4 = null,
            colFilter4 = null,
            _dataColumn4 = null,
            oTable5 = null,
            colFilter5 = null,
            _dataColumn5 = null,
            oTable6 = null,
            colFilter6 = null,
            _dataColumn6 = null,
            oTable7 = null,
            colFilter7 = null,
            _dataColumn7 = null,
            oTable8 = null,
            colFilter8 = null,
            _dataColumn8 = null;

        var TableEditable = function () {
            var MinipokerTable = function () {
                var table = $('#tbl_datatable');
                loadTable();
                function loadTable() {
                    $('.divLoading').fadeIn();
                    var param = [];
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 80,
                            p: JSON.stringify(param)
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 5005) {
                                window.location.assign("login.aspx");
                                return;
                            }
                            if (data.status == 0) {
                                if (oTable != null) {
                                    oTable.fnDestroy();
                                    $('#tbl_datatable tbody').html("");
                                }
                                _dataColumn = data.columnName;
                                if (colFilter == null) {
                                    $('#tbl_datatable thead tr').html("");
                                    colFilter = _dataColumn;
                                    var strHtmlColName = "";
                                    $.each(_dataColumn, function (key, obj) {
                                        strHtmlColName += "<td>" + obj + "</td>";
                                    });
                                    $('#tbl_datatable thead tr').append(strHtmlColName);
                                    if (data.data.length > 20) {
                                        $('#tbl_datatable tfoot tr').append(strHtmlColName);
                                    }
                                } else {
                                    $('#tbl_datatable tfoot tr').empty();
                                    if (data.data.length > 20) {
                                        var strHtmlColName = "";
                                        $.each(_dataColumn, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable tfoot tr').append(strHtmlColName);
                                    }
                                }

                                for (var i = 0; i < data.data.length; i++) {
                                    var obj = data.data[i];
                                    var func = 'ExceptFund(1,"' + obj[0] + '");';
                                    var updateGiftcode = "<a class='btn btn-xs red btn-circle btn-outline' onclick='" + func + "' >Trừ quỹ game</a>";
                                    var funcJackpot = 'Jackpot(3,"' + obj[0] + '");';
                                    var Jackpot = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='" + funcJackpot + "' >Đập hũ(Bot)</a>";
                                    var funcJackpotUser = 'JackpotUser(3,"' + obj[0] + '");';
                                    var JackpotUser = "<a class='btn btn-xs green btn-circle btn-outline' onclick='" + funcJackpotUser + "' >Đập hũ (User) </a>";
                                    $('#tbl_datatable tbody').append("<tr>" +
                                        "<td>" + obj[0] + "</td>" +
                                        "<td>" + obj[1] + "</td>" +
                                        "<td>" + obj[2] + "</td>" +
                                        "<td>" + obj[3] + "</td>" +
                                        "<td>" + updateGiftcode + Jackpot + JackpotUser +  "</td>" +
                                        "</tr>");
                                }

                                var colHiden = [];
                                oTable = table.dataTable({
                                    //"data": data.data,
                                    "lengthMenu": [
                                        [50, 100, 500, -1],
                                        [50, 100, 500, "All"]
                                    ],
                                    "pageLength": _pageSize,
                                    "language": {
                                        "lengthMenu": " _MENU_ records"
                                    },
                                    "columnDefs": [{
                                        'orderable': true,
                                        'targets': colHiden
                                    }, {
                                        "searchable": true,
                                        "targets": [0]
                                    }],
                                    "order": [
                                        [0 , "asc"]
                                    ]
                                });

                                if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                                    var bVis = oTable.fnSettings().aoColumns[4].bVisible;
                                    oTable.fnSetColumnVis(4, bVis ? false : true);
                                }
                            }
                            else {
                                bootbox.alert({
                                    message: data.msg,
                                    callback: function () {
                                    }
                                });
                            }
                        },
                        complete: function () {
                            setTimeout($(".divLoading").fadeOut(500),3000);
                        }
                    });
                }
            },
                Slot1Table = function () {
                var table = $('#tbl_datatable2');
                loadTable();
                function loadTable() {
                    //$('.divLoading').fadeIn();
                    var param = [];
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 81,
                            p: JSON.stringify(param)
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 5005) {
                                window.location.assign("login.aspx");
                                return;
                            }
                            if (data.status == 0) {
                                if (oTable2 != null) {
                                    oTable2.fnDestroy();
                                    $('#tbl_datatable2 tbody').html("");
                                }
                                _dataColumn2 = data.columnName;
                                if (colFilter2 == null) {
                                    $('#tbl_datatable2 thead tr').html("");
                                    colFilter2 = _dataColumn2;
                                    var strHtmlColName = "";
                                    $.each(_dataColumn2, function (key, obj) {
                                        strHtmlColName += "<td>" + obj + "</td>";
                                    });
                                    $('#tbl_datatable2 thead tr').append(strHtmlColName);
                                    if (data.data.length > 20) {
                                        $('#tbl_datatable2 tfoot tr').append(strHtmlColName);
                                    }
                                } else {
                                    $('#tbl_datatable2 tfoot tr').empty();
                                    if (data.data.length > 20) {
                                        var strHtmlColName = "";
                                        $.each(_dataColumn2, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable2 tfoot tr').append(strHtmlColName);
                                    }
                                }

                                for (var i = 0; i < data.data.length; i++) {
                                    var obj = data.data[i];
                                    var func = 'ExceptFund(2,"' + obj[0] + '");';
                                    var updateGiftcode = "<a class='btn btn-xs red btn-circle btn-outline' onclick='" + func + "' >Trừ quỹ game</a>";
                                    var funcJackpot = 'Jackpot(1,"' + obj[0] + '");';
                                    var Jackpot = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='" + funcJackpot + "' >Đập hũ (Bot) </a>";
                                    var funcJackpotUser = 'JackpotUser(1,"' + obj[0] + '");';
                                    var JackpotUser = "<a class='btn btn-xs green btn-circle btn-outline' onclick='" + funcJackpotUser + "' >Đập hũ (User) </a>";
                                    $('#tbl_datatable2 tbody').append("<tr>" +
                                        "<td>" + obj[0] + "</td>" +
                                        "<td>" + obj[1] + "</td>" +
                                        "<td>" + obj[2] + "</td>" +
                                        "<td>" + obj[3] + "</td>" +
                                        "<td>" + updateGiftcode + Jackpot + JackpotUser + "</td>" +
                                        "</tr>");
                                }

                                var colHiden = [];
                                oTable2 = table.dataTable({
                                    //"data": data.data,
                                    "lengthMenu": [
                                        [50, 100, 500, -1],
                                        [50, 100, 500, "All"]
                                    ],
                                    "pageLength": _pageSize,
                                    "language": {
                                        "lengthMenu": " _MENU_ records"
                                    },
                                    "columnDefs": [{
                                        'orderable': true,
                                        'targets': colHiden
                                    }, {
                                        "searchable": true,
                                        "targets": [0]
                                    }],
                                    "order": [
                                        [0, "asc"]
                                    ]
                                });

                                if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                                    var bVis = oTable2.fnSettings().aoColumns[4].bVisible;
                                    oTable2.fnSetColumnVis(4, bVis ? false : true);
                                }

                            }
                            else {
                                bootbox.alert({
                                    message: data.msg,
                                    callback: function () {
                                    }
                                });
                            }
                        },
                        complete: function () {
                            //$(".divLoading").fadeOut(500);
                        }
                    });
                }
            },
                Slot2Table = function () {
                    var table = $('#tbl_datatable3');
                    loadTable();
                    function loadTable() {
                        //$('.divLoading').fadeIn();
                        var param = [];
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 82,
                                p: JSON.stringify(param)
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 5005) {
                                    window.location.assign("login.aspx");
                                    return;
                                }
                                if (data.status == 0) {
                                    if (oTable3 != null) {
                                        oTable3.fnDestroy();
                                        $('#tbl_datatable3 tbody').html('');
                                    }
                                    _dataColumn3 = data.columnName;
                                    if (colFilter3 == null) {
                                        $('#tbl_datatable3 thead tr').html("");
                                        colFilter3 = _dataColumn3;
                                        var strHtmlColName = "";
                                        $.each(_dataColumn3, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable3 thead tr').append(strHtmlColName);
                                        if (data.data.length > 20) {
                                            $('#tbl_datatable3 tfoot tr').append(strHtmlColName);
                                        }
                                    } else {
                                        $('#tbl_datatable3 tfoot tr').empty();
                                        if (data.data.length > 20) {
                                            var strHtmlColName = "";
                                            $.each(_dataColumn3, function (key, obj) {
                                                strHtmlColName += "<td>" + obj + "</td>";
                                            });
                                            $('#tbl_datatable3 tfoot tr').append(strHtmlColName);
                                        }
                                    }

                                    for (var i = 0; i < data.data.length; i++) {
                                        var obj = data.data[i];
                                        var func = 'ExceptFund(3,"' + obj[0] + '");';
                                        var updateGiftcode = "<a class='btn btn-xs red btn-circle btn-outline' onclick='" + func + "' >Trừ quỹ game</a>";
                                        var funcJackpot = 'Jackpot(2,"' + obj[0] + '");';
                                        var Jackpot = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='" + funcJackpot + "' >Đập hũ (Bot) </a>";
                                        var funcJackpotUser = 'JackpotUser(2,"' + obj[0] + '");';
                                        var JackpotUser = "<a class='btn btn-xs green btn-circle btn-outline' onclick='" + funcJackpotUser + "' >Đập hũ (User) </a>";
                                        $('#tbl_datatable3 tbody').append("<tr>" +
                                            "<td>" + obj[0] + "</td>" +
                                            "<td>" + obj[1] + "</td>" +
                                            "<td>" + obj[2] + "</td>" +
                                            "<td>" + obj[3] + "</td>" +
                                            "<td>" + updateGiftcode + Jackpot + JackpotUser + "</td>" +
                                            "</tr>");
                                    }

                                    var colHiden = [];
                                    oTable3 = table.dataTable({
                                        //"data": data.data,
                                        "lengthMenu": [
                                            [50, 100, 500, -1],
                                            [50, 100, 500, "All"]
                                        ],
                                        "pageLength": _pageSize,
                                        "language": {
                                            "lengthMenu": " _MENU_ records"
                                        },
                                        "columnDefs": [{
                                            'orderable': true,
                                            'targets': colHiden
                                        }, {
                                            "searchable": true,
                                            "targets": [0]
                                        }],
                                        "order": [
                                            [0, "asc"]
                                        ]
                                    });

                                    if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                                        var bVis = oTable3.fnSettings().aoColumns[4].bVisible;
                                        oTable3.fnSetColumnVis(4, bVis ? false : true);
                                    }

                                }
                                else {
                                    bootbox.alert({
                                        message: data.msg,
                                        callback: function () {
                                        }
                                    });
                                }
                            },
                            complete: function () {
                                //$(".divLoading").fadeOut(500);
                            }
                        });
                    }
                },
                Slot3Table = function () {
                    var table = $('#tbl_datatable4');
                    loadTable();
                    function loadTable() {
                        //$('.divLoading').fadeIn();
                        var param = [];
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 83,
                                p: JSON.stringify(param)
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 5005) {
                                    window.location.assign("login.aspx");
                                    return;
                                }
                                if (data.status == 0) {
                                    if (oTable4 != null) {
                                        oTable4.fnDestroy();
                                        $('#tbl_datatable4 tbody').html('');
                                    }
                                    _dataColumn4 = data.columnName;
                                    if (colFilter4 == null) {
                                        $('#tbl_datatable4 thead tr').html("");
                                        colFilter4 = _dataColumn4;
                                        var strHtmlColName = "";
                                        $.each(_dataColumn4, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable4 thead tr').append(strHtmlColName);
                                        if (data.data.length > 20) {
                                            $('#tbl_datatable4 tfoot tr').append(strHtmlColName);
                                        }
                                    } else {
                                        $('#tbl_datatable4 tfoot tr').empty();
                                        if (data.data.length > 20) {
                                            var strHtmlColName = "";
                                            $.each(_dataColumn4, function (key, obj) {
                                                strHtmlColName += "<td>" + obj + "</td>";
                                            });
                                            $('#tbl_datatable4 tfoot tr').append(strHtmlColName);
                                        }
                                    }


                                    for (var i = 0; i < data.data.length; i++) {
                                        var obj = data.data[i];
                                        var func = 'ExceptFund(4,"' + obj[0] + '");';
                                        var updateGiftcode = "<a class='btn btn-xs red btn-circle btn-outline' onclick='" + func + "' >Trừ quỹ game</a>";
                                        var funcJackpot = 'Jackpot(8,"' + obj[0] + '");';
                                        var Jackpot = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='" + funcJackpot + "' >Đập hũ (Bot)</a>";
                                        var funcJackpotUser = 'JackpotUser(8,"' + obj[0] + '");';
                                        var JackpotUser = "<a class='btn btn-xs green btn-circle btn-outline' onclick='" + funcJackpotUser + "' >Đập hũ (User) </a>";
                                        $('#tbl_datatable4 tbody').append("<tr>" +
                                            "<td>" + obj[0] + "</td>" +
                                            "<td>" + obj[1] + "</td>" +
                                            "<td>" + obj[2] + "</td>" +
                                            "<td>" + obj[3] + "</td>" +
                                            "<td>" + updateGiftcode + Jackpot + JackpotUser +"</td>" +
                                            "</tr>");
                                    }

                                    var colHiden = [];
                                    oTable4 = table.dataTable({
                                        //"data": data.data,
                                        "lengthMenu": [
                                            [50, 100, 500, -1],
                                            [50, 100, 500, "All"]
                                        ],
                                        "pageLength": _pageSize,
                                        "language": {
                                            "lengthMenu": " _MENU_ records"
                                        },
                                        "columnDefs": [{
                                            'orderable': true,
                                            'targets': colHiden
                                        }, {
                                            "searchable": true,
                                            "targets": [0]
                                        }],
                                        "order": [
                                            [0, "asc"]
                                        ]
                                    });

                                    if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                                        var bVis = oTable4.fnSettings().aoColumns[4].bVisible;
                                        oTable4.fnSetColumnVis(4, bVis ? false : true);
                                    }

                                }
                                else {
                                    bootbox.alert({
                                        message: data.msg,
                                        callback: function () {
                                        }
                                    });
                                }
                            },
                            complete: function () {
                                //$(".divLoading").fadeOut(500);
                            }
                        });
                    }
                },
                ThanQuayTable = function () {
                    var table = $('#tbl_datatable5');
                    loadTable();
                    function loadTable() {
                        //$('.divLoading').fadeIn();
                        var param = [];
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 84,
                                p: JSON.stringify(param)
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 5005) {
                                    window.location.assign("login.aspx");
                                    return;
                                }
                                if (data.status == 0) {
                                    if (oTable5 != null) {
                                        oTable5.fnDestroy();
                                        $('#tbl_datatable5 tbody').html('');
                                    }
                                    _dataColumn5 = data.columnName;
                                    if (colFilter5 == null) {
                                        $('#tbl_datatable5 thead tr').html("");
                                        colFilter5 = _dataColumn5;
                                        var strHtmlColName = "";
                                        $.each(_dataColumn5, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable5 thead tr').append(strHtmlColName);
                                        if (data.data.length > 20) {
                                            $('#tbl_datatable5 tfoot tr').append(strHtmlColName);
                                        }
                                    } else {
                                        $('#tbl_datatable5 tfoot tr').empty();
                                        if (data.data.length > 20) {
                                            var strHtmlColName = "";
                                            $.each(_dataColumn5, function (key, obj) {
                                                strHtmlColName += "<td>" + obj + "</td>";
                                            });
                                            $('#tbl_datatable5 tfoot tr').append(strHtmlColName);
                                        }
                                    }

                                    for (var i = 0; i < data.data.length; i++) {
                                        var obj = data.data[i];
                                        var func = 'ExceptFund(5,"' + obj[0] + '");';
                                        var updateGiftcode = "<a class='btn btn-xs red btn-circle btn-outline' onclick='" + func + "' >Trừ quỹ game</a>";
                                        var funcJackpot = 'Jackpot(4,"' + obj[0] + '");';
                                        var Jackpot = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='" + funcJackpot + "' >Đập hũ (Bot)</a>";
                                        var funcJackpotUser = 'JackpotUser(4,"' + obj[0] + '");';
                                        var JackpotUser = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='" + funcJackpotUser + "' >Đập hũ (User) </a>";
                                        $('#tbl_datatable5 tbody').append("<tr>" +
                                            "<td>" + obj[0] + "</td>" +
                                            "<td>" + obj[1] + "</td>" +
                                            "<td>" + obj[2] + "</td>" +
                                            "<td>" + obj[3] + "</td>" +
                                            "<td>" + updateGiftcode + Jackpot + JackpotUser+ "</td>" +
                                            "</tr>");
                                    }

                                    var colHiden = [];
                                    oTable5 = table.dataTable({
                                        //"data": data.data,
                                        "lengthMenu": [
                                            [50, 100, 500, -1],
                                            [50, 100, 500, "All"]
                                        ],
                                        "pageLength": _pageSize,
                                        "language": {
                                            "lengthMenu": " _MENU_ records"
                                        },
                                        "columnDefs": [{
                                            'orderable': true,
                                            'targets': colHiden
                                        }, {
                                            "searchable": true,
                                            "targets": [0]
                                        }],
                                        "order": [
                                            [0, "asc"]
                                        ]
                                    });

                                    if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                                        var bVis = oTable5.fnSettings().aoColumns[4].bVisible;
                                        oTable5.fnSetColumnVis(4, bVis ? false : true);
                                    }

                                }
                                else {
                                    bootbox.alert({
                                        message: data.msg,
                                        callback: function () {
                                        }
                                    });
                                }
                            },
                            complete: function () {
                                //$(".divLoading").fadeOut(500);
                            }
                        });
                    }
                },
                HiloTable = function () {
                    var table = $('#tbl_datatable6');
                    loadTable();
                    function loadTable() {
                        //$('.divLoading').fadeIn();
                        var param = [];
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 85,
                                p: JSON.stringify(param)
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 5005) {
                                    window.location.assign("login.aspx");
                                    return;
                                }
                                if (data.status == 0) {
                                    if (oTable6 != null) {
                                        oTable6.fnDestroy();
                                        $('#tbl_datatable6 tbody').html('');
                                    }
                                    _dataColumn6 = data.columnName;
                                    if (colFilter6 == null) {
                                        $('#tbl_datatable6 thead tr').html("");
                                        colFilter6 = _dataColumn6;
                                        var strHtmlColName = "";
                                        $.each(_dataColumn6, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable6 thead tr').append(strHtmlColName);
                                        if (data.data.length > 20) {
                                            $('#tbl_datatable6 tfoot tr').append(strHtmlColName);
                                        }
                                    } else {
                                        $('#tbl_datatable6 tfoot tr').empty();
                                        if (data.data.length > 20) {
                                            var strHtmlColName = "";
                                            $.each(_dataColumn6, function (key, obj) {
                                                strHtmlColName += "<td>" + obj + "</td>";
                                            });
                                            $('#tbl_datatable6 tfoot tr').append(strHtmlColName);
                                        }
                                    }

                                    for (var i = 0; i < data.data.length; i++) {
                                        var obj = data.data[i];
                                        var func = 'ExceptFund(6,"' + obj[0] + '");';
                                        var updateGiftcode = "<a class='btn btn-xs red btn-circle btn-outline' onclick='" + func + "' >Trừ quỹ game</a>";

                                        $('#tbl_datatable6 tbody').append("<tr>" +
                                            "<td>" + obj[0] + "</td>" +
                                            "<td>" + obj[1] + "</td>" +
                                            "<td>" + obj[2] + "</td>" +
                                            "<td>" + obj[3] + "</td>" +
                                            "<td>" + obj[4] + "</td>" +
                                            "<td>" + updateGiftcode + "</td>" +
                                            "</tr>");
                                    }

                                    var colHiden = [];
                                    oTable6 = table.dataTable({
                                        //"data": data.data,
                                        "lengthMenu": [
                                            [50, 100, 500, -1],
                                            [50, 100, 500, "All"]
                                        ],
                                        "pageLength": _pageSize,
                                        "language": {
                                            "lengthMenu": " _MENU_ records"
                                        },
                                        "columnDefs": [{
                                            'orderable': true,
                                            'targets': colHiden
                                        }, {
                                            "searchable": true,
                                            "targets": [0]
                                        }],
                                        "order": [
                                            [0, "asc"]
                                        ]
                                    });

                                    if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                                        var bVis = oTable6.fnSettings().aoColumns[5].bVisible;
                                        oTable6.fnSetColumnVis(5, bVis ? false : true);
                                    }

                                }
                                else {
                                    bootbox.alert({
                                        message: data.msg,
                                        callback: function () {
                                        }
                                    });
                                }
                            },
                            complete: function () {
                                //$(".divLoading").fadeOut(500);
                            }
                        });
                    }
                },
                DiskSharkingTable = function () {
                    var table = $('#tbl_datatable7');
                    loadTable();
                    function loadTable() {
                        //$('.divLoading').fadeIn();
                        var param = [];
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 86,
                                p: JSON.stringify(param)
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 5005) {
                                    window.location.assign("login.aspx");
                                    return;
                                }
                                if (data.status == 0) {
                                    if (oTable7 != null) {
                                        oTable7.fnDestroy();
                                    }
                                    _dataColumn7 = data.columnName;
                                    if (colFilter7 == null) {
                                        $('#tbl_datatable7 thead tr').html("");
                                        colFilter7 = _dataColumn7;
                                        var strHtmlColName = "";
                                        $.each(_dataColumn7, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable7 thead tr').append(strHtmlColName);
                                        if (data.data.length > 20) {
                                            $('#tbl_datatable7 tfoot tr').append(strHtmlColName);
                                        }
                                    } else {
                                        $('#tbl_datatable7 tfoot tr').empty();
                                        if (data.data.length > 20) {
                                            var strHtmlColName = "";
                                            $.each(_dataColumn7, function (key, obj) {
                                                strHtmlColName += "<td>" + obj + "</td>";
                                            });
                                            $('#tbl_datatable7 tfoot tr').append(strHtmlColName);
                                        }
                                    }


                                    var colHiden = [];
                                    oTable7 = table.dataTable({
                                        "data": data.data,
                                        "lengthMenu": [
                                            [50, 100, 500, -1],
                                            [50, 100, 500, "All"]
                                        ],
                                        "pageLength": _pageSize,
                                        "language": {
                                            "lengthMenu": " _MENU_ records"
                                        },
                                        "columnDefs": [{
                                            'orderable': true,
                                            'targets': colHiden
                                        }, {
                                            "searchable": true,
                                            "targets": [0]
                                        }],
                                        "order": [
                                            [0, "asc"]
                                        ]
                                    });

                                    var bVis = oTable7.fnSettings().aoColumns[1].bVisible;
                                    oTable7.fnSetColumnVis(1, bVis ? false : true);

                                }
                                else {
                                    bootbox.alert({
                                        message: data.msg,
                                        callback: function () {
                                        }
                                    });
                                }
                            },
                            complete: function () {
                                //$(".divLoading").fadeOut(500);
                            }
                        });
                    }
                },
                HooHeyHowTable = function () {
                    var table = $('#tbl_datatable8');
                    loadTable();
                    function loadTable() {
                        //$('.divLoading').fadeIn();
                        var param = [];
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 87,
                                p: JSON.stringify(param)
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 5005) {
                                    window.location.assign("login.aspx");
                                    return;
                                }
                                if (data.status == 0) {
                                    if (oTable8 != null) {
                                        oTable8.fnDestroy();
                                    }
                                    _dataColumn8 = data.columnName;
                                    if (colFilter8 == null) {
                                        $('#tbl_datatable8 thead tr').html("");
                                        colFilter8 = _dataColumn8;
                                        var strHtmlColName = "";
                                        $.each(_dataColumn8, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable8 thead tr').append(strHtmlColName);
                                        if (data.data.length > 20) {
                                            $('#tbl_datatable8 tfoot tr').append(strHtmlColName);
                                        }
                                    } else {
                                        $('#tbl_datatable8 tfoot tr').empty();
                                        if (data.data.length > 20) {
                                            var strHtmlColName = "";
                                            $.each(_dataColumn8, function (key, obj) {
                                                strHtmlColName += "<td>" + obj + "</td>";
                                            });
                                            $('#tbl_datatable8 tfoot tr').append(strHtmlColName);
                                        }
                                    }


                                    var colHiden = [];
                                    oTable8 = table.dataTable({
                                        "data": data.data,
                                        "lengthMenu": [
                                            [50, 100, 500, -1],
                                            [50, 100, 500, "All"]
                                        ],
                                        "pageLength": _pageSize,
                                        "language": {
                                            "lengthMenu": " _MENU_ records"
                                        },
                                        "columnDefs": [{
                                            'orderable': true,
                                            'targets': colHiden
                                        }, {
                                            "searchable": true,
                                            "targets": [0]
                                        }],
                                        "order": [
                                            [0, "asc"]
                                        ]
                                    });

                                    var bVis = oTable8.fnSettings().aoColumns[1].bVisible;
                                    oTable8.fnSetColumnVis(1, bVis ? false : true);

                                }
                                else {
                                    bootbox.alert({
                                        message: data.msg,
                                        callback: function () {
                                        }
                                    });
                                }
                            },
                            complete: function () {
                                //$(".divLoading").fadeOut(500);
                            }
                        });
                    }
                }
            return {
                //main function to initiate the module
                init: function () {
                    MinipokerTable();
                    Slot1Table();
                    Slot2Table();
                    Slot3Table();
                    ThanQuayTable();
                    HiloTable();
                    DiskSharkingTable();
                    HooHeyHowTable();
                },
                reloadTable: function () {
                    MinipokerTable();
                    Slot1Table();
                    Slot2Table();
                    Slot3Table();
                    ThanQuayTable();
                    HiloTable();
                    DiskSharkingTable();
                    HooHeyHowTable();
                }
            };
        }();

        function ExceptFund(type, roomId) {
            bootbox.prompt({
                size: "small",
                title: "Nhập số tiền trừ quỹ?",
                callback: function (result) {
                    if (result !== null) {
                        var json = {
                            "GameID": type,
                            "RoomID": roomId,
                            "Value": result
                        }
                        POST_DATA("Apis/API_GameAccount.ashx", {
                            type: 11,
                            json: JSON.stringify(json)
                        }, function (res) {
                            //if (res.status == 1) {
                                
                            //}
                            //else {

                            //}

                            bootbox.alert({
                                title: "Thông báo",
                                message: res.msg,
                                callback: function () {
                                    TableEditable.init();
                                }
                            })

                        });
                    }
                }
            });
        }

        function JackpotUser(type, roomId) {
            $('#ID_Game').val(type);
            $('#ID_Room').val(roomId);
            $('#modal_jackpot_user').modal('show');
        }
        function SubMitJackpotUser() {
            
            var json = {
                "GameId": $('#ID_Game').val(),
                "RoomId": $('#ID_Room').val(),
                "AccountName": $("#txtAccountID").val().split('-')[1],
                "AccountID": $("#txtAccountID").val().split('-')[0]
            }
            POST_DATA("Apis/API_GameAccount.ashx", {
                type: 17,
                json: JSON.stringify(json)
            }, function (res) {
                if (res.status == 1) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {
                            TableEditable.init();
                            $('#txtAccountID').val('');
                            $('#modal_jackpot_user').modal('hide');
                        }
                    })
                }
                else {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {

                        }
                    })
                }

                

            });
        }

        function Jackpot(type, roomId) {
            //@_GameId = 1 -- Nong trai
            //@_GameId = 2 -- Mafia
            //@_GameId = 3 --minipoker
            //@_GameId = 4 -- vua bao
            //@_GameId = 6 --than quat
            //@_GameId = 8 -- hai vuong
            bootbox.prompt({
                size: "small",
                title: "Nhập tên bot trúng thưởng?",
                callback: function (result) {
                    if (result !== null) {
                        var json = {
                            "GameId": type,
                            "RoomId": roomId,
                            "AccountName": result,
                            "AccountID": 0
                        }
                        POST_DATA("Apis/API_GameAccount.ashx", {
                            type: 17,
                            json: JSON.stringify(json)
                        }, function (res) {
                            //if (res.status == 1) {

                            //}
                            //else {

                            //}

                            bootbox.alert({
                                title: "Thông báo",
                                message: res.msg,
                                callback: function () {
                                    TableEditable.init();
                                }
                            })

                        });
                    }
                }
            });
            //bootbox.confirm("Xác nhận đập hủ?", function (result) {
            //    if (result) {
            //        $('.divLoading').fadeIn();
            //        var json = {
            //            "GameId": type,
            //            "RoomId": roomId
            //        }
            //        $.ajax({
            //            type: "POST",
            //            url: "Apis/API_GameAccount.ashx",
            //            data: {
            //                json: JSON.stringify(json),
            //                type: 17
            //            },
            //            dataType: 'json',
            //            success: function (data) {
            //                $(".divLoading").fadeOut(500);
            //                if (data.status == 1)
            //                    TableEditable.init();
            //                else
            //                    bootbox.alert(data.msg);
            //            }
            //        });
            //    }
            //});
        }

        function formatMoney(num) {
            if (num > 0)
                return num.toLocaleString('en-US');
            else
                return num;
        }

</script>
</asp:Content>
