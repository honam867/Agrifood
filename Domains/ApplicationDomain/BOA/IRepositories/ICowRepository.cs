using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.Models.Cows;
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
        IQueryable GetCowsByFarmerId(int userId);
        IQueryable GetCowByByreId(int byreId);
        Task<bool> CheckCodeExistsAsync(string code);
        IQueryable GetCowNotExitsByMilkingSlipId(int milkingSlipId, int farmerId);
        IQueryable GetCowByGender(int gd, int userId);
    }
}
