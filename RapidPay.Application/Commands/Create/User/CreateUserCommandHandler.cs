using MediatR;
using RapidPay.Application.Crosscutting;
using RapidPay.Domain.User;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Application.Commands.Create.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandInput, bool>
    {
        private readonly IUserRepository _repository;
        public CreateUserCommandHandler(IMediator mediator, IUserRepository repository)
        {
            this._repository = repository;
        }
        public async Task<bool> Handle(CreateUserCommandInput request, CancellationToken cancellationToken)
        {
            _repository.Add(new UserData { Password = SHA1Tool.GetSHA1(request.Password), UserName = request.UserName });

            var ret = _repository.UnitOfWork.CommitAsync(cancellationToken);

            return ret.IsCompletedSuccessfully;
        }
    }
}
