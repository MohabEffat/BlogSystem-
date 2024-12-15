using BlogSystem.Application.Services.Interfaces;
using BlogSystem.Domain.Entities.Identity;
using BlogSystem.Infrastructure.Data.Contexts;
using BlogSystem.Infrastructure.OptionsSetup;
using BlogSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtOptions>(configuration.GetSection("JWT"));
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
