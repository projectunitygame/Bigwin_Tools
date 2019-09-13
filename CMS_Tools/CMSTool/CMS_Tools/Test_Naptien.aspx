<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test_Naptien.aspx.cs" Inherits="CMS_Tools.Test_Naptien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <style>
        .easy-autocomplete-container ul li, .easy-autocomplete-container ul .eac-category {
            font-size: 12px !important;
        }

        .easy-autocomplete {
            float: left;
            margin-right: 10px;
            width:100% !important;
        }
        
        .add-cash-title{
            margin-bottom: 5px;
        }
        .add-cash-title h2{
            text-align: center;
            font-weight: bold;
            font-size: 20px;
            text-transform: uppercase;
        }
        
        #tbl-menh-gia thead tr{
            background: #135f5b;
    		color: #fff;
    		text-transform: uppercase;
        }
        #tbl-menh-gia tbody tr{
            background:#FFF;
            cursor:pointer;
        }
        #tbl-menh-gia tbody tr.activeVal{
            background: #efefef;
            color: #403f3f;
            font-weight: bold;
        }
#tbl-menh-gia tbody tr: hover{
            background: #efefef;
            color: #403f3f;
            font-weight: bold;
        }
		.input-icon > i{
            z-index:0 !important;
        }
#add-cash-panel{
    border-radius: 15px !important;
    background: rgba(24, 205, 196, 0.22);
    padding: 20px;
    border: 1px solid #18cdc4;
}
.img-verifire-captcha{
	position:absolute;
    right:15px;
    top:0;
    background: rgba(0,0,0,.1);
}
.btnTopup{
	width: 130px;
  	text-align:center;
}
table.table {
    border: 1px solid #eee;
}


    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        Nạp Tiền Đại Lý
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
                    <form action="javascript:" id="form_Agency" class="form-horizontal" novalidate="novalidate">
                    <input type="hidden" id="customerID"/>
                    <div class="modal-body">
                        <div class="form-body">
                            <div class="alert alert-danger display-hide">
                                <button class="close" data-close="alert"></button>
                                Vui lòng kiểm tra và nhập đầy đủ thông tin!
                            </div>
                            <div class="alert alert-success display-hide">
                                <button class="close" data-close="alert"></button>
                                Nhập thông tin hợp lệ
                            </div>
                            <div class="row">
                            	<div class="col-md-10 col-md-offset-1" style="margin-bottom:10px" id="add-cash-panel">
                                    <div class='row'>
                                    <div class="col-md-6">
                                        <div class="row add-cash-title">
                                            <h2>Thông tin nạp tiền</h2>
                                        </div>
                                        <div class="form-group row">
                                            <label class="control-label col-md-4">
                                                Số tài khoản: <span class="required" aria-required="true">* </span>
                                            </label>
                                            <div class="col-md-8">
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <input id="txtAgencyID" type="text" class="form-control" name="AgencyID"/>
                                                    <span class="control-label"><i>Nhập mã đại lí/ tên đại lý/ số điện thoại</i></span>
                                                    <span class="loading1" style="display: none;width: 29px;position: absolute;right: 1px;top: 3px;"><img style='max-width: 100%;' src="assets/global/img/loading_spinner.gif"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="control-label col-md-4">
                                                Tên đại lý:
                                            </label>
                                            <div class="col-md-8">
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <input id="txtAgencyName" type="text" class="form-control" readonly style="cursor: not-allowed;"/>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="control-label col-md-4">
                                                Mệnh giá nạp: <span class="required" aria-required="true">* </span>
                                            </label>
                                            <div class="col-md-8">
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <select class="form-control" id="txt_MenhGia" name="MenhGia" required="">
                                                        <option value="">Chọn mệnh giá...</option>
                                                   </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="control-label col-md-4">
                                                Nội dung:
                                            </label>
                                            <div class="col-md-8">
                                                <div class="input-icon right">
                                                    <i class="fa"></i>
                                                    <textarea id="txtNode" class="form-control" style="resize: none" rows="2" cols="1"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="control-label col-md-4">
                                            </label>
                                            <div class="col-md-8">
                                                  <div class="col-md-6 row">
                                                      <img style="height: 34px; margin-right: 5px" id="captcha" src="Apis/Captcha.ashx">
                                                  </div>
                                                  <div class="col-md-6 row">
                                                      <img style="width:28px;cursor: pointer;margin: 4px 5px 0;" onclick="refresh_captcha();" src="assets/pages/img/login/reload.png">
                                                  </div>
                                            </div>
                                        </div>
                                         <div class="form-group row">
                                            <label class="control-label col-md-4">
                                                Captcha:
                                            </label>
                                            <div class="col-md-8">
                                            	<div class="input-icon right">
                                                      <i class="fa"></i>
                                                      <input id="txtCaptcha" type="text" class="form-control" name="Captcha" autocomplete="off" >
                                                  </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row add-cash-title">
                                            <h2>Bảng quy đổi</h2>
                                        </div>
                                        <table class="table" id="tbl-menh-gia">
                                            <thead>
                                                <tr>
                                                    <td><b>Mệnh giá(VNĐ)</b></td>
                                                    <td><b>Tiền Win</b></td>
                                                </tr>
                                            </thead>
                                            <tbody>

                                            </tbody>
                                        </table>
                                    </div>
                                    </div>
                                    <div class='row'>
                                    	<center><button type="submit" class="btn blue btn-circle btnTopup">Nạp Tiền</button></center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script src="assets/global/plugins/Base64JS.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script>
        $(function () {
            $('#btnAddAction').hide();
            var agencyID = AppManage.getURLParameter('agencyid');
            if (agencyID != null) {
                var infoAgency = Base64.decode(agencyID).split('-');
                $("#txtAgencyID").val(infoAgency[0]);
                $("#txtAgencyName").val(infoAgency[1]);
            }


            var options = {
                url: function (param) {
                    return "Apis/API_Agency.ashx";
                },
                getValue: function (element) {
                    $('.loading1').fadeOut(10);
                    return element.AgencyID + '-' + element.DisplayName;
                },
                ajaxSettings: {
                    dataType: "json",
                    method: "POST",
                    data: {
                        type: 4,
                        mid: AppManage.getURLParameter('m')
                    }
                },
                preparePostData: function (data) {
                    $('.loading1').fadeIn();
                    data.param = $("#txtAgencyID").val();
                    return data;
                },
                requestDelay: 500
            };
            $("#txtAgencyID").easyAutocomplete(options);
        })

        jQuery(document).ready(function () {
            if (JSON.parse($('#_userdata').val()).GroupID == 6) {
                $('.btnTopup').remove();
            }

            FormValidation.init();
            $('#txt_MenhGia').change(function () {
                if ($("#txt_MenhGia")[0].selectedIndex > 0) {
                    $('#tbl-menh-gia tbody tr').removeClass('activeVal');
                    $('#tbl-menh-gia tbody tr').eq($("#txt_MenhGia")[0].selectedIndex - 1).addClass('activeVal');
                }

            });
            $('#tbl-menh-gia').delegate('tbody tr', 'click', function () {
                if ($(this).hasClass('activeVal')) { return; }
                $('#tbl-menh-gia tbody tr').removeClass('activeVal');
                $(this).addClass('activeVal');
                $('#txt_MenhGia option').eq($(this).index() + 1).prop('selected', true);
            });
            $('#eac-container-txtAgencyID').delegate('ul li', 'click', function () {
                var infoAgency = $(this).text().split('-');
                $('#txtAgencyID').val(infoAgency[0]);
                $('#txtAgencyName').val(infoAgency[1]);
            });

            LoadExchangeGold();
        });

        function LoadExchangeGold() {
            $.ajax({
                type: "POST",
                url: "Apis/Menu.ashx",
                data: {
                    type: 13,
                    mid: 29
                },
                dataType: 'json',
                success: function (data) {
                    var strHtml = '';
                    var strListOT = "";
                    $.each(data.data, function (i, obj) {
                        strHtml += '<tr><td>' + parseInt(obj[1]).format()+ '</td><td>' + parseInt(obj[0]).format() + '</td></tr>';
                        strListOT += '<option value="' + obj[0] + '"  money="' + obj[1] + '">' + parseInt(obj[0]).format() + '</option>';
                    });
                    $('#tbl-menh-gia tbody').append(strHtml);
                    $('#txt_MenhGia').append(strListOT);
                }
            });
        }
        Number.prototype.format = function (n, x) {
            var re = '\\d(?=(\\d{' + (x || 3) + '})+' + (n > 0 ? '\\.' : '$') + ')';
            return this.toFixed(Math.max(0, ~~n)).replace(new RegExp(re, 'g'), '$&,');
        };
        function formatMoney(num) {
            if (num > 0)
                return num.toLocaleString('en-US');
            else
                return num;
        }

        function AddCash() {
            $.ajax({
                type: "POST",
                url: "Apis/API_Agency.ashx",
                data: {
                    captcha: $('#txtCaptcha').val(),
                    type: 6
                },
                dataType: 'json',
                success: function (data) {
                    if (data.status == 0) {
                        bootbox.confirm("Xác nhận nạp " + $('#txt_MenhGia').val() + " vào tài khoản " + $('#txtAgencyID').val(), function (r) {
                            if (r)
                                PerformAddCash();
                        });
                    }
                    else {
                        refresh_captcha();
                        bootbox.alert({
                            message: data.msg,
                            callback: function () {
                            }
                        });
                    }
                }
            });

        }

        function PerformAddCash() {
            $(".divLoading").fadeIn();
            var uwinID = $('#txtAgencyID').val().split('-')[0];
            var json = {
                agencyID: uwinID,
                amount: $('#txt_MenhGia').val(),
                //amount: formatMoney($("#txt_MenhGia").find(':selected').attr('money')),
                reason: $('#txtNode').val()
            };
            $.ajax({
                type: "POST",
                url: "Apis/API_Agency.ashx",
                data: {
                    json: JSON.stringify(json),
                    type: 5
                },
                dataType: 'json',
                success: function (data) {
                    $(".divLoading").fadeOut(500);
                    $('#modal_customer').modal('hide');
                    if (data.status == 1) {
                        bootbox.alert({
                            message: data.msg,
                            callback: function () {
                            }
                        });
                        ResetForm();
                        $('#tbl-menh-gia tbody tr').removeClass('activeVal');
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
                        AgencyID: {
                            required: !0
                        },
                        MenhGia: {
                            required: !0
                        },
                        Captcha: {
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
                            AddCash();
                    }
                })
            }
            return {
                init: function () {
                    r()
                }
            }
        }();

        function ResetForm(type = 0) {
            //$('#form_Agency').trigger('reset');
            $('#txt_MenhGia option').eq(0).prop('selected', true);
            $('#txtNode').val('');
            refresh_captcha();
            $('.form-group').removeClass('has-success').removeClass('has-error');
            $('.form-group i').removeClass('fa-warning').removeClass('fa-check');
        }
        function refresh_captcha() {
            $('#txtCaptcha').val('');
            $('.form-control[name="captcha"]').val('');
            var today = new Date();
            var time = today.getHours() + "" + today.getMinutes() + "" + today.getSeconds();
            $('#captcha').attr("src", "../../Apis/Captcha.ashx?t=" + time);
        }

</script>
</asp:Content>
