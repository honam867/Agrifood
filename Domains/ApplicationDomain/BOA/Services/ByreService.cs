using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Byres;
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
    public class ByreService : ServiceBase, IByreService
    {
        private readonly IByreRepository _byreRepository;
        private readonly IBreedRepository _breedRepository;
        public ByreService(
            IByreRepository byreRepository,
            IBreedRepository breedRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _byreRepository = byreRepository;
            _breedRepository = breedRepository;
        }

        public async Task<int> CreateByreAsync(ByreModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Byre>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.CreateBy(issuer).UpdateBy(issuer);
                _byreRepository.Create(entity);
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

        public async Task<bool> DeleteByreAsync(int id)
        {
            try
            {
                var entity = await _byreRepository.GetEntityByIdAsync(id);
                _byreRepository.Delete(entity);
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

        public async Task<IEnumerable<ByreModel>> GetByresAsync()
        {
            return await _byreRepository.GetByres().MapQueryTo<ByreModel>(_mapper).ToListAsync();
           
        }

        public async Task<ByreModel> GetByreByIdAsync(int id)
        {
            return await _byreRepository.GetByreById(id).MapQueryTo<ByreModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ByreModel>> GetByreByFarmerId(UserIdentity<int> issuer)
        {
            return await _byreRepository.GetByreByFarmerId(issuer.Id).MapQueryTo<ByreModel>(_mapper).ToListAsync();
        }


        public async Task<bool> UpdateByreAsync(int id, ByreModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _byreRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _byreRepository.Update(entity);
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
            return await _byreRepository.CheckCodeExistsAsync(code);
        }
        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateCode(10);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateCode(10));
        }
        public async Task<bool> UpdateCodeAsync()
        {
            var listFeed = await _byreRepository.GetEntitiesAsync();
            foreach (var item in listFeed)
            {
                item.Code = await AutoGenerateCodeAsync();
                _byreRepository.Update(item);
                await _uow.SaveChangesAsync();
            }
            return true;
        }
    }
}