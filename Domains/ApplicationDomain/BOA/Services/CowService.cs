using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Cows;
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
    public class CowService : ServiceBase, ICowService
    {
        private readonly ICowRepository _cowRepository;

        public CowService(
            ICowRepository cowRepository,
            IBreedRepository breedRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _cowRepository = cowRepository;

        }

        public async Task<int> CreateCowAsync(CowModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Cow>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _cowRepository.Create(entity);
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

        public async Task<bool> DeleteCowAsync(int id)
        {
            try
            {
                var entity = await _cowRepository.GetEntityByIdAsync(id);
                _cowRepository.Delete(entity);
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

        public async Task<IEnumerable<CowModel>> GetCowsAsync()
        {
            return await _cowRepository.GetCows().MapQueryTo<CowModel>(_mapper).ToListAsync();

        }

        public async Task<CowModel> GetCowByIdAsync(int id)
        {
            return await _cowRepository.GetCowById(id).MapQueryTo<CowModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCowAsync(int id, CowModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _cowRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _cowRepository.Update(entity);
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
            return await _cowRepository.CheckCodeExistsAsync(code);
        }

        public async Task<IEnumerable<CowModel>> GetCowByByreId(int byreId)
        {
            return await _cowRepository.GetCowByByreId(byreId).MapQueryTo<CowModel>(_mapper).ToListAsync();
        }

        public async Task<IEnumerable<CowModel>> GetCowByUserIdAsync(int userId)
        {
            var list = await _cowRepository.GetCowsByFarmerId(userId).MapQueryTo<CowModel>(_mapper).ToListAsync();
            return list;
        }
        public async Task<IEnumerable<CowModel>> GetCowNotExitsByMilkingSlipIdAsync(int id)
        {
            return await _cowRepository.GetCowNotExitsByMilkingSlipId(id).MapQueryTo<CowModel>(_mapper).ToListAsync();
            
        }
    }
}
