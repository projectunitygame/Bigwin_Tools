<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_GameDT_GiftCodeThongTin.aspx.cs" Inherits="CMS_Tools.Test_GiftCodeThongKe" %>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        Thông tin Giftcode
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
                                <option value='Code'>Mã giftcode</option>
                            	<option value='Gold'>Giá trị</option>
                                <option value='AccountId'>Id sử dụng</option>
                                <option value='EventID'>Mã event</option>
                                <option value='AccountName'>Tài khoản sử dụng</option>
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
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">\
    <script src="assets/global/plugins/Base64JS.js"></script>
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script type="text/javascript">
        var colFilter = null;
        jQuery(document).ready(function () {
            $('.page-toolbar').remove();

            var d = AppManage.getURLParameter('eventid');
            console.log(d);
            if (d != null) {
                $("#txtFindData").val(d);
                $('#filterColumn').val('EventID');
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

                                _dataTable = [];
                                for (var i = 0; i < data.data.length; i++) {
                                    var obj = data.data[i];
                                    $('#tbl_datatable tbody').append("<tr>" +
                                        "<td>" + obj[0] + "</td>" +
                                        "<td>" + obj[1] + "</td>" +
                                        "<td>" + obj[2] + "</td>" +
                                        "<td>" + (obj[3] =='False'?'Chưa sử dụng':'Đã sử dụng') + "</td>" +
                                        "<td>" + obj[4] + "</td>" +
                                        "<td>" + obj[5] + "</td>" +
                                        "<td>" + obj[6] + "</td>" +
                                        "<td>" + obj[7] + "</td>" +
                                        "<td>" + obj[8] + "</td>" +
                                        "<td></td>" +
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
                                        [2, "desc"]
                                    ]
                                });

                                var bVis = oTable.fnSettings().aoColumns[9].bVisible;
                                oTable.fnSetColumnVis(9, bVis ? false : true);

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

</script>
</asp:Content>
