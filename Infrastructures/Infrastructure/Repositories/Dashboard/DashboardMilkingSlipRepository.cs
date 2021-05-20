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
using ApplicationDomain.BOA.Models.MilkingSlips;
using Infrastructures;
using ApplicationDomain.Dashboard.IRepositories;
using ApplicationDomain.Dashboard.Models.MilkingSlips;

namespace Infrastructure.Repositories.Dashboard
{
    public class DashboardMilkingSlipRepository : IDashboardMilkingSlipRepository
    {
        private MSSQLProvider _sqlProvider;
        public DashboardMilkingSlipRepository()
        {
            _sqlProvider = new MSSQLProvider(EFConnectionString.Alias);
        }

        public async Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoAsync(int from, int to)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_MILKINGSLIP_BY_DAYFROMTO {0},{1}", from, to));
            IEnumerable<DashboardMilkingSlipModel> results = IMapperExtentions.ConvertDataTable<DashboardMilkingSlipModel>(dtResult).ToList();
            return results;
        }

        public async Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(int from, int to, int farmerId)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_MILKINGSLIP_BY_DAYFROMTO_FARMER {0},{1},{2}", from,to,farmerId));
            IEnumerable<DashboardMilkingSlipModel> results = IMapperExtentions.ConvertDataTable<DashboardMilkingSlipModel>(dtResult).ToList();
            return results;
        }
    }
}
