using ApplicationDomain.Helper;
using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using ApplicationDomain.Identity.IServices;
using ApplicationDomain.Identity.Models;
using AspNetCore.Common.Identity;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.Services
{
    public class RoleService : ServiceBase, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<Role> _roleManagement;
     
        public RoleService(IMapper mapper,
            IUnitOfWork uow,
            IRoleRepository roleRepository,
            RoleManager<Role> roleManagement)
            : base(mapper, uow)
        {
            _roleRepository = roleRepository;
            _roleManagement = roleManagement;
       
        }

        public IEnumerable<RoleListModel> GetListRoles()
        {
            return _roleRepository.GetListRoles().MapQueryTo<RoleListModel>(_mapper);
        }

        public RoleListModel GetRoleById(int id)
        {
            return _roleRepository.GetRoleById(id).MapQueryTo<RoleListModel>(_mapper).FirstOrDefault();
        }

        public async Task<int> CreateRoleAsync(RoleCreatedModelRq model, UserIdentity<int> issuer)
        {
            var role = _mapper.Map<Role>(model);
            if (issuer != null)
            {
                role.CreateBy(issuer).UpdateBy(issuer);
            }
            var identityResult = await _roleManagement.CreateAsync(role);
            if (!identityResult.Succeeded)
            {
                throw CreateException(identityResult.Errors);
            }
            await _uow.SaveChangesAsync();
            return role.Id;
        }

        public async Task<bool> UpdateRoleAsync(int id, RoleCreatedModelRq model, UserIdentity<int> issuer)
        {
            var role = _roleRepository.GetRoleById(id).MapQueryTo<Role>(_mapper).FirstOrDefault();
            role.Name = model.Name;
            if (issuer != null)
                role.UpdateBy(issuer);
            await _roleManagement.UpdateAsync(role);

            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = _roleRepository.GetRoleById(id).MapQueryTo<Role>(_mapper).FirstOrDefault();

            if (role == null)
            {
                return false;
            }
            _roleRepository.Delete(role);

            await _uow.SaveChangesAsync();

            return true;
        }

        private Exception CreateException(IEnumerable<IdentityError> errors)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoleListModel>> GetRoleNotExistsInUserRoleId(int userId)
        {
            return await _roleRepository.GetRoleNotExistsInUserRoleId(userId).MapQueryTo<RoleListModel>(_mapper).ToListAsync();
        }

        public async Task<bool> CreateDefaultEntityRolesAsync(UserIdentity<int> issuer)
        {
            try
            {
                var menusDefault = new List<RoleCreatedModelRq>()
                {
                    new RoleCreatedModelRq()
                    {
                        Name = ROLE_CONSTANT.SYSADMIN
                    },
                    new RoleCreatedModelRq()
                    {
                        Name = ROLE_CONSTANT.EMPLOYEE
                    },
                    //new RoleCreatedModelRq()
                    //{
                    //    Name = ROLE_CONSTANT.CUSTOMER
                    //},
                    new RoleCreatedModelRq()
                    {
                        Name = ROLE_CONSTANT.ADMIN
                    },
                    //new RoleCreatedModelRq()
                    //{
                    //    Name = ROLE_CONSTANT.MANAGER
                    //},
                    //new RoleCreatedModelRq()
                    //{
                    //    Name = ROLE_CONSTANT.DIRECTOR
                    //}
                };
                foreach (var item in menusDefault)
                {
                    if (!await _roleRepository.CheckNameExists(item.Name))
                    {
                        await this.CreateRoleAsync(item, issuer);
                    }
                }
                if (await _uow.SaveChangesAsync() >= 1)
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

        public async Task<string> GetRoleQuotationEmployee()
        {
            return await _roleRepository.GetRoleQuotationEmployeeAsync();
        }

        //public async Task<string> GetRoleQuotationManager()
        //{
        //    return await _roleRepository.GetRoleQuotationManagerAsync();
        //}

        //public async Task<string> GetRoleQuotationDirector()
        //{
        //    return await _roleRepository.GetRoleQuotationDirectorAsync();
        //}

        public async Task<string> GetRoleQuotationService()
        {
            return await _roleRepository.GetRoleQuotationServiceAsync();
        }

        public async Task<string> GetRoleQuotationCommerce()
        {
            return await _roleRepository.GetRoleQuotationCommerceAsync();
        }

        
    }
}
