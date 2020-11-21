using ApplicationDomain.BOA.Entities;
using AutoMapper;

namespace ApplicationDomain.BOA.Models
{
    public class ProvinceModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
    }

    public class ProvinceModelMapper : Profile
    {
        public ProvinceModelMapper()
        {
            CreateMap<Province, ProvinceModel>();
        }
    }
}
