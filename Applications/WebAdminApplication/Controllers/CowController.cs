using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Cows;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class CowController : BaseController
    {
        private readonly ICowService _cowService;
        public CowController(ICowService cowService)
        {
            _cowService = cowService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetCowsAsync()
        {
            return Ok(await _cowService.GetCowsAsync());
        }

        [Route("byre/{byreId}")]
        [HttpGet]
        public async Task<IActionResult> GetCowsByByreIdAsync(int byreId)
        {
            return Ok(await _cowService.GetCowByByreId(byreId));
        }

        [Route("user/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetCowsByUserIdAsync(int userId)
        {            
            return Ok(await _cowService.GetCowByUserIdAsync(userId));
        }

        [Route("checkingcode/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExistsAsync(string code)
        {
            return Ok(await _cowService.CheckCodeExistsAsync(code));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCowById(int id)
        {
            return Ok(await _cowService.GetCowByIdAsync(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateCowAsync([FromBody]CowModelRq model)
        {
            if (!ModelState.IsValid)
            {
                Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection modelErrors = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection();
                foreach (var entry in ModelState.Values)
                    foreach (var error in entry.Errors)
                        modelErrors.Add(error);
                return BadRequest(modelErrors);
            }
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                if (await _cowService.CheckCodeExistsAsync(model.Code))
                {
                    return BadRequest("Code Exists");
                }
                return Ok(await _cowService.CreateCowAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCowAsync(int id)
        {
            try
            {
                await _cowService.DeleteCowAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCowAsync(int id, [FromBody]CowModelRq model)
        {
            if (!ModelState.IsValid)
            {
                Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection modelErrors = new Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection();
                foreach (var entry in ModelState.Values)
                    foreach (var error in entry.Errors)
                        modelErrors.Add(error);
                return BadRequest(modelErrors);
            }
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return Ok(await _cowService.UpdateCowAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("checkcow/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCowNotExitsByMilkingSlipIdAsync(int id)
        {
            return Ok(await _cowService.GetCowNotExitsByMilkingSlipIdAsync(id));
        }
    }
}