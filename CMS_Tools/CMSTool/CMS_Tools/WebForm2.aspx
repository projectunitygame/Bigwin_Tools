<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="CMS_Tools.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        Khách Hàng
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
                                <input type="text" class="form-control" placeholder="Date Range(MM/DD/YYYY)" disabled />
                                <span class="input-group-btn">
                                    <button class="btn default date-range-toggle" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-bottom: 10px;">
                            <select id="filterColumn" class="form-control"></select>
                        </div>
                        <div class="col-md-3" style="margin-bottom: 10px;">
                            <input type="text" class="form-control" id="txtFindData" placeholder="Search..." />
                        </div>
                        <div class="col-md-2" style="margin-bottom: 10px;">
                            <button id="btnFindData" type="button" class="btn green form-control"><i class="icon-magnifier"></i>Search</button>
                        </div>
                    </div>
                    <div id="sample_1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable"
                            aria-describedby="sample_1_info">
                            <thead>
                                <tr role="row">
                                    <td>ID</td>
                                    <td>Mã KH</td>
                                    <td>Tên CTY</td>
                                    <td>MST</td>
                                    <td>Địa Chỉ 1</td>
                                    <td>Tỉnh Thành 1</td>
                                    <td>Quốc Gia 1</td>
                                    <td>Email</td>
                                    <td>Số Điện Thoại</td>
                                    <td>Liên Hệ</td>
                                    <td>Ngày Tạo</td>
                                    <td>Trạng Thái</td>
                                    <td>Địa Chỉ 2</td>
                                    <td>Tỉnh Thành 2</td>
                                    <td>Quốc Gia 2</td>
                                    <td>Địa Chỉ 3</td>
                                    <td>Tỉnh Thành 3</td>
                                    <td>Quốc Gia 3</td>
                                    <td>KM</td>
                                    <td>KM1</td>
                                    <td>KM2</td>
                                    <td>Chỉnh sửa</td>
                                </tr>
                            </thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-----From update customer------>
    <div id="modal_customer" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog custom-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_Customer" class="form-horizontal" novalidate="novalidate">
                    <input type="hidden" id="customerID"/>
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title" id="title_task">
                                <i class="fa fa-edit"></i> QUẢN LÝ THÔNG TIN KHÁCH HÀNG</h4>
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
                            <h3 class="form-section">Thông tin liên hệ</h3>
                            <div class=row>
                            	<div class="col-md-6">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-4">
                                            Tên CTY <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtCompanyName" type="text" class="form-control" name="companyName" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-4">
                                            Mã Số Thuế
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtTaxCode" type="text" class="form-control"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-md-6">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Email
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtEmail" type="text" class="form-control" name="email" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Số Điện Thoại
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtPhone" type="text" class="form-control" name="phone"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-md-6">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Người Liên Hệ
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtContact" type="text" class="form-control"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                	<div class="form-group">
                                    	<label class="control-label col-md-4">
                                            Trạng Thái
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select id="selectStatus" class="form-control" name="province">
                                                    <option value="1">Kích hoạt</option>
                                                    <option value="0">Chưa kích hoạt</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-md-6">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Loại Đơn
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select style="width:100%;" id="selectLoaiDon" class="form-control" name="loaidon">
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                	<div class="form-group">
                                    	<label class="control-label col-md-4">
                                            Loại Hình Sản Xuất
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select style="width:100%;" id="selectLoaiHinhSX" class="form-control" name="loaihinhsx">  
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <h3 class="form-section">Địa chỉ giao hàng</h3>
                            <div class="row">
                            	<div class="col-md-4">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtAddress" type="text" class="form-control" placeholder="Địa chỉ 1"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select style="width:100%;" id="selectProvince" class="form-control selectProvince" name="province">
                                                    <option value="">Chọn tỉnh thành...</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select style="width:100%;" id="selectCountry" class="form-control selectCountry" name="country">
                                                    <option value="">Chọn Quốc Gia...</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <input id="txtKM" type="text" class="form-control" name="KM" placeholder="Km"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-md-4">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtAddress1" type="text" class="form-control" placeholder="Địa chỉ 2"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select style="width:100%;" id="selectProvince1" class="form-control selectProvince" name="province">
                                                    <option value="">Chọn tỉnh thành...</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select style="width:100%;" id="selectCountry1" class="form-control selectCountry" name="country">
                                                    <option value="">Chọn Quốc Gia...</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <input id="txtKM1" type="text" class="form-control" name="KM1" placeholder="Km"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-md-4">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtAddress2" type="text" class="form-control" placeholder="Địa chỉ 3"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select style="width:100%;" id="selectProvince2" class="form-control selectProvince" name="province">
                                                    <option value="">Chọn tỉnh thành...</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select style="width:100%;" id="selectCountry2" class="form-control selectCountry" name="country">
                                                    <option value="">Chọn Quốc Gia...</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                	<div class="form-group">
                                        <div class="col-md-12">
                                            <div class="input-icon right">
                                                <input id="txtKM2" type="text" class="form-control" name="KM2" placeholder="Km"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn dark btn-outline">Hủy</button>
                        <button type="submit" class="btn green">Đồng Ý</button>
                    </div>
                </form>
            </div>
        </div>
    </div>  



    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script type="text/javascript">
        var colFilter = null;
        jQuery(document).ready(function () {
            $('#btnAddNew').html("<i class='fa fa-plus'></i> Tạo KH Mới");
            FormValidation.init();
            GetCountry();
            GetProvince();
            GetLoaiDon();
            GetLoaiHinhSX();
            $('#btnAddNew').click(function () {
                ResetForm();
                $('#modal_customer').modal('show');
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
        var _pageSize = 10;
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
                    param.push(_dateStart);
                    param.push(_dateEnd);
                    param.push($('#filterColumn').val() != null ? $('#filterColumn').val() : 'CreateDate');
                    param.push($('#txtFindData').val());
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
                                    $('#tbl_datatable thead').html("<tr role='row'>" +
                                        "<td>ID</td>" +
                                        "<td style='width:40px'>Mã KH</td>" +
                                        "<td>Tên CTY</td>" +
                                        "<td>MST</td>" +
                                        "<td>Địa Chỉ 1</td>" +
                                        "<td>Tỉnh Thành 1</td>" +
                                        "<td>Quốc Gia 1</td>" +
                                        "<td>Email</td>" +
                                        "<td>Số Điện Thoại</td>" +
                                        "<td>Liên Hệ</td>" +
                                        "<td>Ngày Tạo</td>" +
                                        "<td>Trạng Thái</td>" + 
                                        "<td>Địa Chỉ 2</td>" +
                                        "<td>Tỉnh Thành 2</td>" +
                                        "<td>Quốc Gia 2</td>" +
                                        "<td>Địa Chỉ 3</td>" +
                                        "<td>Tỉnh Thành 3</td>" +
                                        "<td>Quốc Gia 3</td>" +
                                        "<td>KM</td>" +
                                        "<td>KM1</td>" +
                                        "<td>KM2</td>" +
                                        "<td style='width:200px'>Chỉnh sửa</td></tr>");
                                    $('#tbl_datatable tbody').html("");
                                    $('#tbl_datatable').on('click', ' tbody td .row-details', function () {
                                    }).unbind('click');
                                }
                                var _dataColumn = data.columnName;
                                if (colFilter == null) {
                                    var selectCol = "<option value=''>Select...</option>";
                                    $.each(_dataColumn, function (key, obj) {
                                        if (key < _dataColumn.length - 1)
                                            selectCol += "<option value='" + obj + "'>" + obj + "</option>";
                                    });
                                    $('#filterColumn').html(selectCol);
                                    if ($('#filterColumn').val() == "")
                                        $('#filterColumn').val("CreateDate");
                                }
                                _dataTable = [];
                              	for(var i = 0; i < data.data.length; i++){
                                	var obj = data.data[i];
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
                                    "<td>" + (obj[11] == '1' ? "Kích Hoạt" : "Khóa") + "</td>" +
                                    "<td>" + obj[12] + "</td>" +
                                    "<td>" + obj[13] + "</td>" +
                                    "<td>" + obj[14] + "</td>" +
                                    "<td>" + obj[15] + "</td>" +
                                    "<td>" + obj[16] + "</td>" +
                                    "<td>" + obj[17] + "</td>" +                                                                       
                                    "<td>" + obj[18] + "</td>" +
                                    "<td>" + obj[19] + "</td>" +
                                    "<td>" + obj[20] + "</td>" +
                                    "<td><a class='btn btn-xs blue edit' onclick='Update("+obj[0]+");'>Cập Nhật</a> " +
                                        "<a class='btn btn-xs green edit' onclick='GetURL(this);'>Chi Tiết</a></td>" +
                                    "</tr>");
                                }
                              
                              	function fnFormatDetails(oTable, nTr) {
                                    var aData = oTable.fnGetData(nTr);
                                    var sOut = '<table>';
                                    sOut += '<tr><td colspan=2 style="text-align: center; background: #ccc;">THÔNG TIN KHÁCH HÀNG</td></tr>';
                                    sOut += '<tr><td><i>ID:</i></td><td>' + aData[1] + '</td></tr>';
                                    sOut += '<tr><td><i>Mã KH:</i></td><td>' + aData[2] + '</td></tr>';
                                    sOut += '<tr><td><i>Tên CTY:</i></td><td>' + aData[3] + '</td></tr>';
                                    sOut += '<tr><td><i>Mã Số Thuế:</i></td><td>' + aData[4] + '</td></tr>';
                                    sOut += '<tr><td><i>Email:</i></td><td>' + aData[8] + '</td></tr>';
                                    sOut += '<tr><td><i>Số Điện Thoại:</i></td><td>' + aData[9] + '</td></tr>';
                                    sOut += '<tr><td><i>Liên Hệ:</i></td><td>' + aData[10] + '</td></tr>';
                                    sOut += '<tr><td><i>Ngày Tạo:</i></td><td>' + aData[11] + '</td></tr>';
                                    sOut += '<tr><td><i>Trạng Thái:</i></td><td>' + aData[12] + '</td></tr>';
                                  	sOut += '<tr><td colspan=2 style="text-align: center; background: #ccc;">ĐỊA CHỈ GIAO HÀNG:</td></tr>';
                                  	sOut += '<tr><td><i>Địa Chỉ 1:</i></td><td>' + aData[5] + '</td></tr>';
                                    sOut += '<tr><td><i>Tỉnh Thành 1:</i></td><td>' + aData[6] + '</td></tr>';
                                    sOut += '<tr><td><i>Quốc Gia 1:</i></td><td>' + aData[7] + '</td></tr>';
                                    sOut += '<tr><td><i>Số KM 1:</i></td><td>' + aData[19] + '</td></tr>';
                                    sOut += '<tr><td><i>Địa Chỉ 2:</i></td><td>' + aData[13] + '</td></tr>';
                                    sOut += '<tr><td><i>Tỉnh Thành 2:</i></td><td>' + aData[14] + '</td></tr>';
                                    sOut += '<tr><td><i>Quốc Gia 2:</i></td><td>' + aData[15] + '</td></tr>';
                                    sOut += '<tr><td><i>Số KM 2:</i></td><td>' + aData[20] + '</td></tr>';
                                    sOut += '<tr><td><i>Địa Chỉ 3:</i></td><td>' + aData[16] + '</td></tr>';
                                    sOut += '<tr><td><i>Tỉnh Thành 3:</i></td><td>' + aData[17] + '</td></tr>';
                                    sOut += '<tr><td><i>Quốc Gia 3:</i></td><td>' + aData[18] + '</td></tr>';
                                    sOut += '<tr><td><i>Số KM 3:</i></td><td>' + aData[21] + '</td></tr>';
                                    sOut += '</table>';
                                    return sOut;
                                }
                              	var nCloneTh = document.createElement('th');
                                var nCloneTd = document.createElement('td');
                                nCloneTd.innerHTML = '<span class="row-details row-details-close"></span>';

                                $('#tbl_datatable thead tr').each(function () {
                                    this.insertBefore(nCloneTh, this.childNodes[0]);
                                });

                                $('#tbl_datatable tbody tr').each(function () {
                                    this.insertBefore(nCloneTd.cloneNode(true), this.childNodes[0]);
                                });

                                $('#tbl_datatable').on('click', ' tbody td .row-details', function () {
                                    var nTr = $(this).parents('tr')[0];
                                    if (oTable.fnIsOpen(nTr)) {
                                        $(this).addClass("row-details-close").removeClass("row-details-open");
                                        oTable.fnClose(nTr);
                                    }
                                    else {
                                        $(this).addClass("row-details-open").removeClass("row-details-close");
                                        oTable.fnOpen(nTr, fnFormatDetails(oTable, nTr), 'details');
                                    }
                                    tableWrapper.find(".dataTables_length select").select2({
                                        showSearchInput: false
                                    });
                                });
                              
                              
                                var colHiden = [];
                                oTable = table.dataTable({
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

                                var bVis = oTable.fnSettings().aoColumns[4].bVisible;
                                oTable.fnSetColumnVis(4, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[5].bVisible;
                                oTable.fnSetColumnVis(5, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[6].bVisible;
                                oTable.fnSetColumnVis(6, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[7].bVisible;
                                oTable.fnSetColumnVis(7, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[8].bVisible;
                                oTable.fnSetColumnVis(8, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[9].bVisible;
                                //oTable.fnSetColumnVis(9, bVis ? false : true);
                                //bVis = oTable.fnSettings().aoColumns[10].bVisible;
                                //oTable.fnSetColumnVis(10, bVis ? false : true);
                                //bVis = oTable.fnSettings().aoColumns[11].bVisible;
                                oTable.fnSetColumnVis(11, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[12].bVisible;
                                oTable.fnSetColumnVis(12, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[13].bVisible;
                                oTable.fnSetColumnVis(13, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[14].bVisible;
                                oTable.fnSetColumnVis(14, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[15].bVisible;
                                oTable.fnSetColumnVis(15, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[16].bVisible;
                                oTable.fnSetColumnVis(16, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[17].bVisible;
                                oTable.fnSetColumnVis(17, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[18].bVisible;
                                oTable.fnSetColumnVis(18, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[19].bVisible;
                                oTable.fnSetColumnVis(19, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[20].bVisible;
                                oTable.fnSetColumnVis(20, bVis ? false : true);
                                bVis = oTable.fnSettings().aoColumns[21].bVisible;
                                oTable.fnSetColumnVis(21, bVis ? false : true);

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
                var e = $("#form_Customer"),
                    r = $(".alert-danger", e),
                    i = $(".alert-success", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        companyName: {
                            minlength: 2,
                            required: !0
                        },
                        email: {
                            email: !0
                        },
                        phone: {
                            maxlength: 10,
                            number: !0
                        }
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
                        SubmitFormCustomer();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        function SubmitFormCustomer() {
            $('.divLoading').fadeIn();
            var json = {
                "CustomerID": $('#customerID').val(),
                "CompanyName": $('#txtCompanyName').val(),
                "TaxCode": $('#txtTaxCode').val(),
                "Address": $('#txtAddress').val(),
                "City": $('#selectProvince').val(),
                "Country": $('#selectCountry').val(),
                "Address1": $('#txtAddress1').val(),
                "City1": $('#selectProvince1').val(),
                "Country1": $('#selectCountry1').val(),
                "Address2": $('#txtAddress2').val(),
                "City2": $('#selectProvince2').val(),
                "Country2": $('#selectCountry2').val(),
                "Email": $('#txtEmail').val(),
                "Phone": $('#txtPhone').val(),
                "Contact": $('#txtContact').val(),
                "Status": $('#selectStatus').val(),
                "KM": $('#txtKM').val(),
                "KM1": $('#txtKM1').val(),
                "KM2": $('#txtKM2').val(),
                "Loaidon_ID": $('#selectLoaiDon').val(),
                "LoaiHinhSX_ID": $('#selectLoaiHinhSX').val()
            };
            $.ajax({
                type: "POST",
                url: "Apis/API_Customer.ashx",
                data: {
                    type: $('#customerID').val() == 0 ? 4000 : 4001,
                    mid: AppManage.getURLParameter('m'),
                    json: JSON.stringify(json)
                },
                dataType: 'json',
                success: function (data) {
                    $(".divLoading").fadeOut(500);
                    $('#modal_customer').modal('hide');
                    if (data.status == 0) {
                        TableEditable.init();
                    }
                    else {
                        bootbox.alert({
                            message: data.msg,
                            callback: function () {
                            }
                        });
                    }
                }
            });
        }

        function GetCountry() {
            $.ajax({
                type: "POST",
                url: "Apis/API_Customer.ashx",
                data: {
                    type: 4006,
                    mid: AppManage.getURLParameter('m')
                },
                dataType: 'json',
                success: function (data) {
                    $('.selectCountry').html("<option value='0'>Chọn Quốc Gia...</option>");
                    $.each(data.data, function (key, obj) {
                        $('.selectCountry').append("<option value='"+obj.CountryID+"'>"+obj.CountryName+"</option>");
                    });
                    $('.selectCountry').val(84);
                    $('.selectCountry').select2({
                        showSearchInput: true
                    });
                }
            });
        }

        function GetProvince() {
            $.ajax({
                type: "POST",
                url: "Apis/API_Customer.ashx",
                data: {
                    type: 4005,
                    mid: AppManage.getURLParameter('m')
                },
                dataType: 'json',
                success: function (data) {
                    $('.selectProvince').html("<option value='0'>Chọn Tỉnh Thành...</option>");
                    $.each(data.data, function (key, obj) {
                        $('.selectProvince').append("<option value='" + obj.ProvinceID + "'>"+obj.ProvinceName+"</option>");
                    });
                    $('.selectProvince').select2({
                        showSearchInput: true
                    });
                }
            });
        }

        function GetLoaiDon() {
            $.ajax({
                type: "POST",
                url: "Apis/API_Customer.ashx",
                data: {
                    type: 4008,
                    mid: AppManage.getURLParameter('m')
                },
                dataType: 'json',
                success: function (data) {
                    $('#selectLoaiDon').html("<option value='0'>Chọn loại đơn...</option>");
                    $.each(data.data, function (key, obj) {
                        $('#selectLoaiDon').append("<option value='" + obj.LoaiDon_ID + "'>"+obj.Name+"</option>");
                    });
                    $('#selectLoaiDon').select2({
                        showSearchInput: true
                    });
                }
            });
        }

        function GetLoaiHinhSX() {
            $.ajax({
                type: "POST",
                url: "Apis/API_Customer.ashx",
                data: {
                    type: 4010,
                    mid: AppManage.getURLParameter('m')
                },
                dataType: 'json',
                success: function (data) {
                    $('#selectLoaiHinhSX').html("<option value='0'>Chọn loại hình sx...</option>");
                    $.each(data.data, function (key, obj) {
                        $('#selectLoaiHinhSX').append("<option value='" + obj.LoaiHinhSX_ID + "'>"+obj.Name+"</option>");
                    });
                    $('#selectLoaiHinhSX').select2({
                        showSearchInput: true
                    });
                }
            });
        }

        function GetCustomer(id, callback) {
            $.ajax({
                type: "POST",
                url: "Apis/API_Customer.ashx",
                data: {
                    type: 4002,
                    mid: AppManage.getURLParameter('m'),
                    customerID: id
                },
                dataType: 'json',
                success: function (data) {
                    callback(data);
                }
            });
        }

        function Update(customerID) {
            
            GetCustomer(customerID, function (customerInfo) {
                if (customerInfo.status == 0) {
                    var data = customerInfo.data[0];
                    $('#customerID').val(data.CustomerID);
                    $('#txtCompanyName').val(data.CompanyName);
                    $('#txtTaxCode').val(data.TaxCode);
                    $('#txtAddress').val(data.Address);
                    $('#selectProvince').val(data.City);
                    $('#selectCountry').val(data.Country);
                    $('#txtAddress1').val(data.Address1);
                    $('#selectProvince1').val(data.City1);
                    $('#selectCountry1').val(data.Country1);
                    $('#txtAddress2').val(data.Address2);
                    $('#selectProvince2').val(data.City2);
                    $('#selectCountry2').val(data.Country2);
                    $('#txtEmail').val(data.Email);
                    $('#txtPhone').val(data.Phone);
                    $('#txtContact').val(data.Contact);
                    $('#selectStatus').val(data.Status);
                    $('#txtKM').val(data.KM);
                    $('#txtKM1').val(data.KM1);
                    $('#txtKM2').val(data.KM2);
                    $('#selectLoaiDon').val(data.LoaiDon_ID);
                    $('#selectLoaiHinhSX').val(data.LoaiHinhSX_ID);
                    $('#modal_customer').modal('show');
                    if (data.Country1 == 0)
                        $('#selectCountry1').val(84);
                    if (data.Country2 == 0)
                        $('#selectCountry2').val(84);
                    $('.selectProvince').select2({
                        showSearchInput: true
                    });
                    $('.selectCountry').select2({
                        showSearchInput: true
                    });
                    $('#selectLoaiDon').select2({
                        showSearchInput: true
                    });
                    $('#selectLoaiHinhSX').select2({
                        showSearchInput: true
                    });
                }
                else
                    bootbox.alert(customerInfo.msg);
            });
        }

        function ResetForm() {
            $('#customerID').val(0);
            $('#txtCompanyName').val("");
            $('#txtTaxCode').val("");
            $('#txtAddress').val("");
            $('#selectProvince').val(0);
            $('#selectCountry').val(84);
            $('#txtAddress1').val("");
            $('#selectProvince1').val(0);
            $('#selectCountry1').val(84);
            $('#txtAddress2').val("");
            $('#selectProvince2').val(0);
            $('#selectCountry2').val(84);
            $('#txtEmail').val("");
            $('#txtPhone').val("");
            $('#txtContact').val("");
            $('#txtKM').val(0);
            $('#txtKM1').val(0);
            $('#txtKM2').val(0);
            $('#selectLoaiDon').val(0);
            $('#selectLoaiHinhSX').val(0);
            $('#selectStatus').val(1);
            $('.selectProvince').select2({
                showSearchInput: true
            });
            $('.selectCountry').select2({
                showSearchInput: true
            });
            $('#selectLoaiDon').select2({
                showSearchInput: true
            });
            $('#selectLoaiHinhSX').select2({
                showSearchInput: true
            });
            $('.form-group').removeClass('has-success').removeClass('has-error');
            $('.form-group i').removeClass('fa-warning').removeClass('fa-check');
        }
    </script>
</body>
</html>
