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
    /// Summary description for API_GameAccount
    /// </summary>
    public class API_GameAccount : IHttpHandler, IRequiresSessionState
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

                Constants.REQUEST_GAME_ACOUNT_TYPE requestType = (Constants.REQUEST_GAME_ACOUNT_TYPE)int.Parse(context.Request.Form["type"]);
                switch (requestType)
                {
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.LOCK_GAME_ACCOUNT:
                        LOCK_GAME_ACCOUNT(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.UNLOCK_GAME_ACCOUNT:
                        UNLOCK_GAME_ACCOUNT(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.LOCK_CHAT_GAME_ACCOUNT:
                        LOCK_CHAT_GAME_ACCOUNT(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.UNLOCK_CHAT_GAME_ACCOUNT:
                        UNLOCK_CHAT_GAME_ACCOUNT(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.CREATE_SCHEME_NOTIFICATION:
                        CREATE_SCHEME_NOTIFICATION(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.UPDATE_SCHEME_NOTIFICATION:
                        UPDATE_SCHEME_NOTIFICATION(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.DELETE_SCHEME_NOTIFICATION:
                        DELETE_SCHEME_NOTIFICATION(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.CREATE_EVENT_GIFTCODE:
                        CREATE_EVENT_GIFTCODE(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.UPDATE_EVENT_GIFTCODE:
                        UPDATE_EVENT_GIFTCODE(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.DELETE_EVENT_GIFTCODE:
                        DELETE_EVENT_GIFTCODE(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.EXCEPT_FUND_GAME:
                        EXCEPT_FUND_GAME(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.ACCEPT_CARD:
                        ACCEPT_CARD(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.DELETE_CASH_OUT_CARD:
                        DELETE_CASH_OUT_CARD(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.DELETE_FAIL_TRANSACTION_CARD:
                        DELETE_FAIL_TRANSACTION_CARD(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.INPUT_CARD:
                        INPUT_CARD(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.CONFIG_CARD:
                        CONFIG_CARD(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.SET_JACKPOT_PRIZE:
                        SET_JACKPOT_PRIZE(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.CONFIG_BOT:
                        CONFIG_BOT(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.FIND_GAME_ACCOUNT:
                        FIND_GAME_ACCOUNT(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.ADD_MONEY_USER:
                        ADD_MONEY_USER(context);
                        break;
                    case Constants.REQUEST_GAME_ACOUNT_TYPE.DEDUCT_GOLD_USER:
                        DEDUCT_GOLD_USER(context);
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
        private void DEDUCT_GOLD_USER(HttpContext context)
        {
            try
            {
                if (context.Session["DEDUCT_GOLD_USER"] == null || (DateTime.Now - (DateTime)context.Session["DEDUCT_GOLD_USER"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<DeductGoldUser>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<DeductGoldUser>(json);
                        if (jsonData != null)
                        {
                            if (jsonData.Amount < 0)
                            {
                                result.status = Constants.NUMBER_CODE.ADD_MONEY_USER_VALI;
                                result.msg = "Dữ liệu truyền vào phải từ 0 trờ lên";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else
                            {
                                jsonData.UserID = accountInfo.AccountId;
                                jsonData.UserName = accountInfo.UserName;
                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/DeductGoldUser");
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
                Logs.SaveError("ERROR DEDUCT_GOLD_USER: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["ADD_MONEY_USER"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }
        private void ADD_MONEY_USER(HttpContext context)
        {
            try { 
                if (context.Session["ADD_MONEY_USER"] == null || (DateTime.Now - (DateTime)context.Session["ADD_MONEY_USER"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<AddMoneyUser>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<AddMoneyUser>(json);
                        if (jsonData != null)
                        {
                            if (jsonData.Amount < 0)
                            {
                                result.status = Constants.NUMBER_CODE.ADD_MONEY_USER_VALI;
                                result.msg = "Dữ liệu truyền vào phải từ 0 trờ lên";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else
                            {
                                jsonData.SenderID = accountInfo.AccountId.ToString();
                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/AddMoneyUser");
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
                Logs.SaveError("ERROR ADD_MONEY_USER: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["ADD_MONEY_USER"] = DateTime.Now;
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

        private void CONFIG_BOT(HttpContext context)
        {
            try
            {
                if (context.Session["CONFIG_BOT"] == null || (DateTime.Now - (DateTime)context.Session["CONFIG_BOT"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<UpdateBotConfigLuckDice>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<UpdateBotConfigLuckDice>(json);
                        if (jsonData != null)
                        {
                            if (jsonData.MinBot < 0 || jsonData.MaxBot < 0 || jsonData.NumRichBot < 0 || jsonData.NumNormalBot < 0
                                || jsonData.NumPoorBot < 0 || jsonData.VipChangeRate < 0 || jsonData.NorChangeRate < 0
                                || jsonData.PoorChangeRate < 0 || jsonData.MinTimeChange < 0 || jsonData.MaxTimeChange < 0 )
                            {
                                result.status = Constants.NUMBER_CODE.CONFIG_BOT_VALI;
                                result.msg = "Dữ liệu truyền vào phải từ 0 trờ lên";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (jsonData.MinBot > jsonData.MaxBot)
                            {
                                result.status = Constants.NUMBER_CODE.CONFIG_BOT_VALI;
                                result.msg = "Minbot không được lớn hơn Maxbot";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (jsonData.MaxBot != (jsonData.NumRichBot+jsonData.NumNormalBot + jsonData.NumPoorBot))
                            {
                                result.status = Constants.NUMBER_CODE.CONFIG_BOT_VALI;
                                result.msg = "MaxBot phải bằng NumRichBot + NumNormalBot+ NumPoorBot";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else
                            {
                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/UpdateBotConfigLuckDice");
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
                Logs.SaveError("ERROR CONFIG_BOT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["CONFIG_BOT"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void SET_JACKPOT_PRIZE(HttpContext context)
        {
            try
            {
                if (context.Session["SET_JACKPOT_PRIZE"] == null || (DateTime.Now - (DateTime)context.Session["SET_JACKPOT_PRIZE"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<SetJackpotPrize>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<SetJackpotPrize>(json);
                        if (jsonData != null)
                        {
                            if (string.IsNullOrEmpty(jsonData.AccountName))
                            {
                                result.status = Constants.NUMBER_CODE.DATA_NULL;
                                result.msg = "Tên tài khoản trúng không được bỏ trống";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (jsonData.AccountName.Length>30)
                            {
                                result.status = Constants.NUMBER_CODE.ACCOUNT_NAME_VALI;
                                result.msg = "Tên tài khoản không được quá 30 ký tự";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else
                            {
                                //@_GameId = 1 -- Nong trai
                                //@_GameId = 2 -- Mafia
                                //@_GameId = 3 --minipoker
                                //@_GameId = 4 -- vua bao
                                //@_GameId = 6 --than quat
                                //@_GameId = 8 -- hai vuong


                                //jsonData.AccountName = accountInfo.UserName;
                                //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                                //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));


                                jsonData.CreatorId = accountInfo.AccountId.ToString();

                                PayloadApi p = new PayloadApi()
                                {
                                    clientIP = UtilClass.GetIPAddress(),
                                    data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                                };
                                var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/SetJackpotPrize");
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
                Logs.SaveError("ERROR SET_JACKPOT_PRIZE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["SET_JACKPOT_PRIZE"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }



        /// <summary>
        /// Cấu hình thẻ nạp
        /// </summary>
        /// <param name="context"></param>
        private void CONFIG_CARD(HttpContext context)
        {
            try
            {
                if (context.Session["CONFIG_CARD"] == null || (DateTime.Now - (DateTime)context.Session["CONFIG_CARD"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<ConfigCard>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<ConfigCard>(json);
                        if (jsonData != null)
                        {
                            //jsonData.AccountName = accountInfo.UserName;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            jsonData.PayOrderConfig = jsonData.Pay + "|0";

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/ConfigCard");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR CONFIG_CARD: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["CONFIG_CARD"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Nạp thẻ
        /// </summary>
        /// <param name="context"></param>
        private void INPUT_CARD(HttpContext context)
        {
            try
            {
                if (context.Session["INPUT_CARD"] == null || (DateTime.Now - (DateTime)context.Session["INPUT_CARD"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<InputCard>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                        var jsonData = JsonConvert.DeserializeObject<InputCard>(json);
                        if (jsonData != null)
                        {
                            //jsonData.AccountName = accountInfo.UserName;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/InputCard");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR INPUT_CARD: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["INPUT_CARD"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Xóa giao dịch mua thẻ lỗi
        /// </summary>
        /// <param name="context"></param>
        private void DELETE_FAIL_TRANSACTION_CARD(HttpContext context)
        {
            try
            {
                if (context.Session["DELETE_FAIL_TRANSACTION_CARD"] == null || (DateTime.Now - (DateTime)context.Session["DELETE_FAIL_TRANSACTION_CARD"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<DeleteFailTransactionCard>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<DeleteFailTransactionCard>(json);
                        if (jsonData != null)
                        {
                            //jsonData.AccountName = accountInfo.UserName;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/DeleteFailTransactionCard");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR DELETE_FAIL_TRANSACTION_CARD: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["DELETE_FAIL_TRANSACTION_CARD"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }
        /// <summary>
        /// Xóa yêu cầu rút tiền thẻ
        /// </summary>
        /// <param name="context"></param>
        private void DELETE_CASH_OUT_CARD(HttpContext context)
        {
            try
            {
                if (context.Session["DELETE_CASH_OUT_CARD"] == null || (DateTime.Now - (DateTime)context.Session["DELETE_CASH_OUT_CARD"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<DeleteCashOutCard>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<DeleteCashOutCard>(json);
                        if (jsonData != null)
                        {
                            //jsonData.AccountName = accountInfo.UserName;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/DeleteCashOutCard");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR DELETE_CASH_OUT_CARD: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["DELETE_CASH_OUT_CARD"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }
        /// <summary>
        /// Duyệt thẻ
        /// </summary>
        /// <param name="context"></param>
        private void ACCEPT_CARD(HttpContext context)
        {
            try
            {
                if (context.Session["ACCEPT_CARD"] == null || (DateTime.Now - (DateTime)context.Session["ACCEPT_CARD"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<AcceptCard>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<AcceptCard>(json);
                        if (jsonData != null)
                        {
                            //jsonData.AccountName = accountInfo.UserName;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            jsonData.AcceptorID = accountInfo.AccountId.ToString();
                            jsonData.AcceptorName = accountInfo.UserName;

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/AcceptCard");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR ACCEPT_CARD: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["ACCEPT_CARD"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void EXCEPT_FUND_GAME(HttpContext context)
        {
            try
            {
                if (context.Session["EXCEPT_FUND_GAME"] == null || (DateTime.Now - (DateTime)context.Session["EXCEPT_FUND_GAME"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<ExceptFundGame>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<ExceptFundGame>(json);
                        if (jsonData != null)
                        {
                            jsonData.AccountName = accountInfo.UserName;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/ExceptFundGame");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR EXCEPT_FUND_GAME: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["EXCEPT_FUND_GAME"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void DELETE_EVENT_GIFTCODE(HttpContext context)
        {
            try
            {
                if (context.Session["DELETE_EVENT_GIFTCODE"] == null || (DateTime.Now - (DateTime)context.Session["DELETE_EVENT_GIFTCODE"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<DeleteEventGiftCode>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<DeleteEventGiftCode>(json);
                        if (jsonData != null)
                        {
                            //jsonData.Author = accountInfo.AccountId;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/DeleteEventGiftCode");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR DELETE_EVENT_GIFTCODE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["DELETE_EVENT_GIFTCODE"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void UPDATE_EVENT_GIFTCODE(HttpContext context)
        {
            try
            {
                if (context.Session["UPDATE_EVENT_GIFTCODE"] == null || (DateTime.Now - (DateTime)context.Session["UPDATE_EVENT_GIFTCODE"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<UpdateEventGiftCode>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<UpdateEventGiftCode>(json);
                        if (jsonData != null)
                        {
                            //jsonData.Author = accountInfo.AccountId;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/UpdateEventGiftCode");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR UPDATE_EVENT_GIFTCODE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["UPDATE_EVENT_GIFTCODE"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void CREATE_EVENT_GIFTCODE(HttpContext context)
        {
            try
            {
                if (context.Session["CREATE_EVENT_GIFTCODE"] == null || (DateTime.Now - (DateTime)context.Session["CREATE_EVENT_GIFTCODE"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<CreateEventGiftCode>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<CreateEventGiftCode>(json);
                        if (jsonData != null)
                        {
                            if (string.IsNullOrEmpty(jsonData.Name))
                            {
                                result.status = Constants.NUMBER_CODE.EVENT_GIFTCODE_VALI;
                                result.msg = "Tên giftcode không được để trống";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (jsonData.Name.Length > 200)
                            {
                                result.status = Constants.NUMBER_CODE.EVENT_GIFTCODE_VALI;
                                result.msg = "Tên giftcode không được lớn hơn 500 ký tự";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (string.IsNullOrEmpty(jsonData.Prefix))
                            {
                                result.status = Constants.NUMBER_CODE.EVENT_GIFTCODE_VALI;
                                result.msg = "Tiền tố giftcode không được để trống";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (jsonData.Prefix.Length > 5)
                            {
                                result.status = Constants.NUMBER_CODE.EVENT_GIFTCODE_VALI;
                                result.msg = "Tiền tố giftcode không được lớn hơn 5 ký tự";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            jsonData.AgencyId = 0;
                            jsonData.Created = accountInfo.AccountId;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/CreateEventGiftCode");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR CREATE_EVENT_GIFTCODE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["CREATE_EVENT_GIFTCODE"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void DELETE_SCHEME_NOTIFICATION(HttpContext context)
        {
            try
            {
                if (context.Session["DELETE_SCHEME_NOTIFICATION"] == null || (DateTime.Now - (DateTime)context.Session["DELETE_SCHEME_NOTIFICATION"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<DeleteSchemeNotificationGameEnity>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<DeleteSchemeNotificationGameEnity>(json);
                        if (jsonData != null)
                        {
                            //jsonData.Author = accountInfo.AccountId;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/DeleteSchemeNotificationGame");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR DELETE_SCHEME_NOTIFICATION: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["DELETE_SCHEME_NOTIFICATION"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void UPDATE_SCHEME_NOTIFICATION(HttpContext context)
        {
            try
            {
                if (context.Session["UPDATE_SCHEME_NOTIFICATION"] == null || (DateTime.Now - (DateTime)context.Session["UPDATE_SCHEME_NOTIFICATION"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<UpdateSchemeNotificationGameEnity>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<UpdateSchemeNotificationGameEnity>(json);
                        if (jsonData != null)
                        {
                            if (string.IsNullOrEmpty(jsonData.Message))
                            {
                                result.status = Constants.NUMBER_CODE.NOTIFICATION_VALI;
                                result.msg = "Nội dung thông báo không được để trống";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (jsonData.Message.Length > 500)
                            {
                                result.status = Constants.NUMBER_CODE.NOTIFICATION_VALI;
                                result.msg = "Nội dung thông báo không được lớn hơn 500 ký tự";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (jsonData.Title.Length > 250)
                            {
                                result.status = Constants.NUMBER_CODE.NOTIFICATION_VALI;
                                result.msg = "Title thông báo không được lớn hơn 250 ký tự";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            //jsonData.Author = accountInfo.AccountId;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/UpdateSchemeNotificationGame");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR UPDATE_SCHEME_NOTIFICATION: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["UPDATE_SCHEME_NOTIFICATION"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void CREATE_SCHEME_NOTIFICATION(HttpContext context)
        {
            try
            {
                if (context.Session["CREATE_SCHEME_NOTIFICATION"] == null || (DateTime.Now - (DateTime)context.Session["CREATE_SCHEME_NOTIFICATION"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<CreateSchemeNotificationGameEnity>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<CreateSchemeNotificationGameEnity>(json);
                        if (jsonData != null)
                        {

                            if (string.IsNullOrEmpty(jsonData.Message))
                            {
                                result.status = Constants.NUMBER_CODE.NOTIFICATION_VALI;
                                result.msg = "Nội dung thông báo không được để trống";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (jsonData.Message.Length >500)
                            {
                                result.status = Constants.NUMBER_CODE.NOTIFICATION_VALI;
                                result.msg = "Nội dung thông báo không được lớn hơn 500 ký tự";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            else if (jsonData.Title.Length > 250)
                            {
                                result.status = Constants.NUMBER_CODE.NOTIFICATION_VALI;
                                result.msg = "Title thông báo không được lớn hơn 250 ký tự";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }

                            //jsonData.Author = accountInfo.AccountId;
                            //jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            //Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/CreateSchemeNotificationGame");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR CREATE_SCHEME_NOTIFICATION: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["CREATE_SCHEME_NOTIFICATION"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }


        /// <summary>
        /// Mở khóa chat game
        /// </summary>
        /// <param name="context"></param>
        private void UNLOCK_CHAT_GAME_ACCOUNT(HttpContext context)
        {
            try
            {
                if (context.Session["UNLOCK_CHAT_GAME_ACCOUNT"] == null || (DateTime.Now - (DateTime)context.Session["UNLOCK_CHAT_GAME_ACCOUNT"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<UnlockChatAccountGameEnity>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<UnlockChatAccountGameEnity>(json);
                        if (jsonData != null)
                        {
                            jsonData.Author = accountInfo.AccountId;
                            jsonData.Reason = "Tài khoản mở khóa chat: " + accountInfo.UserName;

                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/UnlockChatAccountGame");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR UNLOCK_CHAT_GAME_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["UNLOCK_CHAT_GAME_ACCOUNT"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Khóa chat game
        /// </summary>
        /// <param name="context"></param>
        private void LOCK_CHAT_GAME_ACCOUNT(HttpContext context)
        {
            try
            {
                if (context.Session["LOCK_CHAT_GAME_ACCOUNT"] == null || (DateTime.Now - (DateTime)context.Session["LOCK_CHAT_GAME_ACCOUNT"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<LockChatAccountGameEnity>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<LockChatAccountGameEnity>(json);
                        if (jsonData != null)
                        {
                            jsonData.Author = accountInfo.AccountId;
                            jsonData.Reason = "Tài khoản khóa chat: " + accountInfo.UserName + ", Ghi chú: " + jsonData.Reason;
                            if (jsonData.Reason.Length > 500)
                            {
                                result.status = Constants.NUMBER_CODE.LOCK_ACCOUNT_GAME_VALI;
                                result.msg = "Nội dung thông báo không được để trống";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/LockChatAccountGame");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR LOCK_CHAT_GAME_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["LOCK_CHAT_GAME_ACCOUNT"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Mở khóa đăng nhập game
        /// </summary>
        /// <param name="context"></param>
        private void UNLOCK_GAME_ACCOUNT(HttpContext context)
        {
            try
            {
                if (context.Session["UNLOCK_GAME_ACCOUNT"] == null || (DateTime.Now - (DateTime)context.Session["UNLOCK_GAME_ACCOUNT"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<UnlockAccountGameEnity>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<UnlockAccountGameEnity>(json);
                        if (jsonData != null)
                        {
                            jsonData.Author = accountInfo.AccountId;
                            jsonData.Reason = "Tài khoản mở khóa: " + accountInfo.UserName;

                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/UnlockAccountGame");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR UNLOCK_GAME_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["UNLOCK_GAME_ACCOUNT"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Khóa đăng nhập game
        /// </summary>
        /// <param name="context"></param>
        private void LOCK_GAME_ACCOUNT(HttpContext context)
        {
            try
            {
                if (context.Session["LOCK_GAME_ACCOUNT"] == null || (DateTime.Now - (DateTime)context.Session["LOCK_GAME_ACCOUNT"]).TotalMilliseconds > Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<LockAccountGameEnity>(json);
                        }
                        catch (Exception)
                        {
                            result.status = Constants.NUMBER_CODE.ERROR_EX;
                            result.msg = "Sai thông tin nhập vào";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }

                        var jsonData = JsonConvert.DeserializeObject<LockAccountGameEnity>(json);
                        if (jsonData != null)
                        {
                            jsonData.Author = accountInfo.AccountId;
                            jsonData.Reason = "Tài khoản khóa: " + accountInfo.UserName + ", Ghi chú: " + jsonData.Reason;
                            if (jsonData.Reason.Length > 500)
                            {
                                result.status = Constants.NUMBER_CODE.LOCK_ACCOUNT_GAME_VALI;
                                result.msg = "Nội dung thông báo không được để trống";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            Logs.SaveLog(JsonConvert.SerializeObject(jsonData));

                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "api/v1/GameAccount/LockAccountGame");
                            context.Response.Write(responseData);
                            return;
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
                Logs.SaveError("ERROR LOCK_GAME_ACCOUNT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["LOCK_GAME_ACCOUNT"] = DateTime.Now;
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


        #region Enity class
        public class LockAccountGameEnity
        {
            public long AccountID;
            public string Reason;
            public int Author;
        }

        public class UnlockAccountGameEnity
        {
            public long AccountID;
            public string Reason;
            public int Author;
        }

        public class LockChatAccountGameEnity
        {
            public long AccountID;
            public string Reason;
            public int Author;
        }

        public class UnlockChatAccountGameEnity
        {
            public long AccountID;
            public string Reason;
            public int Author;
        }

        public class CreateSchemeNotificationGameEnity
        {
            public CreateSchemeNotificationGameEnity()
            {
                Title = "";
                Platform = "ALL";
            }
            public string Title;
            public string Message;
            public string Platform;
            public DateTime DateSend;
            public string Loop;
            public string Status;
        }

        public class UpdateSchemeNotificationGameEnity
        {
            public UpdateSchemeNotificationGameEnity()
            {
                Title = "";
                Platform = "ALL";
            }
            public int Id;
            public string Title;
            public string Message;
            public string Platform;
            public DateTime DateSend;
            public string Loop;
            public string Status;
        }

        public class DeleteSchemeNotificationGameEnity
        {
            public int Id;
        }

        public class CreateEventGiftCode
        {
            public CreateEventGiftCode()
            {
                Type = 0;
                Created = 0;
            }
            public string Name;
            public int Created;
            public long Price;
            public int Type;
            public int AgencyId;
            public int Qty;
            public string Prefix;
            public DateTime Expired;
        }
        public class DeleteEventGiftCode
        {
            public string ID;
        }

        public class UpdateEventGiftCode
        {
            public int ID;
            public DateTime Expired;
        }
        public class ExceptFundGame
        {
            public int GameID;
            public int RoomID;
            public long Value;
            public string AccountName;
        }
        public class AcceptCard
        {
            public long CardID;
            public string AcceptorID;
            public string AcceptorName;
        }
        public class DeleteCashOutCard
        {
            public long CardID;
        }
        public class DeleteFailTransactionCard
        {
            public long ID;
        }

        public class CardObject
        {
            public string ProviderCode { get; set; }
            public string Serial { get; set; }
            public string PinCode { get; set; }
            public int Amount { get; set; }
        }
        public class ConfigCard
        {
            public int ID;
            public bool Enable;
            public int Promotion;
            public int CashoutRate;
            public bool EnableCashout;
            public int TopupRate;
            public int PromotionCashout;
            public string PayOrderConfig;
            public int Pay;
        }
        public class SetJackpotPrize
        {
            public int GameId;
            public int RoomId;
            public string AccountName;
            public long AccountID;
            public string CreatorId;
        }
        public class UpdateBotConfigLuckDice
        {
            public int MinBot;
            public int MaxBot;
            public int NumRichBot;
            public int NumNormalBot;
            public int NumPoorBot;
            public int VipChangeRate;
            public int NorChangeRate;
            public int PoorChangeRate;
            public int MinTimeChange;
            public int MaxTimeChange;
        }
        public class InputCard
        {
            public int CardType;
            public int Amount;
            public int Qty;
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
       
        public class AddMoneyUser
        {
            public AddMoneyUser()
            {
                Reason = "";
            }
            public long UserID;
            public string Reason;
            public int Amount;
            public string SenderID;
        }
        public class DeductGoldUser
        {
            public int ID;
            public long AccountId;
            public long Amount;
            public string Description;
            public string UserName;
            public int UserID;
            //public string Balance;
        }
        #endregion
    }
}