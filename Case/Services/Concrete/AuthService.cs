using Case.DTOs;
using Case.Models;
using Case.Repository;
using Case.ViewModels;

namespace Case.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService tokenService;
    private readonly IUserRepository userRepository;
    private readonly IAuthTokenRepository authTokenRepository;

    public AuthService(ITokenService tokenService, IUserRepository userRepository, IAuthTokenRepository authTokenRepository)
    {
        this.tokenService = tokenService;
        this.userRepository = userRepository;
        this.authTokenRepository = authTokenRepository;
    }

    public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
    {
        UserLoginResponse response = new();

        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            throw new ArgumentNullException(nameof(request));
        }

        var user = userRepository.GetAsync(x => x.Email == request.Email &&  x.Password == request.Password);

        if (user != null)
        {
            var generatedTokenInfo = await tokenService.GenerateToken(new GTokenRequest { UserMail = request.Email });

            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInfo.Token;
            response.AccessTokenExpireDate = generatedTokenInfo.TokenExpDate;

            authTokenRepository.AddAsync(new AuthToken
            {
                UserId = user.Id,
                CreatedDate = DateTime.Now,
                Token = response.AuthToken
            });
        }

        return response;

    }
}
