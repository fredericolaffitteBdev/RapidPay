using MediatR;

namespace RapidPay.Application.Services.Payment
{
    public class PayServiceInput : IRequest<string>
    {
        public long CardNumberPayment { get; set; }
        public decimal PaymentValue { get; set; }
        public string PaymentDescription { get; set; }
        public string Receiver { get; set; }
        public int CVV { get; set; }
    }
}
