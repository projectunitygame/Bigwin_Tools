using api_cms.common;
using api_cms.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api_cms.Models
{
    public class CustomerModel
    {
        private string connectString = "";//ConnectionDB.GetConnectionDB("Datphu_DB_ConnectString");
        private string connectString2 = ConnectionDB.GetConnectionDB("ConnectString_ManamentCMSTools_DB");
        private static CustomerModel instance = null;
        private static readonly object padlock = new object();
        public static CustomerModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new CustomerModel();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Lay thong tin khach hang
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public DataTable GetCustomerDetail(string customerID)
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
                        cmd.CommandText = "sp_Api_GetCustomerDetail";
                        cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                        cmd.Parameters["@CustomerID"].Value = int.Parse(customerID);
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
                LogClass.SaveError("ERROR GetCustomerDetail: " + ex);
                return null;
            }
        }

        public DataTable GetCustomerDetailByCode(string customerCode)
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
                        cmd.CommandText = "sp_Api_GetCustomerDetailByCode";
                        cmd.Parameters.Add("@CustomerCode", SqlDbType.VarChar, 20);
                        cmd.Parameters["@CustomerCode"].Value = customerCode;
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
                LogClass.SaveError("ERROR GetCustomerDetailByCode: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Tao khach hang moi
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CreateCustomer(CustomerEntity p)
        {
            try
            {
                LogClass.SaveDBLog("CreateCustomer: " + JsonConvert.SerializeObject(p));
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_CreateCustomer";
                        cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@CompanyName"].Value = p.CompanyName;
                        cmd.Parameters.Add("@TaxCode", SqlDbType.VarChar, 15);
                        cmd.Parameters["@TaxCode"].Value = p.TaxCode;

                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Address"].Value = p.Address;
                        cmd.Parameters.Add("@City", SqlDbType.SmallInt);
                        cmd.Parameters["@City"].Value = p.City;
                        cmd.Parameters.Add("@Country", SqlDbType.SmallInt);
                        cmd.Parameters["@Country"].Value = p.Country;
                        cmd.Parameters.Add("@Address1", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Address1"].Value = p.Address1;
                        cmd.Parameters.Add("@City1", SqlDbType.SmallInt);
                        cmd.Parameters["@City1"].Value = p.City1;
                        cmd.Parameters.Add("@Country1", SqlDbType.SmallInt);
                        cmd.Parameters["@Country1"].Value = p.Country1;
                        cmd.Parameters.Add("@Address2", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Address2"].Value = p.Address2;
                        cmd.Parameters.Add("@City2", SqlDbType.SmallInt);
                        cmd.Parameters["@City2"].Value = p.City2;
                        cmd.Parameters.Add("@Country2", SqlDbType.SmallInt);
                        cmd.Parameters["@Country2"].Value = p.Country2;

                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 80);
                        cmd.Parameters["@Email"].Value = p.Email;
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Phone"].Value = p.Phone;
                        cmd.Parameters.Add("@Contact", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@Contact"].Value = p.Contact;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = p.Status;
                        cmd.Parameters.Add("@UserEdit", SqlDbType.Int);
                        cmd.Parameters["@UserEdit"].Value = p.UserID;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.UserName;
                        cmd.Parameters.Add("@KM", SqlDbType.SmallInt);
                        cmd.Parameters["@KM"].Value = p.KM;
                        cmd.Parameters.Add("@KM1", SqlDbType.SmallInt);
                        cmd.Parameters["@KM1"].Value = p.KM1;
                        cmd.Parameters.Add("@KM2", SqlDbType.SmallInt);
                        cmd.Parameters["@KM2"].Value = p.KM2;
                        cmd.Parameters.Add("@LoaiDon_ID", SqlDbType.TinyInt);
                        cmd.Parameters["@LoaiDon_ID"].Value = p.Loaidon_ID;
                        cmd.Parameters.Add("@LoaiHinhSX_ID", SqlDbType.Int);
                        cmd.Parameters["@LoaiHinhSX_ID"].Value = p.LoaiHinhSX_ID;
                        cmd.Parameters.Add("@ClientIP", SqlDbType.VarChar, 40);
                        cmd.Parameters["@ClientIP"].Value = p.ClientIP != null ? p.ClientIP : "";
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        LogClass.SaveDBLog("Result CreateCustomer: " + code);
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                LogClass.SaveError("Error CreateCustomer: " + ex.Message, ex, true);
                return (int)ERROR_CODDE.ERROR_EX;
            }
        }

        /// <summary>
        /// Cap nhat thong tin khach hang
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int UpdateCustomer(CustomerEntity p)
        {
            try
            {
                LogClass.SaveDBLog("UpdateCustomer: " + JsonConvert.SerializeObject(p));
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_UpdateCustomer";
                        cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                        cmd.Parameters["@CustomerID"].Value = p.CustomertID;
                        cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@CompanyName"].Value = p.CompanyName;
                        cmd.Parameters.Add("@TaxCode", SqlDbType.VarChar, 15);
                        cmd.Parameters["@TaxCode"].Value = p.TaxCode;

                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Address"].Value = p.Address;
                        cmd.Parameters.Add("@City", SqlDbType.SmallInt);
                        cmd.Parameters["@City"].Value = p.City;
                        cmd.Parameters.Add("@Country", SqlDbType.SmallInt);
                        cmd.Parameters["@Country"].Value = p.Country;
                        cmd.Parameters.Add("@Address1", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Address1"].Value = p.Address1;
                        cmd.Parameters.Add("@City1", SqlDbType.SmallInt);
                        cmd.Parameters["@City1"].Value = p.City1;
                        cmd.Parameters.Add("@Country1", SqlDbType.SmallInt);
                        cmd.Parameters["@Country1"].Value = p.Country1;
                        cmd.Parameters.Add("@Address2", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Address2"].Value = p.Address2;
                        cmd.Parameters.Add("@City2", SqlDbType.SmallInt);
                        cmd.Parameters["@City2"].Value = p.City2;
                        cmd.Parameters.Add("@Country2", SqlDbType.SmallInt);
                        cmd.Parameters["@Country2"].Value = p.Country2;

                        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 80);
                        cmd.Parameters["@Email"].Value = p.Email;
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Phone"].Value = p.Phone;
                        cmd.Parameters.Add("@Contact", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@Contact"].Value = p.Contact;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = p.Status;
                        cmd.Parameters.Add("@UserEdit", SqlDbType.Int);
                        cmd.Parameters["@UserEdit"].Value = p.UserID;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.UserName;
                        cmd.Parameters.Add("@KM", SqlDbType.SmallInt);
                        cmd.Parameters["@KM"].Value = p.KM;
                        cmd.Parameters.Add("@KM1", SqlDbType.SmallInt);
                        cmd.Parameters["@KM1"].Value = p.KM1;
                        cmd.Parameters.Add("@KM2", SqlDbType.SmallInt);
                        cmd.Parameters["@KM2"].Value = p.KM2;
                        cmd.Parameters.Add("@LoaiDon_ID", SqlDbType.TinyInt);
                        cmd.Parameters["@LoaiDon_ID"].Value = p.Loaidon_ID;
                        cmd.Parameters.Add("@LoaiHinhSX_ID", SqlDbType.Int);
                        cmd.Parameters["@LoaiHinhSX_ID"].Value = p.LoaiHinhSX_ID;
                        cmd.Parameters.Add("@ClientIP", SqlDbType.VarChar, 40);
                        cmd.Parameters["@ClientIP"].Value = p.ClientIP != null ? p.ClientIP : "";
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        LogClass.SaveDBLog("Result UpdateCustomer: " + code);
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                LogClass.SaveError("Error UpdateCustomer: " + ex.Message, ex, true);
                return (int)ERROR_CODDE.ERROR_EX;
            }
        }

        /// <summary>
        /// Lấy danh sách quốc gia active
        /// </summary>
        /// <returns></returns>
        public DataTable GetCountry()
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
                        cmd.CommandText = "sp_Api_GetCountry";
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
                LogClass.SaveError("ERROR GetCountry: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách tỉnh thành active
        /// </summary>
        /// <returns></returns>
        public DataTable GetProvince()
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
                        cmd.CommandText = "sp_Api_GetProvince";
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
                LogClass.SaveError("ERROR GetProvince: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Lay thong tin publisher secretkey
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="serviceID"></param>
        /// <param name="serverIP"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetPublisherKey(string publickey, short serviceID, string serverIP, ref int code)
        {
            try
            {
                LogClass.SaveLog("GetPublisherKey: " + publickey + "," + serverIP);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString2))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetPublisherKey";
                        cmd.Parameters.Add("@PublicKey", SqlDbType.VarChar, 32);
                        cmd.Parameters["@PublicKey"].Value = publickey;
                        cmd.Parameters.Add("@ServiceID", SqlDbType.SmallInt);
                        cmd.Parameters["@ServiceID"].Value = serviceID;
                        cmd.Parameters.Add("@ServerIP", SqlDbType.VarChar, 200);
                        cmd.Parameters["@ServerIP"].Value = serverIP;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR GetPublisherKey: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Lay danh sach nha cung cap
        /// </summary>
        /// <returns></returns>
        public DataTable GetNhaCungCap()
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
                        cmd.CommandText = "sp_Api_GetNhaCungCap";
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
                LogClass.SaveError("ERROR GetNhaCungCap: " + ex);
                return null;
            }
        }

        /// <summary>
        /// lay danh sach chat lieu theo nhà cung cấp
        /// </summary>
        /// <param name="nhacungcap_id"></param>
        /// <returns></returns>
        public DataTable GetChatLieu(int nhacungcap_id)
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
                        cmd.CommandText = "sp_Api_GetChatLieu";
                        cmd.Parameters.Add("@NhaCungCap_ID", SqlDbType.Int);
                        cmd.Parameters["@NhaCungCap_ID"].Value = nhacungcap_id;
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
                LogClass.SaveError("ERROR GetChatLieu: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Lay danh sách loai đơn hàng
        /// </summary>
        /// <param name="nhacungcap_id"></param>
        /// <returns></returns>
        public DataTable GetLoaiDonHang()
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
                        cmd.CommandText = "sp_Api_GetLoaiDon";
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
                LogClass.SaveError("ERROR GetLoaiDonHang: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Lay danh sach gia cong dong dan
        /// </summary>
        /// <returns></returns>
        public DataTable GetGiaCongDongDan()
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
                        cmd.CommandText = "sp_Api_GetGiaCongDongDan";
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
                LogClass.SaveError("ERROR GetGiaCongDongDan: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Lay danh dach loai hinh sx
        /// </summary>
        /// <returns></returns>
        public DataTable GetLoaiHinhSX()
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
                        cmd.CommandText = "sp_Api_GetLoaiHinhSX";
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
                LogClass.SaveError("ERROR GetLoaiHinhSX: " + ex);
                return null;
            }
        }

        /// <summary>
        /// lay danh sach kieu thung
        /// </summary>
        /// <returns></returns>
        public DataTable GetLoaiThung()
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
                        cmd.CommandText = "sp_Api_GetLoaiThung";
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
                LogClass.SaveError("ERROR GetLoaiThung: " + ex);
                return null;
            }
        }
        
        /// <summary>
        /// lay danh sach loai song 
        /// </summary>
        /// <returns></returns>
        public DataTable GetLoaiSong()
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
                        cmd.CommandText = "sp_Api_GetLoaiSong";
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
                LogClass.SaveError("ERROR GetLoaiSong: " + ex);
                return null;
            }
        }
        /// <summary>
        /// Tim kiem khach hang
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable FindCustomers(string param)
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
                        cmd.CommandText = "sp_Api_FindCustomers";
                        cmd.Parameters.Add("@Input", SqlDbType.NVarChar, 200);
                        cmd.Parameters["@Input"].Value = param;
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
                LogClass.SaveError("ERROR FindCustomers: " + ex);
                return null;
            }
        }

        public DataTable FindCustomersByOrder(int userID)
        {
            DataTable dt = new DataTable();
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
                        cmd.CommandText = "sp_Api_FindCustomerByOrder";
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = userID;
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
                LogClass.SaveError("ERROR FindCustomersByOrder: " + ex);
                return dt;
            }
        }
    }
}