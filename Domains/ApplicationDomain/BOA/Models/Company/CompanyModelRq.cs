using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;

namespace ApplicationDomain.BOA.Models.Companys
{
    public class CompanyModelRq
    {
        public int Id { set; get; }
        public string Name { set; get; } 
        public string ForeignName { set; get; }
        public string ShortName { set; get; }
        public string Code { set; get; } //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
        public string Address { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Fax { set; get; }
        public string TaxCode { set; get; }
        public string LogoURL { set; get; }
        public string StampURL { get; set; }
        public string WebsiteURL { get; set; }
        public int? RepresentativeId { get; set; }
        public string FacebookName { get; set; }
    }

    public class CompanyRqMapper : Profile
    {
        public CompanyRqMapper()
        {
            CreateMap<CompanyModelRq, Company>();
            var mapers = CreateMap<Company, CompanyModelRq>();
        }
    }

    public class CompanyModelRqValidator : AbstractValidator<CompanyModelRq>
    {
        public CompanyModelRqValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(3);
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }
}
