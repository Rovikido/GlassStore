using GlassStore.Server.Domain.Models.Glass;

namespace GlassStore.Server.Domain.Models.User
{
    public class Basket
    {
        public List<Glasses> Glasses { get; set; }

        public decimal TotalPrice => Glasses.Sum(g => g.Price);  //!!!!!


    }
}
