using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Application.Services.Payment;
using System.Threading.Tasks;

namespace RapidPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase

    {

        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("newPayment")]
        [Authorize]
        public async Task<IActionResult> Create(PayServiceInput paymentDetails)
        {
            return new OkObjectResult(_mediator.Send(paymentDetails).Result);
        }
    }
}
