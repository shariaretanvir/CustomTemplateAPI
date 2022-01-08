using CustomTemplateAPI.RepositoryLayer.Classes;
using CustomTemplateAPI.RepositoryLayer.Interfaces;
using CustomTemplateAPI.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CustomTemplateAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection connection;
        private IDbTransaction transaction;
        private IStudentRepository _studentRepository;
        private IAddressRepository _addressRepository;
        private bool disposedValue;

        public UnitOfWork()
        {

        }
        public IStudentRepository StudentRepository
        {
            get
            {
                OpenConnection();
                return _studentRepository ?? (_studentRepository = new StudentRepository(connection, transaction));
            }
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                OpenConnection();
                return _addressRepository ?? (_addressRepository = new AddressRepository(connection, transaction));
            }
        }


        private void OpenConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(Common.AppSettings["ConnectionStrings:MyConstring"].ToString());
                connection.Open();
            }
        }
        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch (System.Exception e)
            {
                transaction.Rollback();
                throw new System.Exception(e.Message);
            }
            finally
            {
                connection.Dispose();
                resetRepository();
            }
        }

        private void resetRepository()
        {
            _studentRepository = null;
            _addressRepository = null;
        }

        public void InitTransaction()
        {
            OpenConnection();
            transaction = connection.BeginTransaction();
        }

        public void Rollback()
        {
            transaction.Rollback();
            resetRepository();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }
                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}
