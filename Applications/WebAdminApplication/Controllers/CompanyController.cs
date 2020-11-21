using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Companys;
using AspNetCore.Mvc;
using DevExpress.Compatibility.System.Web;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Route("code")]
        [HttpGet]
        public IActionResult GetCode()
        {
            return Ok( _companyService.GetCodeAsync());
        }

        [Route("checkingcode/{code}")]
        [HttpGet]
        public async Task<IActionResult> CheckCodeExistsAsync(string code)
        {
            return OkValueObject(await _companyService.CheckCodeExistsAsync(code));
        }

        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyAsync()
        {
            return Ok(await _companyService.GetCompanyAsync());
        }

        [Route("stamptest")]
        [HttpGet]
        public IActionResult GetStamp()
        {
            try
            {
                string url = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath) + @"\Assets\stamp.jpg";
                Bitmap bm = new Bitmap(url );
                MemoryStream memoryStream = new MemoryStream();
                bm.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] byteArray = memoryStream.GetBuffer();
                Models.CompanyModel companyModel = new Models.CompanyModel()
                {
                    Stamp = byteArray,
                    StampBitmap = bm,
                    CompanyName = "Tuloc technology",
                    LocalURL = url
                };
                return Ok(companyModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetCompany()
        {
            return Ok(await _companyService.GetCompany());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            return Ok(await _companyService.GetCompanyByIdAsync(id));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateCompanyAsync([FromBody]CompanyModelRq model)
        {
            if(!ModelState.IsValid)
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
                if(await _companyService.CheckCompanyExistsAsync())
                {
                    return BadRequest("Company Exists");
                }
                return Ok(await _companyService.CreateCompanyAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> UploadLogoAsync([FromForm]CompanyUploadLogoModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return OkValueObject(await _companyService.UploadLogoAsync(model.Logo, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            try
            {
                await _companyService.DeleteCompanyAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody]CompanyModelRq model)
        {
            var issuer = GetCurrentUserIdentity<int>();
            try
            {
                return Ok(await _companyService.UpdateCompanyAsync(id, model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}