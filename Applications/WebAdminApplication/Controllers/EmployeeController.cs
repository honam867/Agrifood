using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models.Employees;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAdminApplication.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeListAsync()
        {
            return Ok(await _EmployeeService.GetEmployeeListAsync());
        }

        //[Route("checkingcode/{code}")]
        //[HttpGet]
        //public async Task<IActionResult> CheckCodeExistsAsync(string code)
        //{
        //    return OkValueObject(await _EmployeeService.CheckCodeExistsAsync(code));
        //}

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            return Ok(await _EmployeeService.GetEmployeeByIdAsync(id));
        }


        [Route("newcode")]
        [HttpGet]
        public async Task<IActionResult> AutoGenerateCodeAsync()
        {
            return OkValueObject(await _EmployeeService.AutoGenerateCodeAsync());
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody]EmployeeModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                if(await _EmployeeService.CheckCodeExistsAsync(model.Code))
                {
                    return BadRequest("Code Exists");
                }
                return Ok(await _EmployeeService.CreateEmployeeAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody]EmployeeModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return Ok(await _EmployeeService.UpdateEmployeeAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DelteEmployeeAsync(int id)
        {
            try
            {
                return Ok(await _EmployeeService.DeleteEmployeeAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}