using System.Data;

namespace CustomTemplateAPI.RepositoryLayer.Classes
{
    public class RepositoryBase
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }

        public RepositoryBase(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
    }
}
