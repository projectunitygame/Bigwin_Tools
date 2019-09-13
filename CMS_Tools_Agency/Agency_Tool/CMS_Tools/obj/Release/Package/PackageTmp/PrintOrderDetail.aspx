<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintOrderDetail.aspx.cs" Inherits="CMS_Tools.PrintOrderDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TỜ LIỆT KÊ</title>
    <style>
        .table td, .table th {
            font-size: 14px !important;
            vertical-align: middle !important;
        }        

        .center {
            text-align: center;
        }

        .lblbox {
            border: 1px solid #ddd;
            width: 32px;
            height: 30px;
            text-align: center;
            vertical-align: middle;
            display: inherit;
        }

        .form-group {
            margin-bottom: 0 !important;
        }

        .tab-content {
            margin-top: 0px !important;
            margin-bottom: 15px;
            padding-top: 0px !important;
        }

        .tblOrderDetailPrint label {
            background: #FFF;
            padding: 4px 0px 3px 5px;
            display: inherit;
            width: 100%;
        }

        #input-group-addon {
            min-width: 100px;
            float: left;
            background-color: #e5e5e5 !important;
            color: #000 !important;
        }

        .tblOrderDetailPrint tr td {
            padding: 0 !important;
            text-align: center;
        }

        .tblOrderDetailPrint {
            margin-bottom: 15px !important;
        }

        .imgKieuThung {
            position: relative;
            margin: 10px 0;
            max-height: 260px;
            overflow: hidden;
        }

        .imgKieuThung img {
            width: 500px;
            margin-left:-7px;
        }

        .input-group-addon:first-child {
            font-size: 12px;
            border: 0px !important;
            padding: 6px 5px !important;
            min-width: 80px;
            text-align: left;
        }
        .input-group {
            width: 100%;
        }

        #lblGhiChu {
            padding: 5px;
        }

            #lblGhiChu p {
                margin: 0;
            }

        #tbl_order_detail .btn-sm {
            padding: 2px 8px !important;
            font-size: 11px !important;
        }

        .fa-check {
            display: none !important;
        }

        .input-icon.right > i {
            right: 20px !important;
        }
        .tbl_thongtinchitietdonhang tr th, .tbl_thongtinchitietdonhang tr td {
            border: 1px solid #1f1d1d !important;
        }
        .tbl_thongtinchitietdonhang{
            margin-bottom: 50px !important;
        }
        .profile .table-bordered, .profile .table-bordered td, .profile .table-bordered th {
            border-color: #c9dae6 !important;
        }

        .table-bordered th, .table-bordered td {
            border-color: #c9dae6 !important;
        }
        .titlePrint{
            clear: both;
            text-align: center;
            margin-bottom: 20px;
        }
        .tbl_thongtinchitietdonhang {transform:scale(.9);margin-left: -40px;}
        .line{
            margin: 35px 0;
            width: 100%;
            height: 1px;
            border: 1px dashed #ddd;
        }
        .line1{
            width: 100%;
            height: 100px;
        }
        p{margin: 5px !important;}
        .lblGhiChu{min-height:170px;}
        .text_inan{
            position: absolute;
            top: 50%;
            left: 50%;
            font-size: 20px;
            font-weight: bold;
            margin-left: -67px;
            margin-top: 0px;
            opacity: .5;
        }
    </style>
    <link href="assets/global/css/print/style.css" rel="stylesheet" />
    <link href="assets/global/css/print/print.css" rel="stylesheet" />
    <link href="assets/pages/css/kieuthung_print.css" rel="stylesheet" />
    <link href="assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/datatables/DT_bootstrap.css" rel="stylesheet" />  
    <link href="assets/global/css/plugins.css" rel="stylesheet" />
    <link href="assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/css/Style.css" rel="stylesheet" />
    <script src="assets/global/plugins/jquery.min.js"></script>
    <script>
        var countLoadImg = 0;
        var len = 0;
        $(function () {
            var orderID = $('#orderID').val();
            var p = $('#pagePrint').val();
            if (orderID == "" || p == "")
                return;
            $.ajax({
                type: "POST",
                url: "Apis/API_Order.ashx",
                data: {
                    type: 4026,
                    mid: 9,
                    pagePrint: p,
                    orderID: orderID
                },
                dataType: 'json',
                success: function (data) {
                    if (data.status == 0) {
                        len = data.data.length;
                        for (var i = 0; i < len; i++) {
                            var tableID = '#tbl_thongtinchitietdonhang_0 ';
                            if (i > 0) {
                                tableID = '#tbl_thongtinchitietdonhang_' + i + " ";
                                //console.log($('#tbl_thongtinchitietdonhang_0 tbody').html());
                                $('#listOrders').append("<div class='line'></div><div class='col-lg-6 col-md-6'>CTY TNHH TM-SX-DV ĐẠT PHÚ</div>"+
                                    "<div class='col-lg-6 col-md-6'></div>"+
                                    "<div class='titlePrint'><h3>TỜ LIỆT KÊ</h3></div>" +
                                    "<div class='col-lg-12 col-md-12'><label class='lblngayinlietke'></label></div>" +
                                    "<table id='tbl_thongtinchitietdonhang_" + i + "' class='tbl_thongtinchitietdonhang table table-bordered table-striped tblOrderDetailPrint'>" + $('#tbl_thongtinchitietdonhang_0 tbody').html() + "</table>");
                            }

                            var d = data.data[i];
                            $('#_orderDetailID').val(d.OrderDetail_ID);
                            $('#_orderID').val(d.Order_ID);
                            $('.lblngayinlietke').text("Ngày in liệt kê: " + $('#NgayIn').val());
                            $(tableID + '.lblNvkd').text(d.UserName);
                            $(tableID + '.lblMaKH').text(d.Ma_KH);
                            $(tableID + '.lblTenKH').text(d.CompanyName);
                            $(tableID + '.lblNgayMo').text(d.Ngay_Mo_Don);
                            $(tableID + '.lblNgayGiao').text(d.Ngay_Giao_Hang);
                            $(tableID + '.lblMaDH').text(d.MaDonHang);
                            $(tableID + '.lblSTT').text(d.STT + "/" + d.CountOrder);
                            $(tableID + '.lblPO').text(d.So_PO != "" ? d.So_PO : "");
                            $(tableID + '.lblSoDonKh').text(d.So_Don_KH != "" ? d.So_Don_KH : "");
                            $(tableID + '.lblTenSP').text(d.Ten_SP);
                            $(tableID + '.lblKyHieu').text(d.Ky_Hieu_Don != "" ? d.Ky_Hieu_Don : "");
                            $(tableID + '.lblDai').text(d.QuyCach_SX_D);
                            $(tableID + '.lblRong').text(d.QuyCach_SX_R);
                            $(tableID + '.lblCao').text(d.QuyCach_SX_C);
                            $(tableID + '.lblSL').text(d.SL);
                            $(tableID + '.lblSL_Tang').text(d.SL_Tang);
                            $(tableID + '.lblKieuDang').text(d.MaThung);
                            $(tableID + '.lblLopSong').text(d.TenLoaiSong);
                            $(tableID + '.lblRongThung').text(d.Thung_Cat_R);
                            $(tableID + '.lblDaiThung').text(d.Thung_Cat_D);
                            $(tableID + '.lblSongGiay').text(d.MaLoaiSong);
                            $(tableID + '.lblKhoGiay').text(d.QuyCach_KhoGiay_R);
                            $(tableID + '.lblDaiGiay').text(d.QuyCach_KhoGiay_D);
                            $(tableID + '.lblCaiTam').text(d.Cai);
                            $(tableID + '.lblSlGiayDat').text(d.SL_Bi_Lieu);
                            $(tableID + '.lblChatLieu').text(d.Ten_Chat_Lieu);
                            $(tableID + '.lblNhaCungCap').text(d.Ten_Nha_Cung_Cap);
                            $(tableID + '.lblDanDongKim').text(d.Dong_Dan);
                            var mauin = "";
                            if (d.MauIn != "")
                                mauin = "("+d.MauIn+")";
                            $(tableID + '.lblSoMauIn').text(d.So_Mau_In != "" ? d.So_Mau_In + mauin : "");
                            $(tableID + '.lblInAn').text(d.In_An == false ? "không" : "Có");
                            if (d.In_An == false)
                                $(tableID + '.text_inan').html("KHÔNG IN ẤN");
                            else
                                $(tableID + '.text_inan').html("");
                            $(tableID + '.lblCanBien').text(d.Can_bien == false ? "Không" : "Có");
                            $(tableID + '.lblNgayCanBien').text(d.Ngay_Can_Bien);
                            $(tableID + '.lblMayIn').text(d.May_In == false ? "Không" : "Có");
                            $(tableID + '.lblNgayMayIn').text(d.Ngay_In);
                            $(tableID + '.lblCatRanh').text(d.Cat_Ranh == false ? "Không" : "Có");
                            $(tableID + '.lblNgayCatRanh').text(d.Ngay_Cat_Ranh);
                            $(tableID + '.lblMayBe').text(d.May_Be == false ? "Không" : "Có");
                            $(tableID + '.lblNgayMayBe').text(d.Ngay_Be);
                            $(tableID + '.lblDongDinh').text(d.Dong_Dinh == false ? "Không" : "Có");
                            $(tableID + '.lblNgayDongDinh').text(d.Ngay_Dong_Dinh);
                            $(tableID + '.lblDanKeo').text(d.Dan_Keo == false ? "Không" : "Có");
                            $(tableID + '.lblNgayDanKeo').text(d.Ngay_Dan_keo);
                            $(tableID + '.lblDongGoi').text(d.Ten_Dong_Goi);
                            $(tableID + '.lblGiaCongDB').text(d.Gia_Cong_DB != "" ? d.Gia_Cong_DB : "");
                            $(tableID + '.lblLoaiBanIn').text(d.Loai_Ban_In == 1 ? "Bản mới" : d.Loai_Ban_In == 2 ? "Bản cũ" : "Sửa bản cũ");
                            $(tableID + '.lblMaBanIn').text(d.Ma_So_Ban_In != "" ? d.Ma_So_Ban_In : "");
                            $(tableID + '.lblMaKhuonBe').text(d.Ma_So_Khuon_Be != "" ? d.Ma_So_Khuon_Be : "");
                            $(tableID + '.lblDinhKem').text(d.Dinh_Kem == 1 ? "Theo mẫu" : "Bản vẽ");
                            $(tableID + '.lblDT_Cai').text(d.DT_Cai);
                            $(tableID + '.lblDT_Don').text(d.Tong_DT);
                            $(tableID + '.lblGhiChu').html("");
                            $(tableID + '.lblSLNhapKho').html(d.Sl_NhapKho > 0 ? d.Sl_NhapKho : "");
                            $(tableID + '.lblNgayNhapKho').html(d.NgayNhapKho);
                            if (d.Ghi_Chu_SX != "")
                                $(tableID + '.lblGhiChu').append("<p>Ghi chú SX: " + d.Ghi_Chu_SX + "</p>");
                            if (d.Ghi_Chu_Don_Hang != "")
                                $(tableID + '.lblGhiChu').append("<p>Ghi chú đơn hàng: " + d.Ghi_Chu_Don_Hang + "</p>");
                            if (d.Ghi_Chu_Giao_Hang != "")
                                $(tableID + '.lblGhiChu').append("<p>Ghi chú giao hàng: " + d.Ghi_Chu_Giao_Hang + "</p>");
                            if (d.Thung_Image.substring(0, 4) != "http")
                                d.Thung_Image = "https://" + d.Thung_Image;
                            $(tableID + '.imgKieuThung').html("<img src='" + d.Thung_Image + "'/>" +
                                "<div class='CanNap_" + d.LoaiThung_ID + "'></div>" +
                                "<div class='CanLan_" + d.LoaiThung_ID + "'></div>");

                            var cannap = d.Can_Nap.split('|');
                            var canlan = d.Can_Lan.split('|');
                            var s = 0;
                            for (var j = 0; j < cannap.length; j++) {
                                if (cannap[j] != "") {
                                    $(tableID + '.imgKieuThung .CanNap_' + d.LoaiThung_ID).append("<span>" + cannap[j] + "</span>");
                                    if(cannap.length > 1)
                                        s += parseInt(cannap[j]);
                                }
                            }
                            if (s > 0)
                                $(tableID + '.imgKieuThung .CanNap_' + d.LoaiThung_ID).append("<span>" + s + "</span>");
                            s = 0;
                            for (var j = 0; j < canlan.length; j++) {
                                if (canlan[j] != "") {
                                    $(tableID + '.imgKieuThung .CanLan_' + d.LoaiThung_ID).append("<span>" + canlan[j] + "</span>");
                                    if (canlan.length > 1)
                                        s += parseInt(canlan[j]);
                                }
                            }
                            if (s > 0)
                                $(tableID + '.imgKieuThung .CanLan_' + d.LoaiThung_ID).append("<span>" + s + "</span>");
                            var tmpImg = new Image();
                            tmpImg.src = $(tableID + '.imgKieuThung img').attr('src');
                            tmpImg.onload = function () {
                                console.log("loaded img");
                                callback(len);
                            };
                        } 
                    }
                    else
                        alert(data.msg);
                }
            });
        });

        function callback(len) {
            countLoadImg++;
            console.log("countLoadImg: " + countLoadImg + "/" + len);
            if (countLoadImg == len) {
                window.print();
            }
        }
    </script>
