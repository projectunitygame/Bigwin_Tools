using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_cms.Entity
{
    public class GetListOrderInfo
    {
        public int orderID;
        public int userID;
    }

    public class GetOrderPrintInfo
    {
        public string pagePrint;
        public int orderID;
        public int userID;
    }

    public class GetOrderInfo
    {
        public int orderDetailID;
        public int orderID;
        public int userID;
    }

    public class GetListOrderDetail
    {
        public string orderCode;
        public int userID;
    }

    public class RemoveOrderInfo
    {
        public int orderDetail_ID;
        public int order_ID;
        public string userName;
        public int userID;
        public string clientIP;
    }

    public class SaveOrderInfo
    {
        public string userName;
        public int userID;
        public string clientIP;
    }
    public class AddOrderInfo
    {
        public OrderDetailEntity orderDetail { get; set; }
        public OrderEntity order { get; set; }
        public string sign { get; set; }
        public string sign_server { get { return common.Encryptor.GetMd5Hash(JsonConvert.SerializeObject(orderDetail) + common.Constants.KEY_SERVER + JsonConvert.SerializeObject(order)); } }
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

    public class RequestTinhToanKichThuocThung: BaseApiInfo
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
}