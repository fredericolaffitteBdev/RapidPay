using MediatR;

namespace RapidPay.Application.Commands.Create.Card
{
    public class CreateCardCommandInput : IRequest<CreateCardCommandResult>
    {
        public string NameInCard { get; init; }
        public decimal InitialBalance { get; init; }
    }
}
