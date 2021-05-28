using ApplicationDomain.BOA.Models.MilkingSlips;
using ApplicationDomain.Dashboard.IRepositories;
using ApplicationDomain.Dashboard.IServices;
using ApplicationDomain.Dashboard.Models.MilkingSlips;
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
    public class DashboardMilkingSlipService : IDashboardMilkingSlipService
    {
        private readonly IDashboardMilkingSlipRepository _dashboardMilkingSlipRepository;

        public DashboardMilkingSlipService(IDashboardMilkingSlipRepository dashboardMilkingSlipRepository) 
        {
            _dashboardMilkingSlipRepository = dashboardMilkingSlipRepository;

        }

        public async Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoAsync(int from, int to)
        {
            try
            {
                return await _dashboardMilkingSlipRepository.GetDashboardMilkingSlipByDayfromtoAsync(from, to);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoCowIdAsync(int from, int to, int cowId)
        {
            try
            {
                return await _dashboardMilkingSlipRepository.GetDashboardMilkingSlipByDayfromtoCowIdAsync(from, to, cowId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(int from, int to, int farmerId)
        {
            try
            {
                return await _dashboardMilkingSlipRepository.GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(from,to,farmerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
