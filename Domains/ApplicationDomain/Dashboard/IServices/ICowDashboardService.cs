using ApplicationDomain.BOA.Models.Cows;
using ApplicationDomain.Dashboard.Models.Cows;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IServices
{
    public interface ICowDashboardService
    {
        Task<IEnumerable<CowDashboard>> GetCowDashboardAsync(int id);
        Task<IEnumerable<CowTotal>> GetCowTotalAsync(int id);

    }
}
