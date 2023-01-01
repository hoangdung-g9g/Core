using System.Linq.Expressions;
using AutoMapper;
using hoangdung.Core.Entity.Entity;
using hoangdung.Core.Entity.IRepository;
using Microsoft.EntityFrameworkCore;

namespace hoangdung.Core.Entity.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _entity;
        protected readonly IMapper _mapper;
        public GenericRepository(DbContext context, IMapper mapper)
        {
            _context = context;
            _entity = context.Set<T>();
            _mapper = mapper;
        }
        public async Task Add(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _entity.AddRangeAsync(entities);
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }

        public IQueryable<T?> Find(Expression<Func<T, bool>> expression)
        {
            return _entity.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _entity.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entity.RemoveRange(entities);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _entity.UpdateRange(entities);
        }
    }
}