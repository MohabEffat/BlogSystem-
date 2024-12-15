using BlogSystem.Application.Dtos;
using BlogSystem.Application.Manager.Commands;
using BlogSystem.Application.Services.Interfaces;
using BlogSystem.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BlogSystem.Application.Manager.Handler
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, ResponseDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public RegisterHandler(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<ResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userManager.FindByEmailAsync(request.Register.Email);

            if (existUser is not null) throw new InvalidOperationException("User with this email already exists.");

            var user = new AppUser
            {
                FirstName = request.Register.FirstName,
                LastName = request.Register.LastName,
                Email = request.Register.Email,
                UserName = request.Register.UserName,
                DateOfBirth = request.Register.DateOfBirth,
            };

            var result = await _userManager.CreateAsync(user, request.Register.Password);

            if (!result.Succeeded) throw new InvalidOperationException("User registration failed. Errors: " +
                                             string.Join(", ", result.Errors.Select(e => e.Description)));
            return (new ResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Token = await _tokenService.GenerateTokenAsync(user)
            });
        }
    }
}
