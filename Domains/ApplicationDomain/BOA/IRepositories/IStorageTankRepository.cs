using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IStorageTankRepository : IGenericRepository<StorageTank, int>
    {
        IQueryable GetStorageTanks();
        IQueryable GetStorageTankById(int id);
        IQueryable GetStorageTankByMilkCollectionId(int id);
        Task<bool> CheckCodeExistsAsync(string code);
        //IQueryable GetStorageTankByDate(int date, int month, int year, int session);
    }
}
