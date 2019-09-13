<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_agency_info.aspx.cs" Inherits="CMS_Tools.Test_agency_web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        ::-webkit-scrollbar{
            width: 3px;
        }
 
        ::-webkit-scrollbar-track {
            -webkit-box-shadow: inset 0 0 3px rgba(0,0,0,0.3);
        }
 
        ::-webkit-scrollbar-thumb {
          background-color: #0d5383;
          outline: 1px solid slategrey;
        }
        .select2-container--bootstrap .select2-selection {
            font-size: 12px !important;
        }

        .select2-container--bootstrap .select2-selection--single {
            height: 30px !important;
        }

        .easy-autocomplete-container ul li, .easy-autocomplete-container ul .eac-category {
            font-size: 12px !important;
        }

        .loading1 {
            width: 28px;
            position: absolute;
            right: 1px; 
            bottom: -19px; 
        }

            .loading1 img {
                max-width: 100%;
            }

        .easy-autocomplete {
            float: left;
            margin-right: 10px;
        }

        #btnSearchKH {
            margin-top: 2px;
            float: left;
        }

        .table td{
            vertical-align: middle !important;
            font-size:11.5px !important;
            padding:4px 8px !important;
        }
        .table>tfoot>tr>td, .table>tfoot>tr>th{
            padding: 4px 10px !important;
        }
        #tbl_viewDonHangSX tr>td:nth-child(2), #tbl_viewdonhangqlsx tr>td:nth-child(2), #tbl_viewdonhang tr>td:nth-child(2){
            text-align:center;
        }
        .portlet.light > .portlet-title > .nav-tabs > li > a {
            color: #FFF !important;
            text-transform:uppercase;
        }

        .page-content {
            padding-top: 0px !important;
        }

        .page-bar, #PageTitle_PageTitle {
            display: none;
        }

        .sidebar {
            height: 100%;
            width: 20px;
            position: absolute;
            z-index: 1;
            top: 0;
            right: 0;
            background-color: #fafafa;
            overflow-x: hidden;
            transition: 0.5s;
            padding-top: 10px;
            border-left: 1px solid #e5e5e5;
        }

            .sidebar a {
                /*padding: 8px 8px 8px 32px;
                text-decoration: none;
                font-size: 25px;
                color: #818181;
                display: block;*/
                transition: 0.3s;
            }

            .sidebar a:hover {
                color: #1871af;
            }
            .sidebar a:hover>div {
                color: #1871af;
            }

        .btnSidebar {
            cursor: pointer;
            margin-top: 20px;
            position:absolute;
        }


        .sidebar .closebtn {
            position: absolute;
            top: 0;
            right: 25px;
            font-size: 36px;
            margin-left: 50px;
        }

        .openbtn {
            font-size: 20px;
            cursor: pointer;
            background-color: #111;
            color: white;
            padding: 10px 15px;
            border: none;
        }

            .openbtn:hover {
                background-color: #444;
            }

        #main {
            transition: margin-left .5s;
        }

        /* On smaller screens, where height is less than 450px, change the style of the sidenav (less padding and a smaller font size) */
        @media screen and (max-height: 450px) {
            .sidebar {
                padding-top: 15px;
            }

                .sidebar a {
                    font-size: 18px;
                }
        }

        .portlet > .portlet-title > .nav-tabs {
            float: left !important;
        }

        .portlet.light > .portlet-title > .nav-tabs > li.active > a {
            color: #36c6d3 !important;
        }
		.tabbable-line > .nav-tabs > li.active{
        	border-bottom: 0px !important
        }
        .portlet.light > .portlet-title > .nav-tabs > li > a {
            font-weight: bold;
        }

        .title1 {
            margin: 0;
            font-size: 22px;
            text-align: center;
        }

        .portlet-body .form-body {
            padding: 0 !important;
        }

        .form-control {
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            background-color: #fff;
            border: 1px solid #c2cad8;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

        .form-control2 {
            float: left;
            width: 50%;
            height: 34px;
            padding: 6px 12px;
            background-color: #fff;
            border: 1px solid #c2cad8;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

        .header1 {
            font-weight: bold;
            background: #eee;
            color: #565555;
            border: 1px solid #eee !important;
            font-size: 13px !important;
        }

        #PageContent_PageID .form-control {
            height: 30px !important;
            padding: 4px 6px !important;
            font-size: 13px !important;
        }

        .page-content .form-control {
            height: 30px !important;
            padding: 4px 6px !important;
            font-size: 13px !important;
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
            padding-bottom:10px;
            position:relative;
        }

        .tab-content {
            margin-top: 0px !important;
            padding-top: 0px !important;
            -webkit-border-radius: 5px !important;
            -moz-border-radius: 5px !important;
            border-radius: 5px !important;
            border: 1px solid #ffffff;
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

        #imgKieuThung {
            position: relative;
            margin: 10px 0;
        }

            #imgKieuThung img {
                width: 500px;
            }

        .input-group-addon:first-child {
            font-size: 11px;
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
            right: 5px !important;
        }
        .input-icon.right > .form-control {
            padding-right: 5px !important;
            padding-left: 5px !important;
        }
        #tbl_thongtinchitietdonhang tr th, #tbl_thongtinchitietdonhang tr td {
            border: 1px solid #ccc !important;
        }

        .profile .table-bordered, .profile .table-bordered td, .profile .table-bordered th {
            border-color: #c9dae6 !important;
        }

        .table-bordered th, .table-bordered td {
            border-color: #c9dae6 !important;
        }
        #tbl_viewDonHangSX tr>td {
            padding: 4px 6px !important;
        }
        .tab-content > .tab-pane {
            min-height: 200px;
            background: #FFF;
            padding: 10px;
        }

        .clearfix {
            clear: both;
        }

        .fixbtndate {
            padding: 4px 10px !important;
            border: 1px solid #c2cad8 !important;
        }
        .fixbtndate:hover{
            background: #5fb0e8;
        }
        #btnFindData {
            border: 0;
            background: transparent;
            position: relative;
            float: right;
            margin-top: -25px;
        }

        input::placeholder {
            font-size: 11px !important;
        }

        .tabbable-line > .nav-tabs > li.active > a {
            color: #36c6d3 !important;
        }

        .profile .tabbable-custom-profile .nav-tabs > li > a {
            font-size: 12px;
        }

        .nav-pills, .nav-tabs {
            margin-bottom: 0px !important;
        }

        .portlet.light {
            background-color: transparent !important;
        }

        .dataTables_wrapper .dt-buttons {
            float: left !important;
        }

        .page-content {
            background: #1f2b3d !important;
        }

        .portlet > .portlet-title {
            border-bottom: 1px solid #9fe4ea !important;
        }

        .table_title {
            text-align: center;
            font-weight: bold;
            font-size: 13px;
            background: rgba(227, 251, 249, 0.78);
            color: #306cb5;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid rgba(122, 216, 211, 0.72);
            -webkit-border-radius: 10px !important;
            -moz-border-radius: 10px !important;
            border-radius: 10px !important;
            text-transform: uppercase;
        }

        .btnTabQlSX, .btnTabSX {
            font-size: 12px !important;
            text-transform: uppercase !important;
            font-weight:600;
        }

        table th {
            text-transform: uppercase !important;
            font-size:11px !important;
        }

        .btnDatGiayEdit {
            padding: 2px 4px !important;
            font-size: 10px !important;
            min-width: 60px !important;
            margin-bottom: 3px !important;
            text-align: center !important;
        }

        .danhanhang {
            text-align: center;
            width: 70px;
            float: left;
            font-size: 20px;
            color: #24cc29;
        }
        .table>tfoot>tr>td, .table>tfoot>tr>th{padding:6px;}
        .table-striped > tbody > tr:nth-of-type(odd) {
            background-color: rgba(191, 192, 193, 0.2901960784313726) !important;
        }

        .table-hover > tbody > tr:hover, .table-hover > tbody > tr:hover > td {
            background: #d5f9f7 !important;
        }

        table thead tr,table tfoot tr {
            background: #1871af;
            color: #FFF;
        }

        table input:focus {
            background: rgba(227, 251, 249, 0.78) !important;
            border: 1px solid rgba(122, 216, 211, 0.72) !important;
        }

        .redClass {
            color: red;
        }
        #main .form-control {
            height: 30px !important;
            padding: 4px 6px !important;
            font-size: 13px !important;
        }
        .choise td{
            background: #d5f9f7 !important;
            background-color: #d5f9f7 !important;
        }
        .bootbox-body{
            padding: 20px;
        }
        .activeqlsx{
            background-color:orange !important;
            border:0 !important;
        }
        .lblFromNgayMoDon{
            color: #3598dc;
            font-weight: bold;
            text-transform: uppercase;
            font-size: 12px;
            margin-bottom: 3px;
        }
        #tblCanNap tr td, #tblCanDai tr td{padding:0 !important;}
        .portlet-title > .nav-tabs > li:hover > a{
            color: #36c6d3 !important;
        }
        .tabbable-line > .nav-tabs > li:hover {
            border-bottom: 0 !important;
        }
        .easy-pie-chart .title{padding:0;font-size:12px;}
        .portlet.light.portlet-fit > .portlet-body{min-height:100px; padding: 10px 5px 20px 18px;}
        .static-info .name {
            font-size: 11.5px;
        }
        .static-info .value {
            font-size: 11.5px;
        }
        .icon-btn{width:90px;}
        .ver-inline-menu li a{font-size: 12px !important;}

        .panel-account-agency{
             border-radius: 5px !important;
            padding: 20px 40px;
            border: 1px solid #26344b;
            margin-bottom: 20px;
        }
        .account-agency-title{
            background: #1f2b3d;
            padding: 15px;
            margin-bottom: 15px;
            border-radius: 5px !important;
        }
        .account-agency-title h2{
            color: #fff;
            text-align: center;
            font-size: 18px;
            margin:0;
            text-transform: uppercase;
            font-weight: bold;
        }
        .tab-content > .tab-pane{
            padding:0;
        }

        @media (max-width:991px){
            .profile ul.profile-nav img.pic-bordered{
                display: block;
                margin: auto;
                width:300px;
                max-width:100%;
            }
            .profile > .col-md-4{
                padding:15px;
            }
        }
        .easy-autocomplete{
            width:100% !important;
            padding-bottom: 10px;
        }
        #txtBalance,#txtBalance2{
            background:unset;
            font-weight: bold;
        }
