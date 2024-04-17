using GlassStore.Server.Domain.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GlassStore.Server.Servise.Auth;

namespace GlassStore.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthServise authServise;
        public AuthController(AuthServise authServise)
        {
            this.authServise = authServise;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            

            var user = await authServise.AuthentificateUser(request.Email, request.Password);
            if (user != null)
            {
                var token = authServise.GenerateJWT(user);
                return Ok(new { access_token = token });
            }
            return Unauthorized();
            
        }


    }
}
