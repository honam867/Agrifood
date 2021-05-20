using ApplicationDomain.Dashboard.Models.OrderFoods;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IServices
{
    public interface IDashboardOrderFoodService
    {
        Task<IEnumerable<DashboardOrderFoodModel>> GetDashboardOrderFoodByDayfromtoAsync(int from, int to);
        Task<IEnumerable<DashboardOrderFoodModel>> GetDashboardOrderFoodByDayfromtoFarmerIdAsync(int from, int to, int farmerId);
    }
}
