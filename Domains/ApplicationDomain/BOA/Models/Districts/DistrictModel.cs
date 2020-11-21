using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models
{
    public class DistrictModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }

    public class DistrictModelMapper : Profile
    {
        public DistrictModelMapper()
        {
            CreateMap<District, DistrictModel>();
        }
    }
}
