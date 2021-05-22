using ApplicationDomain.BOA.Models.Cows;
using ApplicationDomain.Dashboard.IRepositories;
using ApplicationDomain.Dashboard.IServices;
using ApplicationDomain.Dashboard.Models.Cows;
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
    public class DashboardCowService : IDashboardCowService
    {
        private readonly IDashboardCowRepository _cowDashboardRepository;

        public DashboardCowService(IDashboardCowRepository cowDashboardRepository) 
        {
            _cowDashboardRepository = cowDashboardRepository;

        }

        public async Task<IEnumerable<DashboardCowModel>> GetDashboardCowAsync()
        {
            try
            {
                return await _cowDashboardRepository.GetDashboardCowAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardCowModel>> GetDashboardCowByFarmerIdAsync(int id)
        {
            try
            {
                return await _cowDashboardRepository.GetDashboardCowByFarmerIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardTotalCowModel>> GetDashboardTotalCowAsync()
        {
            try
            {
                return await _cowDashboardRepository.GetDashboardTotalCowAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardTotalCowModel>> GetDashboardTotalCowByFarmerIdAsync(int id)
        {
            try
            {
                return await _cowDashboardRepository.GetDashboardTotalCowByFarmerIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
