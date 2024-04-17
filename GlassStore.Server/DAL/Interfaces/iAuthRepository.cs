using GlassStore.Server.Domain.Models.Auth;
using GlassStore.Server.Repositories.Interfaces;

namespace GlassStore.Server.DAL.Interfaces
{
    public interface iAuthRepository : iBaseRepository<Accounts>
    {
        public Task<Accounts> FindUser(string email, string password);
    }
}
