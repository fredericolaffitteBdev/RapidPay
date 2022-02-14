using MediatR;

namespace RapidPay.Application.Services.Authentication
{
    public class AuthServiceInput : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
