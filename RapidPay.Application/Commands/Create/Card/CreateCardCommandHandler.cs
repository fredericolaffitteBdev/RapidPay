using MediatR;
using RapidPay.Domain.Card;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Application.Commands.Create.Card
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommandInput, CreateCardCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly ICardRepository _repository;
        public CreateCardCommandHandler(IMediator mediator, ICardRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<CreateCardCommandResult> Handle(CreateCardCommandInput request, CancellationToken cancellationToken)
        {
            var rand = new Random();

            var initial = request.InitialBalance;
            var cardData = _repository.Get().OrderByDescending(p => p.CardNumber).FirstOrDefault();
            var number = cardData == null ? 452637589657852 : cardData.CardNumber + 1;


            var newCard = new CardData
            {
                Balance = initial,
                CardNumber = number,
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddMonths(24),
                CVV = rand.Next(0, 999),
                IsCredit = true,
                BalanceUsed = 0
            };

            _repository.Add(newCard);

            await _repository.UnitOfWork.CommitAsync(cancellationToken);

            return new CreateCardCommandResult
            {
                CardNumber = newCard.CardNumber,
                Balance = newCard.Balance,
                CVV = newCard.CVV,
                ExpirationDate = newCard.ExpirationDate
            };


        }
    }
}
