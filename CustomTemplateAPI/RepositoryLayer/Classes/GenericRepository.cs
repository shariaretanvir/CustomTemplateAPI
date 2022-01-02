using CustomTemplateAPI.RepositoryLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomTemplateAPI.RepositoryLayer.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveAsync(T model)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(T model)
        {
            throw new System.NotImplementedException();
        }
    }
}
