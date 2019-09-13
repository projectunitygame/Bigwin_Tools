<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_GameDT_ThongBao.aspx.cs" Inherits="CMS_Tools.Test_ThongBao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
        .fa.fa-check{
            z-index:0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBar" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        Danh sách thông báo
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                        <a href="javascript:;" class="reload" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
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
                    <div id="sample_1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable"
                            aria-describedby="sample_1_info">
                            <thead>
                                <tr role="row">
                                </tr>
                            </thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                        	<tfoot><tr role="row"></tr></tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-----From create notification------>
    <div id="modal_create_noti" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_Create_Notification" class="form-horizontal" novalidate="novalidate">
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title" id="title_task">
                                <i class="fa fa-edit"></i> QUẢN LÝ THÔNG BÁO GAME</h4>
                        </div>
                        <div class="form-body">
                            <div class="alert alert-danger display-hide">
                                <button class="close" data-close="alert"></button>
                                Vui lòng kiểm tra và nhập đầy đủ thông tin!
                            </div>
                            <div class="alert alert-success display-hide">
                                <button class="close" data-close="alert"></button>
                                Nhập thông tin hợp lệ
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-4">
                                            Chọn ngày: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class='input-group date' id='datetimepicker1'> 
                                                <input type='text' id="txtDateSend" name="DateSend" class="form-control" style="pointer-events: none;background-color: #eef1f5;cursor: not-allowed;" /> 
                                                <span class="input-group-addon"> 
                                                    <span class="glyphicon glyphicon-calendar">
                                                    </span> 
                                                </span> 
                                            </div> 
                                        </div>
                                    </div>
                                </div>
                            </div>
                           <!-- <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Title:
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtTitle" type="text" class="form-control" name="Title"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>-->
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           Nội dung thông báo: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtMessage" type="text" class="form-control" name="Message"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Lặp lại thông báo:
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select id="selectLoop" class="form-control">
                                                    <option value="">Chỉ 1 Lần</option>
                                                    <option value="MINUTE">Mỗi phút</option>
                                                    <option value="DAY">Hàng Ngày</option>
                                                    <option value="WEEK">Hàng Tuần</option>
                                                    <option value="MONTH">Hàng Tháng</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Trạng thái thông báo:
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select id="selectStatus" class="form-control">
                                                    <option value="0">Mở</option>
                                                    <option value="1">Tắt</option>
                                                </select>
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

    <!-----From update notification------>
    <div id="modal_update_noti" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_Update_Notification" class="form-horizontal" novalidate="novalidate">
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title">
                                <i class="fa fa-edit"></i> CẬP NHẬT THÔNG BÁO GAME</h4>
                        </div>
                        <div class="form-body">
                            <div class="alert alert-danger-2 display-hide">
                                <button class="close" data-close="alert"></button>
                                Vui lòng kiểm tra và nhập đầy đủ thông tin!
                            </div>
                            <div class="alert alert-success-2 display-hide">
                                <button class="close" data-close="alert"></button>
                                Nhập thông tin hợp lệ
                            </div>
                            <input type="hidden" id="txtID_Update" />
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-4">
                                            Chọn ngày: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class='input-group date' id='datetimepicker2'> 
                                                <input type='text' id="txtDateSend2" name="DateSend" class="form-control" style="pointer-events: none;background-color: #eef1f5;cursor: not-allowed;" /> 
                                                <span class="input-group-addon"> 
                                                    <span class="glyphicon glyphicon-calendar">
                                                    </span> 
                                                </span> 
                                            </div> 
                                        </div>
                                    </div>
                                </div>
                            </div>
                           <!-- <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Title:
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtTitle2" type="text" class="form-control" name="Title"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>-->
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           Nội dung thông báo: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtMessage2" type="text" class="form-control" name="Message"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Lặp lại thông báo:
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select id="selectLoop2" class="form-control">
                                                    <option value="">Chỉ 1 Lần</option>
                                                    <option value="MINUTE">Mỗi phút</option>
                                                    <option value="DAY">Hàng Ngày</option>
                                                    <option value="WEEK">Hàng Tuần</option>
                                                    <option value="MONTH">Hàng Tháng</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Trạng thái thông báo:
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select id="selectStatus2" class="form-control">
                                                    <option value="0">Mở</option>
                                                    <option value="1">Tắt</option>
                                                </select>
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
    <script src="assets/global/plugins/Datetime/moment.min.js"></script>     
    <script src="assets/global/plugins/Datetime/moment-with-locales.min.js"></script>
    <script src="assets/global/plugins/Datetime/bootstrap-datetimepicker.js"></script>
    <script src="assets/global/plugins/Base64JS.js"></script>
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({
                locale: 'vi',
                format: 'YYYY-MM-DD HH:mm:ss',
            });
            $('#datetimepicker2').datetimepicker({
                locale: 'vi',
                format: 'YYYY-MM-DD HH:mm:ss',
            });
        });
        var colFilter = null;
        jQuery(document).ready(function () {
            if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                $('.page-toolbar').remove();
            }

            FormValidation.init();
            FormValidation2.init();

            $('#btnAddNew').html("<i class='fa fa-plus'></  i> Tạo Thông báo mới");

            $('#btnAddNew').click(function () {
                //ResetForm();
                $('#modal_create_noti').modal('show');
            });

            $('#txtFindData').on('keyup', function (e) {
                if (e.keyCode == 13) {
                    TableEditable.init();
                }
            });

            $('#btnFindData').click(function () {
                if ($('#txtFindData').val() != "")
                    TableEditable.init();
            });

            $('#filterColumn').on('change', function () {
                if ($('#txtFindData').val() != "")
                    TableEditable.init();
            });

            //load danh sach dai ly
            TableEditable.init();
            $('body').on('click', '.portlet > .portlet-title > .tools > a.reload', function (e) {
                TableEditable.init();
            });
        });

        var oTable = null;
        var _pageSize = 50;
        var _dataColumn = null;
        var TableEditable = function () {
            var handleTable = function () {
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
                            mid: AppManage.getURLParameter('m'),
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

                                if (_dataColumn == null) {
                                    _dataColumn = data.columnName;
                                    var selectCol = "<option value=''>Select...</option>";
                                    $('#tbl_datatable thead tr').html("");
                                    //$.each(_dataColumn, function (key, obj) {
                                    //    $('#tbl_datatable thead tr').append("<th>" + obj + "</th>");
                                    //	if (key < _dataColumn.length - 1)
                                    //		selectCol += "<option value='" + obj + "'>" + obj + "</option>";
                                    //});
                                    var strHtmlColName = "";
                                    $.each(_dataColumn, function (key, obj) {
                                        strHtmlColName += "<td>" + obj + "</td>";
                                        if (key < _dataColumn.length - 1)
                                            selectCol += "<option value='" + obj + "'>" + obj + "</option>";
                                    });
                                    $('#tbl_datatable thead tr').append(strHtmlColName);
                                    console.log(data.data.length);
                                    if (data.data.length > 20) {
                                        $('#tbl_datatable tfoot tr').append(strHtmlColName);
                                    }
                                    $('#filterColumn').html(selectCol);
                                    if ($('#filterColumn').val() == "")
                                        $('#filterColumn').val("AccountID");
                                }
                                else {
                                    $('#tbl_datatable tfoot tr').empty();
                                    if (data.data.length > 20) {
                                        var strHtmlColName = "";
                                        $.each(_dataColumn, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable tfoot tr').append(strHtmlColName);
                                    }
                                }
                                _dataTable = [];
                                for (var i = 0; i < data.data.length; i++) {
                                    var obj = data.data[i];
                                    var func = 'SetUpdateNotification(' + obj[0] + ',"' + obj[2] + '","' + obj[4] + '","' + obj[7] + '","' + obj[5] + '");';
                                    var updateNoti = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='" + func + "'> Chỉnh sửa</a>";
                                    var deleteNoti = "<a class='btn btn-xs red btn-circle btn-outline' onclick='DeleteNotification(\"" + obj[0] + "\");'> Xóa</a>";
                                    var loop = "";
                                    switch (obj[7]) {
                                        case "":
                                            loop = "Chỉ một lần"
                                            break;
                                        case "MINUTE":
                                            loop = "Mỗi phút"
                                            break;
                                        case "DAY":
                                            loop = "Hàng ngày"
                                            break;
                                        case "WEEK":
                                            loop = "Hàng Tuần"
                                            break;
                                        case "MONTH":
                                            loop = "Hàng Tháng"
                                            break;
                                        default:
                                            break;
                                    }
                                    var stt = "";
                                    switch (obj[5]) {
                                        case "0":
                                            stt = "Mở";
                                            break;
                                        case "1":
                                            stt = "Tắt";
                                            break;
                                        default:
                                            break;
                                    }

                                    $('#tbl_datatable tbody').append("<tr>" +
                                        "<td>" + obj[0] + "</td>" +
                                        "<td>" + obj[1] + "</td>" +
                                        "<td>" + obj[2] + "</td>" +
                                        "<td>" + obj[3] + "</td>" +
                                        "<td>" + obj[4] + "</td>" +
                                        "<td>" + stt + "</td>" +
                                        "<td>" + obj[6] + "</td>" +
                                        "<td>" + loop + "</td>" +
                                        "<td>" + updateNoti + deleteNoti + "</td>" +
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
                                        [0, "desc"]
                                    ]
                                });

                                var bVis = oTable.fnSettings().aoColumns[1].bVisible;
                                oTable.fnSetColumnVis(1, bVis ? false : true);
                                var bVis = oTable.fnSettings().aoColumns[3].bVisible;
                                oTable.fnSetColumnVis(3, bVis ? false : true);
                                var bVis = oTable.fnSettings().aoColumns[6].bVisible;
                                oTable.fnSetColumnVis(6, bVis ? false : true);
                                if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                                    var bVis = oTable.fnSettings().aoColumns[8].bVisible;
                                    oTable.fnSetColumnVis(8, bVis ? false : true);
                                }
                                var tableWrapper = $("#tbl_datatable_wrapper");
                                jQuery('#tbl_datatable_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
                                jQuery('#tbl_datatable_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
                                jQuery('#tbl_datatable_wrapper .dataTables_length select').select2(); // initialize select2 dropdown

                                tableWrapper.find(".dataTables_length select").select2({
                                    showSearchInput: false
                                });
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
                            $(".divLoading").fadeOut(500);
                        }
                    });
                }
            }

            return {
                //main function to initiate the module
                init: function () {
                    handleTable();
                },
                reloadTable: function () {
                    handleTable();
                }
            };
        }();

        function generate() {
            $('#txtPassword').val(randomPassword(8));
        }

        function formatMoney(num) {
            if (num > 0)
                return num.toLocaleString('en-US');
            else
                return num;
        }
        function escapeRegExp(str) {
            return str.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
        }

        function replaceAll(str, find, replace) {
            return str.replace(new RegExp(escapeRegExp(find), 'g'), replace);
        }
        function SetUpdateNotification(ID, Message, DateSend, Loop, Status) {
            $('#txtID_Update').val(ID);
            $('#txtMessage2').val(Message);
            $('#txtDateSend2').val(DateSend);
            $('#selectLoop2').val(Loop);
            $('#selectStatus2').val(Status);
            $('#modal_update_noti').modal('show');
        }
        function UpdateNotification(ID) {
            var json = {
                "Id": $('#txtID_Update').val(),
                "DateSend": $('#txtDateSend2').val(),
                "Message": $('#txtMessage2').val(),
                "Loop": $('#selectLoop2').val(),
                "Status": $('#selectStatus2').val()
            }
            POST_DATA("Apis/API_GameAccount.ashx", {
                type: 6,
                json: JSON.stringify(json)
            }, function (res) {
                if (res.status == 1) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {
                            $('#modal_update_noti').modal('hide');
                            TableEditable.init();
                        }
                    })
                }
                else {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {
                            TableEditable.init();
                        }
                    })
                }

                $(".divLoading").fadeOut(500);

            });
        }
        function DeleteNotification(ID) {
            bootbox.confirm("Xác nhận xóa thông báo game?", function (result) {
                if (result) {
                    $('.divLoading').fadeIn();
                    var json = {
                        "Id": ID
                    };
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_GameAccount.ashx",
                        data: {
                            json: JSON.stringify(json),
                            type: 7
                        },
                        dataType: 'json',
                        success: function (data) {
                            $(".divLoading").fadeOut(500);
                            if (data.status == 1)
                                TableEditable.init();
                            else
                                bootbox.alert(data.msg);
                        }
                    });
                }
            });
        }

        function CreateNotification() {
            var json = {
                "DateSend": $('#txtDateSend').val(),
                "Message": $('#txtMessage').val(),
                "Loop": $('#selectLoop').val(),
                "Status": $('#selectStatus').val()
            }
            POST_DATA("Apis/API_GameAccount.ashx", {
                type: 5,
                json: JSON.stringify(json)
            }, function (res) {
                if (res.status == 1) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {
                            $('#modal_create_noti').modal('hide');
                            TableEditable.init();
                        }
                    })
                }
                else {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {
                            TableEditable.init();
                        }
                    })
                }

                $(".divLoading").fadeOut(500);

            });
        }

        var FormValidation = function () {
            var r = function () {
                var e = $("#form_Create_Notification"),
                    r = $(".alert-danger", e),
                    i = $(".alert-success", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        DateSend: {
                            required: !0
                        },
                        Message: {
                            maxlength: 500,
                            required: !0
                        }
                        //email: {
                        //    maxlength: 80,
                        //},
                        //Phone: {
                        //    maxlength: 10,
                        //    minlength: 10,
                        //    number: !0,
                        //    required: !0
                        //},
                        //AgencyName: {
                        //    minlength: 6,
                        //    maxlength: 150,
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
                            CreateNotification();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();
        var FormValidation2 = function () {
            var r = function () {
                var e = $("#form_Update_Notification"),
                    r = $(".alert-danger2", e),
                    i = $(".alert-success2", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        DateSend: {
                            required: !0
                        },
                        Message: {
                            maxlength: 500,
                            required: !0
                        }
                        //email: {
                        //    maxlength: 80,
                        //},
                        //Phone: {
                        //    maxlength: 10,
                        //    minlength: 10,
                        //    number: !0,
                        //    required: !0
                        //},
                        //AgencyName: {
                        //    minlength: 6,
                        //    maxlength: 150,
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
                            UpdateNotification();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();
</script>
</asp:Content>