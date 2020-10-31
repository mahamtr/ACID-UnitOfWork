
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace backend.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDataContext _appDataContext;
        public Repository(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }
        public TEntity GetById(int id)
        {
            return _appDataContext.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _appDataContext.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate)
        {
            return _appDataContext.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _appDataContext.Set<TEntity>().Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entity)
        {
            _appDataContext.Set<TEntity>().AddRange(entity);
        }

        public void Remove(TEntity entity)
        {
            _appDataContext.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            _appDataContext.Set<TEntity>().RemoveRange(entity);
        }
    }
}
