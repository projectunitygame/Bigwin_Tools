<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LayoutBanHang.aspx.cs" Inherits="CMS_Tools.LayoutBanHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


    <div id="main">
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
        <div class="profile-content">
            <div class="row">
                <div class="">
                    <div class="portlet light">
                        <div class="portlet-title tabbable-line">
                            <ul class="nav nav-tabs" id="listTab">
                                <li class="active">
                                    <a href="#tab_1_1" data-toggle="tab" aria-expanded="true">BÁO CÁO</a>
                                </li>
                                <li>
                                    <a href="#tab_1_2" data-toggle="tab" aria-expanded="false">BÁN HÀNG</a>
                                </li>
                                <li>
                                    <a href="#tab_1_3" data-toggle="tab" aria-expanded="false">HÓA ĐƠN</a>
                                </li>
                                <li>
                                    <a href="#tab_1_4" data-toggle="tab" aria-expanded="false">THIẾT KẾ</a>
                                </li>
                                <li>
                                    <a href="#tab_1_5" data-toggle="tab" aria-expanded="false">QUẢN LÝ SẢN XUẤT</a>
                                </li>
                                <li>
                                    <a href="#tab_1_6" data-toggle="tab" aria-expanded="false">SẢN XUẤT</a>
                                </li>
                                <li>
                                    <a href="#tab_1_7" data-toggle="tab" aria-expanded="false">THU MUA</a>
                                </li>
                                <li>
                                    <a href="#tab_1_8" data-toggle="tab" aria-expanded="false">GIAO HÀNG</a>
                                </li>
                                <li>
                                    <a href="#tab_1_9" data-toggle="tab" aria-expanded="false">KHO</a>
                                </li>
                                <li>
                                    <a href="#tab_1_10" data-toggle="tab" aria-expanded="false">KHÁCH HÀNG</a>
                                </li>
                                <li>
                                    <a href="#tab_1_11" data-toggle="tab" aria-expanded="false">ĐƠN HÀNG</a>
                                </li>
                            </ul>
                        </div>
                        <div class="portlet-body" style="padding: 0;">
                            <div class="tab-content">
                                <!-- PERSONAL INFO TAB -->
                                <div class="divLoading1" style="display: none;">
                                    <div class="lds-grid">
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
                                <div class="col-md-12 row">
                                    <div id="dateFilter" class="col-md-3 col-sm-12" style="margin-bottom: 10px; padding: 15px 15px 10px;">
                                        <label>Từ ngày mở đơn</label><br />
                                        <div class="input-group" id="dateRangeEvent">
                                            <input type="text" class="form-control" placeholder="Date Range(MM/DD/YYYY)" disabled />
                                            <span class="input-group-btn">
                                                <button class="btn default date-range-toggle fixbtndate" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>                                        
                                    </div>
                                    <div class="col-md-6 col-sm-12" style="padding: 30px 0px 0px 0px">
                                        <button id="btnSearchThuMua" type="button" class="btn blue btn-circle btnTabQlSX" style="margin-bottom: 30px;display:none"> Đặt mua giấy tấm</button>
                                        <button id="btnSearchDatGiayTam" type="button" class="btn green btn-circle btnTabQlSX" style="margin-bottom: 30px;display:none;"> Đơn hàng giấy tấm </button>
                                        <button id="btnSearchGiayTon" type="button" class="btn yellow btn-circle btnTabQlSX" style="margin-bottom: 30px;display:none;"> Giấy tồn kho </button>
                                    </div>
                                </div>
                                <div class="tab-pane active" id="tab_1_1">
                                </div>
                                <div class="tab-pane" id="tab_1_2">
                                    <div class="profile" style="padding:0;">
                                        <div class="col-md-3">
                                            <ul class="list-unstyled profile-nav">
                                                <li>
                                                    <img src="assets/pages/img/member.png" class="img-responsive pic-bordered" alt="">
                                                </li>
                                            </ul>

                                            <div class="col-md-12">
                                                <div class="portlet sale-summary">
                                                    <div class="portlet-title">
                                                        <div class="caption font-red sbold">Sales Summary </div>
                                                        <div class="tools">
                                                            <a class="reload" href="javascript:;" data-original-title="" title=""></a>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <ul class="list-unstyled">
                                                            <li>
                                                                <span class="sale-info">Today
                                                                            <i class="fa fa-img-up"></i>
                                                                </span>
                                                                <span class="sale-num">0</span>
                                                            </li>
                                                            <li>
                                                                <span class="sale-info">Monthly
                                                                            <i class="fa fa-img-down"></i>
                                                                </span>
                                                                <span class="sale-num">0</span>
                                                            </li>
                                                            <li>
                                                                <span class="sale-info">Total </span>
                                                                <span class="sale-num">0</span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <!--end row-->
                                            <div class="tabbable-line tabbable-custom-profile">
                                                <div class="portlet-body" style="margin-bottom: 30px;">
                                                    <button id="btnNewOrder" type="button" class="btn blue btn-circle" style="margin-bottom: 30px;"><i class="fa fa-edit"></i> Mở Đơn</button>
                                                    <button id="btnSaveOrder" type="button" class="btn green btn-circle" style="margin-bottom: 30px;display:none;"><i class="fa fa-save"></i> Lưu Đơn Hàng</button>
                                                    <button id="btnPrintOrder" type="button" class="btn default btn-circle" style="margin-bottom: 30px;display:none;"><i class="fa fa-print"></i> In Liệt Kê</button>
                                                    <ul class="nav nav-tabs">
                                                        <li class="active">
                                                            <a href="#tab_0_11" data-toggle="tab">CHI TIẾT ĐƠN HÀNG </a>
                                                        </li>
                                                    </ul>
                                                    <table id="tbl_order_detail" class="table table-striped table-bordered table-advance table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th style="width:30px;">STT</th>
                                                                <th>Tên Sản Phẩm</th>
                                                                <th style="width:90px;">Mã Thùng</th>
                                                                <th style="width:30px;">SL</th>
                                                                <th style="width:80px;">Đơn Giá</th>
                                                                <th style="width:100px;">Thành Tiền</th>
                                                                <th></th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <ul class="nav nav-tabs">
                                                    <li class="active">
                                                        <a href="#tab_2_1" data-toggle="tab">ĐƠN HÀNG </a>
                                                    </li>
                                                </ul>
                                                <div class="tab-content">
                                                    <div class="tab-pane active" id="tab_2_1" style="padding:0;">
                                                        <div class="portlet-body">
                                                            <table id="tbl_OrderList" class="table table-striped table-bordered table-advance table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th style="width:105px;">MÃ ĐƠN HÀNG</th>
                                                                        <th>KHÁCH HÀNG</th>
                                                                        <th style="width:100px;">TỔNG TIỀN</th>
                                                                        <th style="width:100px;">TRẠNG THÁI</th>
                                                                        <th style="width:50px;"></th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="tab_1_3">
                                </div>
                                <div class="tab-pane" id="tab_1_4">
                                </div>
                                <div class="tab-pane" id="tab_1_5">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table_title">THÔNG TIN CHI TIẾT ĐƠN HÀNG ĐẶT GIẤY TẤM</div>
                                            <div id="" class="dataTables_wrapper form-inline" role="grid">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_viewdonhangdatgiaytam"
                                                    aria-describedby="sample_1_info">
                                                    <thead><tr></tr></thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_viewgiayton"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr></tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div> 
                                </div>
                                <div class="tab-pane" id="tab_1_6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table_title">THÔNG TIN THEO DÕI ĐƠN HÀNG SẢN XUẤT</div>
                                            <div class="dataTables_wrapper form-inline" role="grid">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_viewDonHangSX"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr></tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="tab_1_7">
                                    <div class="row">
                                        <div class="col-md-12">
                                            
                                        </div>
                                    </div> 
                                </div>
                                <div class="tab-pane" id="tab_1_8">
                                </div>
                                <div class="tab-pane" id="tab_1_9">
                                </div>
                                <div class="tab-pane" id="tab_1_10">
                                </div>
                                <div class="tab-pane" id="tab_1_11">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table_title">THÔNG TIN CHI TIẾT ĐƠN HÀNG</div>
                                            <div class="dataTables_wrapper form-inline" role="grid">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_viewdonhang"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr></tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>                                   
                                </div>
                                <!-- END PRIVACY SETTINGS TAB -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="mySidebar" class="sidebar">
        <div class='btnSidebar' action="close" onclick="openNav(this)"><i class="icon-logout"></i></div>
    </div>

    <div id="modal_order" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <form action="#" id="form_Order" class="form-horizontal" novalidate="novalidate">
                    <input type="hidden" id="madonhang_ID" />
                    <input type="hidden" id="ma_chitiet_donhang_ID" />
                    <input type="hidden" id="country_ID" />
                    <div class="modal-body">
                        <div class="light portlet-fit portlet" style="margin-bottom: 0;">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-settings font-dark"></i>
                                    <span class="caption-subject font-dark sbold uppercase">MỞ ĐƠN HÀNG</span>
                                </div>
                                <div class="actions">
                                    <div class="btn-group btn-group-devided" data-toggle="buttons">
                                        <button id="btnSubmitOrder" type="submit" class="btn green-haze btn-outline btn-circle btn-sm"><i class="fa fa-plus"></i> Lưu</button>
                                        <button type="button" data-dismiss="modal" class="btn dark btn-outline btn-circle btn-sm"><i class="fa fa-close"></i> Hủy</button>
                                    </div>
                                </div>
                            </div>
                            <div class="form-body">
                                <div class="portlet-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="alert alert-danger display-hide">
                                                <button class="close" data-close="alert"></button>
                                                Vui lòng kiểm tra và nhập đầy đủ thông tin!
                                            </div>
                                            <div class="alert alert-success display-hide">
                                                <button class="close" data-close="alert"></button>
                                                Nhập thông tin hợp lệ
                                            </div>
                                            <div class="portlet-title tabbable-line">
                                                <ul class="nav nav-tabs">
                                                    <li class="active">
                                                        <a href="#tab_order_1" data-toggle="tab" aria-expanded="true">THÔNG TIN KHÁCH HÀNG</a>
                                                    </li>
                                                    <li class="">
                                                        <a href="#tab_order_2" data-toggle="tab" aria-expanded="false">THÔNG TIN ĐƠN HÀNG</a>
                                                    </li>
                                                    <li class="">
                                                        <a href="#tab_order_3" data-toggle="tab" aria-expanded="false">GIÁ</a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="tab-content" style="margin-top: 20px;">
                                                <div class="tab-pane active" id="tab_order_1">
                                                    <table id="tbl_thongtinkhachhang" class="table table-bordered table-striped">
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="12" style="text-align: center;">
                                                                    <input style="width: 300px; height: 34px; padding: 4px 6px; font-size: 13px; margin-right: 15px;" id="txtSearchKH" type="text" placeholder="Nhập thông tin khách hàng..." />
                                                                    <span class="loading1">
                                                                        <img src="assets/global/img/loading_spinner.gif" /></span>
                                                                    <button id="btnSearchKH" type="button" class="btn green btn-circle btn-sm btn-outline"><i class="icon-magnifier"></i> Tìm Kiếm</button>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 10%">Ngày Mở</td>
                                                                <td style="width: 10%">Ngày Giao</td>
                                                                <td style="width: 10%">Mã DC</td>
                                                                <td style="width: 10%">Mã KH</td>
                                                                <td style="width: 20%" colspan="2">Ký Hiệu</td>
                                                                <td style="width: 20%" colspan="2">Loại Đơn</td>
                                                                <td style="width: 20%" colspan="2">Loại Hình SX</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label id="lblNgayMoDon"></label>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input id="txtNgayGiao" name="NgayGiao" value="" type="text" class="form-control form-control-inline date-picker" maxlength="10" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <label id="lblMaDonHang"></label>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input id="txtMaKH" name="MaKH" type="text" class="form-control" readonly />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td colspan="2">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input id="txtKyHieu" name="KyHieu" type="text" class="form-control" maxlength="20" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td colspan="2">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <select tabindex="-1" class="form-control select2me" name="LoaiDonHang" id="selectLoaiDonHang" style="width: 100%;">
                                                                                </select>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td colspan="2">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <select tabindex="-1" class="form-control select2me" name="LoaiHinhSX" id="selectLoaiHinhSX" style="width: 100%;">
                                                                                </select>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <label id="lblCompanyName"></label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <label id="lblMST"></label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <label id="lblContact"></label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <label id="lblAddress"></label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <select class="form-control" id="selectProvince">
                                                                    </select>
                                                                </td>
                                                                <td colspan="2">
                                                                    <label id="lblSoKM"></label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">Ghi Chú Đơn Hàng</td>
                                                                <td colspan="8">
                                                                    <textarea id="txtGhiChuDonHang" rows="4" class="form-control" maxlength="2000"></textarea></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">Ghi Chú Sản Xuất</td>
                                                                <td colspan="8">
                                                                    <textarea id="txtGhiChuSX" rows="4" class="form-control" maxlength="2000"></textarea></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">Ghi Chú Giao Hàng</td>
                                                                <td colspan="8">
                                                                    <textarea id="txtChiChuGiaoHang" rows="4" class="form-control" maxlength="2000"></textarea></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="tab-pane" id="tab_order_2">
                                                    <table id="tbl_thongtindonhang" class="table table-bordered table-striped">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 20%" colspan="2">Kiểu Thùng</td>
                                                                <td style="width: 10%">Loại Sóng</td>
                                                                <td style="width: 10%">Số Đơn KH</td>
                                                                <td style="width: 20%" colspan="2">Tên Sản Phẩm</td>
                                                                <td style="width: 20%" colspan="2">Số PO</td>
                                                                <td style="width: 20%" colspan="2">Nhà Cung Cấp</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <select onchange="Page.TinhToanKichThuoc();" tabindex="-1" name="KieuThung" style="width: 100%;" id="selectKieuThung" class="form-control select2me">
                                                                                </select>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <select onchange="Page.TinhToanKichThuoc();" tabindex="-1" name="LoaiSong" style="width: 100%;" id="selectLoaiSong" class="form-control select2me">
                                                                                </select>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="SoDonKH" id="txtSoDonKH" type="text" class="form-control" maxlength="20" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td colspan="2">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="TenSP" id="txtTenSP" type="text" class="form-control" maxlength="100" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td colspan="2">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="SoPO" id="txtSoPO" type="text" class="form-control" maxlength="20" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td colspan="2">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <select name="NhaCungCap" style="width: 100%;" id="selectNhaCungCap" class="form-control select2me">
                                                                                </select>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <label>Quy Cách Khách Hàng</label></td>
                                                                <td colspan="3">
                                                                    <label>Quy Cách Sản Xuất</label></td>
                                                                <td>
                                                                    <label>Lưỡi Gà</label></td>
                                                                <td colspan="2">
                                                                    <label>Số Lượng</label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="QCKH_D" id="txtQCKH_Dai" type="text" class="form-control" placeholder="Dài" maxlength="8" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="QCKH_R" id="txtQCKH_Rong" type="text" class="form-control" placeholder="Rộng" maxlength="8" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="QCKH_C" id="txtQCKH_Cao" type="text" class="form-control" placeholder="Cao" maxlength="8" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input onchange="Page.TinhToanKichThuoc();" name="QCSX_D" id="txtQCSX_Dai" type="text" class="form-control" placeholder="Dài" maxlength="8" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input onchange="Page.TinhToanKichThuoc();" name="QCSX_R" id="txtQCSX_Rong" type="text" class="form-control" placeholder="Rộng" maxlength="8" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input onchange="Page.TinhToanKichThuoc();" name="QCSX_C" id="txtQCSX_Cao" type="text" class="form-control" placeholder="Cao" maxlength="8" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input onchange="Page.TinhToanKichThuoc();" name="QCSX_LuoiGa" id="txtLuoiGa" type="text" class="form-control" maxlength="5" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input onchange="Page.TinhToanKichThuoc();" name="SL" id="txtSL" type="text" class="form-control" placeholder="SL" maxlength="8" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input onchange="Page.TinhToanKichThuoc();" name="SL_Tang" id="txtSL_Tang" type="text" class="form-control" placeholder="SL Tặng" maxlength="5" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <input id="txtTotalSL" type="text" class="form-control" readonly />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">Cắt Dài,Rộng Thùng(Rộng,Dài)</td>
                                                                <td colspan="2">Quy Cách Đặt Mua(Rộng,Dài)</td>
                                                                <td>SL Sản Xuất</td>
                                                                <td>SL Bị Liệu</td>
                                                                <td>Cái/Tấm</td>
                                                                <td>Chất Liệu</td>
                                                                <td colspan="2">Đóng/Dán Kim</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input id="txtCatRong" type="text" class="form-control" readonly placeholder="Rộng" />
                                                                </td>
                                                                <td>
                                                                    <input id="txtCatDai" type="text" class="form-control" readonly placeholder="Dài" />
                                                                </td>
                                                                <td>
                                                                    <input id="txtKhoGiay_Rong" type="text" class="form-control" readonly placeholder="Rộng" />
                                                                </td>
                                                                <td>
                                                                    <input id="txtKhoGiay_Dai" type="text" class="form-control" readonly placeholder="Dài" />
                                                                </td>
                                                                <td>
                                                                    <input id="txtSLSX" type="text" class="form-control" readonly />
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="SLBL" id="txtSLBL" type="text" class="form-control" maxlength="8" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <input id="txtCai" type="text" class="form-control" readonly placeholder="Cái" />
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <select style="width: 100%;" name="ChatLieu" id="selectChatLieu" class="form-control select2me">
                                                                                </select>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td colspan="2">
                                                                    <select id="selectDongDanKim" class="form-control" style="width:100%;">
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Số Màu IN</td>
                                                                <td>In Ấn</td>
                                                                <td>Cán Biên</td>
                                                                <td>Máy In</td>
                                                                <td>Cắt Rãnh</td>
                                                                <td>Máy Bế</td>
                                                                <td>Đóng Đinh</td>
                                                                <td>Dán Keo</td>
                                                                <td colspan="2">Đóng Gói</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input id="txtSoMauIn" type="text" class="form-control" placeholder="" />
                                                                </td>
                                                                <td class="center">
                                                                    <label class="mt-checkbox">
                                                                        <input id="checkboxInAn" type="checkbox" value="1" />
                                                                        <span></span>
                                                                    </label>
                                                                </td>
                                                                <td class="center">
                                                                    <label class="mt-checkbox">
                                                                        <input id="checkboxCanBien" type="checkbox" value="1" />
                                                                        <span></span>
                                                                    </label>
                                                                </td>
                                                                <td class="center">
                                                                    <label class="mt-checkbox">
                                                                        <input id="checkboxMayIn" type="checkbox" value="1" />
                                                                        <span></span>
                                                                    </label>
                                                                </td>
                                                                <td class="center">
                                                                    <label class="mt-checkbox">
                                                                        <input id="checkboxCatRanh" type="checkbox" value="1" />
                                                                        <span></span>
                                                                    </label>
                                                                </td>
                                                                <td class="center">
                                                                    <label class="mt-checkbox">
                                                                        <input id="checkboxMayBe" type="checkbox" value="1" />
                                                                        <span></span>
                                                                    </label>
                                                                </td>
                                                                <td class="center">
                                                                    <label class="mt-checkbox">
                                                                        <input id="checkboxDongDinh" type="checkbox" value="1" />
                                                                        <span></span>
                                                                    </label>
                                                                </td>
                                                                <td class="center">
                                                                    <label class="mt-checkbox">
                                                                        <input id="checkboxDangKeo" type="checkbox" value="1" />
                                                                        <span></span>
                                                                    </label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <select id="selectDongGoi" class="form-control">
                                                                        <option value="1">Cột 2 đầu</option>
                                                                        <option value="2">Cột 1 đầu</option>
                                                                        <option value="2">Lót giấy 2 bên</option>
                                                                        <option value="2">Gói bao giấy</option>
                                                                        <option value="2">Gói nylon</option>
                                                                        <option value="2">Đóng thùng</option>
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Gia Công ĐB</td>
                                                                <td colspan="3">
                                                                    <input id="txtGiaCongDB" type="text" class="form-control" maxlength="500" /></td>
                                                                <td>Cán Nắp(rộng)</td>
                                                                <td colspan="2">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanNap1"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanNap2"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanNap3"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanNap4"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanNap5"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanNap6"></label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>Cán Lằn In(dài)</td>
                                                                <td colspan="2">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanLan1"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanLan2"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanLan3"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanLan4"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanLan5"></label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="lblbox" id="txtCanLan6"></label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">Loại Bản IN</td>
                                                                <td>Mã Số Bản IN</td>
                                                                <td>Mã Số Khuôn Bế</td>
                                                                <td colspan="2">Kèm Theo</td>
                                                                <td>DT/Cái(m2)</td>
                                                                <td>Tổng DT(m2)</td>
                                                                <td>Số Mét Tới</td>
                                                                <td>SL Tối Thiểu</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <select id="selectLoaiBanIn" class="form-control">
                                                                        <option value="1">Bản mới</option>
                                                                        <option value="2">Bản cũ</option>
                                                                        <option value="3">Sửa bản cũ</option>
                                                                    </select>
                                                                </td>
                                                                <td>
                                                                    <input id="txtMaSoBanIn" type="text" class="form-control" /></td>
                                                                <td>
                                                                    <input id="txtMaSoKhuonBe" type="text" class="form-control" /></td>
                                                                <td colspan="2">
                                                                    <select id="selectKemTheo" class="form-control">
                                                                        <option value="1">Theo mẫu</option>
                                                                        <option value="2">Bản vẽ</option>
                                                                    </select>
                                                                </td>
                                                                <td>
                                                                    <input id="txtDT" readonly type="text" class="form-control" /></td>
                                                                <td>
                                                                    <input id="txtTotalDT" readonly type="text" class="form-control" /></td>
                                                                <td>
                                                                    <input id="txtSoMetToi" readonly type="text" class="form-control" /></td>
                                                                <td>
                                                                    <input id="txtSLToiThieu" readonly type="text" class="form-control" /></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="tab-pane" id="tab_order_3">
                                                    <table id="tbl_chiphi" class="table table-bordered table-striped">
                                                        <tbody>
                                                            <tr>
                                                                <td>Giá Bán/Thùng</td>
                                                                <td>Hoa Hồng(%)</td>
                                                                <td>Kê Giá</td>
                                                                <td>Giá Bán/Bộ</td>
                                                                <td>Doanh Thu BH</td>
                                                                <td>Giá Mua/m2</td>
                                                                <td>Giá Bán Thực Tế/m2</td>
                                                                <td>Lợi Nhuận Bán Giấy(%)</td>
                                                                <td>Giá Vốn Bán Hàng</td>
                                                                <td>Lợi Nhuận Bán Giấy</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input id="txtGiaBanThung" name="giabanthung" type="text" class="form-control" maxlength="8" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="hoahong" id="txtHoaHong" type="text" class="form-control" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="kegia" id="txtKeGia" type="text" class="form-control" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <div class="input-icon right">
                                                                                <i class="fa tooltips"></i>
                                                                                <input name="giabanbo" id="txtGiaBanBo" type="text" class="form-control" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <input id="txtDoanhThuBanHang" type="text" class="form-control" readonly /></td>
                                                                <td>
                                                                    <input id="txtGiaMua" type="text" class="form-control" readonly /></td>
                                                                <td>
                                                                    <input id="txtGiaBanThucTe" type="text" class="form-control" readonly /></td>
                                                                <td>
                                                                    <input id="txtLoiNhuanThucTe" type="text" class="form-control" readonly /></td>
                                                                <td>
                                                                    <input id="txtGiaVonBanHang" type="text" class="form-control" readonly /></td>
                                                                <td>
                                                                    <input id="txtLoiNhuanBanGiay" type="text" class="form-control" readonly /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Phí Hao Hụt Giấy</td>
                                                                <td>Phí Vận Chuyển</td>
                                                                <td>Phí Bản IN</td>
                                                                <td>Phí Khuôn Bế</td>
                                                                <td>Hoa Hồng</td>
                                                                <td>Phí Tờ Khai</td>
                                                                <td>Phí Gia Công</td>
                                                                <td>Chi Phí Khác</td>
                                                                <td colspan="2">Tổng Chi Phí</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input id="txtPhiHaoHut" name="phihaohut" type="text" class="form-control" readonly/></td>
                                                                <td>
                                                                    <input id="txtPhiVanChuyen" name="phivanchuyen" type="text" class="form-control" readonly/></td>
                                                                <td>
                                                                    <input onchange="TinhChiPhi();" id="txtPhiBanIn" name="phibanin" type="text" class="form-control"/></td>
                                                                <td>
                                                                    <input onchange="TinhChiPhi();" id="txtPhiKhuonBe" name="phikhuonbe" type="text" class="form-control"/></td>
                                                                <td>
                                                                    <input id="txtHoaHongHuong" type="text" class="form-control" readonly/></td>
                                                                <td>
                                                                    <input onchange="TinhChiPhi();" id="txtPhiToKhai" name="phitokhai"  type="text" class="form-control"/></td>
                                                                <td>
                                                                    <input id="txtPhiGiaCong" name="phigiacong" type="text" class="form-control" readonly/></td>
                                                                <td>
                                                                    <input onchange="TinhChiPhi();" id="txtChiPhiKhac" name="chiphikhac" type="text" class="form-control"/></td>
                                                                <td colspan="2">
                                                                    <input id="txtTongChiPhi" type="text" class="form-control" readonly /></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="8">Lợi Nhuận Trước Thuế</td>
                                                                <td colspan="2">
                                                                    <input id="txtLoiNhuanTruocThue" type="text" class="form-control" readonly /></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="8">Phần Trăm Lợi Nhuận/Doanh Thu</td>
                                                                <td colspan="2">
                                                                    <input id="txtPhanTramLoiNhuan" type="text" class="form-control" readonly /></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div id="modal_ViewOrderDetail" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog modal-full" style="max-width: 1240px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="light portlet-fit portlet" style="margin-bottom: 0;">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-dark"></i>
                                <span class="caption-subject font-dark sbold uppercase">THÔNG TIN ĐƠN HÀNG</span>
                            </div>
                            <div class="actions">
                                <div class="btn-group btn-group-devided" data-toggle="buttons">
                                    <button type="button" class="btn dark btn-outline btn-circle btn-sm" id="btn_print"><i class="fa fa-print"></i> In</button>
                                    <button type="button" data-dismiss="modal" class="btn dark btn-outline btn-circle btn-sm"><i class="fa fa-close"></i> Đóng</button>
                                </div>
                            </div>
                        </div>
                        <div class="form-body">
                            <div class="portlet-body">
                                <input type="hidden" id="_orderDetailID"/>
                                <input type="hidden" id="_orderID"/>
                                <table id="tbl_thongtinchitietdonhang" class="table table-bordered table-striped tblOrderDetailPrint">
                                    <tbody>
                                        <tr>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        MÃ KH
                                                    </span>
                                                    <label id="lblMaKH"></label>
                                                </div>
                                            </td>
                                            <td style="width: 30%" colspan="6">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        KH
                                                    </span>
                                                    <label id="lblTenKH"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        NGÀY MỞ
                                                    </span>
                                                    <label id="lblNgayMo"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        NGÀY GIAO
                                                    </span>
                                                    <label id="lblNgayGiao"></label>
                                                </div>
                                            </td>
                                            <td style="width: 25%" colspan="5">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        NVKD
                                                    </span>
                                                    <label id="lblNvkd"></label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        STT
                                                    </span>
                                                    <label id="lblSTT"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        MÃ ĐH
                                                    </span>
                                                    <label id="lblMaDH"></label>
                                                </div>
                                            </td>                                           
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        KÝ HIỆU
                                                    </span>
                                                    <label id="lblKyHieu"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        SỐ ĐƠN KH
                                                    </span>
                                                    <label id="lblSoDonKh"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        SỐ PO
                                                    </span>
                                                    <label id="lblPO"></label>
                                                </div>
                                            </td>   
                                            <td style="width: 25%" colspan="5">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        TÊN SP
                                                    </span>
                                                    <label id="lblTenSP"></label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>        
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        KIỂU DÁNG
                                                    </span>
                                                    <label id="lblKieuDang"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        DÀI
                                                    </span>
                                                    <label id="lblDai"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        RỘNG
                                                    </span>
                                                    <label id="lblRong"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        CAO
                                                    </span>
                                                    <label id="lblCao"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        SL
                                                    </span>
                                                    <label id="lblSL"></label>
                                                </div>
                                            </td>
                                            <td style="width: 10%" colspan="2">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        SL TẶNG
                                                    </span>
                                                    <label id="lblSL_Tang"></label>
                                                </div>
                                            </td>                                       
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        LỚP SÓNG
                                                    </span>
                                                    <label id="lblLopSong"></label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        SÓNG GIẤY
                                                    </span>
                                                    <label id="lblSongGiay"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        R THÙNG
                                                    </span>
                                                    <label id="lblRongThung"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        D THÙNG
                                                    </span>
                                                    <label id="lblDaiThung"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        KHỔ GIẤY
                                                    </span>
                                                    <label id="lblKhoGiay"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        DÀI GIẤY
                                                    </span>
                                                    <label id="lblDaiGiay"></label>
                                                </div>
                                            </td>
                                            <td style="width: 10%" colspan="2">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        CÁI/TẤM
                                                    </span>
                                                    <label id="lblCaiTam"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        SL GIẤY ĐẶT
                                                    </span>
                                                    <label id="lblSlGiayDat"></label>
                                                </div>
                                            </td>                        
                                        </tr>
                                        <tr>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        CHẤT LIỆU
                                                    </span>
                                                    <label id="lblChatLieu"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        CUNG ỨNG
                                                    </span>
                                                    <label id="lblNhaCungCap"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        DT/Cái
                                                    </span>
                                                    <label id="lblDT_Cai"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        DT/Đơn
                                                    </span>
                                                    <label id="lblDT_Don"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        MÃ BẢN IN
                                                    </span>
                                                    <label id="lblMaBanIn"></label>
                                                </div>
                                            </td>
                                            <td style="width: 25%" colspan="5">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        MÃ KHUÔN BẾ
                                                    </span>
                                                    <label id="lblMaKhuonBe"></label>
                                                </div>
                                            </td>                               
                                        </tr>
                                        <tr>                 
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        IN ẤN
                                                    </span>
                                                    <label id="lblInAn"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        SỐ MÀU IN
                                                    </span>
                                                    <label id="lblSoMauIn"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        ĐÓNG/DÁN
                                                    </span>
                                                    <label id="lblDanDongKim"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        ĐÓNG GÓI
                                                    </span>
                                                    <label id="lblDongGoi"></label>
                                                </div>
                                            </td>
                                            <td style="width: 15%" colspan="3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        LOẠI BẢN IN
                                                    </span>
                                                    <label id="lblLoaiBanIn"></label>
                                                </div>
                                            </td>
                                            <td style="width: 25%" colspan="5">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        KÈM THEO
                                                    </span>
                                                    <label id="lblDinhKem"></label>
                                                </div>
                                            </td>
                                        </tr>                                     
                                        <tr>
                                            <td colspan="10" rowspan="9" style="width:50%">
                                                <div id="imgKieuThung" style="position:relative;"></div>
                                            </td>
                                            <td style="width:10%;background: #eee;padding: 3px !important;" colspan="2">
                                                LOẠI MÁY
                                            </td>
                                            <td style="width:10%;background: #eee;padding: 3px !important;" colspan="2">
                                                CÔNG ĐOẠN
                                            </td>
                                            <td style="width:10%;background: #eee;padding: 3px !important;" colspan="2">
                                                NGÀY
                                            </td>
                                            <td style="width:10%;background: #eee;padding: 3px !important;" colspan="2">
                                                SỐ LƯỢNG
                                            </td>
                                            <td style="width:10%;background: #eee;padding: 3px !important;" colspan="2">
                                                NGÀY LẬP BIỂU
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                Máy Cán Biên
                                            </td>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                <span id="lblCanBien"></span>
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                Máy In
                                            </td>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                <span id="lblMayIn"></span>
                                            </td>
                                            <td style="width:10%;" colspan="2">
                                            </td>
                                            <td style="width:10%;" colspan="2">
                                            </td>
                                            <td style="width:10%;" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                Máy Cắt Rãnh
                                            </td>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                <span id="lblCatRanh"></span>
                                            </td>
                                            <td style="width:10%;" colspan="2">
                                            </td>
                                            <td style="width:10%;" colspan="2">
                                            </td>
                                            <td style="width:10%;" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                Máy Bế
                                            </td>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                <span id="lblMayBe"></span>
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                Máy Đóng Đinh
                                            </td>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                <span id="lblDongDinh"></span>
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                Dán Keo
                                            </td>
                                            <td style="width:10%" colspan="2">
                                                <span id="lblDanKeo"></span>
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                            <td style="width:10%" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%;padding: 3px !important;" colspan="2">
                                                Gia Công ĐB
                                            </td>
                                            <td style="width:40%" colspan="8">
                                                <span id="lblGiaCongDB"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:50%;text-align: left; vertical-align: top !important;" colspan="10" rowspan="3">
                                                <div id="lblGhiChu"></div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="modal_ViewThuMuaGiayTam" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog modal-full" style="max-width: 1240px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="light portlet-fit portlet" style="margin-bottom: 0;">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-dark"></i>
                                <span class="caption-subject font-dark sbold uppercase">ĐẶT GIẤY TẤM</span>
                            </div>
                            <div class="actions">
                                <div class="btn-group btn-group-devided" data-toggle="buttons">
                                    <button type="button" class="btn btn-circle btn-sm blue" id="btn_datgiaytam" disabled="disabled"><i class="fa fa-plus"></i> Đặt Giấy Tấm</button>
                                    <button type="button" data-dismiss="modal" class="btn dark btn-outline btn-circle btn-sm"><i class="fa fa-close"></i> Đóng</button>
                                </div>
                            </div>
                        </div>
                        <div class="form-body">
                            <div class="portlet-body" style="padding-bottom: 20px;">
                                <div class="row">
                                    <div class="form-group" style="margin-bottom: 15px !important;">
                                        <div class="col-md-2"></div>
                                        <div class="col-md-8">
                                            <div class="col-md-6">
                                                <label class="col-md-4 control-label" style="line-height: 28px;">
                                                    Ngày đăt:
                                                </label>
                                                <div class="col-md-8">
                                                    <div class="input-group date form_meridian_datetime bs-datetime" id="txtNgayDatGiay" data-date="" style="margin-bottom: 8px;">
                                                        <input type="text" class="form-control" readonly />
                                                        <span class="input-group-addon" style="padding: 3px 7px;">
                                                            <button class="btn default date-set" type="button" style="padding: 0;background: transparent;">
                                                                <i class="fa fa-calendar"></i>
                                                            </button>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <label class="col-md-4 control-label" style="line-height: 28px;">
                                                    Ngày giao:
                                                </label>
                                                <div class="col-md-8">
                                                    <div class="input-group date form_meridian_datetime bs-datetime" id="txtNgayNhanGiay" data-date="">
                                                        <input type="text" class="form-control" readonly />
                                                        <span class="input-group-addon" style="padding: 3px 7px;">
                                                            <button class="btn default date-set" type="button" style="padding: 0;background: transparent;">
                                                                <i class="fa fa-calendar"></i>
                                                            </button>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="col-md-6">
                                                <label class="col-md-4 control-label" style="line-height: 28px;">
                                                    Ký hiệu đơn:
                                                </label>
                                                <div class="col-md-8">
                                                    <input type="text" class="form-control" id="txtKyhieudon"/>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2"></div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                                <div class="dataTables_wrapper form-inline" role="grid">
                                    <table class="table table-striped table-bordered table-hover dataTable" id="tbl_viewdatgiaytam"
                                        aria-describedby="sample_1_info">
                                        <thead>
                                            <tr></tr>
                                        </thead>
                                        <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                    </table>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="modal_nhangiaytam" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog modal-full" style="max-width: 500px;">
            <input type="hidden" id="id_datgiaytam"/>
            <div class="modal-content">
                <div class="modal-body">
                    <div class="light portlet-fit portlet" style="margin-bottom: 0;">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-dark"></i>
                                <span class="caption-subject font-dark sbold uppercase">NHẬN GIẤY TẤM</span>
                            </div>
                            <div class="actions">
                                <div class="btn-group btn-group-devided" data-toggle="buttons">
                                    <button type="button" class="btn btn-circle btn-sm blue" id="btn_nhangiaytam"><i class="fa fa-plus"></i> Xác Nhận</button>
                                    <button type="button" data-dismiss="modal" class="btn dark btn-outline btn-circle btn-sm"><i class="fa fa-close"></i> Đóng</button>
                                </div>
                            </div>
                        </div>
                        <div class="form-body">
                            <div class="portlet-body" style="padding-bottom: 20px;">
                                <div class="row">
                                    <div class="form-group" style="margin-bottom: 15px !important;">
                                        <div class="col-md-12">
                                            <label class="col-md-4 control-label" style="line-height: 28px;">
                                                Số lượng nhận:
                                            </label>
                                            <div class="col-md-8">
                                                <input type="number" class="form-control" id="txtSL_NhanGiayTam" />
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top: 10px;">
                                            <label class="col-md-4 control-label" style="line-height: 28px;">
                                                Số lượng tặng:
                                            </label>
                                            <div class="col-md-8">
                                                <input type="number" class="form-control" id="txtSLTang_NhanGiayTam" />
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top: 10px;">
                                            <label class="col-md-4 control-label" style="line-height: 28px;">
                                                Ghi chú:
                                            </label>
                                            <div class="col-md-8">
                                                <textarea class="form-control" id="txtGhiChu_NhanGiayTam" rows="5" style="height:100px !important"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="modal_capnhatgiaytonkho" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog modal-full" style="max-width: 500px;">
            <input type="hidden" id="id_giaytonkho"/>
            <div class="modal-content">
                <div class="modal-body">
                    <div class="light portlet-fit portlet" style="margin-bottom: 0;">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-dark"></i>
                                <span class="caption-subject font-dark sbold uppercase">CẬP NHẬT GIẤY TỒN KHO</span>
                            </div>
                            <div class="actions">
                                <div class="btn-group btn-group-devided" data-toggle="buttons">
                                    <button type="button" class="btn btn-circle btn-sm blue" id="btn_updateGiayTonKho"><i class="fa fa-plus"></i> Cập Nhật</button>
                                    <button type="button" data-dismiss="modal" class="btn dark btn-outline btn-circle btn-sm"><i class="fa fa-close"></i> Đóng</button>
                                </div>
                            </div>
                        </div>
                        <div class="form-body">
                            <div class="portlet-body" style="padding-bottom: 20px;">
                                <div class="row">
                                    <div class="form-group" style="margin-bottom: 15px !important;">
                                        <div class="col-md-12">
                                            <label class="col-md-4 control-label" style="line-height: 28px;">
                                                Số lượng nhận:
                                            </label>
                                            <div class="col-md-8">
                                                <input type="number" class="form-control" id="txtSL_Nhan" />
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top: 10px;">
                                            <label class="col-md-4 control-label" style="line-height: 28px;">
                                                Số lượng tặng:
                                            </label>
                                            <div class="col-md-8">
                                                <input type="number" class="form-control" id="txtSLTang_Nhan" />
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top: 10px;">
                                            <label class="col-md-4 control-label" style="line-height: 28px;">
                                                Số lượng Hàng Hư:
                                            </label>
                                            <div class="col-md-8">
                                                <input type="number" class="form-control" id="txtSL_HangHu" />
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top: 10px;">
                                            <label class="col-md-4 control-label" style="line-height: 28px;">
                                                Ghi chú:
                                            </label>
                                            <div class="col-md-8">
                                                <textarea class="form-control" id="txtGhiChu_TonKho" rows="5" style="height:100px !important"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
