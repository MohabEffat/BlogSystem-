using BlogSystem.Application.Dtos;
using BlogSystem.Application.Manager.Commands;
using BlogSystem.Application.Services.Interfaces;
using BlogSystem.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Api.Controllers
{
    public class AccountController : BaseController
    {

        private readonly IMediator _mediator;

        public AccountController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult>Register(RegisterDto input)
        {
            var command = new RegisterCommand(input);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult>Login(LoginDto input)
        {
            var command = new LoginCommand(input);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
