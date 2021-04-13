using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.TypeOfMilks;
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
    public class TypeOfMilkService : ServiceBase, ITypeOfMilkService
    {
        private readonly ITypeOfMilkRepository _typeOfMilkRepository;
        
        public TypeOfMilkService(
            ITypeOfMilkRepository typeOfMilkRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _typeOfMilkRepository = typeOfMilkRepository;
            
        }

        public async Task<int> CreateTypeOfMilkAsync(TypeOfMilkModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<TypeOfMilk>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _typeOfMilkRepository.Create(entity);
                return await _uow.SaveChangesAsync() == 1 ? entity.Id : 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteTypeOfMilkAsync(int id)
        {
            try
            {
                var entity = await _typeOfMilkRepository.GetEntityByIdAsync(id);
                _typeOfMilkRepository.Delete(entity);
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

        public async Task<IEnumerable<TypeOfMilkModel>> GetTypeOfMilksAsync()
        {
            return await _typeOfMilkRepository.GetTypeOfMilks().MapQueryTo<TypeOfMilkModel>(_mapper).ToListAsync();
           
        }

        public async Task<TypeOfMilkModel> GetTypeOfMilkByIdAsync(int id)
        {
            return await _typeOfMilkRepository.GetTypeOfMilkById(id).MapQueryTo<TypeOfMilkModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateTypeOfMilkAsync(int id, TypeOfMilkModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _typeOfMilkRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _typeOfMilkRepository.Update(entity);
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
            return await _typeOfMilkRepository.CheckCodeExistsAsync(code);
        }
    }
}