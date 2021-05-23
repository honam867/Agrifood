using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Farmers;
using ApplicationDomain.BOA.Models.MilkCouponDetails;
using ApplicationDomain.BOA.Models.MilkCoupons;
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
    public class MilkCouponService : ServiceBase, IMilkCouponService
    {
        private readonly IMilkCouponRepository _milkCouponRepository;
        private readonly IMilkCouponDetailRepository _milkCouponDetailRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public MilkCouponService(
            IMilkCouponRepository milkCouponRepository,
            IMilkCouponDetailRepository milkCouponDetailRepository,
            IEmployeeRepository employeeRepository,
            IBreedRepository breedRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _milkCouponRepository = milkCouponRepository;
            _milkCouponDetailRepository = milkCouponDetailRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<int> CreateMilkCouponAsync(MilkCouponModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<MilkCoupon>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.Status = 0;
                entity.CreateBy(issuer).UpdateBy(issuer);
                _milkCouponRepository.Create(entity);
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

        public async Task<bool> DeleteMilkCouponAsync(int id)
        {
            try
            {
                var milkcouponDetail = await _milkCouponDetailRepository.GetMilkcouponDetailByMilkcouponId(id).MapQueryTo<MilkCouponDetailModel>(_mapper).ToListAsync();
                var result = true;
                if (milkcouponDetail.Count() == 0)
                {
                    var entity = await _milkCouponRepository.GetEntityByIdAsync(id);

                    _milkCouponRepository.Delete(entity);
                    if (await _uow.SaveChangesAsync() == 1)
                    {
                        result = true;
                    }
                }else
                {
                    result = false;
                }
                
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<MilkCouponModel>> GetMilkCouponAsync()
        {
            return await _milkCouponRepository.GetMilkCoupons().MapQueryTo<MilkCouponModel>(_mapper).ToListAsync();
        }

        public async Task<MilkCouponModel> GetMilkCouponByIdAsync(int id)
        {
            return await _milkCouponRepository.GetMilkCouponById(id).MapQueryTo<MilkCouponModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMilkCouponAsync(int id, MilkCouponModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _milkCouponRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _milkCouponRepository.Update(entity);
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
            return await _milkCouponRepository.CheckCodeExistsAsync(code);
        }

        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateMilkCouponCode(3);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateMilkCouponCode(3));
        }

        public async Task<bool> UpdateStatusAsync(int id, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _milkCouponRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                entity.Status = 1;
                entity.UpdateBy(issuer);
                _milkCouponRepository.Update(entity);
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
    }
}