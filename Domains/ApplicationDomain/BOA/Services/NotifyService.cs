using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Notifys;
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
    public class NotifyService : ServiceBase, INotifyService
    {
        private readonly INotifyRepository _notifyRepository;
        
        public NotifyService(
            INotifyRepository notifyRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _notifyRepository = notifyRepository;
            
        }

        public async Task<int> CreateNotifyAsync(NotifyModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Notify>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.Status = 0;
                entity.CreateBy(issuer).UpdateBy(issuer);
                _notifyRepository.Create(entity);
                return await _uow.SaveChangesAsync() == 1 ? entity.Id : 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteNotifyAsync(int id)
        {
            try
            {
                var entity = await _notifyRepository.GetEntityByIdAsync(id);
                _notifyRepository.Delete(entity);
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

        public async Task<IEnumerable<NotifyModel>> GetNotifysAsync()
        {
            return await _notifyRepository.GetNotifys().MapQueryTo<NotifyModel>(_mapper).ToListAsync();
           
        }

        public async Task<NotifyModel> GetNotifyByIdAsync(int id)
        {
            return await _notifyRepository.GetNotifyById(id).MapQueryTo<NotifyModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateNotifyAsync(int id, NotifyModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _notifyRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _notifyRepository.Update(entity);
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
            return await _notifyRepository.CheckCodeExistsAsync(code);
        }

        public async Task<IEnumerable<NotifyModel>> GetNotifyByFarmerIdAsync(int id)
        {
            return await _notifyRepository.GetNotifyByFarmerId(id).MapQueryTo<NotifyModel>(_mapper).ToListAsync();
        }
        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateCode(10);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateCode(10));
        }

        public async Task<IEnumerable<NotifyModel>> GetNotifyByEmployeeIdAsync(int id)
        {
            return await _notifyRepository.GetNotifyByEmployeeId(id).MapQueryTo<NotifyModel>(_mapper).ToListAsync();
        }

        public async Task<bool> UpdateStatusAsync(int id, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _notifyRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                entity.Status = 1;
                entity.UpdateBy(issuer);
                _notifyRepository.Update(entity);
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