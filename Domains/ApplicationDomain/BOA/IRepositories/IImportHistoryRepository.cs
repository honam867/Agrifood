using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IImportHistoryRepository : IGenericRepository<ImportHistory, int>
    {
        IQueryable GetImportHistorys();
        IQueryable GetImportHistoryById(int id);
        //Task<bool> CheckCodeExistsAsync(string code);
        //IQueryable GetImportHistoryByDate(int date, int month, int year, int session);
    }
}
