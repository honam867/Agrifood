using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Cows;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class MilkingSlipController : BaseController
    {
        private readonly IMilkingSlipService _milkingSlipService;
        public MilkingSlipController(IMilkingSlipService milkingSlipService)
        {
            _milkingSlipService = milkingSlipService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetMilkingSlipAsync()
        {
            return Ok(await _milkingSlipService.GetMilkingSlipAsync());
        }

        [Route("checkingcode/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExistsAsync(string code)
        {
            return Ok(await _milkingSlipService.CheckCodeExistsAsync(code));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMilkingSlipByIdAsync(int id)
        {
            return Ok(await _milkingSlipService.GetMilkingSlipByIdAsync(id));
        }

        [Route("{day}/{month}/{year}")]
        [HttpPost]
        public async Task<IActionResult> CreateMilkingSlipAsync([FromBody]MilkingSlipModelRq model, int day, int month, int year)
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
                
                if (await _milkingSlipService.CheckCodeExistsAsync(model.Code))
                {
                    return BadRequest("Code Exists");
                }
                return Ok(await _milkingSlipService.CreateMilkingSlipAsync(model, issuer,day,month,year));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMilkingSlipAsync(int id)
        {
            try
            {
                await _milkingSlipService.DeleteMilkingSlipAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMilkingSlipAsync(int id, [FromBody]MilkingSlipModelRq model)
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
                return Ok(await _milkingSlipService.UpdateMilkingSlipAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("newcode")]
        [HttpGet]
        public async Task<IActionResult> AutoGenerateCodeAsync()
        {
            return OkValueObject(await _milkingSlipService.AutoGenerateCodeAsync());
        }

        [Route("{date}/{month}/{year}/{session}")]
        [HttpGet]
        public async Task<IActionResult> GetMilkingSlipByDateAsync(int date, int month, int year, int session)
        {
            var issuer = GetCurrentUserIdentity<int>();
            var data = await _milkingSlipService.GetMilkingSlipByDateAsync(date, month, year, session,issuer);
            if(data != null)
            {
                return Ok(data);
            }
            else
            {
                MilkingSlipModel milkingSlipModel = new MilkingSlipModel();
                milkingSlipModel.Id = -1;
                milkingSlipModel.Code = null;
                milkingSlipModel.Session = null;
                return Ok(milkingSlipModel);
            }
        }
    }
}