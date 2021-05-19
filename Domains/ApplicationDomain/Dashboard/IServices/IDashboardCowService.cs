using ApplicationDomain.BOA.Models.Cows;
using ApplicationDomain.Dashboard.Models.Cows;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IServices
{
    public interface IDashboardCowService
    {
        Task<IEnumerable<DashboardCowModel>> GetDashboardCowByFarmerIdAsync(int id);
        Task<IEnumerable<DashboardTotalCowModel>> GetDashboardTotalCowByFarmerIdAsync(int id);
        Task<IEnumerable<DashboardCowModel>> GetDashboardCowAsync();
        Task<IEnumerable<DashboardTotalCowModel>> GetDashboardTotalCowAsync();

    }
}
