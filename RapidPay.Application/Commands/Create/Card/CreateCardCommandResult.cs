using System;

namespace RapidPay.Application.Commands.Create.Card
{
    public class CreateCardCommandResult
    {
        public Int64 CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVV { get; set; }
        public decimal Balance { get; set; }
    }
}
