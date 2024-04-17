using GlassStore.Server.Repositories.Implementations;
using GlassStore.Server.Repositories.Interfaces;
using GlassStore.Server.Domain.Models.Auth;
using MongoDB.Driver;
using GlassStore.Server.DAL.Interfaces;

namespace GlassStore.Server.DAL.Implementations
{
    public class AuthRepository : BaseRepository<Accounts>,  iAuthRepository
    {
        private readonly IMongoCollection<Accounts> _data;
        public AuthRepository(ApplicationDbContext db) : base(db)
        {
            _data = db.dbSet<Accounts>();
        }
        public async Task<Accounts> FindUser(string email, string password)
        {
            return (await _data.FindAsync(x => x.Email == email && x.Password == password)).FirstOrDefault();
        }


    }
}
