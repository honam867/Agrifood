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
    public class CowDashboardService : ICowDashboardService
    {
        private readonly ICowDashboardRepository _cowDashboardRepository;

        public CowDashboardService(ICowDashboardRepository cowDashboardRepository) 
        {
            _cowDashboardRepository = cowDashboardRepository;

        }

        public async Task<IEnumerable<CowDashboardModel>> GetCowDashboardAsync(int id)
        {
            try
            {
                return await _cowDashboardRepository.GetCowDashboardAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CowTotalModel>> GetCowTotalAsync(int id)
        {
            try
            {
                return await _cowDashboardRepository.GetCowTotalAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
