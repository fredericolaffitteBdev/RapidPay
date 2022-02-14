using MediatR;

namespace RapidPay.Application.Commands.Create.User
{
    public class CreateUserCommandInput : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
