using GlassStore.Server.Domain.Models.Glass;

namespace GlassStore.Server.Domain.Models.User
{
    public class Orders : Basket
    {
       public DateTime OrderDate { get; set; }
    }
}
