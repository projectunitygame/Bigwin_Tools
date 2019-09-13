<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CMS_Tools.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
        <title>User Login</title>
        <meta name='robots' content='noindex,follow' />
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta content="width=device-width, initial-scale=1" name="viewport" />
        <meta content="" name="description" />
        <meta content="" name="author" />
        <!-- BEGIN GLOBAL MANDATORY STYLES -->
        <link href="https://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
        <link href="assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/global/css/loading.css" rel="stylesheet" />
        <link href="assets/global/css/Style.css" rel="stylesheet" />
        <!-- END GLOBAL MANDATORY STYLES -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <link href="assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL STYLES -->
        <link href="assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
        <link href="assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
        <!-- END THEME GLOBAL STYLES -->
        <!-- BEGIN PAGE LEVEL STYLES -->
        <link href="assets/pages/css/login-5.min.css" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL STYLES -->
        <!-- BEGIN THEME LAYOUT STYLES -->
        <!-- END THEME LAYOUT STYLES -->
        <link rel="shortcut icon" href="favicon.ico" />
        <style>
            .popup{
                position: fixed;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                z-index: 10;
                background: rgba(51, 51, 51, 0.15);
            }
            .bgTopup {
    width: 350px;
    margin: 0 auto;
    max-width: 98%;
    margin: 0 auto;
    margin-left: 80px;
    margin-right: 1%;
    overflow: hidden;
    position: relative;
    margin-top: 15px;
    padding: 15px;
    background: #FFF;
    -webkit-border-radius: 10px !important;
    -moz-border-radius: 10px !important;
    border-radius: 10px !important;
    background-color: white;
    border: 1px solid #b5b4b4;
    -webkit-box-shadow: 2px 2px 15px -1px rgba(0,0,0,0.75);
    -moz-box-shadow: 2px 2px 15px -1px rgba(0,0,0,0.75);
    box-shadow: 2px 2px 15px -1px rgba(0,0,0,0.75);
}
            .bgTopup img{
                max-width: 100%;
                width: 100px;
                border-radius: 50% !important;
                -webkit-border-radius: 50% !important;
                -moz-border-radius: 50% !important;
            }
            .col1{width:40%;float:left;}
            .col2{width:60%;float:left;}
            .msgError{color:orangered;margin-top:5px;}
            .userName{
                text-transform: uppercase;
                font-size: 14px;
                font-weight: bold;
            }
        </style>
</head>
<body class="login">
    <div id="showPopup" runat="server"></div>
    <input type="hidden" id="status" runat="server"/>
    <!-- BEGIN : LOGIN PAGE 5-2 -->
        <div class="user-login-5">
            <div class="row bs-reset">
                <div class="col-md-6 login-container bs-reset">
                    <%--<img style="width: 240px;" class="login-logo login-6" src="assets/layouts/layout2/img/logo.png"/>--%>
                    <div class="login-content">
                        <div class="divLoading" style="display:none;">                            
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
                        <h1>Admin Login</h1>
                        <%--<p> Lorem ipsum dolor sit amet, coectetuer adipiscing elit sed diam nonummy et nibh euismod aliquam erat volutpat. Lorem ipsum dolor sit amet, coectetuer adipiscing. </p>--%>
                        <form action="javascript:;" class="login-form" method="post">                          
                            <div class="alert alert-danger display-hide">
                                <button class="close" data-close="alert"></button>
                                <span class="msg">Vui lòng điền đầy đủ thông tin bên dưới. </span>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <input class="form-control form-control-solid placeholder-no-fix form-group" type="text" autocomplete="off" placeholder="Email hoặc số điện thoại" name="username" required/> 
                                </div>
                                <div class="col-xs-6">
                                    <input class="form-control form-control-solid placeholder-no-fix form-group" type="password" autocomplete="off" placeholder="Password" name="password" required/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label class="rememberme mt-checkbox mt-checkbox-outline">
                                        <input type="checkbox" name="remember" value="1" /> Nhớ mật khẩu
                                        <span></span>
                                    </label>
                                </div>
                                <div class="col-sm-8 text-right">
                                    <div class="forgot-password">
                                        <a href="javascript:;" id="forget-password" class="forget-password">Quên mật khẩu?</a>
                                    </div>
                                    <button class="btn blue" type="submit">Đăng nhập</button>                                  
                                </div>
                            </div>
                        </form>
                        <!-- BEGIN FORGOT PASSWORD FORM -->
                        <form class="forget-form" action="javascript:Login.resetPassword();" method="post">
                            <h3>Forgot Password ?</h3>
                            <p> Enter your e-mail address below to reset your password. </p>
                            <div class="form-group">
                                <input id="txtEmail" class="form-control placeholder-no-fix" type="email" autocomplete="off" placeholder="Email" name="email" required/> </div>
                            <div class="form-actions">
                                <button type="button" id="back-btn" class="btn blue btn-outline">Back</button>
                                <button type="submit" class="btn blue uppercase pull-right">Submit</button>                              
                            </div>
                        </form>
                        <!-- END FORGOT PASSWORD FORM -->
                    </div>
                    <div class="login-footer">
                        <div class="row bs-reset">
                            <div class="col-xs-5 bs-reset">
                                <ul class="social-icons login-social">
                                    <li>
                                        <a class="social-icon-color facebook" data-original-title="facebook" href="Authen/LoginFB.aspx">
                                        </a>
                                    </li>
                                    <li>
                                        <a class="social-icon-color googleplus" data-original-title="Goole Plus" href="Authen/LoginGG.aspx">
                                        </a>
                                    </li>                
                                </ul>
                            </div>
                            <div class="col-xs-7 bs-reset">
                                <div class="login-copyright text-right" id="copyRight" runat="server">          
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 bs-reset">
                    <div class="login-bg"> </div>
                </div>
            </div>
        </div>
        <!-- END : LOGIN PAGE 5-2 -->
        <!--[if lt IE 9]>
        <script src="../assets/global/plugins/respond.min.js"></script>
        <script src="../assets/global/plugins/excanvas.min.js"></script> 
        <script src="../assets/global/plugins/ie8.fix.min.js"></script> 
        <![endif]-->
        <!-- BEGIN CORE PLUGINS -->
        <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
        <script src="assets/global/plugins/bootbox.min.js"></script>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="assets/global/scripts/app.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="assets/pages/scripts/login.js" type="text/javascript"></script>
        <script src="assets/pages/scripts/ajax.js"></script>
        <!-- END PAGE LEVEL SCRIPTS -->
        <!-- BEGIN THEME LAYOUT SCRIPTS -->
        <!-- END THEME LAYOUT SCRIPTS -->          
</body>
</html>
