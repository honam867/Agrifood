using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models.Employees;
using ApplicationDomain.BOA.Models.Farmers;
using AspNetCore.AutoGenerate;
using AspNetCore.Common.Identity;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.CMMS.Services
{
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeService(
            IEmployeeRepository EmployeeRepository,
            IMapper mapper,
            IUnitOfWork uow) : base(mapper, uow)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeeListAsync()
        {
            return await _EmployeeRepository.GetEmployees().MapQueryTo<EmployeeModel>(_mapper).ToListAsync();
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            return await _EmployeeRepository.GetEmployeeById(id).MapQueryTo<EmployeeModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<int> CreateEmployeeAsync(EmployeeModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Employee>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _EmployeeRepository.Create(entity);
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

        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateCode(3);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateCode(3));
        }

        public async Task<bool> UpdateEmployeeAsync(int id, EmployeeModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Employee>(model);
                entity = await _EmployeeRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _EmployeeRepository.Update(entity);
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

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            try
            {
                var entity = await _EmployeeRepository.GetEntityByIdAsync(id);
                _EmployeeRepository.Delete(entity);
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
            return await _EmployeeRepository.CheckCodeExistsAsync(code);
        }

        //public async Task<IEnumerable<EmployeeModel>> GetEmployeeByProvinceIdAndDistrictId(int provinceId, int districtId)
        //{
        //    try
        //    {
        //        return await _EmployeeRepository.GetEmployeeByProvinceIdAndDistrictId(provinceId, districtId).MapQueryTo<EmployeeModel>(_mapper).ToListAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
