using GlassStore.Server.DAL.Interfaces;
using GlassStore.Server.Domain.Models.Auth;
using GlassStore.Server.Domain.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GlassStore.Server.Servise.Helpers
{
    public class HttpService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public iUserRepository userRepository { get; }

        public HttpService(IHttpContextAccessor httpContextAccessor, iUserRepository userRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userRepository = userRepository;
        }

        public string GetCurrentUserId()
        {
            //var userIdClaim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            //return userIdClaim?.Value;
            var claims = httpContextAccessor.HttpContext.User.Claims;

            //var subClaim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
            var subClaim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = subClaim?.Value;
            return userId;
        }

        public async Task<Accounts> GetCurrentUser()
        {
            return await userRepository.GetByIdAsync(GetCurrentUserId());
        }
    }
}
