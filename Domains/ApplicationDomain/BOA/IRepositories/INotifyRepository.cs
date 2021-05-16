using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface INotifyRepository : IGenericRepository<Notify, int>
    {
        IQueryable GetNotifys();
        IQueryable GetNotifyById(int id);
        Task<bool> CheckCodeExistsAsync(string code);
        IQueryable GetNotifyByFarmerId(int id);
        IQueryable GetNotifyByEmployeeId(int id);

    }
}
