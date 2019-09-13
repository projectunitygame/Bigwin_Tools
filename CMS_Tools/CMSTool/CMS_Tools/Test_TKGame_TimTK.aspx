<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_TKGame_TimTK.aspx.cs" Inherits="CMS_Tools.Test_TaiKhoanGame" %>
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
        .table-responsive td, .table-responsive th{
            text-align:center;
        }
        table thead tr, table tfoot tr {
            background: #1871af;
            color: #FFF;
            border: 1px solid #1871af;
            font-weight: 600;
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
                        Thông tin player
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
                        <div class="col-md-3" style="margin-bottom: 10px;">
                        	<label class="control-label label-balance">Chọn lọc dữ liệu theo cột</label>
                            <select id="filterColumn" class="form-control">
                                <option value="AccountID">ID tài khoản</option>
                                <option value="Username">Tên đăng nhập</option>
                                <!--<option value="UserType">UserType</option>-->
                                <option value="DisplayName">Tên hiển thị</option>
                                <option value="Gold">Số tiền hiện tại</option>
                                <!--<option value="CreatedTime">Ngày tạo</option>-->
                                <option value="Tel">Số điện thoại</option>
                                <!--<option value="LockedGold">LockedGold</option>
                                <option value="IsBlocked">IsBlocked</option>
                                <option value="IsMute">IsMute</option>-->
                            </select>
                        </div>
                        <div class="col-md-3" style="margin-bottom: 10px;">
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
    <!-----From update customer------>
    <div id="modal_history_account" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title" id="title_task">
                                <i class="fa fa-edit"></i> Lịch sử người chơi</h4>
                        </div>
                        <div class="form-body">
                            <ul id="myTabs" class="nav nav-tabs" role="tablist">
                                    <!--<li role="presentation" class="active"><a href="#hPlay" id="history-play" aria-controls="hPlay" role="tab" data-toggle="tab" aria-expanded="false" >Lịch sử chơi</a></li>
                                    <li role="presentation" class=""><a href="#hBalance" role="tab" id="history-balance" aria-controls="hBalance" data-toggle="tab" aria-expanded="true">Lịch sử số dư</a></li>
                                    <li role="presentation" class=""><a href="#hLog" role="tab" id="history-log" aria-controls="hLog" data-toggle="tab" aria-expanded="false" >Lịch sử đăng nhập</a></li>-->
                                    <li role="presentation" class="active"><a href="#hchargeLog" role="tab" id="history-chargelog" aria-controls="hLog" data-toggle="tab" aria-expanded="false" ">Lịch sử nạp tiền</a></li>
                                    <li role="presentation" class=""><a href="#hcashoutLog" role="tab" id="history-cashoutlog" aria-controls="hLog" data-toggle="tab" aria-expanded="false"">Lịch sử đổi</a></li>
                                </ul>
                             <div id="myTabContent" class="tab-content scrollbar1" style="overflow: hidden; outline: none;" tabindex="5000">
                                <!--<div role="tabpanel" class="tab-pane fade table-responsive active in" aria-labelledby="history-play" id="hPlay">
                                        
                                </div>

                                <div role="tabpanel" class="tab-pane fade table-responsive" aria-labelledby="history-balance" id="hBalance">

                                </div>
                                <div role="tabpanel" class="tab-pane fade table-responsive" aria-labelledby="history-log" id="hLog">
                                        
                                </div>-->
                                <div role="tabpanel" class="tab-pane fade table-responsive active in" aria-labelledby="history-chargelog" id="hchargeLog">
                                    <table id="tbl-hchargeLog" class="table table-responsive">
                                        <thead></thead>
                                        <tbody></tbody>
                                    </table>        
                                </div>

                                <div role="tabpanel" class="tab-pane fade table-responsive" aria-labelledby="history-cashoutlog" id="hcashoutLog">
                                    <table id="tbl-hcashoutLog" class="table table-responsive">
                                        <thead></thead>
                                        <tbody></tbody>
                                    </table>  
                                </div>
                            </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn dark btn-outline">Hủy</button>
                    </div>
            </div>
        </div>
    </div>  

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script src="assets/global/plugins/Base64JS.js"></script>
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script type="text/javascript">
        var colFilter = null;
        jQuery(document).ready(function () {
            $('#btnAddAction').remove();

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
                    param.push($('#filterColumn').val() != null ? $('#filterColumn').val() : 'AccountID');//@2
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
                                    //$('#filterColumn').html(selectCol);
                                    //if ($('#filterColumn').val() == "")
                                    //    $('#filterColumn').val("AccountID");
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
                                    var linkLock = "<a class='btn btn-xs red btn-circle btn-outline' onclick='LockAcountGame(\"" + obj[0] +"\");'> Khóa</a>";
                                    if (obj[8] == "True")
                                        linkLock = "<a class='btn btn-xs default btn-circle btn-outline' onclick='UnlockAcountGame(\"" + obj[0] + "\");'> Mở khóa</a>";
                                    var lockChat = "<a class='btn btn-xs yellow btn-circle btn-outline' onclick='LockChatAcountGame(\"" + obj[0] + "\");'> Khóa chat</a>";
                                    if (obj[9] == "True")
                                        lockChat = "<a class='btn btn-xs default btn-circle btn-outline' onclick='UnlockChatAcountGame(\"" + obj[0] + "\");'> Mở khóa chat</a>";
                                    var hisAccount = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='ShowHistoryAccount(\"" + obj[0] + "\");'> Xem lịch sử</a>";
                                    var addMoney = "<a class='btn btn-xs green btn-circle btn-outline' onclick='AddMoney(\"" + obj[0] + "\");'> Nạp tiền</a>";
                                    $('#tbl_datatable tbody').append("<tr>" +
                                        "<td>" + obj[0] + "</td>" +
                                        "<td>" + obj[1] + "</td>" +
                                        "<td>" + obj[2] + "</td>" +
                                        "<td>" + obj[3] + "</td>" +
                                        "<td>" + obj[4] + "</td>" +
                                        "<td>" + obj[5] + "</td>" +
                                        "<td>" + obj[6] + "</td>" +
                                        "<td>" + obj[7] + "</td>" +
                                        "<td>" + obj[8] + "</td>" +
                                        "<td>" + obj[9] + "</td>" +
                                        "<td>" + linkLock + lockChat + hisAccount + addMoney + "</td>" +
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

                                var bVis = oTable.fnSettings().aoColumns[8].bVisible;
                                oTable.fnSetColumnVis(8, bVis ? false : true);
                                var bVis = oTable.fnSettings().aoColumns[9].bVisible;
                                oTable.fnSetColumnVis(9, bVis ? false : true);
                                if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                                    var bVis = oTable.fnSettings().aoColumns[10].bVisible;
                                    oTable.fnSetColumnVis(10, bVis ? false : true);
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

        function AddMoney(ID) {
            bootbox.prompt({
                size: "small",
                title: "Nhập số tiền cộng cho User?",
                callback: function (result) {
                    if (result !== null) {
                        var json = {
                            "UserID": ID,
                            "Amount": result
                        }
                        POST_DATA("Apis/API_GameAccount.ashx", {
                            type: 20,
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

        function ShowHistoryAccount(ID) {
            $('#history-chargelog').click();
            var paramTopUp = [];
            var paramCashOut = [];
            paramTopUp.push(ID);
            paramCashOut.push(ID);
            $(".divLoading").fadeIn();
            $.ajax({
                type: "POST",
                url: "Apis/Menu.ashx",
                data: {
                    type: 13,
                    mid: 105,
                    p: JSON.stringify(paramTopUp)
                },
                dataType: 'json',
                success: function (res) {
                    if (res.status == 5005) {
                        window.location.assign("login.aspx");
                        return;
                    }
                    if (res.status == 0) {
                        $('#tbl-hchargeLog thead').html('');
                        $('#tbl-hchargeLog tbody').html('');
                        var strHead = '';
                        var strBody = '';
                        $.each(res.columnName, function (i, obj) {
                            strHead += '<th>' + obj +'</th>';
                        });
                        $.each(res.data, function (i, obj) {
                            strBody += '<tr>';
                            $.each(obj, function (i, subObj) {
                                strBody += '<td>' + subObj + '</td>';
                            });
                            strBody += '</tr>';
                        });
                        $('#tbl-hchargeLog thead').html(strHead);
                        $('#tbl-hchargeLog tbody').html(strBody);
                        $('#tbl-hchargeLog tbody tr td:last-child').remove();
                    }
                },
                complete: function () {
                    $(".divLoading").fadeOut(500);
                }
            });
            $.ajax({
                type: "POST",
                url: "Apis/Menu.ashx",
                data: {
                    type: 13,
                    mid: 106,
                    p: JSON.stringify(paramCashOut)
                },
                dataType: 'json',
                success: function (res) {
                    if (res.status == 5005) {
                        window.location.assign("login.aspx");
                        return;
                    }
                    if (res.status == 0) {
                        $('#tbl-hcashoutLog thead').html('');
                        $('#tbl-hcashoutLog tbody').html('');
                        var strHead = '';
                        var strBody = '';
                        $.each(res.columnName, function (i, obj) {
                            strHead += '<th>' + obj + '</th>';
                        });
                        $.each(res.data, function (i, obj) {
                            strBody += '<tr>';
                            $.each(obj, function (i, subObj) {
                                strBody += '<td>' + subObj + '</td>';
                            });
                            strBody += '</tr>';
                        });
                        $('#tbl-hcashoutLog thead').html(strHead);
                        $('#tbl-hcashoutLog tbody').html(strBody);
                        $('th:last-child').remove();
                        $('#tbl-hcashoutLog tbody tr td:last-child').remove();
                    }
                }
            });
           
            $('#modal_history_account').modal('show');
        }

        function LockAcountGame(accountID){

            bootbox.prompt({
                title: "Ghi chú nội dung khóa!",
                centerVertical: true,
                callback: function (result) {
                    if (result === null) {
                        // Prompt dismissed
                    } else {
                        // result has a value
                        $('.divLoading').fadeIn();
                        var json = {
                            "AccountID": accountID,
                            "Reason": result
                        }
                        POST_DATA("Apis/API_GameAccount.ashx", {
                            type: 1,
                            json: JSON.stringify(json)
                        }, function (res) {
                                if (res.status == 1)
                                    TableEditable.init();
                                else
                                    bootbox.alert(res.msg);
                            $(".divLoading").fadeOut(500);

                        });
                    }

                }
            });
            
        } 

        function UnlockAcountGame(accountID) {
            bootbox.confirm("Xác nhận mở khóa tài khoản?", function (result) {
                if (result) {
                    $('.divLoading').fadeIn();
                    var json = {
                        "AccountID": accountID
                    }
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_GameAccount.ashx",
                        data: {
                            json: JSON.stringify(json),
                            type: 2
                        },
                        dataType: 'json',
                        success: function (res) {
                            if (res.status == 1)
                                TableEditable.init();
                            else
                                bootbox.alert(res.msg);
                            $(".divLoading").fadeOut(500);
                        }
                    });
                }
            });
        } 

        function LockChatAcountGame(accountID) {

            bootbox.prompt({
                title: "Ghi chú nội dung khóa!",
                centerVertical: true,
                callback: function (result) {
                    if (result === null) {
                        // Prompt dismissed
                    } else {
                        // result has a value
                        $('.divLoading').fadeIn();
                        var json = {
                            "AccountID": accountID,
                            "Reason": result
                        }
                        POST_DATA("Apis/API_GameAccount.ashx", {
                            type: 3,
                            json: JSON.stringify(json)
                        }, function (res) {
                            if (res.status == 1)
                                TableEditable.init();
                            else
                                bootbox.alert(res.msg);
                            $(".divLoading").fadeOut(500);

                        });
                    }

                }
            });

        }

        function UnlockChatAcountGame(accountID) {
            bootbox.confirm("Xác nhận mở khóa tài khoản?", function (result) {
                if (result) {
                    $('.divLoading').fadeIn();
                    var json = {
                        "AccountID": accountID
                    }
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_GameAccount.ashx",
                        data: {
                            json: JSON.stringify(json),
                            type: 4
                        },
                        dataType: 'json',
                        success: function (res) {
                            if (res.status == 1)
                                TableEditable.init();
                            else
                                bootbox.alert(res.msg);
                            $(".divLoading").fadeOut(500);
                        }
                    });
                }
            });
        } 
</script>
</asp:Content>
