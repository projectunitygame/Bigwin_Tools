using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_cms.Entity
{
    public struct CustomerEntity
    {
        public int CustomertID;
        public string CustomerCode;
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
        public string CreateDate;
        public byte Status;
        public int UserID;
        public string UserName;
        public short KM;
        public short KM1;
        public short KM2;
        public byte Loaidon_ID;
        public int LoaiHinhSX_ID;
        public string ClientIP;
    }

    public class FindCustomerInfo: BaseApiInfo
    {
        public string param;
    }

    public class RequestInfo:BaseApiInfo
    {
    }

    public class GetChatLieuInfo: BaseApiInfo
    {
        public int nhacungcap_ID;
    }

    public class GetCustomerInfo: BaseApiInfo
    {
        public string customerCode;
    }

    public class CreateCustomerInfo: BaseApiInfo
    {
        public int customerID;
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
    }

    public abstract class BaseApiInfo {
        public string publickey;
        public short serviceID;
    }
}