using CMS_Tools.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CMS_Tools.Model
{
    public class AccountModel
    {
        private static AccountModel instance = null;
        private static readonly object padlock = new object();
        public static AccountModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new AccountModel();
                        }
                    }
                }
                return instance;
            }
        }

        string connectString = ConnectionDB.GetConnectionDB(Constants.STR_CONNECT_IDENTITY + "ManamentCMSTools_DB");
        string connectString2 = ConnectionDB.GetConnectionDB(Constants.STR_CONNECT_IDENTITY + "AccountSystem_DB");
        //public AccountModel()
        //{
        //}
        //public AccountModel(string connect)
        //{
        //    connectString = ConnectionDB.GetConnectionDB(connect);
        //}

        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="loginType"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int ResetPassword(string loginId, byte loginType, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_ResetNewPassword";
                        cmd.Parameters.Add("@LoginId", SqlDbType.VarChar, 50);
                        cmd.Parameters["@LoginId"].Value = loginId;
                        cmd.Parameters.Add("@LoginType", SqlDbType.TinyInt);
                        cmd.Parameters["@LoginType"].Value = loginType;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Password"].Value = password;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error ResetPassword: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// CheckResetPassword
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="loginType"></param>
        /// <returns></returns>
        public int CheckResetPassword(string loginId, byte loginType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_CheckResetPassword";
                        cmd.Parameters.Add("@LoginID", SqlDbType.VarChar, 50);
                        cmd.Parameters["@LoginID"].Value = loginId;
                        cmd.Parameters.Add("@LoginType", SqlDbType.TinyInt);
                        cmd.Parameters["@LoginType"].Value = loginType;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error UpdateStatusAccount: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UpdateStatusAccount
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateStatusAccount(long accountId, byte status, int group, int publisherId, string phone, string position, string accountCode, string userName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_UpdateStatusAccount";
                        cmd.Parameters.Add("@AccountId", SqlDbType.BigInt);
                        cmd.Parameters["@AccountId"].Value = accountId;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = status;
                        cmd.Parameters.Add("@GroupId", SqlDbType.Int);
                        cmd.Parameters["@GroupId"].Value = group;
                        cmd.Parameters.Add("@PublisherId", SqlDbType.Int);
                        cmd.Parameters["@PublisherId"].Value = publisherId;
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10);
                        cmd.Parameters["@Phone"].Value = phone;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Position", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Position"].Value = position != null ? position : "";
                        cmd.Parameters.Add("@AccountCode", SqlDbType.VarChar, 10);
                        cmd.Parameters["@AccountCode"].Value = accountCode;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = userName;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error UpdateStatusAccount: " + ex, ex);
                throw new Exception(ex.ToString());
            }
        }

        public Dictionary<int, string> GetAccountRule(long accountId){
            try
            {
                Dictionary<int, string> listRule = new Dictionary<int, string>();
                return listRule;
                //int code = -1;
                //var dt = GetMenuUsers(ref code);
                //if (code == 0)
                //{
                //    foreach (var item in dt.Rows)
                //    {
                //        for (int j = 0; j < dt.Columns.Count; j++)
                //        {
                            
                //        }
                //    }
                //}
                //else {
                //    return new Dictionary<int, string>();
                //}
            }
            catch (Exception)
            {
                return null;
            }
        }      

        /// <summary>
        /// LockAccount
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public int LockAccount(string accountId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_LockAccount";
                        cmd.Parameters.Add("@AccountId", SqlDbType.VarChar, 500);
                        cmd.Parameters["@AccountId"].Value = accountId;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error GetAccountList: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetAccountList
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetAccountList(ref int? code)
        {
            try
            {
                code = -1;
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    using(SqlCommand cmd = new SqlCommand()){
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetAccountList";
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;

                        DataTable dt = new DataTable();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error GetAccountList: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// LoginOut
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int LoginOut(string token)
        {
            try
            {
                int code = -1;
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Logout";
                        cmd.Parameters.Add("@logoutType", SqlDbType.TinyInt);
                        cmd.Parameters["@logoutType"].Value = (byte)Lib.Constants.LOGOUT_TYPE.SINGLE_DEVICE;
                        cmd.Parameters.Add("@Token", SqlDbType.VarChar, 32);
                        cmd.Parameters["@Token"].Value = token;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        return (int)code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error LoginWithToken: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// LoginWithToken
        /// </summary>
        /// <param name="token"></param>
        /// <param name="ip"></param>
        /// <param name="code"></param>
        /// <returns>
        /// AccountId
        /// Email
        /// UserName
        /// Avatar
        /// Token
        /// TokenOld
        /// PublisherId
        /// Position
        /// </returns>
        public UserInfo LoginWithToken(string token,string ip, ref int? code)
        {
            try
            {
                Lib.Logs.SaveLog("LoginWithToken: " + token + ",IP " + ip);
                code = -1;
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Account_LoginWithToken";

                        cmd.Parameters.Add("@Token", SqlDbType.VarChar, 32);
                        cmd.Parameters["@Token"].Value = token;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Ip"].Value = ip;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;

                        DataTable dt = new DataTable();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        if (code == 1)
                        {
                            return new UserInfo()
                            {
                                AccountId = int.Parse(dt.Rows[0]["AccountId"].ToString()),
                                Avatar = dt.Rows[0]["Avatar"].ToString(),
                                Email = dt.Rows[0]["Email"].ToString(),
                                PublisherID = int.Parse(dt.Rows[0]["PublisherID"].ToString()),
                                Token = dt.Rows[0]["Token"].ToString(),
                                Code = dt.Rows[0]["Code"].ToString(),
                                UserName = dt.Rows[0]["UserName"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error LoginWithToken: " + token + ",Ip: " + ip 
                    + "\r\n" + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="reg"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable Register(RegisterInfo reg, ref int code) {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    code = -1;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Account_Register";

                        cmd.Parameters.Add("@LoginID", SqlDbType.VarChar, 50);
                        cmd.Parameters["@LoginID"].Value = reg.loginId;
                        cmd.Parameters.Add("@LoginType", SqlDbType.TinyInt);
                        cmd.Parameters["@LoginType"].Value = reg.loginType;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = reg.userName;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Email"].Value = reg.email;
                        cmd.Parameters.Add("@Picture", SqlDbType.VarChar, 500);
                        cmd.Parameters["@Picture"].Value = reg.picture;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Ip"].Value = reg.ip;
                        cmd.Parameters.Add("@DeviceId", SqlDbType.VarChar, 50);
                        cmd.Parameters["@DeviceId"].Value = reg.deviceId;
                        cmd.Parameters.Add("@DeviceName", SqlDbType.VarChar, 50);
                        cmd.Parameters["@DeviceName"].Value = reg.deviceName;
                        cmd.Parameters.Add("@PublisherId", SqlDbType.Int);
                        cmd.Parameters["@PublisherId"].Value = reg.publisherId;
                        cmd.Parameters.Add("@GroupId", SqlDbType.Int);
                        cmd.Parameters["@GroupId"].Value = reg.group;
                        cmd.Parameters.Add("@Position", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Position"].Value = reg.position != null ? reg.position : "";
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@AccountCode", SqlDbType.VarChar, 10);
                        cmd.Parameters["@AccountCode"].Value = reg.code;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;

                        DataTable dt = new DataTable();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error Register: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// LoginID by email , phone
        /// AccountId, Email, UserName, Avatar, Token, TokenOld , PublisherID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pass"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public UserInfo LoginID(LoginInfo login, ref int? code) {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    code = -1;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Account_LoginID";

                        cmd.Parameters.Add("@LoginID", SqlDbType.VarChar, 50);
                        cmd.Parameters["@LoginID"].Value = login.loginId;
                        cmd.Parameters.Add("@LoginType", SqlDbType.TinyInt);
                        cmd.Parameters["@LoginType"].Value = login.loginType;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Ip"].Value = login.ip;
                        cmd.Parameters.Add("@DeviceId", SqlDbType.VarChar, 50);
                        cmd.Parameters["@DeviceId"].Value = login.deviceId;
                        cmd.Parameters.Add("@DeviceName", SqlDbType.VarChar, 50);
                        cmd.Parameters["@DeviceName"].Value = login.deviceName;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Password"].Value = login.password;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        DataTable dt = new DataTable();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        if(code == 1)
                        {
                            return new UserInfo()
                            {
                                AccountId = int.Parse(dt.Rows[0]["AccountId"].ToString()),
                                Avatar = dt.Rows[0]["Avatar"].ToString(),
                                Email = dt.Rows[0]["Email"].ToString(),
                                PublisherID = int.Parse(dt.Rows[0]["PublisherID"].ToString()),
                                Token = dt.Rows[0]["Token"].ToString(),
                                Code = dt.Rows[0]["Code"].ToString(),
                                UserName = dt.Rows[0]["UserName"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                        //return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error LoginID: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        public int GetRuleByAccountId(int accountId, ref string menuId, ref string menu_rules, ref int groupID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    int code = -1;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetRuleByUser_v1";

                        cmd.Parameters.Add("@AccountId", SqlDbType.Int);
                        cmd.Parameters["@AccountId"].Value = accountId;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MenuId", SqlDbType.VarChar, -1);
                        cmd.Parameters["@MenuId"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MenuRule", SqlDbType.VarChar, -1);
                        cmd.Parameters["@MenuRule"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@GroupID", SqlDbType.Int);
                        cmd.Parameters["@GroupID"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        menuId = cmd.Parameters["@MenuId"].Value.ToString();
                        menu_rules = cmd.Parameters["@MenuRule"].Value.ToString();
                        groupID = int.Parse(cmd.Parameters["@GroupID"].Value.ToString());
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error GetRuleByAccountId: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }
    }

    public class RegisterInfo
    {
        public string loginId;
        public byte loginType;
        public string userName;
        public string email;
        public string ip;
        public string picture;
        public string deviceId;
        public string deviceName;
        public int publisherId;
        public string code;
        public int group;
        public string position;
    }

    public class LoginInfo
    {
        public LoginInfo() {
            password = "";
        }
        public string loginId;
        public byte loginType;
        public string ip;
        public string deviceId;
        public string deviceName;
        public string password;
    }
    //AccountId, Email, UserName, Avatar, Token, TokenOld , PublisherID

    public class UserInfo
    {
        public int AccountId;
        public string Email;
        public string UserName;
        public string Avatar;
        public string Token;
        public int PublisherID;
        public int GroupID;
        public string Code;
    }
}