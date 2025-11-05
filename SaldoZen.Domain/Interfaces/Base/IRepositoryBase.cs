using System.Linq.Expressions;

namespace SaldoZen.Domain.Interfaces.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        IQueryable<TEntity> ListBy(Expression<Func<TEntity, bool>> predicate);
    }
}
