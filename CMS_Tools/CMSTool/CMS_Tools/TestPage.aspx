<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="CMS_Tools.TestPage" %>
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
            width: 29px;
            position: relative;
            float: left;
            left: -40px;
            top: 3px;
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
            font-size: 13px !important;
            color: #FFF !important;
            text-transform: uppercase;
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
            font-size: 13px !important;
        }

        .page-content .form-control {
            /*height: 30px !important;
            padding: 4px 6px !important;*/
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
            margin-bottom: 15px !important;
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
            color: #FFF;
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
        .portlet.light.portlet-fit > .portlet-body{min-height:100px; padding: 10px 5px 20px 0px;}
        .static-info .name {
            font-size: 11.5px;
        }
        .static-info .value {
            font-size: 11.5px;
        }
        .icon-btn{width:90px;}
        .chartReport{
            width: 100%;
            height: 300px;
        }
        .chartTrendView{
            width: 100%;
            height: 300px;
            background:#FFF;
            margin:20px 0;
            -webkit-border-radius: 10px !important;
            -moz-border-radius: 10px !important;
            border-radius: 10px !important;
            overflow:hidden;
        }
        .checkbox-inline, .radio-inline{margin-left:10px;margin-bottom: 5px;}
        .toggle.ios, .toggle-on.ios, .toggle-off.ios { border-radius: 20px; }
        .toggle.ios .toggle-handle { border-radius: 20px; }
        .dataTables_wrapper .dataTables_paginate .paginate_button {
            padding: 2px 8px !important;
            font-size: 12px !important;
        }
        .checkbox-inline{margin-bottom:25px;}
        .page-header.navbar .page-logo {
            background: #FFF;
            border-right: 0;
        }
        #tab_1_2{background: transparent; padding: 10px 25px;}
        .showItem{
            text-align: right;
            font-size: 30px;
            color: #fff;
        }
        .showItem a{color:#fff;}
        .showItem a:hover{
            color:aqua;
        }
        .showItem .active{
            color:aqua;
        }
        .portlet{
            -webkit-transition: width 1s;
            transition: width 1s;
        }
        .page-header.navbar{background: transparent !important;}
        .page-header.navbar .menu-toggler.responsive-toggler{display:none !important;}
        @media (max-width: 767px) {
            .page-header.navbar .page-logo {
                width: auto !important;
                position: absolute;
            }
            .page-header.navbar {
                padding: 0;
                height: auto !important;
            }
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
                                <li class="active" style="display:block;">
                                    <a href="#tab_1_1" data-toggle="tab" aria-expanded="true">Dashboard</a>
                                </li>
                                <li style="display:block;">
                                    <a href="#tab_1_2" data-toggle="tab" aria-expanded="false">Trend View</a>
                                </li>
                                <li style="display:block;">
                                    <a href="#tab_1_3" data-toggle="tab" aria-expanded="false">Report Data</a>
                                </li>
                                <li style="display:block;">
                                    <a href="#tab_1_4" data-toggle="tab" aria-expanded="false">Alarms</a>
                                </li>
                                <li style="display:block;">
                                    <a href="#tab_1_5" data-toggle="tab" aria-expanded="false">Setting</a>
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
                                        <label class="lblFromNgayMoDon">Filter data by date ranges:</label><br />
                                        <div class="input-group" id="dateRangeEvent">
                                            <input style="color: #1f5d88;border: 1px solid #3598dc;" type="text" class="form-control" placeholder="Date Range(MM/DD/YYYY)" disabled />
                                            <span class="input-group-btn">
                                                <button style="border-color: #3598dc !important; color: #FFF;background: #3598dc;" class="btn default date-range-toggle fixbtndate" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>     
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="tab-pane active" id="tab_1_1">
                                    <div style="width:100%; overflow:auto; text-align:center;position:relative">
                                        <img src="img/Factory_flow.jpg" style="margin-top: -140px;"/>
                                        <div class="lbls1"></div>
                                        <div class="lbls2"></div>
                                        <div class="lbls3"></div>
                                        <div class="lbls4"></div>
                                        <div class="lbls5"></div>
                                        <div class="lbls6"></div>
                                        <div class="lbls7"></div>
                                        <div class="lbls8"></div>
                                        <div class="lbls9"></div>
                                        <div class="lbls10"></div>
                                        <div class="lbls11"></div>
                                        <div class="lbls12"></div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="tab_1_2">
                                    <div class="row">
                                        <div id="container_tab2" class="dataTables_wrapper form-inline" role="grid">
                                            <div class="showItem">
                                                View charts
                                                <a class="active" data="1"><i class="fa fa-align-justify"></i></a>
                                                <a data="2"><i class="fa fa-th-large"></i></a>
                                                <a data="3"><i class="fa fa-th"></i></a>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 1
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart1" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 2
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart2" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 3
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart3" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 4
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart4" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 5
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart5" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 6
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart6" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 7
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart7" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 8
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart8" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 9
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart9" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 10
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart10" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 11
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart11" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 12
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart12" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 13
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart13" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 14
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart14" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 15
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart15" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                            <div class="portlet box green">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-bar-chart"></i>SENSOR 16
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div id="trendchart16" class="chartTrendView"></div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="tab-pane" id="tab_1_3">
                                    <div id="container_tab3" class="dataTables_wrapper form-inline" role="grid">
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 1
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_1"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv1" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 2
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_2"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv2" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 3
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_3"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv3" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 4
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_4"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv4" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 5
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_5"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv5" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 6
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_6"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv6" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 7
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_7"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv7" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 8
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_8"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv8" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 9
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_9"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv9" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 10
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_10"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv10" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 11
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_11"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv11" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 12
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_12"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv12" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 13
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_13"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv13" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 14
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_14"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv14" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 15
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_15"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv15" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-bar-chart"></i> SENSOR 16
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_16"
                                                    aria-describedby="sample_1_info">
                                                    <thead>
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>TimeStamp</td>
                                                            <td>RH(%)</td>
                                                            <td>temperature(°C)</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                                </table>
                                                <br /><br />
                                                <div id="chartdiv16" class="chartReport"></div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="tab_1_4">
                                    <div class="portlet box green">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-bar-chart"></i>List alarms
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <table class="table table-striped table-bordered table-hover dataTable" id="tbl_alarms"
                                                aria-describedby="sample_1_info">
                                                <thead>
                                                    <tr>
                                                        <td style="width:50px;">ID</td>
                                                        <td>TimeStamp</td>
                                                        <td>Class</td>
                                                        <td>Device</td>
                                                        <td style="width:50px;">Status</td>
                                                        <td>Event</td>
                                                        <td>User</td>
                                                        <td>Comment</td>
                                                        <td>TimeUpdate</td>
                                                        <td style="width:50px;"></td>
                                                    </tr>
                                                </thead>
                                                <tbody role="alert" aria-live="polite" aria-relevant="all"></tbody>
                                            </table>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="tab_1_5">
                                    <div class="portlet box green">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="icon-equalizer font-red-sunglo"></i> Setting 
                                            </div>
                                        </div>
                                        <div class="portlet-body form">
                                            <!-- BEGIN FORM-->
                                            <form action="#" class="form-horizontal">
                                                <div class="form-body">
                                                    <br />
                                                    <div class="form-group">
                                                        <label class="col-md-3 control-label">Sensor</label>
                                                        <div class="col-md-4">
                                                            <select class="form-control">
                                                                <option value="">Please choise...</option>
                                                                <option value="1">Sensor1</option>
                                                                <option value="1">Sensor2</option>
                                                                <option value="1">Sensor3</option>
                                                                <option value="1">Sensor4</option>
                                                                <option value="1">Sensor5</option>
                                                                <option value="1">Sensor6</option>
                                                                <option value="1">Sensor7</option>
                                                                <option value="1">Sensor8</option>
                                                                <option value="1">Sensor9</option>
                                                                <option value="1">Sensor10</option>
                                                                <option value="1">Sensor11</option>
                                                                <option value="1">Sensor12</option>
                                                                <option value="1">Sensor13</option>
                                                                <option value="1">Sensor14</option>
                                                                <option value="1">Sensor15</option>
                                                                <option value="1">Sensor16</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <br /><br /><br />
                                                    <div class="form-group">
                                                        <label class="col-md-3 control-label">Temperature(°C)</label>
                                                        <div class="col-md-4">
                                                            <div class="input-group">
                                                                <div id="setting_nhietdo" class="noUi-danger"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br /><br /><br />
                                                    <div class="form-group">
                                                        <label class="col-md-3 control-label">Humidity(%)</label>
                                                        <div class="col-md-4">
                                                            <div class="input-group">
                                                                <div id="setting_doam" class="noUi-danger"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-md-3 control-label">Alarm Email</label>
                                                        <div class="col-md-4">
                                                            <div class="input-group">
                                                                <label style="margin-top:5px;" class="mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox" class="checkboxes" id="alarmEmail"><span></span></label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-md-3 control-label">Email receive alarm</label>
                                                        <div class="col-md-4">
                                                            <div class="input-group">
                                                                <select style="width:100%;" id="txtEmailAlarms" class="form-control" multiple="multiple">
                                                                    <option selected>root@company.com</option>
                                                                    <option selected>admin@company.com</option>
                                                                    <option selected>it@company.com</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-md-3 control-label">Update data cycle(minute)</label>
                                                        <div class="col-md-4">
                                                            <div class="input-icon">
                                                                <input id="txtUpdateData" type="number" class="form-control">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-actions">
                                                    <div class="row">
                                                        <div class="col-md-offset-3 col-md-9">
                                                            <button type="submit" class="btn btn-circle green">Submit</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </form>
                                            <!-- END FORM-->
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
        <div class="portlet light portlet-fit bordered">
            <div class="portlet-body">
                <br /><br />
                <label style="margin-left:24px;" class="cb1 mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox" class="checkboxes" id="cb_all"><span></span> CheckAll</label> 
                <label style="margin-left:24px;" class="cb2 mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox" class="checkboxes" id="cb_all2"><span></span> CheckAll</label>
                <br />
                <div class="clearfix"></div>
                <div id="listSensor" style="text-align: center; display:none;">
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 1 </div>
                        <label class="checkbox-inline">
                            <input data="1" type="checkbox" checked="" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 2 </div>
                        <label class="checkbox-inline">
                            <input data="2" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 3 </div>
                        <label class="checkbox-inline">
                            <input data="3" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 4 </div>
                        <label class="checkbox-inline">
                            <input data="4" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 5 </div>
                        <label class="checkbox-inline">
                            <input data="5" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 6 </div>
                        <label class="checkbox-inline">
                            <input data="6" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 7 </div>
                        <label class="checkbox-inline">
                            <input data="7" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 8 </div>
                        <label class="checkbox-inline">
                            <input data="8" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 9 </div>
                        <label class="checkbox-inline">
                            <input data="9" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 10 </div>
                        <label class="checkbox-inline">
                            <input data="10" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 11 </div>
                        <label class="checkbox-inline">
                            <input data="11" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 12 </div>
                        <label class="checkbox-inline">
                            <input data="12" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 13 </div>
                        <label class="checkbox-inline">
                            <input data="13" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 14 </div>
                        <label class="checkbox-inline">
                            <input data="14" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 15 </div>
                        <label class="checkbox-inline">
                            <input data="15" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 16 </div>
                        <label class="checkbox-inline">
                            <input data="16" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                </div>

                <div id="listSensor2" style="text-align: center; display:none;">
                    <div class="clearfix"></div>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 1 </div>
                        <label class="checkbox-inline">
                            <input data="1" type="checkbox" checked="" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 2 </div>
                        <label class="checkbox-inline">
                            <input data="2" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 3 </div>
                        <label class="checkbox-inline">
                            <input data="3" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 4 </div>
                        <label class="checkbox-inline">
                            <input data="4" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 5 </div>
                        <label class="checkbox-inline">
                            <input data="5" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 6 </div>
                        <label class="checkbox-inline">
                            <input data="6" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 7 </div>
                        <label class="checkbox-inline">
                            <input data="7" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 8 </div>
                        <label class="checkbox-inline">
                            <input data="8" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 9 </div>
                        <label class="checkbox-inline">
                            <input data="9" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 10 </div>
                        <label class="checkbox-inline">
                            <input data="10" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 11 </div>
                        <label class="checkbox-inline">
                            <input data="11" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 12 </div>
                        <label class="checkbox-inline">
                            <input data="12" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 13 </div>
                        <label class="checkbox-inline">
                            <input data="13" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 14 </div>
                        <label class="checkbox-inline">
                            <input data="14" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 15 </div>
                        <label class="checkbox-inline">
                            <input data="15" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                    <a href="javascript:;" class="icon-btn">
                        <i class="fa fa-rss"></i>
                        <div>Sensor 16 </div>
                        <label class="checkbox-inline">
                            <input data="16" type="checkbox" data-toggle="toggle" data-on="ON" data-off="OFF" data-size="mini"></label>
                    </a>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="modal_alarams" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <form method="post" action="javascript:CommentAlarm();">
                    <div id="form_sample_1" novalidate="novalidate">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            </button>
                            <h4 class="modal-title" id="title_task">Comment warning alarm</h4>
                        </div>
                        <div class="modal-body">
                            <input type="hidden" id="alarmID" value="0" />
                            <div class="form-body">
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            Comment</label>
                                        <div class="col-md-8">
                                            <div class="input-icon right">
                                                <textarea id="txtComment" class="form-control input-lg" required maxlength="500"></textarea>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            Password</label>
                                        <div class="col-md-8">
                                            <input id="txtPassword" type="password" class="form-control input-lg" maxlength="20" required/>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn default" data-dismiss="modal">
                                Close</button>
                            <button id="btnSubmit" type="submit" class="btn blue">
                                Save changes</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <link href="assets/global/css/sensor.css" rel="stylesheet" />
    <link href="assets/global/plugins/datepicker/css/bootstrap-timepicker.min.css" rel="stylesheet" />  
    <link href="assets/global/plugins/Datetime/datetimepicker.css" rel="stylesheet" />
	<link href="assets/pages/css/kieuthung.css" rel="stylesheet" />
    <link href="assets/global/plugins/datatables/Datatable_1_10_16/buttons.dataTables.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap/css/bootstrap-toggle.min.css" rel="stylesheet" />
    <script src="assets/global/plugins/bootstrap/js/bootstrap-toggle.min.js"></script>
    <link href="assets/global/plugins/nouislider/nouislider.min.css" rel="stylesheet" />
    <link href="assets/global/plugins/nouislider/nouislider.pips.css" rel="stylesheet" />
    <script src="assets/global/plugins/nouislider/nouislider.min.js"></script>
    <script src="assets/global/plugins/nouislider/components-nouisliders.min.js"></script>

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
    <script src="assets/global/plugins/easyChart/jquery.easypiechart.min.js"></script>
    <script src="assets/global/plugins/amcharts/v4/core.js"></script>
    <script src="assets/global/plugins/amcharts/v4/charts.js"></script>
    <script src="assets/global/plugins/amcharts/v4/animated.js"></script>
    <script src="assets/global/plugins/jquery.pulsate.min.js"></script>
    <script> 
        var num = 0;
        var globalVars = {unloaded:true};
        var chart1;
        var data = [];
        var _pageSize = 10;
        var _currentPage = 0;
        var oTableAlarm = null;
        var colHiden = [];
        var t1 = [], t2 = [], t3 = [], t4 = [], t5 = [], t6 = [], t7 = [], t8 = [], t9 = [], t10 = [], t11 = [], t12 = [], t13 = [], t14 = [], t15 = [], t16 = [];
        var t_alarms = [];
        var chartData1 = [], chartData2 = [], chartData3 = [], chartData4 = [], chartData5 = [], chartData6 = [], chartData7 = [], chartData8 = [], chartData9 = [], chartData10 = [], chartData11 = [], chartData12 = [], chartData13 = [], chartData14 = [], chartData15 = [], chartData16 = [];
        var oTable1, oTable2, oTable3, oTable4, oTable5, oTable6, oTable7, oTable8, oTable9, oTable10, oTable11, oTable12, oTable13, oTable14, oTable15, oTable16, oTable_alarms;

        //$(window).bind('beforeunload', function () {
        //    console.log("before unload");
        //    globalVars.unloaded = true;
        //});

        $(document).ready(function () {
            for (var i = 0; i < 16; i++) {
                LoadChartTrenView("trendchart" + (i+1));
            }
        });

        function SetData(data, chartData) {
            var d = moment("0000", "hmm");
            for (var i = 0; i < 96; i++) {
                d.add(15, 'minutes');
                var obj = [];
                obj.push(moment().format("DD/MM/YYYY"));//ngay report
                obj.push(d.format("HH:mm")); //thoi gian report
                obj.push(randomIntFromInterval(10, 90))// do am
                obj.push(randomIntFromInterval(10, 70))// nhiet do
                data.push(obj);
                chartData.push({ "date": obj[1], "RH": obj[2], "Temperature": obj[3], "low": 20, "high": 60 });
            }
        }

        function SetTableAlarms(data) {
            var d = moment("0000", "hmm");
            for (var i = 0; i < 20; i++) {
                d.add(15, 'minutes');
                var obj = [];
                obj.push(i+1)
                obj.push(moment().format("DD/MM/YYYY") + " " + d.format("HH:mm"));// timestamp
                obj.push(randomIntFromInterval(1, 100) > 50 ? "ERROR" : "WARNING")// class
                obj.push(randomIntFromInterval(1, 16));
                obj.push("I");//status
                obj.push("");//event
                obj.push("");//user
                obj.push("");//comment
                obj.push("");
                obj.push("<a href='javascript:;' class='btn btn-sm btnAck green'><i class='fa fa-plus'></i> ACK </a>");//button ack
                data.push(obj);
            }
        }

        function CommentAlarm() {
            var index = parseInt($('#alarmID').val());
            var uData = JSON.parse($('#_userdata').val());
            t_alarms[index][6] = uData.UserName;
            t_alarms[index][7] = $('#txtComment').val();
            t_alarms[index][8] = moment().calendar();
            ViewTableAlarms("#tbl_alarms", t_alarms);
            $('#modal_alarams').modal('hide');
            $('#txtComment').val("");
            $('#txtPassword').val("");
        }

        $(function () {
            $('.divLoading1').fadeIn();
            $('.sidebar-toggler').hide();
            $('.page-content').css("margin-left", "0");
            // init page
            $('#txtEmailAlarms').select2({
                tags: true,
                tokenSeparators: [',', ' ']
            });
            $('#txtUpdateData').val(5);

            $('#listSensor').hide();
            $('#listSensor2').hide();
            $('#menuPage').hide(0);
            $('#container_tab3 .portlet').fadeOut(0);
            var item = $('#container_tab3 .portlet')[0];
            $(item).fadeIn(50);
            SetTableAlarms(t_alarms);
            SetData(t1, chartData1);
            SetData(t2, chartData2);
            SetData(t3, chartData3);
            SetData(t4, chartData4);
            SetData(t5, chartData5);
            SetData(t6, chartData6);
            SetData(t7, chartData7);
            SetData(t8, chartData8);
            SetData(t9, chartData9);
            SetData(t10, chartData10);
            SetData(t11, chartData11);
            SetData(t12, chartData12);
            SetData(t13, chartData13);
            SetData(t14, chartData14);
            SetData(t15, chartData15);
            SetData(t16, chartData16);
            ViewTableReport("#tbl_1", t1, oTable1);
            oTable1 = "";
            LoadChart("chartdiv1", chartData1);
            ViewTableReport("#tbl_2", t2, oTable2);
            oTable2 = "";
            LoadChart("chartdiv2", chartData2);
            ViewTableReport("#tbl_3", t3, oTable3);
            oTable3 = "";
            LoadChart("chartdiv3", chartData3);
            ViewTableReport("#tbl_4", t4, oTable4);
            oTable4 = "";
            LoadChart("chartdiv4", chartData4);
            ViewTableReport("#tbl_5", t5, oTable5);
            oTable5 = "";
            LoadChart("chartdiv5", chartData5);
            ViewTableReport("#tbl_6", t6, oTable6);
            oTable6 = "";
            LoadChart("chartdiv6", chartData6);
            ViewTableReport("#tbl_7", t7, oTable7);
            oTable7 = "";
            LoadChart("chartdiv7", chartData7);
            ViewTableReport("#tbl_8", t8, oTable8);
            oTable8 = "";
            LoadChart("chartdiv8", chartData8);
            ViewTableReport("#tbl_9", t9, oTable9);
            oTable9 = "";
            LoadChart("chartdiv9", chartData9);
            ViewTableReport("#tbl_10", t10, oTable10);
            oTable10 = "";
            LoadChart("chartdiv10", chartData10);
            ViewTableReport("#tbl_11", t11, oTable11);
            oTable11 = "";
            LoadChart("chartdiv11", chartData11);
            ViewTableReport("#tbl_12", t12, oTable12);
            oTable12 = "";
            LoadChart("chartdiv12", chartData12);
            ViewTableReport("#tbl_13", t13, oTable13);
            oTable13 = "";
            LoadChart("chartdiv13", chartData13);
            ViewTableReport("#tbl_14", t14, oTable14);
            oTable14 = "";
            LoadChart("chartdiv14", chartData14);
            ViewTableReport("#tbl_15", t15, oTable15);
            oTable15 = "";
            LoadChart("chartdiv15", chartData15);
            ViewTableReport("#tbl_16", t16, oTable16);
            oTable16 = "";
            LoadChart("chartdiv16", chartData16);
            $('#listSensor input').bootstrapToggle('on');
            $('#container_tab3 .portlet').fadeIn();
            $('#cb_all').prop("checked", true);
            $('#listSensor2 input').bootstrapToggle('on');
            $('#cb_all2').prop("checked", true);
            //--------------------

            $('.showItem a').click(function () {
                $('.showItem a').removeClass('active');
                $(this).addClass('active');
                var t = $(this).attr('data');
                switch (t) {
                    case "1":
                        $('#container_tab2 .portlet').removeClass("col-md-4");
                        $('#container_tab2 .portlet').removeClass("col-md-6");
                        $('#container_tab2 .portlet').addClass("col-md-12");
                        break;
                    case "2":
                        $('#container_tab2 .portlet').removeClass("col-md-4");
                        $('#container_tab2 .portlet').removeClass("col-md-12");
                        $('#container_tab2 .portlet').addClass("col-md-6");
                        break;
                    case "3":
                        $('#container_tab2 .portlet').removeClass("col-md-12");
                        $('#container_tab2 .portlet').removeClass("col-md-6");
                        $('#container_tab2 .portlet').addClass("col-md-4");
                        break;
                    default:
                }
            });

            $('#listSensor input').change(function () {
                var value = $(this).prop('checked');
                if (!value) {
                    $('#cb_all').prop("checked", false);
                }
                else {
                    var cb = $('#listSensor input');
                    console.log(cb);
                    var count = 0;
                    for (var i = 0; i < cb.length; i++) {
                        if (cb[i].checked)
                            count++;
                    }
                    if (count == 16) {
                        $('#cb_all').prop("checked", true);
                    }
                }
                //console.log('Toggle: ' + $(this).prop('checked') +
                //    ", value: " + $(this).attr('data'));
                var sensorID = parseInt($(this).attr('data'));
                console.log("ID: " + sensorID);
                var item = $('#container_tab3 .portlet')[sensorID - 1];
                switch (sensorID) {
                    case 1:
                        callback();
                        if (value) {//ON
                            $(item).fadeIn(500);
                        }
                        else {//OFF
                            $(item).fadeOut(200);
                        }
                        break;
                    case 2:
                        if (t2.length == 0) {
                            SetData(t2, chartData2);
                            ViewTableReport("#tbl_" + sensorID, t2);
                            LoadChart("chartdiv" + sensorID, chartData2, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable2 = "";
                        }
                        if (value) {
                            //console.log(oTable2);
                            if (oTable2 == undefined || oTable2 == null) {
                                ViewTableReport("#tbl_" + sensorID, t2);
                                LoadChart("chartdiv" + sensorID, chartData2, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable2 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 3:
                        if (t3.length == 0) {
                            SetData(t3, chartData3);
                            ViewTableReport("#tbl_" + sensorID, t3);
                            LoadChart("chartdiv" + sensorID, chartData3, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable3 = "";
                        }
                        if (value) {
                            if (oTable3 == undefined || oTable3 == null) {
                                ViewTableReport("#tbl_" + sensorID, t3);
                                LoadChart("chartdiv" + sensorID, chartData3, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable3 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 4:
                        if (t4.length == 0) {
                            SetData(t4, chartData4);
                            ViewTableReport("#tbl_" + sensorID, t4);
                            LoadChart("chartdiv" + sensorID, chartData4, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable4 = "";
                        }
                        if (value) {
                            if (oTable4 == undefined || oTable4 == null) {
                                ViewTableReport("#tbl_" + sensorID, t4);
                                LoadChart("chartdiv" + sensorID, chartData4, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable4 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 5:
                        if (t5.length == 0) {
                            SetData(t5, chartData5);
                            ViewTableReport("#tbl_" + sensorID, t5);
                            LoadChart("chartdiv" + sensorID, chartData5, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable5 = "";
                        }
                        if (value) {
                            if (oTable5 == undefined || oTable5 == null) {
                                ViewTableReport("#tbl_" + sensorID, t5);
                                LoadChart("chartdiv" + sensorID, chartData5, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable5 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 6:
                        if (t6.length == 0) {
                            SetData(t6, chartData6);
                            ViewTableReport("#tbl_" + sensorID, t6);
                            LoadChart("chartdiv" + sensorID, chartData6, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable6 = "";
                        }
                        if (value) {
                            if (oTable6 == undefined || oTable6 == null) {
                                ViewTableReport("#tbl_" + sensorID, t6);
                                LoadChart("chartdiv" + sensorID, chartData6, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable6 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 7:
                        if (t7.length == 0) {
                            SetData(t7, chartData7);
                            ViewTableReport("#tbl_" + sensorID, t7);
                            LoadChart("chartdiv" + sensorID, chartData7, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable7 = "";
                        }
                        if (value) {
                            if (oTable7 == undefined || oTable7 == null) {
                                ViewTableReport("#tbl_" + sensorID, t7);
                                LoadChart("chartdiv" + sensorID, chartData7, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable7 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 8:
                        if (t8.length == 0) {
                            SetData(t8, chartData8);
                            ViewTableReport("#tbl_" + sensorID, t8);
                            LoadChart("chartdiv" + sensorID, chartData8, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable8 = "";
                        }
                        if (value) {
                            if (oTable8 == undefined || oTable8 == null) {
                                ViewTableReport("#tbl_" + sensorID, t8);
                                LoadChart("chartdiv" + sensorID, chartData8, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable8 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 9:
                        if (t9.length == 0) {
                            SetData(t9, chartData9);
                            ViewTableReport("#tbl_" + sensorID, t9);
                            LoadChart("chartdiv" + sensorID, chartData9, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable9 = "";
                        }
                        if (value) {
                            if (oTable9 == undefined || oTable9 == null) {
                                ViewTableReport("#tbl_" + sensorID, t9);
                                LoadChart("chartdiv" + sensorID, chartData9, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable9 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 10:
                        if (t10.length == 0) {
                            SetData(t10, chartData10);
                            ViewTableReport("#tbl_" + sensorID, t10);
                            LoadChart("chartdiv" + sensorID, chartData10, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable10 = "";
                        }
                        if (value) {
                            if (oTable10 == undefined || oTable10 == null) {
                                ViewTableReport("#tbl_" + sensorID, t10);
                                LoadChart("chartdiv" + sensorID, chartData10, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable10 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 11:
                        if (t11.length == 0) {
                            SetData(t11, chartData11);
                            ViewTableReport("#tbl_" + sensorID, t11);
                            LoadChart("chartdiv" + sensorID, chartData11, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable11 = "";
                        }
                        if (value) {
                            if (oTable11 == undefined || oTable11 == null) {
                                ViewTableReport("#tbl_" + sensorID, t11);
                                LoadChart("chartdiv" + sensorID, chartData11, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable11 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 12:
                        if (t12.length == 0) {
                            SetData(t12, chartData12);
                            ViewTableReport("#tbl_" + sensorID, t12);
                            LoadChart("chartdiv" + sensorID, chartData12, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable12 = "";
                        }
                        if (value) {
                            if (oTable12 == undefined || oTable12 == null) {
                                ViewTableReport("#tbl_" + sensorID, t12);
                                LoadChart("chartdiv" + sensorID, chartData12, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable12 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 13:
                        if (t13.length == 0) {
                            SetData(t13, chartData13);
                            ViewTableReport("#tbl_" + sensorID, t13);
                            LoadChart("chartdiv" + sensorID, chartData13, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable13 = "";
                        }
                        if (value) {
                            if (oTable13 == undefined || oTable13 == null) {
                                ViewTableReport("#tbl_" + sensorID, t13);
                                LoadChart("chartdiv" + sensorID, chartData13, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable13 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 14:
                        if (t14.length == 0) {
                            SetData(t14, chartData14);
                            ViewTableReport("#tbl_" + sensorID, t14);
                            LoadChart("chartdiv" + sensorID, chartData14, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable14 = "";
                        }
                        if (value) {
                            if (oTable14 == undefined || oTable14 == null) {
                                ViewTableReport("#tbl_" + sensorID, t14);
                                LoadChart("chartdiv" + sensorID, chartData14, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable14 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 15:
                        if (t15.length == 0) {
                            SetData(t15, chartData15);
                            ViewTableReport("#tbl_" + sensorID, t15);
                            LoadChart("chartdiv" + sensorID, chartData15, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable15 = "";
                        }
                        if (value) {
                            if (oTable15 == undefined || oTable15 == null) {
                                ViewTableReport("#tbl_" + sensorID, t15);
                                LoadChart("chartdiv" + sensorID, chartData15, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable15 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    case 16:
                        if (t16.length == 0) {
                            SetData(t16, chartData16);
                            ViewTableReport("#tbl_" + sensorID, t16);
                            LoadChart("chartdiv" + sensorID, chartData16, "date", "doam", "nhietdo", "", "%", "°C");
                            oTable16 = "";
                        }
                        if (value) {
                            if (oTable16 == undefined || oTable16 == null) {
                                ViewTableReport("#tbl_" + sensorID, t16);
                                LoadChart("chartdiv" + sensorID, chartData16, "date", "doam", "nhietdo", "", "%", "°C");
                                oTable16 = "";
                            }
                            $(item).fadeIn(500);
                        }
                        else
                            $(item).fadeOut(200);
                        callback();
                        break;
                    default:
                }
            });

            $('#listSensor2 input').change(function () {
                var value = $(this).prop('checked');
                if (!value) {
                    $('#cb_all2').prop("checked", false);
                }
                else {
                    var cb = $('#listSensor2 input');
                    console.log(cb);
                    var count = 0;
                    for (var i = 0; i < cb.length; i++) {
                        if (cb[i].checked)
                            count++;
                    }
                    if (count == 16) {
                        $('#cb_all2').prop("checked", true);
                    }
                }
                var sensorID = parseInt($(this).attr('data'));
                console.log("ID: " + sensorID);
                var item = $('#container_tab2 .portlet')[sensorID - 1];
                if (value) {//ON
                    $(item).fadeIn(500);
                }
                else {//OFF
                    $(item).fadeOut(200);
                }
            });

            $('#cb_all').change(function () {
                console.log($('#cb_all').is(':checked'));
                if ($('#cb_all').is(':checked')) {
                    $('#listSensor input').bootstrapToggle('on');
                }
                else {
                    $('#listSensor input').bootstrapToggle('off');
                }
            });

            $('#cb_all2').change(function () {
                console.log($('#cb_all2').is(':checked'));
                if ($('#cb_all2').is(':checked')) {
                    $('#listSensor2 input').bootstrapToggle('on');
                }
                else {
                    $('#listSensor2 input').bootstrapToggle('off');
                }
            });

            ComponentsPickers.init();
            
            
            /////////////// EVENT DELEGATE /////////////////
            $('#listTab').delegate("li", "click", function () {
                var t = $(this).text().trim();
                console.log("listTab click: " + t);
                switch (t) {
                    case "Trend View":
                        $('.cb2').show();
                        $('.cb1').hide();
                        $('#listSensor2').show();
                        $('#listSensor').hide();
                        $('#dateFilter').fadeOut(0);
                        //if ($('.btnSidebar').attr('action') == "close")
                        //    $('.btnSidebar').click();
                        //chart.data = data;
                        break;
                    case "Report Data":
                        $('.cb1').show();
                        $('.cb2').hide();
                        $('#listSensor').show();
                        $('#listSensor2').hide();
                        $('#dateFilter').fadeIn(0);
                        //if ($('.btnSidebar').attr('action') == "close")
                        //    $('.btnSidebar').click();
                        //if ($('#listSensor').html() == "") {
                        //    for (var i = 0; i < 32; i++) {
                        //        $('#listSensor').append("<label class='checkbox-inline'>" +
                        //            "<input data='"+(i+1)+"' type='checkbox' " + (i == 0 ? "checked" : "") + " data-toggle='toggle' data-on='ON "+(i+1)+"' data-off='OFF "+(i+1)+"' data-size='mini'>" +
                        //        "</label>");
                        //    }
                        //}
                        break;
                    case "Alarms":
                        if ($('.btnSidebar').attr('action') == "open")
                            $('.btnSidebar').click();
                        $('#dateFilter').fadeIn(0);
                        if (oTable_alarms == undefined) {
                            ViewTableAlarms("#tbl_alarms", t_alarms);
                            oTable_alarms = "";
                        }
                        break;
                    default:
                        $('#dateFilter').fadeOut(0);
                        if ($('.btnSidebar').attr('action') == "open")
                            $('.btnSidebar').click();
                        break;
                }
            });

            $('#tbl_alarms').on('click', '.btnAck', function (e) {
                e.preventDefault();
                var nRow = $(this).parents('tr')[0];
                var aData = oTableAlarm.fnGetData(nRow);
                console.log(aData);
                $('#alarmID').val($(this).parents('tr').index());
                $('#modal_alarams').modal('show');
            });
        });

        function callback() {
            num++;
            console.log("num = " + num);
            if (num >= 32) {
                num = 0;
                $('.divLoading1').fadeOut(500);
            }
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
                    startDate: moment().subtract('day', 0),
                    endDate: moment(),
                    minDate: moment().subtract('year', 1).format('MM/DD/YYYY'),
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
                _dateStart = moment().subtract('day', 0).format('YYYY/MM/DD');
                _dateEnd = moment().format('YYYY/MM/DD');
                _dateReportStart = moment().subtract('day', 0).format('DD/MM/YYYY');
                _dateReportEnd = moment().format('DD/MM/YYYY');
                $('#dateRangeEvent input').val(_dateStart + ' - ' + _dateEnd);
            };

            return {
                init: function () {
                    handleDateRangePickers();
                }
            };
        }();    

        function LoadChartTrenView(div) {
            var chart;
            var dataChart = [];
            am4core.ready(function () {
                // Themes begin
                am4core.useTheme(am4themes_animated);
                // Themes end

                chart = am4core.create(div, am4charts.XYChart);
                chart.hiddenState.properties.opacity = 0;
                chart.padding(0, 0, 0, 0);

                chart.zoomOutButton.disabled = true;

                var visits = 0;
                var visits2 = 0;
                var i = 0;
                if (dataChart.length == 0) {
                    for (i = 0; i <= 40; i++) {
                        visits = randomIntFromInterval(10, 70);//Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);
                        visits2 = randomIntFromInterval(10, 100);
                        dataChart.push({ date: new Date().setSeconds(i - 30), value: visits, value2: visits2, low: 20, high: 60 });
                    }
                }
                chart.data = dataChart;

                var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
                dateAxis.renderer.grid.template.location = 0;
                dateAxis.renderer.minGridDistance = 30;
                dateAxis.dateFormats.setKey("second", "ss");
                dateAxis.periodChangeDateFormats.setKey("second", "[bold]h:mm a");
                dateAxis.periodChangeDateFormats.setKey("minute", "[bold]h:mm a");
                dateAxis.periodChangeDateFormats.setKey("hour", "[bold]h:mm a");
                dateAxis.renderer.inside = true;
                dateAxis.renderer.axisFills.template.disabled = true;
                dateAxis.renderer.ticks.template.disabled = true;

                var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
                valueAxis.tooltip.disabled = true;
                valueAxis.interpolationDuration = 500;
                valueAxis.rangeChangeDuration = 500;
                valueAxis.renderer.inside = true;
                valueAxis.renderer.minLabelPosition = 0.05;
                valueAxis.renderer.maxLabelPosition = 0.95;
                valueAxis.renderer.axisFills.template.disabled = true;
                valueAxis.renderer.grid.template.disabled = true;
                valueAxis.renderer.ticks.template.disabled = true;
                valueAxis.min = 10;
                valueAxis.max = 80;
                valueAxis.strictMinMax = true;
                valueAxis.title.text = "Temperature(°C)";

                var valueAxis2 = chart.yAxes.push(new am4charts.ValueAxis());
                valueAxis2.tooltip.disabled = true;
                valueAxis2.interpolationDuration = 500;
                valueAxis2.rangeChangeDuration = 500;
                valueAxis2.renderer.inside = true;
                valueAxis2.renderer.opposite = true;
                valueAxis2.renderer.minLabelPosition = 0.05;
                valueAxis2.renderer.maxLabelPosition = 0.95;
                valueAxis2.renderer.axisFills.template.disabled = true;
                valueAxis2.renderer.grid.template.disabled = true;
                valueAxis2.renderer.ticks.template.disabled = true;
                valueAxis2.min = 0;
                valueAxis2.max = 100;
                valueAxis2.strictMinMax = true;
                valueAxis2.title.text = "RH(%)";
                

                var series = chart.series.push(new am4charts.LineSeries());
                series.dataFields.dateX = "date";
                series.dataFields.valueY = "value";
                series.interpolationDuration = 500;
                series.defaultState.transitionDuration = 0;
                series.tensionX = 0.8;
                series.strokeWidth = 2;
                series.yAxis = valueAxis;
                series.propertyFields.strokeDasharray = "dashLength";
                series.name = "Temperature" + "(°C)";
                //series.tooltipText = "Temperature" + ": {valueY}" + "°C";

                var series2 = chart.series.push(new am4charts.LineSeries());
                series2.dataFields.dateX = "date";
                series2.dataFields.valueY = "value2";
                series2.interpolationDuration = 500;
                series2.defaultState.transitionDuration = 0;
                series2.tensionX = 0.8;
                series2.strokeWidth = 2;
                series2.yAxis = valueAxis2;
                series2.propertyFields.strokeDasharray = "dashLength";
                series2.name = "RH" + "(%)";
                //series2.tooltipText = "RH" + ": {valueY}" + "%";

                var lowSeries = chart.series.push(new am4charts.LineSeries());
                lowSeries.dataFields.valueY = "low";
                lowSeries.dataFields.dateX = "date";
                lowSeries.interpolationDuration = 500;
                lowSeries.defaultState.transitionDuration = 0;
                lowSeries.tensionX = 0.8;
                lowSeries.strokeWidth = 2;
                lowSeries.yAxis = valueAxis;
                lowSeries.name = "Low(°C)";
                lowSeries.strokeWidth = 1;
                lowSeries.propertyFields.strokeDasharray = "dashLength";

                var highSeries = chart.series.push(new am4charts.LineSeries());
                highSeries.dataFields.valueY = "high";
                highSeries.dataFields.dateX = "date";
                highSeries.interpolationDuration = 500;
                highSeries.defaultState.transitionDuration = 0;
                highSeries.tensionX = 0.8;
                highSeries.strokeWidth = 2;
                highSeries.yAxis = valueAxis;
                highSeries.name = "High(°C)";
                highSeries.strokeWidth = 1;
                highSeries.propertyFields.strokeDasharray = "dashLength";


                // Add legend
                chart.legend = new am4charts.Legend();

                // Add cursor
                chart.cursor = new am4charts.XYCursor();
                chart.cursor.fullWidthLineX = true;
                chart.cursor.xAxis = dateAxis;
                chart.cursor.lineX.strokeOpacity = 0;
                chart.cursor.lineX.fill = am4core.color("#000");
                chart.cursor.lineX.fillOpacity = 0.1;


                chart.events.on("datavalidated", function () {
                    dateAxis.zoom({ start: 1 / 15, end: 1.2 }, false, true);
                });

                dateAxis.interpolationDuration = 500;
                dateAxis.rangeChangeDuration = 500;

                document.addEventListener("visibilitychange", function () {
                    if (document.hidden) {
                        if (interval) {
                            clearInterval(interval);
                        }
                    }
                    else {
                        startInterval();
                    }
                }, false);

                // add data
                var interval;
                function startInterval() {
                    interval = setInterval(function () {
                        visits = randomIntFromInterval(10, 70);
                        visits2 = randomIntFromInterval(10, 100);
                        //console.log("lbls" + div.replace("trendchart", ""));
                        $('.lbls' + div.replace("trendchart", "")).html(visits);
                        if (visits <= 20)
                            $('.lbls' + div.replace("trendchart", "")).pulsate({ color: "#c11313" });
                        else if (visits >= 60)
                            $('.lbls' + div.replace("trendchart", "")).pulsate({ color: "#c11313" });
                        else
                            $('.lbls' + div.replace("trendchart", "")).pulsate({ color: "#09f" })
                        var lastdataItem = series.dataItems.getIndex(series.dataItems.length - 1);
                        chart.addData(
                            { date: new Date(lastdataItem.dateX.getTime() + 3000), value: visits, value2: visits2, low: 20, high: 60 }
                        );
                    }, 3000);
                }

                startInterval();

                // all the below is optional, makes some fancy effects
                // gradient fill of the series
                series.fillOpacity = 1;
                var gradient = new am4core.LinearGradient();
                gradient.addColor(chart.colors.getIndex(0), 0);
                gradient.addColor(chart.colors.getIndex(0), 0);
                series.fill = gradient;

                series2.fillOpacity = 1;
                var gradient2 = new am4core.LinearGradient();
                gradient2.addColor(chart.colors.getIndex(0), 0);
                gradient2.addColor(chart.colors.getIndex(0), 0);
                series2.fill = gradient2;

                // this makes date axis labels to fade out
                dateAxis.renderer.labels.template.adapter.add("fillOpacity", function (fillOpacity, target) {
                    var dataItem = target.dataItem;
                    return dataItem.position;
                });

                // need to set this, otherwise fillOpacity is not changed and not set
                dateAxis.events.on("validated", function () {
                    am4core.iter.each(dateAxis.renderer.labels.iterator(), function (label) {
                        label.fillOpacity = label.fillOpacity;
                    })
                });

                // this makes date axis labels which are at equal minutes to be rotated
                dateAxis.renderer.labels.template.adapter.add("rotation", function (rotation, target) {
                    var dataItem = target.dataItem;
                    if (dataItem.date && dataItem.date.getTime() == am4core.time.round(new Date(dataItem.date.getTime()), "minute").getTime()) {
                        target.verticalCenter = "middle";
                        target.horizontalCenter = "left";
                        return -90;
                    }
                    else {
                        target.verticalCenter = "bottom";
                        target.horizontalCenter = "middle";
                        return 0;
                    }
                })

                // bullet at the front of the line
                var bullet = series.createChild(am4charts.CircleBullet);
                bullet.circle.radius = 5;
                bullet.fillOpacity = 1;
                bullet.fill = chart.colors.getIndex(0);
                bullet.isMeasured = false;

                series.events.on("validated", function () {
                    bullet.moveTo(series.dataItems.last.point);
                    bullet.validatePosition();
                });

                var bullet2 = series2.createChild(am4charts.CircleBullet);
                bullet2.circle.radius = 5;
                bullet2.fillOpacity = 1;
                bullet2.fill = chart.colors.getIndex(0);
                bullet2.isMeasured = false;

                series2.events.on("validated", function () {
                    bullet2.moveTo(series2.dataItems.last.point);
                    bullet2.validatePosition();
                });
            });
        }

        function LoadChart(chartid, dataChart, dateChart, value1, value2, chartName, unit1, unit2) {
            am4core.ready(function () {
                am4core.useTheme(am4themes_animated);
                var chart = am4core.create(chartid, am4charts.XYChart);
                chart.colors.step = 2;
                chart.maskBullets = false;
                // Add data
                chart.data = dataChart;

                // Create categoryAxis
                var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
                categoryAxis.dataFields.category = "date";
                categoryAxis.renderer.grid.template.location = 0;
                categoryAxis.renderer.minGridDistance = 30;
                categoryAxis.renderer.labels.template.rotation = 90;

                var distanceAxis = chart.yAxes.push(new am4charts.ValueAxis());
                distanceAxis.title.text = "Temperature"; //nhiet do
                distanceAxis.renderer.grid.template.disabled = true;
                distanceAxis.min = 10;
                distanceAxis.max = 80;
                distanceAxis.strictMinMax  = true;

                var durationAxis = chart.yAxes.push(new am4charts.ValueAxis());
                durationAxis.title.text = "RH"; // do am
                durationAxis.renderer.grid.template.disabled = true;
                durationAxis.renderer.opposite = true;
                durationAxis.min = 0;
                durationAxis.max = 100;
                durationAxis.strictMinMax  = true;

                // Create series
                var distanceSeries = chart.series.push(new am4charts.LineSeries());
                distanceSeries.dataFields.valueY = "RH";
                distanceSeries.dataFields.categoryX = "date";
                distanceSeries.yAxis = distanceAxis;
                distanceSeries.name = "RH" + "(%)";
                distanceSeries.strokeWidth = 2;
                distanceSeries.propertyFields.strokeDasharray = "dashLength";
                distanceSeries.tooltipText = "RH" + ": {valueY}" + "%";

                var durationSeries = chart.series.push(new am4charts.LineSeries());
                durationSeries.dataFields.valueY = "Temperature";
                durationSeries.dataFields.categoryX = "date";
                durationSeries.yAxis = durationAxis;
                durationSeries.name = "Temperature" + "(°C)";
                durationSeries.strokeWidth = 2;
                durationSeries.propertyFields.strokeDasharray = "dashLength";
                durationSeries.tooltipText = "Temperature" + ": {valueY}" + "°C";

                var lowSeries = chart.series.push(new am4charts.LineSeries());
                lowSeries.dataFields.valueY = "low";
                lowSeries.dataFields.categoryX = "date";
                lowSeries.yAxis = distanceAxis;
                lowSeries.name = "Low(°C)";
                lowSeries.strokeWidth = 1;
                lowSeries.propertyFields.strokeDasharray = "dashLength";
                //durationSeries.tooltipText = "Temperature" + ": {valueY}" + "°C";

                var highSeries = chart.series.push(new am4charts.LineSeries());
                highSeries.dataFields.valueY = "high";
                highSeries.dataFields.categoryX = "date";
                highSeries.yAxis = distanceAxis;
                highSeries.name = "High(°C)";
                highSeries.strokeWidth = 1;
                highSeries.propertyFields.strokeDasharray = "dashLength";
                //durationSeries.tooltipText = "Temperature" + ": {valueY}" + "°C";

                // Add legend
                chart.legend = new am4charts.Legend();

                // Add cursor
                chart.cursor = new am4charts.XYCursor();
                chart.cursor.fullWidthLineX = true;
                chart.cursor.xAxis = categoryAxis;
                chart.cursor.lineX.strokeOpacity = 0;
                chart.cursor.lineX.fill = am4core.color("#000");
                chart.cursor.lineX.fillOpacity = 0.1;
                callback();
            }); // end am4core.ready()
        }

        function ViewTableReport(div, data) {
            var table = $(div);
            table.dataTable({
                "createdRow": function (row, data, dataIndex) {
                    if (data[3] <= 20 || data[3] >= 60) {
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
                        messageTop: 'SAO KÊ CHI TIẾT TỪ ' + _dateReportStart + ' ĐẾN ' + _dateReportEnd
                    }
                ],
                "data": data,
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
                    [1, "asc"]
                ]
            });

            jQuery(div + '_wrapper .dataTables_filter input').addClass("form-control input-small");
            jQuery(div + '_wrapper .dataTables_length select').addClass("form-control input-small");
            callback();
        }

        function ViewTableAlarms(div, data) {
            var table = $(div);
             if (oTableAlarm != null) {
                _currentPage = oTableAlarm.fnPagingInfo().iPage;
                oTableAlarm.fnDestroy();
            }           
            oTableAlarm = table.dataTable({
                "lengthMenu": [
                    [10, 50, 100, 500, -1],
                    [10, 50, 100, 500, "All"]
                ],
                dom: 'Bfrtip',
                buttons: [
                    'copy',
                    {
                        extend: 'excel',
                        messageTop: 'SAO KÊ CHI TIẾT TỪ ' + _dateReportStart + ' ĐẾN ' + _dateReportEnd
                    }
                ],
                "data": data,
                "displayStart":_currentPage * _pageSize,
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
                    [1, "asc"]
                ]
            });

            jQuery(div + '_wrapper .dataTables_filter input').addClass("form-control input-small");
            jQuery(div + '_wrapper .dataTables_length select').addClass("form-control input-small");
        }

        function randomIntFromInterval(min, max) // min and max included
        {
            return Math.floor(Math.random() * (max - min + 1) + min);
        }
    </script>
</asp:Content>
