using ApplicationDomain.Dashboard.Models.Cows;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IRepositories
{
    public interface IDashboardCowRepository
    { 
        Task<IEnumerable<DashboardCowModel>> GetDashboardCowByFarmerIdAsync(int id);
        Task<IEnumerable<DashboardTotalCowModel>> GetDashboardTotalCowByFarmerIdAsync(int id);
        Task<IEnumerable<DashboardCowModel>> GetDashboardCowAsync();
        Task<IEnumerable<DashboardTotalCowModel>> GetDashboardTotalCowAsync();
    }
}
