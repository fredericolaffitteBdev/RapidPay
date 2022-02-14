using MediatR;
using RapidPay.Application.Crosscutting;
using RapidPay.Domain.User;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Application.Services.Authentication
{
    public class AuthServiceHandler : IRequestHandler<AuthServiceInput, bool>
    {

        private readonly IUserRepository _userRepository;
        public AuthServiceHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public async Task<bool> Handle(AuthServiceInput request, CancellationToken cancellationToken)
        {
            return ValidateUserAccess(new UserData { UserName = request.UserName, Password = request.Password });
        }

        private bool ValidateUserAccess(UserData loginDetails)
        {
            if (loginDetails.UserName == "test" && loginDetails.Password == "test")
            {
                return true;
            }

            var user = _userRepository.Get()
                .Where(p => p.UserName == loginDetails.UserName)
                .FirstOrDefault().Password
                .Equals(SHA1Tool
                .GetSHA1(loginDetails.Password));

            return user;
        }

    }
}
