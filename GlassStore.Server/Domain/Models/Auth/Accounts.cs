using GlassStore.Server.Domain.Models.Glass;

namespace GlassStore.Server.Domain.Models.Auth
{
    public class Accounts: DbBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role[] Roles { get; set; }
    }

    public enum Role
    {
        User,
        Admin
    }
}
