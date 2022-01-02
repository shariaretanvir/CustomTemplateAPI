using CustomTemplateAPI.Models;
using CustomTemplateAPI.ServiceLayer.Interfaces;
using CustomTemplateAPI.UnitOfWork;
using Microsoft.Extensions.Logging;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomTemplateAPI.ServiceLayer.Classes
{
    public class StudentService : IStudentService
    {
        public ILogger<StudentService> logger { get; set; }
        public IUnitOfWork UnitOfWork { get; }

        public StudentService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            this.logger = new LoggerFactory().CreateLogger<StudentService>();
        }

        public Task<IEnumerable<object>> GetAllStudents()
        {
            return UnitOfWork.StudentRepository.GetAllStudents();
        }

        public Task<int> SaveStudent(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}
