using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IFarmerRepository : IGenericRepository<Farmer, int>
    {
        Task<bool> CheckCodeExistsAsync(string code);
        IQueryable GetFarmers();
        IQueryable GetFarmerById(int id);
        Task<string> GetCodeByIdAsync(int id);
        IQueryable GetFarmerByUser(int id);
    }
}
