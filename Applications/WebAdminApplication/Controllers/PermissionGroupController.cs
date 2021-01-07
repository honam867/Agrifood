using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.Identity.IServices;
using ApplicationDomain.Identity.Models.Permissions;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class PermissionGroupController : BaseController
    {
        private readonly IPermissionGroupService _permissionGroupService;
        public PermissionGroupController(IPermissionGroupService permissionGroupService)
        {
            _permissionGroupService = permissionGroupService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetPermissionGroups()
        {
            try
            {
                return Ok(await _permissionGroupService.GetPermissionGroups());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPermissionGroupId(int id)
        {
            try
            {
                return Ok(await _permissionGroupService.GetPermissionGroupById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreatePermissionGroup([FromBody]PermissionGroupDetailRq permissionGroupDetail)
        {
            try
            {
                int createdPermissionGroupId = await _permissionGroupService.CreatePermissionGroup(permissionGroupDetail);
                return OkValueObject(createdPermissionGroupId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePermissionGroup(int id)
        {
            try
            {
                return OkValueObject(await _permissionGroupService.DeletePermissionGroup(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePermissionGroup(int id, [FromBody]PermissionGroupDetailRq permissionGroupDetail)
        {
            try
            {
                return OkValueObject(await _permissionGroupService.UpdatePermissionGroup(id, permissionGroupDetail));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}