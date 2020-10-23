using backend.Core.Entities;
using CleanArchitecture.Core.Entities;

namespace backend.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Users> Users { get; private set; }
        public IRepository<Accounts> Accounts { get; private set; }

        public IRepository<TransactionLog> TransactionLog { get; private set; }

        private readonly BankDbContext _context;


        public UnitOfWork(BankDbContext context)
        {
            _context = context;
            Accounts = new Repository<Accounts>(context);
            Users = new Repository<Users>(context);
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
