using CMS_Tools.Lib;
using CMS_Tools.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace CMS_Tools.Apis
{
    /// <summary>
    /// Summary description for Account
    /// </summary>
    public class Account : IHttpHandler, IRequiresSessionState
    {
        Result result = new Result();
        Model.ManagerDAO manage = new Model.ManagerDAO();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=utf-8";
            try
            {
                Constants.REQUEST_TYPE requestType = (Constants.REQUEST_TYPE)int.Parse(context.Request.Form["type"]);
                switch (requestType)
                {
                    case Constants.REQUEST_TYPE.RESET_PASSWORD:
                        RESET_PASSWORD(context);
                        break;
                    case Constants.REQUEST_TYPE.FORGOT_PASSWORD:
                        FORGOT_PASSWORD(context);
                        break;
                    case Constants.REQUEST_TYPE.UPDATE_STATUS_ACCOUNT:
                        UPDATE_STATUS_ACCOUNT(context);
                        break;
                    case Constants.REQUEST_TYPE.CREATE_ACCOUNT:
                        CREATE_ACCOUNT(context);
                        break;
                    case Constants.REQUEST_TYPE.LOCK_ACCOUNT:
                        LOCK_ACCOUNT(context);
                        break;
                    case Constants.REQUEST_TYPE.GET_ACCOUNT_LIST:
                        GET_ACCOUNT_LIST(context);
                        break;
                    case Constants.REQUEST_TYPE.LOGIN:
                        LOGIN(context);
                        break;
                    case Constants.REQUEST_TYPE.SIGN_OUT:
                        SIGN_OUT(context);
                        break;
                    case Constants.REQUEST_TYPE.LOCK_SCREEN:
                        LOCK_SCREEN(context);
                        break;
                    default:
                        result.status = Constants.NUMBER_CODE.REQUEST_NOT_FOUND;
                        result.msg = Constants.NUMBER_CODE.REQUEST_NOT_FOUND.ToString();
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        break;
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
                context.Response.Write(JsonConvert.SerializeObject(result));
            }           
        }

        private void RESET_PASSWORD(HttpContext context)
        {
            try
            {
                if (context.Session["resetpassword"] != null)
                {
                    var data = (ResetPasswordUser)context.Session["resetpassword"];
                    string password = context.Request.Form["password"];
                    if (string.IsNullOrEmpty(password)) {
                        result.status = Constants.NUMBER_CODE.PASS_IS_NULL;
                        result.msg = "Nhập mật khẩu mới!";
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                    else
                    {
                        if (UtilClass.IsUnicode(password))
                        {
                            result.status = Constants.NUMBER_CODE.PASS_INVALID;
                            result.msg = "Nhập mật khẩu không được có bỏ dấu!";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                    }
                    int code = manage.AccountModel.ResetPassword(data.loginId, data.loginType, password);
                    if (code == 0)
                    {
                        string link = UtilClass.GetWebAppRoot() + "/login.aspx";
                        bool s = SendMailUser("Thiết lập mật khẩu thành công", "Thiết lập mật khẩu thành công<br/>Email: " + data.loginId + "<br/>Link đăng nhập: <a href='"+link+"'>"+ link +"</a>", data.loginId);
                        if (s)
                        {
                            result.status = Constants.NUMBER_CODE.SUCCESS;
                            result.msg = "Cập nhật mật khẩu mới thành công";
                            context.Session.Clear();
                            context.Session.Abandon();
                            UtilClass.RemoveCookie(context, "accountToken");

                        }
                        else
                        {
                            result.status = Constants.NUMBER_CODE.SEND_MAIL_FAILD;
                            result.msg = "Lỗi hệ thống vui lòng thử lại!";
                        }
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.RESET_PASSWORD_TIMEOUT;
                    result.msg = "Lỗi hệ thống vui lòng thử lại!";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CREATE_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void FORGOT_PASSWORD(HttpContext context)
        {
            try
            {
                string email = context.Request.Form["email"];
                if (!string.IsNullOrEmpty(email))
                {
                    email = email.Trim();
                    int code = manage.AccountModel.CheckResetPassword(email, (byte)Constants.LOGIN_TYPE.SINGLEID);
                    if (code == 0)
                    {
                        string token = email.ToLower() + "|" + UtilClass.UnixTime(DateTime.Now) + "|" + UtilClass.GetIPAddress() + "|" + ((int)Constants.LOGIN_TYPE.SINGLEID);
                        string link = UtilClass.GetWebAppRoot() + "/VetifyResetPassword.aspx?token=" + Encryptor.Base64Encode(Encryptor.EncryptString(token, Constants.KEY_SERVER));
                        bool s = SendMailUser("Yêu cầu xác nhận thiết lập lại mật khẩu", "Hệ thống nhận yêu cầu thiết lập lại mật khẩu của Bạn. Vui lòng nhấn link bên dưới để thiết lập lại mật khẩu: <br/><br/><a href='" + link + "'>" + link + "</a>", email);
                        if (s)
                        {
                            result.status = Constants.NUMBER_CODE.SUCCESS;
                            result.msg = "Vui lòng kiểm tra Email để xác nhận lấy lại mật khẩu mới";
                        }
                        else
                        {
                            result.status = Constants.NUMBER_CODE.SEND_MAIL_FAILD;
                            result.msg = "Lỗi hệ thống vui lòng thử lại!";
                        }
                    }
                    else
                    {
                        result.status = (Constants.NUMBER_CODE)code;
                        result.msg = result.status.ToString();
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = "Email không được để trống!";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CREATE_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void UPDATE_STATUS_ACCOUNT(HttpContext context)
        {
            try
            {
                long accountId = long.Parse(context.Request.Form["accountId"]);
                string phone = context.Request.Form["phone"];
                string userName = context.Request.Form["userName"];
                string accountCode = context.Request.Form["code"];
                int group = int.Parse(context.Request.Form["group"]);
                int publisherId = int.Parse(context.Request.Form["publisherId"]);
                byte status = context.Request.Form["status"] == "Active" ? (byte)1 : (byte)0;
                int code = manage.AccountModel.UpdateStatusAccount(accountId, status, group, publisherId, phone, "", accountCode, userName);
                result.status = (Constants.NUMBER_CODE)code;
                result.msg = code == 0 ? Constants.NUMBER_CODE.SUCCESS.ToString() : "Lỗi cập nhật!";
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CREATE_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        private void CREATE_ACCOUNT(HttpContext context)
        {
            try
            {
                string userName = context.Request.Form["userName"];
                string code = context.Request.Form["code"];
                string email = context.Request.Form["email"];
                string phone = context.Request.Form["phone"];
                string group = context.Request.Form["group"];
                int publisherId = int.Parse(context.Request.Form["publisherId"]);
                int r = 0;
                if (!string.IsNullOrEmpty(email))
                {
                    email = email.Trim();
                    manage.AccountModel.Register(new Model.RegisterInfo()
                    {
                        deviceId = "",
                        deviceName = "",
                        email = email,
                        ip = Lib.UtilClass.GetIPAddress(),
                        loginId = email,
                        loginType = (byte)Constants.LOGIN_TYPE.SINGLEID,
                        picture = "",
                        publisherId = publisherId,
                        userName = userName,
                        code = code,
                        group = int.Parse(group),
                        position = ""
                    }, ref r);
                    result.status = (Constants.NUMBER_CODE)r;
                    result.msg = r == 0 ? Constants.NUMBER_CODE.SUCCESS.ToString() : "Lỗi đăng ký!";
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = "Email không được để trống!";
                }
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CREATE_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        private void LOCK_ACCOUNT(HttpContext context)
        {
            try
            {
                var accountInfo = Account.GetAccountInfo(context);
                if (accountInfo == null)
                {
                    result.status = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN;
                    result.msg = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN.ToString();
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                string accountId = context.Request.Form["accountId"];
                if (!string.IsNullOrEmpty(accountId))
                {
                    int code = manage.AccountModel.LockAccount(accountId);
                    result.msg = code == 0 ? Constants.NUMBER_CODE.SUCCESS.ToString() : "Lỗi hệ thống [" + code + "]";
                    result.status = code == 0 ? Constants.NUMBER_CODE.SUCCESS : Constants.NUMBER_CODE.LOCK_ACCOUNT_FAID;
                }
                else {
                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR LOCK_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// GET_ACCOUNT_LIST
        /// </summary>
        /// <param name="context"></param>
        private void GET_ACCOUNT_LIST(HttpContext context)
        {
            Account_List result = new Account_List();
            try
            {
                var accountInfo = Account.GetAccountInfo(context);
                if (accountInfo == null)
                {
                    result.status = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN;
                    result.msg = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN.ToString();
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                int? code = 0;
                var listAccount = manage.AccountModel.GetAccountList(ref code);
                result.msg = Constants.NUMBER_CODE.SUCCESS.ToString();
                result.columnName = (from dc in listAccount.Columns.Cast<DataColumn>()
                                     select dc.ColumnName).ToArray();
                result.data = Helper.DataTableToArray(listAccount);
                result.status = code > 0 ? Constants.NUMBER_CODE.SUCCESS : Constants.NUMBER_CODE.ACCOUNT_LIST_NULL;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_ACCOUNT_LIST: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// LOCK_SCREEN
        /// </summary>
        /// <param name="context"></param>
        private void LOCK_SCREEN(HttpContext context)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR LOCK_SCREEN: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
        }

        /// <summary>
        /// SIGN_OUT
        /// </summary>
        /// <param name="context"></param>
        private void SIGN_OUT(HttpContext context)
        {
            try
            {
                if (LOGOUT_ACCOUNT(context))
                {
                    context.Session.Clear();
                    context.Session.Abandon();
                    UtilClass.RemoveCookie(context, "accountToken");
                    result.msg = Constants.NUMBER_CODE.SUCCESS.ToString();
                    result.status = Constants.NUMBER_CODE.SUCCESS;
                }
                else
                {
                    result.msg = Constants.NUMBER_CODE.SIGN_OUT_FAID.ToString();
                    result.status = Constants.NUMBER_CODE.SIGN_OUT_FAID;
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR SIGN_OUT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Login account by email , phone
        /// </summary>
        /// <param name="context"></param>
        private void LOGIN(HttpContext context)
        {
            string id = context.Request.Form["id"];
            string pass = context.Request.Form["pass"];
            string captcha = context.Request.Form["captcha"];
            try
            {
                bool remember = Convert.ToBoolean(context.Request.Form["remember"]);
                if (string.IsNullOrEmpty(id))
                {
                    result.status = Constants.NUMBER_CODE.USERNAME_IS_NULL;
                    result.msg = "Vui lòng nhập ID!";
                }
                else if (string.IsNullOrEmpty(pass))
                {
                    result.status = Constants.NUMBER_CODE.PASS_IS_NULL;
                    result.msg = "Vui lòng nhập mật khẩu!";
                }
                else if (string.IsNullOrEmpty(captcha))
                {
                    result.status = Constants.NUMBER_CODE.CAPTCHA_NULL;
                    result.msg = "Vui lòng nhập captcha!";
                }
                else
                {
                    id = id.Trim();
                    int? code = 0;
                    if(context.Session["captcha"] == null)
                    {
                        context.Session["captcha"] = "";
                    }
                    if(captcha != context.Session["captcha"].ToString())
                    {
                        result.status = Constants.NUMBER_CODE.CAPTCHA_ERROR;
                        result.msg = "Mã captcha không đúng!";
                    }
                    else
                    {
                        var userData = manage.AccountModel.LoginID(new Model.LoginInfo()
                        {
                            deviceId = "",
                            deviceName = "",
                            ip = UtilClass.GetIPAddress(),
                            loginId = id,
                            loginType = (byte)Constants.LOGIN_TYPE.SINGLEID,
                            password = pass
                        }, ref code);

                        if (code == 1)//login success
                        {
                            context.Session["account"] = userData;
                            if (remember)
                            {
                                UtilClass.AddCookie(context, "accountToken", userData.Token);
                            }
                            string menuId = "";
                            string menuRule = "";
                            int groupID = 0;
                            int r = manage.AccountModel.GetRuleByAccountId(userData.AccountId, ref menuId, ref menuRule, ref groupID);
                            if (r == 0)
                            {
                                userData.GroupID = groupID;
                                context.Session["menuId"] = JsonConvert.DeserializeObject<List<int>>(menuId);
                                context.Session["menuRule"] = JsonConvert.DeserializeObject<List<List<int>>>(menuRule);
                                context.Session["account"] = userData;
                            }
                            result.status = Constants.NUMBER_CODE.SUCCESS;
                            result.msg = "Đăng nhập thành công";
                            if (groupID == 6)
                                result.data = "Page.aspx?m=9";
                            else
                                result.data = "Dashboard.aspx";
                        }
                        else
                        {
                            result.status = (Constants.NUMBER_CODE)code;
                            result.msg = "Đăng nhập không thành công!";
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR LOGIN: " + id +"\r\n"+ ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public static UserInfo GetUserByToken(string token)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    ManagerDAO manage = new ManagerDAO();
                    int? code = 0;
                    var userData = manage.AccountModel.LoginWithToken(token, Lib.UtilClass.GetIPAddress(), ref code);
                    if (code == 1)
                    {
                        HttpContext.Current.Session["account"] = userData;
                        string menuId = "";
                        string menuRule = "";
                        int groupID = 0;
                        int r = manage.AccountModel.GetRuleByAccountId(userData.AccountId, ref menuId, ref menuRule, ref groupID);
                        if (r == 0)
                        {
                            userData.GroupID = groupID;
                            HttpContext.Current.Session["menuId"] = JsonConvert.DeserializeObject<List<int>>(menuId);
                            HttpContext.Current.Session["menuRule"] = JsonConvert.DeserializeObject<List<List<int>>>(menuRule);
                            HttpContext.Current.Session["account"] = userData;
                        }
                        return userData;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// GetAccountInfo
        /// </summary>
        /// <returns></returns>
        public static UserInfo GetAccountInfo(HttpContext context)
        {
            try
            {
                if (context.Session["account"] != null)
                {
                    var userData = (UserInfo)HttpContext.Current.Session["account"];
                    return userData;
                }
                else if(context.Request.Cookies["accountToken"] != null) {
                    string token = context.Request.Cookies["accountToken"].Value;
                    return GetUserByToken(token);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GetAccountInfo: " + ex);
                return null;
            }
        }

        /// <summary>
        /// LOGOUT_ACCOUNT Clear all cookie user
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool LOGOUT_ACCOUNT(HttpContext context) {
            try
            {
                var account = GetAccountInfo(context);
                if (account != null)
                {
                    Model.ManagerDAO managerDao = new Model.ManagerDAO();
                    int r = managerDao.AccountModel.LoginOut(account.Token);
                    if (r == (int)Constants.NUMBER_CODE.SUCCESS)
                        return true;
                    else
                        return false;
                }
                else
                {
                    context.Session["account"] = null;
                    UtilClass.RemoveCookie(context, "accountToken");
                }
                return true;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR LOGOUT_ACCOUNT: " + ex);
                return false;
            }
        }

        /// <summary>
        /// SendMailUser
        /// </summary>
        /// <param name="title"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public bool SendMailUser(string title, string content, string email) {
            try
            {
                StringBuilder sendMailContent = new StringBuilder();
                sendMailContent.Append("Chào Bạn," +
                   "<br/>" + content);
                //"<br/>Hệ thống nhận yêu cầu thiết lập lại mật khẩu của Bạn. Vui lòng nhấn link bên dưới để thiết lập lại mật khẩu: ");
                //sendMailContent.Append("<br/><br/>" + link);
                sendMailContent.Append("<br/><br/>Nếu bạn gặp bất kì vấn đề nào trong quá trình sử dụng tài khoản vui lòng liên hệ<br/>" +
                    "với chúng tôi theo địa chỉ mail: support@mysystem.com.vn/ <br/>" +
                    "Team mysystem<br/>" +
                    "Thân.");
                Mail.SendEmail(title, sendMailContent.ToString(), email);
                return true;
            }
            catch (Exception ex)
            {
                Logs.SaveError("Error Send Mail: " + ex);
                return false;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Result
    {
        public Constants.NUMBER_CODE status { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }

    public class ResultSearchAgrency
    {
        public Constants.NUMBER_CODE status { get; set; }
        public string msg { get; set; }
        public List<AgencyInfo> data { get; set; }
    }

    public class AgencyInfo
    {
        public string AgencyID;
        public string DisplayName;
    }

    public class Account_List
    {
        public Constants.NUMBER_CODE status { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public string[] columnName { get; set; }
    }
}