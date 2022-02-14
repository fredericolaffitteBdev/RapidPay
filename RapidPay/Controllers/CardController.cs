using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Application.Commands.Create.Card;
using RapidPay.Application.Commands.Update;
using RapidPay.Application.Queries.Get.Card;
using System;
using System.Threading.Tasks;

namespace RapidPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase

    {

        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("createCard")]
        [Authorize]
        public async Task<IActionResult> Create(string name, decimal initialBalance)
        {
            return new OkObjectResult(_mediator.Send(new CreateCardCommandInput
            {
                InitialBalance = initialBalance,
                NameInCard = name
            }).Result);
        }

        [HttpPut("changeBalanceLimit")]
        [Authorize]
        public async Task<IActionResult> Update(Int64 cardNumber, decimal newBalance, bool newCVV = false)
        {
            return new OkObjectResult(_mediator.Send(new UpdateCardCommandInput
            {
                CardNumber = cardNumber,
                NewBalance = newBalance,
                UpdateCVV = newCVV
            }).Result)
            ;
        }

        [HttpGet("getBalance")]
        [Authorize]
        public async Task<IActionResult> Get(Int64 cardNumber)
        {
            return new OkObjectResult(_mediator.Send(new GetBalanceQueryInput { CardNumber = cardNumber }).Result);
        }
    }
}
