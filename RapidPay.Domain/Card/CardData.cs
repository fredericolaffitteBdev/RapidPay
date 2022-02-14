using System;

namespace RapidPay.Domain.Card
{
    public class CardData : BaseEntity
    {
        public bool IsCredit { get; set; }
        public Int64 CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVV { get; set; }
        public decimal Balance { get; set; }
        public decimal BalanceUsed { get; set; }
    }
}
