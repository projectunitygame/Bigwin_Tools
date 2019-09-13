<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginFB.aspx.cs" Inherits="CMS_Tools.Authen.LoginFB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Facebook Login</title>   
    <script>
        // This is called with the results from from FB.getLoginStatus().
        function statusChangeCallback(response) {
            console.log("statusChangeCallback");
            console.log(response);
            // The response object is returned with a status field that lets the
            // app know the current login status of the person.
            // Full docs on the response object can be found in the documentation
            // for FB.getLoginStatus().
            if (response.status === "connected") {
                // Logged into your app and Facebook
                //testAPI();
                var uri = (window.location.href.split("?")[0]).replace("LoginFB.aspx", "FBLogin_Request.aspx");
                var link = "https://www.facebook.com/logout.php?next=" + uri + "&access_token=" + response.authResponse.accessToken;
                window.location = link;
                     
            } else {
                window.location = "FBLogin_Request.aspx";
            }
        }

        window.fbAsyncInit = function () {
            FB.init({
                appId: "245765952726441",
                autoLogAppEvents: true,
                xfbml: true,
                version: "v3.1"
            });


            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });

        };

        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement(s); js.id = id;
            js.src = "https://connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, "script", "facebook-jssdk"));

        
    </script>
    
</head>
<body>
    <div id="fb-root"></div>
    <div id="fb_link"></div>
</body>
</html>
