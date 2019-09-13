using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_cms.Entity
{
    public class AgencyInfoEntity
    {
        public int agencyID;
        public string agencyCode;
        public string email;
        public string phone;
        public string displayName;
        public decimal balance;
        public decimal balance_bonus;
        public decimal balance_lock;
        public decimal limitTransaction;
        public decimal limitTransactionDaily;
        public bool isOTP;
        public bool emailActive;
        public bool phoneActive;
        public string dateCreated;
        public string masterID;
        public string fb;
        public bool display;
        public string information;
    }

    public class AgencyEntity
    {
        public string agencyCode;
        public string password;
        public string email;
        public string phone;
        public string displayName;
        public string ownerID;
        public string IP;
        public decimal limitTransaction;
        public decimal limitTransactionDaily;
        public int creatorID;
        public string creatorName;
        public string infomation;
        public bool display;
        public string FB;
    }

    public class AddMoneyAgencyEntity
    {
        public string agencyID;
        public string IP;
        public decimal amount;
        public decimal bonus;
        public int creatorID;
        public string creatorName;
        public string reason;
    }

    public class ChangeLimitTransactionAgency
    {
        public string uwinID;
        public decimal limitTransaction;
        public decimal limitTransactionDaily;
        public bool isOTP;
    }

    public class ChangePasswordAgency
    {
        public string uwinID;
        public string passwordOld;
        public string passwordNew;
    }

    public class LockAgencyEntity
    {
        public string agencyID;
        public string note;
        public int creatorID;
        public string creatorName;
    }

    public class UpdateFBAgencyEntity
    {
        public string agencyID;
        public string fb;
        public int creatorID;
        public string creatorName;
    }

    public class UpdateDisplayAgencyEntity
    {
        public string agencyID;
        public bool display;
        public int creatorID;
        public string creatorName;
    }

    public class UpdateInformationAgencyEntity
    {
        public string agencyID;
        public string information;
        public int creatorID;
        public string creatorName;
    }

    public class LoginAgencyEntity
    {
        public string loginID;
        public string password;
        public string ip;
    }

    public class FindAgencyEntity
    {
        public string param;
        public int topN;
        public string uwinID;
    }

    public class getAgencyInfoEntity
    {
        public string uwinID;
    }

    public class FotgetPasswordAgencyEntity
    {
        public string phone;
    }

    public class ResetPasswordAgencyEntity
    {
        public string phone;
        public string otp;
    }

    public class TransferMoneyToUser
    {
        public string senderID;
        public long recipientID;
        public decimal amount;
        public string ip;
        public string reason;
        public string OTP;
    }

    public class TransferMoneyToAgency
    {
        public string senderID;
        public string recipientID;
        public decimal amount;
        public string ip;
        public string reason;
        public string OTP;
    }

    public class ActivePhoneAgency
    {
        public string uwinID;
        public string phone;
        public string OTP;
        public string ip;
    }

    public class ChangePhoneAgency
    {
        public string uwinID;
        public string phoneOld;
        public string phoneNew;
        public string OTP;
        public string ip;
    }
}