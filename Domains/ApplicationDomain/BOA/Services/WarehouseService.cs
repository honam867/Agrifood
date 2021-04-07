using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Warehouses;
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
    public class WarehouseService : ServiceBase, IWarehouseService
    {
        private readonly IWarehouseRepository _WarehouseRepository;

        public WarehouseService(
            IWarehouseRepository WarehouseRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _WarehouseRepository = WarehouseRepository;
        
        }

        public async Task<int> CreateWarehouseAsync(WarehouseModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Warehouse>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _WarehouseRepository.Create(entity);
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

        public async Task<bool> DeleteWarehouseAsync(int id)
        {
            try
            {
                var entity = await _WarehouseRepository.GetEntityByIdAsync(id);
                _WarehouseRepository.Delete(entity);
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

        public async Task<IEnumerable<WarehouseModel>> GetWarehouseAsync()
        {
            return await _WarehouseRepository.GetWarehouses().MapQueryTo<WarehouseModel>(_mapper).ToListAsync();
           
        }

        public async Task<WarehouseModel> GetWarehouseByIdAsync(int id)
        {
            return await _WarehouseRepository.GetWarehouseById(id).MapQueryTo<WarehouseModel>(_mapper).FirstOrDefaultAsync();
        }


        public async Task<bool> UpdateWarehouseAsync(int id, WarehouseModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _WarehouseRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _WarehouseRepository.Update(entity);
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