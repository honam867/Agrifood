using ApplicationDomain.Dashboard.Models.OrderFoods;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IRepositories
{
    public interface IDashboardOrderFoodRepository
    {
        Task<IEnumerable<DashboardOrderFoodModel>> GetDashboardOrderFoodByDayfromtoAsync(int from, int to);
        Task<IEnumerable<DashboardOrderFoodModel>> GetDashboardOrderFoodByDayfromtoFarmerIdAsync(int from, int to, int farmerId);
    }
}
