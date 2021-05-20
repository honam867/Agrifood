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
using ApplicationDomain.Dashboard.Models.Usings;

namespace Infrastructure.Repositories.Dashboard
{
    public class DashboardUsingRepository : IDashboardUsingRepository
    {
        private MSSQLProvider _sqlProvider;
        public DashboardUsingRepository()
        {
            _sqlProvider = new MSSQLProvider(EFConnectionString.Alias);
        }

        public async Task<IEnumerable<DashboardUsingModel>> GetDashboardUsingByDayfromtoAsync(int from, int to)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_USING_BY_DAYFROMTO {0},{1}", from, to));
            IEnumerable<DashboardUsingModel> results = IMapperExtentions.ConvertDataTable<DashboardUsingModel>(dtResult).ToList();
            return results;
        }

        public async Task<IEnumerable<DashboardUsingModel>> GetDashboardUsingByDayfromtoFarmerIdAsync(int from, int to, int farmerId)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_USING_BY_DAYFROMTO_FARMER {0},{1},{2}", from,to,farmerId));
            IEnumerable<DashboardUsingModel> results = IMapperExtentions.ConvertDataTable<DashboardUsingModel>(dtResult).ToList();
            return results;
        }
    }
}
