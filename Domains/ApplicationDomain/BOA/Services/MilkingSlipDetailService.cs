using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkingSlipDetails;
using ApplicationDomain.BOA.Models.MilkingSlips;
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
    public class MilkingSlipDetailService : ServiceBase, IMilkingSlipDetailService
    {
        private readonly IMilkingSlipDetailRepository _milkingSlipDetailRepository;

        public MilkingSlipDetailService(
            IMilkingSlipDetailRepository milkingSlipDetailRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _milkingSlipDetailRepository = milkingSlipDetailRepository;
        
        }

        public async Task<int> CreateMilkingSlipDetailAsync(MilkingSlipDetailModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<MilkingSlipDetail>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _milkingSlipDetailRepository.Create(entity);
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

        public async Task<bool> DeleteMilkingSlipDetailAsync(int id)
        {
            try
            {
                var entity = await _milkingSlipDetailRepository.GetEntityByIdAsync(id);
                _milkingSlipDetailRepository.Delete(entity);
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

        public async Task<IEnumerable<MilkingSlipDetailModel>> GetMilkingSlipDetailAsync()
        {
            return await _milkingSlipDetailRepository.GetMilkingSlipDetails().MapQueryTo<MilkingSlipDetailModel>(_mapper).ToListAsync();
           
        }

        public async Task<MilkingSlipDetailModel> GetMilkingSlipDetailByIdAsync(int id)
        {
            return await _milkingSlipDetailRepository.GetMilkingSlipDetailById(id).MapQueryTo<MilkingSlipDetailModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MilkingSlipDetailModel>> GetMilkingSlipDetailByMilkingSlipIdAsync(int id)
        {
            return await _milkingSlipDetailRepository.GetMilkingSlipDetailByMilkingSlipId(id).MapQueryTo<MilkingSlipDetailModel>(_mapper).ToListAsync();
        }

        public async Task<bool> UpdateMilkingSlipDetailAsync(int id, MilkingSlipDetailModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _milkingSlipDetailRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _milkingSlipDetailRepository.Update(entity);
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

        //public async Task<bool> CheckCodeExistsAsync(string code)
        //{
        //    return await _milkingSlipRepository.CheckCodeExistsAsync(code);
        //}
    }
}