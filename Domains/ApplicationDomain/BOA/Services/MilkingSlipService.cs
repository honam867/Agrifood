using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkingSlips;
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
    public class MilkingSlipService : ServiceBase, IMilkingSlipService
    {
        private readonly IMilkingSlipRepository _milkingSlipRepository;

        public MilkingSlipService(
            IMilkingSlipRepository milkingSlipRepository,
            IBreedRepository breedRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _milkingSlipRepository = milkingSlipRepository;
        
        }

        public async Task<int> CreateMilkingSlipAsync(MilkingSlipModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var code = await AutoGenerateCodeAsync();
                model.Code = code;
                var entity = _mapper.Map<MilkingSlip>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _milkingSlipRepository.Create(entity);
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

        public async Task<bool> DeleteMilkingSlipAsync(int id)
        {
            try
            {
                var entity = await _milkingSlipRepository.GetEntityByIdAsync(id);
                _milkingSlipRepository.Delete(entity);
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

        public async Task<IEnumerable<MilkingSlipModel>> GetMilkingSlipAsync()
        {
            return await _milkingSlipRepository.GetMilkingSlips().MapQueryTo<MilkingSlipModel>(_mapper).ToListAsync();
           
        }

        public async Task<MilkingSlipModel> GetMilkingSlipByIdAsync(int id)
        {
            return await _milkingSlipRepository.GetMilkingSlipById(id).MapQueryTo<MilkingSlipModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMilkingSlipAsync(int id, MilkingSlipModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _milkingSlipRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _milkingSlipRepository.Update(entity);
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
            return await _milkingSlipRepository.CheckCodeExistsAsync(code);
        }

        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateMilkingSlipCode(3);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateMilkingSlipCode(3));
        }
    }
}