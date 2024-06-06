using Case.DTOs;
using Case.ViewModels;

namespace Case.Services
{
    public interface ITokenService
    {
        public Task<GTokenResponse> GenerateToken(GTokenRequest request);

    }
}
