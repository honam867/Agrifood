using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using ApplicationDomain.Identity.IServices;
using ApplicationDomain.Identity.Models.Permissions;
using AspNetCore.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AspNetCore.DataBinding.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDomain.Identity.Services
{
    public class PermissionGroupService : ServiceBase, IPermissionGroupService
    {
        private IPermissionGroupRepository _permissionGroupRepository;
        private IPermissionMembershipRepository _permissionMembershipRepository;
        private IMenuPermissionRepository _menuPermissionRepository;


        public PermissionGroupService(

            IMapper mapper,
            IUnitOfWork uow,
            IPermissionGroupRepository permissionGroupRepository,
            IPermissionMembershipRepository permissionMembershipRepository,
            IMenuPermissionRepository menuPermissionRepository

            ) : base(mapper, uow)
        {

            _permissionGroupRepository = permissionGroupRepository;
            _permissionMembershipRepository = permissionMembershipRepository;
            _menuPermissionRepository = menuPermissionRepository;
       
        }

        public async Task<int> CreatePermissionGroup(PermissionGroupDetailRq permissionGroupDetailRq)
        {
            int createdPermissionGroupId = await CreatePermissionGroupDetailAsync(new PermissionGroup(permissionGroupDetailRq.Name, permissionGroupDetailRq.Description));

            await AddMemberToPermissionGroupAsync(createdPermissionGroupId, permissionGroupDetailRq.Users);

            GrantMenuPermissionToGroup(createdPermissionGroupId, permissionGroupDetailRq.MenuPms);
     
            await _uow.SaveChangesAsync();

            return createdPermissionGroupId;
        }

        public async Task<IEnumerable<PermissionGroup>> GetPermissionGroups()
        {
            return await _permissionGroupRepository.GetEntitiesAsync();
        }

        private async Task<int> CreatePermissionGroupDetailAsync(PermissionGroup permissionGroup)
        {
            _permissionGroupRepository.Create(permissionGroup);
            if (await _uow.SaveChangesAsync() == 1)
            {
                return permissionGroup.Id;
            }
            return 0;
        }

        private async Task AddMemberToPermissionGroupAsync(int permissionGroupId, List<int> userIds)
        {
            List<PermissionMembership> permissionMemberships = new List<PermissionMembership>();
            userIds.ForEach(userId =>
               {
                   permissionMemberships.Add(new PermissionMembership(permissionGroupId, userId));
               }
            );
            await _permissionMembershipRepository.CreateRangeAsync(permissionMemberships);
        }
        private void GrantMenuPermissionToGroup(int permissionGroupId, MenuPermissionModel menuPermissionRq)
        {
            MenuPermission menuPermission = new MenuPermission();
            _mapper.Map(menuPermissionRq, menuPermission);
            menuPermission.PermissionGroupId = permissionGroupId;
            _menuPermissionRepository.Create(menuPermission);
        }
     

        public async Task<PermissionGroupDetailModel> GetPermissionGroupById(int id)
        {
            try
            {
                PermissionGroupDetailModel result = new PermissionGroupDetailModel();
                PermissionGroup permissionGroup = await _permissionGroupRepository.GetEntityByIdAsync(id);
                result.Id = permissionGroup.Id;
                result.Name = permissionGroup.Name;
                result.Description = permissionGroup.Description;
                result.Users = await _permissionMembershipRepository.GetAllMemberByPermissionGroupId(id).Cast<PermissionMembership>().Select(p => p.UserId).ToListAsync();
                result.MenuPms = await _menuPermissionRepository.GetMenuPermissionByPermissionGroupId(id).MapQueryTo<MenuPermissionModel>(_mapper).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> DeletePermissionGroup(int id)
        {
            try
            {
                var permissionGroup = await _permissionGroupRepository.GetEntityByIdAsync(id);
                var permissionMembership = await _permissionMembershipRepository.GetAllMemberByPermissionGroupId(permissionGroup.Id).Cast<PermissionMembership>().ToListAsync();
                var menuPms = _menuPermissionRepository.GetMenuPermissionByPermissionGroupId(permissionGroup.Id).Cast<MenuPermission>().FirstOrDefault();
                if (menuPms != null) _menuPermissionRepository.Delete(menuPms);

                if (_uow.SaveChangesAsync().Result > 0)
                {
                    await _permissionGroupRepository.DeleteAsync(permissionGroup.Id);
                    return await _uow.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception e )
            {

                throw e;
            }
      
        }

        public async Task<bool> UpdatePermissionGroup(int id, PermissionGroupDetailRq permissionGroupDetailRq)
        {
            try
            {

                var permissionGroup = await _permissionGroupRepository.GetEntityByIdAsync(id);
                var permissionMembership = await _permissionMembershipRepository.GetAllMemberByPermissionGroupId(permissionGroup.Id).Cast<PermissionMembership>().ToListAsync();
                var menuPms = _menuPermissionRepository.GetMenuPermissionByPermissionGroupId(permissionGroup.Id).Cast<MenuPermission>().FirstOrDefault();
           
                _mapper.Map(permissionGroupDetailRq.MenuPms, menuPms);
                _menuPermissionRepository.Update(menuPms);

                permissionMembership.ForEach(pm =>
                {
                    if (!permissionGroupDetailRq.Users.Contains(pm.UserId))
                    {
                        _permissionMembershipRepository.Delete(pm);
                    }
                });

                permissionGroupDetailRq.Users.ForEach(u =>
                {
                    if (!permissionMembership.Select(p => p.UserId).Contains(u))
                    {
                        _permissionMembershipRepository.Create(new PermissionMembership(permissionGroup.Id, u));
                    }
                });

                if (_uow.SaveChangesAsync().Result > 0)
                {
                    permissionGroup.Name = permissionGroupDetailRq.Name;
                    permissionGroup.Description = permissionGroupDetailRq.Description;
                    _permissionGroupRepository.Update(permissionGroup);
                    return await _uow.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
