using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Notifys;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class NotifyController : BaseController
    {
        private readonly INotifyService _notifyService;
        public NotifyController(INotifyService notifyService)
        {
            _notifyService = notifyService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetNotifysAsync()
        {
            return Ok(await _notifyService.GetNotifysAsync());
        }

        [Route("checkingcode/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExistsAsync(string code)
        {
            return Ok(await _notifyService.CheckCodeExistsAsync(code));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetNotifyById(int id)
        {
            return Ok(await _notifyService.GetNotifyByIdAsync(id));
        }

        [Route("farmer/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetNotifyByFarmerId(int id)
        {
            return Ok(await _notifyService.GetNotifyByFarmerIdAsync(id));
        }

        [Route("employee/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetNotifyByEmployeeId(int id)
        {
            return Ok(await _notifyService.GetNotifyByEmployeeIdAsync(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateNotifyAsync([FromBody]NotifyModelRq model)
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
                return Ok(await _notifyService.CreateNotifyAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteNotifyAsync(int id)
        {
            try
            {
                
                return Ok(await _notifyService.DeleteNotifyAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateNotifyAsync(int id, [FromBody]NotifyModelRq model)
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
                return Ok(await _notifyService.UpdateNotifyAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}