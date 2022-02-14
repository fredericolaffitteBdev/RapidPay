using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Domain
{
    public interface IBaseRepository<TEntity> : IRepository where TEntity : IBaseEntity
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> predicate = null);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Remove(Guid id);
    }
}
