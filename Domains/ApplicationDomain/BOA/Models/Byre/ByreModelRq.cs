using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Branchs
{
    public class ByreModelRq
    {
        public int Id { get; set; }
        public string Name { get; set; } //NOT NULL, LENGTH > 5, UPPER CASE
        public string ForeignName { set; get; }
        public string ShortName { set; get; }
        public string Code { set; get; } //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
        public string Address { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Fax { set; get; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }

    public class ByreModelRqMapper : Profile
    {
        public ByreModelRqMapper()
        {
            CreateMap<ByreModelRq, Byre>();
            var mapers = CreateMap<Byre, ByreModelRq>();
        }
    }
    public class ByreModelRqValidator : AbstractValidator<ByreModelRq>
    {
        public ByreModelRqValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(3);
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }
}
