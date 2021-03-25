using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.MilkingSlips
{
    public class MilkingSlipModelRq
    {
        public string Code { get; set; }
        public int FarmerId { get; set; }
        public string Session { get; set; }
    }

    public class MilkingSlipModelRqMapper : Profile
    {
        public MilkingSlipModelRqMapper()
        {
            CreateMap<MilkingSlipModelRq, MilkingSlip>();
            var mapers = CreateMap<MilkingSlip, MilkingSlipModelRq>();
        }
    }
    public class MilkingSlipModelRqValidator : AbstractValidator<MilkingSlipModelRq>
    {
        public MilkingSlipModelRqValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }
}
