<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tools.aspx.cs" Inherits="CMS_Tools.Tools" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <div class="portlet box grey">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Responsive Table Maintenance With Expandable details
            </div>
        </div>
        <div class="portlet-body">
            <div class="form-group">
                <label class="control-label col-md-5">
                    <input id="txtCode" name="" type="text" class="form-control input-lg" placeholder="MD5 ASCII" />
                </label>
                <label class="control-label col-md-2" style="text-align: center;">
                    <button type="button" class="btn blue" id="btn1">Submit</button>
                    <button type="button" class="btn" id="btn2">Clear</button>
                </label>
                <div class="col-md-5">
                    <label class="form-control input-lg" id="lblResult"></label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="control-label col-md-5">
                    <input id="txtCode1" name="" type="text" class="form-control input-lg" placeholder="MD5 UTF8" />
                </label>
                <label class="control-label col-md-2" style="text-align: center;">
                    <button type="button" class="btn blue" id="btn3">Submit</button>
                    <button type="button" class="btn" id="btn4">Clear</button>
                </label>
                <div class="col-md-5">
                    <label class="form-control input-lg" id="lblResult1"></label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="control-label col-md-5">
                    <input id="Text1" name="" type="text" class="form-control input-lg" placeholder="Base64Encode" />
                </label>
                <label class="control-label col-md-2" style="text-align: center;">
                    <button type="button" class="btn blue" id="btnBase64Encode">Base64Encode</button>
                    <button type="button" class="btn" id="btnBase64Decode">Base64Decode</button>
                </label>
                <div class="col-md-5">
                    <input id="Text2" name="" type="text" class="form-control input-lg" placeholder="Base64Decode" />
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="control-label col-md-5">
                    <textarea id="txtInput1" name="" type="text" class="form-control input-lg" placeholder="Encryption text"></textarea>
                    <button type="button" class="btn blue" id="btnEnrypt">Encrypt <i class="fa fa-arrow-circle-right"></i></button>
                </label>
                <label class="control-label col-md-2" style="text-align: center;">
                    <input id="txtKey" name="" type="text" class="form-control input-lg" placeholder="Key" />
                </label>
                <div class="col-md-5">
                    <textarea id="txtInput2" name="" type="text" class="form-control input-lg" placeholder="Decryption text"></textarea>
                    <button type="button" class="btn" id="btnDecrypt" style="float: right;"><i class="fa fa-arrow-circle-left"></i>Decrypt</button>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btn1').click(function () {
                if ($('#txtCode').val() != "") {
                    $.ajax({
                        type: "POST",
                        url: 'Apis/General.ashx',
                        data: { type: 'GetMD5', code: $('#txtCode').val() },
                        success: function (d) {
                            if (d.message == "success")
                                $('#lblResult').html(d.data);
                        }
                    });
                }
            });

            $('#btn2').click(function () {
                $('#txtCode').val("");
                $('#lblResult').html("");
            });

            $('#btn3').click(function () {
                if ($('#txtCode1').val() != "") {
                    $.ajax({
                        type: "POST",
                        url: 'Apis/General.ashx',
                        data: { type: 'GetMD5_UTF8', code: $('#txtCode1').val() },
                        success: function (d) {
                            if (d.message == "success")
                                $('#lblResult1').html(d.data);
                        }
                    });
                }
            });

            $('#btn4').click(function () {
                $('#txtCode1').val("");
                $('#lblResult1').html("");
            });

            $('#btnEnrypt').click(function () {
                if ($('#txtInput1').val() != "") {
                    $.ajax({
                        type: "POST",
                        url: 'Apis/General.ashx',
                        data: { type: 'Encryption', code: $('#txtInput1').val(), key: $('#txtKey').val() },
                        success: function (d) {
                            if (d.message == "success")
                                $('#txtInput2').val(d.data);
                        }
                    });
                }
            });


            $('#btnDecrypt').click(function () {
                if ($('#txtInput2').val() != "") {
                    $.ajax({
                        type: "POST",
                        url: 'Apis/General.ashx',
                        data: { type: 'Decryption', code: $('#txtInput2').val(), key: $('#txtKey').val() },
                        success: function (d) {
                            if (d.message == "success")
                                $('#txtInput1').val(d.data);
                        }
                    });
                }
            });

            $('#btnBase64Encode').click(function () {
                if ($('#Text1').val() != "") {
                    $.ajax({
                        type: "POST",
                        url: 'Apis/General.ashx',
                        data: { type: 'Base64Encode', code: $('#Text1').val() },
                        success: function (d) {
                            if (d.message == "success")
                                $('#Text2').val(d.data);
                        }
                    });
                }
            });


            $('#btnBase64Decode').click(function () {
                if ($('#Text2').val() != "") {
                    $.ajax({
                        type: "POST",
                        url: 'Apis/General.ashx',
                        data: { type: 'Base64Decode', code: $('#Text2').val() },
                        success: function (d) {
                            if (d.message == "success")
                                $('#Text1').val(d.data);
                        }
                    });
                }
            });
        });
    </script>
</asp:Content>
