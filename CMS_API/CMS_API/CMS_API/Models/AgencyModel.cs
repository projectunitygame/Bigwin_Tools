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
    public class AgencyModel
    {
        private string connectString = ConnectionDB.GetConnectionDB("ConnectString_GamePortal_DB");
        private static AgencyModel instance = null;
        private static readonly object padlock = new object();
        public static AgencyModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new AgencyModel();
                        }
                    }
                }
                return instance;
            }
        }



        /// <summary>
        /// Cập nhật thông tin đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UpdateInformation_Agency(Entity.UpdateInformationAgencyEntity p, ref string msg)
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
                        cmd.CommandText = "API_UpdateInformation_Agency";
                        cmd.Parameters.Add("@AgencyID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@AgencyID"].Value = p.agencyID;
                        cmd.Parameters.Add("@Information", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Information"].Value = p.information;
                        cmd.Parameters.Add("@CreatorID", SqlDbType.Int);
                        cmd.Parameters["@CreatorID"].Value = p.creatorID;
                        cmd.Parameters.Add("@CreatorName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CreatorName"].Value = p.creatorName;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR UpdateInformation_Agency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUpdateInformation_Agency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Cập nhật trạng thái hiển thị đại lý trong game
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UpdateDisplay_Agency(Entity.UpdateDisplayAgencyEntity p, ref string msg)
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
                        cmd.CommandText = "API_UpdateDisplay_Agency";
                        cmd.Parameters.Add("@AgencyID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@AgencyID"].Value = p.agencyID;
                        cmd.Parameters.Add("@Display", SqlDbType.Bit);
                        cmd.Parameters["@Display"].Value = p.display;
                        cmd.Parameters.Add("@CreatorID", SqlDbType.Int);
                        cmd.Parameters["@CreatorID"].Value = p.creatorID;
                        cmd.Parameters.Add("@CreatorName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CreatorName"].Value = p.creatorName;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR UpdateDisplay_Agency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUpdateDisplay_Agency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Cập nhật thông tin FB
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UpdateFB_Agency(Entity.UpdateFBAgencyEntity p, ref string msg)
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
                        cmd.CommandText = "API_UpdateFB_Agency";
                        cmd.Parameters.Add("@AgencyID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@AgencyID"].Value = p.agencyID;
                        cmd.Parameters.Add("@FB", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@FB"].Value = p.fb;
                        cmd.Parameters.Add("@CreatorID", SqlDbType.Int);
                        cmd.Parameters["@CreatorID"].Value = p.creatorID;
                        cmd.Parameters.Add("@CreatorName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CreatorName"].Value = p.creatorName;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR UpdateFB_Agency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUpdateFB_Agency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Chuyển tiền cho đại lý khác
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int TransferMoneyToAgency(Entity.TransferMoneyToAgency p, ref string msg, ref string otp,ref string phone)
        {
            string log = "TransferMoneyToAgency: " + JsonConvert.SerializeObject(p);
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
                        cmd.CommandText = "API_TransferMoneyToAgency";
                        cmd.Parameters.Add("@SenderID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@SenderID"].Value = p.senderID;
                        cmd.Parameters.Add("@RecipientID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@RecipientID"].Value = p.recipientID;
                        cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 1000);
                        cmd.Parameters["@Reason"].Value = p.reason;
                        cmd.Parameters.Add("@Amount", SqlDbType.Money);
                        cmd.Parameters["@Amount"].Value = p.amount;
                        cmd.Parameters.Add("@OTP", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTP"].Value = p.OTP;
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters["@IP"].Value = p.ip;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@OTPNew", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTPNew"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 15);
                        cmd.Parameters["@Phone"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        otp = cmd.Parameters["@OTPNew"].Value.ToString();
                        phone = cmd.Parameters["@Phone"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nOTP: " + otp;
                        log += "\r\nPhone: " + phone;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR TransferMoneyToAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nTransferMoneyToAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Chuyển tiền cho user trong game
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int TransferMoneyToUser(Entity.TransferMoneyToUser p, ref string msg, ref string otp, ref string phone)
        {
            string log = "TransferMoneyToUser: " + JsonConvert.SerializeObject(p);
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
                        cmd.CommandText = "API_TransferMoneyToUser";
                        cmd.Parameters.Add("@SenderID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@SenderID"].Value = p.senderID;
                        cmd.Parameters.Add("@RecipientID", SqlDbType.BigInt);
                        cmd.Parameters["@RecipientID"].Value = p.recipientID;
                        cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 1000);
                        cmd.Parameters["@Reason"].Value = p.reason;
                        cmd.Parameters.Add("@Amount", SqlDbType.Money);
                        cmd.Parameters["@Amount"].Value = p.amount;
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters["@IP"].Value = p.ip;
                        cmd.Parameters.Add("@OTP", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTP"].Value = p.OTP;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@OTPNew", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTPNew"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 15);
                        cmd.Parameters["@Phone"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        otp = cmd.Parameters["@OTPNew"].Value.ToString();
                        phone = cmd.Parameters["@Phone"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                        log += "\r\nOtp: " + otp;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR TransferMoneyToUser: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nTransferMoneyToUser " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Thay đổi mật khẩu
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int ChangePasswordAgency(Entity.ChangePasswordAgency p, ref string msg)
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
                        cmd.CommandText = "API_ChangePassword_Agency";
                        cmd.Parameters.Add("@UwinID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@UwinID"].Value = p.uwinID;
                        cmd.Parameters.Add("@PasswordNew", SqlDbType.VarChar, 30);
                        cmd.Parameters["@PasswordNew"].Value = p.passwordNew;
                        cmd.Parameters.Add("@PasswordOld", SqlDbType.VarChar, 30);
                        cmd.Parameters["@PasswordOld"].Value = p.passwordOld;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR ChangePasswordAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nChangePasswordAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Thay đổi hạn mức chuyển tiền đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int ChangeLimitTransactionAgency(Entity.ChangeLimitTransactionAgency p, ref string msg)
        {
            string log = JsonConvert.SerializeObject(p);
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
                        cmd.CommandText = "API_ChangeLimitTransaction";
                        cmd.Parameters.Add("@UwinID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@UwinID"].Value = p.uwinID;
                        cmd.Parameters.Add("@LimitTransaction", SqlDbType.Money);
                        cmd.Parameters["@LimitTransaction"].Value = p.limitTransaction;
                        cmd.Parameters.Add("@LimitTransactionDaily", SqlDbType.Money);
                        cmd.Parameters["@LimitTransactionDaily"].Value = p.limitTransactionDaily;
                        cmd.Parameters.Add("@IsOTP", SqlDbType.Bit);
                        cmd.Parameters["@IsOTP"].Value = p.isOTP;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR ChangeLimitTransactionAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nChangeLimitTransactionAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Lấy thông tin đại lý UwinID
        /// </summary>
        /// <param name="uwinID"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Entity.AgencyInfoEntity GetAgencyByID(string uwinID, ref int code, ref string msg)
        {
            Entity.AgencyInfoEntity agency = null;
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "API_GetAgencyInfo";
                        cmd.Parameters.Add("@UwinID", SqlDbType.NVarChar, 200);
                        cmd.Parameters["@UwinID"].Value = uwinID;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                            msg = cmd.Parameters["@Msg"].Value.ToString();
                            if(code == 1)
                            {
                                agency = new Entity.AgencyInfoEntity()
                                {
                                    agencyCode = dt.Rows[0]["AgencyCode"].ToString(),
                                    agencyID = int.Parse(dt.Rows[0]["AgencyID"].ToString()),
                                    balance = decimal.Parse(dt.Rows[0]["Balance"].ToString()),
                                    balance_bonus = decimal.Parse(dt.Rows[0]["Balance_bonus"].ToString()),
                                    balance_lock = decimal.Parse(dt.Rows[0]["Balance_Lock"].ToString()),
                                    displayName = dt.Rows[0]["DisplayName"].ToString(),
                                    email = dt.Rows[0]["Email"].ToString(),
                                    phone = dt.Rows[0]["Phone"].ToString(),
                                    emailActive = bool.Parse(dt.Rows[0]["EmailActive"].ToString()),
                                    phoneActive = bool.Parse(dt.Rows[0]["PhoneActive"].ToString()),
                                    isOTP = bool.Parse(dt.Rows[0]["IsOTP"].ToString()),
                                    limitTransaction = decimal.Parse(dt.Rows[0]["LimitTransaction"].ToString()),
                                    limitTransactionDaily = decimal.Parse(dt.Rows[0]["LimitTransactionDaily"].ToString()),
                                    dateCreated = dt.Rows[0]["DateCreated"].ToString(),
                                    masterID = dt.Rows[0]["MasterID"].ToString(),
                                    display = bool.Parse(dt.Rows[0]["Display"].ToString()),
                                    fb = dt.Rows[0]["FB"].ToString(),
                                    information = dt.Rows[0]["Information"].ToString()
                                };
                            }
                        }
                    }
                }
                return agency;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR GetAgencyByID: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mo khóa tài khoản đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UnLockAgency(Entity.LockAgencyEntity p, ref string msg)
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
                        cmd.CommandText = "API_UnlockAgency";
                        cmd.Parameters.Add("@AgencyID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@AgencyID"].Value = p.agencyID;
                        cmd.Parameters.Add("@CreatorID", SqlDbType.Int);
                        cmd.Parameters["@CreatorID"].Value = p.creatorID;
                        cmd.Parameters.Add("@CreatorName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CreatorName"].Value = p.creatorName;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR UnLockAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUnLockAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Khoa tai khoan đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int LockAgency(Entity.LockAgencyEntity p, ref string msg)
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
                        cmd.CommandText = "API_LockAgency";
                        cmd.Parameters.Add("@AgencyID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@AgencyID"].Value = p.agencyID;
                        cmd.Parameters.Add("@Note", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Note"].Value = p.note != null ? p.note : "";
                        cmd.Parameters.Add("@CreatorID", SqlDbType.Int);
                        cmd.Parameters["@CreatorID"].Value = p.creatorID;
                        cmd.Parameters.Add("@CreatorName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CreatorName"].Value = p.creatorName;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR LockAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nLockAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Tạo tài khoản đại lý mới
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int CreateAgency(Entity.AgencyEntity p, ref string msg)
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
                        cmd.CommandText = "API_CreateAgency";
                        cmd.Parameters.Add("@AgencyCode", SqlDbType.VarChar, 10);
                        cmd.Parameters["@AgencyCode"].Value = p.agencyCode;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 30);
                        cmd.Parameters["@Password"].Value = p.password;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 80);
                        cmd.Parameters["@Email"].Value = p.email;
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10);
                        cmd.Parameters["@Phone"].Value = p.phone;
                        cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@DisplayName"].Value = p.displayName;
                        cmd.Parameters.Add("@OwnerID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@OwnerID"].Value = "";
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters["@IP"].Value = p.IP;
                        cmd.Parameters.Add("@LimitTransaction", SqlDbType.Money);
                        cmd.Parameters["@LimitTransaction"].Value = p.limitTransaction;
                        cmd.Parameters.Add("@LimitTransactionDaily", SqlDbType.Money);
                        cmd.Parameters["@LimitTransactionDaily"].Value = p.limitTransactionDaily;
                        cmd.Parameters.Add("@CreatorID", SqlDbType.Int);
                        cmd.Parameters["@CreatorID"].Value = p.creatorID;
                        cmd.Parameters.Add("@CreatorName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CreatorName"].Value = p.creatorName;
                        cmd.Parameters.Add("@DeviceID", SqlDbType.VarChar, 150);
                        cmd.Parameters["@DeviceID"].Value = "";
                        cmd.Parameters.Add("@Infomation", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Infomation"].Value = p.infomation != null ? p.infomation : "";
                        cmd.Parameters.Add("@Display", SqlDbType.Bit);
                        cmd.Parameters["@Display"].Value = p.display;
                        cmd.Parameters.Add("@FB", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@FB"].Value = p.FB != null ? p.FB : "";
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR CreateAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nCreateAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Tạo tài khoản đại lý cấp 2
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int CreateAgency_C2(Entity.AgencyEntity p, ref string msg)
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
                        cmd.CommandText = "API_CreateAgency_C2";
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 30);
                        cmd.Parameters["@Password"].Value = p.password;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 80);
                        cmd.Parameters["@Email"].Value = p.email;
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10);
                        cmd.Parameters["@Phone"].Value = p.phone;
                        cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@DisplayName"].Value = p.displayName;
                        cmd.Parameters.Add("@OwnerID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@OwnerID"].Value = p.ownerID;
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters["@IP"].Value = p.IP;
                        cmd.Parameters.Add("@LimitTransaction", SqlDbType.Money);
                        cmd.Parameters["@LimitTransaction"].Value = p.limitTransaction;
                        cmd.Parameters.Add("@LimitTransactionDaily", SqlDbType.Money);
                        cmd.Parameters["@LimitTransactionDaily"].Value = p.limitTransactionDaily;
                        cmd.Parameters.Add("@CreatorID", SqlDbType.Int);
                        cmd.Parameters["@CreatorID"].Value = p.creatorID;
                        cmd.Parameters.Add("@CreatorName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CreatorName"].Value = p.creatorName;
                        cmd.Parameters.Add("@DeviceID", SqlDbType.VarChar, 150);
                        cmd.Parameters["@DeviceID"].Value = "";
                        cmd.Parameters.Add("@Infomation", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Infomation"].Value = p.infomation != null ? p.infomation : "";
                        cmd.Parameters.Add("@Display", SqlDbType.Bit);
                        cmd.Parameters["@Display"].Value = p.display;
                        cmd.Parameters.Add("@FB", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@FB"].Value = p.FB != null ? p.FB : "";
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR CreateAgency_C2: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nCreateAgency_C2 " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Nap tien cho đại lý cấp 1
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int AddMoneyAgency(Entity.AddMoneyAgencyEntity p, ref string msg)
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
                        cmd.CommandText = "API_AddMoneyAgency";
                        cmd.Parameters.Add("@RecipientID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@RecipientID"].Value = p.agencyID;
                        cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 1000);
                        cmd.Parameters["@Reason"].Value = p.reason;
                        cmd.Parameters.Add("@Amount", SqlDbType.Money);
                        cmd.Parameters["@Amount"].Value = p.amount;
                        cmd.Parameters.Add("@Bonus", SqlDbType.Money);
                        cmd.Parameters["@Bonus"].Value = p.bonus;
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters["@IP"].Value = p.IP;
                        cmd.Parameters.Add("@CreatorID", SqlDbType.Int);
                        cmd.Parameters["@CreatorID"].Value = p.creatorID;
                        cmd.Parameters.Add("@CreatorName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CreatorName"].Value = p.creatorName;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
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
                LogClass.SaveError("ERROR AddMoneyAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nAddMoneyAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Tìm kiếm thông tin tài khoản đại lý
        /// </summary>
        /// <param name="uwinID"></param>
        /// <param name="param"></param>
        /// <param name="topN"></param>
        /// <returns></returns>
        public DataTable FindAgency(string uwinID, string param, int topN = 20)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "API_FindAgency_v1";
                        cmd.Parameters.Add("@Input", SqlDbType.NVarChar, 200);
                        cmd.Parameters["@Input"].Value = param;
                        cmd.Parameters.Add("@TopN", SqlDbType.Int);
                        cmd.Parameters["@TopN"].Value = topN;
                        cmd.Parameters.Add("@UwinID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@UwinID"].Value = uwinID;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR FindAgency: " + ex);
                return null;
            }
        }

        /// <summary>
        /// tim kiem thông tin game account
        /// </summary>
        /// <param name="param"></param>
        /// <param name="topN"></param>
        /// <returns></returns>
        public DataTable FindGameAccount(string param, int topN = 20)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "API_FindGameAccount";
                        cmd.Parameters.Add("@Input", SqlDbType.NVarChar, 200);
                        cmd.Parameters["@Input"].Value = param;
                        cmd.Parameters.Add("@TopN", SqlDbType.Int);
                        cmd.Parameters["@TopN"].Value = topN;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR FindGameAccount: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Đăng nhập tài khoản đại lý
        /// </summary>
        /// <param name="P"></param>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Entity.AgencyInfoEntity LoginAgency(Entity.LoginAgencyEntity P, ref int code, ref string msg)
        {
            string log = "LoginAgency: " + JsonConvert.SerializeObject(P);
            Entity.AgencyInfoEntity agency = null;
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (P.loginID.Contains("@"))
                        {
                            cmd.CommandText = "API_LoginAgencyWithEmail";
                            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 80);
                            cmd.Parameters["@Email"].Value = P.loginID;
                            log += "\r\nLoginAgencyWithEmail: " + P.loginID;
                        }
                        else
                        {
                            cmd.CommandText = "API_LoginAgencyWithPhone";
                            cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10);
                            cmd.Parameters["@Phone"].Value = P.loginID;
                            log += "\r\nLoginAgencyWithPhone: " + P.loginID;
                        }
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 30);
                        cmd.Parameters["@Password"].Value = P.password;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                            msg = cmd.Parameters["@Msg"].Value.ToString();
                            if(code == 1)
                            {
                                agency = new Entity.AgencyInfoEntity()
                                {
                                    agencyCode = dt.Rows[0]["AgencyCode"].ToString(),
                                    agencyID = int.Parse(dt.Rows[0]["AgencyID"].ToString()),
                                    balance = decimal.Parse(dt.Rows[0]["Balance"].ToString()),
                                    balance_bonus = decimal.Parse(dt.Rows[0]["Balance_bonus"].ToString()),
                                    balance_lock = decimal.Parse(dt.Rows[0]["Balance_Lock"].ToString()),
                                    displayName = dt.Rows[0]["DisplayName"].ToString(),
                                    email = dt.Rows[0]["Email"].ToString(),
                                    phone = dt.Rows[0]["Phone"].ToString(),
                                    emailActive = bool.Parse(dt.Rows[0]["EmailActive"].ToString()),
                                    phoneActive = bool.Parse(dt.Rows[0]["PhoneActive"].ToString()),
                                    isOTP = bool.Parse(dt.Rows[0]["IsOTP"].ToString()),
                                    limitTransaction = decimal.Parse(dt.Rows[0]["LimitTransaction"].ToString()),
                                    limitTransactionDaily = decimal.Parse(dt.Rows[0]["LimitTransactionDaily"].ToString()),
                                    dateCreated = dt.Rows[0]["DateCreated"].ToString(),
                                    masterID = dt.Rows[0]["MasterID"].ToString()
                                };
                            }
                            log += "\r\nCode: " + code;
                            log += "\r\nMsg: " + msg;
                            log += "\r\n" + JsonConvert.SerializeObject(agency);
                        }
                    }
                }
                return agency;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR LoginAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nLoginAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Kiem tra sdt để gửi OTP thiết lập mật khẩu mới
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="msg"></param>
        /// <param name="otp"></param>
        /// <returns></returns>
        public int CheckRessetPasswordAgency(string phone, ref string msg, ref string otp)
        {
            string log = "";
            int code = 0;
            try
            {
                log = "phone: " + phone;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "API_CheckResetPasswordAgency";
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10);
                        cmd.Parameters["@Phone"].Value = phone;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@OTP", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTP"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        otp = cmd.Parameters["@OTP"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                        log += "\r\nOTP: " + otp;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR CheckRessetPasswordAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nCheckRessetPasswordAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Thiết lập mật khẩu mới cho đại lý
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="otp"></param>
        /// <param name="msg"></param>
        /// <param name="passwordNew"></param>
        /// <returns></returns>
        public int RessetPasswordAgency(string phone, string otp, ref string msg, ref string passwordNew)
        {
            string log = "";
            int code = 0;
            try
            {
                log = "phone: " + phone;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "API_ResetPasswordAgency";
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10);
                        cmd.Parameters["@Phone"].Value = phone;
                        cmd.Parameters.Add("@OTP", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTP"].Value = otp;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@PasswordNew", SqlDbType.VarChar, 8);
                        cmd.Parameters["@PasswordNew"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        passwordNew = cmd.Parameters["@PasswordNew"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR RessetPasswordAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nRessetPasswordAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Kich hoat số điện thoai đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <param name="otp"></param>
        /// <returns></returns>
        public int ActivePhoneAgency(Entity.ActivePhoneAgency p, ref string msg, ref string otp)
        {
            string log = "ActivePhoneAgency: " + JsonConvert.SerializeObject(p);
            int code = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "API_ActivePhoneAgency";
                        cmd.Parameters.Add("@UwinID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@UwinID"].Value = p.uwinID;
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10);
                        cmd.Parameters["@Phone"].Value = p.phone;
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters["@IP"].Value = p.ip;
                        cmd.Parameters.Add("@OTP", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTP"].Value = p.OTP;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@OTPNew", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTPNew"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        otp = cmd.Parameters["@OTPNew"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                        log += "\r\nOTP: " + otp;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR ActivePhoneAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nActivePhoneAgency " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Thay đổi sđt đại lý
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <param name="otp"></param>
        /// <returns></returns>
        public int ChangePhoneAgency(Entity.ChangePhoneAgency p, ref string msg, ref string otp)
        {
            string log = "ChangePhoneAgency: " + JsonConvert.SerializeObject(p);
            int code = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "API_ChangePhone_Agency";
                        cmd.Parameters.Add("@UwinID", SqlDbType.VarChar, 15);
                        cmd.Parameters["@UwinID"].Value = p.uwinID;
                        cmd.Parameters.Add("@PhoneCurrent", SqlDbType.VarChar, 10);
                        cmd.Parameters["@PhoneCurrent"].Value = p.phoneOld;
                        cmd.Parameters.Add("@PhoneNew", SqlDbType.VarChar, 10);
                        cmd.Parameters["@PhoneNew"].Value = p.phoneNew;
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters["@IP"].Value = p.ip;
                        cmd.Parameters.Add("@OTP", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTP"].Value = p.OTP;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Key"].Value = Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@OTPNew", SqlDbType.VarChar, 8);
                        cmd.Parameters["@OTPNew"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        otp = cmd.Parameters["@OTPNew"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                        log += "\r\nOTP: " + otp;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR ChangePhoneAgency: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nChangePhoneAgency " + log + "\r\n**********");
            }
        }
    }
}