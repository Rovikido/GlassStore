using GlassStore.Server.Repositories.Implementations;
using GlassStore.Server.Repositories.Interfaces;
using MongoDB.Driver;
using GlassStore.Server.DAL.Interfaces;
using GlassStore.Server.Domain.Models.User;
using GlassStore.Server.Domain.Models.Auth;

namespace GlassStore.Server.DAL.Implementations
{
    public class UserRepository : BaseRepository<Accounts>,  iUserRepository
    {
        private readonly IMongoCollection<Accounts> _data;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _data = db.Account;
        }
        public async Task<Accounts> FindUserAuth(string email, string password)
        {
            return (await _data.FindAsync(x => x.Email == email && x.Password == password)).FirstOrDefault();
        }



    }
}
