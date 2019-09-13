using CMS_Tools.Lib;
using CMS_Tools.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CMS_Tools.Apis
{
    /// <summary>
    /// Summary description for API_Customer
    /// </summary>
    public class API_Customer : IHttpHandler, IRequiresSessionState
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

                Constants.REQUEST_TYPE requestType = (Constants.REQUEST_TYPE)int.Parse(context.Request.Form["type"]);
                switch (requestType)
                {
                    case Constants.REQUEST_TYPE.API_GET_GIACONGDONGDAN:
                        API_GET_GIACONGDONGDAN(context);
                        break;
                    case Constants.REQUEST_TYPE.API_FIND_CUSTOMERS_BY_ORDER:
                        API_FIND_CUSTOMERS_BY_ORDER(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_CUSTOMER_BY_CODE:
                        API_GET_CUSTOMER_BY_CODE(context);
                        break;
                    case Constants.REQUEST_TYPE.API_FIND_CUSTOMERS:
                        API_FIND_CUSTOMERS(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_LOAISONG:
                        API_GET_LOAISONG(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_CHATLIEU:
                        API_GET_CHATLIEU(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_KIEUTHUNG:
                        API_GET_KIEUTHUNG(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_LOAIDONHANG:
                        API_GET_LOAIDONHANG(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_LOAIHINHSX:
                        API_GET_LOAIHINHSX(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_NHACUNGCAP:
                        API_GET_NHACUNGCAP(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_CUSTOMER:
                        API_GET_CUSTOMER(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_COUNTRY:
                        API_GET_COUNTRY(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_PROVINCE:
                        API_GET_PROVINCE(context);
                        break;
                    case Constants.REQUEST_TYPE.API_CREATE_CUSTOMER:
                        API_CREATE_CUSTOMER(context);
                        break;
                    case Constants.REQUEST_TYPE.API_UPDATE_CUSTOMER:
                        API_UPDATE_CUSTOMER(context);
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

        private void API_GET_GIACONGDONGDAN(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_GIACONGDONGDAN"] == null || ((DateTime)context.Session["API_GET_GIACONGDONGDAN"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    RequestInfo send = new RequestInfo()
                    {
                        clientIP = UtilClass.GetIPAddress()
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetGiaCongDongDan");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_GIACONGDONGDAN: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_GIACONGDONGDAN"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_FIND_CUSTOMERS_BY_ORDER(HttpContext context)
        {
            try
            {
                if (context.Session["API_FIND_CUSTOMERS_BY_ORDER"] == null || ((DateTime)context.Session["API_FIND_CUSTOMERS_BY_ORDER"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    FindCustomerInfo send = new FindCustomerInfo()
                    {
                        param = accountInfo.AccountId.ToString()
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/FindCustomersByOrder");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_FIND_CUSTOMERS_BY_ORDER: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_FIND_CUSTOMERS_BY_ORDER"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_CUSTOMER_BY_CODE(HttpContext context)
        {
            try
            {
                string param = context.Request.Form["param"];
                if (context.Session["API_GET_CUSTOMER_BY_CODE"] == null || ((DateTime)context.Session["API_GET_CUSTOMER_BY_CODE"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    if (!string.IsNullOrEmpty(param))
                    {
                        param = context.Request.Form["param"].Split('-')[0].Trim();
                        GetCustomerInfo send = new GetCustomerInfo()
                        {
                            customerCode = param
                        };
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetCustomerDetailByCode");
                        context.Response.Write(responseData);
                        return;
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = "Vui lòng nhập thông tin khách hàng!";
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_CUSTOMER_BY_CODE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_CUSTOMER_BY_CODE"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_FIND_CUSTOMERS(HttpContext context)
        {
            try
            {
                string param = context.Request.Form["param"];
                if (context.Session["API_FIND_CUSTOMERS"] == null || ((DateTime)context.Session["API_FIND_CUSTOMERS"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    if (!string.IsNullOrEmpty(param))
                    {
                        param = UtilClass.RemoveSign4VietnameseString(param);
                        FindCustomerInfo send = new FindCustomerInfo()
                        {
                            param = param
                        };
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/FindCustomers");
                        context.Response.Write(responseData);
                        return;
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = "Vui lòng nhập thông tin khách hàng!";
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_FIND_CUSTOMERS: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_FIND_CUSTOMERS"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_LOAISONG(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_LOAISONG"] == null || ((DateTime)context.Session["API_GET_LOAISONG"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    RequestInfo send = new RequestInfo()
                    {
                        clientIP = UtilClass.GetIPAddress()
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetLoaiSong");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_LOAISONG: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_LOAISONG"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_CHATLIEU(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_CHATLIEU"] == null || ((DateTime)context.Session["API_GET_CHATLIEU"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string nhacungcap_id = context.Request.Form["nhaCungCap_ID"];
                    if (!string.IsNullOrEmpty(nhacungcap_id))
                    {
                        GetChatLieuInfo send = new GetChatLieuInfo()
                        {
                            nhacungcap_ID = int.Parse(nhacungcap_id)
                        };
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetChatLieu");
                        context.Response.Write(responseData);
                        return;
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = "Vui lòng chọn nhà cung cấp!";
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_CHATLIEU: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_CHATLIEU"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_KIEUTHUNG(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_KIEUTHUNG"] == null || ((DateTime)context.Session["API_GET_KIEUTHUNG"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    RequestInfo send = new RequestInfo()
                    {
                        clientIP = UtilClass.GetIPAddress()
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetKieuThung");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_KIEUTHUNG: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_KIEUTHUNG"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_LOAIDONHANG(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_LOAIDONHANG"] == null || ((DateTime)context.Session["API_GET_LOAIDONHANG"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    RequestInfo send = new RequestInfo()
                    {
                        clientIP = UtilClass.GetIPAddress()
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetLoaiDonHang");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_LOAIDONHANG: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_LOAIDONHANG"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_LOAIHINHSX(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_LOAIHINHSX"] == null || ((DateTime)context.Session["API_GET_LOAIHINHSX"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    RequestInfo send = new RequestInfo()
                    {
                        clientIP = UtilClass.GetIPAddress()
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetLoaiHinhSX");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_LOAIHINHSX: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_LOAIHINHSX"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_NHACUNGCAP(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_NHACUNGCAP"] == null || ((DateTime)context.Session["API_GET_NHACUNGCAP"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    RequestInfo send = new RequestInfo()
                    {
                        clientIP = UtilClass.GetIPAddress()
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetNhaCungCap");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_NHACUNGCAP: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_NHACUNGCAP"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_CUSTOMER(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_CUSTOMER"] == null || ((DateTime)context.Session["API_GET_CUSTOMER"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    if (!string.IsNullOrEmpty(context.Request.Form["customerID"]))
                    {
                        string param = context.Request.Form["customerID"];
                        GetCustomerInfo send = new GetCustomerInfo()
                        {
                            customerCode = param
                        };
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetCustomerDetail");
                        context.Response.Write(responseData);
                        return;
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.CUSTOMER_ID_INVALID;
                        result.msg = Constants.NUMBER_CODE.CUSTOMER_ID_INVALID.ToString();
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_CUSTOMER: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_CUSTOMER"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_COUNTRY(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_COUNTRY"] == null || ((DateTime)context.Session["API_GET_COUNTRY"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    RequestInfo send = new RequestInfo()
                    {
                        clientIP = UtilClass.GetIPAddress()
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetCountry");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_COUNTRY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_COUNTRY"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_PROVINCE(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_PROVINCE"] == null || ((DateTime)context.Session["API_GET_PROVINCE"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    RequestInfo send = new RequestInfo()
                    {
                        clientIP = UtilClass.GetIPAddress()
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/GetProvince");
                    context.Response.Write(responseData);
                    return;
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_GET_PROVINCE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_PROVINCE"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_CREATE_CUSTOMER(HttpContext context)
        {
            try
            {
                if (context.Session["API_CREATE_CUSTOMER"] == null || ((DateTime)context.Session["API_CREATE_CUSTOMER"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    short KM = 0, KM1 = 0, KM2 = 0;
                    string json = context.Request.Form["json"];
                    var cus = JsonConvert.DeserializeObject<Customer>(json);
                    if (string.IsNullOrEmpty(cus.CompanyName))
                    {
                        result.status = Constants.NUMBER_CODE.COMPANY_NAME_IS_NULL;
                        result.msg = "Tên CTY không được bỏ trống!";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(cus.Address))
                        {
                            if(cus.City == 0)
                            {
                                result.status = Constants.NUMBER_CODE.CITY_IS_NULL;
                                result.msg = "Vui lòng chọn tỉnh thành!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            if (cus.Country == 0)
                            {
                                result.status = Constants.NUMBER_CODE.COUNTRY_IS_NULL;
                                result.msg = "Vui lòng chọn quốc gia!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(cus.Address1))
                        {
                            if (cus.City1 == 0)
                            {
                                result.status = Constants.NUMBER_CODE.CITY_IS_NULL;
                                result.msg = "Vui lòng chọn tỉnh thành!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            if (cus.Country1 == 0)
                            {
                                result.status = Constants.NUMBER_CODE.COUNTRY_IS_NULL;
                                result.msg = "Vui lòng chọn quốc gia!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(cus.Address2))
                        {
                            if (cus.City2 == 0)
                            {
                                result.status = Constants.NUMBER_CODE.CITY_IS_NULL;
                                result.msg = "Vui lòng chọn tỉnh thành!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            if (cus.Country2 == 0)
                            {
                                result.status = Constants.NUMBER_CODE.COUNTRY_IS_NULL;
                                result.msg = "Vui lòng chọn quốc gia!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(cus.KM))
                        {
                            if (!short.TryParse(cus.KM, out KM) || KM < 0)
                            {
                                result.status = Constants.NUMBER_CODE.KM_INVALID;
                                result.msg = "Nhập số Km không chính xác!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(cus.KM1))
                        {
                            if (!short.TryParse(cus.KM1, out KM1) || KM1 < 0)
                            {
                                result.status = Constants.NUMBER_CODE.KM_INVALID;
                                result.msg = "Nhập số Km không chính xác!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(cus.KM2))
                        {
                            if (!short.TryParse(cus.KM2, out KM2) || KM2 < 0)
                            {
                                result.status = Constants.NUMBER_CODE.KM_INVALID;
                                result.msg = "Nhập số Km không chính xác!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }

                        CreateCustomerInfo send = new CreateCustomerInfo()
                        {
                            Address = cus.Address != null ? cus.Address.Trim() : "",
                            City = cus.City,
                            Country = cus.Country,
                            Address1 = cus.Address1 != null ? cus.Address1.Trim() : "",
                            City1 = cus.City1,
                            Country1 = cus.Country1,
                            Address2 = cus.Address2 != null ? cus.Address2.Trim() : "",
                            City2 = cus.City2,
                            Country2 = cus.Country2,
                            CompanyName = cus.CompanyName,
                            Contact = cus.Contact != null ? cus.Contact.Trim() : "",
                            Email = cus.Email != null ? cus.Email.Trim() : "",
                            Phone = cus.Phone != null ? cus.Phone.Trim() : "",
                            publickey = Constants.API_PUBLICKEY,
                            serviceID = Constants.API_SERVICEID,
                            sign = Encryptor.GeneralSignature(Constants.API_SECRETKEY, new List<string>() { Constants.API_SERVICEID.ToString(), Constants.API_PUBLICKEY, cus.CompanyName }),
                            TaxCode = cus.TaxCode != null ? cus.TaxCode : "",
                            UserID = accountInfo.AccountId,
                            UserName = accountInfo.UserName,
                            Status = cus.Status,
                            KM = KM,
                            KM1 = KM1,
                            KM2 = KM2,
                            Loaidon_ID = cus.Loaidon_ID,
                            LoaiHinhSX_ID = cus.LoaiHinhSX_ID,
                            ClientIP = UtilClass.GetIPAddress()
                        };
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/CreateCustomer");
                        context.Response.Write(responseData);
                        return;
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }              
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_CREATE_CUSTOMER: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_CREATE_CUSTOMER"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_UPDATE_CUSTOMER(HttpContext context)
        {
            try
            {
                if (context.Session["API_UPDATE_CUSTOMER"] == null || ((DateTime)context.Session["API_UPDATE_CUSTOMER"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    var cus = JsonConvert.DeserializeObject<Customer>(json);
                    short KM = 0, KM1 = 0, KM2 = 0;
                    if (string.IsNullOrEmpty(cus.CompanyName))
                    {
                        result.status = Constants.NUMBER_CODE.COMPANY_NAME_IS_NULL;
                        result.msg = "Tên CTY không được bỏ trống!";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(cus.Address))
                        {
                            if(cus.City == 0)
                            {
                                result.status = Constants.NUMBER_CODE.CITY_IS_NULL;
                                result.msg = "Vui lòng chọn tỉnh thành!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            if (cus.Country == 0)
                            {
                                result.status = Constants.NUMBER_CODE.COUNTRY_IS_NULL;
                                result.msg = "Vui lòng chọn quốc gia!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(cus.Address1))
                        {
                            if (cus.City1 == 0)
                            {
                                result.status = Constants.NUMBER_CODE.CITY_IS_NULL;
                                result.msg = "Vui lòng chọn tỉnh thành!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            if (cus.Country1 == 0)
                            {
                                result.status = Constants.NUMBER_CODE.COUNTRY_IS_NULL;
                                result.msg = "Vui lòng chọn quốc gia!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(cus.Address2))
                        {
                            if (cus.City2 == 0)
                            {
                                result.status = Constants.NUMBER_CODE.CITY_IS_NULL;
                                result.msg = "Vui lòng chọn tỉnh thành!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                            if (cus.Country2 == 0)
                            {
                                result.status = Constants.NUMBER_CODE.COUNTRY_IS_NULL;
                                result.msg = "Vui lòng chọn quốc gia!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(cus.KM))
                        {
                            if(!short.TryParse(cus.KM, out KM) || KM < 0)
                            {
                                result.status = Constants.NUMBER_CODE.KM_INVALID;
                                result.msg = "Nhập số Km không chính xác!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(cus.KM1))
                        {
                            if (!short.TryParse(cus.KM1, out KM1) || KM1 < 0)
                            {
                                result.status = Constants.NUMBER_CODE.KM_INVALID;
                                result.msg = "Nhập số Km không chính xác!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(cus.KM2))
                        {
                            if (!short.TryParse(cus.KM2, out KM2) || KM2 < 0)
                            {
                                result.status = Constants.NUMBER_CODE.KM_INVALID;
                                result.msg = "Nhập số Km không chính xác!";
                                context.Response.Write(JsonConvert.SerializeObject(result));
                                return;
                            }
                        }

                        CreateCustomerInfo send = new CreateCustomerInfo()
                        {
                            customerID = cus.CustomerID,
                            Address = cus.Address != null ? cus.Address.Trim() : "",
                            City = cus.City,
                            Country = cus.Country,
                            Address1 = cus.Address1 != null ? cus.Address1.Trim() : "",
                            City1 = cus.City1,
                            Country1 = cus.Country1,
                            Address2 = cus.Address2 != null ? cus.Address2.Trim() : "",
                            City2 = cus.City2,
                            Country2 = cus.Country2,
                            CompanyName = cus.CompanyName,
                            Contact = cus.Contact != null ? cus.Contact.Trim() : "",
                            Email = cus.Email != null ? cus.Email.Trim() : "",
                            Phone = cus.Phone != null ? cus.Phone.Trim() : "",
                            publickey = Constants.API_PUBLICKEY,
                            serviceID = Constants.API_SERVICEID,
                            sign = Encryptor.GeneralSignature(Constants.API_SECRETKEY, new List<string>() { Constants.API_SERVICEID.ToString(), Constants.API_PUBLICKEY, cus.CompanyName }),
                            TaxCode = cus.TaxCode != null ? cus.TaxCode : "",
                            UserID = accountInfo.AccountId,
                            UserName = accountInfo.UserName,
                            Status = cus.Status,
                            KM = KM,
                            KM1 = KM1,
                            KM2 = KM2,
                            Loaidon_ID = cus.Loaidon_ID,
                            LoaiHinhSX_ID = cus.LoaiHinhSX_ID,
                            ClientIP = UtilClass.GetIPAddress()
                        };
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(send), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Customer/UpdateCustomer");
                        context.Response.Write(responseData);
                        return;
                    }
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER;
                    result.msg = Constants.NUMBER_CODE.ERROR_CONNECT_SERVER.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR API_UPDATE_CUSTOMER: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_UPDATE_CUSTOMER"] = DateTime.Now;
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

    public class CreateCustomerInfo
    {
        public int customerID;
        public string publickey;
        public short serviceID;
        public string CompanyName;
        public string TaxCode;
        public string Address;
        public short City;
        public short Country;
        public string Address1;
        public short City1;
        public short Country1;
        public string Address2;
        public short City2;
        public short Country2;
        public string Email;
        public string Phone;
        public string Contact;
        public int UserID;
        public string UserName;
        public byte Status;
        public short KM;
        public short KM1;
        public short KM2;
        public byte Loaidon_ID;
        public int LoaiHinhSX_ID;
        public string ClientIP;
        public string sign;
    }

    public struct Customer
    {
        public int CustomerID;
        public string CompanyName;
        public string TaxCode;
        public string Email;
        public string Phone;
        public string Contact;
        public byte Status;
        public string Address;
        public short City;
        public short Country;
        public string Address1;
        public short City1;
        public short Country1;
        public string Address2;
        public short City2;
        public short Country2;
        public string KM;
        public string KM1;
        public string KM2;
        public byte Loaidon_ID;
        public int LoaiHinhSX_ID;
    }

    public class GetChatLieuInfo
    {
        public int nhacungcap_ID;
    }
    public class GetCustomerInfo
    {
        public string customerCode;
    }
    public class FindCustomerInfo
    {
        public string param;
    }
    public class RequestInfo
    {
        public string clientIP;
    }

    public abstract class BaseApiInfo
    {
        public string publickey = Constants.API_PUBLICKEY;
        public short serviceID = Constants.API_SERVICEID;
    }
}