using ApplicationDomain.Dashboard.Models.Usings;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IServices
{
    public interface IDashboardUsingService
    {
        Task<IEnumerable<DashboardUsingModel>> GetDashboardUsingByDayfromtoAsync(int year);
        Task<IEnumerable<DashboardUsingModel>> GetDashboardUsingByDayfromtoFarmerIdAsync(int year, int farmerId);
    }
}
