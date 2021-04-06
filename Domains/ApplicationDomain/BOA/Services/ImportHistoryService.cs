using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.ImportHistorys;
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
    public class ImportHistoryService : ServiceBase, IImportHistoryService
    {
        private readonly IImportHistoryRepository _importHistoryRepository;

        public ImportHistoryService(
            IImportHistoryRepository importHistoryRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _importHistoryRepository = importHistoryRepository;
        
        }

        public async Task<int> CreateImportHistoryAsync(ImportHistoryModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<ImportHistory>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _importHistoryRepository.Create(entity);
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

        public async Task<bool> DeleteImportHistoryAsync(int id)
        {
            try
            {
                var entity = await _importHistoryRepository.GetEntityByIdAsync(id);
                _importHistoryRepository.Delete(entity);
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

        public async Task<IEnumerable<ImportHistoryModel>> GetImportHistoryAsync()
        {
            return await _importHistoryRepository.GetImportHistorys().MapQueryTo<ImportHistoryModel>(_mapper).ToListAsync();
           
        }

        public async Task<ImportHistoryModel> GetImportHistoryByIdAsync(int id)
        {
            return await _importHistoryRepository.GetImportHistoryById(id).MapQueryTo<ImportHistoryModel>(_mapper).FirstOrDefaultAsync();
        }


        public async Task<bool> UpdateImportHistoryAsync(int id, ImportHistoryModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _importHistoryRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _importHistoryRepository.Update(entity);
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