using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogSystem.Infrastructure.OptionsSetup
{
    public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _options;

        public JwtBearerOptionsSetup(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidIssuer = _options.Issuer,
                ValidateAudience = true,
                ValidAudience = _options.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }
    }
}
