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
        private readonly IDashboardMilkingSlipRepository _milkingSlipDashboardRepository;

        public DashboardMilkingSlipService(IDashboardMilkingSlipRepository milkingSlipDashboardRepository) 
        {
            _milkingSlipDashboardRepository = milkingSlipDashboardRepository;

        }

        public async Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoAsync(DateTime dayFrom, DateTime dayTo)
        {
            try
            {
                return await _milkingSlipDashboardRepository.GetDashboardMilkingSlipByDayfromtoAsync(dayFrom, dayTo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardMilkingSlipModel>> GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(DateTime dayFrom, DateTime dayTo, int farmerId)
        {
            try
            {
                return await _milkingSlipDashboardRepository.GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(dayFrom,dayTo,farmerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
