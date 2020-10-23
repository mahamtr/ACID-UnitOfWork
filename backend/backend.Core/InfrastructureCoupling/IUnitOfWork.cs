using backend.Core.Entities;
using CleanArchitecture.Core.Entities;
using System;

namespace backend.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Users> Users { get; }
        IRepository<Accounts> Accounts{ get; }
        IRepository<TransactionLog> TransactionLog { get; }


        int Commit();

    }
}
