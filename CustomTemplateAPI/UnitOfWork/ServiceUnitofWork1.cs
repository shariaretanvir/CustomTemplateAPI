using CustomTemplateAPI.ServiceLayer.Interfaces;

namespace CustomTemplateAPI.UnitOfWork
{
    public class ServiceUnitofWork1 : IServiceUnitOfWork
    {
        public IStudentService StudentService => throw new System.NotImplementedException();

        public string Name { get; set; }
    }
}
