using Microsoft.EntityFrameworkCore;
using RapidPay.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Infra
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected BaseRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private readonly Context _context;

        public IUnitOfWork UnitOfWork => _context;

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _context
                .Set<TEntity>()
                .AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }

        public IQueryable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> predicate = null)
            => Get(predicate).AsNoTracking();

        public void Add(TEntity entity) => _context.Add(entity);

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
            => await _context.AddAsync(entity, cancellationToken);

        public void Update(TEntity entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Remove(Guid id) => _context.Remove(id);

    }
}