#chartdiv {
  width: 100%;
  height: 250px;
}
#chartdiv2 {
  width: 100%;
  height: 500px;
}
.profile label{
    margin-top:0 !important;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
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
                                    <a href="#tab_1_1" data-toggle="tab" aria-expanded="false">TÀI KHOẢN</a>
                                </li>
                                <li>
                                    <a href="#tab_1_2" data-toggle="tab" aria-expanded="false">CHUYỂN TIỀN</a>
                                </li>
                                <li>
                                    <a href="#tab_1_3" data-toggle="tab" aria-expanded="false" style="display:none">YÊU CẦU RÚT TIỀN</a>
                                </li>
                                <li>
                                    <a href="#tab_1_4" data-toggle="tab" aria-expanded="false">Thống kê</a>
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
                                <div class="col-md-12 row" style="padding: 20px 0px 0px 0px">
                                </div>
                                <div class="tab-pane active" id="tab_1_1">
                                    <div class="profile" style="padding:0;">
                                        <div class="col-md-4">
                                            <ul class="list-unstyled profile-nav" style="display:none">
                                                <li>
                                                    <img src="assets/pages/img/member.png" class="img-responsive pic-bordered" alt="">
                                                </li>
                                            </ul>
                                            <ul class="ver-inline-menu tabbable margin-bottom-10">
                                                <li class="active">
                                                    <a data-toggle="tab" href="#tab_2-1" aria-expanded="true">
                                                        <i class="fa fa-cog"></i>Thông tin cá nhân </a>
                                                    <span class="after"></span>
                                                </li>
                                                <li class="">
                                                    <a data-toggle="tab" href="#tab_2-2" aria-expanded="true">
                                                        <i class="fa fa-balance-scale"></i>Hạn mức chuyển tiền </a>
                                                </li>
                                                <li class="">
                                                    <a data-toggle="tab" href="#tab_2-3" aria-expanded="false">
                                                        <i class="fa fa-lock"></i>Đổi mật khẩu </a>
                                                </li>
                                            </ul>
                                            <br/>
                                            <div id="chartdiv"></div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="tab-content">
                                                <div id="tab_2-1" class="tab-pane active">
                                                    <div class="col-md-10 col-md-offset-1 account-agency-title">
                                                        <h2>Thông tin tài khoản</h2>
                                                    </div>
                                                    <div class="col-md-10 col-md-offset-1 panel-account-agency" id="panel-info-agency">
                                                        <div class="form-group">
                                                            <label class="control-label">Mã đại lý</label>
                                                            <input type="text" readonly class="form-control" name="agencyCode">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Tên đại lý</label>
                                                            <input type="text" readonly class="form-control" name="displayName">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Số tài khoản</label>
                                                            <input type="text" readonly class="form-control" name="masterID">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Số tiền</label>
                                                            <input type="text" readonly class="form-control" name="balance">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Số điện thoại</label>
                                                            <input type="text" readonly class="form-control" name="phone" style="width: calc(100% - 70px);">
                                                            <a href="javascript:OpenFormChangePhone();" type="submit" class="btn blue" id="btn_change_phone" style="position: absolute;right: 0;height: 30px;top: 19px;line-height: 17px;">Thay đổi</a>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Email</label>
                                                            <input type="text" readonly class="form-control" name="email">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Kích hoạt số điện thoại</label>
                                                            <input type="text" readonly class="form-control" name="phoneActive">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Xác thực OTP</label>
                                                            <input type="text" readonly class="form-control" name="isOTP">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Thông tin liên hệ</label>
                                                            <input type="text" readonly class="form-control" name="agencyInfo" style="width: calc(100% - 70px);">
                                                            <a href="javascript:OpenFormChangeAgencyInfo();" type="submit" class="btn blue" id="btn_change_info" style="position: absolute;right: 0;height: 30px;top: 19px;line-height: 17px;">Thay đổi</a>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Trạng thái hiển thị</label>
                                                            <!--<input type="text" readonly class="form-control" name="displayStatus" style="width: calc(100% - 70px);">
                                                            <a href="javascript:OpenFormChangeDisplayStt();" type="submit" class="btn blue" id="btn_change_display" style="position: absolute;right: 0;height: 30px;top: 19px;line-height: 17px;">Thay đổi</a>-->
                                                            <div class="md-radio-inline">
                                                                <div class="md-radio has-error">
                                                                    <input type="radio" id="radioFlaseDisplay" name="radio" class="md-radiobtn" value="false">
                                                                    <label for="radioFlaseDisplay">
                                                                        <span class="inc"></span>
                                                                        <span class="check"></span>
                                                                        <span class="box"></span> Không hiển thị </label>
                                                                </div>
                                                                <div class="md-radio has-warning">
                                                                    <input type="radio" id="radioTrueDisplay" name="radio" value="true" class="md-radiobtn">
                                                                    <label for="radioTrueDisplay">
                                                                        <span class="inc"></span>
                                                                        <span class="check"></span>
                                                                        <span class="box"></span> Hiển thị </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Facebook link</label>
                                                            <input type="text" readonly class="form-control" name="fbLink" style="width: calc(100% - 70px);">
                                                            <a href="javascript:OpenFormChangeFBLink();" type="submit" class="btn blue" id="btn_change_fbLink" style="position: absolute;right: 0;height: 30px;top: 19px;line-height: 17px;">Thay đổi</a>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="tab_2-2" class="tab-pane">
                                                    <div class="col-md-10 col-md-offset-1 account-agency-title">
                                                        <h2>Hạn mức chuyển tiền</h2>
                                                    </div>
                                                    <div class="col-md-10 col-md-offset-1 panel-account-agency">
                                                        <form action="javascript:;" id="LimitTransactionForm">
                                                            <div class="alert alert-danger display-hide" id="alert-danger-ChangeLimitTransaction">
                                                                <button class="close" data-close="alert"></button>
                                                                Vui lòng kiểm tra và nhập đầy đủ thông tin!
                                                            </div>
                                                            <div class="alert alert-success display-hide" id="alert-success-ChangeLimitTransaction">
                                                                <button class="close" data-close="alert"></button>
                                                                Nhập thông tin hợp lệ
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Hạn mức mỗi lần giao dịch</label>
                                                                <input type="text" id="txtLimitTransaction" readonly class="form-control" name="limitTransaction" style="cursor:not-allowed">
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Thay đổi hạn mức mỗi lần giao dịch</label>
                                                                <select class="form-control" id="opLimiTrans" name="LimiTrans">
                                                                    <option value="0">Chọn hạn mức</option>
                                                                </select>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Hạn mức giao dịch trong ngày</label>
                                                                <input type="text" id="txtLimitTransactionDaily" readonly class="form-control" name="limitTransactionDaily" style="cursor:not-allowed">
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Thay đổi hạn mức giao dịch trong ngày</label>
                                                                <select class="form-control" id="opLimiTransDaily" name="LimiTransDaily">
                                                                    <option value="0">Chọn hạn mức</option>
                                                                </select>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Hình thức xác thực OTP</label>
                                                                <select class="form-control" id="opOTP" name="OTP">
                                                                    <option value="true">Qua SMS</option>
                                                                    <option value="false">Không xác thực</option>
                                                                </select>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Mã Captcha</label>
                                                                <div class="img-verifire-captcha">
                                                                    <img style="height: 34px; margin-right: 5px" class="captcha-img" id="captcha" src="Apis/Captcha.ashx">
                                                	                <img style="width:28px;cursor: pointer;margin: 4px 5px 0;" onclick="refresh_captcha();" src="assets/pages/img/login/reload.png">
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Nhập Captcha</label>
                                                                <input type="text" id="txtCaptchaChangeLimit" class="form-control" name="captcha">
                                                            </div>
                                                        
                                                            <div class="margin-top-10">
                                                                <center>
                                                                    <button type="submit" class="btn green">Xác nhận</button>
                                                                </center>
                                                            
                                                            </div>
                                                        </form>
                                                    </div>
                                                    
                                                </div>
                                                <div id="tab_2-3" class="tab-pane">
                                                    <div class="col-md-10 col-md-offset-1 account-agency-title">
                                                        <h2>Đổi mật khẩu</h2>
                                                    </div>
                                                    <div class="col-md-10 col-md-offset-1 panel-account-agency">
                                                        <form action="javascript:;" id="ChangePasswordForm">
                                                            <div class="alert alert-danger display-hide" id="alert-danger-ChangePassword">
                                                                <button class="close" data-close="alert"></button>
                                                                Vui lòng kiểm tra và nhập đầy đủ thông tin!
                                                            </div>
                                                            <div class="alert alert-success display-hide" id="alert-success-ChangePassword">
                                                                <button class="close" data-close="alert"></button>
                                                                Nhập thông tin hợp lệ
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Mật khẩu cũ</label>
                                                                <input id="txtOldPassword" type="password" name="oldpassword" class="form-control">
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Mật khẩu mới</label>
                                                                <input id="txtNewPassword" type="password" name="newpassword" class="form-control">
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Nhập lại mật khẩu mới</label>
                                                                <input id="txtReNewPassword" type="password" name="renewpassword" class="form-control">
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Mã Captcha</label>
                                                                <div class="img-verifire-captcha">
                                                                    <img style="height: 34px; margin-right: 5px" id="captcha2" class="captcha-img" src="Apis/Captcha.ashx">
                                                	                <img style="width:28px;cursor: pointer;margin: 4px 5px 0;" onclick="refresh_captcha();" src="assets/pages/img/login/reload.png">
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Nhập Captcha</label>
                                                                <input type="text" id="txtCaptchaChangePass" class="form-control" name="captcha">
                                                            </div>
                                                            <div class="margin-top-10">
                                                                <center>
                                                                    <button type="submit" href="javascript:" class="btn green">Xác nhận</button>
                                                                </center>
                                                            </div>
                                                        </form>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="tab_1_2">
                                    <div class="profile" style="padding:0;">
                                        <div class="col-md-4">
                                            <ul class="ver-inline-menu tabbable margin-bottom-10">
                                                <li class="active">
                                                    <a data-toggle="tab" href="#tab_3-1" aria-expanded="true">
                                                        <i class="fa fa-users"></i>Chuyển tiền cho đại lý </a>
                                                    <span class="after"></span>
                                                </li>
                                                <li class="">
                                                    <a data-toggle="tab" href="#tab_3-2" aria-expanded="true">
                                                        <i class="fa fa-user"></i>Chuyển tiền tài khoản game </a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="tab-content">
                                                <div id="tab_3-1" class="tab-pane active">
                                                    <div class="col-md-10 col-md-offset-1 account-agency-title">
                                                        <h2>Chuyển tiền cho đại lý</h2>
                                                    </div>
                                                    <div class="col-md-10 col-md-offset-1 panel-account-agency">
                                                        <form action="javascript:" id="TransferMoneyToAgencyForm">
                                                            <div class="alert alert-danger display-hide" id="alert-danger-TransferMoneyToAgency">
                                                                <button class="close" data-close="alert"></button>
                                                                Vui lòng kiểm tra và nhập đầy đủ thông tin!
                                                            </div>
                                                            <div class="alert alert-success display-hide" id="alert-success-TransferMoneyToAgency">
                                                                <button class="close" data-close="alert"></button>
                                                                Nhập thông tin hợp lệ
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Số dư tài khoản</label>
                                                                <input type="text" id="txtBalance" readonly class="form-control" name="balance">
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Số tài khoản gửi</label>
                                                                <input type="text" id="txtSenderID" readonly class="form-control" name="senderID" style="cursor:not-allowed">
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Số tài khoản nhận</label>
                                                                <input type="text" id="txtRecipientID" class="form-control" name="recipientID" placeholder="Nhập mã đại lí/ tên đại lý/ số điện thoại">
                                                                <span class="loading1" style="display: none;"><img style="max-width: 100%;" src="assets/global/img/loading_spinner.gif"></span>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="form-group">
                                                                <label class="control-label">Số tiền</label>
                                                                <input type="text" id="txtAmount" class="form-control" name="amount" placeholder="Nhập số tiền tối thiểu 100000"> 
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Ghi chú</label>
                                                                <textarea id="txtReason" class="form-control"  name="reason" style="resize: none; height:auto !important" rows="3" cols="1"></textarea>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Mã Captcha</label>
                                                                <div class="img-verifire-captcha">
                                                                    <img style="height: 34px; margin-right: 5px" class="captcha-img" id="captcha3" src="Apis/Captcha.ashx">
                                                	                <img style="width:28px;cursor: pointer;margin: 4px 5px 0;" onclick="refresh_captcha();" src="assets/pages/img/login/reload.png">
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Nhập Captcha</label>
                                                                <input type="text" id="txtCaptchaTransferMoneyToAgency" class="form-control" name="captcha">
                                                            </div>
                                                            <div class="margin-top-10">
                                                                <center>
                                                                    <button type="submit" class="btn green">Xác nhận </button>
                                                                </center>
                                                            </div>
                                                        </form>
                                                        <form action="javascript:TransferMoneyToAgency()" id="TransferMoneyToAgencyOTPForm" style="display:none">
                                                            <div class="form-group">
                                                                <label class="control-label">Nhập OTP</label>
                                                                <input type="text" id="txtOTP" class="form-control" name="OTP"  value="">
                                                            </div>
                                                            <div class="margin-top-10">
                                                                <center>
                                                                    <button type="submit" class="btn green">Xác nhận </button>
                                                                </center>
                                                            </div>
                                                        </form>
                                                    </div>
                                                </div>
                                                <div id="tab_3-2" class="tab-pane">
                                                    <div class="col-md-10 col-md-offset-1 account-agency-title">
                                                        <h2>Chuyển tiền cho tài khoản game</h2>
                                                    </div>
                                                    <div class="col-md-10 col-md-offset-1 panel-account-agency">
                                                        <form action="javascript:" id="TransferMoneyToUserForm">
                                                            <div class="alert alert-danger display-hide" id="alert-danger-TransferMoneyToUser">
                                                                <button class="close" data-close="alert"></button>
                                                                Vui lòng kiểm tra và nhập đầy đủ thông tin!
                                                            </div>
                                                            <div class="alert alert-success display-hide" id="alert-success-TransferMoneyToUser">
                                                                <button class="close" data-close="alert"></button>
                                                                Nhập thông tin hợp lệ
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Số dư tài khoản</label>
                                                                <input type="text" id="txtBalance2" readonly class="form-control" name="balance">
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Số tài khoản gửi</label>
                                                                <input type="text" id="txtSenderID2" readonly class="form-control" name="senderID">
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Tài khoản game nhận</label>
                                                                <input type="text" id="txtRecipientID2" class="form-control" name="recipientID" placeholder="Nhập tên hiển thị/ tên đăng nhập/ số điện thoại">
                                                                <span class="loading1" style="display: none;"><img style="max-width: 100%;" src="assets/global/img/loading_spinner.gif"></span>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="form-group">
                                                                <label class="control-label">Số tiền</label>
                                                                <input type="text" id="txtAmount2" class="form-control" name="amount" placeholder="Nhập số tiền tối thiểu 100000">
                                                            </div>
                                                            <div class="form-group" id="TransactionFee" style="display:none">
                                                                <label class="control-label">Phí giao dịch(2%)</label>
                                                                <input type="text" id="txtTransactionFee" class="form-control" disabled>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Ghi chú</label>
                                                                <textarea id="txtReason2" class="form-control"  name="reason" style="resize: none; height:auto !important" rows="3" cols="1"></textarea>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Mã Captcha</label>
                                                                <div class="img-verifire-captcha">
                                                                    <img style="height: 34px; margin-right: 5px" class="captcha-img" id="captcha4" src="Apis/Captcha.ashx">
                                                	                <img style="width:28px;cursor: pointer;margin: 4px 5px 0;" onclick="refresh_captcha();" src="assets/pages/img/login/reload.png">
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label">Nhập Captcha</label>
                                                                <input type="text" id="txtCaptchaTransferMoneyToUser" class="form-control" name="captcha">
                                                            </div>
                                                            <div class="margin-top-10">
                                                                <center>
                                                                    <button type="submit" class="btn green">Xác nhận </button>
                                                                </center>
                                                            </div>
                                                        </form>
                                                        <form action="javascript:TransferMoneyToUser()" id="TransferMoneyToUserOTPForm" style="display:none">
                                                            <div class="form-group">
                                                                <label class="control-label">Nhập OTP</label>
                                                                <input type="text" id="txtOTP2" class="form-control" name="OTP"  value="">
                                                            </div>
                                                            <div class="margin-top-10">
                                                                <center>
                                                                    <button type="submit" class="btn green">Xác nhận </button>
                                                                </center>
                                                            </div>
                                                        </form>
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
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4" style="margin-bottom: 10px;">
                                                <label class="control-label label-balance">Chọn ngày kết xuất dữ liệu</label>
                                                <div class="input-group" id="dateRangeEvent">
                                                    <input type="text" class="form-control" placeholder="Date Range(MM/DD/YYYY)" disabled style="height: 34px !important" />
                                                    <span class="input-group-btn">
                                                        <button class="btn default date-range-toggle" type="button"><i class="fa fa-calendar"></i></button>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="col-md-12" style="margin-bottom: 10px;">
                                                <div id="sample_1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                                    <table class="table table-striped table-bordered table-hover dataTable" id="tbl_datatable"
                                                        aria-describedby="sample_1_info">
                                                        <thead>
                                                            <tr role="row"></tr>
                                                        </thead>
                                                        <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                        <tfoot>
                                                            <tr role="row"></tr>
                                                        </tfoot>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div><br />
                                            <div id="chartdiv2"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--modal change phone-->
    <div id="modal_ChangePhone" class="modal fade" data-backdrop="static" data-keyboard="false" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <form action="javascript:;" id="form_ChangePhone" class="form-horizontal" novalidate="novalidate">
                    <input type="hidden" id="customerID"/>
                    <div class="modal-body">
                    	<div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title" id="title_task">
                                <i class="fa fa-edit"></i> Thiết lập số điện thoại mới</h4>
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
                                        <label class="control-label col-md-4">
                                            Số điện thoại mới: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtNewPhoneChangePhone" type="text" class="form-control" name="newPhone" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Mã captcha:
                                        </label>
                                        <div class="col-md-8">
                                            <div class="img-verifire-captcha">
                                                <img style="height: 34px; margin-right: 5px" class="captcha-img" id="captcha5" src="../../Apis/Captcha.ashx">
                                                <img style="width:28px;cursor: pointer;margin: 4px 5px 0;" onclick="refresh_captcha();" src="assets/pages/img/login/reload.png">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="col-xs-10 col-xs-offset-1">
                                	<div class="form-group">
                                        <label class="control-label col-md-4">
                                            Nhập captcha: <span class="required" aria-required="true">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <i class="fa"></i>
                                                <input id="txtCaptchaChangePhone" type="text" class="form-control" name="captcha" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn dark btn-outline">Hủy</button>
                        <button type="submit" class="btn green" onclick="javascript:ChangePhone()">Đăng Ký</button>
                    </div>
                </form>
            </div>
        </div>
    </div>    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script src="assets/global/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>
    <script src="assets/global/plugins/amcharts/v4/core.js"></script>
    <script src="assets/global/plugins/amcharts/v4/charts.js"></script>
    <script src="assets/global/plugins/amcharts/v4/animated.js"></script>
    <script>
        //jQuery(document).ready(function () {
        //    FormValidation.init();
        //});
        $(document).ready(function () {

            $('#panel-info-agency').find('input[name=radio]').click(function () {
                if ($(this).attr('checked') == 'checked') {
                    return;
                }
                //console.log($(this).val());
                //$('#radioTrueDisplay').removeAttr('checked');
                //$('#radioFlaseDisplay').removeAttr('checked');
                ChangeDisplayStt($(this).val());

            });
            $('.sidebar-toggler').click();
            
            ComponentsPickers.init();
            loadBalanceChart();
            $('#listTab li a').click(function () {
                ResetForm();
                if ($(this).attr('href') == "#tab_1_4") {
                    TableEditable.init();
                }
            });
            $('.ver-inline-menu li a').click(function () {
                ResetForm();
                if ($(this).attr('href') == "#tab_2-2") {
                    init();
                }
            });
            LoadTransactionInfo()
            init();
            FormValidationChangeLimit.init();
            FormValidationChangePassword.init();
            FormValidationTransferMoneyToAgency.init();
            FormValidationTransferMoneyToUser.init();

            $('#txtAmount2').on('keyup', function (e) {
                var transFee = (parseInt($('#txtAmount2').val()) / 100) * 2;
                $('#txtTransactionFee').val(transFee);
            });

            var options = {
                url: function (param) {
                    return "Apis/API_Agency.ashx";
                },
                getValue: function (element) {
                    $('.loading1').fadeOut(10);
                    //return element.AgencyID + '-' + element.DisplayName;
                    return element.AgencyID + '-' + element.DisplayName;
                },
                ajaxSettings: {
                    dataType: "json",
                    method: "POST",
                    data: {
                        type: 7,
                        mid: AppManage.getURLParameter('m')
                    }
                },
                preparePostData: function (data) {
                    $('.loading1').fadeIn();
                    data.param = $("#txtRecipientID").val();
                    return data;
                },
                requestDelay: 500
            };
            $("#txtRecipientID").easyAutocomplete(options);

            var options2 = {
                url: function (param) {
                    return "Apis/API_Agency.ashx";
                },
                getValue: function (element) {
                    $('.loading1').fadeOut(10);
                    //return element.AgencyID + '-' + element.DisplayName;
                    return element.AccountID + '-' + element.DisplayName;
                },
                ajaxSettings: {
                    dataType: "json",
                    method: "POST",
                    data: {
                        type: 9,
                        mid: AppManage.getURLParameter('m')
                    }
                },
                preparePostData: function (data) {
                    $('.loading1').fadeIn();
                    data.param = $("#txtRecipientID2").val();
                    return data;
                },
                requestDelay: 500
            };
            $("#txtRecipientID2").easyAutocomplete(options2);
        });

        function LoadTransactionInfo() {
            $('.divLoading').fadeIn();
            POST_DATA("Apis/Menu.ashx", {
                type: 13,
                mid: 31
            }, function (res) {
                var data = res.data;
                var strHtml1 = '';
                var strHtml2 = '';
                $.each(data, function (i, obj) {
                    strHtml1 += '<option value=' + parseInt(data[i][0]) + '>' + formatMoney(parseInt(data[i][0])) + '</option>';
                    strHtml2 += '<option value=' + parseInt(data[i][1]) + '>' + formatMoney(parseInt(data[i][1])) + '</option>';
                });
                $('#opLimiTrans').append(strHtml1);
                $('#opLimiTransDaily').append(strHtml2);
                $('.divLoading').fadeOut();
            });
        }

        function init() {
            console.log('init');
            $('.divLoading').fadeIn();
            $('#opLimiTrans option').eq(0).prop('selected', true);
            $('#opLimiTransDaily option').eq(0).prop('selected', true);

            POST_DATA("Apis/API_Agency.ashx", { type: 4 }, function (res) {
                $('#btn_active_phone').remove();
                var data = res.data;
                var item = $('#panel-info-agency');
                item.find('input[name=agencyCode]').val(data.agencyCode);
                //item.find('input[name=agencyID]').val(data.agencyID);
                item.find('input[name=balance]').val(formatMoney(parseInt(data.balance)));
                item.find('input[name=balance_bonus]').val(data.balance_bonus);
                item.find('input[name=balance_lock]').val(data.balance_lock);
                item.find('input[name=displayName] ').val(data.displayName);
                item.find('input[name=email]').val(data.email);
                //item.find('input[name=emailActive]').val(data.emailActive == true ? 'Đã kích hoạt' : 'Chưa kích hoạt');
                item.find('input[name=isOTP]').val(data.isOTP == true ? 'Qua SMS' : 'Không xác thực');
                //item.find('input[name=limitTransaction]').val(data.limitTransaction);
                //item.find('input[name=limitTransactionDaily]').val(data.limitTransactionDaily);
                item.find('input[name=masterID]').val(data.masterID);
                item.find('input[name=phone]').val(data.phone);

                if (data.phoneActive == true) {
                    item.find('input[name=phoneActive]').val('Đã kích hoạt');
                }
                else {
                    item.find('input[name=phoneActive]').val('Chưa kích hoạt');
                    item.find('input[name=phoneActive]').parent().append('<a href="javascript:ActivePhoneAgency();" type="submit" class="btn red" id="btn_active_phone" >Kích hoạt ngay </button>');
                }
                item.find('input[name=agencyInfo]').val(data.information);
                //item.find('input[name=displayStatus]').val(data.display==true?"Hiển thị thông tin":"Không hiển thị thông tin");
                if (data.display == true) {
                    $('#radioTrueDisplay').attr("checked", "checked");
                    $('#radioFlaseDisplay').removeAttr("checked");
                } else {
                    $('#radioFlaseDisplay').attr("checked", "checked");
                    $('#radioTrueDisplay').removeAttr("checked");
                }
                item.find('input[name=fbLink]').val(data.fb);


                $('#LimitTransactionForm').find('input[name=limitTransaction]').val(formatMoney(parseInt(data.limitTransaction)));
                $('#opLimiTrans').val(data.limitTransaction);
                $('#LimitTransactionForm').find('input[name=limitTransactionDaily]').val(formatMoney(parseInt(data.limitTransactionDaily)));
                $('#opLimiTransDaily').val(data.limitTransactionDaily);


                $('#TransferMoneyToAgencyForm').find('input[name=senderID]').val(data.masterID);
                $('#TransferMoneyToAgencyForm').find('input[name=balance]').val(formatMoney(parseInt(data.balance)));
                $('#TransferMoneyToUserForm').find('input[name=senderID]').val(data.masterID);
                $('#TransferMoneyToUserForm').find('input[name=balance]').val(formatMoney(parseInt(data.balance)));
                if (data.agencyCode.length > 13) {
                    $('#TransactionFee').show();
                }


                $('.divLoading').fadeOut();

            });
        }

        function TransferMoneyToAgency() {
            $('.divLoading').fadeIn();
            var json = {
                recipientID: $('#txtRecipientID').val().split('-')[0],
                amount: $('#txtAmount').val(),
                reason: $('#txtReason').val(),
                captcha: $('#txtCaptchaTransferMoneyToAgency').val(),
                OTP: $('#txtOTP').val(),
            }
            POST_DATA("Apis/API_Agency.ashx", {
                type: 8,
                json: JSON.stringify(json)
            }, function (res) {
                refresh_captcha();
                if (res.status == 2) {
                    //Check OTP
                    $('#TransferMoneyToAgencyForm').hide();
                    $('#TransferMoneyToAgencyOTPForm').show();
                }
                else if (res.status == -14) {
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {
                            $('#listTab li:first-child a').click();
                        }
                    });

                }
                //else if (res.status == 0) {
                //    //Chưa kích hoạt
                //}
                else {
                    if (res.status == 1) {
                        //Thành công
                        $('#TransferMoneyToAgencyForm').show();
                        $('#TransferMoneyToAgencyOTPForm').hide();
                        ResetForm();
                        init();
                    }
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {
                            $('#txtOTP').val('');
                        }
                    });
                }

                $('.divLoading').fadeOut();
            });
        }
        function TransferMoneyToUser() {
            $('.divLoading').fadeIn();
            var json = {
                recipientID: $('#txtRecipientID2').val().split('-')[0],
                amount: $('#txtAmount2').val(),
                reason: $('#txtReason2').val(),
                captcha: $('#txtCaptchaTransferMoneyToUser').val(),
                OTP: $('#txtOTP2').val()
            }
            POST_DATA("Apis/API_Agency.ashx", {
                type: 10,
                json: JSON.stringify(json)
            }, function (res) {
                refresh_captcha();
                if (res.status == 2) {
                    //Check OTP
                    $('#TransferMoneyToUserForm').hide();
                    $('#TransferMoneyToUserOTPForm').show();
                }
                //else if (res.status == 0) {
                //    //Chưa kích hoạt

                //}
                else if (res.status == -14) {
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {
                            $('#listTab li:first-child a').click();
                        }
                    });

                }
                else {
                    if (res.status == 1) {
                        //Thành công
                        $('#TransferMoneyToUserForm').show();
                        $('#TransferMoneyToUserOTPForm').hide();
                        ResetForm();
                        init();
                    }
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {
                            $('#txtOTP2').val('');
                        }
                    });
                }
                $('.divLoading').fadeOut();
            });
        }

        function ActivePhoneAgency() {
            POST_DATA("Apis/API_Agency.ashx", {
                type: 11,
            }, function (res) {
                refresh_captcha();
                if (res.status == 2) {
                    bootbox.prompt({
                        //size: "small",
                        title: "Nhập mã OTP kích hoạt số điện thoại?",
                        callback: function (result) {
                            /* result = String containing user input if OK clicked or null if Cancel clicked */
                            if (result !== null) {
                                POST_DATA("Apis/API_Agency.ashx", {
                                    otp: result,
                                    type: 11,
                                }, function (res) {
                                    bootbox.alert({
                                        message: res.msg,
                                        callback: function () {
                                            init();
                                        }
                                    });
                                });
                            }
                        }
                    });
                }
                else {
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {

                        }
                    });
                }
            });
        }

        function ChangeLimitTransaction() {
            $('.divLoading').fadeIn();
            var json = {
                limitTransaction: $('#opLimiTrans').val(),
                limitTransactionDaily: $('#opLimiTransDaily').val(),
                isOTP: $('#opOTP').val() == "true" ? true : false,
                captcha: $('#txtCaptchaChangeLimit').val()
            }
            POST_DATA("Apis/API_Agency.ashx", {
                type: 6,
                json: JSON.stringify(json)
            }, function (res) {
                refresh_captcha();
                bootbox.alert({
                    message: res.msg,
                    callback: function () {
                        if (res.status == 0) {
                            ResetForm();
                            init();
                        }
                    }
                });
                $('.divLoading').fadeOut();
            });
        }

        function ChangePassword() {
            $('.divLoading').fadeIn();
            var json = {
                passwordOld: $('#txtOldPassword').val(),
                passwordNew: $('#txtNewPassword').val(),
                rePasswordNew: $('#txtReNewPassword').val(),
                captcha: $('#txtCaptchaChangePass').val()
            }
            POST_DATA("Apis/API_Agency.ashx", {
                type: 5,
                json: JSON.stringify(json)
            }, function (res) {
                    refresh_captcha();
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {
                            ResetForm();
                        }
                    });
                    $('.divLoading').fadeOut();
                });
            }

        function OpenFormChangeFBLink() {
            bootbox.prompt({
                size: "small",
                title: "Nhập đường link facebook mới",
                value: $('#panel-info-agency').find('input[name=fbLink]').val(),
                callback: function (result) {
                    if (result !== null) {
                        ChangeFBLink(result);
                    }
                }
            });
        }
        function ChangeFBLink(fbLink) {
            $('.divLoading').fadeIn();
            POST_DATA("Apis/API_Agency.ashx", {
                type: 16,
                fb: fbLink
            }, function (res) {
                refresh_captcha();
                bootbox.alert({
                    message: res.msg,
                    callback: function () {

                    }
                });
                if (res.status == 1) {
                    init();
                }
                $('.divLoading').fadeOut();
            });
        }

        //function OpenFormChangeDisplayStt() {
        //    bootbox.confirm({
        //        size: "small",
        //        title: "Hiển thị thông tin?",
        //        message: "Thay đổi hiển thị thông tin đại lý",
        //        buttons: {
        //            cancel: {
        //                label: '<i class="fa fa-times"></i> Không hiển thị'
        //            },
        //            confirm: {
        //                label: '<i class="fa fa-check"></i> Hiển thị'
        //            }
        //        },
        //        callback: function (result) {
        //            //console.log('This was logged in the callback: ' + result);
        //            ChangeDisplayStt(result);
        //        }
        //    });
        //}
        function ChangeDisplayStt(type) {
            //console.log("type:" + type);
            $('.divLoading').fadeIn();
            POST_DATA("Apis/API_Agency.ashx", {
                type: 15,
                display: type
            }, function (res) {
                refresh_captcha();
                
                    //init();
                    if (res.status == 1) {
                        bootbox.alert({
                            message: res.msg,
                            callback: function () {
                                init();
                            }
                        });
                        
                    }
                    else {
                        bootbox.alert({
                            message: res.msg,
                            callback: function () {
                                if (type.toString() == "true") {
                                    setTimeout($('#radioFlaseDisplay').attr("checked", "checked"), 2000);
                                    $('#radioTrueDisplay').removeAttr("checked");
                                } else {
                                    setTimeout($('#radioTrueDisplay').attr("checked", "checked"),2000);
                                    $('#radioFlaseDisplay').removeAttr("checked");
                                    
                                }
                            }
                        });
                    }
                $('.divLoading').fadeOut();
            });
        }

        function OpenFormChangeAgencyInfo() {
            bootbox.prompt({
                size: "small",
                title: "Nhập thông tin liên hệ mới",
                value: $('#panel-info-agency').find('input[name=agencyInfo]').val(),
                callback: function (result) {
                    if (result !== null) {
                        ChangeAgencyInfo(result);
                    }
                }
            });
        }
        function ChangeAgencyInfo(info) {
            $('.divLoading').fadeIn();
            POST_DATA("Apis/API_Agency.ashx", {
                type: 14,
                information: info
            }, function (res) {
                    refresh_captcha();
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {

                        }
                    });
                    if (res.status == 1) {
                        init();
                    }
                    $('.divLoading').fadeOut();
            });
        }

        function OpenFormChangePhone() {
            $('#modal_ChangePhone').modal('show');
            refresh_captcha();
        }
        function ChangePhone() {
            $('.divLoading').fadeIn();
            var json = {
                phoneNew: $('#txtNewPhoneChangePhone').val(),
                captcha: $('#txtCaptchaChangePhone').val()
            }
            POST_DATA("Apis/API_Agency.ashx", {
                type: 13,
                json: JSON.stringify(json)
            }, function (res) {
                refresh_captcha();
                if (res.status == 1) {
                    $('#modal_ChangePhone').modal('hide');
                    init();
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {
                            ActivePhoneAgency();
                        }
                    });
                }
                else if (res.status == 2) {
                    bootbox.prompt("OTP kích hoạt đã được gửi đến số điện thoại cũ của bạn, vui lòng xác nhận!", function (result) {
                        if (result !== null) {
                            var json = {
                                phoneNew: $('#txtNewPhoneChangePhone').val(),
                                otp: result
                            }
                            POST_DATA("Apis/API_Agency.ashx", {
                                type: 13,
                                json: JSON.stringify(json)
                            }, function (res) {
                                if (res.status == 1) {
                                    init();
                                    bootbox.alert({
                                        message: res.msg,
                                        callback: function () {
                                            ActivePhoneAgency();
                                        }
                                    });

                                }
                                else {
                                    bootbox.alert({
                                        message: res.msg,
                                        callback: function () {

                                        }
                                    });
                                }
                                ResetForm();
                                $('#modal_ChangePhone').modal('hide');

                            });
                        }
                    });
                }
                else {
                    bootbox.alert({
                        message: res.msg,
                        callback: function () {

                        }
                    });
                }

                $('.divLoading').fadeOut();
            });
        }

        function refresh_captcha() {
            $('#txtCaptcha').val('');
            $('.form-control[name="captcha"]').val('');
            var today = new Date();
            var time = today.getHours() + "" + today.getMinutes() + "" + today.getSeconds();
            $('.captcha-img').attr("src", "../../Apis/Captcha.ashx?t=" + time);
            $('.bootbox-body').delegate('#infos', 'load', function () {
                $(this).find('#captcha5').attr("src", "../../Apis/Captcha.ashx?t=" + time);
            });
        }
        function formatMoney(num) {
            if (num > 0)
                return num.toLocaleString('en-US');
            else
                return num;
        }

        var FormValidationChangeLimit = function () {
            var r = function () {
                var e = $("#LimitTransactionForm"),
                    r = $("#alert-danger-ChangeLimitTransaction", e),
                    i = $("#alert-success-ChangeLimitTransaction", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        LimiTrans: {
                            required: !0
                        },
                        LimiTransDaily: {
                            required: !0
                        },
                        captcha: {
                            required: !0
                        }
                        //AgencyID: {
                        //    required: !0
                        //},
                        //MenhGia: {
                        //    required: !0
                        //},

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
                            ChangeLimitTransaction();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        var FormValidationChangePassword = function () {
            var r = function () {
                var e = $("#ChangePasswordForm"),
                    r = $("#alert-danger-ChangePassword", e),
                    i = $("#alert-success-ChangePassword", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        oldpassword: {
                            required: !0
                        },
                        newpassword: {
                            minlength: 6,
                            maxlength: 20,
                            required: !0
                        },
                        renewpassword: {
                            required: !0
                        },
                        captcha: {
                            required: !0
                        }
                        //AgencyID: {
                        //    required: !0
                        //},
                        //MenhGia: {
                        //    required: !0
                        //},

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
                            ChangePassword();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        var FormValidationTransferMoneyToAgency = function () {
            var r = function () {
                var e = $("#TransferMoneyToAgencyForm"),
                    r = $("#alert-danger-TransferMoneyToAgency", e),
                    i = $("#alert-success-TransferMoneyToAgency", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        recipientID: {
                            required: !0
                        },
                        amount: {
                            required: !0,
                            digits: !0
                        },
                        captcha: {
                            required: !0
                        }
                        //AgencyID: {
                        //    required: !0
                        //},
                        //MenhGia: {
                        //    required: !0
                        //},

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
                            TransferMoneyToAgency()
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        var FormValidationTransferMoneyToUser = function () {
            var r = function () {
                var e = $("#TransferMoneyToUserForm"),
                    r = $("#alert-danger-TransferMoneyToUser", e),
                    i = $("#alert-success-TransferMoneyToUser", e);
                e.validate({
                    errorElement: "span",
                    errorClass: "help-block help-block-error",
                    focusInvalid: !1,
                    ignore: "",
                    rules: {
                        recipientID: {
                            required: !0
                        },
                        amount: {
                            required: !0,
                            digits: !0
                        },
                        captcha: {
                            required: !0
                        }
                        //AgencyID: {
                        //    required: !0
                        //},
                        //MenhGia: {
                        //    required: !0
                        //},

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
                            TransferMoneyToUser()
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        function ResetForm() {
            $('#opLimiTrans option')[0].selected = true;
            $('#opLimiTransDaily option')[0].selected = true;
            $('#opOTP option')[0].selected = true;
            $('#txtRecipientID').val('');
            $('#txtAmount').val('');
            $('#txtReason').val('');
            $('#txtRecipientID2').val('');
            $('#txtAmount2').val('');
            $('#txtReason2').val('');
            $('#txtNewPhoneChangePhone').val('');
            $('#txtCaptchaChangePhone').val('');
            $('#txtOldPassword').val('');
            $('#txtNewPassword').val('');
            $('#txtReNewPassword').val('');
            $('#ChangePasswordForm').trigger('reset');
            refresh_captcha();

            $('.form-group').removeClass('has-success').removeClass('has-error');
            $('.form-group i').removeClass('fa-warning').removeClass('fa-check');
            $('.alert.alert-danger.display-hide').hide();
            $('.alert.alert-success.display-hide').hide();
        }

        function loadBalanceChart() {
            $.ajax({
                type: "POST",
                url: "Apis/Menu.ashx",
                data: {
                    type: 13,
                    mid: 47
                },
                dataType: 'json',
                success: function (data) {
                    var d = data.data;
                    if (d.length > 0) {
                        var chartData = [];
                        for (var i = 0; i < d.length; i++) {
                            chartData.push({
                                "Name": "Tiền vào",
                                "Value": d[i][0]
                            });
                            chartData.push({
                                "Name": "Tiền ra",
                                "Value": d[i][1]
                            });
                        }
                        am4core.ready(function () {
                            am4core.useTheme(am4themes_animated);
                            var chart = am4core.create("chartdiv", am4charts.PieChart);
                            var pieSeries = chart.series.push(new am4charts.PieSeries());
                            pieSeries.dataFields.value = "Value";
                            pieSeries.dataFields.category = "Name";

                            // Let's cut a hole in our Pie chart the size of 30% the radius
                            chart.innerRadius = am4core.percent(30);

                            // Put a thick white border around each Slice
                            pieSeries.slices.template.stroke = am4core.color("#fff");
                            pieSeries.slices.template.strokeWidth = 2;
                            pieSeries.slices.template.strokeOpacity = 1;
                            pieSeries.slices.template
                                // change the cursor on hover to make it apparent the object can be interacted with
                                .cursorOverStyle = [
                                    {
                                        "property": "cursor",
                                        "value": "pointer"
                                    }
                                ];

                            pieSeries.alignLabels = false;
                            pieSeries.labels.template.bent = true;
                            pieSeries.labels.template.radius = 3;
                            pieSeries.labels.template.padding(0, 0, 0, 0);

                            pieSeries.ticks.template.disabled = true;

                            // Create a base filter effect (as if it's not there) for the hover to return to
                            var shadow = pieSeries.slices.template.filters.push(new am4core.DropShadowFilter);
                            shadow.opacity = 0;

                            // Create hover state
                            var hoverState = pieSeries.slices.template.states.getKey("hover"); // normally we have to create the hover state, in this case it already exists

                            // Slightly shift the shadow and make it more prominent on hover
                            var hoverShadow = hoverState.filters.push(new am4core.DropShadowFilter);
                            hoverShadow.opacity = 0.7;
                            hoverShadow.blur = 5;

                            // Add a legend
                            chart.legend = new am4charts.Legend();

                            chart.data = chartData;

                        }); // end am4core.ready()
                    }
                }
            });
        }


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
                    startDate: moment().subtract('month', 3),
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
                _dateStart = moment().subtract('month', 3).format('YYYY/MM/DD');
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
        var colFilter = null;
        var TableEditable = function () {
            var handleTable = function () {
                var table = $('#tbl_datatable');
                loadTable();
                function loadTable() {
                    $('.divLoading').fadeIn();
                    if (_dateStart == null)
                        _dateStart = moment().subtract('month', 1).format('YYYY/MM/DD');
                    if (_dateEnd == null)
                        _dateEnd = moment().format('YYYY/MM/DD');
                    var param = [];
                    param.push(_dateStart);//@0
                    param.push(_dateEnd);//@1
                    $.ajax({
                        type: "POST",
                        url: "Apis/Menu.ashx",
                        data: {
                            type: 13,
                            mid: 49,
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
                                }
                                _dataColumn = data.columnName;
                                var columnLength = data.columnName.length;
                                if (colFilter == null) {
                                    $('#tbl_datatable thead tr').html("");
                                    colFilter = _dataColumn;
                                    var strHtmlColName = "";
                                    _dataColumn.splice(_dataColumn.length - 1, 1);
                                    $.each(_dataColumn, function (key, obj) {
                                        strHtmlColName += "<td>" + obj + "</td>";
                                    });
                                    $('#tbl_datatable thead tr').append(strHtmlColName);
                                    if (data.data.length > 20) {
                                        $('#tbl_datatable tfoot tr').append(strHtmlColName);
                                    }
                                }
                                var dataReport = data.data;
                                var chartData = [];
                                var countRow = dataReport.length;
                                for (var i = 0; i < countRow; i++) {
                                    dataReport[i].splice(columnLength - 1, 1);
                                    chartData.push({
                                        "date": data.data[i][0],
                                        "vao": data.data[i][1],
                                        "ra": data.data[i][2]
                                    });
                                }
                                console.log(dataReport);
                                var colHiden = [];
                                oTable = table.dataTable({
                                    "data": dataReport,
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
                                var tableWrapper = $("#tbl_datatable_wrapper");
                                jQuery('#tbl_datatable_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
                                jQuery('#tbl_datatable_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
                                jQuery('#tbl_datatable_wrapper .dataTables_length select').select2(); // initialize select2 dropdown

                                tableWrapper.find(".dataTables_length select").select2({
                                    showSearchInput: false
                                });
                                loadThongkeChart(chartData);
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



        function formatMoney(num) {
            if (num > 0)
                return num.toLocaleString('en-US');
            else
                return num;
        }

        function loadThongkeChart(dataChart) {
            am4core.ready(function () {
                am4core.useTheme(am4themes_animated);
                var chart = am4core.create("chartdiv2", am4charts.XYChart);
                chart.data = dataChart;
                chart.colors.step = 2;
                chart.maskBullets = false;
                // Create axes
                var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
                dateAxis.renderer.grid.template.location = 0;
                dateAxis.renderer.minGridDistance = 50;

                var distanceAxis = chart.yAxes.push(new am4charts.ValueAxis());
                distanceAxis.title.text = "Tiền vào";
                distanceAxis.renderer.grid.template.disabled = true;

                var durationAxis = chart.yAxes.push(new am4charts.ValueAxis());
                durationAxis.title.text = "Tiền ra";
                durationAxis.renderer.grid.template.disabled = true;
                durationAxis.renderer.opposite = true;

                // Create series
                var distanceSeries = chart.series.push(new am4charts.ColumnSeries());
                distanceSeries.dataFields.valueY = "vao";
                distanceSeries.dataFields.dateX = "date";
                distanceSeries.yAxis = distanceAxis;
                distanceSeries.tooltipText = "{valueY} VND";
                distanceSeries.name = "Nguồn tiền vào";
                distanceSeries.columns.template.fillOpacity = 0.7;
                distanceSeries.columns.template.propertyFields.strokeDasharray = "dashLength";
                distanceSeries.columns.template.propertyFields.fillOpacity = "alpha";

                var disatnceState = distanceSeries.columns.template.states.create("hover");
                disatnceState.properties.fillOpacity = 0.9;

                var durationSeries = chart.series.push(new am4charts.LineSeries());
                durationSeries.dataFields.valueY = "ra";
                durationSeries.dataFields.dateX = "date";
                durationSeries.yAxis = durationAxis;
                durationSeries.name = "Nguồn tiền ra";
                durationSeries.strokeWidth = 2;
                durationSeries.propertyFields.strokeDasharray = "dashLength";
                durationSeries.tooltipText = "{valueY} VND";

                var durationBullet = durationSeries.bullets.push(new am4charts.Bullet());
                var durationRectangle = durationBullet.createChild(am4core.Rectangle);
                durationBullet.horizontalCenter = "middle";
                durationBullet.verticalCenter = "middle";
                durationBullet.width = 7;
                durationBullet.height = 7;
                durationRectangle.width = 7;
                durationRectangle.height = 7;

                var durationState = durationBullet.states.create("hover");
                durationState.properties.scale = 1.2;
                // Add legend
                chart.legend = new am4charts.Legend();

                // Add cursor
                chart.cursor = new am4charts.XYCursor();
                chart.cursor.fullWidthLineX = true;
                chart.cursor.xAxis = dateAxis;
                chart.cursor.lineX.strokeOpacity = 0;
                chart.cursor.lineX.fill = am4core.color("#000");
                chart.cursor.lineX.fillOpacity = 0.1;

            }); // end am4core.ready()
        }
    </script>
</asp:Content>
