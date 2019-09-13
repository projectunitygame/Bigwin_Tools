<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AccountManage.aspx.cs" Inherits="CMS_Tools.AccountManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/global/plugins/datatables/DT_bootstrap.css" rel="stylesheet" />  
    <style>
        #tbl_account tbody tr:nth-child(1)>td:nth-child(2){
            width:50px;
        }
        .avatarUser{
            max-width:48px;
            max-height:48px;
            -webkit-border-radius: 50% !important;
            -moz-border-radius: 50px !important;
            border-radius: 50px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="page-title">Quản lý Tài khoản
        <small>Account list</small>
    </h1>
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
                <span>Menu Manage</span>
            </li>
        </ul>
        <div class="page-toolbar">
            <div class="btn-group pull-right">
                <button type="button" class="btn btn-fit-height blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                    Chức năng <i class="fa fa-angle-down"></i>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li>
                        <a href="javascript:;" class="btnAddAccount"><i class="fa fa-plus"></i> Tạo Tài khoản Mới</a>
                    </li>
                    <%--<li>
                        <a href="#" class="btnViewHistoryMenu"><i class="fa fa-history"></i> Lịch sử chỉnh sửa</a>
                    </li>--%>
                    <%--<li>
                        <a href="#" class="btnCopyMenu"><i class="fa fa-clone"></i> Sao chép menu</a>
                    </li>
                    <li class="divider"></li>
                    <li>
                        <a href="#" class="btnRemoveMenu"><i class="fa fa-trash-o"></i> Xóa menu</a>
                    </li>--%>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN PORTLET-->
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        Account
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                        <%--<a href="#portlet-config" data-toggle="modal" class="config" data-original-title="" title=""></a>--%>
                        <a href="javascript:;" class="reload" data-original-title="" title=""></a>
                        <%--<a href="javascript:;" class="remove" data-original-title="" title=""></a>--%>
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
                    <div class="clearfix btnAccount_button" style="margin-bottom:10px;">
                        <a href="javascript:;" class="btn btn-xs red disable" id="btn_remove" step="0"><i class="fa fa-trash-o"></i> <label>Xóa Tài Khoản</label></a>
                        <a href="javascript:;" class="btn btn-xs green disable" id="btn_edit"><i class="fa fa-edit"></i> <label>Chỉnh Sửa</label></a>
                        <a href="javascript:;" class="btn btn-xs green disable" id="btn_Rule"><i class="fa fa-cog"></i> <label>Phân Quyền</label></a>
                    </div>
                    <div id="sample_1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_account"
                            aria-describedby="sample_1_info">
                            <thead></thead>
                            <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                        </table>
                    </div>
                </div>
            </div>
            <!-- END PORTLET-->
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script src="assets/global/plugins/datatables/jquery.dataTables.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>   
    <script src="assets/pages/scripts/AccountManage.js"></script>
</asp:Content>