</head>
<body>
    <input type="hidden" id="orderID" runat="server"/>
    <input type="hidden" id="userName" runat="server"/>
    <input type="hidden" id="pagePrint" runat="server"/>
    <input type="hidden" id="NgayIn" runat="server"/>
    <div id="page-wrap">
        <div id="listOrders" style="padding:15px 0 0 25px;">
            <div class="col-lg-12 col-md-12" style="margin-top:10px;">CTY TNHH TM-SX-DV ĐẠT PHÚ</div>
            <div class="titlePrint"><h3>TỜ LIỆT KÊ</h3></div>
            <div class="col-lg-12 col-md-12"><label class="lblngayinlietke"></label></div>
            <table id="tbl_thongtinchitietdonhang_0" class="tbl_thongtinchitietdonhang table table-bordered table-striped tblOrderDetailPrint">
                <tbody>
                    <tr>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">MÃ KH
                                </span>
                                <label class="lblMaKH"></label>
                            </div>
                        </td>
                        <td style="width: 30%" colspan="6">
                            <div class="input-group">
                                <span class="input-group-addon">KH
                                </span>
                                <label class="lblTenKH"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">NGÀY MỞ
                                </span>
                                <label class="lblNgayMo"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">NGÀY GIAO
                                </span>
                                <label class="lblNgayGiao"></label>
                            </div>
                        </td>
                        <td style="width: 25%" colspan="5">
                            <div class="input-group">
                                <span class="input-group-addon">NVKD
                                </span>
                                <label class="lblNvkd"></label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">STT
                                </span>
                                <label class="lblSTT"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">MÃ ĐH
                                </span>
                                <label class="lblMaDH"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">KÝ HIỆU
                                </span>
                                <label class="lblKyHieu"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">SỐ ĐƠN KH
                                </span>
                                <label class="lblSoDonKh"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">SỐ PO
                                </span>
                                <label class="lblPO"></label>
                            </div>
                        </td>
                        <td style="width: 25%" colspan="5">
                            <div class="input-group">
                                <span class="input-group-addon">TÊN SP
                                </span>
                                <label class="lblTenSP"></label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">KIỂU DÁNG
                                </span>
                                <label class="lblKieuDang"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">DÀI
                                </span>
                                <label class="lblDai"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">RỘNG
                                </span>
                                <label class="lblRong"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">CAO
                                </span>
                                <label class="lblCao"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">SL
                                </span>
                                <label class="lblSL"></label>
                            </div>
                        </td>
                        <td style="width: 10%" colspan="2">
                            <div class="input-group">
                                <span class="input-group-addon">SL TẶNG
                                </span>
                                <label class="lblSL_Tang"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">LỚP SÓNG
                                </span>
                                <label class="lblLopSong"></label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">SÓNG GIẤY
                                </span>
                                <label class="lblSongGiay"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">R THÙNG
                                </span>
                                <label class="lblRongThung"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">D THÙNG
                                </span>
                                <label class="lblDaiThung"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">KHỔ GIẤY
                                </span>
                                <label class="lblKhoGiay"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">DÀI GIẤY
                                </span>
                                <label class="lblDaiGiay"></label>
                            </div>
                        </td>
                        <td style="width: 10%" colspan="2">
                            <div class="input-group">
                                <span class="input-group-addon">CÁI/TẤM
                                </span>
                                <label class="lblCaiTam"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">SL GIẤY ĐẶT
                                </span>
                                <label class="lblSlGiayDat"></label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">CHẤT LIỆU
                                </span>
                                <label class="lblChatLieu"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">CUNG ỨNG
                                </span>
                                <label class="lblNhaCungCap"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">DT/Cái
                                </span>
                                <label class="lblDT_Cai"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">DT/Đơn
                                </span>
                                <label class="lblDT_Don"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">MÃ BẢN IN
                                </span>
                                <label class="lblMaBanIn"></label>
                            </div>
                        </td>
                        <td style="width: 25%" colspan="5">
                            <div class="input-group">
                                <span class="input-group-addon">MÃ KHUÔN BẾ
                                </span>
                                <label class="lblMaKhuonBe"></label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">IN ẤN
                                </span>
                                <label class="lblInAn"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">SỐ MÀU IN
                                </span>
                                <label class="lblSoMauIn"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">KÈM THEO
                                </span>
                                <label class="lblDinhKem"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">ĐÓNG GÓI
                                </span>
                                <label class="lblDongGoi"></label>
                            </div>
                        </td>
                        <td style="width: 15%" colspan="3">
                            <div class="input-group">
                                <span class="input-group-addon">LOẠI BẢN IN
                                </span>
                                <label class="lblLoaiBanIn"></label>
                            </div>
                        </td>
                        <td style="width: 25%" colspan="5">
                            <div class="input-group">
                                <span class="input-group-addon">ĐÓNG/DÁN
                                </span>
                                <label class="lblDanDongKim"></label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="10" rowspan="9" style="width: 50%;position: relative;">
                            <div class="imgKieuThung" style="position: relative; transform: scale(.9);"></div>
                            <div class="text_inan"></div>
                        </td>
                        <td style="width: 10%; background: #eee;padding: 5px !important;" colspan="2">LOẠI MÁY
                        </td>
                        <td style="width: 10%; background: #eee;padding: 5px !important;" colspan="2">CÔNG ĐOẠN
                        </td>
                        <td style="width: 10%; background: #eee;padding: 5px !important;" colspan="2">NGÀY LẬP
                        </td>
                        <td style="width: 10%; background: #eee;padding: 5px !important;" colspan="2">SỐ LƯỢNG
                        </td>
                        <td style="width: 10%; background: #eee;padding: 5px !important;" colspan="2">KÝ NHẬN
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%;padding: 5px !important;" colspan="2">Máy Cán Biên
                        </td>
                        <td style="width: 10%;" colspan="2">
                            <span class="lblCanBien"></span>
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblNgayCanBien"></span>
                        </td>
                        <td style="width: 10%" colspan="2"></td>
                        <td style="width: 10%" colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%;padding: 5px !important;" colspan="2">Máy In
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblMayIn"></span>
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblNgayMayIn"></span>
                        </td>
                        <td style="width: 10%" colspan="2"></td>
                        <td style="width: 10%" colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%;padding: 5px !important;" colspan="2">Máy Cắt Rãnh
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblCatRanh"></span>
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblNgayCatRanh"></span>
                        </td>
                        <td style="width: 10%" colspan="2"></td>
                        <td style="width: 10%" colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%;padding: 5px !important;" colspan="2">Máy Bế
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblMayBe"></span>
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblNgayMayBe"></span>
                        </td>
                        <td style="width: 10%" colspan="2"></td>
                        <td style="width: 10%" colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%;padding: 5px !important;" colspan="2">Máy Đóng Đinh
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblDongDinh"></span>
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblNgayDongDinh"></span>
                        </td>
                        <td style="width: 10%" colspan="2"></td>
                        <td style="width: 10%" colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%;padding: 5px !important;" colspan="2">Dán Keo
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblDanKeo"></span>
                        </td>
                        <td style="width: 10%" colspan="2">
                            <span class="lblNgayDanKeo"></span>
                        </td>
                        <td style="width: 10%" colspan="2"></td>
                        <td style="width: 10%" colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%;padding: 5px !important;" colspan="2">Gia Công ĐB
                        </td>
                        <td style="width: 40%" colspan="8">
                            <span class="lblGiaCongDB"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%;padding: 5px !important;" colspan="2">Nhập Kho
                        </td>
                        <td style="width: 10%" colspan="2">
                        </td>
                        <td style="width: 10%" colspan="2"><span class="lblNgayNhapKho"></span></td>
                        <td style="width: 10%" colspan="2"><span class="lblSLNhapKho"></span></td>
                        <td style="width: 10%" colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="text-align: left; vertical-align: top !important;" colspan="20">
                            <div class="lblGhiChu"></div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>      
    </div>
</body>
</html>
