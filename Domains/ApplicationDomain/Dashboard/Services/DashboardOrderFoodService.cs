using ApplicationDomain.Dashboard.IRepositories;
using ApplicationDomain.Dashboard.IServices;
using ApplicationDomain.Dashboard.Models.OrderFoods;
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
    public class DashboardOrderFoodService : IDashboardOrderFoodService
    {
        private readonly IDashboardOrderFoodRepository _dashboardOrderFoodRepository;

        public DashboardOrderFoodService(IDashboardOrderFoodRepository dashboardOrderFoodRepository) 
        {
            _dashboardOrderFoodRepository = dashboardOrderFoodRepository;

        }

        public async Task<IEnumerable<DashboardOrderFoodModel>> GetDashboardOrderFoodByDayfromtoAsync(int from, int to)
        {
            try
            {
                return await _dashboardOrderFoodRepository.GetDashboardOrderFoodByDayfromtoAsync(from, to);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardOrderFoodModel>> GetDashboardOrderFoodByDayfromtoFarmerIdAsync(int from, int to, int farmerId)
        {
            try
            {
                return await _dashboardOrderFoodRepository.GetDashboardOrderFoodByDayfromtoFarmerIdAsync(from,to,farmerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
