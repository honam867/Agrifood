using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Breeds;
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
    public class BreedService : ServiceBase, IBreedService
    {
        private readonly IBreedRepository _breedRepository;
        
        public BreedService(
            IBreedRepository breedRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _breedRepository = breedRepository;
            
        }

        public async Task<int> CreateBreedAsync(BreedModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Breed>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _breedRepository.Create(entity);
                return await _uow.SaveChangesAsync() == 1 ? entity.Id : 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteBreedAsync(int id)
        {
            try
            {
                var entity = await _breedRepository.GetEntityByIdAsync(id);
                _breedRepository.Delete(entity);
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

        public async Task<IEnumerable<BreedModel>> GetBreedsAsync()
        {
            return await _breedRepository.GetBreeds().MapQueryTo<BreedModel>(_mapper).ToListAsync();
           
        }

        public async Task<BreedModel> GetBreedByIdAsync(int id)
        {
            return await _breedRepository.GetBreedById(id).MapQueryTo<BreedModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateBreedAsync(int id, BreedModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _breedRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _breedRepository.Update(entity);
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
            return await _breedRepository.CheckCodeExistsAsync(code);
        }
    }
}