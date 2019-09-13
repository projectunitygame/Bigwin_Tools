<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="CMS_Tools.Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <div id="PageTitle" runat="server"></div>
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
                <span><label id="lblMenuName" runat="server"></label></span>
            </li>
        </ul>
        <div class="page-toolbar">
            <div class="btn-group pull-right">
                <button id="btnAddAction" type="button" class="btn btn-fit-height blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                    Chức năng <i class="fa fa-angle-down"></i>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li>
                        <a href="javascript:;" id="btnAddNew"><i class="fa fa-plus"></i> Thêm mới</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
    <div id="PageID" runat="server"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <div id="PageIncludeJS" runat="server"></div>
    <script>
        $(function () {
            var menuId = AppManage.getURLParameter("m");
            if (menuId != null) {
                $('#m_' + menuId).addClass("active open");
                $('#m_' + menuId).parent().parent().addClass("active open");
                var e = document.createElement('span');
                e.classList.add('selected');
                if ($('#m_' + menuId).parent().parent().find("a").length > 0) {
                    $('#m_' + menuId).parent().parent().find("a")[0].append(e);
                }
            }
        });
    </script>
</asp:Content>
