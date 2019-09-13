using CMS_Tools.Lib;
using CMS_Tools.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CMS_Tools.Apis
{
    /// <summary>
    /// Summary description for API_Agency
    /// </summary>
    public class API_Agency : IHttpHandler, IRequiresSessionState
    {
        Model.ManagerDAO manage = new Model.ManagerDAO();
        UserInfo accountInfo;
        Result result = new Result();
        List<Constants.USER_PERMISSTIONS> uSER_RULEs = new List<Constants.USER_PERMISSTIONS>();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=utf-8";
            try
            {
                Constants.REQUEST_AGENCY_TYPE requestType = (Constants.REQUEST_AGENCY_TYPE)int.Parse(context.Request.Form["type"]);
                if (requestType != Constants.REQUEST_AGENCY_TYPE.LOGIN_AGENCY 
                    && requestType != Constants.REQUEST_AGENCY_TYPE.CHECK_FORGOT_PASSWORD
                    && requestType != Constants.REQUEST_AGENCY_TYPE.RESET_PASSWORD)
                {
                    #region CHECK ACCOUNT LOGIN
                    accountInfo = Account.GetAccountInfo(context);

                    if (accountInfo == null)
                    {
                        result.status = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN;
                        result.msg = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN.ToString();
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                    #endregion
                }
                switch (requestType)
                {
                    case Constants.REQUEST_AGENCY_TYPE.LOGIN_AGENCY:
                        LOGIN_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.CHECK_FORGOT_PASSWORD:
                        CHECK_FORGOT_PASSWORD(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.RESET_PASSWORD:
                        RESET_PASSWORD(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.GET_INFO_AGENCY:
                        GET_INFO_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.CHANGE_PASSWORD:
                        CHANGE_PASSWORD(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.CHANGE_TRANSACTION_LIMIT:
                        CHANGE_TRANSACTION_LIMIT(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.FIND_AGENCY:
                        FIND_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.TRANFER_MONEY_TO_AGENCY:
                        TRANFER_MONEY_TO_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.FIND_GAME_ACCOUNT:
                        FIND_GAME_ACCOUNT(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.TRANFER_MONEY_TO_AGENCY_USER:
                        TRANFER_MONEY_TO_AGENCY_USER(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.ACTIVE_PHONE_AGENCY:
                        ACTIVE_PHONE_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.CREATE_AGENCY_SUB2:
                        CREATE_AGENCY_SUB2(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.CHANGE_PHONE_AGENCY:
                        CHANGE_PHONE_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.CHANGE_INFOMATION_AGENCY:
                        CHANGE_INFOMATION_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.CHANGE_DISPLAY_AGENCY:
                        CHANGE_DISPLAY_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.CHANGE_FB_AGENCY:
                        CHANGE_FB_AGENCY(context);
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
                Logs.SaveError("ERROR API_Agency: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        private void CHANGE_FB_AGENCY(HttpContext context)
        {
            try
            {
                if (context.Session["CHANGE_FB_AGENCY"] == null || (DateTime.Now - (DateTime)context.Session["CHANGE_FB_AGENCY"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    UpdateFBLinkEntity jsonData = new UpdateFBLinkEntity();
                    //if (string.IsNullOrEmpty(context.Request.Form["fb"]))
                    //{
                    //    result.status = Constants.NUMBER_CODE.DATA_NULL;
                    //    result.msg = "Link facebook không được để trống!";
                    //}
                    //else
                    {
                        accountInfo = (UserInfo)context.Session["account"];
                        jsonData.agencyID = accountInfo.MasterID;
                        jsonData.fb = context.Request.Form["fb"];
                        jsonData.creatorID = accountInfo.AccountId;
                        jsonData.creatorName = accountInfo.UserName;
                        if (string.IsNullOrEmpty(jsonData.agencyID))
                        {
                            result.status = Constants.NUMBER_CODE.DATA_NULL;
                            result.msg = "Không tìn thấy thông tin tài khoản";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                        jsonData.ip = UtilClass.GetIPAddress();
                        //Logs.SaveLog("jsonData TRANFER_MONEY_TO_AGENCY_USER" + JsonConvert.SerializeObject(jsonData));
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/UpdateFB_Agency");
                        context.Response.Write(responseData);
                        return;
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CHANGE_FB_AGENCY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["CHANGE_FB_AGENCY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void CHANGE_DISPLAY_AGENCY(HttpContext context)
        {
            try
            {
                if (context.Session["CHANGE_DISPLAY_AGENCY"] == null || (DateTime.Now - (DateTime)context.Session["CHANGE_DISPLAY_AGENCY"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    UpdateDisplayAgencyEntity jsonData = new UpdateDisplayAgencyEntity();
                    bool display = true;
                    if (string.IsNullOrEmpty(context.Request.Form["display"]))
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = "Giá trị chọn không tồn tại!";
                    }
                    else if(!bool.TryParse(context.Request.Form["display"], out display))
                    {
                        result.status = Constants.NUMBER_CODE.TRYPARSE_ERROR;
                        result.msg = "Dữ liệu truyền vào không đúng!";
                    }
                    else
                    {
                        display = bool.Parse(context.Request.Form["display"]);
                        accountInfo = (UserInfo)context.Session["account"];
                        jsonData.agencyID = accountInfo.MasterID;
                        jsonData.display = display;
                        jsonData.creatorID = accountInfo.AccountId;
                        jsonData.creatorName = accountInfo.UserName;
                        if (string.IsNullOrEmpty(jsonData.agencyID))
                        {
                            result.status = Constants.NUMBER_CODE.DATA_NULL;
                            result.msg = "Không tìn thấy thông tin tài khoản";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                        jsonData.ip = UtilClass.GetIPAddress();
                        //Logs.SaveLog("jsonData TRANFER_MONEY_TO_AGENCY_USER" + JsonConvert.SerializeObject(jsonData));
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/UpdateDisplay_Agency");
                        context.Response.Write(responseData);
                        return;
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CHANGE_DISPLAY_AGENCY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["CHANGE_DISPLAY_AGENCY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void CHANGE_INFOMATION_AGENCY(HttpContext context)
        {
            try
            {
                if (context.Session["CHANGE_INFOMATION_AGENCY"] == null || (DateTime.Now - (DateTime)context.Session["CHANGE_INFOMATION_AGENCY"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    UpdateInformationAgencyEntity jsonData = new UpdateInformationAgencyEntity();
                    //if (string.IsNullOrEmpty(context.Request.Form["information"]))
                    //{
                    //    result.status = Constants.NUMBER_CODE.DATA_NULL;
                    //    result.msg = "Thông tin đại lý không được để trống!";
                    //}
                    //else
                    {
                        accountInfo = (UserInfo)context.Session["account"];
                        jsonData.agencyID = accountInfo.MasterID;
                        jsonData.information = context.Request.Form["information"];
                        jsonData.creatorID = accountInfo.AccountId;
                        jsonData.creatorName = accountInfo.UserName;
                        if (string.IsNullOrEmpty(jsonData.agencyID))
                        {
                            result.status = Constants.NUMBER_CODE.DATA_NULL;
                            result.msg = "Không tìn thấy thông tin tài khoản";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                        jsonData.ip = UtilClass.GetIPAddress();
                        //Logs.SaveLog("jsonData TRANFER_MONEY_TO_AGENCY_USER" + JsonConvert.SerializeObject(jsonData));
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/UpdateInformation_Agency");
                        context.Response.Write(responseData);
                        return;
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CHANGE_INFOMATION_AGENCY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["CHANGE_INFOMATION_AGENCY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void CHANGE_PHONE_AGENCY(HttpContext context)
        {
            try
            {
                if (context.Session["CHANGE_PHONE_AGENCY"] == null || (DateTime.Now - (DateTime)context.Session["CHANGE_PHONE_AGENCY"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<ChangePhoneAgency>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                        var jsonData = JsonConvert.DeserializeObject<ChangePhoneAgency>(json);

                        if (jsonData != null)
                        {
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));


                            if (string.IsNullOrEmpty(jsonData.phoneNew))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Vui lòng nhập số điện thoại mới!";
                            }
                            else
                            {
                                if (jsonData.OTP == "")
                                {
                                    if (string.IsNullOrEmpty(jsonData.captcha))
                                    {
                                        result.status = Constants.NUMBER_CODE.CAPTCHA_NULL;
                                        result.msg = "Vui lòng nhập captcha!";
                                        context.Response.Write(JsonConvert.SerializeObject(result));
                                        return;
                                    }
                                    else
                                    {
                                        if (context.Session["captcha"] != null && jsonData.captcha != context.Session["captcha"].ToString())
                                        {
                                            result.status = Constants.NUMBER_CODE.CAPTCHA_ERROR;
                                            result.msg = "Mã captcha không đúng!";
                                            context.Response.Write(JsonConvert.SerializeObject(result));
                                            return;
                                        }
                                    }
                                }
                                accountInfo = (UserInfo)context.Session["account"];
                                jsonData.uwinID = accountInfo.MasterID;
                                jsonData.phoneOld = accountInfo.AgencyInfo.phone;
                                if (string.IsNullOrEmpty(jsonData.uwinID))
                                {
                                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                                    result.msg = "Không tìn thấy thông tin tài khoản";
                                    context.Response.Write(JsonConvert.SerializeObject(result));
                                    return;
                                }
                                jsonData.ip = UtilClass.GetIPAddress();
                                //Logs.SaveLog("jsonData TRANFER_MONEY_TO_AGENCY_USER" + JsonConvert.SerializeObject(jsonData));
                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/ChangePhoneAgency");
                                context.Response.Write(responseData);
                                return;
                            }
                        }
                        else
                        {
                            result.status = Constants.NUMBER_CODE.DATA_NULL;
                            result.msg = "Thông tin không được để trống";
                        }
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                        result.msg = "Không thể kết nối";
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CHANGE_PHONE_AGENCY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["CHANGE_PHONE_AGENCY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void CREATE_AGENCY_SUB2(HttpContext context)
        {
            short debug = 0;
            try
            {
                if (context.Session["CREATE_AGENCY_SUB2"] == null || (DateTime.Now - (DateTime)context.Session["CREATE_AGENCY_SUB2"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    debug = 1;
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        debug = 2;
                        var jsonData = JsonConvert.DeserializeObject<AgencyEntity>(json);
                        if (jsonData != null)
                        {
                            debug = 3;
                            if (string.IsNullOrEmpty(jsonData.agencyCode))
                            {
                                debug = 303;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Password không được để trống";
                            }
                            if (string.IsNullOrEmpty(jsonData.password))
                            {
                                debug = 303;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Password không được để trống";
                            }
                            else if (jsonData.password.Length < 6 && jsonData.password.Length > 20)
                            {
                                debug = 304;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Password phải từ 6-20 ký tự";
                            }
                            else if (jsonData.email.Length > 80)
                            {
                                debug = 3051;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Email không được dài hơn 80 ký tự";
                            }
                            else if (string.IsNullOrEmpty(jsonData.phone))
                            {
                                debug = 306;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Số điện thoại không được để trống";
                            }
                            else if (jsonData.phone.Length != 10)
                            {
                                debug = 307;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Số điện thoại phải là 10 chữ số";
                            }
                            else if (string.IsNullOrEmpty(jsonData.displayName))
                            {
                                debug = 308;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Tên hiển thị không được để trống";
                            }
                            else if (jsonData.displayName.Length < 6)
                            {
                                debug = 3091;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Tên hiển thị phải nhiều hơn 5 ký tự";
                            }
                            else if (jsonData.infomation.Length >= 250)
                            {
                                debug = 3092;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Thông tin đại lý phải ít hơn 250 ký tự";
                            }
                            else if (jsonData.FB.Length >= 250)
                            {
                                debug = 3093;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Đường link facebook phải ít hơn 250 ký tự";
                            }
                            else
                            {
                                debug = 310;

                                jsonData.IP = UtilClass.GetIPAddress();
                                jsonData.creatorID = accountInfo.AccountId;
                                jsonData.creatorName = accountInfo.UserName;
                                jsonData.limitTransaction = Constants.limitTransaction;
                                jsonData.limitTransactionDaily = Constants.limitTransactionDaily;
                                accountInfo = (UserInfo)context.Session["account"];
                                jsonData.ownerID = accountInfo.MasterID;
                                if (accountInfo.AgencyInfo.agencyCode.Length >13) {

                                    result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                    result.msg = "Đại lý cấp 2 không thể tạo đại lý con";
                                    context.Response.Write(JsonConvert.SerializeObject(result));
                                    return;
                                }
                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Agency/CreateAgency_C2");
                                context.Response.Write(responseData);
                                return;
                            }
                        }
                        else
                        {
                            debug = 4;
                            result.status = Constants.NUMBER_CODE.DATA_NULL;
                            result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
                        }
                    }
                    else
                    {
                        debug = 5;
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
                    }
                }
                else
                {
                    debug = 6;
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CREATE_AGENCY: [debug]:" + debug + "\n,\n" + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                Logs.SaveError("[debug]:" + debug);
                context.Session["CREATE_AGENCY_SUB2"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void ACTIVE_PHONE_AGENCY(HttpContext context)
        {
            try
            {
                if (context.Session["ACTIVE_PHONE_AGENCY"] == null || (DateTime.Now - (DateTime)context.Session["ACTIVE_PHONE_AGENCY"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    var jsonData = new ActivePhoneAgency();

                    accountInfo = (UserInfo)context.Session["account"];
                    jsonData.uwinID = accountInfo.MasterID;
                    jsonData.phone = accountInfo.AgencyInfo.phone;
                    jsonData.ip = UtilClass.GetIPAddress();
                    if (context.Request.Form["otp"] !=null)
                    {
                        jsonData.OTP = context.Request.Form["otp"];
                    }


                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    Logs.SaveLog("accountInfo ACTIVE_PHONE_AGENCY: " + JsonConvert.SerializeObject(accountInfo));
                    Logs.SaveLog("jsonData ACTIVE_PHONE_AGENCY: " + JsonConvert.SerializeObject(jsonData));
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/ActivePhoneAgency");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR TRANFER_MONEY_TO_AGENCY_USER: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["TRANFER_MONEY_TO_AGENCY_USER"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void TRANFER_MONEY_TO_AGENCY_USER(HttpContext context)
        {
            try
            {
                if (context.Session["TRANFER_MONEY_TO_AGENCY_USER"] == null || (DateTime.Now - (DateTime)context.Session["TRANFER_MONEY_TO_AGENCY_USER"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    var listMenus = (List<int>)context.Session["menuId"];
                    var userRules = (List<List<int>>)context.Session["menuRule"];
                    if (!listMenus.Contains(26))
                    {
                        result.status = Constants.NUMBER_CODE.YOU_DO_NOT_PERMISSION_TO_ACCESS;
                        result.msg = "Tài khoản không có quyền truy cập!";
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                    var indexMenu = listMenus.IndexOf(26);
                    var myRules = userRules[indexMenu];
                    if (!myRules.Contains((int)Constants.USER_PERMISSTIONS.CHUYEN_TIEN_USERS))
                    {
                        result.status = Constants.NUMBER_CODE.YOU_DO_NOT_PERMISSION_TO_ACCESS;
                        result.msg = "Tài khoản không có quyền chuyển tiền!";
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<TransferMoneyToUser>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                        var jsonData = JsonConvert.DeserializeObject<TransferMoneyToUser>(json);

                        if (jsonData != null)
                        {
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));


                            if (string.IsNullOrEmpty(jsonData.recipientID.ToString()))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Vui lòng nhập tài khoản người nhận!";
                            }
                            else if (string.IsNullOrEmpty(jsonData.amount.ToString()))
                            {
                                result.status = Constants.NUMBER_CODE.CAPTCHA_NULL;
                                result.msg = "Vui lòng nhập số tiền cần chuyển";
                            }
                            else
                            {
                                if (jsonData.OTP == "")
                                {
                                    if (string.IsNullOrEmpty(jsonData.captcha))
                                    {
                                        result.status = Constants.NUMBER_CODE.CAPTCHA_NULL;
                                        result.msg = "Vui lòng nhập captcha!";
                                        context.Response.Write(JsonConvert.SerializeObject(result));
                                        return;
                                    }
                                    else
                                    {
                                        if (context.Session["captcha"] != null && jsonData.captcha != context.Session["captcha"].ToString())
                                        {
                                            result.status = Constants.NUMBER_CODE.CAPTCHA_ERROR;
                                            result.msg = "Mã captcha không đúng!";
                                            context.Response.Write(JsonConvert.SerializeObject(result));
                                            return;
                                        }
                                    }
                                }
                                accountInfo = (UserInfo)context.Session["account"];
                                jsonData.senderID = accountInfo.MasterID;
                                if (string.IsNullOrEmpty(jsonData.senderID))
                                {
                                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                                    result.msg = "Không tìn thấy thông tin tài khoản";
                                    context.Response.Write(JsonConvert.SerializeObject(result));
                                    return;
                                }
                                jsonData.ip = UtilClass.GetIPAddress();
                                //Logs.SaveLog("jsonData TRANFER_MONEY_TO_AGENCY_USER" + JsonConvert.SerializeObject(jsonData));
                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/TransferMoneyToUser");
                                context.Response.Write(responseData);
                                return;
                            }
                        }
                        else
                        {
                            result.status = Constants.NUMBER_CODE.DATA_NULL;
                            result.msg = "Thông tin không được để trống";
                        }
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                        result.msg = "Không thể kết nối";
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR TRANFER_MONEY_TO_AGENCY_USER: " + ex, ex, true);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["TRANFER_MONEY_TO_AGENCY_USER"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }


        private void FIND_GAME_ACCOUNT(HttpContext context)
        {
            try
            {
                if (context.Session["FIND_GAME_ACCOUNT"] == null || (DateTime.Now - (DateTime)context.Session["FIND_GAME_ACCOUNT"]).TotalMilliseconds > 200)
                {
                    FindAgencyEntity findAgencyEntity = new FindAgencyEntity();
                    findAgencyEntity.param = context.Request.Form["param"];
                    findAgencyEntity.topN = 20;
                    Logs.SaveLog(JsonConvert.SerializeObject(findAgencyEntity));
                    if (string.IsNullOrEmpty(findAgencyEntity.param))
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = "Không có từ khóa tìm kiếm được nhập!";
                    }
                    else
                    {
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(findAgencyEntity), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/FindGameAccount");
                        var d = JsonConvert.DeserializeObject<ResultSearchUserGame>(responseData);
                        //{ "status":0,"msg":null,"data":[{"AgencyID":9,"DisplayName":"Đại Lý 1","AgencyCode":"daily1","Phone":"0962474560"}]}
                        //[{"CustomerID":31,"CustomerCode":"HC1900031","CompanyName":"MR-VIET CO LTD","CompanyName2":"MR-VIET CO LTD","TaxCode":"","Email":"","Phone":"","Contact":"TUAN","Contact2":"TUAN","CreateDate":"2019-07-03T08:59:03.983","Status":1,"Address":"21/1E NGUYEN ANH THU BA DIEM HOC MON","City":56,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":0,"LoaiHinhSX_ID":0,"LastUpdate":"2019-07-03T08:59:03.983"},{"CustomerID":30,"CustomerCode":"BD1900030","CompanyName":"MINH LONG","CompanyName2":"MINH LONG","TaxCode":"","Email":"","Phone":"","Contact":"TUAN","Contact2":"TUAN","CreateDate":"2019-07-02T09:24:20.28","Status":1,"Address":"KCN VIETNAM SINGAGPORE","City":8,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":0,"LastUpdate":"2019-07-02T09:24:20.28"},{"CustomerID":29,"CustomerCode":"BD1900029","CompanyName":"APPAREL","CompanyName2":"APPAREL","TaxCode":"","Email":"","Phone":"","Contact":"TUẤN","Contact2":"TUAN","CreateDate":"2019-07-01T17:03:25.523","Status":1,"Address":"46 DAI LO TU DO VSIP,THUAN AN ,BD","City":8,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":0,"LastUpdate":"2019-07-01T17:03:25.523"},{"CustomerID":28,"CustomerCode":"DN1900028","CompanyName":"NANGYANG","CompanyName2":"NANGYANG","TaxCode":"","Email":"","Phone":"","Contact":"TUẤN","Contact2":"TUAN","CreateDate":"2019-06-25T14:00:23.617","Status":1,"Address":"BLOCK C LONG KHANH,DONG NAI","City":17,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":0,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-25T14:00:23.617"},{"CustomerID":27,"CustomerCode":"BT1900027","CompanyName":"HOANG LOAN","CompanyName2":"HOANG LOAN","TaxCode":"","Email":"","Phone":"","Contact":"TUAN","Contact2":"TUAN","CreateDate":"2019-06-22T14:07:46.897","Status":0,"Address":"","City":7,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-22T14:29:22.227"},{"CustomerID":26,"CustomerCode":"BT1900026","CompanyName":"HOÀNG LOAN","CompanyName2":"HOANG LOAN","TaxCode":"","Email":"","Phone":"","Contact":"TUAN","Contact2":"TUAN","CreateDate":"2019-06-22T13:57:47.35","Status":1,"Address":"GIỒNG TRÔM ,BỂN TRE","City":7,"Country":84,"KM":0,"Address1":"","City1":7,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-22T14:28:58.757"},{"CustomerID":22,"CustomerCode":"HC1900022","CompanyName":"TRANG VANG","CompanyName2":"TRANG VANG","TaxCode":"","Email":"","Phone":"","Contact":"TUẤN","Contact2":"TUAN","CreateDate":"2019-06-13T09:55:48.3","Status":1,"Address":"26/1ATRẦN QUÝ CÁP ,BÌNH THẠNH","City":56,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-13T09:55:48.3"},{"CustomerID":19,"CustomerCode":"TG1900019","CompanyName":"ITOCHU(HỒNG ÂN)","CompanyName2":"ITOCHU(HONG AN)","TaxCode":"","Email":"","Phone":"","Contact":"TUẤN","Contact2":"TUAN","CreateDate":"2019-06-08T11:58:34.03","Status":1,"Address":"CAI LẬY,TIỀN GIANG","City":51,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-08T11:58:34.03"},{"CustomerID":13,"CustomerCode":"HC1900013","CompanyName":"TUYẾN HIỆP LỢI","CompanyName2":"TUYEN HIEP LOI","TaxCode":"","Email":"","Phone":"","Contact":"Ms HOA","Contact2":"Ms HOA","CreateDate":"2019-05-31T14:16:57.62","Status":1,"Address":"Ap 3, xã Phạm Văn Cội, Huyện Củ Chi, TP. HCM","City":56,"Country":84,"KM":130,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":1,"LastUpdate":"2019-05-31T14:17:20.997"},{"CustomerID":6,"CustomerCode":"HC1900006","CompanyName":"CTY TNHH TM DV TÚ PHÚ","CompanyName2":"CTY TNHH TM DV TU PHU","TaxCode":"0333345774","Email":"","Phone":"0988867676","Contact":"Anh Tú","Contact2":"Anh Tu","CreateDate":"2019-04-07T14:47:45.453","Status":1,"Address":"268 To Hien Thanh","City":56,"Country":84,"KM":10,"Address1":"80/23 Trinh Dinh Thao","City1":1,"Country1":84,"KM1":200,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":1,"LastUpdate":"2019-06-01T00:59:40.683"}]
                        context.Response.Write(JsonConvert.SerializeObject(d.data));
                        return;
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR FIND_GAME_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["FIND_GAME_ACCOUNT"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }


        private void TRANFER_MONEY_TO_AGENCY(HttpContext context)
        {
            try
            {
                if (context.Session["TRANFER_MONEY_TO_AGENCY"] == null || (DateTime.Now - (DateTime)context.Session["TRANFER_MONEY_TO_AGENCY"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<TransferMoneyToAgency>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                        var jsonData = JsonConvert.DeserializeObject<TransferMoneyToAgency>(json);

                        if (jsonData != null)
                        {
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));


                            if (string.IsNullOrEmpty(jsonData.recipientID))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Vui lòng nhập tài khoản người nhận!";
                            }
                            else if (jsonData.senderID == jsonData.recipientID)
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Tài khoản người gửi và tài khoản người nhận không được giống nhau!";
                            }
                            else if (string.IsNullOrEmpty(jsonData.amount.ToString()))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Vui lòng nhập số tiền cần chuyển";
                            }
                            else
                            {
                                if (jsonData.OTP == "")
                                {
                                    if (string.IsNullOrEmpty(jsonData.captcha))
                                    {
                                        result.status = Constants.NUMBER_CODE.CAPTCHA_NULL;
                                        result.msg = "Vui lòng nhập captcha!";
                                        context.Response.Write(JsonConvert.SerializeObject(result));
                                        return;
                                    }
                                    else
                                    {
                                        if (context.Session["captcha"] != null && jsonData.captcha != context.Session["captcha"].ToString())
                                        {
                                            result.status = Constants.NUMBER_CODE.CAPTCHA_ERROR;
                                            result.msg = "Mã captcha không đúng!";
                                            context.Response.Write(JsonConvert.SerializeObject(result));
                                            return;
                                        }
                                    }
                                }

                                accountInfo = (UserInfo)context.Session["account"];
                                jsonData.senderID = accountInfo.MasterID;
                                if (string.IsNullOrEmpty(jsonData.senderID))
                                {
                                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                                    result.msg = "Không tìn thấy thông tin tài khoản";
                                    context.Response.Write(JsonConvert.SerializeObject(result));
                                    return;
                                }
                                jsonData.ip = UtilClass.GetIPAddress();
                                Logs.SaveLog(JsonConvert.SerializeObject(jsonData));
                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/TransferMoneyToAgency");
                                context.Response.Write(responseData);
                                return;
                            }
                        }
                        else
                        {
                            result.status = Constants.NUMBER_CODE.DATA_NULL;
                            result.msg = "Thông tin không được để trống";
                        }
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                        result.msg = "Không thể kết nối";
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR TRANFER_MONEY_TO_AGENCY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["TRANFER_MONEY_TO_AGENCY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void FIND_AGENCY(HttpContext context)
        {
            try
            {
                if (context.Session["FIND_AGENCY"] == null || (DateTime.Now - (DateTime)context.Session["FIND_AGENCY"]).TotalMilliseconds > 200)
                {
                    FindAgencyEntity findAgencyEntity = new FindAgencyEntity();
                    findAgencyEntity.param = context.Request.Form["param"];
                    findAgencyEntity.topN = 20;

                    accountInfo = (UserInfo)context.Session["account"];

                    findAgencyEntity.uwinID = accountInfo.MasterID;

                    Logs.SaveLog(JsonConvert.SerializeObject(findAgencyEntity));
                    if (string.IsNullOrEmpty(findAgencyEntity.param))
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = "Không có từ khóa tìm kiếm được nhập!";
                    }
                    else
                    {
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(findAgencyEntity), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/FindAgency");
                        var d = JsonConvert.DeserializeObject<ResultSearchAgrency>(responseData);
                        //{ "status":0,"msg":null,"data":[{"AgencyID":9,"DisplayName":"Đại Lý 1","AgencyCode":"daily1","Phone":"0962474560"}]}
                        //[{"CustomerID":31,"CustomerCode":"HC1900031","CompanyName":"MR-VIET CO LTD","CompanyName2":"MR-VIET CO LTD","TaxCode":"","Email":"","Phone":"","Contact":"TUAN","Contact2":"TUAN","CreateDate":"2019-07-03T08:59:03.983","Status":1,"Address":"21/1E NGUYEN ANH THU BA DIEM HOC MON","City":56,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":0,"LoaiHinhSX_ID":0,"LastUpdate":"2019-07-03T08:59:03.983"},{"CustomerID":30,"CustomerCode":"BD1900030","CompanyName":"MINH LONG","CompanyName2":"MINH LONG","TaxCode":"","Email":"","Phone":"","Contact":"TUAN","Contact2":"TUAN","CreateDate":"2019-07-02T09:24:20.28","Status":1,"Address":"KCN VIETNAM SINGAGPORE","City":8,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":0,"LastUpdate":"2019-07-02T09:24:20.28"},{"CustomerID":29,"CustomerCode":"BD1900029","CompanyName":"APPAREL","CompanyName2":"APPAREL","TaxCode":"","Email":"","Phone":"","Contact":"TUẤN","Contact2":"TUAN","CreateDate":"2019-07-01T17:03:25.523","Status":1,"Address":"46 DAI LO TU DO VSIP,THUAN AN ,BD","City":8,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":0,"LastUpdate":"2019-07-01T17:03:25.523"},{"CustomerID":28,"CustomerCode":"DN1900028","CompanyName":"NANGYANG","CompanyName2":"NANGYANG","TaxCode":"","Email":"","Phone":"","Contact":"TUẤN","Contact2":"TUAN","CreateDate":"2019-06-25T14:00:23.617","Status":1,"Address":"BLOCK C LONG KHANH,DONG NAI","City":17,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":0,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-25T14:00:23.617"},{"CustomerID":27,"CustomerCode":"BT1900027","CompanyName":"HOANG LOAN","CompanyName2":"HOANG LOAN","TaxCode":"","Email":"","Phone":"","Contact":"TUAN","Contact2":"TUAN","CreateDate":"2019-06-22T14:07:46.897","Status":0,"Address":"","City":7,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-22T14:29:22.227"},{"CustomerID":26,"CustomerCode":"BT1900026","CompanyName":"HOÀNG LOAN","CompanyName2":"HOANG LOAN","TaxCode":"","Email":"","Phone":"","Contact":"TUAN","Contact2":"TUAN","CreateDate":"2019-06-22T13:57:47.35","Status":1,"Address":"GIỒNG TRÔM ,BỂN TRE","City":7,"Country":84,"KM":0,"Address1":"","City1":7,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-22T14:28:58.757"},{"CustomerID":22,"CustomerCode":"HC1900022","CompanyName":"TRANG VANG","CompanyName2":"TRANG VANG","TaxCode":"","Email":"","Phone":"","Contact":"TUẤN","Contact2":"TUAN","CreateDate":"2019-06-13T09:55:48.3","Status":1,"Address":"26/1ATRẦN QUÝ CÁP ,BÌNH THẠNH","City":56,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-13T09:55:48.3"},{"CustomerID":19,"CustomerCode":"TG1900019","CompanyName":"ITOCHU(HỒNG ÂN)","CompanyName2":"ITOCHU(HONG AN)","TaxCode":"","Email":"","Phone":"","Contact":"TUẤN","Contact2":"TUAN","CreateDate":"2019-06-08T11:58:34.03","Status":1,"Address":"CAI LẬY,TIỀN GIANG","City":51,"Country":84,"KM":0,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":2,"LastUpdate":"2019-06-08T11:58:34.03"},{"CustomerID":13,"CustomerCode":"HC1900013","CompanyName":"TUYẾN HIỆP LỢI","CompanyName2":"TUYEN HIEP LOI","TaxCode":"","Email":"","Phone":"","Contact":"Ms HOA","Contact2":"Ms HOA","CreateDate":"2019-05-31T14:16:57.62","Status":1,"Address":"Ap 3, xã Phạm Văn Cội, Huyện Củ Chi, TP. HCM","City":56,"Country":84,"KM":130,"Address1":"","City1":0,"Country1":84,"KM1":0,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":1,"LastUpdate":"2019-05-31T14:17:20.997"},{"CustomerID":6,"CustomerCode":"HC1900006","CompanyName":"CTY TNHH TM DV TÚ PHÚ","CompanyName2":"CTY TNHH TM DV TU PHU","TaxCode":"0333345774","Email":"","Phone":"0988867676","Contact":"Anh Tú","Contact2":"Anh Tu","CreateDate":"2019-04-07T14:47:45.453","Status":1,"Address":"268 To Hien Thanh","City":56,"Country":84,"KM":10,"Address1":"80/23 Trinh Dinh Thao","City1":1,"Country1":84,"KM1":200,"Address2":"","City2":0,"Country2":84,"KM2":0,"LoaiDon_ID":1,"LoaiHinhSX_ID":1,"LastUpdate":"2019-06-01T00:59:40.683"}]
                        context.Response.Write(JsonConvert.SerializeObject(d.data));
                        return;
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR FIND_AGENCY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["FIND_AGENCY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void CHANGE_TRANSACTION_LIMIT(HttpContext context)
        {
            try
            {
                if (context.Session["CHANGE_TRANSACTION_LIMIT"] == null || (DateTime.Now - (DateTime)context.Session["CHANGE_TRANSACTION_LIMIT"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<ChangeLimitTransactionAgency>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                        var jsonData = JsonConvert.DeserializeObject<ChangeLimitTransactionAgency>(json);
                        
                        if (jsonData != null)
                        {
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));


                            if (string.IsNullOrEmpty(jsonData.limitTransaction.ToString()))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Cần phải nhập password cũ!";
                            }
                            else if (string.IsNullOrEmpty(jsonData.limitTransactionDaily.ToString()))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Cần phải nhập password mới!";
                            }
                            else if (string.IsNullOrEmpty(jsonData.captcha))
                            {
                                result.status = Constants.NUMBER_CODE.CAPTCHA_NULL;
                                result.msg = "Vui lòng nhập captcha!";
                            }
                            else
                            {
                                if (context.Session["captcha"] != null && jsonData.captcha != context.Session["captcha"].ToString())
                                {
                                    result.status = Constants.NUMBER_CODE.CAPTCHA_ERROR;
                                    result.msg = "Mã captcha không đúng!";
                                }
                                else
                                {

                                    UserInfo userInfo = (UserInfo)context.Session["account"];
                                    jsonData.uwinID = userInfo.MasterID;
                                    PayloadApi p = new PayloadApi()
                                    {
                                        clientIP = UtilClass.GetIPAddress(),
                                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                    };
                                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/ChangeLimitTransactionAgency");
                                    context.Response.Write(responseData);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            result.status = Constants.NUMBER_CODE.DATA_NULL;
                            result.msg = "Thông tin không được để trống";
                        }
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                        result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CHANGE_TRANSACTION_LIMIT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["CHANGE_TRANSACTION_LIMIT"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void CHANGE_PASSWORD(HttpContext context)
        {
            try
            {
                if (context.Session["CHANGE_PASSWORD"] == null || (DateTime.Now - (DateTime)context.Session["CHANGE_PASSWORD"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        var jsonData = JsonConvert.DeserializeObject<ChangePasswordAgency>(json);
                        if (jsonData != null)
                        {
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));
                            if (string.IsNullOrEmpty(jsonData.passwordOld))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Vui lòng nhập password cũ!";
                            }
                            else if (string.IsNullOrEmpty(jsonData.passwordNew))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Vui lòng nhập password mới!";
                            }
                            else if (string.IsNullOrEmpty(jsonData.rePasswordNew))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Vui lòng nhập lại password mới!";
                            }
                            else if (jsonData.passwordNew != jsonData.rePasswordNew)
                            {
                                result.status = Constants.NUMBER_CODE.PASS_INVALID;
                                result.msg = "Password mới và password nhập lại phải giống nhau!";
                            }
                            else if (string.IsNullOrEmpty(jsonData.captcha))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Vui lòng nhập captcha!";
                            }
                            else
                            {
                                if (context.Session["captcha"] != null && jsonData.captcha != context.Session["captcha"].ToString())
                                {
                                    result.status = Constants.NUMBER_CODE.CAPTCHA_ERROR;
                                    result.msg = "Mã captcha không đúng!";
                                }
                                else
                                {
                                    UserInfo userInfo = (UserInfo)context.Session["account"];
                                    jsonData.uwinID = userInfo.MasterID;
                                    PayloadApi p = new PayloadApi()
                                    {
                                        clientIP = UtilClass.GetIPAddress(),
                                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                    };
                                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/ChangePasswordAgency");
                                    context.Response.Write(responseData);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            result.status = Constants.NUMBER_CODE.DATA_NULL;
                            result.msg = "Thông tin không được để trống";
                        }
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                        result.msg = "Không thể kết nối";
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = "Thao tác quá nhanh! vui lòng thử lại";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR BUY_CASH: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["CHANGE_PASSWORD"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void GET_INFO_AGENCY(HttpContext context)
        {
            try
            {
                if (accountInfo.AgencyInfo != null)
                {
                    var json = new
                    {
                        uwinID = accountInfo.MasterID
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(json), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/GetAgencyInfo");

                    Result resGetData = JsonConvert.DeserializeObject<Result>(responseData);
                    string infoDecrypt = Encryptor.DecryptString(resGetData.data.ToString(), Constants.API_SECRETKEY);
                    AgencyInfoEntity agencyInfo = JsonConvert.DeserializeObject<AgencyInfoEntity>(infoDecrypt);
                    //resGetData.data = agencyInfo;
                    accountInfo.AgencyInfo = agencyInfo;
                    context.Session["account"] = accountInfo;
                    AgencyInfoEntity responseAgencyInfo = new AgencyInfoEntity();

                    responseAgencyInfo.agencyID = agencyInfo.agencyID;
                    responseAgencyInfo.agencyCode = agencyInfo.agencyCode;
                    responseAgencyInfo.email = agencyInfo.email;
                    responseAgencyInfo.phone = "*******" + agencyInfo.phone.Substring(7, 3);
                    responseAgencyInfo.displayName = agencyInfo.displayName;
                    responseAgencyInfo.balance = agencyInfo.balance;
                    responseAgencyInfo.balance_bonus = agencyInfo.balance_bonus;
                    responseAgencyInfo.balance_lock = agencyInfo.balance_bonus;
                    responseAgencyInfo.limitTransaction = agencyInfo.limitTransaction;
                    responseAgencyInfo.limitTransactionDaily = agencyInfo.limitTransactionDaily;
                    responseAgencyInfo.isOTP = agencyInfo.isOTP;
                    responseAgencyInfo.emailActive = agencyInfo.emailActive;
                    responseAgencyInfo.phoneActive = agencyInfo.phoneActive;
                    responseAgencyInfo.masterID = agencyInfo.masterID;
                    responseAgencyInfo.fb = agencyInfo.fb;
                    responseAgencyInfo.display = agencyInfo.display;
                    responseAgencyInfo.information = agencyInfo.information;
                    responseAgencyInfo.vippoint = agencyInfo.vippoint;
                    resGetData.data = responseAgencyInfo;
                    //agencyInfo.phone = "*******" + agencyInfo.phone.Substring(7, 3);
                    context.Response.Write(JsonConvert.SerializeObject(resGetData));
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = "Không có thông tin đại lý";
                    return;
                }
                
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR RESET_PASSWORD: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void RESET_PASSWORD(HttpContext context)
        {
            string otp = context.Request.Form["OTP"];
            string phone = context.Request.Form["phone"];
            try
            {
                if (string.IsNullOrEmpty(otp))
                {
                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = "Nhập OTP không chính xác";
                }
                else
                {
                    var json = new
                    {
                        phone = phone,
                        otp = otp
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(json), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Agency/ResetPasswordAgency");
                    context.Response.Write(responseData);
                    return;
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR RESET_PASSWORD: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void CHECK_FORGOT_PASSWORD(HttpContext context)
        {
            string phone = context.Request.Form["phone"];
            try
            {
                if (string.IsNullOrEmpty(phone))
                {
                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = "Vui lòng nhập số điện thoại";
                }
                else if (!UtilClass.IsPhoneNumber(phone))
                {
                    result.status = Constants.NUMBER_CODE.PHONE_INVALID;
                    result.msg = "Nhập số điện thoại không chính xác!";
                }
                else
                {
                    var json = new
                    {
                        phone = phone
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(json), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Agency/ForgotPasswordAgency");
                    context.Response.Write(responseData);
                    return;
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CHECK_FORGOT_PASSWORD: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void LOGIN_AGENCY(HttpContext context)
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
                    if (context.Session["captcha"] != null && captcha != context.Session["captcha"].ToString())
                    {
                        result.status = Constants.NUMBER_CODE.CAPTCHA_ERROR;
                        result.msg = "Mã captcha không đúng!";
                    }
                    else
                    {
                        var loginData = new
                        {
                            loginID = id,
                            password = pass,
                            ip = UtilClass.GetIPAddress()
                        };
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(loginData), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Agency/LoginAgency");
                        
                        var obj = JsonConvert.DeserializeObject<ResultLoginAgency>(responseData);

                        Logs.SaveLog("Login result: " + JsonConvert.SerializeObject(obj));
                        if (obj.status == 1)//login success
                        {
                            AgencyInfoEntity agency = JsonConvert.DeserializeObject<AgencyInfoEntity>(Encryptor.DecryptString(obj.data, Constants.API_SECRETKEY));

                            int accountID = Constants.ID_DAILY; //account group daily
                            var userData = manage.AccountModel.LoginWithAccountID(
                                accountID,
                                agency.masterID,
                                UtilClass.GetIPAddress(),
                                ref code
                            );
                            Logs.SaveLog("Get userInfo: " + JsonConvert.SerializeObject(userData));
                            if (code == 1)//login cms success
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
                                    userData.AgencyInfo = agency;
                                    context.Session["menuId"] = JsonConvert.DeserializeObject<List<int>>(menuId);
                                    context.Session["menuRule"] = JsonConvert.DeserializeObject<List<List<int>>>(menuRule);
                                    context.Session["account"] = userData;
                                }
                                result.status = Constants.NUMBER_CODE.LOGIN_SUCCESS;
                                result.msg = "Đăng nhập thành công";
                                result.data = "Page.aspx?m=26";
                            }
                            else
                            {
                                result.status = (Constants.NUMBER_CODE)code;
                                result.msg = "Đăng nhập không thành công!";
                                context.Session.Clear();
                                context.Session.Abandon();
                                UtilClass.RemoveCookie(context, "accountToken");
                            }
                        }
                        else
                        {
                            context.Response.Write(responseData);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR LOGIN: " + id + "\r\n" + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Tạo đại lý cấp 1 mới
        /// </summary>
        /// <param name="context"></param>
        //private void CREATE_AGENCY(HttpContext context)
        //{
        //    try
        //    {
        //        if (context.Session["CREATE_AGENCY"] == null || ((DateTime)context.Session["CREATE_AGENCY"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
        //        {
        //            string json = context.Request.Form["json"];
        //            if (!string.IsNullOrEmpty(json))
        //            {
        //                var jsonData = JsonConvert.DeserializeObject<AgencyEntity>(json);
        //                if(jsonData != null)
        //                {
        //                    if (string.IsNullOrEmpty(jsonData.agencyCode))
        //                    {
        //                        result.status = Constants.NUMBER_CODE.DATA_NULL;
        //                        result.msg = "Mã đại lý không được bỏ trống!";
        //                    }
        //                    else if (string.IsNullOrEmpty(jsonData.password))
        //                    {
        //                        result.status = Constants.NUMBER_CODE.DATA_NULL;
        //                        result.msg = "!";
        //                    }
        //                    else {
        //                        PayloadApi p = new PayloadApi()
        //                        {
        //                            clientIP = UtilClass.GetIPAddress(),
        //                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
        //                        };
        //                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Agency/CreateAgency");
        //                        context.Response.Write(responseData);
        //                        return;
        //                    }
        //                }
        //                else
        //                {
        //                    result.status = Constants.NUMBER_CODE.DATA_NULL;
        //                    result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
        //                }
        //            }
        //            else
        //            {
        //                result.status = Constants.NUMBER_CODE.DATA_NULL;
        //                result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
        //            }
        //        }
        //        else
        //        {
        //            result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
        //            result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.SaveError("ERROR CREATE_AGENCY: " + ex);
        //        result.status = Constants.NUMBER_CODE.ERROR_EX;
        //        result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
        //    }
        //    finally
        //    {
        //        context.Session["CREATE_AGENCY"] = DateTime.Now;
        //    }
        //    context.Response.Write(JsonConvert.SerializeObject(result));
        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class AgencyEntity
    {
        public string agencyCode;
        public string password;
        public string email;
        public string phone;
        public string displayName;
        public string ownerID;
        public string IP;
        public decimal limitTransaction;
        public decimal limitTransactionDaily;
        public int creatorID;
        public string creatorName;
        public string infomation;
        public bool display;
        public string FB;
    }

    public class ResultLoginAgency
    {
        public int status;
        public string msg;
        public string data;
    }

    public class AgencyInfoEntity
    {
        public int agencyID;
        public string agencyCode;
        public string email;
        public string phone;
        public string displayName;
        public decimal balance;
        public decimal balance_bonus;
        public decimal balance_lock;
        public decimal limitTransaction;
        public decimal limitTransactionDaily;
        public bool isOTP;
        public bool emailActive;
        public bool phoneActive;
        public string masterID;
        public string fb;
        public bool display;
        public string information;
        public float vippoint;
    }
    public class ChangePasswordAgency
    {
        public string uwinID;
        public string passwordOld;
        public string passwordNew;
        public string rePasswordNew;
        public string captcha;
    }
    public class ChangeLimitTransactionAgency
    {
        public string uwinID;
        public decimal limitTransaction;
        public decimal limitTransactionDaily;
        public bool isOTP;
        public string captcha;
    }
    public class TransferMoneyToAgency
    {
        public TransferMoneyToAgency()
        {
            OTP = "";
        }
        public string senderID;
        public string recipientID;
        public decimal amount;
        public string ip;
        public string reason;
        public string OTP;
        public string captcha;
    }
    public class TransferMoneyToUser
    {
        public TransferMoneyToUser()
        {
            OTP = "";
        }
        public string senderID;
        public long recipientID;
        public decimal amount;
        public string ip;
        public string reason;
        public string OTP;
        public string captcha;
    }

    public class FindAgencyEntity
    {
        public string param;
        public int topN;
        public string uwinID;
    }
    public class ResultSearchUserGame
    {
        public Constants.NUMBER_CODE status { get; set; }
        public string msg { get; set; }
        public List<UserGameInfo> data { get; set; }
    }
    public class UserGameInfo
    {
        public long AccountID;
        public string DisplayName;
        public string Username;
        public string Tel;
    }

    public class ActivePhoneAgency
    {
        public ActivePhoneAgency()
        {
            OTP = "";
        }
        public string uwinID;
        public string phone;
        public string OTP;
        public string ip;
    }
    public class ChangePhoneAgency
    {
        public ChangePhoneAgency()
        {
            OTP = "";
        }
        public string uwinID;
        public string phoneOld;
        public string phoneNew;
        public string OTP;
        public string ip;
        public string captcha;
    }
    public class UpdateInformationAgencyEntity
    {
        public string agencyID;
        public string information;
        public int creatorID;
        public string creatorName;
        public string ip;
    }
    public class UpdateDisplayAgencyEntity
    {
        public string agencyID;
        public bool display;
        public int creatorID;
        public string creatorName;
        public string ip;
    }
    public class UpdateFBLinkEntity
    {
        public string agencyID;
        public string fb;
        public int creatorID;
        public string creatorName;
        public string ip;
    }
    
}

