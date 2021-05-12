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
    public class MilkingSlipDashboardRepository : IMilkingSlipDashboardRepository
    {
        private MSSQLProvider _sqlProvider;
        public MilkingSlipDashboardRepository()
        {
            _sqlProvider = new MSSQLProvider(EFConnectionString.Alias);
        }

        public async Task<IEnumerable<MilkingSlipDashboardModel>> GetMilkingSlipDashboardAsync(int month, int year, int farmerId)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_MILKINGSLIP_MONTH {0},{1},{2}", month,year,farmerId));
            IEnumerable<MilkingSlipDashboardModel> results = IMapperExtentions.ConvertDataTable<MilkingSlipDashboardModel>(dtResult).ToList();
            return results;
        }
    }
}
