using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;

namespace ApplicationDomain.BOA.Models
{
    public class ProvinceModelRq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
    }

    public class ProvinceModelRqMapper : Profile
    {
        public ProvinceModelRqMapper()
        {
            CreateMap<ProvinceModelRq, Province>();
        }
    }

    public class ProvinceModelRqValidator : AbstractValidator<ProvinceModelRq>
    {
        public ProvinceModelRqValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Type).NotEmpty();
        }
    }
}
