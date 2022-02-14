namespace RapidPay.Application.Services.Fee
{
    public interface IFeeService
    {
        public decimal GetLastFeeAmount();
        public decimal GetFee();

    }
}
