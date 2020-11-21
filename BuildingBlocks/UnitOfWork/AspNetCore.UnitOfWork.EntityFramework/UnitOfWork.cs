using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.UnitOfWork.EntityFramework
{
    public class UnitOfWork<TDbContext> : IUnitOfWork, IDisposable where TDbContext : DbContext
    {
        protected DbContext dbContext;
        protected IServiceProvider serviceProvider;
        private bool disposed = false;
        public UnitOfWork(TDbContext dbContext, IServiceProvider serviceProvider)
        {
            this.dbContext = dbContext;
            this.serviceProvider = serviceProvider;
        }
        public IUnitOfWorkTransactionScope BeginTransaction()
        {
            return new UnitOfWorkTransactionScope(this.dbContext).BeginTransaction();
        }

        public void Configure(UnitOfWorkOptions unitOfWorkOptions)
        {
            if (unitOfWorkOptions.Timeout.HasValue)
            {
                this.dbContext.Database.SetCommandTimeout(unitOfWorkOptions.Timeout.Value);
            }
        }
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing && dbContext != null)
                {
                    this.dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion Dispose
        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }

        TRepository IUnitOfWork.GetRepository<TRepository>()
        {
            var service = this.serviceProvider.GetService(typeof(TRepository));
            return service as TRepository;
        }
    }
}
