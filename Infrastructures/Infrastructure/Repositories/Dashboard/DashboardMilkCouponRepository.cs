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
using ApplicationDomain.BOA.Models.MilkCoupons;
using Infrastructures;
using ApplicationDomain.Dashboard.IRepositories;
using ApplicationDomain.Dashboard.Models.MilkCoupons;

namespace Infrastructure.Repositories.Dashboard
{
    public class DashboardMilkCouponRepository : IDashboardMilkCouponRepository
    {
        private MSSQLProvider _sqlProvider;
        public DashboardMilkCouponRepository()
        {
            _sqlProvider = new MSSQLProvider(EFConnectionString.Alias);
        }

        public async Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoAsync(int from, int to)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_MILKCOUPON_BY_DAYFROMTO {0},{1}", from, to));
            IEnumerable<DashboardMilkCouponModel> results = IMapperExtentions.ConvertDataTable<DashboardMilkCouponModel>(dtResult).ToList();
            return results;
        }

        public async Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoFarmerIdAsync(int from, int to, int farmerId)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_DASHBOARD_MILKCOUPON_BY_DAYFROMTO_FARMER {0},{1},{2}", from,to,farmerId));
            IEnumerable<DashboardMilkCouponModel> results = IMapperExtentions.ConvertDataTable<DashboardMilkCouponModel>(dtResult).ToList();
            return results;
        }
    }
}
