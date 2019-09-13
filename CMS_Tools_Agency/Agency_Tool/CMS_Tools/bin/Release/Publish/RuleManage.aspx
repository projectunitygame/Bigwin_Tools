<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RuleManage.aspx.cs" Inherits="CMS_Tools.RuleManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
    <link href="assets/global/plugins/kendo/kendo.common.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/kendo/kendo.silver.min.css" rel="stylesheet" type="text/css" />  
    <link href="assets/global/plugins/nestable/jquery.nestable.css" rel="stylesheet" />
    <style type="text/css">
        .form-group
        {
            float: left;
            clear: both;
            width: 100%;  
        }
        .actions{margin-top:10px !important}
        .menuID
        {
            float: left;
            margin: 9px 5px 0 10px !important;    
        }
        .rulesID
        {
            float: right;
            min-width:150px;
            width:auto;
            overflow:auto;
        }
        .rulesID ul{float:left;}
        #nestable_list_1 h2 {
            font-weight: normal;
        }
        #nestable_list_1 label {
            display: inline-block;
            margin: 15px 0 5px 0;
        }
        #nestable_list_1 select {
            width: 350px;
        }
        #get {
            float: right;
            margin: 25px auto 0;
        }
        #timer{color:#666666}
        #linkhomepage a{color:#f07b07; text-decoration:none;}
        #linkhomepage a:link{color:#f07b07; text-decoration:none;}
        #linkhomepage a:hover{color:Blue; text-decoration:none;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="page-title">Quản lý phân quyền</h1>
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
                <span>Phân Quyền</span>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="margin-bottom-10" id="nestable_list_menu">
                <button id="btn_expandall" type="button" class="btn" data-action="expand-all">
                    Expand All</button>
                <button type="button" class="btn" data-action="collapse-all">
                    Collapse All</button>
                <button type="button" class="btn" id="btn_update">Update</button>
            </div>
        </div>
    </div>
    <div class="portlet box grey">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-comments"></i>Danh sách trang
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a>
            </div>
        </div>
        <div class="portlet-body ">
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
            <div class="dd" id="nestable_list_1">
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div id="error" class="alert alert-danger display-hide">
                <strong>Error!</strong> The daily cronjob has failed.
            </div>
            <div id="success" class="alert alert-success display-hide">
                <strong>Success!</strong> The page has been added.
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script src="assets/global/plugins/nestable/jquery.nestable.js" type="text/javascript"></script>
    <script src="assets/global/plugins/kendo/kendo.all.min.js" type="text/javascript"></script>
    <script src="assets/pages/scripts/RuleManage.js"></script>
</asp:Content>
