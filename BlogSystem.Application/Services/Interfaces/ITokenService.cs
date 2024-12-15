using BlogSystem.Domain.Entities.Identity;

namespace BlogSystem.Application.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(AppUser user);
        Task<string> VerifyTokenAsync();
    }
}
