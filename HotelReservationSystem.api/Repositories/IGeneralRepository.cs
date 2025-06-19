using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HotelReservationSystem.api.Repositories
{
    public interface IGeneralRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();

        IQueryable<T> Get(Expression<Func<T, bool>> expression);

        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);

        Task<T?> GetByIdWithTrackingAsync(int id);

        Task<T> AddAsync(T t);
        Task<T> RemoveAsync(T t);
        Task<List<T>> AddRangeAsync(List<T> ts);
        Task<List<T>> RemoveRangeAsync(List<T> ts);

        Task<int> UpdateAsync(Expression<Func<T, bool>> predicate
                , Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setProperties);

        Task<bool> DeleteAsync(int id);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
