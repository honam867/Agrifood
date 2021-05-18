using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkCouponDetails;
using ApplicationDomain.BOA.Models.MilkCoupons;
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
        private readonly IMilkCouponRepository _milkCouponRepository;
        private readonly IStorageTankRepository _storageTankRepository;
        public MilkCouponDetailService(
            IMilkCouponDetailRepository milkCouponDetailRepository,
            IMilkCouponRepository milkCouponRepository,
            IStorageTankRepository storageTankRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _milkCouponDetailRepository = milkCouponDetailRepository;
            _milkCouponRepository = milkCouponRepository;
            _storageTankRepository = storageTankRepository;
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
                    var milkcoupon = await _milkCouponRepository.GetMilkCouponById((int)entity.MilkCouponId).MapQueryTo<MilkCouponModel>(_mapper).FirstOrDefaultAsync();
                    var storageTank = await _storageTankRepository.GetEntityByIdAsync(milkcoupon.StorageTankId);
                    storageTank.Quantity += entity.Quantity;
                    _storageTankRepository.Update(storageTank);
                    await _uow.SaveChangesAsync();
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
                var milkcoupon = await _milkCouponRepository.GetMilkCouponById((int)entity.MilkCouponId).MapQueryTo<MilkCouponModel>(_mapper).FirstOrDefaultAsync();
                var storageTank = await _storageTankRepository.GetEntityByIdAsync(milkcoupon.StorageTankId);
                if (storageTank.Quantity > entity.Quantity)
                {
                    storageTank.Quantity -= entity.Quantity;
                }
                _storageTankRepository.Update(storageTank);
                await _uow.SaveChangesAsync();
                _milkCouponDetailRepository.Delete(entity);
                if (await _uow.SaveChangesAsync() > 0)
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

        public async Task<IEnumerable<MilkCouponDetailModel>> GetMilkcouponDetailByMilkcouponIdAsync(int id)
        {
            return await _milkCouponDetailRepository.GetMilkcouponDetailByMilkcouponId(id).MapQueryTo<MilkCouponDetailModel>(_mapper).ToListAsync();
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
                var milkcoupon = await _milkCouponRepository.GetMilkCouponById((int)entity.MilkCouponId).MapQueryTo<MilkCouponModel>(_mapper).FirstOrDefaultAsync();
                var storageTank = await _storageTankRepository.GetEntityByIdAsync(milkcoupon.StorageTankId);
                var quantityOld = storageTank.Quantity - entity.Quantity;
                storageTank.Quantity = quantityOld + model.Quantity;
                storageTank.UpdateBy(issuer);
                _storageTankRepository.Update(storageTank);
                await _uow.SaveChangesAsync();

                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _milkCouponDetailRepository.Update(entity);
                if (await _uow.SaveChangesAsync() >0)
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