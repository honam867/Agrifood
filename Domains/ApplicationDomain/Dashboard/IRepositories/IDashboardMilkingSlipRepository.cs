using ApplicationDomain.Dashboard.Models.MilkingSlips;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IRepositories
{
    public interface IDashboardMilkingSlipRepository
    { 
        Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(DateTime dayFrom, DateTime dayTo, int farmerId);
        Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoAsync(DateTime dayFrom, DateTime dayTo);
    }
}
