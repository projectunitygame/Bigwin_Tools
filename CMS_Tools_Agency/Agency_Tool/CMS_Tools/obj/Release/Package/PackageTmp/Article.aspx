<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="CMS_Tools.Article" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <link href="assets/global/plugins/UploadFiles/style1.css" rel="stylesheet" />
    <link href="assets/global/plugins/Markdown/wysiwyg-color.css" rel="stylesheet" />
    <link href="assets/global/plugins/Markdown/bootstrap-markdown.min.css" rel="stylesheet" />
    <style>
        .lstVideos
        {
            margin: 10px;
            color: #ffffff;
            padding: 0px 0px 0px 10px;
            text-align: center;
            line-height: 30px;
            display: inline-block;    
        }
        .removeVideo
        {
            height: 100%;
            padding: 7.5px 7px;
            line-height: 30px;
            background-color: #F3565D;
            cursor:pointer;    
            float:right;
        }
        .updateVideo
        {
            height: 100%;
            padding: 7.5px 7px;
            line-height: 30px;
            background-color: #49AAF9;
            cursor:pointer;  
            float:right;  
        }
        .removeVideo:hover
        {
            background-color: #89C4F4;
        }
        .updateVideo:hover
        {
            background-color: #89C4F4;
        }
        .title_video{margin-right:5px;line-height: 45px;}
        #innerVideos{margin-top:10px; float: left; margin-left: 10px; margin-right: 10px;}
    </style>            
    <script src="assets/global/plugins/Datetime/moment.min.js"></script>     
    <script src="assets/global/plugins/Datetime/moment-with-locales.min.js"></script>
    <script src="assets/global/plugins/Datetime/bootstrap-datetimepicker.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="page-title">Quản lý bài viết</h1>
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
                <span>Quản lý bài viết</span>
            </li>
        </ul>       
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <!-- BEGIN FORM-->
    <form runat="server" method="post" action="javascript:UpdateArticle();">      
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <div class="row">
            <div class="col-md-12">
                <div class="portlet box">
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
                    </div>
                    <input type="hidden" value="0" id="input_articleId" />
                    <div class="tabbable tabbable-custom boxless">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab_6_1" data-toggle="tab">Bài Viết</a> </li>
                            <li><a href="#tab_6_5" data-toggle="tab">Thông tin sản phẩm</a> </li>
                            <li><a href="#tab_6_2" data-toggle="tab">Hình Ảnh</a></li>
                            <li><a href="#tab_6_3" data-toggle="tab">Videos</a></li>
                            <li><a href="#tab_6_4" data-toggle="tab">Từ Khóa</a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_6_1">
                                <div class="form-horizontal form-bordered">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Trạng Thái</label>
                                            <div class="col-md-9">
                                                <select id="select_Status" class="form-control">
                                                    <option value="1">Hiển thị</option>
                                                    <option value="0">Ẩn</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Ngày Đăng</label>
                                            <div class="col-md-9">
                                                <div class='input-group date' id='txtPubdate'>
                                                    <input type='text' class="form-control" required/>
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Tiêu Đề</label>
                                            <div class="col-md-9">
                                                <input type="text" class="form-control title" maxlength="150" name="txtTitle" id="txtTitle" required/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Link</label>
                                            <div class="col-md-9">
                                                <input type="text" class="form-control title" maxlength="255" name="" id="txtLink"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Tác Giả</label>
                                            <div class="col-md-9">
                                                <input type="text" class="form-control title" maxlength="150" name="txtTitle" id="txtAuthor" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Nguồn</label>
                                            <div class="col-md-9">
                                                <input type="text" class="form-control title" maxlength="150" name="txtTitle" id="txtQuote" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Mô Tả Ngắn</label>
                                            <div class="col-md-9">
                                                <textarea class="form-control description" maxlength="1000" rows="5" name="txtDescription"
                                                    id="txtDescription" placeholder="This description has a limit of 1000 chars." data-provide="markdown"></textarea>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Nội Dung</label>
                                            <div class="col-md-9">
                                                <telerik:RadEditor ID="RadEditor1" runat="server" DialogHandlerUrl="Telerik.Web.UI.DialogHandler.axd"
                                                    Width="100%" Height="497px">
                                                    <Tools>
                                                        <telerik:EditorToolGroup>
                                                            <telerik:EditorTool Name="Print" />
                                                            <telerik:EditorTool Name="AjaxSpellCheck" />
                                                            <telerik:EditorTool Name="FindAndReplace" />
                                                            <telerik:EditorTool Name="SelectAll" />
                                                            <telerik:EditorTool Name="Cut" />
                                                            <telerik:EditorTool Name="Copy" />
                                                            <telerik:EditorTool Name="Paste" />
                                                            <telerik:EditorTool Name="PasteStrip" />
                                                        </telerik:EditorToolGroup>
                                                        <telerik:EditorToolGroup>
                                                            <telerik:EditorTool Name="Undo" />
                                                            <telerik:EditorTool Name="Redo" />
                                                        </telerik:EditorToolGroup>
                                                        <telerik:EditorToolGroup>
                                                            <telerik:EditorTool Name="InsertImage" />
                                                            <telerik:EditorTool Name="ImageManager" />
                                                            <telerik:EditorTool Name="FlashManager" />
                                                            <telerik:EditorTool Name="MediaManager" />
                                                            <telerik:EditorTool Name="DocumentManager" />
                                                            <telerik:EditorTool Name="TemplateManager" />
                                                            <telerik:EditorTool Name="LinkManager" />
                                                            <telerik:EditorTool Name="Unlink" />
                                                        </telerik:EditorToolGroup>
                                                        <telerik:EditorToolGroup>
                                                            <telerik:EditorTool Name="Superscript" />
                                                            <telerik:EditorTool Name="Subscript" />
                                                            <telerik:EditorTool Name="InsertParagraph" />
                                                            <telerik:EditorTool Name="InsertGroupbox" />
                                                            <telerik:EditorTool Name="InsertHorizontalRule" />
                                                            <telerik:EditorTool Name="InsertDate" />
                                                            <telerik:EditorTool Name="InsertTime" />
                                                            <telerik:EditorTool Name="FormatCodeBlock" />
                                                        </telerik:EditorToolGroup>
                                                        <telerik:EditorToolGroup>
                                                            <telerik:EditorTool Name="FormatBlock" />
                                                            <telerik:EditorTool Name="FontName" />
                                                            <telerik:EditorTool Name="RealFontSize" />
                                                        </telerik:EditorToolGroup>
                                                        <telerik:EditorToolGroup>
                                                            <telerik:EditorTool Name="AbsolutePosition" />
                                                            <telerik:EditorTool Name="Bold" />
                                                            <telerik:EditorTool Name="Italic" />
                                                            <telerik:EditorTool Name="Underline" />
                                                            <telerik:EditorTool Name="StrikeThrough" />
                                                        </telerik:EditorToolGroup>
                                                        <telerik:EditorToolGroup>
                                                            <telerik:EditorTool Name="JustifyLeft" />
                                                            <telerik:EditorTool Name="JustifyCenter" />
                                                            <telerik:EditorTool Name="JustifyRight" />
                                                            <telerik:EditorTool Name="JustifyFull" />
                                                            <telerik:EditorTool Name="JustifyNone" />
                                                            <telerik:EditorSeparator />
                                                            <telerik:EditorTool Name="Indent" />
                                                            <telerik:EditorTool Name="Outdent" />
                                                            <telerik:EditorSeparator />
                                                            <telerik:EditorTool Name="InsertOrderedList" />
                                                            <telerik:EditorTool Name="InsertUnorderedList" />
                                                            <telerik:EditorSeparator />
                                                            <telerik:EditorTool Name="ToggleTableBorder" />
                                                            <telerik:EditorTool Name="XhtmlValidator" />
                                                        </telerik:EditorToolGroup>
                                                        <telerik:EditorToolGroup>
                                                            <telerik:EditorTool Name="ForeColor" />
                                                            <telerik:EditorTool Name="BackColor" />
                                                            <telerik:EditorTool Name="ApplyClass" />
                                                            <telerik:EditorTool Name="FormatStripper" />
                                                        </telerik:EditorToolGroup>
                                                        <telerik:EditorToolGroup>
                                                            <telerik:EditorTool Name="InsertSymbol" />
                                                            <telerik:EditorTool Name="InsertTable" />
                                                            <telerik:EditorTool Name="InsertFormElement" />
                                                            <telerik:EditorTool Name="InsertSnippet" />
                                                            <telerik:EditorTool Name="ImageMapDialog" />
                                                            <telerik:EditorTool Name="InsertCustomLink" />
                                                            <telerik:EditorSeparator />
                                                            <telerik:EditorTool Name="ConvertToLower" />
                                                            <telerik:EditorTool Name="ConvertToUpper" />
                                                            <telerik:EditorSeparator />
                                                            <telerik:EditorTool Name="Zoom" />
                                                            <telerik:EditorTool Name="ModuleManager" />
                                                            <telerik:EditorTool Name="ToggleScreenMode" />
                                                            <telerik:EditorTool Name="AboutDialog" />
                                                        </telerik:EditorToolGroup>
                                                    </Tools>
                                                </telerik:RadEditor>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Danh mục khác</label>
                                            <div class="col-md-9">
                                                <select id="txtCategoriesTags" class="form-control" multiple="multiple"></select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Tags</label>
                                            <div class="col-md-9">
                                                <select id="txtTags" class="form-control" multiple="multiple"></select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_6_5">
                                <div class="form-horizontal form-bordered">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Mã Sản Phẩm</label>
                                            <div class="col-md-9">
                                                <select id="txtProductID" class="form-control" style="width:100%;"></select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Giá Bán</label>
                                            <div class="col-md-9">
                                                <input type="number" class="form-control" name="" id="txtPrice" readonly/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Giá gốc</label>
                                            <div class="col-md-9">
                                                <input type="number" class="form-control" name="" id="txtPriceOld" readonly/>
                                            </div>
                                        </div>
                                        <div class="form-group" style="display: none;">
                                            <label class="control-label col-md-3">
                                                Price</label>
                                            <div class="col-md-9">
                                                <input type="text" class="form-control title" maxlength="10" name="" id="txtTitleDes1" />
                                            </div>
                                        </div>
                                        <div class="form-group" style="display: none;">
                                            <label class="control-label col-md-3">
                                                Discount(%)</label>
                                            <div class="col-md-9">
                                                <input type="number" class="form-control" name="" id="txtDiscount" value="0" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Thông số kỹ thuật</label>
                                            <div class="col-md-9">
                                                <textarea class="form-control" rows="5" name=""
                                                    id="txtProduct_Specifications" data-provide="markdown"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions fluid"></div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_6_2">
                                <div class="form-horizontal form-bordered">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="control-label col-md-3">
                                                <label>Add url</label>
                                                <input class="radioImage" type="radio" name="urlImage" value="male" onclick="$('#divAddImage').removeClass('hidden'); $('#divUpload').addClass('hidden');"/>
                                                <label>
                                                    Upload Files</label>
                                                <input class="radioImage" type="radio" name="urlImage" value="male" onclick="$('#divAddImage').addClass('hidden'); $('#divUpload').removeClass('hidden');" checked="checked"/>
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
                                    <div class="form-actions fluid"></div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_6_3">
                                <div class="form-horizontal form-bordered">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Type</label>
                                            <div class="col-md-9">
                                                <select id="select_videoType" class="form-control">
                                                    <option value="Embed">Embeb code</option>
                                                    <option value="Link">Link file</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Title</label>
                                            <div class="col-md-9">
                                                <input type="text" class="form-control title" maxlength="250" id="txtVideo_title" />
                                            </div>
                                        </div>
                                        <div class="form-group field1">
                                            <label class="control-label col-md-3">
                                                Embed</label>
                                            <div class="col-md-9">
                                                <textarea class="form-control description" maxlength="4000" rows="5" name="txtEmbed"
                                                    id="txtEmbed"></textarea>
                                            </div>
                                        </div>
                                        <div class="form-group field2" style="display: none">
                                            <label class="control-label col-md-3">
                                                360 SD</label>
                                            <div class="col-md-9">
                                                <input class="form-control description" maxlength="500" name="txtFile"
                                                    id="txtFile" placeholder="360 SD" />
                                            </div>
                                            <label class="control-label col-md-3">
                                                720 HD</label>
                                            <div class="col-md-9">
                                                <input class="form-control description" maxlength="500" name="txtFile2"
                                                    id="txtFile2" placeholder="720 HD" />
                                            </div>
                                            <label class="control-label col-md-3">
                                                1080 Full HD</label>
                                            <div class="col-md-9">
                                                <input class="form-control description" maxlength="500" name="txtFile3"
                                                    id="txtFile3" placeholder="Full HD" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions fluid">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <br />
                                                <div class="col-md-offset-3 col-md-9">
                                                    <button id="btnAddVideo" type="button" class="btn green">Add</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="innerVideos"></div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_6_4">
                                <div class="form-horizontal form-bordered">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Mô Tả Từ Khóa</label>
                                            <div class="col-md-9">
                                                <textarea id="txtMetadescription" class="form-control metadescription" maxlength="225"
                                                    rows="3" placeholder="This meta description has a limit of 225 chars."></textarea>
                                                <span class="help-block">Mô tả từ khóa khi tìm kiếm trên Google</span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">
                                                Từ Khóa SEO</label>
                                            <div class="col-md-9">
                                                <textarea id="txtMetakeyword" class="form-control metakeyword" maxlength="225" rows="3"
                                                    placeholder="This meta keyword has a limit of 225 chars."></textarea>
                                                <span class="help-block">Liệt kê những từ khóa cho bài viết</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions fluid"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <br />
                                    <div class="col-md-offset-3 col-md-9">
                                        <button id="Button1" type="submit" class="btn green" runat="server">
                                            <i class="fa fa-check"></i>Submit</button>
                                        <button id="btnCancel" type="button" class="btn default">
                                            Cancel</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- END FORM-->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script src="assets/global/plugins/UploadFiles/jquery.tmpl.min.js"></script>
    <!--[if lt IE 9]>
    <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <script src="assets/global/plugins/UploadFiles/modernizr.custom.js"></script>
    <script src="assets/global/plugins/UploadFiles/upload.js"></script>
    <script src="assets/global/plugins/Markdown/markdown.js"></script>
    <script src="assets/global/plugins/Markdown/bootstrap-markdown.js"></script>
    <script src="assets/global/plugins/bootstrap-maxlength.min.js"></script>
    <script src="assets/global/plugins/jquery.tablednd.js"></script>
    <script>
        var arrayVideos = [];
        var flag_update = false;
        var currentIndex = -1;
        $(function () {            
            $('.title').maxlength({
                limitReachedClass: "label label-danger",
                threshold: 100
            });
            $('.description').maxlength({
                limitReachedClass: "label label-danger",
                threshold: 1000
            });
            $('.metadescription').maxlength({
                limitReachedClass: "label label-danger",
                alwaysShow: true
            });
            $('.metakeyword').maxlength({
                limitReachedClass: "label label-danger",
                alwaysShow: true
            });
                      
            $('#select_videoType').change(function () {
                if ($(this).val() == "Embed") {
                    $('.field1').fadeIn();
                    $('.field2').css("display", "none");
                    $('#txtFile').val("");
                    $('#txtFile2').val("");
                    $('#txtFile3').val("");
                }
                else {
                    $('.field2').fadeIn();
                    $('.field1').css("display", "none");
                    $('#txtEmbed').val("");
                }
            });

            $('#btnAddVideo').click(function () {
                if (!flag_update) {
                    if ($('#txtVideo_title').val() == "") {
                        bootbox.alert("This field title is required!");
                        $('#txtVideo_title').focus();
                    }
                    else {
                        var s = "<span class='lstVideos label-info'><span class='title_video'>" + $('#txtVideo_title').val() + "</span>" +
                            " <span onclick='removeVideo(this);' class='removeVideo'><i class='fa fa-trash-o'></i></span>" +
                            " <span onclick='updateVideo(this);' class='updateVideo'><i class='fa fa-edit'></i></span>" +
                            "</span>";
                        $('#innerVideos').append(s);
                        var listFiles = [];
                        listFiles.push({ "file": $('#txtFile').val(), "label": "360 SD" });
                        listFiles.push({ "file": $('#txtFile2').val(), "label": "720 HD" });
                        listFiles.push({ "file": $('#txtFile3').val(), "label": "1080 FHD" });
                        arrayVideos.push({
                            "Title": $('#txtVideo_title').val(),
                            "VideoType": $('#select_videoType').val(),
                            "Embed": $('#txtEmbed').val(),
                            "Files": listFiles
                        });
                        $('#txtVideo_title').val("");
                        $('#txtEmbed').val("");
                        $('#txtFile').val("");
                        $('#txtFile2').val("");
                        $('#txtFile3').val("");
                        console.log(arrayVideos);
                    }
                }
                else {
                    if (currentIndex > -1) {
                        var listFiles = [];
                        listFiles.push({ "file": $('#txtFile').val(), "label": "360 SD" });
                        listFiles.push({ "file": $('#txtFile2').val(), "label": "720 HD" });
                        listFiles.push({ "file": $('#txtFile3').val(), "label": "1080 FHD" });
                        arrayVideos[currentIndex] = {
                            "Title": $('#txtVideo_title').val(),
                            "VideoType": $('#select_videoType').val(),
                            "Embed": $('#txtEmbed').val(),
                            "Files": listFiles
                        }
                        $('.title_video').each(function (index) {
                            if (index == currentIndex) {
                                $(this).html($('#txtVideo_title').val());
                                return false;
                            }
                        });
                        currentIndex = -1;
                        flag_update = false;
                        $('#btnAddVideo').text("Add");
                    }
                }
            });

            $('#txtProductID').change(function () {
                var element = $("option:selected", this);
                var price = element.attr("price");
                var priceOld = element.attr("priceOld");
                $('#txtPrice').val(price);
                $('#txtPriceOld').val(priceOld);
            });

            $('#btnCancel').click(function () {
                window.location.assign("Page.aspx?m=19&catId=" + AppManage.getURLParameter("catId"));
            });

            if (AppManage.getURLParameter("articleId") != null) {
                LoadArticleDetail();
            }
            else {
                $('#txtPubdate').datetimepicker({
                    locale: 'vi',
                    format:'YYYY/MM/DD HH:mm:ss',
                });
                $('#txtTags').select2({
                    tags: true,
                    tokenSeparators: [',', ' ']
                });
                GetCategoryTags();
                GetProductID();
                GetArticleTags();
            }
        });

        function removeVideo(d) {
            var p = $(d).parent();
            var myIndex = p.parent().children().index(p);
            arrayVideos.splice(myIndex, 1);
            console.log(arrayVideos);
            $(d).parent().remove();
            currentIndex = -1;
            flag_update = false;
            $('#btnAddVideo').text("Add");
            $('#txtVideo_title').val("");
            $('#txtEmbed').val("");
            $('#txtFile').val("");
            $('#txtFile2').val("");
            $('#txtFile3').val("");
        }

        function updateVideo(d) {
            flag_update = true;
            var p = $(d).parent();
            var myIndex = p.parent().children().index(p);
            currentIndex = myIndex;
            $('#btnAddVideo').text("Update");
            if (arrayVideos[myIndex].VideoType == "Embed") {
                $('.field2').css("display", "none");
                $('.field1').fadeIn();
            }
            else {
                $('.field1').css("display", "none");
                $('.field2').fadeIn();
            }
            $('#txtEmbed').val(arrayVideos[myIndex].Embed);
            $('#txtVideo_title').val(arrayVideos[myIndex].Title);
            var f = arrayVideos[myIndex].Files;
            $('#txtFile').val(f[0].file);
            $('#txtFile2').val(f[1].file);
            $('#txtFile3').val(f[2].file);
            $('#select_videoType').val(arrayVideos[myIndex].VideoType);
        }

        var j = 1;
        function AddImage(el1, el2) {
            if ($.trim($(el1).val()) != "") {
                $(el2).append("<tr id='li-" + (++j) + "'>" +
                            "<td><img class='urlImg' data-fileSize=''" +
                            " data-fileName=''" +
                            " data-urlweb='" + $(el1).val() +
                            "' data-urltablet='" + $(el1).val() +
                            "' data-urlphone='" + $(el1).val() +
                            "' src='" + $(el1).val() + "' style='width:50px; max-height:65px;border: 1px solid gray;margin:5px 10px 5px 0px'/></td>" +
                            "<td></td>" +
                            "<td></td>" +
                            "<td class='colDel'><button type='button' class='btn red delete' onclick='$(\"#li-" + j + "\").remove();'>" +
								"<i class='fa fa-trash-o'></i> " +
								"<span>Delete</span>" +
								"</button>" +
                            "</tr>");
                $(el1).val("");
            }
            else
                alert("Vui lòng nhập vào url ảnh!");
        }

        var articleData = null;
        function LoadArticleDetail() {
            $(".divLoading").fadeIn(0);
            var param = [];
            param.push(AppManage.getURLParameter("articleId"));
            POST_DATA(URL_MENU, {type: 14, mid: 20, p: JSON.stringify(param)}, function (res) {
                if (res.status == 0) {
                    articleData = res.data[0];
                    $('#select_Status').val(articleData.Status);
                    $('#txtPubdate input').val(articleData.DatePublish);
                    $('#txtPubdate').datetimepicker({
                        locale: 'vi',
                        format:'YYYY/MM/DD HH:mm:ss',
                    });
                    $('#txtTitle').val(articleData.Title);         
                    $('#txtDescription').val(articleData.Description);
                    $('#txtMetadescription').val(articleData.MetaDescription);
                    $('#txtMetakeyword').val(articleData.MetaKeywords);
                    $('#txtAuthor').val(articleData.Author);
                    $('#txtQuote').val(articleData.Quote);
                    $('#txtLink').val(articleData.Link);
                    document.getElementById("PageContent_RadEditor1_contentIframe").contentWindow.document.body.innerHTML = articleData.Body;
                    var listImagesArticles = $.parseJSON(articleData.Images);
                    console.log(listImagesArticles);
                    if (listImagesArticles .length > 0) {
                        $.each(listImagesArticles, function (key, value) {
                            $('#tblImages tbody').append("<tr id='img0_" + key + "'>" +
                                    "<td><img data-fileSize='" + value.size + "' data-fileName='" + value.fileName + "' class='urlImg' " +
                                        "' data-urlweb='" + value.urlWeb +
                                        "' data-urltablet='" + value.urlTablet +
                                        "' data-urlphone='" + value.urlPhone +
                                        "' src='" + value.urlPhone + "' style='width:50px;max-height:65px;border: 1px solid gray;margin:5px 10px 5px 0px'/></td>" +
                                    "<td>" + value.fileName + "</td>" +
                                    "<td>" + value.size + "</td>" +
                                    "<td class='colDel'><button type='button' class='btn red delete' onclick='$(\"#img0_" + key + "\").remove();'>" +
								        "<i class='fa fa-trash-o'></i> " +
								        "<span>Delete</span>" +
								        "</button></td>" +
                                    "</tr>");
                        });
                        $("#tblImages").tableDnD();
                    }
                    //------------------------------load videos----------------------------------                    
                    var obj3 = $.parseJSON(articleData.Videos);
                    $.each(obj3, function (key, obj) {
                        arrayVideos.push({
                            "Id": obj.Id,
                            "Title": obj.Title,
                            "VideoType": obj.VideoType,
                            "Embed": obj.Embed,
                            "Files": obj.Files
                        });
                        var s = "<span class='lstVideos label-info'><span class='title_video'>" + obj.Title + "</span>" +
                                    " <span onclick='removeVideo(this);' class='removeVideo'><i class='fa fa-trash-o'></i></span>" +
                                    " <span onclick='updateVideo(this);' class='updateVideo'><i class='fa fa-edit'></i></span>" +
                                    "</span>";
                        $('#innerVideos').append(s);
                    });
                    GetCategoryTags();
                    GetProductID();
                    GetArticleTags();
                }
                $(".divLoading").fadeOut(0);
            });
        }

        function GetArticleTags() {
            var u = $.parseJSON($('#_userdata').val());
            var param = [];
            param.push(u.PublisherID);
            POST_DATA(URL_MENU, {type: 14, mid: 21, p: JSON.stringify(param)}, function (res) {
                if (res.status == 0) {
                    $.each(res.data, function (i, obj) {
                        var selected = "";
                        if (articleData != null && articleData.Tags != "") {
                            $.each(articleData.Tags.split(','), function (i, d) {
                                if (d == obj.TagName) {
                                    selected = "selected";
                                    return false;
                                }
                            });
                        }
                        $('#txtTags').append("<option " + selected + " value='"+obj.TagName+"'>"+obj.TagName+"</option>");
                    });                   
                }
                $('#txtTags').select2({
                    tags: true,
                    tokenSeparators: [',', ' ']
                });
            });
        }

        function GetCategoryTags() {
            var catId = AppManage.getURLParameter("catId") != null ? AppManage.getURLParameter("catId") : "";
            var u = $.parseJSON($('#_userdata').val());
            var param = [];
            param.push(u.PublisherID);
            POST_DATA(URL_MENU, {type: 14, mid: 14, p: JSON.stringify(param)}, function (res) {
                if (res.status == 0) {
                    $.each(res.data, function (i, obj) {
                        var selected = "";
                        if (articleData == null) {
                            if (obj.CategoryId == catId)
                                selected = "selected";
                        }
                        else {
                            if (articleData.CategoryTags != "") {
                                $.each(articleData.CategoryTags.split(','), function (i, d) {
                                    if (d == obj.CategoryId) {
                                        selected = "selected";
                                        return false;
                                    }
                                });
                            }
                        }
                        $('#txtCategoriesTags').append("<option " + selected + " value='"+obj.CategoryId+"'>"+obj.CategoryName+"</option>");
                    });
                    $('#txtCategoriesTags').select2();
                }
            });
        }

        function GetProductID() {
            var u = $.parseJSON($('#_userdata').val());
            var param = [];
            param.push(u.PublisherID);
            POST_DATA(URL_MENU, {type: 14, mid: 15, p: JSON.stringify(param)}, function (res) {
                if (res.status == 0) {
                    $('#txtProductID').html("<option value='' priceOld='' price=''>No-Product</option>");
                    $.each(res.data, function (i, obj) {     
                        var selected = ""
                        if (articleData != null) {
                            if (articleData.ProductId == obj.ProductCode) {
                                selected = "selected";
                                $('#txtPrice').val(obj.Price);
                                $('#txtPriceOld').val(obj.PriceOld);
                            }
                        }
                        $('#txtProductID').append("<option "+selected+" priceOld='"+obj.PriceOld+"' price='"+obj.Price+"' value='"+obj.ProductCode+"'>" + '['+obj.ProductCode+'] ' + obj.ProductName + "</option>");
                    });
                    $('#txtProductID').select2();               
                }
            });
        }

        function UpdateArticle() {
            $(".divLoading").fadeIn(0);
            var listObjImageArticle = $('#tblImages .urlImg');
                var listImageArticle = [];
                for (var i = 0; i < listObjImageArticle.length; i++) {
                    var images = {
                        "urlWeb": $(listObjImageArticle[i]).attr("data-urlweb"),
                        "urlTablet": $(listObjImageArticle[i]).attr("data-urltablet"),
                        "urlPhone": $(listObjImageArticle[i]).attr("data-urlphone"),
                        "fileName": $(listObjImageArticle[i]).attr("data-fileName"),
                        "size": $(listObjImageArticle[i]).attr("data-fileSize")
                    }
                    listImageArticle.push(images);
                }
            var jsonData = {
                "id": AppManage.getURLParameter("articleId") != null ? AppManage.getURLParameter("articleId") : 0,
                "status": $('#select_Status').val(),
                "title": $('#txtTitle').val(),
                "link": $('#txtLink').val(),
                "description": $('#txtDescription').val(),
                "metaKeyword": $('#txtMetakeyword').val(),
                "metaDescription": $('#txtMetadescription').val(),
                "images": JSON.stringify(listImageArticle),
                "videos": JSON.stringify(arrayVideos),
                "author": $('#txtAuthor').val(),
                "quote": $('#txtQuote').val(),
                "tags": $('#txtTags').val() != null ? $('#txtTags').val().toString() : "",
                "productCode": $('#txtProductID').val(),
                "product_Specifications": $('#txtProduct_Specifications').val(),
                "datePublish": $('#txtPubdate input').val(),
                "categoriesTags": $('#txtCategoriesTags').val() != null ? $('#txtCategoriesTags').val().toString() : ""
            };
            $.post(
                URL_MENU,
                {
                    type: 29,
                    json: JSON.stringify(jsonData),
                    body: document.getElementById("PageContent_RadEditor1_contentIframe").contentWindow.document.body.innerHTML.toString(),
                },
                function (data) {
                    if (data.status == 5005) {
                        window.location.assign("Login.aspx");
                        return;
                    }
                    if (data.status == 0) {
                        window.location.assign("Page.aspx?m=19&catId=" + AppManage.getURLParameter('catId'));
                    }
                    else {
                        $(".divLoading").fadeOut(0);
                        bootbox.alert(data.msg);
                    }                    
                }
            );
        }
    </script>
</asp:Content>
