using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models.Farmers;
using AspNetCore.AutoGenerate;
using AspNetCore.Common.Identity;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.CMMS.Services
{
    public class FarmerService : ServiceBase, IFarmerService
    {
        private readonly IFarmerRepository _FarmerRepository;
        public FarmerService(
            IFarmerRepository FarmerRepository,
            IMapper mapper,
            IUnitOfWork uow) : base(mapper, uow)
        {
            _FarmerRepository = FarmerRepository;
        }

        public async Task<IEnumerable<FarmerModel>> GetFarmerListAsync()
        {
            return await _FarmerRepository.GetFarmers().MapQueryTo<FarmerModel>(_mapper).ToListAsync();
        }

        public async Task<FarmerModel> GetFarmerByIdAsync(int id)
        {
            return await _FarmerRepository.GetFarmerById(id).MapQueryTo<FarmerModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<int> CreateFarmerAsync(FarmerModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Farmer>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _FarmerRepository.Create(entity);
                if (await _uow.SaveChangesAsync() == 1)
                {
                    return entity.Id;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateCode(3);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateCode(3));
        }

        public async Task<bool> UpdateFarmerAsync(int id, FarmerModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Farmer>(model);
                entity = await _FarmerRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _FarmerRepository.Update(entity);
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

        public async Task<bool> DeleteFarmerAsync(int id)
        {
            try
            {
                var entity = await _FarmerRepository.GetEntityByIdAsync(id);
                _FarmerRepository.Delete(entity);
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
            return await _FarmerRepository.CheckCodeExistsAsync(code);
        }

        //public async Task<IEnumerable<FarmerModel>> GetFarmerByProvinceIdAndDistrictId(int provinceId, int districtId)
        //{
        //    try
        //    {
        //        return await _FarmerRepository.GetFarmerByProvinceIdAndDistrictId(provinceId, districtId).MapQueryTo<FarmerModel>(_mapper).ToListAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public async Task<FarmerModel> GetFarmerByUserIdAsync(int id)
        {
            return await _FarmerRepository.GetFarmerByUser(id).MapQueryTo<FarmerModel>(_mapper).FirstOrDefaultAsync();
        }
    }
}
