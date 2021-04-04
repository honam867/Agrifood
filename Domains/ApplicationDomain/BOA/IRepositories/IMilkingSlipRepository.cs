using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IMilkingSlipRepository : IGenericRepository<MilkingSlip, int>
    {
        IQueryable GetMilkingSlips();
        IQueryable GetMilkingSlipById(int id);
        Task<bool> CheckCodeExistsAsync(string code);
        IQueryable GetMilkingSlipByDate(int date, int month, int year, int session);
    }
}
