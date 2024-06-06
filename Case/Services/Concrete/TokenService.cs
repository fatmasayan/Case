using Case.DTOs;
using Case.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Case.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public Task<GTokenResponse> GenerateToken(GTokenRequest request)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]));

            var tokenExpSecond = int.Parse(_configuration["AppSettings:Expiration"]);

            var dateTime = DateTime.Now;

            var expires = dateTime.AddSeconds(tokenExpSecond);

            JwtSecurityToken jwt = new JwtSecurityToken(
               issuer: _configuration["AppSettings:ValidIssuer"],
               audience: _configuration["AppSettings:ValidAudience"],
               claims: new List<Claim> {
                    new Claim("userMail", request.UserMail)
               },
               notBefore: dateTime,
               expires: expires,
               signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
           );

            return Task.FromResult(new GTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpDate = expires
            });
        }
    }
}
