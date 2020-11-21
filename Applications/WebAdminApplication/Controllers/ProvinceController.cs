using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class ProvinceController : BaseController
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetProvincesAsync()
        {
            return Ok(await _provinceService.GetListProvincesAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProvinceByIdAsync(int id)
        {
            return Ok(await _provinceService.GetProvinceByIdAsync(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateProvinceAsync([FromBody]ProvinceModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {               
                return Ok(await _provinceService.CreateProvinceAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProvinceAsync(int id, [FromBody]ProvinceModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return Ok(await _provinceService.UpdateProvinceAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DelteProvinceAsync(int id)
        {
            try
            {
                return Ok(await _provinceService.DeleteProvinceAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("import")]
        [HttpPost]
        public async Task<IActionResult> ImportProvinceFromAPIAsync()
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return Ok(await _provinceService.ImportProvinceFromAPIAsync(issuer));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("newcode")]
        [HttpGet]
        public async Task<IActionResult> AutoGenerateCodeAsync()
        {
            return OkValueObject(await _provinceService.AutoGenerateCodeAsync());
        }

        [Route("checkcodeexists/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExists(string code)
        {
            return OkValueObject(await _provinceService.CheckCodeExistsAsync(code));
        }
    }
}