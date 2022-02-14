using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RapidPay.Application.Services.Authentication;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;
        public AuthenticationController(IConfiguration configuration, IMediator mediator)
        {
            _config = configuration;
            _mediator = mediator;
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(AuthServiceInput loginDetails)
        {
            bool resultado = await _mediator.Send(new AuthServiceInput { UserName = loginDetails.UserName, Password = loginDetails.Password });

            if (resultado)
            {
                var issuer = _config["Jwt:Issuer"];
                var audience = _config["Jwt:Audience"];
                var expiry = DateTime.Now.AddMinutes(60);
                var securityKey = new SymmetricSecurityKey
                                  (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials
                                  (securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(issuer: issuer,
                                                 audience: audience,
                                                 expires: DateTime.Now.AddMinutes(120),
                                                 signingCredentials: credentials);
                var tokenHandler = new JwtSecurityTokenHandler();
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(new { token = stringToken });
            }
            else
            {
                return Unauthorized();
            }
        }



    }
}
