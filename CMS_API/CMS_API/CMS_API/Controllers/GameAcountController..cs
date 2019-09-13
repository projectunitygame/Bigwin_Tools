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
    public class GameAcount
    {
        [RoutePrefix("api/v1/GameAccount")]
        public class GameAcountController : ApiController
        {
            private string version = "1.0";
            DAO.PublisherKey publisher = null;
            public GameAcountController()
            {
                publisher = new DAO.PublisherKey();
            }

            [Route("DeductGoldUser")]
            [HttpPost]
            public HttpResponseMessage DeductGoldUser(PayloadApi p)
            {
                LogClass.SaveCustomerLog("DeductGoldUser: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<DeductGoldUser>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.DEDUCT_MONEY_USER(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR DeductGoldUser: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Cộng tiền user từ cms
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("AddMoneyUser")]
            [HttpPost]
            public HttpResponseMessage AddMoneyUser(PayloadApi p)
            {
                LogClass.SaveCustomerLog("AddMoneyUser: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<AddMoneyUser>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.ADD_MONEY_USER(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR AddMoneyUser: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Nạp thẻ
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>

            [Route("InputCard")]
            [HttpPost]
            public HttpResponseMessage InputCard(PayloadApi p)
            {
                LogClass.SaveCustomerLog("InputCard: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                CardObject cardObject = new CardObject();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<InputCard>(publisherInfo.data.ToString());
                        string msg = "";
                        
                        if (data.CardType != 1 && data.CardType != 2 && data.CardType != 3)
                        {
                            result.msg = "CardType sai định dạng";
                            return null;
                        }

                        int successtransaction = 0;
                        int errortransaction = 0;
                        int errorsavelog = 0;
                        short debug = 0;
                        try
                        {
                            string serviceCode = string.Empty;

                            if (data.CardType == 1)
                            {
                                serviceCode = "VTT";
                            }
                            else if (data.CardType == 2)
                            {
                                serviceCode = "VMS";
                            }
                            else if (data.CardType == 3)
                            {
                                serviceCode = "VNP";
                            }
                            debug = 1;
                            for (int i = 0; i < data.Qty; i++)
                            {
                                debug = 2;
                                long transactionId = DateTime.Now.Ticks;

                                var service = new muathe24h.MechantServicesSoapClient();
                                string email = "boxvn1888@gmail.com";
                                string pass = "tinhanhem8668";

                                var res = service.BuyCards(new muathe24h.UserCredentials { userName = email, pass = pass }
                                  , transactionId.ToString(), serviceCode, data.Amount, 1);
                                debug = 3;
                                LogClass.SaveLog("muathe24h" + JsonConvert.SerializeObject(res));
                                string resultCode = res?.RepCode.ToString();
                                debug = 4;
                                //Khoi tao ket qua ghi log mac dinh

                                cardObject.Amount = data.Amount;
                                cardObject.Experied = string.Empty;
                                cardObject.CardType = data.CardType;
                                cardObject.TelCode = serviceCode;
                                cardObject.TradeMark = "muathe24h";
                                cardObject.BuyTime = DateTime.Now;
                                cardObject.ResultCode = resultCode;

                                debug = 5;
                                if (res != null && res.RepCode == 0)
                                {
                                    successtransaction++;
                                    var seri = JsonConvert.DeserializeObject<List<CardObject_Muathe24h>>(res.Data.ToString());
                                    //Mua thanh cong ghi lai code va seri the
                                    cardObject.CardCode = seri[0].PinCode;
                                    cardObject.CardSerial = seri[0].Serial;
                                    cardObject.TransactionCode = transactionId.ToString();
                                    cardObject.Status = true; //Mua thanh cong
                                    LogClass.SaveLog("cardObject buy success:" + JsonConvert.SerializeObject(cardObject));
                                    result.status = managerModel.GameAcountModel.INPUT_CARD(cardObject, ref msg);
                                    if(result.status != 1) 
                                    {
                                        debug = 3;
                                        errorsavelog++;
                                        cardObject.CardCode = string.Empty;
                                        cardObject.CardSerial = string.Empty;
                                        cardObject.TransactionCode = string.Empty;
                                        cardObject.Status = false; // Mua that bai
                                        LogClass.SaveLog("cardObject savelog error:" + JsonConvert.SerializeObject(cardObject));
                                        managerModel.GameAcountModel.INPUT_CARD(cardObject, ref msg);
                                    }
                                }
                                else //Mua the that bai
                                {
                                    debug = 4;
                                    errortransaction++;
                                    cardObject.CardCode = string.Empty;
                                    cardObject.CardSerial = string.Empty;
                                    cardObject.TransactionCode = string.Empty;
                                    cardObject.Status = false; // Mua that bai
                                    LogClass.SaveLog("cardObject buy card error:" + JsonConvert.SerializeObject(cardObject));
                                    managerModel.GameAcountModel.INPUT_CARD(cardObject, ref msg);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogClass.SaveError("Mua thẻ thất bại" + ex + "\n,cardObject:" + JsonConvert.SerializeObject(cardObject));
                        }
                        string msgTotalBuyCard = "Mua thành công " +successtransaction+" thẻ";
                        if (errortransaction > 0)
                        {
                            msgTotalBuyCard += " và thất bại " +errortransaction+ " thẻ";
                        }
                        if (errorsavelog > 0)
                        {
                            msgTotalBuyCard += ". Ghi log thất bại " + errorsavelog + " thẻ";
                        }

                        result.msg = msgTotalBuyCard;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR InputCard: " + ex.Message + "\n,cardObject:" + JsonConvert.SerializeObject(cardObject), ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Cấu hình bot tài xỉu
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>

            [Route("UpdateBotConfigLuckDice")]
            [HttpPost]
            public HttpResponseMessage UpdateBotConfigLuckDice(PayloadApi p)
            {
                LogClass.SaveCustomerLog("UpdateBotConfigLuckDice: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<UpdateBotConfigLuckDice>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.UPDATE_BOT_CONFIG_LUCK_DICE(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR UpdateBotConfigLuckDice: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Đập hũ
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("SetJackpotPrize")]
            [HttpPost]
            public HttpResponseMessage SetJackpotPrize(PayloadApi p)
            {
                LogClass.SaveCustomerLog("SetJackpotPrize: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<SetJackpotPrize>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.SET_JACKPOT_PRIZE(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR SetJackpotPrize: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Cấu hình thẻ nạp
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("ConfigCard")]
            [HttpPost]
            public HttpResponseMessage ConfigCard(PayloadApi p)
            {
                LogClass.SaveCustomerLog("ConfigCard: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<ConfigCard>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.CONFIG_CARD(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR ConfigCard: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Xóa giao dịch mua thẻ lỗi
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("DeleteFailTransactionCard")]
            [HttpPost]
            public HttpResponseMessage DeleteFailTransactionCard(PayloadApi p)
            {
                LogClass.SaveCustomerLog("DeleteCashOutCard: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<DeleteFailTransactionCard>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.DELETE_FAIL_TRANSACTION_CARD(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR DeleteFailTransactionCard: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Xóa yêu cầu rút tiền(thẻ)
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("DeleteCashOutCard")]
            [HttpPost]
            public HttpResponseMessage DeleteCashOutCard(PayloadApi p)
            {
                LogClass.SaveCustomerLog("DeleteCashOutCard: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<DeleteCashOutCard>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.DELETE_CASH_OUT_CARD(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR DeleteCashOutCard: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Duyệt thẻ
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("AcceptCard")]
            [HttpPost]
            public HttpResponseMessage AcceptCard(PayloadApi p)
            {
                LogClass.SaveCustomerLog("AcceptCard: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<AcceptCard>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.ACCEPT_CARD(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR AcceptCard: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Trừ quỹ game
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>

            [Route("ExceptFundGame")]
            [HttpPost]
            public HttpResponseMessage ExceptFundGame(PayloadApi p)
            {
                LogClass.SaveCustomerLog("ExceptFundGame: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<ExceptFundGame>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.EXCEPT_FUND_GAME(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR ExceptFundGame: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Xóa event giftcode
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("DeleteEventGiftCode")]
            [HttpPost]
            public HttpResponseMessage DeleteEventGiftCode(PayloadApi p)
            {
                LogClass.SaveCustomerLog("DeleteEventGiftCode: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<DeleteEventGiftCode>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.DELETE_EVENT_GIFTCODE(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR DeleteEventGiftCode: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Cập nhật ngày event giftcode
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("UpdateEventGiftCode")]
            [HttpPost]
            public HttpResponseMessage UpdateEventGiftCode(PayloadApi p)
            {
                LogClass.SaveCustomerLog("UpdateEventGiftCode: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<UpdateEventGiftCode>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.UPDATE_EVENT_GIFTCODE(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR UpdateEventGiftCode: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }


            /// <summary>
            /// Tạo event giftcode mới
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("CreateEventGiftCode")]
            [HttpPost]
            public HttpResponseMessage CreateEventGiftCode(PayloadApi p)
            {
                LogClass.SaveCustomerLog("CreateEventGiftCode: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<CreateEventGiftCode>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.CREATE_EVENT_GIFTCODE(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR CreateEventGiftCode: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Xóa thông báo game
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("DeleteSchemeNotificationGame")]
            [HttpPost]
            public HttpResponseMessage DeleteSchemeNotificationGame(PayloadApi p)
            {
                LogClass.SaveCustomerLog("DeleteSchemeNotificationGame: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<DeleteSchemeNotificationGameEnity>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.DELETE_SCHEME_NOTIFICATION_GAME(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR DeleteSchemeNotificationGame: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Cập nhật thông báo game
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("UpdateSchemeNotificationGame")]
            [HttpPost]
            public HttpResponseMessage UpdateSchemeNotificationGame(PayloadApi p)
            {
                LogClass.SaveCustomerLog("UpdateSchemeNotificationGame: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<UpdateSchemeNotificationGameEnity>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.UPDATE_SCHEME_NOTIFICATION_GAME(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR UpdateSchemeNotificationGame: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Tạo thông báo game mới
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("CreateSchemeNotificationGame")]
            [HttpPost]
            public HttpResponseMessage CreateSchemeNotificationGame(PayloadApi p)
            {
                LogClass.SaveCustomerLog("CreateSchemeNotificationGame: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<CreateSchemeNotificationGameEnity>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.CREATE_SCHEME_NOTIFICATION_GAME(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR CreateSchemeNotificationGame: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Khóa chat tài khoản game
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("LockChatAccountGame")]
            [HttpPost]
            public HttpResponseMessage LockChatAccountGame(PayloadApi p)
            {
                LogClass.SaveCustomerLog("LockChatAccountGame: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<LockChatAccountGameEnity>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.LOCK_CHAT_ACCOUNT_GAME(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR LockChatAccountGame: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }


            /// <summary>
            /// Mở khóa chat tài khoản game
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("UnlockChatAccountGame")]
            [HttpPost]
            public HttpResponseMessage UnlockChatAccountGame(PayloadApi p)
            {
                LogClass.SaveCustomerLog("UnlockChatAccountGame: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<UnlockChatAccountGameEnity>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.UNLOCK_CHAT_ACCOUNT_GAME(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR UnlockChatAccountGame: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }

            /// <summary>
            /// Khóa đăng nhập tài khoản game
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("LockAccountGame")]
            [HttpPost]
            public HttpResponseMessage LockAccountGame(PayloadApi p)
            {
                LogClass.SaveCustomerLog("LockAccountGame: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<LockAccountGameEnity>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.LOCK_ACCOUNT_GAME(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR LockAccountGame: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }


            /// <summary>
            /// Mở khóa đăng nhập tài khoản game
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            [Route("UnlockAccountGame")]
            [HttpPost]
            public HttpResponseMessage UnlockAccountGame(PayloadApi p)
            {
                LogClass.SaveCustomerLog("UnlockAccountGame: " + JsonConvert.SerializeObject(p));
                ResultApi result = new ResultApi();
                try
                {
                    var publisherInfo = publisher.CheckPublickey(p, version);
                    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
                    {
                        ManagerModel managerModel = new ManagerModel();
                        var data = JsonConvert.DeserializeObject<UnlockAccountGameEnity>(publisherInfo.data.ToString());
                        string msg = "";
                        result.status = managerModel.GameAcountModel.UNLOCK_ACCOUNT_GAME(data, ref msg);
                        result.msg = msg;
                    }
                    else
                        result = publisherInfo;
                }
                catch (Exception ex)
                {
                    LogClass.SaveError("ERROR UnlockAccountGame: " + ex.Message, ex, true);
                    result.status = (int)ERROR_CODDE.ERROR_EX;
                    result.msg = ex.Message;
                }
                return Request.CreateResponse(result);
            }
        }
    }
}