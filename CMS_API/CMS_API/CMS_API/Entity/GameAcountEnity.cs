using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_cms.Entity
{
    public class GameAcountEnity
    {

    }
    public class LockAccountGameEnity
    {
        public long AccountID;
        public string Reason;
        public int Author;
    }

    public class UnlockAccountGameEnity
    {
        public long AccountID;
        public string Reason;
        public int Author;
    }

    public class LockChatAccountGameEnity
    {
        public long AccountID;
        public string Reason;
        public int Author;
    }

    public class UnlockChatAccountGameEnity
    {
        public long AccountID;
        public string Reason;
        public int Author;
    }

    public class CreateSchemeNotificationGameEnity
    {
        public string Title;
        public string Message;
        public string Platform;
        public DateTime DateSend;
        public string Loop;
        public string Status;
    }

    public class UpdateSchemeNotificationGameEnity
    {
        public int Id;
        public string Title;
        public string Message;
        public string Platform;
        public DateTime DateSend;
        public string Loop;
        public string Status;
    }

    public class DeleteSchemeNotificationGameEnity
    {
        public int Id;
    }

    public class CreateEventGiftCode
    {
        public string Name;
        public int Created;
        public long Price;
        public int Type;
        public int AgencyId;
        public int Qty;
        public string Prefix;
        public DateTime Expired;
    }
    public class DeleteEventGiftCode
    {
        public string ID;
    }

    public class UpdateEventGiftCode
    {
        public int ID;
        public DateTime Expired;
    }

    public class ExceptFundGame
    {
        public int GameID;
        public int RoomID;
        public long Value;
        public string AccountName;
    }

    //public class CardConfig
    //{
    //    public int ID { get; set; }
    //    public int Type { get; set; }
    //    public int Prize { get; set; }
    //    public bool Enable { get; set; }
    //    public int Promotion { get; set; }
    //    public int CashoutRate { get; set; }
    //    public bool EnableCashout { get; set; }
    //    public int TopupRate { get; set; }
    //    public int PromotionCashout { get; set; }
    //    private string _PayOrderConfig;
    //    public string PayOrderConfig
    //    {
    //        get
    //        {
    //            return _PayOrderConfig;
    //        }
    //        set
    //        {
    //            _PayOrderConfig = value;
    //            if (!string.IsNullOrEmpty(_PayOrderConfig))
    //            {
    //                var spl = _PayOrderConfig.Split('|');
    //                int pay1 = 0;
    //                int pay2 = 0;
    //                int pay3 = 0;
    //                int pay4 = 0;
    //                int pay5 = 0;
    //                int pay6 = 0;
    //                int pay7 = 0;
    //                int pay8 = 0;
    //                int.TryParse(spl[0], out pay1);
    //                if (spl.Length > 1)
    //                    int.TryParse(spl[1], out pay2);
    //                if (spl.Length > 2)
    //                    int.TryParse(spl[2], out pay3);
    //                if (spl.Length > 3)
    //                    int.TryParse(spl[3], out pay4);
    //                if (spl.Length > 4)
    //                    int.TryParse(spl[4], out pay5);
    //                if (spl.Length > 5)
    //                    int.TryParse(spl[5], out pay6);
    //                if (spl.Length > 6)
    //                    int.TryParse(spl[6], out pay7);
    //                if (spl.Length > 7)
    //                    int.TryParse(spl[7], out pay8);
    //                if (Pay1 == 0)
    //                    Pay1 = pay1;
    //                if (Pay2 == 0)
    //                    Pay2 = pay2;
    //                if (Pay3 == 0)
    //                    Pay3 = pay3;
    //                if (Pay4 == 0)
    //                    Pay4 = pay4;
    //                if (Pay5 == 0)
    //                    Pay5 = pay5;
    //                if (Pay6 == 0)
    //                    Pay6 = pay6;
    //                if (Pay7 == 0)
    //                    Pay7 = pay7;
    //                if (Pay8 == 0)
    //                    Pay8 = pay8;
    //            }
    //        }
    //    }
    //    public int Pay1 { get; set; }
    //    public int Pay2 { get; set; }
    //    public int Pay3 { get; set; }
    //    public int Pay4 { get; set; }
    //    public int Pay5 { get; set; }
    //    public int Pay6 { get; set; }
    //    public int Pay7 { get; set; }
    //    public int Pay8 { get; set; }
    //}

    public class AcceptCard
    {
        public long CardID;
        public string AcceptorID;
        public string AcceptorName;
    }
    public class DeleteCashOutCard
    {
        public long CardID;
    }
    public class DeleteFailTransactionCard
    {
        public long ID;
    }
    public class ConfigCard
    {
        public string ID;
        public bool Enable;
        public int Promotion;
        public int CashoutRate;
        public bool EnableCashout;
        public int TopupRate;
        public int PromotionCashout;
        public string PayOrderConfig;
    }

    public class SetJackpotPrize
    {
        public int GameId;
        public int RoomId;
        public string AccountName;
        public long AccountID;
        public string CreatorId;
    }
    public class UpdateBotConfigLuckDice
    {
        public int MinBot;
        public int MaxBot;
        public int NumRichBot;
        public int NumNormalBot;
        public int NumPoorBot;
        public int VipChangeRate;
        public int NorChangeRate;
        public int PoorChangeRate;
        public int MinTimeChange;
        public int MaxTimeChange;
    }
    public class UpdateBetValueLuckDice
    {
        public int BetValue;
        public int Vip;
        public int Quantity;
        public int NumNormalBot;
        public int NumPoorBot;
        public int VipChangeRate;
        public int NorChangeRate;
        public int PoorChangeRate;
        public int MinTimeChange;
        public int MaxTimeChange;
    }
    public class CardObject
    {
        public string CardCode;
        public string CardSerial;
        public long Amount;
        public string Experied;
        public int CardType;
        public string TelCode;
        public string TradeMark;
        public DateTime BuyTime;
        public string TransactionCode;
        public string ResultCode;
        public bool Status;
    }
    public class CardObject_Muathe24h
    {
        public string ProviderCode { get; set; }
        public string Serial { get; set; }
        public string PinCode { get; set; }
        public int Amount { get; set; }
    }
    public class InputCard
    {
        public int CardType;
        public int Amount;
        public int Qty;
    }
    public class AddMoneyUser
    {
        public long UserID;
        public string Reason;
        public int Amount;
        public string SenderID;
    }

    public class DeductGoldUser
    {
        public int ID;
        public long AccountId;
        public long Amount;
        public string Description;
        public string UserName;
        public int UserID;
        //public string Balance;
    }
    public class DeductGoldAgency
    {
        public long AccountId;
        public long ServiceId;
        public long Amount;
        public string Description;
        public int Type;
        public long ReferId;
    }
}