using BlogSystem.Application.Dtos;
using BlogSystem.Application.Manager.Commands;
using BlogSystem.Application.Services.Interfaces;
using BlogSystem.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace BlogSystem.Application.Manager.Handler
{
    public class LoginHandler : IRequestHandler<LoginCommand, ResponseDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginHandler(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }
        public async Task<ResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userManager.FindByEmailAsync(request.LoginDto.Email);

            if (existUser is null) throw new Exception("Invalid email or password.");

            var result = await _signInManager.CheckPasswordSignInAsync(existUser, request.LoginDto.Password, false);

            if (!result.Succeeded) throw new Exception("Invalid email or password.");

            return new ResponseDto
            {
                Id = existUser.Id,
                Email = existUser.Email!,
                UserName = existUser.UserName!,
                Token = await _tokenService.GenerateTokenAsync(existUser)
            };
        }
    }
}
