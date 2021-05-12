using ApplicationDomain.Dashboard.Models.Cows;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IRepositories
{
    public interface ICowDashboardRepository
    { 
        Task<IEnumerable<CowDashboardModel>> GetCowDashboardAsync(int id);
        Task<IEnumerable<CowTotalModel>> GetCowTotalAsync(int id);
    }
}
