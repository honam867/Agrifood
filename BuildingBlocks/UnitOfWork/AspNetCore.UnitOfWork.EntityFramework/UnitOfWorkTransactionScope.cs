using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.UnitOfWork.EntityFramework
{
    public class UnitOfWorkTransactionScope : IUnitOfWorkTransactionScope
    {
        private DbContext context;
        private bool disposed = false;
        private bool isCommited = false;
        private bool isTransactionCreated = false;
        private IDbContextTransaction transaction;
        public UnitOfWorkTransactionScope(DbContext context)
        {
            this.context = context;
        }
        public IUnitOfWorkTransactionScope BeginTransaction()
        {
            this.transaction = context.Database.BeginTransaction();
            this.isTransactionCreated = true;
            return this;
        }

        public void Commit()
        {
            this.transaction.Commit();
            this.isCommited = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }
            if (disposing)
            {
                if (!this.isTransactionCreated || this.transaction == null)
                {
                    return;
                }
                if (!this.isCommited)
                {
                    this.transaction.Rollback();
                }
                this.transaction.Dispose();
            }
        }
    }
}
