using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.StorageTanks;
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
using AspNetCore.AutoGenerate;

namespace ApplicationDomain.BOA.Services
{
    public class StorageTankService : ServiceBase, IStorageTankService
    {
        private readonly IStorageTankRepository _storageTankRepository;

        public StorageTankService(
            IStorageTankRepository storageTankRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _storageTankRepository = storageTankRepository;
        
        }

        public async Task<int> CreateStorageTankAsync(StorageTankModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<StorageTank>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.CreateBy(issuer).UpdateBy(issuer);
                _storageTankRepository.Create(entity);
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

        public async Task<bool> DeleteStorageTankAsync(int id)
        {
            try
            {
                var entity = await _storageTankRepository.GetEntityByIdAsync(id);
                _storageTankRepository.Delete(entity);
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

        public async Task<IEnumerable<StorageTankModel>> GetStorageTankAsync()
        {
            return await _storageTankRepository.GetStorageTanks().MapQueryTo<StorageTankModel>(_mapper).ToListAsync();
           
        }

        public async Task<StorageTankModel> GetStorageTankByIdAsync(int id)
        {
            return await _storageTankRepository.GetStorageTankById(id).MapQueryTo<StorageTankModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StorageTankModel>> GetStorageTankByMilkCollectionIdAsync(int id)
        {
            return await _storageTankRepository.GetStorageTankByMilkCollectionId(id).MapQueryTo<StorageTankModel>(_mapper).ToListAsync();
        }

        public async Task<bool> UpdateStorageTankAsync(int id, StorageTankModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _storageTankRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _storageTankRepository.Update(entity);
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
            return await _storageTankRepository.CheckCodeExistsAsync(code);
        }

        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateCode(3);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateCode(3));
        }

    }
}