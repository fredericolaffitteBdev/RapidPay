using MediatR;
using System;

namespace RapidPay.Application.Queries.Get.Card
{
    public class GetBalanceQueryInput : IRequest<decimal>
    {
        public Int64 CardNumber { get; set; }
    }
}
