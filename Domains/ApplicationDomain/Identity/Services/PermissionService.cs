using ApplicationDomain.Helper;
using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using ApplicationDomain.Identity.IServices;
using ApplicationDomain.Identity.Models.Permissions;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.Services
{
    public class PermissionService : ServiceBase, IPermissionService
    {
        private IPermissionGroupRepository _permissionGroupRepository;
        private IPermissionMembershipRepository _permissionMembershipRepository;
        private IFarmerPermissionRepository _farmerPermissionRepository;

        private IUserService _userService;
        public PermissionService(IMapper mapper,
            IUnitOfWork uow,

           IFarmerPermissionRepository FarmerPermissionRepository,
            IPermissionGroupRepository permissionGroupRepository,
            IPermissionMembershipRepository permissionMembershipRepository,
        
            IUserService userService
            ) : base(mapper, uow)
        {
            _permissionGroupRepository = permissionGroupRepository;
            _farmerPermissionRepository = FarmerPermissionRepository;
            _permissionMembershipRepository = permissionMembershipRepository;
            _userService = userService;
        }

        

        public async Task<GrantedFarmerPermission> GetGrantedFarmerPermission(int userId, IList<string> roles = null)
        {
            GrantedFarmerPermission grantedFarmerPermission = new GrantedFarmerPermission();
            // Contract Service Permission
            grantedFarmerPermission.CanViewFarmer = await CanViewFarmer(userId, roles);
            grantedFarmerPermission.CanCreateFarmer = await CanCreateFarmer(userId, roles);
            grantedFarmerPermission.CanDeleteFarmer = await CanDeleteFarmer(userId, roles);
            grantedFarmerPermission.CanEditFarmer = await CanEditFarmer(userId, roles);
            grantedFarmerPermission.CanAccessFarmer = await CanAccessFarmer(userId, roles);
            return grantedFarmerPermission;

        }

        public async Task<bool> CanAccessFarmer(int userId, IList<string> roles = null)
        {
            if (roles == null) roles = await _userService.GetRoleByUser(userId);
            if (roles.Contains(ROLE_CONSTANT.SYSADMIN) || roles.Contains(ROLE_CONSTANT.ADMIN))
            {
                return true;
            }
            List<int> allGroup = await _permissionMembershipRepository.GetAllGroupByUserId(userId).Cast<int>().ToListAsync();
            bool isGranted = _farmerPermissionRepository
                .GetFarmerPmsByListPermissionGroupId(allGroup)
                .Cast<FarmerPermission>()
                .OrderByDescending(r => r.CanAccess)
                .Select(p => p.CanView)
                .FirstOrDefault();
            return isGranted;
        }

        public async Task<bool> CanViewFarmer(int userId, IList<string> roles = null)
        {
            if (roles == null) roles = await _userService.GetRoleByUser(userId);
            if (roles.Contains(ROLE_CONSTANT.SYSADMIN) || roles.Contains(ROLE_CONSTANT.ADMIN))
            {
                return true;
            }
            List<int> allGroup = await _permissionMembershipRepository.GetAllGroupByUserId(userId).Cast<int>().ToListAsync();
            bool isGranted = _farmerPermissionRepository
                .GetFarmerPmsByListPermissionGroupId(allGroup)
                .Cast<FarmerPermission>()
                .OrderByDescending(r => r.CanView)
                .Select(p => p.CanView)
                .FirstOrDefault();
            return isGranted;
        }

        private async Task<bool> CanCreateFarmer(int userId, IList<string> roles = null)
        {
            if (roles == null) roles = await _userService.GetRoleByUser(userId);
            if (roles.Contains(ROLE_CONSTANT.SYSADMIN) || roles.Contains(ROLE_CONSTANT.ADMIN))
            {
                return true;
            }
            List<int> allGroup = await _permissionMembershipRepository.GetAllGroupByUserId(userId).Cast<int>().ToListAsync();
            bool isGranted = _farmerPermissionRepository.GetFarmerPmsByListPermissionGroupId(allGroup).Cast<FarmerPermission>().OrderByDescending(r => r.CanCreate).Select(p => p.CanCreate).FirstOrDefault();
            return isGranted;
        }

        private async Task<bool> CanEditFarmer(int userId, IList<string> roles = null)
        {
            if (roles == null) roles = await _userService.GetRoleByUser(userId);
            if (roles.Contains(ROLE_CONSTANT.SYSADMIN) || roles.Contains(ROLE_CONSTANT.ADMIN))
            {
                return true;
            }
            List<int> allGroup = await _permissionMembershipRepository.GetAllGroupByUserId(userId).Cast<int>().ToListAsync();
            bool isGranted = _farmerPermissionRepository.GetFarmerPmsByListPermissionGroupId(allGroup).Cast<FarmerPermission>().OrderByDescending(r => r.CanEdit).Select(p => p.CanEdit).FirstOrDefault();
            return isGranted;
        }


        private async Task<bool> CanDeleteFarmer(int userId, IList<string> roles = null)
        {
            if (roles == null) roles = await _userService.GetRoleByUser(userId);
            if (roles.Contains(ROLE_CONSTANT.SYSADMIN) || roles.Contains(ROLE_CONSTANT.ADMIN))
            {
                return true;
            }
            List<int> allGroup = await _permissionMembershipRepository.GetAllGroupByUserId(userId).Cast<int>().ToListAsync();
            bool isGranted = _farmerPermissionRepository.GetFarmerPmsByListPermissionGroupId(allGroup).Cast<FarmerPermission>().OrderByDescending(r => r.CanDelete).Select(p => p.CanDelete).FirstOrDefault();
            return isGranted;
        }



    }
}
