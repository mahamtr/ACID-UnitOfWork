
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace backend.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BankDbContext _bankDbContext;
        public Repository(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public TEntity GetById(int id)
        {
            return _bankDbContext.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _bankDbContext.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate)
        {
            return _bankDbContext.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _bankDbContext.Set<TEntity>().Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entity)
        {
            _bankDbContext.Set<TEntity>().AddRange(entity);
        }

        public void Remove(TEntity entity)
        {
            _bankDbContext.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            _bankDbContext.Set<TEntity>().RemoveRange(entity);
        }
    }
}
