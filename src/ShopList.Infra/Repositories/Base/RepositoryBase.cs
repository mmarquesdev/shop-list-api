using Microsoft.EntityFrameworkCore;
using ShopList.Domain.Entities.Base;
using ShopList.Domain.Repositories.Base;
using System.Linq.Expressions;

namespace ShopList.Infra.Repositories.Base
{
    public abstract class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : EntityBase where TId : struct
    {
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        private readonly DbContext _context;

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public TEntity? GetById(TId id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).Where(x => x.Id.Equals(id)).SingleOrDefault();
            }

            return _context.Set<TEntity>().Find(id);
        }

        public TEntity? GetBy(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return List(includeProperties)?.Where(where)?.FirstOrDefault();
        }

        public bool Exists(Func<TEntity, bool> where)
        {
            return _context.Set<TEntity>().Any(where);
        }

        public IQueryable<TEntity> List(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntity>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntity> ListBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return List(includeProperties).Where(where);
        }

        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
