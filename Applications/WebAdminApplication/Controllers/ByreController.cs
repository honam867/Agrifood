using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Byres;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class ByreController : BaseController
    {
        private readonly IByreService _byreService;
        public ByreController(IByreService byreService)
        {
            _byreService = byreService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetByresAsync()
        {
            return Ok(await _byreService.GetByresAsync());
        }

        [Route("checkingcode/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExistsAsync(string code)
        {
            return Ok(await _byreService.CheckCodeExistsAsync(code));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByreById(int id)
        {
            return Ok(await _byreService.GetByreByIdAsync(id));
        }

        [Route("farmer")]
        [HttpGet]
        public async Task<IActionResult> GetByreByFarmerId()
        {
            var issuer = GetCurrentUserIdentity<int>();
            var data = await _byreService.GetByreByFarmerId(issuer);
            if(data != null)
            {
                return Ok(data);
            } else
            {
                ByreModel byreModel = new ByreModel();
                byreModel.Id = -1;
                byreModel.Name = null;
                byreModel.QuantityCow = 0;
                byreModel.FarmerId = -1;
                return Ok(byreModel);
            }
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateByreAsync([FromBody]ByreModelRq model)
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
                if (await _byreService.CheckCodeExistsAsync(model.Code))
                {
                    return BadRequest("Code Exists");
                }
                return Ok(await _byreService.CreateByreAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteByreAsync(int id)
        {
            try
            {
                await _byreService.DeleteByreAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateByreAsync(int id, [FromBody]ByreModelRq model)
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
                return Ok(await _byreService.UpdateByreAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}