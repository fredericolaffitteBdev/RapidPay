using MediatR;
using RapidPay.Domain.Card;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Application.Commands.Update
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommandInput, UpdateCardCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly ICardRepository _repository;
        public UpdateCardCommandHandler(IMediator mediator, ICardRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<UpdateCardCommandResult> Handle(UpdateCardCommandInput request, CancellationToken cancellationToken)
        {
            var rand = new Random();

            var actualData = _repository
                .Get()
                .Where(p => p.CardNumber == request.CardNumber)
                .FirstOrDefault();

            actualData.CVV = request.UpdateCVV ?
                rand.Next(0, 999) :
                actualData.CVV;



            if (request.NewBalance == null)
                _repository.Update(actualData);

            else
            {
                actualData.Balance = request.NewBalance;
                _repository.Update(actualData);
            }

            await _repository.UnitOfWork.CommitAsync(cancellationToken);

            var result = actualData;

            return new UpdateCardCommandResult { UpdatedCard = result };
        }
    }
}
