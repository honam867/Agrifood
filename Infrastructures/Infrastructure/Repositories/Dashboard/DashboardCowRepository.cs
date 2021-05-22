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
using ApplicationDomain.BOA.Models.Cows;
using Infrastructures;
using ApplicationDomain.Dashboard.IRepositories;
using ApplicationDomain.Dashboard.Models.Cows;

namespace Infrastructure.Repositories.Dashboard
{
    public class DashboardCowRepository : IDashboardCowRepository
    {
        private MSSQLProvider _sqlProvider;
        public DashboardCowRepository()
        {
            _sqlProvider = new MSSQLProvider(EFConnectionString.Alias);
        }

        public async Task<IEnumerable<DashboardCowModel>> GetDashboardCowAsync()
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_COW"));
            IEnumerable<DashboardCowModel> results = IMapperExtentions.ConvertDataTable<DashboardCowModel>(dtResult).ToList();
            return results;
        }

        public async Task<IEnumerable<DashboardCowModel>> GetDashboardCowByFarmerIdAsync(int id)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_COW_BY_FARMER {0}", id));
            IEnumerable<DashboardCowModel> results = IMapperExtentions.ConvertDataTable<DashboardCowModel>(dtResult).ToList();
            return results;
        }

        public async Task<IEnumerable<DashboardTotalCowModel>> GetDashboardTotalCowAsync()
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_TOTALCOW"));
            IEnumerable<DashboardTotalCowModel> results = IMapperExtentions.ConvertDataTable<DashboardTotalCowModel>(dtResult).ToList();
            return results;
        }

        public async Task<IEnumerable<DashboardTotalCowModel>> GetDashboardTotalCowByFarmerIdAsync(int id)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_TOTALCOW_BY_FARMER {0}", id));
            IEnumerable<DashboardTotalCowModel> results = IMapperExtentions.ConvertDataTable<DashboardTotalCowModel>(dtResult).ToList();
            return results;
        }
    }
}
