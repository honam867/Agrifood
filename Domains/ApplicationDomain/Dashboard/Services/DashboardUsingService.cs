using ApplicationDomain.Dashboard.IRepositories;
using ApplicationDomain.Dashboard.IServices;
using ApplicationDomain.Dashboard.Models.Usings;
using AspNetCore.Common.Identity;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.Services
{
    public class DashboardUsingService : IDashboardUsingService
    {
        private readonly IDashboardUsingRepository _dashboardUsingRepository;

        public DashboardUsingService(IDashboardUsingRepository dashboardUsingRepository) 
        {
            _dashboardUsingRepository = dashboardUsingRepository;

        }

        public async Task<IEnumerable<DashboardUsingModel>> GetDashboardUsingByDayfromtoAsync(int from, int to)
        {
            try
            {
                return await _dashboardUsingRepository.GetDashboardUsingByDayfromtoAsync(from, to);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardUsingModel>> GetDashboardUsingByDayfromtoFarmerIdAsync(int from, int to, int farmerId)
        {
            try
            {
                return await _dashboardUsingRepository.GetDashboardUsingByDayfromtoFarmerIdAsync(from,to,farmerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
