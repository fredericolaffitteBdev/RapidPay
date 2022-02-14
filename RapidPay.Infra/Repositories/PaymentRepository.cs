using RapidPay.Domain.Payment;

namespace RapidPay.Infra.Repositories
{
    public class PaymentRepository : BaseRepository<PaymentData>, IPaymentRepository
    {
        public PaymentRepository(Context context) : base(context) { }
    }
}
