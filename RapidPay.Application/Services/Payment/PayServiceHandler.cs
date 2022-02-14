using MediatR;
using RapidPay.Application.Services.Fee;
using RapidPay.Domain.Card;
using RapidPay.Domain.Payment;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Application.Services.Payment
{
    public class PayServiceHandler : IRequestHandler<PayServiceInput, string>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IFeeService _feeService;
        public PayServiceHandler(ICardRepository repository, IPaymentRepository paymentRepository, IFeeService fee)
        {
            _feeService = fee;
            _cardRepository = repository;
            _paymentRepository = paymentRepository;
        }
        public async Task<string> Handle(PayServiceInput request, CancellationToken cancellationToken)
        {

            var cardData = _cardRepository.Get().Where(p => p.CardNumber == request.CardNumberPayment).FirstOrDefault();

            if (cardData == null)
                return "The credit card does not exists";

            var feeAmount = _feeService.GetFee();
            var result =
                DateTime.Now >= cardData.ExpirationDate
                ? "The card is over expiration date" :
                request.CVV != cardData.CVV
                ? "Wrong CVV" :
                cardData.Balance - cardData.BalanceUsed < request.PaymentValue
                ? "The card has no balance" : "Success";


            if (!result.Equals("Success"))
            {
                return result;
            }

            var payment = new PaymentData
            {
                CardNumberPayment = request.CardNumberPayment,
                PaymentDate = DateTime.Now,
                PaymentDescription = request.PaymentDescription,
                PaymentResult = result,
                PaymentValue = request.PaymentValue + feeAmount,
                Receiver = request.Receiver,
                FeeTransaction = feeAmount
            };

            cardData.BalanceUsed += request.PaymentValue + feeAmount;

            _cardRepository.Update(cardData);

            _paymentRepository.Add(payment);

            await _cardRepository.UnitOfWork.CommitAsync(cancellationToken);
            await _paymentRepository.UnitOfWork.CommitAsync(cancellationToken);

            return $"The fee price is {payment.FeeTransaction}";

        }
    }
}
