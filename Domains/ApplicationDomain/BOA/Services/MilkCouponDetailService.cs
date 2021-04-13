using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkCouponDetails;
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
    public class MilkCouponDetailService : ServiceBase, IMilkCouponDetailService
    {
        private readonly IMilkCouponDetailRepository _milkCouponDetailRepository;

        public MilkCouponDetailService(
            IMilkCouponDetailRepository milkCouponDetailRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _milkCouponDetailRepository = milkCouponDetailRepository;
        
        }

        public async Task<int> CreateMilkCouponDetailAsync(MilkCouponDetailModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<MilkCouponDetail>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _milkCouponDetailRepository.Create(entity);
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

        public async Task<bool> DeleteMilkCouponDetailAsync(int id)
        {
            try
            {
                var entity = await _milkCouponDetailRepository.GetEntityByIdAsync(id);
                _milkCouponDetailRepository.Delete(entity);
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

        public async Task<IEnumerable<MilkCouponDetailModel>> GetMilkCouponDetailAsync()
        {
            return await _milkCouponDetailRepository.GetMilkCouponDetails().MapQueryTo<MilkCouponDetailModel>(_mapper).ToListAsync();
           
        }

        public async Task<MilkCouponDetailModel> GetMilkCouponDetailByIdAsync(int id)
        {
            return await _milkCouponDetailRepository.GetMilkCouponDetailById(id).MapQueryTo<MilkCouponDetailModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<MilkCouponDetailModel> GetMilkcouponDetailByMilkcouponIdAsync(int id, UserIdentity<int> issuer)
        {
            return await _milkCouponDetailRepository.GetMilkcouponDetailByMilkcouponId(id, issuer.Id).MapQueryTo<MilkCouponDetailModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMilkCouponDetailAsync(int id, MilkCouponDetailModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _milkCouponDetailRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _milkCouponDetailRepository.Update(entity);
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