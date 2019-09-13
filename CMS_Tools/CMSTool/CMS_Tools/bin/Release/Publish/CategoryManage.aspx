<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoryManage.aspx.cs" Inherits="CMS_Tools.CategoryManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/global/plugins/Markdown/wysiwyg-color.css" rel="stylesheet" />
    <link href="assets/global/css/summernote.css" rel="stylesheet" />
    <link href="assets/global/plugins/Markdown/bootstrap-markdown.min.css" rel="stylesheet" />
    <link href="assets/global/plugins/UploadFiles/style1.css" rel="stylesheet" />
    <style type="text/css">
        .control-label{
            font-size:14px;    
        }
        .form-control{
            padding: 10px 5px;
            height: 40px;
        }
        .form-group
        {
            float: left;
            clear: both;
            width: 100%;    
        }
        .actions{margin-top:10px !important}
        .btn-group>.btn-group:first-child:not(:last-child)>.btn:last-child, .btn-group>.btn-group:first-child:not(:last-child)>.dropdown-toggle, .btn-group>.btn:first-child:not(:last-child):not(.dropdown-toggle) {
            border-bottom-right-radius: 0;
            border-top-right-radius: 0;
        }
        .btn-group-sm>.btn, .btn-sm {
            padding: 5px 10px;
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
            height: 30px;
            margin-left: 2px !important;
        }
        .btn-group, .btn-group-vertical {
            position: relative;
            display: inline-block;
            vertical-align: middle;
        }
        input::placeholder {
          font-size:14px !important; 
        }
        .input-group-lg>.form-control, .input-group-lg>.input-group-addon, .input-group-lg>.input-group-btn>.btn, .input-lg{
            font-size: 14px !important;
        }
        .input-icon.right > .form-control{
            padding-left: 5px !important;
        }
    </style>
    
    <script src="assets/global/plugins/datatables/jquery.dataTables.js"></script>
    <script src="assets/global/plugins/datatables/DT_bootstrap.js"></script>   
    <script src="assets/global/plugins/Markdown/markdown.js"></script>
    <script src="assets/global/plugins/Markdown/bootstrap-markdown.js"></script>

    <script src="assets/global/plugins/UploadFiles/jquery.tmpl.min.js"></script>
    <!--[if lt IE 9]>
    <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <script src="assets/global/plugins/UploadFiles/modernizr.custom.js"></script>
    <script src="assets/global/plugins/UploadFiles/upload.js"></script>
    <script src="assets/global/plugins/bootstrap-maxlength.min.js"></script>
    <script src="assets/global/plugins/jquery.tablednd.js"></script>

    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>

    <%--<script src="js/jquery.validate.min.js" type="text/javascript"></script>--%>
    <script src="assets/global/plugins/summernote.min.js"></script>
    <script src="assets/pages/scripts/CategoryManage.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            TableCategories.init();
            FormValidation.init();
            loadParent_category();
            loadTags("#txtActionTags", "actiontags", "");
            loadTags("#txtCategoriesTags", "catagorytags", "");
            $('#btnSubmit').click(function () {
                var r = validator.form();
                if (r) {
                    var e = $("#formCategory");
                    r = $(".alert-danger", e);
                    //i = $(".alert-success", e);
                    r.hide();
                    //i.show()
                    UpdateCategory();
                }
            });

            $('#btnAddNew').click(function () {
                $('#modal_category').modal('show');
                resetForm();
            });
        });
    </script>
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
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="page-title">Quản lý danh mục
        <small>Categories</small>
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
                <span><a href="CategoryManage.aspx">Category Manage</a></span>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <span id="lblNode"></span>
            </li>
        </ul>
        <div class="page-toolbar">
            <div class="btn-group pull-right">
                <button type="button" class="btn btn-fit-height blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                    Chức năng <i class="fa fa-angle-down"></i>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li>
                        <a id="btnAddNew" href="javascript:;" class="btnAddAccount"><i class="fa fa-plus"></i> Tạo danh mục mới</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <input type="hidden" id="_parentID" runat="server" value="0"/>
    <input id="ruleAdd" type="hidden" runat="server" value="0"/>
    <input id="ruleEdit" type="hidden" runat="server" value="0"/>
    <input id="ruleDelete" type="hidden" runat="server" value="0"/>
    <input id="rulePage" type="hidden" runat="server"/>
    <div class="portlet box grey">
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
            <div id="sample_1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                <table class="table table-striped table-bordered table-hover dataTable" id="tbl_category"
                    aria-describedby="sample_1_info">
                    <thead>
                        <tr role="row">
                            <th>ID</th>
                            <th>Hình Ảnh</th>   
                            <th>Tên Danh Mục</th>    
                            <th>Danh Mục Cha</th>                                     
                            <th>Mô Tả</th>
                            <th>Mô Tả Từ Khóa</th>
                            <th>Từ Khóa</th>
                            <th>Loại form</th>                                                                                
                            <th>Người Tạo</th>                            
                            <th>Ngày Tạo</th>
                            <th>Trạng Thái</th>
                            <th>Hiển Thị Menu</th>
                            <th>Vị Trí Hiển Thị</th>
                            <th>Đường Dẫn</th>
                            <th>Icon</th>
                            <th>CSS</th>
                            <th>HTML</th>
                            <th>Action Tags</th> 
                            <th>Category Tags</th> 
                            <th>Thể Loại</th>      
                            <th>Action</th>                     
                        </tr>
                    </thead>
                    <tbody role="alert" aria-live="polite" aria-relevant="all">
                    </tbody>
                </table>
            </div>
        </div>
    </div>


     <!-------------------------------Dialog----------------------------->
    <div class="modal fade" id="modal_category" data-backdrop="static">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <form id="formCategory" method="post">      
                    <div id="form_sample_1" novalidate="novalidate">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        </button>
                        <h4 class="modal-title" id="title_task">Update Category</h4>
                    </div>
                    <div class="modal-body">
                        <input type="hidden" id="categoryID" value="0" />
                        <div class="alert alert-danger display-hide">
                            <button class="close" data-close="alert"></button>
                            Vui lòng kiểm tra và nhập đầy đủ thông tin!
                        </div>
                        <div class="alert alert-success display-hide">
                            <button class="close" data-close="alert"></button>
                            Nhập thông tin hợp lệ
                        </div>

                        <div class="form-body">
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Tên danh mục</label>
                                    <div class="col-md-8">
                                        <div class="input-icon right">
                                            <i class="fa tooltips"></i>
                                            <input id="txtCategoryName" name="categoryName" type="text" class="form-control input-lg" placeholder="Category Name" maxlength="150"/>
                                        </div>
                                        
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Hiển thị</label>
                                    <div class="col-md-8">
                                        <input id="txtIndex" type="text" class="form-control input-lg" placeholder="Display index" maxlength="9" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Meta Description</label>
                                    <div class="col-md-8">
                                        <textarea id="txtMetaDescription" name="metaDescription" class="form-control" rows="3" cols="5" placeholder="Meta Description"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Meta Keyword</label>
                                    <div class="col-md-8">
                                        <textarea id="txtMetaKeyword" name="metaKeyword" class="form-control" rows="3" cols="5" placeholder="Meta Keyword"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Description</label>
                                    <div class="col-md-8">
                                        <textarea id="txtDescription" name="description" class="form-control" rows="5" cols="5" placeholder="Description" data-provide="markdown"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Link</label>
                                    <div class="col-md-8">
                                        <input type="text" id="txtLink" name="link" class="form-control" placeholder="link" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Action Tags</label>
                                    <div class="col-md-8">
                                        <select style="width:100%;" id="txtActionTags" class="form-control" multiple="multiple"></select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Categories Tags</label>
                                    <div class="col-md-8">
                                        <select style="width:100%;" id="txtCategoriesTags" class="form-control" multiple="multiple"></select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Icon</label>
                                    <div class="col-md-8">
                                        <input type="text" id="txtIcon" name="link" class="form-control" placeholder="Icon" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        CSS</label>
                                    <div class="col-md-8">
                                        <textarea id="txtCSS" name="css" class="form-control" rows="3" cols="5" placeholder="CSS"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        HTML</label>
                                    <div class="col-md-8">
                                        <textarea id="txtHTML" name="html" class="form-control" placeholder="HTML" name="content" data-provide="markdown" rows="10"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Parent Name</label>
                                    <div class="col-md-8">
                                        <select class="form-control" style="width: 349px" id="selectParentID" name="parentName">
                                            <option value="0">Parent</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        FormType Name</label>
                                    <div class="col-md-8">
                                        <select class="form-control" id="selectFormTypeID" name="formTypeName">
                                            <option value="1">Bài Viết</option>
                                            <option value="2">Sản Phẩm</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Status</label>
                                    <div class="col-md-8">
                                        <select class="form-control" id="selectStatus" name="status">
                                            <option value="1">Publish</option>
                                            <option value="0">UnPublish</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">Is Menu</label>
                                    <div class="col-md-8">
                                        <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                            <input type="checkbox" class="checkboxes" name="isMenu" id="ckbIsMenu"><span></span></label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="control-label col-md-3">
                                        <label>Add URLs</label>
                                        <input style="margin-right: 10px;" class="radioImage" type="radio" name="urlImage" value="male" onclick="$('#divAddImage').removeClass('hidden'); $('#divUpload').addClass('hidden');" />
                                        <label>
                                            Upload Files</label>
                                        <input class="radioImage" type="radio" name="urlImage" value="male" onclick="$('#divAddImage').addClass('hidden'); $('#divUpload').removeClass('hidden');" checked="checked" />
                                    </div>
                                    <div class="col-md-9">
                                        <label>Upload Hình Ảnh Bài Viết</label>
                                        <div id="divAddImage" style="min-height: 165px;" class="hidden">
                                            <input type="text" id="txtLinkImage" style="float: left; width: 300px; padding: 3px; margin-right: 10px" />
                                            <a href="javascript:;" id="btnAddimage" onclick="AddImage('#txtLinkImage','#tblImages');" class="btn btn-sm green">Add Image <i class="fa fa-plus"></i></a>
                                        </div>
                                        <div style="width: 100%">
                                            <div id="divUpload">
                                                <section id="wrapper">
                                                    <div id="droparea" class="droparea">
                                                        <div class="loading">
                                                            <div>
                                                                <img src="assets/layouts/layout2/img/ajax-loading.gif" />
                                                            </div>
                                                        </div>
                                                        <div class="dropareainner">
                                                            <p class="dropfiletext">Drop files here</p>
                                                            <p>or</p>
                                                            <p>
                                                                <input id="uploadbtn" class="uploadbtn" type="button" value="Select Files" />
                                                            </p>
                                                            <p class="err"></p>
                                                        </div>
                                                        <input id="upload" type="file" multiple />
                                                    </div>
                                                </section>
                                                <div class="clearfix"></div>
                                            </div>
                                            <table role="presentation" class="table table-striped" id="tblImages">
                                                <tbody class="files">
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn default" data-dismiss="modal">
                            Close</button>
                        <button id="btnSubmit" type="submit" class="btn blue" id="">
                            Save changes</button>
                    </div>
                </div>
                </form>
            </div>
        </div>
        <!--/.modal-dialog-->
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
</asp:Content>
