using CustomTemplateAPI.ServiceLayer.Interfaces;

namespace CustomTemplateAPI.UnitOfWork
{
    public interface IServiceUnitOfWork
    {
        IStudentService StudentService { get; }        
    }
}
