using MediatR;
using RapidPay.Domain.Card;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Application.Queries.Get.Card
{
    public class GetBalanceQueryHandler : IRequestHandler<GetBalanceQueryInput, decimal>
    {
        private readonly IMediator _mediator;
        private readonly ICardRepository _repository;
        public GetBalanceQueryHandler(IMediator mediator, ICardRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<decimal> Handle(GetBalanceQueryInput request, CancellationToken cancellationToken)
        {
            var data = _repository.Get().Where(p => p.CardNumber == request.CardNumber).FirstOrDefault();
            var result = data.Balance - data.BalanceUsed;

            return result;
        }
    }
}
