using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.FeedHistoryDetails;
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
    public class FeedHistoryDetailService : ServiceBase, IFeedHistoryDetailService
    {
        private readonly IFeedHistoryDetailRepository _feedHistoryDetailRepository;
        
        public FeedHistoryDetailService(
            IFeedHistoryDetailRepository feedHistoryDetailRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _feedHistoryDetailRepository = feedHistoryDetailRepository;
            
        }

        public async Task<int> CreateFeedHistoryDetailAsync(FeedHistoryDetailModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<FeedHistoryDetail>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.CreateBy(issuer).UpdateBy(issuer);
                _feedHistoryDetailRepository.Create(entity);
                return await _uow.SaveChangesAsync() == 1 ? entity.Id : 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteFeedHistoryDetailAsync(int id)
        {
            try
            {
                var entity = await _feedHistoryDetailRepository.GetEntityByIdAsync(id);
                _feedHistoryDetailRepository.Delete(entity);
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

        public async Task<IEnumerable<FeedHistoryDetailModel>> GetFeedHistoryDetailsAsync()
        {
            return await _feedHistoryDetailRepository.GetFeedHistoryDetails().MapQueryTo<FeedHistoryDetailModel>(_mapper).ToListAsync();
           
        }

        public async Task<FeedHistoryDetailModel> GetFeedHistoryDetailByIdAsync(int id)
        {
            return await _feedHistoryDetailRepository.GetFeedHistoryDetailById(id).MapQueryTo<FeedHistoryDetailModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateFeedHistoryDetailAsync(int id, FeedHistoryDetailModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _feedHistoryDetailRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _feedHistoryDetailRepository.Update(entity);
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
            return await _feedHistoryDetailRepository.CheckCodeExistsAsync(code);
        }

        public async Task<IEnumerable<FeedHistoryDetailModel>> GetFeedHistoryDetailByFeedHistoryIdAsync(int id)
        {
            return await _feedHistoryDetailRepository.GetFeedHistoryDetailByFeedHistoryId(id).MapQueryTo<FeedHistoryDetailModel>(_mapper).ToListAsync();
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