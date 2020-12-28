using ApplicationDomain.BOA.IServices;
using ApplicationDomain.Helper;
using ApplicationDomain.Identity.IServices;
using ApplicationDomain.Identity.Models;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAdminApplication.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private static string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};
        public UserController(IUserService userService
          
            )
        {
            _userService = userService;
      
        }
        [Route("test")]
        [HttpGet]
        public IActionResult GetTest()
        {

            return Ok(Summaries);
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetListUsers());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                return Ok(await _userService.GetUserById(id));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("role/{userid}")]
        [HttpGet]
        public async Task<IActionResult> GetRoleByUser(int userId)
        {
            try
            {
                return Ok(await _userService.GetRoleByUser(userId));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreatedUserRq model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection modelErrors = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection();
                    foreach (var entry in ModelState.Values)
                        foreach (var error in entry.Errors)
                            modelErrors.Add(error);
                    return BadRequest(modelErrors);
                }
                return Ok(await _userService.CreateUserAsync(model));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


        [Route("farmersignup")]
        [HttpPost]
        public async Task<IActionResult> FarmerSignUpAsync([FromBody]CreatedFarmerRq model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection modelErrors = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection();
                    foreach (var entry in ModelState.Values)
                        foreach (var error in entry.Errors)
                            modelErrors.Add(error);
                    return BadRequest(modelErrors);
                }
                return Ok(await _userService.FarmerSignUpAsync(model));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

     


        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody]UpdatedUserRq model)
        {
            if (!ModelState.IsValid)
            {
                Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection modelErrors = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection();
                foreach (var entry in ModelState.Values)
                    foreach (var error in entry.Errors)
                        modelErrors.Add(error);
                return BadRequest(modelErrors);
            }
            var userId = await _userService.UpdateUserAsync(id, model, GetCurrentUserIdentity<int>());
            return OkValueObject(userId);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _userService.DeleteUserAsync(id));
        }

        [Route("role")]
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser([FromBody]UpdateUserRoleModelRq model)
        {
            if (!ModelState.IsValid)
            {
                Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection modelErrors = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection();
                foreach (var entry in ModelState.Values)
                    foreach (var error in entry.Errors)
                        modelErrors.Add(error);
                return BadRequest(modelErrors);
            }
            return OkValueObject(await _userService.AddRoleToUserAsync(model));
        }

        [Route("addlistrole")]
        [HttpPost]
        public async Task<IActionResult> AddRolesToUser([FromBody]AddRolesToUserModelRq models)
        {
            if (!ModelState.IsValid)
            {
                Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection modelErrors = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection();
                foreach (var entry in ModelState.Values)
                    foreach (var error in entry.Errors)
                        modelErrors.Add(error);
                return BadRequest(modelErrors);
            }
            return OkValueObject(await _userService.AddRolesToUser(models));
        }

        [Route("{userId}/{roleName}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveRoleToUser(int userId, string roleName)
        {
            UpdateUserRoleModelRq model = new UpdateUserRoleModelRq()
            {
                UserId = userId,
                RoleName = roleName
            };
            return OkValueObject(await _userService.RemoveRoleToUserAsync(model));
        }

        [Route("emailchecking/{email}")]
        [HttpGet]
        public async Task<IActionResult> CheckEmailAsync(string email)
        {
            return OkValueObject(await _userService.CheckEmailAsync(email));
        }

        [Route("phonechecking/{phone}")]
        [HttpGet]
        public async Task<IActionResult> CheckPhoneNumberFarmerAsync(string phone)
        {
            return OkValueObject(await _userService.CheckPhoneNumberAsync(phone));
        }

    }
}