<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_GameData_GameID.aspx.cs" Inherits="CMS_Tools.Test_GameData_GameID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        Game ID
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
                            <thead><tr role="row"></tr></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
<script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        $('.page-toolbar').remove();
        $('#filterColumn').on('change', function () {
            if ($('#txtFindData').val() != "")
                TableEditable.init();
        });

        if ($('#ContentPlaceHolder_MAIN_ruleAdd').val() == "0")
            $('#tbl_datatable_new').remove();
        TableEditable.init();
        $('body').on('click', '.portlet > .portlet-title > .tools > a.reload', function (e) {
            TableEditable.init();
        });
    });
    var oTable = null;
    var colFilter = null;
    var _dataColumn;
    var nEditing = null;
    var nNew = false;
    var _dataType = null;
    var _action = null;
    var _pageSize = 10;
    var TableEditable = function () {
        var handleTable = function () {
            $(".divLoading").fadeOut(500);
            loadTable();
            var table = $('#tbl_datatable');
            function loadTable() {
                $.ajax({
                    type: "POST",
                    url: "Apis/Menu.ashx",
                    data: { type: 13, mid: AppManage.getURLParameter('m') },
                    dataType: 'json',
                    success: function (data) {
                        if (data.status == 5005) {
                            window.location.assign("login.aspx");
                            return;
                        }
                        if (data.status == 0) {
                            if (oTable != null) {
                                oTable.fnDeleteRow(nEditing);
                                nEditing = null;
                                nNew = false;
                                oTable.fnDestroy();
                            }
                            _dataColumn = data.columnName;
                            _dataType = $.parseJSON(data.dataType);
                            if (colFilter == null) {
                                $('#tbl_datatable thead tr').html("");
                                colFilter = _dataColumn;
                                $.each(_dataColumn, function (key, obj) {
                                    $('#tbl_datatable thead tr').append("<th>" + obj + "</th>");
                                });
                            }
                            var colHiden = [];
                            colHiden.push(_dataColumn.length - 1);
                            oTable = table.dataTable({
                                "lengthMenu": [
                                    [10, 50, 100, 500, -1],
                                    [10, 50, 100, 500, "All"]
                                ],
                                "pageLength": _pageSize,
                                "data": data.data,
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
                            jQuery('#tbl_datatable_wrapper .dataTables_filter input').addClass("form-control input-small");
                            jQuery('#tbl_datatable_wrapper .dataTables_length select').addClass("form-control input-small");
                            jQuery('#tbl_datatable_wrapper .dataTables_length select').select2();

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
            init: function () {
                handleTable();
            },
            reloadTable: function () {
                handleTable();
            }
        };

    }();

    function restoreRow(oTable, nRow) {
        var aData = oTable.fnGetData(nRow);
        var jqTds = $('>td', nRow);

        for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
            oTable.fnUpdate(aData[i], nRow, i, false);
        }
        oTable.fnDraw();
    }

    function editRow(oTable, nRow) {
        var aData = oTable.fnGetData(nRow);
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
                    jqTds[i].innerHTML = "<input " + (_dataType[i].attr == "readonly" && _action == "update" ? "readonly" : "") +" type='" + _dataType[i].type + "' class='form-control' value='" + aData[i] + "'>";
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

    function saveRow(oTable, nRow) {
        var aData = oTable.fnGetData(nRow);
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
        else if(_action == "update") {
            type = "21";
        }
        $.ajax({
            type: "POST",
            url: "Apis/Menu.ashx",
            data: { type: type, menuID: AppManage.getURLParameter("m"), data: JSON.stringify(data) },
            success: function (data) {
                if (data.status == 0) {
                    TableEditable.init();
                }
                else
                    bootbox.alert(data.msg);
            }
        });
    }


    $(document).ready(function () {
        $('#btnAddNew').click(function (e) {
            _action = "add";
            e.preventDefault();
            if (nEditing && nNew == false) {
                restoreRow(oTable, nEditing);
                nEditing = null;
            }
            if (nNew && nEditing) {
                bootbox.confirm("Bạn có chắc muốn lưu không?", function (result) {
                    if (result) {
                        saveRow(oTable, nEditing); // save
                        $(nEditing).find("td:first").html("Untitled");
                        nEditing = null;
                        nNew = false;
                    }
                    else {
                        oTable.fnDeleteRow(nEditing); // cancel
                        nEditing = null;
                        nNew = false;
                        return;
                    }
                });
            }
            else {
                var colNew = [];
                for (var i = 0; i < _dataColumn.length; i++) {
                    colNew[i] = "";
                }
                var aiNew = oTable.fnAddData(colNew);
                oTable.fnSort([[0, 'asc']]);
                var nRow = oTable.fnGetNodes(aiNew[0]);
                editRow(oTable, nRow);
                nEditing = nRow;
                nNew = true;
            }
        });

        $('#tbl_datatable').on('click', '.delete', function (e) {
            _action = "delete";
            e.preventDefault();
            var nRow = $(this).parents('tr')[0];
            var aData = oTable.fnGetData(nRow);
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

        $('#tbl_datatable').on('click', '.cancel', function (e) {
            e.preventDefault();
            if (nNew) {
                oTable.fnDeleteRow(nEditing);
                nEditing = null;
                nNew = false;
            } else {
                restoreRow(oTable, nEditing);
                nEditing = null;
            }
        });

        $('#tbl_datatable').on('click', '.edit', function (e) {
            e.preventDefault();
            if (nNew && nEditing) {
                bootbox.confirm("Bạn có chắc muốn lưu không?", function (result) {
                    if (result) {
                        saveRow(oTable, nEditing); // save
                        $(nEditing).find("td:first").html("Untitled");
                        nEditing = null;
                        nNew = false;
                    }
                    else {
                        oTable.fnDeleteRow(nEditing); // cancel
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
                    restoreRow(oTable, nEditing);
                    editRow(oTable, nRow);
                    nEditing = nRow;
                } else if (nEditing == nRow && this.innerHTML == "Save") {
                    /* Editing this row and want to save it */
                    saveRow(oTable, nEditing);
                    //nEditing = null;
                    //alert("Updated! Do not forget to do some ajax to sync with backend :)");
                } else {
                    /* No edit in progress - let's start one */
                    editRow(oTable, nRow);
                    nEditing = nRow;
                }              
            }
        });
    });
</script>
</asp:Content>
