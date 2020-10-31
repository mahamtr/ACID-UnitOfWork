using backend.Core.Entities;
using CleanArchitecture.Core.Entities;

namespace backend.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<User> Users { get; private set; }
        public IRepository<Account> Accounts { get; private set; }

        public IRepository<TransactionLog> TransactionLog { get; private set; }

        private readonly AppDataContext _context;


        public UnitOfWork(AppDataContext context)
        {
            _context = context;
            Accounts = new Repository<Account>(context);
            Users = new Repository<User>(context);
            TransactionLog = new Repository<TransactionLog>(context);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
