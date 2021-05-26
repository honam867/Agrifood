using ApplicationDomain.Dashboard.Models.Usings;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IRepositories
{
    public interface IDashboardUsingRepository
    {
        Task<IEnumerable<DashboardUsingModel>> GetDashboardUsingByDayfromtoAsync(int year);
        Task<IEnumerable<DashboardUsingModel>> GetDashboardUsingByDayfromtoFarmerIdAsync(int year, int farmerId);
    }
}
