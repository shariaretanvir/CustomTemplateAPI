using CustomTemplateAPI.BusinessLayer.Interfaces;
using CustomTemplateAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomTemplateAPI.BusinessLayer.Classes
{
    public class StudentRepository : IStudentRepository
    {
        public Task<int> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveAsync(Student model)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(Student model)
        {
            throw new System.NotImplementedException();
        }
    }
}
