<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_GameDT_TheNap_KhoThe.aspx.cs" Inherits="CMS_Tools.Test_TheNapThongKe" %>
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
                        Quản lý kho thẻ
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
                    <div class="row" style="display:none">
                        <div class="col-md-4" style="margin-bottom: 10px;">
                            <label class="control-label label-balance">Chọn ngày kết xuất dữ liệu</label>
                            <div class="input-group" id="dateRangeEvent">
                                <input type="text" class="form-control" placeholder="Date Range(MM/DD/YYYY)" disabled />
                                <span class="input-group-btn">
                                    <button class="btn default date-range-toggle" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-bottom: 10px;">
                            <label class="control-label label-balance">Chọn lọc dữ liệu theo cột</label>
                            <select id="filterColumn" class="form-control">
                                <option value='MA_GIAO_DICH'>Mã giao dịch</option>
                            	<option value='TK_NGUOI_GUI'>Tài khoản người gửi</option>
                                <option value='TEN_NGUOI_GUI'>Tên người gửi</option>
                                <option value='TK_NGUOI_NHAN'>Tài khoản người nhận</option>
                                <option value='TEN_NGUOI_NHAN'>Tên người nhận</option>
                                
                            </select>
                        </div>
                        <div class="col-md-3" style="margin-bottom: 10px;">
                            <label class="control-label label-balance">Nhập từ khóa tìm kiếm</label>
                            <input type="text" class="form-control" id="txtFindData" placeholder="Search..." />
                        </div>
                        <div class="col-md-2" style="margin-bottom: 10px;">
                            <label class="control-label label-balance">Tìm kiếm</label>
                            <button id="btnFindData" type="button" class="btn green form-control"><i class="icon-magnifier"></i>Search</button>
                        </div>
                    </div>
                    <div id="sample_1_wrapper" class="dataTables_wrapper form-inline" role="grid">
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

    <!-----From buy card------>
    <div id="modal_buy_card" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_buy_card" class="form-horizontal" novalidate="novalidate">
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title">
                                <i class="fa fa-edit"></i> MUA THẺ MỚI</h4>
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
                                            Loại thẻ: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select name="cardType" class="form-control" id="cardType">
                                                    <option value="1">Vietel</option>
                                                    <option value="2">Mobi</option>
                                                    <option value="3">Vina</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-4">
                                            Mệnh giá: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select name="valueCard" class="form-control" id="valueCard">
                                                    <option value="20000">20,000</option>
                                                    <option value="50000">50,000</option>
                                                    <option value="100000">100,000</option>
                                                    <option value="200000">200,000</option>
                                                    <option value="500000">500,000</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group margin-top-20">
                                        <label class="control-label col-md-4">
                                            Số lượng: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" style="width:100%;" id="qtyCard" class="form-control" name="qtyCard" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn dark btn-outline">Hủy</button>
                        <button type="submit" class="btn green">Xác nhận</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">\
    <script src="assets/global/plugins/Base64JS.js"></script>
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script type="text/javascript">
        var colFilter = null;
        jQuery(document).ready(function () {
            if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                $('.page-toolbar').remove();
            }
            //$('.page-toolbar').remove();
            FormValidation.init();
            $('#btnAddNew').html("<i class='fa fa-plus'></  i> Mua thẻ");
            $('#btnAddNew').click(function () {
                ResetForm();
                $('#modal_buy_card').modal('show');
            });
            var d = AppManage.getURLParameter('agencyid');
            console.log(d);
            if (d != null) {
                var s = Base64.decode(d).split('-')[0];
                $("#txtFindData").val(s);
                $('#filterColumn').val('TK_NGUOI_NHAN');
            }
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
                    startDate: moment().subtract('month', 3),
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
                _dateStart = moment().subtract('month', 3).format('YYYY/MM/DD');
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
                        _dateStart = moment().subtract('month', 3).format('YYYY/MM/DD');
                    if (_dateEnd == null)
                        _dateEnd = moment().format('YYYY/MM/DD');
                    var param = [];
                    param.push(_dateStart);//@0
                    param.push(_dateEnd);//@1
                    param.push($('#filterColumn').val());//@2
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

                                for (var i = 0; i < data.data.length; i++) {
                                    var obj = data.data[i];
                                    var typeCard = "";
                                    switch (obj[1]) {
                                        case "1":
                                            typeCard = 'Viettel'
                                            break;
                                        case "2":
                                            typeCard = 'Mobiphone'
                                            break;
                                        case "3":
                                            typeCard = 'Vinaphone'
                                            break;
                                        default:
                                            typeCard = 'Chưa phân loại'
                                            break;
                                    }

                                    $('#tbl_datatable tbody').append("<tr>" +
                                        "<td>" + obj[0] + "</td>" +
                                        "<td>" + typeCard + "</td>" +
                                        "<td>" + obj[2] + "</td>" +
                                        "<td>" + obj[3] + "</td>" +
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
                                        [1, "asc"]
                                    ]
                                });

                                var bVis = oTable.fnSettings().aoColumns[3].bVisible;
                                oTable.fnSetColumnVis(3, bVis ? false : true);

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

        

        function formatMoney(num) {
            if (num > 0)
                return num.toLocaleString('en-US');
            else
                return num;
        }
        function ResetForm() {
            $('#form_buy_card').trigger('reset');
        }
        function BuyCard() {
            var json = {
                "CardType": $('#cardType').val(),
                "Amount": $('#valueCard').val(),
                "Qty": $('#qtyCard').val()
            }
            POST_DATA("Apis/API_GameAccount.ashx", {
                type: 15,
                json: JSON.stringify(json)
            }, function (res) {
                bootbox.alert({
                    title: "Thông báo",
                    message: res.msg,
                    callback: function () {
                        $('#modal_buy_card').modal('show');
                        TableEditable.init();
                    }
                })

                $(".divLoading").fadeOut(500);

            });
        }

        var FormValidation = function () {
            var r = function () {
                var e = $("#form_buy_card"),
                    r = $(".alert-danger", e),
                    i = $(".alert-success", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        required: {
                            number: !0,
                            required: !0
                        },
                        valueCard: {
                            number: !0,
                            required: !0
                        },
                        qtyCard: {
                            number: !0,
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
                            BuyCard();
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