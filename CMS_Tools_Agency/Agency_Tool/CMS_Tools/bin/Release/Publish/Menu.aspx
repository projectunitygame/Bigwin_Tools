<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CMS_Tools.Menu" validateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="assets/global/plugins/codemirror/lib/codemirror.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/codemirror/theme/neat.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/codemirror/theme/ambiance.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/codemirror/theme/material.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/codemirror/theme/neo.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="page-title">Quản lý trang
        <small>thêm mới, cập nhật, sao chép, lịch sử cập nhật</small>
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
                <span>Menu</span>
            </li>
        </ul>
        <div class="page-toolbar">
            <div class="btn-group pull-right">
                <button type="button" class="btn btn-fit-height grey-salt dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                    Chức năng <i class="fa fa-angle-down"></i>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li>
                        <a href="#" class="btnAddMenu"><i class="fa fa-plus"></i> Thêm mới</a>
                    </li>
                    <li>
                        <a href="#" class="btnViewHistoryMenu"><i class="fa fa-history"></i> Lịch sử chỉnh sửa</a>
                    </li>
                    <li>
                        <a href="#" class="btnCopyMenu"><i class="fa fa-clone"></i> Sao chép menu</a>
                    </li>
                    <li class="divider"></li>
                    <li>
                        <a href="#" class="btnRemoveMenu"><i class="fa fa-trash-o"></i> Xóa menu</a>
                    </li>
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
                        Menu
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                        <%--<a href="#portlet-config" data-toggle="modal" class="config" data-original-title="" title=""></a>--%>
                        <a href="javascript:;" class="reload" data-original-title="" title=""></a>
                        <%--<a href="javascript:;" class="remove" data-original-title="" title=""></a>--%>
                    </div>
                </div>
                <div class="portlet-body form">
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
                    <!-- BEGIN FORM-->
                    <form method="post" action="javascript:;" class="form-horizontal form-bordered form-label-stripped menu-form">
                        <input type="hidden" value="0" id="input_menuID"/>
                        <input type="hidden" value="" id="input_action" runat="server"/>
                        <input type="hidden" value="0" id="input_parent" runat="server"/>
                        <div class="form-body">
                            <div class="form-group">
                                <label class="control-label col-md-3">Trạng Thái</label>
                                <div class="col-md-9">
                                    <select class="form-control" id="input_status">
                                        <option value="1">Kích hoạt</option>
                                        <option value="0">Chưa kích hoạt</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Thứ Tự Hiển Thị</label>
                                <div class="col-md-9">
                                    <select class="form-control" id="input_displayIndex">
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Menu Name</label>
                                <div class="col-md-9">
                                    <input id="input_menuName" maxlength="150" name="MenuName" type="text" class="form-control">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Mô Tả</label>
                                <div class="col-md-9">
                                    <input id="input_menuDescription" maxlength="500" name="MenuDescription" type="text" class="form-control">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Icon</label>
                                <div class="col-md-9">
                                    <input id="input_icon" maxlength="50" name="MenuIcon" type="text" class="form-control">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Menu Click</label>
                                <div class="col-md-9">
                                    <input id="input_menuClick" maxlength="1000" name="MenuClick" type="text" class="form-control">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">JS</label>
                                <div class="col-md-9">
                                    <textarea id="code_editor_js" class="form-control" rows="20"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">CSS</label>
                                <div class="col-md-9">
                                    <textarea id="code_editor_css" class="form-control"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">HTML</label>
                                <div class="col-md-9">
                                    <textarea id="code_editor_html" class="form-control"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Database Name</label>
                                <div class="col-md-9">
                                    <select id="input_database" class="form-control select2_category">
                                    </select>
                                </div>
                            </div>                      
                            <div class="form-group">
                                <label class="control-label col-md-3">SqlCommand</label>
                                <div class="col-md-9">
                                    <div class="md-radio-list">
                                        <div class="md-radio">
                                            <input type="radio" id="checkbox1_0" checked name="radio1" value="0" class="md-radiobtn">
                                            <label for="checkbox1_0">
                                                <span></span>
                                                <span class="check"></span>
                                                <span class="box"></span>None
                                            </label>
                                        </div>
                                        <div class="md-radio">
                                            <input type="radio" id="checkbox1_1" name="radio1" value="1" class="md-radiobtn">
                                            <label for="checkbox1_1">
                                                <span></span>
                                                <span class="check"></span>
                                                <span class="box"></span>SQL Query
                                            </label>
                                        </div>
                                        <div class="md-radio">
                                            <input type="radio" id="checkbox1_2" name="radio1" value="2" class="md-radiobtn">
                                            <label for="checkbox1_2">
                                                <span></span>
                                                <span class="check"></span>
                                                <span class="box"></span>Store Procedure
                                            </label>
                                        </div>
                                    </div>              
                                </div>
                            </div>
                            <div class="form-group sql_group" style="display:none">
                                <label class="control-label col-md-3">SQL Query</label>
                                <div class="col-md-9">
                                    <textarea name="input_sql_query" rows="3" id="input_sql_query" class="form-control"></textarea>
                                </div>
                            </div>
                            <div class="form-group sql_group" style="display:none">
                                <label class="control-label col-md-3">Data Type</label>
                                <div class="col-md-9">
                                    <textarea name="input_sql_dataType" rows="3" id="input_sql_dataType" class="form-control"></textarea>
                                </div>
                            </div>
                            <%--<div class="form-group last sql_group" style="display:none">
                                <label class="control-label col-md-3">Is Rule</label>
                                <div class="col-md-9">
                                    <div class="md-checkbox">
                                        <input type="checkbox" id="input_isRule" class="md-check" value="1"/>
                                        <label for="input_isRule">
                                            <span></span>
                                            <span class="check"></span>
                                            <span class="box"></span>
                                        </label>
                                    </div>                            
                                </div>
                            </div>--%>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <button type="submit" class="btn green">
                                        <i class="fa fa-check"></i>Submit</button>
                                    <button type="button" class="btn default" onclick="Menu.cancel();">Cancel</button>
                                </div>
                            </div>
                        </div>
                    </form>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END PORTLET-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="assets/global/plugins/codemirror/lib/codemirror.js" type="text/javascript"></script>
    <script src="assets/global/plugins/codemirror/mode/javascript/javascript.js" type="text/javascript"></script>
    <script src="assets/global/plugins/codemirror/mode/htmlmixed/htmlmixed.js" type="text/javascript"></script>
    <script src="assets/global/plugins/codemirror/mode/css/css.js" type="text/javascript"></script>
    
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <script src="assets/pages/scripts/components-code-editors.min.js" type="text/javascript"></script>
    <script src="assets/pages/scripts/menu.js"></script>
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