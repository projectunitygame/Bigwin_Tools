using api_cms.common;
using api_cms.Entity;
using api_cms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_cms.Controllers
{
    [RoutePrefix("api/v1/Agency")]
    public class AgencyController : ApiController
    {
        private string version = "1.0";
        DAO.PublisherKey publisher = null;
        public AgencyController()
        {
            publisher = new DAO.PublisherKey();
        }

        /// <summary>
        /// Cập nhật thông tin liên hệ đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("UpdateInformation_Agency")]
        [HttpPost]
        public HttpResponseMessage UpdateInformation_Agency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("UpdateInformation_Agency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<UpdateInformationAgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.UpdateInformation_Agency(data, ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR UpdateInformation_Agency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Cập nhật hiển thị đại lý trong game
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("UpdateDisplay_Agency")]
        [HttpPost]
        public HttpResponseMessage UpdateDisplay_Agency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("UpdateDisplay_Agency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<UpdateDisplayAgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.UpdateDisplay_Agency(data, ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR UpdateDisplay_Agency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Cập nhật FB link
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("UpdateFB_Agency")]
        [HttpPost]
        public HttpResponseMessage UpdateFB_Agency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("UpdateFB_Agency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<UpdateFBAgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.UpdateFB_Agency(data, ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR UpdateFB_Agency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Thay đổi số điện thoại đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("ChangePhoneAgency")]
        [HttpPost]
        public HttpResponseMessage ChangePhoneAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("ChangePhoneAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<ChangePhoneAgency>(publisherInfo.data.ToString());
                    string msg = "";
                    string otpNew = "";
                    result.status = managerModel.AgencyModel.ChangePhoneAgency(data, ref msg, ref otpNew);
                    result.msg = msg;
                    if(result.status == 2)
                    {
                        SMS.SendMessage(data.phoneOld,"Ma OTP xac thuc thay doi sdt la " + otpNew + ", hieu luc 3 phut");
                    }
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR CreateAgency_C2: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Tạo đại lý cấp 2
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("CreateAgency_C2")]
        [HttpPost]
        public HttpResponseMessage CreateAgency_C2(PayloadApi p)
        {
            LogClass.SaveCustomerLog("CreateAgency_C2: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<AgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.CreateAgency_C2(data, ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR CreateAgency_C2: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Tạo tài khoản đại lý mới
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("CreateAgency")]
        [HttpPost]
        public HttpResponseMessage CreateAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("CreateAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<AgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.CreateAgency(data, ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR CreateAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Nạp tiền cho đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("AddMoneyAgency")]
        [HttpPost]
        public HttpResponseMessage AddMoneyAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("AddMoneyAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<AddMoneyAgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.AddMoneyAgency(data, ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR AddMoneyAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Khóa tk đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("LockAgency")]
        [HttpPost]
        public HttpResponseMessage LockAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("LockAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<LockAgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.LockAgency(data, ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR LockAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Mở khóa tk đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("UnLockAgency")]
        [HttpPost]
        public HttpResponseMessage UnLockAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("UnLockAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<LockAgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.UnLockAgency(data, ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR UnLockAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Đăng nhập tài khoản đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("LoginAgency")]
        [HttpPost]
        public HttpResponseMessage LoginAgency(PayloadApi p)
        {
            //LogClass.SaveCustomerLog("LoginAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<LoginAgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    int code = -1;
                    var d = managerModel.AgencyModel.LoginAgency(data, ref code, ref msg);
                    result.data = Encryptor.EncryptString(JsonConvert.SerializeObject(d), publisherInfo.secreckey);
                    result.msg = msg;
                    result.status = code;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR LoginAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Lấy thông tin cá nhân đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("GetAgencyInfo")]
        [HttpPost]
        public HttpResponseMessage GetAgencyInfo(PayloadApi p)
        {
            LogClass.SaveCustomerLog("GetAgencyInfo: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<getAgencyInfoEntity>(publisherInfo.data.ToString());
                    int code = -1;
                    string msg = "";
                    var d = managerModel.AgencyModel.GetAgencyByID(data.uwinID, ref code, ref msg);
                    LogClass.SaveCustomerLog("AgencyInfo: " + JsonConvert.SerializeObject(d));
                    result.status = (int)ERROR_CODDE.SUCCESS;
                    result.data = Encryptor.EncryptString(JsonConvert.SerializeObject(d), publisherInfo.secreckey);
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR GetAgencyInfo: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            LogClass.SaveCustomerLog("return GetAgencyInfo: " + JsonConvert.SerializeObject(result));
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Tìm kiếm thông tin đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("FindAgency")]
        [HttpPost]
        public HttpResponseMessage FindAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("FindAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<FindAgencyEntity>(publisherInfo.data.ToString());
                    result.data = managerModel.AgencyModel.FindAgency(data.uwinID, data.param, data.topN);
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR FindAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Tìm kiếm thông tin 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("FindGameAccount")]
        [HttpPost]
        public HttpResponseMessage FindGameAccount(PayloadApi p)
        {
            LogClass.SaveCustomerLog("FindGameAccount: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<FindAgencyEntity>(publisherInfo.data.ToString());
                    result.data = managerModel.AgencyModel.FindGameAccount(data.param, data.topN);
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR FindGameAccount: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Quên mật khẩu gửi OTP để xác nhận thiết lập mật khẩu mới
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("ForgotPasswordAgency")]
        [HttpPost]
        public HttpResponseMessage ForgotPasswordAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("ForgotPasswordAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<FotgetPasswordAgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    string otp = "";
                    result.status = managerModel.AgencyModel.CheckRessetPasswordAgency(data.phone, ref msg, ref otp);
                    result.msg = msg;
                    if(result.status == 1)
                    {
                        SMS.SendMessage(data.phone, "Ma OTP xac thuc reset mat khau la " + otp + ", hieu luc 3 phut");
                    }
                    //result.data = otp;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR ForgotPasswordAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Thiết lập mật khẩu mới cho đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("ResetPasswordAgency")]
        [HttpPost]
        public HttpResponseMessage ResetPasswordAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("ResetPasswordAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<ResetPasswordAgencyEntity>(publisherInfo.data.ToString());
                    string msg = "";
                    string passwordNew = "";
                    result.status = managerModel.AgencyModel.RessetPasswordAgency(data.phone, data.otp, ref msg, ref passwordNew);
                    result.msg = msg;
                    if (result.status == 1)
                    {
                        SMS.SendMessage(data.phone, passwordNew + " la mat khau moi cua Ban.");
                    }
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR ResetPasswordAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Thay đổi hạn mức chuyển tiền và xác thực OTP
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("ChangeLimitTransactionAgency")]
        [HttpPost]
        public HttpResponseMessage ChangeLimitTransactionAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("ChangeLimitTransactionAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<ChangeLimitTransactionAgency>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.ChangeLimitTransactionAgency(data,ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR ChangeLimitTransactionAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Thay đổi mật khẩu đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("ChangePasswordAgency")]
        [HttpPost]
        public HttpResponseMessage ChangePasswordAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("ChangePasswordAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<ChangePasswordAgency>(publisherInfo.data.ToString());
                    string msg = "";
                    result.status = managerModel.AgencyModel.ChangePasswordAgency(data, ref msg);
                    result.msg = msg;
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR ChangePasswordAgency: " + ex.Message, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Chuyển tiền cho user trong game
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("TransferMoneyToUser")]
        [HttpPost]
        public HttpResponseMessage TransferMoneyToUser(PayloadApi p)
        {
            LogClass.SaveCustomerLog("TransferMoneyToUser: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<TransferMoneyToUser>(publisherInfo.data.ToString());
                    string msg = "";
                    string otp = "";
                    string phone = "";
                    result.status = managerModel.AgencyModel.TransferMoneyToUser(data, ref msg, ref otp, ref phone);
                    result.msg = msg;
                    if (result.status == 2)
                    {
                        SMS.SendMessage(phone,"Ma OTP xac thuc GD la " + otp + ", hieu luc 3 phut.Chi tiet GD: Chuyen khoan cho user so tien " + UtilClass.formatMoney((int)data.amount) + " VND.");
                    }
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR TransferMoneyToUser: " + ex, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Chuyển tiền cho đại lý khác
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("TransferMoneyToAgency")]
        [HttpPost]
        public HttpResponseMessage TransferMoneyToAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("TransferMoneyToAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<TransferMoneyToAgency>(publisherInfo.data.ToString());
                    string msg = "";
                    string otp = "";
                    string phone = "";
                    result.status = managerModel.AgencyModel.TransferMoneyToAgency(data, ref msg, ref otp, ref phone);
                    result.msg = msg;
                    if(result.status == 2)
                    {
                        //SMS.SendMessage(phone, otp + " la ma xac thuc chuyen tien cua Ban.");
                        SMS.SendMessage(phone, "Ma OTP xac thuc GD la " + otp + ", hieu luc 3 phut.Chi tiet GD: Chuyen khoan cho dai ly so tien " + UtilClass.formatMoney((int)data.amount) + " VND.");
                    }
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR TransferMoneyToAgency: " + ex, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }

        /// <summary>
        /// Kich hoat số điện thoại
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [Route("ActivePhoneAgency")]
        [HttpPost]
        public HttpResponseMessage ActivePhoneAgency(PayloadApi p)
        {
            LogClass.SaveCustomerLog("ActivePhoneAgency: " + JsonConvert.SerializeObject(p));
            ResultApi result = new ResultApi();
            try
            {
                var publisherInfo = publisher.CheckPublickey(p, version);
                if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                {
                    ManagerModel managerModel = new ManagerModel();
                    var data = JsonConvert.DeserializeObject<ActivePhoneAgency>(publisherInfo.data.ToString());
                    string msg = "";
                    string otp = "";
                    result.status = managerModel.AgencyModel.ActivePhoneAgency(data, ref msg, ref otp);
                    result.msg = msg;
                    if (result.status == 2)
                    {
                        SMS.SendMessage(data.phone,"Ma OTP xac thuc kich hoat sdt la " + otp + ", hieu luc 3 phut");
                    }
                }
                else
                    result = publisherInfo;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR ActivePhoneAgency: " + ex, ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return Request.CreateResponse(result);
        }
    }
}
