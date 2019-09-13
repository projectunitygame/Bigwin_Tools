<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Page404.aspx.cs" Inherits="CMS_Tools.Page404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var r = parseFloat(1650 / 1000 * 2064 / 1000).toFixed(4);
        var d = parseFloat('1.7');
        alert(r);



        function formatNumber(num) {
            return num.toLocaleString('en-US');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
</asp:Content>
