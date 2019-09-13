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
        UserInfo accountInfo;
        Result result = new Result();
        List<Constants.USER_PERMISSTIONS> uSER_RULEs = new List<Constants.USER_PERMISSTIONS>();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=utf-8";
            try
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

                Constants.REQUEST_AGENCY_TYPE requestType = (Constants.REQUEST_AGENCY_TYPE)int.Parse(context.Request.Form["type"]);
                switch (requestType)
                {
                    case Constants.REQUEST_AGENCY_TYPE.CREATE_AGENCY:
                        CREATE_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.LOCK_AGENCY:
                        LOCK_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.UNLOCK_AGENCY:
                        UNLOCK_AGENCY(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.AUTO_COMPLETE_SEARCH:
                        AUTO_COMPLETE_SEARCH(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.BUY_CASH:
                        BUY_CASH(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.VERIFIRE_CAPTCHA:
                        VERIFIRE_CAPTCHA(context);
                        break;
                    case Constants.REQUEST_AGENCY_TYPE.CHANGE_DISPLAY_AGENCY:
                        CHANGE_DISPLAY_AGENCY(context);
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
                    else if (!bool.TryParse(context.Request.Form["display"], out display))
                    {
                        result.status = Constants.NUMBER_CODE.TRYPARSE_ERROR;
                        result.msg = "Dữ liệu truyền vào không đúng!";
                    }
                    else if (string.IsNullOrEmpty(context.Request.Form["agencyID"]))
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = "Tài khoản không tồn tại!";
                    }
                    
                    else
                    {
                        display = bool.Parse(context.Request.Form["display"]);
                        jsonData.agencyID = context.Request.Form["agencyID"];
                        jsonData.display = display;
                        jsonData.creatorID = accountInfo.AccountId;
                        jsonData.creatorName = accountInfo.UserName;
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

        private void VERIFIRE_CAPTCHA(HttpContext context)
        {
            try
            {
                if (context.Session["VERIFIRE_CAPTCHA"] == null || (DateTime.Now - (DateTime)context.Session["VERIFIRE_CAPTCHA"]).TotalMilliseconds > 200)
                {
                    string captcha = context.Request.Form["captcha"];
                    if (context.Session["captcha"] == null)
                    {
                        context.Session["captcha"] = "";
                    }
                    if (captcha != context.Session["captcha"].ToString())
                    {
                        result.status = Constants.NUMBER_CODE.CAPTCHA_ERROR;
                        result.msg = "Mã captcha không đúng!";
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.SUCCESS;
                        result.msg = "Verifire success!";
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
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["VERIFIRE_CAPTCHA"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void BUY_CASH(HttpContext context)
        {
            try
            {
                if (context.Session["BUY_CASH"] == null || (DateTime.Now - (DateTime)context.Session["BUY_CASH"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    decimal[] rulerAmount = { 20000000,50000000, 100000000, 200000000, 500000000 , 1000000000 };
                    if (!string.IsNullOrEmpty(json))
                    {
                        var jsonData = JsonConvert.DeserializeObject<AddMoneyAgencyEntity>(json);
                        if (jsonData != null)
                        {
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));
                            if (string.IsNullOrEmpty(jsonData.agencyID))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Mã đại lý không được trống!";
                            }
                            else if (!rulerAmount.Contains(jsonData.amount))
                            {
                                result.status = Constants.NUMBER_CODE.AMOUNT_WRONG;
                                result.msg = "Số tiền không hợp lệ!";
                            }
                            else
                            {
                                jsonData.IP = UtilClass.GetIPAddress();
                                jsonData.creatorID = accountInfo.AccountId;
                                jsonData.creatorName = accountInfo.UserName;

                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/AddMoneyAgency");
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
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["BUY_CASH"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void AUTO_COMPLETE_SEARCH(HttpContext context)
        {
            try
            {
                if (context.Session["AUTO_COMPLETE_SEARCH"] == null || (DateTime.Now - (DateTime)context.Session["AUTO_COMPLETE_SEARCH"]).TotalMilliseconds > 200)
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
                Logs.SaveError("ERROR AUTO_COMPLETE_SEARCH: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["AUTO_COMPLETE_SEARCH"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Mở khóa đại lý
        /// </summary>
        /// <param name="context"></param>
        private void UNLOCK_AGENCY(HttpContext context)
        {
            try
            {
                if (context.Session["UNLOCK_AGENCY"] == null || (DateTime.Now -(DateTime)context.Session["UNLOCK_AGENCY"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        var jsonData = JsonConvert.DeserializeObject<UnLockAgencyEntity>(json);
                        if (jsonData != null)
                        {
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));
                            if (string.IsNullOrEmpty(jsonData.agencyID))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Mã đại lý không được trống!";
                            }
                            else
                            {
                                jsonData.creatorID = accountInfo.AccountId;
                                jsonData.creatorName = accountInfo.UserName;

                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/UnLockAgency");
                                context.Response.Write(responseData);
                                return;
                            }
                        }
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
                Logs.SaveError("ERROR UNLOCK_AGENCY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["UNLOCK_AGENCY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Khóa đại lý
        /// </summary>
        /// <param name="context"></param>
        private void LOCK_AGENCY(HttpContext context)
        {
            try
            {
                if (context.Session["LOCK_AGENCY"] == null || (DateTime.Now- (DateTime)context.Session["LOCK_AGENCY"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        var jsonData = JsonConvert.DeserializeObject<LockAgencyEntity>(json);
                        if (jsonData != null)
                        {
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));
                            if (string.IsNullOrEmpty(jsonData.agencyID))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Mã đại lý không được trống!";
                            }
                            else
                            {
                                jsonData.creatorID = accountInfo.AccountId;
                                jsonData.creatorName = accountInfo.UserName;

                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/Agency/LockAgency");
                                context.Response.Write(responseData);
                                return;
                            }
                        }
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
                Logs.SaveError("ERROR LOCK_AGENCY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["LOCK_AGENCY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }


        /// <summary>
        /// Tạo đại lý cấp 1 mới
        /// </summary>
        /// <param name="context"></param>
        private void CREATE_AGENCY(HttpContext context)
        {
            short debug = 0;
            try
            {
                if (context.Session["CREATE_AGENCY"] == null || (DateTime.Now - (DateTime)context.Session["CREATE_AGENCY"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    debug = 1;
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        debug = 2;
                        try
                        {
                            JsonConvert.DeserializeObject<AgencyEntity>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                        var jsonData = JsonConvert.DeserializeObject<AgencyEntity>(json);
                        if (jsonData != null)
                        {
                            debug = 3;
                            if (string.IsNullOrEmpty(jsonData.agencyCode))
                            {
                                debug = 301;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Mã đại lý không được bỏ trống!";
                            }
                            else if(jsonData.agencyCode.Length < 6 || jsonData.agencyCode.Length >10)
                            {
                                debug = 302;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Mã đại lý phải từ 6-10 ký tự";
                            }
                            else if (string.IsNullOrEmpty(jsonData.password))
                            {
                                debug = 303;
                                result.status = Constants.NUMBER_CODE.INFO_CREATE_AGENCY_VALI;
                                result.msg = "Password không được để trống";
                            }
                            else if (jsonData.password.Length <6 && jsonData.password.Length >20)
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

                            else {
                                debug = 310;

                                jsonData.IP = UtilClass.GetIPAddress();
                                jsonData.creatorID = accountInfo.AccountId;
                                jsonData.creatorName = accountInfo.UserName;
                                jsonData.limitTransaction = Constants.limitTransaction;
                                jsonData.limitTransactionDaily = Constants.limitTransactionDaily;

                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Agency/CreateAgency");
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
                Logs.SaveError("ERROR CREATE_AGENCY: [debug]:" +debug + "\n,\n" + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                Logs.SaveError("[debug]:" + debug);
                context.Session["CREATE_AGENCY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }



    #region EnityClass
    public class AddMoneyAgencyEntity
    {
        public AddMoneyAgencyEntity()
        {
            amount = 0;
        }
        public string agencyID;
        public string IP;
        public decimal amount; // menh gia nap
        public decimal bonus; // tam thời chưa sd đến
        public int creatorID;
        public string creatorName;
        public string reason; // nội dung nạp tiền
    }
    public class FindAgencyEntity
    {
        public string param;
        public int topN;
        public string uwinID="";
    }
    public class AgencyEntity
    {
        public AgencyEntity()
        {
            FB = "";
        }
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

    public class LockAgencyEntity
    {
        public string agencyID;
        public string note; //ghi chú khi khoa tai khoan của đại lý
        public int creatorID;
        public string creatorName;
    }

    public class UnLockAgencyEntity
    {
        public string agencyID;
        public int creatorID;
        public string creatorName;
    }

    public class UpdateDisplayAgencyEntity
    {
        public string agencyID;
        public bool display;
        public int creatorID;
        public string creatorName;
        public string ip;
    }
    #endregion


}