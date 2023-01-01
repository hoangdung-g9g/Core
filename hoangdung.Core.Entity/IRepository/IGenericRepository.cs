using System.Linq.Expressions;
using hoangdung.Core.Entity.Entity;

namespace hoangdung.Core.Entity.IRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        IQueryable<T?> Find(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task SaveChange();
        Task Dispose();
    }
}