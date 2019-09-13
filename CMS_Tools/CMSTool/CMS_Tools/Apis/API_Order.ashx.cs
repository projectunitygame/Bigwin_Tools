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
    /// Summary description for API_Order
    /// </summary>
    public class API_Order : IHttpHandler, IRequiresSessionState
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
                    case Constants.REQUEST_TYPE.API_PHAN_HOI_SX:
                        API_PHAN_HOI_SX(context);
                        break;
                    case Constants.REQUEST_TYPE.API_NHAP_KHO_SX:
                        API_NHAP_KHO_SX(context);
                        break;
                    case Constants.REQUEST_TYPE.API_UPDATE_DONHANG_SANXUAT:
                        API_UPDATE_DONHANG_SANXUAT(context);
                        break;
                    case Constants.REQUEST_TYPE.API_REMOVE_ORDER:
                        API_REMOVE_ORDER(context);
                        break;
                    case Constants.REQUEST_TYPE.API_UPDATE_GIAYTONKHO:
                        API_UPDATE_GIAYTONKHO(context);
                        break;
                    case Constants.REQUEST_TYPE.API_REMOVE_ORDER_DAT_GIAY_TAM:
                        API_REMOVE_ORDER_DAT_GIAY_TAM(context);
                        break;
                    case Constants.REQUEST_TYPE.API_UPDATE_ORDER_DAT_GIAY_TAM:
                        API_UPDATE_ORDER_DAT_GIAY_TAM(context);
                        break;
                    case Constants.REQUEST_TYPE.API_ADD_ORDER_DAT_GIAY_TAM:
                        API_ADD_ORDER_DAT_GIAY_TAM(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_ORDER_PRINT_INFO:
                        API_GET_ORDER_PRINT_INFO(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_ORDER_INFO:
                        API_GET_ORDER_INFO(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_LIST_ORDER_DETAIL_BY_ORDERCODE:
                        API_GET_LIST_ORDER_DETAIL_BY_ORDERCODE(context);
                        break;
                    case Constants.REQUEST_TYPE.API_SAVE_ORDER:
                        API_SAVE_ORDER(context);
                        break;
                    case Constants.REQUEST_TYPE.API_REMOVE_ORDER_DETAIL:
                        API_REMOVE_ORDER_DETAIL(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_LIST_ORDERS:
                        API_GET_LIST_ORDERS(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_LIST_ORDER_DETAIL:
                        API_GET_LIST_ORDER_DETAIL(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_LIST_ORDER_DETAIL_TEMP:
                        API_GET_LIST_ORDER_DETAIL_TEMP(context);
                        break;
                    case Constants.REQUEST_TYPE.API_UPDATE_ORDER_DETAIL:
                        API_UPDATE_ORDER_DETAIL(context);
                        break;
                    case Constants.REQUEST_TYPE.API_GET_TINHTOAN_KICHTHUOC_THUNG:
                        API_GET_TINHTOAN_KICHTHUOC_THUNG(context);
                        break;
                    case Constants.REQUEST_TYPE.API_ADD_NEW_ORDER_DETAIL:
                        API_ADD_NEW_ORDER_DETAIL(context);
                        break;
                    default:
                        result.status = Constants.NUMBER_CODE.REQUEST_TYPE_NOT_FOUND;
                        result.msg = Constants.NUMBER_CODE.REQUEST_TYPE_NOT_FOUND.ToString();
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

        private void API_PHAN_HOI_SX(HttpContext context)
        {
            try
            {
                if (context.Session["API_PHAN_HOI_SX"] == null || ((DateTime)context.Session["API_PHAN_HOI_SX"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string orderID = context.Request.Form["id"];
                    string phanhoi = context.Request.Form["phanhoi"];
                    PhanHoiSanXuat jsonData = new PhanHoiSanXuat()
                    {
                        ip = UtilClass.GetIPAddress(),
                        id = int.Parse(orderID),
                        phanhoi = phanhoi,
                        userID = accountInfo.AccountId,
                        userName = accountInfo.UserName
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/PhanHoiSanXuat");
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
                Logs.SaveError("ERROR API_PHAN_HOI_SX: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_PHAN_HOI_SX"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_NHAP_KHO_SX(HttpContext context)
        {
            try
            {
                if (context.Session["API_NHAP_KHO_SX"] == null || ((DateTime)context.Session["API_NHAP_KHO_SX"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string orderID = context.Request.Form["id"];
                    string sl = context.Request.Form["sl"];
                    NhapKhoSanXuat jsonData = new NhapKhoSanXuat()
                    {
                        ip = UtilClass.GetIPAddress(),
                        id = int.Parse(orderID),
                        qty = int.Parse(sl),
                        userID = accountInfo.AccountId,
                        userName = accountInfo.UserName,
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/NhapKhoSanXuat");
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
                Logs.SaveError("ERROR API_NHAP_KHO_SX: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_NHAP_KHO_SX"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_UPDATE_DONHANG_SANXUAT(HttpContext context)
        {
            try
            {
                if (context.Session["API_UPDATE_DONHANG_SANXUAT"] == null || ((DateTime)context.Session["API_UPDATE_DONHANG_SANXUAT"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string orderID = context.Request.Form["id"];
                    string updateName = context.Request.Form["update"];
                    string value = context.Request.Form["value"];
                    UpdateDonHangSanXuat jsonData = new UpdateDonHangSanXuat()
                    {
                        ip = UtilClass.GetIPAddress(),
                        id = int.Parse(orderID),
                        updateName = updateName,
                        value = int.Parse(value),
                        userID = accountInfo.AccountId,
                        userName = accountInfo.UserName
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/UpdateDonHangSanXuat");
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
                Logs.SaveError("ERROR API_UPDATE_DONHANG_SANXUAT: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_UPDATE_DONHANG_SANXUAT"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_REMOVE_ORDER(HttpContext context)
        {
            try
            {
                if (context.Session["API_REMOVE_ORDER"] == null || ((DateTime)context.Session["API_REMOVE_ORDER"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string orderID = context.Request.Form["orderID"];
                    RemoveOrderInfo jsonData = new RemoveOrderInfo()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        order_ID = int.Parse(orderID),
                        userID = accountInfo.AccountId,
                        userName = accountInfo.UserName
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/RemoveOrder");
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
                Logs.SaveError("ERROR API_REMOVE_ORDER: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_REMOVE_ORDER"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_UPDATE_GIAYTONKHO(HttpContext context)
        {
            try
            {
                if (context.Session["API_UPDATE_GIAYTONKHO"] == null || ((DateTime)context.Session["API_UPDATE_GIAYTONKHO"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string id = context.Request.Form["id"];
                    string sl_nhan = context.Request.Form["sl_nhan"];
                    string sl_tang = context.Request.Form["sl_tang"];
                    string sl_hanghu = context.Request.Form["sl_hanghu"];
                    string ghichu = context.Request.Form["ghichu"];
                    if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(sl_nhan) && !string.IsNullOrEmpty(sl_tang) && !string.IsNullOrEmpty(sl_hanghu))
                    {
                        int slNhan = 0;
                        int slTang = 0;
                        int slHangHu = 0;
                        if (int.TryParse(sl_nhan, out slNhan) && int.TryParse(sl_tang, out slTang) && int.TryParse(sl_hanghu, out slHangHu))
                        {
                            UpdateGiayTonInfo jsonData = new UpdateGiayTonInfo()
                            {
                                id = int.Parse(id),
                                sl_nhan = slNhan,
                                sl_tang = slTang,
                                sl_hanghu = slHangHu,
                                userID = accountInfo.AccountId,
                                userName = accountInfo.UserName,
                                ghichu = ghichu,
                                ip = UtilClass.GetIPAddress()
                            };
                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/UpdateGiayTonKho");
                            context.Response.Write(responseData);
                            return;
                        }
                        else
                        {
                            result.status = Constants.NUMBER_CODE.NUMBER_INVALID;
                            result.msg = "Nhập số lượng không chính xác!";
                        }
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
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
                Logs.SaveError("ERROR API_UPDATE_GIAYTONKHO: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_UPDATE_GIAYTONKHO"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_UPDATE_ORDER_DAT_GIAY_TAM(HttpContext context)
        {
            try
            {
                if (context.Session["API_UPDATE_ORDER_DAT_GIAY_TAM"] == null || ((DateTime)context.Session["API_UPDATE_ORDER_DAT_GIAY_TAM"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string id = context.Request.Form["id"];
                    string sl_nhan = context.Request.Form["sl_nhan"];
                    string sl_tang = context.Request.Form["sl_tang"];
                    string ghichu = context.Request.Form["ghichu"];
                    if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(sl_nhan) && !string.IsNullOrEmpty(sl_tang))
                    {
                        int slNhan = 0;
                        int slTang = 0;
                        if (int.TryParse(sl_nhan, out slNhan) && int.TryParse(sl_tang, out slTang))
                        {
                            UpdateOrderDatGiayTamInfo jsonData = new UpdateOrderDatGiayTamInfo()
                            {
                                id = int.Parse(id),
                                sl_nhan = slNhan,
                                sl_tang = slTang,
                                userID = accountInfo.AccountId,
                                userName = accountInfo.UserName,
                                ghichu = ghichu,
                                ip = UtilClass.GetIPAddress()
                            };
                            PayloadApi p = new PayloadApi()
                            {
                                clientIP = UtilClass.GetIPAddress(),
                                data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                            };
                            var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/UpdateOrderDatGiayTam");
                            context.Response.Write(responseData);
                            return;
                        }
                        else
                        {
                            result.status = Constants.NUMBER_CODE.NUMBER_INVALID;
                            result.msg = "Nhập số lượng không chính xác!";
                        }
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
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
                Logs.SaveError("ERROR API_UPDATE_ORDER_DAT_GIAY_TAM: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_UPDATE_ORDER_DAT_GIAY_TAM"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_REMOVE_ORDER_DAT_GIAY_TAM(HttpContext context)
        {
            try
            {
                if (context.Session["API_REMOVE_ORDER_DAT_GIAY_TAM"] == null || ((DateTime)context.Session["API_REMOVE_ORDER_DAT_GIAY_TAM"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string id = context.Request.Form["id"];
                    if (!string.IsNullOrEmpty(id))
                    {
                        RemoveOrderDatGiayTamInfo jsonData = new RemoveOrderDatGiayTamInfo()
                        {
                            id = int.Parse(id),
                            userID = accountInfo.AccountId,
                            userName = accountInfo.UserName,
                            ip = UtilClass.GetIPAddress()
                        };
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/RemoveOrderDatGiayTam");
                        context.Response.Write(responseData);
                        return;
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
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
                Logs.SaveError("ERROR API_REMOVE_ORDER_DAT_GIAY_TAM: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_REMOVE_ORDER_DAT_GIAY_TAM"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_ADD_ORDER_DAT_GIAY_TAM(HttpContext context)
        {
            try
            {
                if (context.Session["API_ADD_ORDER_DAT_GIAY_TAM"] == null || ((DateTime)context.Session["API_ADD_ORDER_DAT_GIAY_TAM"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string json = context.Request.Form["json"];
                    string ngaydatgiay = context.Request.Form["ngaydatgiay"];
                    string ngayyeucaugiao = context.Request.Form["ngayyeucaugiao"];
                    string kyhieudon = context.Request.Form["kyhieudon"];
                    if (!string.IsNullOrEmpty(json) && !string.IsNullOrEmpty(ngaydatgiay) && !string.IsNullOrEmpty(ngayyeucaugiao))
                    {
                        var d = ngaydatgiay.Split(' ')[0].Split('/');
                        string _ngaydat = d[2] + "/" + d[1] + '/' + d[0] + " " + ngaydatgiay.Split(' ')[1] + ":00"; //yyyy/mm/dd hh:mm:ss
                        var d2 = ngayyeucaugiao.Split(' ')[0].Split('/');
                        string _ngaygiao = d2[2] + "/" + d2[1] + '/' + d2[0] + " " + ngayyeucaugiao.Split(' ')[1] + ":00";//yyyy/mm/dd hh:mm:ss
                        AddOrderDatGiayTamInfo jsonData = new AddOrderDatGiayTamInfo()
                        {
                            json = JsonConvert.DeserializeObject<List<json_datgiaytam>>(json),
                            ngaydatgiay = _ngaydat,
                            ngayyeucaugiao = _ngaygiao,
                            userID = accountInfo.AccountId,
                            userName = accountInfo.UserName,
                            ip = UtilClass.GetIPAddress()
                        };
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/AddOrderDatGiayTam");
                        context.Response.Write(responseData);
                        return;
                    }
                    else
                    {
                        result.status = Constants.NUMBER_CODE.DATA_NULL;
                        result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
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
                Logs.SaveError("ERROR API_ADD_ORDER_DAT_GIAY_TAM: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_ADD_ORDER_DAT_GIAY_TAM"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_ORDER_PRINT_INFO(HttpContext context)
        {
            string orderDetailID = context.Request.Form["orderDetailID"];
            string orderID = context.Request.Form["orderID"];
            string pagePrint = context.Request.Form["pagePrint"];
            if (string.IsNullOrEmpty(pagePrint))
                pagePrint = "all";
            try
            {
                if (context.Session["API_GET_ORDER_PRINT_INFO"] == null || ((DateTime)context.Session["API_GET_ORDER_PRINT_INFO"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    GetOrderPrintInfo jsonData = new GetOrderPrintInfo()
                    {
                        pagePrint = pagePrint,
                        orderID = int.Parse(orderID),
                        userID = accountInfo.AccountId
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/GetOrderPrintInfo");
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
                Logs.SaveError("ERROR API_GET_ORDER_PRINT_INFO: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_ORDER_PRINT_INFO"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_ORDER_INFO(HttpContext context)
        {
            string orderDetailID = context.Request.Form["orderDetailID"];
            string orderID = context.Request.Form["orderID"];
            try
            {
                if (context.Session["API_GET_ORDER_INFO"] == null || ((DateTime)context.Session["API_GET_ORDER_INFO"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    GetOrderInfo jsonData = new GetOrderInfo()
                    {
                        orderDetailID = int.Parse(orderDetailID),
                        orderID = int.Parse(orderID),
                        userID = accountInfo.AccountId
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/GetOrderInfo");
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
                Logs.SaveError("ERROR API_GET_ORDER_INFO: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_ORDER_INFO"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_LIST_ORDER_DETAIL_BY_ORDERCODE(HttpContext context)
        {
            string param = context.Request.Form["param"];
            try
            {
                if (context.Session["API_GET_LIST_ORDER_DETAIL_BY_ORDERCODE"] == null || ((DateTime)context.Session["API_GET_LIST_ORDER_DETAIL_BY_ORDERCODE"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    GetListOrderDetail jsonData = new GetListOrderDetail()
                    {
                        orderCode  = param,
                        userID = accountInfo.AccountId
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/GetListOrderDetailByOrderCode");
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
                Logs.SaveError("ERROR API_GET_LIST_ORDER_DETAIL_BY_ORDERCODE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_LIST_ORDER_DETAIL_BY_ORDERCODE"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_SAVE_ORDER(HttpContext context)
        {
            try
            {
                if (context.Session["API_SAVE_ORDER"] == null || ((DateTime)context.Session["API_SAVE_ORDER"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    SaveOrderInfo jsonData = new SaveOrderInfo()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        userID = accountInfo.AccountId,
                        userName = accountInfo.UserName
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/SaveOrder");
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
                Logs.SaveError("ERROR API_SAVE_ORDER: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_SAVE_ORDER"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_REMOVE_ORDER_DETAIL(HttpContext context)
        {
            try
            {
                if (context.Session["API_REMOVE_ORDER_DETAIL"] == null || ((DateTime)context.Session["API_REMOVE_ORDER_DETAIL"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    string orderDetailID = context.Request.Form["orderDetailID"];
                    string orderID = context.Request.Form["orderID"];
                    RemoveOrderInfo jsonData = new RemoveOrderInfo()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        orderDetail_ID = int.Parse(orderDetailID),
                        order_ID = int.Parse(orderID),
                        userID = accountInfo.AccountId,
                        userName = accountInfo.UserName
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/RemoveOrderDetail");
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
                Logs.SaveError("ERROR API_REMOVE_ORDER_DETAIL: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_REMOVE_ORDER_DETAIL"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_LIST_ORDERS(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_LIST_ORDERS"] == null || ((DateTime)context.Session["API_GET_LIST_ORDERS"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(accountInfo.AccountId.ToString(), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/GetOrdersByUser");
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
                Logs.SaveError("ERROR API_GET_LIST_ORDERS: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_LIST_ORDER_DETAIL"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_LIST_ORDER_DETAIL(HttpContext context)
        {
            string param = context.Request.Form["param"];
            try
            {
                if (context.Session["API_GET_LIST_ORDER_DETAIL"] == null || ((DateTime)context.Session["API_GET_LIST_ORDER_DETAIL"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    GetListOrderInfo jsonData = new GetListOrderInfo()
                    {
                        orderID = int.Parse(param),
                        userID = accountInfo.AccountId
                    };
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/GetListOrderDetail");
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
                Logs.SaveError("ERROR API_GET_LIST_ORDER_DETAIL: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_LIST_ORDER_DETAIL"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_LIST_ORDER_DETAIL_TEMP(HttpContext context)
        {
            try
            {
                if (context.Session["API_GET_LIST_ORDER_DETAIL_TEMP"] == null || ((DateTime)context.Session["API_GET_LIST_ORDER_DETAIL_TEMP"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    PayloadApi p = new PayloadApi()
                    {
                        clientIP = UtilClass.GetIPAddress(),
                        data = Encryptor.EncryptString(accountInfo.AccountId.ToString(), Constants.API_SECRETKEY)
                    };
                    var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/GetOrderDetailDrafts");
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
                Logs.SaveError("ERROR API_GET_LIST_ORDER_DETAIL_TEMP: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_LIST_ORDER_DETAIL_TEMP"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_UPDATE_ORDER_DETAIL(HttpContext context)
        {
            try
            {
                string param = context.Request.Form["param"];
                if (context.Session["API_UPDATE_ORDER_DETAIL"] == null || ((DateTime)context.Session["API_UPDATE_ORDER_DETAIL"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    if (!string.IsNullOrEmpty(param))
                    {
                        var jsonData = JsonConvert.DeserializeObject<AddOrderInfo>(param);
                        jsonData.order.ClientIP = UtilClass.GetIPAddress();
                        if (!string.IsNullOrEmpty(jsonData.orderDetail.Ngay_Mo_Don))
                        {
                            var d = jsonData.orderDetail.Ngay_Mo_Don.Split('/');
                            jsonData.orderDetail.Ngay_Mo_Don = d[2] + "/" + d[1] + '/' + d[0];//yyyy/mm/dd
                        }
                        if (!string.IsNullOrEmpty(jsonData.orderDetail.Ngay_Giao_Hang))
                        {
                            var d = jsonData.orderDetail.Ngay_Giao_Hang.Split('/');
                            jsonData.orderDetail.Ngay_Giao_Hang = d[2] + "/" + d[1] + '/' + d[0];//yyyy/mm/dd
                        }
                        //jsonData.order.UserID = accountInfo.AccountId;
                        //jsonData.order.UserName = accountInfo.UserName;
                        //jsonData.order.UserCode = accountInfo.Code;
                        jsonData.orderDetail.OwnerID = accountInfo.AccountId;
                        jsonData.orderDetail.OwnerName = accountInfo.UserName;
                        List<string> cannap = new List<string>();
                        List<string> canlan = new List<string>();
                        var c1 = jsonData.orderDetail.Can_Nap.Split('|').ToArray();
                        var c2 = jsonData.orderDetail.Can_Lan.Split('|').ToArray();
                        for (int i = 0; i < c1.Count(); i++)
                        {
                            if (c1[i].Trim() != "")
                                cannap.Add(c1[i]);
                            else
                                break;
                        }
                        for (int i = 0; i < c2.Count(); i++)
                        {
                            if (c2[i].Trim() != "")
                                canlan.Add(c2[i]);
                            else
                                break;
                        }
                        if (cannap.Count() > 0)
                            jsonData.orderDetail.Can_Nap = string.Join("|", cannap);
                        if (canlan.Count() > 0)
                            jsonData.orderDetail.Can_Lan = string.Join("|", canlan);
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/UpdateOrder");
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
                Logs.SaveError("ERROR API_UPDATE_ORDER_DETAIL: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_UPDATE_ORDER_DETAIL"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_ADD_NEW_ORDER_DETAIL(HttpContext context)
        {
            try
            {
                string param = context.Request.Form["param"];
                if (context.Session["API_ADD_NEW_ORDER_DETAIL"] == null || ((DateTime)context.Session["API_ADD_NEW_ORDER_DETAIL"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    if (!string.IsNullOrEmpty(param))
                    {
                        var jsonData = JsonConvert.DeserializeObject<AddOrderInfo>(param);
                        jsonData.order.ClientIP = UtilClass.GetIPAddress();
                        if (!string.IsNullOrEmpty(jsonData.orderDetail.Ngay_Mo_Don))
                        {
                            var d = jsonData.orderDetail.Ngay_Mo_Don.Split('/');
                            jsonData.orderDetail.Ngay_Mo_Don = d[2] + "/" + d[1] + '/' + d[0];//yyyy/mm/dd
                        }
                        if (!string.IsNullOrEmpty(jsonData.orderDetail.Ngay_Giao_Hang))
                        {
                            var d = jsonData.orderDetail.Ngay_Giao_Hang.Split('/');
                            jsonData.orderDetail.Ngay_Giao_Hang = d[2] + "/" + d[1] + '/' + d[0];//yyyy/mm/dd
                        }
                        //jsonData.order.UserID = accountInfo.AccountId;
                        //jsonData.order.UserName = accountInfo.UserName;
                        //jsonData.order.UserCode = accountInfo.Code;
                        jsonData.orderDetail.OwnerID = accountInfo.AccountId;
                        jsonData.orderDetail.OwnerName = accountInfo.UserName;
                        List<string> cannap = new List<string>();
                        List<string> canlan = new List<string>();
                        var c1 = jsonData.orderDetail.Can_Nap.Split('|').ToArray();
                        var c2 = jsonData.orderDetail.Can_Lan.Split('|').ToArray();
                        for (int i = 0; i < c1.Count(); i++)
                        {
                            if (c1[i].Trim() != "")
                                cannap.Add(c1[i]);
                            else
                                break;
                        }
                        for (int i = 0; i < c2.Count(); i++)
                        {
                            if (c2[i].Trim() != "")
                                canlan.Add(c2[i]);
                            else
                                break;
                        }
                        if(cannap.Count() > 0)
                            jsonData.orderDetail.Can_Nap = string.Join("|", cannap);
                        if(canlan.Count() > 0)
                            jsonData.orderDetail.Can_Lan = string.Join("|", canlan);
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/AddOrder");
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
                Logs.SaveError("ERROR API_ADD_NEW_ORDER_DETAIL: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = ex.ToString();
            }
            finally
            {
                context.Session["API_ADD_NEW_ORDER_DETAIL"] = DateTime.Now;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void API_GET_TINHTOAN_KICHTHUOC_THUNG(HttpContext context)
        {
            try
            {
                string param = context.Request.Form["param"];
                if (context.Session["API_GET_TINHTOAN_KICHTHUOC_THUNG"] == null || ((DateTime)context.Session["API_GET_TINHTOAN_KICHTHUOC_THUNG"] - DateTime.Now).TotalMilliseconds < Constants.TIME_REQUEST)
                {
                    if (!string.IsNullOrEmpty(param))
                    {
                        var jsonData = JsonConvert.DeserializeObject<RequestTinhToanKichThuocThung>(param);
                        PayloadApi p = new PayloadApi()
                        {
                            clientIP = UtilClass.GetIPAddress(),
                            data = Encryptor.EncryptString(JsonConvert.SerializeObject(jsonData), Constants.API_SECRETKEY)
                        };
                        var responseData = UtilClass.SendPost(JsonConvert.SerializeObject(p), Constants.API_URL + "/api/v1/Order/TinhToanKichThuocThung");
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
                Logs.SaveError("ERROR API_GET_TINHTOAN_KICHTHUOC_THUNG: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            finally
            {
                context.Session["API_GET_TINHTOAN_KICHTHUOC_THUNG"] = DateTime.Now;
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

    public class RequestTinhToanKichThuocThung
    {
        public int sl;
        public int loaithungID;
        public int loaisongID;
        public int dai;
        public int rong;
        public int cao;
        public int luoiga;
        public int nhacungapID;
    }
    public class PayloadApi : BaseApiInfo
    {
        public string data { get; set; }
        public string clientIP { get; set; }
        public string sign { get { return Encryptor.GeneralSignature(new List<string> { Encryptor.GetMd5Hash(data), clientIP, publickey, serviceID.ToString() }); } }
    }
    public class SaveOrderInfo
    {
        public string userName;
        public int userID;
        public string clientIP;
    }
    public class RemoveOrderInfo
    {
        public int orderDetail_ID;
        public int order_ID;
        public string userName;
        public int userID;
        public string clientIP;
    }
    public class UpdateDonHangSanXuat
    {
        public string userName;
        public int userID;
        public int id;
        public string ip;
        public string updateName;
        public int value;
    }
    public class NhapKhoSanXuat
    {
        public string userName;
        public int userID;
        public int id;
        public string ip;
        public int qty;
    }
    public class PhanHoiSanXuat
    {
        public string userName;
        public int userID;
        public int id;
        public string ip;
        public string phanhoi;
    }
    public class GetOrderPrintInfo
    {
        public string pagePrint;
        public int orderID;
        public int userID;
    }
    public class GetOrderInfo
    {
        public int orderID;
        public int orderDetailID;
        public int userID;
    }
    public class GetListOrderDetail
    {
        public string orderCode;
        public int userID;
    }
    public class GetListOrderInfo
    {
        public int orderID;
        public int userID;
    }
    public class AddOrderInfo
    {
        public OrderDetailEntity orderDetail { get; set; }
        public OrderEntity order { get; set; }
        public string sign { get { return Encryptor.GetMd5Hash(JsonConvert.SerializeObject(orderDetail) + Constants.KEY_SERVER + JsonConvert.SerializeObject(order)); } }
    }
    public class OrderDetailEntity
    {
        public int OrderDetail_ID;
        public string MaDonHang;
        public int Order_ID;
        public string Address;
        public short City;
        public short Country;
        public short KM;
        public string Ngay_Mo_Don;
        public string Ngay_Giao_Hang;
        public int LoaiThung_ID;
        public int LoaiSong_ID;
        public string So_Don_KH;
        public string So_PO;
        public string Ten_SP;
        public int NhaCungCap_ID;
        public int QuyCach_KH_D;
        public int QuyCach_KH_R;
        public int QuyCach_KH_C;
        public int QuyCach_SX_D;
        public int QuyCach_SX_R;
        public int QuyCach_SX_C;
        public int QuyCach_SX_LuoiGa;
        public int SL;
        public int SL_Tang;
        public int Thung_Cat_D;
        public int Thung_Cat_R;
        public int QuyCach_KhoGiay_D;
        public int QuyCach_KhoGiay_R;
        public int SLSX;
        public int SL_Bi_Lieu;
        public int Cai;
        public int ChatLieu_ID;
        public int Dong_Dan_ID;
        public string So_Mau_In;
        public string Mau_In;
        public bool In_An;
        public bool Can_bien;
        public bool May_In;
        public bool Cat_Ranh;
        public bool May_Be;
        public bool Dong_Dinh;
        public bool Dan_Keo;
        public int Dong_Goi;
        public string Gia_Cong_DB;
        public string Can_Nap;
        public string Can_Lan;
        public byte Loai_Ban_In;
        public string Ma_So_Ban_In;
        public string Ma_So_Khuon_Be;
        public byte Dinh_Kem;
        public decimal DT_Cai;
        public decimal Tong_DT;
        public int So_Met_Toi;
        public int SL_Toi_Thieu;
        public int Gia_Ban_Thung;
        public int Hoa_Hong;
        public int Hoa_hong1;
        public int Ke_Gia;
        public int Gia_Ban_Bo;
        public int Doanh_Thu_Ban_Hang;
        public int Gia_Mua;
        public int Gia_Ban_Thuc_Te;
        public decimal Phan_Tram_Loi_Nhuan_Ban_Giay;
        public int Gia_Von_Ban_Hang;
        public int Loi_Nhuan_Ban_Giay;
        public int Phi_Hao_Hut_Giay;
        public int Phi_Van_Chuyen;
        public int Phi_Ban_In;
        public int Phi_Khuon_Be;
        public int Phi_To_Khai;
        public int Phi_Gia_Cong;
        public int Chi_Phi_Khac;
        public string Ghi_Chu_Don_Hang;
        public string Ghi_Chu_SX;
        public string Ghi_Chu_Giao_Hang;
        public string DateCreate;
        public string LastUpdate;
        public int OwnerID;
        public string OwnerName;
    }
    public class OrderEntity
    {
        public int Order_ID;
        public string OrderCode;
        public string Ma_KH;
        public int CustomerID;
        public string CompanyName;
        public string TaxCode;
        public string Email;
        public string Phone;
        public string Contact;
        public string DateCreate;
        public byte Status;
        public string ClientIP;
        public int UserID;
        public string UserName;
        public string UserCode;
        public string Action;
        public string Ky_Hieu_Don;
        public byte LoaiDon_ID;
        public int LoaiHinhSX_ID;
    }
    public class AddOrderDatGiayTamInfo
    {
        public AddOrderDatGiayTamInfo()
        {
            json = new List<json_datgiaytam>();
        }
        public string userName;
        public int userID;
        public List<json_datgiaytam> json;
        public string ngaydatgiay;
        public string ngayyeucaugiao;
        public string ghichu;
        public string ip;
    }

    public class json_datgiaytam
    {
        public int Id { get; set; }
        public bool isCannap { get; set; }
    }

    public class UpdateOrderDatGiayTamInfo
    {
        public string userName;
        public int userID;
        public int sl_nhan;
        public int sl_tang;
        public int id;
        public string ghichu;
        public string ip;
    }

    public class UpdateGiayTonInfo
    {
        public string userName;
        public int userID;
        public int sl_nhan;
        public int sl_tang;
        public int sl_hanghu;
        public int id;
        public string ghichu;
        public string ip;
    }

    public class RemoveOrderDatGiayTamInfo
    {
        public string userName;
        public int userID;
        public int id;
        public string ip;
    }
}