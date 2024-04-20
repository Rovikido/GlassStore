using GlassStore.Server.Domain.Models.Auth;
using GlassStore.Server.Domain.Models.User;
using GlassStore.Server.Repositories.Interfaces;

namespace GlassStore.Server.DAL.Interfaces
{
    public interface iUserRepository : iBaseRepository<Accounts> 
    {
        public Task<Accounts> FindUserAuth(string email, string password);
    }
}
