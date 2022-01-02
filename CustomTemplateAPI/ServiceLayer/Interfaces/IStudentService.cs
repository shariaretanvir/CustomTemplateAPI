using CustomTemplateAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomTemplateAPI.ServiceLayer.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<object>> GetAllStudents();
        Task<int> SaveStudent(Student student);
    }
}
