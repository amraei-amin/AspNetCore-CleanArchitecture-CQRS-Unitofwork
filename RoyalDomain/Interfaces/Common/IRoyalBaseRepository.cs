using System.Linq.Expressions;

namespace RoyalDomain.Interfaces.Common
{
    public interface IRoyalBaseRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void AddRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
    }
}