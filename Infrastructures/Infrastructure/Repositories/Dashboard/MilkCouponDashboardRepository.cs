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
    public class MilkCouponDashboardRepository : IMilkCouponDashboardRepository
    {
        private MSSQLProvider _sqlProvider;
        public MilkCouponDashboardRepository()
        {
            _sqlProvider = new MSSQLProvider(EFConnectionString.Alias);
        }

        public async Task<IEnumerable<MilkCouponDashboardModel>> GetMilkCouponDashboardAsync(int month, int year, int farmerId)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_MILKCOUPON_MONTH {0},{1},{2}", month,year,farmerId));
            IEnumerable<MilkCouponDashboardModel> results = IMapperExtentions.ConvertDataTable<MilkCouponDashboardModel>(dtResult).ToList();
            return results;
        }
    }
}
