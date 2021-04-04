using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Cows;
using ApplicationDomain.BOA.Models.MilkingSlipDetails;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class MilkingSlipDetailController : BaseController
    {
        private readonly IMilkingSlipDetailService _milkingSlipDetailService;
        public MilkingSlipDetailController(IMilkingSlipDetailService milkingSlipDetailService)
        {
            _milkingSlipDetailService = milkingSlipDetailService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetMilkingSlipDetailAsync()
        {
            return Ok(await _milkingSlipDetailService.GetMilkingSlipDetailAsync());
        }

        //[Route("checkingcode/{code}")]
        //[HttpGet]
        //public async Task<IActionResult> CheckCodeExistsAsync(string code)
        //{
        //    return Ok(await _milkingSlipService.CheckCodeExistsAsync(code));
        //}

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMilkingSlipDetailByIdAsync(int id)
        {
            return Ok(await _milkingSlipDetailService.GetMilkingSlipDetailByIdAsync(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateMilkingSlipDetailAsync([FromBody]MilkingSlipDetailModelRq model)
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
                //if (await _milkingSlipDetailService.CheckCodeExistsAsync(model.Code))
                //{
                //    return BadRequest("Code Exists");
                //}
                return Ok(await _milkingSlipDetailService.CreateMilkingSlipDetailAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMilkingSlipDetailAsync(int id)
        {
            try
            {
                await _milkingSlipDetailService.DeleteMilkingSlipDetailAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMilkingSlipDetailAsync(int id, [FromBody]MilkingSlipDetailModelRq model)
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
                return Ok(await _milkingSlipDetailService.UpdateMilkingSlipDetailAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("detail/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMilkingSlipDetailByMilkingSlipIdAsync(int id)
        {
            return Ok(await _milkingSlipDetailService.GetMilkingSlipDetailByMilkingSlipIdAsync(id));
        }
    }
}