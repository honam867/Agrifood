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
    public class MilkingSlipDashboardService : IMilkingSlipDashboardService
    {
        private readonly IMilkingSlipDashboardRepository _milkingSlipDashboardRepository;

        public MilkingSlipDashboardService(IMilkingSlipDashboardRepository milkingSlipDashboardRepository) 
        {
            _milkingSlipDashboardRepository = milkingSlipDashboardRepository;

        }

        public async Task<IEnumerable<MilkingSlipDashboardModel>> GetMilkingSlipDashboardAsync(int month, int year, int farmerId)
        {
            try
            {
                return await _milkingSlipDashboardRepository.GetMilkingSlipDashboardAsync(month,year,farmerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
