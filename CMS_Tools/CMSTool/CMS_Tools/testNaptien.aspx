<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testNaptien.aspx.cs" Inherits="CMS_Tools.testNaptien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <a href="javascript:NapThe()">Nạp thẻ</a>
    <script>
        function NapThe() {
            $.ajax({
                type: "POST",
                url: "Apis/API_GameAccount.ashx",
                data: {
                    type: 19
                },
                dataType: 'json',
                success: function (data) {
                   
                }
            });
        }
    </script>
</body>
</html>
