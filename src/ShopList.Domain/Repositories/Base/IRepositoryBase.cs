using ShopList.Domain.Entities.Base;
using System.Linq.Expressions;

namespace ShopList.Domain.Repositories.Base
{
    public interface IRepositoryBase<TEntity, TId>
          where TEntity : EntityBase
          where TId : struct
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        Task SaveChangesAsync();

        TEntity? GetById(TId id, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity? GetBy(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties);
        bool Exists(Func<TEntity, bool> where);

        IQueryable<TEntity> List(params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> ListBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
