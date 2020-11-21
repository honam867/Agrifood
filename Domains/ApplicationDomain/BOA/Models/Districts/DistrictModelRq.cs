using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models
{
    public class DistrictModelRq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int ProvinceId { get; set; }
    }

    public class DistrictModelRqMapper : Profile
    {
        public DistrictModelRqMapper()
        {
            CreateMap<DistrictModelRq, District>();
        }
    }
}
