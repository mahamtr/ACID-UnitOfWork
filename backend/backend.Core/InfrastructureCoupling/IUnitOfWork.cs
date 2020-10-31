using backend.Core.Entities;
using CleanArchitecture.Core.Entities;
using System;

namespace backend.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Account> Accounts{ get; }
        IRepository<TransactionLog> TransactionLog { get; }


        int Commit();

    }
}
