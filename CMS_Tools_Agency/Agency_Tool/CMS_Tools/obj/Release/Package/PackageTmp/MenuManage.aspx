<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MenuManage.aspx.cs" Inherits="CMS_Tools.MenuManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
    <style>
        #tbl_menu tbody tr:nth-child(1)>td:nth-child(2), #tbl_menu tbody tr:nth-child(1)>td:nth-child(4){
            width:80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="page-title">Quản lý trang
        <small>Menu list</small>
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
                <span><a href="MenuManage.aspx">Menu Manage</a></span>
            </li>
        </ul>
        <div class="page-toolbar">
            <div class="btn-group pull-right">
                <button type="button" class="btn btn-fit-height blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                    Chức năng <i class="fa fa-angle-down"></i>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li>
                        <a href="javascript:;" class="btnAddMenu"><i class="fa fa-plus"></i> Thêm mới</a>
                    </li>
                    <li>
                        <a href="#" class="btnViewHistoryMenu"><i class="fa fa-history"></i> Lịch sử chỉnh sửa</a>
                    </li>
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
    <input id="input_parentID" runat="server" type="hidden"/>
    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN PORTLET-->
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption">
                        Menu
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
                    <div class="clearfix btnMenu_button" style="margin-bottom:10px;">
                        <a href="javascript:;" class="btn red disable btn-circle" id="btnMenu_remove" step="0"><label>Xóa</label> <i class="fa fa-trash-o"></i></a>
                        <a href="javascript:;" class="btn blue disable btn-circle" id="btnMenu_clone" step="0"><label>Sao Chép</label> <i class="fa fa-file-o"></i></a>
                        <a href="javascript:;" class="btn green disable btn-circle" id="btnMenu_edit"><label>Chỉnh Sửa</label> <i class="fa fa-edit"></i></a>
                    </div>
                    <div id="sample_1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <table class="table table-striped table-bordered table-hover dataTable" id="tbl_menu"
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
    <script src="assets/pages/scripts/MenuManage.js"></script>
    <script>
        $(function () {
            var menuId = 2;
            if (menuId != null) {
                $('#m_' + menuId).addClass("active open");
                $('#m_' + menuId).parent().parent().addClass("active open");
                var e = document.createElement('span');
                e.classList.add('selected');
                $('#m_' + menuId).parent().parent().find("a")[0].append(e);
            }
        });
    </script>
</asp:Content>
