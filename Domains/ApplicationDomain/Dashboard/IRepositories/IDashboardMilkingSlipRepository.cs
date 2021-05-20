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
        Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoAsync(int from, int to);
        Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(int from, int to, int farmerId);
    }
}
