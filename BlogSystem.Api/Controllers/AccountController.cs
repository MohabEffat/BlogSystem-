using BlogSystem.Application.Dtos;
using BlogSystem.Application.Services.Interfaces;
using BlogSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult>Register(RegisterDto input)
        {
            var existUser = await _userManager.FindByEmailAsync(input.Email);

            if (existUser is not null) return BadRequest("Email Already Exists");

            var user = new AppUser
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                UserName = input.UserName,
                DateOfBirth = input.DateOfBirth,
            };

            var result = await _userManager.CreateAsync(user, input.Password);

            if(!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest(new { Message = "User creation failed.", Errors = errors });
            }

            return Ok(new ResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName= user.UserName,
                Token = await _tokenService.GenerateTokenAsync(user)
            });
        }

        [HttpPost]
        public async Task<IActionResult>Login(LoginDto input)
        {
            var existUser = await _userManager.FindByEmailAsync(input.Email);

            if (existUser is null) return NotFound("Email Not Found");

            var result = await _signInManager.CheckPasswordSignInAsync(existUser, input.Password, false);

            if (!result.Succeeded) return NotFound("Email Not Found");

            return Ok(new ResponseDto
            {
                Id = existUser.Id,
                Email = existUser.Email!,
                UserName = existUser.UserName!,
                Token = await _tokenService.GenerateTokenAsync(existUser)

            });


        }
    }
}
