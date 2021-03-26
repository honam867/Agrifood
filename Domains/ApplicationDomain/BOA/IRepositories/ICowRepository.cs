using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface ICowRepository : IGenericRepository<Cow, int>
    {
        IQueryable GetCows();
        IQueryable GetCowById(int id);
        IQueryable GetCowByByreId(int byreId);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
