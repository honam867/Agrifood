using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.FeedHistorys;
using AspNetCore.AutoGenerate;
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
    public class FeedHistoryService : ServiceBase, IFeedHistoryService
    {
        private readonly IFeedHistoryRepository _feedHistoryRepository;
        
        public FeedHistoryService(
            IFeedHistoryRepository feedHistoryRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _feedHistoryRepository = feedHistoryRepository;
            
        }

        public async Task<int> CreateFeedHistoryAsync(FeedHistoryModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<FeedHistory>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.CreateBy(issuer).UpdateBy(issuer);
                _feedHistoryRepository.Create(entity);
                return await _uow.SaveChangesAsync() == 1 ? entity.Id : 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteFeedHistoryAsync(int id)
        {
            try
            {
                var entity = await _feedHistoryRepository.GetEntityByIdAsync(id);
                _feedHistoryRepository.Delete(entity);
                if (await _uow.SaveChangesAsync() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<FeedHistoryModel>> GetFeedHistorysAsync()
        {
            return await _feedHistoryRepository.GetFeedHistorys().MapQueryTo<FeedHistoryModel>(_mapper).ToListAsync();
           
        }

        public async Task<FeedHistoryModel> GetFeedHistoryByIdAsync(int id)
        {
            return await _feedHistoryRepository.GetFeedHistoryById(id).MapQueryTo<FeedHistoryModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateFeedHistoryAsync(int id, FeedHistoryModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _feedHistoryRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _feedHistoryRepository.Update(entity);
                if (await _uow.SaveChangesAsync() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await _feedHistoryRepository.CheckCodeExistsAsync(code);
        }

        public async Task<IEnumerable<FeedHistoryByreModel>> GetFeedHistoryByFarmerIdAsync(int id)
        {
            return await _feedHistoryRepository.GetFeedHistoryByFarmerId(id);
        }

        public async Task<IEnumerable<FeedHistoryModel>> GetFeedHistoryByDateAsync(int day, int month, int year, int farmerId)
        {
            return await _feedHistoryRepository.GetFeedHistoryByDate(day,month,year,farmerId).MapQueryTo<FeedHistoryModel>(_mapper).ToListAsync();
        }

        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateCode(10);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateCode(10));
        }
    }
}