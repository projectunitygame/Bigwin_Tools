<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_GameDT_CauHinhBotTaiXiu.aspx.cs" Inherits="CMS_Tools.Test_GameDT_CauHinhBotTaiXiu" %>
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
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        Cấu hình bot
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                        <a href="javascript:;" class="reload" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
                    
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
    <div class="row" <%--style="display:none"--%>>
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        Bet value
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                        <a href="javascript:;" class="reload" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-md-3" style="margin-bottom: 10px;">
                            <label class="control-label label-balance">Chọn cấp vip</label>
                            <select id="filterColumn" class="form-control">
                                <option value='2' selected>Bot giàu</option>
                                <option value='1'>Bot thường</option>
                                <option value='0'>Bot nghèo</option>
                            </select>
                        </div>
                    </div>
                    <div class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable2"
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
    <!-----From create bet value------>
    <div id="modal_config_bot" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_config_bot" class="form-horizontal" novalidate="novalidate">
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title" id="title_task">
                                <i class="fa fa-edit"></i> Cấu hình bot tài xỉu</h4>
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
                           <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           MinBot: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtMinBot" type="text" class="form-control" name="MinBot"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           MaxBot: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtMaxBot" type="text" class="form-control" name="MaxBot"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-12">
                                           (Lưu ý: MaxBot = NumRichBot + NumNormalBot+ NumPoorBot)
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           NumRichBot: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtNumRichBot" type="text" class="form-control" name="NumRichBot"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           NumNormalBot: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtNumNormalBot" type="text" class="form-control" name="NumNormalBot"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           NumPoorBot: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtNumPoorBot" type="text" class="form-control" name="NumPoorBot"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           VipChangeRate: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtVipChangeRate" type="text" class="form-control" name="VipChangeRate"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           NorChangeRate: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtNorChangeRate" type="text" class="form-control" name="NorChangeRate"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           PoorChangeRate: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtPoorChangeRate" type="text" class="form-control" name="PoorChangeRate"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           MinTimeChange: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtMinTimeChange" type="text" class="form-control" name="MinTimeChange"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                           MaxTimeChange: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtMaxTimeChange" type="text" class="form-control" name="MaxTimeChange"/>
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
        jQuery(document).ready(function () {

            FormValidation.init();

            $('.page-toolbar').remove();

            //$('#txtFindData').on('keyup', function (e) {
            //    if (e.keyCode == 13) {
            //        TableEditable.init();
            //    }
            //});

            //$('#btnFindData').click(function () {
            //    if ($('#txtFindData').val() != "")
            //        TableEditable.init();
            //});

            //$('#filterColumn').on('change', function () {
            //    if ($('#txtFindData').val() != "")
            //        TableEditable.init();
            //});

            $('#filterColumn').on('change', function () {
                    TableEditable.init();
            });

            //load danh sach dai ly
            TableEditable.init();
            $('body').on('click', '.portlet > .portlet-title > .tools > a.reload', function (e) {
                TableEditable.init();
            });

        });

        var _pageSize = 50,
            oTable = null,
            oTable2 = null,
            colFilter = null,
            colFilter2 = null,
            _dataColumn = null,
            _dataColumn2 = null,
            nEditing = null,
            nNew = false,
            _dataType = null,
            _action = null;

        var TableEditable = function () {
            var botConfigTable = function () {
                var table = $('#tbl_datatable');
                loadTable();
                function loadTable() {
                    //$('.divLoading').fadeIn();
                    var param = [];
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 99,
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
                                    var func = 'SetConfigBot(' + obj[0] + ',"' + obj[1] + '","' + obj[2] + '","' + obj[3] + '","'
                                        + obj[4] + '","' + obj[5] + '","' + obj[6] + '","' + obj[7] + '","' + obj[8] + '","' + obj[9] + '");';
                                    var configBot = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='" + func + "'> Cấu hình</a>";

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
                                        "<td>" + configBot + "</td>" +
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
                        
                    });
                }
            },
                betValueTable = function () {
                    var table = $('#tbl_datatable2');
                    $('.divLoading').fadeIn();
                    loadTable();
                    function loadTable() {
                        var param = [];
                        param.push($('#filterColumn').val())
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 100,
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
                                        oTable2.fnDeleteRow(nEditing);
                                        nEditing = null;
                                        nNew = false;
                                        oTable2.fnDestroy();
                                        //$('#tbl_datatable2 tbody').html("");
                                    }
                                    
                                    if (_dataColumn2 == null) {
                                        _dataColumn2 = data.columnName;
                                        _dataType = $.parseJSON(data.dataType);
                                        
                                        var selectCol = "<option value=''>Select...</option>";
                                        $('#tbl_datatable2 thead tr').html("");
                                        //$.each(_dataColumn2, function (key, obj) {
                                        //    $('#tbl_datatable2 thead tr').append("<th>" + obj + "</th>");
                                        //	if (key < _dataColumn2.length - 1)
                                        //		selectCol += "<option value='" + obj + "'>" + obj + "</option>";
                                        //});
                                        var strHtmlColName = "";
                                        $.each(_dataColumn2, function (key, obj) {
                                            strHtmlColName += "<td>" + obj + "</td>";
                                            if (key < _dataColumn2.length - 1)
                                                selectCol += "<option value='" + obj + "'>" + obj + "</option>";
                                        });
                                        //console.log("strHtmlColName" + strHtmlColName);
                                        $('#tbl_datatable2 thead tr').append(strHtmlColName);
                                        console.log(data.data.length);
                                        if (data.data.length > 20) {
                                            $('#tbl_datatable2 tfoot tr').append(strHtmlColName);
                                        }
                                        //$('#filterColumn').html(selectCol);
                                        //if ($('#filterColumn').val() == "")
                                        //    $('#filterColumn').val("AccountID");
                                    }
                                    else {
                                        $('#tbl_datatable2 tbody').html('');
                                        $('#tbl_datatable2 tfoot tr').empty();
                                        if (data.data.length > 20) {
                                            var strHtmlColName = "";
                                            $.each(_dataColumn2, function (key, obj) {
                                                strHtmlColName += "<td>" + obj + "</td>";
                                            });
                                            $('#tbl_datatable2 tfoot tr').append(strHtmlColName);
                                        }
                                    }
                                    _dataTable = [];
                                    for (var i = 0; i < data.data.length; i++) {
                                        var obj = data.data[i];
                                        var func = 'SetConfigBot(' + obj[0] + ',"' + obj[1] + '","' + obj[2] + '","' + obj[3] + '","'
                                            + obj[4] + '","' + obj[5] + '","' + obj[6] + '","' + obj[7] + '","' + obj[8] + '","' + obj[9] + '");';
                                        var configBot = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='" + func + "'> Cấu hình</a>";

                                        switch (obj[2]) {
                                            case "2":
                                                obj[2] = "Bot giàu";
                                                break;
                                            case "1":
                                                obj[2] = "Bot thường";
                                                break;
                                            case "0":
                                                obj[2] = "Bot nghèo";
                                                break;
                                            default:
                                                
                                        }
                                        $('#tbl_datatable2 tbody').append("<tr>" +
                                            "<td>" + obj[0] + "</td>" +
                                            "<td>" + obj[1] + "</td>" +
                                            "<td>" + obj[2] + "</td>" +
                                            "<td>"+ obj[3] +"</td>" +
                                            "<td>"+ obj[4] +"</td>" +
                                            "</tr>");
                                    }
                                    var colHiden = [];
                                    colHiden.push(_dataColumn2.length - 1);
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

                                    //var bVis = oTable2.fnSettings().aoColumns[1].bVisible;
                                    //oTable2.fnSetColumnVis(1, bVis ? false : true);


                                    var tableWrapper = $("#tbl_datatable2_wrapper2");
                                    jQuery('#tbl_datatable2_wrapper2 .dataTables_filter input').addClass("form-control input-small"); // modify table search input
                                    jQuery('#tbl_datatable2_wrapper2 .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
                                    jQuery('#tbl_datatable2_wrapper2 .dataTables_length select').select2(); // initialize select2 dropdown

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
                    botConfigTable();
                    betValueTable();
                },
                reloadTable: function () {
                    botConfigTable();
                    betValueTable();
                }
            };
        }();

        function restoreRow(oTable2, nRow) {
            var aData = oTable2.fnGetData(nRow);
            var jqTds = $('>td', nRow);

            for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                oTable2.fnUpdate(aData[i], nRow, i, false);
            }
            oTable2.fnDraw();
        }

        function editRow(oTable2, nRow) {
            var aData = oTable2.fnGetData(nRow);
            var jqTds = $('>td', nRow);
            var f = false;
            for (var i = 0; i < aData.length - 1; i++) {
                if (_dataType[i].type == "hidden" || _dataType[i].type == "text") {
                    if (_dataType[i].attr == "date-picker") {
                        f = true;
                        var date = new Date();
                        var month = date.getMonth() + 1;
                        var dateString = month + "/" + date.getDate() + "/" + date.getFullYear();
                        if (aData[i] == "") {
                            aData[i] = dateString;
                        }
                        else {
                            var _d = new Date(aData[i]);
                            aData[i] = _d.getMonth() + 1 + "/" + _d.getDate() + "/" + _d.getFullYear();
                        }
                        jqTds[i].innerHTML = "<div class='date date-picker' style='width: 165px;' data-date='" + aData[i] + "'>" +
                            "<input type='" + _dataType[i].type + "' class='form-control input-small' style='float:left' readonly='' value='" + aData[i] + "'>" +
                            "<span class='input-group-btn' style='width: auto;'>" +
                            "<button class='btn default' type='button'>" +
                            "<i class='fa fa-calendar'></i>" +
                            "</button>" +
                            "</span>" +
                            "</div>";
                        //jqTds[i].innerHTML = "<input type='" + _dataType[i].type + "' class='form-control input-small' value='" + aData[i] + "'>";
                    }
                    else {
                        jqTds[i].innerHTML = "<input " + (_dataType[i].attr == "readonly" && _action == "update" ? "readonly" : "") + " type='" + _dataType[i].type + "' class='form-control' value='" + aData[i] + "'>";
                    }
                }
                else if (_dataType[i].type == "radio" || _dataType[i].type == "checkbox") {
                    jqTds[i].innerHTML = "<input type='" + _dataType[i].type + "' class='form-control' value='" + aData[i] + "'>";
                }
                else if (_dataType[i].type == "select") {
                    var c = "";
                    $.each(_dataType[i].data, function (key, obj) {
                        if (aData[i] == obj.value)
                            c += "<option value=" + obj.value + " selected='selected'>" + obj.name + "</option>";
                        else
                            c += "<option value=" + obj.value + ">" + obj.name + "</option>";
                    });
                    jqTds[i].innerHTML = "<select class='form-control'>" + c + "</select>";
                }
            }
            if (f) {
                $('.date-picker').datepicker({
                    rtl: App.isRTL(),
                    format: "mm/dd/yyyy",
                    autoclose: true
                });
            }
            jqTds[aData.length - 1].innerHTML = '<div style=\"width:105px;\"><a class="edit btn btn-xs red" href="">Save</a> <a class="cancel btn btn-xs default" href="">Cancel</a><div>';
        }

        function saveRow(oTable2, nRow) {
            var aData = oTable2.fnGetData(nRow);
            var jqInputs;
            _dataColumn.splice(_dataColumn.length - 1, 1);
            var data = [];
            var z = 0;
            var w = 0;
            for (var i = 0; i < aData.length - 1; i++) {
                var jqInputs;
                if (_dataType[i].type == "hidden" || _dataType[i].type == "text" || _dataType[i].type == "radio" || _dataType[i].type == "checkbox") {
                    jqInputs = $('input', nRow);
                    data[i] = jqInputs[z].value;
                    z++;
                }
                if (_dataType[i].type == "select") {
                    jqInputs = $('select', nRow);
                    data[i] = jqInputs[w].value;
                    w++;
                }
            }
            var type;
            if (_action == "add") {
                type = "20";
                if (_dataType[0].type == "hidden") {
                    data[0] = "0";
                    _dataColumn.splice(0, 1);
                    data.splice(0, 1);
                }
            }
            else if (_action == "update") {
                type = "21";
            }
            $.ajax({
                type: "POST",
                url: "Apis/Menu.ashx",
                data: { type: type, menuID: 100, data: JSON.stringify(data) },
                success: function (data) {
                    if (data.status == 0) {
                        TableEditable.init();
                    }
                    else
                        bootbox.alert(data.msg);
                }
            });
        }

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
        function SetConfigBot(MinBot, MaxBot, NumRichBot, NumNormalBot, NumPoorBot, VipChangeRate, NorChangeRate, PoorChangeRate, MinTimeChange, MaxTimeChange) {
            $('#txtMinBot').val(MinBot);
            $('#txtMaxBot').val(MaxBot);
            $('#txtNumRichBot').val(NumRichBot);
            $('#txtNumNormalBot').val(NumNormalBot);
            $('#txtNumPoorBot').val(NumPoorBot);
            $('#txtVipChangeRate').val(VipChangeRate);
            $('#txtNorChangeRate').val(NorChangeRate);
            $('#txtPoorChangeRate').val(PoorChangeRate);
            $('#txtMinTimeChange').val(MinTimeChange);
            $('#txtMaxTimeChange').val(MaxTimeChange);
            $('#modal_config_bot').modal('show');
        }
        function ConfigBot() {
            var json = {
                "MinBot": $('#txtMinBot').val(),
                "MaxBot": $('#txtMaxBot').val(),
                "NumRichBot": $('#txtNumRichBot').val(),
                "NumNormalBot": $('#txtNumNormalBot').val(),
                "NumPoorBot": $('#txtNumPoorBot').val(),
                "VipChangeRate": $('#txtVipChangeRate').val(),
                "NorChangeRate": $('#txtNorChangeRate').val(),
                "PoorChangeRate": $('#txtPoorChangeRate').val(),
                "MinTimeChange": $('#txtMinTimeChange').val(),
                "MaxTimeChange": $('#txtMaxTimeChange').val()
            }
            POST_DATA("Apis/API_GameAccount.ashx", {
                type: 18,
                json: JSON.stringify(json)
            }, function (res) {
                if (res.status == 1) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {
                            $('#modal_config_bot').modal('hide');
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
                var e = $("#form_config_bot"),
                    r = $(".alert-danger", e),
                    i = $(".alert-success", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        MinBot: {
                            number: !0,
                            required: !0
                        },
                        MaxBot: {
                            number: !0,
                            required: !0
                        },
                        NumRichBot: {
                            number: !0,
                            required: !0
                        },
                        NumNormalBot: {
                            number: !0,
                            required: !0
                        },
                        NumPoorBot: {
                            number: !0,
                            required: !0
                        },
                        VipChangeRate: {
                            number: !0,
                            required: !0
                        },
                        NorChangeRate: {
                            number: !0,
                            required: !0
                        },
                        PoorChangeRate: {
                            number: !0,
                            required: !0
                        },
                        MinTimeChange: {
                            number: !0,
                            required: !0
                        },
                        MaxTimeChange: {
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
                            ConfigBot();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        $(document).ready(function () {
            $('#tbl_datatable2').on('click', '.delete', function (e) {
                _action = "delete";
                e.preventDefault();
                var nRow = $(this).parents('tr')[0];
                var aData = oTable2.fnGetData(nRow);
                var id = aData[0];
                bootbox.confirm("Bạn có chắc muốn xóa không?", function (result) {
                    if (!result) {
                        return;
                    }
                    else {
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: { type: "22", menuID: AppManage.getURLParameter("m"), id: id },
                            success: function (data) {
                                if (data.status == 0) {
                                    TableEditable.init();
                                }
                                else
                                    bootbox.alert(data.msg);
                            }
                        });
                    }
                });
            });

            $('#tbl_datatable2').on('click', '.cancel', function (e) {
                e.preventDefault();
                if (nNew) {
                    oTable2.fnDeleteRow(nEditing);
                    nEditing = null;
                    nNew = false;
                } else {
                    restoreRow(oTable2, nEditing);
                    nEditing = null;
                }
            });

            $('#tbl_datatable2').on('click', '.edit', function (e) {
                e.preventDefault();
                if (nNew && nEditing) {
                    bootbox.confirm("Bạn có chắc muốn lưu không?", function (result) {
                        if (result) {
                            saveRow(oTable2, nEditing); // save
                            $(nEditing).find("td:first").html("Untitled");
                            nEditing = null;
                            nNew = false;
                        }
                        else {
                            oTable2.fnDeleteRow(nEditing); // cancel
                            nEditing = null;
                            nNew = false;
                        }
                    });
                }
                else {
                    _action = "update";
                    /* Get the row as a parent of the link that was clicked on */
                    var nRow = $(this).parents('tr')[0];
                    if (nEditing != null && nEditing != nRow) {
                        /* Currently editing - but not this row - restore the old before continuing to edit mode */
                        restoreRow(oTable2, nEditing);
                        editRow(oTable2, nRow);
                        nEditing = nRow;
                    } else if (nEditing == nRow && this.innerHTML == "Save") {
                        /* Editing this row and want to save it */
                        saveRow(oTable2, nEditing);
                        //nEditing = null;
                        //alert("Updated! Do not forget to do some ajax to sync with backend :)");
                    } else {
                        /* No edit in progress - let's start one */
                        editRow(oTable2, nRow);
                        nEditing = nRow;
                    }
                }
            });
        });
</script>
</asp:Content>