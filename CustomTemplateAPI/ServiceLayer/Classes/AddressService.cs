using CustomTemplateAPI.Models;
using CustomTemplateAPI.ServiceLayer.Interfaces;
using CustomTemplateAPI.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CustomTemplateAPI.ServiceLayer.Classes
{
    public class AddressService : IAddressService
    {
        public ILogger<AddressService> Logger { get; }
        public IUnitOfWork UnitOfWork { get; }
        public AddressService(ILogger<AddressService> logger, IUnitOfWork unitOfWork)
        {
            Logger = new LoggerFactory().CreateLogger<AddressService>();
            UnitOfWork = unitOfWork;
        }

        public async Task<int> SaveAddress(Address address)
        {
            try
            {
                return await UnitOfWork.AddressRepository.SaveAsync(address);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
