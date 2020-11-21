using ApplicationDomain.BOA.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.Models
{
    public class APIListProvinceModel
    {
        //to map with API
        public List<APIProvinceModel> LtsItem { get; set; }
    }

}
