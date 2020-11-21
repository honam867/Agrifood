using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Companys
{
    public class CompanyUploadLogoModelRq
    {
        public int Id { get; set; }
        public IFormFile Logo { get; set; }
    }
}
