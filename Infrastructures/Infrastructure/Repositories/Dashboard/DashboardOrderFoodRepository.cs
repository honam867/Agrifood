using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSQL;
using System.Data;
using AspNetCore.DataBinding.AutoMapper;
using Infrastructures;
using ApplicationDomain.Dashboard.IRepositories;
using ApplicationDomain.Dashboard.Models.OrderFoods;

namespace Infrastructure.Repositories.Dashboard
{
    public class DashboardOrderFoodRepository : IDashboardOrderFoodRepository
    {
        private MSSQLProvider _sqlProvider;
        public DashboardOrderFoodRepository()
        {
            _sqlProvider = new MSSQLProvider(EFConnectionString.Alias);
        }

        public async Task<IEnumerable<DashboardOrderFoodModel>> GetDashboardOrderFoodByDayfromtoAsync(int from, int to)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_ORDER_FOOD_BY_DAYFROMTO {0},{1}", from, to));
            IEnumerable<DashboardOrderFoodModel> results = IMapperExtentions.ConvertDataTable<DashboardOrderFoodModel>(dtResult).ToList();
            return results;
        }

        public async Task<IEnumerable<DashboardOrderFoodModel>> GetDashboardOrderFoodByDayfromtoFarmerIdAsync(int from, int to, int farmerId)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_ORDER_FOOD_BY_DAYFROMTO_FARMERID {0},{1},{2}", from,to,farmerId));
            IEnumerable<DashboardOrderFoodModel> results = IMapperExtentions.ConvertDataTable<DashboardOrderFoodModel>(dtResult).ToList();
            return results;
        }
    }
}
