using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Cows;
using ApplicationDomain.BOA.Models.ImportHistorys;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class ImportHistoryController : BaseController
    {
        private readonly IImportHistoryService _importHistoryService;
        public ImportHistoryController(IImportHistoryService importHistoryService)
        {
            _importHistoryService = importHistoryService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetImportHistoryAsync()
        {
            return Ok(await _importHistoryService.GetImportHistoryAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetImportHistoryByIdAsync(int id)
        {
            return Ok(await _importHistoryService.GetImportHistoryByIdAsync(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateImportHistoryAsync([FromBody]ImportHistoryModelRq model)
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
                //if (await _ImportHistoryService.CheckCodeExistsAsync(model.Code))
                //{
                //    return BadRequest("Code Exists");
                //}
                return Ok(await _importHistoryService.CreateImportHistoryAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteImportHistoryAsync(int id)
        {
            try
            {
                await _importHistoryService.DeleteImportHistoryAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateImportHistoryAsync(int id, [FromBody]ImportHistoryModelRq model)
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
                return Ok(await _importHistoryService.UpdateImportHistoryAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}