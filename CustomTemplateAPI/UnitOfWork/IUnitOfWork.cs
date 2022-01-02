using CustomTemplateAPI.RepositoryLayer.Interfaces;
using System;

namespace CustomTemplateAPI.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        void InitTransaction();

        IStudentRepository StudentRepository { get; }
    }
}
