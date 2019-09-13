<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_GameDT_GiftcodeEvent.aspx.cs" Inherits="CMS_Tools.Test_GiftcodeEvent" %>
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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBar" runat="server">
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="icon-home"></i>
                <a href="Home.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <span><label id="PageBar_lblMenuName">Tài khoản đại lý</label></span>
            </li>
        </ul>
        <div class="page-toolbar">
            <div class="btn-group pull-right">
                <button id="btnAddAction" type="button" class="btn btn-fit-height blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" aria-expanded="false">
                    Chức năng <i class="fa fa-angle-down"></i>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li>
                        <a href="javascript:;" id="btnAddNew"><i class="fa fa-plus"><!--  i--> Tạo KH Mới</i></a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        Event Giftcode
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
                    <div class="row">
                        <div class="col-md-4" style="margin-bottom: 10px;">
                            <div class="input-group" id="dateRangeEvent">
                            	<label class="control-label label-balance">Chọn ngày kết xuất dữ liệu</label>
                                <input type="text" class="form-control" placeholder="Date Range(MM/DD/YYYY)" disabled />
                                <span class="input-group-btn" style='position: relative; top: 10px; left: 1px;'>
                                    <button class="btn default date-range-toggle" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-bottom: 10px;visibility:hidden">
                            <label class="control-label label-balance">Chọn lọc dữ liệu theo cột</label>
                            <select id="filterColumn" class="form-control">
                                <option value="Name">Tên Event</option>
                                <option value="EventID">Mã Event</option>
                                <option value="Total">Số lượng</option> 
                            </select>
                        </div>
                        <div class="col-md-3" style="margin-bottom: 10px;visibility:hidden">
                            <label class="control-label label-balance">Nhập từ khóa tìm kiếm</label>
                            <input type="text" class="form-control" id="txtFindData" placeholder="Search..." />
                        </div>
                        <div class="col-md-2" style="margin-bottom: 10px;">
                            <label class="control-label label-balance">Tìm kiếm</label>
                            <button id="btnFindData" type="button" class="btn green form-control"><i class="icon-magnifier"></i> Search</button>
                        </div>
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
    <!-----From create giftcode------>
    <div id="modal_Create_Giftcode" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_Create_Giftcode" class="form-horizontal" novalidate="novalidate">
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title">
                                <i class="fa fa-edit"></i> TẠO GIFTCODE MỚI</h4>
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
                                            Tên Event: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtName" type="text" class="form-control" name="Name" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-4">
                                            Tiền tố: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtPrefix" type="text" class="form-control" name="Prefix" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Giá trị: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" style="width:100%;" id="txtPrice" class="form-control" name="Price" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Số lượng: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" style="width:100%;" id="txtQty" class="form-control" name="Qty" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-4">
                                            Chọn ngày: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtExpired" name="Expired" class="form-control" value="" />
                                                <span class="control-label">Định dạng Tháng/Ngày/Năm</span>
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

    <!-----From update giftcode------>
    <div id="modal_Update_Giftcode" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_Update_Giftcode" class="form-horizontal" novalidate="novalidate">
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title">
                                <i class="fa fa-edit"></i> CẬP NHẬT NGÀY HẾT HẠN GIFTCODE</h4>
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
                            <input id="ID_Giftcode" type="hidden"/>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-4">
                                            Chọn ngày: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtExpired2" name="Expired" class="form-control" value="" />
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
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script type="text/javascript">
        var colFilter = null;
        $(function () {
            $('#txtExpired').daterangepicker({
                singleDatePicker: true,
                showDropdowns: true,
                format: 'MM/DD/YYYY',
                startDate: moment().subtract('day', 0).format('MM/DD/YYYY'),
                minDate: moment().subtract('day', 0).format('MM/DD/YYYY'),
                maxYear: parseInt(moment().format('YYYY'), 10)
            }, function (start, end, label) {
                //var years = moment().diff(start, 'years');
                //alert("You are " + years + " years old!");
                });
            $('#txtExpired2').daterangepicker({
                singleDatePicker: true,
                showDropdowns: true,
                format: 'MM/DD/YYYY',
                startDate: moment().subtract('day', 0).format('MM/DD/YYYY'),
                minDate: moment().subtract('day', 0).format('MM/DD/YYYY'),
                maxYear: parseInt(moment().format('YYYY'), 10)
            }, function (start, end, label) {
                //var years = moment().diff(start, 'years');
                //alert("You are " + years + " years old!");
            });
        });

        function ResetForm() {
            $('#form_Create_Giftcode').trigger('reset');
        }
        jQuery(document).ready(function () {
            if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                $('.page-toolbar').remove();
            }
            $('#btnAddNew').html("<i class='fa fa-plus'></  i> Tạo GiftCode Mới");
            FormValidation.init();
            FormValidation2.init();
            $('#btnAddNew').click(function () {
                ResetForm();
                $('#modal_Create_Giftcode').modal('show');
                $('#txtExpired').val(moment().subtract('day', 0).format('MM/DD/YYYY'))
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
            ComponentsPickers.init();
        });

        var _dateStart = null;
        var _dateEnd = null;
        var ComponentsPickers = function () {
            var handleDateRangePickers = function () {
                if (!jQuery().daterangepicker) {
                    return;
                }

                $('#dateRangeEvent').daterangepicker({
                    opens: (App.isRTL() ? 'left' : 'right'),
                    format: 'MM/DD/YYYY',
                    separator: ' to ',
                    startDate: moment().subtract('year', 2),
                    endDate: moment(),
                    minDate: moment().subtract('year', 5).format('MM/DD/YYYY'),
                    maxDate: moment().format('MM/DD/YYYY'),
                },
                    function (start, end) {
                        _dateStart = start.format('YYYY/MM/DD');
                        _dateEnd = end.format('YYYY/MM/DD');
                        console.log("Callback has been called!");
                        $('#dateRangeEvent input').val(start.format('MM/DD/YYYY') + ' - ' + end.format('MM/DD/YYYY'));
                        TableEditable.init();
                    }
                );
                _dateStart = moment().subtract('year', 2).format('YYYY/MM/DD');
                _dateEnd = moment().format('YYYY/MM/DD');
                $('#dateRangeEvent input').val(_dateStart + ' - ' + _dateEnd);
            };

            return {
                init: function () {
                    handleDateRangePickers();
                }
            };
        }();

        var oTable = null;
        var _pageSize = 50;
        var _dataColumn = null;
        var TableEditable = function () {
            var handleTable = function () {
                var table = $('#tbl_datatable');
                loadTable();
                function loadTable() {
                    $('.divLoading').fadeIn();
                    if (_dateStart == null)
                        _dateStart = moment().subtract('year', 2).format('YYYY/MM/DD');
                    if (_dateEnd == null)
                        _dateEnd = moment().format('YYYY/MM/DD');
                    var param = [];
                    param.push(_dateStart);//@0
                    param.push(_dateEnd);//@1
                    param.push($('#filterColumn').val() != null ? $('#filterColumn').val() : 'UWIN_ID');//@2
                    param.push($('#txtFindData').val());//@3
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
                                _dataTable = [];
                                for (var i = 0; i < data.data.length; i++) {
                                    var obj = data.data[i];
                                    var func = 'SetUpdateGiftcode(' + obj[0] + ',"' + obj[3] + '");';
                                    var updateGiftcode = "<a class='btn btn-xs green btn-circle btn-outline' onclick='" + func + "' >Sửa ngày hết hạn</a>";
                                    $('#tbl_datatable tbody').append("<tr>" +
                                        "<td>" + obj[0] + "</td>" +
                                        "<td>" + obj[1] + "</td>" +
                                        "<td>" + obj[2] + "</td>" +
                                        "<td>" + obj[3] + "</td>" +
                                        "<td>" + obj[4] + "</td>" +
                                        "<td>" + obj[5] + "</td>" +
                                        "<td>" + obj[6] + "</td>" +
                                        "<td>" + obj[7] + "</td>" +
                                        "<td>" +
                                        "<a class='btn btn-xs blue btn-circle btn-outline' href='Page.aspx?m=66&eventid=" + obj[0] + "' target='_blank'>Xem chi tiết</a>" +
                                        updateGiftcode +
                                        "<a class='btn btn-xs red btn-circle btn-outline' onclick='javascript:DeleteGiftcode(`" + obj[0] + "`);' >Xóa Giftcode</a>" +
                                        "</td>" +
                                        "</tr>");
                                }


                                var colHiden = [];
                                oTable = table.dataTable({
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

                                //an column
                                var bVis = oTable.fnSettings().aoColumns[7].bVisible;
                                oTable.fnSetColumnVis(7, bVis ? false : true);
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

        var FormValidation = function () {
            var r = function () {
                var e = $("#form_Create_Giftcode"),
                    r = $(".alert-danger", e),
                    i = $(".alert-success", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        Name: {
                            required: !0,
                            maxlength: 200
                        },
                        Prefix: {
                            required: !0,
                            maxlength: 5
                        },
                        Price: {
                            required: !0,
                            number: !0
                        },
                        Qty: {
                            required: !0,
                            number: !0
                            
                        },
                        Expired: {
                            required: !0, 
                        },
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
                            CreateGiftcode();
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
                var e = $("#form_Update_Giftcode"),
                    r = $(".alert-danger2", e),
                    i = $(".alert-success2", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        Expired: {
                            required: !0,
                        }
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
                            UpdateGiftcode();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        function SetUpdateGiftcode(ID, Expired) {
            $('#ID_Giftcode').val(ID);
            $('#txtExpired2').val(Expired);
            $('#modal_Update_Giftcode').modal('show');
        }
        function UpdateGiftcode(ID) {
            var json = {
                "ID": $('#ID_Giftcode').val(),
                "Expired": $('#txtExpired2').val()
            }
            POST_DATA("Apis/API_GameAccount.ashx", {
                type: 9,
                json: JSON.stringify(json)
            }, function (res) {
                if (res.status == 1) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {
                            $('#modal_Update_Giftcode').modal('hide');
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

        function CreateGiftcode() {
            var json = {
                "Name": $('#txtName').val(),
                "Prefix": $('#txtPrefix').val(),
                "Price": $('#txtPrice').val(),
                "Qty": $('#txtQty').val(),
                "Expired": $('#txtExpired').val()
            }
            POST_DATA("Apis/API_GameAccount.ashx", {
                type: 8,
                json: JSON.stringify(json)
            }, function (res) {
                if (res.status == 1) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {
                            $('#modal_Create_Giftcode').modal('hide');
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

        function DeleteGiftcode(ID) {
            bootbox.confirm("Xác nhận xóa GiftCode?", function (result) {
                if (result) {
                    $('.divLoading').fadeIn();
                    var json = {
                        "ID": ID
                    };
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_GameAccount.ashx",
                        data: {
                            json: JSON.stringify(json),
                            type: 10
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

        function SubmitForm() {

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

        
</script>
</asp:Content>