using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkCollectionStations;
using ApplicationDomain.BOA.Models.MilkCoupons;
using ApplicationDomain.BOA.Models.StorageTanks;
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
    public class MilkCollectionStationService : ServiceBase, IMilkCollectionStationService
    {
        private readonly IMilkCollectionStationRepository _milkCollectionStationRepository;
        private readonly IStorageTankRepository _storageTankRepository;
        private readonly IMilkCouponRepository _milkCouponRepository;
        public MilkCollectionStationService(
            IMilkCollectionStationRepository milkCollectionStationRepository,
            IStorageTankRepository storageTankRepository,
            IMilkCouponRepository milkCouponRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _milkCollectionStationRepository = milkCollectionStationRepository;
            _storageTankRepository = storageTankRepository;
            _milkCouponRepository = milkCouponRepository;
        }

        public async Task<int> CreateMilkCollectionStationAsync(MilkCollectionStationModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<MilkCollectionStation>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.CreateBy(issuer).UpdateBy(issuer);
                _milkCollectionStationRepository.Create(entity);

                if (await _uow.SaveChangesAsync() > 0)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        StorageTank storageTank = new StorageTank
                        {
                            Name = "Thùng " + i,
                            Quantity = 0,
                            TypeMilk = "Sữa Bò",
                            MilkCollectionStationId = entity.Id
                        };
                        storageTank.CreateBy(issuer).UpdateBy(issuer);
                        _storageTankRepository.Create(storageTank);
                        await _uow.SaveChangesAsync();
                    }
                    return entity.Id;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteMilkCollectionStationAsync(int id)
        {
            try
            {
                var milkcoupon = await _milkCouponRepository.GetMilkCouponByMilkCollectionStationId(id).MapQueryTo<MilkCouponModel>(_mapper).ToListAsync();
                var result = true;
                if (milkcoupon.Count() == 0)
                {
                    var entity = await _milkCollectionStationRepository.GetEntityByIdAsync(id);
                    var storageTank = await _storageTankRepository.GetStorageTankByMilkCollectionId(id).MapQueryTo<StorageTankModel>(_mapper).ToListAsync();
                    foreach (var st in storageTank)
                    {
                        var stEntity = _mapper.Map<StorageTank>(st);
                        _storageTankRepository.Delete(stEntity);
                        await _uow.SaveChangesAsync();
                    }
                    _milkCollectionStationRepository.Delete(entity);
                    if (await _uow.SaveChangesAsync() > 0)
                    {
                        result = true;
                    }
                } else
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

        public async Task<IEnumerable<MilkCollectionStationModel>> GetMilkCollectionStationAsync()
        {
            return await _milkCollectionStationRepository.GetMilkCollectionStations().MapQueryTo<MilkCollectionStationModel>(_mapper).ToListAsync();
           
        }

        public async Task<MilkCollectionStationModel> GetMilkCollectionStationByIdAsync(int id)
        {
            return await _milkCollectionStationRepository.GetMilkCollectionStationById(id).MapQueryTo<MilkCollectionStationModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMilkCollectionStationAsync(int id, MilkCollectionStationModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _milkCollectionStationRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _milkCollectionStationRepository.Update(entity);
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
            return await _milkCollectionStationRepository.CheckCodeExistsAsync(code);
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