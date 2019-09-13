<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="testapi.aspx.cs" Inherits="CMS_Tools.testapi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageJSAdd" runat="server">
    <script>
        var json = {
            senderID:'UWIN.00000006',
            recipientID:'UWIN.00000007',
            amount:'1000000',
            reason:'chuyển tiền'
        }
        POST_DATA("Apis/API_Agency.ashx", {
            type: 7,
            json: JSON.stringify(json)
        }, function (res) {
            bootbox.alert({
                message: res.msg,
                callback: function () {
                }
            });
        });
    </script>
</asp:Content>
