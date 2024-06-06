using Case.DTOs;
using Case.ViewModels;

namespace Case.Services
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);

    }
}
