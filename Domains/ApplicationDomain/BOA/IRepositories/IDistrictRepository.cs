using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IDistrictRepository : IGenericRepository<District, int>
    {
        IQueryable GetDistricts();
        IQueryable GetDistrictById(int id);
        IQueryable GetDistricByPrivinceId(int id);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
