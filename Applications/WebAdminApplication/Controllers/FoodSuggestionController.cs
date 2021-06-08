using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models.FoodSuggestions;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAdminApplication.Controllers
{
    public class FoodSuggestionController : BaseController
    {
        private readonly IFoodSuggestionService _breedService;
        public FoodSuggestionController(IFoodSuggestionService breedService)
        {
            _breedService = breedService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetFoodSuggestionsAsync()
        {
            return Ok(await _breedService.GetFoodSuggestionsAsync());
        }

        /*[Route("checkingcode/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExistsAsync(string code)
        {
            return Ok(await _breedService.CheckCodeExistsAsync(code));
        }*/

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetFoodSuggestionById(int id)
        {
            return Ok(await _breedService.GetFoodSuggestionByIdAsync(id));
        }

        [Route("province")]
        [HttpGet]
        public async Task<IActionResult> GetFoodSuggestionByProvinceIdAsync()
        {
            var issuer = GetCurrentUserIdentity<int>();
            return Ok(await _breedService.GetFoodSuggestionByProvinceIdAsync(issuer));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateFoodSuggestionAsync([FromBody]FoodSuggestionModelRq model)
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
            return Ok(await _breedService.CreateFoodSuggestionAsync(model, issuer));

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFoodSuggestionAsync(int id)
        {
            try
            {
                await _breedService.DeleteFoodSuggestionAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateFoodSuggestionAsync(int id, [FromBody]FoodSuggestionModelRq model)
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
                return Ok(await _breedService.UpdateFoodSuggestionAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("farmer")]
        [HttpGet]
        public async Task<IActionResult> GetFoodSuggestionsByFarmerIdAsync()
        {
            var issuer = GetCurrentUserIdentity<int>();
            return Ok(await _breedService.GetFoodSuggestionsByFarmerIdAsync(issuer));
        }
    }
}