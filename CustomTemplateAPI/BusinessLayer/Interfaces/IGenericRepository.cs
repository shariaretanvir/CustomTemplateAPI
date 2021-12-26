using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomTemplateAPI.BusinessLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> SaveAsync(T model);
        Task<int> UpdateAsync(T model);
        Task<int> DeleteAsync(int id);
    }
}
