using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Byres
{
    public class ByreModelRq
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public int BreedId { set; get; }
        public int? QuantityCow { set; get; }
        public int FarmerId { set; get; }
        public string Ration { set; get; }
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
