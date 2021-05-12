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
    public class CowDashboardRepository : ICowDashboardRepository
    {
        private MSSQLProvider _sqlProvider;
        public CowDashboardRepository()
        {
            _sqlProvider = new MSSQLProvider(EFConnectionString.Alias);
        }

        public async Task<IEnumerable<CowDashboardModel>> GetCowDashboardAsync(int id)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_Thong_Ke_Bo {0}", id));
            IEnumerable<CowDashboardModel> results = IMapperExtentions.ConvertDataTable<CowDashboardModel>(dtResult).ToList();
            return results;
        }

        public async Task<IEnumerable<CowTotalModel>> GetCowTotalAsync(int id)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_Tong_Dan_Bo {0}", id));
            IEnumerable<CowTotalModel> results = IMapperExtentions.ConvertDataTable<CowTotalModel>(dtResult).ToList();
            return results;
        }
    }
}
