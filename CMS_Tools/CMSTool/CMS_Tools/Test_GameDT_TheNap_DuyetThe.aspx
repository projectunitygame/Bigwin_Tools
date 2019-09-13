<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_GameDT_TheNap_DuyetThe.aspx.cs" Inherits="CMS_Tools.Test_GameDT_TheNap_DuyetThe_" %>
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
                        Duyệt thẻ
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
            
            $('.page-toolbar').remove();
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
                                    var acceptCard = "<a class='btn btn-xs blue btn-circle btn-outline' onclick='AcceptCard(\"" + obj[0] + "\");'> Duyệt thẻ</a>";
                                    var deleteCard = "<a class='btn btn-xs red btn-circle btn-outline' onclick='DeleteCard(\"" + obj[0] + "\");'> Xóa thẻ</a>";

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
                                        "<td>" + obj[10] + "</td>" +
                                        "<td>" + acceptCard + deleteCard + "</td>" +
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
                                    var bVis = oTable.fnSettings().aoColumns[11].bVisible;
                                    oTable.fnSetColumnVis(11, bVis ? false : true);
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
        
        function DeleteCard(ID) {
            bootbox.confirm("Xác nhận xóa thẻ?", function (result) {
                if (result) {
                    $('.divLoading').fadeIn();
                    var json = {
                        "CardID": ID
                    };
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_GameAccount.ashx",
                        data: {
                            json: JSON.stringify(json),
                            type: 13
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
        function AcceptCard(ID) {
            bootbox.confirm("Xác nhận duyệt thẻ?", function (result) {
                if (result) {
                    $('.divLoading').fadeIn();
                    var json = {
                        "CardID": ID
                    };
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_GameAccount.ashx",
                        data: {
                            json: JSON.stringify(json),
                            type: 12
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
</script>
</asp:Content>