<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CMS_Tools.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>    
    <link href="assets/global/plugins/datepicker/css/bootstrap-timepicker.min.css" rel="stylesheet" />  
    <link href="assets/global/plugins/Datetime/datetimepicker.css" rel="stylesheet" />
	<link href="assets/pages/css/kieuthung.css" rel="stylesheet" />
    <link href="assets/global/plugins/datatables/Datatable_1_10_16/buttons.dataTables.min.css" rel="stylesheet" type="text/css" />
	<script src="assets/global/plugins/Datetime/bootstrap-timepicker.min.js"></script>
    <script src="assets/global/plugins/Datetime/bootstrap-datetimepicker.min.js"></script>
    <script src="assets/global/plugins/Datetime/components-date-time-pickers.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script src="assets/global/plugins/datatables/Datatable_1_10_16/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/datatables/Datatable_1_10_16/fnPagingInfo.js"></script>
    <script src="assets/global/plugins/datatables/Datatable_1_10_16/dataTables.buttons.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/datatables/Datatable_1_10_16/buttons.flash.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/datatables/Datatable_1_10_16/jszip.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/datatables/Datatable_1_10_16/pdfmake.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/datatables/Datatable_1_10_16/vfs_fonts.js" type="text/javascript"></script>
    <script src="assets/global/plugins/datatables/Datatable_1_10_16/buttons.html5.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/datatables/Datatable_1_10_16/buttons.print.min.js" type="text/javascript"></script>
    <script> 
        $(function () {
            ResetForm();
            FormValidation.init();
            ComponentsPickers.init();
            $('.loading1').fadeOut();

            if ($('#listTab .active a').text() == "BÁN HÀNG")
                $('#dateFilter').hide();
            else
                $('#dateFilter').show();

            $('#tbl_chiphi input[type=text]').focus(function () {
                if ($(this).val() == "0")
                    $(this).val("");
            });
            $('#tbl_chiphi input[type=text]').focusout(function () {
                if ($(this).val() == "")
                    $(this).val(0);
            });

            $('#txtSL_Tang').focus(function () {
                if ($(this).val() == "0")
                    $(this).val("");
            });
            $('#txtSL_Tang').focusout(function () {
                if ($(this).val() == "")
                    $(this).val(0);
            });

            ///////////////// EVENT CLICK //////////////////
            $('#listTab li').click(function () {
                var t = $(this).text().trim();
                switch (t) {
                    case "QUẢN LÝ SẢN XUẤT":
                        if (!$(this).hasClass('active'))
                            TableEditable.ViewDonHangDatGiayTam();
                        $('#dateFilter').show();
                        $('.btnTabQlSX').show();
                        var currentdate = new Date();
                        var nextDate = new Date();
                        nextDate.setDate(nextDate.getDate() + 2);
                        var _ngaydat = ("" + currentdate.getDate().toString().length < 2 ? "0" + currentdate.getDate().toString() : currentdate.getDate().toString())
                            + "/" + ((currentdate.getMonth() + 1).toString().length < 2 ? "0" + (currentdate.getMonth() + 1) : (currentdate.getMonth() + 1).toString())
                            + "/" + currentdate.getFullYear() + " 10:00";
                        var _ngaynhan = ("" + nextDate.getDate().toString().length < 2 ? "0" + nextDate.getDate() : nextDate.getDate().toString())
                            + "/" + ((nextDate.getMonth() + 1).toString().length < 2 ? "0" + (nextDate.getMonth() + 1) : (nextDate.getMonth() + 1).toString())
                            + "/" + nextDate.getFullYear() + " 10:00";
                        $('#txtNgayDatGiay').attr("data-date", _ngaydat);
                        $('#txtNgayDatGiay input').val(_ngaydat);
                        $('#txtNgayNhanGiay').attr("data-date", _ngaynhan);
                        $('#txtNgayNhanGiay input').val(_ngaynhan);
                        break;
                    case "BÁN HÀNG":
                        $('#dateFilter').hide();
                        $('.btnTabQlSX').hide();
                        break;
                    case "ĐƠN HÀNG":
                        if (!$(this).hasClass('active'))
                            TableEditable.ViewDonHang();
                        $('#dateFilter').show();
                        $('.btnTabQlSX').hide();
                        break;
                    case "SẢN XUẤT":
                        if (!$(this).hasClass('active'))
                            TableEditable.ViewDonHangSX();
                        $('#dateFilter').show();
                        $('.btnTabQlSX').hide();
                        break;
                    case "THU MUA":
                        //if(!$(this).hasClass('active'))
                        //    TableEditable.ViewDatGiayTam();
                        $('#dateFilter').show();
                        $('.btnTabQlSX').hide();
                        break;
                    default:
                        $('.btnTabQlSX').hide();
                        break;
                }
            });

            $('#btnSearchGiayTon').click(function () {
                TableEditable.ViewGiayTon();
            });

            $('#btnSearchDatGiayTam').click(function () {
                TableEditable.ViewDonHangDatGiayTam();
            });

            $('#btnSearchThuMua').click(function () {
                $('#modal_ViewThuMuaGiayTam').modal('show');
                TableEditable.ViewDatGiayTam();
            });

            $('#btn_print').click(function () {
                window.open("PrintOrderDetail.aspx?&OrderID=" + $('#_orderID').val() + "&p=" + $('#lblSTT').text().split('/')[0], '_blank', 'location=yes,height=600,width=1000,scrollbars=yes,status=yes');
            });

            $('#btnPrintOrder').click(function () {
                window.open("PrintOrderDetail.aspx?&OrderID=" + $('#_orderID').val() + "&p=all", '_blank', 'location=yes,height=600,width=1200,scrollbars=yes,status=yes');
            });

            $('#btnSaveOrder').click(function () {
                bootbox.confirm("Xác nhận lưu đơn hàng?", function (r) {
                    if (r) {
                        $.ajax({
                            type: "POST",
                            url: "Apis/API_Order.ashx",
                            data: {
                                type: 4018,
                                mid: AppManage.getURLParameter('m')
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 0) {
                                    $('#btnSaveOrder').fadeOut(0);
                                    $('#tbl_order_detail tbody').html("<tr><td colspan='7'>Không có đơn hàng</td></tr>");
                                    Page.GetListOrderUser();
                                }
                                else
                                    bootbox.alert(data.msg);
                            }
                        });
                    }
                });
            });

            $('#btnSubmitOrder').click(function () {
                var r = validator.form();
                if (r) {
                    var e = $("#form_Order");
                    r = $(".alert-danger", e);
                    //i = $(".alert-success", e);
                    r.hide();
                    //i.show();
                    SubmitForm();
                }
            });

            $('#btn_datgiaytam').click(function () {
                $(this).prop("disabled", true);
                var arr = [];
                $(".checkbox_menu:checked").each(function (key, obj) {
                    arr[key] = $(obj).val()
                });
                console.log(arr);
                if (arr.length > 0) {
                    bootbox.confirm("Xác nhận đặt giấy tấm?", function (r) {
                        if (r) {
                            $('.divLoading1').fadeIn();
                            $.ajax({
                                type: "POST",
                                url: "Apis/API_Order.ashx",
                                data: {
                                    type: 4028,
                                    mid: AppManage.getURLParameter('m'),
                                    ids: arr.join(),
                                    ngaydatgiay: $('#txtNgayDatGiay input').val(),
                                    ngayyeucaugiao: $('#txtNgayNhanGiay input').val(),
                                    kyhieudon: $('#txtKyhieudon').val()
                                },
                                dataType: 'json',
                                success: function (data) {
                                    bootbox.alert(data.msg);
                                    $('#btn_datgiaytam').prop("disabled", false);
                                    if (data.status == 0) {
                                        $('#modal_ViewThuMuaGiayTam').modal("hide");
                                        TableEditable.ViewDatGiayTam();
                                        TableEditable.ViewDonHangDatGiayTam();
                                    }
                                    else
                                        $('.divLoading1').fadeOut();
                                }
                            });
                        }
                        else
                            $('#btn_datgiaytam').prop("disabled", false);
                    });
                }
            });

            $('#btn_nhangiaytam').click(function () {
                var slNhan = parseInt($('#txtSL_NhanGiayTam').val());
                var slTang = $('#txtSLTang_NhanGiayTam').val();
                if (slTang == "")
                    slTang = 0;
                else
                    slTang = parseInt($('#txtSLTang_NhanGiayTam').val());
                if (!isNaN(slNhan) && !isNaN(slTang)) {
                    $('#btn_nhangiaytam').prop("disabled", true);
                    $('.divLoading1').fadeIn();
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Order.ashx",
                        data: {
                            type: 4029,
                            mid: AppManage.getURLParameter('m'),
                            id: $('#id_datgiaytam').val(),
                            sl_nhan: slNhan,
                            sl_tang: slTang,
                            ghichu: $('#txtGhiChu_NhanGiayTam').val()
                        },
                        dataType: 'json',
                        success: function (data) {
                            $('#btn_nhangiaytam').prop("disabled", false);
                            bootbox.alert(data.msg);
                            if (data.status == 0) {
                                $('#modal_nhangiaytam').modal("hide");
                                TableEditable.ViewDonHangDatGiayTam();
                            }
                            else
                                $('.divLoading1').fadeOut();
                        }
                    });
                }
                else {
                    bootbox.alert("Vui lòng nhập số lượng nhận!");
                }
            });

            $('#btn_updateGiayTonKho').click(function () {
                if ($('#txtSLTang_Nhan').val() == "")
                    $('#txtSLTang_Nhan').val(0);
                if ($('#txtSL_HangHu').val() == "")
                    $('#txtSL_HangHu').val(0);
                var slNhan = parseInt($('#txtSL_Nhan').val());
                var slTang = parseInt($('#txtSLTang_Nhan').val());
                var slHangHu = parseInt($('#txtSL_HangHu').val());
                if (!isNaN(slNhan) && !isNaN(slTang) && !isNaN(slHangHu)) {
                    $('#btn_updateGiayTonKho').prop("disabled", true);
                    $('.divLoading1').fadeIn();
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Order.ashx",
                        data: {
                            type: 4031,
                            mid: AppManage.getURLParameter('m'),
                            id: $('#id_giaytonkho').val(),
                            sl_nhan: slNhan,
                            sl_tang: slTang,
                            sl_hanghu: slHangHu,
                            ghichu: $('#txtGhiChu_TonKho').val()
                        },
                        dataType: 'json',
                        success: function (data) {
                            $('#btn_updateGiayTonKho').prop("disabled", false);
                            bootbox.alert(data.msg);
                            if (data.status == 0) {
                                $('#modal_capnhatgiaytonkho').modal("hide");
                                TableEditable.ViewGiayTon();
                            }
                            else
                                $('.divLoading1').fadeOut();
                        }
                    });
                }
                else {
                    bootbox.alert("Vui lòng nhập số lượng nhận!");
                }
            });

            $('#btnNewOrder').click(function () {
                FindCustomer();
                $('#modal_order').modal('show');
            });

            $('#btnSearchKH').click(function () {
                $.ajax({
                    type: "POST",
                    url: "Apis/API_Customer.ashx",
                    data: {
                        type: 4014,
                        mid: AppManage.getURLParameter('m'),
                        param: $('#txtSearchKH').val()
                    },
                    dataType: 'json',
                    success: function (data) {
                        if (data.status != 0) {
                            bootbox.alert(data.msg);
                            return;
                        }
                        var customer = data.data[0];
                        $('#country_ID').val(customer.Country);
                        $('#txtMaKH').val(customer.CustomerCode);
                        $('#lblContact').text(customer.Contact);
                        $('#lblCompanyName').text(customer.CompanyName);
                        $('#lblMST').text(customer.TaxCode);
                        $('#lblAddress').text(customer.Address);
                        $('#lblSoKM').text(customer.KM + " KM");
                        $('#country_ID').val(customer.Country);
                        $('#selectLoaiDonHang').val(customer.LoaiDon_ID);
                        $('#selectLoaiHinhSX').val(customer.LoaiHinhSX_ID);
                        $('#selectProvince').html("");
                        $('#selectLoaiHinhSX').select2({
                            showSearchInput: true
                        });
                        $('#selectLoaiDonHang').select2({
                            showSearchInput: true
                        });
                        if (customer.Address != "")
                            $('#selectProvince').append("<option address='" + customer.Address + "' km='" + customer.KM + "' value='" + customer.City + "' countryID='" + customer.Country + "'>" + customer.Province + "</option>");
                        if (customer.Address1 != "") {
                            $('#selectProvince').append("<option address='" + customer.Address1 + "' km='" + customer.KM1 + "' value='" + customer.City1 + "' countryID='" + customer.Country1 + "'>" + customer.Province1 + "</option>");
                            if ($('#lblAddress').text() == "") {
                                $('#lblAddress').text(customer.Address1);
                                $('#lblSoKM').text(customer.KM1 + " KM");
                            }
                        }
                        if (customer.Address2 != "") {
                            $('#selectProvince').append("<option address='" + customer.Address2 + "' km='" + customer.KM2 + "' value='" + customer.City2 + "' countryID='" + customer.Country2 + "'>" + customer.Province2 + "</option>");
                            if ($('#lblAddress').text() == "") {
                                $('#lblAddress').text(customer.Address2);
                                $('#lblSoKM').text(customer.KM2 + " KM");
                            }
                        }
                        validator.form();
                        TinhPhiVanChuyen();
                    }
                });
            });
            //////////////////////////////////////////////////////////////

            //////////////// EVENT CHANGE //////////////
            $('#selectDongDanKim').change(function () {
                if ($(this).val() == "1" || $(this).val() == "2" || $(this).val() == "5") {
                    $('#tbl_thongtindonhang label input:checkbox').prop("checked", false);
                    $('#checkboxDongDinh').prop("checked", true);

                }
                else if ($(this).val() == "3") {
                    $('#tbl_thongtindonhang label input:checkbox').prop("checked", false);
                    $('#checkboxDangKeo').prop("checked", true);
                    $('.mt-checkbox').toggleClass('span');
                }
            });

            $('#selectLoaiDon').change(function () {
                TableEditable.ViewGiayTon();
            });

            $('#txtHoaHong').change(function () {
                TinhHoaHong();
            });

            $('#txtGiaBanThung').change(function () {
                TinhDoanhThu();
            });

            $('#txtSLBL').change(function () {
                TinhDoanhThu();
            });

            $('#selectChatLieu').change(function () {
                if ($(this).val() != "") {
                    $('#txtGiaMua').val(formatNumber(parseInt($('option:selected', this).attr('gia'))));
                    TinhDoanhThu();
                }
                else
                    $('#txtGiaMua').val("");
            });

            $('#txtQCKH_Dai').change(function () {
                var QCKH_Dai = parseInt($(this).val());
                if (!isNaN(QCKH_Dai)) {
                    $('#txtQCSX_Dai').val(QCKH_Dai);
                    Page.TinhToanKichThuoc();
                }
                else
                    $('#txtQCSX_Dai').val(0);
            });

            $('#txtQCKH_Cao').change(function () {
                var QCKH_Cao = parseInt($(this).val());
                if (!isNaN(QCKH_Cao)) {
                    $('#txtQCSX_Cao').val(QCKH_Cao);
                    Page.TinhToanKichThuoc();
                }
                else
                    $('#txtQCSX_Cao').val(0);
            });

            $('#txtQCKH_Rong').change(function () {
                var QCKH_Rong = parseInt($(this).val());
                if (!isNaN(QCKH_Rong)) {
                    $('#txtQCSX_Rong').val(QCKH_Rong);
                    Page.TinhToanKichThuoc();
                }
                else
                    $('#txtQCSX_Rong').val(0);
            });

            $('#txtSLBL').change(function () {
                var slbl = parseInt($(this).val());
                var slsx = parseInt($('#txtSLSX').val());
                var dai_thung = parseInt($('#txtCatDai').val());
                var cai = parseInt($('#txtCai').val());
                if (slbl >= slsx) {
                    var somettoi = Math.round(parseFloat(slbl * dai_thung / 1000));
                    if (somettoi == 0) {
                        bootbox.alert("Nhập quy cách kích thước sx hoặc số lượng quá nhỏ!!!");
                        $('#txtSLToiThieu').val(0);
                    }
                    else {
                        $('#txtSLToiThieu').val(Math.round(parseInt(slbl * 250 * cai / somettoi)));
                    }
                    $('#txtSoMetToi').val(somettoi * cai);
                }
                else {
                    $(this).val(slsx);
                    bootbox.alert("Vui lòng nhập số lượng bị liệu lớn hơn hoặc bằng số lượng sx!");
                }
            });

            $('#txtSL').change(function () {
                var n1 = parseInt($(this).val());
                var n2 = parseInt($('#txtSL_Tang').val());
                if (!isNaN(n1) && !isNaN(n2)) {
                    $('#txtTotalSL').val(n1 + n2);
                }
                else
                    $('#txtTotalSL').val(0);
                TinhDoanhThu();
            });

            $('#txtSL_Tang').change(function () {
                var n1 = parseInt($(this).val());
                var n2 = parseInt($('#txtSL').val());
                if (!isNaN(n1) && !isNaN(n2)) {
                    $('#txtTotalSL').val(n1 + n2);
                }
                else
                    $('#txtTotalSL').val(0);
            });

            $('#selectProvince').change(function () {
                $('#lblAddress').text($('option:selected', this).attr('address'));
                $('#lblSoKM').text($('option:selected', this).attr('km') + " KM");
                $('#country_ID').val($('option:selected', this).attr('countryID'));
            });          

            $('#selectNhaCungCap').change(function () {
                Page.GetChatLieu();
            });          
            //////////////////////////////////////////////////////

            /////////////// EVENT DELEGATE /////////////////
            $("#tbl_viewdatgiaytam tbody").delegate(".checkbox_menu", "change", function () {
                if (this.checked) {
                    //if ($(".checkbox_menu:checked").length == $("input[name='ckbox[]']").length) {
                    //    $(".checkbox_all").prop("checked", true);
                    //}
                    $("#btn_datgiaytam").prop("disabled", false);
                }
                else {
                    if ($(".checkbox_menu:checked").length == 0) {
                        //$(".btnMenu_button a").addClass("disable");
                        //$(".checkbox_all").prop("checked", false);
                        $("#btn_datgiaytam").prop("disabled", true);
                    }      
                    //if ($(".checkbox_menu:checked").length < $("input[name='ckbox[]']").length) {
                    //    $(".checkbox_all").prop("checked", false);
                    //}
                }
            });

            $("#tbl_viewdonhangdatgiaytam tbody").delegate(".btnNhanGiay", "click", function () {
                $('#modal_nhangiaytam').modal("show");
                $('#id_datgiaytam').val($(this).attr('id'));
                $('#txtSL_NhanGiayTam').val("");
                $('#txtSLTang_NhanGiayTam').val("");
                $('#txtGhiChu_NhanGiayTam').val("");
            });

            $("#tbl_viewgiayton tbody").delegate(".btnUpdateGiayTon", "click", function () {
                $('#modal_capnhatgiaytonkho').modal("show");
                $('#id_giaytonkho').val($(this).attr('id'));
                $('#txtSL_Nhan').val($(this).attr('slNhan'));
                $('#txtSLTang_Nhan').val($(this).attr('slTang'));
                $('#txtSL_HangHu').val("");
                $('#txtGhiChu_TonKho').val("");
            });

            $("#tbl_viewdonhangdatgiaytam tbody").delegate(".btnRemoveDatGiay", "click", function () {
                $('#id_datgiaytam').val($(this).attr('id'));
                bootbox.confirm("Xác nhận hủy đặt giấy?", function (r) {
                    if (r) { 
                        $('.divLoading1').fadeIn();
                        $.ajax({
                            type: "POST",
                            url: "Apis/API_Order.ashx",
                            data: {
                                type: 4030,
                                mid: AppManage.getURLParameter('m'),
                                id: $('#id_datgiaytam').val()
                            },
                            dataType: 'json',
                            success: function (data) {
                                bootbox.alert(data.msg);
                                if (data.status == 0) {
                                    TableEditable.ViewDonHangDatGiayTam();
                                }
                                else
                                    $('.divLoading1').fadeOut();
                            }
                        });
                    }
                });
            });

            $('#tbl_order_detail').delegate(".btnViewOrderDetail", "click", function () { 
                $('#modal_ViewOrderDetail').modal('show'); 
                var orderDetailID = $(this).attr("orderDetailID"); 
                var orderID = $(this).attr("orderID"); 
                $.ajax({
                    type: "POST",
                    url: "Apis/API_Order.ashx",
                    data: {
                        type: 4025,
                        mid: AppManage.getURLParameter('m'),
                        orderDetailID: orderDetailID,
                        orderID: orderID
                    },
                    dataType: 'json',
                    success: function (data) {
                        if (data.status == 0) {
                            var d = data.data[0];
                            $('#_orderDetailID').val(d.OrderDetail_ID);
                            $('#_orderID').val(d.Order_ID);
                            $('#lblNvkd').text(d.UserName);
                            $('#lblMaKH').text(d.Ma_KH);
                            $('#lblTenKH').text(d.CompanyName);
                            $('#lblNgayMo').text(d.Ngay_Mo_Don);
                            $('#lblNgayGiao').text(d.Ngay_Giao_Hang);
                            $('#lblMaDH').text(d.MaDonHang);
                            $('#lblSTT').text(d.STT + "/" + d.CountOrder);
                            $('#lblPO').text(d.So_PO != "" ? d.So_PO : "");
                            $('#lblSoDonKh').text(d.So_Don_KH != "" ? d.So_Don_KH : "");
                            $('#lblTenSP').text(d.Ten_SP);
                            $('#lblKyHieu').text(d.Ky_Hieu_Don != "" ? d.Ky_Hieu_Don : "");
                            $('#lblDai').text(d.QuyCach_SX_D);
                            $('#lblRong').text(d.QuyCach_SX_R);
                            $('#lblCao').text(d.QuyCach_SX_C);
                            $('#lblSL').text(d.SL);
                            $('#lblSL_Tang').text(d.SL_Tang);
                            $('#lblKieuDang').text(d.MaThung);
                            $('#lblLopSong').text(d.TenLoaiSong);
                            $('#lblRongThung').text(d.Thung_Cat_R);
                            $('#lblDaiThung').text(d.Thung_Cat_D);
                            $('#lblSongGiay').text(d.MaLoaiSong);
                            $('#lblKhoGiay').text(d.QuyCach_KhoGiay_R);
                            $('#lblDaiGiay').text(d.QuyCach_KhoGiay_D);
                            $('#lblCaiTam').text(d.Cai);
                            $('#lblSlGiayDat').text(d.SL_Bi_Lieu);
                            $('#lblChatLieu').text(d.Ten_Chat_Lieu);
                            $('#lblNhaCungCap').text(d.Ten_Nha_Cung_Cap);
                            $('#lblDanDongKim').text(d.Dong_Dan);
                            $('#lblSoMauIn').text(d.So_Mau_In != "" ? d.So_Mau_In : "");
                            $('#lblInAn').text(d.In_An == false ? "không": "Có");
                            $('#lblCanBien').text(d.Can_bien == false ? "Không": "Có");
                            $('#lblMayIn').text(d.May_In == false ? "Không": "Có");
                            $('#lblCatRanh').text(d.Cat_Ranh == false ? "Không": "Có");
                            $('#lblMayBe').text(d.May_Be == false ? "Không": "Có");
                            $('#lblDongDinh').text(d.Dong_Dinh == false ? "Không": "Có");
                            $('#lblDanKeo').text(d.Dan_Keo == false ? "Không" : "Có");
                            $('#lblDongGoi').text(d.Ten_Dong_Goi);
                            $('#lblGiaCongDB').text(d.Gia_Cong_DB != "" ? d.Gia_Cong_DB : "");
                            $('#lblLoaiBanIn').text(d.Loai_Ban_In == 1 ? "Bản mới" : d.Loai_Ban_In == 2 ? "Bản cũ": "Sửa bản cũ");
                            $('#lblMaBanIn').text(d.Ma_So_Ban_In != "" ? d.Ma_So_Ban_In : "");
                            $('#lblMaKhuonBe').text(d.Ma_So_Khuon_Be != "" ? d.Ma_So_Khuon_Be : "");
                            $('#lblDinhKem').text(d.Dinh_Kem == 1 ? "Theo mẫu" : "Bản vẽ");
                            $('#lblDT_Cai').text(d.DT_Cai);
                            $('#lblDT_Don').text(d.Tong_DT);
                            $('#lblGhiChu').html("");
                            if(d.Ghi_Chu_SX != "")
                                $('#lblGhiChu').append("<p>Ghi chú SX: " + d.Ghi_Chu_SX + "</p>");
                            if(d.Ghi_Chu_Don_Hang != "")
                                $('#lblGhiChu').append("<p>Ghi chú đơn hàng: " + d.Ghi_Chu_Don_Hang + "</p>");
                            if(d.Ghi_Chu_Giao_Hang != "")
                                $('#lblGhiChu').append("<p>Ghi chú giao hàng: " + d.Ghi_Chu_Giao_Hang + "</p>");
                            if (d.Thung_Image.substring(0, 4) != "http")
                                d.Thung_Image = "https://" + d.Thung_Image;
                            $('#imgKieuThung').html("<img src='" + d.Thung_Image + "'/>" + 
                                "<div id='CanNap_" + d.LoaiThung_ID + "'></div>" + 
                                "<div id='CanLan_" + d.LoaiThung_ID + "'></div>");
                            var cannap = d.Can_Nap.split('|');
                            var canlan = d.Can_Lan.split('|');
                            var s = 0;
                            for (var i = 0; i < cannap.length; i++) {
                                if (cannap[i] != "") {
                                    $('#CanNap_' + d.LoaiThung_ID).append("<span>" + cannap[i] + "</span>");
                                    if(cannap.length > 1)
                                        s += parseInt(cannap[i]);
                                }
                            }
                            if (s > 0)
                                $('#CanNap_' + d.LoaiThung_ID).append("<span>" + s + "</span>");
                            s = 0;
                            for (var i = 0; i < canlan.length; i++) {
                                if (canlan[i] != "") {
                                    $('#CanLan_' + d.LoaiThung_ID).append("<span>" + canlan[i] + "</span>");
                                    if(canlan.length > 1)
                                        s += parseInt(canlan[i]);
                                }
                            }
                            if (s > 0)
                                $('#CanLan_' + d.LoaiThung_ID).append("<span>" + s + "</span>");
                        }
                        else
                            bootbox.alert(data.msg);
                    }
                });
            });

            $('#tbl_order_detail').delegate(".btnRemoveOrderDetail", "click", function () {
                var orderID = $(this).attr("orderID");  
                var orderDetailID = $(this).attr("orderDetailID"); 
                var TenSP = $(this).attr("tenSP"); 
                bootbox.confirm("Xác nhận xóa đơn hàng [" + TenSP + "]?", function (r) {
                    if (r) {
                        $.ajax({
                            type: "POST",
                            url: "Apis/API_Order.ashx",
                            data: {
                                type: 4019,
                                mid: AppManage.getURLParameter('m'),
                                orderID: orderID,
                                orderDetailID: orderDetailID
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 0) {
                                    Page.GetListOrderDetailTemp();
                                }
                                else if (data.status == 1)
                                {
                                    Page.GetListOrderDetailTemp();
                                    Page.GetListOrderUser();
                                }
                                else
                                    bootbox.alert(data.msg);
                            }
                        });
                    }
                });   
            });

            $('#tbl_OrderList').delegate(".btnRemoveOrder", "click", function () { 
            });

            $('#tbl_OrderList').delegate("tr", "click", function () { 
                if ($(this).attr('choise') != "0")
                    return;
                $('#tbl_OrderList tr').attr('choise', '0');
                $('#_orderID').val($(this).attr('orderID'));
                $(this).attr('choise', '1');
                var ma_donhang = $(this).find('td').eq(0).text();
                $.ajax({
                    type: "POST",
                    url: "Apis/API_Order.ashx",
                    data: {
                        type: 4024,
                        mid: AppManage.getURLParameter('m'),
                        param: ma_donhang
                    },
                    dataType: 'json',
                    success: function (data) {
                        if (data.status == 0) {
                            ViewListOrderDetail(data.data);
                            $('#btnPrintOrder').show();
                        }
                        else if (data.status == -9998) {
                            $('#btnPrintOrder').hide();
                            $('#btnSaveOrder').hide();
                            $('#tbl_order_detail tbody').html("<tr><td colspan='7'>Không có đơn hàng</td></tr>");
                        }
                        else {
                            $('#btnPrintOrder').hide();
                            $('#btnSaveOrder').hide();
                            bootbox.alert(data.msg);
                        }
                    }
                });
            });

            var options = {
                url: function (param) {
                    return "Apis/API_Customer.ashx";
                },
                getValue: function (element) {
                    $('.loading1').fadeOut(10);
                    console.log(element);
                    return element.CustomerCode + ' - ' + element.CompanyName;
                },
                ajaxSettings: {
                    dataType: "json",
                    method: "POST",
                    data: {
                        type: 4013,
                        mid: AppManage.getURLParameter('m')
                    }
                },
                preparePostData: function (data) {
                    $('.loading1').fadeIn();
                    data.param = $("#txtSearchKH").val();
                    return data;
                },
                requestDelay: 500
            };
            $("#txtSearchKH").easyAutocomplete(options);
            Page.init();
        });

        function FindCustomer() {
            $.ajax({
                type: "POST",
                url: "Apis/API_Customer.ashx",
                data: {
                    type: 4023,
                    mid: AppManage.getURLParameter('m')
                },
                dataType: 'json',
                success: function (data) {
                    if (data.status > 0) {
                        if ($("#txtSearchKH").val() == "") {
                            $("#txtSearchKH").val(data.data[0].CustomerName);
                            $('#btnSearchKH').click();
                        }
                    }
                    else {
                        ResetForm();
                        $('#txtSearchKH').val("");
                        $('#txtMaKH').val("");
                        $('#lblCompanyName').text("");
                        $('#lblMST').text("");
                        $('#lblContact').text("");
                        $('#lblAddress').text("");
                        $('#selectProvince').html("");
                        $('#lblSoKM').text("");
                        $('#selectLoaiDonHang').val("");
                        $('#selectLoaiHinhSX').val("");
                        $('#selectLoaiDonHang').select2({
                            showSearchInput: true
                        });
                        $('#selectLoaiHinhSX').select2({
                            showSearchInput: true
                        });
                    }
                }
            });
        }

        function openNav(div) {
            if ($(div).attr('action') == 'close') {
                document.getElementById("mySidebar").style.width = "250px";
                document.getElementById("main").style.marginRight = "250px";
                $(div).attr('action', 'open');
                $(div).html("<i class='icon-login'></i>");
            }
            else {
                document.getElementById("mySidebar").style.width = "20px";
                document.getElementById("main").style.marginRight = "0";
                $(div).attr('action', 'close');
                $(div).html("<i class='icon-logout'></i>");
            }
        }

        function GetCurrentDate(day) {         
            var today = new Date();
            if (day > 0) {
                var d = new Date();
                today.setDate(d.getDate() + day);
            }
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
            var yyyy = today.getFullYear();

            var stoday = dd + '/' + mm + '/' + yyyy;
            return stoday;
        }

        var countFunc = 0;
        function callBackFunc() {
            countFunc++;
            if (countFunc == 6) {
                $('.divLoading').fadeOut();
            }
        }

        var Page = function () {
            var GetLoaiDonHang = function () {
                $.ajax({
                    type: "POST",
                    url: "Apis/API_Customer.ashx",
                    data: {
                        type: 4008,
                        mid: AppManage.getURLParameter('m')
                    },
                    dataType: 'json',
                    success: function (data) {
                        $('#selectLoaiDonHang').html("<option value=''>...</option>");
                        if (data.status == 0) {
                            $.each(data.data, function (key, obj) {
                                $('#selectLoaiDonHang').append("<option value='" + obj.LoaiDon_ID + "'>" + obj.Name + "</option>");
                            });
                            $('#selectLoaiDonHang').select2({
                                showSearchInput: true
                            });
                            callBackFunc();
                        }
                    }
                });
            },
                GetGiaCongDongDan = function () {
                $.ajax({
                    type: "POST",
                    url: "Apis/API_Customer.ashx",
                    data: {
                        type: 4027,
                        mid: AppManage.getURLParameter('m')
                    },
                    dataType: 'json',
                    success: function (data) {
                        $('#selectDongDanKim').html("");
                        if (data.status == 0) {
                            $.each(data.data, function (key, obj) {
                                $('#selectDongDanKim').append("<option value='" + obj.Id + "'>" + obj.Name + "</option>");
                            });
                            $('#selectDongDanKim').val(4);
                            $('#selectDongDanKim').select2({
                                showSearchInput: true
                            });
                            callBackFunc();
                        }
                    }
                });
            },
                GetLoaiHinhSX = function () {
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Customer.ashx",
                        data: {
                            type: 4010,
                            mid: AppManage.getURLParameter('m')
                        },
                        dataType: 'json',
                        success: function (data) {
                            $('#selectLoaiHinhSX').html("<option value=''>...</option>");
                            if (data.status == 0) {
                                $.each(data.data, function (key, obj) {
                                    $('#selectLoaiHinhSX').append("<option value='" + obj.LoaiHinhSX_ID + "'>" + obj.Name + "</option>");
                                });
                                $('#selectLoaiHinhSX').select2({
                                    showSearchInput: true
                                });
                                callBackFunc();
                            }
                        }
                    });
                },
                GetNhaCungCap = function () {
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Customer.ashx",
                        data: {
                            type: 4007,
                            mid: AppManage.getURLParameter('m')
                        },
                        dataType: 'json',
                        success: function (data) {
                            $('#selectNhaCungCap').html("");
                            if (data.status == 0) {
                                $.each(data.data, function (key, obj) {
                                    $('#selectNhaCungCap').append("<option value='" + obj.NhaCungCap_ID + "'>" + obj.Name + "</option>");
                                });
                                $('#selectNhaCungCap').select2({
                                    showSearchInput: true
                                });
                                GetChatLieu();
                                callBackFunc();
                            }
                        }
                    });
                },
                GetChatLieu = function () {
                    $('#selectChatLieu').html("<option value=''>...</option>");
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Customer.ashx",
                        data: {
                            type: 4011,
                            mid: AppManage.getURLParameter('m'),
                            nhaCungCap_ID: $('#selectNhaCungCap').val()
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 0) {
                                $.each(data.data, function (key, obj) {
                                    $('#selectChatLieu').append("<option gia='" + obj.Gia + "' value='" + obj.ChatLieu_ID + "'>" + obj.Ten_Chat_Lieu + "</option>");
                                });
                                $('#selectChatLieu').select2({
                                    showSearchInput: true
                                });
                            }
                        }
                    });
                },
                GetKieuThung = function () {
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Customer.ashx",
                        data: {
                            type: 4009,
                            mid: AppManage.getURLParameter('m')
                        },
                        dataType: 'json',
                        success: function (data) {
                            $('#selectKieuThung').html("<option value=''>...</option>");
                            if (data.status == 0) {
                                $.each(data.data, function (key, obj) {
                                    $('#selectKieuThung').append("<option value='" + obj.LoaiThungID + "'>" + obj.MaThung + "</option>");
                                });
                                $('#selectKieuThung').select2({
                                    showSearchInput: true
                                });
                                callBackFunc();
                            }
                        }
                    });
                },
                GetLoaiSong = function () {
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Customer.ashx",
                        data: {
                            type: 4012,
                            mid: AppManage.getURLParameter('m')
                        },
                        dataType: 'json',
                        success: function (data) {
                            $('#selectLoaiSong').html("<option value=''>...</option>");
                            if (data.status == 0) {
                                $.each(data.data, function (key, obj) {
                                    $('#selectLoaiSong').append("<option value='" + obj.LoaiSongID + "'>" + obj.Name + "</option>");
                                });
                                $('#selectLoaiSong').select2({
                                    showSearchInput: true
                                });
                                callBackFunc();
                            }
                        }
                    });
                },
                FindCustomers = function () {
                    if ($('#txtSearchKH').val().trim() != "") {
                        $.ajax({
                            type: "POST",
                            url: "Apis/API_Customer.ashx",
                            data: {
                                type: 4013,
                                mid: AppManage.getURLParameter('m'),
                                param: $('#txtSearchKH').val()
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 0) {

                                }
                            }
                        });
                    }
                },
                TinhToanKichThuoc = function () {
                    var KieuThungID = $('#selectKieuThung').val();
                    var LoaiSongID = $('#selectLoaiSong').val();
                    var Cao = parseInt($('#txtQCSX_Cao').val());
                    var Rong = parseInt($('#txtQCSX_Rong').val());
                    var Dai = parseInt($('#txtQCSX_Dai').val());
                    var SL = parseInt($('#txtSL').val());
                    var NhacungcapID = parseInt($('#selectNhaCungCap').val());
                    var LuoiGa = parseInt($('#txtLuoiGa').val());
                    var SL_Tang = parseInt($('#txtSL_Tang').val());
                    if (KieuThungID != "" && LoaiSongID != "" && !isNaN(Cao)
                        && !isNaN(Dai) && !isNaN(Rong) && !isNaN(SL) && !isNaN(SL_Tang)
                        && !isNaN(LuoiGa) && Dai > 0 && Rong > 0 && Cao > 0 && SL > 0 && SL_Tang >= 0) {
                        $('.divLoading').fadeIn();
                        var json = {
                            "loaithungID": KieuThungID,
                            "loaisongID": LoaiSongID,
                            "dai": Dai,
                            "rong": Rong,
                            "cao": Cao,
                            "sl": SL + SL_Tang,
                            "luoiga": LuoiGa,
                            "nhacungapID": NhacungcapID
                        };
                        $.ajax({
                            type: "POST",
                            url: "Apis/API_Order.ashx",
                            data: {
                                type: 4015,
                                mid: AppManage.getURLParameter('m'),
                                param: JSON.stringify(json)
                            },
                            dataType: 'json',
                            success: function (data) {
                                $('.divLoading').fadeOut(300);
                                if (data.status == 0) {
                                    if (data.data.length > 0) {
                                        $('#btnSubmitOrder').show();
                                        var obj = data.data[0];
                                        $('#txtCatDai').val(obj.DAI_THUNG);
                                        $('#txtCatRong').val(obj.RONG_THUNG);
                                        $('#txtKhoGiay_Rong').val(obj.KHOGIAY);
                                        $('#txtKhoGiay_Dai').val(obj.DAI_THUNG);
                                        $('#txtSLSX').val(obj.SOLUONG_GIAY);
                                        $('#txtSLBL').val(obj.SOLUONG_GIAY + 1);
                                        $('#txtCai').val(obj.TAM_CAI);
                                        var dt_cai = parseFloat(obj.KHOGIAY*obj.DAI_THUNG / 1000000) / obj.TAM_CAI;
                                        $('#txtDT').val(formatNumber(dt_cai));
                                        $('#txtTotalDT').val(Math.round(dt_cai * (SL + SL_Tang)));
                                        var slbl = obj.SOLUONG_GIAY + 1;
                                        var somettoi = parseFloat(slbl * obj.DAI_THUNG / 1000);
                                        var sltoithieu = 0;
                                        if (somettoi == 0) {
                                            bootbox.alert("Nhập quy cách kích thước sx hoặc số lượng quá nhỏ!!!");
                                            $('#txtSLToiThieu').val(0);
                                        }
                                        else {
                                            sltoithieu = Math.round(parseFloat((slbl * 250 * obj.TAM_CAI) / somettoi));
                                            $('#txtSLToiThieu').val(sltoithieu);
                                        }
                                        $('#txtSoMetToi').val(Math.round(somettoi));
                                        //Tính phi hao hụt
                                        TinhPhiHaoHut();

                                        var candai = obj.CANDAI;
                                        var cannap = obj.CANNAP;
                                        $('.lblbox').text("");
                                        if (candai != "") {
                                            var _candai = candai.split(',');
                                            for (var i = 0; i < _candai.length; i++) {
                                                $('#txtCanLan' + (i + 1)).text(_candai[i]);
                                            }
                                        }
                                        if (cannap != "") {
                                            var _cannap = cannap.split(',');
                                            for (var i = 0; i < _candai.length; i++) {
                                                $('#txtCanNap' + (i + 1)).text(_cannap[i]);
                                            }
                                        }
                                        TinhDoanhThu();
                                    }
                                }
                                else if (data.status == 5005) {
                                    bootbox.alert("Tài khoản mất session vui lòng login lại!", function () {
                                        window.location.href = "Login.aspx?ref=-1";
                                    });
                                }
                                else {
                                    bootbox.alert(data.msg, function () {
                                        $('.lblbox').text("");
                                        $('#btnSubmitOrder').hide();
                                    });
                                }
                            }
                        });
                    }
                    else {
                        $('#txtCatDai').val("");
                        $('#txtCatRong').val("");
                        $('#txtKhoGiay_Dai').val("");
                        $('#txtKhoGiay_Rong').val("");
                        $('#txtSLSX').val("");
                        $('#txtCai').val("");
                        $('.lblbox').text("");
                    }
                },
                GetListOrderDetailTemp = function () {
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Order.ashx",
                        data: {
                            type: 4020,
                            mid: AppManage.getURLParameter('m')
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 0) {
                                ViewListOrderDetail(data.data);
                                $('#btnSaveOrder').fadeIn(0);
                            }
                            else if (data.status == -9998) {
                                $('#btnSaveOrder').fadeOut(0);
                                $('#tbl_order_detail tbody').html("<tr><td colspan='7'>Không có đơn hàng</td></tr>");
                            }
                            else {
                                bootbox.alert(data.msg);
                            }
                        }
                    });
                },
                GetListOrderUser = function () {
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Order.ashx",
                        data: {
                            type: 4022,
                            mid: AppManage.getURLParameter('m')
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 0) {
                                ViewListOrder(data.data);
                            }
                            else if (data.status == -9998) {
                                $('#tbl_OrderList tbody').html("<tr><td colspan='5'>Không có đơn hàng</td></tr>");
                            }
                            else {
                                bootbox.alert(data.msg);
                            }
                        }
                    });
                },
                GetListOrderDetail = function () {
                    $.ajax({
                        type: "POST",
                        url: "Apis/API_Order.ashx",
                        data: {
                            type: 4021,
                            mid: AppManage.getURLParameter('m'),
                            param: $('#madonhang_ID').val()
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 0) {

                            }
                            else {
                                bootbox.alert(data.msg);
                            }
                        }
                    });
                }
            return {
                init: function () {
                    $('.divLoading').fadeIn();
                    GetGiaCongDongDan();
                    GetLoaiDonHang();
                    GetLoaiHinhSX();
                    GetNhaCungCap();
                    GetKieuThung();
                    GetLoaiSong();
                    GetListOrderDetailTemp();
                    GetListOrderUser();
                },
                TinhToanKichThuoc: function () {
                    TinhToanKichThuoc();
                },
                GetListOrderDetailTemp: function () {
                    GetListOrderDetailTemp();
                },
                GetListOrderUser: function () {
                    GetListOrderUser();
                }
            };
        }();

        function ViewListOrderDetail(data) {
            $('#tbl_order_detail tbody').html("");
            $.each(data, function (key, obj) {
                if (key == 0) {
                    if(obj.Status == 0)
                        $('#btnSaveOrder').fadeIn(0);
                    else
                        $('#btnSaveOrder').fadeOut(0);
                }
                $('#tbl_order_detail tbody').append("<tr>" +
                    "<td>" + obj.STT + "</td>" +
                    "<td>" + obj.Ten_SP + "</td>" +
                    "<td>" + obj.MaThung + "</td>" +
                    "<td>" + obj.SL + "</td>" +
                    "<td>" + formatNumber(obj.Gia_Ban_Thung) + "</td>" +
                    "<td>" + formatNumber(obj.LoiNhuanTruocThue) + "</td>" +
                    "<td style='" + (obj.Status == 0 ? "width:150px;" : "width:40px;") + "'><a class='btn btn-sm grey-salsa btn-outline btnViewOrderDetail btn-circle' href='javascript:;' orderDetailID='" + obj.OrderDetail_ID + "' orderID='" + obj.Order_ID + "'>Xem</a>" +
                    (obj.Status == 0 ? "<a class='btn btn-sm grey-salsa btn-outline btnEditOrderDetail green btn-circle' href='javascript:;' orderDetailID='" + obj.OrderDetail_ID + "' orderID='" + obj.Order_ID + "'>Sửa</a>" +
                    "<a class='btn btn-sm grey-salsa btn-outline btnRemoveOrderDetail red btn-circle' href='javascript:;' orderID='" + obj.Order_ID + "' orderDetailID='" + obj.OrderDetail_ID + "' tenSP='" + obj.Ten_SP + "'>Xóa </a>" : "") + "</td</tr > ");
            });
        }

        function ViewListOrder(data) {
            $('#tbl_OrderList tbody').html("");
            $.each(data, function (key, obj) {
                $('#tbl_OrderList tbody').append("<tr choise='0' orderID='" + obj.Order_ID + "'>" +
                    "<td>" + obj.OrderCode + "</td>" +
                    "<td>" + obj.CompanyName + "</td>" +
                    "<td>" + formatNumber(obj.Gia_Ban_Bo > 0 ? obj.Gia_Ban_Bo : obj.Total) + "</td>" +
                    "<td>" + TrangThaiDonHang(obj.Status) + "</td>" +
                    "<td>" + (obj.Status == 0 ? "<a class='btn btn-sm grey-salsa btn-outline btnRemoveOrder' href='javascript:;'>Xóa</a>" : "") + "</td></tr>");
            });
        }

        function TrangThaiDonHang(status) {
            var color_arr = ["SILVER", 'BLUE', 'GREEN', 'BLACK', 'LIME', 'OLIVE', 'MAROON', 'TEAL', 'FUCHSIA', 'PURPLE'];
            var classbtn = color_arr[status];
            var trangthai = "";
            switch (parseInt(status)) {
                case 0: //mo don
                    trangthai = 'Mở Đơn';
                    break;
                case 1: // cho xu ly
                    trangthai = 'Chờ xử lý';
                    break;
                case 2: // thiết kế
                    trangthai = 'Thiết Kế';
                    break;
                case 3: // đặt giấy tấm
                    trangthai = 'Đặt Giấy Tấm';
                    break;
                case 4: // nhan giay tam
                    trangthai = 'Nhận Giấy Tấm';
                    break;
                case 5: // san xuat
                    trangthai = 'Đang SX';
                    break;
                case 6: // giao hang
                    trangthai = 'Giao Hàng';
                    break;
                case 7: // da giao hang'
                    trangthai = 'Đã Giao Hàng';
                    break;
                case 8: // thanh toan
                    trangthai = 'Thanh Toán';
                    break;
                case 9: // thanh toan cham
                    trangthai = 'Chậm Thanh Toán';
                    break;
                default:
                    trangthai = "";
                    classbtn = 'BLACK';
                    break;
            }
            return "<a style='border-color: " + classbtn + "; color: " + classbtn + "; background: 0 0;'" +
                " class='btn btn-sm btnDatGiayEdit btn-outline btn-circle' href='javascript:;'> " + trangthai + "</a>";
        }

        var validator; 
        var FormValidation = function () {
            var r = function () {
                var e = $("#form_Order"),
                    r = $(".alert-danger", e),
                    i = $(".alert-success", e);
                validator = e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        MaKH: {
                            required: !0
                        },
                        LoaiDonHang: {
                            required: !0
                        },
                        LoaiHinhSX: {
                            required: !0
                        },
                        NgayGiao: {
                            minlength: 10,
                            required: !0
                        },
                        KieuThung: {
                            required: !0
                        },
                        LoaiSong: {
                            required: !0
                        },
                        TenSP: {
                            required: !0
                        },
                        NhaCungCap: {
                            required: !0
                        },
                        QCKH_D: {
                            required: !0,
                            digits: !0
                        },
                        QCKH_R: {
                            required: !0,
                            digits: !0
                        },
                        QCKH_C: {
                            required: !0,
                            digits: !0
                        },
                        QCSX_D: {
                            required: !0,
                            digits: !0
                        },
                        QCSX_R: {
                            required: !0,
                            digits: !0
                        },
                        QCSX_C: {
                            required: !0,
                            digits: !0
                        },
                        QCSX_LuoiGa: {
                            required: !0,
                            digits: !0
                        },
                        SL: {
                            required: !0,
                            digits: !0
                        },
                        SL_Tang: {
                            required: !0,
                            digits: !0
                        },
                        SLBL: {
                            required: !0,
                            digits: !0
                        },
                        ChatLieu: {
                            required: !0
                        },
                        giabanthung: {
                            required: !0,
                            digits: !0,
                            min: 1
                        }
                    },
                    messages: {
                        MaKH: {
                            required: "Vui lòng chọn mã khách hàng!"
                        },
                        LoaiDonHang: {
                            required: "Vui lòng chọn!"
                            //minlength: jQuery.validator.format("Please select  at least {0} types of Service")
                        },
                        LoaiHinhSX: {
                            required: "Vui lòng chọn!"
                        },
                        NgayGiao: {
                            required: "Vui lòng chọn ngày!"
                        },
                        KieuThung: {
                            required: "Vui lòng chọn!"
                        },
                        LoaiSong: {
                            required: "Vui lòng chọn!"
                        },
                        TenSP: {
                            required: "Vui lòng nhập tên sản phẩm!"
                        },
                        NhaCungCap: {
                            required: "Vui lòng chọn nhà cung cấp!"
                        },
                        QCKH_D: {
                            required: "Vui lòng nhập kích thướt!"
                        },
                        QCKH_R: {
                            required: "Vui lòng nhập kích thướt!"
                        },
                        QCKH_C: {
                            required: "Vui lòng nhập kích thướt!"
                        },
                        QCSX_D: {
                            required: "Vui lòng nhập kích thướt!"
                        },
                        QCSX_R: {
                            required: "Vui lòng nhập kích thướt!"
                        },
                        QCSX_C: {
                            required: "Vui lòng nhập kích thướt!"
                        },
                        SL: {
                            required: "Vui lòng nhập số lượng!"
                        },
                        SL_Tang: {
                            required: "Vui lòng nhập số lượng!"
                        },
                        ChatLieu: {
                            required: "Vui lòng chọn chất liệu!"
                        },
                        giabanthung: {
                            required: "Vui lòng nhập giá mua!",
                            min: "Vui lòng nhập giá mua!"
                        }
                    },
                    invalidHandler: function (e, t) {
                        i.hide(), r.show();//App.scrollTo(r, -200);
                    },
                    errorPlacement: function (e, r) {
                        var i = $(r).parent(".input-icon").children("i");
                        i.removeClass("fa-check").addClass("fa-warning"), i.attr("data-original-title", e.text()).tooltip({
                            container: "body"
                        });
                    },
                    highlight: function (e) {
                        r.show(); i.hide();
                        $(e).closest(".form-group").removeClass("has-success").addClass("has-error");
                    },
                    unhighlight: function (e) {
                        $(e).closest(".form-group").removeClass("has-error");
                    },
                    success: function (e, r) {
                        var i = $(r).parent(".input-icon").children("i");
                        $(r).closest(".form-group").removeClass("has-error").addClass("has-success");
                        i.removeClass("fa-warning").addClass("fa-check");
                    },
                    submitHandler: function (e) {
                        i.show(), r.hide();
                    }
                }), $(".select2me", e).change(function () {
                    e.validate().element($(this))
                }), $(".date-picker").datepicker({
                    rtl: App.isRTL(),
                    autoclose: !0
                }), $(".input-icon .date-picker").change(function () {
                    e.validate().element($(this))
                })

            }
            return {
                init: function () {
                    r()
                }
            }
        }();
        
        function SubmitForm() {
            var loinhuantruocthue = replaceAll($('#txtLoiNhuanTruocThue').val(), ',', '');
            if (parseInt(loinhuantruocthue) < 0) {
                bootbox.confirm("Đơn hàng này có lợi nhuận bị lỗ!. Bạn có chắc muốn tiếp tục hay không?", function (r) {
                    if (r)
                        saveOrder();
                });
            }
            else {
                saveOrder();
            }
            
        }

        function saveOrder() {
            $('.divLoading1').fadeIn();
            var OrderDetailEntity = {
                "OrderDetail_ID": $('#ma_chitiet_donhang_ID').val(),
                "Address": $('#lblAddress').text(),
                "City": $('#selectProvince').val(),
                "Country": $('#country_ID').val(),
                "KM": $('#lblSoKM').text().replace('KM', '').replace(' ', ''),
                "Ngay_Mo_Don": $('#lblNgayMoDon').text(),
                "Ngay_Giao_Hang": $('#txtNgayGiao').val(),
                "LoaiThung_ID": $('#selectKieuThung').val(),
                "LoaiSong_ID": $('#selectLoaiSong').val(),
                "So_Don_KH": $('#txtSoDonKH').val(),
                "So_PO": $('#txtSoPO').val(),
                "Ten_SP": $('#txtTenSP').val(),
                "NhaCungCap_ID": $('#selectNhaCungCap').val(),
                "QuyCach_KH_D": $('#txtQCKH_Dai').val(),
                "QuyCach_KH_R": $('#txtQCKH_Rong').val(),
                "QuyCach_KH_C": $('#txtQCKH_Cao').val(),
                "QuyCach_SX_D": $('#txtQCSX_Dai').val(),
                "QuyCach_SX_R": $('#txtQCSX_Rong').val(),
                "QuyCach_SX_C": $('#txtQCSX_Cao').val(),
                "QuyCach_SX_LuoiGa": $('#txtLuoiGa').val(),
                "SL": $('#txtSL').val(),
                "SL_Tang": $('#txtSL_Tang').val(),
                "Thung_Cat_D": $('#txtCatDai').val(),
                "Thung_Cat_R": $('#txtCatRong').val(),
                "QuyCach_KhoGiay_D": $('#txtKhoGiay_Dai').val(),
                "QuyCach_KhoGiay_R": $('#txtKhoGiay_Rong').val(),
                "SLSX": $('#txtSLSX').val(),
                "SL_Bi_Lieu": $('#txtSLBL').val(),
                "Cai": $('#txtCai').val(),
                "ChatLieu_ID": $('#selectChatLieu').val(),
                "Dong_Dan_ID": $('#selectDongDanKim').val(),
                "So_Mau_In": $('#txtSoMauIn').val(),
                "In_An": $('#checkboxInAn').is(":checked"),
                "Can_bien": $('#checkboxCanBien').is(":checked"),
                "May_In": $('#checkboxMayIn').is(":checked"),
                "Cat_Ranh": $('#checkboxCatRanh').is(":checked"),
                "May_Be": $('#checkboxMayBe').is(":checked"),
                "Dong_Dinh": $('#checkboxDongDinh').is(":checked"),
                "Dan_Keo": $('#checkboxDangKeo').is(":checked"),
                "Dong_Goi": $('#selectDongGoi').val(),
                "Gia_Cong_DB": $('#txtGiaCongDB').val(),
                "Can_Nap": $('#txtCanNap1').text() + "|" + $('#txtCanNap2').text() + "|" + $('#txtCanNap3').text() + "|" + $('#txtCanNap4').text() + "|" + $('#txtCanNap5').text() + "|" + $('#txtCanNap6').text(),
                "Can_Lan": $('#txtCanLan1').text() + "|" + $('#txtCanLan2').text() + "|" + $('#txtCanLan3').text() + "|" + $('#txtCanLan4').text() + "|" + $('#txtCanLan5').text() + "|" + $('#txtCanLan6').text(),
                "Loai_Ban_In": $('#selectLoaiBanIn').val(),
                "Ma_So_Ban_In": $('#txtMaSoBanIn').val(),
                "Ma_So_Khuon_Be": $('#txtMaSoKhuonBe').val(),
                "Dinh_Kem": $('#selectKemTheo').val(),
                "DT_Cai": $('#txtDT').val(),
                "Tong_DT": $('#txtTotalDT').val(),
                "So_Met_Toi": $('#txtSoMetToi').val(),
                "SL_Toi_Thieu": $('#txtSLToiThieu').val(),
                "Gia_Ban_Thung": $('#txtGiaBanThung').val(),
                "Hoa_Hong": $('#txtHoaHong').val(),
                "Hoa_hong1": replaceAll($('#txtHoaHongHuong').val(),",", ""),
                "Ke_Gia": $('#txtKeGia').val(),
                "Gia_Ban_Bo": $('#txtGiaBanBo').val(),
                "Doanh_Thu_Ban_Hang": replaceAll($('#txtDoanhThuBanHang').val(),',',''),
                "Gia_Mua": replaceAll($('#txtGiaMua').val(),',',''),
                "Gia_Ban_Thuc_Te": replaceAll($('#txtGiaBanThucTe').val(),',',''),
                "Phan_Tram_Loi_Nhuan_Ban_Giay": $('#txtLoiNhuanThucTe').val().replace('%',''),
                "Gia_Von_Ban_Hang": replaceAll($('#txtGiaVonBanHang').val(),',',''),
                "Loi_Nhuan_Ban_Giay": replaceAll($('#txtLoiNhuanBanGiay').val(),',',''),
                "Phi_Hao_Hut_Giay": replaceAll($('#txtPhiHaoHut').val(),',',''),
                "Phi_Van_Chuyen": parseInt(replaceAll($('#txtPhiVanChuyen').val(), ',','')),
                "Phi_Ban_In": $('#txtPhiBanIn').val(),
                "Phi_Khuon_Be": $('#txtPhiKhuonBe').val(),
                "Phi_To_Khai": $('#txtPhiToKhai').val(),
                "Phi_Gia_Cong": replaceAll($('#txtPhiGiaCong').val(), ',',''),
                "Chi_Phi_Khac": $('#txtChiPhiKhac').val(),
                "Ghi_Chu_Don_Hang": $('#txtGhiChuDonHang').val(),
                "Ghi_Chu_SX": $('#txtGhiChuSX').val(),
                "Ghi_Chu_Giao_Hang": $('#txtChiChuGiaoHang').val()
            };
            var OrderEntity = {
                "Order_ID": $('#madonhang_ID').val(),
                "Ma_KH": $('#txtMaKH').val(),
                "Ky_Hieu_Don": $('#txtKyHieu').val(),
                "LoaiDon_ID": $('#selectLoaiDonHang').val(),
                "LoaiHinhSX_ID": $('#selectLoaiHinhSX').val()
            };
            var AddOrderInfo = {
                "orderDetail": OrderDetailEntity,
                "order": OrderEntity
            };
            $.ajax({
                type: "POST",
                url: "Apis/API_Order.ashx",
                data: {
                    type: $('#ma_chitiet_donhang_ID').val() == "0" ? 4016 : 4017,
                    mid: AppManage.getURLParameter('m'),
                    param: JSON.stringify(AddOrderInfo)
                },
                dataType: 'json',
                success: function (data) {
                    $('.divLoading1').fadeOut();
                    if (data.status > 0) {
                        $('#modal_order').modal('hide');
                        ViewListOrderDetail(data.data);
                        if(data.status == 1)
                            Page.GetListOrderUser();
                    }
                    else {
                        bootbox.alert(data.msg);
                    }
                }
            });
        }

        function formatNumber(num) {
            return num.toLocaleString('en-US');
        }

        function ResetForm() {
            var e = $("#form_Order"),
            r = $(".alert-danger", e),
            i = $(".alert-success", e);
            r.hide();
            i.hide();
            $('#txtSL').val(0);
            $('#country_ID').val(0);
            $('#txtSL_Tang').val(0);
            $('#txtSLBL').val(0);
            $('#txtTotalSL').val(0);
            $('#madonhang_ID').val("0");
            $('#ma_chitiet_donhang_ID').val("0");
            $('#txtCatDai').val("");
            $('#txtCatRong').val("");
            $('#txtKhoGiay_Dai').val("");
            $('#txtKhoGiay_Rong').val("");
            $('#txtSLSX').val("");
            $('#txtCai').val("");
            $('#txtSLBL').val("");
            $('#lblNgayMoDon').text(GetCurrentDate(0));
            $('#txtNgayGiao').attr('value', GetCurrentDate(3));
            $('#txtGiaBanThung').val(0);
            $('#txtDoanhThuBanHang').val(0);
            $('#txtGiaBanThucTe').val(0);
            $('#txtLoiNhuanThucTe').val(0);
            $('#txtGiaVonBanHang').val(0);
            $('#txtLoiNhuanBanGiay').val(0);
            $('#txtLuoiGa').val(32);
            $('#txtGiaBanBo').val(0);
            $('#txtKeGia').val(0);
            $('#txtHoaHong').val(0);
            $('#txtGiaMua').val(0);
            $('#txtPhiHaoHut').val(0);
            $('#txtPhiVanChuyen').val(0);
            $('#txtPhiBanIn').val(0);
            $('#txtPhiKhuonBe').val(0);
            $('#txtHoaHongHuong').val(0);
            $('#txtPhiToKhai').val(0);
            $('#txtPhiGiaCong').val(0);
            $('#txtChiPhiKhac').val(0);
            $('#txtTongChiPhi').val(0);
            $('#txtLoiNhuanTruocThue').val(0);
            $('#txtPhanTramLoiNhuan').val(0);

            $('#txtQCKH_Dai').val("");
            $('#txtQCKH_Rong').val("");
            $('#txtQCKH_Cao').val("");
            $('#txtQCSX_Dai').val("");
            $('#txtQCSX_Rong').val("");
            $('#txtQCSX_Cao').val("");
            $('#txtSoMauIn').val("");
            $('#txtGiaCongDB').val("");
            $('#txtSoDonKH').val("");
            $('#txtTenSP').val("");
            $('#txtSoPO').val("");
            $('#txtMaSoBanIn').val("");
            $('#txtMaSoKhuonBe').val("");
            $('#txtDT').val("");
            $('#txtTotalDT').val("");
            $('#txtSoMetToi').val("");
            $('#txtSLToiThieu').val("");

            $('#selectChatLieu').val("");
            $('#selectChatLieu').select2({
                showSearchInput: true
            });
            $('#selectNhaCungCap').val(1);
            $('#selectNhaCungCap').select2({
                showSearchInput: true
            });
            $('#selectKieuThung').val("");
            $('#selectKieuThung').select2({
                showSearchInput: true
            });
            $('#selectLoaiSong').val("");
            $('#selectLoaiSong').select2({
                showSearchInput: true
            });

            $(".date-picker").datepicker({
                rtl: App.isRTL(),
                format: "dd/mm/yyyy",
                orientation: "left",
                autoclose: !0
            });

            $('#checkboxInAn').prop("checked", false);
            $('#checkboxCanBien').prop("checked", false);
            $('#checkboxMayIn').prop("checked", false);
            $('#checkboxCatRanh').prop("checked", false);
            $('#checkboxMayBe').prop("checked", false);
            $('#checkboxDongDinh').prop("checked", false);
            $('#checkboxDangKeo').prop("checked", false);
            $('.lblbox').text("");
            $('#btnSubmitOrder').click();
        }

        function TinhDoanhThu() {
            var giaban = parseInt(replaceAll($('#txtGiaBanThung').val(),",",""));
            var sl_dat = parseInt($('#txtSL').val());
            var dt_thung = parseFloat($('#txtDT').val());
            var giamua = parseInt(replaceAll($('#txtGiaMua').val(),',',''));
            var slbl = parseInt($('#txtSLBL').val());
            var khogiay_rong = parseInt($('#txtKhoGiay_Rong').val());
            var khogiay_dai = parseInt($('#txtKhoGiay_Dai').val());
            var cai = parseInt($('#txtCai').val());
            var doanhthubanhang = 0;
            var giavonbanhang = 0;
            if (!isNaN(dt_thung) && !isNaN(giaban)) {
                if (giaban < 0)
                    giaban = 0;
                var giabanthucte = parseFloat(giaban / dt_thung);
                $('#txtGiaBanThucTe').val(formatNumber(Math.round(giabanthucte)));
                if (!isNaN(giamua)) {
                    var loinhuanthucte = parseFloat((giabanthucte - giamua) * 100 / giamua);
                    $('#txtLoiNhuanThucTe').val(Math.round(loinhuanthucte) + '%');
                }
                else {
                    giamua = 0;
                    $('#txtLoiNhuanThucTe').val(0);
                }
                var dt_giaymua = 0;
                if (!isNaN(khogiay_rong) && !isNaN(khogiay_dai) && !isNaN(cai) && !isNaN(slbl)) {
                    dt_giaymua = parseFloat(khogiay_rong/1000 * khogiay_dai/1000).toFixed(4);
                    giavonbanhang = Math.round(parseFloat(slbl * dt_giaymua * giamua));
                    $('#txtGiaVonBanHang').val(formatNumber(giavonbanhang));
                }
            }
            if (!isNaN(giaban) && !isNaN(sl_dat)) {
                if (giaban < 0)
                    giaban = 0;
                if (sl_dat < 0)
                    sl_dat = 0;
                doanhthubanhang = giaban * sl_dat;
                $('#txtDoanhThuBanHang').val(formatNumber(doanhthubanhang));
            }
            else
                $('#txtDoanhThuBanHang').val(0);
            $('#txtLoiNhuanBanGiay').val(formatNumber(doanhthubanhang - giavonbanhang));
            TinhHoaHong();
        }

        function TinhChiPhi() {
            TinhPhiHaoHut();
            TinhPhiVanChuyen();
            var loinhuanbangiay = parseInt(replaceAll($('#txtLoiNhuanBanGiay').val(),',',''));
            //console.log(loinhuanbangiay);
            if (isNaN(loinhuanbangiay))
                loinhuanbangiay = 0;
            var doanhthubanhang = parseInt(replaceAll($('#txtDoanhThuBanHang').val(),',',''));
            if (isNaN(doanhthubanhang))
                doanhthubanhang = 0;
            var phihaohut = parseInt(replaceAll($('#txtPhiHaoHut').val(),',',''));
            if (isNaN(phihaohut))
                phihaohut = 0;
            var phivanchuyen = parseInt(replaceAll($('#txtPhiVanChuyen').val(),',',''));
            if (isNaN(phivanchuyen))
                phivanchuyen = 0;
            var phibanin = parseInt(replaceAll($('#txtPhiBanIn').val(),',',''));
            if (isNaN(phibanin))
                phibanin = 0;
            var phikhuonbe = parseInt(replaceAll($('#txtPhiKhuonBe').val(),',',''));
            if (isNaN(phikhuonbe))
                phikhuonbe = 0;
            var hoahong = parseInt(replaceAll($('#txtHoaHongHuong').val(),',',''));
            if (isNaN(hoahong))
                hoahong = 0;
            var phitokhai = parseInt(replaceAll($('#txtPhiToKhai').val(),',',''));
            if (isNaN(phitokhai))
                phitokhai = 0;
            var phigiacong = parseInt(replaceAll($('#txtPhiGiaCong').val(),',',''));
            if (isNaN(phigiacong))
                phigiacong = 0;
            var chiphikhac = parseInt(replaceAll($('#txtChiPhiKhac').val(),',',''));
            if (isNaN(chiphikhac))
                chiphikhac = 0;
            var tongchiphi = phihaohut + phivanchuyen + phibanin + phikhuonbe + hoahong + phitokhai + phigiacong + chiphikhac;
            $('#txtTongChiPhi').val(formatNumber(tongchiphi));
            $('#txtLoiNhuanTruocThue').val(formatNumber(loinhuanbangiay - tongchiphi));
            if (doanhthubanhang > 0) {
                var phantramloinhuan = parseFloat((loinhuanbangiay - tongchiphi) * 100 / doanhthubanhang).toFixed(1);
                $('#txtPhanTramLoiNhuan').val(phantramloinhuan + "%");
            }
            else
                $('#txtPhanTramLoiNhuan').val(0);
        }

        function TinhHoaHong() {
            var hoahong = parseInt(replaceAll($('#txtHoaHong').val(),',',''));
            var doanhthu = parseInt(replaceAll($('#txtDoanhThuBanHang').val(),",",""));
            if (!isNaN(hoahong) && !isNaN(doanhthu))
                $('#txtHoaHongHuong').val(formatNumber(hoahong * doanhthu/100));
            TinhChiPhi();
        }

        function TinhPhiHaoHut() {
            if (parseInt($('#txtSoMetToi').val()) < 250 && $('#selectChatLieu').val() != "") {
                var sl = parseInt($('#txtSLToiThieu').val()) / parseInt($('#txtCai').val());
                var giavatlieu = parseInt(replaceAll($('#txtGiaMua').val(), ',', ''));
                var dt = parseFloat($('#txtDT').val());
                var m1 = dt * giavatlieu;
                var p = (m1 * sl) - (m1 * parseInt($('#txtSLBL').val()));
                var m2 = Math.round(p * 0.65);
                $('#txtPhiHaoHut').val(formatNumber(m2));      
                console.log("sl:" + sl + ", giavatlieu: " + giavatlieu + ", dt: " + dt);
                console.log("Gia1:" + (m1 * sl));
                console.log("Gia2:" + (m1 * parseInt($('#txtSLBL').val())));
                console.log("HaoHut: " + p);
                console.log("TongHaoHut(65%): " + m2);
            }
            else {
                $('#txtPhiHaoHut').val(0);
            }
        }

        function TinhPhiVanChuyen() {
            if ($('#lblSoKM').text() != "") {
                var km = parseInt($('#lblSoKM').text().replace(" KM"));
                var tongdt = 0;
                var somet = 0;
                if ($('#txtTotalDT').val() != "")
                    tongdt = parseInt($('#txtTotalDT').val());
                if ($('#txtSoMetToi').val() != "")
                    somet = parseInt($('#txtSoMetToi').val());
                var phivanchuyen = 0;
                var phigiacong = 0;
                if (!isNaN(km) && tongdt > 0) {
                    if (km > 0 && km < 51)
                        phivanchuyen = Math.round(500000/tongdt);
                    else if (km >= 51 && km < 61)
                        phivanchuyen = Math.round(600000/tongdt);
                    else if (km >= 61 && km < 61)
                        phivanchuyen = Math.round(km * 9000/tongdt);
                }
                $('#txtPhiVanChuyen').val(formatNumber(phivanchuyen));

                if (somet > 0 && somet < 50)
                    phigiacong = tongdt * 4500 + phivanchuyen;
                else if (somet > 0 && somet < 100)
                    phigiacong = tongdt * 4000 + phivanchuyen;
                else if (somet > 0 && somet < 150)
                    phigiacong = tongdt * 3500 + phivanchuyen;
                else if (somet > 0 && somet < 200)
                    phigiacong = tongdt * 3000 + phivanchuyen;
                else if (somet > 0 && somet < 250)
                    phigiacong = tongdt * 2700 + phivanchuyen;
                else if (somet > 0 && somet < 400)
                    phigiacong = tongdt * 2200 + phivanchuyen / 2;
                else
                    phigiacong = tongdt * 2000;
                $('#txtPhiGiaCong').val(formatNumber(phigiacong));
            }
        }

        function escapeRegExp(str) {
            return str.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
        }

        function replaceAll(str, find, replace) {
            return str.replace(new RegExp(escapeRegExp(find), 'g'), replace);
        }

        var _dateStart = null;
        var _dateEnd = null;
        var _dateReportStart = null;
        var _dateReportEnd = null;
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
                    minDate: moment().subtract('year', 2).format('MM/DD/YYYY'),
                    maxDate: moment().format('MM/DD/YYYY'),
                },
                function (start, end) {
                    _dateStart = start.format('YYYY/MM/DD');
                    _dateEnd = end.format('YYYY/MM/DD');
                    _dateReportStart = start.format('DD/MM/YYYY');
                    _dateReportEnd = end.format('DD/MM/YYYY');
                    console.log("Callback has been called!");
                    $('#dateRangeEvent input').val(start.format('MM/DD/YYYY') + ' - ' + end.format('MM/DD/YYYY'));
                    var tab = $('#listTab .active a').text();
                    switch (tab) {
                        case "ĐƠN HÀNG":
                            TableEditable.ViewDonHang();
                            break;                       
                        default:
                            break;
                    }
                    
                }
                );
                _dateStart = moment().subtract('month', 1).format('YYYY/MM/DD');
                _dateEnd = moment().format('YYYY/MM/DD');
                _dateReportStart = moment().subtract('month', 1).format('DD/MM/YYYY');
                _dateReportEnd = moment().format('DD/MM/YYYY');
                $('#dateRangeEvent input').val(_dateStart + ' - ' + _dateEnd);
            };

            return {
                init: function () {
                    handleDateRangePickers();
                }
            };
        }();

        var oTable_DonHang = null;
        var oTable_DonHangDatGiayTam = null;
        var oTable_DatGiayTam = null;
        var oTable_GiayTon = null;
        var oTable_DonHangSX = null;
        var _pageSize = 10;
        var TableEditable = function () {
            var ViewDonHang = function () {
                    var table = $('#tbl_viewdonhang');
                    loadTable();
                    function loadTable() {
                        $('.divLoading1').fadeIn();
                        var param = [];
                        param.push(_dateStart);
                        param.push(_dateEnd);
                        $.ajax({
                            type: "POST",
                            url: "Apis/Menu.ashx",
                            data: {
                                type: 13,
                                mid: 36,
                                p: JSON.stringify(param)
                            },
                            dataType: 'json',
                            success: function (data) {
                                if (data.status == 5005) {
                                    window.location.assign("login.aspx");
                                    return;
                                }
                                if (data.status == 0) {
                                    if (oTable_DonHang != null) {
                                        oTable_DonHang.fnDestroy();
                                    }
                                    var _dataColumn = data.columnName;
                                    $('#tbl_viewdonhang thead tr').html("");
                                    $.each(_dataColumn, function (key, obj) {
                                        $('#tbl_viewdonhang thead tr').append("<th>" + obj + "</th>");
                                    });
                                    $.each(data.data, function (key, obj) {
                                        obj[1] = TrangThaiDonHang(obj[1]);
                                    });
                                    var colHiden = [];
                                    oTable_DonHang = table.dataTable({
                                        "lengthMenu": [
                                            [10, 50, 100, 500, -1],
                                            [10, 50, 100, 500, "All"]
                                        ],
                                        dom: 'Bfrtip',
                                        buttons: [
                                            'copy',
                                            {
                                                extend: 'excel',
                                                messageTop: 'SAO KÊ CHI TIẾT ĐƠN HÀNG TỪ ' + _dateReportStart + ' ĐẾN ' + _dateReportEnd
                                            }
                                        ],
                                        "data": data.data,
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
                                    var bVis = oTable_DonHang.fnSettings().aoColumns[_dataColumn.length - 1].bVisible;
                                    oTable_DonHang.fnSetColumnVis(_dataColumn.length - 1, bVis ? false : true);

                                    var tableWrapper = $("#tbl_viewdonhang_wrapper");
                                    jQuery('#tbl_viewdonhang_wrapper .dataTables_filter input').addClass("form-control input-small");
                                    jQuery('#tbl_viewdonhang_wrapper .dataTables_length select').addClass("form-control input-small");
                                    jQuery('#tbl_viewdonhang_wrapper .dataTables_length select').select2();

                                    //tableWrapper.find(".viewdonhang_length select").select2({
                                    //    showSearchInput: false
                                    //});

                                    $("#tbl_viewdonhang").wrap("<div class='table-scrollable'></div>");
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
                                $(".divLoading1").fadeOut(500);
                            }
                        });
                    }
                },
                ViewDonHangDatGiayTam = function () {
                    $('.table_title').html("THÔNG TIN THEO DÕI ĐƠN HÀNG ĐẶT GIẤY TẤM");
                    $('#tbl_viewgiayton_wrapper').hide();
                    $('#tbl_viewdonhangdatgiaytam_wrapper').show();
                    var table = $('#tbl_viewdonhangdatgiaytam');
                    $('.divLoading1').fadeIn();
                    var param = [];
                    param.push(_dateStart);
                    param.push(_dateEnd);
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 38,
                            p: JSON.stringify(param)
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 5005) {
                                window.location.assign("login.aspx");
                                return;
                            }
                            if (data.status == 0) {
                                if (oTable_DonHangDatGiayTam != null) {
                                    oTable_DonHangDatGiayTam.fnDestroy();
                                }
                                var _dataColumn = data.columnName;
                                $('#tbl_viewdonhangdatgiaytam thead tr').html("<th></th>");
                                $.each(_dataColumn, function (key, obj) {
                                    $('#tbl_viewdonhangdatgiaytam thead tr').append("<th>" + obj + "</th>");
                                });
                                var listDH = [];
                                $.each(data.data, function (key, obj) {
                                    var arr = obj;
                                    if (obj[21] == 0) {
                                        arr.splice(0, 0, "<a class='btn btn-sm btnDatGiayEdit btn-outline btn-circle blue btnNhanGiay' href='javascript:;' id='" + obj[0] + "'>Nhận Giấy</a>" +
                                            "<a class='btn btn-sm btnDatGiayEdit btn-outline btn-circle red btnRemoveDatGiay' href='javascript:;' id='" + obj[0] + "'>Xóa</a>");
                                    }
                                    else {
                                        arr.splice(0, 0, "<a class='danhanhang' href='javascript:;'><i class='fa fa-check-circle'></i></a>");
                                    }
                                    listDH.push(arr);
                                });
                                var colHiden = [];
                                oTable_DonHangDatGiayTam = table.dataTable({
                                    "createdRow": function (row, data, dataIndex) {
                                        if (data[19] != "0") {
                                            $(row).addClass('redClass');
                                        }
                                    },
                                    "lengthMenu": [
                                        [10, 50, 100, 500, -1],
                                        [10, 50, 100, 500, "All"]
                                    ],
                                    dom: 'Bfrtip',
                                    buttons: [
                                        'copy',
                                        {
                                            extend: 'excel',
                                            messageTop: 'SAO KÊ CHI TIẾT ĐƠN HÀNG ĐẶT MUA GIẤY TẤM TỪ ' + _dateReportStart + ' ĐẾN ' + _dateReportEnd
                                        }
                                    ],
                                    "data": listDH,
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
                                var bVis = oTable_DonHangDatGiayTam.fnSettings().aoColumns[_dataColumn.length].bVisible;
                                oTable_DonHangDatGiayTam.fnSetColumnVis(_dataColumn.length, bVis ? false : true);
                                bVis = oTable_DonHangDatGiayTam.fnSettings().aoColumns[_dataColumn.length - 1].bVisible;
                                oTable_DonHangDatGiayTam.fnSetColumnVis(_dataColumn.length - 1, bVis ? false : true);
                                var tableWrapper = $("#tbl_viewdonhangdatgiaytam_wrapper");
                                jQuery('#tbl_viewdonhangdatgiaytam_wrapper .dataTables_filter input').addClass("form-control input-small");
                                jQuery('#tbl_viewdonhangdatgiaytam_wrapper .dataTables_length select').addClass("form-control input-small");
                                jQuery('#tbl_viewdonhangdatgiaytam_wrapper .dataTables_length select').select2();
                                $("#tbl_viewdonhangdatgiaytam").wrap("<div class='table-scrollable'></div>");
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
                            $(".divLoading1").fadeOut(500);
                        }
                    });
                },
                ViewDatGiayTam = function () {
                    var table = $('#tbl_viewdatgiaytam');
                    $('.divLoading1').fadeIn();
                    var param = [];
                    param.push(_dateStart);
                    param.push(_dateEnd);
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: $('#selectLoaiDon').val(),
                            p: JSON.stringify(param)
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 5005) {
                                window.location.assign("login.aspx");
                                return;
                            }
                            if (data.status == 0) {
                                if (oTable_DatGiayTam != null) {
                                    oTable_DatGiayTam.fnDestroy();
                                }
                                var _dataColumn = data.columnName;
                                $('#tbl_viewdatgiaytam thead tr').html("<th>Chọn</th>");
                                $.each(_dataColumn, function (key, obj) {
                                    $('#tbl_viewdatgiaytam thead tr').append("<th>" + obj + "</th>");
                                });
                                var listDH = [];
                                $.each(data.data, function (key, obj) {
                                    var arr = obj;
                                    arr.splice(0, 0, "<label class='mt-checkbox mt-checkbox-single mt-checkbox-outline'><input name='ckbox[]' type='checkbox' class='checkboxes checkbox_menu' value='" + obj[0] + "' /> <span></span> </label>");
                                    listDH.push(arr);
                                });
                                var colHiden = [0];
                                oTable_DatGiayTam = table.dataTable({
                                    "createdRow": function (row, data, dataIndex) {
                                        if (data[16] != "") {
                                            $(row).addClass('redClass');
                                        }
                                    },
                                    "lengthMenu": [
                                        [10, 50, 100, 500, -1],
                                        [10, 50, 100, 500, "All"]
                                    ],
                                    dom: 'Bfrtip',
                                    buttons: [
                                        'copy',
                                        {
                                            extend: 'excel',
                                            messageTop: 'SAO KÊ CHI TIẾT PHIẾU THU MUA GIẤY TẤM TỪ ' + _dateReportStart + ' ĐẾN ' + _dateReportEnd
                                        }
                                    ],
                                    "data": listDH,
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
                                        [5, "desc"]
                                    ]
                                });

                                var bVis = oTable_DatGiayTam.fnSettings().aoColumns[_dataColumn.length].bVisible;
                                oTable_DatGiayTam.fnSetColumnVis(_dataColumn.length, bVis ? false : true);

                                var tableWrapper = $("#tbl_viewdatgiaytam_wrapper");
                                jQuery('#tbl_viewdatgiaytam_wrapper .dataTables_filter input').addClass("form-control input-small");
                                jQuery('#tbl_viewdatgiaytam_wrapper .dataTables_length select').addClass("form-control input-small");
                                jQuery('#tbl_viewdatgiaytam_wrapper .dataTables_length select').select2();

                                //tableWrapper.find(".tbl_viewdatgiaytam_length select").select2({
                                //    showSearchInput: false
                                //});
                                $("#tbl_viewdatgiaytam").wrap("<div class='table-scrollable'></div>");
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
                            $(".divLoading1").fadeOut(500);
                        }
                    });
                },
                ViewGiayTon = function () {
                    $('.table_title').html("THÔNG TIN THEO DÕI GIẤY TỒN KHO");
                    $('#tbl_viewdonhangdatgiaytam_wrapper').hide();
                    $('#tbl_viewgiayton_wrapper').show();
                    var table = $('#tbl_viewgiayton');
                    $('.divLoading1').fadeIn();
                    var param = [];
                    param.push(_dateStart);
                    param.push(_dateEnd);
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 39,
                            p: JSON.stringify(param)
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 5005) {
                                window.location.assign("login.aspx");
                                return;
                            }
                            if (data.status == 0) {
                                if (oTable_GiayTon != null) {
                                    oTable_GiayTon.fnDestroy();
                                }
                                var _dataColumn = data.columnName;
                                $('#tbl_viewgiayton thead tr').html("<th></th>");
                                $.each(_dataColumn, function (key, obj) {
                                    $('#tbl_viewgiayton thead tr').append("<th>" + obj + "</th>");
                                });
                                var listDH = [];
                                $.each(data.data, function (key, obj) {
                                    var arr = obj;
                                    arr.splice(0, 0, "<a class='btn btn-sm btnDatGiayEdit btn-outline btn-circle blue btnUpdateGiayTon' href='javascript:;' id='" + obj[0] + "' slNhan='" + obj[12] + "' slTang='" + obj[13] + "'>Cập nhật</a>");
                                    listDH.push(arr);
                                });
                                var colHiden = [0];
                                oTable_GiayTon = table.dataTable({
                                    "lengthMenu": [
                                        [10, 50, 100, 500, -1],
                                        [10, 50, 100, 500, "All"]
                                    ],
                                    dom: 'Bfrtip',
                                    buttons: [
                                        'copy',
                                        {
                                            extend: 'excel',
                                            messageTop: 'SAO KÊ GIẤY TỒN KHO TỪ ' + _dateReportStart + ' ĐẾN ' + _dateReportEnd
                                        }
                                    ],
                                    "data": listDH,
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
                                var bVis = oTable_GiayTon.fnSettings().aoColumns[_dataColumn.length].bVisible;
                                oTable_GiayTon.fnSetColumnVis(_dataColumn.length, bVis ? false : true);
                                var tableWrapper = $("#tbl_viewgiayton_wrapper");
                                jQuery('#tbl_viewgiayton_wrapper .dataTables_filter input').addClass("form-control input-small");
                                jQuery('#tbl_viewgiayton_wrapper .dataTables_length select').addClass("form-control input-small");
                                jQuery('#tbl_viewgiayton_wrapper .dataTables_length select').select2();
                                $("#tbl_viewgiayton").wrap("<div class='table-scrollable'></div>");
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
                            $(".divLoading1").fadeOut(500);
                        }
                    });
                },
                ViewDonHangSX = function () {
                    var table = $('#tbl_viewDonHangSX');
                    $('.divLoading1').fadeIn();
                    var param = [];
                    param.push(_dateStart);
                    param.push(_dateEnd);
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 40,
                            p: JSON.stringify(param)
                        },
                        dataType: 'json',
                        success: function (data) {
                            if (data.status == 5005) {
                                window.location.assign("login.aspx");
                                return;
                            }
                            if (data.status == 0) {
                                if (oTable_DonHangSX != null) {
                                    oTable_DonHangSX.fnDestroy();
                                }
                                var _dataColumn = data.columnName;
                                $('#tbl_viewDonHangSX thead tr').html("<th></th>");
                                $.each(_dataColumn, function (key, obj) {
                                    $('#tbl_viewDonHangSX thead tr').append("<th>" + obj + "</th>");
                                });
                                var listDH = [];
                                $.each(data.data, function (key, obj) {
                                    obj[1] = TrangThaiDonHang(obj[1]);
                                    var arr = obj;
                                    arr.splice(0, 0, "<a class='btn btn-sm btnDatGiayEdit btn-outline btn-circle blue btnUpdateGiayTon' href='javascript:;' id='" + obj[0] + "'>Cập nhật</a>");
                                    listDH.push(arr);
                                });
                                var colHiden = [];
                                oTable_DonHangSX = table.dataTable({
                                    "createdRow": function (row, data, dataIndex) {
                                        console.log("SLBL: " + data[31]);
                                        if (parseInt(data[31]) < 250) {
                                            $(row).addClass('redClass');
                                        }
                                    },
                                    "lengthMenu": [
                                        [10, 50, 100, 500, -1],
                                        [10, 50, 100, 500, "All"]
                                    ],
                                    dom: 'Bfrtip',
                                    buttons: [
                                        'copy',
                                        {
                                            extend: 'excel',
                                            messageTop: 'SAO KÊ CHI TIẾT ĐƠN HÀNG SẢN XUẤT TỪ ' + _dateReportStart + ' ĐẾN ' + _dateReportEnd
                                        }
                                    ],
                                    "data": listDH,
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
                                var bVis = oTable_DonHangSX.fnSettings().aoColumns[_dataColumn.length].bVisible;
                                oTable_DonHangSX.fnSetColumnVis(_dataColumn.length, bVis ? false : true);

                                var tableWrapper = $("#tbl_viewDonHangSX_wrapper");
                                jQuery('#tbl_viewDonHangSX_wrapper .dataTables_filter input').addClass("form-control input-small");
                                jQuery('#tbl_viewDonHangSX_wrapper .dataTables_length select').addClass("form-control input-small");
                                jQuery('#tbl_viewDonHangSX_wrapper .dataTables_length select').select2();
                                $("#tbl_viewDonHangSX").wrap("<div class='table-scrollable'></div>");
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
                            $(".divLoading1").fadeOut(500);
                        }
                    });
                }

            return {
                ViewDonHang: function () {
                    ViewDonHang();
                },
                ViewDatGiayTam: function () {
                    ViewDatGiayTam();
                },
                ViewDonHangDatGiayTam: function () {
                    ViewDonHangDatGiayTam();
                },
                ViewGiayTon: function () {
                    ViewGiayTon();
                },
                ViewDonHangSX: function () {
                    ViewDonHangSX();
                }
            };
        }();
    </script>
</body>
</html>
