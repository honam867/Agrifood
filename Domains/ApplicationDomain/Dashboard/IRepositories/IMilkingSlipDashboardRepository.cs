using ApplicationDomain.Dashboard.Models.MilkingSlips;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IRepositories
{
    public interface IMilkingSlipDashboardRepository
    { 
        Task<IEnumerable<MilkingSlipDashboardModel>> GetMilkingSlipDashboardAsync(int month, int year, int farmerId);
    }
}
