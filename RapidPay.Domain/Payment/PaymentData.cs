using System;

namespace RapidPay.Domain.Payment
{
    public class PaymentData : BaseEntity
    {
        public Int64 CardNumberPayment { get; set; }
        public decimal PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentDescription { get; set; }
        public string PaymentResult { get; set; }
        public string Receiver { get; set; }
        public decimal FeeTransaction { get; set; }
    }
}