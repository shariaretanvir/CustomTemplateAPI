using CustomTemplateAPI.Models;
using CustomTemplateAPI.RepositoryLayer.Interfaces;
using DataAccessApp.DataAccessLayer;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CustomTemplateAPI.RepositoryLayer.Classes
{
    public class AddressRepository : RepositoryBase,IAddressRepository
    {
        private readonly ISqlDataAccess sqlDataAccess;
        public AddressRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
            sqlDataAccess = new SqlDataAccess(Connection, Transaction);
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Address>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Address> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> SaveAsync(Address model)
        {
            try
            {
                return await sqlDataAccess.Execute("InsAddress @AddressID,@AddressType,@FullAddress,@StudentID", model);
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }

        public Task<int> UpdateAsync(Address model)
        {
            throw new System.NotImplementedException();
        }
    }
}
