using ApplicationDomain.Dashboard.Models.MilkingSlips;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IServices
{
    public interface IDashboardMilkingSlipService
    {
        Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoAsync(int from, int to);
        Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(int from, int to, int farmerId);
    }
}
