using GlassStore.Server.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlassStore.Server.Repositories.Interfaces;

    public interface iBaseRepository <T> where T : class
{
        Task<IEnumerable<T>> GetAllAsync();
        Task<DataList<T>> GetFirstAsync(int i);
        Task<T> GetByIdAsync(string id);
        Task<DataList<T>> GetSliceAsync(int from, int to);
        Task CreateAsync(T movie);
        Task UpdateAsync(string id, T updatedData);
        Task DeleteAsync(string id);
}

