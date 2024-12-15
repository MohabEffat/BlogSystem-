using BlogSystem.Application.Services.Interfaces;
using BlogSystem.Domain.Entities.Identity;
using BlogSystem.Infrastructure.OptionsSetup;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogSystem.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtOptions _options;  
        private readonly SymmetricSecurityKey _key;

        public TokenService(UserManager<AppUser> userManager, IOptions<JwtOptions> options)
        {
            _userManager = userManager;
            _options = options.Value;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        }
        public async Task<string> GenerateTokenAsync(AppUser user)
        {
            var userClaims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, user.FirstName!),
                new Claim (ClaimTypes.Surname, user.LastName!),
                new Claim (ClaimTypes.GivenName, user.UserName!),
                new Claim (ClaimTypes.Email, user.Email!),
                new Claim (ClaimTypes.DateOfBirth, user.DateOfBirth.ToString(("yyyy-MM-dd"))!),
                new Claim (ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles) 
                userClaims.Add(new Claim(ClaimTypes.Role, role));

            var userCreds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = userCreds,
                Subject = new ClaimsIdentity(userClaims),
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                Expires = DateTime.UtcNow.Add(_options.ExpiryTimeFrame)

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken (tokenDescriptor);

            return tokenHandler.WriteToken (token);
        }

        public Task<string> VerifyTokenAsync()
        {
            throw new NotImplementedException();
        }
    }
}
