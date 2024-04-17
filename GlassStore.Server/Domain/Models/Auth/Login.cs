using System.ComponentModel.DataAnnotations;

namespace GlassStore.Server.Domain.Models.Auth
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
