<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Daily.aspx.cs" Inherits="CMS_Tools.Daily" %>

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
                                    <a href="#tab_1_1" data-toggle="tab" aria-expanded="false">TÀI KHOẢN</a>
                                </li>
                                <li>
                                    <a href="#tab_1_2" data-toggle="tab" aria-expanded="false">CHUYỂN TIỀN</a>
                                </li>
                                <li>
                                    <a href="#tab_1_3" data-toggle="tab" aria-expanded="false">YÊU CẦU RÚT TIỀN</a>
                                </li>
                                <li>
                                    <a href="#tab_1_4" data-toggle="tab" aria-expanded="false">SAO KÊ</a>
                                </li>
                                <li>
                                    <a href="#tab_1_5" data-toggle="tab" aria-expanded="false">ĐẠI LÝ CẤP 2</a>
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
                                    <div id="dateFilter" class="col-md-3 col-sm-12" style="margin-bottom: 10px; padding: 15px 15px 10px;display:none;">
                                        <label class="lblFromNgayMoDon">Từ ngày mở đơn</label><br />
                                        <div class="input-group" id="dateRangeEvent">
                                            <input style="color: #1f5d88;border: 1px solid #3598dc;" type="text" class="form-control" placeholder="Date Range(MM/DD/YYYY)" disabled />
                                            <span class="input-group-btn">
                                                <button style="border-color: #3598dc !important; color: #FFF;background: #3598dc;" class="btn default date-range-toggle fixbtndate" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>                                        
                                    </div>
                                    <div class="col-md-9 col-sm-12" style="padding: 36px 0px 0px 0px">
                                    </div>
                                </div>
                                <div class="tab-pane active" id="tab_1_1">
                                    <div class="profile" style="padding:0;">
                                        <div class="col-md-3">
                                            <ul class="list-unstyled profile-nav">
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
                                                        <i class="fa fa-eye"></i>Cài đặt hạn mức chuyển tiền </a>
                                                </li>
                                                <li class="">
                                                    <a data-toggle="tab" href="#tab_2-3" aria-expanded="false">
                                                        <i class="fa fa-lock"></i>Đổi mật khẩu </a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="tab-content">
                                                <div id="tab_2-1" class="tab-pane active">
                                                    <form role="form" action="#">
                                                        <div class="form-group">
                                                            <label class="control-label">First Name</label>
                                                            <input type="text" placeholder="John" class="form-control">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Last Name</label>
                                                            <input type="text" placeholder="Doe" class="form-control">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Mobile Number</label>
                                                            <input type="text" placeholder="+1 646 580 DEMO (6284)" class="form-control">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Interests</label>
                                                            <input type="text" placeholder="Design, Web etc." class="form-control">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Occupation</label>
                                                            <input type="text" placeholder="Web Developer" class="form-control">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">About</label>
                                                            <textarea class="form-control" rows="3" placeholder="We are KeenThemes!!!"></textarea>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Website Url</label>
                                                            <input type="text" placeholder="http://www.mywebsite.com" class="form-control">
                                                        </div>
                                                        <div class="margiv-top-10">
                                                            <a href="javascript:;" class="btn green">Save Changes </a>
                                                            <a href="javascript:;" class="btn default">Cancel </a>
                                                        </div>
                                                    </form>
                                                </div>
                                                <div id="tab_2-2" class="tab-pane">
                                                    <form action="#">
                                                        <table class="table table-bordered table-striped">
                                                            <tbody>
                                                                <tr>
                                                                    <td>Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus.. </td>
                                                                    <td>
                                                                        <div class="mt-radio-inline">
                                                                            <label class="mt-radio">
                                                                                <input type="radio" name="optionsRadios1" value="option1">
                                                                                Yes
                                                                                <span></span>
                                                                            </label>
                                                                            <label class="mt-radio">
                                                                                <input type="radio" name="optionsRadios1" value="option2" checked="">
                                                                                No
                                                                                <span></span>
                                                                            </label>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Enim eiusmod high life accusamus terry richardson ad squid wolf moon </td>
                                                                    <td>
                                                                        <div class="mt-radio-inline">
                                                                            <label class="mt-radio">
                                                                                <input type="radio" name="optionsRadios21" value="option1">
                                                                                Yes
                                                                                <span></span>
                                                                            </label>
                                                                            <label class="mt-radio">
                                                                                <input type="radio" name="optionsRadios21" value="option2" checked="">
                                                                                No
                                                                                <span></span>
                                                                            </label>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Enim eiusmod high life accusamus terry richardson ad squid wolf moon </td>
                                                                    <td>
                                                                        <div class="mt-radio-inline">
                                                                            <label class="mt-radio">
                                                                                <input type="radio" name="optionsRadios31" value="option1">
                                                                                Yes
                                                                                <span></span>
                                                                            </label>
                                                                            <label class="mt-radio">
                                                                                <input type="radio" name="optionsRadios31" value="option2" checked="">
                                                                                No
                                                                                <span></span>
                                                                            </label>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Enim eiusmod high life accusamus terry richardson ad squid wolf moon </td>
                                                                    <td>
                                                                        <div class="mt-radio-inline">
                                                                            <label class="mt-radio">
                                                                                <input type="radio" name="optionsRadios41" value="option1">
                                                                                Yes
                                                                                <span></span>
                                                                            </label>
                                                                            <label class="mt-radio">
                                                                                <input type="radio" name="optionsRadios41" value="option2" checked="">
                                                                                No
                                                                                <span></span>
                                                                            </label>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <!--end profile-settings-->
                                                        <div class="margin-top-10">
                                                            <a href="javascript:;" class="btn green">Save Changes </a>
                                                            <a href="javascript:;" class="btn default">Cancel </a>
                                                        </div>
                                                    </form>
                                                </div>
                                                <div id="tab_2-3" class="tab-pane">
                                                    <form action="#">
                                                        <div class="form-group">
                                                            <label class="control-label">Current Password</label>
                                                            <input type="password" class="form-control">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">New Password</label>
                                                            <input type="password" class="form-control">
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Re-type New Password</label>
                                                            <input type="password" class="form-control">
                                                        </div>
                                                        <div class="margin-top-10">
                                                            <a href="javascript:;" class="btn green">Change Password </a>
                                                            <a href="javascript:;" class="btn default">Cancel </a>
                                                        </div>
                                                    </form>
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
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_viewdonhangqlsx"
                                                    aria-describedby="sample_1_info">
                                                    <thead><tr></tr></thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                    <tfoot><tr></tr></tfoot>
                                                </table>
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_viewdonhangdatgiaytam"
                                                    aria-describedby="sample_1_info">
                                                    <thead><tr></tr></thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                    <tfoot><tr></tr></tfoot>
                                                </table>
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_viewgiayton"
                                                    aria-describedby="sample_1_info">
                                                    <thead><tr></tr></thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                    <tfoot><tr></tr></tfoot>
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
                                                    <thead><tr></tr></thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                    <tfoot><tr></tr></tfoot>
                                                </table>
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_viewdonhangdatgiaytam_SX"
                                                    aria-describedby="sample_1_info">
                                                    <thead><tr></tr></thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                    <tfoot><tr></tr></tfoot>
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
                                                    <thead><tr></tr></thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                    <tfoot><tr></tr></tfoot>
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
</body>
</html>
