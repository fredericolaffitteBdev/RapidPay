using RapidPay.Domain.BankAccount;

namespace RapidPay.Infra.Repositories
{
    public class BankRepository : BaseRepository<BankData>, IBankRepository
    {
        public BankRepository(Context context) : base(context) { }
    }
}
