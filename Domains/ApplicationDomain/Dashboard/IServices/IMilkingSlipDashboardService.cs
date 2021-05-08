using ApplicationDomain.Dashboard.Models.MilkingSlips;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IServices
{
    public interface IMilkingSlipDashboardService
    {
        Task<IEnumerable<MilkingSlipDashboardModel>> GetMilkingSlipDashboardAsync(int month, int year, int farmerId);
    }
}
