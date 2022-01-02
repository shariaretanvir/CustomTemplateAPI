using CustomTemplateAPI.ServiceLayer.Classes;
using CustomTemplateAPI.ServiceLayer.Interfaces;
using Microsoft.Extensions.Logging;

namespace CustomTemplateAPI.UnitOfWork
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        public ILogger<ServiceUnitOfWork> logger { get; }
        public ServiceUnitOfWork(ILogger<ServiceUnitOfWork> logger)
        {
            this.logger = logger;
        }
        public UnitOfWork UnitOfWork { get; }
        public ServiceUnitOfWork(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        private IStudentService studentService;
        public IStudentService StudentService
        {
            get { return studentService ?? (studentService = new StudentService(UnitOfWork)); }

        }

        
    }
}
