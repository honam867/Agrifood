using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAdminApplication.Controllers
{
    public class DistrictController : BaseController
    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetDistrictAsyncs()
        {
            return Ok(await _districtService.GetDistrictsAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDistrictByIdAsync(int id)
        {
            return Ok(await _districtService.GetDistrictByIdAsync(id));
        }
        [Route("provinceId/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDistricByPrivinceIdAsync(int id)
        {
            try
            {
                return Ok(await _districtService.GetDistricByPrivinceIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateDistrictAsync([FromBody]DistrictModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return Ok(await _districtService.CreateDistrictAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDistrictAsync(int id, [FromBody]DistrictModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return Ok(await _districtService.UpdateDistrictAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DelteDistrictAsync(int id)
        {
            try
            {
                return Ok(await _districtService.DeleteDistrictAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("import")]
        [HttpPost]
        public async Task<IActionResult> ImportDistrictFromAPIAsync()
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return Ok(await _districtService.ImportDistrictFromAPIAsync(issuer));
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
            return OkValueObject(await _districtService.AutoGenerateCodeAsync());
        }

        [Route("checkcodeexists/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExists(string code)
        {
            return OkValueObject(await _districtService.CheckCodeExistsAsync(code));
        }
    }
}