using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Departments;
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
    public class DepartmentService : ServiceBase, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(
            IDepartmentRepository departmentRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> CreateDepartmentAsync(DepartmentModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Department>(model);
                _departmentRepository.Create(entity);
                entity.CreateBy(issuer).UpdateBy(issuer);
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

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            try
            {
                var entity = await _departmentRepository.GetEntityByIdAsync(id);
                _departmentRepository.Delete(entity);
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

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentsAsync()
        {
            return await _departmentRepository.GetDepartment().MapQueryTo<DepartmentModel>(_mapper).ToListAsync();
            
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetDepartmentById(id).MapQueryTo<DepartmentModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateDepartmentAsync(int id, DepartmentModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _departmentRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _departmentRepository.Update(entity);
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
            return await _departmentRepository.CheckCodeExistsAsync(code);
        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartMentByBranchIdAsync(int id)
        {
            return await _departmentRepository.GetDepartmentByBranchId(id).MapQueryTo<DepartmentModel>(_mapper).ToListAsync();
        }
    }
}