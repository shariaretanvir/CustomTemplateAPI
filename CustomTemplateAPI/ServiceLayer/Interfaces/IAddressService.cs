using CustomTemplateAPI.Models;
using System.Threading.Tasks;

namespace CustomTemplateAPI.ServiceLayer.Interfaces
{
    public interface IAddressService
    {
        Task<int> SaveAddress(Address address);
    }
}
