using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : class, IRepository;
        /// <summary>
        ///  
        /// </summary>
        /// <returns>
        /// The number of objects in an Added, Modified, or Deleted state when SaveChanges was called
        /// </returns>
        int SaveChanges();

        Task<int> SaveChangesAsync();
        IUnitOfWorkTransactionScope BeginTransaction();
        /// <summary>
        /// Begin Unit of work
        /// </summary>
        /// <param name="unitOfWorkOptions"></param>
        void Configure(UnitOfWorkOptions unitOfWorkOptions);

    }

    public interface IUnitOfWork<TContext>
    {
        TContext Context { set; get; }
    }

}
