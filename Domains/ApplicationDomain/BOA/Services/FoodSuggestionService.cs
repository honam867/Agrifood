using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.FoodSuggestions;
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
    public class FoodSuggestionService : ServiceBase, IFoodSuggestionService
    {
        private readonly IFoodSuggestionRepository _foodSuggestionRepository;
        
        public FoodSuggestionService(
            IFoodSuggestionRepository foodSuggestionRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _foodSuggestionRepository = foodSuggestionRepository;
            
        }

        public async Task<int> CreateFoodSuggestionAsync(FoodSuggestionModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<FoodSuggestion>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.CreateBy(issuer).UpdateBy(issuer);
                _foodSuggestionRepository.Create(entity);
                return await _uow.SaveChangesAsync() == 1 ? entity.Id : 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteFoodSuggestionAsync(int id)
        {
            try
            {
                var entity = await _foodSuggestionRepository.GetEntityByIdAsync(id);
                _foodSuggestionRepository.Delete(entity);
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

        public async Task<IEnumerable<FoodSuggestionModel>> GetFoodSuggestionsAsync()
        {
            return await _foodSuggestionRepository.GetFoodSuggestions().MapQueryTo<FoodSuggestionModel>(_mapper).ToListAsync();
           
        }

        public async Task<FoodSuggestionModel> GetFoodSuggestionByIdAsync(int id)
        {
            return await _foodSuggestionRepository.GetFoodSuggestionById(id).MapQueryTo<FoodSuggestionModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateFoodSuggestionAsync(int id, FoodSuggestionModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _foodSuggestionRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _foodSuggestionRepository.Update(entity);
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

        public async Task<IEnumerable<FoodSuggestionModel>> GetFoodSuggestionsByFarmerIdAsync(UserIdentity<int> issuer)
        {
            return await _foodSuggestionRepository.GetFoodSuggestionByFarmerId(issuer.Id).MapQueryTo<FoodSuggestionModel>(_mapper).ToListAsync();
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await _foodSuggestionRepository.CheckCodeExistsAsync(code);
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