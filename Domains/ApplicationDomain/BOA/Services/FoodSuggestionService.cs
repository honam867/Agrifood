using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.FoodSuggestions;
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
        private readonly IFoodSuggestionRepository _breedRepository;
        
        public FoodSuggestionService(
            IFoodSuggestionRepository breedRepository,
            ICompanyRepository companyRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _breedRepository = breedRepository;
            
        }

        public async Task<int> CreateFoodSuggestionAsync(FoodSuggestionModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<FoodSuggestion>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _breedRepository.Create(entity);
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
                var entity = await _breedRepository.GetEntityByIdAsync(id);
                _breedRepository.Delete(entity);
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
            return await _breedRepository.GetFoodSuggestions().MapQueryTo<FoodSuggestionModel>(_mapper).ToListAsync();
           
        }

        public async Task<FoodSuggestionModel> GetFoodSuggestionByIdAsync(int id)
        {
            return await _breedRepository.GetFoodSuggestionById(id).MapQueryTo<FoodSuggestionModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateFoodSuggestionAsync(int id, FoodSuggestionModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _breedRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _breedRepository.Update(entity);
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

        /*public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await _breedRepository.CheckCodeExistsAsync(code);
        }*/
    }
}