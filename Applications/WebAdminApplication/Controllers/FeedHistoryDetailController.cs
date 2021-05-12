using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.FeedHistoryDetails;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class FeedHistoryDetailController : BaseController
    {
        private readonly IFeedHistoryDetailService _feedHistoryDetailService;
        public FeedHistoryDetailController(IFeedHistoryDetailService feedHistoryDetailService)
        {
            _feedHistoryDetailService = feedHistoryDetailService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetFeedHistoryDetailsAsync()
        {
            return Ok(await _feedHistoryDetailService.GetFeedHistoryDetailsAsync());
        }

        [Route("feedhistory/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetFeedHistoryDetailByFeedHistoryIdAsync(int id)
        {
            return Ok(await _feedHistoryDetailService.GetFeedHistoryDetailByFeedHistoryIdAsync(id));
        }

        [Route("checkingcode/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExistsAsync(string code)
        {
            return Ok(await _feedHistoryDetailService.CheckCodeExistsAsync(code));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetFeedHistoryDetailById(int id)
        {
            return Ok(await _feedHistoryDetailService.GetFeedHistoryDetailByIdAsync(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateFeedHistoryDetailAsync([FromBody]FeedHistoryDetailModelRq model)
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
                if (await _feedHistoryDetailService.CheckCodeExistsAsync(model.Code))
                {
                    return BadRequest("Code Exists");
                }
                return Ok(await _feedHistoryDetailService.CreateFeedHistoryDetailAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFeedHistoryDetailAsync(int id)
        {
            try
            {
                await _feedHistoryDetailService.DeleteFeedHistoryDetailAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateFeedHistoryDetailAsync(int id, [FromBody]FeedHistoryDetailModelRq model)
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
                return Ok(await _feedHistoryDetailService.UpdateFeedHistoryDetailAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}