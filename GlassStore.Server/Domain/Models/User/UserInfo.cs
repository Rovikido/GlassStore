
using GlassStore.Server.Domain.Models.Auth;
using GlassStore.Server.Domain.Models.Glass;

namespace GlassStore.Server.Domain.Models.User
{
    public class UserInfo : DbBase
    {
        public string Email { get; set; }
        //public string Password { get; set; }
        public List<Orders> Orders { get; set; }
        public Basket Basket { get; set; }
        public Role[] Roles { get; set; }
    }
}
