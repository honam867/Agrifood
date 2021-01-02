using ApplicationDomain.Helper;
using ApplicationDomain.Identity.IServices;
using ApplicationDomain.Identity.Models;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdminApplication.Models;

namespace WebAdminApplication.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        //private readonly IQuotationRolePermissionService _quotationRolePermissionService;
        public RoleController(IRoleService roleService
           /* IQuotationRolePermissionService quotationRolePermissionService*/)
        {
            _roleService = roleService;
           /* _quotationRolePermissionService = quotationRolePermissionService*/;
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetRoles()
        {
            try
            {
                var issuer = GetCurrentUserIdentity<int>();
                if (issuer.Roles.Contains(ROLE_CONSTANT.SYSADMIN) || issuer.Roles.Contains(ROLE_CONSTANT.ADMIN))
                {
                    return Ok(_roleService.GetListRoles());
                }
                return BadRequest("You need the role of Admin or SysAdmin to perform this action.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetRoleById(int id)
        {
            return Ok(_roleService.GetRoleById(id));
        }

        [Route("rolenotexists/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetRoleNotExistsInUserRoleId(int id)
        {
            try
            {
                var issuer = GetCurrentUserIdentity<int>();
                if (issuer.Roles.Contains(ROLE_CONSTANT.ADMIN) || issuer.Roles.Contains(ROLE_CONSTANT.SYSADMIN))
                {
                    return Ok(await _roleService.GetRoleNotExistsInUserRoleId(id));
                }
                return BadRequest("You need the role of Admin or SysAdmin to perform this action.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[Route("checkingquotationemployee")]
        //[HttpGet]
        //public async Task<IActionResult> CheckRoleQuotationEmployeeAsync()
        //{
        //    var issuer = GetCurrentUserIdentity<int>();
        //    return OkValueObject(issuer.Roles.Contains(await _roleService.GetRoleQuotationEmployee()));
        //}


        //[Route("checkingquotationmanager")]
        //[HttpGet]
        //public async Task<IActionResult> CheckRoleQuotationManagerAsync()
        //{
        //    var issuer = GetCurrentUserIdentity<int>();
        //    return OkValueObject(issuer.Roles.Contains(await _roleService.GetRoleQuotationManager()));
        //}

        //[Route("checkingquotationdirector")]
        //[HttpGet]
        //public async Task<IActionResult> CheckRoleQuotationDirectorAsync()
        //{
        //    var issuer = GetCurrentUserIdentity<int>();
        //    return OkValueObject(issuer.Roles.Contains(await _roleService.GetRoleQuotationDirector()));
        //}

        //[Route("checkingquotationservice")]
        //[HttpGet]
        //public async Task<IActionResult> CheckRoleQuotationServiceAsync()
        //{
        //    var issuer = GetCurrentUserIdentity<int>();
        //    return OkValueObject(issuer.Roles.Contains(await _roleService.GetRoleQuotationService()));
        //}

        //[Route("checkingquotationcommer")]
        //[HttpGet]
        //public async Task<IActionResult> CheckRoleQuotationCommerceAsync()
        //{
        //    var issuer = GetCurrentUserIdentity<int>();
        //    return OkValueObject(issuer.Roles.Contains(await _roleService.GetRoleQuotationCommerce()));
        //}

        //[Route("rolequotationpermission")]
        //[HttpGet]
        //public async Task<IActionResult> RoleQuotationPermissionAsync()
        //{
        //    var issuer = GetCurrentUserIdentity<int>();
        //    var result = new RoleQuotationPermissionModel()
        //    {
        //        IsQuotationEmployee = issuer.Roles.Contains(await _roleService.GetRoleQuotationEmployee()),
        //        IsQuotationManager = issuer.Roles.Contains(await _roleService.GetRoleQuotationManager()),
        //        IsQuotationDirector = issuer.Roles.Contains(await _roleService.GetRoleQuotationDirector()),
        //        IsQuotationCommercial = issuer.Roles.Contains(await _roleService.GetRoleQuotationCommerce()),
        //        IsQuotationService = issuer.Roles.Contains(await _roleService.GetRoleQuotationService()),
        //    };
        //    return Ok(result);
        //}

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody]RoleCreatedModelRq model)
        {
            try
            {
                var issuer = GetCurrentUserIdentity<int>();
                return Ok(await _roleService.CreateRoleAsync(model, issuer));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateRole(int id, [FromBody]RoleCreatedModelRq model)
        {
            try
            {
                var issuer = GetCurrentUserIdentity<int>();
                return Ok(await _roleService.UpdateRoleAsync(id, model, issuer));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DelteRole(int id)
        {
            try
            {
                var issuer = GetCurrentUserIdentity<int>();
                if (issuer.Roles.Contains(ROLE_CONSTANT.ADMIN) || issuer.Roles.Contains(ROLE_CONSTANT.SYSADMIN))
                {
                    return Ok(await _roleService.DeleteRoleAsync(id));
                }
                return BadRequest("You need the role of Admin or SysAdmin to perform this action.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("default")]
        [HttpPost]
        public async Task<IActionResult> InsertDeufaultRolesAsync()
        {
            var issuer = GetCurrentUserIdentity<int>();
            return Ok(await _roleService.CreateDefaultEntityRolesAsync(issuer));
        }
    }
}
