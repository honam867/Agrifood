using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.UnitOfWork
{
    public interface IGenericRepository<TEntity, TKey> : IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> GetEntity();
        Task<TEntity> GetEntityByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetEntitiesAsync();
        void Update(TEntity entity);
        Task DeleteAsync(TKey id);
        void Delete(TEntity entityToDelete);
        void DeleteRange(List<TEntity> entitiesToDelete);
        void UpdateRange(List<TEntity> entitiesToUpdate);
    }
}
