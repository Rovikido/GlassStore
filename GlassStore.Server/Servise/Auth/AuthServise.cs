
using GlassStore.Server.DAL.Implementations;
using GlassStore.Server.Domain.Models.Auth;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GlassStore.Server.Servise.Auth
{
    public class AuthServise
    {
        private readonly IOptions<AuthOptions> authoptions;
        private readonly AuthRepository authRepository;
        public AuthServise(AuthRepository authRepository, IOptions<AuthOptions> authOptions) {
            this.authoptions = authOptions;
            this.authRepository = authRepository;
        }
        public async Task<Accounts> AuthentificateUser(string email, string password)
        {
            return await authRepository.FindUser(email, password);
        }

        public string GenerateJWT(Accounts user)
        {
            var authParams = authoptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>() {
                        new Claim (JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
                    };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }
            var token = new JwtSecurityToken(authParams.Issuer,
            authParams.Audience,
            claims,
            expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
            signingCredentials: credentials) ;

            return new JwtSecurityTokenHandler().WriteToken(token);
            
        } 
    }
}
