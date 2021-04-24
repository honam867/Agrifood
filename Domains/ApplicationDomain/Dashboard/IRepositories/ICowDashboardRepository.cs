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
        Task<IEnumerable<CowDashboard>> GetCowDashboardAsync(int id);
        Task<IEnumerable<CowTotal>> GetCowTotalAsync(int id);
    }
}
