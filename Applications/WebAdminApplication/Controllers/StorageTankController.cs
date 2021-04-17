using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Cows;
using ApplicationDomain.BOA.Models.StorageTanks;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class StorageTankController : BaseController
    {
        private readonly IStorageTankService _StorageTankService;
        public StorageTankController(IStorageTankService StorageTankService)
        {
            _StorageTankService = StorageTankService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetStorageTankAsync()
        {
            return Ok(await _StorageTankService.GetStorageTankAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetStorageTankByIdAsync(int id)
        {
            return Ok(await _StorageTankService.GetStorageTankByIdAsync(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateStorageTankAsync([FromBody]StorageTankModelRq model)
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
                //if (await _StorageTankService.CheckCodeExistsAsync(model.Code))
                //{
                //    return BadRequest("Code Exists");
                //}
                return Ok(await _StorageTankService.CreateStorageTankAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStorageTankAsync(int id)
        {
            try
            {
                await _StorageTankService.DeleteStorageTankAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStorageTankAsync(int id, [FromBody]StorageTankModelRq model)
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
                return Ok(await _StorageTankService.UpdateStorageTankAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}