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

        public async Task<IEnumerable<CowDashboard>> GetCowDashboardAsync(int id)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_Thong_Ke_Bo {0}", id));
            IEnumerable<CowDashboard> results = IMapperExtentions.ConvertDataTable<CowDashboard>(dtResult).ToList();
            return results;
        }

        public async Task<IEnumerable<CowTotal>> GetCowTotalAsync(int id)
        {
            DataTable dtResult = await _sqlProvider.FromQueryAsync(string.Format("exec PR_Tong_Dan_Bo {0}", id));
            IEnumerable<CowTotal> results = IMapperExtentions.ConvertDataTable<CowTotal>(dtResult).ToList();
            return results;
        }
    }
}
