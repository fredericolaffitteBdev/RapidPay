using MediatR;
using System;

namespace RapidPay.Application.Commands.Update
{
    public class UpdateCardCommandInput : IRequest<UpdateCardCommandResult>
    {
        public Int64 CardNumber { get; set; }
        public decimal NewBalance { get; set; }
        public bool UpdateCVV { get; set; }
    }
}
