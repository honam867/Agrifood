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
        private IMenuPermissionRepository _menuPermissionRepository;


        private IUserService _userService;
        public PermissionService(IMapper mapper,
            IUnitOfWork uow,
          
            IPermissionGroupRepository permissionGroupRepository,
            IPermissionMembershipRepository permissionMembershipRepository,
            IMenuPermissionRepository menuPermissionRepository,
        
            IUserService userService
            ) : base(mapper, uow)
        {
            _permissionGroupRepository = permissionGroupRepository;
            _permissionMembershipRepository = permissionMembershipRepository;
            _menuPermissionRepository = menuPermissionRepository;
            _userService = userService;
        }

        public async Task<GrantedPermission> GetGrantedPermission(int userId, IList<string> roles = null)
        {
            GrantedPermission grantedPermission = new GrantedPermission();
            grantedPermission.IsManagerOrDirector = await IsManagerOrDirector(userId, roles);

            // Quotaion
            grantedPermission.CanAccessQuotationsMenu = true;
            grantedPermission.CreateQuotationMenu = true;
            grantedPermission.RulesQuotationMenu = true;
            grantedPermission.CustomerQuotaionMenu = true;
            grantedPermission.MonthlyReportQuotaionMenu = true;
            grantedPermission.SummarizeReportQuotaionMenu = true;
            grantedPermission.ShippingCostQuotationMenu = true;
            grantedPermission.CanViewQuotationService = true;
            grantedPermission.CanViewQuotationCommerce = true;
            // Contract
            grantedPermission.ContractsMenu = true;
            grantedPermission.CreateContractMenu = true;
            grantedPermission.ContractTemplateMenu = true;
            // Order
            grantedPermission.OrdersMenu = true;
            grantedPermission.CreateOrderMenu = true;
            grantedPermission.BillMenu = true;
            grantedPermission.OrderReportMenu = true;
            // Library
            grantedPermission.CanAccessLibraryMenu = true;
            grantedPermission.CustomerLibraryMenu = true;
            grantedPermission.DistrictLibraryMenu = true;
            grantedPermission.OtherMenu = true;
            // HRM
            grantedPermission.CanAccessHRMMenu = true;
            // User
            grantedPermission.CanAccessUserMenu = true;
            // Asset
            grantedPermission.CanAccessAssetMenu = true;
            // System
            grantedPermission.CanAccessSystemMenu = true;
            // Structure
            grantedPermission.CanAccessStructureMenu = true;
            // Inventory
            grantedPermission.CanAccessInventoryMenu = true;
            // Purchase
            grantedPermission.CanAccessPurchaseMenu = true;
            // Service
            grantedPermission.CanAccessServiceMenu = true;
            return grantedPermission;
        }
        private async Task<bool> IsManagerOrDirector(int userId, IList<string> roles = null)
        {
            if(roles == null)
                roles = await _userService.GetRoleByUser(userId);
            if (roles.Contains(ROLE_CONSTANT.DIRECTOR) || roles.Contains(ROLE_CONSTANT.MANAGER))
            {
                return true;
            }
            return false;
        }

       

    }
}
