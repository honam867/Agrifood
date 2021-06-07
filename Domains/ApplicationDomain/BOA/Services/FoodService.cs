using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Foods;
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
    public class FoodService : ServiceBase, IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IFoodSuggestionService _foodSuggestionService;
        
        public FoodService(
            IFoodRepository foodRepository,
            IFoodSuggestionService foodSuggestionService,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _foodRepository = foodRepository;
            _foodSuggestionService = foodSuggestionService;
        }

        public async Task<int> CreateFoodAsync(FoodModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Food>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.CreateBy(issuer).UpdateBy(issuer);
                _foodRepository.Create(entity);
                if (await _uow.SaveChangesAsync() > 0)
                {
                    FoodSuggestionModelRq rq = new FoodSuggestionModelRq
                    {
                        Content = entity.Name,
                        FoodId = entity.Id
                    };
                    await _foodSuggestionService.CreateFoodSuggestionAsync(rq, issuer);
                    return entity.Id;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteFoodAsync(int id)
        {
            try
            {
                var entity = await _foodRepository.GetEntityByIdAsync(id);
                await _foodSuggestionService.DeleteFoodSuggestionAsync(id);
                _foodRepository.Delete(entity);
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

        public async Task<IEnumerable<FoodModel>> GetFoodsAsync()
        {
            return await _foodRepository.GetFoods().MapQueryTo<FoodModel>(_mapper).ToListAsync();
           
        }

        public async Task<FoodModel> GetFoodByIdAsync(int id)
        {
            return await _foodRepository.GetFoodById(id).MapQueryTo<FoodModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateFoodAsync(int id, FoodModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _foodRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _foodRepository.Update(entity);
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
            return await _foodRepository.CheckCodeExistsAsync(code);
        }

        public async Task<IEnumerable<FoodModel>> GetFoodByProvinceAsync(UserIdentity<int> issuer)
        {
            return await _foodRepository.GetFoodByProvince(issuer.Id).MapQueryTo<FoodModel>(_mapper).ToListAsync();
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