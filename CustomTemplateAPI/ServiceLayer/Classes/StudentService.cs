using CustomTemplateAPI.Models;
using CustomTemplateAPI.ServiceLayer.Interfaces;
using CustomTemplateAPI.UnitOfWork;
using Microsoft.Extensions.Logging;
using NLog;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> SaveStudent(Student student)
        {
            try
            {
                UnitOfWork.InitTransaction();
                int stdid = await UnitOfWork.StudentRepository.SaveStudent(student);
                student.Addresses.ForEach(address =>address.StudentID = stdid);
                //await UnitOfWork.AddressRepository.SaveAsync(student.Addresses[0]);
                foreach (Address address in student.Addresses)
                {
                    await UnitOfWork.AddressRepository.SaveAsync(address);
                }
                UnitOfWork.Commit();                
                return 1;
            }
            catch (System.Exception e)
            {
                UnitOfWork.Rollback();
                throw new System.Exception(e.Message);
            }
        }
    }
}
