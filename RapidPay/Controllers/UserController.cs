using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Application.Commands.Create.User;
using System.Threading.Tasks;

namespace RapidPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {


        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("createUser")]
        [Authorize]
        public async Task<IActionResult> Create(string name, string password)
        {
            return new OkObjectResult(_mediator.Send(new CreateUserCommandInput
            {
                UserName = name,
                Password = password
            }).Result);
        }
    }
}
