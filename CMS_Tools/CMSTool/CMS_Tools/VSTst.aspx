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
                                    <td>No</td>
                                    <td>AgencyID</td>
                                    <td>AgencyCode</td>
                                    <td>Email</td>
                                    <td>Phone</td>
                                    <td>DisplayName</td>
                                    <td>OwnerID</td>
                                    <td>Status</td>
                                    <td>IsActive</td>
                                    <td>IsLock</td>
                                    <td>DateCreated</td>
                                    <td>DateActive</td>
                                    <td>LastUpdate</td>
                                    <td>LastUpdate</td>
                                    <td>Balance_Bonus</td>
                                    <td>Balance_Lock</td>
                                    <td>LimitTransaction</td>
                                    <td>LimitTransactionDaily</td>
                                    <td>IsOTP</td>
                                    <td>IP</td>
                                    <td>EmailActive</td>
                                    <td>PhoneActive</td>
                                    <td>WrongPassword</td>
                                    <td>LockTimeLogin</td>
                                    <td>DateLogin</td>
                                    <td>CreatorID</td>
                                    <td>CreatorName</td>
                                    <td>Edit</td>
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
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_Agency" class="form-horizontal" novalidate="novalidate">
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
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group  margin-top-20">
                                        <label class="control-label col-md-3">
                                            Mã đại lý: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-9">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtAgencyCode" type="text" class="form-control" name="AgencyCode" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-3">
                                            Mật khẩu: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-6">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtPassword" type="text" class="form-control" name="password" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <a class="btn btn-primary" onclick="javascript:generate()"><i class="fa fa-lock" aria-hidden="true"></i>&nbsp;Tạo mới</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-3">
                                            Email:
                                        </label>
                                        <div class="col-md-9">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtEmail" type="text" class="form-control" name="email"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-3">
                                            Số điện thoại: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-9">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" style="width:100%;" id="txtPhone" class="form-control" name="Phone" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-3">
                                            Tên đại lý: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-9">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" style="width:100%;" id="txtAgencyName" class="form-control" name="AgencyName" />
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


    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script type="text/javascript">
        var colFilter = null;
        jQuery(document).ready(function () {
            $('#btnAddNew').html("<i class='fa fa-plus'></i> Tạo KH Mới");
            FormValidation.init();
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
                    param.push(_dateStart);//@0
                    param.push(_dateEnd);//@1
                    param.push($('#filterColumn').val() != null ? $('#filterColumn').val() : 'DateCreated');//@2
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
                                    //$('#tbl_datatable thead').html("<tr role='row'>" +
                                    //    "<td>No</td>" +
                                    //    "<td style='width:40px'>AgencyID</td>" +
                                    //    "<td>AgencyCode</td>" +
                                    //    "<td>Email</td>" +
                                    //    "<td>Phone</td>" +
                                    //    "<td>DisplayName</td>" +
                                    //    "<td>OwnerID</td>" +
                                    //    "<td>Email</td>" +
                                    //    "<td>Status</td>" +
                                    //    "<td>IsActive</td>" +
                                    //    "<td>IsLock</td>" +
                                    //    "<td>DateCreated</td>" +
                                    //    "<td>DateActive</td>" +
                                    //    "<td>LastUpdate</td>" +
                                    //    "<td>Balance_Bonus</td>" +
                                    //    "<td>Balance_Lock</td>" +
                                    //    "<td>LimitTransaction</td>" +
                                    //    "<td>LimitTransactionDaily</td>" +
                                    //    "<td>IsOTP</td>" +
                                    //    "<td>IP</td>" +
                                    //    "<td>EmailActive</td>" +
                                    //    "<td>PhoneActive</td>" +
                                    //    "<td>WrongPassword</td>" +
                                    //    "<td>LockTimeLogin</td>" +
                                    //    "<td>DateLogin</td>" +
                                    //    "<td>CreatorID</td>" +
                                    //    "<td>CreatorName</td>" +
                                    //    "<td style='width:200px'>Chỉnh sửa</td></tr>");
                                    //$('#tbl_datatable tbody').html("");
                                    //$('#tbl_datatable').on('click', ' tbody td .row-details', function () {
                                    //}).unbind('click');
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
                                        $('#filterColumn').val("DateCreated");
                                }
                                _dataTable = [];
                                for (var i = 0; i < data.data.length; i++) {
                                    //var obj = data.data[i];
                                    //$('#tbl_datatable tbody').append("<tr>" +
                                    //    "<td>" + obj[0] + "</td>" +
                                    //    "<td>" + obj[1] + "</td>" +
                                    //    "<td>" + obj[2] + "</td>" +
                                    //    "<td>" + obj[3] + "</td>" +
                                    //    "<td>" + obj[4] + "</td>" +
                                    //    "<td>" + obj[5] + "</td>" +
                                    //    "<td>" + obj[6] + "</td>" +
                                    //    "<td>" + obj[7] + "</td>" +
                                    //    "<td>" + obj[8] + "</td>" +
                                    //    "<td>" + obj[9] + "</td>" +
                                    //    "<td>" + obj[10] + "</td>" +
                                    //    "<td>" + (obj[11] == '1' ? "Kích Hoạt" : "Khóa") + "</td>" +
                                    //    "<td>" + obj[12] + "</td>" +
                                    //    "<td>" + obj[13] + "</td>" +
                                    //    "<td>" + obj[14] + "</td>" +
                                    //    "<td>" + obj[15] + "</td>" +
                                    //    "<td>" + obj[16] + "</td>" +
                                    //    "<td>" + obj[17] + "</td>" +
                                    //    "<td>" + obj[18] + "</td>" +
                                    //    "<td>" + obj[19] + "</td>" +
                                    //    "<td>" + obj[20] + "</td>" +
                                    //    "<td><a class='btn btn-xs blue edit' onclick='LockAgency(" + obj[0] + ");'> Khóa</a> " +
                                    //    "<a class='btn btn-xs green edit' onclick='GetURL(this);'> Xem</a></td>" +
                                    //    "</tr>");
                                }

                                function fnFormatDetails(oTable, nTr) {
                                    var aData = oTable.fnGetData(nTr);
                                    var sOut = '<table>';
                                    //sOut += '<tr><td colspan=2 style="text-align: center; background: #ccc;">THÔNG TIN KHÁCH HÀNG</td></tr>';
                                    //sOut += '<tr><td><i>ID:</i></td><td>' + aData[1] + '</td></tr>';
                                    //sOut += '<tr><td><i>Mã KH:</i></td><td>' + aData[2] + '</td></tr>';
                                    //sOut += '<tr><td><i>Tên CTY:</i></td><td>' + aData[3] + '</td></tr>';
                                    //sOut += '<tr><td><i>Mã Số Thuế:</i></td><td>' + aData[4] + '</td></tr>';
                                    //sOut += '<tr><td><i>Email:</i></td><td>' + aData[8] + '</td></tr>';
                                    //sOut += '<tr><td><i>Số Điện Thoại:</i></td><td>' + aData[9] + '</td></tr>';
                                    //sOut += '<tr><td><i>Liên Hệ:</i></td><td>' + aData[10] + '</td></tr>';
                                    //sOut += '<tr><td><i>Ngày Tạo:</i></td><td>' + aData[11] + '</td></tr>';
                                    //sOut += '<tr><td><i>Trạng Thái:</i></td><td>' + aData[12] + '</td></tr>';
                                    //sOut += '<tr><td colspan=2 style="text-align: center; background: #ccc;">ĐỊA CHỈ GIAO HÀNG:</td></tr>';
                                    //sOut += '<tr><td><i>Địa Chỉ 1:</i></td><td>' + aData[5] + '</td></tr>';
                                    //sOut += '<tr><td><i>Tỉnh Thành 1:</i></td><td>' + aData[6] + '</td></tr>';
                                    //sOut += '<tr><td><i>Quốc Gia 1:</i></td><td>' + aData[7] + '</td></tr>';
                                    //sOut += '<tr><td><i>Số KM 1:</i></td><td>' + aData[19] + '</td></tr>';
                                    //sOut += '<tr><td><i>Địa Chỉ 2:</i></td><td>' + aData[13] + '</td></tr>';
                                    //sOut += '<tr><td><i>Tỉnh Thành 2:</i></td><td>' + aData[14] + '</td></tr>';
                                    //sOut += '<tr><td><i>Quốc Gia 2:</i></td><td>' + aData[15] + '</td></tr>';
                                    //sOut += '<tr><td><i>Số KM 2:</i></td><td>' + aData[20] + '</td></tr>';
                                    //sOut += '<tr><td><i>Địa Chỉ 3:</i></td><td>' + aData[16] + '</td></tr>';
                                    //sOut += '<tr><td><i>Tỉnh Thành 3:</i></td><td>' + aData[17] + '</td></tr>';
                                    //sOut += '<tr><td><i>Quốc Gia 3:</i></td><td>' + aData[18] + '</td></tr>';
                                    //sOut += '<tr><td><i>Số KM 3:</i></td><td>' + aData[21] + '</td></tr>';
                                    //sOut += '</table>';
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

                                //an column
                                //var bVis = oTable.fnSettings().aoColumns[4].bVisible;
                                //oTable.fnSetColumnVis(4, bVis ? false : true);


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
                var e = $("#form_Agency"),
                    r = $(".alert-danger", e),
                    i = $(".alert-success", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        AgencyCode: {
                            minlength: 6,
                            required: !0
                        },
                        password: {
                            required: !0
                        },
                        Phone: {
                            maxlength: 10,
                            number: !0,
                            required: !0
                        },
                        AgencyName: {
                            required: !0
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
                            SubmitFormAgency();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        function SubmitFormAgency() {
            $('.divLoading').fadeIn();
            var json = {
                "CustomerID": $('#customerID').val(),
                "CompanyName": $('#txtCompanyName').val(),
                "TaxCode": $('#txtTaxCode').val(),
                "Address": $('#txtAddress').val(),
                "City": $('#selectProvince').val(),
                "Country": $('#selectCountry').val()
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

        function Update(customerID) {

            GetAgency(agencyID, function (agencyInfo) {
                if (agencyInfo.status == 0) {
                    var data = agencyInfo.data[0];
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
            //$('#customerID').val(0);
            //$('#txtCompanyName').val("");
            //$('#txtTaxCode').val("");
            //$('#txtAddress').val("");
            //$('#selectProvince').val(0);
            //$('#selectCountry').val(84);
            //$('#txtAddress1').val("");
            //$('#selectProvince1').val(0);
            //$('#selectCountry1').val(84);
            //$('#txtAddress2').val("");
            //$('#selectProvince2').val(0);
            //$('#selectCountry2').val(84);
            //$('#txtEmail').val("");
            //$('#txtPhone').val("");
            //$('#txtContact').val("");
            //$('#txtKM').val(0);
            //$('#txtKM1').val(0);
            //$('#txtKM2').val(0);
            //$('#selectLoaiDon').val(0);
            //$('#selectLoaiHinhSX').val(0);
            //$('#selectStatus').val(1);
            //$('.selectProvince').select2({
            //    showSearchInput: true
            //});
            //$('.selectCountry').select2({
            //    showSearchInput: true
            //});
            //$('#selectLoaiDon').select2({
            //    showSearchInput: true
            //});
            //$('#selectLoaiHinhSX').select2({
            //    showSearchInput: true
            //});

            $('#form_Agency').trigger('reset');

            $('.form-group').removeClass('has-success').removeClass('has-error');
            $('.form-group i').removeClass('fa-warning').removeClass('fa-check');
        }
        function randomPassword(length) {
            //var chars = "abcdefghijklmnopqrstuvwxyz!@#$%^&*()-+<>ABCDEFGHIJKLMNOP1234567890";
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOP1234567890";
            var pass = "";
            for (var x = 0; x < length; x++) {
                var i = Math.floor(Math.random() * chars.length);
                pass += chars.charAt(i);
            }
            return pass;
        }
        function generate() {
            $('#txtPassword').val(randomPassword(20));
        }
</script>