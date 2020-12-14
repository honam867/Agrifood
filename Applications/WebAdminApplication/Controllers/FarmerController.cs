using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models.Farmers;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAdminApplication.Controllers
{
    public class FarmerController : BaseController
    {
        private readonly IFarmerService _FarmerService;
        public FarmerController(IFarmerService farmerService)
        {
            _FarmerService = farmerService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetFarmerListAsync()
        {
            return Ok(await _FarmerService.GetFarmerListAsync());
        }

        //[Route("checkingcode/{code}")]
        //[HttpGet]
        //public async Task<IActionResult> CheckCodeExistsAsync(string code)
        //{
        //    return OkValueObject(await _FarmerService.CheckCodeExistsAsync(code));
        //}

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetFarmerByIdAsync(int id)
        {
            return Ok(await _FarmerService.GetFarmerByIdAsync(id));
        }


        [Route("newcode")]
        [HttpGet]
        public async Task<IActionResult> AutoGenerateCodeAsync()
        {
            return OkValueObject(await _FarmerService.AutoGenerateCodeAsync());
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateFarmerAsync([FromBody]FarmerModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                if(await _FarmerService.CheckCodeExistsAsync(model.Code))
                {
                    return BadRequest("Code Exists");
                }
                return Ok(await _FarmerService.CreateFarmerAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateFarmerAsync(int id, [FromBody]FarmerModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return Ok(await _FarmerService.UpdateFarmerAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DelteFarmerAsync(int id)
        {
            try
            {
                return Ok(await _FarmerService.DeleteFarmerAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}