using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Foods;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class FoodController : BaseController
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetFoodsAsync()
        {
            return Ok(await _foodService.GetFoodsAsync());
        }

        [Route("province")]
        [HttpGet]
        public async Task<IActionResult> GetFoodByProvinceAsync()
        {
            var issuer = GetCurrentUserIdentity<int>();
            return Ok(await _foodService.GetFoodByProvinceAsync(issuer));
        }

        [Route("checkingcode/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExistsAsync(string code)
        {
            return Ok(await _foodService.CheckCodeExistsAsync(code));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetFoodById(int id)
        {
            return Ok(await _foodService.GetFoodByIdAsync(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateFoodAsync([FromBody]FoodModelRq model)
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
                if (await _foodService.CheckCodeExistsAsync(model.Code))
                {
                    return BadRequest("Code Exists");
                }
                return Ok(await _foodService.CreateFoodAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFoodAsync(int id)
        {
            try
            {
                await _foodService.DeleteFoodAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateFoodAsync(int id, [FromBody]FoodModelRq model)
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
                return Ok(await _foodService.UpdateFoodAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}