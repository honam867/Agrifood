using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.FeedHistorys;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class FeedHistoryController : BaseController
    {
        private readonly IFeedHistoryService _feedHistoryService;
        public FeedHistoryController(IFeedHistoryService feedHistoryService)
        {
            _feedHistoryService = feedHistoryService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetFeedHistorysAsync()
        {
            return Ok(await _feedHistoryService.GetFeedHistorysAsync());
        }

        [Route("checkingcode/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExistsAsync(string code)
        {
            return Ok(await _feedHistoryService.CheckCodeExistsAsync(code));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetFeedHistoryById(int id)
        {
            return Ok(await _feedHistoryService.GetFeedHistoryByIdAsync(id));
        }

        [Route("farmer/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetFeedHistoryByFarmerIdAsync(int id)
        {
            return Ok(await _feedHistoryService.GetFeedHistoryByFarmerIdAsync(id));
        }

        [Route("{day}/{month}/{year}/{farmerid}")]
        [HttpGet]
        public async Task<IActionResult> GetFeedHistoryByDateAsync(int day, int month, int year, int farmerId)
        {
            return Ok(await _feedHistoryService.GetFeedHistoryByDateAsync(day,month,year,farmerId));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateFeedHistoryAsync([FromBody]FeedHistoryModelRq model)
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
                if (await _feedHistoryService.CheckCodeExistsAsync(model.Code))
                {
                    return BadRequest("Code Exists");
                }
                return Ok(await _feedHistoryService.CreateFeedHistoryAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFeedHistoryAsync(int id)
        {
            try
            {
                await _feedHistoryService.DeleteFeedHistoryAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateFeedHistoryAsync(int id, [FromBody]FeedHistoryModelRq model)
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
                return Ok(await _feedHistoryService.UpdateFeedHistoryAsync(id, model, issuer));
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
            return OkValueObject(await _feedHistoryService.AutoGenerateCodeAsync());
        }
    }
}