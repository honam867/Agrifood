using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Cows;
using ApplicationDomain.BOA.Models.MilkCouponDetails;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class MilkCouponDetailController : BaseController
    {
        private readonly IMilkCouponDetailService _milkCouponDetailService;
        public MilkCouponDetailController(IMilkCouponDetailService milkCouponDetailService)
        {
            _milkCouponDetailService = milkCouponDetailService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetMilkCouponDetailAsync()
        {
            return Ok(await _milkCouponDetailService.GetMilkCouponDetailAsync());
        }

        //[Route("checkingcode/{code}")]
        //[HttpGet]
        //public async Task<IActionResult> CheckCodeExistsAsync(string code)
        //{
        //    return Ok(await _milkingSlipService.CheckCodeExistsAsync(code));
        //}

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMilkCouponDetailByIdAsync(int id)
        {
            return Ok(await _milkCouponDetailService.GetMilkCouponDetailByIdAsync(id));
        }

        [Route("detail/{milkCounponId}")]
        [HttpGet]
        public async Task<IActionResult> GetMilkcouponDetailByMilkcouponIdAsync(int milkCounponId) {
            return Ok(await _milkCouponDetailService.GetMilkcouponDetailByMilkcouponIdAsync(milkCounponId));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateMilkCouponDetailAsync([FromBody]MilkCouponDetailModelRq model)
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
                //if (await _MilkCouponDetailService.CheckCodeExistsAsync(model.Code))
                //{
                //    return BadRequest("Code Exists");
                //}
                return Ok(await _milkCouponDetailService.CreateMilkCouponDetailAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMilkCouponDetailAsync(int id)
        {
            try
            {
                await _milkCouponDetailService.DeleteMilkCouponDetailAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMilkCouponDetailAsync(int id, [FromBody]MilkCouponDetailModelRq model)
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
                return Ok(await _milkCouponDetailService.UpdateMilkCouponDetailAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}