using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HotelReservationSystem.api.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : BaseModel
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GeneralRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet
                .Where(c => c.IsActive);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return GetAll().Where(expression);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var course = await _dbSet
                .FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

            return course;
        }
        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var property in includeProperties)
            {
                query = _dbSet.Include(property);
            }

            var course = await query
                .FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

            return course;
        }

        public async Task<T?> GetByIdWithTrackingAsync(int id)
        {
            var course = await _dbSet
                .AsTracking()
                .FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

            return course;
        }

        public async Task<T> AddAsync(T t)
        {
            await _dbSet.AddAsync(t);
            await _context.SaveChangesAsync();

            return t;
        }

        public async Task<T> RemoveAsync(T t)
        {
            _dbSet.Remove(t);
            await _context.SaveChangesAsync();

            return t;
        }

        public async Task<List<T>> AddRangeAsync(List<T> ts)
        {
            await _dbSet.AddRangeAsync(ts);
            await _context.SaveChangesAsync();

            return ts;
        }
        public async Task<List<T>> RemoveRangeAsync(List<T> ts)
        {
            _dbSet.RemoveRange(ts);
            await _context.SaveChangesAsync();

            return ts;
        }

        public async Task<int> UpdateAsync(Expression<Func<T, bool>> predicate
                , Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setProperties)
        {
            var updatedRows = await _dbSet
                    .Where(predicate)
                    .ExecuteUpdateAsync(setProperties);
            return updatedRows;
        }

        public async Task UpdateIncludeAsync(T entity, params string[] modifiedProperties)
        {
            if (!_dbSet.Any(x => x.Id == entity.Id))
                return;

            var local = _dbSet.Local.FirstOrDefault(x => x.Id == entity.Id);

            EntityEntry entityEntry;
            if (local is null)
            {
                entityEntry = _dbSet.Entry(entity);
            }
            else
            {
                entityEntry = _context.ChangeTracker
                    .Entries<T>()
                    .FirstOrDefault(x => x.Entity.Id == entity.Id);
            }

            foreach (var property in entityEntry.Properties)
            {
                if (modifiedProperties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await GetByIdWithTrackingAsync(id);
            if (res is null)
                return false;

            res.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var isMatch = await _dbSet.AnyAsync(predicate, cancellationToken);

            return isMatch;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // This will save ALL changes made to ANY entity tracked by this DbContext instance.
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
