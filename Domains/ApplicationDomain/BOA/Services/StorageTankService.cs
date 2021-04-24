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

namespace ApplicationDomain.BOA.Services
{
    public class StorageTankService : ServiceBase, IStorageTankService
    {
        private readonly IStorageTankRepository _StorageTankRepository;

        public StorageTankService(
            IStorageTankRepository StorageTankRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _StorageTankRepository = StorageTankRepository;
        
        }

        public async Task<int> CreateStorageTankAsync(StorageTankModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<StorageTank>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _StorageTankRepository.Create(entity);
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
                var entity = await _StorageTankRepository.GetEntityByIdAsync(id);
                _StorageTankRepository.Delete(entity);
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
            return await _StorageTankRepository.GetStorageTanks().MapQueryTo<StorageTankModel>(_mapper).ToListAsync();
           
        }

        public async Task<StorageTankModel> GetStorageTankByIdAsync(int id)
        {
            return await _StorageTankRepository.GetStorageTankById(id).MapQueryTo<StorageTankModel>(_mapper).FirstOrDefaultAsync();
        }


        public async Task<bool> UpdateStorageTankAsync(int id, StorageTankModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _StorageTankRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _StorageTankRepository.Update(entity);
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