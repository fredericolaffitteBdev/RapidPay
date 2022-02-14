using RapidPay.Domain.User;

namespace RapidPay.Infra.Repositories
{
    public class UserRepository : BaseRepository<UserData>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }
    }
}
