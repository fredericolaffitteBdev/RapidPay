namespace RapidPay.Domain.BankAccount
{
    public class BankData : BaseEntity
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int BankAccountNumber { get; set; }
        public int BankAgencyNumber { get; set; }
        public decimal BankAmount { get; set; }


    }
}
