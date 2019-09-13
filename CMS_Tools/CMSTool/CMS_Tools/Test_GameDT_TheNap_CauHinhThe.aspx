<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_GameDT_TheNap_CauHinhThe.aspx.cs" Inherits="CMS_Tools.Test_GameDT_TheNap_CauHinhThe" %>
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
#tbl_datatable_wrapper > .row{
    display:none;
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
                        Danh sách thẻ cấu hình
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

    <!-----From update card------>
    <div id="modal_config_card" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_config_card" class="form-horizontal" novalidate="novalidate">
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
                            <input id="ID_Card" type="hidden"/>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Loại thẻ: 
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtTypeCard" name="TypeCard" class="form-control" value="" disabled />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Mệnh giá:
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtPrize" name="Prize" class="form-control" value="" disabled/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Kích hoạt nạp: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select id="selectEnable" name="Enable" class="form-control">
                                                    <option value="True">Kích hoạt</option>
                                                    <option value="False">Không kích hoạt</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Khuyến mãi nạp: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtPromotion" name="Promotion" class="form-control" value="" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Tỷ lệ nạp: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtTopupRate" name="TopupRate" class="form-control" value="" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Kích hoạt đổi: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <select id="selectEnableCashout" name="EnableCashout" class="form-control">
                                                    <option value="True">Kích hoạt</option>
                                                    <option value="False">Không kích hoạt</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Khuyến mãi đổi: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtPromotionCashout" name="PromotionCashout" class="form-control" value="" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Tỷ lệ đổi: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtCashoutRate" name="CashoutRate" class="form-control" value="" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=row>
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Pay: <span class="required" aria-required="true">* </span>
                                        </label> 
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input type="text" id="txtPay" name="Pay" class="form-control" value="" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                          </div>  
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn dark btn-outline">Hủy</button>
                        <button type="submit" class="btn green">Cập nhật</button>
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

        function ResetForm() {
            $('#form_config_card').trigger('reset');
        }
        jQuery(document).ready(function () {
            $('.page-toolbar').remove();
            FormValidation.init();
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
                                    
                                    var cardType = "";
                                    switch (obj[1]) {
                                        case "1":
                                            cardType = "Viettel";
                                            break;
                                        case "2":
                                            cardType = "Mobi";
                                            break;
                                        case "3":
                                            cardType = "Vina";
                                            break;
                                        default:
                                            cardType = "Khác";
                                            break;
                                    }
                                    var func = 'SetConfigCard(' + obj[0] + ',"' + cardType + '","'
                                        + obj[2] + '","' + obj[3] + '","' + obj[4]
                                        + '","' + obj[5] + '","' + obj[6] + '","'
                                        + obj[7] + '","' + obj[8] + '","' + obj[9].split('|')[0] + '");';
                                    var configCard = "<a class='btn btn-xs green btn-circle btn-outline' onclick='" + func + "' >Cấu hình</a>";

                                    $('#tbl_datatable tbody').append("<tr>" +
                                        "<td>" + obj[0] + "</td>" +
                                        "<td>" + cardType + "</td>" +
                                        "<td>" + obj[2] + "</td>" +
                                        "<td>" + (obj[3] == "True" ? "Kích hoạt" : "Không kích hoạt") + "</td>" +
                                        "<td>" + obj[4] + "</td>" +
                                        "<td>" + obj[5] + "</td>" +
                                        "<td>" + (obj[6] == "True" ? "Kích hoạt" : "Không kích hoạt") + "</td>" +
                                        "<td>" + obj[7] + "</td>" +
                                        "<td>" + obj[8] + "</td>" +
                                        "<td>" + obj[9].split('|')[0] + "</td>" +
                                        "<td>" + configCard +"</td>" +
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
                                        [0, "asc"]
                                    ]
                                });

                                //an column
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

        var FormValidation = function () {
            var r = function () {
                var e = $("#form_config_card"),
                    r = $(".alert-danger", e),
                    i = $(".alert-success", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        Prize: {
                            required: !0,
                            number: !0
                        },
                        Enable: {
                            required: !0,
                        },
                        Promotion: {
                            required: !0,
                            number: !0
                        },
                        TopupRate: {
                            required: !0,
                            number: !0
                            
                        },
                        EnableCashout: {
                            required: !0, 
                        },
                        PromotionCashout: {
                            required: !0,
                            number: !0

                        },
                        CashoutRate: {
                            required: !0,
                            number: !0

                        },
                        Pay: {
                            required: !0,
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
                            UpdateConfigCard();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        function SetConfigCard(ID, TypeCard, Prize, Enable, Promotion, TopupRate, EnableCashout, PromotionCashout, CashoutRate, Pay) {
            $('#ID_Card').val(ID);
            $('#txtTypeCard').val(TypeCard);
            $('#txtPrize').val(Prize);
            $('#selectEnable').val(Enable);
            $('#txtPromotion').val(Promotion);
            $('#txtTopupRate').val(TopupRate);
            $('#selectEnableCashout').val(EnableCashout);
            $('#txtPromotionCashout').val(PromotionCashout);
            $('#txtCashoutRate').val(CashoutRate);
            $('#txtPay').val(Pay);
            $('#modal_config_card').modal('show');
        }
        function UpdateConfigCard() {
            var json = {
                "ID": $('#ID_Card').val(),
                "Enable": $('#selectEnable').val(),
                "Promotion": $('#txtPromotion').val(),
                "CashoutRate": $('#txtCashoutRate').val(),
                "EnableCashout": $('#selectEnableCashout').val(),
                "TopupRate": $('#txtTopupRate').val(),
                "PromotionCashout": $('#txtPromotionCashout').val(),
                "Pay": $('#txtPay').val()
            }
            POST_DATA("Apis/API_GameAccount.ashx", {
                type: 16,
                json: JSON.stringify(json)
            }, function (res) {
                if (res.status == 1) {
                    bootbox.alert({
                        title: "Thông báo",
                        message: res.msg,
                        callback: function () {
                            $('#modal_config_card').modal('hide');
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
