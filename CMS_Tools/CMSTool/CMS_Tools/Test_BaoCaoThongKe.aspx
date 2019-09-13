<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_BaoCaoThongKe.aspx.cs" Inherits="CMS_Tools.Test_BaoCaoThongKe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .af-kpi-box-footer{
        text-align: center;
        text-align: center;
        border-top: 1px solid #ddd;
        padding: 6px;
        margin: 0;
        font-weight: 500 !important;
        margin-top:20px;
    }
.kpi-border {
    border: 1px solid #ddd;
    -webkit-border-radius: 5px !important;
    -moz-border-radius: 5px !important;
    border-radius: 5px !important;
    background: #26344b;
    color: #18cdc4;
    text-align: center;
}
.clearfix{clear:both}
.af-kpi-box-pieces-container .af-kpi-box-piece {
    border-right: 1px dashed #18cdc4;
}
.af-kpi-box-pieces-container .af-kpi-box-piece:last-child {
    border-right: none;
}
.af-kpi-box-piece h5{font-weight: 500 !important;  font-size: 12px;}
.af-kpi-box-piece h2{margin: 0;}
.chartdiv {
  width: 100%;
  height: 300px;
  margin-top: 50px;
}
.kpi-box{margin-bottom: 20px;}
#PageContent_PageID{
	background: #FFF;
    padding: 20px;
}
.table td {
    vertical-align: middle !important;
    font-size: 11.5px !important;
    padding: 4px 8px !important;
}
table thead tr, table tfoot tr {
    background: #1871af;
    color: #FFF;
    border: 1px solid #1871af;
    font-weight: 600;
}
.page-content{
	background: #1f2b3d !important;
}
.page-container-bg-solid .page-title, .page-container-bg-solid .page-title small {
    color: #18cdc4 !important;
}
#PageContent_PageID, .page-bar{
-webkit-border-radius: 5px !important;
-moz-border-radius: 5px !important;
border-radius: 5px !important;
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
    <div class="table-toolbar">
        <div class="row">
            <div class="col-md-3" style="margin-bottom: 10px;">
                Asia/Bangkok Timezone UTC+7
                <div class="input-group" id="dateRangeEvent">
                    <input type="text" class="form-control" placeholder="Date Range(MM/DD/YYYY)" disabled />
                    <span class="input-group-btn">
                        <button class="btn default date-range-toggle" type="button"><i class="fa fa-calendar"></i></button>
                    </span>
                </div>
            </div>
            <div class="col-md-3" style="margin-bottom: 10px; display: none">
                Chọn games
                <select id="gameList" class="form-control">
                    <option value=''>--Tất cả games--</option>
                    <option value='1'>Kungfu Panda</option>
                    <option value='2'>Thần tài</option>
                    <option value='3'>Tam quốc</option>
                    <option value='4'>Mini Poker</option>
                    <option value='5'>Mini Slot</option>
                    <option value='6'>Kim cương</option>
                    <option value='7'>Cao thấp</option>
                    <option value='8'>Tài xỉu</option>
                    <option value='9'>SuperNova</option>
                    <option value='10'>Bầu cua</option>
                    <option value='11'>Ba cây</option>
                    <option value='15'>Sam Dem La</option>
                    <option value='35'>Sam solo</option>
                    <option value='33'>TLMN</option>
                    <option value='107'>TLMN solo</option>
                </select>
            </div>
        </div>
    </div>
    <div class='row' style='display: block;'>
        <div class="col-md-4 kpi-box">
            <div class='kpi-border af-kpi-box-pieces-container'>
                <div class="col-md-4 af-kpi-box-piece">
                    <h5>Web</h5>
                    <h2>
                        <text id="nru-web" style="transition: background-color 0.8s ease-out 0s, color, opacity;">0</text>
                    </h2>
                </div>
                <div class="col-md-4 af-kpi-box-piece">
                    <h5>Android</h5>
                    <h2>
                        <text id='nru-android' style="transition: background-color 0.8s ease-out 0s, color, opacity;">0</text>
                    </h2>
                </div>
                <div class="col-md-4 af-kpi-box-piece">
                    <h5>IOS</h5>
                    <h2>
                        <text id='nru-ios' style="transition: background-color 0.8s ease-out 0s, color, opacity;">0</text>
                    </h2>
                </div>
                <div class='clearfix'>
                    <h5 class="af-kpi-box-footer">NRU Current</h5>
                </div>
            </div>
        </div>
        <div class="col-md-4 kpi-box">
            <div class='kpi-border af-kpi-box-pieces-container'>
                <div class="col-md-4 af-kpi-box-piece">
                    <h5>Web</h5>
                    <h2>
                        <text id='dau-web' style="transition: background-color 0.8s ease-out 0s, color, opacity;">0</text>
                    </h2>
                </div>
                <div class="col-md-4 af-kpi-box-piece">
                    <h5>Android</h5>
                    <h2>
                        <text id='dau-android' style="transition: background-color 0.8s ease-out 0s, color, opacity;">0</text>
                    </h2>
                </div>
                <div class="col-md-4 af-kpi-box-piece">
                    <h5>IOS</h5>
                    <h2>
                        <text id='dau-ios' style="transition: background-color 0.8s ease-out 0s, color, opacity;">0</text>
                    </h2>
                </div>
                <div class='clearfix'>
                    <h5 class="af-kpi-box-footer">DAU Current</h5>
                </div>
            </div>
        </div>
        <div class="col-md-2 kpi-box">
            <div class='kpi-border af-kpi-box-pieces-container'>
                <div class="col-md-12 af-kpi-box-piece">
                    <h5>PCCU(max ccu)</h5>
                    <h2>
                        <text id="pccu-current" style="transition: background-color 0.8s ease-out 0s, color, opacity;">0</text>
                    </h2>
                </div>
                <div class='clearfix'>
                    <h5 class="af-kpi-box-footer">PCCU Current</h5>
                </div>
            </div>
        </div>
        <div class="col-md-2 kpi-box">
            <div class='kpi-border af-kpi-box-pieces-container'>
                <div class="col-md-12 af-kpi-box-piece">
                    <h5>Users</h5>
                    <h2>
                        <text id="totalUsers-current" style="transition: background-color 0.8s ease-out 0s, color, opacity;">0</text>
                    </h2>
                </div>
                <div class='clearfix'>
                    <h5 class="af-kpi-box-footer">Total Users</h5>
                </div>
            </div>
        </div>
    </div>

    <div class='row'>
    	<!------ NAU report------>
        <div class="col-md-12" style="margin-bottom: 10px;">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-bar-chart"></i> NAU Report
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
                     <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable"
                            aria-describedby="sample_1_info">
                            <thead>
                                <tr role="row"></tr>
                            </thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot>
                                <tr role="row"></tr>
                            </tfoot>
                        </table>
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <div id="chartdiv" class='chartdiv'></div>
                </div>
            </div>
        </div>
        <!--------- end nau report------------>
        <!--------- nru report----------->
        <div class="col-md-12" style="margin-bottom: 10px;">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-bar-chart"></i> NRU Report
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
                     <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable2"
                            aria-describedby="sample_1_info">
                            <thead>
                                <tr role="row"></tr>
                            </thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot>
                                <tr role="row"></tr>
                            </tfoot>
                        </table>
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <div id="chartdiv2" class='chartdiv'></div>
                </div>
            </div>
        </div>
        <!--------- end nau report------------>
        <!--------- ccu 24h report----------->
        <div class="col-md-12" style="margin-bottom: 10px;">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-bar-chart"></i> CCU 24H Report
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
                     <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable3"
                            aria-describedby="sample_1_info">
                            <thead>
                                <tr role="row"></tr>
                            </thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot>
                                <tr role="row"></tr>
                            </tfoot>
                        </table>
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <div id="chartdiv3" class='chartdiv'></div>
                </div>
            </div>
        </div>
        <!--------- end ccu 24h report------------>
        <!--------- top dai gia report----------->
        <div class="col-md-12" style="margin-bottom: 10px;">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-bar-chart"></i> Top Đại Gia Report
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
                     <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable4"
                            aria-describedby="sample_1_info">
                            <thead>
                                <tr role="row"></tr>
                            </thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                            <tfoot>
                                <tr role="row"></tr>
                            </tfoot>
                        </table>
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <div id="chartdiv4" class='chartdiv'></div>
                </div>
            </div>
        </div>
        <!--------- end top dai gia report------------>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
        <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script src="assets/global/plugins/amcharts/v4/core.js"></script>
    <script src="assets/global/plugins/amcharts/v4/charts.js"></script>
    <script src="assets/global/plugins/amcharts/v4/animated.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            $('.page-toolbar').remove();

            if ($('#ContentPlaceHolder_MAIN_ruleAdd').val() == "0")
                $('.sample_editable_1_new').remove();

            ComponentsPickers.init();
            TableEditable.init();
            
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
                    startDate: moment().subtract('month', 1),
                    endDate: moment(),
                    minDate: moment().subtract('month', 12).format('MM/DD/YYYY'),
                    maxDate: moment().format('MM/DD/YYYY'),
                },
                    function (start, end) {
                        _dateStart = start.format('YYYY/MM/DD');
                        _dateEnd = end.format('YYYY/MM/DD');
                        //alert(_dateEnd);
                        console.log("Callback has been called!");
                        $('#dateRangeEvent input').val(start.format('MM/DD/YYYY') + ' - ' + end.format('MM/DD/YYYY'));
                        TableEditable.init();
                    }
                );
                _dateStart = moment().subtract('month', 1).format('YYYY/MM/DD');
                _dateEnd = moment().format('YYYY/MM/DD');
                $('#dateRangeEvent input').val(_dateStart + ' - ' + _dateEnd);
            };

            return {
                //main function to initiate the module
                init: function () {
                    handleDateRangePickers();
                }
            };
        }();

        var oTable = null;
        var oTable2 = null;
        var oTable3 = null;
        var oTable4 = null;
        var _pageSize = 10;
        var _dataColumn = null;
        var colFilter = null;
        var colFilter2 = null;
        var _dataColumn2 = null;
        var colFilter2 = null;
        var colFilter3 = null;
        var _dataColumn3 = null;
        var colFilter3 = null;
        var _dataColumn4 = null;
        var colFilter4 = null;
        var TableEditable = function () {
            var NAU_Table = function () {
                var table_NAU = $('#tbl_datatable');
                loadTable();
                function loadTable() {
                    $('.divLoading').fadeIn();
                    if (_dateStart == null)
                        _dateStart = moment().subtract('month', 1).format('YYYY/MM/DD');
                    if (_dateEnd == null)
                        _dateEnd = moment().format('YYYY/MM/DD');
                    var param = [];
                    param.push(_dateStart);//@0
                    param.push(_dateEnd);//@1
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 50, //DAU
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
                                    console.log("fnDestroy DAU");
                                    colFilter = null
                                }
                                _dataColumn = data.columnName;
                                var columnLength = data.columnName.length;
                                if (colFilter == null) {
                                    $('#tbl_datatable thead tr').html("");
                                    colFilter = _dataColumn;
                                    var strHtmlColName = "";
                                    _dataColumn.splice(_dataColumn.length - 1, 1);
                                    $.each(_dataColumn, function (key, obj) {
                                        strHtmlColName += "<td>" + obj + "</td>";
                                    });
                                    $('#tbl_datatable thead tr').append(strHtmlColName);
                                    if (data.data.length > 20 && _pageSize > 10) {
                                        $('#tbl_datatable tfoot tr').append(strHtmlColName);
                                    }
                                }
                                else {
                                    $('#tbl_datatable thead tr').empty();
                                    var strHtmlColName = "";
                                    $.each(_dataColumn, function (key, obj) {
                                        strHtmlColName += "<td>" + obj + "</td>";
                                    });
                                    if (data.data.length > 20 && _pageSize > 10) {
                                        $('#tbl_datatable tfoot tr').append(strHtmlColName);
                                    }
                                }
                                var dataReport = data.data;
                                var chartData = [];
                                var countRow = dataReport.length;
                                $('#dau-web').html(dataReport[countRow - 1][1])//android
                                $('#dau-android').html(dataReport[countRow - 1][2])//ios
                                $('#dau-ios').html(dataReport[countRow - 1][3])//web
                                for (var i = 0; i < countRow; i++) {
                                    dataReport[i].splice(columnLength - 1, 1);
                                    chartData.push({
                                        "date": data.data[i][0],
                                        "android": data.data[i][1],
                                        "ios": data.data[i][2],
                                        "web": data.data[i][3],
                                        "total": data.data[i][4],
                                        "chartName": "DAU Login"
                                    });
                                }
                                //console.log(dataReport);
                                var colHiden = [];
                                oTable = table_NAU.dataTable({
                                    "data": dataReport,
                                    "lengthMenu": [
                                        [10, 50, 100, 500, -1],
                                        [10, 50, 100, 500, "All"]
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
                                var tableWrapper = $("#tbl_datatable_wrapper");
                                jQuery('#tbl_datatable_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
                                jQuery('#tbl_datatable_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
                                jQuery('#tbl_datatable_wrapper .dataTables_length select').select2(); // initialize select2 dropdown

                                //tableWrapper.find(".dataTables_length select").select2({
                                //    showSearchInput: false
                                //});
                                loadThongkeChart(chartData, 'chartdiv');
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
            },
                NRU_Table = function () {
                    var table_NRU = $('#tbl_datatable2');
                    loadTable2();
                    function loadTable2() {
                        //$('.divLoading').fadeIn();
                        if (_dateStart == null)
                            _dateStart = moment().subtract('month', 1).format('YYYY/MM/DD');
                        if (_dateEnd == null)
                            _dateEnd = moment().format('YYYY/MM/DD');
                        var param = [];
                        param.push(_dateStart);//@0
                        param.push(_dateEnd);//@1
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 51, //NRU
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
                                        colFilter2 = null;
                                        console.log("fnDestroy NRU");
                                    }
                                    _dataColumn2 = data.columnName;
                                    var columnLength = data.columnName.length;
                                    if (colFilter2 == null) {
                                        $('#tbl_datatable2 thead tr').html("");
                                        colFilter2 = _dataColumn2;
                                        var strHtmlColName = "";
                                        _dataColumn2.splice(_dataColumn2.length - 1, 1);
                                        $.each(_dataColumn2, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable2 thead tr').append(strHtmlColName);
                                        if (data.data.length > 20 && _pageSize > 10) {
                                            $('#tbl_datatable2 tfoot tr').append(strHtmlColName);
                                        }
                                    }
                                    else {
                                        $('#tbl_datatable2 thead tr').empty();
                                        var strHtmlColName = "";
                                        $.each(_dataColumn, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        if (data.data.length > 20 && _pageSize > 10) {
                                            $('#tbl_datatable2 tfoot tr').append(strHtmlColName);
                                        }
                                    }
                                    var dataReport = data.data;
                                    var chartData = [];
                                    var countRow = dataReport.length;
                                    $('#nru-web').html(dataReport[countRow - 1][1])//android
                                    $('#nru-android').html(dataReport[countRow - 1][2])//ios
                                    $('#nru-ios').html(dataReport[countRow - 1][3])//web
                                    for (var i = 0; i < countRow; i++) {
                                        dataReport[i].splice(columnLength - 1, 1);
                                        chartData.push({
                                            "date": data.data[i][0],
                                            "android": data.data[i][1],
                                            "ios": data.data[i][2],
                                            "web": data.data[i][3],
                                            "total": data.data[i][4],
                                            "chartName": "NRU Install"
                                        });
                                    }
                                    //console.log(dataReport);
                                    var colHiden = [];
                                    oTable2 = table_NRU.dataTable({
                                        "data": dataReport,
                                        "lengthMenu": [
                                            [10, 50, 100, 500, -1],
                                            [10, 50, 100, 500, "All"]
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
                                    var tableWrapper = $("#tbl_datatable2_wrapper");
                                    jQuery('#tbl_datatable2_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
                                    jQuery('#tbl_datatable2_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
                                    jQuery('#tbl_datatable2_wrapper .dataTables_length select').select2(); // initialize select2 dropdown

                                    //tableWrapper.find(".dataTables_length select").select2({
                                    //    showSearchInput: false
                                    //});
                                    loadThongkeChart(chartData, 'chartdiv2');
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
                PCCU_Table = function () {
                    //$('.divLoading').fadeIn();
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 53, //PCCU
                            p: ""
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.data.length > 0) {
                                $('#pccu-current').html(data.data[0][1]);
                            }
                            else {
                                $('#pccu-current').html("0");
                            }
                        },
                        complete: function () {
                            //$(".divLoading").fadeOut(500);
                        }
                    });
                },
                TotalUsers_Table = function () {
                    //$('.divLoading').fadeIn();
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 55, //Total users
                            p: ""
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.data.length > 0) {
                                $('#totalUsers-current').html(data.data[0][0]);
                            }
                            else {
                                $('#totalUsers-current').html("0");
                            }
                        },
                        complete: function () {
                            //$(".divLoading").fadeOut(500);
                        }
                    });
                },
                CCU_24h_Table = function () {
                    var table_CCU_24H = $('#tbl_datatable3');
                    loadTable3();
                    function loadTable3() {
                        //$('.divLoading').fadeIn();
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 52, //CCU-24H
                                p: ""
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
                                        colFilter3 = null;
                                        console.log("fnDestroy NRU");
                                    }
                                    _dataColumn3 = data.columnName;
                                    var columnLength = data.columnName.length;
                                    if (colFilter3 == null) {
                                        $('#tbl_datatable3 thead tr').html("");
                                        colFilter3 = _dataColumn3;
                                        var strHtmlColName = "";
                                        _dataColumn3.splice(_dataColumn3.length - 1, 1);
                                        $.each(_dataColumn3, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable3 thead tr').append(strHtmlColName);
                                        if (data.data.length > 20 && _pageSize > 10) {
                                            $('#tbl_datatable3 tfoot tr').append(strHtmlColName);
                                        }
                                    }
                                    else {
                                        $('#tbl_datatable3 thead tr').empty();
                                        var strHtmlColName = "";
                                        $.each(_dataColumn, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        if (data.data.length > 20 && _pageSize > 10) {
                                            $('#tbl_datatable3 tfoot tr').append(strHtmlColName);
                                        }
                                    }
                                    var dataReport = data.data;
                                    var chartData = [];
                                    var countRow = dataReport.length;
                                    for (var i = 0; i < countRow; i++) {
                                        dataReport[i].splice(columnLength - 1, 1);
                                        chartData.push({
                                            "time": data.data[i][0],
                                            "ccu": data.data[i][2],
                                            "chartName": "CCU 24h"
                                        });
                                    }
                                    
                                    //console.log(dataReport);
                                    var colHiden = [];
                                    oTable3 = table_CCU_24H.dataTable({
                                        "data": dataReport,
                                        "lengthMenu": [
                                            [10, 50, 100, 500, -1],
                                            [10, 50, 100, 500, "All"]
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
                                    var tableWrapper = $("#tbl_datatable3_wrapper");
                                    jQuery('#tbl_datatable3_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
                                    jQuery('#tbl_datatable3_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
                                    jQuery('#tbl_datatable3_wrapper .dataTables_length select').select2(); // initialize select2 dropdown

                                    //tableWrapper.find(".dataTables_length select").select2({
                                    //    showSearchInput: false
                                    //});
                                    loadCCU24H_Chart(chartData, 'chartdiv3');
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
                Top_Dai_Gia_Table = function () {
                    var table_Top_Dai_Gia = $('#tbl_datatable4');
                    loadTable4();
                    function loadTable4() {
                        //$('.divLoading').fadeIn();
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 59, //top đại gia
                                p: ""
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
                                        colFilter4 = null;
                                        console.log("fnDestroy TOP_DAI_GIA");
                                    }
                                    _dataColumn4 = data.columnName;
                                    var columnLength = data.columnName.length;
                                    if (colFilter4 == null) {
                                        $('#tbl_datatable4 thead tr').html("");
                                        colFilter4 = _dataColumn4;
                                        var strHtmlColName = "";
                                        _dataColumn4.splice(_dataColumn4.length - 1, 1);
                                        $.each(_dataColumn4, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        $('#tbl_datatable4 thead tr').append(strHtmlColName);
                                        if (data.data.length > 20 && _pageSize > 10) {
                                            $('#tbl_datatable4 tfoot tr').append(strHtmlColName);
                                        }
                                    }
                                    else {
                                        $('#tbl_datatable4 thead tr').empty();
                                        var strHtmlColName = "";
                                        $.each(_dataColumn, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                        });
                                        if (data.data.length > 20 && _pageSize > 10) {
                                            $('#tbl_datatable4 tfoot tr').append(strHtmlColName);
                                        }
                                    }
                                    var dataReport = data.data;
                                    var chartData = [];
                                    var countRow = dataReport.length;
                                    for (var i = 0; i < countRow; i++) {
                                        dataReport[i].splice(columnLength - 1, 1);
                                        chartData.push({
                                            "displayname": data.data[i][3],
                                            "gold": parseInt(data.data[i][4]),
                                            "chartName": "Top Đại Gia"
                                        });
                                        if (i ==19) { break; }
                                    }
                                    console.log(chartData);
                                    //console.log(dataReport);
                                    var colHiden = [];
                                    oTable4 = table_Top_Dai_Gia.dataTable({
                                        "data": dataReport,
                                        "lengthMenu": [
                                            [10, 50, 100, 500, -1],
                                            [10, 50, 100, 500, "All"]
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
                                            [4, "desc"]
                                        ]
                                    });
                                    var tableWrapper = $("#tbl_datatable4_wrapper");
                                    jQuery('#tbl_datatable4_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
                                    jQuery('#tbl_datatable4_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
                                    jQuery('#tbl_datatable4_wrapper .dataTables_length select').select2(); // initialize select2 dropdown

                                    tableWrapper.find(".dataTables_length select").select2({
                                        showSearchInput: false
                                    });
                                    loadTopDaiGia_Chart(chartData, 'chartdiv4');
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
                    NAU_Table();
                    NRU_Table();
                    PCCU_Table();
                    TotalUsers_Table();
                    CCU_24h_Table();
                    Top_Dai_Gia_Table();
                },
                reloadTable: function () {
                    NAU_Table();
                    NRU_Table();
                    PCCU_Table();
                    TotalUsers_Table();
                    CCU_24h_Table();
                    Top_Dai_Gia_Table();
                }
            };
        }();


        function loadThongkeChart(dataChart, ChartID) {
            am4core.ready(function () {
                am4core.useTheme(am4themes_animated);
                var chart = am4core.create(ChartID, am4charts.XYChart);
                chart.data = dataChart;
                chart.colors.step = 2;
                chart.maskBullets = false;
                // Create axes
                var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
                dateAxis.renderer.grid.template.location = 0;
                dateAxis.renderer.minGridDistance = 50;

                var distanceAxis = chart.yAxes.push(new am4charts.ValueAxis());
                distanceAxis.title.text = "User Login";
                distanceAxis.renderer.grid.template.disabled = true;
                // Create series
                var distanceSeries = chart.series.push(new am4charts.ColumnSeries());
                distanceSeries.dataFields.valueY = "android";
                distanceSeries.dataFields.dateX = "date";
                distanceSeries.yAxis = distanceAxis;
                //distanceSeries.tooltipText = "Android: {valueY}";
                distanceSeries.name = "Android";
                distanceSeries.columns.template.fillOpacity = 0.7;
                distanceSeries.columns.template.propertyFields.strokeDasharray = "dashLength";
                distanceSeries.columns.template.propertyFields.fillOpacity = "alpha";

                var disatnceState = distanceSeries.columns.template.states.create("hover");
                disatnceState.properties.fillOpacity = 0.9;

                var webSeries = chart.series.push(new am4charts.ColumnSeries());
                webSeries.dataFields.valueY = "web";
                webSeries.dataFields.dateX = "date";
                webSeries.yAxis = distanceAxis;
                //webSeries.tooltipText = "Web: {valueY}";
                webSeries.name = "Web";
                webSeries.columns.template.fillOpacity = 0.7;
                webSeries.columns.template.propertyFields.strokeDasharray = "dashLength";
                webSeries.columns.template.propertyFields.fillOpacity = "alpha";

                var webState = webSeries.columns.template.states.create("hover");
                webState.properties.fillOpacity = 0.9;

                var IOSSeries = chart.series.push(new am4charts.ColumnSeries());
                IOSSeries.dataFields.valueY = "ios";
                IOSSeries.dataFields.dateX = "date";
                IOSSeries.yAxis = distanceAxis;
                //totalSeries.tooltipText = "Total: {valueY}";
                IOSSeries.name = "iOS";
                IOSSeries.columns.template.fillOpacity = 0.7;
                IOSSeries.columns.template.propertyFields.strokeDasharray = "dashLength";
                IOSSeries.columns.template.propertyFields.fillOpacity = "alpha";
                var iosState = IOSSeries.columns.template.states.create("hover");
                iosState.properties.fillOpacity = 0.9;


                var totalSeries = chart.series.push(new am4charts.LineSeries());
                totalSeries.dataFields.valueY = "total";
                totalSeries.dataFields.dateX = "date";
                totalSeries.yAxis = distanceAxis;
                totalSeries.name = "Total";
                totalSeries.strokeWidth = 2;
                totalSeries.propertyFields.strokeDasharray = "dashLength";
                totalSeries.tooltipText = `[bold]{chartName}[/]
                -----------------
                Web: {web}
                Android: {android}
                iOS: {ios}
                Total: {total}`;
                totalSeries.tooltip.pointerOrientation = "vertical";

                var totalBullet = totalSeries.bullets.push(new am4charts.Bullet());
                var totalRectangle = totalBullet.createChild(am4core.Rectangle);
                totalBullet.horizontalCenter = "middle";
                totalBullet.verticalCenter = "middle";
                totalBullet.width = 4;
                totalBullet.height = 4;
                totalRectangle.width = 4;
                totalRectangle.height = 4;

                var totalState = totalBullet.states.create("hover");
                totalState.properties.scale = 1.2;
                // Add legend
                chart.legend = new am4charts.Legend();

                // Add cursor
                chart.cursor = new am4charts.XYCursor();
                chart.cursor.fullWidthLineX = true;
                chart.cursor.xAxis = dateAxis;
                chart.cursor.lineX.strokeOpacity = 0;
                chart.cursor.lineX.fill = am4core.color("#000");
                chart.cursor.lineX.fillOpacity = 0.1;

            }); // end am4core.ready()
        }

        function loadCCU24H_Chart(dataChart, ChartID) {
            am4core.ready(function () {
                am4core.useTheme(am4themes_animated);
                var chart = am4core.create(ChartID, am4charts.XYChart);
                chart.data = dataChart;
                chart.colors.step = 2;
                chart.maskBullets = false;

                var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
                categoryAxis.dataFields.category = "time";
                categoryAxis.renderer.grid.template.location = 0;
                categoryAxis.renderer.minGridDistance = 30;
                categoryAxis.renderer.labels.template.rotation = 90;
                // Create axes
                var distanceAxis = chart.yAxes.push(new am4charts.ValueAxis());
                distanceAxis.title.text = "Users login";
                distanceAxis.renderer.grid.template.disabled = true;
                // Create series
                var CCUSeries = chart.series.push(new am4charts.LineSeries());
                CCUSeries.dataFields.valueY = "ccu";
                CCUSeries.dataFields.categoryX = "time";
                CCUSeries.yAxis = distanceAxis;
                CCUSeries.name = "CCU";
                CCUSeries.strokeWidth = 2;
                CCUSeries.propertyFields.strokeDasharray = "dashLength";
                CCUSeries.tooltipText = "Users: {valueY}";

                var CCUBullet = CCUSeries.bullets.push(new am4charts.Bullet());
                var CCURectangle = CCUBullet.createChild(am4core.Rectangle);
                CCURectangle.horizontalCenter = "middle";
                CCURectangle.verticalCenter = "middle";
                CCURectangle.width = 1;
                CCURectangle.height = 1;
                CCURectangle.width = 1;
                CCURectangle.height = 1;

                var CCUState = CCUBullet.states.create("hover");
                CCUState.properties.scale = 1.2;
                // Add legend
                chart.legend = new am4charts.Legend();

                // Add cursor
                chart.cursor = new am4charts.XYCursor();
                chart.cursor.fullWidthLineX = true;
                chart.cursor.xAxis = categoryAxis;
                chart.cursor.lineX.strokeOpacity = 0;
                chart.cursor.lineX.fill = am4core.color("#000");
                chart.cursor.lineX.fillOpacity = 0.1;

            }); // end am4core.ready()
        }

        function loadTopDaiGia_Chart(dataChart, ChartID) {
            am4core.ready(function () {
                am4core.useTheme(am4themes_animated);
                var chart = am4core.create(ChartID, am4charts.XYChart);
                chart.data = dataChart;
                chart.colors.step = 2;
                chart.maskBullets = false;

                var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
                categoryAxis.dataFields.category = "displayname";
                categoryAxis.renderer.grid.template.location = 0;
                categoryAxis.renderer.minGridDistance = 30;
                categoryAxis.renderer.labels.template.rotation = 90;
                // Create axes
                var distanceAxis = chart.yAxes.push(new am4charts.ValueAxis());
                distanceAxis.title.text = "Top đại gia";
                distanceAxis.renderer.grid.template.disabled = true;
                // Create series
                //var CCUSeries = chart.series.push(new am4charts.LineSeries());
                //CCUSeries.dataFields.valueY = "gold";
                //CCUSeries.dataFields.categoryX = "displayname";
                //CCUSeries.yAxis = distanceAxis;
                //CCUSeries.name = "Số Gold";
                //CCUSeries.strokeWidth = 2;
                //CCUSeries.propertyFields.strokeDasharray = "dashLength";
                //CCUSeries.tooltipText = "Số gold: {valueY}";

                var CCUSeries = chart.series.push(new am4charts.ColumnSeries());
                CCUSeries.dataFields.valueY = "gold";
                CCUSeries.dataFields.categoryX = "displayname";
                CCUSeries.yAxis = distanceAxis;
                CCUSeries.name = "Số Gold";
                CCUSeries.columns.template.fillOpacity = 0.7;
                CCUSeries.columns.template.propertyFields.strokeDasharray = "dashLength";
                CCUSeries.columns.template.propertyFields.fillOpacity = "alpha";

                // Create series
                //var CCUSeries = chart.series.push(new am4charts.LineSeries());
                //CCUSeries.dataFields.valueY = "ccu";
                //CCUSeries.dataFields.categoryX = "time";
                //CCUSeries.yAxis = distanceAxis;
                //CCUSeries.name = "CCU";
                //CCUSeries.strokeWidth = 2;
                //CCUSeries.propertyFields.strokeDasharray = "dashLength";
                //CCUSeries.tooltipText = "Users: {valueY}";

                var CCUBullet = CCUSeries.bullets.push(new am4charts.Bullet());
                var CCURectangle = CCUBullet.createChild(am4core.Rectangle);
                CCURectangle.horizontalCenter = "middle";
                CCURectangle.verticalCenter = "middle";
                CCURectangle.width = 1;
                CCURectangle.height = 1;
                CCURectangle.width = 1;
                CCURectangle.height = 1;

                var CCUState = CCUBullet.states.create("hover");
                CCUState.properties.scale = 1.2;
                // Add legend
                chart.legend = new am4charts.Legend();

                // Add cursor
                chart.cursor = new am4charts.XYCursor();
                chart.cursor.fullWidthLineX = true;
                chart.cursor.xAxis = categoryAxis;
                chart.cursor.lineX.strokeOpacity = 0;
                chart.cursor.lineX.fill = am4core.color("#000");
                chart.cursor.lineX.fillOpacity = 0.1;

            }); // end am4core.ready()
        }
    </script>
</asp:Content>
