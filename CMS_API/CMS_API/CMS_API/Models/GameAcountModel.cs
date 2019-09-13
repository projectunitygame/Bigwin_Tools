using api_cms.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api_cms.Models
{
    public class GameAcountModel
    {
        private string connectString = ConnectionDB.GetConnectionDB("ConnectString_GamePortal_DB");
        private static GameAcountModel instance = null;
        private static readonly object padlock = new object();

        /// <summary>
        /// Trừ tiền user từ cms
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int DEDUCT_MONEY_USER(Entity.DeductGoldUser p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[API_DeductGold_User]";
                        cmd.Parameters.Add("@_ID", SqlDbType.Int);
                        cmd.Parameters["@_ID"].Value = p.ID;
                        cmd.Parameters.Add("@_AccountId", SqlDbType.BigInt);
                        cmd.Parameters["@_AccountId"].Value = p.AccountId;
                        cmd.Parameters.Add("@_Amount", SqlDbType.BigInt);
                        cmd.Parameters["@_Amount"].Value = p.Amount;
                        cmd.Parameters.Add("@_Description", SqlDbType.NVarChar,150);
                        cmd.Parameters["@_Description"].Value = p.Description;
                        cmd.Parameters.Add("@_UserName", SqlDbType.NVarChar,50);
                        cmd.Parameters["@_UserName"].Value = p.UserName;
                        cmd.Parameters.Add("@_UserID", SqlDbType.Int);
                        cmd.Parameters["@_UserID"].Value = p.UserID;
                        cmd.Parameters.Add("@_Balance", SqlDbType.BigInt);
                        cmd.Parameters["@_Balance"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@_ResponseStatus", SqlDbType.Int);
                        cmd.Parameters["@_ResponseStatus"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@_Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@_Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@_ResponseStatus"].Value.ToString());
                        msg = cmd.Parameters["@_Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR DEDUCT_MONEY_USER: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nDEDUCT_MONEY_USER " + log + "\r\n**********");
            }
        }
        /// <summary>
        /// Cộng tiền user từ cms
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int ADD_MONEY_USER(Entity.AddMoneyUser p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[API_AddMoneyUser]";
                        cmd.Parameters.Add("@UserID", SqlDbType.BigInt);
                        cmd.Parameters["@UserID"].Value = p.UserID;
                        cmd.Parameters.Add("@Reason", SqlDbType.NVarChar,200);
                        cmd.Parameters["@Reason"].Value = p.Reason;
                        cmd.Parameters.Add("@Amount", SqlDbType.Int);
                        cmd.Parameters["@Amount"].Value = p.Amount;
                        cmd.Parameters.Add("@SenderID", SqlDbType.VarChar,50);
                        cmd.Parameters["@SenderID"].Value = p.SenderID;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR ADD_MONEY_USER: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nADD_MONEY_USER " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Ghi log nạp thẻ
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int INPUT_CARD(Entity.CardObject p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_INPUT_CARD]";
                        cmd.Parameters.Add("@CardCode", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@CardCode"].Value = p.CardCode;
                        cmd.Parameters.Add("@CardSerial", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@CardSerial"].Value = p.CardSerial;
                        cmd.Parameters.Add("@Amount", SqlDbType.BigInt);
                        cmd.Parameters["@Amount"].Value = p.Amount;
                        cmd.Parameters.Add("@Experied", SqlDbType.NVarChar,30);
                        cmd.Parameters["@Experied"].Value = p.Experied;
                        cmd.Parameters.Add("@CardType", SqlDbType.Int);
                        cmd.Parameters["@CardType"].Value = p.CardType;
                        cmd.Parameters.Add("@TelCode", SqlDbType.NVarChar, 10);
                        cmd.Parameters["@TelCode"].Value = p.TelCode;
                        cmd.Parameters.Add("@TradeMark", SqlDbType.NVarChar, 10);
                        cmd.Parameters["@TradeMark"].Value = p.TradeMark;
                        cmd.Parameters.Add("@BuyTime", SqlDbType.DateTime);
                        cmd.Parameters["@BuyTime"].Value = p.BuyTime;
                        cmd.Parameters.Add("@TransactionCode", SqlDbType.NVarChar,30);
                        cmd.Parameters["@TransactionCode"].Value = p.TransactionCode;
                        cmd.Parameters.Add("@ResultCode", SqlDbType.NVarChar,10);
                        cmd.Parameters["@ResultCode"].Value = p.ResultCode;
                        cmd.Parameters.Add("@Status", SqlDbType.Bit);
                        cmd.Parameters["@Status"].Value = p.Status;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR INPUT_CARD: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nINPUT_CARD " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Cấu hình bot tài xỉu
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UPDATE_BOT_CONFIG_LUCK_DICE(Entity.UpdateBotConfigLuckDice p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_UPDATE_BOT_CONFIG_LUCK_DICE]";
                        cmd.Parameters.Add("@_MinBot", SqlDbType.Int);
                        cmd.Parameters["@_MinBot"].Value = p.MinBot;
                        cmd.Parameters.Add("@_MaxBot", SqlDbType.Int);
                        cmd.Parameters["@_MaxBot"].Value = p.MaxBot;
                        cmd.Parameters.Add("@_NumRichBot", SqlDbType.Int);
                        cmd.Parameters["@_NumRichBot"].Value = p.NumRichBot;
                        cmd.Parameters.Add("@_NumNormalBot", SqlDbType.Int);
                        cmd.Parameters["@_NumNormalBot"].Value = p.NumNormalBot;
                        cmd.Parameters.Add("@_NumPoorBot", SqlDbType.Int);
                        cmd.Parameters["@_NumPoorBot"].Value = p.NumPoorBot;
                        cmd.Parameters.Add("@_VipChangeRate", SqlDbType.Int);
                        cmd.Parameters["@_VipChangeRate"].Value = p.VipChangeRate;
                        cmd.Parameters.Add("@_NorChangeRate", SqlDbType.Int);
                        cmd.Parameters["@_NorChangeRate"].Value = p.NorChangeRate;
                        cmd.Parameters.Add("@_PoorChangeRate", SqlDbType.Int);
                        cmd.Parameters["@_PoorChangeRate"].Value = p.PoorChangeRate;
                        cmd.Parameters.Add("@_MinTimeChange", SqlDbType.Int);
                        cmd.Parameters["@_MinTimeChange"].Value = p.MinTimeChange;
                        cmd.Parameters.Add("@_MaxTimeChange", SqlDbType.Int);
                        cmd.Parameters["@_MaxTimeChange"].Value = p.MaxTimeChange;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR SET_JACKPOT_PRIZE: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nSET_JACKPOT_PRIZE " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Đập hũ
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int SET_JACKPOT_PRIZE(Entity.SetJackpotPrize p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_SET_JACKPOT_PRIZE]";
                        cmd.Parameters.Add("@_GameId", SqlDbType.Int);
                        cmd.Parameters["@_GameId"].Value = p.GameId;
                        cmd.Parameters.Add("@_RoomId", SqlDbType.Int);
                        cmd.Parameters["@_RoomId"].Value = p.RoomId;
                        cmd.Parameters.Add("@_AccountName", SqlDbType.NVarChar,30);
                        cmd.Parameters["@_AccountName"].Value = p.AccountName;
                        cmd.Parameters.Add("@_AccountID", SqlDbType.BigInt);
                        cmd.Parameters["@_AccountID"].Value = p.AccountID;
                        cmd.Parameters.Add("@_CreatorId", SqlDbType.VarChar,50);
                        cmd.Parameters["@_CreatorId"].Value = p.CreatorId;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR SET_JACKPOT_PRIZE: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nSET_JACKPOT_PRIZE " + log + "\r\n**********");
            }
        }

        public static GameAcountModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new GameAcountModel();
                        }
                    }
                }
                return instance;
            }
        }
        /// <summary>
        /// Cấu hình thẻ nạp
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int CONFIG_CARD (Entity.ConfigCard p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_CONFIG_CARD]";
                        cmd.Parameters.Add("@ID", SqlDbType.Int);
                        cmd.Parameters["@ID"].Value = p.ID;
                        cmd.Parameters.Add("@Enable", SqlDbType.Bit);
                        cmd.Parameters["@Enable"].Value = p.Enable;
                        cmd.Parameters.Add("@Promotion", SqlDbType.Int);
                        cmd.Parameters["@Promotion"].Value = p.Promotion;
                        cmd.Parameters.Add("@CashoutRate", SqlDbType.Int);
                        cmd.Parameters["@CashoutRate"].Value = p.CashoutRate;
                        cmd.Parameters.Add("@EnableCashout", SqlDbType.Bit);
                        cmd.Parameters["@EnableCashout"].Value = p.EnableCashout;
                        cmd.Parameters.Add("@TopupRate", SqlDbType.Int);
                        cmd.Parameters["@TopupRate"].Value = p.TopupRate;
                        cmd.Parameters.Add("@PromotionCashout", SqlDbType.Int);
                        cmd.Parameters["@PromotionCashout"].Value = p.PromotionCashout;
                        cmd.Parameters.Add("@PayOrderConfig", SqlDbType.NVarChar,50);
                        cmd.Parameters["@PayOrderConfig"].Value = p.PayOrderConfig;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR CONFIG_CARD: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nCONFIG_CARD " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Xóa giao dịch mua thẻ lỗi
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int DELETE_FAIL_TRANSACTION_CARD(Entity.DeleteFailTransactionCard p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_DELETE_FAIL_TRANSACTION_CARD]";
                        cmd.Parameters.Add("@_ID", SqlDbType.BigInt);
                        cmd.Parameters["@_ID"].Value = p.ID;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR DELETE_FAIL_TRANSACTION_CARD: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nDELETE_FAIL_TRANSACTION_CARD " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Xóa yêu cầu rút tiền(thẻ)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int DELETE_CASH_OUT_CARD(Entity.DeleteCashOutCard p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_DELETE_CASH_OUT_CARD]";
                        cmd.Parameters.Add("@_CardID", SqlDbType.BigInt);
                        cmd.Parameters["@_CardID"].Value = p.CardID;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR DELETE_CASH_OUT_CARD: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nDELETE_CASH_OUT_CARD " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Duyệt thẻ
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int ACCEPT_CARD(Entity.AcceptCard p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_ACCEPT_CARD]";
                        cmd.Parameters.Add("@_CardID", SqlDbType.BigInt);
                        cmd.Parameters["@_CardID"].Value = p.CardID;
                        cmd.Parameters.Add("@_AcceptorID", SqlDbType.VarChar,50);
                        cmd.Parameters["@_AcceptorID"].Value = p.AcceptorID;
                        cmd.Parameters.Add("@_AcceptorName", SqlDbType.NVarChar,150);
                        cmd.Parameters["@_AcceptorName"].Value = p.AcceptorName;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR ACCEPT_CARD: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nACCEPT_CARD " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Trừ quỹ game
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int EXCEPT_FUND_GAME (Entity.ExceptFundGame p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_EXCEPT_FUND_GAME]";
                        cmd.Parameters.Add("@GameID", SqlDbType.Int);
                        cmd.Parameters["@GameID"].Value = p.GameID;
                        cmd.Parameters.Add("@RoomID", SqlDbType.Int);
                        cmd.Parameters["@RoomID"].Value = p.RoomID;
                        cmd.Parameters.Add("@Value", SqlDbType.BigInt);
                        cmd.Parameters["@Value"].Value = p.Value;
                        cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar,50);
                        cmd.Parameters["@AccountName"].Value = p.AccountName;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR EXCEPT_FUND_GAME: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nEXCEPT_FUND_GAME " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Xóa event giftcode
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int DELETE_EVENT_GIFTCODE(Entity.DeleteEventGiftCode p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_DELETE_EVENT_GIFTCODE]";
                        cmd.Parameters.Add("@ID", SqlDbType.Int);
                        cmd.Parameters["@ID"].Value = p.ID;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        //cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //msg = cmd.Parameters["@Msg"].Value.ToString();
                        msg = code == 1 ? "Xóa giftcode thành công" : "Xóa giftcode thất bại";
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR DELETE_EVENT_GIFTCODE: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nDELETE_EVENT_GIFTCODE " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Tạo event giftcode mới
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>

        /// <summary>
        /// Cập nhật ngày event
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UPDATE_EVENT_GIFTCODE(Entity.UpdateEventGiftCode p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_UPDATE_EVENT_GIFTCODE]";
                        cmd.Parameters.Add("@ID", SqlDbType.Int);
                        cmd.Parameters["@ID"].Value = p.ID;
                        cmd.Parameters.Add("@Expired", SqlDbType.DateTime);
                        cmd.Parameters["@Expired"].Value = p.Expired;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        //cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //msg = cmd.Parameters["@Msg"].Value.ToString();
                        msg = code == 1 ? "Update giftcode thành công" : "Update giftcode thất bại";
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR UPDATE_EVENT_GIFTCODE: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUPDATE_EVENT_GIFTCODE " + log + "\r\n**********");
            }
        }

        public int CREATE_EVENT_GIFTCODE(Entity.CreateEventGiftCode p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_CREATE_EVENT_GIFTCODE]";
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar,200);
                        cmd.Parameters["@Name"].Value = p.Name;
                        cmd.Parameters.Add("@Created", SqlDbType.Int);
                        cmd.Parameters["@Created"].Value = p.Created;
                        cmd.Parameters.Add("@Price", SqlDbType.BigInt);
                        cmd.Parameters["@Price"].Value = p.Price;
                        cmd.Parameters.Add("@Type", SqlDbType.Int);
                        cmd.Parameters["@Type"].Value = p.Type;
                        cmd.Parameters.Add("@AgencyId", SqlDbType.Int);
                        cmd.Parameters["@AgencyId"].Value = p.AgencyId;
                        cmd.Parameters.Add("@Qty", SqlDbType.Int);
                        cmd.Parameters["@Qty"].Value = p.Qty;
                        cmd.Parameters.Add("@Prefix", SqlDbType.VarChar, 5);
                        cmd.Parameters["@Prefix"].Value = p.Prefix;
                        cmd.Parameters.Add("@Expired", SqlDbType.DateTime);
                        cmd.Parameters["@Expired"].Value = p.Expired;

                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("CREATE_EVENT_GIFTCODE CREATE_NOTIFICATION_GAME: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nCREATE_EVENT_GIFTCODE " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Xóa thông báo game
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int DELETE_SCHEME_NOTIFICATION_GAME(Entity.DeleteSchemeNotificationGameEnity p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_DELETE_SCHEME_NOTIFICATION]";
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = p.Id;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        //cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //msg = cmd.Parameters["@Msg"].Value.ToString();
                        msg = code == 1 ? "Xóa thông báo game thành công" : "Xóa thông báo game thất bại";
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR DELETE_SCHEME_NOTIFICATION_GAME: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nDELETE_SCHEME_NOTIFICATION_GAME " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Cập nhật thông báo game
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UPDATE_SCHEME_NOTIFICATION_GAME(Entity.UpdateSchemeNotificationGameEnity p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_UPDATE_SCHEME_NOTIFICATION]";
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = p.Id;
                        cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@Title"].Value = p.Title;
                        cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Message"].Value = p.Message;
                        cmd.Parameters.Add("@Platform", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Platform"].Value = p.Platform;
                        cmd.Parameters.Add("@DateSend", SqlDbType.DateTime);
                        cmd.Parameters["@DateSend"].Value = p.DateSend;
                        cmd.Parameters.Add("@Loop", SqlDbType.VarChar, 30);
                        cmd.Parameters["@Loop"].Value = p.Loop;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = p.Status;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        //cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //msg = cmd.Parameters["@Msg"].Value.ToString();
                        msg = code == 1 ? "Cập nhật thông báo game thành công" : "Cập nhật thông báo game thất bại";
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR UPDATE_SCHEME_NOTIFICATION_GAME: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUPDATE_SCHEME_NOTIFICATION_GAME " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Tạo thông báo game mới
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int CREATE_SCHEME_NOTIFICATION_GAME(Entity.CreateSchemeNotificationGameEnity p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_CREATE_SCHEME_NOTIFICATION]";
                        cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@Title"].Value = p.Title;
                        cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Message"].Value = p.Message;
                        cmd.Parameters.Add("@Platform", SqlDbType.NVarChar,50);
                        cmd.Parameters["@Platform"].Value = p.Platform;
                        cmd.Parameters.Add("@DateSend", SqlDbType.DateTime);
                        cmd.Parameters["@DateSend"].Value = p.DateSend;
                        cmd.Parameters.Add("@Loop", SqlDbType.VarChar, 30);
                        cmd.Parameters["@Loop"].Value = p.Loop;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = p.Status;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        //cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //msg = cmd.Parameters["@Msg"].Value.ToString();
                        msg = code == 1 ? "Tạo thông báo game thành công" : "Tạo thông báo game thất bại";
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR CREATE_NOTIFICATION_GAME: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nCREATE_NOTIFICATION_GAME " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Khóa chat tài khoản game
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int LOCK_CHAT_ACCOUNT_GAME(Entity.LockChatAccountGameEnity p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_LOCK_CHAT_ACCOUNT_GAME]";
                        cmd.Parameters.Add("@AccountID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@AccountID"].Value = p.AccountID;
                        cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Reason"].Value = p.Reason;
                        cmd.Parameters.Add("@Author", SqlDbType.Int);
                        cmd.Parameters["@Author"].Value = p.Author;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        //cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //msg = cmd.Parameters["@Msg"].Value.ToString();
                        msg = code == 1 ? "Khóa chat tài khoản game thành công" : "Khóa chat tài khoản game thất bại";
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR LOCK_CHAT_ACCOUNT_GAME: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nLOCK_CHAT_ACCOUNT_GAME " + log + "\r\n**********");
            }
        }


        /// <summary>
        /// Mở khóa chat tài khoản game
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UNLOCK_CHAT_ACCOUNT_GAME(Entity.UnlockChatAccountGameEnity p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_UNLOCK_CHAT_ACCOUNT_GAME]";
                        cmd.Parameters.Add("@AccountID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@AccountID"].Value = p.AccountID;
                        cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Reason"].Value = p.Reason;
                        cmd.Parameters.Add("@Author", SqlDbType.Int);
                        cmd.Parameters["@Author"].Value = p.Author;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        //cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //msg = cmd.Parameters["@Msg"].Value.ToString();
                        msg = code == 1 ? "Mở khóa chat tài khoản game thành công" : "Mở khóa chat tài khoản game thất bại";
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR UNLOCK_CHAT_ACCOUNT_GAME: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUNLOCK_CHAT_ACCOUNT_GAME " + log + "\r\n**********");
            }
        }



        /// <summary>
        /// Khóa đăng nhập tài khoản game
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int LOCK_ACCOUNT_GAME(Entity.LockAccountGameEnity p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_LOCK_ACCOUNT_GAME]";
                        cmd.Parameters.Add("@AccountID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@AccountID"].Value = p.AccountID;
                        cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Reason"].Value = p.Reason;
                        cmd.Parameters.Add("@Author", SqlDbType.Int);
                        cmd.Parameters["@Author"].Value = p.Author;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        //cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //msg = cmd.Parameters["@Msg"].Value.ToString();
                        msg = code == 1 ? "Khóa tài khoản game thành công" : "Khóa tài khoản game thất bại";
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR LOCK_ACCOUNT_GAME: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nLOCK_ACCOUNT_GAME " + log + "\r\n**********");
            }
        }


        /// <summary>
        /// Mở khóa đăng nhập tài khoản game
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UNLOCK_ACCOUNT_GAME(Entity.UnlockAccountGameEnity p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[SP_TOOL_UNLOCK_ACCOUNT_GAME]";
                        cmd.Parameters.Add("@AccountID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@AccountID"].Value = p.AccountID;
                        cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Reason"].Value = p.Reason;
                        cmd.Parameters.Add("@Author", SqlDbType.Int);
                        cmd.Parameters["@Author"].Value = p.Author;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        //cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //msg = cmd.Parameters["@Msg"].Value.ToString();
                        msg = code == 1 ? "Mở khóa tài khoản game thành công" : "Mở khóa tài khoản game thất bại";
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR LOCK_ACCOUNT_GAME: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nLOCK_ACCOUNT_GAME " + log + "\r\n**********");
            }
        }
    }
}