using CustomTemplateAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomTemplateAPI.RepositoryLayer.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<object>> GetAllStudents();
        Task<int> SaveStudent(Student student);
    }
}
