using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.MilkingSlipDetails
{
    public class MilkingSlipDetailModelRq
    {
        public int CowId { get; set; }
        public int MilkingSlipId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }

    public class MilkingSlipDetailModelRqMapper : Profile
    {
        public MilkingSlipDetailModelRqMapper()
        {
            CreateMap<MilkingSlipDetailModelRq, MilkingSlipDetail>();
            var mapers = CreateMap<MilkingSlipDetail, MilkingSlipDetailModelRq>();
        }
    }
    public class MilkingSlipDetailModelRqValidator : AbstractValidator<MilkingSlipDetailModelRq>
    {
        public MilkingSlipDetailModelRqValidator()
        {
            
        }
    }
}
