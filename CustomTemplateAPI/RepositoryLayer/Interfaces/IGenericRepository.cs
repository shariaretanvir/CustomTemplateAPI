using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomTemplateAPI.RepositoryLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<int> SaveAsync(T model);
        Task<int> UpdateAsync(T model);
        Task<int> DeleteAsync(int id);
    }
}
