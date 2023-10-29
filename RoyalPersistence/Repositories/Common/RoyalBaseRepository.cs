using Microsoft.EntityFrameworkCore;
using RoyalDomain.Interfaces.Common;
using RoyalPersistence.Context;
using System.Linq.Expressions;

namespace RoyalPersistence.Common
{
    public abstract class RoyalBaseRepository<T> : IRoyalBaseRepository<T> where T : class
    {
        protected RoyalDbContext RepositoryContext { get; set; }
        public RoyalBaseRepository(RoyalDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public T Create(T entity) => RepositoryContext.Set<T>().Add(entity).Entity;
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);       
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
        public void AddRange(IEnumerable<T> entities) => RepositoryContext.Set<T>().AddRange(entities);

       
    }
}
