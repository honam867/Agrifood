using AspNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.UnitOfWork.EntityFramework
{
    public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
          where TEntity : class, IEntity<TKey>
    {
        protected DbContext context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository(DbContext dbContext)
        {
            this.context = dbContext;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            TEntity entityToDelete = await dbSet.Where(p => p.Id.Equals(id)).SingleOrDefaultAsync();
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (entityToDelete is ISoftDeletable)
            {
                context.Entry(entityToDelete)
                .Property("IsDeleted")
                .CurrentValue = true;
                context.Entry(entityToDelete).State = EntityState.Modified;
            }
            else
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<TEntity> GetEntity()
        {
            return await dbSet.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetEntitiesAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetEntityByIdAsync(TKey id)
        {
            return await dbSet.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public void DeleteRange(List<TEntity> entitiesToDelete)
        {
            if (entitiesToDelete.Count > 0)
            {
                entitiesToDelete.ForEach(entity =>
                {
                    Delete(entity);
                });
            }
        }

        public virtual void UpdateRange(List<TEntity> entitiesToUpdate)
        {
            if (entitiesToUpdate.Count > 0)
            {
                entitiesToUpdate.ForEach(entity =>
                {
                    Update(entity);
                });
            }
        }
    }
}
