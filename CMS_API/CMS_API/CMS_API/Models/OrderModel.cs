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
    public class OrderModel
    {
        private string connectString = "";//ConnectionDB.GetConnectionDB("Datphu_DB_ConnectString");
        private static OrderModel instance = null;
        private static readonly object padlock = new object();
        public static OrderModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new OrderModel();
                        }
                    }
                }
                return instance;
            }
        }

        public DataTable GetOrderPrintInfo(GetOrderPrintInfo p)
        {
            string log = "";
            try
            {
                log = "GetOrderPrintInfo: " + JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_API_GetOrderPrintInfo";
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@PagePrint", SqlDbType.VarChar, 100);
                        cmd.Parameters["@PagePrint"].Value = p.pagePrint;
                        cmd.Parameters.Add("@OrderID", SqlDbType.Int);
                        cmd.Parameters["@OrderID"].Value = p.orderID;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            log += "\r\nResult: " + JsonConvert.SerializeObject(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR GetOrderPrintInfo: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\n" + log + "\r\n**********");
            }
        }

        public DataTable GetOrderInfo(GetOrderInfo p)
        {
            string log = "";
            try
            {
                log = "GetOrderInfo: " + JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_API_GetOrderInfo";
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@OrderDetailID", SqlDbType.Int);
                        cmd.Parameters["@OrderDetailID"].Value = p.orderDetailID;
                        cmd.Parameters.Add("@OrderID", SqlDbType.Int);
                        cmd.Parameters["@OrderID"].Value = p.orderID;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            log += "\r\nResult: " + JsonConvert.SerializeObject(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR GetOrderInfo: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\n" + log + "\r\n**********");
            }
        }

        public DataTable GetOrdersDetailDraftsByUser(int userID)
        {
            string log = "";
            try
            {
                log = "GetOrdersDetailDraftsByUser: " + userID;
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_GetOrderDetailDraftsByUser";
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = userID;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            log += "\r\nResult: " + JsonConvert.SerializeObject(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR GetOrdersDetailDraftsByUser: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\n" + log + "\r\n**********");
            }
        }

        public DataTable GetOrderDetailByUser(int userID, int orderID)
        {
            string log = "";
            try
            {
                log = "GetOrderDetailByUser: " + userID;
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_GetOrderDetailByUser";
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = userID;
                        cmd.Parameters.Add("@OrderID", SqlDbType.Int);
                        cmd.Parameters["@OrderID"].Value = orderID;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            log += "\r\nResult: " + JsonConvert.SerializeObject(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR GetOrderDetailByUser: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\n" + log + "\r\n**********");
            }
        }

        public DataTable GetListOrderDetailByOrderCode(int userID, string orderCode)
        {
            string log = "";
            try
            {
                log = "GetListOrderDetailByOrderCode: userID = " + userID + ", orderCode = " + orderCode;
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_GetListOrderDetailByOrderCode";
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = userID;
                        cmd.Parameters.Add("@OrderCode", SqlDbType.VarChar, 30);
                        cmd.Parameters["@OrderCode"].Value = orderCode;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            log += "\r\nResult: " + JsonConvert.SerializeObject(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR GetListOrderDetailByOrderCode: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\n" + log + "\r\n**********");
            }
        }

        public DataTable GetOrdersByUser(int userID)
        {
            string log = "";
            try
            {
                log = "GetOrdersByUser: " + userID;
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_GetOrderByUser";
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = userID;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            log += "\r\nResult: " + JsonConvert.SerializeObject(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR GetOrdersByUser: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\n" + log + "\r\n**********");
            }
        }

        public DataTable TinhToankichThuotThung(RequestTinhToanKichThuocThung p)
        {
            string log = "";
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_TinhToanKichThuotThung";
                        cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
                        cmd.Parameters["@SoLuong"].Value = p.sl;
                        cmd.Parameters.Add("@LoaiThungID", SqlDbType.Int);
                        cmd.Parameters["@LoaiThungID"].Value = p.loaithungID;
                        cmd.Parameters.Add("@LoaiSongID", SqlDbType.Int);
                        cmd.Parameters["@LoaiSongID"].Value = p.loaisongID;
                        cmd.Parameters.Add("@Dai", SqlDbType.Int);
                        cmd.Parameters["@Dai"].Value = p.dai;
                        cmd.Parameters.Add("@Rong", SqlDbType.Int);
                        cmd.Parameters["@Rong"].Value = p.rong;
                        cmd.Parameters.Add("@Cao", SqlDbType.Int);
                        cmd.Parameters["@Cao"].Value = p.cao;
                        cmd.Parameters.Add("@LuoiGa", SqlDbType.Int);
                        cmd.Parameters["@LuoiGa"].Value = p.luoiga;
                        cmd.Parameters.Add("@NhaCungCap_ID", SqlDbType.Int);
                        cmd.Parameters["@NhaCungCap_ID"].Value = p.nhacungapID;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            log += "\r\nResult: " + JsonConvert.SerializeObject(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR TinhToankichThuotThung: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nTinhToankichThuotThung " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Khoi tao chi tiet don hang
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <param name="order"></param>
        /// <returns>
        /// </returns>
        public DataTable AddOrderDetail(OrderDetailEntity orderDetail, OrderEntity order, ref int code, ref string msg)
        {
            string log = "\r\n**********\r\n";
            try
            {
                log += "AddOrderDetail Info: " + JsonConvert.SerializeObject(orderDetail) + "\r\nOrderInfo: " + JsonConvert.SerializeObject(order);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_AddOrderDetail_v2";
                        cmd.Parameters.Add("@Order_ID", SqlDbType.Int);
                        cmd.Parameters["@Order_ID"].Value = order.Order_ID;
                        cmd.Parameters.Add("@Ma_KH", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Ma_KH"].Value = order.Ma_KH;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Address"].Value = orderDetail.Address;
                        cmd.Parameters.Add("@City", SqlDbType.SmallInt);
                        cmd.Parameters["@City"].Value = orderDetail.City;
                        cmd.Parameters.Add("@Country", SqlDbType.SmallInt);
                        cmd.Parameters["@Country"].Value = orderDetail.Country;
                        cmd.Parameters.Add("@KM", SqlDbType.SmallInt);
                        cmd.Parameters["@KM"].Value = orderDetail.KM;
                        cmd.Parameters.Add("@Ngay_Mo_Don", SqlDbType.DateTime);
                        cmd.Parameters["@Ngay_Mo_Don"].Value = Convert.ToDateTime(orderDetail.Ngay_Mo_Don);
                        cmd.Parameters.Add("@Ngay_Giao_Hang", SqlDbType.DateTime);
                        cmd.Parameters["@Ngay_Giao_Hang"].Value = Convert.ToDateTime(orderDetail.Ngay_Giao_Hang);
                        cmd.Parameters.Add("@Ky_Hieu_Don", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Ky_Hieu_Don"].Value = order.Ky_Hieu_Don != null ? UtilClass.RemoveSign4VietnameseString(order.Ky_Hieu_Don) : "";
                        cmd.Parameters.Add("@LoaiDon_ID", SqlDbType.TinyInt);
                        cmd.Parameters["@LoaiDon_ID"].Value = order.LoaiDon_ID;
                        cmd.Parameters.Add("@LoaiSong_ID", SqlDbType.Int);
                        cmd.Parameters["@LoaiSong_ID"].Value = orderDetail.LoaiSong_ID;
                        cmd.Parameters.Add("@LoaiHinhSX_ID", SqlDbType.Int);
                        cmd.Parameters["@LoaiHinhSX_ID"].Value = order.LoaiHinhSX_ID;
                        cmd.Parameters.Add("@LoaiThung_ID", SqlDbType.Int);
                        cmd.Parameters["@LoaiThung_ID"].Value = orderDetail.LoaiThung_ID;
                        cmd.Parameters.Add("@So_Don_KH", SqlDbType.VarChar, 20);
                        cmd.Parameters["@So_Don_KH"].Value = orderDetail.So_Don_KH != null ? orderDetail.So_Don_KH : "";
                        cmd.Parameters.Add("@So_PO", SqlDbType.VarChar, 20);
                        cmd.Parameters["@So_PO"].Value = orderDetail.So_PO != null ? orderDetail.So_PO : "";
                        cmd.Parameters.Add("@Ten_SP", SqlDbType.NVarChar, 100);
                        cmd.Parameters["@Ten_SP"].Value = orderDetail.Ten_SP != null ? orderDetail.Ten_SP : "";
                        cmd.Parameters.Add("@NhaCungCap_ID", SqlDbType.Int);
                        cmd.Parameters["@NhaCungCap_ID"].Value = orderDetail.NhaCungCap_ID;
                        cmd.Parameters.Add("@QuyCach_KH_D", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KH_D"].Value = orderDetail.QuyCach_KH_D;
                        cmd.Parameters.Add("@QuyCach_KH_R", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KH_R"].Value = orderDetail.QuyCach_KH_R;
                        cmd.Parameters.Add("@QuyCach_KH_C", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KH_C"].Value = orderDetail.QuyCach_KH_C;
                        cmd.Parameters.Add("@QuyCach_SX_D", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_SX_D"].Value = orderDetail.QuyCach_SX_D;
                        cmd.Parameters.Add("@QuyCach_SX_R", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_SX_R"].Value = orderDetail.QuyCach_SX_R;
                        cmd.Parameters.Add("@QuyCach_SX_C", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_SX_C"].Value = orderDetail.QuyCach_SX_C;
                        cmd.Parameters.Add("@QuyCach_SX_LuoiGa", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_SX_LuoiGa"].Value = orderDetail.QuyCach_SX_LuoiGa;
                        cmd.Parameters.Add("@SL", SqlDbType.Int);
                        cmd.Parameters["@SL"].Value = orderDetail.SL;
                        cmd.Parameters.Add("@SL_Tang", SqlDbType.Int);
                        cmd.Parameters["@SL_Tang"].Value = orderDetail.SL_Tang;
                        cmd.Parameters.Add("@Thung_Cat_D", SqlDbType.Int);
                        cmd.Parameters["@Thung_Cat_D"].Value = orderDetail.Thung_Cat_D;
                        cmd.Parameters.Add("@Thung_Cat_R", SqlDbType.Int);
                        cmd.Parameters["@Thung_Cat_R"].Value = orderDetail.Thung_Cat_R;
                        cmd.Parameters.Add("@QuyCach_KhoGiay_D", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KhoGiay_D"].Value = orderDetail.QuyCach_KhoGiay_D;
                        cmd.Parameters.Add("@QuyCach_KhoGiay_R", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KhoGiay_R"].Value = orderDetail.QuyCach_KhoGiay_R;
                        cmd.Parameters.Add("@SLSX", SqlDbType.Int);
                        cmd.Parameters["@SLSX"].Value = orderDetail.SLSX;
                        cmd.Parameters.Add("@SL_Bi_Lieu", SqlDbType.Int);
                        cmd.Parameters["@SL_Bi_Lieu"].Value = orderDetail.SL_Bi_Lieu;
                        cmd.Parameters.Add("@Cai", SqlDbType.Int);
                        cmd.Parameters["@Cai"].Value = orderDetail.Cai;
                        cmd.Parameters.Add("@ChatLieu_ID", SqlDbType.Int);
                        cmd.Parameters["@ChatLieu_ID"].Value = orderDetail.ChatLieu_ID;
                        cmd.Parameters.Add("@Dong_Dan_ID", SqlDbType.Int);
                        cmd.Parameters["@Dong_Dan_ID"].Value = orderDetail.Dong_Dan_ID;
                        cmd.Parameters.Add("@So_Mau_In", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@So_Mau_In"].Value = orderDetail.So_Mau_In;
                        cmd.Parameters.Add("@Mau_In", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Mau_In"].Value = orderDetail.Mau_In;
                        cmd.Parameters.Add("@In_An", SqlDbType.Bit);
                        cmd.Parameters["@In_An"].Value = orderDetail.In_An;
                        cmd.Parameters.Add("@Can_bien", SqlDbType.Bit);
                        cmd.Parameters["@Can_bien"].Value = orderDetail.Can_bien;
                        cmd.Parameters.Add("@May_In", SqlDbType.Bit);
                        cmd.Parameters["@May_In"].Value = orderDetail.May_In;
                        cmd.Parameters.Add("@Cat_Ranh", SqlDbType.Bit);
                        cmd.Parameters["@Cat_Ranh"].Value = orderDetail.Cat_Ranh;
                        cmd.Parameters.Add("@May_Be", SqlDbType.Bit);
                        cmd.Parameters["@May_Be"].Value = orderDetail.May_Be;
                        cmd.Parameters.Add("@Dong_Dinh", SqlDbType.Bit);
                        cmd.Parameters["@Dong_Dinh"].Value = orderDetail.Dong_Dinh;
                        cmd.Parameters.Add("@Dan_Keo", SqlDbType.Bit);
                        cmd.Parameters["@Dan_Keo"].Value = orderDetail.Dan_Keo;
                        cmd.Parameters.Add("@Dong_Goi", SqlDbType.Int);
                        cmd.Parameters["@Dong_Goi"].Value = orderDetail.Dong_Goi;
                        cmd.Parameters.Add("@Gia_Cong_DB", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Gia_Cong_DB"].Value = orderDetail.Gia_Cong_DB;
                        cmd.Parameters.Add("@Can_Nap", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Can_Nap"].Value = orderDetail.Can_Nap;
                        cmd.Parameters.Add("@Can_Lan", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Can_Lan"].Value = orderDetail.Can_Lan;
                        cmd.Parameters.Add("@Loai_Ban_In", SqlDbType.TinyInt);
                        cmd.Parameters["@Loai_Ban_In"].Value = orderDetail.Loai_Ban_In;
                        cmd.Parameters.Add("@Ma_So_Ban_In", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Ma_So_Ban_In"].Value = orderDetail.Ma_So_Ban_In;
                        cmd.Parameters.Add("@Ma_So_Khuon_Be", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Ma_So_Khuon_Be"].Value = orderDetail.Ma_So_Khuon_Be;
                        cmd.Parameters.Add("@Dinh_Kem", SqlDbType.Bit);
                        cmd.Parameters["@Dinh_Kem"].Value = orderDetail.Dinh_Kem;
                        cmd.Parameters.Add("@DT_Cai", SqlDbType.Float);
                        cmd.Parameters["@DT_Cai"].Value = orderDetail.DT_Cai;
                        cmd.Parameters.Add("@Tong_DT", SqlDbType.Float);
                        cmd.Parameters["@Tong_DT"].Value = orderDetail.Tong_DT;
                        cmd.Parameters.Add("@So_Met_Toi", SqlDbType.Int);
                        cmd.Parameters["@So_Met_Toi"].Value = orderDetail.So_Met_Toi;
                        cmd.Parameters.Add("@SL_Toi_Thieu", SqlDbType.Int);
                        cmd.Parameters["@SL_Toi_Thieu"].Value = orderDetail.SL_Toi_Thieu;
                        cmd.Parameters.Add("@Gia_Ban_Thung", SqlDbType.Int);
                        cmd.Parameters["@Gia_Ban_Thung"].Value = orderDetail.Gia_Ban_Thung;
                        cmd.Parameters.Add("@Hoa_Hong", SqlDbType.Int);
                        cmd.Parameters["@Hoa_Hong"].Value = orderDetail.Hoa_Hong;
                        cmd.Parameters.Add("@Hoa_Hong1", SqlDbType.Int);
                        cmd.Parameters["@Hoa_Hong1"].Value = orderDetail.Hoa_hong1;
                        cmd.Parameters.Add("@Ke_Gia", SqlDbType.Int);
                        cmd.Parameters["@Ke_Gia"].Value = orderDetail.Ke_Gia;
                        cmd.Parameters.Add("@Gia_Ban_Bo", SqlDbType.Int);
                        cmd.Parameters["@Gia_Ban_Bo"].Value = orderDetail.Gia_Ban_Bo;
                        cmd.Parameters.Add("@Doanh_Thu_Ban_Hang", SqlDbType.Int);
                        cmd.Parameters["@Doanh_Thu_Ban_Hang"].Value = orderDetail.Doanh_Thu_Ban_Hang;
                        cmd.Parameters.Add("@Gia_Mua", SqlDbType.Int);
                        cmd.Parameters["@Gia_Mua"].Value = orderDetail.Gia_Mua;
                        cmd.Parameters.Add("@Gia_Ban_Thuc_Te", SqlDbType.Int);
                        cmd.Parameters["@Gia_Ban_Thuc_Te"].Value = orderDetail.Gia_Ban_Thuc_Te;
                        cmd.Parameters.Add("@Phan_Tram_Loi_Nhuan_Ban_Giay", SqlDbType.Float);
                        cmd.Parameters["@Phan_Tram_Loi_Nhuan_Ban_Giay"].Value = (float)orderDetail.Phan_Tram_Loi_Nhuan_Ban_Giay;
                        cmd.Parameters.Add("@Gia_Von_Ban_Hang", SqlDbType.Int);
                        cmd.Parameters["@Gia_Von_Ban_Hang"].Value = orderDetail.Gia_Von_Ban_Hang;
                        cmd.Parameters.Add("@Loi_Nhuan_Ban_Giay", SqlDbType.BigInt);
                        cmd.Parameters["@Loi_Nhuan_Ban_Giay"].Value = orderDetail.Loi_Nhuan_Ban_Giay;
                        cmd.Parameters.Add("@Phi_Hao_Hut_Giay", SqlDbType.Int);
                        cmd.Parameters["@Phi_Hao_Hut_Giay"].Value = orderDetail.Phi_Hao_Hut_Giay;
                        cmd.Parameters.Add("@Phi_Van_Chuyen", SqlDbType.Int);
                        cmd.Parameters["@Phi_Van_Chuyen"].Value = orderDetail.Phi_Van_Chuyen;
                        cmd.Parameters.Add("@Phi_Ban_In", SqlDbType.Int);
                        cmd.Parameters["@Phi_Ban_In"].Value = orderDetail.Phi_Ban_In;
                        cmd.Parameters.Add("@Phi_Khuon_Be", SqlDbType.Int);
                        cmd.Parameters["@Phi_Khuon_Be"].Value = orderDetail.Phi_Khuon_Be;
                        cmd.Parameters.Add("@Phi_To_Khai", SqlDbType.Int);
                        cmd.Parameters["@Phi_To_Khai"].Value = orderDetail.Phi_To_Khai;
                        cmd.Parameters.Add("@Phi_Gia_Cong", SqlDbType.Int);
                        cmd.Parameters["@Phi_Gia_Cong"].Value = orderDetail.Phi_Gia_Cong;
                        cmd.Parameters.Add("@Chi_Phi_Khac", SqlDbType.Int);
                        cmd.Parameters["@Chi_Phi_Khac"].Value = orderDetail.Chi_Phi_Khac;
                        cmd.Parameters.Add("@Ghi_Chu_Don_Hang", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@Ghi_Chu_Don_Hang"].Value = orderDetail.Ghi_Chu_Don_Hang != null ? orderDetail.Ghi_Chu_Don_Hang : "";
                        cmd.Parameters.Add("@Ghi_Chu_SX", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@Ghi_Chu_SX"].Value = orderDetail.Ghi_Chu_SX != null ? orderDetail.Ghi_Chu_SX : "";
                        cmd.Parameters.Add("@Ghi_Chu_Giao_Hang", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@Ghi_Chu_Giao_Hang"].Value = orderDetail.Ghi_Chu_Giao_Hang != null ? orderDetail.Ghi_Chu_Giao_Hang : "";
                        cmd.Parameters.Add("@ClientIP", SqlDbType.VarChar, 40);
                        cmd.Parameters["@ClientIP"].Value = order.ClientIP;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = order.UserID;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = order.UserName;
                        cmd.Parameters.Add("@OwnerID", SqlDbType.Int);
                        cmd.Parameters["@OwnerID"].Value = orderDetail.OwnerID;
                        cmd.Parameters.Add("@OwnerName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@OwnerName"].Value = orderDetail.OwnerName;
                        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10);
                        cmd.Parameters["@UserCode"].Value = order.UserCode;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                            msg = cmd.Parameters["@Msg"].Value.ToString();
                            log += "\r\nResult: " + JsonConvert.SerializeObject(dt) + 
                                "\r\nCode: " + code + 
                                "\r\nMsg: " + msg;
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR AddOrderDetail: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("AddOrderDetail: " + log + "\r\n**********");
            }
        }

        public DataTable UpdateOrderDetail(OrderDetailEntity orderDetail, OrderEntity order, ref int code, ref string msg)
        {
            string log = "";
            try
            {
                log += "UpdateOrderDetail Info: " + JsonConvert.SerializeObject(orderDetail) + "\r\nOrderInfo: " + JsonConvert.SerializeObject(order);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_UpdateOrderDetail_v2";
                        cmd.Parameters.Add("@Order_ID", SqlDbType.Int);
                        cmd.Parameters["@Order_ID"].Value = order.Order_ID;
                        cmd.Parameters.Add("@OrderDetail_ID", SqlDbType.Int);
                        cmd.Parameters["@OrderDetail_ID"].Value = orderDetail.OrderDetail_ID;
                        cmd.Parameters.Add("@Ma_KH", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Ma_KH"].Value = order.Ma_KH;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Address"].Value = orderDetail.Address;
                        cmd.Parameters.Add("@City", SqlDbType.SmallInt);
                        cmd.Parameters["@City"].Value = orderDetail.City;
                        cmd.Parameters.Add("@Country", SqlDbType.SmallInt);
                        cmd.Parameters["@Country"].Value = orderDetail.Country;
                        cmd.Parameters.Add("@KM", SqlDbType.SmallInt);
                        cmd.Parameters["@KM"].Value = orderDetail.KM;
                        cmd.Parameters.Add("@Ngay_Mo_Don", SqlDbType.DateTime);
                        cmd.Parameters["@Ngay_Mo_Don"].Value = Convert.ToDateTime(orderDetail.Ngay_Mo_Don);
                        cmd.Parameters.Add("@Ngay_Giao_Hang", SqlDbType.DateTime);
                        cmd.Parameters["@Ngay_Giao_Hang"].Value = Convert.ToDateTime(orderDetail.Ngay_Giao_Hang);
                        cmd.Parameters.Add("@Ky_Hieu_Don", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Ky_Hieu_Don"].Value = order.Ky_Hieu_Don != null ? UtilClass.RemoveSign4VietnameseString(order.Ky_Hieu_Don) : "";
                        cmd.Parameters.Add("@LoaiDon_ID", SqlDbType.TinyInt);
                        cmd.Parameters["@LoaiDon_ID"].Value = order.LoaiDon_ID;
                        cmd.Parameters.Add("@LoaiSong_ID", SqlDbType.Int);
                        cmd.Parameters["@LoaiSong_ID"].Value = orderDetail.LoaiSong_ID;
                        cmd.Parameters.Add("@LoaiHinhSX_ID", SqlDbType.Int);
                        cmd.Parameters["@LoaiHinhSX_ID"].Value = order.LoaiHinhSX_ID;
                        cmd.Parameters.Add("@LoaiThung_ID", SqlDbType.Int);
                        cmd.Parameters["@LoaiThung_ID"].Value = orderDetail.LoaiThung_ID;
                        cmd.Parameters.Add("@So_Don_KH", SqlDbType.VarChar, 20);
                        cmd.Parameters["@So_Don_KH"].Value = orderDetail.So_Don_KH != null ? orderDetail.So_Don_KH : "";
                        cmd.Parameters.Add("@So_PO", SqlDbType.VarChar, 20);
                        cmd.Parameters["@So_PO"].Value = orderDetail.So_PO != null ? orderDetail.So_PO : "";
                        cmd.Parameters.Add("@Ten_SP", SqlDbType.NVarChar, 100);
                        cmd.Parameters["@Ten_SP"].Value = orderDetail.Ten_SP != null ? orderDetail.Ten_SP : "";
                        cmd.Parameters.Add("@NhaCungCap_ID", SqlDbType.Int);
                        cmd.Parameters["@NhaCungCap_ID"].Value = orderDetail.NhaCungCap_ID;
                        cmd.Parameters.Add("@QuyCach_KH_D", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KH_D"].Value = orderDetail.QuyCach_KH_D;
                        cmd.Parameters.Add("@QuyCach_KH_R", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KH_R"].Value = orderDetail.QuyCach_KH_R;
                        cmd.Parameters.Add("@QuyCach_KH_C", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KH_C"].Value = orderDetail.QuyCach_KH_C;
                        cmd.Parameters.Add("@QuyCach_SX_D", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_SX_D"].Value = orderDetail.QuyCach_SX_D;
                        cmd.Parameters.Add("@QuyCach_SX_R", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_SX_R"].Value = orderDetail.QuyCach_SX_R;
                        cmd.Parameters.Add("@QuyCach_SX_C", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_SX_C"].Value = orderDetail.QuyCach_SX_C;
                        cmd.Parameters.Add("@QuyCach_SX_LuoiGa", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_SX_LuoiGa"].Value = orderDetail.QuyCach_SX_LuoiGa;
                        cmd.Parameters.Add("@SL", SqlDbType.Int);
                        cmd.Parameters["@SL"].Value = orderDetail.SL;
                        cmd.Parameters.Add("@SL_Tang", SqlDbType.Int);
                        cmd.Parameters["@SL_Tang"].Value = orderDetail.SL_Tang;
                        cmd.Parameters.Add("@Thung_Cat_D", SqlDbType.Int);
                        cmd.Parameters["@Thung_Cat_D"].Value = orderDetail.Thung_Cat_D;
                        cmd.Parameters.Add("@Thung_Cat_R", SqlDbType.Int);
                        cmd.Parameters["@Thung_Cat_R"].Value = orderDetail.Thung_Cat_R;
                        cmd.Parameters.Add("@QuyCach_KhoGiay_D", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KhoGiay_D"].Value = orderDetail.QuyCach_KhoGiay_D;
                        cmd.Parameters.Add("@QuyCach_KhoGiay_R", SqlDbType.Int);
                        cmd.Parameters["@QuyCach_KhoGiay_R"].Value = orderDetail.QuyCach_KhoGiay_R;
                        cmd.Parameters.Add("@SLSX", SqlDbType.Int);
                        cmd.Parameters["@SLSX"].Value = orderDetail.SLSX;
                        cmd.Parameters.Add("@SL_Bi_Lieu", SqlDbType.Int);
                        cmd.Parameters["@SL_Bi_Lieu"].Value = orderDetail.SL_Bi_Lieu;
                        cmd.Parameters.Add("@Cai", SqlDbType.Int);
                        cmd.Parameters["@Cai"].Value = orderDetail.Cai;
                        cmd.Parameters.Add("@ChatLieu_ID", SqlDbType.Int);
                        cmd.Parameters["@ChatLieu_ID"].Value = orderDetail.ChatLieu_ID;
                        cmd.Parameters.Add("@Dong_Dan_ID", SqlDbType.Int);
                        cmd.Parameters["@Dong_Dan_ID"].Value = orderDetail.Dong_Dan_ID;
                        cmd.Parameters.Add("@So_Mau_In", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@So_Mau_In"].Value = orderDetail.So_Mau_In;
                        cmd.Parameters.Add("@Mau_In", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Mau_In"].Value = orderDetail.Mau_In;
                        cmd.Parameters.Add("@In_An", SqlDbType.Bit);
                        cmd.Parameters["@In_An"].Value = orderDetail.In_An;
                        cmd.Parameters.Add("@Can_bien", SqlDbType.Bit);
                        cmd.Parameters["@Can_bien"].Value = orderDetail.Can_bien;
                        cmd.Parameters.Add("@May_In", SqlDbType.Bit);
                        cmd.Parameters["@May_In"].Value = orderDetail.May_In;
                        cmd.Parameters.Add("@Cat_Ranh", SqlDbType.Bit);
                        cmd.Parameters["@Cat_Ranh"].Value = orderDetail.Cat_Ranh;
                        cmd.Parameters.Add("@May_Be", SqlDbType.Bit);
                        cmd.Parameters["@May_Be"].Value = orderDetail.May_Be;
                        cmd.Parameters.Add("@Dong_Dinh", SqlDbType.Bit);
                        cmd.Parameters["@Dong_Dinh"].Value = orderDetail.Dong_Dinh;
                        cmd.Parameters.Add("@Dan_Keo", SqlDbType.Bit);
                        cmd.Parameters["@Dan_Keo"].Value = orderDetail.Dan_Keo;
                        cmd.Parameters.Add("@Dong_Goi", SqlDbType.Int);
                        cmd.Parameters["@Dong_Goi"].Value = orderDetail.Dong_Goi;
                        cmd.Parameters.Add("@Gia_Cong_DB", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Gia_Cong_DB"].Value = orderDetail.Gia_Cong_DB;
                        cmd.Parameters.Add("@Can_Nap", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Can_Nap"].Value = orderDetail.Can_Nap;
                        cmd.Parameters.Add("@Can_Lan", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Can_Lan"].Value = orderDetail.Can_Lan;
                        cmd.Parameters.Add("@Loai_Ban_In", SqlDbType.TinyInt);
                        cmd.Parameters["@Loai_Ban_In"].Value = orderDetail.Loai_Ban_In;
                        cmd.Parameters.Add("@Ma_So_Ban_In", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Ma_So_Ban_In"].Value = orderDetail.Ma_So_Ban_In;
                        cmd.Parameters.Add("@Ma_So_Khuon_Be", SqlDbType.VarChar, 20);
                        cmd.Parameters["@Ma_So_Khuon_Be"].Value = orderDetail.Ma_So_Khuon_Be;
                        cmd.Parameters.Add("@Dinh_Kem", SqlDbType.Bit);
                        cmd.Parameters["@Dinh_Kem"].Value = orderDetail.Dinh_Kem;
                        cmd.Parameters.Add("@DT_Cai", SqlDbType.Float);
                        cmd.Parameters["@DT_Cai"].Value = (float)orderDetail.DT_Cai;
                        cmd.Parameters.Add("@Tong_DT", SqlDbType.Float);
                        cmd.Parameters["@Tong_DT"].Value = (float)orderDetail.Tong_DT;
                        cmd.Parameters.Add("@So_Met_Toi", SqlDbType.Int);
                        cmd.Parameters["@So_Met_Toi"].Value = orderDetail.So_Met_Toi;
                        cmd.Parameters.Add("@SL_Toi_Thieu", SqlDbType.Int);
                        cmd.Parameters["@SL_Toi_Thieu"].Value = orderDetail.SL_Toi_Thieu;
                        cmd.Parameters.Add("@Gia_Ban_Thung", SqlDbType.Int);
                        cmd.Parameters["@Gia_Ban_Thung"].Value = orderDetail.Gia_Ban_Thung;
                        cmd.Parameters.Add("@Hoa_Hong", SqlDbType.Int);
                        cmd.Parameters["@Hoa_Hong"].Value = orderDetail.Hoa_Hong;
                        cmd.Parameters.Add("@Hoa_Hong1", SqlDbType.Int);
                        cmd.Parameters["@Hoa_Hong1"].Value = orderDetail.Hoa_hong1;
                        cmd.Parameters.Add("@Ke_Gia", SqlDbType.Int);
                        cmd.Parameters["@Ke_Gia"].Value = orderDetail.Ke_Gia;
                        cmd.Parameters.Add("@Gia_Ban_Bo", SqlDbType.Int);
                        cmd.Parameters["@Gia_Ban_Bo"].Value = orderDetail.Gia_Ban_Bo;
                        cmd.Parameters.Add("@Doanh_Thu_Ban_Hang", SqlDbType.Int);
                        cmd.Parameters["@Doanh_Thu_Ban_Hang"].Value = orderDetail.Doanh_Thu_Ban_Hang;
                        cmd.Parameters.Add("@Gia_Mua", SqlDbType.Int);
                        cmd.Parameters["@Gia_Mua"].Value = orderDetail.Gia_Mua;
                        cmd.Parameters.Add("@Gia_Ban_Thuc_Te", SqlDbType.Int);
                        cmd.Parameters["@Gia_Ban_Thuc_Te"].Value = orderDetail.Gia_Ban_Thuc_Te;
                        cmd.Parameters.Add("@Phan_Tram_Loi_Nhuan_Ban_Giay", SqlDbType.Float);
                        cmd.Parameters["@Phan_Tram_Loi_Nhuan_Ban_Giay"].Value = (float)orderDetail.Phan_Tram_Loi_Nhuan_Ban_Giay;
                        cmd.Parameters.Add("@Gia_Von_Ban_Hang", SqlDbType.Int);
                        cmd.Parameters["@Gia_Von_Ban_Hang"].Value = orderDetail.Gia_Von_Ban_Hang;
                        cmd.Parameters.Add("@Loi_Nhuan_Ban_Giay", SqlDbType.BigInt);
                        cmd.Parameters["@Loi_Nhuan_Ban_Giay"].Value = orderDetail.Loi_Nhuan_Ban_Giay;
                        cmd.Parameters.Add("@Phi_Hao_Hut_Giay", SqlDbType.Int);
                        cmd.Parameters["@Phi_Hao_Hut_Giay"].Value = orderDetail.Phi_Hao_Hut_Giay;
                        cmd.Parameters.Add("@Phi_Van_Chuyen", SqlDbType.Int);
                        cmd.Parameters["@Phi_Van_Chuyen"].Value = orderDetail.Phi_Van_Chuyen;
                        cmd.Parameters.Add("@Phi_Ban_In", SqlDbType.Int);
                        cmd.Parameters["@Phi_Ban_In"].Value = orderDetail.Phi_Ban_In;
                        cmd.Parameters.Add("@Phi_Khuon_Be", SqlDbType.Int);
                        cmd.Parameters["@Phi_Khuon_Be"].Value = orderDetail.Phi_Khuon_Be;
                        cmd.Parameters.Add("@Phi_To_Khai", SqlDbType.Int);
                        cmd.Parameters["@Phi_To_Khai"].Value = orderDetail.Phi_To_Khai;
                        cmd.Parameters.Add("@Phi_Gia_Cong", SqlDbType.Int);
                        cmd.Parameters["@Phi_Gia_Cong"].Value = orderDetail.Phi_Gia_Cong;
                        cmd.Parameters.Add("@Chi_Phi_Khac", SqlDbType.Int);
                        cmd.Parameters["@Chi_Phi_Khac"].Value = orderDetail.Chi_Phi_Khac;
                        cmd.Parameters.Add("@Ghi_Chu_Don_Hang", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@Ghi_Chu_Don_Hang"].Value = orderDetail.Ghi_Chu_Don_Hang != null ? orderDetail.Ghi_Chu_Don_Hang : "";
                        cmd.Parameters.Add("@Ghi_Chu_SX", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@Ghi_Chu_SX"].Value = orderDetail.Ghi_Chu_SX != null ? orderDetail.Ghi_Chu_SX : "";
                        cmd.Parameters.Add("@Ghi_Chu_Giao_Hang", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@Ghi_Chu_Giao_Hang"].Value = orderDetail.Ghi_Chu_Giao_Hang != null ? orderDetail.Ghi_Chu_Giao_Hang : "";
                        cmd.Parameters.Add("@ClientIP", SqlDbType.VarChar, 40);
                        cmd.Parameters["@ClientIP"].Value = order.ClientIP;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = order.UserID;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = order.UserName;
                        cmd.Parameters.Add("@OwnerID", SqlDbType.Int);
                        cmd.Parameters["@OwnerID"].Value = orderDetail.OwnerID;
                        cmd.Parameters.Add("@OwnerName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@OwnerName"].Value = orderDetail.OwnerName;
                        cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10);
                        cmd.Parameters["@UserCode"].Value = order.UserCode;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                            msg = cmd.Parameters["@Msg"].Value.ToString();
                            log += "\r\nResult: " + JsonConvert.SerializeObject(dt) +
                                "\r\nCode: " + code +
                                "\r\nMsg: " + msg;
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR UpdateOrderDetail: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("UpdateOrderDetail: " + log);
            }
        }

        public int RemoveOrderDetail(RemoveOrderInfo p, ref string msg) {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_RemoveOrderDetail";
                        cmd.Parameters.Add("@OrderDetail_ID", SqlDbType.Int);
                        cmd.Parameters["@OrderDetail_ID"].Value = p.orderDetail_ID;
                        cmd.Parameters.Add("@Order_ID", SqlDbType.Int);
                        cmd.Parameters["@Order_ID"].Value = p.order_ID;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@ClientIP", SqlDbType.VarChar, 40);
                        cmd.Parameters["@ClientIP"].Value = p.clientIP;
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
                LogClass.SaveError("ERROR RemoveOrderDetail: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nRemoveOrderDetail " + log + "\r\n**********");
            }
        }

        public int RemoveOrder(RemoveOrderInfo p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_RemoveOrder";
                        cmd.Parameters.Add("@Order_ID", SqlDbType.Int);
                        cmd.Parameters["@Order_ID"].Value = p.order_ID;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@ClientIP", SqlDbType.VarChar, 40);
                        cmd.Parameters["@ClientIP"].Value = p.clientIP;
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
                LogClass.SaveError("ERROR RemoveOrder: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nRemoveOrder " + log + "\r\n**********");
            }
        }

        public int SaveOrderDetail(SaveOrderInfo p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_SaveOrderTemp";
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@ClientIP", SqlDbType.VarChar, 40);
                        cmd.Parameters["@ClientIP"].Value = p.clientIP;
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
                LogClass.SaveError("ERROR SaveOrderDetail: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nSaveOrderDetail " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Luu don hang mua giay tam
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int AddOrderDatGiayTam(AddOrderDatGiayTamInfo p, ref string msg, ref string madatgiay)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_API_DatGiayTam_v1";
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@Json", SqlDbType.VarChar, 2000);
                        cmd.Parameters["@Json"].Value = JsonConvert.SerializeObject(p.json);
                        cmd.Parameters.Add("@NgayDatGiay", SqlDbType.DateTime);
                        cmd.Parameters["@NgayDatGiay"].Value = p.ngaydatgiay;
                        cmd.Parameters.Add("@NgayYeuCauNhanGiay", SqlDbType.DateTime);
                        cmd.Parameters["@NgayYeuCauNhanGiay"].Value = p.ngayyeucaugiao;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 40);
                        cmd.Parameters["@Ip"].Value = p.ip;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MaDatGiay", SqlDbType.NVarChar, 20);
                        cmd.Parameters["@MaDatGiay"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        madatgiay = cmd.Parameters["@MaDatGiay"].Value.ToString();
                        log += "\r\nCode: " + code;
                        log += "\r\nMsg: " + msg;
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR AddOrderDatGiayTam: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nAddOrderDatGiayTam " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Cap nhat nhan giay
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UpdateOrderDatGiayTam(UpdateOrderDatGiayTamInfo p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_API_Update_DatGiayTam";
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = p.id;
                        cmd.Parameters.Add("@SL_Tang", SqlDbType.Int);
                        cmd.Parameters["@SL_Tang"].Value = p.sl_tang;
                        cmd.Parameters.Add("@SL_Nhan", SqlDbType.Int);
                        cmd.Parameters["@SL_Nhan"].Value = p.sl_nhan;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@GhiChu"].Value = p.ghichu;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 40);
                        cmd.Parameters["@Ip"].Value = p.ip;
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
                LogClass.SaveError("ERROR UpdateOrderDatGiayTam: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUpdateOrderDatGiayTam " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Cap nhat giay ton kho
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UpdateGiayTon(UpdateGiayTonInfo p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_API_Update_GiayTon";
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = p.id;
                        cmd.Parameters.Add("@SL_Tang", SqlDbType.Int);
                        cmd.Parameters["@SL_Tang"].Value = p.sl_tang;
                        cmd.Parameters.Add("@SL_Nhan", SqlDbType.Int);
                        cmd.Parameters["@SL_Nhan"].Value = p.sl_nhan;
                        cmd.Parameters.Add("@SL_HangHu", SqlDbType.Int);
                        cmd.Parameters["@SL_HangHu"].Value = p.sl_hanghu;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@GhiChu"].Value = p.ghichu;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 40);
                        cmd.Parameters["@Ip"].Value = p.ip;
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
                LogClass.SaveError("ERROR UpdateGiayTon: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUpdateGiayTon " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Xoa don dat giay tam
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int RemoveOrderDatGiayTam(RemoveOrderDatGiayTamInfo p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_API_Remove_DatGiayTam";
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = p.id;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 40);
                        cmd.Parameters["@Ip"].Value = p.ip;
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
                LogClass.SaveError("ERROR RemoveOrderDatGiayTam: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nRemoveOrderDatGiayTam " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Cap nhat tinh trang san xuat
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int UpdateDonHangSX(UpdateDonHangSanXuat p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_CapNhapSanXuat";
                        cmd.Parameters.Add("@UpdateName", SqlDbType.VarChar, 20);
                        cmd.Parameters["@UpdateName"].Value = p.updateName;
                        cmd.Parameters.Add("@Value", SqlDbType.Int);
                        cmd.Parameters["@Value"].Value = p.value;
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = p.id;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 40);
                        cmd.Parameters["@Ip"].Value = p.ip;
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
                LogClass.SaveError("ERROR UpdateDonHangSX: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nUpdateDonHangSX " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Nhập sl kho sx
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int NhapKhoSX(NhapKhoSanXuat p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_NhapKhoSX";
                        cmd.Parameters.Add("@SL", SqlDbType.Int);
                        cmd.Parameters["@SL"].Value = p.qty;
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = p.id;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 40);
                        cmd.Parameters["@Ip"].Value = p.ip;
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
                LogClass.SaveError("ERROR NhapKhoSX: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nNhapKhoSX " + log + "\r\n**********");
            }
        }

        /// <summary>
        /// Phan hồi sản xuất
        /// </summary>
        /// <param name="p"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int PhanHoiSX(PhanHoiSanXuat p, ref string msg)
        {
            string log = "";
            int code = 0;
            try
            {
                log = JsonConvert.SerializeObject(p);
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Api_PhanHoiSX";
                        cmd.Parameters.Add("@PhanHoi", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@PhanHoi"].Value = p.phanhoi;
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = p.id;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@UserName"].Value = p.userName;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        cmd.Parameters["@UserID"].Value = p.userID;
                        cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 40);
                        cmd.Parameters["@Ip"].Value = p.ip;
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
                LogClass.SaveError("ERROR PhanHoiSX: " + ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                LogClass.SaveDBLog("\r\n**********\r\nPhanHoiSX " + log + "\r\n**********");
            }
        }
    }
}