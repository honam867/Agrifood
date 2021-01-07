using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Branchs;
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
    public class BranchService : ServiceBase, IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly ICompanyRepository _companyRepository;
        public BranchService(
            IBranchRepository branchRepository,
            ICompanyRepository companyRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _branchRepository = branchRepository;
            _companyRepository = companyRepository;
        }

        public async Task<int> CreateBranchAsync(ByreModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Branch>(model);
                var company = (await _companyRepository.GetEntitiesAsync()).FirstOrDefault();
                if (company == null)
                    throw new Exception("Please create company info first!");
                entity.CompanyId = company.Id;
                entity.CreateBy(issuer).UpdateBy(issuer);
                _branchRepository.Create(entity);
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

        public async Task<bool> DeleteBranchAsync(int id)
        {
            try
            {
                var entity = await _branchRepository.GetEntityByIdAsync(id);
                _branchRepository.Delete(entity);
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

        public async Task<IEnumerable<ByreModel>> GetBranchsAsync()
        {
            return await _branchRepository.GetBranchs().MapQueryTo<ByreModel>(_mapper).ToListAsync();
           
        }

        public async Task<ByreModel> GetBranchByIdAsync(int id)
        {
            return await _branchRepository.GetBranchById(id).MapQueryTo<ByreModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateBranchAsync(int id, ByreModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _branchRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _branchRepository.Update(entity);
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
            return await _branchRepository.CheckCodeExistsAsync(code);
        }
    }
}